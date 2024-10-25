using System;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for VworkflowPagamentoCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class VworkflowPagamentoCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private VworkflowPagamentoCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((VworkflowPagamento) info.GetValue(i.ToString(),typeof(VworkflowPagamento)));
			}
		}

		//Costruttore
		public VworkflowPagamentoCollection()
		{
			this.ItemType = typeof(VworkflowPagamento);
		}

		//Get e Set
		public new VworkflowPagamento this[int index]
		{
			get { return (VworkflowPagamento)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new VworkflowPagamentoCollection GetChanges()
		{
			return (VworkflowPagamentoCollection) base.GetChanges();
		}

		//Add
		public int Add(VworkflowPagamento VworkflowPagamentoObj)
		{
			return base.Add(VworkflowPagamentoObj);
		}

		//AddCollection
		public void AddCollection(VworkflowPagamentoCollection VworkflowPagamentoCollectionObj)
		{
			foreach (VworkflowPagamento VworkflowPagamentoObj in VworkflowPagamentoCollectionObj)
				this.Add(VworkflowPagamentoObj);
		}

		//Insert
		public void Insert(int index, VworkflowPagamento VworkflowPagamentoObj)
		{
			base.Insert(index, VworkflowPagamentoObj);
		}

		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public VworkflowPagamentoCollection SubSelect(NullTypes.StringNT CodTipoEqualThis, NullTypes.StringNT CodWorkflowEqualThis, NullTypes.IntNT OrdineEqualThis, 
NullTypes.BoolNT ObbligatorioEqualThis, NullTypes.StringNT DescrizioneEqualThis, NullTypes.StringNT UrlEqualThis, 
NullTypes.StringNT TipoPagamentoEqualThis, NullTypes.StringNT CodFaseEqualThis, NullTypes.StringNT FaseEqualThis, 
NullTypes.IntNT OrdineFaseEqualThis)
		{
			VworkflowPagamentoCollection VworkflowPagamentoCollectionTemp = new VworkflowPagamentoCollection();
			foreach (VworkflowPagamento VworkflowPagamentoItem in this)
			{
				if (((CodTipoEqualThis == null) || ((VworkflowPagamentoItem.CodTipo != null) && (VworkflowPagamentoItem.CodTipo.Value == CodTipoEqualThis.Value))) && ((CodWorkflowEqualThis == null) || ((VworkflowPagamentoItem.CodWorkflow != null) && (VworkflowPagamentoItem.CodWorkflow.Value == CodWorkflowEqualThis.Value))) && ((OrdineEqualThis == null) || ((VworkflowPagamentoItem.Ordine != null) && (VworkflowPagamentoItem.Ordine.Value == OrdineEqualThis.Value))) && 
((ObbligatorioEqualThis == null) || ((VworkflowPagamentoItem.Obbligatorio != null) && (VworkflowPagamentoItem.Obbligatorio.Value == ObbligatorioEqualThis.Value))) && ((DescrizioneEqualThis == null) || ((VworkflowPagamentoItem.Descrizione != null) && (VworkflowPagamentoItem.Descrizione.Value == DescrizioneEqualThis.Value))) && ((UrlEqualThis == null) || ((VworkflowPagamentoItem.Url != null) && (VworkflowPagamentoItem.Url.Value == UrlEqualThis.Value))) && 
((TipoPagamentoEqualThis == null) || ((VworkflowPagamentoItem.TipoPagamento != null) && (VworkflowPagamentoItem.TipoPagamento.Value == TipoPagamentoEqualThis.Value))) && ((CodFaseEqualThis == null) || ((VworkflowPagamentoItem.CodFase != null) && (VworkflowPagamentoItem.CodFase.Value == CodFaseEqualThis.Value))) && ((FaseEqualThis == null) || ((VworkflowPagamentoItem.Fase != null) && (VworkflowPagamentoItem.Fase.Value == FaseEqualThis.Value))) && 
((OrdineFaseEqualThis == null) || ((VworkflowPagamentoItem.OrdineFase != null) && (VworkflowPagamentoItem.OrdineFase.Value == OrdineFaseEqualThis.Value))))
				{
					VworkflowPagamentoCollectionTemp.Add(VworkflowPagamentoItem);
				}
			}
			return VworkflowPagamentoCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public VworkflowPagamentoCollection FiltroObbligatorio(NullTypes.BoolNT ObbligatorioEqualThis)
		{
			VworkflowPagamentoCollection VworkflowPagamentoCollectionTemp = new VworkflowPagamentoCollection();
			foreach (VworkflowPagamento VworkflowPagamentoItem in this)
			{
				if (((ObbligatorioEqualThis == null) || ((VworkflowPagamentoItem.Obbligatorio != null) && (VworkflowPagamentoItem.Obbligatorio.Value == ObbligatorioEqualThis.Value))))
				{
					VworkflowPagamentoCollectionTemp.Add(VworkflowPagamentoItem);
				}
			}
			return VworkflowPagamentoCollectionTemp;
		}



	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<vWORKFLOW_PAGAMENTO>
  <ViewName>vWORKFLOW_PAGAMENTO</ViewName>
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
      <COD_TIPO>Equal</COD_TIPO>
      <COD_WORKFLOW>Equal</COD_WORKFLOW>
      <COD_FASE>Equal</COD_FASE>
      <DESCRIZIONE>Like</DESCRIZIONE>
    </Find>
  </Finds>
  <Filters>
    <FiltroObbligatorio>
      <OBBLIGATORIO>Equal</OBBLIGATORIO>
    </FiltroObbligatorio>
  </Filters>
  <externalFields />
  <AddedFkFields />
</vWORKFLOW_PAGAMENTO>
*/