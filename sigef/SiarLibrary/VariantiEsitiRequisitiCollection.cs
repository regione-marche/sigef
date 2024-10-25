using System;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for VariantiEsitiRequisitiCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class VariantiEsitiRequisitiCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private VariantiEsitiRequisitiCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((VariantiEsitiRequisiti) info.GetValue(i.ToString(),typeof(VariantiEsitiRequisiti)));
			}
		}

		//Costruttore
		public VariantiEsitiRequisitiCollection()
		{
			this.ItemType = typeof(VariantiEsitiRequisiti);
		}

		//Costruttore con provider
		public VariantiEsitiRequisitiCollection(IVariantiEsitiRequisitiProvider providerObj)
		{
			this.ItemType = typeof(VariantiEsitiRequisiti);
			this.Provider = providerObj;
		}

		//Get e Set
		public new VariantiEsitiRequisiti this[int index]
		{
			get { return (VariantiEsitiRequisiti)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new VariantiEsitiRequisitiCollection GetChanges()
		{
			return (VariantiEsitiRequisitiCollection) base.GetChanges();
		}

		[NonSerialized] private IVariantiEsitiRequisitiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IVariantiEsitiRequisitiProvider Provider
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
		public int Add(VariantiEsitiRequisiti VariantiEsitiRequisitiObj)
		{
			if (VariantiEsitiRequisitiObj.Provider == null) VariantiEsitiRequisitiObj.Provider = this.Provider;
			return base.Add(VariantiEsitiRequisitiObj);
		}

		//AddCollection
		public void AddCollection(VariantiEsitiRequisitiCollection VariantiEsitiRequisitiCollectionObj)
		{
			foreach (VariantiEsitiRequisiti VariantiEsitiRequisitiObj in VariantiEsitiRequisitiCollectionObj)
				this.Add(VariantiEsitiRequisitiObj);
		}

		//Insert
		public void Insert(int index, VariantiEsitiRequisiti VariantiEsitiRequisitiObj)
		{
			if (VariantiEsitiRequisitiObj.Provider == null) VariantiEsitiRequisitiObj.Provider = this.Provider;
			base.Insert(index, VariantiEsitiRequisitiObj);
		}

		//CollectionGetById
		public VariantiEsitiRequisiti CollectionGetById(NullTypes.IntNT IdVarianteValue, NullTypes.IntNT IdRequisitoValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdVariante == IdVarianteValue) && (this[i].IdRequisito == IdRequisitoValue))
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
		public VariantiEsitiRequisitiCollection SubSelect(NullTypes.IntNT IdVarianteEqualThis, NullTypes.IntNT IdRequisitoEqualThis, NullTypes.StringNT CodEsitoEqualThis, 
NullTypes.DatetimeNT DataEqualThis, NullTypes.StringNT CfOperatoreEqualThis, NullTypes.StringNT CodEsitoIstruttoreEqualThis, 
NullTypes.DatetimeNT DataValutazioneEqualThis, NullTypes.StringNT IstruttoreEqualThis, NullTypes.BoolNT EscludiDaComunicazioneEqualThis)
		{
			VariantiEsitiRequisitiCollection VariantiEsitiRequisitiCollectionTemp = new VariantiEsitiRequisitiCollection();
			foreach (VariantiEsitiRequisiti VariantiEsitiRequisitiItem in this)
			{
				if (((IdVarianteEqualThis == null) || ((VariantiEsitiRequisitiItem.IdVariante != null) && (VariantiEsitiRequisitiItem.IdVariante.Value == IdVarianteEqualThis.Value))) && ((IdRequisitoEqualThis == null) || ((VariantiEsitiRequisitiItem.IdRequisito != null) && (VariantiEsitiRequisitiItem.IdRequisito.Value == IdRequisitoEqualThis.Value))) && ((CodEsitoEqualThis == null) || ((VariantiEsitiRequisitiItem.CodEsito != null) && (VariantiEsitiRequisitiItem.CodEsito.Value == CodEsitoEqualThis.Value))) && 
((DataEqualThis == null) || ((VariantiEsitiRequisitiItem.Data != null) && (VariantiEsitiRequisitiItem.Data.Value == DataEqualThis.Value))) && ((CfOperatoreEqualThis == null) || ((VariantiEsitiRequisitiItem.CfOperatore != null) && (VariantiEsitiRequisitiItem.CfOperatore.Value == CfOperatoreEqualThis.Value))) && ((CodEsitoIstruttoreEqualThis == null) || ((VariantiEsitiRequisitiItem.CodEsitoIstruttore != null) && (VariantiEsitiRequisitiItem.CodEsitoIstruttore.Value == CodEsitoIstruttoreEqualThis.Value))) && 
((DataValutazioneEqualThis == null) || ((VariantiEsitiRequisitiItem.DataValutazione != null) && (VariantiEsitiRequisitiItem.DataValutazione.Value == DataValutazioneEqualThis.Value))) && ((IstruttoreEqualThis == null) || ((VariantiEsitiRequisitiItem.Istruttore != null) && (VariantiEsitiRequisitiItem.Istruttore.Value == IstruttoreEqualThis.Value))) && ((EscludiDaComunicazioneEqualThis == null) || ((VariantiEsitiRequisitiItem.EscludiDaComunicazione != null) && (VariantiEsitiRequisitiItem.EscludiDaComunicazione.Value == EscludiDaComunicazioneEqualThis.Value))))
				{
					VariantiEsitiRequisitiCollectionTemp.Add(VariantiEsitiRequisitiItem);
				}
			}
			return VariantiEsitiRequisitiCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public VariantiEsitiRequisitiCollection FiltroEsitoPositivo(NullTypes.BoolNT EsitoPositivoEqualThis, NullTypes.BoolNT EsitoPositivoIstruttoreEqualThis)
		{
			VariantiEsitiRequisitiCollection VariantiEsitiRequisitiCollectionTemp = new VariantiEsitiRequisitiCollection();
			foreach (VariantiEsitiRequisiti VariantiEsitiRequisitiItem in this)
			{
				if (((EsitoPositivoEqualThis == null) || ((VariantiEsitiRequisitiItem.EsitoPositivo != null) && (VariantiEsitiRequisitiItem.EsitoPositivo.Value == EsitoPositivoEqualThis.Value))) && ((EsitoPositivoIstruttoreEqualThis == null) || ((VariantiEsitiRequisitiItem.EsitoPositivoIstruttore != null) && (VariantiEsitiRequisitiItem.EsitoPositivoIstruttore.Value == EsitoPositivoIstruttoreEqualThis.Value))))
				{
					VariantiEsitiRequisitiCollectionTemp.Add(VariantiEsitiRequisitiItem);
				}
			}
			return VariantiEsitiRequisitiCollectionTemp;
		}



	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<VARIANTI_ESITI_REQUISITI>
  <ViewName>vVARIANTI_ESITI_REQUISITI</ViewName>
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
      <ID_VARIANTE>Equal</ID_VARIANTE>
      <ID_REQUISITO>Equal</ID_REQUISITO>
    </Find>
  </Finds>
  <Filters>
    <FiltroEsitoPositivo>
      <ESITO_POSITIVO>Equal</ESITO_POSITIVO>
      <ESITO_POSITIVO_ISTRUTTORE>Equal</ESITO_POSITIVO_ISTRUTTORE>
    </FiltroEsitoPositivo>
  </Filters>
  <externalFields />
  <AddedFkFields />
</VARIANTI_ESITI_REQUISITI>
*/