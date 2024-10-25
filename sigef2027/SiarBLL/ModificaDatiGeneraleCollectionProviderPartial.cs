using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiarLibrary;


namespace SiarBLL
{
    public partial class ModificaDatiGeneraleCollectionProvider : IModificaDatiGeneraleProvider
    {
    }
}

namespace SiarLibrary
{
    public partial class ModificaDatiGenerale : BaseObject
    {
        public enum eTipoModifica { Priorita, Indicatori, Requisiti };
    }
}