using Medipol_Hospital.Cryptography;
using MediSoft.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Medipol_Hospital
{
    public partial class NewPassword : Form
    {
        public NewPassword()
        {
            InitializeComponent();
        }

        
        Context c = new Context();
        private void button1_Click(object sender, EventArgs e)
        {
            if (Session.WhoIsLoggedIn == 1)
            {
                if (Sha256Converter.ComputeSha256Hash(textBox1.Text) == Session.Password)
                {
                    if (textBox2.Text == textBox3.Text)
                    {
                        string deger = Sha256Converter.ComputeSha256Hash(textBox3.Text);
                        var sonuc = c.Doctors.FirstOrDefault(x => x.doctorID == Session.sessionId);
                        sonuc.Password = deger;
                        Session.Password = deger;
                    }
                }
            }
            else if (Session.WhoIsLoggedIn == 0)
            {
                if (Sha256Converter.ComputeSha256Hash(textBox1.Text) == Session.Password)
                {
                    if (textBox2.Text == textBox3.Text)
                    {
                        string deger = Sha256Converter.ComputeSha256Hash(textBox3.Text);
                        var sonuc = c.Patches.FirstOrDefault(x => x.pID == Session.sessionId);
                        sonuc.Password = deger;
                        Session.Password = deger;
                    }
                }
            }
            else
            {
                MessageBox.Show("Hata Ana Sayfaya Yönlendiriliyorsunuz ");
                Form1 form1 = new Form1();
                form1.Show();
                this.Close();
            }
            
        }
    }
}
