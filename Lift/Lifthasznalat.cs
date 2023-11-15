using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lift
{

    //  2018.03.06.   11   3    0
    internal class Lifthasznalat
    {
        DateTime idopont;
        int sorszam;
        int indulo;
        int erkezo;

        public Lifthasznalat(DateTime idopont, int sorszam, int indulo, int erkezo)
        {
            this.idopont = idopont;
            this.sorszam = sorszam;
            this.indulo = indulo;
            this.erkezo = erkezo;
        }

        public DateTime Idopont { get => idopont; set => idopont = value; }
        public int Sorszam { get => sorszam; set => sorszam = value; }
        public int Indulo { get => indulo; set => indulo = value; }
        public int Erkezo { get => erkezo; set => erkezo = value; }
    }
}
