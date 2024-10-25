using System;
using System.ComponentModel;

namespace SiarLibrary
{

	// interfaccia provider per WorkflowProcedure
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IWorkflowProcedureProvider
	{
		int Save(WorkflowProcedure WorkflowProcedureObj);
		int SaveCollection(WorkflowProcedureCollection collectionObj);
		int Delete(WorkflowProcedure WorkflowProcedureObj);
		int DeleteCollection(WorkflowProcedureCollection collectionObj);
	}
	/// <summary>
	/// Summary description for WorkflowProcedure
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public class WorkflowProcedure: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.StringNT _CodTipoProcedura;
		private NullTypes.StringNT _CodWorkflow;
		private NullTypes.IntNT _Ordine;
		private NullTypes.BoolNT _Obbligatorio;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.StringNT _Url;
		[NonSerialized] private IWorkflowProcedureProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IWorkflowProcedureProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public WorkflowProcedure()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:COD_TIPO_PROCEDURA
		/// Tipo sul db:CHAR(3)
		/// </summary>
		public NullTypes.StringNT CodTipoProcedura
		{
			get { return _CodTipoProcedura; }
			set {
				if (CodTipoProcedura != value)
				{
					_CodTipoProcedura = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_WORKFLOW
		/// Tipo sul db:CHAR(5)
		/// </summary>
		public NullTypes.StringNT CodWorkflow
		{
			get { return _CodWorkflow; }
			set {
				if (CodWorkflow != value)
				{
					_CodWorkflow = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ORDINE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Ordine
		{
			get { return _Ordine; }
			set {
				if (Ordine != value)
				{
					_Ordine = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:OBBLIGATORIO
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT Obbligatorio
		{
			get { return _Obbligatorio; }
			set {
				if (Obbligatorio != value)
				{
					_Obbligatorio = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE
		/// Tipo sul db:VARCHAR(500)
		/// </summary>
		public NullTypes.StringNT Descrizione
		{
			get { return _Descrizione; }
			set {
				if (Descrizione != value)
				{
					_Descrizione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:URL
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT Url
		{
			get { return _Url; }
			set {
				if (Url != value)
				{
					_Url = value;
					SetDirtyFlag();
				}
			}
		}



		public int Save()
		{
			if (this.IsDirty)
			{
				return _provider.Save(this);
			}
			else
			{
				return 0;
			}
		}

		public int Delete()
		{
			return _provider.Delete(this);
		}

		//Get e Set dei campi 'aggiuntivi'

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