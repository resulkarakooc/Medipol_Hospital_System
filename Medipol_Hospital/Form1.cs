using MediSoft.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;

namespace Medipol_Hospital
{
    public partial class Form1 : Form
    {
        Context c = new Context();

        public Form1()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) //linkLabel ile yeni kullanıcı oluştur
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1 != null || textBox2 != null) //boş mu kontrol et
            {
                
                //if(textBox1.Text == "61030403940" && textBox2.Text =="resul" )
                //{
                //    Form3 form3 = new Form3();
                //    form3.Show();
                //    this.Hide();
                //}
                if (radioButton1.Checked == true)
                {
                    Doctors deger = c.Doctors.FirstOrDefault(x => x.nationalityNo.ToString() == textBox1.Text);
                    Session.sessionId = deger.doctorID;
                    Form5 form5 = new Form5();
                    form5.Show();
                    this.Hide();


                }
                else if (radioButton2.Checked == true)
                {
                    Patinets hasta = c.Patches.FirstOrDefault(x => x.nationalityNo.ToString() == textBox1.Text);
                    Session.sessionId = hasta.pID;
                    Form4 form4 = new Form4();
                    form4.Show();
                    this.Hide();
                }



            }
            else
            {
                MessageBox.Show("Tüm Alanları Doldurunuz");
            }
        }

        private void button2_Click(object sender, EventArgs e) //kapat
        {
            Application.Exit();
        }

       
    }
}
