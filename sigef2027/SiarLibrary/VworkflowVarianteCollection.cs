using System;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for VworkflowVariantiCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]
	public class VworkflowVarianteCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private VworkflowVarianteCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((VworkflowVariante) info.GetValue(i.ToString(),typeof(VworkflowVariante)));
			}
		}

		//Costruttore
		public VworkflowVarianteCollection()
		{
			this.ItemType = typeof(VworkflowVariante);
		}

		//Get e Set
		public new VworkflowVariante this[int index]
		{
			get { return (VworkflowVariante)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new VworkflowVarianteCollection GetChanges()
		{
			return (VworkflowVarianteCollection) base.GetChanges();
		}

		//Add
		public int Add(VworkflowVariante VworkflowVariantiObj)
		{
			return base.Add(VworkflowVariantiObj);
		}

		//AddCollection
		public void AddCollection(VworkflowVarianteCollection VworkflowVariantiCollectionObj)
		{
			foreach (VworkflowVariante VworkflowVariantiObj in VworkflowVariantiCollectionObj)
				this.Add(VworkflowVariantiObj);
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