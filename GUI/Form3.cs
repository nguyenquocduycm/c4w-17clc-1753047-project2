using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        //log out
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private string _studentID;
        public string StudentID
        {
            get { return _studentID; }
            set { _studentID = value; }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            //Form1 f1 = new Form1();
            string s = _studentID;
            DAL.DAL da = new DAL.DAL();
            DTO.Class cls = new DTO.Class();
            cls = da.GetStudentToInserrtfromDB(s);
            textBox1.Text = cls.Name;
            textBox2.Text = cls.ID;
            textBox3.Text = cls.classes;
        }

        //view score
        private void button3_Click(object sender, EventArgs e)
        {
            DAL.DAL da = new DAL.DAL();
            List<DTO.Transcript> score = new List<DTO.Transcript>();
            score=da.GetCoreStudent(textBox2.Text.ToString());
            listView3.Items.Clear();
            double result;
            string[] re = new string[2] { "Pass", "Fail" };
            foreach (DTO.Transcript c in score)
            {
                ListViewItem item = new ListViewItem();
                item.Text = c.Name;
                item.SubItems.Add(c.MidTerm);
                item.SubItems.Add(c.FinalTerm);
                item.SubItems.Add(c.Bonus);
                item.SubItems.Add(c.Total);
                double.TryParse(c.Total, out result);
                if (result < 5)
                    item.SubItems.Add(re[1]);
                else
                    item.SubItems.Add(re[0]);


                listView3.Items.Add(item);
            }
        }
    }
}
