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
        //Metodo lasciato senza distinzione con il POC per la ricerca dei progetti durante l'import dei contratti
        // e per progetti Confidi
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

        public ProgettoSoggettoGestoreCollection FindOperatoreCreazioneSoggettoGestoreNonPoc(int? IdOperatore, bool? BandiCovid)
        {
            ProgettoSoggettoGestoreCollection ProgettoSoggettoGestoreCollectionObj = new ProgettoSoggettoGestoreCollection();
            DbProvider db = DbProviderObj;
            IDbCommand cmd = db.GetCommand();
            ProgettoSoggettoGestore ProgettoSoggettoGestoreObj;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SpFindOperatoreCreazioneSoggettoGestoreNonPoc";
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

        public ProgettoSoggettoGestoreCollection FindOperatoreCreazioneSoggettoGestoreFondiPoc(int? IdOperatore)
        {
            ProgettoSoggettoGestoreCollection ProgettoSoggettoGestoreCollectionObj = new ProgettoSoggettoGestoreCollection();
            DbProvider db = DbProviderObj;
            IDbCommand cmd = db.GetCommand();
            ProgettoSoggettoGestore ProgettoSoggettoGestoreObj;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SpFindOperatoreCreazioneSoggettoGestoreFondiPoc";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_OPERATORE", IdOperatore));
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
