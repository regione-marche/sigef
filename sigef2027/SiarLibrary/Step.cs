using System;
using System.ComponentModel;

namespace SiarLibrary
{

	// interfaccia provider per Step
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IStepProvider
	{
		int Save(Step StepObj);
		int SaveCollection(StepCollection collectionObj);
		int Delete(Step StepObj);
		int DeleteCollection(StepCollection collectionObj);
	}
	/// <summary>
	/// Summary description for Step
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public class Step: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdStep;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.BoolNT _Automatico;
		private NullTypes.StringNT _QuerySql;
		private NullTypes.StringNT _CodeMethod;
		private NullTypes.StringNT _Url;
		private NullTypes.StringNT _ValMassimo;
		private NullTypes.StringNT _ValMinimo;
		private NullTypes.StringNT _QuerySqlPost;
		private NullTypes.StringNT _FaseProcedurale;
		private NullTypes.IntNT _Ordine;
		private NullTypes.StringNT _CodFase;
		private NullTypes.StringNT _Misura;
		[NonSerialized] private IStepProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IStepProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public Step()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_STEP
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdStep
		{
			get { return _IdStep; }
			set {
				if (IdStep != value)
				{
					_IdStep = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE
		/// Tipo sul db:VARCHAR(255)
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
		/// Corrisponde al campo:AUTOMATICO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Automatico
		{
			get { return _Automatico; }
			set {
				if (Automatico != value)
				{
					_Automatico = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:QUERY_SQL
		/// Tipo sul db:VARCHAR(3000)
		/// </summary>
		public NullTypes.StringNT QuerySql
		{
			get { return _QuerySql; }
			set {
				if (QuerySql != value)
				{
					_QuerySql = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CODE_METHOD
		/// Tipo sul db:VARCHAR(30)
		/// </summary>
		public NullTypes.StringNT CodeMethod
		{
			get { return _CodeMethod; }
			set {
				if (CodeMethod != value)
				{
					_CodeMethod = value;
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

		/// <summary>
		/// Corrisponde al campo:VAL_MASSIMO
		/// Tipo sul db:VARCHAR(20)
		/// </summary>
		public NullTypes.StringNT ValMassimo
		{
			get { return _ValMassimo; }
			set {
				if (ValMassimo != value)
				{
					_ValMassimo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:VAL_MINIMO
		/// Tipo sul db:VARCHAR(20)
		/// </summary>
		public NullTypes.StringNT ValMinimo
		{
			get { return _ValMinimo; }
			set {
				if (ValMinimo != value)
				{
					_ValMinimo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:QUERY_SQL_POST
		/// Tipo sul db:VARCHAR(300)
		/// </summary>
		public NullTypes.StringNT QuerySqlPost
		{
			get { return _QuerySqlPost; }
			set {
				if (QuerySqlPost != value)
				{
					_QuerySqlPost = value;
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
		/// Corrisponde al campo:MISURA
		/// Tipo sul db:NVARCHAR
		/// </summary>
		public NullTypes.StringNT Misura
		{
			get { return _Misura; }
			set {
				if (Misura != value)
				{
					_Misura = value;
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
<STEP>
  <ViewName>vSTEP</ViewName>
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
    <Find OrderBy="ORDER BY ">
      <ID_STEP>Equal</ID_STEP>
      <AUTOMATICO>Equal</AUTOMATICO>
      <COD_FASE>Equal</COD_FASE>
    </Find>
  </Finds>
  <Filters>
    <FiltroMisura>
      <MISURA>Like</MISURA>
    </FiltroMisura>
  </Filters>
  <externalFields />
  <AddedFkFields />
</STEP>
*/