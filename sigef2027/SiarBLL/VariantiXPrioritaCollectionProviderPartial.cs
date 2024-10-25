using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{
	public partial class VariantiXPrioritaCollectionProvider : IVariantiXPrioritaProvider
	{
        public VariantiXPrioritaCollection GetVariantiPerPriorita(int id_variante)
        {
            VariantiXPrioritaCollection variantiXpriorita = new VariantiXPrioritaCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpGetVariantiPerPrioritaByVariante";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_VARIANTE", id_variante));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                VariantiXPriorita vp = SiarDAL.VariantiXPrioritaDAL.GetFromDatareader(DbProviderObj);
                vp.AdditionalAttributes.Add("ID_PRIORITA", new IntNT(DbProviderObj.DataReader["ID_PRIORITA"]));
                vp.AdditionalAttributes.Add("DESCRIZIONE", new StringNT(DbProviderObj.DataReader["DESCRIZIONE"]));
                variantiXpriorita.Add(vp);
            }
            DbProviderObj.Close();
            return variantiXpriorita;
        }
	}
}