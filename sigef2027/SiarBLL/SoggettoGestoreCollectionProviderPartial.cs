using System.Linq;
using SiarLibrary;
using SiarLibrary.NullTypes;

namespace SiarBLL
{
    public partial class SoggettoGestoreCollectionProvider : ISoggettoGestoreProvider
    {
        // Enum per SVILUPPO
        //public enum EnumSoggettiGestore
        //{
        //    Artigiancassa = 1,
        //    Confidi = 2,
        //    ELios = 3,
        //    Poeta_Francesco = 4
        //}

        //Enum per PRODUZIONE
        public enum EnumSoggettiGestore
        {
            Artigiancassa = 1,          // ARTIGIANCASSA S.P.A.
            Confidi_Unico = 2,          // SOC.REG.DI GARANZIA MARCHE SCPA
            Confidicoop_Marche = 3,     // CONFIDICOOP MARCHE - SOCIETA‘ COOPERATIVA
            Fider = 4,                  // FIDER SOCIETA‘ COOPERATIVA DI GARANZIA COLLETTIVA FIDI
            Italia_Comfidi = 5          // ITALIA COM-FIDI SOCIETA‘ CONSORTILE A RESPONSABILITA‘ LIMITATA
        }
    }
}
