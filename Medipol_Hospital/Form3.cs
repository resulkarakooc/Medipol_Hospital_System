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
            groupBox2.Visible = false;
            groupBox3.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = false;
            groupBox2.Visible = true;

            listBox2.Items.Clear();
            foreach (Patinets pat in personelManager.GetPatAll())
            {
                listBox1.Items.Add(pat.Name + " " + pat.Surname + pat.registerDate);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            groupBox3.Visible = true;

            listBox2.Items.Clear();
            foreach (Doctors dc in personelManager.GetDoctorAll())
            {
                listBox2.Items.Add(dc.Name + " " + dc.Surname + " " + dc.BirthYear);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            groupBox4.Visible = true;
            groupBox3.Visible = false;
            groupBox2.Visible = false;

            comboBox1.DataSource = c.Doctors.ToList();
            comboBox1.DisplayMember = "FullName";
            comboBox1.ValueMember = "doctorID";
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Doctors selectDoctor = (Doctors)comboBox1.SelectedItem;

            personelManager.RemoveDoctor(selectDoctor);

            comboBox1.DataSource = c.Doctors.ToList();
            comboBox1.DisplayMember = "FullName";
            comboBox1.ValueMember = "doctorID";

        }


        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


    }
}
