namespace UserApp
{
    partial class Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calibrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setUZPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreFactorySettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.signalAnalyzerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showBITErrorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Verification = new System.Windows.Forms.Button();
            this.Calibration = new System.Windows.Forms.Button();
            this.Parameters = new System.Windows.Forms.Button();
            this.Reset = new System.Windows.Forms.Button();
            this.counts_show = new System.Windows.Forms.Label();
            this.Position_show = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.calibrationToolStripMenuItem,
            this.toolToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(907, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 21);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.openToolStripMenuItem.Text = "Save Parameters";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.closeToolStripMenuItem.Text = "Exit";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // calibrationToolStripMenuItem
            // 
            this.calibrationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setUZPToolStripMenuItem,
            this.restoreFactorySettingsToolStripMenuItem});
            this.calibrationToolStripMenuItem.Name = "calibrationToolStripMenuItem";
            this.calibrationToolStripMenuItem.Size = new System.Drawing.Size(53, 21);
            this.calibrationToolStripMenuItem.Text = "Setup";
            // 
            // setUZPToolStripMenuItem
            // 
            this.setUZPToolStripMenuItem.Name = "setUZPToolStripMenuItem";
            this.setUZPToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.setUZPToolStripMenuItem.Text = "Zero Position";
            this.setUZPToolStripMenuItem.Click += new System.EventHandler(this.setUZPToolStripMenuItem_Click);
            // 
            // restoreFactorySettingsToolStripMenuItem
            // 
            this.restoreFactorySettingsToolStripMenuItem.Name = "restoreFactorySettingsToolStripMenuItem";
            this.restoreFactorySettingsToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.restoreFactorySettingsToolStripMenuItem.Text = "Restore factory settings";
            this.restoreFactorySettingsToolStripMenuItem.Click += new System.EventHandler(this.restoreFactorySettingsToolStripMenuItem_Click);
            // 
            // toolToolStripMenuItem
            // 
            this.toolToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.signalAnalyzerToolStripMenuItem,
            this.showBITErrorsToolStripMenuItem});
            this.toolToolStripMenuItem.Name = "toolToolStripMenuItem";
            this.toolToolStripMenuItem.Size = new System.Drawing.Size(64, 21);
            this.toolToolStripMenuItem.Text = "Analyse";
            // 
            // signalAnalyzerToolStripMenuItem
            // 
            this.signalAnalyzerToolStripMenuItem.Name = "signalAnalyzerToolStripMenuItem";
            this.signalAnalyzerToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.signalAnalyzerToolStripMenuItem.Text = "Signal analyzer";
            // 
            // showBITErrorsToolStripMenuItem
            // 
            this.showBITErrorsToolStripMenuItem.Name = "showBITErrorsToolStripMenuItem";
            this.showBITErrorsToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.showBITErrorsToolStripMenuItem.Text = "BIT Error";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.supportToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(47, 21);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // supportToolStripMenuItem
            // 
            this.supportToolStripMenuItem.Name = "supportToolStripMenuItem";
            this.supportToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.supportToolStripMenuItem.Text = "Support";
            this.supportToolStripMenuItem.Click += new System.EventHandler(this.supportToolStripMenuItem_Click);
            // 
            // Verification
            // 
            this.Verification.Location = new System.Drawing.Point(25, 48);
            this.Verification.Name = "Verification";
            this.Verification.Size = new System.Drawing.Size(113, 48);
            this.Verification.TabIndex = 1;
            this.Verification.Text = "Verification";
            this.Verification.UseVisualStyleBackColor = true;
            this.Verification.Click += new System.EventHandler(this.Verification_Click);
            // 
            // Calibration
            // 
            this.Calibration.Location = new System.Drawing.Point(25, 123);
            this.Calibration.Name = "Calibration";
            this.Calibration.Size = new System.Drawing.Size(113, 48);
            this.Calibration.TabIndex = 1;
            this.Calibration.Text = "Calibration\r\n";
            this.Calibration.UseVisualStyleBackColor = true;
            this.Calibration.Click += new System.EventHandler(this.Calibration_Click);
            // 
            // Parameters
            // 
            this.Parameters.Location = new System.Drawing.Point(25, 197);
            this.Parameters.Name = "Parameters";
            this.Parameters.Size = new System.Drawing.Size(113, 48);
            this.Parameters.TabIndex = 1;
            this.Parameters.Text = "Parameters";
            this.Parameters.UseVisualStyleBackColor = true;
            this.Parameters.Click += new System.EventHandler(this.Parameters_Click);
            // 
            // Reset
            // 
            this.Reset.Location = new System.Drawing.Point(681, 153);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(113, 48);
            this.Reset.TabIndex = 1;
            this.Reset.Text = "Reset";
            this.Reset.UseVisualStyleBackColor = true;
            this.Reset.Click += new System.EventHandler(this.Reset_Click);
            // 
            // counts_show
            // 
            this.counts_show.AutoSize = true;
            this.counts_show.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.counts_show.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.counts_show.Location = new System.Drawing.Point(402, 452);
            this.counts_show.Name = "counts_show";
            this.counts_show.Size = new System.Drawing.Size(81, 17);
            this.counts_show.TabIndex = 2;
            this.counts_show.Text = "counts_show";
            // 
            // Position_show
            // 
            this.Position_show.AutoSize = true;
            this.Position_show.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Position_show.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Position_show.Location = new System.Drawing.Point(402, 426);
            this.Position_show.Name = "Position_show";
            this.Position_show.Size = new System.Drawing.Size(90, 17);
            this.Position_show.TabIndex = 2;
            this.Position_show.Text = "Position_Show";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(522, 426);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Position [degrees]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(522, 457);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "[counts]";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::UserApp.Properties.Resources.indicator;
            this.pictureBox1.InitialImage = global::UserApp.Properties.Resources.indicator;
            this.pictureBox1.Location = new System.Drawing.Point(246, 48);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(391, 334);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(104, 426);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(907, 565);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Position_show);
            this.Controls.Add(this.counts_show);
            this.Controls.Add(this.Reset);
            this.Controls.Add(this.Parameters);
            this.Controls.Add(this.Calibration);
            this.Controls.Add(this.Verification);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "UserApp";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calibrationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Button Verification;
        private System.Windows.Forms.Button Calibration;
        private System.Windows.Forms.Button Parameters;
        private System.Windows.Forms.Button Reset;
        private System.Windows.Forms.Label counts_show;
        private System.Windows.Forms.Label Position_show;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem setUZPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restoreFactorySettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem signalAnalyzerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showBITErrorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supportToolStripMenuItem;
        private System.Windows.Forms.Button button1;
    }
}

