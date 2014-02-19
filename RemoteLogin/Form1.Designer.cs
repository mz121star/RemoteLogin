namespace RemoteLogin
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
            this.txt_Cookie = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.btn_cookie = new System.Windows.Forms.Button();
            this.btn_rcookie = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_Cookie
            // 
            this.txt_Cookie.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Cookie.Location = new System.Drawing.Point(518, 457);
            this.txt_Cookie.Multiline = true;
            this.txt_Cookie.Name = "txt_Cookie";
            this.txt_Cookie.Size = new System.Drawing.Size(449, 150);
            this.txt_Cookie.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button1.Location = new System.Drawing.Point(395, 457);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "SEND——>Server";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox2.Location = new System.Drawing.Point(13, 457);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(376, 150);
            this.textBox2.TabIndex = 2;
            this.textBox2.Text = "{\"from\":\"192.168.112.11:33333\",\"flag\":\"0\",\"url\":\"http://www.weibo.com\"}";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(24, 35);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(943, 416);
            this.webBrowser1.TabIndex = 3;
            this.webBrowser1.Url = new System.Uri("http://www.miaozhuang.net/", System.UriKind.Absolute);
            // 
            // btn_cookie
            // 
            this.btn_cookie.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_cookie.Location = new System.Drawing.Point(414, 504);
            this.btn_cookie.Name = "btn_cookie";
            this.btn_cookie.Size = new System.Drawing.Size(75, 23);
            this.btn_cookie.TabIndex = 4;
            this.btn_cookie.Text = "Cookie";
            this.btn_cookie.UseVisualStyleBackColor = true;
            this.btn_cookie.Click += new System.EventHandler(this.btn_cookie_Click);
            // 
            // btn_rcookie
            // 
            this.btn_rcookie.Location = new System.Drawing.Point(396, 574);
            this.btn_rcookie.Name = "btn_rcookie";
            this.btn_rcookie.Size = new System.Drawing.Size(93, 23);
            this.btn_rcookie.TabIndex = 5;
            this.btn_rcookie.Text = "<-Return Cookie";
            this.btn_rcookie.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 619);
            this.Controls.Add(this.btn_rcookie);
            this.Controls.Add(this.btn_cookie);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt_Cookie);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Cookie;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button btn_cookie;
        private System.Windows.Forms.Button btn_rcookie;

    }
}

