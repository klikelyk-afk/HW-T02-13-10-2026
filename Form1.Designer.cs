namespace WinFormsApp_DNS_511
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonGetIp = new Button();
            textBoxHostName = new TextBox();
            textBoxIpAddress = new TextBox();
            buttonGetHost = new Button();
            listBoxAddresses = new ListBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            labelHostName = new Label();
            button1 = new Button();
            button2 = new Button();
            buttonGet = new Button();
            textBoxOutput = new TextBox();
            SuspendLayout();
            // 
            // buttonGetIp
            // 
            buttonGetIp.Location = new Point(209, 38);
            buttonGetIp.Name = "buttonGetIp";
            buttonGetIp.Size = new Size(94, 29);
            buttonGetIp.TabIndex = 0;
            buttonGetIp.Text = "Get IP";
            buttonGetIp.UseVisualStyleBackColor = true;
            buttonGetIp.Click += buttonGetIp_Click;
            // 
            // textBoxHostName
            // 
            textBoxHostName.Location = new Point(23, 39);
            textBoxHostName.Name = "textBoxHostName";
            textBoxHostName.Size = new Size(166, 27);
            textBoxHostName.TabIndex = 1;
            // 
            // textBoxIpAddress
            // 
            textBoxIpAddress.Location = new Point(23, 411);
            textBoxIpAddress.Name = "textBoxIpAddress";
            textBoxIpAddress.Size = new Size(166, 27);
            textBoxIpAddress.TabIndex = 2;
            // 
            // buttonGetHost
            // 
            buttonGetHost.Location = new Point(209, 411);
            buttonGetHost.Name = "buttonGetHost";
            buttonGetHost.Size = new Size(94, 29);
            buttonGetHost.TabIndex = 3;
            buttonGetHost.Text = "Get Host";
            buttonGetHost.UseVisualStyleBackColor = true;
            buttonGetHost.Click += buttonGetHost_Click;
            // 
            // listBoxAddresses
            // 
            listBoxAddresses.FormattingEnabled = true;
            listBoxAddresses.Location = new Point(23, 111);
            listBoxAddresses.Name = "listBoxAddresses";
            listBoxAddresses.Size = new Size(166, 264);
            listBoxAddresses.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 16);
            label1.Name = "label1";
            label1.Size = new Size(43, 20);
            label1.TabIndex = 5;
            label1.Text = "Host:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 388);
            label2.Name = "label2";
            label2.Size = new Size(24, 20);
            label2.TabIndex = 6;
            label2.Text = "IP:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 88);
            label3.Name = "label3";
            label3.Size = new Size(93, 20);
            label3.TabIndex = 7;
            label3.Text = "IP addresses:";
            // 
            // labelHostName
            // 
            labelHostName.AutoSize = true;
            labelHostName.Location = new Point(327, 415);
            labelHostName.Name = "labelHostName";
            labelHostName.Size = new Size(100, 20);
            labelHostName.TabIndex = 8;
            labelHostName.Text = "<host_name>";
            // 
            // button1
            // 
            button1.Location = new Point(333, 39);
            button1.Name = "button1";
            button1.Size = new Size(186, 29);
            button1.TabIndex = 9;
            button1.Text = "Ping host with steps";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(694, 39);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 10;
            button2.Text = "Tasks";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // buttonGet
            // 
            buttonGet.Location = new Point(209, 111);
            buttonGet.Name = "buttonGet";
            buttonGet.Size = new Size(94, 29);
            buttonGet.TabIndex = 11;
            buttonGet.Text = "GET";
            buttonGet.UseVisualStyleBackColor = true;
            buttonGet.Click += buttonGet_Click;
            // 
            // textBoxOutput
            // 
            textBoxOutput.Location = new Point(209, 156);
            textBoxOutput.Multiline = true;
            textBoxOutput.Name = "textBoxOutput";
            textBoxOutput.Size = new Size(511, 219);
            textBoxOutput.TabIndex = 12;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBoxOutput);
            Controls.Add(buttonGet);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(labelHostName);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(listBoxAddresses);
            Controls.Add(buttonGetHost);
            Controls.Add(textBoxIpAddress);
            Controls.Add(textBoxHostName);
            Controls.Add(buttonGetIp);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonGetIp;
        private TextBox textBoxHostName;
        private TextBox textBoxIpAddress;
        private Button buttonGetHost;
        private ListBox listBoxAddresses;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label labelHostName;
        private Button button1;
        private Button button2;
        private Button buttonGet;
        private TextBox textBoxOutput;
    }
}
