namespace ContentFilter
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button_accept = new System.Windows.Forms.Button();
            this.button_decline = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // button_accept
            // 
            this.button_accept.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_accept.Location = new System.Drawing.Point(1083, 9);
            this.button_accept.Margin = new System.Windows.Forms.Padding(0);
            this.button_accept.Name = "button_accept";
            this.button_accept.Size = new System.Drawing.Size(300, 300);
            this.button_accept.TabIndex = 0;
            this.button_accept.Text = "ANNEHMEN";
            this.button_accept.UseVisualStyleBackColor = true;
            this.button_accept.Click += new System.EventHandler(this.button_accept_Click);
            // 
            // button_decline
            // 
            this.button_decline.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_decline.Location = new System.Drawing.Point(1083, 373);
            this.button_decline.Name = "button_decline";
            this.button_decline.Size = new System.Drawing.Size(300, 300);
            this.button_decline.TabIndex = 1;
            this.button_decline.Text = "ABLEHNEN";
            this.button_decline.UseVisualStyleBackColor = true;
            this.button_decline.Click += new System.EventHandler(this.button_decline_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(349, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(390, 650);
            this.pictureBox.TabIndex = 2;
            this.pictureBox.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1395, 685);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.button_decline);
            this.Controls.Add(this.button_accept);
            this.Name = "Form1";
            this.Text = "ContentFilter";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_accept;
        private System.Windows.Forms.Button button_decline;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Timer timer;
    }
}

