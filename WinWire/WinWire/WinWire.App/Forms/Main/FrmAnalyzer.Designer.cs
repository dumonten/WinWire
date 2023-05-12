namespace WinWire.App.Forms.Main
{
    partial class FrmAnalyzer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAnalyzer));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topMostMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataAboutPacketMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.darkThemeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tbtnStart = new System.Windows.Forms.ToolStripButton();
            this.tbtnStop = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtnClearAll = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStripReady = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lstReceivedPackets = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.packetByteRepresentation = new System.Windows.Forms.TextBox();
            this.packetChunkNum = new System.Windows.Forms.TextBox();
            this.packetCharRepresentation = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.treePacketDetails = new System.Windows.Forms.TreeView();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.lblTextBufferUsage = new System.Windows.Forms.Label();
            this.progressBufferUsage = new System.Windows.Forms.ProgressBar();
            this.lbTextlTotalPkgsReceived = new System.Windows.Forms.Label();
            this.lblTotalPkgsReceived = new System.Windows.Forms.Label();
            this.lblBufferUsage = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.bpfField = new System.Windows.Forms.TextBox();
            this.tbtnFilterOn = new System.Windows.Forms.Button();
            this.menuStrip.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuItem,
            this.viewMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(974, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileMenuItem
            // 
            this.fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeMenuItem});
            this.fileMenuItem.Name = "fileMenuItem";
            this.fileMenuItem.Size = new System.Drawing.Size(48, 20);
            this.fileMenuItem.Text = "&Файл";
            // 
            // closeMenuItem
            // 
            this.closeMenuItem.Name = "closeMenuItem";
            this.closeMenuItem.Size = new System.Drawing.Size(120, 22);
            this.closeMenuItem.Text = "&Закрыть";
            this.closeMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // viewMenuItem
            // 
            this.viewMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.topMostMenuItem,
            this.dataAboutPacketMenuItem,
            this.darkThemeMenuItem});
            this.viewMenuItem.Name = "viewMenuItem";
            this.viewMenuItem.Size = new System.Drawing.Size(76, 20);
            this.viewMenuItem.Text = "&Просмотр";
            // 
            // topMostMenuItem
            // 
            this.topMostMenuItem.Name = "topMostMenuItem";
            this.topMostMenuItem.Size = new System.Drawing.Size(261, 22);
            this.topMostMenuItem.Text = "Режим поверх приложений";
            this.topMostMenuItem.Click += new System.EventHandler(this.topMostMenuItem_Click);
            // 
            // dataAboutPacketMenuItem
            // 
            this.dataAboutPacketMenuItem.Name = "dataAboutPacketMenuItem";
            this.dataAboutPacketMenuItem.Size = new System.Drawing.Size(261, 22);
            this.dataAboutPacketMenuItem.Text = "Отображать байты данных пакета";
            this.dataAboutPacketMenuItem.Click += new System.EventHandler(this.dataAboutPacketMenuItem_Click);
            // 
            // darkThemeMenuItem
            // 
            this.darkThemeMenuItem.Name = "darkThemeMenuItem";
            this.darkThemeMenuItem.Size = new System.Drawing.Size(261, 22);
            this.darkThemeMenuItem.Text = "Темная тема";
            this.darkThemeMenuItem.Click += new System.EventHandler(this.darkThemeMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbtnStart,
            this.tbtnStop,
            this.toolStripSeparator1,
            this.tbtnClearAll});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.MinimumSize = new System.Drawing.Size(0, 30);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(974, 30);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tbtnStart
            // 
            this.tbtnStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnStart.Image = ((System.Drawing.Image)(resources.GetObject("tbtnStart.Image")));
            this.tbtnStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnStart.Name = "tbtnStart";
            this.tbtnStart.Size = new System.Drawing.Size(23, 27);
            this.tbtnStart.Text = "Start";
            this.tbtnStart.Click += new System.EventHandler(this.tbtnStart_Click);
            // 
            // tbtnStop
            // 
            this.tbtnStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnStop.Image = ((System.Drawing.Image)(resources.GetObject("tbtnStop.Image")));
            this.tbtnStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnStop.Name = "tbtnStop";
            this.tbtnStop.Size = new System.Drawing.Size(23, 27);
            this.tbtnStop.Text = "Stop";
            this.tbtnStop.Click += new System.EventHandler(this.tbtnStop_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 30);
            // 
            // tbtnClearAll
            // 
            this.tbtnClearAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnClearAll.Image = ((System.Drawing.Image)(resources.GetObject("tbtnClearAll.Image")));
            this.tbtnClearAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnClearAll.Name = "tbtnClearAll";
            this.tbtnClearAll.Size = new System.Drawing.Size(23, 27);
            this.tbtnClearAll.Text = "Clear All";
            this.tbtnClearAll.Click += new System.EventHandler(this.tbtnClearAll_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStripReady});
            this.statusStrip.Location = new System.Drawing.Point(0, 585);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(974, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip1";
            // 
            // lblStripReady
            // 
            this.lblStripReady.Margin = new System.Windows.Forms.Padding(0, 3, 1, 2);
            this.lblStripReady.Name = "lblStripReady";
            this.lblStripReady.Size = new System.Drawing.Size(39, 17);
            this.lblStripReady.Text = "Ready";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 16);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lstReceivedPackets);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Window;
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(968, 510);
            this.splitContainer1.SplitterDistance = 256;
            this.splitContainer1.TabIndex = 0;
            // 
            // lstReceivedPackets
            // 
            this.lstReceivedPackets.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.lstReceivedPackets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstReceivedPackets.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lstReceivedPackets.FullRowSelect = true;
            this.lstReceivedPackets.GridLines = true;
            this.lstReceivedPackets.HideSelection = false;
            this.lstReceivedPackets.Location = new System.Drawing.Point(0, 0);
            this.lstReceivedPackets.Name = "lstReceivedPackets";
            this.lstReceivedPackets.Size = new System.Drawing.Size(966, 254);
            this.lstReceivedPackets.TabIndex = 0;
            this.lstReceivedPackets.UseCompatibleStateImageBehavior = false;
            this.lstReceivedPackets.View = System.Windows.Forms.View.Details;
            this.lstReceivedPackets.SelectedIndexChanged += new System.EventHandler(this.lstReceivedPackets_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "No.";
            this.columnHeader1.Width = 70;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Time";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Source";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Source Port";
            this.columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Destination";
            this.columnHeader5.Width = 100;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Destination Port";
            this.columnHeader6.Width = 100;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Protocol";
            this.columnHeader7.Width = 100;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Package Size";
            this.columnHeader8.Width = 100;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel.Controls.Add(this.packetByteRepresentation, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.packetChunkNum, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.packetCharRepresentation, 2, 0);
            this.tableLayoutPanel.Location = new System.Drawing.Point(313, -1);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(654, 249);
            this.tableLayoutPanel.TabIndex = 1;
            // 
            // packetByteRepresentation
            // 
            this.packetByteRepresentation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.packetByteRepresentation.Location = new System.Drawing.Point(133, 3);
            this.packetByteRepresentation.Multiline = true;
            this.packetByteRepresentation.Name = "packetByteRepresentation";
            this.packetByteRepresentation.ReadOnly = true;
            this.packetByteRepresentation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.packetByteRepresentation.Size = new System.Drawing.Size(255, 243);
            this.packetByteRepresentation.TabIndex = 1;
            this.packetByteRepresentation.WordWrap = false;
            // 
            // packetChunkNum
            // 
            this.packetChunkNum.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.packetChunkNum.Location = new System.Drawing.Point(3, 3);
            this.packetChunkNum.Multiline = true;
            this.packetChunkNum.Name = "packetChunkNum";
            this.packetChunkNum.ReadOnly = true;
            this.packetChunkNum.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.packetChunkNum.Size = new System.Drawing.Size(124, 243);
            this.packetChunkNum.TabIndex = 0;
            // 
            // packetCharRepresentation
            // 
            this.packetCharRepresentation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.packetCharRepresentation.Location = new System.Drawing.Point(394, 3);
            this.packetCharRepresentation.Multiline = true;
            this.packetCharRepresentation.Name = "packetCharRepresentation";
            this.packetCharRepresentation.ReadOnly = true;
            this.packetCharRepresentation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.packetCharRepresentation.Size = new System.Drawing.Size(257, 243);
            this.packetCharRepresentation.TabIndex = 2;
            this.packetCharRepresentation.WordWrap = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.treePacketDetails);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(313, 248);
            this.panel1.TabIndex = 0;
            // 
            // treePacketDetails
            // 
            this.treePacketDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treePacketDetails.Location = new System.Drawing.Point(0, 0);
            this.treePacketDetails.Name = "treePacketDetails";
            this.treePacketDetails.Size = new System.Drawing.Size(313, 248);
            this.treePacketDetails.TabIndex = 0;
            // 
            // groupBox
            // 
            this.groupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox.Controls.Add(this.splitContainer1);
            this.groupBox.Location = new System.Drawing.Point(0, 53);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(974, 529);
            this.groupBox.TabIndex = 3;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Анализатор пакетов:";
            // 
            // lblTextBufferUsage
            // 
            this.lblTextBufferUsage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTextBufferUsage.AutoSize = true;
            this.lblTextBufferUsage.Location = new System.Drawing.Point(682, 590);
            this.lblTextBufferUsage.Name = "lblTextBufferUsage";
            this.lblTextBufferUsage.Size = new System.Drawing.Size(70, 13);
            this.lblTextBufferUsage.TabIndex = 4;
            this.lblTextBufferUsage.Text = "Buffer usage:";
            // 
            // progressBufferUsage
            // 
            this.progressBufferUsage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBufferUsage.BackColor = System.Drawing.SystemColors.Control;
            this.progressBufferUsage.Location = new System.Drawing.Point(753, 587);
            this.progressBufferUsage.Name = "progressBufferUsage";
            this.progressBufferUsage.Size = new System.Drawing.Size(127, 18);
            this.progressBufferUsage.TabIndex = 5;
            // 
            // lbTextlTotalPkgsReceived
            // 
            this.lbTextlTotalPkgsReceived.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTextlTotalPkgsReceived.AutoSize = true;
            this.lbTextlTotalPkgsReceived.Location = new System.Drawing.Point(504, 590);
            this.lbTextlTotalPkgsReceived.Name = "lbTextlTotalPkgsReceived";
            this.lbTextlTotalPkgsReceived.Size = new System.Drawing.Size(93, 13);
            this.lbTextlTotalPkgsReceived.TabIndex = 6;
            this.lbTextlTotalPkgsReceived.Text = "Packets received:";
            // 
            // lblTotalPkgsReceived
            // 
            this.lblTotalPkgsReceived.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalPkgsReceived.AutoSize = true;
            this.lblTotalPkgsReceived.Location = new System.Drawing.Point(598, 590);
            this.lblTotalPkgsReceived.Name = "lblTotalPkgsReceived";
            this.lblTotalPkgsReceived.Size = new System.Drawing.Size(13, 13);
            this.lblTotalPkgsReceived.TabIndex = 7;
            this.lblTotalPkgsReceived.Text = "0";
            // 
            // lblBufferUsage
            // 
            this.lblBufferUsage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBufferUsage.AutoSize = true;
            this.lblBufferUsage.Location = new System.Drawing.Point(883, 590);
            this.lblBufferUsage.Name = "lblBufferUsage";
            this.lblBufferUsage.Size = new System.Drawing.Size(13, 13);
            this.lblBufferUsage.TabIndex = 8;
            this.lblBufferUsage.Text = "0";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // bpfField
            // 
            this.bpfField.BackColor = System.Drawing.SystemColors.Window;
            this.bpfField.Location = new System.Drawing.Point(97, 27);
            this.bpfField.Name = "bpfField";
            this.bpfField.Size = new System.Drawing.Size(799, 20);
            this.bpfField.TabIndex = 9;
            this.bpfField.TextChanged += new System.EventHandler(this.bpfField_TextChanged);
            // 
            // tbtnFilterOn
            // 
            this.tbtnFilterOn.BackColor = System.Drawing.Color.White;
            this.tbtnFilterOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbtnFilterOn.Image = ((System.Drawing.Image)(resources.GetObject("tbtnFilterOn.Image")));
            this.tbtnFilterOn.Location = new System.Drawing.Point(895, 26);
            this.tbtnFilterOn.Name = "tbtnFilterOn";
            this.tbtnFilterOn.Size = new System.Drawing.Size(75, 22);
            this.tbtnFilterOn.TabIndex = 10;
            this.tbtnFilterOn.Text = "⮕";
            this.tbtnFilterOn.UseVisualStyleBackColor = false;
            this.tbtnFilterOn.Click += new System.EventHandler(this.tbtnFilterOn_Click);
            // 
            // FrmAnalyzer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 607);
            this.Controls.Add(this.tbtnFilterOn);
            this.Controls.Add(this.bpfField);
            this.Controls.Add(this.lblBufferUsage);
            this.Controls.Add(this.lblTotalPkgsReceived);
            this.Controls.Add(this.lbTextlTotalPkgsReceived);
            this.Controls.Add(this.progressBufferUsage);
            this.Controls.Add(this.lblTextBufferUsage);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FrmAnalyzer";
            this.Text = "WinWire";
            this.Load += new System.EventHandler(this.FrmAnalyzer_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripButton tbtnStart;
        private System.Windows.Forms.ToolStripButton tbtnStop;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView lstReceivedPackets;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.TreeView treePacketDetails;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.ToolStripStatusLabel lblStripReady;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tbtnClearAll;
        private System.Windows.Forms.ToolStripMenuItem closeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewMenuItem;
        private System.Windows.Forms.ToolStripMenuItem topMostMenuItem;
        private System.Windows.Forms.Label lblTextBufferUsage;
        private System.Windows.Forms.ProgressBar progressBufferUsage;
        private System.Windows.Forms.Label lbTextlTotalPkgsReceived;
        private System.Windows.Forms.Label lblTotalPkgsReceived;
        private System.Windows.Forms.Label lblBufferUsage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem dataAboutPacketMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.TextBox packetChunkNum;
        private System.Windows.Forms.TextBox packetCharRepresentation;
        private System.Windows.Forms.TextBox packetByteRepresentation;
        private System.Windows.Forms.TextBox bpfField;
        private System.Windows.Forms.Button tbtnFilterOn;
        private System.Windows.Forms.ToolStripMenuItem darkThemeMenuItem;
    }
}