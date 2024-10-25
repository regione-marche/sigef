using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{
    public partial class ProgettoSoggettoGestoreCollectionProvider : IProgettoSoggettoGestoreProvider
    {
        public ProgettoSoggettoGestoreCollection FindOperatoreCreazioneSoggettoGestore(int? IdOperatore, bool? BandiCovid)
        {
            ProgettoSoggettoGestoreCollection ProgettoSoggettoGestoreCollectionObj = new ProgettoSoggettoGestoreCollection();
            DbProvider db = DbProviderObj;
            IDbCommand cmd = db.GetCommand();
            ProgettoSoggettoGestore ProgettoSoggettoGestoreObj;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SpFindOperatoreCreazioneSoggettoGestore";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_OPERATORE", IdOperatore));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("BANDI_COVID", BandiCovid));
            db.InitDatareader(cmd);
            while (db.DataReader.Read())
            {
                ProgettoSoggettoGestoreObj = ProgettoSoggettoGestoreDAL.GetFromDatareader(db);
                ProgettoSoggettoGestoreObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ProgettoSoggettoGestoreObj.IsDirty = false;
                ProgettoSoggettoGestoreObj.IsPersistent = true;
                ProgettoSoggettoGestoreCollectionObj.Add(ProgettoSoggettoGestoreObj);
            }
            db.Close();
            return ProgettoSoggettoGestoreCollectionObj;
        }
    }
}
