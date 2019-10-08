namespace KitkuAdminApp
{
    partial class TambahBarang
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
            this.buttonSimpan = new System.Windows.Forms.Button();
            this.boxDeskripsi = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.boxHarga = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.boxSatuanInt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.boxMitra = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.boxNamaBarang = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.boxIDBarang = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.boxKategori = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.boxIDSupplier = new System.Windows.Forms.TextBox();
            this.buttonCekMitra = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.boxKodeBarang = new System.Windows.Forms.TextBox();
            this.buttonIDBarangInfo = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.productPicture = new System.Windows.Forms.PictureBox();
            this.buttonPilihGambar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.productPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSimpan
            // 
            this.buttonSimpan.Location = new System.Drawing.Point(512, 175);
            this.buttonSimpan.Name = "buttonSimpan";
            this.buttonSimpan.Size = new System.Drawing.Size(75, 23);
            this.buttonSimpan.TabIndex = 41;
            this.buttonSimpan.Text = "Simpan";
            this.buttonSimpan.UseVisualStyleBackColor = true;
            this.buttonSimpan.Click += new System.EventHandler(this.ButtonSimpan_Click);
            // 
            // boxDeskripsi
            // 
            this.boxDeskripsi.Location = new System.Drawing.Point(93, 175);
            this.boxDeskripsi.Multiline = true;
            this.boxDeskripsi.Name = "boxDeskripsi";
            this.boxDeskripsi.Size = new System.Drawing.Size(408, 128);
            this.boxDeskripsi.TabIndex = 40;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(26, 175);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 13);
            this.label9.TabIndex = 39;
            this.label9.Text = "Deskripsi :";
            // 
            // boxHarga
            // 
            this.boxHarga.Location = new System.Drawing.Point(93, 132);
            this.boxHarga.Name = "boxHarga";
            this.boxHarga.Size = new System.Drawing.Size(121, 20);
            this.boxHarga.TabIndex = 36;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(40, 135);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 35;
            this.label7.Text = "Harga :";
            // 
            // boxSatuanInt
            // 
            this.boxSatuanInt.Location = new System.Drawing.Point(93, 92);
            this.boxSatuanInt.Name = "boxSatuanInt";
            this.boxSatuanInt.Size = new System.Drawing.Size(121, 20);
            this.boxSatuanInt.TabIndex = 32;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "Satuan :";
            // 
            // boxMitra
            // 
            this.boxMitra.Location = new System.Drawing.Point(339, 52);
            this.boxMitra.Name = "boxMitra";
            this.boxMitra.Size = new System.Drawing.Size(123, 20);
            this.boxMitra.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(297, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Mitra :";
            // 
            // boxNamaBarang
            // 
            this.boxNamaBarang.Location = new System.Drawing.Point(93, 52);
            this.boxNamaBarang.Name = "boxNamaBarang";
            this.boxNamaBarang.Size = new System.Drawing.Size(176, 20);
            this.boxNamaBarang.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Nama Barang :";
            // 
            // boxIDBarang
            // 
            this.boxIDBarang.Location = new System.Drawing.Point(512, 283);
            this.boxIDBarang.Name = "boxIDBarang";
            this.boxIDBarang.ReadOnly = true;
            this.boxIDBarang.Size = new System.Drawing.Size(130, 20);
            this.boxIDBarang.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(509, 267);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "ID Barang :";
            // 
            // boxKategori
            // 
            this.boxKategori.FormattingEnabled = true;
            this.boxKategori.Items.AddRange(new object[] {
            "DAGING",
            "SAYUR",
            "BIJI",
            "IKAN"});
            this.boxKategori.Location = new System.Drawing.Point(93, 12);
            this.boxKategori.Name = "boxKategori";
            this.boxKategori.Size = new System.Drawing.Size(121, 21);
            this.boxKategori.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Kategori :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(269, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 42;
            this.label6.Text = "Kode Mitra :";
            // 
            // boxIDSupplier
            // 
            this.boxIDSupplier.Location = new System.Drawing.Point(339, 92);
            this.boxIDSupplier.Name = "boxIDSupplier";
            this.boxIDSupplier.ReadOnly = true;
            this.boxIDSupplier.Size = new System.Drawing.Size(123, 20);
            this.boxIDSupplier.TabIndex = 43;
            this.boxIDSupplier.TextChanged += new System.EventHandler(this.RemoveFocus);
            this.boxIDSupplier.Enter += new System.EventHandler(this.RemoveFocus);
            // 
            // buttonCekMitra
            // 
            this.buttonCekMitra.Location = new System.Drawing.Point(468, 50);
            this.buttonCekMitra.Name = "buttonCekMitra";
            this.buttonCekMitra.Size = new System.Drawing.Size(43, 23);
            this.buttonCekMitra.TabIndex = 44;
            this.buttonCekMitra.Text = "Cek";
            this.buttonCekMitra.UseVisualStyleBackColor = true;
            this.buttonCekMitra.Click += new System.EventHandler(this.ButtonCekMitra_Click);
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Location = new System.Drawing.Point(512, 217);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(130, 47);
            this.textBox2.TabIndex = 45;
            this.textBox2.Text = "ID Barang akan muncul ketika penambahan barang berhasil dilakukan";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox2.Enter += new System.EventHandler(this.RemoveFocus);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(220, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 13);
            this.label8.TabIndex = 46;
            this.label8.Text = "Kode Barang :";
            // 
            // boxKodeBarang
            // 
            this.boxKodeBarang.Location = new System.Drawing.Point(301, 12);
            this.boxKodeBarang.Name = "boxKodeBarang";
            this.boxKodeBarang.Size = new System.Drawing.Size(100, 20);
            this.boxKodeBarang.TabIndex = 47;
            // 
            // buttonIDBarangInfo
            // 
            this.buttonIDBarangInfo.BackgroundImage = global::KitkuAdminApp.Properties.Resources.Info_icon_72a7cf_svg;
            this.buttonIDBarangInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonIDBarangInfo.Location = new System.Drawing.Point(407, 10);
            this.buttonIDBarangInfo.Name = "buttonIDBarangInfo";
            this.buttonIDBarangInfo.Size = new System.Drawing.Size(23, 23);
            this.buttonIDBarangInfo.TabIndex = 48;
            this.buttonIDBarangInfo.UseVisualStyleBackColor = true;
            this.buttonIDBarangInfo.Click += new System.EventHandler(this.ButtonIDBarangInfo_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(529, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 13);
            this.label10.TabIndex = 49;
            this.label10.Text = "Gambar : ";
            // 
            // productPicture
            // 
            this.productPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.productPicture.Location = new System.Drawing.Point(532, 39);
            this.productPicture.Name = "productPicture";
            this.productPicture.Size = new System.Drawing.Size(100, 100);
            this.productPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.productPicture.TabIndex = 50;
            this.productPicture.TabStop = false;
            // 
            // buttonPilihGambar
            // 
            this.buttonPilihGambar.Location = new System.Drawing.Point(588, 10);
            this.buttonPilihGambar.Name = "buttonPilihGambar";
            this.buttonPilihGambar.Size = new System.Drawing.Size(54, 23);
            this.buttonPilihGambar.TabIndex = 51;
            this.buttonPilihGambar.Text = "Pilih";
            this.buttonPilihGambar.UseVisualStyleBackColor = true;
            this.buttonPilihGambar.Click += new System.EventHandler(this.ButtonPilihGambar_Click);
            // 
            // TambahBarang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonPilihGambar);
            this.Controls.Add(this.productPicture);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.buttonIDBarangInfo);
            this.Controls.Add(this.boxKodeBarang);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.buttonCekMitra);
            this.Controls.Add(this.boxIDSupplier);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.buttonSimpan);
            this.Controls.Add(this.boxDeskripsi);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.boxHarga);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.boxSatuanInt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.boxMitra);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.boxNamaBarang);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.boxIDBarang);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.boxKategori);
            this.Controls.Add(this.label1);
            this.Name = "TambahBarang";
            this.Size = new System.Drawing.Size(700, 310);
            ((System.ComponentModel.ISupportInitialize)(this.productPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonSimpan;
        private System.Windows.Forms.TextBox boxDeskripsi;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox boxHarga;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox boxSatuanInt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox boxMitra;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox boxNamaBarang;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox boxIDBarang;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox boxKategori;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox boxIDSupplier;
        private System.Windows.Forms.Button buttonCekMitra;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox boxKodeBarang;
        private System.Windows.Forms.Button buttonIDBarangInfo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox productPicture;
        private System.Windows.Forms.Button buttonPilihGambar;
    }
}
