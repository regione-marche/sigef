using System;
using System.ComponentModel;

namespace SiarLibrary
{

	// interfaccia provider per CorrettivaRendicontazioneSpostamenti
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface ICorrettivaRendicontazioneSpostamentiProvider
	{
		int Save(CorrettivaRendicontazioneSpostamenti CorrettivaRendicontazioneSpostamentiObj);
		int SaveCollection(CorrettivaRendicontazioneSpostamentiCollection collectionObj);
		int Delete(CorrettivaRendicontazioneSpostamenti CorrettivaRendicontazioneSpostamentiObj);
		int DeleteCollection(CorrettivaRendicontazioneSpostamentiCollection collectionObj);
	}
	/// <summary>
	/// Summary description for CorrettivaRendicontazioneSpostamenti
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public class CorrettivaRendicontazioneSpostamenti: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _Id;
		private NullTypes.IntNT _IdCorrettiva;
		private NullTypes.IntNT _IdInvestimentoDa;
		private NullTypes.IntNT _IdInvestimentoA;
		private NullTypes.DecimalNT _ImportoSpostato;
		private NullTypes.BoolNT _Concluso;
		private NullTypes.BoolNT _Annullato;
		private NullTypes.IntNT _IdUtente;
		private NullTypes.DatetimeNT _Data;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.IntNT _IdJsonLog;
		[NonSerialized] private ICorrettivaRendicontazioneSpostamentiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ICorrettivaRendicontazioneSpostamentiProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public CorrettivaRendicontazioneSpostamenti()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Id
		{
			get { return _Id; }
			set {
				if (Id != value)
				{
					_Id = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_CORRETTIVA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdCorrettiva
		{
			get { return _IdCorrettiva; }
			set {
				if (IdCorrettiva != value)
				{
					_IdCorrettiva = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_INVESTIMENTO_DA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdInvestimentoDa
		{
			get { return _IdInvestimentoDa; }
			set {
				if (IdInvestimentoDa != value)
				{
					_IdInvestimentoDa = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_INVESTIMENTO_A
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdInvestimentoA
		{
			get { return _IdInvestimentoA; }
			set {
				if (IdInvestimentoA != value)
				{
					_IdInvestimentoA = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IMPORTO_SPOSTATO
		/// Tipo sul db:DECIMAL(18,2)
		/// Default:((0))
		/// </summary>
		public NullTypes.DecimalNT ImportoSpostato
		{
			get { return _ImportoSpostato; }
			set {
				if (ImportoSpostato != value)
				{
					_ImportoSpostato = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CONCLUSO
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT Concluso
		{
			get { return _Concluso; }
			set {
				if (Concluso != value)
				{
					_Concluso = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ANNULLATO
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT Annullato
		{
			get { return _Annullato; }
			set {
				if (Annullato != value)
				{
					_Annullato = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_UTENTE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdUtente
		{
			get { return _IdUtente; }
			set {
				if (IdUtente != value)
				{
					_IdUtente = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT Data
		{
			get { return _Data; }
			set {
				if (Data != value)
				{
					_Data = value;
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
		/// Corrisponde al campo:ID_JSON_LOG
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdJsonLog
		{
			get { return _IdJsonLog; }
			set {
				if (IdJsonLog != value)
				{
					_IdJsonLog = value;
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
<CORRETTIVA_RENDICONTAZIONE_SPOSTAMENTI>
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
    <Find OrderBy="ORDER BY ID">
      <ID_CORRETTIVA>Equal</ID_CORRETTIVA>
      <ID_INVESTIMENTO_DA>Equal</ID_INVESTIMENTO_DA>
      <ID_INVESTIMENTO_A>Equal</ID_INVESTIMENTO_A>
      <CONCLUSO>Equal</CONCLUSO>
      <ANNULLATO>Equal</ANNULLATO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</CORRETTIVA_RENDICONTAZIONE_SPOSTAMENTI>
*/