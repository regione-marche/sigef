using System;
using System.ComponentModel;

namespace SiarLibrary
{

	// interfaccia provider per StepParametri
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IStepParametriProvider
	{
		int Save(StepParametri StepParametriObj);
		int SaveCollection(StepParametriCollection collectionObj);
		int Delete(StepParametri StepParametriObj);
		int DeleteCollection(StepParametriCollection collectionObj);
	}
	/// <summary>
	/// Summary description for StepParametri
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public class StepParametri: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdParametro;
		private NullTypes.IntNT _IdStep;
		private NullTypes.StringNT _Nome;
		private NullTypes.StringNT _Tipo;
		[NonSerialized] private IStepParametriProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IStepParametriProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public StepParametri()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_PARAMETRO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdParametro
		{
			get { return _IdParametro; }
			set {
				if (IdParametro != value)
				{
					_IdParametro = value;
					SetDirtyFlag();
				}
			}
		}

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
		/// Corrisponde al campo:NOME
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT Nome
		{
			get { return _Nome; }
			set {
				if (Nome != value)
				{
					_Nome = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TIPO
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT Tipo
		{
			get { return _Tipo; }
			set {
				if (Tipo != value)
				{
					_Tipo = value;
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
<STEP_PARAMETRI>
  <ViewName>
  </ViewName>
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
      <ID_PARAMETRO>Equal</ID_PARAMETRO>
      <ID_STEP>Equal</ID_STEP>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</STEP_PARAMETRI>
*/