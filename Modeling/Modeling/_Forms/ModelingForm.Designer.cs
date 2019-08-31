using System.Windows.Forms;

namespace Modeling
{
    partial class ModelingForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModelingForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.buttonSysleStart = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.programToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parameterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.programToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.parameterToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.найтиИЗаменитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.перенумероватьКадрыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выйтиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.labelZ = new System.Windows.Forms.Label();
            this.labelX = new System.Windows.Forms.Label();
            this.buttonSingleBlock = new System.Windows.Forms.Button();
            this.N = new System.Windows.Forms.Label();
            this.coorX = new System.Windows.Forms.Label();
            this.coorZ = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.checkBoxShowError = new System.Windows.Forms.CheckBox();
            this.buttonStart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pictureBox1.Location = new System.Drawing.Point(2, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(634, 404);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.SizeChanged += new System.EventHandler(this.PictureBox1_SizeChanged);
            this.pictureBox1.DoubleClick += new System.EventHandler(this.PictureBox1_DoubleClick);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseUp);
            // 
            // richTextBox1
            // 
            this.richTextBox1.DetectUrls = false;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox1.Location = new System.Drawing.Point(3, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ShowSelectionMargin = true;
            this.richTextBox1.Size = new System.Drawing.Size(307, 506);
            this.richTextBox1.TabIndex = 12;
            this.richTextBox1.Text = "";
            this.richTextBox1.WordWrap = false;
            this.richTextBox1.TextChanged += new System.EventHandler(this.RichTextBox1_TextChanged);
            this.richTextBox1.DoubleClick += new System.EventHandler(this.richTextBox1_DoubleClick);
            // 
            // buttonSysleStart
            // 
            this.buttonSysleStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSysleStart.BackColor = System.Drawing.Color.LightGreen;
            this.buttonSysleStart.Enabled = false;
            this.buttonSysleStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonSysleStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSysleStart.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonSysleStart.Location = new System.Drawing.Point(3, 417);
            this.buttonSysleStart.Name = "buttonSysleStart";
            this.buttonSysleStart.Size = new System.Drawing.Size(75, 35);
            this.buttonSysleStart.TabIndex = 2;
            this.buttonSysleStart.Text = "CYCLE START";
            this.buttonSysleStart.UseVisualStyleBackColor = false;
            this.buttonSysleStart.Click += new System.EventHandler(this.ButtonSysleStart_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonReset.AutoSize = true;
            this.buttonReset.BackColor = System.Drawing.Color.IndianRed;
            this.buttonReset.Enabled = false;
            this.buttonReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonReset.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonReset.Location = new System.Drawing.Point(3, 499);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 35);
            this.buttonReset.TabIndex = 3;
            this.buttonReset.Text = "RESET";
            this.buttonReset.UseVisualStyleBackColor = false;
            this.buttonReset.Click += new System.EventHandler(this.ButtonReset_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(973, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.сохранитьToolStripMenuItem,
            this.найтиИЗаменитьToolStripMenuItem,
            this.перенумероватьКадрыToolStripMenuItem,
            this.выйтиToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.programToolStripMenuItem,
            this.parameterToolStripMenuItem});
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.открытьToolStripMenuItem.Text = "Открыть";
            // 
            // programToolStripMenuItem
            // 
            this.programToolStripMenuItem.Name = "programToolStripMenuItem";
            this.programToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.programToolStripMenuItem.Text = "Program";
            this.programToolStripMenuItem.Click += new System.EventHandler(this.ProgramOpenToolStripMenuItem_Click);
            // 
            // parameterToolStripMenuItem
            // 
            this.parameterToolStripMenuItem.Name = "parameterToolStripMenuItem";
            this.parameterToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.parameterToolStripMenuItem.Text = "Parameter";
            this.parameterToolStripMenuItem.Click += new System.EventHandler(this.ParameterOpenToolStripMenuItem_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.programToolStripMenuItem1,
            this.parameterToolStripMenuItem1});
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            // 
            // programToolStripMenuItem1
            // 
            this.programToolStripMenuItem1.Name = "programToolStripMenuItem1";
            this.programToolStripMenuItem1.Size = new System.Drawing.Size(128, 22);
            this.programToolStripMenuItem1.Text = "Program";
            this.programToolStripMenuItem1.Click += new System.EventHandler(this.ProgramSaveToolStripMenuItem1_Click);
            // 
            // parameterToolStripMenuItem1
            // 
            this.parameterToolStripMenuItem1.Name = "parameterToolStripMenuItem1";
            this.parameterToolStripMenuItem1.Size = new System.Drawing.Size(128, 22);
            this.parameterToolStripMenuItem1.Text = "Parameter";
            this.parameterToolStripMenuItem1.Click += new System.EventHandler(this.ParameterSaveToolStripMenuItem1_Click);
            // 
            // найтиИЗаменитьToolStripMenuItem
            // 
            this.найтиИЗаменитьToolStripMenuItem.Name = "найтиИЗаменитьToolStripMenuItem";
            this.найтиИЗаменитьToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.найтиИЗаменитьToolStripMenuItem.Text = "Найти и заменить";
            this.найтиИЗаменитьToolStripMenuItem.Click += new System.EventHandler(this.FindAndReplaceToolStripMenuItem_Click);
            // 
            // перенумероватьКадрыToolStripMenuItem
            // 
            this.перенумероватьКадрыToolStripMenuItem.Name = "перенумероватьКадрыToolStripMenuItem";
            this.перенумероватьКадрыToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.перенумероватьКадрыToolStripMenuItem.Text = "Перенумеровать кадры";
            this.перенумероватьКадрыToolStripMenuItem.Click += new System.EventHandler(this.RenumberFramesToolStripMenuItem_Click);
            // 
            // выйтиToolStripMenuItem
            // 
            this.выйтиToolStripMenuItem.Name = "выйтиToolStripMenuItem";
            this.выйтиToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.выйтиToolStripMenuItem.Text = "Выйти";
            this.выйтиToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оПрограммеToolStripMenuItem});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.AboutTheProgramToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(562, 378);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "100%";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // labelZ
            // 
            this.labelZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelZ.AutoSize = true;
            this.labelZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelZ.Location = new System.Drawing.Point(480, 378);
            this.labelZ.Name = "labelZ";
            this.labelZ.Size = new System.Drawing.Size(17, 17);
            this.labelZ.TabIndex = 6;
            this.labelZ.Text = "Z";
            // 
            // labelX
            // 
            this.labelX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelX.AutoSize = true;
            this.labelX.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelX.Location = new System.Drawing.Point(380, 378);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(17, 17);
            this.labelX.TabIndex = 7;
            this.labelX.Text = "X";
            // 
            // buttonSingleBlock
            // 
            this.buttonSingleBlock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSingleBlock.BackColor = System.Drawing.Color.AliceBlue;
            this.buttonSingleBlock.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonSingleBlock.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSingleBlock.ForeColor = System.Drawing.Color.Black;
            this.buttonSingleBlock.Location = new System.Drawing.Point(3, 458);
            this.buttonSingleBlock.Name = "buttonSingleBlock";
            this.buttonSingleBlock.Size = new System.Drawing.Size(75, 35);
            this.buttonSingleBlock.TabIndex = 8;
            this.buttonSingleBlock.Text = "SINGLE BLOCK";
            this.buttonSingleBlock.UseVisualStyleBackColor = false;
            this.buttonSingleBlock.Click += new System.EventHandler(this.ButtonSingleBlock_Click);
            // 
            // N
            // 
            this.N.AutoSize = true;
            this.N.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.N.Location = new System.Drawing.Point(16, 25);
            this.N.Name = "N";
            this.N.Size = new System.Drawing.Size(18, 17);
            this.N.TabIndex = 13;
            this.N.Text = "N";
            // 
            // coorX
            // 
            this.coorX.AutoSize = true;
            this.coorX.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.coorX.Location = new System.Drawing.Point(16, 63);
            this.coorX.Name = "coorX";
            this.coorX.Size = new System.Drawing.Size(17, 17);
            this.coorX.TabIndex = 14;
            this.coorX.Text = "X";
            // 
            // coorZ
            // 
            this.coorZ.AutoSize = true;
            this.coorZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.coorZ.Location = new System.Drawing.Point(17, 97);
            this.coorZ.Name = "coorZ";
            this.coorZ.Size = new System.Drawing.Size(17, 17);
            this.coorZ.TabIndex = 15;
            this.coorZ.Text = "Z";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(321, 538);
            this.tabControl1.TabIndex = 16;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.richTextBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(313, 512);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Program";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.richTextBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(313, 512);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Parameter";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // richTextBox2
            // 
            this.richTextBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox2.Location = new System.Drawing.Point(3, 3);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ShowSelectionMargin = true;
            this.richTextBox2.Size = new System.Drawing.Size(307, 506);
            this.richTextBox2.TabIndex = 0;
            this.richTextBox2.Text = "";
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonRefresh.Enabled = false;
            this.buttonRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonRefresh.Location = new System.Drawing.Point(84, 500);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(75, 35);
            this.buttonRefresh.TabIndex = 17;
            this.buttonRefresh.Text = "REFRESH";
            this.buttonRefresh.UseVisualStyleBackColor = false;
            this.buttonRefresh.Click += new System.EventHandler(this.ButtonRefresh_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(580, 417);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(48, 47);
            this.button1.TabIndex = 18;
            this.button1.Text = "+";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ButtonPluse_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(523, 417);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(48, 47);
            this.button2.TabIndex = 19;
            this.button2.Text = "-";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.ButtonMinus_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 27);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.checkBoxShowError);
            this.splitContainer1.Panel2.Controls.Add(this.buttonStart);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.buttonRefresh);
            this.splitContainer1.Panel2.Controls.Add(this.buttonSingleBlock);
            this.splitContainer1.Panel2.Controls.Add(this.buttonReset);
            this.splitContainer1.Panel2.Controls.Add(this.coorX);
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Panel2.Controls.Add(this.button2);
            this.splitContainer1.Panel2.Controls.Add(this.buttonSysleStart);
            this.splitContainer1.Panel2.Controls.Add(this.N);
            this.splitContainer1.Panel2.Controls.Add(this.coorZ);
            this.splitContainer1.Panel2.Controls.Add(this.labelX);
            this.splitContainer1.Panel2.Controls.Add(this.labelZ);
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox1);
            this.splitContainer1.Size = new System.Drawing.Size(965, 538);
            this.splitContainer1.SplitterDistance = 321;
            this.splitContainer1.TabIndex = 21;
            // 
            // checkBoxShowError
            // 
            this.checkBoxShowError.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxShowError.AutoSize = true;
            this.checkBoxShowError.Checked = true;
            this.checkBoxShowError.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxShowError.Location = new System.Drawing.Point(195, 417);
            this.checkBoxShowError.Name = "checkBoxShowError";
            this.checkBoxShowError.Size = new System.Drawing.Size(121, 17);
            this.checkBoxShowError.TabIndex = 22;
            this.checkBoxShowError.Text = "Show program error ";
            this.checkBoxShowError.UseVisualStyleBackColor = true;
            this.checkBoxShowError.Click += new System.EventHandler(this.checkBoxShowError_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonStart.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.buttonStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonStart.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonStart.Location = new System.Drawing.Point(84, 417);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 35);
            this.buttonStart.TabIndex = 21;
            this.buttonStart.Text = "START";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.ButtonStart_Click);
            // 
            // ModelingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(973, 566);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(981, 600);
            this.Name = "ModelingForm";
            this.Text = "CNC Modeling";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ModelingForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button buttonSysleStart;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выйтиToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label labelZ;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem найтиИЗаменитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem перенумероватьКадрыToolStripMenuItem;
        private Button buttonSingleBlock;
        private Label N;
        private Label coorX;
        private Label coorZ;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private RichTextBox richTextBox2;
        private ToolStripMenuItem programToolStripMenuItem;
        private ToolStripMenuItem parameterToolStripMenuItem;
        private ToolStripMenuItem programToolStripMenuItem1;
        private ToolStripMenuItem parameterToolStripMenuItem1;
        private Button buttonRefresh;
        private Button button1;
        private Button button2;
        private Timer timer1;
        private SplitContainer splitContainer1;
        private Button buttonStart;
        private CheckBox checkBoxShowError;
    }
}

