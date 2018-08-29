namespace Prime_Manager
{
    partial class Main
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
            this.Header_Panel = new System.Windows.Forms.Panel();
            this.Menu_Panel = new System.Windows.Forms.Panel();
            this.Exit = new System.Windows.Forms.Button();
            this.Relics = new System.Windows.Forms.Button();
            this.Items = new System.Windows.Forms.Button();
            this.Item_Panel = new System.Windows.Forms.Panel();
            this.Item_Header = new System.Windows.Forms.Panel();
            this.Item_Title = new System.Windows.Forms.TextBox();
            this.Item_Filter = new System.Windows.Forms.Panel();
            this.Item_Filter_Submit = new System.Windows.Forms.Button();
            this.Item_Filter_Type = new System.Windows.Forms.ComboBox();
            this.Item_Filter_Vaulted = new System.Windows.Forms.CheckBox();
            this.Item_Filter_Constructed = new System.Windows.Forms.CheckBox();
            this.Item_Filter_Text_Name = new System.Windows.Forms.TextBox();
            this.Item_Collection = new System.Windows.Forms.Panel();
            this.Relic_Panel = new System.Windows.Forms.Panel();
            this.Relic_Header = new System.Windows.Forms.Panel();
            this.Relic_Title = new System.Windows.Forms.TextBox();
            this.Relic_Filter = new System.Windows.Forms.Panel();
            this.Relic_Filter_Submit = new System.Windows.Forms.Button();
            this.Relic_Filter_Type = new System.Windows.Forms.ComboBox();
            this.Relic_Filter_Vaulted = new System.Windows.Forms.CheckBox();
            this.Relic_Filter_Constructed = new System.Windows.Forms.CheckBox();
            this.Relic_Filter_Text_Name = new System.Windows.Forms.TextBox();
            this.Relic_Collection = new System.Windows.Forms.Panel();
            this.Menu_Panel.SuspendLayout();
            this.Item_Panel.SuspendLayout();
            this.Item_Header.SuspendLayout();
            this.Item_Filter.SuspendLayout();
            this.Relic_Panel.SuspendLayout();
            this.Relic_Header.SuspendLayout();
            this.Relic_Filter.SuspendLayout();
            this.SuspendLayout();
            // 
            // Header_Panel
            // 
            this.Header_Panel.AutoSize = true;
            this.Header_Panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(113)))), ((int)(((byte)(155)))));
            this.Header_Panel.Location = new System.Drawing.Point(0, 0);
            this.Header_Panel.MaximumSize = new System.Drawing.Size(9999, 75);
            this.Header_Panel.MinimumSize = new System.Drawing.Size(0, 75);
            this.Header_Panel.Name = "Header_Panel";
            this.Header_Panel.Size = new System.Drawing.Size(1000, 75);
            this.Header_Panel.TabIndex = 0;
            // 
            // Menu_Panel
            // 
            this.Menu_Panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(159)))), ((int)(((byte)(219)))));
            this.Menu_Panel.Controls.Add(this.Exit);
            this.Menu_Panel.Controls.Add(this.Relics);
            this.Menu_Panel.Controls.Add(this.Items);
            this.Menu_Panel.Location = new System.Drawing.Point(0, 75);
            this.Menu_Panel.Name = "Menu_Panel";
            this.Menu_Panel.Size = new System.Drawing.Size(200, 586);
            this.Menu_Panel.TabIndex = 1;
            // 
            // Exit
            // 
            this.Exit.FlatAppearance.BorderSize = 0;
            this.Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Exit.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Exit.ForeColor = System.Drawing.Color.White;
            this.Exit.Location = new System.Drawing.Point(0, 525);
            this.Exit.Margin = new System.Windows.Forms.Padding(0);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(200, 50);
            this.Exit.TabIndex = 3;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = false;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Relics
            // 
            this.Relics.FlatAppearance.BorderSize = 0;
            this.Relics.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Relics.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Relics.ForeColor = System.Drawing.Color.White;
            this.Relics.Location = new System.Drawing.Point(0, 48);
            this.Relics.Margin = new System.Windows.Forms.Padding(0);
            this.Relics.Name = "Relics";
            this.Relics.Size = new System.Drawing.Size(200, 50);
            this.Relics.TabIndex = 2;
            this.Relics.Text = "Relics";
            this.Relics.UseVisualStyleBackColor = false;
            this.Relics.Click += new System.EventHandler(this.Relics_Click);
            // 
            // Items
            // 
            this.Items.FlatAppearance.BorderSize = 0;
            this.Items.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Items.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Items.ForeColor = System.Drawing.Color.White;
            this.Items.Location = new System.Drawing.Point(0, 0);
            this.Items.Margin = new System.Windows.Forms.Padding(0);
            this.Items.Name = "Items";
            this.Items.Size = new System.Drawing.Size(200, 50);
            this.Items.TabIndex = 1;
            this.Items.Text = "Items";
            this.Items.UseVisualStyleBackColor = false;
            this.Items.Click += new System.EventHandler(this.Items_Click);
            // 
            // Item_Panel
            // 
            this.Item_Panel.Controls.Add(this.Item_Header);
            this.Item_Panel.Controls.Add(this.Item_Filter);
            this.Item_Panel.Controls.Add(this.Item_Collection);
            this.Item_Panel.Location = new System.Drawing.Point(200, 75);
            this.Item_Panel.Margin = new System.Windows.Forms.Padding(0);
            this.Item_Panel.Name = "Item_Panel";
            this.Item_Panel.Size = new System.Drawing.Size(783, 575);
            this.Item_Panel.TabIndex = 2;
            // 
            // Item_Header
            // 
            this.Item_Header.Controls.Add(this.Item_Title);
            this.Item_Header.Location = new System.Drawing.Point(0, 0);
            this.Item_Header.Margin = new System.Windows.Forms.Padding(0);
            this.Item_Header.Name = "Item_Header";
            this.Item_Header.Size = new System.Drawing.Size(780, 60);
            this.Item_Header.TabIndex = 3;
            // 
            // Item_Title
            // 
            this.Item_Title.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Item_Title.CausesValidation = false;
            this.Item_Title.Cursor = System.Windows.Forms.Cursors.Default;
            this.Item_Title.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Item_Title.Location = new System.Drawing.Point(300, 19);
            this.Item_Title.Margin = new System.Windows.Forms.Padding(0);
            this.Item_Title.Name = "Item_Title";
            this.Item_Title.ReadOnly = true;
            this.Item_Title.Size = new System.Drawing.Size(100, 23);
            this.Item_Title.TabIndex = 0;
            this.Item_Title.Text = "Items";
            this.Item_Title.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Item_Title.WordWrap = false;
            // 
            // Item_Filter
            // 
            this.Item_Filter.Controls.Add(this.Item_Filter_Submit);
            this.Item_Filter.Controls.Add(this.Item_Filter_Type);
            this.Item_Filter.Controls.Add(this.Item_Filter_Vaulted);
            this.Item_Filter.Controls.Add(this.Item_Filter_Constructed);
            this.Item_Filter.Controls.Add(this.Item_Filter_Text_Name);
            this.Item_Filter.Location = new System.Drawing.Point(0, 60);
            this.Item_Filter.Margin = new System.Windows.Forms.Padding(0);
            this.Item_Filter.Name = "Item_Filter";
            this.Item_Filter.Size = new System.Drawing.Size(780, 100);
            this.Item_Filter.TabIndex = 4;
            // 
            // Item_Filter_Submit
            // 
            this.Item_Filter_Submit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(159)))), ((int)(((byte)(219)))));
            this.Item_Filter_Submit.FlatAppearance.BorderSize = 0;
            this.Item_Filter_Submit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Item_Filter_Submit.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Item_Filter_Submit.ForeColor = System.Drawing.Color.White;
            this.Item_Filter_Submit.Location = new System.Drawing.Point(656, 60);
            this.Item_Filter_Submit.Margin = new System.Windows.Forms.Padding(0);
            this.Item_Filter_Submit.Name = "Item_Filter_Submit";
            this.Item_Filter_Submit.Size = new System.Drawing.Size(115, 34);
            this.Item_Filter_Submit.TabIndex = 6;
            this.Item_Filter_Submit.Text = "Filter";
            this.Item_Filter_Submit.UseVisualStyleBackColor = false;
            this.Item_Filter_Submit.Click += new System.EventHandler(this.button1_Click);
            // 
            // Item_Filter_Type
            // 
            this.Item_Filter_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Item_Filter_Type.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Item_Filter_Type.FormattingEnabled = true;
            this.Item_Filter_Type.Items.AddRange(new object[] {
            "All"});
            this.Item_Filter_Type.Location = new System.Drawing.Point(17, 60);
            this.Item_Filter_Type.Name = "Item_Filter_Type";
            this.Item_Filter_Type.Size = new System.Drawing.Size(148, 24);
            this.Item_Filter_Type.TabIndex = 5;
            this.Item_Filter_Type.SelectedIndexChanged += new System.EventHandler(this.Item_Filter_Type_SelectedIndexChanged);
            // 
            // Item_Filter_Vaulted
            // 
            this.Item_Filter_Vaulted.AutoSize = true;
            this.Item_Filter_Vaulted.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Item_Filter_Vaulted.Location = new System.Drawing.Point(191, 19);
            this.Item_Filter_Vaulted.Name = "Item_Filter_Vaulted";
            this.Item_Filter_Vaulted.Size = new System.Drawing.Size(70, 20);
            this.Item_Filter_Vaulted.TabIndex = 4;
            this.Item_Filter_Vaulted.Text = "Vaulted";
            this.Item_Filter_Vaulted.UseVisualStyleBackColor = true;
            // 
            // Item_Filter_Constructed
            // 
            this.Item_Filter_Constructed.AutoSize = true;
            this.Item_Filter_Constructed.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Item_Filter_Constructed.Location = new System.Drawing.Point(191, 63);
            this.Item_Filter_Constructed.Name = "Item_Filter_Constructed";
            this.Item_Filter_Constructed.Size = new System.Drawing.Size(97, 20);
            this.Item_Filter_Constructed.TabIndex = 2;
            this.Item_Filter_Constructed.Text = "Constructed";
            this.Item_Filter_Constructed.UseVisualStyleBackColor = true;
            // 
            // Item_Filter_Text_Name
            // 
            this.Item_Filter_Text_Name.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Item_Filter_Text_Name.Location = new System.Drawing.Point(17, 16);
            this.Item_Filter_Text_Name.Name = "Item_Filter_Text_Name";
            this.Item_Filter_Text_Name.Size = new System.Drawing.Size(148, 22);
            this.Item_Filter_Text_Name.TabIndex = 1;
            this.Item_Filter_Text_Name.Text = "Filter by item name";
            this.Item_Filter_Text_Name.TextChanged += new System.EventHandler(this.Item_Filter_Text_Name_TextChanged);
            // 
            // Item_Collection
            // 
            this.Item_Collection.AutoScroll = true;
            this.Item_Collection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Item_Collection.Location = new System.Drawing.Point(0, 160);
            this.Item_Collection.Name = "Item_Collection";
            this.Item_Collection.Size = new System.Drawing.Size(780, 415);
            this.Item_Collection.TabIndex = 5;
            // 
            // Relic_Panel
            // 
            this.Relic_Panel.Controls.Add(this.Relic_Header);
            this.Relic_Panel.Controls.Add(this.Relic_Filter);
            this.Relic_Panel.Controls.Add(this.Relic_Collection);
            this.Relic_Panel.Location = new System.Drawing.Point(200, 75);
            this.Relic_Panel.Margin = new System.Windows.Forms.Padding(0);
            this.Relic_Panel.Name = "Relic_Panel";
            this.Relic_Panel.Size = new System.Drawing.Size(783, 575);
            this.Relic_Panel.TabIndex = 2;
            // 
            // Relic_Header
            // 
            this.Relic_Header.Controls.Add(this.Relic_Title);
            this.Relic_Header.Location = new System.Drawing.Point(0, 0);
            this.Relic_Header.Margin = new System.Windows.Forms.Padding(0);
            this.Relic_Header.Name = "Relic_Header";
            this.Relic_Header.Size = new System.Drawing.Size(780, 60);
            this.Relic_Header.TabIndex = 3;
            // 
            // Relic_Title
            // 
            this.Relic_Title.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Relic_Title.CausesValidation = false;
            this.Relic_Title.Cursor = System.Windows.Forms.Cursors.Default;
            this.Relic_Title.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Relic_Title.Location = new System.Drawing.Point(300, 19);
            this.Relic_Title.Margin = new System.Windows.Forms.Padding(0);
            this.Relic_Title.Name = "Relic_Title";
            this.Relic_Title.ReadOnly = true;
            this.Relic_Title.Size = new System.Drawing.Size(100, 23);
            this.Relic_Title.TabIndex = 0;
            this.Relic_Title.Text = "Items";
            this.Relic_Title.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Relic_Title.WordWrap = false;
            // 
            // Relic_Filter
            // 
            this.Relic_Filter.Controls.Add(this.Relic_Filter_Submit);
            this.Relic_Filter.Controls.Add(this.Relic_Filter_Type);
            this.Relic_Filter.Controls.Add(this.Relic_Filter_Vaulted);
            this.Relic_Filter.Controls.Add(this.Relic_Filter_Constructed);
            this.Relic_Filter.Controls.Add(this.Relic_Filter_Text_Name);
            this.Relic_Filter.Location = new System.Drawing.Point(0, 60);
            this.Relic_Filter.Margin = new System.Windows.Forms.Padding(0);
            this.Relic_Filter.Name = "Relic_Filter";
            this.Relic_Filter.Size = new System.Drawing.Size(780, 100);
            this.Relic_Filter.TabIndex = 4;
            // 
            // Relic_Filter_Submit
            // 
            this.Relic_Filter_Submit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(159)))), ((int)(((byte)(219)))));
            this.Relic_Filter_Submit.FlatAppearance.BorderSize = 0;
            this.Relic_Filter_Submit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Relic_Filter_Submit.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Relic_Filter_Submit.ForeColor = System.Drawing.Color.White;
            this.Relic_Filter_Submit.Location = new System.Drawing.Point(656, 60);
            this.Relic_Filter_Submit.Margin = new System.Windows.Forms.Padding(0);
            this.Relic_Filter_Submit.Name = "Relic_Filter_Submit";
            this.Relic_Filter_Submit.Size = new System.Drawing.Size(115, 34);
            this.Relic_Filter_Submit.TabIndex = 6;
            this.Relic_Filter_Submit.Text = "Filter";
            this.Relic_Filter_Submit.UseVisualStyleBackColor = false;
            this.Relic_Filter_Submit.Click += new System.EventHandler(this.button1_Click);
            // 
            // Relic_Filter_Type
            // 
            this.Relic_Filter_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Relic_Filter_Type.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Relic_Filter_Type.FormattingEnabled = true;
            this.Relic_Filter_Type.Items.AddRange(new object[] {
            "All"});
            this.Relic_Filter_Type.Location = new System.Drawing.Point(17, 60);
            this.Relic_Filter_Type.Name = "Relic_Filter_Type";
            this.Relic_Filter_Type.Size = new System.Drawing.Size(148, 24);
            this.Relic_Filter_Type.TabIndex = 5;
            this.Relic_Filter_Type.SelectedIndexChanged += new System.EventHandler(this.Item_Filter_Type_SelectedIndexChanged);
            // 
            // Relic_Filter_Vaulted
            // 
            this.Relic_Filter_Vaulted.AutoSize = true;
            this.Relic_Filter_Vaulted.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Relic_Filter_Vaulted.Location = new System.Drawing.Point(191, 19);
            this.Relic_Filter_Vaulted.Name = "Relic_Filter_Vaulted";
            this.Relic_Filter_Vaulted.Size = new System.Drawing.Size(70, 20);
            this.Relic_Filter_Vaulted.TabIndex = 4;
            this.Relic_Filter_Vaulted.Text = "Vaulted";
            this.Relic_Filter_Vaulted.UseVisualStyleBackColor = true;
            // 
            // Relic_Filter_Constructed
            // 
            this.Relic_Filter_Constructed.AutoSize = true;
            this.Relic_Filter_Constructed.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Relic_Filter_Constructed.Location = new System.Drawing.Point(191, 63);
            this.Relic_Filter_Constructed.Name = "Relic_Filter_Constructed";
            this.Relic_Filter_Constructed.Size = new System.Drawing.Size(97, 20);
            this.Relic_Filter_Constructed.TabIndex = 2;
            this.Relic_Filter_Constructed.Text = "Constructed";
            this.Relic_Filter_Constructed.UseVisualStyleBackColor = true;
            // 
            // Relic_Filter_Text_Name
            // 
            this.Relic_Filter_Text_Name.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Relic_Filter_Text_Name.Location = new System.Drawing.Point(17, 16);
            this.Relic_Filter_Text_Name.Name = "Relic_Filter_Text_Name";
            this.Relic_Filter_Text_Name.Size = new System.Drawing.Size(148, 22);
            this.Relic_Filter_Text_Name.TabIndex = 1;
            this.Relic_Filter_Text_Name.Text = "Filter by item name";
            this.Relic_Filter_Text_Name.TextChanged += new System.EventHandler(this.Item_Filter_Text_Name_TextChanged);
            // 
            // Relic_Collection
            // 
            this.Relic_Collection.AutoScroll = true;
            this.Relic_Collection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Relic_Collection.Location = new System.Drawing.Point(0, 160);
            this.Relic_Collection.Name = "Relic_Collection";
            this.Relic_Collection.Size = new System.Drawing.Size(780, 415);
            this.Relic_Collection.TabIndex = 5;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 657);
            this.Controls.Add(this.Header_Panel);
            this.Controls.Add(this.Menu_Panel);
            this.Controls.Add(this.Item_Panel);
            this.Controls.Add(this.Relic_Panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Main";
            this.Text = "Form1";
            this.Menu_Panel.ResumeLayout(false);
            this.Item_Panel.ResumeLayout(false);
            this.Item_Header.ResumeLayout(false);
            this.Item_Header.PerformLayout();
            this.Item_Filter.ResumeLayout(false);
            this.Item_Filter.PerformLayout();
            this.Relic_Panel.ResumeLayout(false);
            this.Relic_Header.ResumeLayout(false);
            this.Relic_Header.PerformLayout();
            this.Relic_Filter.ResumeLayout(false);
            this.Relic_Filter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Header_Panel;
        private System.Windows.Forms.Panel Menu_Panel;
        private System.Windows.Forms.Button Items;
        private System.Windows.Forms.Button Relics;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Panel Item_Panel;
        private System.Windows.Forms.TextBox Item_Title;
        private System.Windows.Forms.Panel Item_Header;
        private System.Windows.Forms.Panel Item_Filter;
        private System.Windows.Forms.TextBox Item_Filter_Text_Name;
        private System.Windows.Forms.CheckBox Item_Filter_Constructed;
        private System.Windows.Forms.CheckBox Item_Filter_Vaulted;
        private System.Windows.Forms.ComboBox Item_Filter_Type;
        public System.Windows.Forms.Panel Item_Collection;
        private System.Windows.Forms.Button Item_Filter_Submit;
        private System.Windows.Forms.Panel Relic_Panel;
        private System.Windows.Forms.Panel Relic_Header;
        private System.Windows.Forms.TextBox Relic_Title;
        private System.Windows.Forms.Panel Relic_Filter;
        private System.Windows.Forms.Button Relic_Filter_Submit;
        private System.Windows.Forms.ComboBox Relic_Filter_Type;
        private System.Windows.Forms.CheckBox Relic_Filter_Vaulted;
        private System.Windows.Forms.CheckBox Relic_Filter_Constructed;
        private System.Windows.Forms.TextBox Relic_Filter_Text_Name;
        public System.Windows.Forms.Panel Relic_Collection;
    }
}

