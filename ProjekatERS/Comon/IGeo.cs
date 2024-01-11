using Comon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Comon
{
    [ServiceContract]
    public interface IGeo
    {
        [OperationContract]
        List<GeografskaOblast> evidencija();

        [OperationContract]
        void ubaci(GeografskaOblast oblast);
    }
}
