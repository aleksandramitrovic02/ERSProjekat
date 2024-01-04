using Comon;
using Comon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazaPodataka
{
    public class Servis : IEvidencija
    {
        public static DataBaseImpl Baza = DataBaseImpl.getBase();
        public void Audit(Audit a)
        {
            Baza.InsertAudit(a);
        }

        public void PrognoziranaIPotrosena(Potrosnja p)
        {
            Baza.InsertPotrosnja(p);
        }
    }
}
