namespace AudioRedirector
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            listBoxDevices = new ListBox();
            buttonConnect = new Button();
            buttonDisconnect = new Button();
            labelStatus = new Label();
            groupBoxVolume = new GroupBox();
            labelVolume2 = new Label();
            labelVolume1 = new Label();
            trackBarVolume2 = new TrackBar();
            trackBarVolume1 = new TrackBar();
            buttonRefresh = new Button();
            labelDevices = new Label();
            groupBoxVolume.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarVolume2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarVolume1).BeginInit();
            SuspendLayout();
            // 
            // listBoxDevices
            // 
            listBoxDevices.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            listBoxDevices.FormattingEnabled = true;
            listBoxDevices.ItemHeight = 20;
            listBoxDevices.Location = new Point(16, 45);
            listBoxDevices.Margin = new Padding(4, 5, 4, 5);
            listBoxDevices.Name = "listBoxDevices";
            listBoxDevices.SelectionMode = SelectionMode.MultiSimple;
            listBoxDevices.Size = new Size(479, 204);
            listBoxDevices.TabIndex = 0;
            listBoxDevices.SelectedIndexChanged += listBoxDevices_SelectedIndexChanged;
            // 
            // buttonConnect
            // 
            buttonConnect.Location = new Point(16, 260);
            buttonConnect.Margin = new Padding(4, 5, 4, 5);
            buttonConnect.Name = "buttonConnect";
            buttonConnect.Size = new Size(167, 46);
            buttonConnect.TabIndex = 1;
            buttonConnect.Text = "Подключить";
            buttonConnect.UseVisualStyleBackColor = true;
            buttonConnect.Click += buttonConnect_Click;
            // 
            // buttonDisconnect
            // 
            buttonDisconnect.Enabled = false;
            buttonDisconnect.Location = new Point(191, 260);
            buttonDisconnect.Margin = new Padding(4, 5, 4, 5);
            buttonDisconnect.Name = "buttonDisconnect";
            buttonDisconnect.Size = new Size(167, 46);
            buttonDisconnect.TabIndex = 2;
            buttonDisconnect.Text = "Отключить";
            buttonDisconnect.UseVisualStyleBackColor = true;
            buttonDisconnect.Click += buttonDisconnect_Click;
            // 
            // labelStatus
            // 
            labelStatus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelStatus.Location = new Point(16, 325);
            labelStatus.Margin = new Padding(4, 0, 4, 0);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(480, 35);
            labelStatus.TabIndex = 3;
            labelStatus.Text = "Готов к подключению";
            labelStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // groupBoxVolume
            // 
            groupBoxVolume.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxVolume.Controls.Add(labelVolume2);
            groupBoxVolume.Controls.Add(labelVolume1);
            groupBoxVolume.Controls.Add(trackBarVolume2);
            groupBoxVolume.Controls.Add(trackBarVolume1);
            groupBoxVolume.Enabled = false;
            groupBoxVolume.Location = new Point(16, 365);
            groupBoxVolume.Margin = new Padding(4, 5, 4, 5);
            groupBoxVolume.Name = "groupBoxVolume";
            groupBoxVolume.Padding = new Padding(4, 5, 4, 5);
            groupBoxVolume.Size = new Size(480, 249);
            groupBoxVolume.TabIndex = 4;
            groupBoxVolume.TabStop = false;
            groupBoxVolume.Text = "Громкость";
            // 
            // labelVolume2
            // 
            labelVolume2.AutoSize = true;
            labelVolume2.Location = new Point(8, 146);
            labelVolume2.Margin = new Padding(4, 0, 4, 0);
            labelVolume2.Name = "labelVolume2";
            labelVolume2.Size = new Size(135, 20);
            labelVolume2.TabIndex = 3;
            labelVolume2.Text = "Устройство 2: 50%";
            // 
            // labelVolume1
            // 
            labelVolume1.AutoSize = true;
            labelVolume1.Location = new Point(8, 38);
            labelVolume1.Margin = new Padding(4, 0, 4, 0);
            labelVolume1.Name = "labelVolume1";
            labelVolume1.Size = new Size(135, 20);
            labelVolume1.TabIndex = 2;
            labelVolume1.Text = "Устройство 1: 50%";
            // 
            // trackBarVolume2
            // 
            trackBarVolume2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            trackBarVolume2.Location = new Point(8, 171);
            trackBarVolume2.Margin = new Padding(4, 5, 4, 5);
            trackBarVolume2.Maximum = 100;
            trackBarVolume2.Name = "trackBarVolume2";
            trackBarVolume2.Size = new Size(464, 56);
            trackBarVolume2.TabIndex = 1;
            trackBarVolume2.Value = 50;
            trackBarVolume2.Scroll += trackBarVolume2_Scroll;
            // 
            // trackBarVolume1
            // 
            trackBarVolume1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            trackBarVolume1.Location = new Point(8, 63);
            trackBarVolume1.Margin = new Padding(4, 5, 4, 5);
            trackBarVolume1.Maximum = 100;
            trackBarVolume1.Name = "trackBarVolume1";
            trackBarVolume1.Size = new Size(464, 56);
            trackBarVolume1.TabIndex = 0;
            trackBarVolume1.Value = 50;
            trackBarVolume1.Scroll += trackBarVolume1_Scroll;
            // 
            // buttonRefresh
            // 
            buttonRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonRefresh.Location = new Point(365, 260);
            buttonRefresh.Margin = new Padding(4, 5, 4, 5);
            buttonRefresh.Name = "buttonRefresh";
            buttonRefresh.Size = new Size(131, 46);
            buttonRefresh.TabIndex = 5;
            buttonRefresh.Text = "Обновить";
            buttonRefresh.UseVisualStyleBackColor = true;
            buttonRefresh.Click += buttonRefresh_Click;
            // 
            // labelDevices
            // 
            labelDevices.AutoSize = true;
            labelDevices.Location = new Point(16, 20);
            labelDevices.Margin = new Padding(4, 0, 4, 0);
            labelDevices.Name = "labelDevices";
            labelDevices.Size = new Size(168, 20);
            labelDevices.TabIndex = 6;
            labelDevices.Text = "Доступные устройства:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(512, 632);
            Controls.Add(labelDevices);
            Controls.Add(buttonRefresh);
            Controls.Add(groupBoxVolume);
            Controls.Add(labelStatus);
            Controls.Add(buttonDisconnect);
            Controls.Add(buttonConnect);
            Controls.Add(listBoxDevices);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 5, 4, 5);
            MinimumSize = new Size(527, 667);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Audio Redirector";
            Load += Form1_Load;
            groupBoxVolume.ResumeLayout(false);
            groupBoxVolume.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarVolume2).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarVolume1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBoxDevices;
        private Button buttonConnect;
        private Button buttonDisconnect;
        private Label labelStatus;
        private GroupBox groupBoxVolume;
        private Label labelVolume2;
        private Label labelVolume1;
        private TrackBar trackBarVolume2;
        private TrackBar trackBarVolume1;
        private Button buttonRefresh;
        private Label labelDevices;
    }
}