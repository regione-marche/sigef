using System;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for CorrettivaRendicontazioneCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class CorrettivaRendicontazioneCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private CorrettivaRendicontazioneCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((CorrettivaRendicontazione) info.GetValue(i.ToString(),typeof(CorrettivaRendicontazione)));
			}
		}

		//Costruttore
		public CorrettivaRendicontazioneCollection()
		{
			this.ItemType = typeof(CorrettivaRendicontazione);
		}

		//Costruttore con provider
		public CorrettivaRendicontazioneCollection(ICorrettivaRendicontazioneProvider providerObj)
		{
			this.ItemType = typeof(CorrettivaRendicontazione);
			this.Provider = providerObj;
		}

		//Get e Set
		public new CorrettivaRendicontazione this[int index]
		{
			get { return (CorrettivaRendicontazione)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new CorrettivaRendicontazioneCollection GetChanges()
		{
			return (CorrettivaRendicontazioneCollection) base.GetChanges();
		}

		[NonSerialized] private ICorrettivaRendicontazioneProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ICorrettivaRendicontazioneProvider Provider
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
		public int Add(CorrettivaRendicontazione CorrettivaRendicontazioneObj)
		{
			if (CorrettivaRendicontazioneObj.Provider == null) CorrettivaRendicontazioneObj.Provider = this.Provider;
			return base.Add(CorrettivaRendicontazioneObj);
		}

		//AddCollection
		public void AddCollection(CorrettivaRendicontazioneCollection CorrettivaRendicontazioneCollectionObj)
		{
			foreach (CorrettivaRendicontazione CorrettivaRendicontazioneObj in CorrettivaRendicontazioneCollectionObj)
				this.Add(CorrettivaRendicontazioneObj);
		}

		//Insert
		public void Insert(int index, CorrettivaRendicontazione CorrettivaRendicontazioneObj)
		{
			if (CorrettivaRendicontazioneObj.Provider == null) CorrettivaRendicontazioneObj.Provider = this.Provider;
			base.Insert(index, CorrettivaRendicontazioneObj);
		}

		//CollectionGetById
		public CorrettivaRendicontazione CollectionGetById(NullTypes.IntNT IdValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].Id == IdValue))
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
		public CorrettivaRendicontazioneCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.IntNT IdDomandaPagamentoEqualThis, NullTypes.BoolNT ConclusaEqualThis, 
NullTypes.BoolNT AnnullataEqualThis, NullTypes.IntNT IdUtenteEqualThis, NullTypes.DatetimeNT DataEqualThis, 
NullTypes.IntNT IdNoteEqualThis)
		{
			CorrettivaRendicontazioneCollection CorrettivaRendicontazioneCollectionTemp = new CorrettivaRendicontazioneCollection();
			foreach (CorrettivaRendicontazione CorrettivaRendicontazioneItem in this)
			{
				if (((IdEqualThis == null) || ((CorrettivaRendicontazioneItem.Id != null) && (CorrettivaRendicontazioneItem.Id.Value == IdEqualThis.Value))) && ((IdDomandaPagamentoEqualThis == null) || ((CorrettivaRendicontazioneItem.IdDomandaPagamento != null) && (CorrettivaRendicontazioneItem.IdDomandaPagamento.Value == IdDomandaPagamentoEqualThis.Value))) && ((ConclusaEqualThis == null) || ((CorrettivaRendicontazioneItem.Conclusa != null) && (CorrettivaRendicontazioneItem.Conclusa.Value == ConclusaEqualThis.Value))) && 
((AnnullataEqualThis == null) || ((CorrettivaRendicontazioneItem.Annullata != null) && (CorrettivaRendicontazioneItem.Annullata.Value == AnnullataEqualThis.Value))) && ((IdUtenteEqualThis == null) || ((CorrettivaRendicontazioneItem.IdUtente != null) && (CorrettivaRendicontazioneItem.IdUtente.Value == IdUtenteEqualThis.Value))) && ((DataEqualThis == null) || ((CorrettivaRendicontazioneItem.Data != null) && (CorrettivaRendicontazioneItem.Data.Value == DataEqualThis.Value))) && 
((IdNoteEqualThis == null) || ((CorrettivaRendicontazioneItem.IdNote != null) && (CorrettivaRendicontazioneItem.IdNote.Value == IdNoteEqualThis.Value))))
				{
					CorrettivaRendicontazioneCollectionTemp.Add(CorrettivaRendicontazioneItem);
				}
			}
			return CorrettivaRendicontazioneCollectionTemp;
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