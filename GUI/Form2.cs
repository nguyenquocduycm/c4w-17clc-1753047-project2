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
                comboBox6.Items.Add(r);
            }

            List<string> l = new List<string>();
            l = da.GetScoreFromDBToCombobox();
            foreach (string r in l)
            {
                comboBox7.Items.Add(r);
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
            List<string> cls=new List<string>();
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
                    foreach (string s in cls)
                    {
                        comboBox5.Items.Add(s);
                        comboBox6.Items.Add(s);
                    }
                    
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

            comboBox6.Visible = false;
            listView2.Visible = false;
            button13.Visible = false;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            button10.Visible = false;
            button11.Visible = false;

            label7.Visible = false;
            label8.Visible = false;

            comboBox5.Visible = false;
            textBox5.Visible = false;

            comboBox6.Visible = true;
            listView2.Visible = true;
            button13.Visible = true;
            
        }

        private void button13_Click(object sender, EventArgs e)
        {
            DAL.DAL da = new DAL.DAL();
            //List<DTO.Class> cls = new List<DTO.Class>();

            //var cls = da.GetClassfromDB(comboBox1.SelectedItem.ToString());
            var cls = da.GetCodeShedulefromDB(comboBox6.SelectedItem.ToString());
            listView2.Items.Clear();

            foreach (DTO.Class c in cls)
            {
                ListViewItem item = new ListViewItem();
                item.Text = c.ID;
                item.SubItems.Add(c.Name);
                item.SubItems.Add(c.Sex);
                item.SubItems.Add(c.SSN);
                item.SubItems.Add(c.classes);
                listView2.Items.Add(item);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if(comboBox5.Text.ToString()==""||textBox5.Text.ToString()=="")
            {
                MessageBox.Show("You must enter all text", "Erorr", MessageBoxButtons.OK);
            }
            else
            {
                BUS.BUS b = new BUS.BUS();
                b.AddSchedule(comboBox5.SelectedItem.ToString(), textBox5.Text.ToString());
                MessageBox.Show("Inserted success", "Insert", MessageBoxButtons.OK);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (comboBox5.Text.ToString() == "" || textBox5.Text.ToString() == "")
            {
                MessageBox.Show("You must enter all text", "Erorr", MessageBoxButtons.OK);
            }
            else
            {
                BUS.BUS b = new BUS.BUS();
                b.DeleteSchedule(comboBox5.SelectedItem.ToString(), textBox5.Text.ToString());
                MessageBox.Show("Deleted success", "Insert", MessageBoxButtons.OK);
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            label9.Visible = true;
            label10.Visible = true;
            label11.Visible = true;
            label12.Visible = true;
            label13.Visible = true;
            label14.Visible = true;

            label15.Visible = false;
            label16.Visible = false;
            label17.Visible = false;
            label18.Visible = false;

            comboBox7.Visible = true;

            listView3.Visible = false;

            button18.Visible = false;
            button19.Visible = true;
            button20.Visible = false;
            button21.Visible = true;

            textBox6.Visible = true;
            textBox7.Visible = true;
            textBox8.Visible = true;
            textBox9.Visible = true;
            textBox10.Visible = true;

            textBox11.Visible = false;
            textBox12.Visible = false;
            textBox13.Visible = false;
            textBox14.Visible = false;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            label9.Visible = true;

            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
            label16.Visible = false;
            label17.Visible = false;
            label18.Visible = false;

            comboBox7.Visible = true;

            listView3.Visible = true ;

            button18.Visible = false;
            button19.Visible = false;
            button20.Visible = true;
            button21.Visible =false;

            textBox6.Visible = false;

            textBox7.Visible = false;
            textBox8.Visible = false;
            textBox9.Visible = false;
            textBox10.Visible = false;
            textBox11.Visible = false;
            textBox12.Visible = false;
            textBox13.Visible = false;
            textBox14.Visible = false;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            label9.Visible = true;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            label14.Visible = false;

            label15.Visible = true;
            label16.Visible = true;
            label17.Visible = true;
            label18.Visible = true;

            comboBox7.Visible = true;

            listView3.Visible = false;

            button18.Visible = true;
            button19.Visible = false;
            button20.Visible = false;
            button21.Visible = false;

            textBox6.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;
            textBox9.Visible = false;
            textBox10.Visible = false;

            textBox11.Visible = true;
            textBox12.Visible = true;
            textBox13.Visible = true;
            textBox14.Visible = true;
        }

        //import score
        private void button14_Click(object sender, EventArgs e)
        {
            string cls = "";
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
                
                bool type = da.AddScore(open.FileName, cls);


                if (type == false)
                {
                    MessageBox.Show("Format file is erorr", "ERORR", MessageBoxButtons.OK);
                }
                else
                {
                   comboBox7.Items.Add(cls);
                   
                    MessageBox.Show("Imported", "Message", MessageBoxButtons.OK);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //file update
        private void button21_Click(object sender, EventArgs e)
        {
            if(comboBox7.SelectedItem.ToString()==""||textBox6.Text.ToString()=="")
            {
                MessageBox.Show("You must enter all text", "Erorr", MessageBoxButtons.OK);
            }
            else
            {
                DAL.DAL d =new DAL.DAL();
                var update=d.GetFindUpdate(comboBox7.SelectedItem.ToString(), textBox6.Text.ToString());
                textBox7.Text = update.MidTerm;
                textBox8.Text = update.FinalTerm;
                textBox9.Text = update.Bonus;
                textBox10.Text = update.Total;
            }
        }

        //update
        private void button19_Click(object sender, EventArgs e)
        {
            double temp=0;
            DTO.Transcript Dt = new DTO.Transcript();
            if (comboBox7.SelectedItem.ToString() == "" || textBox6.Text.ToString() == ""|| !double.TryParse(textBox7.Text.ToString(),out temp) ||
                 !double.TryParse(textBox8.Text.ToString(), out temp) || !double.TryParse(textBox9.Text.ToString(), out temp) || !double.TryParse(textBox10.Text.ToString(), out temp))
            {
                
                MessageBox.Show("You must enter all text or data invalid", "Erorr", MessageBoxButtons.OK);
            }
            else
            {
                DAL.DAL da = new DAL.DAL();
                da.UpdateScore(comboBox7.SelectedItem.ToString(), textBox6.Text.ToString(), textBox7.Text.ToString(), textBox8.Text.ToString(), textBox9.Text.ToString(), textBox10.Text.ToString());
                MessageBox.Show("Updated success", "Update", MessageBoxButtons.OK);
            }
        }

        //view Score
        private void button20_Click(object sender, EventArgs e)
        {
            if (comboBox7.SelectedItem.ToString() == "" )
            {
                MessageBox.Show("You must enter all text", "Erorr", MessageBoxButtons.OK);
            }
            else
            {
                DAL.DAL da = new DAL.DAL();
                //List<DTO.Class> cls = new List<DTO.Class>();

                //var cls = da.GetClassfromDB(comboBox1.SelectedItem.ToString());

                var cls = da.GetScorefromDB(comboBox7.SelectedItem.ToString());
                listView3.Items.Clear();
                double result;
                string[] re =new string[2] { "Pass", "Fail" };
                foreach (DTO.Transcript c in cls)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = c.STT;
                    item.SubItems.Add(c.ID);
                    item.SubItems.Add(c.Name);
                    item.SubItems.Add(c.MidTerm);
                    item.SubItems.Add(c.FinalTerm);
                    item.SubItems.Add(c.Bonus);
                    item.SubItems.Add(c.Total);
                    double.TryParse(c.Total, out result);
                    if(result<5)
                        item.SubItems.Add(re[1]);
                    else
                        item.SubItems.Add(re[0]);


                    listView3.Items.Add(item);
                }
            }
        }
    }


}
