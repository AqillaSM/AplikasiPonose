namespace AplikasiPonose
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties5 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties6 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties7 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties8 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            this.gunaElipse1 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.gunaPanel2 = new Guna.UI.WinForms.GunaPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gunaElipsePanel1 = new Guna.UI.WinForms.GunaElipsePanel();
            this.CloseButton = new Guna.UI.WinForms.GunaButton();
            this.LoginButton = new Guna.UI.WinForms.GunaButton();
            this.PasswordTextBox = new Bunifu.UI.WinForms.BunifuTextBox();
            this.UsernameTextBox = new Bunifu.UI.WinForms.BunifuTextBox();
            this.gunaPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gunaElipsePanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gunaElipse1
            // 
            this.gunaElipse1.Radius = 40;
            this.gunaElipse1.TargetControl = this;
            // 
            // gunaPanel2
            // 
            this.gunaPanel2.BackColor = System.Drawing.Color.Black;
            this.gunaPanel2.Controls.Add(this.pictureBox1);
            this.gunaPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.gunaPanel2.Location = new System.Drawing.Point(0, 0);
            this.gunaPanel2.Name = "gunaPanel2";
            this.gunaPanel2.Size = new System.Drawing.Size(1440, 94);
            this.gunaPanel2.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(629, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(188, 94);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // gunaElipsePanel1
            // 
            this.gunaElipsePanel1.BackColor = System.Drawing.Color.Transparent;
            this.gunaElipsePanel1.BaseColor = System.Drawing.Color.White;
            this.gunaElipsePanel1.Controls.Add(this.CloseButton);
            this.gunaElipsePanel1.Controls.Add(this.LoginButton);
            this.gunaElipsePanel1.Controls.Add(this.PasswordTextBox);
            this.gunaElipsePanel1.Controls.Add(this.UsernameTextBox);
            this.gunaElipsePanel1.Location = new System.Drawing.Point(376, 186);
            this.gunaElipsePanel1.Name = "gunaElipsePanel1";
            this.gunaElipsePanel1.Radius = 20;
            this.gunaElipsePanel1.Size = new System.Drawing.Size(759, 501);
            this.gunaElipsePanel1.TabIndex = 3;
            // 
            // CloseButton
            // 
            this.CloseButton.AnimationHoverSpeed = 0.07F;
            this.CloseButton.AnimationSpeed = 0.03F;
            this.CloseButton.BackColor = System.Drawing.Color.Transparent;
            this.CloseButton.BaseColor = System.Drawing.Color.White;
            this.CloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.CloseButton.BorderSize = 1;
            this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.CloseButton.FocusedColor = System.Drawing.Color.Empty;
            this.CloseButton.Font = new System.Drawing.Font("Montserrat", 14F);
            this.CloseButton.ForeColor = System.Drawing.Color.Black;
            this.CloseButton.Image = null;
            this.CloseButton.ImageSize = new System.Drawing.Size(20, 20);
            this.CloseButton.Location = new System.Drawing.Point(133, 338);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.CloseButton.OnHoverBorderColor = System.Drawing.Color.Black;
            this.CloseButton.OnHoverForeColor = System.Drawing.Color.White;
            this.CloseButton.OnHoverImage = null;
            this.CloseButton.OnPressedColor = System.Drawing.Color.Black;
            this.CloseButton.Radius = 20;
            this.CloseButton.Size = new System.Drawing.Size(517, 60);
            this.CloseButton.TabIndex = 4;
            this.CloseButton.Text = "Close";
            this.CloseButton.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // LoginButton
            // 
            this.LoginButton.AnimationHoverSpeed = 0.07F;
            this.LoginButton.AnimationSpeed = 0.03F;
            this.LoginButton.BackColor = System.Drawing.Color.Transparent;
            this.LoginButton.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(121)))), ((int)(((byte)(71)))));
            this.LoginButton.BorderColor = System.Drawing.Color.Black;
            this.LoginButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.LoginButton.FocusedColor = System.Drawing.Color.Empty;
            this.LoginButton.Font = new System.Drawing.Font("Montserrat", 14F);
            this.LoginButton.ForeColor = System.Drawing.Color.White;
            this.LoginButton.Image = null;
            this.LoginButton.ImageSize = new System.Drawing.Size(20, 20);
            this.LoginButton.Location = new System.Drawing.Point(133, 259);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.LoginButton.OnHoverBorderColor = System.Drawing.Color.Black;
            this.LoginButton.OnHoverForeColor = System.Drawing.Color.White;
            this.LoginButton.OnHoverImage = null;
            this.LoginButton.OnPressedColor = System.Drawing.Color.Black;
            this.LoginButton.Radius = 20;
            this.LoginButton.Size = new System.Drawing.Size(517, 60);
            this.LoginButton.TabIndex = 2;
            this.LoginButton.Text = "Login";
            this.LoginButton.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.AcceptsReturn = false;
            this.PasswordTextBox.AcceptsTab = false;
            this.PasswordTextBox.AnimationSpeed = 200;
            this.PasswordTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.PasswordTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.PasswordTextBox.BackColor = System.Drawing.Color.Transparent;
            this.PasswordTextBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PasswordTextBox.BackgroundImage")));
            this.PasswordTextBox.BorderColorActive = System.Drawing.Color.DodgerBlue;
            this.PasswordTextBox.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.PasswordTextBox.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.PasswordTextBox.BorderColorIdle = System.Drawing.Color.Silver;
            this.PasswordTextBox.BorderRadius = 20;
            this.PasswordTextBox.BorderThickness = 1;
            this.PasswordTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.PasswordTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.PasswordTextBox.DefaultFont = new System.Drawing.Font("Montserrat", 14F);
            this.PasswordTextBox.DefaultText = "";
            this.PasswordTextBox.FillColor = System.Drawing.Color.White;
            this.PasswordTextBox.HideSelection = true;
            this.PasswordTextBox.IconLeft = ((System.Drawing.Image)(resources.GetObject("PasswordTextBox.IconLeft")));
            this.PasswordTextBox.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.PasswordTextBox.IconPadding = 10;
            this.PasswordTextBox.IconRight = null;
            this.PasswordTextBox.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.PasswordTextBox.Lines = new string[0];
            this.PasswordTextBox.Location = new System.Drawing.Point(98, 175);
            this.PasswordTextBox.MaxLength = 32767;
            this.PasswordTextBox.MinimumSize = new System.Drawing.Size(1, 1);
            this.PasswordTextBox.Modified = false;
            this.PasswordTextBox.Multiline = false;
            this.PasswordTextBox.Name = "PasswordTextBox";
            stateProperties1.BorderColor = System.Drawing.Color.DodgerBlue;
            stateProperties1.FillColor = System.Drawing.Color.Empty;
            stateProperties1.ForeColor = System.Drawing.Color.Empty;
            stateProperties1.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.PasswordTextBox.OnActiveState = stateProperties1;
            stateProperties2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.PasswordTextBox.OnDisabledState = stateProperties2;
            stateProperties3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties3.FillColor = System.Drawing.Color.Empty;
            stateProperties3.ForeColor = System.Drawing.Color.Empty;
            stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.PasswordTextBox.OnHoverState = stateProperties3;
            stateProperties4.BorderColor = System.Drawing.Color.Silver;
            stateProperties4.FillColor = System.Drawing.Color.White;
            stateProperties4.ForeColor = System.Drawing.Color.Empty;
            stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.PasswordTextBox.OnIdleState = stateProperties4;
            this.PasswordTextBox.Padding = new System.Windows.Forms.Padding(3);
            this.PasswordTextBox.PasswordChar = '\0';
            this.PasswordTextBox.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.PasswordTextBox.PlaceholderText = "";
            this.PasswordTextBox.ReadOnly = false;
            this.PasswordTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.PasswordTextBox.SelectedText = "";
            this.PasswordTextBox.SelectionLength = 0;
            this.PasswordTextBox.SelectionStart = 0;
            this.PasswordTextBox.ShortcutsEnabled = true;
            this.PasswordTextBox.Size = new System.Drawing.Size(592, 60);
            this.PasswordTextBox.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
            this.PasswordTextBox.TabIndex = 1;
            this.PasswordTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.PasswordTextBox.TextMarginBottom = 0;
            this.PasswordTextBox.TextMarginLeft = 20;
            this.PasswordTextBox.TextMarginTop = 0;
            this.PasswordTextBox.TextPlaceholder = "";
            this.PasswordTextBox.UseSystemPasswordChar = false;
            this.PasswordTextBox.WordWrap = true;
            // 
            // UsernameTextBox
            // 
            this.UsernameTextBox.AcceptsReturn = false;
            this.UsernameTextBox.AcceptsTab = false;
            this.UsernameTextBox.AnimationSpeed = 200;
            this.UsernameTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.UsernameTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.UsernameTextBox.BackColor = System.Drawing.Color.Transparent;
            this.UsernameTextBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("UsernameTextBox.BackgroundImage")));
            this.UsernameTextBox.BorderColorActive = System.Drawing.Color.DodgerBlue;
            this.UsernameTextBox.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.UsernameTextBox.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.UsernameTextBox.BorderColorIdle = System.Drawing.Color.Silver;
            this.UsernameTextBox.BorderRadius = 20;
            this.UsernameTextBox.BorderThickness = 1;
            this.UsernameTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.UsernameTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.UsernameTextBox.DefaultFont = new System.Drawing.Font("Montserrat", 14F);
            this.UsernameTextBox.DefaultText = "";
            this.UsernameTextBox.FillColor = System.Drawing.Color.White;
            this.UsernameTextBox.HideSelection = true;
            this.UsernameTextBox.IconLeft = ((System.Drawing.Image)(resources.GetObject("UsernameTextBox.IconLeft")));
            this.UsernameTextBox.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.UsernameTextBox.IconPadding = 10;
            this.UsernameTextBox.IconRight = null;
            this.UsernameTextBox.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.UsernameTextBox.Lines = new string[0];
            this.UsernameTextBox.Location = new System.Drawing.Point(98, 98);
            this.UsernameTextBox.MaxLength = 32767;
            this.UsernameTextBox.MinimumSize = new System.Drawing.Size(1, 1);
            this.UsernameTextBox.Modified = false;
            this.UsernameTextBox.Multiline = false;
            this.UsernameTextBox.Name = "UsernameTextBox";
            stateProperties5.BorderColor = System.Drawing.Color.DodgerBlue;
            stateProperties5.FillColor = System.Drawing.Color.Empty;
            stateProperties5.ForeColor = System.Drawing.Color.Empty;
            stateProperties5.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.UsernameTextBox.OnActiveState = stateProperties5;
            stateProperties6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties6.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties6.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.UsernameTextBox.OnDisabledState = stateProperties6;
            stateProperties7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties7.FillColor = System.Drawing.Color.Empty;
            stateProperties7.ForeColor = System.Drawing.Color.Empty;
            stateProperties7.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.UsernameTextBox.OnHoverState = stateProperties7;
            stateProperties8.BorderColor = System.Drawing.Color.Silver;
            stateProperties8.FillColor = System.Drawing.Color.White;
            stateProperties8.ForeColor = System.Drawing.Color.Empty;
            stateProperties8.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.UsernameTextBox.OnIdleState = stateProperties8;
            this.UsernameTextBox.Padding = new System.Windows.Forms.Padding(3);
            this.UsernameTextBox.PasswordChar = '\0';
            this.UsernameTextBox.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.UsernameTextBox.PlaceholderText = "Username";
            this.UsernameTextBox.ReadOnly = false;
            this.UsernameTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.UsernameTextBox.SelectedText = "";
            this.UsernameTextBox.SelectionLength = 0;
            this.UsernameTextBox.SelectionStart = 0;
            this.UsernameTextBox.ShortcutsEnabled = true;
            this.UsernameTextBox.Size = new System.Drawing.Size(592, 60);
            this.UsernameTextBox.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
            this.UsernameTextBox.TabIndex = 0;
            this.UsernameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.UsernameTextBox.TextMarginBottom = 0;
            this.UsernameTextBox.TextMarginLeft = 20;
            this.UsernameTextBox.TextMarginTop = 0;
            this.UsernameTextBox.TextPlaceholder = "Username";
            this.UsernameTextBox.UseSystemPasswordChar = false;
            this.UsernameTextBox.WordWrap = true;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(240)))), ((int)(((byte)(221)))));
            this.ClientSize = new System.Drawing.Size(1440, 895);
            this.Controls.Add(this.gunaElipsePanel1);
            this.Controls.Add(this.gunaPanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.gunaPanel2.ResumeLayout(false);
            this.gunaPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gunaElipsePanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI.WinForms.GunaElipse gunaElipse1;
        private Guna.UI.WinForms.GunaElipsePanel gunaElipsePanel1;
        private Guna.UI.WinForms.GunaButton LoginButton;
        private Bunifu.UI.WinForms.BunifuTextBox PasswordTextBox;
        private Bunifu.UI.WinForms.BunifuTextBox UsernameTextBox;
        private Guna.UI.WinForms.GunaPanel gunaPanel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI.WinForms.GunaButton CloseButton;
    }
}

