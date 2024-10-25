using SiarLibrary;
using SiarLibrary.NullTypes;

namespace SiarBLL
{
    public partial class RecuperoBeneficiarioCollectionProvider : IRecuperoBeneficiarioProvider
    {
    }

    public class OrigineRecuperoBeneficiario
    {
        public IntNT Id { get; set; }
        public StringNT Tipologia { get; set; }   
        public StringNT IdETipologia { get; set; }
        public StringNT Origine { get; set; }
        public DecimalNT Importo { get; set; }
        public BoolNT Selezionato { get; set; }
    }
}
