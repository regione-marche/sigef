using System;
using SiarBLL;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{
    public partial class ChecklistGenericaCollectionProvider :IChecklistGenericaProvider
    {

        public ChecklistGenericaCollection GetSchedeByIdChecklist(int id_checklist)
        {
            var c_coll = new ChecklistGenericaCollection();

            IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"SELECT CG.* 
                                FROM VCHECKLIST_GENERICA CG 
	                                JOIN SCHEDA_X_CHECKLIST SXC ON CG.ID_CHECKLIST_GENERICA = SXC.ID_CHECKLIST_FIGLIO 
                                WHERE 1 = 1  
	                                AND CG.ID_TIPO = 2 
	                                AND SXC.ID_CHECKLIST_PADRE = @ID_CHECKLIST 
                                ORDER BY SXC.ORDINE ";

            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_CHECKLIST", id_checklist));

            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                var c = ChecklistGenericaDAL.GetFromDatareader(DbProviderObj);
                c_coll.Add(c);
            }
            DbProviderObj.Close();

            return c_coll;
        }

        public ChecklistGenericaCollection GetSchedeNotInIdChecklist(int id_checklist)
        {
            var c_coll = new ChecklistGenericaCollection();

            IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"SELECT CG.* 
                                FROM VCHECKLIST_GENERICA CG 
                                WHERE 1 = 1 
	                                AND CG.ID_TIPO = 2 
	                                AND CG.ID_CHECKLIST_GENERICA NOT IN (SELECT ID_CHECKLIST_FIGLIO 
										                                FROM SCHEDA_X_CHECKLIST 
										                                WHERE ID_CHECKLIST_PADRE = @ID_CHECKLIST) ";

            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_CHECKLIST", id_checklist));

            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                var c = ChecklistGenericaDAL.GetFromDatareader(DbProviderObj);
                c_coll.Add(c);
            }
            DbProviderObj.Close();

            return c_coll;
        }
    }
}
