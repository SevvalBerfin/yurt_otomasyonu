namespace yurt_otomasyon_projesi
{
    partial class Ana_Form
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
            this.btn_ogr = new System.Windows.Forms.Button();
            this.btn_kayit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_ogr
            // 
            this.btn_ogr.Location = new System.Drawing.Point(475, 122);
            this.btn_ogr.Name = "btn_ogr";
            this.btn_ogr.Size = new System.Drawing.Size(122, 51);
            this.btn_ogr.TabIndex = 0;
            this.btn_ogr.Text = "Öğrenci İşlemleri";
            this.btn_ogr.UseVisualStyleBackColor = true;
            this.btn_ogr.Click += new System.EventHandler(this.btn_ogr_Click);
            // 
            // btn_kayit
            // 
            this.btn_kayit.Location = new System.Drawing.Point(498, 240);
            this.btn_kayit.Name = "btn_kayit";
            this.btn_kayit.Size = new System.Drawing.Size(125, 55);
            this.btn_kayit.TabIndex = 1;
            this.btn_kayit.Text = "Oda Kayıt İşlemleri";
            this.btn_kayit.UseVisualStyleBackColor = true;
            this.btn_kayit.Click += new System.EventHandler(this.btn_kayit_Click);
            // 
            // Ana_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_kayit);
            this.Controls.Add(this.btn_ogr);
            this.Name = "Ana_Form";
            this.Text = "Ana_Form";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_ogr;
        private System.Windows.Forms.Button btn_kayit;
    }
}