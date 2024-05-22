using Medipol_Hospital.Concrete;
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

    public partial class Form4 : Form
    {
        Context c;
        PatientManager patientManager = new PatientManager();//nesne türet ve içindeki methotlara eriş
        
        public Form4()
        {
            InitializeComponent();
            
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            //nesne türet ve içindeki methotlara eriş
            c = new Context();
            
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            label6.Text = Session.sessionId.ToString();
        }

        private void button1_Click(object sender, EventArgs e) // Yeni Randevu
        {

            groupBox4.Visible = true;
            groupBox3.Visible = false;
            groupBox2.Visible = false;
            groupBox6.Visible = false;
            


            comboBox1.Items.Clear();
            // Doktorları ListBox'a ekleme
            foreach (var doktor in patientManager.GetDoctorAll())
            {
                comboBox1.Items.Add(doktor.Name);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = true;
            groupBox4.Visible = false;
            groupBox2.Visible = false;
            groupBox6.Visible = false;

            listBox1.Items.Clear();
            foreach (var x in patientManager.GetDoctorAll())
            {
                listBox1.Items.Add(x.Name + " " + x.Surname);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {


            Appointment meet = new Appointment()
            {
                appinmentTime = dateTimePicker1.Value,
                p_ID = Session.sessionId,
                doctorID = comboBox1.SelectedIndex,

            };
            if (!c.Appointments.Any(x => x.appinmentTime == meet.appinmentTime))
            {
                c.Appointments.Add(meet);
                c.SaveChanges();
            }
            else
            {
                MessageBox.Show("Randevu Dolu");
            }




        }

        private void button8_Click(object sender, EventArgs e) // Çıkış butonu
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

            //groupBox4.Visible = false;
            //groupBox3.Visible = false;
            //groupBox2.Visible = false;
            //groupBox5.Visible = false;
            groupBox6.Visible = true;

            dataGridView1.DataSource=  c.Appointments.ToList();

        }
    }
}
