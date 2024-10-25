using System;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for CollaboratoriXManifestazioneCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class CollaboratoriXManifestazioneCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private CollaboratoriXManifestazioneCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((CollaboratoriXManifestazione) info.GetValue(i.ToString(),typeof(CollaboratoriXManifestazione)));
			}
		}

		//Costruttore
		public CollaboratoriXManifestazioneCollection()
		{
			this.ItemType = typeof(CollaboratoriXManifestazione);
		}

		//Costruttore con provider
		public CollaboratoriXManifestazioneCollection(ICollaboratoriXManifestazioneProvider providerObj)
		{
			this.ItemType = typeof(CollaboratoriXManifestazione);
			this.Provider = providerObj;
		}

		//Get e Set
		public new CollaboratoriXManifestazione this[int index]
		{
			get { return (CollaboratoriXManifestazione)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new CollaboratoriXManifestazioneCollection GetChanges()
		{
			return (CollaboratoriXManifestazioneCollection) base.GetChanges();
		}

		[NonSerialized] private ICollaboratoriXManifestazioneProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ICollaboratoriXManifestazioneProvider Provider
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
		public int Add(CollaboratoriXManifestazione CollaboratoriXManifestazioneObj)
		{
			if (CollaboratoriXManifestazioneObj.Provider == null) CollaboratoriXManifestazioneObj.Provider = this.Provider;
			return base.Add(CollaboratoriXManifestazioneObj);
		}

		//AddCollection
		public void AddCollection(CollaboratoriXManifestazioneCollection CollaboratoriXManifestazioneCollectionObj)
		{
			foreach (CollaboratoriXManifestazione CollaboratoriXManifestazioneObj in CollaboratoriXManifestazioneCollectionObj)
				this.Add(CollaboratoriXManifestazioneObj);
		}

		//Insert
		public void Insert(int index, CollaboratoriXManifestazione CollaboratoriXManifestazioneObj)
		{
			if (CollaboratoriXManifestazioneObj.Provider == null) CollaboratoriXManifestazioneObj.Provider = this.Provider;
			base.Insert(index, CollaboratoriXManifestazioneObj);
		}

		//CollectionGetById
		public CollaboratoriXManifestazione CollectionGetById(NullTypes.IntNT IdCollaboratoreValue)
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
		public CollaboratoriXManifestazioneCollection SubSelect(NullTypes.IntNT IdCollaboratoreEqualThis, NullTypes.IntNT IdBandoEqualThis, NullTypes.IntNT IdManifestazioneEqualThis, 
NullTypes.StringNT CfUtenteEqualThis, NullTypes.StringNT OperatoreEqualThis, NullTypes.DatetimeNT DataInserimentoEqualThis)
		{
			CollaboratoriXManifestazioneCollection CollaboratoriXManifestazioneCollectionTemp = new CollaboratoriXManifestazioneCollection();
			foreach (CollaboratoriXManifestazione CollaboratoriXManifestazioneItem in this)
			{
				if (((IdCollaboratoreEqualThis == null) || ((CollaboratoriXManifestazioneItem.IdCollaboratore != null) && (CollaboratoriXManifestazioneItem.IdCollaboratore.Value == IdCollaboratoreEqualThis.Value))) && ((IdBandoEqualThis == null) || ((CollaboratoriXManifestazioneItem.IdBando != null) && (CollaboratoriXManifestazioneItem.IdBando.Value == IdBandoEqualThis.Value))) && ((IdManifestazioneEqualThis == null) || ((CollaboratoriXManifestazioneItem.IdManifestazione != null) && (CollaboratoriXManifestazioneItem.IdManifestazione.Value == IdManifestazioneEqualThis.Value))) && 
((CfUtenteEqualThis == null) || ((CollaboratoriXManifestazioneItem.CfUtente != null) && (CollaboratoriXManifestazioneItem.CfUtente.Value == CfUtenteEqualThis.Value))) && ((OperatoreEqualThis == null) || ((CollaboratoriXManifestazioneItem.Operatore != null) && (CollaboratoriXManifestazioneItem.Operatore.Value == OperatoreEqualThis.Value))) && ((DataInserimentoEqualThis == null) || ((CollaboratoriXManifestazioneItem.DataInserimento != null) && (CollaboratoriXManifestazioneItem.DataInserimento.Value == DataInserimentoEqualThis.Value))))
				{
					CollaboratoriXManifestazioneCollectionTemp.Add(CollaboratoriXManifestazioneItem);
				}
			}
			return CollaboratoriXManifestazioneCollectionTemp;
		}



	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<COLLABORATORI_X_MANIFESTAZIONE>
  <ViewName>vCOLLABORATORI_X_MANIFESTAZIONE</ViewName>
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
    <Find OrderBy="ORDER BY ">
      <ID_BANDO>Equal</ID_BANDO>
      <ID_MANIFESTAZIONE>Equal</ID_MANIFESTAZIONE>
      <CF_UTENTE>Equal</CF_UTENTE>
      <CUAA>Like</CUAA>
      <RAGIONE_SOCIALE>Like</RAGIONE_SOCIALE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</COLLABORATORI_X_MANIFESTAZIONE>
*/