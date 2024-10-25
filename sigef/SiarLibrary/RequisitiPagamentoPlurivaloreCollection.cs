using System;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for RequisitiPagamentoPlurivaloreCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class RequisitiPagamentoPlurivaloreCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private RequisitiPagamentoPlurivaloreCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((RequisitiPagamentoPlurivalore) info.GetValue(i.ToString(),typeof(RequisitiPagamentoPlurivalore)));
			}
		}

		//Costruttore
		public RequisitiPagamentoPlurivaloreCollection()
		{
			this.ItemType = typeof(RequisitiPagamentoPlurivalore);
		}

		//Costruttore con provider
		public RequisitiPagamentoPlurivaloreCollection(IRequisitiPagamentoPlurivaloreProvider providerObj)
		{
			this.ItemType = typeof(RequisitiPagamentoPlurivalore);
			this.Provider = providerObj;
		}

		//Get e Set
		public new RequisitiPagamentoPlurivalore this[int index]
		{
			get { return (RequisitiPagamentoPlurivalore)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new RequisitiPagamentoPlurivaloreCollection GetChanges()
		{
			return (RequisitiPagamentoPlurivaloreCollection) base.GetChanges();
		}

		[NonSerialized] private IRequisitiPagamentoPlurivaloreProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IRequisitiPagamentoPlurivaloreProvider Provider
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
		public int Add(RequisitiPagamentoPlurivalore RequisitiPagamentoPlurivaloreObj)
		{
			if (RequisitiPagamentoPlurivaloreObj.Provider == null) RequisitiPagamentoPlurivaloreObj.Provider = this.Provider;
			return base.Add(RequisitiPagamentoPlurivaloreObj);
		}

		//AddCollection
		public void AddCollection(RequisitiPagamentoPlurivaloreCollection RequisitiPagamentoPlurivaloreCollectionObj)
		{
			foreach (RequisitiPagamentoPlurivalore RequisitiPagamentoPlurivaloreObj in RequisitiPagamentoPlurivaloreCollectionObj)
				this.Add(RequisitiPagamentoPlurivaloreObj);
		}

		//Insert
		public void Insert(int index, RequisitiPagamentoPlurivalore RequisitiPagamentoPlurivaloreObj)
		{
			if (RequisitiPagamentoPlurivaloreObj.Provider == null) RequisitiPagamentoPlurivaloreObj.Provider = this.Provider;
			base.Insert(index, RequisitiPagamentoPlurivaloreObj);
		}

		//CollectionGetById
		public RequisitiPagamentoPlurivalore CollectionGetById(NullTypes.IntNT IdValoreValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdValore == IdValoreValue))
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
		public RequisitiPagamentoPlurivaloreCollection SubSelect(NullTypes.IntNT IdValoreEqualThis, NullTypes.IntNT IdRequisitoEqualThis, NullTypes.StringNT CodiceEqualThis, 
NullTypes.StringNT DescrizioneEqualThis)
		{
			RequisitiPagamentoPlurivaloreCollection RequisitiPagamentoPlurivaloreCollectionTemp = new RequisitiPagamentoPlurivaloreCollection();
			foreach (RequisitiPagamentoPlurivalore RequisitiPagamentoPlurivaloreItem in this)
			{
				if (((IdValoreEqualThis == null) || ((RequisitiPagamentoPlurivaloreItem.IdValore != null) && (RequisitiPagamentoPlurivaloreItem.IdValore.Value == IdValoreEqualThis.Value))) && ((IdRequisitoEqualThis == null) || ((RequisitiPagamentoPlurivaloreItem.IdRequisito != null) && (RequisitiPagamentoPlurivaloreItem.IdRequisito.Value == IdRequisitoEqualThis.Value))) && ((CodiceEqualThis == null) || ((RequisitiPagamentoPlurivaloreItem.Codice != null) && (RequisitiPagamentoPlurivaloreItem.Codice.Value == CodiceEqualThis.Value))) && 
((DescrizioneEqualThis == null) || ((RequisitiPagamentoPlurivaloreItem.Descrizione != null) && (RequisitiPagamentoPlurivaloreItem.Descrizione.Value == DescrizioneEqualThis.Value))))
				{
					RequisitiPagamentoPlurivaloreCollectionTemp.Add(RequisitiPagamentoPlurivaloreItem);
				}
			}
			return RequisitiPagamentoPlurivaloreCollectionTemp;
		}



	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<REQUISITI_PAGAMENTO_PLURIVALORE>
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
    <Find OrderBy="ORDER BY CODICE">
      <ID_VALORE>Equal</ID_VALORE>
      <ID_REQUISITO>Equal</ID_REQUISITO>
      <CODICE>Equal</CODICE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</REQUISITI_PAGAMENTO_PLURIVALORE>
*/