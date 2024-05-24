using Medipol_Hospital.Abstract;
using Medipol_Hospital.Adapter;
using Medipol_Hospital.Concrete;
using Medipol_Hospital.Cryptography;
using Medipol_Hospital.Entities;
using MediSoft.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Medipol_Hospital
{
    public partial class Form2 : Form
    {

        Context c = new Context();
        LoginManager loginManager = new LoginManager();
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1 != null && textBox2 != null && textBox3 != null && textBox4 != null && textBox5 != null)
            {

                string hashpass = Sha256Converter.ComputeSha256Hash(textBox4.Text); /*Hashleme*/

                if (comboBox1.SelectedIndex == 0)
                {
                    Patinets user = new Patinets()
                    {
                        nationalityNo = textBox1.Text,
                        Name = textBox2.Text,
                        Surname = textBox3.Text,
                        BirthYear = Convert.ToInt32(textBox5.Text),
                        registerDate = DateTime.Now,
                        Password = hashpass
                    };

                    if (loginManager.RegisterPatient(user)) { this.Hide(); }


                }

                //Doktor Kayıt
                else if (comboBox1.SelectedIndex == 1)
                {
                    Doctors user = new Doctors()
                    {
                        nationalityNo = textBox1.Text,
                        Name = textBox2.Text,
                        Surname = textBox3.Text,
                        BirthYear = Convert.ToInt32(textBox5.Text),
                        Password = hashpass
                    };

                    if (loginManager.RegisterDoctor(user)) { this.Hide(); }

                }
                else
                {
                    MessageBox.Show("Tüm Alanları Doldurun Lütfen");
                }
            }
            else
            {
                MessageBox.Show("Tüm Alanları Doldurun Lütfen");

            }



        }


        //Hashleme




        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }

}
