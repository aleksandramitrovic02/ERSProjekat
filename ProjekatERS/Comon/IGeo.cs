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
<<<<<<< HEAD
=======

>>>>>>> 0ef284351df4a79a14c4edaa229fe0ef7a36aa5d
    }
}
