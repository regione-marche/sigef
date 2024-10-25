using System;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for PartecipantiXFilieraCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class PartecipantiXFilieraCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private PartecipantiXFilieraCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((PartecipantiXFiliera) info.GetValue(i.ToString(),typeof(PartecipantiXFiliera)));
			}
		}

		//Costruttore
		public PartecipantiXFilieraCollection()
		{
			this.ItemType = typeof(PartecipantiXFiliera);
		}

		//Costruttore con provider
		public PartecipantiXFilieraCollection(IPartecipantiXFilieraProvider providerObj)
		{
			this.ItemType = typeof(PartecipantiXFiliera);
			this.Provider = providerObj;
		}

		//Get e Set
		public new PartecipantiXFiliera this[int index]
		{
			get { return (PartecipantiXFiliera)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new PartecipantiXFilieraCollection GetChanges()
		{
			return (PartecipantiXFilieraCollection) base.GetChanges();
		}

		[NonSerialized] private IPartecipantiXFilieraProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IPartecipantiXFilieraProvider Provider
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
		public int Add(PartecipantiXFiliera PartecipantiXFilieraObj)
		{
			if (PartecipantiXFilieraObj.Provider == null) PartecipantiXFilieraObj.Provider = this.Provider;
			return base.Add(PartecipantiXFilieraObj);
		}

		//AddCollection
		public void AddCollection(PartecipantiXFilieraCollection PartecipantiXFilieraCollectionObj)
		{
			foreach (PartecipantiXFiliera PartecipantiXFilieraObj in PartecipantiXFilieraCollectionObj)
				this.Add(PartecipantiXFilieraObj);
		}

		//Insert
		public void Insert(int index, PartecipantiXFiliera PartecipantiXFilieraObj)
		{
			if (PartecipantiXFilieraObj.Provider == null) PartecipantiXFilieraObj.Provider = this.Provider;
			base.Insert(index, PartecipantiXFilieraObj);
		}

		//CollectionGetById
		public PartecipantiXFiliera CollectionGetById(NullTypes.IntNT IdPartecipanteValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdPartecipante == IdPartecipanteValue))
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
		public PartecipantiXFilieraCollection SubSelect(NullTypes.IntNT IdPartecipanteEqualThis, NullTypes.StringNT CodFilieraEqualThis, NullTypes.StringNT CuaaEqualThis, 
NullTypes.IntNT IdProgettoValidatoEqualThis, NullTypes.StringNT CodRuoloSitraEqualThis, NullTypes.BoolNT AmmessoEqualThis, 
NullTypes.DatetimeNT DataValidazioneEqualThis, NullTypes.StringNT CfOperatoreEqualThis)
		{
			PartecipantiXFilieraCollection PartecipantiXFilieraCollectionTemp = new PartecipantiXFilieraCollection();
			foreach (PartecipantiXFiliera PartecipantiXFilieraItem in this)
			{
				if (((IdPartecipanteEqualThis == null) || ((PartecipantiXFilieraItem.IdPartecipante != null) && (PartecipantiXFilieraItem.IdPartecipante.Value == IdPartecipanteEqualThis.Value))) && ((CodFilieraEqualThis == null) || ((PartecipantiXFilieraItem.CodFiliera != null) && (PartecipantiXFilieraItem.CodFiliera.Value == CodFilieraEqualThis.Value))) && ((CuaaEqualThis == null) || ((PartecipantiXFilieraItem.Cuaa != null) && (PartecipantiXFilieraItem.Cuaa.Value == CuaaEqualThis.Value))) && 
((IdProgettoValidatoEqualThis == null) || ((PartecipantiXFilieraItem.IdProgettoValidato != null) && (PartecipantiXFilieraItem.IdProgettoValidato.Value == IdProgettoValidatoEqualThis.Value))) && ((CodRuoloSitraEqualThis == null) || ((PartecipantiXFilieraItem.CodRuoloSitra != null) && (PartecipantiXFilieraItem.CodRuoloSitra.Value == CodRuoloSitraEqualThis.Value))) && ((AmmessoEqualThis == null) || ((PartecipantiXFilieraItem.Ammesso != null) && (PartecipantiXFilieraItem.Ammesso.Value == AmmessoEqualThis.Value))) && 
((DataValidazioneEqualThis == null) || ((PartecipantiXFilieraItem.DataValidazione != null) && (PartecipantiXFilieraItem.DataValidazione.Value == DataValidazioneEqualThis.Value))) && ((CfOperatoreEqualThis == null) || ((PartecipantiXFilieraItem.CfOperatore != null) && (PartecipantiXFilieraItem.CfOperatore.Value == CfOperatoreEqualThis.Value))))
				{
					PartecipantiXFilieraCollectionTemp.Add(PartecipantiXFilieraItem);
				}
			}
			return PartecipantiXFilieraCollectionTemp;
		}



	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<PARTECIPANTI_X_FILIERA>
  <ViewName>
  </ViewName>
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
      <ID_PARTECIPANTE>Equal</ID_PARTECIPANTE>
      <COD_FILIERA>Equal</COD_FILIERA>
      <CUAA>Equal</CUAA>
      <ID_PROGETTO_VALIDATO>Equal</ID_PROGETTO_VALIDATO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</PARTECIPANTI_X_FILIERA>
*/