using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pp_lr_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private string _fileName = "";
        private bool _isOpened = false;
        private int _counter = 0;
        private int _index = 0;
        private string _ExtractedMethodName = "";
        RichTextBox[] RichTextBoxes = new RichTextBox[256];

        private void MenuFileOpen_Click(object sender, EventArgs e)
        {
            string data = "";

            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Cs files (*.cs)|*.cs|All files (*.*)|*.*";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                _fileName = fileDialog.FileName;

                StreamReader sr_file = new StreamReader(_fileName);
                data = sr_file.ReadToEnd();
                sr_file.Close();

                int tabPagesCount = TC_WorkSpaceField.TabPages.Count;

                RichTextBoxes[_counter] = new RichTextBox()
                {
                    Name = "NewRichTextBox" + tabPagesCount.ToString(),
                    Text = data,
                    Font = new Font("Consolas", 12),
                    Dock = DockStyle.Fill
                };

                TC_WorkSpaceField.TabPages.Add(GetFileNameFromPath(_fileName));
                TC_WorkSpaceField.TabPages[tabPagesCount].Controls.Add(RichTextBoxes[_counter]);
                FileLength.Text = RichTextBoxes[_counter].TextLength.ToString();
                TC_WorkSpaceField.SelectedIndex = tabPagesCount;

                _counter++;
                _isOpened = true;
                timer.Enabled = true;
            }
        }

        private void MenuFileSave_Click(object sender, EventArgs e)
        {
            if (_isOpened)
            {
                StreamWriter sw_file = new StreamWriter(_fileName);
                sw_file.Write(TC_WorkSpaceField.TabPages[TC_WorkSpaceField.SelectedIndex].Text);
                sw_file.Close();
            }
            else
            {
                MessageBox.Show("Impossible to save file!\n   Try 'Save As ...'", "Error!", MessageBoxButtons.OK);
            }
        }

        private void MenuFileSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();

            fileDialog.OverwritePrompt = true;
            fileDialog.AddExtension = true;
            fileDialog.RestoreDirectory = true;
            fileDialog.Filter = "Cs files (*.cs)|*.cs|Other files (*.*)|*.*";
            fileDialog.FilterIndex = 1;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw_file = new StreamWriter(fileDialog.FileName);
                sw_file.Write(TC_WorkSpaceField.TabPages[TC_WorkSpaceField.SelectedIndex].Text);
                sw_file.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            _index = TC_WorkSpaceField.SelectedIndex;
            RichTextBoxes[_index].TextChanged += this.TextChangedHandler;
            RichTextBoxes[_index].MouseUp += this.MouseUpHandler;
            RichTextBoxes[_index].KeyUp += this.KeyUpHandler;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer.Enabled = false;
        }

        private void TC_WorkSpaceField_Selecting(object sender, TabControlCancelEventArgs e)
        {
            int index = TC_WorkSpaceField.SelectedIndex;
            FileLength.Text = RichTextBoxes[index].TextLength.ToString();
            SelectionLength.Text = "0";
            CursorPosition.Text = "0";
        }

        private void MenuRefactorExtractMethod_Click(object sender, EventArgs e)
        {
            try
            {
                if (RichTextBoxes[TC_WorkSpaceField.SelectedIndex].SelectedText.Length >= 150)
                {
                    ExtractMethodForm form = new ExtractMethodForm();
                    form.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Selected text must be not less then 150 characters!", "Warning!", MessageBoxButtons.OK);
                }
            }
            catch
            {
                MessageBox.Show("Selected text must be not less then 150 characters!", "Warning!", MessageBoxButtons.OK);
            }
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            FileInfo fileInfo = new FileInfo("temp");
            if (fileInfo.Exists)
            {
                StreamReader sr_file = new StreamReader(fileInfo.FullName);
                _ExtractedMethodName = sr_file.ReadToEnd();
                sr_file.Close();

                fileInfo.Delete();
            }
        }

        private void TextChanged(RichTextBox richRextBox)
        {
            FileLength.Text = richRextBox.TextLength.ToString();
        }
        private void MouseUp(RichTextBox richRextBox)
        {
            CursorPosition.Text = richRextBox.SelectionStart.ToString();
            SelectionLength.Text = richRextBox.SelectedText.Length.ToString();
        }
        private void KeyUp(RichTextBox richRextBox)
        {
            CursorPosition.Text = richRextBox.SelectionStart.ToString();
            SelectionLength.Text = richRextBox.SelectedText.Length.ToString();
        }
        private string GetFileNameFromPath(string path)
        {
            int index = (path.LastIndexOf('\\') == -1) ? path.LastIndexOf('/') : path.LastIndexOf('\\');
            path = path.Remove(0, index + 1);

            return path;
        }
        private void KeyUpHandler(object sender, KeyEventArgs e)
        {
            _index = TC_WorkSpaceField.SelectedIndex;
            KeyUp(RichTextBoxes[_index]);
        }
        private void MouseUpHandler(object sender, MouseEventArgs e)
        {
            _index = TC_WorkSpaceField.SelectedIndex;
            MouseUp(RichTextBoxes[_index]);
        }
        private void TextChangedHandler(object sender, EventArgs e)
        {
            _index = TC_WorkSpaceField.SelectedIndex;
            TextChanged(RichTextBoxes[_index]);
        }

    }
}
