﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher2023.Demo.DL.Model
{
    public class DistrictPagingArgument : BasePagingArgument
    {
        public Guid CityId { get; set; }
    }
}
