using System;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for VistruttoriaDomandeCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class VistruttoriaDomandeCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private VistruttoriaDomandeCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((VistruttoriaDomande) info.GetValue(i.ToString(),typeof(VistruttoriaDomande)));
			}
		}

		//Costruttore
		public VistruttoriaDomandeCollection()
		{
			this.ItemType = typeof(VistruttoriaDomande);
		}

		//Get e Set
		public new VistruttoriaDomande this[int index]
		{
			get { return (VistruttoriaDomande)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new VistruttoriaDomandeCollection GetChanges()
		{
			return (VistruttoriaDomandeCollection) base.GetChanges();
		}

		//Add
		public int Add(VistruttoriaDomande VistruttoriaDomandeObj)
		{
			return base.Add(VistruttoriaDomandeObj);
		}

		//AddCollection
		public void AddCollection(VistruttoriaDomandeCollection VistruttoriaDomandeCollectionObj)
		{
			foreach (VistruttoriaDomande VistruttoriaDomandeObj in VistruttoriaDomandeCollectionObj)
				this.Add(VistruttoriaDomandeObj);
		}

		//Insert
		public void Insert(int index, VistruttoriaDomande VistruttoriaDomandeObj)
		{
			base.Insert(index, VistruttoriaDomandeObj);
		}

		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public VistruttoriaDomandeCollection SubSelect(NullTypes.IntNT IdProgettoEqualThis, NullTypes.IntNT IdBandoEqualThis, NullTypes.IntNT IdProgIntegratoEqualThis, 
NullTypes.StringNT CodStatoEqualThis, NullTypes.StringNT StatoEqualThis, NullTypes.StringNT CuaaEqualThis, 
NullTypes.StringNT PartitaIvaEqualThis, NullTypes.StringNT RagioneSocialeEqualThis, NullTypes.StringNT ComuneEqualThis, 
NullTypes.StringNT SiglaEqualThis, NullTypes.StringNT CapEqualThis, NullTypes.StringNT IstruttoreEqualThis, 
NullTypes.StringNT ProvinciaAssegnazioneEqualThis, NullTypes.BoolNT SelezionataXRevisioneEqualThis, NullTypes.StringNT ProvinciaDiPresentazioneEqualThis, 
NullTypes.IntNT IdIstruttoreEqualThis, NullTypes.StringNT ViaEqualThis, NullTypes.StringNT SegnaturaRiEqualThis, 
NullTypes.StringNT FiltroStatoIstruttoriaEqualThis, NullTypes.IntNT OrdineStatoEqualThis, NullTypes.IntNT IdImpresaEqualThis)
		{
			VistruttoriaDomandeCollection VistruttoriaDomandeCollectionTemp = new VistruttoriaDomandeCollection();
			foreach (VistruttoriaDomande VistruttoriaDomandeItem in this)
			{
				if (((IdProgettoEqualThis == null) || ((VistruttoriaDomandeItem.IdProgetto != null) && (VistruttoriaDomandeItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((IdBandoEqualThis == null) || ((VistruttoriaDomandeItem.IdBando != null) && (VistruttoriaDomandeItem.IdBando.Value == IdBandoEqualThis.Value))) && ((IdProgIntegratoEqualThis == null) || ((VistruttoriaDomandeItem.IdProgIntegrato != null) && (VistruttoriaDomandeItem.IdProgIntegrato.Value == IdProgIntegratoEqualThis.Value))) && 
((CodStatoEqualThis == null) || ((VistruttoriaDomandeItem.CodStato != null) && (VistruttoriaDomandeItem.CodStato.Value == CodStatoEqualThis.Value))) && ((StatoEqualThis == null) || ((VistruttoriaDomandeItem.Stato != null) && (VistruttoriaDomandeItem.Stato.Value == StatoEqualThis.Value))) && ((CuaaEqualThis == null) || ((VistruttoriaDomandeItem.Cuaa != null) && (VistruttoriaDomandeItem.Cuaa.Value == CuaaEqualThis.Value))) && 
((PartitaIvaEqualThis == null) || ((VistruttoriaDomandeItem.PartitaIva != null) && (VistruttoriaDomandeItem.PartitaIva.Value == PartitaIvaEqualThis.Value))) && ((RagioneSocialeEqualThis == null) || ((VistruttoriaDomandeItem.RagioneSociale != null) && (VistruttoriaDomandeItem.RagioneSociale.Value == RagioneSocialeEqualThis.Value))) && ((ComuneEqualThis == null) || ((VistruttoriaDomandeItem.Comune != null) && (VistruttoriaDomandeItem.Comune.Value == ComuneEqualThis.Value))) && 
((SiglaEqualThis == null) || ((VistruttoriaDomandeItem.Sigla != null) && (VistruttoriaDomandeItem.Sigla.Value == SiglaEqualThis.Value))) && ((CapEqualThis == null) || ((VistruttoriaDomandeItem.Cap != null) && (VistruttoriaDomandeItem.Cap.Value == CapEqualThis.Value))) && ((IstruttoreEqualThis == null) || ((VistruttoriaDomandeItem.Istruttore != null) && (VistruttoriaDomandeItem.Istruttore.Value == IstruttoreEqualThis.Value))) && 
((ProvinciaAssegnazioneEqualThis == null) || ((VistruttoriaDomandeItem.ProvinciaAssegnazione != null) && (VistruttoriaDomandeItem.ProvinciaAssegnazione.Value == ProvinciaAssegnazioneEqualThis.Value))) && ((SelezionataXRevisioneEqualThis == null) || ((VistruttoriaDomandeItem.SelezionataXRevisione != null) && (VistruttoriaDomandeItem.SelezionataXRevisione.Value == SelezionataXRevisioneEqualThis.Value))) && ((ProvinciaDiPresentazioneEqualThis == null) || ((VistruttoriaDomandeItem.ProvinciaDiPresentazione != null) && (VistruttoriaDomandeItem.ProvinciaDiPresentazione.Value == ProvinciaDiPresentazioneEqualThis.Value))) && 
((IdIstruttoreEqualThis == null) || ((VistruttoriaDomandeItem.IdIstruttore != null) && (VistruttoriaDomandeItem.IdIstruttore.Value == IdIstruttoreEqualThis.Value))) && ((ViaEqualThis == null) || ((VistruttoriaDomandeItem.Via != null) && (VistruttoriaDomandeItem.Via.Value == ViaEqualThis.Value))) && ((SegnaturaRiEqualThis == null) || ((VistruttoriaDomandeItem.SegnaturaRi != null) && (VistruttoriaDomandeItem.SegnaturaRi.Value == SegnaturaRiEqualThis.Value))) && 
((FiltroStatoIstruttoriaEqualThis == null) || ((VistruttoriaDomandeItem.FiltroStatoIstruttoria != null) && (VistruttoriaDomandeItem.FiltroStatoIstruttoria.Value == FiltroStatoIstruttoriaEqualThis.Value))) && ((OrdineStatoEqualThis == null) || ((VistruttoriaDomandeItem.OrdineStato != null) && (VistruttoriaDomandeItem.OrdineStato.Value == OrdineStatoEqualThis.Value))) && ((IdImpresaEqualThis == null) || ((VistruttoriaDomandeItem.IdImpresa != null) && (VistruttoriaDomandeItem.IdImpresa.Value == IdImpresaEqualThis.Value))))
				{
					VistruttoriaDomandeCollectionTemp.Add(VistruttoriaDomandeItem);
				}
			}
			return VistruttoriaDomandeCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public VistruttoriaDomandeCollection FiltroIstruttoria(NullTypes.IntNT IdProgettoEqualThis, NullTypes.IntNT IdIstruttoreEqualThis, NullTypes.StringNT ProvinciaAssegnazioneEqualThis, 
NullTypes.StringNT FiltroStatoIstruttoriaEqualThis, NullTypes.StringNT CuaaEqualThis, NullTypes.StringNT RagioneSocialeLike)
		{
			VistruttoriaDomandeCollection VistruttoriaDomandeCollectionTemp = new VistruttoriaDomandeCollection();
			foreach (VistruttoriaDomande VistruttoriaDomandeItem in this)
			{
				if (((IdProgettoEqualThis == null) || ((VistruttoriaDomandeItem.IdProgetto != null) && (VistruttoriaDomandeItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((IdIstruttoreEqualThis == null) || ((VistruttoriaDomandeItem.IdIstruttore != null) && (VistruttoriaDomandeItem.IdIstruttore.Value == IdIstruttoreEqualThis.Value))) && ((ProvinciaAssegnazioneEqualThis == null) || ((VistruttoriaDomandeItem.ProvinciaAssegnazione != null) && (VistruttoriaDomandeItem.ProvinciaAssegnazione.Value == ProvinciaAssegnazioneEqualThis.Value))) && 
((FiltroStatoIstruttoriaEqualThis == null) || ((VistruttoriaDomandeItem.FiltroStatoIstruttoria != null) && (VistruttoriaDomandeItem.FiltroStatoIstruttoria.Value == FiltroStatoIstruttoriaEqualThis.Value))) && ((CuaaEqualThis == null) || ((VistruttoriaDomandeItem.Cuaa != null) && (VistruttoriaDomandeItem.Cuaa.Value == CuaaEqualThis.Value))) && ((RagioneSocialeLike == null) || ((VistruttoriaDomandeItem.RagioneSociale !=null) &&(VistruttoriaDomandeItem.RagioneSociale.Like(RagioneSocialeLike.Value)))))
				{
					VistruttoriaDomandeCollectionTemp.Add(VistruttoriaDomandeItem);
				}
			}
			return VistruttoriaDomandeCollectionTemp;
		}



	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<vISTRUTTORIA_DOMANDE>
  <ViewName>vISTRUTTORIA_DOMANDE</ViewName>
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
    <Find OrderBy="ORDER BY ID_PROGETTO">
      <ID_BANDO>Equal</ID_BANDO>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_ISTRUTTORE>Equal</ID_ISTRUTTORE>
      <PROVINCIA_ASSEGNAZIONE>Equal</PROVINCIA_ASSEGNAZIONE>
      <ID_IMPRESA>Equal</ID_IMPRESA>
      <CUAA>Equal</CUAA>
      <RAGIONE_SOCIALE>Like</RAGIONE_SOCIALE>
      <FILTRO_STATO_ISTRUTTORIA>Equal</FILTRO_STATO_ISTRUTTORIA>
      <SELEZIONATA_X_REVISIONE>Equal</SELEZIONATA_X_REVISIONE>
    </Find>
  </Finds>
  <Filters>
    <FiltroIstruttoria>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_ISTRUTTORE>Equal</ID_ISTRUTTORE>
      <PROVINCIA_ASSEGNAZIONE>Equal</PROVINCIA_ASSEGNAZIONE>
      <FILTRO_STATO_ISTRUTTORIA>Equal</FILTRO_STATO_ISTRUTTORIA>
      <CUAA>Equal</CUAA>
      <RAGIONE_SOCIALE>Like</RAGIONE_SOCIALE>
    </FiltroIstruttoria>
  </Filters>
  <externalFields />
  <AddedFkFields />
</vISTRUTTORIA_DOMANDE>
*/