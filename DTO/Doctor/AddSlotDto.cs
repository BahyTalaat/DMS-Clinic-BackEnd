﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Doctor
{
    public class AddSlotDto
    {
        public DateTime Time { get; set; }
        public int Status { get; set; }
        public int WorkingDayID { get; set; }
    }
}
