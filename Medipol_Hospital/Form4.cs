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
            VisibleFalse();
            
            label6.Text = Session.sessionId.ToString();
            label8.Text = Session.UserName.ToUpper();
        }

        private void button1_Click(object sender, EventArgs e) // Yeni Randevu sayfası
        {
            comboBox1.DataSource = c.Doctors.ToList(); //comboboxa verileri gönder
            comboBox1.DisplayMember = "FullName";
            comboBox1.ValueMember = "doctorID";

            VisibleFalse(); 
            groupNewAppointment.Visible = true;

        }

        private void button5_Click(object sender, EventArgs e) //yeni randevu oluşturma 
        {
            Doctors selectdoctor = (Doctors)comboBox1.SelectedItem;  //seçilen doktoru al 

            Appointment meet = new Appointment()  //randevu nesnesi oluştur
            {
                appinmentTime = dateTimePicker1.Value.Date,
                p_ID = Session.sessionId,
                doctorID = selectdoctor.doctorID,
                hourAndSecond = dateTimePicker2.Value.Hour.ToString() + "." + dateTimePicker2.Value.Minute

            };

            patientManager.AddNewAppointment(meet); //managera postala

        }


        private void button4_Click(object sender, EventArgs e) //doktorları listele
        {
            VisibleFalse();
            groupListDoctor.Visible = true;
           

            listBox1.Items.Clear();                             //listeye ekle doktorların isimlerini
            foreach (var x in patientManager.GetDoctorAll())   
            {
                listBox1.Items.Add(x.Name + " " + x.Surname);
            }
        }

        private void button2_Click(object sender, EventArgs e) //mevcut randevu listesi
        {
            VisibleFalse();
            List<Appointment> currnetapp = patientManager.GetCurrentAppt(Session.sessionId);   //method ile randevular getirildi oturumu açık olan hastanın
            
            dataGridView1.DataSource = currnetapp; //getirilen liste dataGridView'e aktarıldı          
            groupListCurrent.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)  // Çıkış yap
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();

        }

        private void button8_Click(object sender, EventArgs e) // Çıkış butonu
        {
            Application.Exit();
        }

        private void VisibleFalse()
        {
            groupNewAppointment.Visible = false;
            groupListDoctor.Visible = false;
            groupListCurrent.Visible = false;
        }

      
    }
}
