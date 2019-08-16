using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace GUI
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.Visible = true;
            listView1.Visible = true;
            button7.Visible = true;

            comboBox2.Visible = false;
            label1.Visible = false;
            textBox1.Visible = false;
            button3.Visible = false;
            button4.Visible = false;

            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;

            comboBox3.Visible = false;
            comboBox4.Visible = false;

            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;

            button5.Visible = false;
            button6.Visible = false;

            /*
            DAL.DAL da = new DAL.DAL();
            List<string> n = new List<string>();
            n = da.GetClassFromDBToCombobox();
            foreach(string s in n)
            {
                comboBox1.Items.Add(s);
            }
            */
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox2.SelectedIndex==0)
            {
                label1.Visible = true;
                textBox1.Visible = true;
                button3.Visible = true;
                button4.Visible = true;

                comboBox1.Visible = false;
                comboBox3.Visible = false;
                comboBox4.Visible = false;

                listView1.Visible = false;

                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;

                textBox2.Visible = false;
                textBox3.Visible = false;
                textBox4.Visible = false;

                button5.Visible = false;
                button6.Visible = false;
            }
            else if(comboBox2.SelectedIndex == 1)
            {
                label1.Visible = false;
                textBox1.Visible = false;
                button3.Visible = false ;
                button4.Visible = false;

                comboBox1.Visible = false;

                comboBox3.Visible = true;
                comboBox4.Visible = true;

                listView1.Visible = false;

                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;

                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;

                button5.Visible = true;
                button6.Visible = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox2.Visible = true;

            listView1.Visible = false;

            comboBox1.Visible = false;
            comboBox3.Visible = false;
            comboBox4.Visible = false;

            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;

            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;

            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
           
            /*
            DAL.DAL da = new DAL.DAL();
            List<string> n = new List<string>();
            n = da.GetClassFromDBToCombobox();
            foreach (string s in n)
            {
                comboBox3.Items.Add(s);
            }
            */
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            DAL.DAL da = new DAL.DAL();
            List<string> n = new List<string>();
            n = da.GetClassFromDBToCombobox();
            foreach (string s in n)
            {
                comboBox1.Items.Add(s);
                comboBox3.Items.Add(s);
            }

            List<string> m = new List<string>();
            m = da.GetScheduleFromDBToCombobox();
            foreach (string r in m)
            {
                comboBox5.Items.Add(r);
            }
        }

        //import list student
        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.ToString()=="")
            {
                MessageBox.Show("you must enter the path","Erorr",MessageBoxButtons.OK);
            }
            else if(!File.Exists(textBox1.Text.ToString()))
            {
                MessageBox.Show("The path isn't exist", "Erorr",MessageBoxButtons.OK);
            }
            else
            {
                BUS.BUS b = new BUS.BUS();
                
                bool type = b.AddListStudent(textBox1.Text.ToString());

                string cl = b.GetCLassfromPath(textBox1.Text.ToString());

                comboBox1.Items.Add(cl);
                comboBox3.Items.Add(cl);

                if (type == false)
                {
                    MessageBox.Show("Format file is erorr", "ERORR", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Imported", "Message", MessageBoxButtons.OK);

                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DTO.Class cl = new DTO.Class();
            cl.ID = textBox2.Text.ToString();
            cl.Name = textBox3.Text.ToString();
            cl.Sex = comboBox4.SelectedItem.ToString();
            //cl.Sex = comboBox4.SelectedText.ToString();
            cl.SSN = textBox4.Text.ToString();
            //cl.classes = comboBox3.SelectedText.ToString();
            cl.classes = comboBox3.SelectedItem.ToString();

            if (cl.ID == "" || cl.Name == "" || cl.classes == "")
                MessageBox.Show("You must enter all text", "Erorr", MessageBoxButtons.OK);
            else
            {
                DAL.DAL da = new DAL.DAL();
                da.AddStudent(cl);
                MessageBox.Show("Imported", "Message", MessageBoxButtons.OK);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DAL.DAL da = new DAL.DAL();
            //List<DTO.Class> cls = new List<DTO.Class>();
            
            var cls=da.GetClassfromDB(comboBox1.SelectedItem.ToString());
            listView1.Items.Clear();

            foreach(DTO.Class c in cls)
            {
                ListViewItem item = new ListViewItem();
                item.Text = c.STT.ToString();
                item.SubItems.Add(c.ID);
                item.SubItems.Add(c.Name);
                item.SubItems.Add(c.Sex);
                item.SubItems.Add(c.SSN);
                listView1.Items.Add(item);
            }
        }

        //import Schedule
        private void button8_Click(object sender, EventArgs e)
        {
            string cls="";
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Excel File |*csv";
                if (open.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }
                
                //BLL_ImportListClass.ReadFileCSV(open.FileName);
                DAL.DAL da = new DAL.DAL();
                bool type=da.AddSchedule(open.FileName, cls);

                

                if (type == false)
                {
                    MessageBox.Show("Format file is erorr", "ERORR", MessageBoxButtons.OK);
                }
                else
                {
                    comboBox5.Items.Add(cls);
                    MessageBox.Show("Imported", "Message", MessageBoxButtons.OK);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            button10.Visible = true;
            button11.Visible = true;

            label7.Visible = true;
            label8.Visible = true;

            comboBox5.Visible = true;
            textBox5.Visible = true;
        }
    }


}
