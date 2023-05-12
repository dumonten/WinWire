namespace WinWire.App.Forms.CaptureInformation
{
    partial class FrmCaptureInfo
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.comboBuffer = new System.Windows.Forms.ComboBox();
            this.lblBuffer = new System.Windows.Forms.Label();
            this.comboIp = new System.Windows.Forms.ComboBox();
            this.lblIp = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.comboBuffer);
            this.groupBox.Controls.Add(this.lblBuffer);
            this.groupBox.Controls.Add(this.comboIp);
            this.groupBox.Controls.Add(this.lblIp);
            this.groupBox.Location = new System.Drawing.Point(2, 12);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(282, 165);
            this.groupBox.TabIndex = 2;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Параметры захвата:";
            // 
            // comboBuffer
            // 
            this.comboBuffer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBuffer.FormattingEnabled = true;
            this.comboBuffer.Location = new System.Drawing.Point(11, 99);
            this.comboBuffer.Name = "comboBuffer";
            this.comboBuffer.Size = new System.Drawing.Size(262, 21);
            this.comboBuffer.TabIndex = 3;
            // 
            // lblBuffer
            // 
            this.lblBuffer.AutoSize = true;
            this.lblBuffer.Location = new System.Drawing.Point(8, 82);
            this.lblBuffer.Name = "lblBuffer";
            this.lblBuffer.Size = new System.Drawing.Size(215, 13);
            this.lblBuffer.TabIndex = 2;
            this.lblBuffer.Text = "Выберите размер буферизации пакетов:";
            // 
            // comboIp
            // 
            this.comboIp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboIp.FormattingEnabled = true;
            this.comboIp.Location = new System.Drawing.Point(11, 46);
            this.comboIp.Name = "comboIp";
            this.comboIp.Size = new System.Drawing.Size(262, 21);
            this.comboIp.TabIndex = 1;
            // 
            // lblIp
            // 
            this.lblIp.AutoSize = true;
            this.lblIp.Location = new System.Drawing.Point(8, 30);
            this.lblIp.Name = "lblIp";
            this.lblIp.Size = new System.Drawing.Size(149, 13);
            this.lblIp.TabIndex = 0;
            this.lblIp.Text = "Выберите IP адрес захвата:";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(209, 183);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Начать";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // FrmCaptureInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 212);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.btnStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmCaptureInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.ComboBox comboBuffer;
        private System.Windows.Forms.Label lblBuffer;
        private System.Windows.Forms.ComboBox comboIp;
        private System.Windows.Forms.Label lblIp;
        private System.Windows.Forms.Button btnStart;
    }
}