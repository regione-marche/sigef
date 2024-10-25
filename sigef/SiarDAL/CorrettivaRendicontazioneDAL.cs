using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;

namespace SiarDAL
{

	/// <summary>
	/// Summary description for CorrettivaRendicontazioneDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	public class CorrettivaRendicontazioneDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, CorrettivaRendicontazione CorrettivaRendicontazioneObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", CorrettivaRendicontazioneObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdDomandaPagamento", CorrettivaRendicontazioneObj.IdDomandaPagamento);
			DbProvider.SetCmdParam(cmd,firstChar + "Conclusa", CorrettivaRendicontazioneObj.Conclusa);
			DbProvider.SetCmdParam(cmd,firstChar + "Annullata", CorrettivaRendicontazioneObj.Annullata);
			DbProvider.SetCmdParam(cmd,firstChar + "IdUtente", CorrettivaRendicontazioneObj.IdUtente);
			DbProvider.SetCmdParam(cmd,firstChar + "Data", CorrettivaRendicontazioneObj.Data);
			DbProvider.SetCmdParam(cmd,firstChar + "IdNote", CorrettivaRendicontazioneObj.IdNote);
		}
		//Insert
		private static int Insert(DbProvider db, CorrettivaRendicontazione CorrettivaRendicontazioneObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZCorrettivaRendicontazioneInsert", new string[] {"IdDomandaPagamento", "Conclusa", 
"Annullata", "IdUtente", "Data", 
"IdNote", }, new string[] {"int", "bool", 
"bool", "int", "DateTime", 
"int", },"");
				CompileIUCmd(false, insertCmd,CorrettivaRendicontazioneObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				CorrettivaRendicontazioneObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				CorrettivaRendicontazioneObj.Conclusa = new SiarLibrary.NullTypes.BoolNT(db.DataReader["CONCLUSA"]);
				CorrettivaRendicontazioneObj.Annullata = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ANNULLATA"]);
				}
				CorrettivaRendicontazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CorrettivaRendicontazioneObj.IsDirty = false;
				CorrettivaRendicontazioneObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, CorrettivaRendicontazione CorrettivaRendicontazioneObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZCorrettivaRendicontazioneUpdate", new string[] {"Id", "IdDomandaPagamento", "Conclusa", 
"Annullata", "IdUtente", "Data", 
"IdNote", }, new string[] {"int", "int", "bool", 
"bool", "int", "DateTime", 
"int", },"");
				CompileIUCmd(true, updateCmd,CorrettivaRendicontazioneObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				CorrettivaRendicontazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CorrettivaRendicontazioneObj.IsDirty = false;
				CorrettivaRendicontazioneObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, CorrettivaRendicontazione CorrettivaRendicontazioneObj)
		{
			switch (CorrettivaRendicontazioneObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, CorrettivaRendicontazioneObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, CorrettivaRendicontazioneObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,CorrettivaRendicontazioneObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, CorrettivaRendicontazioneCollection CorrettivaRendicontazioneCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZCorrettivaRendicontazioneUpdate", new string[] {"Id", "IdDomandaPagamento", "Conclusa", 
"Annullata", "IdUtente", "Data", 
"IdNote", }, new string[] {"int", "int", "bool", 
"bool", "int", "DateTime", 
"int", },"");
				IDbCommand insertCmd = db.InitCmd( "ZCorrettivaRendicontazioneInsert", new string[] {"IdDomandaPagamento", "Conclusa", 
"Annullata", "IdUtente", "Data", 
"IdNote", }, new string[] {"int", "bool", 
"bool", "int", "DateTime", 
"int", },"");
				IDbCommand deleteCmd = db.InitCmd( "ZCorrettivaRendicontazioneDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < CorrettivaRendicontazioneCollectionObj.Count; i++)
				{
					switch (CorrettivaRendicontazioneCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,CorrettivaRendicontazioneCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									CorrettivaRendicontazioneCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
									CorrettivaRendicontazioneCollectionObj[i].Conclusa = new SiarLibrary.NullTypes.BoolNT(db.DataReader["CONCLUSA"]);
									CorrettivaRendicontazioneCollectionObj[i].Annullata = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ANNULLATA"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,CorrettivaRendicontazioneCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (CorrettivaRendicontazioneCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)CorrettivaRendicontazioneCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < CorrettivaRendicontazioneCollectionObj.Count; i++)
				{
					if ((CorrettivaRendicontazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CorrettivaRendicontazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						CorrettivaRendicontazioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						CorrettivaRendicontazioneCollectionObj[i].IsDirty = false;
						CorrettivaRendicontazioneCollectionObj[i].IsPersistent = true;
					}
					if ((CorrettivaRendicontazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						CorrettivaRendicontazioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						CorrettivaRendicontazioneCollectionObj[i].IsDirty = false;
						CorrettivaRendicontazioneCollectionObj[i].IsPersistent = false;
					}
				}
			}
			catch 
			{
				db.Rollback();
				throw;
			}
			finally
			{
				db.Close();
			}
			return returnValue;
		}

		//Delete
		public static int Delete(DbProvider db, CorrettivaRendicontazione CorrettivaRendicontazioneObj)
		{
			int returnValue = 0;
			if (CorrettivaRendicontazioneObj.IsPersistent) 
			{
				returnValue = Delete(db, CorrettivaRendicontazioneObj.Id);
			}
			CorrettivaRendicontazioneObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			CorrettivaRendicontazioneObj.IsDirty = false;
			CorrettivaRendicontazioneObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZCorrettivaRendicontazioneDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, CorrettivaRendicontazioneCollection CorrettivaRendicontazioneCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZCorrettivaRendicontazioneDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < CorrettivaRendicontazioneCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", CorrettivaRendicontazioneCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < CorrettivaRendicontazioneCollectionObj.Count; i++)
				{
					if ((CorrettivaRendicontazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CorrettivaRendicontazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						CorrettivaRendicontazioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						CorrettivaRendicontazioneCollectionObj[i].IsDirty = false;
						CorrettivaRendicontazioneCollectionObj[i].IsPersistent = false;
					}
				}
			}
			catch 
			{
				db.Rollback();
				throw;
			}
			finally
			{
				db.Close();
			}
			return returnValue;
		}

		//getById
		public static CorrettivaRendicontazione GetById(DbProvider db, int IdValue)
		{
			CorrettivaRendicontazione CorrettivaRendicontazioneObj = null;
			IDbCommand readCmd = db.InitCmd( "ZCorrettivaRendicontazioneGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				CorrettivaRendicontazioneObj = GetFromDatareader(db);
				CorrettivaRendicontazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CorrettivaRendicontazioneObj.IsDirty = false;
				CorrettivaRendicontazioneObj.IsPersistent = true;
			}
			db.Close();
			return CorrettivaRendicontazioneObj;
		}

		//getFromDatareader
		public static CorrettivaRendicontazione GetFromDatareader(DbProvider db)
		{
			CorrettivaRendicontazione CorrettivaRendicontazioneObj = new CorrettivaRendicontazione();
			CorrettivaRendicontazioneObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			CorrettivaRendicontazioneObj.IdDomandaPagamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA_PAGAMENTO"]);
			CorrettivaRendicontazioneObj.Conclusa = new SiarLibrary.NullTypes.BoolNT(db.DataReader["CONCLUSA"]);
			CorrettivaRendicontazioneObj.Annullata = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ANNULLATA"]);
			CorrettivaRendicontazioneObj.IdUtente = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_UTENTE"]);
			CorrettivaRendicontazioneObj.Data = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA"]);
			CorrettivaRendicontazioneObj.IdNote = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_NOTE"]);
			CorrettivaRendicontazioneObj.Note = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOTE"]);
			CorrettivaRendicontazioneObj.Nominativo = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOMINATIVO"]);
			CorrettivaRendicontazioneObj.CodEnte = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_ENTE"]);
			CorrettivaRendicontazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			CorrettivaRendicontazioneObj.IsDirty = false;
			CorrettivaRendicontazioneObj.IsPersistent = true;
			return CorrettivaRendicontazioneObj;
		}

		//Find Select

		public static CorrettivaRendicontazioneCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.BoolNT ConclusaEqualThis, 
SiarLibrary.NullTypes.BoolNT AnnullataEqualThis, SiarLibrary.NullTypes.IntNT IdUtenteEqualThis, SiarLibrary.NullTypes.DatetimeNT DataEqualThis, 
SiarLibrary.NullTypes.IntNT IdNoteEqualThis)

		{

			CorrettivaRendicontazioneCollection CorrettivaRendicontazioneCollectionObj = new CorrettivaRendicontazioneCollection();

			IDbCommand findCmd = db.InitCmd("Zcorrettivarendicontazionefindselect", new string[] {"Idequalthis", "IdDomandaPagamentoequalthis", "Conclusaequalthis", 
"Annullataequalthis", "IdUtenteequalthis", "Dataequalthis", 
"IdNoteequalthis"}, new string[] {"int", "int", "bool", 
"bool", "int", "DateTime", 
"int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Conclusaequalthis", ConclusaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Annullataequalthis", AnnullataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdUtenteequalthis", IdUtenteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Dataequalthis", DataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdNoteequalthis", IdNoteEqualThis);
			CorrettivaRendicontazione CorrettivaRendicontazioneObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				CorrettivaRendicontazioneObj = GetFromDatareader(db);
				CorrettivaRendicontazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CorrettivaRendicontazioneObj.IsDirty = false;
				CorrettivaRendicontazioneObj.IsPersistent = true;
				CorrettivaRendicontazioneCollectionObj.Add(CorrettivaRendicontazioneObj);
			}
			db.Close();
			return CorrettivaRendicontazioneCollectionObj;
		}

		//Find Find

		public static CorrettivaRendicontazioneCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.BoolNT AnnullataEqualThis, SiarLibrary.NullTypes.BoolNT ConclusaEqualThis)

		{

			CorrettivaRendicontazioneCollection CorrettivaRendicontazioneCollectionObj = new CorrettivaRendicontazioneCollection();

			IDbCommand findCmd = db.InitCmd("Zcorrettivarendicontazionefindfind", new string[] {"IdDomandaPagamentoequalthis", "Annullataequalthis", "Conclusaequalthis"}, new string[] {"int", "bool", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Annullataequalthis", AnnullataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Conclusaequalthis", ConclusaEqualThis);
			CorrettivaRendicontazione CorrettivaRendicontazioneObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				CorrettivaRendicontazioneObj = GetFromDatareader(db);
				CorrettivaRendicontazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CorrettivaRendicontazioneObj.IsDirty = false;
				CorrettivaRendicontazioneObj.IsPersistent = true;
				CorrettivaRendicontazioneCollectionObj.Add(CorrettivaRendicontazioneObj);
			}
			db.Close();
			return CorrettivaRendicontazioneCollectionObj;
		}

	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<CORRETTIVA_RENDICONTAZIONE>
  <ViewName>vCORRETTIVA_RENDICONTAZIONE</ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>True</chkDataModifica>
  <txtNomeCampoDataModifica>DATA_MODIFICA</txtNomeCampoDataModifica>
  <chkOptimisticCouncurrency>False</chkOptimisticCouncurrency>
  <chkShortNames>False</chkShortNames>
  <chkCase>False</chkCase>
  <chkCache>False</chkCache>
  <PLName>SiarPLL</PLName>
  <DALName>SiarDAL</DALName>
  <BLLName>SiarBLL</BLLName>
  <TypeNameSpaceName>SiarLibrary</TypeNameSpaceName>
  <Finds>
    <Find OrderBy="ORDER BY ID">
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
      <ANNULLATA>Equal</ANNULLATA>
      <CONCLUSA>Equal</CONCLUSA>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</CORRETTIVA_RENDICONTAZIONE>
*/