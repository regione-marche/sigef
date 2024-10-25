using System;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for CollaboratoriXBandoCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class CollaboratoriXBandoCollection : CustomCollection, System.Runtime.Serialization.ISerializable
	{

		//Serializzazione xml
		public void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
		{
			info.AddValue("_count",this.Count);
			for(int i=0;i<this.Count;i++)
			{
				info.AddValue(i.ToString(),this[i]);
			}
		}
		private CollaboratoriXBandoCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((CollaboratoriXBando) info.GetValue(i.ToString(),typeof(CollaboratoriXBando)));
			}
		}

		//Costruttore
		public CollaboratoriXBandoCollection()
		{
			this.ItemType = typeof(CollaboratoriXBando);
		}

		//Costruttore con provider
		public CollaboratoriXBandoCollection(ICollaboratoriXBandoProvider providerObj)
		{
			this.ItemType = typeof(CollaboratoriXBando);
			this.Provider = providerObj;
		}

		//Get e Set
		public new CollaboratoriXBando this[int index]
		{
			get { return (CollaboratoriXBando)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new CollaboratoriXBandoCollection GetChanges()
		{
			return (CollaboratoriXBandoCollection) base.GetChanges();
		}

		[NonSerialized] private ICollaboratoriXBandoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ICollaboratoriXBandoProvider Provider
		{
			get {return _provider;}
			set 
			{ 
				_provider = value;
				for (int i = 0; i < this.Count; i++)
				{
					this[i].Provider = value;
				}
			} 
		}

		public int SaveCollection()
		{
			return _provider.SaveCollection(this);
		}
		public int DeleteCollection()
		{
			return _provider.DeleteCollection(this);
		}
		//Add
		public int Add(CollaboratoriXBando CollaboratoriXBandoObj)
		{
			if (CollaboratoriXBandoObj.Provider == null) CollaboratoriXBandoObj.Provider = this.Provider;
			return base.Add(CollaboratoriXBandoObj);
		}

		//AddCollection
		public void AddCollection(CollaboratoriXBandoCollection CollaboratoriXBandoCollectionObj)
		{
			foreach (CollaboratoriXBando CollaboratoriXBandoObj in CollaboratoriXBandoCollectionObj)
				this.Add(CollaboratoriXBandoObj);
		}

		//Insert
		public void Insert(int index, CollaboratoriXBando CollaboratoriXBandoObj)
		{
			if (CollaboratoriXBandoObj.Provider == null) CollaboratoriXBandoObj.Provider = this.Provider;
			base.Insert(index, CollaboratoriXBandoObj);
		}

		//CollectionGetById
		public CollaboratoriXBando CollectionGetById(NullTypes.IntNT IdCollaboratoreValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdCollaboratore == IdCollaboratoreValue))
					find = true;
				else
					i++;
			}
			if (find)
				return this[i];
			else
				return null;
		}
		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public CollaboratoriXBandoCollection SubSelect(NullTypes.IntNT IdCollaboratoreEqualThis, NullTypes.IntNT IdBandoEqualThis, NullTypes.IntNT IdProgettoEqualThis, 
NullTypes.IntNT IdUtenteEqualThis, NullTypes.StringNT ProvinciaEqualThis, NullTypes.IntNT OperatoreInserimentoEqualThis, 
NullTypes.DatetimeNT DataInserimentoEqualThis, NullTypes.IntNT OperatoreFineValiditaEqualThis, NullTypes.DatetimeNT DataFineValiditaEqualThis, 
NullTypes.BoolNT AttivoEqualThis)
		{
			CollaboratoriXBandoCollection CollaboratoriXBandoCollectionTemp = new CollaboratoriXBandoCollection();
			foreach (CollaboratoriXBando CollaboratoriXBandoItem in this)
			{
				if (((IdCollaboratoreEqualThis == null) || ((CollaboratoriXBandoItem.IdCollaboratore != null) && (CollaboratoriXBandoItem.IdCollaboratore.Value == IdCollaboratoreEqualThis.Value))) && ((IdBandoEqualThis == null) || ((CollaboratoriXBandoItem.IdBando != null) && (CollaboratoriXBandoItem.IdBando.Value == IdBandoEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((CollaboratoriXBandoItem.IdProgetto != null) && (CollaboratoriXBandoItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && 
((IdUtenteEqualThis == null) || ((CollaboratoriXBandoItem.IdUtente != null) && (CollaboratoriXBandoItem.IdUtente.Value == IdUtenteEqualThis.Value))) && ((ProvinciaEqualThis == null) || ((CollaboratoriXBandoItem.Provincia != null) && (CollaboratoriXBandoItem.Provincia.Value == ProvinciaEqualThis.Value))) && ((OperatoreInserimentoEqualThis == null) || ((CollaboratoriXBandoItem.OperatoreInserimento != null) && (CollaboratoriXBandoItem.OperatoreInserimento.Value == OperatoreInserimentoEqualThis.Value))) && 
((DataInserimentoEqualThis == null) || ((CollaboratoriXBandoItem.DataInserimento != null) && (CollaboratoriXBandoItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) && ((OperatoreFineValiditaEqualThis == null) || ((CollaboratoriXBandoItem.OperatoreFineValidita != null) && (CollaboratoriXBandoItem.OperatoreFineValidita.Value == OperatoreFineValiditaEqualThis.Value))) && ((DataFineValiditaEqualThis == null) || ((CollaboratoriXBandoItem.DataFineValidita != null) && (CollaboratoriXBandoItem.DataFineValidita.Value == DataFineValiditaEqualThis.Value))) && 
((AttivoEqualThis == null) || ((CollaboratoriXBandoItem.Attivo != null) && (CollaboratoriXBandoItem.Attivo.Value == AttivoEqualThis.Value))))
				{
					CollaboratoriXBandoCollectionTemp.Add(CollaboratoriXBandoItem);
				}
			}
			return CollaboratoriXBandoCollectionTemp;
		}



	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<COLLABORATORI_X_BANDO>
  <ViewName>vCOLLABORATORI_X_BANDO</ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>False</chkDataModifica>
  <txtNomeCampoDataModifica>DATA</txtNomeCampoDataModifica>
  <chkOptimisticCouncurrency>False</chkOptimisticCouncurrency>
  <chkShortNames>False</chkShortNames>
  <chkCase>False</chkCase>
  <chkCache>False</chkCache>
  <PLName>SiarPLL</PLName>
  <DALName>SiarDAL</DALName>
  <BLLName>SiarBLL</BLLName>
  <TypeNameSpaceName>SiarLibrary</TypeNameSpaceName>
  <Finds>
    <Find OrderBy="ORDER BY ID_PROGETTO">
      <ID_BANDO>Equal</ID_BANDO>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_UTENTE>Equal</ID_UTENTE>
      <PROVINCIA>Equal</PROVINCIA>
      <ATTIVO>Equal</ATTIVO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</COLLABORATORI_X_BANDO>
*/