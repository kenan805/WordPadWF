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

namespace WordPadWF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            foreach (var fontfamily in FontFamily.Families)
            {
                cb_Font.Items.Add(fontfamily.Name);
            }
            cb_Font.StartIndex = 37;

            cb_ForeColor.DataSource = typeof(Color).GetProperties()
.Where(x => x.PropertyType == typeof(Color))
.Select(x => x.GetValue(null)).ToList();
            cb_ForeColor.MaxDropDownItems = 10;
            cb_ForeColor.IntegralHeight = false;
            cb_ForeColor.DrawMode = DrawMode.OwnerDrawFixed;
            cb_ForeColor.DropDownStyle = ComboBoxStyle.DropDownList;

            cb_BackColor.DataSource = typeof(Color).GetProperties()
.Where(x => x.PropertyType == typeof(Color))
.Select(x => x.GetValue(null)).ToList();
            cb_BackColor.MaxDropDownItems = 10;
            cb_BackColor.IntegralHeight = false;
            cb_BackColor.DrawMode = DrawMode.OwnerDrawFixed;
            cb_BackColor.DropDownStyle = ComboBoxStyle.DropDownList;

            cb_ForeColor.SelectedIndex = 8;
            cb_BackColor.SelectedIndex = 137;

            richTextBox1.AllowDrop = true;
            richTextBox1.DragDrop += Form1_DragDrop;
            richTextBox1.DragEnter += Form1_DragEnter;
        }
        bool isBold;
        bool isUnderline;
        bool isItalic;

        private void Btn_HAlignment_Click(object sender, EventArgs e)
        {
            if (sender is Guna.UI2.WinForms.Guna2Button btn)
            {
                if (btn.Name == "btn_AlgLeft")
                {
                    richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
                    btn_AlgLeft.FillColor = Color.FromArgb(200, 225, 245);
                    btn_AlgLeft.BorderColor = Color.Blue;
                    btn_AlgRight.FillColor = Color.Transparent;
                    btn_AlgRight.BorderColor = Color.Transparent;
                    btn_AlgCenter.FillColor = Color.Transparent;
                    btn_AlgCenter.BorderColor = Color.Transparent;
                }
                else if (btn.Name == "btn_AlgCenter")
                {
                    richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
                    btn_AlgCenter.FillColor = Color.FromArgb(200, 225, 245);
                    btn_AlgCenter.BorderColor = Color.Blue;
                    btn_AlgRight.FillColor = Color.Transparent;
                    btn_AlgRight.BorderColor = Color.Transparent;
                    btn_AlgLeft.FillColor = Color.Transparent;
                    btn_AlgLeft.BorderColor = Color.Transparent;
                }
                else if (btn.Name == "btn_AlgRight")
                {
                    richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
                    btn_AlgRight.FillColor = Color.FromArgb(200, 225, 245);
                    btn_AlgRight.BorderColor = Color.Blue;
                    btn_AlgLeft.FillColor = Color.Transparent;
                    btn_AlgLeft.BorderColor = Color.Transparent;
                    btn_AlgCenter.FillColor = Color.Transparent;
                    btn_AlgCenter.BorderColor = Color.Transparent;
                }
            }
        }
        private void Btn_Bold_Click(object sender, EventArgs e)
        {
            if (isBold == false)
            {
                isBold = true;
                btn_Bold.FillColor = Color.FromArgb(200, 225, 245);
                btn_Bold.BorderColor = Color.Blue;
                if (isItalic == false && isUnderline == false)
                {
                    richTextBox1.SelectionFont = new Font(cb_Font.Text, float.Parse(cb_Size.Text), FontStyle.Bold);
                }
                else if (isItalic == true && isUnderline == false)
                {
                    richTextBox1.SelectionFont = new Font(cb_Font.Text, float.Parse(cb_Size.Text), FontStyle.Italic | FontStyle.Bold);
                }
                else if (isItalic == false && isUnderline == true)
                {
                    richTextBox1.SelectionFont = new Font(cb_Font.Text, float.Parse(cb_Size.Text), FontStyle.Underline | FontStyle.Bold);
                }
                else if (isItalic == true && isUnderline == true)
                {
                    richTextBox1.SelectionFont = new Font(cb_Font.Text, float.Parse(cb_Size.Text), FontStyle.Italic | FontStyle.Underline | FontStyle.Bold);
                }
            }
            else
            {
                isBold = false;
                btn_Bold.FillColor = Color.Transparent;
                btn_Bold.BorderColor = Color.Transparent;
                if (isItalic == false && isUnderline == false)
                {
                    richTextBox1.SelectionFont = new Font(cb_Font.Text, float.Parse(cb_Size.Text), FontStyle.Regular);
                }
                else if (isItalic == true && isUnderline == false)
                {
                    richTextBox1.SelectionFont = new Font(cb_Font.Text, float.Parse(cb_Size.Text), FontStyle.Italic);
                }
                else if (isItalic == false && isUnderline == true)
                {
                    richTextBox1.SelectionFont = new Font(cb_Font.Text, float.Parse(cb_Size.Text), FontStyle.Underline);
                }
                else if (isItalic == true && isUnderline == true)
                {
                    richTextBox1.SelectionFont = new Font(cb_Font.Text, float.Parse(cb_Size.Text), FontStyle.Italic | FontStyle.Underline);
                }
            }
        }
        private void Btn_Underline_Click(object sender, EventArgs e)
        {
            if (isUnderline == false)
            {
                isUnderline = true;
                btn_Underline.FillColor = Color.FromArgb(200, 225, 245);
                btn_Underline.BorderColor = Color.Blue;
                if (isItalic == false && isBold == false)
                {
                    richTextBox1.SelectionFont = new Font(cb_Font.Text, float.Parse(cb_Size.Text), FontStyle.Underline);
                }
                else if (isItalic == true && isBold == false)
                {
                    richTextBox1.SelectionFont = new Font(cb_Font.Text, float.Parse(cb_Size.Text), FontStyle.Italic | FontStyle.Underline);
                }
                else if (isItalic == false && isBold == true)
                {
                    richTextBox1.SelectionFont = new Font(cb_Font.Text, float.Parse(cb_Size.Text), FontStyle.Bold | FontStyle.Underline);
                }
                else if (isItalic == true && isBold == true)
                {
                    richTextBox1.SelectionFont = new Font(cb_Font.Text, float.Parse(cb_Size.Text), FontStyle.Italic | FontStyle.Bold | FontStyle.Underline);
                }
            }
            else
            {
                isUnderline = false;
                btn_Underline.FillColor = Color.Transparent;
                btn_Underline.BorderColor = Color.Transparent;
                if (isItalic == false && isBold == false)
                {
                    richTextBox1.SelectionFont = new Font(cb_Font.Text, float.Parse(cb_Size.Text), FontStyle.Regular);
                }
                else if (isItalic == true && isBold == false)
                {
                    richTextBox1.SelectionFont = new Font(cb_Font.Text, float.Parse(cb_Size.Text), FontStyle.Italic);
                }
                else if (isItalic == false && isBold == true)
                {
                    richTextBox1.SelectionFont = new Font(cb_Font.Text, float.Parse(cb_Size.Text), FontStyle.Bold);
                }
                else if (isItalic == true && isBold == true)
                {
                    richTextBox1.SelectionFont = new Font(cb_Font.Text, float.Parse(cb_Size.Text), FontStyle.Italic | FontStyle.Bold);
                }
            }
        }
        private void Btn_Italic_Click(object sender, EventArgs e)
        {
            if (isItalic == false)
            {
                isItalic = true;
                btn_Italic.FillColor = Color.FromArgb(200, 225, 245);
                btn_Italic.BorderColor = Color.Blue;
                if (isBold == false && isUnderline == false)
                {
                    richTextBox1.SelectionFont = new Font(cb_Font.Text, float.Parse(cb_Size.Text), FontStyle.Italic);
                }
                else if (isBold == true && isUnderline == false)
                {
                    richTextBox1.SelectionFont = new Font(cb_Font.Text, float.Parse(cb_Size.Text), FontStyle.Bold | FontStyle.Italic);
                }
                else if (isBold == false && isUnderline == true)
                {
                    richTextBox1.SelectionFont = new Font(cb_Font.Text, float.Parse(cb_Size.Text), FontStyle.Underline | FontStyle.Italic);
                }
                else if (isBold == true && isUnderline == true)
                {
                    richTextBox1.SelectionFont = new Font(cb_Font.Text, float.Parse(cb_Size.Text), FontStyle.Bold | FontStyle.Underline | FontStyle.Italic);
                }
            }
            else
            {
                isItalic = false;
                btn_Italic.FillColor = Color.Transparent;
                btn_Italic.BorderColor = Color.Transparent;
                if (isBold == false && isUnderline == false)
                {
                    richTextBox1.SelectionFont = new Font(cb_Font.Text, float.Parse(cb_Size.Text), FontStyle.Regular);
                }
                else if (isBold == true && isUnderline == false)
                {
                    richTextBox1.SelectionFont = new Font(cb_Font.Text, float.Parse(cb_Size.Text), FontStyle.Bold);
                }
                else if (isBold == false && isUnderline == true)
                {
                    richTextBox1.SelectionFont = new Font(cb_Font.Text, float.Parse(cb_Size.Text), FontStyle.Underline);
                }
                else if (isBold == true && isUnderline == true)
                {
                    richTextBox1.SelectionFont = new Font(cb_Font.Text, float.Parse(cb_Size.Text), FontStyle.Bold | FontStyle.Underline);
                }
            }
        }
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void RichTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.L)
            {
                richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
                btn_AlgLeft.FillColor = Color.FromArgb(200, 225, 245);
                btn_AlgLeft.BorderColor = Color.Blue;
                btn_AlgRight.FillColor = Color.Transparent;
                btn_AlgRight.BorderColor = Color.Transparent;
                btn_AlgCenter.FillColor = Color.Transparent;
                btn_AlgCenter.BorderColor = Color.Transparent;
            }
            else if (e.Control == true && e.KeyCode == Keys.E)
            {
                richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
                btn_AlgCenter.FillColor = Color.FromArgb(200, 225, 245);
                btn_AlgCenter.BorderColor = Color.Blue;
                btn_AlgRight.FillColor = Color.Transparent;
                btn_AlgRight.BorderColor = Color.Transparent;
                btn_AlgLeft.FillColor = Color.Transparent;
                btn_AlgLeft.BorderColor = Color.Transparent;
            }
            else if (e.Control == true && e.KeyCode == Keys.R)
            {
                richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
                btn_AlgRight.FillColor = Color.FromArgb(200, 225, 245);
                btn_AlgRight.BorderColor = Color.Blue;
                btn_AlgLeft.FillColor = Color.Transparent;
                btn_AlgLeft.BorderColor = Color.Transparent;
                btn_AlgCenter.FillColor = Color.Transparent;
                btn_AlgCenter.BorderColor = Color.Transparent;

            }
            else if (e.Control == true && e.KeyCode == Keys.B)
            {
                if (isBold == false)
                {
                    isBold = true;
                    btn_Bold.FillColor = Color.FromArgb(200, 225, 245);
                    btn_Bold.BorderColor = Color.Blue;
                    if (isItalic == false && isUnderline == false)
                    {
                        richTextBox1.SelectionFont = new Font(cb_Font.Text, float.Parse(cb_Size.Text), FontStyle.Bold);
                    }
                    else if (isItalic == true && isUnderline == false)
                    {
                        richTextBox1.SelectionFont = new Font(cb_Font.Text, float.Parse(cb_Size.Text), FontStyle.Italic | FontStyle.Bold);
                    }
                    else if (isItalic == false && isUnderline == true)
                    {
                        richTextBox1.SelectionFont = new Font(cb_Font.Text, float.Parse(cb_Size.Text), FontStyle.Underline | FontStyle.Bold);
                    }
                    else if (isItalic == true && isUnderline == true)
                    {
                        richTextBox1.SelectionFont = new Font(cb_Font.Text, float.Parse(cb_Size.Text), FontStyle.Italic | FontStyle.Underline | FontStyle.Bold);
                    }
                }
                else
                {
                    isBold = false;
                    btn_Bold.FillColor = Color.Transparent;
                    btn_Bold.BorderColor = Color.Transparent;
                    if (isItalic == false && isUnderline == false)
                    {
                        richTextBox1.SelectionFont = new Font(cb_Font.Text, float.Parse(cb_Size.Text), FontStyle.Regular);
                    }
                    else if (isItalic == true && isUnderline == false)
                    {
                        richTextBox1.SelectionFont = new Font(cb_Font.Text, float.Parse(cb_Size.Text), FontStyle.Italic);
                    }
                    else if (isItalic == false && isUnderline == true)
                    {
                        richTextBox1.SelectionFont = new Font(cb_Font.Text, float.Parse(cb_Size.Text), FontStyle.Underline);
                    }
                    else if (isItalic == true && isUnderline == true)
                    {
                        richTextBox1.SelectionFont = new Font(cb_Font.Text, float.Parse(cb_Size.Text), FontStyle.Italic | FontStyle.Underline);
                    }
                }
            }
            else if (e.Control == true && e.KeyCode == Keys.U)
            {
                if (isUnderline == false)
                {
                    isUnderline = true;
                    btn_Underline.FillColor = Color.FromArgb(200, 225, 245);
                    btn_Underline.BorderColor = Color.Blue;
                    if (isItalic == false && isBold == false)
                    {
                        richTextBox1.SelectionFont = new Font(cb_Font.Text, float.Parse(cb_Size.Text), FontStyle.Underline);
                    }
                    else if (isItalic == true && isBold == false)
                    {
                        richTextBox1.SelectionFont = new Font(cb_Font.Text, float.Parse(cb_Size.Text), FontStyle.Italic | FontStyle.Underline);
                    }
                    else if (isItalic == false && isBold == true)
                    {
                        richTextBox1.SelectionFont = new Font(cb_Font.Text, float.Parse(cb_Size.Text), FontStyle.Bold | FontStyle.Underline);
                    }
                    else if (isItalic == true && isBold == true)
                    {
                        richTextBox1.SelectionFont = new Font(cb_Font.Text, float.Parse(cb_Size.Text), FontStyle.Italic | FontStyle.Bold | FontStyle.Underline);
                    }
                }
                else
                {
                    isUnderline = false;
                    btn_Underline.FillColor = Color.Transparent;
                    btn_Underline.BorderColor = Color.Transparent;
                    if (isItalic == false && isBold == false)
                    {
                        richTextBox1.SelectionFont = new Font(cb_Font.Text, float.Parse(cb_Size.Text), FontStyle.Regular);
                    }
                    else if (isItalic == true && isBold == false)
                    {
                        richTextBox1.SelectionFont = new Font(cb_Font.Text, float.Parse(cb_Size.Text), FontStyle.Italic);
                    }
                    else if (isItalic == false && isBold == true)
                    {
                        richTextBox1.SelectionFont = new Font(cb_Font.Text, float.Parse(cb_Size.Text), FontStyle.Bold);
                    }
                    else if (isItalic == true && isBold == true)
                    {
                        richTextBox1.SelectionFont = new Font(cb_Font.Text, float.Parse(cb_Size.Text), FontStyle.Italic | FontStyle.Bold);
                    }
                }
            }
        }
        private void BtnPaste_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += Clipboard.GetText();
        }
        private void BtnCopy_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText.Length != 0)
                Clipboard.SetText(richTextBox1.SelectedText);
            else
                MessageBox.Show("Bir text secin!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void BtnCut_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText.Length != 0)
            {
                Clipboard.SetText(richTextBox1.SelectedText);
                richTextBox1.SelectedText = "";
            }
            else
                MessageBox.Show("Bir text secin!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length == 0)
            {
                isBold = false;
                isItalic = false;
                isUnderline = false;
                btn_Bold.FillColor = Color.Transparent;
                btn_Bold.BorderColor = Color.Transparent;
                btn_Italic.FillColor = Color.Transparent;
                btn_Italic.BorderColor = Color.Transparent;
                btn_Underline.FillColor = Color.Transparent;
                btn_Underline.BorderColor = Color.Transparent;
                cb_Font.SelectedItem = "Calibri";
                cb_Size.SelectedItem = "11";
                cb_ForeColor.SelectedIndex = 8;
                cb_BackColor.SelectedIndex = 137;
            }
        }

        private void Cb_Font_SelectedIndexChanged(object sender, EventArgs e) => richTextBox1.SelectionFont = new Font(cb_Font.SelectedItem.ToString(), float.Parse(cb_Size.SelectedItem.ToString()));

        private void Cb_Size_SelectedIndexChanged(object sender, EventArgs e) => richTextBox1.SelectionFont = new Font(cb_Font.SelectedItem.ToString(), float.Parse(cb_Size.SelectedItem.ToString()));

        private void Cb_ForeColor_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            if (e.Index >= 0)
            {
                var txt = cb_ForeColor.GetItemText(cb_ForeColor.Items[e.Index]);
                var color = (Color)cb_ForeColor.Items[e.Index];
                var r1 = new Rectangle(e.Bounds.Left + 1, e.Bounds.Top + 1,
                    2 * (e.Bounds.Height - 2), e.Bounds.Height - 2);
                var r2 = Rectangle.FromLTRB(r1.Right + 2, e.Bounds.Top,
                    e.Bounds.Right, e.Bounds.Bottom);
                using (var b = new SolidBrush(color))
                    e.Graphics.FillRectangle(b, r1);
                e.Graphics.DrawRectangle(Pens.Black, r1);
                TextRenderer.DrawText(e.Graphics, txt, cb_ForeColor.Font, r2,
                    cb_ForeColor.ForeColor, TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
            }
        }

        private void Cb_BackColor_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            if (e.Index >= 0)
            {
                var txt = cb_BackColor.GetItemText(cb_BackColor.Items[e.Index]);
                var color = (Color)cb_BackColor.Items[e.Index];
                var r1 = new Rectangle(e.Bounds.Left + 1, e.Bounds.Top + 1,
                    2 * (e.Bounds.Height - 2), e.Bounds.Height - 2);
                var r2 = Rectangle.FromLTRB(r1.Right + 2, e.Bounds.Top,
                    e.Bounds.Right, e.Bounds.Bottom);
                using (var b = new SolidBrush(color))
                    e.Graphics.FillRectangle(b, r1);
                e.Graphics.DrawRectangle(Pens.Black, r1);
                TextRenderer.DrawText(e.Graphics, txt, cb_ForeColor.Font, r2,
                    cb_BackColor.ForeColor, TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
            }
        }

        private void Cb_ForeColor_SelectedIndexChanged(object sender, EventArgs e) => richTextBox1.SelectionColor = (Color)cb_ForeColor.SelectedValue;

        private void Cb_BackColor_SelectedIndexChanged(object sender, EventArgs e) => richTextBox1.SelectionBackColor = (Color)cb_BackColor.SelectedValue;

        private void BtnDateTime_Click(object sender, EventArgs e)
        {
            DateAndTimeForm dateAndTimeForm = new DateAndTimeForm(this);
            dateAndTimeForm.ShowDialog();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "All files|*.*|Text files|*.txt";
            openFileDialog1.FilterIndex = 2;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader streamReader = new StreamReader(openFileDialog1.FileName))
                {
                    richTextBox1.Text = streamReader.ReadToEnd();
                }

            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] filenames = e.Data.GetData(DataFormats.FileDrop) as string[];
                if (filenames != null)
                {
                    foreach (var name in filenames)
                    {
                        try
                        {
                            richTextBox1.AppendText(File.ReadAllText(name));
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.FileName = "Document.txt";
            save.Filter = "Text File | *.txt";
            if (save.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(save.OpenFile());
                writer.WriteLine(richTextBox1.Text);
                writer.Dispose();
                writer.Close();
                MessageBox.Show("Succesfully saved", "Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}

