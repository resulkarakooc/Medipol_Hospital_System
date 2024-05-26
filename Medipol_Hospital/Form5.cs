using Medipol_Hospital.Concrete;
using Medipol_Hospital.MailService;
using Medipol_Hospital.PdfCreater;
using System;

using System.Windows.Forms;

namespace Medipol_Hospital
{
    public partial class Form5 : Form
    {
        DoctorManager doctorManager = new DoctorManager();
        
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            //label3.Text = Session.UserName;
        }


        private void button1_Click(object sender, EventArgs e) //giriş yapan doktora randevusu olan hastalara getir 
        {
           dataGridView1.DataSource =  doctorManager.GetMyPat(Session.sessionId); //gelen listeyi ata
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MailService.MailService.SendEmail("resul.coder@gmail.com");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
    }
}
