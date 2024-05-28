using Medipol_Hospital.Concrete;
using Medipol_Hospital.Cryptography;
using MediSoft.Entities;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Medipol_Hospital
{
    public partial class Form1 : Form
    {
        Context c = new Context();
        LoginManager loginManager = new LoginManager();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            Confirm(false);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) //linkLabel ile yeni kullanıcı oluştur
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)  //giriş yap butonu
        {
            if (loginManager.Logins(textBox1.Text, textBox2.Text)) { this.Hide(); }
        }

        int a;

        private void button4_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int random = rnd.Next(100000, 1000000);
            if (loginManager.Verification(textBox4.Text, random)) { Confirm(true); a = random; }
            //label5.Text = a.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == a.ToString())
            {
                panel1.Visible = false;
                Session.MailConfirm = true;
                NewPassword pass = new NewPassword();
                pass.ShowDialog();
            }
            else
            {
                MessageBox.Show("Onay Kodu Hatalı Tekrar Dene");
            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel1.Visible = false;
            Confirm(false);
        }
        private void button2_Click(object sender, EventArgs e) //kapat
        {
            Application.Exit();
        }

        private void Confirm(bool deger)
        {
            textBox3.Visible = deger;
            button3.Visible = deger;
            label6.Visible = deger;
        }
    }
}