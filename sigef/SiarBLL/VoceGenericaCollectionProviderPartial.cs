using SiarLibrary;
using SiarDAL;
using System.Data;
using SiarLibrary.NullTypes;
using System;

namespace SiarBLL
{
    public partial class VoceGenericaCollectionProvider :IVoceGenericaProvider
    {
        public VoceGenericaCollection GetVociByIdChecklist(int id_checklist)
        {
            var voci_coll = new VoceGenericaCollection();

            IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"SELECT VO.* 
                                FROM VVOCE_GENERICA VO 
	                                JOIN VVOCE_X_CHECKLIST_GENERICA VXC ON VXC.ID_VOCE_GENERICA = VO.ID_VOCE_GENERICA 
                                WHERE 1 = 1  
	                                AND VXC.ID_CHECKLIST_GENERICA = @ID_CHECKLIST 
                                ORDER BY VXC.ORDINE ";

            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_CHECKLIST", id_checklist));

            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                var v = VoceGenericaDAL.GetFromDatareader(DbProviderObj);
                voci_coll.Add(v);
            }
            DbProviderObj.Close();

            return voci_coll;
        }

        public VoceGenericaCollection GetVociNotInIdChecklist(int id_checklist, string id_filtro)
        {
            var voci_coll = new VoceGenericaCollection();

            IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"SELECT VO.* 
                                FROM VVOCE_GENERICA VO 
                                WHERE 1 = 1 
                                    AND (@ID_FILTRO IS NULL OR VO.ID_FILTRO = @ID_FILTRO OR VO.ID_FILTRO = 'G') 
	                                AND VO.ID_VOCE_GENERICA NOT IN (SELECT ID_VOCE_GENERICA 
									                                FROM VVOCE_X_CHECKLIST_GENERICA  
									                                WHERE 1 = 1 
										                                AND ID_CHECKLIST_GENERICA = @ID_CHECKLIST) ";

            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_FILTRO", id_filtro));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_CHECKLIST", id_checklist));

            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                var v = VoceGenericaDAL.GetFromDatareader(DbProviderObj);
                voci_coll.Add(v);
            }
            DbProviderObj.Close();

            return voci_coll;
        }
    }
}
