using System;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for LocalizzazioneInvestimentoCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class LocalizzazioneInvestimentoCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private LocalizzazioneInvestimentoCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((LocalizzazioneInvestimento) info.GetValue(i.ToString(),typeof(LocalizzazioneInvestimento)));
			}
		}

		//Costruttore
		public LocalizzazioneInvestimentoCollection()
		{
			this.ItemType = typeof(LocalizzazioneInvestimento);
		}

		//Costruttore con provider
		public LocalizzazioneInvestimentoCollection(ILocalizzazioneInvestimentoProvider providerObj)
		{
			this.ItemType = typeof(LocalizzazioneInvestimento);
			this.Provider = providerObj;
		}

		//Get e Set
		public new LocalizzazioneInvestimento this[int index]
		{
			get { return (LocalizzazioneInvestimento)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new LocalizzazioneInvestimentoCollection GetChanges()
		{
			return (LocalizzazioneInvestimentoCollection) base.GetChanges();
		}

		[NonSerialized] private ILocalizzazioneInvestimentoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ILocalizzazioneInvestimentoProvider Provider
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
		public int Add(LocalizzazioneInvestimento LocalizzazioneInvestimentoObj)
		{
			if (LocalizzazioneInvestimentoObj.Provider == null) LocalizzazioneInvestimentoObj.Provider = this.Provider;
			return base.Add(LocalizzazioneInvestimentoObj);
		}

		//AddCollection
		public void AddCollection(LocalizzazioneInvestimentoCollection LocalizzazioneInvestimentoCollectionObj)
		{
			foreach (LocalizzazioneInvestimento LocalizzazioneInvestimentoObj in LocalizzazioneInvestimentoCollectionObj)
				this.Add(LocalizzazioneInvestimentoObj);
		}

		//Insert
		public void Insert(int index, LocalizzazioneInvestimento LocalizzazioneInvestimentoObj)
		{
			if (LocalizzazioneInvestimentoObj.Provider == null) LocalizzazioneInvestimentoObj.Provider = this.Provider;
			base.Insert(index, LocalizzazioneInvestimentoObj);
		}

		//CollectionGetById
		public LocalizzazioneInvestimento CollectionGetById(NullTypes.IntNT IdLocalizzazioneValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdLocalizzazione == IdLocalizzazioneValue))
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
		public LocalizzazioneInvestimentoCollection SubSelect(NullTypes.IntNT IdLocalizzazioneEqualThis, NullTypes.IntNT IdInvestimentoEqualThis, NullTypes.IntNT IdCatastoEqualThis)
		{
			LocalizzazioneInvestimentoCollection LocalizzazioneInvestimentoCollectionTemp = new LocalizzazioneInvestimentoCollection();
			foreach (LocalizzazioneInvestimento LocalizzazioneInvestimentoItem in this)
			{
				if (((IdLocalizzazioneEqualThis == null) || ((LocalizzazioneInvestimentoItem.IdLocalizzazione != null) && (LocalizzazioneInvestimentoItem.IdLocalizzazione.Value == IdLocalizzazioneEqualThis.Value))) && ((IdInvestimentoEqualThis == null) || ((LocalizzazioneInvestimentoItem.IdInvestimento != null) && (LocalizzazioneInvestimentoItem.IdInvestimento.Value == IdInvestimentoEqualThis.Value))) && ((IdCatastoEqualThis == null) || ((LocalizzazioneInvestimentoItem.IdCatasto != null) && (LocalizzazioneInvestimentoItem.IdCatasto.Value == IdCatastoEqualThis.Value))))
				{
					LocalizzazioneInvestimentoCollectionTemp.Add(LocalizzazioneInvestimentoItem);
				}
			}
			return LocalizzazioneInvestimentoCollectionTemp;
		}



	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<LOCALIZZAZIONE_INVESTIMENTO>
  <ViewName>vLOCALIZZAZIONE_INVESTIMENTO</ViewName>
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
      <ID_LOCALIZZAZIONE>Equal</ID_LOCALIZZAZIONE>
      <ID_INVESTIMENTO>Equal</ID_INVESTIMENTO>
      <ID_CATASTO>Equal</ID_CATASTO>
      <ID_COMUNE>Equal</ID_COMUNE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</LOCALIZZAZIONE_INVESTIMENTO>
*/