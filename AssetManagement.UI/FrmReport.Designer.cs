namespace AssetManagement.UI
{
    partial class FrmReport
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
            this.lstAssetList = new System.Windows.Forms.ListView();
            this.KayitNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Barkod = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.urunTipi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.urununGuncelFiyati = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.markasi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.modeli = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dtR = new System.Windows.Forms.DateTimePicker();
            this.btnR = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstAssetList
            // 
            this.lstAssetList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.KayitNo,
            this.Barkod,
            this.urunTipi,
            this.urununGuncelFiyati,
            this.markasi,
            this.modeli});
            this.lstAssetList.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lstAssetList.GridLines = true;
            this.lstAssetList.HideSelection = false;
            this.lstAssetList.Location = new System.Drawing.Point(75, 119);
            this.lstAssetList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lstAssetList.Name = "lstAssetList";
            this.lstAssetList.Size = new System.Drawing.Size(660, 285);
            this.lstAssetList.TabIndex = 6;
            this.lstAssetList.UseCompatibleStateImageBehavior = false;
            this.lstAssetList.View = System.Windows.Forms.View.Details;
            // 
            // KayitNo
            // 
            this.KayitNo.Text = "Kayıt Numarası";
            this.KayitNo.Width = 129;
            // 
            // Barkod
            // 
            this.Barkod.Text = "Barkod";
            this.Barkod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Barkod.Width = 87;
            // 
            // urunTipi
            // 
            this.urunTipi.Text = "Ürün Tipi";
            this.urunTipi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.urunTipi.Width = 91;
            // 
            // urununGuncelFiyati
            // 
            this.urununGuncelFiyati.Text = "Ürünün Güncel Fiyatı";
            this.urununGuncelFiyati.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.urununGuncelFiyati.Width = 162;
            // 
            // markasi
            // 
            this.markasi.Text = "Markası";
            this.markasi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.markasi.Width = 97;
            // 
            // modeli
            // 
            this.modeli.Text = "Modeli";
            this.modeli.Width = 125;
            // 
            // dtR
            // 
            this.dtR.Location = new System.Drawing.Point(277, 58);
            this.dtR.Name = "dtR";
            this.dtR.Size = new System.Drawing.Size(200, 22);
            this.dtR.TabIndex = 10;
            // 
            // btnR
            // 
            this.btnR.Location = new System.Drawing.Point(525, 60);
            this.btnR.Name = "btnR";
            this.btnR.Size = new System.Drawing.Size(75, 23);
            this.btnR.TabIndex = 11;
            this.btnR.Text = "Raporla";
            this.btnR.UseVisualStyleBackColor = true;
            this.btnR.Click += new System.EventHandler(this.btnR_Click);
            // 
            // FrmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnR);
            this.Controls.Add(this.dtR);
            this.Controls.Add(this.lstAssetList);
            this.Name = "FrmReport";
            this.Text = "FrmReport";
            this.Load += new System.EventHandler(this.FrmReport_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView lstAssetList;
        private System.Windows.Forms.ColumnHeader KayitNo;
        private System.Windows.Forms.ColumnHeader Barkod;
        private System.Windows.Forms.ColumnHeader urunTipi;
        private System.Windows.Forms.ColumnHeader urununGuncelFiyati;
        private System.Windows.Forms.ColumnHeader markasi;
        private System.Windows.Forms.ColumnHeader modeli;
        private System.Windows.Forms.DateTimePicker dtR;
        private System.Windows.Forms.Button btnR;
    }
}