﻿using MediSoft.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medipol_Hospital.Abstract
{
    public interface IPersoneLService
    {
        List<Patinets> GetPatAll();
        List<Doctors> GetDoctorAll();
    }
}
