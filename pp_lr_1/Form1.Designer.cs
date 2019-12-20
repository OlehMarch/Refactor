namespace pp_lr_1
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.FileLengthTitle = new System.Windows.Forms.ToolStripStatusLabel();
            this.FileLength = new System.Windows.Forms.ToolStripStatusLabel();
            this.Separator = new System.Windows.Forms.ToolStripStatusLabel();
            this.SelectionLengthTitle = new System.Windows.Forms.ToolStripStatusLabel();
            this.SelectionLength = new System.Windows.Forms.ToolStripStatusLabel();
            this.Separator2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.CursorPositionTitle = new System.Windows.Forms.ToolStripStatusLabel();
            this.CursorPosition = new System.Windows.Forms.ToolStripStatusLabel();
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.MenuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuRefactor = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuRefactorExtractMethod = new System.Windows.Forms.ToolStripMenuItem();
            this.TC_WorkSpaceField = new System.Windows.Forms.TabControl();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1.SuspendLayout();
            this.Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileLengthTitle,
            this.FileLength,
            this.Separator,
            this.SelectionLengthTitle,
            this.SelectionLength,
            this.Separator2,
            this.CursorPositionTitle,
            this.CursorPosition});
            this.statusStrip1.Location = new System.Drawing.Point(0, 687);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1195, 26);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // FileLengthTitle
            // 
            this.FileLengthTitle.Name = "FileLengthTitle";
            this.FileLengthTitle.Size = new System.Drawing.Size(93, 21);
            this.FileLengthTitle.Text = "File length:  ";
            // 
            // FileLength
            // 
            this.FileLength.Name = "FileLength";
            this.FileLength.Size = new System.Drawing.Size(19, 21);
            this.FileLength.Text = "0";
            // 
            // Separator
            // 
            this.Separator.Name = "Separator";
            this.Separator.Size = new System.Drawing.Size(30, 21);
            this.Separator.Text = "  |  ";
            // 
            // SelectionLengthTitle
            // 
            this.SelectionLengthTitle.Name = "SelectionLengthTitle";
            this.SelectionLengthTitle.Size = new System.Drawing.Size(132, 21);
            this.SelectionLengthTitle.Text = "Selection length:  ";
            // 
            // SelectionLength
            // 
            this.SelectionLength.Name = "SelectionLength";
            this.SelectionLength.Size = new System.Drawing.Size(19, 21);
            this.SelectionLength.Text = "0";
            // 
            // Separator2
            // 
            this.Separator2.Name = "Separator2";
            this.Separator2.Size = new System.Drawing.Size(30, 21);
            this.Separator2.Text = "  |  ";
            // 
            // CursorPositionTitle
            // 
            this.CursorPositionTitle.Name = "CursorPositionTitle";
            this.CursorPositionTitle.Size = new System.Drawing.Size(128, 21);
            this.CursorPositionTitle.Text = "Cursor position:  ";
            // 
            // CursorPosition
            // 
            this.CursorPosition.Name = "CursorPosition";
            this.CursorPosition.Size = new System.Drawing.Size(19, 21);
            this.CursorPosition.Text = "0";
            // 
            // Menu
            // 
            this.Menu.BackColor = System.Drawing.SystemColors.Control;
            this.Menu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFile,
            this.MenuRefactor});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.Menu.Size = new System.Drawing.Size(1195, 29);
            this.Menu.TabIndex = 1;
            this.Menu.Text = "Menu";
            // 
            // MenuFile
            // 
            this.MenuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFileOpen,
            this.toolStripSeparator1,
            this.MenuFileSave,
            this.MenuFileSaveAs});
            this.MenuFile.Name = "MenuFile";
            this.MenuFile.Size = new System.Drawing.Size(46, 25);
            this.MenuFile.Text = "File";
            // 
            // MenuFileOpen
            // 
            this.MenuFileOpen.Name = "MenuFileOpen";
            this.MenuFileOpen.Size = new System.Drawing.Size(147, 26);
            this.MenuFileOpen.Text = "Open";
            this.MenuFileOpen.Click += new System.EventHandler(this.MenuFileOpen_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(144, 6);
            // 
            // MenuFileSave
            // 
            this.MenuFileSave.Name = "MenuFileSave";
            this.MenuFileSave.Size = new System.Drawing.Size(147, 26);
            this.MenuFileSave.Text = "Save";
            this.MenuFileSave.Click += new System.EventHandler(this.MenuFileSave_Click);
            // 
            // MenuFileSaveAs
            // 
            this.MenuFileSaveAs.Name = "MenuFileSaveAs";
            this.MenuFileSaveAs.Size = new System.Drawing.Size(147, 26);
            this.MenuFileSaveAs.Text = "Save As ...";
            this.MenuFileSaveAs.Click += new System.EventHandler(this.MenuFileSaveAs_Click);
            // 
            // MenuRefactor
            // 
            this.MenuRefactor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuRefactorExtractMethod});
            this.MenuRefactor.Name = "MenuRefactor";
            this.MenuRefactor.Size = new System.Drawing.Size(80, 25);
            this.MenuRefactor.Text = "Refactor";
            // 
            // MenuRefactorExtractMethod
            // 
            this.MenuRefactorExtractMethod.Name = "MenuRefactorExtractMethod";
            this.MenuRefactorExtractMethod.Size = new System.Drawing.Size(184, 26);
            this.MenuRefactorExtractMethod.Text = "Extract Method";
            this.MenuRefactorExtractMethod.Click += new System.EventHandler(this.MenuRefactorExtractMethod_Click);
            // 
            // TC_WorkSpaceField
            // 
            this.TC_WorkSpaceField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TC_WorkSpaceField.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TC_WorkSpaceField.Location = new System.Drawing.Point(0, 29);
            this.TC_WorkSpaceField.Name = "TC_WorkSpaceField";
            this.TC_WorkSpaceField.SelectedIndex = 0;
            this.TC_WorkSpaceField.Size = new System.Drawing.Size(1195, 658);
            this.TC_WorkSpaceField.TabIndex = 3;
            this.TC_WorkSpaceField.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.TC_WorkSpaceField_Selecting);
            // 
            // timer
            // 
            this.timer.Interval = 25;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1195, 713);
            this.Controls.Add(this.TC_WorkSpaceField);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.Menu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainMenuStrip = this.Menu;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel FileLengthTitle;
        private System.Windows.Forms.ToolStripStatusLabel FileLength;
        private System.Windows.Forms.ToolStripStatusLabel Separator;
        private System.Windows.Forms.ToolStripStatusLabel SelectionLengthTitle;
        private System.Windows.Forms.ToolStripStatusLabel SelectionLength;
        private System.Windows.Forms.MenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem MenuFile;
        private System.Windows.Forms.ToolStripMenuItem MenuFileOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MenuFileSave;
        private System.Windows.Forms.ToolStripMenuItem MenuFileSaveAs;
        private System.Windows.Forms.ToolStripMenuItem MenuRefactor;
        private System.Windows.Forms.ToolStripStatusLabel Separator2;
        private System.Windows.Forms.ToolStripStatusLabel CursorPositionTitle;
        private System.Windows.Forms.ToolStripStatusLabel CursorPosition;
        private System.Windows.Forms.TabControl TC_WorkSpaceField;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ToolStripMenuItem MenuRefactorExtractMethod;
    }
}

