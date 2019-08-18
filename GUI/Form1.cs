using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using DTO;

namespace GUI
{
   
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string studentID;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count = 0;
            if (textBox1.Text.ToString() == "" || textBox2.Text.ToString() == "")
            {
                MessageBox.Show("You must import user or pass", "Error", MessageBoxButtons.OK);

            }
            
            else 
            {
                List<DTO.LogIn> log = new List<DTO.LogIn>();
                DAL.DAL d = new DAL.DAL();
                var list = d.GetLogIn();
                foreach (var loglist in list)
                {
                    if(textBox1.Text.ToString() == "giaovu" && textBox2.Text.ToString() == "giaovu")
                    {
                        //this.Close();
                        Visible = false;
                        Form2 f2 = new Form2();
                        //Form1 f1 = new Form1();
                        //f2.Activate();
                        f2.ShowDialog();
                        this.Visible = true;


                        count = 1;
                        break;
                    }
                    else if (loglist.User == textBox1.Text.ToString() && loglist.Password == textBox2.Text.ToString())
                    {

                        
                        Visible = false;
                        Form3 f3 = new Form3();
                        //Form1 f1 = new Form1();
                        //f2.Activate();
                        f3.StudentID= textBox1.Text.ToString();
                        //studentID = textBox1.Text.ToString();
                        f3.ShowDialog();
                        this.Visible = true;

                        count = 1;
                        break;
                    }

                }
                if (count == 0)
                {
                    MessageBox.Show("User or password is invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DAL.DAL d = new DAL.DAL();
            d.InsertGiaoVu();
        }
    }
}
