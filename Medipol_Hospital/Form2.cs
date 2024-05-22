using Medipol_Hospital.Abstract;
using Medipol_Hospital.Adapter;
using Medipol_Hospital.Cryptography;
using MediSoft.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Medipol_Hospital
{
    public partial class Form2 : Form
    {

        Context c = new Context();
        public Form2()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1 != null && textBox2 != null && textBox3 != null && textBox4 != null && textBox5 != null)
            {

                string hashpass = Sha256Converter.ComputeSha256Hash(textBox4.Text); /*Hashleme*/

                if (comboBox1.SelectedIndex == 0)
                {
                    // MessageBox.Show("Emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    Patinets patinet = new Patinets()
                    {
                        nationalityNo = textBox1.Text,
                        Name = textBox2.Text,
                        Surname = textBox3.Text,
                        birthYear = Convert.ToInt32(textBox5.Text),
                        registerDate = DateTime.Now,
                        doctorID = 1

                    };


                    if (!c.Patches.Any(a => a.nationalityNo == patinet.nationalityNo))
                    {
                        ICheckedService check = new FakeAdapterCheckOfPerson(); //böyle biri gerçekten var mı?

                        if (check.CheckofPerson(patinet)) //kişi doğrulanınca if'in içine gir
                        {
                            c.Patches.Add(patinet); //ekle tabloya
                            c.SaveChanges();    //kaydet
                            MessageBox.Show("Hasta başarıyla eklendi."); //feedback
                            Form4 form4 = new Form4();
                            form4.Show();  //yönlendir
                            this.Hide();
                        }

                        //*****Hata Mesajları*****
                        else
                        {
                            MessageBox.Show("Mernis Veritabanında Kişi Bulunamadı");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Zaten Kayıtlı Giriş Ekranına Gidiniz");
                    }
                }

                //Doktor Kayıt
                else if (comboBox1.SelectedIndex == 1)
                {
                    Doctors doctor1 = new Doctors()  //doktor objesi hazırla
                    {
                        nationalityNo = Convert.ToInt64(textBox1.Text),
                        Name = textBox2.Text,
                        Surname = textBox3.Text,
                        BirthYear = Convert.ToInt32(textBox5.Text),
                        Password = hashpass
                    };

                    //Daha önce kayıt oldu mu 
                    if (!c.Doctors.Any(a => a.nationalityNo == doctor1.nationalityNo))
                    {
                        ICheckedService check = new FakeAdapterCheckOfPerson(); //böyle biri gerçekten var mı?

                        if (check.CheckofPerson(doctor1)) //kişi doğrulanınca if'in içine gir
                        {
                            c.Doctors.Add(doctor1); //ekle tabloya
                            c.SaveChanges();    //kaydet
                            MessageBox.Show("Doktor başarıyla eklendi."); //feedback
                            Form5 form5 = new Form5();
                            form5.Show();  //yönlendir
                            this.Hide();
                        }

                        //*****Hata Mesajları*****
                        else
                        {
                            MessageBox.Show("Mernis Veritabanında Kişi Bulunamadı");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Zaten Kayıtlı Giriş Ekranına Gidiniz");
                    }


                }
                else
                {
                    MessageBox.Show("Tüm Alanları Doldurun Lütfen");
                }
            }
            else
            {
                MessageBox.Show("Tüm Alanları Doldurun Lütfen");

            }



        }


        //Hashleme
        

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }

}
