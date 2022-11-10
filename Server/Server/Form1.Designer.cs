namespace Server
{
    partial class Server
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
            this.Elenco_ospiti = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // Elenco_ospiti
            // 
            this.Elenco_ospiti.FormattingEnabled = true;
            this.Elenco_ospiti.ItemHeight = 15;
            this.Elenco_ospiti.Location = new System.Drawing.Point(12, 12);
            this.Elenco_ospiti.Name = "Elenco_ospiti";
            this.Elenco_ospiti.Size = new System.Drawing.Size(253, 244);
            this.Elenco_ospiti.TabIndex = 0;
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 386);
            this.Controls.Add(this.Elenco_ospiti);
            this.Name = "Server";
            this.Text = "Server";
            this.ResumeLayout(false);

        }

        #endregion

        private ListBox Elenco_ospiti;
    }
}