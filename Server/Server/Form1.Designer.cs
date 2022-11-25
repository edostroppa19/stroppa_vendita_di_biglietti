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
            this.avvio_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Elenco_ospiti
            // 
            this.Elenco_ospiti.ColumnWidth = 2;
            this.Elenco_ospiti.FormattingEnabled = true;
            this.Elenco_ospiti.ItemHeight = 15;
            this.Elenco_ospiti.Location = new System.Drawing.Point(103, 12);
            this.Elenco_ospiti.Name = "Elenco_ospiti";
            this.Elenco_ospiti.Size = new System.Drawing.Size(253, 244);
            this.Elenco_ospiti.TabIndex = 0;
            // 
            // avvio_btn
            // 
            this.avvio_btn.Location = new System.Drawing.Point(12, 12);
            this.avvio_btn.Name = "avvio_btn";
            this.avvio_btn.Size = new System.Drawing.Size(75, 244);
            this.avvio_btn.TabIndex = 1;
            this.avvio_btn.Text = "avvio";
            this.avvio_btn.UseVisualStyleBackColor = true;
            this.avvio_btn.Click += new System.EventHandler(this.avvio_btn_Click);
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 386);
            this.Controls.Add(this.avvio_btn);
            this.Controls.Add(this.Elenco_ospiti);
            this.Name = "Server";
            this.Text = "Server";
            this.Load += new System.EventHandler(this.Server_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ListBox Elenco_ospiti;
        private Button avvio_btn;
    }
}