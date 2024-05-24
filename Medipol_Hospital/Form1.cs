using Medipol_Hospital.Concrete;
using Medipol_Hospital.Cryptography;
using MediSoft.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
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
            if(textBox1.Text=="***" && textBox2.Text == "***")
            {
                Form3 form3 = new Form3();
                form3.Show();
                this.Hide();
            }
            

            Doctors dc = c.Doctors.FirstOrDefault(x => x.nationalityNo.ToString() == textBox1.Text);

            Patinets hasta = c.Patches.FirstOrDefault(x => x.nationalityNo.ToString() == textBox1.Text);

            string hashpass = Sha256Converter.ComputeSha256Hash(textBox2.Text);
            LoginManager loginManager = new LoginManager();
            if(loginManager.Login(hasta, dc)) {this.Hide();} 

           

        }

        private void button2_Click(object sender, EventArgs e) //kapat
        {
            Application.Exit();
        }


    }
}
