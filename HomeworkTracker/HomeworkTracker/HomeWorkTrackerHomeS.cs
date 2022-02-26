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

namespace HomeworkTracker
{
    public partial class HomeWorkTrackerHomeS : Form
    {
        public HomeWorkTrackerHomeS()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Class1Panel.Visible = false;
            Class2Panel.Visible = true;
            Class3Panel.Visible = false;
            Class4Panel.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Class1Panel.Visible = true;
            Class2Panel.Visible = false;
            Class3Panel.Visible = false;
            Class4Panel.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (System.IO.StreamWriter A = new System.IO.StreamWriter(@"C:\Users\Public\Documents\Class1.txt")) // Saves Class 1 items into .txt file
            {
                foreach (var item in checkedListBox1.Items)
                {
                    A.WriteLine(item.ToString());
                }
            }
            using (System.IO.StreamWriter A = new System.IO.StreamWriter(@"C:\Users\Public\Documents\Class2.txt")) // Saves Class 2 items into .txt file
            {
                foreach (var item in checkedListBox2.Items)
                {
                    A.WriteLine(item.ToString());
                }
            }
            using (System.IO.StreamWriter A = new System.IO.StreamWriter(@"C:\Users\Public\Documents\Class3.txt")) // Saves Class 3 items into .txt file
            {
                foreach (var item in checkedListBox3.Items)
                {
                    A.WriteLine(item.ToString());
                }
            }
            using (System.IO.StreamWriter A = new System.IO.StreamWriter(@"C:\Users\Public\Documents\Class4.txt")) // Saves Class 4 items into .txt file
            {
                foreach (var item in checkedListBox4.Items)
                {
                    A.WriteLine(item.ToString());
                }
            }

            this.Close(); //Closes program when "Save/Exit" button is pressed
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Class1Button.Text = Class1NameBox.Text; // Adds class 1 names from class 1 textbox
            Class1Group.Text = Class1NameBox.Text; // Adds class 1 name to class 1 group box
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            checkedListBox1.Items.Add(textBox1.Text);// Adds item to Class 1
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            for (int i = checkedListBox1.Items.Count - 1; i >= 0; i--) // Removes selected item in Class 1
            {
                if (checkedListBox1.GetItemChecked(i))
                {
                    checkedListBox1.Items.Remove(checkedListBox1.Items[i]);
                }
            }
        }

        private void Class3Button_Click(object sender, EventArgs e)
        {
            Class1Panel.Visible = false;
            Class2Panel.Visible = false;
            Class3Panel.Visible = true;
            Class4Panel.Visible = false;
        }

        private void Class4Button_Click(object sender, EventArgs e)
        {
            Class1Panel.Visible = false;
            Class2Panel.Visible = false;
            Class3Panel.Visible = false;
            Class4Panel.Visible = true;
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            Class3Button.Text = Class3NameBox.Text; // Adds class 3 names from class 3 textbox
            Class3Group.Text = Class3NameBox.Text; // Adds class 3 name to class 3 group box
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Class2Button.Text = Class2NameBox.Text; // Adds class 2 names from class 2 textbox
            Class2Group.Text = Class2NameBox.Text; // Adds class 2 name to class 2 group box
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            Class4Button.Text = Class4NameBox.Text; // Adds class 4 names from class 4 textbox
            Class4Group.Text = Class4NameBox.Text; // Adds class 4 name to class 4 group box
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            checkedListBox3.Items.Add(textBox4.Text);// Adds item to Class 3
        }

        private void button11_Click(object sender, EventArgs e)
        {
            checkedListBox4.Items.Add(textBox4.Text);// Adds item to Class 4
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            checkedListBox2.Items.Add(textBox2.Text); // Adds item to Class 2
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            for (int i = checkedListBox3.Items.Count - 1; i >= 0; i--) // Removes selected item in Class 3
            {
                if (checkedListBox3.GetItemChecked(i))
                {
                    checkedListBox3.Items.Remove(checkedListBox3.Items[i]);
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            for (int i = checkedListBox4.Items.Count - 1; i >= 0; i--) // Removes selected item in Class 4
            {
                if (checkedListBox4.GetItemChecked(i))
                {
                    checkedListBox4.Items.Remove(checkedListBox4.Items[i]);
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            for (int i = checkedListBox2.Items.Count - 1; i >= 0; i--) // Removes selected item in Class 2
            {
                if (checkedListBox2.GetItemChecked(i))
                {
                    checkedListBox2.Items.Remove(checkedListBox2.Items[i]);
                }
            }
        }

        private void HomeWorkTrackerHomeS_Load(object sender, EventArgs e)
        {
            string Class1 = @"C:\Users\Public\Documents\Class1.txt"; // String Class1 Database
            if (File.Exists(Class1))
            {
                using (System.IO.StreamReader A = new StreamReader(@"C:\Users\Public\Documents\Class1.txt")) // Opens Database when program is opened
                    while (A.Peek() > -1)
                        checkedListBox1.Items.Add(A.ReadLine());
            }
            else
            {
                return; // Makes sure not to give error when no database exists
            }
            string Class2 = @"C:\Users\Public\Documents\Class2.txt"; // String Class2 Database
            if (File.Exists(Class2))
            {
                using (System.IO.StreamReader A = new StreamReader(@"C:\Users\Public\Documents\Class2.txt")) // Opens Database when program is opened
                    while (A.Peek() > -1)
                        checkedListBox2.Items.Add(A.ReadLine());
            }
            else
            {
                return; // Makes sure not to give error when no database exists
            }
            string Class3 = @"C:\Users\Public\Documents\Class3.txt"; // String Class3 Database
            if (File.Exists(Class3))
            {
                using (System.IO.StreamReader A = new StreamReader(@"C:\Users\Public\Documents\Class3.txt")) // Opens Database when program is opened
                    while (A.Peek() > -1)
                        checkedListBox3.Items.Add(A.ReadLine());
            }
            else
            {
                return; // Makes sure not to give error when no database exists
            }
            string Class4 = @"C:\Users\Public\Documents\Class4.txt"; // String Class4 Database
            if (File.Exists(Class4))
            {
                using (System.IO.StreamReader A = new StreamReader(@"C:\Users\Public\Documents\Class4.txt")) // Opens Database when program is opened
                    while (A.Peek() > -1)
                        checkedListBox4.Items.Add(A.ReadLine());
            }
            else
            {
                return; // Makes sure not to give error when no database exists
            }
        }
    }
}
