using System;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for VstatiProceduraliCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class VstatiProceduraliCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private VstatiProceduraliCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((VstatiProcedurali) info.GetValue(i.ToString(),typeof(VstatiProcedurali)));
			}
		}

		//Costruttore
		public VstatiProceduraliCollection()
		{
			this.ItemType = typeof(VstatiProcedurali);
		}

		//Get e Set
		public new VstatiProcedurali this[int index]
		{
			get { return (VstatiProcedurali)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new VstatiProceduraliCollection GetChanges()
		{
			return (VstatiProceduraliCollection) base.GetChanges();
		}

		//Add
		public int Add(VstatiProcedurali VstatiProceduraliObj)
		{
			return base.Add(VstatiProceduraliObj);
		}

		//AddCollection
		public void AddCollection(VstatiProceduraliCollection VstatiProceduraliCollectionObj)
		{
			foreach (VstatiProcedurali VstatiProceduraliObj in VstatiProceduraliCollectionObj)
				this.Add(VstatiProceduraliObj);
		}

		//Insert
		public void Insert(int index, VstatiProcedurali VstatiProceduraliObj)
		{
			base.Insert(index, VstatiProceduraliObj);
		}

		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public VstatiProceduraliCollection SubSelect(NullTypes.StringNT CodStatoEqualThis, NullTypes.StringNT StatoEqualThis, NullTypes.StringNT CodFaseEqualThis, 
NullTypes.StringNT FaseEqualThis, NullTypes.IntNT OrdineFaseEqualThis, NullTypes.IntNT OrdineStatoEqualThis)
		{
			VstatiProceduraliCollection VstatiProceduraliCollectionTemp = new VstatiProceduraliCollection();
			foreach (VstatiProcedurali VstatiProceduraliItem in this)
			{
				if (((CodStatoEqualThis == null) || ((VstatiProceduraliItem.CodStato != null) && (VstatiProceduraliItem.CodStato.Value == CodStatoEqualThis.Value))) && ((StatoEqualThis == null) || ((VstatiProceduraliItem.Stato != null) && (VstatiProceduraliItem.Stato.Value == StatoEqualThis.Value))) && ((CodFaseEqualThis == null) || ((VstatiProceduraliItem.CodFase != null) && (VstatiProceduraliItem.CodFase.Value == CodFaseEqualThis.Value))) && 
((FaseEqualThis == null) || ((VstatiProceduraliItem.Fase != null) && (VstatiProceduraliItem.Fase.Value == FaseEqualThis.Value))) && ((OrdineFaseEqualThis == null) || ((VstatiProceduraliItem.OrdineFase != null) && (VstatiProceduraliItem.OrdineFase.Value == OrdineFaseEqualThis.Value))) && ((OrdineStatoEqualThis == null) || ((VstatiProceduraliItem.OrdineStato != null) && (VstatiProceduraliItem.OrdineStato.Value == OrdineStatoEqualThis.Value))))
				{
					VstatiProceduraliCollectionTemp.Add(VstatiProceduraliItem);
				}
			}
			return VstatiProceduraliCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public VstatiProceduraliCollection FiltroOrdine(NullTypes.IntNT OrdineFaseEqualThis, NullTypes.IntNT OrdineStatoEqualThis, NullTypes.IntNT OrdineFaseGreaterThanThis, 
NullTypes.IntNT OrdineStatoGreaterThanThis, NullTypes.IntNT OrdineFaseLessThanThis, NullTypes.IntNT OrdineStatoLessThanThis)
		{
			VstatiProceduraliCollection VstatiProceduraliCollectionTemp = new VstatiProceduraliCollection();
			foreach (VstatiProcedurali VstatiProceduraliItem in this)
			{
				if (((OrdineFaseEqualThis == null) || ((VstatiProceduraliItem.OrdineFase != null) && (VstatiProceduraliItem.OrdineFase.Value == OrdineFaseEqualThis.Value))) && ((OrdineStatoEqualThis == null) || ((VstatiProceduraliItem.OrdineStato != null) && (VstatiProceduraliItem.OrdineStato.Value == OrdineStatoEqualThis.Value))) && ((OrdineFaseGreaterThanThis == null) || ((VstatiProceduraliItem.OrdineFase != null) && (VstatiProceduraliItem.OrdineFase.Value > OrdineFaseGreaterThanThis.Value))) && 
((OrdineStatoGreaterThanThis == null) || ((VstatiProceduraliItem.OrdineStato != null) && (VstatiProceduraliItem.OrdineStato.Value > OrdineStatoGreaterThanThis.Value))) && ((OrdineFaseLessThanThis == null) || ((VstatiProceduraliItem.OrdineFase != null) && (VstatiProceduraliItem.OrdineFase.Value < OrdineFaseLessThanThis.Value))) && ((OrdineStatoLessThanThis == null) || ((VstatiProceduraliItem.OrdineStato != null) && (VstatiProceduraliItem.OrdineStato.Value < OrdineStatoLessThanThis.Value))))
				{
					VstatiProceduraliCollectionTemp.Add(VstatiProceduraliItem);
				}
			}
			return VstatiProceduraliCollectionTemp;
		}



	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<vSTATI_PROCEDURALI>
  <ViewName>vSTATI_PROCEDURALI</ViewName>
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
    <Find OrderBy="ORDER BY ORDINE_FASE, ORDINE_STATO">
      <COD_STATO>Equal</COD_STATO>
      <COD_FASE>Equal</COD_FASE>
      <ORDINE_FASE>GreaterThan</ORDINE_FASE>
    </Find>
  </Finds>
  <Filters>
    <FiltroOrdine>
      <ORDINE_FASE>Equal</ORDINE_FASE>
      <ORDINE_STATO>Equal</ORDINE_STATO>
      <ORDINE_FASE>GreaterThan</ORDINE_FASE>
      <ORDINE_STATO>GreaterThan</ORDINE_STATO>
      <ORDINE_FASE>LessThan</ORDINE_FASE>
      <ORDINE_STATO>LessThan</ORDINE_STATO>
    </FiltroOrdine>
  </Filters>
  <externalFields />
  <AddedFkFields />
</vSTATI_PROCEDURALI>
*/