using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{
	public partial class BandoValidatoriCollectionProvider : IBandoValidatoriProvider
	{
        public BandoValidatoriCollection GetValidatoriRup(int id_utente_rup, IntNT id_bando)
        {
            BandoValidatoriCollection bv = new BandoValidatoriCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpPsrGetValidatoriRup";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_UTENTE", id_utente_rup));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_BANDO", id_bando));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                BandoValidatori v = BandoValidatoriDAL.GetFromDatareader(DbProviderObj);
                v.AdditionalAttributes.Add("DESCRIZIONE", new StringNT(DbProviderObj.DataReader["DESCRIZIONE"]));
                bv.Add(v);
            }
            DbProviderObj.Close();
            return bv;
        }

        public BandoValidatoriCollection GetValidatoriRupFem(int id_utente_rup, IntNT id_bando)
        {
            BandoValidatoriCollection bv = new BandoValidatoriCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpPsrGetValidatoriRupFem";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_UTENTE", id_utente_rup));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_BANDO", id_bando));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                BandoValidatori v = BandoValidatoriDAL.GetFromDatareader(DbProviderObj);
                v.AdditionalAttributes.Add("DESCRIZIONE", new StringNT(DbProviderObj.DataReader["DESCRIZIONE"]));
                bv.Add(v);
            }
            DbProviderObj.Close();
            return bv;
        }
    }
}
