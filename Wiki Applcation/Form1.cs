using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wiki_Applcation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            inputBox.CharacterCasing = CharacterCasing.Upper;
            inputBox.MaxLength = 10;
        }
        string[,] aaray2D = new string[12,4];
        string currentFileName = "";
        bool Sorted = false;

        private void displayArray()
        {
            listBox.Items.Clear();
            foreach (var variable in aaray2D)
            {
                listBox.Items.Add(variable);
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(inputBox.Text)) ;
            inputBox.Clear();
            inputBox.Focus();
            statusStrip.Text = "Added";
            listBox.Sorted = true;
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex > -1)
                listBox.Items[listBox.SelectedIndex] = inputBox.Text;
            else
                statusStrip.Text = "Select and item in the list";
            listBox.Sorted = true;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex > -1)
                listBox.Items.RemoveAt(listBox.SelectedIndex);
            else
                statusStrip.Text = "Select an item from the list";
            listBox.Sorted = true;
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
            for (int i = 0; i < aaray2D.GetUpperBound(0)-1; i++)
            {
                for (int j = 0; j < aaray2D.GetUpperBound(0); ++j)
                {
                    if (aaray2D[i, 0].CompareTo(aaray2D[j, 0]) > 0)
                    {
                        for (int x = 0; x < aaray2D.GetUpperBound(1); ++x)
                        {
                            string temp = aaray2D[i, x];
                            aaray2D[i, x] = aaray2D[j, x];
                            aaray2D[j, x] = temp; 
                        }
                    }
                }
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            int index = aaray2D.BinarySearch(inputBox.Text);
            if(index == -1)
            {
                MessageBox.Show("Not Found");
                inputBox.Clear();
                inputBox.Focus();
            }
            else
            {
                MessageBox.Show("Found" + index.ToString());
            }
        }
    }
}
