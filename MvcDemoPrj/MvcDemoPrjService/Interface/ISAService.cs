﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcDemoPrj.SQLModel.Models;

namespace MvcDemoPrjService.Interface
{
    interface ISAService
    {
        List<SA_User> GetAll(); 
    }
}
