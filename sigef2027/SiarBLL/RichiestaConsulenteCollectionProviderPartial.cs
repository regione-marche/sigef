using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{

    public partial class RichiestaConsulenteCollectionProvider : IRichiestaConsulenteProvider
    {
        public RichiestaConsulenteCollection GetrRichistaConsulenteProcuraByRup(int idRup)
        {
            RichiestaConsulenteCollection richiesteProcura = new RichiestaConsulenteCollection();
            DbProvider db = DbProviderObj;
            System.Data.IDbCommand cmd = db.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //cmd.CommandText = "SpGetRichiesteAccessoAtti";
            cmd.CommandText = "SpGetRichiesteConsulenteProcura";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_UTENTE", idRup));
            db.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                SiarLibrary.RichiestaConsulente c = SiarDAL.RichiestaConsulenteDAL.GetFromDatareader(DbProviderObj);
                c.AdditionalAttributes.Add("ID", new IntNT(DbProviderObj.DataReader["ID"]));
                c.AdditionalAttributes.Add("ID_BANDO", new IntNT(DbProviderObj.DataReader["ID_BANDO"]));
                c.AdditionalAttributes.Add("ID_RUP", new IntNT(DbProviderObj.DataReader["ID_RUP"]));
                c.AdditionalAttributes.Add("SEGNATURA_PROCURA", new StringNT(DbProviderObj.DataReader["SEGNATURA_PROCURA"]));
                richiesteProcura.Add(c);
            }
            db.Close();
            return richiesteProcura;
        }
    }
}