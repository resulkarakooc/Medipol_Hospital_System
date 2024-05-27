using Medipol_Hospital.Abstract;
using MediSoft.Entities;
using System;
using System.Collections.Generic;
using System.Linq;



namespace Medipol_Hospital.Concrete
{
    public class DoctorManager : IDoctorService
    {
        Context c = new Context();
        public List<object> GetMyPat(int id)
        {
            //LINQ sorgusu yap inner join için
            var sonuc = (from doctor in c.Doctors                              //dokotorlar tablosundaki her bir satır içi ism ata
                         join app in c.Appointments                            //randevular içi ne aynısı
                         on doctor.doctorID equals app.doctorID                //doctor ID aynı olan satırları tut
                         join pat in c.Patches                                 //aynısı hasta tablosu için
                         on app.p_ID equals pat.pID                            //randevu tablosu hasta ıd ile eşle ve tut
                         where doctor.doctorID == id                           // gelen parametreden doktoru ayıkla
                         select new
                         {

                             ID = pat.pID,  //yeni obje satırları eşleme
                             PatientName = pat.Name + " " + pat.Surname,
                             Randevu_Tarihi = app.appinmentTime,
                             Dogum_Yılı = pat.BirthYear,
                             DoctorName = doctor.Name + " " + doctor.Surname

                         }).ToList<object>();                                  //objeleri listelere ata

            return sonuc; //gönder
        }



    }
}
