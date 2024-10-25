using System;
using System.ComponentModel;

namespace SiarLibrary
{

	// interfaccia provider per StepXBando
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IStepXBandoProvider
	{
		int Save(StepXBando StepXBandoObj);
		int SaveCollection(StepXBandoCollection collectionObj);
		int Delete(StepXBando StepXBandoObj);
		int DeleteCollection(StepXBandoCollection collectionObj);
	}
	/// <summary>
	/// Summary description for StepXBando
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public class StepXBando: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdBando;
		private NullTypes.IntNT _IdCheckList;
		private NullTypes.StringNT _CheckList;
		private NullTypes.StringNT _CodFase;
		private NullTypes.StringNT _FaseProcedurale;
		private NullTypes.IntNT _Ordine;
		private NullTypes.BoolNT _FlagTemplate;
		[NonSerialized] private IStepXBandoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IStepXBandoProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public StepXBando()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_BANDO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdBando
		{
			get { return _IdBando; }
			set {
				if (IdBando != value)
				{
					_IdBando = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_CHECK_LIST
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdCheckList
		{
			get { return _IdCheckList; }
			set {
				if (IdCheckList != value)
				{
					_IdCheckList = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CHECK_LIST
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT CheckList
		{
			get { return _CheckList; }
			set {
				if (CheckList != value)
				{
					_CheckList = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_FASE
		/// Tipo sul db:CHAR(1)
		/// </summary>
		public NullTypes.StringNT CodFase
		{
			get { return _CodFase; }
			set {
				if (CodFase != value)
				{
					_CodFase = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:FASE_PROCEDURALE
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT FaseProcedurale
		{
			get { return _FaseProcedurale; }
			set {
				if (FaseProcedurale != value)
				{
					_FaseProcedurale = value;
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
		/// Corrisponde al campo:FLAG_TEMPLATE
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT FlagTemplate
		{
			get { return _FlagTemplate; }
			set {
				if (FlagTemplate != value)
				{
					_FlagTemplate = value;
					SetDirtyFlag();
				}
			}
		}


		//Get e Set dei campi 'ForeignKey'

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
<STEP_X_BANDO>
  <ViewName>vSTEP_X_BANDO</ViewName>
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
    <Find>
      <ID_BANDO>Equal</ID_BANDO>
      <ID_CHECK_LIST>Equal</ID_CHECK_LIST>
      <ORDINE>Equal</ORDINE>
      <COD_FASE>Equal</COD_FASE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</STEP_X_BANDO>
*/