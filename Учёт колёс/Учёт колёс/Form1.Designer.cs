namespace Учёт_колёс
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.oper = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.NS = new System.Windows.Forms.RadioButton();
            this.VS = new System.Windows.Forms.RadioButton();
            this.enter = new System.Windows.Forms.Button();
            this.meltingNumber = new System.Windows.Forms.TextBox();
            this.wheelNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.search = new System.Windows.Forms.Button();
            this.deleteAll = new System.Windows.Forms.Button();
            this.deleteCell = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // oper
            // 
            this.oper.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.oper.FormattingEnabled = true;
            this.oper.Location = new System.Drawing.Point(118, 46);
            this.oper.Name = "oper";
            this.oper.Size = new System.Drawing.Size(100, 21);
            this.oper.TabIndex = 0;
            this.oper.UseWaitCursor = true;
            this.oper.SelectedIndexChanged += new System.EventHandler(this.ComboBox1SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.NS);
            this.groupBox1.Controls.Add(this.VS);
            this.groupBox1.Location = new System.Drawing.Point(252, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(89, 62);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Сторона";
            this.groupBox1.UseWaitCursor = true;
            // 
            // NS
            // 
            this.NS.AutoSize = true;
            this.NS.Location = new System.Drawing.Point(6, 41);
            this.NS.Name = "NS";
            this.NS.Size = new System.Drawing.Size(45, 17);
            this.NS.TabIndex = 1;
            this.NS.TabStop = true;
            this.NS.Text = "Н/С";
            this.NS.UseVisualStyleBackColor = true;
            this.NS.UseWaitCursor = true;
            // 
            // VS
            // 
            this.VS.AutoSize = true;
            this.VS.Location = new System.Drawing.Point(6, 19);
            this.VS.Name = "VS";
            this.VS.Size = new System.Drawing.Size(44, 17);
            this.VS.TabIndex = 0;
            this.VS.TabStop = true;
            this.VS.Text = "В/С";
            this.VS.UseVisualStyleBackColor = true;
            this.VS.UseWaitCursor = true;
            // 
            // enter
            // 
            this.enter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.enter.Enabled = false;
            this.enter.Location = new System.Drawing.Point(118, 155);
            this.enter.Name = "enter";
            this.enter.Size = new System.Drawing.Size(100, 28);
            this.enter.TabIndex = 2;
            this.enter.Text = "Ввод";
            this.enter.UseVisualStyleBackColor = true;
            this.enter.UseWaitCursor = true;
            this.enter.Click += new System.EventHandler(this.EnterButton);
            // 
            // meltingNumber
            // 
            this.meltingNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.meltingNumber.Location = new System.Drawing.Point(118, 84);
            this.meltingNumber.Name = "meltingNumber";
            this.meltingNumber.Size = new System.Drawing.Size(100, 20);
            this.meltingNumber.TabIndex = 3;
            this.meltingNumber.UseWaitCursor = true;
            this.meltingNumber.TextChanged += new System.EventHandler(this.MeltingNumberTextChanged);
            this.meltingNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterButtonKeyDown);
            // 
            // wheelNumber
            // 
            this.wheelNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wheelNumber.Location = new System.Drawing.Point(118, 120);
            this.wheelNumber.Name = "wheelNumber";
            this.wheelNumber.Size = new System.Drawing.Size(100, 20);
            this.wheelNumber.TabIndex = 4;
            this.wheelNumber.UseWaitCursor = true;
            this.wheelNumber.TextChanged += new System.EventHandler(this.WheelNumberTextChanged);
            this.wheelNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterButtonKeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Оператор";
            this.label1.UseWaitCursor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Номер плавки";
            this.label2.UseWaitCursor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Номер колеса";
            this.label3.UseWaitCursor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dataGridView1.Location = new System.Drawing.Point(12, 203);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(329, 414);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.UseWaitCursor = true;
            // 
            // Column
            // 
            this.Column.HeaderText = "№";
            this.Column.Name = "Column";
            this.Column.Width = 30;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Номер колеса";
            this.Column2.Name = "Column2";
            this.Column2.Width = 60;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Сторона";
            this.Column3.Name = "Column3";
            this.Column3.Width = 60;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.HeaderText = "Оператор";
            this.Column4.Name = "Column4";
            // 
            // search
            // 
            this.search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.search.Location = new System.Drawing.Point(252, 110);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(89, 30);
            this.search.TabIndex = 9;
            this.search.Text = "Поиск";
            this.search.UseVisualStyleBackColor = true;
            this.search.UseWaitCursor = true;
            this.search.Click += new System.EventHandler(this.SearchButton);
            // 
            // deleteAll
            // 
            this.deleteAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.deleteAll.Location = new System.Drawing.Point(12, 623);
            this.deleteAll.Name = "deleteAll";
            this.deleteAll.Size = new System.Drawing.Size(100, 30);
            this.deleteAll.TabIndex = 10;
            this.deleteAll.Text = "Удлить все";
            this.deleteAll.UseVisualStyleBackColor = true;
            this.deleteAll.UseWaitCursor = true;
            this.deleteAll.Click += new System.EventHandler(this.DeleteAllButton);
            // 
            // deleteCell
            // 
            this.deleteCell.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.deleteCell.Location = new System.Drawing.Point(118, 623);
            this.deleteCell.Name = "deleteCell";
            this.deleteCell.Size = new System.Drawing.Size(100, 30);
            this.deleteCell.TabIndex = 11;
            this.deleteCell.Text = "Удалить строку";
            this.deleteCell.UseVisualStyleBackColor = true;
            this.deleteCell.UseWaitCursor = true;
            this.deleteCell.Click += new System.EventHandler(this.DeleteCellButton);
            // 
            // save
            // 
            this.save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.save.Enabled = false;
            this.save.Location = new System.Drawing.Point(252, 155);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(89, 30);
            this.save.TabIndex = 12;
            this.save.Text = "Сохранить";
            this.save.UseVisualStyleBackColor = true;
            this.save.UseWaitCursor = true;
            this.save.Click += new System.EventHandler(this.SaveButton);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(354, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.UseWaitCursor = true;
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenToolStripMenuItem,
            this.CreateToolStripMenuItem,
            this.SaveToolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // OpenToolStripMenuItem
            // 
            this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            this.OpenToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.OpenToolStripMenuItem.Text = "Открыть";
            this.OpenToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // CreateToolStripMenuItem
            // 
            this.CreateToolStripMenuItem.Name = "CreateToolStripMenuItem";
            this.CreateToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.CreateToolStripMenuItem.Text = "Создать";
            this.CreateToolStripMenuItem.Click += new System.EventHandler(this.CreateToolStripMenuItem_Click);
            // 
            // SaveToolStripMenuItem
            // 
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.SaveToolStripMenuItem.Text = "Сохранить               F5";
            this.SaveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItemClick);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.ExitToolStripMenuItem.Text = "Выйти";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(354, 663);
            this.Controls.Add(this.save);
            this.Controls.Add(this.deleteCell);
            this.Controls.Add(this.deleteAll);
            this.Controls.Add(this.search);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.wheelNumber);
            this.Controls.Add(this.meltingNumber);
            this.Controls.Add(this.enter);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.oper);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(370, 400);
            this.Name = "Form1";
            this.Text = "Учёт колес";
            this.UseWaitCursor = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterButtonKeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox oper;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton NS;
        private System.Windows.Forms.RadioButton VS;
        private System.Windows.Forms.Button enter;
        private System.Windows.Forms.TextBox meltingNumber;
        private System.Windows.Forms.TextBox wheelNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button search;
        private System.Windows.Forms.Button deleteAll;
        private System.Windows.Forms.Button deleteCell;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CreateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}

