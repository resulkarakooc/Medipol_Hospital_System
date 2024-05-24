using Medipol_Hospital.Concrete;
using Medipol_Hospital.Cryptography;
using MediSoft.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Medipol_Hospital
{

    public partial class Form4 : Form
    {
        Context c;
        PatientManager patientManager = new PatientManager(); //nesne türet ve içindeki methotlara eriş

        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            //nesne türet ve içindeki methotlara eriş
            c = new Context();

            groupListDoctor.Visible = false;
            label6.Text = Session.sessionId.ToString();
            //label8.Text = Session.UserName.ToUpper();
        }

        private void button1_Click(object sender, EventArgs e) // Yeni Randevu
        {
            comboBox1.DataSource = c.Doctors.ToList();
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "doctorID";

            groupNewAppointment.Visible = true;
            groupListDoctor.Visible = false;
            groupListCurrent.Visible = false;

            //comboBox1.Items.Clear();
            //// Doktorları ListBox'a ekleme
            //foreach (var doktor in patientManager.GetDoctorAll())
            //{
            //    comboBox1.Items.Add(doktor.Name);
            //}

        }

        private void button4_Click(object sender, EventArgs e)
        {
            groupListDoctor.Visible = true;
            groupNewAppointment.Visible = false;
            groupListCurrent.Visible = false;

            listBox1.Items.Clear();
            foreach (var x in patientManager.GetDoctorAll())
            {
                listBox1.Items.Add(x.Name + " " + x.Surname);
            }
        }

        private void button5_Click(object sender, EventArgs e) //yeni randevu oluşturma
        {
            Doctors selectdoctor = (Doctors)comboBox1.SelectedItem;

            Appointment meet = new Appointment()
            {
                appinmentTime = dateTimePicker1.Value.Date,
                p_ID = Session.sessionId,
                doctorID = selectdoctor.doctorID,

            };

            patientManager.AddNewAppointment(meet);

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

        private void button2_Click(object sender, EventArgs e) //mevcut randevu listesi
        {
            List<Appointment> currnetapp = patientManager.GetCurrentAppt(Session.sessionId); //method ile randevular getirildi oturumu açık olan hastanın

            dataGridView1.DataSource = currnetapp; //getirilen liste dataGridView'e aktarıldı

            groupNewAppointment.Visible = false;
            groupListDoctor.Visible = false;
            groupListCurrent.Visible = true;
            

        }

        
    }
}
