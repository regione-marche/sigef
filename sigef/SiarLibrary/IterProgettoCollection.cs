using System;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for IterProgettoCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class IterProgettoCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private IterProgettoCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((IterProgetto) info.GetValue(i.ToString(),typeof(IterProgetto)));
			}
		}

		//Costruttore
		public IterProgettoCollection()
		{
			this.ItemType = typeof(IterProgetto);
		}

		//Costruttore con provider
		public IterProgettoCollection(IIterProgettoProvider providerObj)
		{
			this.ItemType = typeof(IterProgetto);
			this.Provider = providerObj;
		}

		//Get e Set
		public new IterProgetto this[int index]
		{
			get { return (IterProgetto)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new IterProgettoCollection GetChanges()
		{
			return (IterProgettoCollection) base.GetChanges();
		}

		[NonSerialized] private IIterProgettoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IIterProgettoProvider Provider
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
		public int Add(IterProgetto IterProgettoObj)
		{
			if (IterProgettoObj.Provider == null) IterProgettoObj.Provider = this.Provider;
			return base.Add(IterProgettoObj);
		}

		//AddCollection
		public void AddCollection(IterProgettoCollection IterProgettoCollectionObj)
		{
			foreach (IterProgetto IterProgettoObj in IterProgettoCollectionObj)
				this.Add(IterProgettoObj);
		}

		//Insert
		public void Insert(int index, IterProgetto IterProgettoObj)
		{
			if (IterProgettoObj.Provider == null) IterProgettoObj.Provider = this.Provider;
			base.Insert(index, IterProgettoObj);
		}

		//CollectionGetById
		public IterProgetto CollectionGetById(NullTypes.IntNT IdProgettoValue, NullTypes.IntNT IdStepValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdProgetto == IdProgettoValue) && (this[i].IdStep == IdStepValue))
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
		public IterProgettoCollection SubSelect(NullTypes.IntNT IdProgettoEqualThis, NullTypes.IntNT IdStepEqualThis, NullTypes.StringNT CodEsitoEqualThis, 
NullTypes.DatetimeNT DataEqualThis, NullTypes.StringNT CfOperatoreEqualThis, NullTypes.StringNT CodEsitoRevisoreEqualThis, 
NullTypes.DatetimeNT DataRevisoreEqualThis, NullTypes.StringNT RevisoreEqualThis)
		{
			IterProgettoCollection IterProgettoCollectionTemp = new IterProgettoCollection();
			foreach (IterProgetto IterProgettoItem in this)
			{
				if (((IdProgettoEqualThis == null) || ((IterProgettoItem.IdProgetto != null) && (IterProgettoItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((IdStepEqualThis == null) || ((IterProgettoItem.IdStep != null) && (IterProgettoItem.IdStep.Value == IdStepEqualThis.Value))) && ((CodEsitoEqualThis == null) || ((IterProgettoItem.CodEsito != null) && (IterProgettoItem.CodEsito.Value == CodEsitoEqualThis.Value))) && 
((DataEqualThis == null) || ((IterProgettoItem.Data != null) && (IterProgettoItem.Data.Value == DataEqualThis.Value))) && ((CfOperatoreEqualThis == null) || ((IterProgettoItem.CfOperatore != null) && (IterProgettoItem.CfOperatore.Value == CfOperatoreEqualThis.Value))) && ((CodEsitoRevisoreEqualThis == null) || ((IterProgettoItem.CodEsitoRevisore != null) && (IterProgettoItem.CodEsitoRevisore.Value == CodEsitoRevisoreEqualThis.Value))) && 
((DataRevisoreEqualThis == null) || ((IterProgettoItem.DataRevisore != null) && (IterProgettoItem.DataRevisore.Value == DataRevisoreEqualThis.Value))) && ((RevisoreEqualThis == null) || ((IterProgettoItem.Revisore != null) && (IterProgettoItem.Revisore.Value == RevisoreEqualThis.Value))))
				{
					IterProgettoCollectionTemp.Add(IterProgettoItem);
				}
			}
			return IterProgettoCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public IterProgettoCollection FiltroEsito(NullTypes.StringNT CodEsitoEqualThis, NullTypes.StringNT CodEsitoRevisoreEqualThis)
		{
			IterProgettoCollection IterProgettoCollectionTemp = new IterProgettoCollection();
			foreach (IterProgetto IterProgettoItem in this)
			{
				if (((CodEsitoEqualThis == null) || ((IterProgettoItem.CodEsito != null) && (IterProgettoItem.CodEsito.Value == CodEsitoEqualThis.Value))) && ((CodEsitoRevisoreEqualThis == null) || ((IterProgettoItem.CodEsitoRevisore != null) && (IterProgettoItem.CodEsitoRevisore.Value == CodEsitoRevisoreEqualThis.Value))))
				{
					IterProgettoCollectionTemp.Add(IterProgettoItem);
				}
			}
			return IterProgettoCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public IterProgettoCollection FiltroEsitoPositivo(NullTypes.BoolNT EsitoPositivoIstruttoreEqualThis, NullTypes.BoolNT EsitoPositivoRevisoreEqualThis)
		{
			IterProgettoCollection IterProgettoCollectionTemp = new IterProgettoCollection();
			foreach (IterProgetto IterProgettoItem in this)
			{
				if (((EsitoPositivoIstruttoreEqualThis == null) || ((IterProgettoItem.EsitoPositivoIstruttore != null) && (IterProgettoItem.EsitoPositivoIstruttore.Value == EsitoPositivoIstruttoreEqualThis.Value))) && ((EsitoPositivoRevisoreEqualThis == null) || ((IterProgettoItem.EsitoPositivoRevisore != null) && (IterProgettoItem.EsitoPositivoRevisore.Value == EsitoPositivoRevisoreEqualThis.Value))))
				{
					IterProgettoCollectionTemp.Add(IterProgettoItem);
				}
			}
			return IterProgettoCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public IterProgettoCollection FiltroNonInRevisione(NullTypes.BoolNT CodEsitoRevisoreIsNull)
		{
			IterProgettoCollection IterProgettoCollectionTemp = new IterProgettoCollection();
			foreach (IterProgetto IterProgettoItem in this)
			{
				if (((CodEsitoRevisoreIsNull == null) || ((IterProgettoItem.CodEsitoRevisore == null) ==  CodEsitoRevisoreIsNull.Value)))
				{
					IterProgettoCollectionTemp.Add(IterProgettoItem);
				}
			}
			return IterProgettoCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public IterProgettoCollection FiltroAutomatico(NullTypes.BoolNT AutomaticoEqualThis)
		{
			IterProgettoCollection IterProgettoCollectionTemp = new IterProgettoCollection();
			foreach (IterProgetto IterProgettoItem in this)
			{
				if (((AutomaticoEqualThis == null) || ((IterProgettoItem.Automatico != null) && (IterProgettoItem.Automatico.Value == AutomaticoEqualThis.Value))))
				{
					IterProgettoCollectionTemp.Add(IterProgettoItem);
				}
			}
			return IterProgettoCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public IterProgettoCollection FiltroObbligatorio(NullTypes.BoolNT ObbligatorioEqualThis)
		{
			IterProgettoCollection IterProgettoCollectionTemp = new IterProgettoCollection();
			foreach (IterProgetto IterProgettoItem in this)
			{
				if (((ObbligatorioEqualThis == null) || ((IterProgettoItem.Obbligatorio != null) && (IterProgettoItem.Obbligatorio.Value == ObbligatorioEqualThis.Value))))
				{
					IterProgettoCollectionTemp.Add(IterProgettoItem);
				}
			}
			return IterProgettoCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public IterProgettoCollection FiltroMisura(NullTypes.StringNT MisuraEqualThis)
		{
			IterProgettoCollection IterProgettoCollectionTemp = new IterProgettoCollection();
			foreach (IterProgetto IterProgettoItem in this)
			{
				if (((MisuraEqualThis == null) || ((IterProgettoItem.Misura != null) && (IterProgettoItem.Misura.Value == MisuraEqualThis.Value))))
				{
					IterProgettoCollectionTemp.Add(IterProgettoItem);
				}
			}
			return IterProgettoCollectionTemp;
		}



	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<ITER_PROGETTO>
  <ViewName>vITER_PROGETTO</ViewName>
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
    <Find OrderBy="ORDER BY ORDINE">
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_STEP>Equal</ID_STEP>
      <COD_ESITO>Equal</COD_ESITO>
      <COD_ESITO_REVISORE>Equal</COD_ESITO_REVISORE>
      <ID_BANDO>Equal</ID_BANDO>
      <COD_FASE>Equal</COD_FASE>
      <ID_CHECK_LIST>Equal</ID_CHECK_LIST>
    </Find>
  </Finds>
  <Filters>
    <FiltroEsito>
      <COD_ESITO>Equal</COD_ESITO>
      <COD_ESITO_REVISORE>Equal</COD_ESITO_REVISORE>
    </FiltroEsito>
    <FiltroEsitoPositivo>
      <ESITO_POSITIVO_ISTRUTTORE>Equal</ESITO_POSITIVO_ISTRUTTORE>
      <ESITO_POSITIVO_REVISORE>Equal</ESITO_POSITIVO_REVISORE>
    </FiltroEsitoPositivo>
    <FiltroNonInRevisione>
      <COD_ESITO_REVISORE>IsNull</COD_ESITO_REVISORE>
    </FiltroNonInRevisione>
    <FiltroAutomatico>
      <AUTOMATICO>Equal</AUTOMATICO>
    </FiltroAutomatico>
    <FiltroObbligatorio>
      <OBBLIGATORIO>Equal</OBBLIGATORIO>
    </FiltroObbligatorio>
    <FiltroMisura>
      <MISURA>Equal</MISURA>
    </FiltroMisura>
  </Filters>
  <externalFields />
  <AddedFkFields />
</ITER_PROGETTO>
*/