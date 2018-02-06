using System.Drawing;
using System.Windows.Forms;

namespace Presentation
{
    partial class Presentation
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
            this.exit = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.label_snapchataccount_name = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // exit
            // 
            this.exit.BackColor = System.Drawing.Color.Black;
            this.exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.exit.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exit.ForeColor = System.Drawing.Color.Black;
            this.exit.Location = new System.Drawing.Point(0, 0);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(100, 100);
            this.exit.TabIndex = 0;
            this.exit.Text = "Exit";
            this.exit.UseVisualStyleBackColor = false;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(765, 215);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(390, 650);
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            // 
            // label_snapchataccount_name
            // 
            this.label_snapchataccount_name.AutoSize = true;
            this.label_snapchataccount_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_snapchataccount_name.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.label_snapchataccount_name.Location = new System.Drawing.Point(1297, 650);
            this.label_snapchataccount_name.Name = "label_snapchataccount_name";
            this.label_snapchataccount_name.Size = new System.Drawing.Size(272, 46);
            this.label_snapchataccount_name.TabIndex = 2;
            this.label_snapchataccount_name.Text = "@htlkremsball";
            // 
            // Presentation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.CancelButton = this.exit;
            this.ClientSize = new System.Drawing.Size(1904, 958);
            this.Controls.Add(this.label_snapchataccount_name);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.exit);
            this.KeyPreview = true;
            this.Name = "Presentation";
            this.Text = "Presentation";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button exit;
        private PictureBox pictureBox;
        private Timer timer;
        private Label label_snapchataccount_name;
    }
}

