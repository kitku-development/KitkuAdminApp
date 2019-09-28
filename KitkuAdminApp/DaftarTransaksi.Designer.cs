namespace KitkuAdminApp
{
    partial class DaftarTransaksi
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.pilihanTanggal = new System.Windows.Forms.DateTimePicker();
            this.tabelRingkasanPemesanan = new System.Windows.Forms.DataGridView();
            this.refreshButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pilihanUrut = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.tabelRingkasanPemesanan)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tanggal :";
            // 
            // pilihanTanggal
            // 
            this.pilihanTanggal.Location = new System.Drawing.Point(61, 7);
            this.pilihanTanggal.Name = "pilihanTanggal";
            this.pilihanTanggal.Size = new System.Drawing.Size(200, 20);
            this.pilihanTanggal.TabIndex = 1;
            this.pilihanTanggal.ValueChanged += new System.EventHandler(this.ExecuteTask);
            // 
            // tabelRingkasanPemesanan
            // 
            this.tabelRingkasanPemesanan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabelRingkasanPemesanan.Location = new System.Drawing.Point(6, 33);
            this.tabelRingkasanPemesanan.Name = "tabelRingkasanPemesanan";
            this.tabelRingkasanPemesanan.Size = new System.Drawing.Size(686, 266);
            this.tabelRingkasanPemesanan.TabIndex = 3;
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(616, 4);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(75, 23);
            this.refreshButton.TabIndex = 4;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.ExecuteTask);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(277, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Urut berdasar :";
            // 
            // pilihanUrut
            // 
            this.pilihanUrut.FormattingEnabled = true;
            this.pilihanUrut.Items.AddRange(new object[] {
            "Pelanggan",
            "Mitra"});
            this.pilihanUrut.Location = new System.Drawing.Point(360, 7);
            this.pilihanUrut.Name = "pilihanUrut";
            this.pilihanUrut.Size = new System.Drawing.Size(121, 21);
            this.pilihanUrut.TabIndex = 6;
            this.pilihanUrut.SelectedIndexChanged += new System.EventHandler(this.ExecuteTask);
            // 
            // DaftarTransaksi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pilihanUrut);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.tabelRingkasanPemesanan);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pilihanTanggal);
            this.Name = "DaftarTransaksi";
            this.Size = new System.Drawing.Size(700, 310);
            ((System.ComponentModel.ISupportInitialize)(this.tabelRingkasanPemesanan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker pilihanTanggal;
        private System.Windows.Forms.DataGridView tabelRingkasanPemesanan;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox pilihanUrut;
    }
}
