namespace AplikasiPonose
{
    partial class FormInputTax
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInputTax));
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            this.gunaElipse1 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.gunaElipse2 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.SubmitButton = new Guna.UI.WinForms.GunaButton();
            this.TaxTextBox = new Bunifu.UI.WinForms.BunifuTextBox();
            this.NameTextBoxx = new Guna.UI.WinForms.GunaLabel();
            this.gunaLabel3 = new Guna.UI.WinForms.GunaLabel();
            this.BackButton = new Guna.UI.WinForms.GunaTileButton();
            this.SuspendLayout();
            // 
            // gunaElipse1
            // 
            this.gunaElipse1.Radius = 40;
            this.gunaElipse1.TargetControl = this;
            // 
            // gunaElipse2
            // 
            this.gunaElipse2.Radius = 40;
            this.gunaElipse2.TargetControl = this;
            // 
            // SubmitButton
            // 
            this.SubmitButton.AnimationHoverSpeed = 0.07F;
            this.SubmitButton.AnimationSpeed = 0.03F;
            this.SubmitButton.BackColor = System.Drawing.Color.Transparent;
            this.SubmitButton.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(121)))), ((int)(((byte)(71)))));
            this.SubmitButton.BorderColor = System.Drawing.Color.Black;
            this.SubmitButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.SubmitButton.FocusedColor = System.Drawing.Color.Empty;
            this.SubmitButton.Font = new System.Drawing.Font("Montserrat Medium", 13F, System.Drawing.FontStyle.Bold);
            this.SubmitButton.ForeColor = System.Drawing.Color.White;
            this.SubmitButton.Image = ((System.Drawing.Image)(resources.GetObject("SubmitButton.Image")));
            this.SubmitButton.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SubmitButton.ImageSize = new System.Drawing.Size(20, 20);
            this.SubmitButton.Location = new System.Drawing.Point(528, 339);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.SubmitButton.OnHoverBorderColor = System.Drawing.Color.Black;
            this.SubmitButton.OnHoverForeColor = System.Drawing.Color.White;
            this.SubmitButton.OnHoverImage = null;
            this.SubmitButton.OnPressedColor = System.Drawing.Color.Black;
            this.SubmitButton.Radius = 20;
            this.SubmitButton.Size = new System.Drawing.Size(186, 49);
            this.SubmitButton.TabIndex = 28;
            this.SubmitButton.Text = "Save";
            this.SubmitButton.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // TaxTextBox
            // 
            this.TaxTextBox.AcceptsReturn = false;
            this.TaxTextBox.AcceptsTab = false;
            this.TaxTextBox.AnimationSpeed = 200;
            this.TaxTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.TaxTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.TaxTextBox.BackColor = System.Drawing.Color.Transparent;
            this.TaxTextBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TaxTextBox.BackgroundImage")));
            this.TaxTextBox.BorderColorActive = System.Drawing.Color.DodgerBlue;
            this.TaxTextBox.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.TaxTextBox.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.TaxTextBox.BorderColorIdle = System.Drawing.Color.Silver;
            this.TaxTextBox.BorderRadius = 20;
            this.TaxTextBox.BorderThickness = 1;
            this.TaxTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.TaxTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TaxTextBox.DefaultFont = new System.Drawing.Font("Montserrat Medium", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaxTextBox.DefaultText = "";
            this.TaxTextBox.FillColor = System.Drawing.Color.White;
            this.TaxTextBox.HideSelection = true;
            this.TaxTextBox.IconLeft = null;
            this.TaxTextBox.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.TaxTextBox.IconPadding = 10;
            this.TaxTextBox.IconRight = ((System.Drawing.Image)(resources.GetObject("TaxTextBox.IconRight")));
            this.TaxTextBox.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.TaxTextBox.Lines = new string[0];
            this.TaxTextBox.Location = new System.Drawing.Point(53, 218);
            this.TaxTextBox.MaxLength = 32767;
            this.TaxTextBox.MinimumSize = new System.Drawing.Size(1, 1);
            this.TaxTextBox.Modified = false;
            this.TaxTextBox.Multiline = false;
            this.TaxTextBox.Name = "TaxTextBox";
            stateProperties1.BorderColor = System.Drawing.Color.DodgerBlue;
            stateProperties1.FillColor = System.Drawing.Color.Empty;
            stateProperties1.ForeColor = System.Drawing.Color.Empty;
            stateProperties1.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.TaxTextBox.OnActiveState = stateProperties1;
            stateProperties2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.TaxTextBox.OnDisabledState = stateProperties2;
            stateProperties3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties3.FillColor = System.Drawing.Color.Empty;
            stateProperties3.ForeColor = System.Drawing.Color.Empty;
            stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.TaxTextBox.OnHoverState = stateProperties3;
            stateProperties4.BorderColor = System.Drawing.Color.Silver;
            stateProperties4.FillColor = System.Drawing.Color.White;
            stateProperties4.ForeColor = System.Drawing.Color.Empty;
            stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.TaxTextBox.OnIdleState = stateProperties4;
            this.TaxTextBox.Padding = new System.Windows.Forms.Padding(3);
            this.TaxTextBox.PasswordChar = '\0';
            this.TaxTextBox.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.TaxTextBox.PlaceholderText = "Enter text";
            this.TaxTextBox.ReadOnly = false;
            this.TaxTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TaxTextBox.SelectedText = "";
            this.TaxTextBox.SelectionLength = 0;
            this.TaxTextBox.SelectionStart = 0;
            this.TaxTextBox.ShortcutsEnabled = true;
            this.TaxTextBox.Size = new System.Drawing.Size(661, 63);
            this.TaxTextBox.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
            this.TaxTextBox.TabIndex = 27;
            this.TaxTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.TaxTextBox.TextMarginBottom = 0;
            this.TaxTextBox.TextMarginLeft = 3;
            this.TaxTextBox.TextMarginTop = 0;
            this.TaxTextBox.TextPlaceholder = "Enter text";
            this.TaxTextBox.UseSystemPasswordChar = false;
            this.TaxTextBox.WordWrap = true;
            this.TaxTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TaxTextBox_KeyPress);
            // 
            // NameTextBoxx
            // 
            this.NameTextBoxx.AutoSize = true;
            this.NameTextBoxx.Font = new System.Drawing.Font("Montserrat Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameTextBoxx.Location = new System.Drawing.Point(48, 187);
            this.NameTextBoxx.Name = "NameTextBoxx";
            this.NameTextBoxx.Size = new System.Drawing.Size(192, 28);
            this.NameTextBoxx.TabIndex = 26;
            this.NameTextBoxx.Text = "New Percentage";
            // 
            // gunaLabel3
            // 
            this.gunaLabel3.AutoSize = true;
            this.gunaLabel3.Font = new System.Drawing.Font("Montserrat", 16F, System.Drawing.FontStyle.Bold);
            this.gunaLabel3.Location = new System.Drawing.Point(46, 128);
            this.gunaLabel3.Name = "gunaLabel3";
            this.gunaLabel3.Size = new System.Drawing.Size(359, 37);
            this.gunaLabel3.TabIndex = 25;
            this.gunaLabel3.Text = "Change Tax Percentage";
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
            this.BackButton.Location = new System.Drawing.Point(53, 54);
            this.BackButton.Name = "BackButton";
            this.BackButton.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.BackButton.OnHoverBorderColor = System.Drawing.Color.Black;
            this.BackButton.OnHoverForeColor = System.Drawing.Color.White;
            this.BackButton.OnHoverImage = null;
            this.BackButton.OnPressedColor = System.Drawing.Color.Black;
            this.BackButton.Radius = 10;
            this.BackButton.Size = new System.Drawing.Size(40, 40);
            this.BackButton.TabIndex = 24;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // FormInputTax
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(240)))), ((int)(((byte)(221)))));
            this.ClientSize = new System.Drawing.Size(760, 443);
            this.Controls.Add(this.SubmitButton);
            this.Controls.Add(this.TaxTextBox);
            this.Controls.Add(this.NameTextBoxx);
            this.Controls.Add(this.gunaLabel3);
            this.Controls.Add(this.BackButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormInputTax";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormInputTax_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI.WinForms.GunaElipse gunaElipse1;
        private Guna.UI.WinForms.GunaButton SubmitButton;
        private Bunifu.UI.WinForms.BunifuTextBox TaxTextBox;
        private Guna.UI.WinForms.GunaLabel NameTextBoxx;
        private Guna.UI.WinForms.GunaLabel gunaLabel3;
        private Guna.UI.WinForms.GunaTileButton BackButton;
        private Guna.UI.WinForms.GunaElipse gunaElipse2;
    }
}