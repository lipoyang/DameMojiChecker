namespace DameMojiChecker
{
    partial class FormMain
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkSubFolder = new System.Windows.Forms.CheckBox();
            this.buttonCheck = new System.Windows.Forms.Button();
            this.textPath = new System.Windows.Forms.TextBox();
            this.buttonRefer = new System.Windows.Forms.Button();
            this.textFileName = new System.Windows.Forms.TextBox();
            this.textResult = new System.Windows.Forms.TextBox();
            this.buttonCopy = new System.Windows.Forms.Button();
            this.radioOnlyEOL = new System.Windows.Forms.RadioButton();
            this.radioFullLine = new System.Windows.Forms.RadioButton();
            this.labelStatus = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "対象フォルダ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "対象ファイル";
            // 
            // checkSubFolder
            // 
            this.checkSubFolder.AutoSize = true;
            this.checkSubFolder.Location = new System.Drawing.Point(12, 65);
            this.checkSubFolder.Name = "checkSubFolder";
            this.checkSubFolder.Size = new System.Drawing.Size(111, 16);
            this.checkSubFolder.TabIndex = 2;
            this.checkSubFolder.Text = "サブフォルダも検索";
            this.checkSubFolder.UseVisualStyleBackColor = true;
            // 
            // buttonCheck
            // 
            this.buttonCheck.Location = new System.Drawing.Point(487, 75);
            this.buttonCheck.Name = "buttonCheck";
            this.buttonCheck.Size = new System.Drawing.Size(75, 23);
            this.buttonCheck.TabIndex = 3;
            this.buttonCheck.Text = "チェック";
            this.buttonCheck.UseVisualStyleBackColor = true;
            this.buttonCheck.Click += new System.EventHandler(this.buttonCheck_Click);
            // 
            // textPath
            // 
            this.textPath.Location = new System.Drawing.Point(82, 6);
            this.textPath.Name = "textPath";
            this.textPath.Size = new System.Drawing.Size(480, 19);
            this.textPath.TabIndex = 4;
            // 
            // buttonRefer
            // 
            this.buttonRefer.Location = new System.Drawing.Point(487, 33);
            this.buttonRefer.Name = "buttonRefer";
            this.buttonRefer.Size = new System.Drawing.Size(75, 23);
            this.buttonRefer.TabIndex = 5;
            this.buttonRefer.Text = "参照";
            this.buttonRefer.UseVisualStyleBackColor = true;
            this.buttonRefer.Click += new System.EventHandler(this.buttonRefer_Click);
            // 
            // textFileName
            // 
            this.textFileName.Location = new System.Drawing.Point(82, 35);
            this.textFileName.Name = "textFileName";
            this.textFileName.Size = new System.Drawing.Size(211, 19);
            this.textFileName.TabIndex = 6;
            // 
            // textResult
            // 
            this.textResult.Location = new System.Drawing.Point(12, 104);
            this.textResult.Multiline = true;
            this.textResult.Name = "textResult";
            this.textResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textResult.Size = new System.Drawing.Size(550, 294);
            this.textResult.TabIndex = 7;
            // 
            // buttonCopy
            // 
            this.buttonCopy.Location = new System.Drawing.Point(487, 406);
            this.buttonCopy.Name = "buttonCopy";
            this.buttonCopy.Size = new System.Drawing.Size(75, 23);
            this.buttonCopy.TabIndex = 8;
            this.buttonCopy.Text = "結果をコピー";
            this.buttonCopy.UseVisualStyleBackColor = true;
            this.buttonCopy.Click += new System.EventHandler(this.buttonCopy_Click);
            // 
            // radioOnlyEOL
            // 
            this.radioOnlyEOL.AutoSize = true;
            this.radioOnlyEOL.Checked = true;
            this.radioOnlyEOL.Location = new System.Drawing.Point(263, 78);
            this.radioOnlyEOL.Name = "radioOnlyEOL";
            this.radioOnlyEOL.Size = new System.Drawing.Size(99, 16);
            this.radioOnlyEOL.TabIndex = 9;
            this.radioOnlyEOL.TabStop = true;
            this.radioOnlyEOL.Text = "行末のみチェック";
            this.radioOnlyEOL.UseVisualStyleBackColor = true;
            // 
            // radioFullLine
            // 
            this.radioFullLine.AutoSize = true;
            this.radioFullLine.Location = new System.Drawing.Point(380, 78);
            this.radioFullLine.Name = "radioFullLine";
            this.radioFullLine.Size = new System.Drawing.Size(87, 16);
            this.radioFullLine.TabIndex = 10;
            this.radioFullLine.Text = "行中もチェック";
            this.radioFullLine.UseVisualStyleBackColor = true;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(12, 432);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(74, 12);
            this.labelStatus.TabIndex = 11;
            this.labelStatus.Text = "ステータス表示";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(392, 406);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 12;
            this.buttonCancel.Text = "中断";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 454);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.radioFullLine);
            this.Controls.Add(this.radioOnlyEOL);
            this.Controls.Add(this.buttonCopy);
            this.Controls.Add(this.textResult);
            this.Controls.Add(this.textFileName);
            this.Controls.Add(this.buttonRefer);
            this.Controls.Add(this.textPath);
            this.Controls.Add(this.buttonCheck);
            this.Controls.Add(this.checkSubFolder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "ダメ文字チェッカー";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkSubFolder;
        private System.Windows.Forms.Button buttonCheck;
        private System.Windows.Forms.TextBox textPath;
        private System.Windows.Forms.Button buttonRefer;
        private System.Windows.Forms.TextBox textFileName;
        private System.Windows.Forms.TextBox textResult;
        private System.Windows.Forms.Button buttonCopy;
        private System.Windows.Forms.RadioButton radioOnlyEOL;
        private System.Windows.Forms.RadioButton radioFullLine;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button buttonCancel;
    }
}

