using Medipol_Hospital.Concrete;
using Medipol_Hospital.MailService;
using Medipol_Hospital.PdfCreater;
using MediSoft.Entities;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Medipol_Hospital
{
    public partial class Form5 : Form
    {
        Context c = new Context();
        DoctorManager doctorManager = new DoctorManager();

        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            VisibleFalse();
            label3.Text = Session.UserName;
            dataGridView2.DataSource = doctorManager.GetMyPat(Session.sessionId);
        }
        private void button1_Click(object sender, EventArgs e) //giriş yapan doktora randevusu olan hastalara getir 
        {
            VisibleFalse();
            groupBox2.Visible = false;
            dataGridView1.DataSource = doctorManager.GetMyPat(Session.sessionId); //gelen listeyi ata
        }

        private void button7_Click(object sender, EventArgs e) // oturumu kapat
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridView2.SelectedRows[0].Index;

                int HastaID = Convert.ToInt32(dataGridView2.Rows[selectedRowIndex].Cells["ID"].Value);

                var sonuc = c.Patches.FirstOrDefault(x => x.pID == HastaID);
                string ad = sonuc.Name;
                string soyad = sonuc.Surname;
                string birth = sonuc.BirthYear.ToString();

                PdfCreater.PdfCreater.Create(sonuc.nationalityNo, ad, soyad, Session.UserName, Session.UserSurname, DateTime.Now.ToString(), textBox2.Text, textBox1.Text, textBox3.Text);
            }
            else
            {
                MessageBox.Show("Lütfen Hasta seçiniz.");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MailService.MailService.SendEmail("resul.coder@gmail.com"); //mail onay kodu çalışır vaziyette
        }

        private void button3_Click(object sender, EventArgs e)
        {
            VisibleFalse();
            groupBox1.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void VisibleFalse()
        {
            groupBox1.Visible=false;
            groupBox2.Visible=false;          
        }

       
    }
}
