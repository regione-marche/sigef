using SiarDAL;
using SiarLibrary;
using SiarLibrary.NullTypes;
using System.Data;

namespace SiarBLL
{
    public partial class IrregolaritaCollectionProvider :IIrregolaritaProvider
    {
        public IrregolaritaCollection GetIrregolaritaDaRecuperarePerProgetto(IntNT idProgetto)
        {
            var irrCollection = new IrregolaritaCollection();

            DbProvider db = DbProviderObj;
            IDbCommand cmd = db.GetCommand();
            Irregolarita irr;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SpGetIrregolaritaDaRecuperarePerProgetto";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("IdProgetto", idProgetto.Value));
            
            db.InitDatareader(cmd);
            while (db.DataReader.Read())
            {
                irr = IrregolaritaDAL.GetFromDatareader(db);
                irrCollection.Add(irr);
            }
            db.Close();

            return irrCollection;
        }

        public DetrazioniGestioneLavori GetDetrazioniGestioniLavori(IntNT idProgetto)
        {
            DetrazioniGestioneLavori d = new DetrazioniGestioneLavori();
            DbProvider db = DbProviderObj;
            IDbCommand cmd = db.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spGetDetrazioniGestioneLavori";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_PROGETTO", idProgetto.Value));

            db.InitDatareader(cmd);
            while (db.DataReader.Read())
            {
                d.DetrazioniImportoAmmesso = new DecimalNT(db.DataReader["IMPORTO_IRREGOLARE_AMMESSO"]);
                d.DetrazioniContributoAmmesso = new DecimalNT(db.DataReader["IMPORTO_IRREGOLARE_CONCESSO"]);
            }
            db.Close();

            return d;
        }

        public class DetrazioniGestioneLavori
        {
            public DecimalNT DetrazioniImportoAmmesso { get; set; }
            public DecimalNT DetrazioniContributoAmmesso { get; set; }
        }
    }
}
