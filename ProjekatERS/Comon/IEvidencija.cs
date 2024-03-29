﻿using Comon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Comon
{
    [ServiceContract]
    public interface IEvidencija
    {
        [OperationContract]

        void PrognoziranaIPotrosena(Potrosnja p);

        [OperationContract]

        void Audit(Audit a);

        [OperationContract]

        List<string> GeoPodr();

        [OperationContract]

        void upisiOblast(GeografskaOblast geo);
    }
}
