using Medipol_Hospital.Concrete;
using MediSoft.Entities;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Medipol_Hospital
{
    public partial class Form3 : Form
    {
        Context c = new Context();
        PersonelManager personelManager = new PersonelManager();

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {


            VisibleFalse();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VisibleFalse();
            groupBox2.Visible = true;

            dataGridView3.DataSource = personelManager.GetAllPat();

        }


        private void button4_Click(object sender, EventArgs e)
        {
            VisibleFalse();
            groupBox4.Visible = true;
            dataGridView2.DataSource = personelManager.GetDoctorAll();
        }


        private void button3_Click_1(object sender, EventArgs e)
        {

            if (dataGridView2.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridView2.SelectedRows[0].Index;
                
                    int doctorID = Convert.ToInt32(dataGridView2.Rows[selectedRowIndex].Cells["doctorID"].Value);
                    personelManager.RemoveDoctor(doctorID);

                    dataGridView1.DataSource = c.Doctors.ToList();
               
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz randevuyu seçiniz.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            VisibleFalse();
            groupBox6.Visible = true;
            dataGridView1.DataSource = personelManager.GetAllAppointment();
        }

        private void button9_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridView1.SelectedRows[0].Index;

                int randevuID = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells["Randevu_ID"].Value);
                personelManager.RemoveAppointment(randevuID);

                dataGridView1.DataSource = personelManager.GetAllAppointment();
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz randevuyu seçiniz.");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void VisibleFalse()
        {
            groupBox2.Visible = false;
            
            groupBox4.Visible = false;
            groupBox6.Visible = false;
        }


    }


}
