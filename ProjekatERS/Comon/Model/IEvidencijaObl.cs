﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Comon.Model
{
    [ServiceContract]
    public interface IEvidencijaObl
    {
        [OperationContract]
        List<GeografskaOblast> evidencija();
    }
}
