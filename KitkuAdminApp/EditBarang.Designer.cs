namespace KitkuAdminApp
{
    partial class EditBarang
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
            this.productPicture = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.boxKategori = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.idbar_textBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.boxNamaBarang = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.boxMitra = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.boxSatuanInt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.boxSatuanKg = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.boxHarga = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.boxJumlah = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.boxDeskripsi = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonPilihGambar = new System.Windows.Forms.Button();
            this.buttonCari = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.productPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // productPicture
            // 
            this.productPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.productPicture.Location = new System.Drawing.Point(3, 40);
            this.productPicture.Name = "productPicture";
            this.productPicture.Size = new System.Drawing.Size(200, 200);
            this.productPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.productPicture.TabIndex = 0;
            this.productPicture.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(209, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Kategori :";
            // 
            // boxKategori
            // 
            this.boxKategori.FormattingEnabled = true;
            this.boxKategori.Items.AddRange(new object[] {
            "DAGING",
            "SAYUR",
            "BIJI",
            "IKAN"});
            this.boxKategori.Location = new System.Drawing.Point(267, 40);
            this.boxKategori.Name = "boxKategori";
            this.boxKategori.Size = new System.Drawing.Size(121, 21);
            this.boxKategori.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "ID Barang :";
            // 
            // idbar_textBox
            // 
            this.idbar_textBox.Location = new System.Drawing.Point(73, 7);
            this.idbar_textBox.Name = "idbar_textBox";
            this.idbar_textBox.Size = new System.Drawing.Size(130, 20);
            this.idbar_textBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(255, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nama Barang :";
            // 
            // boxNamaBarang
            // 
            this.boxNamaBarang.Location = new System.Drawing.Point(339, 7);
            this.boxNamaBarang.Name = "boxNamaBarang";
            this.boxNamaBarang.Size = new System.Drawing.Size(176, 20);
            this.boxNamaBarang.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(525, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Mitra :";
            // 
            // boxMitra
            // 
            this.boxMitra.Location = new System.Drawing.Point(566, 7);
            this.boxMitra.Name = "boxMitra";
            this.boxMitra.Size = new System.Drawing.Size(123, 20);
            this.boxMitra.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(214, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Satuan :";
            // 
            // boxSatuanInt
            // 
            this.boxSatuanInt.Location = new System.Drawing.Point(267, 80);
            this.boxSatuanInt.Name = "boxSatuanInt";
            this.boxSatuanInt.Size = new System.Drawing.Size(121, 20);
            this.boxSatuanInt.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(394, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(12, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "/";
            this.label6.Visible = false;
            // 
            // boxSatuanKg
            // 
            this.boxSatuanKg.Location = new System.Drawing.Point(412, 80);
            this.boxSatuanKg.Name = "boxSatuanKg";
            this.boxSatuanKg.Size = new System.Drawing.Size(57, 20);
            this.boxSatuanKg.TabIndex = 12;
            this.boxSatuanKg.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(219, 123);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Harga :";
            // 
            // boxHarga
            // 
            this.boxHarga.Location = new System.Drawing.Point(267, 120);
            this.boxHarga.Name = "boxHarga";
            this.boxHarga.Size = new System.Drawing.Size(121, 20);
            this.boxHarga.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(480, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Stok :";
            // 
            // boxJumlah
            // 
            this.boxJumlah.Location = new System.Drawing.Point(520, 40);
            this.boxJumlah.Name = "boxJumlah";
            this.boxJumlah.Size = new System.Drawing.Size(36, 20);
            this.boxJumlah.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(205, 163);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Deskripsi :";
            // 
            // boxDeskripsi
            // 
            this.boxDeskripsi.Location = new System.Drawing.Point(208, 179);
            this.boxDeskripsi.Multiline = true;
            this.boxDeskripsi.Name = "boxDeskripsi";
            this.boxDeskripsi.Size = new System.Drawing.Size(408, 128);
            this.boxDeskripsi.TabIndex = 18;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(622, 179);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "Simpan";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // buttonPilihGambar
            // 
            this.buttonPilihGambar.Location = new System.Drawing.Point(3, 246);
            this.buttonPilihGambar.Name = "buttonPilihGambar";
            this.buttonPilihGambar.Size = new System.Drawing.Size(199, 61);
            this.buttonPilihGambar.TabIndex = 20;
            this.buttonPilihGambar.Text = "Ubah Gambar";
            this.buttonPilihGambar.UseVisualStyleBackColor = true;
            this.buttonPilihGambar.Click += new System.EventHandler(this.Button_UbahGambar_Click);
            // 
            // buttonCari
            // 
            this.buttonCari.Location = new System.Drawing.Point(209, 5);
            this.buttonCari.Name = "buttonCari";
            this.buttonCari.Size = new System.Drawing.Size(40, 23);
            this.buttonCari.TabIndex = 21;
            this.buttonCari.Text = "Cari";
            this.buttonCari.UseVisualStyleBackColor = true;
            this.buttonCari.Click += new System.EventHandler(this.Button_Cari_Click);
            // 
            // EditBarang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonCari);
            this.Controls.Add(this.buttonPilihGambar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.boxDeskripsi);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.boxJumlah);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.boxHarga);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.boxSatuanKg);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.boxSatuanInt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.boxMitra);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.boxNamaBarang);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.idbar_textBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.boxKategori);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.productPicture);
            this.Name = "EditBarang";
            this.Size = new System.Drawing.Size(700, 310);
            ((System.ComponentModel.ISupportInitialize)(this.productPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox productPicture;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox boxKategori;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox idbar_textBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox boxNamaBarang;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox boxMitra;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox boxSatuanInt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox boxSatuanKg;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox boxHarga;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox boxJumlah;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox boxDeskripsi;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonPilihGambar;
        private System.Windows.Forms.Button buttonCari;
    }
}
