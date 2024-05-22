using Medipol_Hospital.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
             
        }


        private void button1_Click(object sender, EventArgs e) //giriş yapan doktora randevusu olan hastalara getir 
        {
           dataGridView1.DataSource =  doctorManager.GetMyPat(Session.sessionId); //gelen listeyi ata
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
    }
}
