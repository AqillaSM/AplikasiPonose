namespace AplikasiPonose
{
    partial class FormOpen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOpen));
            this.gunaElipse1 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.BackButton = new Guna.UI.WinForms.GunaTileButton();
            this.gunaElipse3 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.gunaElipse2 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.PosisiPanel = new Guna.UI.WinForms.GunaShadowPanel();
            this.LabelPosisi = new Guna.UI.WinForms.GunaLabel();
            this.LabelNama = new Guna.UI.WinForms.GunaLabel();
            this.gunaCirclePictureBox1 = new Guna.UI.WinForms.GunaCirclePictureBox();
            this.gunaElipse4 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.SettingsPanel = new Guna.UI.WinForms.GunaPanel();
            this.DatePanel = new Guna.UI.WinForms.GunaShadowPanel();
            this.LabelTanggal = new Guna.UI.WinForms.GunaLabel();
            this.gunaLabel3 = new Guna.UI.WinForms.GunaLabel();
            this.gunaElipse5 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.gunaElipse6 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.PosisiPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gunaCirclePictureBox1)).BeginInit();
            this.DatePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // gunaElipse1
            // 
            this.gunaElipse1.Radius = 40;
            this.gunaElipse1.TargetControl = this;
            // 
            // BackButton
            // 
            this.BackButton.AnimationHoverSpeed = 0.07F;
            this.BackButton.AnimationSpeed = 0.03F;
            this.BackButton.BackColor = System.Drawing.Color.Transparent;
            this.BackButton.BaseColor = System.Drawing.Color.White;
            this.BackButton.BorderColor = System.Drawing.Color.Black;
            this.BackButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.BackButton.FocusedColor = System.Drawing.Color.Empty;
            this.BackButton.Font = new System.Drawing.Font("Segoe UI Light", 15.75F);
            this.BackButton.ForeColor = System.Drawing.Color.White;
            this.BackButton.Image = ((System.Drawing.Image)(resources.GetObject("BackButton.Image")));
            this.BackButton.ImageSize = new System.Drawing.Size(20, 20);
            this.BackButton.Location = new System.Drawing.Point(50, 23);
            this.BackButton.Name = "BackButton";
            this.BackButton.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.BackButton.OnHoverBorderColor = System.Drawing.Color.Black;
            this.BackButton.OnHoverForeColor = System.Drawing.Color.White;
            this.BackButton.OnHoverImage = null;
            this.BackButton.OnPressedColor = System.Drawing.Color.Black;
            this.BackButton.Radius = 10;
            this.BackButton.Size = new System.Drawing.Size(40, 40);
            this.BackButton.TabIndex = 39;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // gunaElipse3
            // 
            this.gunaElipse3.Radius = 10;
            this.gunaElipse3.TargetControl = this;
            // 
            // gunaElipse2
            // 
            this.gunaElipse2.Radius = 40;
            this.gunaElipse2.TargetControl = this;
            // 
            // PosisiPanel
            // 
            this.PosisiPanel.BackColor = System.Drawing.Color.Transparent;
            this.PosisiPanel.BaseColor = System.Drawing.Color.White;
            this.PosisiPanel.Controls.Add(this.LabelPosisi);
            this.PosisiPanel.Controls.Add(this.LabelNama);
            this.PosisiPanel.Controls.Add(this.gunaCirclePictureBox1);
            this.PosisiPanel.Location = new System.Drawing.Point(839, 23);
            this.PosisiPanel.Name = "PosisiPanel";
            this.PosisiPanel.Radius = 10;
            this.PosisiPanel.ShadowColor = System.Drawing.Color.Black;
            this.PosisiPanel.ShadowStyle = Guna.UI.WinForms.ShadowMode.Dropped;
            this.PosisiPanel.Size = new System.Drawing.Size(347, 88);
            this.PosisiPanel.TabIndex = 38;
            // 
            // LabelPosisi
            // 
            this.LabelPosisi.AutoSize = true;
            this.LabelPosisi.Font = new System.Drawing.Font("Montserrat", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelPosisi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(156)))), ((int)(((byte)(156)))));
            this.LabelPosisi.Location = new System.Drawing.Point(94, 18);
            this.LabelPosisi.Name = "LabelPosisi";
            this.LabelPosisi.Size = new System.Drawing.Size(107, 21);
            this.LabelPosisi.TabIndex = 6;
            this.LabelPosisi.Text = "I\'m a Cashier";
            // 
            // LabelNama
            // 
            this.LabelNama.AutoSize = true;
            this.LabelNama.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelNama.Location = new System.Drawing.Point(93, 34);
            this.LabelNama.Name = "LabelNama";
            this.LabelNama.Size = new System.Drawing.Size(188, 28);
            this.LabelNama.TabIndex = 5;
            this.LabelNama.Text = "Vanessa Christie";
            // 
            // gunaCirclePictureBox1
            // 
            this.gunaCirclePictureBox1.BaseColor = System.Drawing.Color.White;
            this.gunaCirclePictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("gunaCirclePictureBox1.Image")));
            this.gunaCirclePictureBox1.Location = new System.Drawing.Point(13, 12);
            this.gunaCirclePictureBox1.Name = "gunaCirclePictureBox1";
            this.gunaCirclePictureBox1.Size = new System.Drawing.Size(52, 52);
            this.gunaCirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.gunaCirclePictureBox1.TabIndex = 4;
            this.gunaCirclePictureBox1.TabStop = false;
            this.gunaCirclePictureBox1.UseTransfarantBackground = false;
            // 
            // gunaElipse4
            // 
            this.gunaElipse4.Radius = 40;
            this.gunaElipse4.TargetControl = this.SettingsPanel;
            // 
            // SettingsPanel
            // 
            this.SettingsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(218)))));
            this.SettingsPanel.Location = new System.Drawing.Point(50, 130);
            this.SettingsPanel.Name = "SettingsPanel";
            this.SettingsPanel.Size = new System.Drawing.Size(1328, 742);
            this.SettingsPanel.TabIndex = 37;
            this.SettingsPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.SettingsPanel_Paint);
            // 
            // DatePanel
            // 
            this.DatePanel.BackColor = System.Drawing.Color.Transparent;
            this.DatePanel.BaseColor = System.Drawing.Color.White;
            this.DatePanel.Controls.Add(this.LabelTanggal);
            this.DatePanel.Controls.Add(this.gunaLabel3);
            this.DatePanel.Location = new System.Drawing.Point(1198, 23);
            this.DatePanel.Name = "DatePanel";
            this.DatePanel.Radius = 10;
            this.DatePanel.ShadowColor = System.Drawing.Color.Black;
            this.DatePanel.ShadowStyle = Guna.UI.WinForms.ShadowMode.Dropped;
            this.DatePanel.Size = new System.Drawing.Size(193, 88);
            this.DatePanel.TabIndex = 36;
            // 
            // LabelTanggal
            // 
            this.LabelTanggal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelTanggal.Font = new System.Drawing.Font("Montserrat", 9F);
            this.LabelTanggal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(156)))), ((int)(((byte)(156)))));
            this.LabelTanggal.Location = new System.Drawing.Point(0, 40);
            this.LabelTanggal.Name = "LabelTanggal";
            this.LabelTanggal.Size = new System.Drawing.Size(193, 21);
            this.LabelTanggal.TabIndex = 6;
            this.LabelTanggal.Text = "22 November 2022";
            this.LabelTanggal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gunaLabel3
            // 
            this.gunaLabel3.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold);
            this.gunaLabel3.Location = new System.Drawing.Point(0, 12);
            this.gunaLabel3.Name = "gunaLabel3";
            this.gunaLabel3.Size = new System.Drawing.Size(193, 28);
            this.gunaLabel3.TabIndex = 4;
            this.gunaLabel3.Text = "DATE 🗓️";
            this.gunaLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gunaElipse5
            // 
            this.gunaElipse5.Radius = 40;
            this.gunaElipse5.TargetControl = this;
            // 
            // gunaElipse6
            // 
            this.gunaElipse6.Radius = 40;
            this.gunaElipse6.TargetControl = this;
            // 
            // FormOpen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(154)))), ((int)(((byte)(94)))));
            this.ClientSize = new System.Drawing.Size(1440, 895);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.PosisiPanel);
            this.Controls.Add(this.DatePanel);
            this.Controls.Add(this.SettingsPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormOpen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormOpen_Load);
            this.PosisiPanel.ResumeLayout(false);
            this.PosisiPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gunaCirclePictureBox1)).EndInit();
            this.DatePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI.WinForms.GunaElipse gunaElipse1;
        private Guna.UI.WinForms.GunaTileButton BackButton;
        private Guna.UI.WinForms.GunaShadowPanel PosisiPanel;
        private Guna.UI.WinForms.GunaLabel LabelPosisi;
        private Guna.UI.WinForms.GunaLabel LabelNama;
        private Guna.UI.WinForms.GunaCirclePictureBox gunaCirclePictureBox1;
        private Guna.UI.WinForms.GunaShadowPanel DatePanel;
        private Guna.UI.WinForms.GunaLabel LabelTanggal;
        private Guna.UI.WinForms.GunaLabel gunaLabel3;
        private Guna.UI.WinForms.GunaPanel SettingsPanel;
        private Guna.UI.WinForms.GunaElipse gunaElipse3;
        private Guna.UI.WinForms.GunaElipse gunaElipse2;
        private Guna.UI.WinForms.GunaElipse gunaElipse4;
        private Guna.UI.WinForms.GunaElipse gunaElipse5;
        private Guna.UI.WinForms.GunaElipse gunaElipse6;
    }
}