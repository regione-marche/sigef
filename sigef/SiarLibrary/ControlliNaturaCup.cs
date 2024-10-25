using SiarLibrary.NullTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiarLibrary
{
    public class ControlliNaturaCup
    {
        /// <summary>
        /// - Se Natura CUP = 01, 02, 03 => non deve permettere di includere un anticipo;
        /// - Se Natura CUP = 06, 07 => deve permettere di includere un anticipo con la scelta obbligata della polizza fidejussoria e la quota massima del 40%;
        /// - Se Natura CUP = 08 => deve permettere di includere un anticipo anche senza polizza e senza vincolo su quota massima.
        /// </summary>
        /// <param name="naturaCup"></param>
        /// <param name="quotaMax"></param>
        /// <param name="codTipoPolizza"></param>
        /// <param name="codDomandaPagamento"></param>
        /// <returns></returns>
        public static Boolean ControllaTipoDomandePagamentoByNaturaCupBando(List<string> naturaCup, DecimalNT quotaMax, string codTipoPolizza, SiarLibrary.BandoTipoPagamento tipo) {
            bool ok = true;

            foreach (string n in naturaCup)
            {
                if (n == "01" || n == "02" || n == "03")
                {
                    if (tipo.IdBando != null && tipo.CodTipo == "ANT")
                        ok = false;
                }
                else if (n == "06" || n == "07")
                {
                    if (tipo.IdBando != null && tipo.CodTipo == "ANT")
                    {
                        if (codTipoPolizza != "F1F" || (quotaMax != null && quotaMax.Value > 40))
                            ok = false;
                    }
                }
            }

            return ok;
        }
    }
}
