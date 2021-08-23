using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; // Directoryなど
using System.Threading; // CancellationTokenSource
using IniFileSharp;

namespace DameMojiChecker
{
    public partial class FormMain : Form
    {
        IniFile iniFile;
        CancellationTokenSource tokenSource;

        string m_path;      // 対象フォルダ
        string m_filename;  // 対象ファイル
        bool m_sub_folder;  // サブフォルダも検索か
        bool m_only_eol;    // 行末のみチェックか

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            iniFile = new IniFile();
            textPath.Text          = iniFile.ReadString("PATH", "FOLDER", "");
            textFileName.Text      = iniFile.ReadString("PATH", "FILENAME", "*.c *.h");
            checkSubFolder.Checked = iniFile.ReadBoolean("CONDITIONS", "SUB_FOLDER", false);
            radioOnlyEOL.Checked   = iniFile.ReadBoolean("CONDITIONS", "ONLY_EOL"  , true);
            radioFullLine.Checked = !radioOnlyEOL.Checked;
            labelStatus.Text = "";
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            iniFile.WriteString("PATH", "FOLDER", textPath.Text);
            iniFile.WriteString("PATH", "FILENAME", textFileName.Text);
            iniFile.WriteBoolean("CONDITIONS", "SUB_FOLDER", checkSubFolder.Checked);
            iniFile.WriteBoolean("CONDITIONS", "ONLY_EOL", radioOnlyEOL.Checked);
        }

        private void buttonRefer_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "フォルダを指定してください。";
            fbd.RootFolder = Environment.SpecialFolder.Desktop;
            fbd.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            fbd.ShowNewFolderButton = false;
            if (fbd.ShowDialog(this) == DialogResult.OK)
            {
                textPath.Text = fbd.SelectedPath;
            }
        }

        private async void buttonCheck_Click(object sender, EventArgs e)
        {
            m_path = textPath.Text;
            m_filename = textFileName.Text;
            m_sub_folder = checkSubFolder.Checked;
            m_only_eol = radioOnlyEOL.Checked;

            textPath.Enabled = false;
            textFileName.Enabled = false;
            checkSubFolder.Enabled = false;
            radioOnlyEOL.Enabled = false;
            radioFullLine.Enabled = false;
            buttonCheck.Enabled = false;
            buttonCopy.Enabled = false;
            buttonRefer.Enabled = false;
            labelStatus.Text = "";

            textResult.Text = "";

            tokenSource = new CancellationTokenSource();
            Task task = Task.Run(() => checkDameMoji(tokenSource.Token));
            await task;

            textPath.Enabled = true;
            textFileName.Enabled = true;
            checkSubFolder.Enabled = true;
            radioOnlyEOL.Enabled = true;
            radioFullLine.Enabled = true;
            buttonCheck.Enabled = true;
            buttonCopy.Enabled = true;
            buttonRefer.Enabled = true;
            labelStatus.Text = "";
        }

        private void buttonCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textResult.Text);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            tokenSource.Cancel();
        }

        // ダメ文字チェック処理
        private void checkDameMoji(CancellationToken token)
        {
            // 条件に一致するファイルを検索して列挙
            SearchOption option = m_sub_folder ?
                SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;

            string[] patterns = m_filename.Split(' ');
            string[] matched_files = new string[0];
            try
            {
                foreach (string pattern in patterns)
                {
                    string[] matched = Directory.GetFiles(m_path, pattern, option);
                    if (matched.Length > 0)
                    {
                        matched_files = matched_files.Concat(matched).ToArray();
                    }
                }
            }
            catch (Exception ex)
            {
                addMessageLine(ex.Message);
                return;
            }
            if (matched_files.Length == 0)
            {
                addMessageLine("条件に一致するファイルがありません。");
                return;
            }
            addMessageLine(matched_files.Length.ToString() +
                "件のファイルをチェックします..." + Environment.NewLine);

            // 各々のファイルについて
            int dame_chars = 0;
            int dame_files = 0;
            foreach (string path in matched_files)
            {
                string filename = path.Replace(m_path + "\\", "");
                this.Invoke((Action)(() => {
                    labelStatus.Text = "処理中 " + filename;
                }));

                // 1行ずつ読み込む
                int line_no = 0;
                bool has_dame_moji = false;
                Encoding encoding = Encoding.GetEncoding(932); // 932 = Shift-JIS
                StreamReader sr = new StreamReader(path, encoding);
                Encoder encoder = encoding.GetEncoder();
                string messages = "";
                while (sr.Peek() > -1)
                {
                    // キャンセルされた場合
                    if (token.IsCancellationRequested)
                    {
                        addMessageLine(Environment.NewLine+ "中断されました。");
                        sr.Close();
                        return;
                    }

                    line_no++;
                    string line = sr.ReadLine();
                    char[] chars = line.ToCharArray();
                    byte[] bytes = new byte[2];

                    // 空行チェック
                    if (chars.Length == 0) continue;

                    // 行末のみチェックか行中もチェックか
                    int start = m_only_eol ? chars.Length - 1 : 0;

                    // 1文字ずつ判定
                    for (int i = start; i < chars.Length; i++)
                    {
                        // 2バイト目が 0x5C (='\') であればダメ文字
                        int len = encoder.GetBytes(chars, i, 1, bytes, 0, false);
                        if (len == 2 && bytes[1] == 0x5C)
                        {
                            dame_chars++;
                            has_dame_moji = true;
                            string info = filename + " : " + line_no + "行目 : " + chars[i];
                            if (i == chars.Length - 1){
                                messages += "行末 : " + info + Environment.NewLine;
                            }else{
                                messages += "行中 : " + info + Environment.NewLine;
                            }
                        }
                    }
                }
                if (has_dame_moji)
                {
                    dame_files++;
                    addMessageText(messages);
                }
                sr.Close();
            }
            if (dame_files == 0)
            {
                addMessageLine("ダメ文字は検出されませんでした。");
            }
            else
            {
                addMessageLine(Environment.NewLine + dame_files.ToString() +
                    "件のファイルでダメ文字が検出されました。");
                addMessageLine("トータルで" + dame_chars.ToString() +
                    "個のダメ文字が検出されました。");
            }
        }

        // メッセージ表示
        private void addMessageText(string text)
        {
            this.Invoke((Action)(() => {
                textResult.AppendText(text);
            }));
        }

        // メッセージ表示(改行する)
        private void addMessageLine(string line)
        {
            addMessageText(line + Environment.NewLine);
        }
    }
}
