using System;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for DocumentiCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class DocumentiCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private DocumentiCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((Documenti) info.GetValue(i.ToString(),typeof(Documenti)));
			}
		}

		//Costruttore
		public DocumentiCollection()
		{
			this.ItemType = typeof(Documenti);
		}

		//Costruttore con provider
		public DocumentiCollection(IDocumentiProvider providerObj)
		{
			this.ItemType = typeof(Documenti);
			this.Provider = providerObj;
		}

		//Get e Set
		public new Documenti this[int index]
		{
			get { return (Documenti)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new DocumentiCollection GetChanges()
		{
			return (DocumentiCollection) base.GetChanges();
		}

		[NonSerialized] private IDocumentiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IDocumentiProvider Provider
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
		public int Add(Documenti DocumentiObj)
		{
			if (DocumentiObj.Provider == null) DocumentiObj.Provider = this.Provider;
			return base.Add(DocumentiObj);
		}

		//AddCollection
		public void AddCollection(DocumentiCollection DocumentiCollectionObj)
		{
			foreach (Documenti DocumentiObj in DocumentiCollectionObj)
				this.Add(DocumentiObj);
		}

		//Insert
		public void Insert(int index, Documenti DocumentiObj)
		{
			if (DocumentiObj.Provider == null) DocumentiObj.Provider = this.Provider;
			base.Insert(index, DocumentiObj);
		}

		//CollectionGetById
		public Documenti CollectionGetById(NullTypes.IntNT IdDocumentoValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdDocumento == IdDocumentoValue))
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
		public DocumentiCollection SubSelect(NullTypes.IntNT IdDocumentoEqualThis, NullTypes.StringNT TitoloEqualThis, NullTypes.StringNT DescrizioneEqualThis, 
NullTypes.DatetimeNT DataModificaEqualThis, NullTypes.StringNT OperatoreEqualThis, NullTypes.DatetimeNT DataFineValiditaEqualThis)
		{
			DocumentiCollection DocumentiCollectionTemp = new DocumentiCollection();
			foreach (Documenti DocumentiItem in this)
			{
				if (((IdDocumentoEqualThis == null) || ((DocumentiItem.IdDocumento != null) && (DocumentiItem.IdDocumento.Value == IdDocumentoEqualThis.Value))) && ((TitoloEqualThis == null) || ((DocumentiItem.Titolo != null) && (DocumentiItem.Titolo.Value == TitoloEqualThis.Value))) && ((DescrizioneEqualThis == null) || ((DocumentiItem.Descrizione != null) && (DocumentiItem.Descrizione.Value == DescrizioneEqualThis.Value))) && 
((DataModificaEqualThis == null) || ((DocumentiItem.DataModifica != null) && (DocumentiItem.DataModifica.Value == DataModificaEqualThis.Value))) && ((OperatoreEqualThis == null) || ((DocumentiItem.Operatore != null) && (DocumentiItem.Operatore.Value == OperatoreEqualThis.Value))) && ((DataFineValiditaEqualThis == null) || ((DocumentiItem.DataFineValidita != null) && (DocumentiItem.DataFineValidita.Value == DataFineValiditaEqualThis.Value))))
				{
					DocumentiCollectionTemp.Add(DocumentiItem);
				}
			}
			return DocumentiCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public DocumentiCollection FiltroDescrizione(NullTypes.StringNT TitoloLike, NullTypes.StringNT DescrizioneLike)
		{
			DocumentiCollection DocumentiCollectionTemp = new DocumentiCollection();
			foreach (Documenti DocumentiItem in this)
			{
				if (((TitoloLike == null) || ((DocumentiItem.Titolo !=null) &&(DocumentiItem.Titolo.Like(TitoloLike.Value)))) && ((DescrizioneLike == null) || ((DocumentiItem.Descrizione !=null) &&(DocumentiItem.Descrizione.Like(DescrizioneLike.Value)))))
				{
					DocumentiCollectionTemp.Add(DocumentiItem);
				}
			}
			return DocumentiCollectionTemp;
		}



	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<DOCUMENTI>
  <ViewName>
  </ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>False</chkDataModifica>
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
    <Find OrderBy="ORDER BY DATA_MODIFICA DESC">
      <TITOLO>Like</TITOLO>
      <DESCRIZIONE>Like</DESCRIZIONE>
      <DATA_FINE_VALIDITA>EqGreaterThan</DATA_FINE_VALIDITA>
    </Find>
  </Finds>
  <Filters>
    <FiltroDescrizione>
      <TITOLO>Like</TITOLO>
      <DESCRIZIONE>Like</DESCRIZIONE>
    </FiltroDescrizione>
  </Filters>
  <externalFields />
  <AddedFkFields />
</DOCUMENTI>
*/