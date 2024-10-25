using System;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for MandatiImpresaCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class MandatiImpresaCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private MandatiImpresaCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((MandatiImpresa) info.GetValue(i.ToString(),typeof(MandatiImpresa)));
			}
		}

		//Costruttore
		public MandatiImpresaCollection()
		{
			this.ItemType = typeof(MandatiImpresa);
		}

		//Costruttore con provider
		public MandatiImpresaCollection(IMandatiImpresaProvider providerObj)
		{
			this.ItemType = typeof(MandatiImpresa);
			this.Provider = providerObj;
		}

		//Get e Set
		public new MandatiImpresa this[int index]
		{
			get { return (MandatiImpresa)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new MandatiImpresaCollection GetChanges()
		{
			return (MandatiImpresaCollection) base.GetChanges();
		}

		[NonSerialized] private IMandatiImpresaProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IMandatiImpresaProvider Provider
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
		public int Add(MandatiImpresa MandatiImpresaObj)
		{
			if (MandatiImpresaObj.Provider == null) MandatiImpresaObj.Provider = this.Provider;
			return base.Add(MandatiImpresaObj);
		}

		//AddCollection
		public void AddCollection(MandatiImpresaCollection MandatiImpresaCollectionObj)
		{
			foreach (MandatiImpresa MandatiImpresaObj in MandatiImpresaCollectionObj)
				this.Add(MandatiImpresaObj);
		}

		//Insert
		public void Insert(int index, MandatiImpresa MandatiImpresaObj)
		{
			if (MandatiImpresaObj.Provider == null) MandatiImpresaObj.Provider = this.Provider;
			base.Insert(index, MandatiImpresaObj);
		}

		//CollectionGetById
		public MandatiImpresa CollectionGetById(NullTypes.IntNT IdValue)
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
		public MandatiImpresaCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.IntNT IdImpresaEqualThis, NullTypes.IntNT IdUtenteAbilitatoEqualThis, 
NullTypes.StringNT CodEnteEqualThis, NullTypes.StringNT CodiceSportelloCaaEqualThis, NullTypes.StringNT TipoMandatoEqualThis, 
NullTypes.BoolNT AttivoEqualThis, NullTypes.DatetimeNT DataInizioValiditaEqualThis, NullTypes.DatetimeNT DataFineValiditaEqualThis, 
NullTypes.IntNT IdOperatoreInizioEqualThis, NullTypes.IntNT IdOperatoreFineEqualThis, NullTypes.StringNT SegnaturaMandatoEqualThis, 
NullTypes.StringNT SegnaturaRevocaEqualThis)
		{
			MandatiImpresaCollection MandatiImpresaCollectionTemp = new MandatiImpresaCollection();
			foreach (MandatiImpresa MandatiImpresaItem in this)
			{
				if (((IdEqualThis == null) || ((MandatiImpresaItem.Id != null) && (MandatiImpresaItem.Id.Value == IdEqualThis.Value))) && ((IdImpresaEqualThis == null) || ((MandatiImpresaItem.IdImpresa != null) && (MandatiImpresaItem.IdImpresa.Value == IdImpresaEqualThis.Value))) && ((IdUtenteAbilitatoEqualThis == null) || ((MandatiImpresaItem.IdUtenteAbilitato != null) && (MandatiImpresaItem.IdUtenteAbilitato.Value == IdUtenteAbilitatoEqualThis.Value))) && 
((CodEnteEqualThis == null) || ((MandatiImpresaItem.CodEnte != null) && (MandatiImpresaItem.CodEnte.Value == CodEnteEqualThis.Value))) && ((CodiceSportelloCaaEqualThis == null) || ((MandatiImpresaItem.CodiceSportelloCaa != null) && (MandatiImpresaItem.CodiceSportelloCaa.Value == CodiceSportelloCaaEqualThis.Value))) && ((TipoMandatoEqualThis == null) || ((MandatiImpresaItem.TipoMandato != null) && (MandatiImpresaItem.TipoMandato.Value == TipoMandatoEqualThis.Value))) && 
((AttivoEqualThis == null) || ((MandatiImpresaItem.Attivo != null) && (MandatiImpresaItem.Attivo.Value == AttivoEqualThis.Value))) && ((DataInizioValiditaEqualThis == null) || ((MandatiImpresaItem.DataInizioValidita != null) && (MandatiImpresaItem.DataInizioValidita.Value == DataInizioValiditaEqualThis.Value))) && ((DataFineValiditaEqualThis == null) || ((MandatiImpresaItem.DataFineValidita != null) && (MandatiImpresaItem.DataFineValidita.Value == DataFineValiditaEqualThis.Value))) && 
((IdOperatoreInizioEqualThis == null) || ((MandatiImpresaItem.IdOperatoreInizio != null) && (MandatiImpresaItem.IdOperatoreInizio.Value == IdOperatoreInizioEqualThis.Value))) && ((IdOperatoreFineEqualThis == null) || ((MandatiImpresaItem.IdOperatoreFine != null) && (MandatiImpresaItem.IdOperatoreFine.Value == IdOperatoreFineEqualThis.Value))) && ((SegnaturaMandatoEqualThis == null) || ((MandatiImpresaItem.SegnaturaMandato != null) && (MandatiImpresaItem.SegnaturaMandato.Value == SegnaturaMandatoEqualThis.Value))) && 
((SegnaturaRevocaEqualThis == null) || ((MandatiImpresaItem.SegnaturaRevoca != null) && (MandatiImpresaItem.SegnaturaRevoca.Value == SegnaturaRevocaEqualThis.Value))))
				{
					MandatiImpresaCollectionTemp.Add(MandatiImpresaItem);
				}
			}
			return MandatiImpresaCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public MandatiImpresaCollection FiltroAttivoTipoMandato(NullTypes.BoolNT AttivoEqualThis, NullTypes.StringNT TipoMandatoEqualThis)
		{
			MandatiImpresaCollection MandatiImpresaCollectionTemp = new MandatiImpresaCollection();
			foreach (MandatiImpresa MandatiImpresaItem in this)
			{
				if (((AttivoEqualThis == null) || ((MandatiImpresaItem.Attivo != null) && (MandatiImpresaItem.Attivo.Value == AttivoEqualThis.Value))) && ((TipoMandatoEqualThis == null) || ((MandatiImpresaItem.TipoMandato != null) && (MandatiImpresaItem.TipoMandato.Value == TipoMandatoEqualThis.Value))))
				{
					MandatiImpresaCollectionTemp.Add(MandatiImpresaItem);
				}
			}
			return MandatiImpresaCollectionTemp;
		}



	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<MANDATI_IMPRESA>
  <ViewName>vMANDATI_IMPRESA</ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>False</chkDataModifica>
  <txtNomeCampoDataModifica>DATA_MODIFICA</txtNomeCampoDataModifica>
  <chkOptimisticCouncurrency>True</chkOptimisticCouncurrency>
  <chkShortNames>False</chkShortNames>
  <chkCase>False</chkCase>
  <chkCache>False</chkCache>
  <PLName>SiarPLL</PLName>
  <DALName>SiarDAL</DALName>
  <BLLName>SiarBLL</BLLName>
  <TypeNameSpaceName>SiarLibrary</TypeNameSpaceName>
  <Finds>
    <Find OrderBy="ORDER BY ATTIVO DESC, RAGIONE_SOCIALE">
      <ID_IMPRESA>Equal</ID_IMPRESA>
      <CUAA>Equal</CUAA>
      <CODICE_FISCALE>Equal</CODICE_FISCALE>
      <RAGIONE_SOCIALE>Like</RAGIONE_SOCIALE>
      <ID_UTENTE_ABILITATO>Equal</ID_UTENTE_ABILITATO>
      <COD_ENTE>Equal</COD_ENTE>
      <COD_TIPO_ENTE>Equal</COD_TIPO_ENTE>
      <TIPO_MANDATO>Equal</TIPO_MANDATO>
      <ATTIVO>Equal</ATTIVO>
    </Find>
  </Finds>
  <Filters>
    <FiltroAttivoTipoMandato>
      <ATTIVO>Equal</ATTIVO>
      <TIPO_MANDATO>Equal</TIPO_MANDATO>
    </FiltroAttivoTipoMandato>
  </Filters>
  <externalFields />
  <AddedFkFields />
</MANDATI_IMPRESA>
*/