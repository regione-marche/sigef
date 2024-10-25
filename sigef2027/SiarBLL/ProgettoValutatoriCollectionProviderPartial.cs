using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{
	public partial class ProgettoValutatoriCollectionProvider : IProgettoValutatoriProvider
	{
        public ProgettoValutatoriCollection GetValutatoriProgetto(int id_progetto_valutazione)
        {
            ProgettoValutatoriCollection valutatori = new ProgettoValutatoriCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpGetValutatoriProgetto";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_PROGETTO_VALUTAZIONE", id_progetto_valutazione));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                ProgettoValutatori pv = SiarDAL.ProgettoValutatoriDAL.GetFromDatareader(DbProviderObj);
                pv.AdditionalAttributes.Add("NOMINATIVO", new StringNT(DbProviderObj.DataReader["NOMINATIVO"]));
                valutatori.Add(pv);
            }
            DbProviderObj.Close();
            return valutatori;
        }
	}
}