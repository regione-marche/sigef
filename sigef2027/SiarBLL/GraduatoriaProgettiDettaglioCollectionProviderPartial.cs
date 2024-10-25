using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;


namespace SiarBLL
{
	public partial class GraduatoriaProgettiDettaglioCollectionProvider : IGraduatoriaProgettiDettaglioProvider
	{
        public GraduatoriaProgettiDettaglioCollection GetGraduatoriaProgettiDettaglioValutazione(int id_progetto)
        {
            GraduatoriaProgettiDettaglioCollection graduatoria = new GraduatoriaProgettiDettaglioCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpGetGraduatoriaProgettiDettaglioByPriorita";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_PROGETTO", id_progetto));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                GraduatoriaProgettiDettaglio gp = SiarDAL.GraduatoriaProgettiDettaglioDAL.GetFromDatareader(DbProviderObj);
                gp.AdditionalAttributes.Add("ID_PRIORITA", new IntNT(DbProviderObj.DataReader["ID_PRIORITA"]));
                gp.AdditionalAttributes.Add("FLAG_MANUALE", new IntNT(DbProviderObj.DataReader["FLAG_MANUALE"]));
                gp.AdditionalAttributes.Add("DESCRIZIONE", new StringNT(DbProviderObj.DataReader["DESCRIZIONE"]));
                graduatoria.Add(gp);
            }
            DbProviderObj.Close();
            return graduatoria;
        }
	}
}
