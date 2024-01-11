using Comon;
using Comon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazaPodataka
{
    public class ServisObl : IGeo
    {
        DataBaseImpl baza = DataBaseImpl.getBase();
        public List<GeografskaOblast> evidencija()
        {
            return baza.GetGeografskaOblast();
        }

        public void ubaci(GeografskaOblast oblast)
        {
            baza.InsertGeorafskaOblast(oblast);
        }
    }
}
