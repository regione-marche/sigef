using System;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for CorrettivaRendicontazioneSpostamentiCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class CorrettivaRendicontazioneSpostamentiCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private CorrettivaRendicontazioneSpostamentiCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((CorrettivaRendicontazioneSpostamenti) info.GetValue(i.ToString(),typeof(CorrettivaRendicontazioneSpostamenti)));
			}
		}

		//Costruttore
		public CorrettivaRendicontazioneSpostamentiCollection()
		{
			this.ItemType = typeof(CorrettivaRendicontazioneSpostamenti);
		}

		//Costruttore con provider
		public CorrettivaRendicontazioneSpostamentiCollection(ICorrettivaRendicontazioneSpostamentiProvider providerObj)
		{
			this.ItemType = typeof(CorrettivaRendicontazioneSpostamenti);
			this.Provider = providerObj;
		}

		//Get e Set
		public new CorrettivaRendicontazioneSpostamenti this[int index]
		{
			get { return (CorrettivaRendicontazioneSpostamenti)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new CorrettivaRendicontazioneSpostamentiCollection GetChanges()
		{
			return (CorrettivaRendicontazioneSpostamentiCollection) base.GetChanges();
		}

		[NonSerialized] private ICorrettivaRendicontazioneSpostamentiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ICorrettivaRendicontazioneSpostamentiProvider Provider
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
		public int Add(CorrettivaRendicontazioneSpostamenti CorrettivaRendicontazioneSpostamentiObj)
		{
			if (CorrettivaRendicontazioneSpostamentiObj.Provider == null) CorrettivaRendicontazioneSpostamentiObj.Provider = this.Provider;
			return base.Add(CorrettivaRendicontazioneSpostamentiObj);
		}

		//AddCollection
		public void AddCollection(CorrettivaRendicontazioneSpostamentiCollection CorrettivaRendicontazioneSpostamentiCollectionObj)
		{
			foreach (CorrettivaRendicontazioneSpostamenti CorrettivaRendicontazioneSpostamentiObj in CorrettivaRendicontazioneSpostamentiCollectionObj)
				this.Add(CorrettivaRendicontazioneSpostamentiObj);
		}

		//Insert
		public void Insert(int index, CorrettivaRendicontazioneSpostamenti CorrettivaRendicontazioneSpostamentiObj)
		{
			if (CorrettivaRendicontazioneSpostamentiObj.Provider == null) CorrettivaRendicontazioneSpostamentiObj.Provider = this.Provider;
			base.Insert(index, CorrettivaRendicontazioneSpostamentiObj);
		}

		//CollectionGetById
		public CorrettivaRendicontazioneSpostamenti CollectionGetById(NullTypes.IntNT IdValue)
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
		public CorrettivaRendicontazioneSpostamentiCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.IntNT IdCorrettivaEqualThis, NullTypes.IntNT IdInvestimentoDaEqualThis, 
NullTypes.IntNT IdInvestimentoAEqualThis, NullTypes.DecimalNT ImportoSpostatoEqualThis, NullTypes.BoolNT ConclusoEqualThis, 
NullTypes.BoolNT AnnullatoEqualThis, NullTypes.IntNT IdUtenteEqualThis, NullTypes.DatetimeNT DataEqualThis, 
NullTypes.StringNT DescrizioneEqualThis, NullTypes.IntNT IdJsonLogEqualThis)
		{
			CorrettivaRendicontazioneSpostamentiCollection CorrettivaRendicontazioneSpostamentiCollectionTemp = new CorrettivaRendicontazioneSpostamentiCollection();
			foreach (CorrettivaRendicontazioneSpostamenti CorrettivaRendicontazioneSpostamentiItem in this)
			{
				if (((IdEqualThis == null) || ((CorrettivaRendicontazioneSpostamentiItem.Id != null) && (CorrettivaRendicontazioneSpostamentiItem.Id.Value == IdEqualThis.Value))) && ((IdCorrettivaEqualThis == null) || ((CorrettivaRendicontazioneSpostamentiItem.IdCorrettiva != null) && (CorrettivaRendicontazioneSpostamentiItem.IdCorrettiva.Value == IdCorrettivaEqualThis.Value))) && ((IdInvestimentoDaEqualThis == null) || ((CorrettivaRendicontazioneSpostamentiItem.IdInvestimentoDa != null) && (CorrettivaRendicontazioneSpostamentiItem.IdInvestimentoDa.Value == IdInvestimentoDaEqualThis.Value))) && 
((IdInvestimentoAEqualThis == null) || ((CorrettivaRendicontazioneSpostamentiItem.IdInvestimentoA != null) && (CorrettivaRendicontazioneSpostamentiItem.IdInvestimentoA.Value == IdInvestimentoAEqualThis.Value))) && ((ImportoSpostatoEqualThis == null) || ((CorrettivaRendicontazioneSpostamentiItem.ImportoSpostato != null) && (CorrettivaRendicontazioneSpostamentiItem.ImportoSpostato.Value == ImportoSpostatoEqualThis.Value))) && ((ConclusoEqualThis == null) || ((CorrettivaRendicontazioneSpostamentiItem.Concluso != null) && (CorrettivaRendicontazioneSpostamentiItem.Concluso.Value == ConclusoEqualThis.Value))) && 
((AnnullatoEqualThis == null) || ((CorrettivaRendicontazioneSpostamentiItem.Annullato != null) && (CorrettivaRendicontazioneSpostamentiItem.Annullato.Value == AnnullatoEqualThis.Value))) && ((IdUtenteEqualThis == null) || ((CorrettivaRendicontazioneSpostamentiItem.IdUtente != null) && (CorrettivaRendicontazioneSpostamentiItem.IdUtente.Value == IdUtenteEqualThis.Value))) && ((DataEqualThis == null) || ((CorrettivaRendicontazioneSpostamentiItem.Data != null) && (CorrettivaRendicontazioneSpostamentiItem.Data.Value == DataEqualThis.Value))) && 
((DescrizioneEqualThis == null) || ((CorrettivaRendicontazioneSpostamentiItem.Descrizione != null) && (CorrettivaRendicontazioneSpostamentiItem.Descrizione.Value == DescrizioneEqualThis.Value))) && ((IdJsonLogEqualThis == null) || ((CorrettivaRendicontazioneSpostamentiItem.IdJsonLog != null) && (CorrettivaRendicontazioneSpostamentiItem.IdJsonLog.Value == IdJsonLogEqualThis.Value))))
				{
					CorrettivaRendicontazioneSpostamentiCollectionTemp.Add(CorrettivaRendicontazioneSpostamentiItem);
				}
			}
			return CorrettivaRendicontazioneSpostamentiCollectionTemp;
		}



	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<CORRETTIVA_RENDICONTAZIONE_SPOSTAMENTI>
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
    <Find OrderBy="ORDER BY ID">
      <ID_CORRETTIVA>Equal</ID_CORRETTIVA>
      <ID_INVESTIMENTO_DA>Equal</ID_INVESTIMENTO_DA>
      <ID_INVESTIMENTO_A>Equal</ID_INVESTIMENTO_A>
      <CONCLUSO>Equal</CONCLUSO>
      <ANNULLATO>Equal</ANNULLATO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</CORRETTIVA_RENDICONTAZIONE_SPOSTAMENTI>
*/