using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Class1Button.Text = Class1NameBox.Text;
            Class1Group.Text = Class1NameBox.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            checkedListBox1.Items.Add(textBox1.Text);    
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            for (int i = checkedListBox1.Items.Count - 1; i >= 0; i--)
            {
                if (checkedListBox1.GetItemChecked(i))
                {
                    checkedListBox1.Items.Remove(checkedListBox1.Items[i]);
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            checkedListBox2.Items.Add(textBox2.Text);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            for (int i = checkedListBox2.Items.Count - 1; i >= 0; i--)
            {
                if (checkedListBox2.GetItemChecked(i))
                {
                    checkedListBox2.Items.Remove(checkedListBox2.Items[i]);
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            checkedListBox3.Items.Add(Class2NameBox.Text);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            for (int i = checkedListBox3.Items.Count - 1; i >= 0; i--)
            {
                if (checkedListBox3.GetItemChecked(i))
                {
                    checkedListBox3.Items.Remove(checkedListBox3.Items[i]);
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

        private void button4_Click(object sender, EventArgs e)
        {
            checkedListBox4.Items.Add(textBox4.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = checkedListBox4.Items.Count - 1; i >= 0; i--)
            {
                if (checkedListBox4.GetItemChecked(i))
                {
                    checkedListBox4.Items.Remove(checkedListBox4.Items[i]);
                }
            }
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            Class3Button.Text = Class3NameBox.Text;
            Class3Group.Text = Class3NameBox.Text;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Class2Button.Text = Class2NameBox.Text;
            Class2Group.Text = Class2NameBox.Text;
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            Class4Button.Text = Class4NameBox.Text;
            Class4Group.Text = Class4NameBox.Text;
        }
    }
}
