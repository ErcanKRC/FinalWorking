﻿using FinalWorking.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWorking.Models
{
    public class UserModel : TableData
    {
        public string UserName { get; set; }
        public string UserAddress { get; set; }
    }
}
