using System;
using System.Collections.Generic;
using System.Text;

namespace SianWebSrv
{
    public static class CodiceProgettoAgea
    {
        public static bool IsOk(string CodiceAGEA)
        {
            if (CodiceAGEA.Length != 11) return false;            
            // devono essere tutti numeri
            int prova_intero;
            if (!Int32.TryParse(CodiceAGEA, out prova_intero)) return false;
            
            string Parte1 = CodiceAGEA.Substring(0, 10);
            char CkPresente, CkPrevisto;
            CkPresente = char.Parse(CodiceAGEA.Substring(10, 1));
            CkPrevisto = getCheckDigit(Parte1);
            return (CkPresente == CkPrevisto);            
        }

        public static char getCheckDigit(string Codice)
        {
            // controllo che Codice sia di 10 caratteri numerici
            if (Codice.Length != 10)
            {
                throw new Exception("La prima parte del Codice AGEA deve essere di 10 caratteri [" +
                                    Codice + "] è lungo " + Codice.Length.ToString() + " caratteri.");
            }
            long prova_intero;
            if(!Int64.TryParse(Codice,out prova_intero))
                throw new Exception("Il Codice AGEA deve essere composto di 10 caratteri NUMERICI [" +
                                    Codice + "] contiene almeno un carattere non numerico.");


            char[] Caratteri = Codice.ToCharArray();
            char CkDigit;

            // converto i caratteri in numeri
            int[] Cifre = new int[10];
            for (int ix = 0; 9 >= ix; ++ix)
            {
                Cifre[ix] = Convert.ToInt32(Caratteri[ix].ToString());
            }

            // sostituire cifre di posizione (1,3,5,7,9) con: 
            // somma di parte decimale e intera del doppio/10
            int Cifra, Pint, Pdec;
            decimal d10_2;
            for (int ix = 0; 4 >= ix; ++ix)
            {
                Cifra = Convert.ToInt32(Cifre[ix * 2 + 1]);
                d10_2 = Convert.ToDecimal(Cifra) * 2 / 10;
                Pint = Convert.ToInt32(Math.Truncate(d10_2));
                Pdec = Convert.ToInt32(Math.Truncate((d10_2 - Pint) * 10));
                Cifra = Pint + Pdec;
                Cifre[ix * 2 + 1] = Cifra; 
            }

            // calcolare somma cifre
            decimal sum = 0;
            for (int ix = 0; 9 >= ix; ++ix)
            {
                sum = sum + Cifre[ix];
            }

            // se sum/10 è intero check digit vale 0 altrimenti
            // vale 10 - parte decimale di sum/10
            decimal s10 = sum / 10;
            int CkDigitInt;
            if (Math.Truncate(s10) == s10)
            {
                CkDigit = char.Parse("0");
            }
            else
            {
                Pint = Convert.ToInt32(Math.Truncate(s10));
                Pdec = Convert.ToInt32(Math.Truncate((s10 - Pint) * 10));
                CkDigitInt = 10 - Pdec;
                CkDigit = char.Parse(CkDigitInt.ToString());
            }
            return CkDigit;
        }

        public static string getNewCodiceAgea()
        {
            try
            {
                SiarLibrary.DbProvider db = new SiarLibrary.DbProvider();
                System.Data.IDbCommand cmd = db.GetCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "calcoloCodiceProgettoAgea";
                object result = db.ExecuteScalar(cmd);
                db.Close();
                return result.ToString() + getCheckDigit(result.ToString());
            }
            catch(Exception ex) { return ex.Message; }
        }

    }
}
