using System;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for VprioritaXPunteggioCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class VprioritaXPunteggioCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private VprioritaXPunteggioCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((VprioritaXPunteggio) info.GetValue(i.ToString(),typeof(VprioritaXPunteggio)));
			}
		}

		//Costruttore
		public VprioritaXPunteggioCollection()
		{
			this.ItemType = typeof(VprioritaXPunteggio);
		}

		//Get e Set
		public new VprioritaXPunteggio this[int index]
		{
			get { return (VprioritaXPunteggio)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new VprioritaXPunteggioCollection GetChanges()
		{
			return (VprioritaXPunteggioCollection) base.GetChanges();
		}

		//Add
		public int Add(VprioritaXPunteggio VprioritaXPunteggioObj)
		{
			return base.Add(VprioritaXPunteggioObj);
		}

		//AddCollection
		public void AddCollection(VprioritaXPunteggioCollection VprioritaXPunteggioCollectionObj)
		{
			foreach (VprioritaXPunteggio VprioritaXPunteggioObj in VprioritaXPunteggioCollectionObj)
				this.Add(VprioritaXPunteggioObj);
		}

		//Insert
		public void Insert(int index, VprioritaXPunteggio VprioritaXPunteggioObj)
		{
			base.Insert(index, VprioritaXPunteggioObj);
		}

		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public VprioritaXPunteggioCollection SubSelect(NullTypes.IntNT IdSchedaValutazioneEqualThis, NullTypes.IntNT OrdineEqualThis, NullTypes.DecimalNT PesoEqualThis, 
NullTypes.IntNT IdPrioritaEqualThis, NullTypes.StringNT DescrizioneEqualThis, NullTypes.StringNT CodLivelloEqualThis, 
NullTypes.BoolNT PluriValoreEqualThis, NullTypes.StringNT EvalEqualThis, NullTypes.BoolNT FlagManualeEqualThis, 
NullTypes.BoolNT InputNumericoEqualThis, NullTypes.StringNT MisuraEqualThis, NullTypes.BoolNT MisuraPrevalenteEqualThis, 
NullTypes.IntNT IdBandoEqualThis)
		{
			VprioritaXPunteggioCollection VprioritaXPunteggioCollectionTemp = new VprioritaXPunteggioCollection();
			foreach (VprioritaXPunteggio VprioritaXPunteggioItem in this)
			{
				if (((IdSchedaValutazioneEqualThis == null) || ((VprioritaXPunteggioItem.IdSchedaValutazione != null) && (VprioritaXPunteggioItem.IdSchedaValutazione.Value == IdSchedaValutazioneEqualThis.Value))) && ((OrdineEqualThis == null) || ((VprioritaXPunteggioItem.Ordine != null) && (VprioritaXPunteggioItem.Ordine.Value == OrdineEqualThis.Value))) && ((PesoEqualThis == null) || ((VprioritaXPunteggioItem.Peso != null) && (VprioritaXPunteggioItem.Peso.Value == PesoEqualThis.Value))) && 
((IdPrioritaEqualThis == null) || ((VprioritaXPunteggioItem.IdPriorita != null) && (VprioritaXPunteggioItem.IdPriorita.Value == IdPrioritaEqualThis.Value))) && ((DescrizioneEqualThis == null) || ((VprioritaXPunteggioItem.Descrizione != null) && (VprioritaXPunteggioItem.Descrizione.Value == DescrizioneEqualThis.Value))) && ((CodLivelloEqualThis == null) || ((VprioritaXPunteggioItem.CodLivello != null) && (VprioritaXPunteggioItem.CodLivello.Value == CodLivelloEqualThis.Value))) && 
((PluriValoreEqualThis == null) || ((VprioritaXPunteggioItem.PluriValore != null) && (VprioritaXPunteggioItem.PluriValore.Value == PluriValoreEqualThis.Value))) && ((EvalEqualThis == null) || ((VprioritaXPunteggioItem.Eval != null) && (VprioritaXPunteggioItem.Eval.Value == EvalEqualThis.Value))) && ((FlagManualeEqualThis == null) || ((VprioritaXPunteggioItem.FlagManuale != null) && (VprioritaXPunteggioItem.FlagManuale.Value == FlagManualeEqualThis.Value))) && 
((InputNumericoEqualThis == null) || ((VprioritaXPunteggioItem.InputNumerico != null) && (VprioritaXPunteggioItem.InputNumerico.Value == InputNumericoEqualThis.Value))) && ((MisuraEqualThis == null) || ((VprioritaXPunteggioItem.Misura != null) && (VprioritaXPunteggioItem.Misura.Value == MisuraEqualThis.Value))) && ((MisuraPrevalenteEqualThis == null) || ((VprioritaXPunteggioItem.MisuraPrevalente != null) && (VprioritaXPunteggioItem.MisuraPrevalente.Value == MisuraPrevalenteEqualThis.Value))) && 
((IdBandoEqualThis == null) || ((VprioritaXPunteggioItem.IdBando != null) && (VprioritaXPunteggioItem.IdBando.Value == IdBandoEqualThis.Value))))
				{
					VprioritaXPunteggioCollectionTemp.Add(VprioritaXPunteggioItem);
				}
			}
			return VprioritaXPunteggioCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public VprioritaXPunteggioCollection FiltroMisura(NullTypes.StringNT MisuraEqualThis)
		{
			VprioritaXPunteggioCollection VprioritaXPunteggioCollectionTemp = new VprioritaXPunteggioCollection();
			foreach (VprioritaXPunteggio VprioritaXPunteggioItem in this)
			{
				if (((MisuraEqualThis == null) || ((VprioritaXPunteggioItem.Misura != null) && (VprioritaXPunteggioItem.Misura.Value == MisuraEqualThis.Value))))
				{
					VprioritaXPunteggioCollectionTemp.Add(VprioritaXPunteggioItem);
				}
			}
			return VprioritaXPunteggioCollectionTemp;
		}



	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<vPRIORITA_X_PUNTEGGIO>
  <ViewName>vPRIORITA_X_PUNTEGGIO</ViewName>
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
    <Find OrderBy="ORDER BY MISURA,ORDINE">
      <ID_BANDO>Equal</ID_BANDO>
      <MISURA_PREVALENTE>Equal</MISURA_PREVALENTE>
      <ID_SCHEDA_VALUTAZIONE>Equal</ID_SCHEDA_VALUTAZIONE>
    </Find>
  </Finds>
  <Filters>
    <FiltroMisura>
      <MISURA>Equal</MISURA>
    </FiltroMisura>
  </Filters>
  <externalFields />
  <AddedFkFields />
</vPRIORITA_X_PUNTEGGIO>
*/