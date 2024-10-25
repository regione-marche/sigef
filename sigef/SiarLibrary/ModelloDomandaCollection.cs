using System;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for ModelloDomandaCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class ModelloDomandaCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private ModelloDomandaCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((ModelloDomanda) info.GetValue(i.ToString(),typeof(ModelloDomanda)));
			}
		}

		//Costruttore
		public ModelloDomandaCollection()
		{
			this.ItemType = typeof(ModelloDomanda);
		}

		//Costruttore con provider
		public ModelloDomandaCollection(IModelloDomandaProvider providerObj)
		{
			this.ItemType = typeof(ModelloDomanda);
			this.Provider = providerObj;
		}

		//Get e Set
		public new ModelloDomanda this[int index]
		{
			get { return (ModelloDomanda)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new ModelloDomandaCollection GetChanges()
		{
			return (ModelloDomandaCollection) base.GetChanges();
		}

		[NonSerialized] private IModelloDomandaProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IModelloDomandaProvider Provider
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
		public int Add(ModelloDomanda ModelloDomandaObj)
		{
			if (ModelloDomandaObj.Provider == null) ModelloDomandaObj.Provider = this.Provider;
			return base.Add(ModelloDomandaObj);
		}

		//AddCollection
		public void AddCollection(ModelloDomandaCollection ModelloDomandaCollectionObj)
		{
			foreach (ModelloDomanda ModelloDomandaObj in ModelloDomandaCollectionObj)
				this.Add(ModelloDomandaObj);
		}

		//Insert
		public void Insert(int index, ModelloDomanda ModelloDomandaObj)
		{
			if (ModelloDomandaObj.Provider == null) ModelloDomandaObj.Provider = this.Provider;
			base.Insert(index, ModelloDomandaObj);
		}

		//CollectionGetById
		public ModelloDomanda CollectionGetById(NullTypes.IntNT IdDomandaValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdDomanda == IdDomandaValue))
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
		public ModelloDomandaCollection SubSelect(NullTypes.IntNT IdDomandaEqualThis, NullTypes.IntNT IdBandoEqualThis, NullTypes.BoolNT DefinitivoEqualThis, 
NullTypes.StringNT OperatoreEqualThis, NullTypes.StringNT DenominazioneEqualThis, NullTypes.StringNT DescrizioneEqualThis)
		{
			ModelloDomandaCollection ModelloDomandaCollectionTemp = new ModelloDomandaCollection();
			foreach (ModelloDomanda ModelloDomandaItem in this)
			{
				if (((IdDomandaEqualThis == null) || ((ModelloDomandaItem.IdDomanda != null) && (ModelloDomandaItem.IdDomanda.Value == IdDomandaEqualThis.Value))) && ((IdBandoEqualThis == null) || ((ModelloDomandaItem.IdBando != null) && (ModelloDomandaItem.IdBando.Value == IdBandoEqualThis.Value))) && ((DefinitivoEqualThis == null) || ((ModelloDomandaItem.Definitivo != null) && (ModelloDomandaItem.Definitivo.Value == DefinitivoEqualThis.Value))) && 
((OperatoreEqualThis == null) || ((ModelloDomandaItem.Operatore != null) && (ModelloDomandaItem.Operatore.Value == OperatoreEqualThis.Value))) && ((DenominazioneEqualThis == null) || ((ModelloDomandaItem.Denominazione != null) && (ModelloDomandaItem.Denominazione.Value == DenominazioneEqualThis.Value))) && ((DescrizioneEqualThis == null) || ((ModelloDomandaItem.Descrizione != null) && (ModelloDomandaItem.Descrizione.Value == DescrizioneEqualThis.Value))))
				{
					ModelloDomandaCollectionTemp.Add(ModelloDomandaItem);
				}
			}
			return ModelloDomandaCollectionTemp;
		}



	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<MODELLO_DOMANDA>
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
    <Find>
      <ID_DOMANDA>Equal</ID_DOMANDA>
      <ID_BANDO>Equal</ID_BANDO>
      <DEFINITIVO>Equal</DEFINITIVO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</MODELLO_DOMANDA>
*/