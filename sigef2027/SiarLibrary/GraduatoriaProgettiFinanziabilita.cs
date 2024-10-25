using System;
using System.ComponentModel;

namespace SiarLibrary
{

	// interfaccia provider per GraduatoriaProgettiFinanziabilita
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IGraduatoriaProgettiFinanziabilitaProvider
	{
		int Save(GraduatoriaProgettiFinanziabilita GraduatoriaProgettiFinanziabilitaObj);
		int SaveCollection(GraduatoriaProgettiFinanziabilitaCollection collectionObj);
		int Delete(GraduatoriaProgettiFinanziabilita GraduatoriaProgettiFinanziabilitaObj);
		int DeleteCollection(GraduatoriaProgettiFinanziabilitaCollection collectionObj);
	}
	/// <summary>
	/// Summary description for GraduatoriaProgettiFinanziabilita
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public class GraduatoriaProgettiFinanziabilita: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdBando;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.IntNT _IdProgIntegrato;
		private NullTypes.DecimalNT _CostoTotale;
		private NullTypes.DecimalNT _ContributoDiMisura;
		private NullTypes.DecimalNT _ContributoRimanente;
		private NullTypes.StringNT _Misura;
		private NullTypes.BoolNT _MisuraPrevalente;
		[NonSerialized] private IGraduatoriaProgettiFinanziabilitaProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IGraduatoriaProgettiFinanziabilitaProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public GraduatoriaProgettiFinanziabilita()
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
		/// Corrisponde al campo:ID_PROGETTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdProgetto
		{
			get { return _IdProgetto; }
			set {
				if (IdProgetto != value)
				{
					_IdProgetto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_PROG_INTEGRATO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdProgIntegrato
		{
			get { return _IdProgIntegrato; }
			set {
				if (IdProgIntegrato != value)
				{
					_IdProgIntegrato = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COSTO_TOTALE
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT CostoTotale
		{
			get { return _CostoTotale; }
			set {
				if (CostoTotale != value)
				{
					_CostoTotale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CONTRIBUTO_DI_MISURA
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT ContributoDiMisura
		{
			get { return _ContributoDiMisura; }
			set {
				if (ContributoDiMisura != value)
				{
					_ContributoDiMisura = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CONTRIBUTO_RIMANENTE
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT ContributoRimanente
		{
			get { return _ContributoRimanente; }
			set {
				if (ContributoRimanente != value)
				{
					_ContributoRimanente = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:MISURA
		/// Tipo sul db:VARCHAR(10)
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

		/// <summary>
		/// Corrisponde al campo:MISURA_PREVALENTE
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT MisuraPrevalente
		{
			get { return _MisuraPrevalente; }
			set {
				if (MisuraPrevalente != value)
				{
					_MisuraPrevalente = value;
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
<GRADUATORIA_PROGETTI_FINANZIABILITA>
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
    <Find OrderBy="ORDER BY MISURA_PREVALENTE DESC, MISURA">
      <ID_BANDO>Equal</ID_BANDO>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_PROG_INTEGRATO>Equal</ID_PROG_INTEGRATO>
      <MISURA>Equal</MISURA>
    </Find>
  </Finds>
  <Filters>
    <FiltroMisura>
      <MISURA>Equal</MISURA>
    </FiltroMisura>
  </Filters>
  <externalFields />
  <AddedFkFields />
</GRADUATORIA_PROGETTI_FINANZIABILITA>
*/