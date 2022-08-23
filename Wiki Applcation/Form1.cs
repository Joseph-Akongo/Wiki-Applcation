using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Wiki_Applcation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            displayArray();
        }
        static int row = 12;
        static int col = 4;
        string[,] aaray2D = new string[12,4];
        ArrayList array2D = new ArrayList();
        string currentFileName = "";

        private void displayArray()
        {
            listBox.View = View.Details;
            listBox.GridLines = true;
            listBox.FullRowSelect = true;
            listBox.Columns.Add("Name", 12);
            listBox.Columns.Add("Category", 6);
            listBox.Columns.Add("Structure", 12);
            listBox.Columns.Add("Definition", 12);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text));
            listBox.Items[0].SubItems.Add((string)textBox1.Text);
            if (string.IsNullOrEmpty(textBox2.Text)) ;
            listBox.Items[0].SubItems.Add((string)textBox2.Text);
            if (string.IsNullOrEmpty(textBox3.Text));
            listBox.Items[0].SubItems.Add((string)textBox3.Text);
            if (string.IsNullOrEmpty(textBox4.Text));
            listBox.Items[0].SubItems.Add((string)textBox4.Text);
            array2D.Sort();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            inputBox.Focus();
            statusStrip.Text = "Added";
            listBox.LabelEdit = true;
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            listBox.LabelEdit = true;
            ListViewItem item = listBox.Items[SelectedIndex];
            Label error = (Label)item.FindControl("Select ab item in list");
            if (String.IsNullOrEmpty(error.Text))
                return;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem eachItem in listBox.SelectedItems)
            listBox.Items.Remove(eachItem);
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void sortButton_Click(object sender, EventArgs e)
        {
            array2D.Sort();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            array2D.Sort();
            int indx = array2D.BinarySearch(inputBox.Text);
            if (indx == -1)
            {
                statusStrip.Text = "Not Found";
            }
            else
            {
                statusStrip.Text = "Found";
            }
        }

        private void listBox_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = string.Join("Name", 0);
            textBox2.Text = string.Join("Category", 0);
            textBox3.Text = string.Join("Structure", 0);
            textBox4.Text = string.Join("Definition", 0);
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            string fileNmae = "definitions.dat";
            OpenFileDialog OpenText = new OpenFileDialog();
            DialogResult sr = OpenText.ShowDialog();
            if (sr != DialogResult.OK)
            {
                fileNmae = OpenText.FileName;
            }
            currentFileName = fileNmae;
            try
            {
                array2D.Clear();
                using (StreamReader reader = new StreamReader(File.OpenRead(fileNmae)))
                {
                    while (!reader.EndOfStream)
                    {
                        array2D.Add(reader.ReadLine());
                    }
                }
                displayArray();
            }
            catch(IOException)
            {
                MessageBox.Show("File not open");
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string fileName = "definitions.dat";
            SaveFileDialog SaveText = new SaveFileDialog();
            DialogResult sr = SaveText.ShowDialog();
            if (sr == DialogResult.OK)
            {
                fileName = SaveText.FileName;
            }
            if (sr == DialogResult.Cancel)
            {
                SaveText.FileName = fileName;
            }
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName, false))
                {
                    foreach (var Plates in array2D)
                    {
                        writer.WriteLine(Plates);
                    }
                }
            }
            catch (IOException)
            {
                MessageBox.Show("File NOT saved");
            }
        }
    }
}
