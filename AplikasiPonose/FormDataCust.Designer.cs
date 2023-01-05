namespace AplikasiPonose
{
    partial class FormDataCust
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDataCust));
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            this.gunaElipse1 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.gunaElipse2 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.ChooseButton = new Guna.UI.WinForms.GunaButton();
            this.DataGridMember = new Guna.UI.WinForms.GunaDataGridView();
            this.gunaLabel3 = new Guna.UI.WinForms.GunaLabel();
            this.SearchTextBox = new Bunifu.UI.WinForms.BunifuTextBox();
            this.gunaLabel2 = new Guna.UI.WinForms.GunaLabel();
            this.gunaLabel1 = new Guna.UI.WinForms.GunaLabel();
            this.BackButton = new Guna.UI.WinForms.GunaTileButton();
            this.AddMemberButton = new Guna.UI.WinForms.GunaButton();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridMember)).BeginInit();
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
            // ChooseButton
            // 
            this.ChooseButton.AnimationHoverSpeed = 0.07F;
            this.ChooseButton.AnimationSpeed = 0.03F;
            this.ChooseButton.BackColor = System.Drawing.Color.Transparent;
            this.ChooseButton.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(66)))), ((int)(((byte)(50)))));
            this.ChooseButton.BorderColor = System.Drawing.Color.Black;
            this.ChooseButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.ChooseButton.FocusedColor = System.Drawing.Color.Empty;
            this.ChooseButton.Font = new System.Drawing.Font("Montserrat SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChooseButton.ForeColor = System.Drawing.Color.White;
            this.ChooseButton.Image = null;
            this.ChooseButton.ImageSize = new System.Drawing.Size(20, 20);
            this.ChooseButton.Location = new System.Drawing.Point(51, 819);
            this.ChooseButton.Name = "ChooseButton";
            this.ChooseButton.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.ChooseButton.OnHoverBorderColor = System.Drawing.Color.Black;
            this.ChooseButton.OnHoverForeColor = System.Drawing.Color.White;
            this.ChooseButton.OnHoverImage = null;
            this.ChooseButton.OnPressedColor = System.Drawing.Color.Black;
            this.ChooseButton.Radius = 20;
            this.ChooseButton.Size = new System.Drawing.Size(1339, 42);
            this.ChooseButton.TabIndex = 22;
            this.ChooseButton.Text = "Choose";
            this.ChooseButton.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ChooseButton.Click += new System.EventHandler(this.ChooseButton_Click);
            // 
            // DataGridMember
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.DataGridMember.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridMember.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridMember.BackgroundColor = System.Drawing.Color.White;
            this.DataGridMember.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DataGridMember.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DataGridMember.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Montserrat", 14F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridMember.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridMember.ColumnHeadersHeight = 40;
            this.DataGridMember.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Montserrat", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridMember.DefaultCellStyle = dataGridViewCellStyle3;
            this.DataGridMember.EnableHeadersVisualStyles = false;
            this.DataGridMember.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(240)))), ((int)(((byte)(221)))));
            this.DataGridMember.Location = new System.Drawing.Point(51, 154);
            this.DataGridMember.Name = "DataGridMember";
            this.DataGridMember.ReadOnly = true;
            this.DataGridMember.RowHeadersVisible = false;
            this.DataGridMember.RowHeadersWidth = 51;
            this.DataGridMember.RowTemplate.Height = 30;
            this.DataGridMember.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridMember.Size = new System.Drawing.Size(1339, 639);
            this.DataGridMember.TabIndex = 21;
            this.DataGridMember.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna;
            this.DataGridMember.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.DataGridMember.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.DataGridMember.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.DataGridMember.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.DataGridMember.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.DataGridMember.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.DataGridMember.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(240)))), ((int)(((byte)(221)))));
            this.DataGridMember.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.DataGridMember.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DataGridMember.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Montserrat", 14F, System.Drawing.FontStyle.Bold);
            this.DataGridMember.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Black;
            this.DataGridMember.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DataGridMember.ThemeStyle.HeaderStyle.Height = 40;
            this.DataGridMember.ThemeStyle.ReadOnly = true;
            this.DataGridMember.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.DataGridMember.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DataGridMember.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Montserrat", 12F);
            this.DataGridMember.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.DataGridMember.ThemeStyle.RowsStyle.Height = 30;
            this.DataGridMember.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DataGridMember.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.DataGridMember.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridMember_CellContentClick);
            // 
            // gunaLabel3
            // 
            this.gunaLabel3.AutoSize = true;
            this.gunaLabel3.Font = new System.Drawing.Font("Montserrat", 16F, System.Drawing.FontStyle.Bold);
            this.gunaLabel3.Location = new System.Drawing.Point(105, 95);
            this.gunaLabel3.Name = "gunaLabel3";
            this.gunaLabel3.Size = new System.Drawing.Size(212, 37);
            this.gunaLabel3.TabIndex = 20;
            this.gunaLabel3.Text = "Data Member";
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.AcceptsReturn = false;
            this.SearchTextBox.AcceptsTab = false;
            this.SearchTextBox.AnimationSpeed = 200;
            this.SearchTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.SearchTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.SearchTextBox.BackColor = System.Drawing.Color.Transparent;
            this.SearchTextBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SearchTextBox.BackgroundImage")));
            this.SearchTextBox.BorderColorActive = System.Drawing.Color.DodgerBlue;
            this.SearchTextBox.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.SearchTextBox.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.SearchTextBox.BorderColorIdle = System.Drawing.Color.Silver;
            this.SearchTextBox.BorderRadius = 20;
            this.SearchTextBox.BorderThickness = 1;
            this.SearchTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.SearchTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.SearchTextBox.DefaultFont = new System.Drawing.Font("Montserrat SemiBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchTextBox.DefaultText = "";
            this.SearchTextBox.FillColor = System.Drawing.Color.White;
            this.SearchTextBox.HideSelection = true;
            this.SearchTextBox.IconLeft = ((System.Drawing.Image)(resources.GetObject("SearchTextBox.IconLeft")));
            this.SearchTextBox.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.SearchTextBox.IconPadding = 10;
            this.SearchTextBox.IconRight = null;
            this.SearchTextBox.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.SearchTextBox.Lines = new string[0];
            this.SearchTextBox.Location = new System.Drawing.Point(767, 34);
            this.SearchTextBox.MaxLength = 32767;
            this.SearchTextBox.MinimumSize = new System.Drawing.Size(1, 1);
            this.SearchTextBox.Modified = false;
            this.SearchTextBox.Multiline = false;
            this.SearchTextBox.Name = "SearchTextBox";
            stateProperties1.BorderColor = System.Drawing.Color.DodgerBlue;
            stateProperties1.FillColor = System.Drawing.Color.Empty;
            stateProperties1.ForeColor = System.Drawing.Color.Empty;
            stateProperties1.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.SearchTextBox.OnActiveState = stateProperties1;
            stateProperties2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.SearchTextBox.OnDisabledState = stateProperties2;
            stateProperties3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties3.FillColor = System.Drawing.Color.Empty;
            stateProperties3.ForeColor = System.Drawing.Color.Empty;
            stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.SearchTextBox.OnHoverState = stateProperties3;
            stateProperties4.BorderColor = System.Drawing.Color.Silver;
            stateProperties4.FillColor = System.Drawing.Color.White;
            stateProperties4.ForeColor = System.Drawing.Color.Empty;
            stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.SearchTextBox.OnIdleState = stateProperties4;
            this.SearchTextBox.Padding = new System.Windows.Forms.Padding(3);
            this.SearchTextBox.PasswordChar = '\0';
            this.SearchTextBox.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.SearchTextBox.PlaceholderText = "Search Member Name";
            this.SearchTextBox.ReadOnly = false;
            this.SearchTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.SearchTextBox.SelectedText = "";
            this.SearchTextBox.SelectionLength = 0;
            this.SearchTextBox.SelectionStart = 0;
            this.SearchTextBox.ShortcutsEnabled = true;
            this.SearchTextBox.Size = new System.Drawing.Size(394, 40);
            this.SearchTextBox.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
            this.SearchTextBox.TabIndex = 18;
            this.SearchTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.SearchTextBox.TextMarginBottom = 0;
            this.SearchTextBox.TextMarginLeft = 15;
            this.SearchTextBox.TextMarginTop = 0;
            this.SearchTextBox.TextPlaceholder = "Search Member Name";
            this.SearchTextBox.UseSystemPasswordChar = false;
            this.SearchTextBox.WordWrap = true;
            this.SearchTextBox.TextChanged += new System.EventHandler(this.SearchTextBox_TextChanged);
            // 
            // gunaLabel2
            // 
            this.gunaLabel2.AutoSize = true;
            this.gunaLabel2.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel2.Location = new System.Drawing.Point(327, 40);
            this.gunaLabel2.Name = "gunaLabel2";
            this.gunaLabel2.Size = new System.Drawing.Size(157, 28);
            this.gunaLabel2.TabIndex = 17;
            this.gunaLabel2.Text = "Data Member";
            // 
            // gunaLabel1
            // 
            this.gunaLabel1.AutoSize = true;
            this.gunaLabel1.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel1.ForeColor = System.Drawing.Color.Black;
            this.gunaLabel1.Location = new System.Drawing.Point(107, 40);
            this.gunaLabel1.Name = "gunaLabel1";
            this.gunaLabel1.Size = new System.Drawing.Size(214, 28);
            this.gunaLabel1.TabIndex = 16;
            this.gunaLabel1.Text = "Dashboard > Kasir >";
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
            this.BackButton.Location = new System.Drawing.Point(51, 34);
            this.BackButton.Name = "BackButton";
            this.BackButton.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.BackButton.OnHoverBorderColor = System.Drawing.Color.Black;
            this.BackButton.OnHoverForeColor = System.Drawing.Color.White;
            this.BackButton.OnHoverImage = null;
            this.BackButton.OnPressedColor = System.Drawing.Color.Black;
            this.BackButton.Radius = 10;
            this.BackButton.Size = new System.Drawing.Size(40, 40);
            this.BackButton.TabIndex = 15;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // AddMemberButton
            // 
            this.AddMemberButton.AnimationHoverSpeed = 0.07F;
            this.AddMemberButton.AnimationSpeed = 0.03F;
            this.AddMemberButton.BackColor = System.Drawing.Color.Transparent;
            this.AddMemberButton.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(121)))), ((int)(((byte)(71)))));
            this.AddMemberButton.BorderColor = System.Drawing.Color.Black;
            this.AddMemberButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.AddMemberButton.FocusedColor = System.Drawing.Color.Empty;
            this.AddMemberButton.Font = new System.Drawing.Font("Montserrat SemiBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddMemberButton.ForeColor = System.Drawing.Color.White;
            this.AddMemberButton.Image = null;
            this.AddMemberButton.ImageSize = new System.Drawing.Size(20, 20);
            this.AddMemberButton.Location = new System.Drawing.Point(1189, 34);
            this.AddMemberButton.Name = "AddMemberButton";
            this.AddMemberButton.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.AddMemberButton.OnHoverBorderColor = System.Drawing.Color.Black;
            this.AddMemberButton.OnHoverForeColor = System.Drawing.Color.White;
            this.AddMemberButton.OnHoverImage = null;
            this.AddMemberButton.OnPressedColor = System.Drawing.Color.Black;
            this.AddMemberButton.Radius = 10;
            this.AddMemberButton.Size = new System.Drawing.Size(201, 40);
            this.AddMemberButton.TabIndex = 19;
            this.AddMemberButton.Text = "+ Add Member";
            this.AddMemberButton.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.AddMemberButton.Click += new System.EventHandler(this.AddMemberButton_Click);
            // 
            // FormDataCust
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(240)))), ((int)(((byte)(221)))));
            this.ClientSize = new System.Drawing.Size(1440, 895);
            this.Controls.Add(this.ChooseButton);
            this.Controls.Add(this.DataGridMember);
            this.Controls.Add(this.gunaLabel3);
            this.Controls.Add(this.SearchTextBox);
            this.Controls.Add(this.AddMemberButton);
            this.Controls.Add(this.gunaLabel2);
            this.Controls.Add(this.gunaLabel1);
            this.Controls.Add(this.BackButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormDataCust";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormDataCust_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridMember)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI.WinForms.GunaElipse gunaElipse1;
        private Guna.UI.WinForms.GunaButton ChooseButton;
        private Guna.UI.WinForms.GunaDataGridView DataGridMember;
        private Guna.UI.WinForms.GunaLabel gunaLabel3;
        private Bunifu.UI.WinForms.BunifuTextBox SearchTextBox;
        private Guna.UI.WinForms.GunaLabel gunaLabel2;
        private Guna.UI.WinForms.GunaLabel gunaLabel1;
        private Guna.UI.WinForms.GunaTileButton BackButton;
        private Guna.UI.WinForms.GunaElipse gunaElipse2;
        private Guna.UI.WinForms.GunaButton AddMemberButton;
    }
}