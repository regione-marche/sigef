using System;
using SiarBLL;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;


namespace SiarBLL
{
    public partial class CheckListXStepCollectionProvider : ICheckListXStepProvider
    {
        public CheckListXStepCollection GetStepByChecklist(IntNT IdChecklist, string cod_fase, string misura, string descrizione)
        {
            CheckListXStepCollection retval = new CheckListXStepCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpGetStepByChecklist";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_CHECK_LIST", IdChecklist.Value));
            if (!string.IsNullOrEmpty(cod_fase)) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("COD_FASE", cod_fase));
            if (!string.IsNullOrEmpty(misura)) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("MISURA", misura));
            if (!string.IsNullOrEmpty(descrizione)) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("DESCRIZIONE", descrizione));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read()) retval.Add(SiarDAL.CheckListXStepDAL.GetFromDatareader(DbProviderObj));
            DbProviderObj.Close();
            return retval;
        }

        public CheckListXStepCollection GetStepByCodiceQuery(string codice )
        {
            CheckListXStepCollection retval = new CheckListXStepCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpGetStepByCodiceQuery";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("CODICE", codice));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read()) {
                CheckListXStep CheckListXStepObj = new CheckListXStep();
                CheckListXStepObj.IdStep = new SiarLibrary.NullTypes.IntNT(DbProviderObj.DataReader["ID_STEP"]);
                CheckListXStepObj.Obbligatorio = new SiarLibrary.NullTypes.BoolNT(DbProviderObj.DataReader["OBBLIGATORIO"]);
                CheckListXStepObj.Step = new SiarLibrary.NullTypes.StringNT(DbProviderObj.DataReader["STEP"]);
                CheckListXStepObj.Automatico = new SiarLibrary.NullTypes.BoolNT(DbProviderObj.DataReader["AUTOMATICO"]);
                CheckListXStepObj.QuerySql = new SiarLibrary.NullTypes.StringNT(DbProviderObj.DataReader["QUERY_SQL"]);
                CheckListXStepObj.CheckList = new SiarLibrary.NullTypes.StringNT(DbProviderObj.DataReader["CHECK_LIST"]);
                CheckListXStepObj.ValMassimo = new SiarLibrary.NullTypes.StringNT(DbProviderObj.DataReader["VAL_MASSIMO"]);
                CheckListXStepObj.ValMinimo = new SiarLibrary.NullTypes.StringNT(DbProviderObj.DataReader["VAL_MINIMO"]);
                CheckListXStepObj.FaseProcedurale = new SiarLibrary.NullTypes.StringNT(DbProviderObj.DataReader["FASE_PROCEDURALE"]);

                retval.Add(CheckListXStepObj);
            }
                
                
            DbProviderObj.Close();
            return retval;
        
        }
    }
}
