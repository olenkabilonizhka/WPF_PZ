
namespace AdminWF
{
    partial class StartPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartPage));
            this.styleManager1 = new MetroSet_UI.Components.StyleManager();
            this.ExitButton = new System.Windows.Forms.Button();
            this.bsPeople = new System.Windows.Forms.BindingSource(this.components);
            this.bnPeople = new System.Windows.Forms.BindingNavigator(this.components);
            this.AddNewItem = new System.Windows.Forms.ToolStripButton();
            this.IndexMaxLabel = new System.Windows.Forms.ToolStripLabel();
            this.DeleteItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.IndexTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ActivateButton = new System.Windows.Forms.ToolStripButton();
            this.BlockButton = new System.Windows.Forms.ToolStripButton();
            this.SortByNameButton = new System.Windows.Forms.ToolStripButton();
            this.GetUsersButton = new System.Windows.Forms.ToolStripButton();
            this.GetAllButton = new System.Windows.Forms.ToolStripButton();
            this.FindTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.PeopleDataGridView = new System.Windows.Forms.DataGridView();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            ((System.ComponentModel.ISupportInitialize)(this.bsPeople)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnPeople)).BeginInit();
            this.bnPeople.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PeopleDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // styleManager1
            // 
            this.styleManager1.CustomTheme = "C:\\Users\\admin.VENUS\\AppData\\Roaming\\Microsoft\\Windows\\Templates\\ThemeFile.xml";
            this.styleManager1.MetroForm = this;
            this.styleManager1.Style = MetroSet_UI.Enums.Style.Light;
            this.styleManager1.ThemeAuthor = null;
            this.styleManager1.ThemeName = null;
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ExitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ExitButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ExitButton.FlatAppearance.BorderSize = 0;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ExitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ExitButton.Location = new System.Drawing.Point(1022, 2);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(64, 33);
            this.ExitButton.TabIndex = 3;
            this.ExitButton.Text = "EXIT";
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // bnPeople
            // 
            this.bnPeople.AddNewItem = this.AddNewItem;
            this.bnPeople.AutoSize = false;
            this.bnPeople.CountItem = this.IndexMaxLabel;
            this.bnPeople.DeleteItem = this.DeleteItem;
            this.bnPeople.Dock = System.Windows.Forms.DockStyle.None;
            this.bnPeople.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.bnPeople.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripSeparator1,
            this.IndexTextBox,
            this.IndexMaxLabel,
            this.toolStripSeparator2,
            this.toolStripButton5,
            this.toolStripButton6,
            this.toolStripSeparator3,
            this.AddNewItem,
            this.DeleteItem,
            this.ActivateButton,
            this.BlockButton,
            this.SortByNameButton,
            this.GetUsersButton,
            this.GetAllButton,
            this.toolStripLabel1,
            this.FindTextBox});
            this.bnPeople.Location = new System.Drawing.Point(2, 51);
            this.bnPeople.MoveFirstItem = this.toolStripButton3;
            this.bnPeople.MoveLastItem = this.toolStripButton6;
            this.bnPeople.MoveNextItem = this.toolStripButton5;
            this.bnPeople.MovePreviousItem = this.toolStripButton4;
            this.bnPeople.Name = "bnPeople";
            this.bnPeople.PositionItem = this.IndexTextBox;
            this.bnPeople.Size = new System.Drawing.Size(1084, 42);
            this.bnPeople.TabIndex = 4;
            this.bnPeople.Text = "bindingNavigator1";
            // 
            // AddNewItem
            // 
            this.AddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("AddNewItem.Image")));
            this.AddNewItem.Margin = new System.Windows.Forms.Padding(10, 2, 10, 3);
            this.AddNewItem.Name = "AddNewItem";
            this.AddNewItem.RightToLeftAutoMirrorImage = true;
            this.AddNewItem.Size = new System.Drawing.Size(34, 37);
            this.AddNewItem.Text = "Add new";
            this.AddNewItem.Click += new System.EventHandler(this.AddNewItem_Click);
            // 
            // IndexMaxLabel
            // 
            this.IndexMaxLabel.Name = "IndexMaxLabel";
            this.IndexMaxLabel.Size = new System.Drawing.Size(54, 37);
            this.IndexMaxLabel.Text = "of {0}";
            this.IndexMaxLabel.ToolTipText = "Total number of items";
            // 
            // DeleteItem
            // 
            this.DeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("DeleteItem.Image")));
            this.DeleteItem.Margin = new System.Windows.Forms.Padding(0, 2, 10, 3);
            this.DeleteItem.Name = "DeleteItem";
            this.DeleteItem.RightToLeftAutoMirrorImage = true;
            this.DeleteItem.Size = new System.Drawing.Size(34, 37);
            this.DeleteItem.Text = "Delete";
            this.DeleteItem.Click += new System.EventHandler(this.DeleteItem_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.RightToLeftAutoMirrorImage = true;
            this.toolStripButton3.Size = new System.Drawing.Size(34, 37);
            this.toolStripButton3.Text = "Move first";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.RightToLeftAutoMirrorImage = true;
            this.toolStripButton4.Size = new System.Drawing.Size(34, 37);
            this.toolStripButton4.Text = "Move previous";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 42);
            // 
            // IndexTextBox
            // 
            this.IndexTextBox.AccessibleName = "Position";
            this.IndexTextBox.AutoSize = false;
            this.IndexTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.IndexTextBox.Name = "IndexTextBox";
            this.IndexTextBox.Size = new System.Drawing.Size(50, 31);
            this.IndexTextBox.Text = "0";
            this.IndexTextBox.ToolTipText = "Current position";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 42);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.RightToLeftAutoMirrorImage = true;
            this.toolStripButton5.Size = new System.Drawing.Size(34, 37);
            this.toolStripButton5.Text = "Move next";
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.RightToLeftAutoMirrorImage = true;
            this.toolStripButton6.Size = new System.Drawing.Size(34, 37);
            this.toolStripButton6.Text = "Move last";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 42);
            // 
            // ActivateButton
            // 
            this.ActivateButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ActivateButton.Image = ((System.Drawing.Image)(resources.GetObject("ActivateButton.Image")));
            this.ActivateButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ActivateButton.Name = "ActivateButton";
            this.ActivateButton.Size = new System.Drawing.Size(34, 37);
            this.ActivateButton.Click += new System.EventHandler(this.ActivateButton_Click);
            // 
            // BlockButton
            // 
            this.BlockButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BlockButton.Image = ((System.Drawing.Image)(resources.GetObject("BlockButton.Image")));
            this.BlockButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BlockButton.Margin = new System.Windows.Forms.Padding(10, 2, 10, 3);
            this.BlockButton.Name = "BlockButton";
            this.BlockButton.Size = new System.Drawing.Size(34, 37);
            this.BlockButton.Click += new System.EventHandler(this.BlockButton_Click);
            // 
            // SortByNameButton
            // 
            this.SortByNameButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SortByNameButton.Image = ((System.Drawing.Image)(resources.GetObject("SortByNameButton.Image")));
            this.SortByNameButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SortByNameButton.Margin = new System.Windows.Forms.Padding(0, 2, 10, 3);
            this.SortByNameButton.Name = "SortByNameButton";
            this.SortByNameButton.Size = new System.Drawing.Size(34, 37);
            this.SortByNameButton.Click += new System.EventHandler(this.SortByNameButton_Click);
            // 
            // GetUsersButton
            // 
            this.GetUsersButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.GetUsersButton.Image = ((System.Drawing.Image)(resources.GetObject("GetUsersButton.Image")));
            this.GetUsersButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.GetUsersButton.Margin = new System.Windows.Forms.Padding(0, 2, 10, 3);
            this.GetUsersButton.Name = "GetUsersButton";
            this.GetUsersButton.Size = new System.Drawing.Size(34, 37);
            this.GetUsersButton.Click += new System.EventHandler(this.GetUsersButton_Click);
            // 
            // GetAllButton
            // 
            this.GetAllButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.GetAllButton.Image = ((System.Drawing.Image)(resources.GetObject("GetAllButton.Image")));
            this.GetAllButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.GetAllButton.Margin = new System.Windows.Forms.Padding(0, 2, 10, 3);
            this.GetAllButton.Name = "GetAllButton";
            this.GetAllButton.Size = new System.Drawing.Size(34, 37);
            this.GetAllButton.Click += new System.EventHandler(this.GetAllButton_Click);
            // 
            // FindTextBox
            // 
            this.FindTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FindTextBox.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.FindTextBox.Name = "FindTextBox";
            this.FindTextBox.Size = new System.Drawing.Size(160, 42);
            this.FindTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FindTextBox_KeyDown);
            // 
            // PeopleDataGridView
            // 
            this.PeopleDataGridView.AllowUserToAddRows = false;
            this.PeopleDataGridView.AllowUserToResizeRows = false;
            this.PeopleDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.PeopleDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PeopleDataGridView.Location = new System.Drawing.Point(2, 96);
            this.PeopleDataGridView.MultiSelect = false;
            this.PeopleDataGridView.Name = "PeopleDataGridView";
            this.PeopleDataGridView.RowHeadersWidth = 62;
            this.PeopleDataGridView.RowTemplate.Height = 28;
            this.PeopleDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.PeopleDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.PeopleDataGridView.ShowCellErrors = false;
            this.PeopleDataGridView.Size = new System.Drawing.Size(1084, 479);
            this.PeopleDataGridView.TabIndex = 5;
            this.PeopleDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PeopleDataGridView_RowCellClick);
            this.PeopleDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.UsersDataGridView_CellDoubleClick);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Margin = new System.Windows.Forms.Padding(20, 2, 0, 3);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(73, 37);
            this.toolStripLabel1.Text = "Search: ";
            // 
            // StartPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1090, 581);
            this.Controls.Add(this.PeopleDataGridView);
            this.Controls.Add(this.bnPeople);
            this.Controls.Add(this.ExitButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "StartPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StartPage";
            ((System.ComponentModel.ISupportInitialize)(this.bsPeople)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnPeople)).EndInit();
            this.bnPeople.ResumeLayout(false);
            this.bnPeople.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PeopleDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private MetroSet_UI.Components.StyleManager styleManager1;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.BindingSource bsPeople;
        private System.Windows.Forms.DataGridView PeopleDataGridView;
        private System.Windows.Forms.BindingNavigator bnPeople;
        private System.Windows.Forms.ToolStripButton AddNewItem;
        private System.Windows.Forms.ToolStripLabel IndexMaxLabel;
        private System.Windows.Forms.ToolStripButton DeleteItem;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox IndexTextBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton ActivateButton;
        private System.Windows.Forms.ToolStripButton BlockButton;
        private System.Windows.Forms.ToolStripButton SortByNameButton;
        private System.Windows.Forms.ToolStripButton GetUsersButton;
        private System.Windows.Forms.ToolStripButton GetAllButton;
        private System.Windows.Forms.ToolStripTextBox FindTextBox;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
    }
}