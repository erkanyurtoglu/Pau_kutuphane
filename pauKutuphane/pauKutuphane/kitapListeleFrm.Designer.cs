namespace pauKutuphane
{
    partial class kitapListeleFrm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(kitapListeleFrm));
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_anasayfaDon = new System.Windows.Forms.Button();
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel14 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_YayinYeri = new System.Windows.Forms.TextBox();
            this.panel13 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_barkodAra = new System.Windows.Forms.TextBox();
            this.btn_kitapSil = new System.Windows.Forms.Button();
            this.kitapListeleEkran = new System.Windows.Forms.DataGridView();
            this.btn_kitapGuncelle = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_yerNumarasi = new System.Windows.Forms.TextBox();
            this.txt_barkodNo = new System.Windows.Forms.TextBox();
            this.txt_isbnNo = new System.Windows.Forms.TextBox();
            this.txt_Yayinlayan = new System.Windows.Forms.TextBox();
            this.txt_Yazar = new System.Windows.Forms.TextBox();
            this.txt_Eser = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kitapListeleEkran)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(133)))));
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btn_anasayfaDon);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Location = new System.Drawing.Point(0, 73);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1890, 145);
            this.panel2.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(267, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 72);
            this.label1.TabIndex = 17;
            this.label1.Text = "PAMUKKALE \r\nÜNİVERSİTESİ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_anasayfaDon
            // 
            this.btn_anasayfaDon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_anasayfaDon.ImageKey = "home.png";
            this.btn_anasayfaDon.ImageList = this.ımageList1;
            this.btn_anasayfaDon.Location = new System.Drawing.Point(1608, 39);
            this.btn_anasayfaDon.Name = "btn_anasayfaDon";
            this.btn_anasayfaDon.Size = new System.Drawing.Size(75, 60);
            this.btn_anasayfaDon.TabIndex = 16;
            this.btn_anasayfaDon.UseVisualStyleBackColor = true;
            this.btn_anasayfaDon.Click += new System.EventHandler(this.btn_anasayfaDon_Click);
            // 
            // ımageList1
            // 
            this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
            this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList1.Images.SetKeyName(0, "home.png");
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(699, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(616, 51);
            this.label7.TabIndex = 15;
            this.label7.Text = "KÜTÜPHANE BİLGİ SİSTEMİ";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(119, 9);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(130, 130);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1883, 73);
            this.panel1.TabIndex = 9;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1535, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(204, 73);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel14
            // 
            this.panel14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(24)))), ((int)(((byte)(62)))));
            this.panel14.Location = new System.Drawing.Point(1267, 370);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(250, 5);
            this.panel14.TabIndex = 91;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(24)))), ((int)(((byte)(62)))));
            this.label13.Location = new System.Drawing.Point(1262, 288);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(106, 25);
            this.label13.TabIndex = 90;
            this.label13.Text = "Yayın Yeri:";
            // 
            // txt_YayinYeri
            // 
            this.txt_YayinYeri.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_YayinYeri.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_YayinYeri.Location = new System.Drawing.Point(1267, 340);
            this.txt_YayinYeri.Name = "txt_YayinYeri";
            this.txt_YayinYeri.Size = new System.Drawing.Size(250, 30);
            this.txt_YayinYeri.TabIndex = 89;
            // 
            // panel13
            // 
            this.panel13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(24)))), ((int)(((byte)(62)))));
            this.panel13.Location = new System.Drawing.Point(47, 592);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(250, 5);
            this.panel13.TabIndex = 88;
            // 
            // panel12
            // 
            this.panel12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(24)))), ((int)(((byte)(62)))));
            this.panel12.Location = new System.Drawing.Point(1568, 370);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(250, 5);
            this.panel12.TabIndex = 87;
            // 
            // panel11
            // 
            this.panel11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(24)))), ((int)(((byte)(62)))));
            this.panel11.Location = new System.Drawing.Point(47, 494);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(250, 5);
            this.panel11.TabIndex = 86;
            // 
            // panel10
            // 
            this.panel10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(24)))), ((int)(((byte)(62)))));
            this.panel10.Location = new System.Drawing.Point(662, 370);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(250, 5);
            this.panel10.TabIndex = 85;
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(24)))), ((int)(((byte)(62)))));
            this.panel6.Location = new System.Drawing.Point(967, 370);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(250, 5);
            this.panel6.TabIndex = 84;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(24)))), ((int)(((byte)(62)))));
            this.panel5.Location = new System.Drawing.Point(357, 370);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(250, 5);
            this.panel5.TabIndex = 83;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(24)))), ((int)(((byte)(62)))));
            this.panel3.Location = new System.Drawing.Point(47, 370);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(250, 5);
            this.panel3.TabIndex = 82;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(24)))), ((int)(((byte)(62)))));
            this.label11.Location = new System.Drawing.Point(47, 530);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(116, 25);
            this.label11.TabIndex = 81;
            this.label11.Text = "Barkod Ara:";
            // 
            // txt_barkodAra
            // 
            this.txt_barkodAra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_barkodAra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_barkodAra.Location = new System.Drawing.Point(47, 562);
            this.txt_barkodAra.Name = "txt_barkodAra";
            this.txt_barkodAra.Size = new System.Drawing.Size(250, 30);
            this.txt_barkodAra.TabIndex = 80;
            this.txt_barkodAra.TextChanged += new System.EventHandler(this.txt_barkodAra_TextChanged);
            // 
            // btn_kitapSil
            // 
            this.btn_kitapSil.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_kitapSil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(24)))), ((int)(((byte)(62)))));
            this.btn_kitapSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_kitapSil.ForeColor = System.Drawing.Color.White;
            this.btn_kitapSil.Location = new System.Drawing.Point(42, 733);
            this.btn_kitapSil.Name = "btn_kitapSil";
            this.btn_kitapSil.Size = new System.Drawing.Size(250, 50);
            this.btn_kitapSil.TabIndex = 79;
            this.btn_kitapSil.Text = "Kitap Sil";
            this.btn_kitapSil.UseVisualStyleBackColor = false;
            this.btn_kitapSil.Click += new System.EventHandler(this.btn_kitapSil_Click);
            // 
            // kitapListeleEkran
            // 
            this.kitapListeleEkran.AllowUserToAddRows = false;
            this.kitapListeleEkran.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kitapListeleEkran.BackgroundColor = System.Drawing.Color.White;
            this.kitapListeleEkran.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.kitapListeleEkran.Location = new System.Drawing.Point(364, 431);
            this.kitapListeleEkran.Name = "kitapListeleEkran";
            this.kitapListeleEkran.ReadOnly = true;
            this.kitapListeleEkran.RowHeadersWidth = 51;
            this.kitapListeleEkran.RowTemplate.Height = 24;
            this.kitapListeleEkran.Size = new System.Drawing.Size(1454, 603);
            this.kitapListeleEkran.TabIndex = 78;
            // 
            // btn_kitapGuncelle
            // 
            this.btn_kitapGuncelle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_kitapGuncelle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(24)))), ((int)(((byte)(62)))));
            this.btn_kitapGuncelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_kitapGuncelle.ForeColor = System.Drawing.Color.White;
            this.btn_kitapGuncelle.Location = new System.Drawing.Point(42, 647);
            this.btn_kitapGuncelle.Name = "btn_kitapGuncelle";
            this.btn_kitapGuncelle.Size = new System.Drawing.Size(250, 50);
            this.btn_kitapGuncelle.TabIndex = 77;
            this.btn_kitapGuncelle.Text = "Kitap Güncelle";
            this.btn_kitapGuncelle.UseVisualStyleBackColor = false;
            this.btn_kitapGuncelle.Click += new System.EventHandler(this.btn_kitapGuncelle_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(24)))), ((int)(((byte)(62)))));
            this.label6.Location = new System.Drawing.Point(42, 412);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(168, 25);
            this.label6.TabIndex = 76;
            this.label6.Text = "Barkod Numarası:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(24)))), ((int)(((byte)(62)))));
            this.label2.Location = new System.Drawing.Point(657, 288);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 25);
            this.label2.TabIndex = 75;
            this.label2.Text = "ISBN:";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(24)))), ((int)(((byte)(62)))));
            this.label8.Location = new System.Drawing.Point(1568, 298);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(136, 25);
            this.label8.TabIndex = 74;
            this.label8.Text = "Yer Numarası:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(24)))), ((int)(((byte)(62)))));
            this.label3.Location = new System.Drawing.Point(962, 288);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 25);
            this.label3.TabIndex = 73;
            this.label3.Text = "Yayınlayan:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(24)))), ((int)(((byte)(62)))));
            this.label4.Location = new System.Drawing.Point(352, 288);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 25);
            this.label4.TabIndex = 72;
            this.label4.Text = "Yazar:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(24)))), ((int)(((byte)(62)))));
            this.label5.Location = new System.Drawing.Point(47, 288);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 25);
            this.label5.TabIndex = 71;
            this.label5.Text = "Eser:";
            // 
            // txt_yerNumarasi
            // 
            this.txt_yerNumarasi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_yerNumarasi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_yerNumarasi.Location = new System.Drawing.Point(1568, 340);
            this.txt_yerNumarasi.Name = "txt_yerNumarasi";
            this.txt_yerNumarasi.Size = new System.Drawing.Size(250, 30);
            this.txt_yerNumarasi.TabIndex = 70;
            // 
            // txt_barkodNo
            // 
            this.txt_barkodNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_barkodNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_barkodNo.Location = new System.Drawing.Point(47, 464);
            this.txt_barkodNo.Name = "txt_barkodNo";
            this.txt_barkodNo.Size = new System.Drawing.Size(250, 30);
            this.txt_barkodNo.TabIndex = 69;
            this.txt_barkodNo.TextChanged += new System.EventHandler(this.txt_barkodNo_TextChanged);
            // 
            // txt_isbnNo
            // 
            this.txt_isbnNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_isbnNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_isbnNo.Location = new System.Drawing.Point(662, 340);
            this.txt_isbnNo.Name = "txt_isbnNo";
            this.txt_isbnNo.Size = new System.Drawing.Size(250, 30);
            this.txt_isbnNo.TabIndex = 68;
            // 
            // txt_Yayinlayan
            // 
            this.txt_Yayinlayan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Yayinlayan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_Yayinlayan.Location = new System.Drawing.Point(967, 340);
            this.txt_Yayinlayan.Name = "txt_Yayinlayan";
            this.txt_Yayinlayan.Size = new System.Drawing.Size(250, 30);
            this.txt_Yayinlayan.TabIndex = 67;
            // 
            // txt_Yazar
            // 
            this.txt_Yazar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Yazar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_Yazar.Location = new System.Drawing.Point(357, 340);
            this.txt_Yazar.Name = "txt_Yazar";
            this.txt_Yazar.Size = new System.Drawing.Size(250, 30);
            this.txt_Yazar.TabIndex = 66;
            // 
            // txt_Eser
            // 
            this.txt_Eser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Eser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_Eser.Location = new System.Drawing.Point(47, 340);
            this.txt_Eser.Name = "txt_Eser";
            this.txt_Eser.Size = new System.Drawing.Size(250, 30);
            this.txt_Eser.TabIndex = 65;
            // 
            // kitapListeleFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1882, 1055);
            this.Controls.Add(this.panel14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txt_YayinYeri);
            this.Controls.Add(this.panel13);
            this.Controls.Add(this.panel12);
            this.Controls.Add(this.panel11);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txt_barkodAra);
            this.Controls.Add(this.btn_kitapSil);
            this.Controls.Add(this.kitapListeleEkran);
            this.Controls.Add(this.btn_kitapGuncelle);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_yerNumarasi);
            this.Controls.Add(this.txt_barkodNo);
            this.Controls.Add(this.txt_isbnNo);
            this.Controls.Add(this.txt_Yayinlayan);
            this.Controls.Add(this.txt_Yazar);
            this.Controls.Add(this.txt_Eser);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "kitapListeleFrm";
            this.Text = "kitapListeleFrm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.kitapListeleFrm_Load_1);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kitapListeleEkran)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_anasayfaDon;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ImageList ımageList1;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txt_YayinYeri;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_barkodAra;
        private System.Windows.Forms.Button btn_kitapSil;
        private System.Windows.Forms.DataGridView kitapListeleEkran;
        private System.Windows.Forms.Button btn_kitapGuncelle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_yerNumarasi;
        private System.Windows.Forms.TextBox txt_barkodNo;
        private System.Windows.Forms.TextBox txt_isbnNo;
        private System.Windows.Forms.TextBox txt_Yayinlayan;
        private System.Windows.Forms.TextBox txt_Yazar;
        private System.Windows.Forms.TextBox txt_Eser;
    }
}