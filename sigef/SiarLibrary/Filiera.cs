using System;
using System.ComponentModel;

namespace SiarLibrary
{

	// interfaccia provider per Filiera
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IFilieraProvider
	{
		int Save(Filiera FilieraObj);
		int SaveCollection(FilieraCollection collectionObj);
		int Delete(Filiera FilieraObj);
		int DeleteCollection(FilieraCollection collectionObj);
	}
	/// <summary>
	/// Summary description for Filiera
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public class Filiera: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdFiliera;
		private NullTypes.StringNT _CodTipoFiliera;
		private NullTypes.StringNT _Denominazione;
		private NullTypes.StringNT _IdeaProgettuale;
		private NullTypes.IntNT _NumCertificato;
		private NullTypes.DatetimeNT _DataCertificato;
		private NullTypes.DatetimeNT _DataInserimento;
		private NullTypes.DatetimeNT _DataUltimaModifica;
		private NullTypes.StringNT _Operatore;
		[NonSerialized] private IFilieraProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IFilieraProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public Filiera()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_FILIERA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdFiliera
		{
			get { return _IdFiliera; }
			set {
				if (IdFiliera != value)
				{
					_IdFiliera = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_TIPO_FILIERA
		/// Tipo sul db:CHAR(3)
		/// </summary>
		public NullTypes.StringNT CodTipoFiliera
		{
			get { return _CodTipoFiliera; }
			set {
				if (CodTipoFiliera != value)
				{
					_CodTipoFiliera = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DENOMINAZIONE
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT Denominazione
		{
			get { return _Denominazione; }
			set {
				if (Denominazione != value)
				{
					_Denominazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IDEA_PROGETTUALE
		/// Tipo sul db:NTEXT
		/// </summary>
		public NullTypes.StringNT IdeaProgettuale
		{
			get { return _IdeaProgettuale; }
			set {
				if (IdeaProgettuale != value)
				{
					_IdeaProgettuale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NUM_CERTIFICATO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT NumCertificato
		{
			get { return _NumCertificato; }
			set {
				if (NumCertificato != value)
				{
					_NumCertificato = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_CERTIFICATO
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataCertificato
		{
			get { return _DataCertificato; }
			set {
				if (DataCertificato != value)
				{
					_DataCertificato = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_INSERIMENTO
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataInserimento
		{
			get { return _DataInserimento; }
			set {
				if (DataInserimento != value)
				{
					_DataInserimento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_ULTIMA_MODIFICA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataUltimaModifica
		{
			get { return _DataUltimaModifica; }
			set {
				if (DataUltimaModifica != value)
				{
					_DataUltimaModifica = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:OPERATORE
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT Operatore
		{
			get { return _Operatore; }
			set {
				if (Operatore != value)
				{
					_Operatore = value;
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
<FILIERA>
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
  <Finds />
  <Filters />
  <externalFields />
  <AddedFkFields />
</FILIERA>
*/