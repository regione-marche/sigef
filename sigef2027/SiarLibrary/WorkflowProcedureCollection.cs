using System;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for WorkflowProcedureCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class WorkflowProcedureCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private WorkflowProcedureCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((WorkflowProcedure) info.GetValue(i.ToString(),typeof(WorkflowProcedure)));
			}
		}

		//Costruttore
		public WorkflowProcedureCollection()
		{
			this.ItemType = typeof(WorkflowProcedure);
		}

		//Costruttore con provider
		public WorkflowProcedureCollection(IWorkflowProcedureProvider providerObj)
		{
			this.ItemType = typeof(WorkflowProcedure);
			this.Provider = providerObj;
		}

		//Get e Set
		public new WorkflowProcedure this[int index]
		{
			get { return (WorkflowProcedure)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new WorkflowProcedureCollection GetChanges()
		{
			return (WorkflowProcedureCollection) base.GetChanges();
		}

		[NonSerialized] private IWorkflowProcedureProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IWorkflowProcedureProvider Provider
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
		public int Add(WorkflowProcedure WorkflowProcedureObj)
		{
			if (WorkflowProcedureObj.Provider == null) WorkflowProcedureObj.Provider = this.Provider;
			return base.Add(WorkflowProcedureObj);
		}

		//AddCollection
		public void AddCollection(WorkflowProcedureCollection WorkflowProcedureCollectionObj)
		{
			foreach (WorkflowProcedure WorkflowProcedureObj in WorkflowProcedureCollectionObj)
				this.Add(WorkflowProcedureObj);
		}

		//Insert
		public void Insert(int index, WorkflowProcedure WorkflowProcedureObj)
		{
			if (WorkflowProcedureObj.Provider == null) WorkflowProcedureObj.Provider = this.Provider;
			base.Insert(index, WorkflowProcedureObj);
		}

		//CollectionGetById
		public WorkflowProcedure CollectionGetById(NullTypes.StringNT CodTipoProceduraValue, NullTypes.StringNT CodWorkflowValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].CodTipoProcedura == CodTipoProceduraValue) && (this[i].CodWorkflow == CodWorkflowValue))
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
		public WorkflowProcedureCollection SubSelect(NullTypes.StringNT CodTipoProceduraEqualThis, NullTypes.StringNT CodWorkflowEqualThis, NullTypes.IntNT OrdineEqualThis, 
NullTypes.BoolNT ObbligatorioEqualThis)
		{
			WorkflowProcedureCollection WorkflowProcedureCollectionTemp = new WorkflowProcedureCollection();
			foreach (WorkflowProcedure WorkflowProcedureItem in this)
			{
				if (((CodTipoProceduraEqualThis == null) || ((WorkflowProcedureItem.CodTipoProcedura != null) && (WorkflowProcedureItem.CodTipoProcedura.Value == CodTipoProceduraEqualThis.Value))) && ((CodWorkflowEqualThis == null) || ((WorkflowProcedureItem.CodWorkflow != null) && (WorkflowProcedureItem.CodWorkflow.Value == CodWorkflowEqualThis.Value))) && ((OrdineEqualThis == null) || ((WorkflowProcedureItem.Ordine != null) && (WorkflowProcedureItem.Ordine.Value == OrdineEqualThis.Value))) && 
((ObbligatorioEqualThis == null) || ((WorkflowProcedureItem.Obbligatorio != null) && (WorkflowProcedureItem.Obbligatorio.Value == ObbligatorioEqualThis.Value))))
				{
					WorkflowProcedureCollectionTemp.Add(WorkflowProcedureItem);
				}
			}
			return WorkflowProcedureCollectionTemp;
		}



	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<WORKFLOW_PROCEDURE>
  <ViewName>vWORKFLOW_PROCEDURE</ViewName>
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
      <COD_TIPO_PROCEDURA>Equal</COD_TIPO_PROCEDURA>
      <COD_WORKFLOW>Equal</COD_WORKFLOW>
      <OBBLIGATORIO>Equal</OBBLIGATORIO>
      <ORDINE>EqGreaterThan</ORDINE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</WORKFLOW_PROCEDURE>
*/