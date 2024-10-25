using System;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for NewsCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class NewsCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private NewsCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((News) info.GetValue(i.ToString(),typeof(News)));
			}
		}

		//Costruttore
		public NewsCollection()
		{
			this.ItemType = typeof(News);
		}

		//Costruttore con provider
		public NewsCollection(INewsProvider providerObj)
		{
			this.ItemType = typeof(News);
			this.Provider = providerObj;
		}

		//Get e Set
		public new News this[int index]
		{
			get { return (News)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new NewsCollection GetChanges()
		{
			return (NewsCollection) base.GetChanges();
		}

		[NonSerialized] private INewsProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public INewsProvider Provider
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
		public int Add(News NewsObj)
		{
			if (NewsObj.Provider == null) NewsObj.Provider = this.Provider;
			return base.Add(NewsObj);
		}

		//AddCollection
		public void AddCollection(NewsCollection NewsCollectionObj)
		{
			foreach (News NewsObj in NewsCollectionObj)
				this.Add(NewsObj);
		}

		//Insert
		public void Insert(int index, News NewsObj)
		{
			if (NewsObj.Provider == null) NewsObj.Provider = this.Provider;
			base.Insert(index, NewsObj);
		}

		//CollectionGetById
		public News CollectionGetById(NullTypes.IntNT IdNewsValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdNews == IdNewsValue))
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
		public NewsCollection SubSelect(NullTypes.IntNT IdNewsEqualThis, NullTypes.StringNT TitoloEqualThis, NullTypes.StringNT TestoEqualThis, 
NullTypes.StringNT UrlEqualThis, NullTypes.DatetimeNT DataEqualThis, NullTypes.StringNT OperatoreEqualThis, 
NullTypes.BoolNT InterruzioneSistemaEqualThis, NullTypes.DatetimeNT DataInizioEqualThis, NullTypes.DatetimeNT DataFineEqualThis)
		{
			NewsCollection NewsCollectionTemp = new NewsCollection();
			foreach (News NewsItem in this)
			{
				if (((IdNewsEqualThis == null) || ((NewsItem.IdNews != null) && (NewsItem.IdNews.Value == IdNewsEqualThis.Value))) && ((TitoloEqualThis == null) || ((NewsItem.Titolo != null) && (NewsItem.Titolo.Value == TitoloEqualThis.Value))) && ((TestoEqualThis == null) || ((NewsItem.Testo != null) && (NewsItem.Testo.Value == TestoEqualThis.Value))) && 
((UrlEqualThis == null) || ((NewsItem.Url != null) && (NewsItem.Url.Value == UrlEqualThis.Value))) && ((DataEqualThis == null) || ((NewsItem.Data != null) && (NewsItem.Data.Value == DataEqualThis.Value))) && ((OperatoreEqualThis == null) || ((NewsItem.Operatore != null) && (NewsItem.Operatore.Value == OperatoreEqualThis.Value))) && 
((InterruzioneSistemaEqualThis == null) || ((NewsItem.InterruzioneSistema != null) && (NewsItem.InterruzioneSistema.Value == InterruzioneSistemaEqualThis.Value))) && ((DataInizioEqualThis == null) || ((NewsItem.DataInizio != null) && (NewsItem.DataInizio.Value == DataInizioEqualThis.Value))) && ((DataFineEqualThis == null) || ((NewsItem.DataFine != null) && (NewsItem.DataFine.Value == DataFineEqualThis.Value))))
				{
					NewsCollectionTemp.Add(NewsItem);
				}
			}
			return NewsCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public NewsCollection FiltroInterruzioneDiSistema(NullTypes.BoolNT InterruzioneSistemaEqualThis, NullTypes.DatetimeNT DataInizioEqLessThanThis, NullTypes.DatetimeNT DataFineEqGreaterThanThis)
		{
			NewsCollection NewsCollectionTemp = new NewsCollection();
			foreach (News NewsItem in this)
			{
				if (((InterruzioneSistemaEqualThis == null) || ((NewsItem.InterruzioneSistema != null) && (NewsItem.InterruzioneSistema.Value == InterruzioneSistemaEqualThis.Value))) && ((DataInizioEqLessThanThis == null) || ((NewsItem.DataInizio != null) && (NewsItem.DataInizio.Value <= DataInizioEqLessThanThis.Value))) && ((DataFineEqGreaterThanThis == null) || ((NewsItem.DataFine != null) && (NewsItem.DataFine.Value >= DataFineEqGreaterThanThis.Value))))
				{
					NewsCollectionTemp.Add(NewsItem);
				}
			}
			return NewsCollectionTemp;
		}



	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<NEWS>
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
    <Find OrderBy="ORDER BY DATA DESC">
      <TITOLO>Like</TITOLO>
      <TESTO>Like</TESTO>
      <INTERRUZIONE_SISTEMA>Equal</INTERRUZIONE_SISTEMA>
    </Find>
  </Finds>
  <Filters>
    <FiltroInterruzioneDiSistema>
      <INTERRUZIONE_SISTEMA>Equal</INTERRUZIONE_SISTEMA>
      <DATA_INIZIO>EqLessThan</DATA_INIZIO>
      <DATA_FINE>EqGreaterThan</DATA_FINE>
    </FiltroInterruzioneDiSistema>
  </Filters>
  <externalFields />
  <AddedFkFields />
</NEWS>
*/