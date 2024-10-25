using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per CovidAutodichiarazione
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface ICovidAutodichiarazioneProvider
	{
		int Save(CovidAutodichiarazione CovidAutodichiarazioneObj);
		int SaveCollection(CovidAutodichiarazioneCollection collectionObj);
		int Delete(CovidAutodichiarazione CovidAutodichiarazioneObj);
		int DeleteCollection(CovidAutodichiarazioneCollection collectionObj);
	}
	/// <summary>
	/// Summary description for CovidAutodichiarazione
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class CovidAutodichiarazione : BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _Id;
		private NullTypes.IntNT _OperatoreInserimento;
		private NullTypes.DatetimeNT _DataInserimento;
		private NullTypes.DatetimeNT _DataModifica;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.IntNT _IdBando;
		private NullTypes.IntNT _IdImpresa;
		private NullTypes.StringNT _CodiceFiscale;
		private NullTypes.StringNT _PartitaIva;
		private NullTypes.DatetimeNT _DataInizioAttivita;
		private NullTypes.StringNT _RagioneSociale;
		private NullTypes.StringNT _FormaGiuridica;
		private NullTypes.StringNT _CodiceAteco;
		private NullTypes.IntNT _DimensioneImpresa;
		private NullTypes.StringNT _NumeroRegistroImprese;
		private NullTypes.StringNT _NumeroRea;
		private NullTypes.IntNT _AnnoRea;
		private NullTypes.StringNT _IndirizzoSedeLegale;
		private NullTypes.IntNT _Comune;
		private NullTypes.StringNT _DenominazioneComune;
		private NullTypes.StringNT _Provincia;
		private NullTypes.IntNT _Cap;
		private NullTypes.StringNT _Telefono;
		private NullTypes.StringNT _Email;
		private NullTypes.StringNT _Pec;
		private NullTypes.StringNT _NominativoRappresentanteLegale;
		private NullTypes.StringNT _CfRappresentanteLegale;
		private NullTypes.DatetimeNT _DataDiNascitaRappresentanteLegale;
		private NullTypes.IntNT _ComuneNascitaRappresentanteLegale;
		private NullTypes.StringNT _DenominazioneComuneNascitaRappresentanteLegale;
		private NullTypes.StringNT _ProvinciaNascitaRappresentanteLegale;
		private NullTypes.IntNT _CapComuneNascitaRappresentanteLegale;
		private NullTypes.StringNT _Iban;
		private NullTypes.StringNT _ContattoNominativo;
		private NullTypes.StringNT _ContattoEmail;
		private NullTypes.StringNT _ContattoPec;
		private NullTypes.StringNT _ContattoTelefono;
		private NullTypes.StringNT _ContattoSitoWeb;
		private NullTypes.IntNT _LocalizzazioneComune;
		private NullTypes.StringNT _LocalizzazioneProvincia;
		private NullTypes.IntNT _LocalizzazioneCap;
		private NullTypes.StringNT _LocalizzazioneVia;
		private NullTypes.DatetimeNT _MarcaBolloData;
		private NullTypes.StringNT _MarcaBolloEstremi;
		private NullTypes.BoolNT _Definitiva;
		private NullTypes.DatetimeNT _DataDefinitiva;
		private NullTypes.IntNT _IdFileDomanda;
		private NullTypes.StringNT _TokenCohesion;
		private NullTypes.BoolNT _FlagDelegatoAbilitatoSigef;
		[NonSerialized] private ICovidAutodichiarazioneProvider _provider;
		[System.Xml.Serialization.XmlIgnore]
		public ICovidAutodichiarazioneProvider Provider
		{
			get { return _provider; }
			set { _provider = value; }
		}


		//Costruttore
		public CovidAutodichiarazione()
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
			set
			{
				if (Id != value)
				{
					_Id = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:OPERATORE_INSERIMENTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT OperatoreInserimento
		{
			get { return _OperatoreInserimento; }
			set
			{
				if (OperatoreInserimento != value)
				{
					_OperatoreInserimento = value;
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
			set
			{
				if (DataInserimento != value)
				{
					_DataInserimento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_MODIFICA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataModifica
		{
			get { return _DataModifica; }
			set
			{
				if (DataModifica != value)
				{
					_DataModifica = value;
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
			set
			{
				if (IdProgetto != value)
				{
					_IdProgetto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_BANDO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdBando
		{
			get { return _IdBando; }
			set
			{
				if (IdBando != value)
				{
					_IdBando = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_IMPRESA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdImpresa
		{
			get { return _IdImpresa; }
			set
			{
				if (IdImpresa != value)
				{
					_IdImpresa = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CODICE_FISCALE
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT CodiceFiscale
		{
			get { return _CodiceFiscale; }
			set
			{
				if (CodiceFiscale != value)
				{
					_CodiceFiscale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PARTITA_IVA
		/// Tipo sul db:VARCHAR(11)
		/// </summary>
		public NullTypes.StringNT PartitaIva
		{
			get { return _PartitaIva; }
			set
			{
				if (PartitaIva != value)
				{
					_PartitaIva = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_INIZIO_ATTIVITA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataInizioAttivita
		{
			get { return _DataInizioAttivita; }
			set
			{
				if (DataInizioAttivita != value)
				{
					_DataInizioAttivita = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:RAGIONE_SOCIALE
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT RagioneSociale
		{
			get { return _RagioneSociale; }
			set
			{
				if (RagioneSociale != value)
				{
					_RagioneSociale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:FORMA_GIURIDICA
		/// Tipo sul db:VARCHAR(10)
		/// </summary>
		public NullTypes.StringNT FormaGiuridica
		{
			get { return _FormaGiuridica; }
			set
			{
				if (FormaGiuridica != value)
				{
					_FormaGiuridica = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CODICE_ATECO
		/// Tipo sul db:CHAR(9)
		/// </summary>
		public NullTypes.StringNT CodiceAteco
		{
			get { return _CodiceAteco; }
			set
			{
				if (CodiceAteco != value)
				{
					_CodiceAteco = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DIMENSIONE_IMPRESA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT DimensioneImpresa
		{
			get { return _DimensioneImpresa; }
			set
			{
				if (DimensioneImpresa != value)
				{
					_DimensioneImpresa = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NUMERO_REGISTRO_IMPRESE
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT NumeroRegistroImprese
		{
			get { return _NumeroRegistroImprese; }
			set
			{
				if (NumeroRegistroImprese != value)
				{
					_NumeroRegistroImprese = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NUMERO_REA
		/// Tipo sul db:VARCHAR(20)
		/// </summary>
		public NullTypes.StringNT NumeroRea
		{
			get { return _NumeroRea; }
			set
			{
				if (NumeroRea != value)
				{
					_NumeroRea = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ANNO_REA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT AnnoRea
		{
			get { return _AnnoRea; }
			set
			{
				if (AnnoRea != value)
				{
					_AnnoRea = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:INDIRIZZO_SEDE_LEGALE
		/// Tipo sul db:VARCHAR(1000)
		/// </summary>
		public NullTypes.StringNT IndirizzoSedeLegale
		{
			get { return _IndirizzoSedeLegale; }
			set
			{
				if (IndirizzoSedeLegale != value)
				{
					_IndirizzoSedeLegale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COMUNE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Comune
		{
			get { return _Comune; }
			set
			{
				if (Comune != value)
				{
					_Comune = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DENOMINAZIONE_COMUNE
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT DenominazioneComune
		{
			get { return _DenominazioneComune; }
			set
			{
				if (DenominazioneComune != value)
				{
					_DenominazioneComune = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PROVINCIA
		/// Tipo sul db:CHAR(2)
		/// </summary>
		public NullTypes.StringNT Provincia
		{
			get { return _Provincia; }
			set
			{
				if (Provincia != value)
				{
					_Provincia = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CAP
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Cap
		{
			get { return _Cap; }
			set
			{
				if (Cap != value)
				{
					_Cap = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TELEFONO
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT Telefono
		{
			get { return _Telefono; }
			set
			{
				if (Telefono != value)
				{
					_Telefono = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:EMAIL
		/// Tipo sul db:VARCHAR(200)
		/// </summary>
		public NullTypes.StringNT Email
		{
			get { return _Email; }
			set
			{
				if (Email != value)
				{
					_Email = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PEC
		/// Tipo sul db:VARCHAR(200)
		/// </summary>
		public NullTypes.StringNT Pec
		{
			get { return _Pec; }
			set
			{
				if (Pec != value)
				{
					_Pec = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NOMINATIVO_RAPPRESENTANTE_LEGALE
		/// Tipo sul db:VARCHAR(250)
		/// </summary>
		public NullTypes.StringNT NominativoRappresentanteLegale
		{
			get { return _NominativoRappresentanteLegale; }
			set
			{
				if (NominativoRappresentanteLegale != value)
				{
					_NominativoRappresentanteLegale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CF_RAPPRESENTANTE_LEGALE
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT CfRappresentanteLegale
		{
			get { return _CfRappresentanteLegale; }
			set
			{
				if (CfRappresentanteLegale != value)
				{
					_CfRappresentanteLegale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_DI_NASCITA_RAPPRESENTANTE_LEGALE
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataDiNascitaRappresentanteLegale
		{
			get { return _DataDiNascitaRappresentanteLegale; }
			set
			{
				if (DataDiNascitaRappresentanteLegale != value)
				{
					_DataDiNascitaRappresentanteLegale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COMUNE_NASCITA_RAPPRESENTANTE_LEGALE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT ComuneNascitaRappresentanteLegale
		{
			get { return _ComuneNascitaRappresentanteLegale; }
			set
			{
				if (ComuneNascitaRappresentanteLegale != value)
				{
					_ComuneNascitaRappresentanteLegale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DENOMINAZIONE_COMUNE_NASCITA_RAPPRESENTANTE_LEGALE
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT DenominazioneComuneNascitaRappresentanteLegale
		{
			get { return _DenominazioneComuneNascitaRappresentanteLegale; }
			set
			{
				if (DenominazioneComuneNascitaRappresentanteLegale != value)
				{
					_DenominazioneComuneNascitaRappresentanteLegale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PROVINCIA_NASCITA_RAPPRESENTANTE_LEGALE
		/// Tipo sul db:CHAR(2)
		/// </summary>
		public NullTypes.StringNT ProvinciaNascitaRappresentanteLegale
		{
			get { return _ProvinciaNascitaRappresentanteLegale; }
			set
			{
				if (ProvinciaNascitaRappresentanteLegale != value)
				{
					_ProvinciaNascitaRappresentanteLegale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CAP_COMUNE_NASCITA_RAPPRESENTANTE_LEGALE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT CapComuneNascitaRappresentanteLegale
		{
			get { return _CapComuneNascitaRappresentanteLegale; }
			set
			{
				if (CapComuneNascitaRappresentanteLegale != value)
				{
					_CapComuneNascitaRappresentanteLegale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IBAN
		/// Tipo sul db:VARCHAR(27)
		/// </summary>
		public NullTypes.StringNT Iban
		{
			get { return _Iban; }
			set
			{
				if (Iban != value)
				{
					_Iban = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CONTATTO_NOMINATIVO
		/// Tipo sul db:VARCHAR(250)
		/// </summary>
		public NullTypes.StringNT ContattoNominativo
		{
			get { return _ContattoNominativo; }
			set
			{
				if (ContattoNominativo != value)
				{
					_ContattoNominativo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CONTATTO_EMAIL
		/// Tipo sul db:VARCHAR(200)
		/// </summary>
		public NullTypes.StringNT ContattoEmail
		{
			get { return _ContattoEmail; }
			set
			{
				if (ContattoEmail != value)
				{
					_ContattoEmail = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CONTATTO_PEC
		/// Tipo sul db:VARCHAR(200)
		/// </summary>
		public NullTypes.StringNT ContattoPec
		{
			get { return _ContattoPec; }
			set
			{
				if (ContattoPec != value)
				{
					_ContattoPec = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CONTATTO_TELEFONO
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT ContattoTelefono
		{
			get { return _ContattoTelefono; }
			set
			{
				if (ContattoTelefono != value)
				{
					_ContattoTelefono = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CONTATTO_SITO_WEB
		/// Tipo sul db:VARCHAR(500)
		/// </summary>
		public NullTypes.StringNT ContattoSitoWeb
		{
			get { return _ContattoSitoWeb; }
			set
			{
				if (ContattoSitoWeb != value)
				{
					_ContattoSitoWeb = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:LOCALIZZAZIONE_COMUNE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT LocalizzazioneComune
		{
			get { return _LocalizzazioneComune; }
			set
			{
				if (LocalizzazioneComune != value)
				{
					_LocalizzazioneComune = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:LOCALIZZAZIONE_PROVINCIA
		/// Tipo sul db:CHAR(2)
		/// </summary>
		public NullTypes.StringNT LocalizzazioneProvincia
		{
			get { return _LocalizzazioneProvincia; }
			set
			{
				if (LocalizzazioneProvincia != value)
				{
					_LocalizzazioneProvincia = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:LOCALIZZAZIONE_CAP
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT LocalizzazioneCap
		{
			get { return _LocalizzazioneCap; }
			set
			{
				if (LocalizzazioneCap != value)
				{
					_LocalizzazioneCap = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:LOCALIZZAZIONE_VIA
		/// Tipo sul db:VARCHAR(500)
		/// </summary>
		public NullTypes.StringNT LocalizzazioneVia
		{
			get { return _LocalizzazioneVia; }
			set
			{
				if (LocalizzazioneVia != value)
				{
					_LocalizzazioneVia = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:MARCA_BOLLO_DATA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT MarcaBolloData
		{
			get { return _MarcaBolloData; }
			set
			{
				if (MarcaBolloData != value)
				{
					_MarcaBolloData = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:MARCA_BOLLO_ESTREMI
		/// Tipo sul db:VARCHAR(14)
		/// </summary>
		public NullTypes.StringNT MarcaBolloEstremi
		{
			get { return _MarcaBolloEstremi; }
			set
			{
				if (MarcaBolloEstremi != value)
				{
					_MarcaBolloEstremi = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DEFINITIVA
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Definitiva
		{
			get { return _Definitiva; }
			set
			{
				if (Definitiva != value)
				{
					_Definitiva = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_DEFINITIVA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataDefinitiva
		{
			get { return _DataDefinitiva; }
			set
			{
				if (DataDefinitiva != value)
				{
					_DataDefinitiva = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_FILE_DOMANDA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdFileDomanda
		{
			get { return _IdFileDomanda; }
			set
			{
				if (IdFileDomanda != value)
				{
					_IdFileDomanda = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TOKEN_COHESION
		/// Tipo sul db:XML
		/// </summary>
		public NullTypes.StringNT TokenCohesion
		{
			get { return _TokenCohesion; }
			set
			{
				if (TokenCohesion != value)
				{
					_TokenCohesion = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:FLAG_DELEGATO_ABILITATO_SIGEF
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT FlagDelegatoAbilitatoSigef
		{
			get { return _FlagDelegatoAbilitatoSigef; }
			set
			{
				if (FlagDelegatoAbilitatoSigef != value)
				{
					_FlagDelegatoAbilitatoSigef = value;
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

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for CovidAutodichiarazioneCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class CovidAutodichiarazioneCollection : CustomCollection, System.Runtime.Serialization.ISerializable
	{

		//Serializzazione xml
		public void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
		{
			info.AddValue("_count", this.Count);
			for (int i = 0; i < this.Count; i++)
			{
				info.AddValue(i.ToString(), this[i]);
			}
		}
		private CovidAutodichiarazioneCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : this()
		{
			int c = info.GetInt32("_count");
			for (int i = 0; i < c; i++)
			{
				this.Add((CovidAutodichiarazione)info.GetValue(i.ToString(), typeof(CovidAutodichiarazione)));
			}
		}

		//Costruttore
		public CovidAutodichiarazioneCollection()
		{
			this.ItemType = typeof(CovidAutodichiarazione);
		}

		//Costruttore con provider
		public CovidAutodichiarazioneCollection(ICovidAutodichiarazioneProvider providerObj)
		{
			this.ItemType = typeof(CovidAutodichiarazione);
			this.Provider = providerObj;
		}

		//Get e Set
		public new CovidAutodichiarazione this[int index]
		{
			get { return (CovidAutodichiarazione)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new CovidAutodichiarazioneCollection GetChanges()
		{
			return (CovidAutodichiarazioneCollection)base.GetChanges();
		}

		[NonSerialized] private ICovidAutodichiarazioneProvider _provider;
		[System.Xml.Serialization.XmlIgnore]
		public ICovidAutodichiarazioneProvider Provider
		{
			get { return _provider; }
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
		public int Add(CovidAutodichiarazione CovidAutodichiarazioneObj)
		{
			if (CovidAutodichiarazioneObj.Provider == null) CovidAutodichiarazioneObj.Provider = this.Provider;
			return base.Add(CovidAutodichiarazioneObj);
		}

		//AddCollection
		public void AddCollection(CovidAutodichiarazioneCollection CovidAutodichiarazioneCollectionObj)
		{
			foreach (CovidAutodichiarazione CovidAutodichiarazioneObj in CovidAutodichiarazioneCollectionObj)
				this.Add(CovidAutodichiarazioneObj);
		}

		//Insert
		public void Insert(int index, CovidAutodichiarazione CovidAutodichiarazioneObj)
		{
			if (CovidAutodichiarazioneObj.Provider == null) CovidAutodichiarazioneObj.Provider = this.Provider;
			base.Insert(index, CovidAutodichiarazioneObj);
		}

		//CollectionGetById
		public CovidAutodichiarazione CollectionGetById(NullTypes.IntNT IdValue)
		{
			int i = 0;
			bool find = false;
			while ((i < this.Count) && (!find))
			{
				if ((this[i].Id == IdValue))
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
		public CovidAutodichiarazioneCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.IntNT OperatoreInserimentoEqualThis, NullTypes.DatetimeNT DataInserimentoEqualThis,
NullTypes.DatetimeNT DataModificaEqualThis, NullTypes.IntNT IdProgettoEqualThis, NullTypes.IntNT IdBandoEqualThis,
NullTypes.IntNT IdImpresaEqualThis, NullTypes.StringNT CodiceFiscaleEqualThis, NullTypes.StringNT PartitaIvaEqualThis,
NullTypes.DatetimeNT DataInizioAttivitaEqualThis, NullTypes.StringNT RagioneSocialeEqualThis, NullTypes.StringNT FormaGiuridicaEqualThis,
NullTypes.StringNT CodiceAtecoEqualThis, NullTypes.IntNT DimensioneImpresaEqualThis, NullTypes.StringNT NumeroRegistroImpreseEqualThis,
NullTypes.StringNT NumeroReaEqualThis, NullTypes.IntNT AnnoReaEqualThis, NullTypes.StringNT IndirizzoSedeLegaleEqualThis,
NullTypes.IntNT ComuneEqualThis, NullTypes.StringNT DenominazioneComuneEqualThis, NullTypes.StringNT ProvinciaEqualThis,
NullTypes.IntNT CapEqualThis, NullTypes.StringNT TelefonoEqualThis, NullTypes.StringNT EmailEqualThis,
NullTypes.StringNT PecEqualThis, NullTypes.StringNT NominativoRappresentanteLegaleEqualThis, NullTypes.StringNT CfRappresentanteLegaleEqualThis,
NullTypes.DatetimeNT DataDiNascitaRappresentanteLegaleEqualThis, NullTypes.IntNT ComuneNascitaRappresentanteLegaleEqualThis, NullTypes.StringNT DenominazioneComuneNascitaRappresentanteLegaleEqualThis,
NullTypes.StringNT ProvinciaNascitaRappresentanteLegaleEqualThis, NullTypes.IntNT CapComuneNascitaRappresentanteLegaleEqualThis, NullTypes.StringNT IbanEqualThis,
NullTypes.StringNT ContattoNominativoEqualThis, NullTypes.StringNT ContattoEmailEqualThis, NullTypes.StringNT ContattoPecEqualThis,
NullTypes.StringNT ContattoTelefonoEqualThis, NullTypes.StringNT ContattoSitoWebEqualThis, NullTypes.IntNT LocalizzazioneComuneEqualThis,
NullTypes.StringNT LocalizzazioneProvinciaEqualThis, NullTypes.IntNT LocalizzazioneCapEqualThis, NullTypes.StringNT LocalizzazioneViaEqualThis,
NullTypes.DatetimeNT MarcaBolloDataEqualThis, NullTypes.StringNT MarcaBolloEstremiEqualThis, NullTypes.BoolNT DefinitivaEqualThis,
NullTypes.DatetimeNT DataDefinitivaEqualThis, NullTypes.IntNT IdFileDomandaEqualThis, NullTypes.BoolNT FlagDelegatoAbilitatoSigefEqualThis)
		{
			CovidAutodichiarazioneCollection CovidAutodichiarazioneCollectionTemp = new CovidAutodichiarazioneCollection();
			foreach (CovidAutodichiarazione CovidAutodichiarazioneItem in this)
			{
				if (((IdEqualThis == null) || ((CovidAutodichiarazioneItem.Id != null) && (CovidAutodichiarazioneItem.Id.Value == IdEqualThis.Value))) && ((OperatoreInserimentoEqualThis == null) || ((CovidAutodichiarazioneItem.OperatoreInserimento != null) && (CovidAutodichiarazioneItem.OperatoreInserimento.Value == OperatoreInserimentoEqualThis.Value))) && ((DataInserimentoEqualThis == null) || ((CovidAutodichiarazioneItem.DataInserimento != null) && (CovidAutodichiarazioneItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) &&
((DataModificaEqualThis == null) || ((CovidAutodichiarazioneItem.DataModifica != null) && (CovidAutodichiarazioneItem.DataModifica.Value == DataModificaEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((CovidAutodichiarazioneItem.IdProgetto != null) && (CovidAutodichiarazioneItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((IdBandoEqualThis == null) || ((CovidAutodichiarazioneItem.IdBando != null) && (CovidAutodichiarazioneItem.IdBando.Value == IdBandoEqualThis.Value))) &&
((IdImpresaEqualThis == null) || ((CovidAutodichiarazioneItem.IdImpresa != null) && (CovidAutodichiarazioneItem.IdImpresa.Value == IdImpresaEqualThis.Value))) && ((CodiceFiscaleEqualThis == null) || ((CovidAutodichiarazioneItem.CodiceFiscale != null) && (CovidAutodichiarazioneItem.CodiceFiscale.Value == CodiceFiscaleEqualThis.Value))) && ((PartitaIvaEqualThis == null) || ((CovidAutodichiarazioneItem.PartitaIva != null) && (CovidAutodichiarazioneItem.PartitaIva.Value == PartitaIvaEqualThis.Value))) &&
((DataInizioAttivitaEqualThis == null) || ((CovidAutodichiarazioneItem.DataInizioAttivita != null) && (CovidAutodichiarazioneItem.DataInizioAttivita.Value == DataInizioAttivitaEqualThis.Value))) && ((RagioneSocialeEqualThis == null) || ((CovidAutodichiarazioneItem.RagioneSociale != null) && (CovidAutodichiarazioneItem.RagioneSociale.Value == RagioneSocialeEqualThis.Value))) && ((FormaGiuridicaEqualThis == null) || ((CovidAutodichiarazioneItem.FormaGiuridica != null) && (CovidAutodichiarazioneItem.FormaGiuridica.Value == FormaGiuridicaEqualThis.Value))) &&
((CodiceAtecoEqualThis == null) || ((CovidAutodichiarazioneItem.CodiceAteco != null) && (CovidAutodichiarazioneItem.CodiceAteco.Value == CodiceAtecoEqualThis.Value))) && ((DimensioneImpresaEqualThis == null) || ((CovidAutodichiarazioneItem.DimensioneImpresa != null) && (CovidAutodichiarazioneItem.DimensioneImpresa.Value == DimensioneImpresaEqualThis.Value))) && ((NumeroRegistroImpreseEqualThis == null) || ((CovidAutodichiarazioneItem.NumeroRegistroImprese != null) && (CovidAutodichiarazioneItem.NumeroRegistroImprese.Value == NumeroRegistroImpreseEqualThis.Value))) &&
((NumeroReaEqualThis == null) || ((CovidAutodichiarazioneItem.NumeroRea != null) && (CovidAutodichiarazioneItem.NumeroRea.Value == NumeroReaEqualThis.Value))) && ((AnnoReaEqualThis == null) || ((CovidAutodichiarazioneItem.AnnoRea != null) && (CovidAutodichiarazioneItem.AnnoRea.Value == AnnoReaEqualThis.Value))) && ((IndirizzoSedeLegaleEqualThis == null) || ((CovidAutodichiarazioneItem.IndirizzoSedeLegale != null) && (CovidAutodichiarazioneItem.IndirizzoSedeLegale.Value == IndirizzoSedeLegaleEqualThis.Value))) &&
((ComuneEqualThis == null) || ((CovidAutodichiarazioneItem.Comune != null) && (CovidAutodichiarazioneItem.Comune.Value == ComuneEqualThis.Value))) && ((DenominazioneComuneEqualThis == null) || ((CovidAutodichiarazioneItem.DenominazioneComune != null) && (CovidAutodichiarazioneItem.DenominazioneComune.Value == DenominazioneComuneEqualThis.Value))) && ((ProvinciaEqualThis == null) || ((CovidAutodichiarazioneItem.Provincia != null) && (CovidAutodichiarazioneItem.Provincia.Value == ProvinciaEqualThis.Value))) &&
((CapEqualThis == null) || ((CovidAutodichiarazioneItem.Cap != null) && (CovidAutodichiarazioneItem.Cap.Value == CapEqualThis.Value))) && ((TelefonoEqualThis == null) || ((CovidAutodichiarazioneItem.Telefono != null) && (CovidAutodichiarazioneItem.Telefono.Value == TelefonoEqualThis.Value))) && ((EmailEqualThis == null) || ((CovidAutodichiarazioneItem.Email != null) && (CovidAutodichiarazioneItem.Email.Value == EmailEqualThis.Value))) &&
((PecEqualThis == null) || ((CovidAutodichiarazioneItem.Pec != null) && (CovidAutodichiarazioneItem.Pec.Value == PecEqualThis.Value))) && ((NominativoRappresentanteLegaleEqualThis == null) || ((CovidAutodichiarazioneItem.NominativoRappresentanteLegale != null) && (CovidAutodichiarazioneItem.NominativoRappresentanteLegale.Value == NominativoRappresentanteLegaleEqualThis.Value))) && ((CfRappresentanteLegaleEqualThis == null) || ((CovidAutodichiarazioneItem.CfRappresentanteLegale != null) && (CovidAutodichiarazioneItem.CfRappresentanteLegale.Value == CfRappresentanteLegaleEqualThis.Value))) &&
((DataDiNascitaRappresentanteLegaleEqualThis == null) || ((CovidAutodichiarazioneItem.DataDiNascitaRappresentanteLegale != null) && (CovidAutodichiarazioneItem.DataDiNascitaRappresentanteLegale.Value == DataDiNascitaRappresentanteLegaleEqualThis.Value))) && ((ComuneNascitaRappresentanteLegaleEqualThis == null) || ((CovidAutodichiarazioneItem.ComuneNascitaRappresentanteLegale != null) && (CovidAutodichiarazioneItem.ComuneNascitaRappresentanteLegale.Value == ComuneNascitaRappresentanteLegaleEqualThis.Value))) && ((DenominazioneComuneNascitaRappresentanteLegaleEqualThis == null) || ((CovidAutodichiarazioneItem.DenominazioneComuneNascitaRappresentanteLegale != null) && (CovidAutodichiarazioneItem.DenominazioneComuneNascitaRappresentanteLegale.Value == DenominazioneComuneNascitaRappresentanteLegaleEqualThis.Value))) &&
((ProvinciaNascitaRappresentanteLegaleEqualThis == null) || ((CovidAutodichiarazioneItem.ProvinciaNascitaRappresentanteLegale != null) && (CovidAutodichiarazioneItem.ProvinciaNascitaRappresentanteLegale.Value == ProvinciaNascitaRappresentanteLegaleEqualThis.Value))) && ((CapComuneNascitaRappresentanteLegaleEqualThis == null) || ((CovidAutodichiarazioneItem.CapComuneNascitaRappresentanteLegale != null) && (CovidAutodichiarazioneItem.CapComuneNascitaRappresentanteLegale.Value == CapComuneNascitaRappresentanteLegaleEqualThis.Value))) && ((IbanEqualThis == null) || ((CovidAutodichiarazioneItem.Iban != null) && (CovidAutodichiarazioneItem.Iban.Value == IbanEqualThis.Value))) &&
((ContattoNominativoEqualThis == null) || ((CovidAutodichiarazioneItem.ContattoNominativo != null) && (CovidAutodichiarazioneItem.ContattoNominativo.Value == ContattoNominativoEqualThis.Value))) && ((ContattoEmailEqualThis == null) || ((CovidAutodichiarazioneItem.ContattoEmail != null) && (CovidAutodichiarazioneItem.ContattoEmail.Value == ContattoEmailEqualThis.Value))) && ((ContattoPecEqualThis == null) || ((CovidAutodichiarazioneItem.ContattoPec != null) && (CovidAutodichiarazioneItem.ContattoPec.Value == ContattoPecEqualThis.Value))) &&
((ContattoTelefonoEqualThis == null) || ((CovidAutodichiarazioneItem.ContattoTelefono != null) && (CovidAutodichiarazioneItem.ContattoTelefono.Value == ContattoTelefonoEqualThis.Value))) && ((ContattoSitoWebEqualThis == null) || ((CovidAutodichiarazioneItem.ContattoSitoWeb != null) && (CovidAutodichiarazioneItem.ContattoSitoWeb.Value == ContattoSitoWebEqualThis.Value))) && ((LocalizzazioneComuneEqualThis == null) || ((CovidAutodichiarazioneItem.LocalizzazioneComune != null) && (CovidAutodichiarazioneItem.LocalizzazioneComune.Value == LocalizzazioneComuneEqualThis.Value))) &&
((LocalizzazioneProvinciaEqualThis == null) || ((CovidAutodichiarazioneItem.LocalizzazioneProvincia != null) && (CovidAutodichiarazioneItem.LocalizzazioneProvincia.Value == LocalizzazioneProvinciaEqualThis.Value))) && ((LocalizzazioneCapEqualThis == null) || ((CovidAutodichiarazioneItem.LocalizzazioneCap != null) && (CovidAutodichiarazioneItem.LocalizzazioneCap.Value == LocalizzazioneCapEqualThis.Value))) && ((LocalizzazioneViaEqualThis == null) || ((CovidAutodichiarazioneItem.LocalizzazioneVia != null) && (CovidAutodichiarazioneItem.LocalizzazioneVia.Value == LocalizzazioneViaEqualThis.Value))) &&
((MarcaBolloDataEqualThis == null) || ((CovidAutodichiarazioneItem.MarcaBolloData != null) && (CovidAutodichiarazioneItem.MarcaBolloData.Value == MarcaBolloDataEqualThis.Value))) && ((MarcaBolloEstremiEqualThis == null) || ((CovidAutodichiarazioneItem.MarcaBolloEstremi != null) && (CovidAutodichiarazioneItem.MarcaBolloEstremi.Value == MarcaBolloEstremiEqualThis.Value))) && ((DefinitivaEqualThis == null) || ((CovidAutodichiarazioneItem.Definitiva != null) && (CovidAutodichiarazioneItem.Definitiva.Value == DefinitivaEqualThis.Value))) &&
((DataDefinitivaEqualThis == null) || ((CovidAutodichiarazioneItem.DataDefinitiva != null) && (CovidAutodichiarazioneItem.DataDefinitiva.Value == DataDefinitivaEqualThis.Value))) && ((IdFileDomandaEqualThis == null) || ((CovidAutodichiarazioneItem.IdFileDomanda != null) && (CovidAutodichiarazioneItem.IdFileDomanda.Value == IdFileDomandaEqualThis.Value))) && ((FlagDelegatoAbilitatoSigefEqualThis == null) || ((CovidAutodichiarazioneItem.FlagDelegatoAbilitatoSigef != null) && (CovidAutodichiarazioneItem.FlagDelegatoAbilitatoSigef.Value == FlagDelegatoAbilitatoSigefEqualThis.Value))))
				{
					CovidAutodichiarazioneCollectionTemp.Add(CovidAutodichiarazioneItem);
				}
			}
			return CovidAutodichiarazioneCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public CovidAutodichiarazioneCollection Filter(NullTypes.IntNT OperatoreInserimentoEqualThis, NullTypes.StringNT FormaGiuridicaEqualThis, NullTypes.StringNT CodiceAtecoEqualThis,
NullTypes.IntNT DimensioneImpresaEqualThis, NullTypes.IntNT ComuneEqualThis)
		{
			CovidAutodichiarazioneCollection CovidAutodichiarazioneCollectionTemp = new CovidAutodichiarazioneCollection();
			foreach (CovidAutodichiarazione CovidAutodichiarazioneItem in this)
			{
				if (((OperatoreInserimentoEqualThis == null) || ((CovidAutodichiarazioneItem.OperatoreInserimento != null) && (CovidAutodichiarazioneItem.OperatoreInserimento.Value == OperatoreInserimentoEqualThis.Value))) && ((FormaGiuridicaEqualThis == null) || ((CovidAutodichiarazioneItem.FormaGiuridica != null) && (CovidAutodichiarazioneItem.FormaGiuridica.Value == FormaGiuridicaEqualThis.Value))) && ((CodiceAtecoEqualThis == null) || ((CovidAutodichiarazioneItem.CodiceAteco != null) && (CovidAutodichiarazioneItem.CodiceAteco.Value == CodiceAtecoEqualThis.Value))) &&
((DimensioneImpresaEqualThis == null) || ((CovidAutodichiarazioneItem.DimensioneImpresa != null) && (CovidAutodichiarazioneItem.DimensioneImpresa.Value == DimensioneImpresaEqualThis.Value))) && ((ComuneEqualThis == null) || ((CovidAutodichiarazioneItem.Comune != null) && (CovidAutodichiarazioneItem.Comune.Value == ComuneEqualThis.Value))))
				{
					CovidAutodichiarazioneCollectionTemp.Add(CovidAutodichiarazioneItem);
				}
			}
			return CovidAutodichiarazioneCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for CovidAutodichiarazioneDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class CovidAutodichiarazioneDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, CovidAutodichiarazione CovidAutodichiarazioneObj, string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd, firstChar + "Id", CovidAutodichiarazioneObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd, firstChar + "OperatoreInserimento", CovidAutodichiarazioneObj.OperatoreInserimento);
			DbProvider.SetCmdParam(cmd, firstChar + "DataInserimento", CovidAutodichiarazioneObj.DataInserimento);
			DbProvider.SetCmdParam(cmd, firstChar + "DataModifica", CovidAutodichiarazioneObj.DataModifica);
			DbProvider.SetCmdParam(cmd, firstChar + "IdProgetto", CovidAutodichiarazioneObj.IdProgetto);
			DbProvider.SetCmdParam(cmd, firstChar + "IdBando", CovidAutodichiarazioneObj.IdBando);
			DbProvider.SetCmdParam(cmd, firstChar + "IdImpresa", CovidAutodichiarazioneObj.IdImpresa);
			DbProvider.SetCmdParam(cmd, firstChar + "CodiceFiscale", CovidAutodichiarazioneObj.CodiceFiscale);
			DbProvider.SetCmdParam(cmd, firstChar + "PartitaIva", CovidAutodichiarazioneObj.PartitaIva);
			DbProvider.SetCmdParam(cmd, firstChar + "DataInizioAttivita", CovidAutodichiarazioneObj.DataInizioAttivita);
			DbProvider.SetCmdParam(cmd, firstChar + "RagioneSociale", CovidAutodichiarazioneObj.RagioneSociale);
			DbProvider.SetCmdParam(cmd, firstChar + "FormaGiuridica", CovidAutodichiarazioneObj.FormaGiuridica);
			DbProvider.SetCmdParam(cmd, firstChar + "CodiceAteco", CovidAutodichiarazioneObj.CodiceAteco);
			DbProvider.SetCmdParam(cmd, firstChar + "DimensioneImpresa", CovidAutodichiarazioneObj.DimensioneImpresa);
			DbProvider.SetCmdParam(cmd, firstChar + "NumeroRegistroImprese", CovidAutodichiarazioneObj.NumeroRegistroImprese);
			DbProvider.SetCmdParam(cmd, firstChar + "NumeroRea", CovidAutodichiarazioneObj.NumeroRea);
			DbProvider.SetCmdParam(cmd, firstChar + "AnnoRea", CovidAutodichiarazioneObj.AnnoRea);
			DbProvider.SetCmdParam(cmd, firstChar + "IndirizzoSedeLegale", CovidAutodichiarazioneObj.IndirizzoSedeLegale);
			DbProvider.SetCmdParam(cmd, firstChar + "Comune", CovidAutodichiarazioneObj.Comune);
			DbProvider.SetCmdParam(cmd, firstChar + "DenominazioneComune", CovidAutodichiarazioneObj.DenominazioneComune);
			DbProvider.SetCmdParam(cmd, firstChar + "Provincia", CovidAutodichiarazioneObj.Provincia);
			DbProvider.SetCmdParam(cmd, firstChar + "Cap", CovidAutodichiarazioneObj.Cap);
			DbProvider.SetCmdParam(cmd, firstChar + "Telefono", CovidAutodichiarazioneObj.Telefono);
			DbProvider.SetCmdParam(cmd, firstChar + "Email", CovidAutodichiarazioneObj.Email);
			DbProvider.SetCmdParam(cmd, firstChar + "Pec", CovidAutodichiarazioneObj.Pec);
			DbProvider.SetCmdParam(cmd, firstChar + "NominativoRappresentanteLegale", CovidAutodichiarazioneObj.NominativoRappresentanteLegale);
			DbProvider.SetCmdParam(cmd, firstChar + "CfRappresentanteLegale", CovidAutodichiarazioneObj.CfRappresentanteLegale);
			DbProvider.SetCmdParam(cmd, firstChar + "DataDiNascitaRappresentanteLegale", CovidAutodichiarazioneObj.DataDiNascitaRappresentanteLegale);
			DbProvider.SetCmdParam(cmd, firstChar + "ComuneNascitaRappresentanteLegale", CovidAutodichiarazioneObj.ComuneNascitaRappresentanteLegale);
			DbProvider.SetCmdParam(cmd, firstChar + "DenominazioneComuneNascitaRappresentanteLegale", CovidAutodichiarazioneObj.DenominazioneComuneNascitaRappresentanteLegale);
			DbProvider.SetCmdParam(cmd, firstChar + "ProvinciaNascitaRappresentanteLegale", CovidAutodichiarazioneObj.ProvinciaNascitaRappresentanteLegale);
			DbProvider.SetCmdParam(cmd, firstChar + "CapComuneNascitaRappresentanteLegale", CovidAutodichiarazioneObj.CapComuneNascitaRappresentanteLegale);
			DbProvider.SetCmdParam(cmd, firstChar + "Iban", CovidAutodichiarazioneObj.Iban);
			DbProvider.SetCmdParam(cmd, firstChar + "ContattoNominativo", CovidAutodichiarazioneObj.ContattoNominativo);
			DbProvider.SetCmdParam(cmd, firstChar + "ContattoEmail", CovidAutodichiarazioneObj.ContattoEmail);
			DbProvider.SetCmdParam(cmd, firstChar + "ContattoPec", CovidAutodichiarazioneObj.ContattoPec);
			DbProvider.SetCmdParam(cmd, firstChar + "ContattoTelefono", CovidAutodichiarazioneObj.ContattoTelefono);
			DbProvider.SetCmdParam(cmd, firstChar + "ContattoSitoWeb", CovidAutodichiarazioneObj.ContattoSitoWeb);
			DbProvider.SetCmdParam(cmd, firstChar + "LocalizzazioneComune", CovidAutodichiarazioneObj.LocalizzazioneComune);
			DbProvider.SetCmdParam(cmd, firstChar + "LocalizzazioneProvincia", CovidAutodichiarazioneObj.LocalizzazioneProvincia);
			DbProvider.SetCmdParam(cmd, firstChar + "LocalizzazioneCap", CovidAutodichiarazioneObj.LocalizzazioneCap);
			DbProvider.SetCmdParam(cmd, firstChar + "LocalizzazioneVia", CovidAutodichiarazioneObj.LocalizzazioneVia);
			DbProvider.SetCmdParam(cmd, firstChar + "MarcaBolloData", CovidAutodichiarazioneObj.MarcaBolloData);
			DbProvider.SetCmdParam(cmd, firstChar + "MarcaBolloEstremi", CovidAutodichiarazioneObj.MarcaBolloEstremi);
			DbProvider.SetCmdParam(cmd, firstChar + "Definitiva", CovidAutodichiarazioneObj.Definitiva);
			DbProvider.SetCmdParam(cmd, firstChar + "DataDefinitiva", CovidAutodichiarazioneObj.DataDefinitiva);
			DbProvider.SetCmdParam(cmd, firstChar + "IdFileDomanda", CovidAutodichiarazioneObj.IdFileDomanda);
			DbProvider.SetCmdParam(cmd, firstChar + "TokenCohesion", CovidAutodichiarazioneObj.TokenCohesion);
			DbProvider.SetCmdParam(cmd, firstChar + "FlagDelegatoAbilitatoSigef", CovidAutodichiarazioneObj.FlagDelegatoAbilitatoSigef);
		}
		//Insert
		private static int Insert(DbProvider db, CovidAutodichiarazione CovidAutodichiarazioneObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd("ZCovidAutodichiarazioneInsert", new string[] {"OperatoreInserimento", "DataInserimento",
"DataModifica", "IdProgetto", "IdBando",
"IdImpresa", "CodiceFiscale", "PartitaIva",
"DataInizioAttivita", "RagioneSociale", "FormaGiuridica",
"CodiceAteco", "DimensioneImpresa", "NumeroRegistroImprese",
"NumeroRea", "AnnoRea", "IndirizzoSedeLegale",
"Comune", "DenominazioneComune", "Provincia",
"Cap", "Telefono", "Email",
"Pec", "NominativoRappresentanteLegale", "CfRappresentanteLegale",
"DataDiNascitaRappresentanteLegale", "ComuneNascitaRappresentanteLegale", "DenominazioneComuneNascitaRappresentanteLegale",
"ProvinciaNascitaRappresentanteLegale", "CapComuneNascitaRappresentanteLegale", "Iban",
"ContattoNominativo", "ContattoEmail", "ContattoPec",
"ContattoTelefono", "ContattoSitoWeb", "LocalizzazioneComune",
"LocalizzazioneProvincia", "LocalizzazioneCap", "LocalizzazioneVia",
"MarcaBolloData", "MarcaBolloEstremi", "Definitiva",
"DataDefinitiva", "IdFileDomanda", "TokenCohesion",
"FlagDelegatoAbilitatoSigef"}, new string[] {"int", "DateTime",
"DateTime", "int", "int",
"int", "string", "string",
"DateTime", "string", "string",
"string", "int", "string",
"string", "int", "string",
"int", "string", "string",
"int", "string", "string",
"string", "string", "string",
"DateTime", "int", "string",
"string", "int", "string",
"string", "string", "string",
"string", "string", "int",
"string", "int", "string",
"DateTime", "string", "bool",
"DateTime", "int", "string",
"bool"}, "");
				CompileIUCmd(false, insertCmd, CovidAutodichiarazioneObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
				{
					CovidAutodichiarazioneObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				}
				CovidAutodichiarazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CovidAutodichiarazioneObj.IsDirty = false;
				CovidAutodichiarazioneObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, CovidAutodichiarazione CovidAutodichiarazioneObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd("ZCovidAutodichiarazioneUpdate", new string[] {"Id", "OperatoreInserimento", "DataInserimento",
"DataModifica", "IdProgetto", "IdBando",
"IdImpresa", "CodiceFiscale", "PartitaIva",
"DataInizioAttivita", "RagioneSociale", "FormaGiuridica",
"CodiceAteco", "DimensioneImpresa", "NumeroRegistroImprese",
"NumeroRea", "AnnoRea", "IndirizzoSedeLegale",
"Comune", "DenominazioneComune", "Provincia",
"Cap", "Telefono", "Email",
"Pec", "NominativoRappresentanteLegale", "CfRappresentanteLegale",
"DataDiNascitaRappresentanteLegale", "ComuneNascitaRappresentanteLegale", "DenominazioneComuneNascitaRappresentanteLegale",
"ProvinciaNascitaRappresentanteLegale", "CapComuneNascitaRappresentanteLegale", "Iban",
"ContattoNominativo", "ContattoEmail", "ContattoPec",
"ContattoTelefono", "ContattoSitoWeb", "LocalizzazioneComune",
"LocalizzazioneProvincia", "LocalizzazioneCap", "LocalizzazioneVia",
"MarcaBolloData", "MarcaBolloEstremi", "Definitiva",
"DataDefinitiva", "IdFileDomanda", "TokenCohesion",
"FlagDelegatoAbilitatoSigef"}, new string[] {"int", "int", "DateTime",
"DateTime", "int", "int",
"int", "string", "string",
"DateTime", "string", "string",
"string", "int", "string",
"string", "int", "string",
"int", "string", "string",
"int", "string", "string",
"string", "string", "string",
"DateTime", "int", "string",
"string", "int", "string",
"string", "string", "string",
"string", "string", "int",
"string", "int", "string",
"DateTime", "string", "bool",
"DateTime", "int", "string",
"bool"}, "");
				CompileIUCmd(true, updateCmd, CovidAutodichiarazioneObj, db.CommandFirstChar);
				SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
				if (d != null)
				{
					i = 1;
					CovidAutodichiarazioneObj.DataModifica = d;
				}
				CovidAutodichiarazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CovidAutodichiarazioneObj.IsDirty = false;
				CovidAutodichiarazioneObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, CovidAutodichiarazione CovidAutodichiarazioneObj)
		{
			switch (CovidAutodichiarazioneObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added: return Insert(db, CovidAutodichiarazioneObj);
				case BaseObject.ObjectStateType.Changed: return Update(db, CovidAutodichiarazioneObj);
				case BaseObject.ObjectStateType.Deleted: return Delete(db, CovidAutodichiarazioneObj);
				default: return 0;
			}
		}

		public static int SaveCollection(DbProvider db, CovidAutodichiarazioneCollection CovidAutodichiarazioneCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd("ZCovidAutodichiarazioneUpdate", new string[] {"Id", "OperatoreInserimento", "DataInserimento",
"DataModifica", "IdProgetto", "IdBando",
"IdImpresa", "CodiceFiscale", "PartitaIva",
"DataInizioAttivita", "RagioneSociale", "FormaGiuridica",
"CodiceAteco", "DimensioneImpresa", "NumeroRegistroImprese",
"NumeroRea", "AnnoRea", "IndirizzoSedeLegale",
"Comune", "DenominazioneComune", "Provincia",
"Cap", "Telefono", "Email",
"Pec", "NominativoRappresentanteLegale", "CfRappresentanteLegale",
"DataDiNascitaRappresentanteLegale", "ComuneNascitaRappresentanteLegale", "DenominazioneComuneNascitaRappresentanteLegale",
"ProvinciaNascitaRappresentanteLegale", "CapComuneNascitaRappresentanteLegale", "Iban",
"ContattoNominativo", "ContattoEmail", "ContattoPec",
"ContattoTelefono", "ContattoSitoWeb", "LocalizzazioneComune",
"LocalizzazioneProvincia", "LocalizzazioneCap", "LocalizzazioneVia",
"MarcaBolloData", "MarcaBolloEstremi", "Definitiva",
"DataDefinitiva", "IdFileDomanda", "TokenCohesion",
"FlagDelegatoAbilitatoSigef"}, new string[] {"int", "int", "DateTime",
"DateTime", "int", "int",
"int", "string", "string",
"DateTime", "string", "string",
"string", "int", "string",
"string", "int", "string",
"int", "string", "string",
"int", "string", "string",
"string", "string", "string",
"DateTime", "int", "string",
"string", "int", "string",
"string", "string", "string",
"string", "string", "int",
"string", "int", "string",
"DateTime", "string", "bool",
"DateTime", "int", "string",
"bool"}, "");
				IDbCommand insertCmd = db.InitCmd("ZCovidAutodichiarazioneInsert", new string[] {"OperatoreInserimento", "DataInserimento",
"DataModifica", "IdProgetto", "IdBando",
"IdImpresa", "CodiceFiscale", "PartitaIva",
"DataInizioAttivita", "RagioneSociale", "FormaGiuridica",
"CodiceAteco", "DimensioneImpresa", "NumeroRegistroImprese",
"NumeroRea", "AnnoRea", "IndirizzoSedeLegale",
"Comune", "DenominazioneComune", "Provincia",
"Cap", "Telefono", "Email",
"Pec", "NominativoRappresentanteLegale", "CfRappresentanteLegale",
"DataDiNascitaRappresentanteLegale", "ComuneNascitaRappresentanteLegale", "DenominazioneComuneNascitaRappresentanteLegale",
"ProvinciaNascitaRappresentanteLegale", "CapComuneNascitaRappresentanteLegale", "Iban",
"ContattoNominativo", "ContattoEmail", "ContattoPec",
"ContattoTelefono", "ContattoSitoWeb", "LocalizzazioneComune",
"LocalizzazioneProvincia", "LocalizzazioneCap", "LocalizzazioneVia",
"MarcaBolloData", "MarcaBolloEstremi", "Definitiva",
"DataDefinitiva", "IdFileDomanda", "TokenCohesion",
"FlagDelegatoAbilitatoSigef"}, new string[] {"int", "DateTime",
"DateTime", "int", "int",
"int", "string", "string",
"DateTime", "string", "string",
"string", "int", "string",
"string", "int", "string",
"int", "string", "string",
"int", "string", "string",
"string", "string", "string",
"DateTime", "int", "string",
"string", "int", "string",
"string", "string", "string",
"string", "string", "int",
"string", "int", "string",
"DateTime", "string", "bool",
"DateTime", "int", "string",
"bool"}, "");
				IDbCommand deleteCmd = db.InitCmd("ZCovidAutodichiarazioneDelete", new string[] { "Id" }, new string[] { "int" }, "");
				for (int i = 0; i < CovidAutodichiarazioneCollectionObj.Count; i++)
				{
					switch (CovidAutodichiarazioneCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added:
							{
								CompileIUCmd(false, insertCmd, CovidAutodichiarazioneCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									CovidAutodichiarazioneCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed:
							{
								CompileIUCmd(true, updateCmd, CovidAutodichiarazioneCollectionObj[i], db.CommandFirstChar);
								SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
								if (d != null)
								{
									returnValue++;
									CovidAutodichiarazioneCollectionObj[i].DataModifica = d;
								}
							}
							break;
						case BaseObject.ObjectStateType.Deleted:
							{
								if (CovidAutodichiarazioneCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)CovidAutodichiarazioneCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < CovidAutodichiarazioneCollectionObj.Count; i++)
				{
					if ((CovidAutodichiarazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CovidAutodichiarazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						CovidAutodichiarazioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						CovidAutodichiarazioneCollectionObj[i].IsDirty = false;
						CovidAutodichiarazioneCollectionObj[i].IsPersistent = true;
					}
					if ((CovidAutodichiarazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						CovidAutodichiarazioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						CovidAutodichiarazioneCollectionObj[i].IsDirty = false;
						CovidAutodichiarazioneCollectionObj[i].IsPersistent = false;
					}
				}
			}
			catch
			{
				db.Rollback();
				throw;
			}
			finally
			{
				db.Close();
			}
			return returnValue;
		}

		//Delete
		public static int Delete(DbProvider db, CovidAutodichiarazione CovidAutodichiarazioneObj)
		{
			int returnValue = 0;
			if (CovidAutodichiarazioneObj.IsPersistent)
			{
				returnValue = Delete(db, CovidAutodichiarazioneObj.Id);
			}
			CovidAutodichiarazioneObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			CovidAutodichiarazioneObj.IsDirty = false;
			CovidAutodichiarazioneObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd("ZCovidAutodichiarazioneDelete", new string[] { "Id" }, new string[] { "int" }, "");
				DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, CovidAutodichiarazioneCollection CovidAutodichiarazioneCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd("ZCovidAutodichiarazioneDelete", new string[] { "Id" }, new string[] { "int" }, "");
				for (int i = 0; i < CovidAutodichiarazioneCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "Id", CovidAutodichiarazioneCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < CovidAutodichiarazioneCollectionObj.Count; i++)
				{
					if ((CovidAutodichiarazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CovidAutodichiarazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						CovidAutodichiarazioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						CovidAutodichiarazioneCollectionObj[i].IsDirty = false;
						CovidAutodichiarazioneCollectionObj[i].IsPersistent = false;
					}
				}
			}
			catch
			{
				db.Rollback();
				throw;
			}
			finally
			{
				db.Close();
			}
			return returnValue;
		}

		//getById
		public static CovidAutodichiarazione GetById(DbProvider db, int IdValue)
		{
			CovidAutodichiarazione CovidAutodichiarazioneObj = null;
			IDbCommand readCmd = db.InitCmd("ZCovidAutodichiarazioneGetById", new string[] { "Id" }, new string[] { "int" }, "");
			DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				CovidAutodichiarazioneObj = GetFromDatareader(db);
				CovidAutodichiarazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CovidAutodichiarazioneObj.IsDirty = false;
				CovidAutodichiarazioneObj.IsPersistent = true;
			}
			db.Close();
			return CovidAutodichiarazioneObj;
		}

		//getFromDatareader
		public static CovidAutodichiarazione GetFromDatareader(DbProvider db)
		{
			CovidAutodichiarazione CovidAutodichiarazioneObj = new CovidAutodichiarazione();
			CovidAutodichiarazioneObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			CovidAutodichiarazioneObj.OperatoreInserimento = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE_INSERIMENTO"]);
			CovidAutodichiarazioneObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
			CovidAutodichiarazioneObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
			CovidAutodichiarazioneObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			CovidAutodichiarazioneObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
			CovidAutodichiarazioneObj.IdImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA"]);
			CovidAutodichiarazioneObj.CodiceFiscale = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE_FISCALE"]);
			CovidAutodichiarazioneObj.PartitaIva = new SiarLibrary.NullTypes.StringNT(db.DataReader["PARTITA_IVA"]);
			CovidAutodichiarazioneObj.DataInizioAttivita = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INIZIO_ATTIVITA"]);
			CovidAutodichiarazioneObj.RagioneSociale = new SiarLibrary.NullTypes.StringNT(db.DataReader["RAGIONE_SOCIALE"]);
			CovidAutodichiarazioneObj.FormaGiuridica = new SiarLibrary.NullTypes.StringNT(db.DataReader["FORMA_GIURIDICA"]);
			CovidAutodichiarazioneObj.CodiceAteco = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE_ATECO"]);
			CovidAutodichiarazioneObj.DimensioneImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["DIMENSIONE_IMPRESA"]);
			CovidAutodichiarazioneObj.NumeroRegistroImprese = new SiarLibrary.NullTypes.StringNT(db.DataReader["NUMERO_REGISTRO_IMPRESE"]);
			CovidAutodichiarazioneObj.NumeroRea = new SiarLibrary.NullTypes.StringNT(db.DataReader["NUMERO_REA"]);
			CovidAutodichiarazioneObj.AnnoRea = new SiarLibrary.NullTypes.IntNT(db.DataReader["ANNO_REA"]);
			CovidAutodichiarazioneObj.IndirizzoSedeLegale = new SiarLibrary.NullTypes.StringNT(db.DataReader["INDIRIZZO_SEDE_LEGALE"]);
			CovidAutodichiarazioneObj.Comune = new SiarLibrary.NullTypes.IntNT(db.DataReader["COMUNE"]);
			CovidAutodichiarazioneObj.DenominazioneComune = new SiarLibrary.NullTypes.StringNT(db.DataReader["DENOMINAZIONE_COMUNE"]);
			CovidAutodichiarazioneObj.Provincia = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROVINCIA"]);
			CovidAutodichiarazioneObj.Cap = new SiarLibrary.NullTypes.IntNT(db.DataReader["CAP"]);
			CovidAutodichiarazioneObj.Telefono = new SiarLibrary.NullTypes.StringNT(db.DataReader["TELEFONO"]);
			CovidAutodichiarazioneObj.Email = new SiarLibrary.NullTypes.StringNT(db.DataReader["EMAIL"]);
			CovidAutodichiarazioneObj.Pec = new SiarLibrary.NullTypes.StringNT(db.DataReader["PEC"]);
			CovidAutodichiarazioneObj.NominativoRappresentanteLegale = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOMINATIVO_RAPPRESENTANTE_LEGALE"]);
			CovidAutodichiarazioneObj.CfRappresentanteLegale = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_RAPPRESENTANTE_LEGALE"]);
			CovidAutodichiarazioneObj.DataDiNascitaRappresentanteLegale = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_DI_NASCITA_RAPPRESENTANTE_LEGALE"]);
			CovidAutodichiarazioneObj.ComuneNascitaRappresentanteLegale = new SiarLibrary.NullTypes.IntNT(db.DataReader["COMUNE_NASCITA_RAPPRESENTANTE_LEGALE"]);
			CovidAutodichiarazioneObj.DenominazioneComuneNascitaRappresentanteLegale = new SiarLibrary.NullTypes.StringNT(db.DataReader["DENOMINAZIONE_COMUNE_NASCITA_RAPPRESENTANTE_LEGALE"]);
			CovidAutodichiarazioneObj.ProvinciaNascitaRappresentanteLegale = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROVINCIA_NASCITA_RAPPRESENTANTE_LEGALE"]);
			CovidAutodichiarazioneObj.CapComuneNascitaRappresentanteLegale = new SiarLibrary.NullTypes.IntNT(db.DataReader["CAP_COMUNE_NASCITA_RAPPRESENTANTE_LEGALE"]);
			CovidAutodichiarazioneObj.Iban = new SiarLibrary.NullTypes.StringNT(db.DataReader["IBAN"]);
			CovidAutodichiarazioneObj.ContattoNominativo = new SiarLibrary.NullTypes.StringNT(db.DataReader["CONTATTO_NOMINATIVO"]);
			CovidAutodichiarazioneObj.ContattoEmail = new SiarLibrary.NullTypes.StringNT(db.DataReader["CONTATTO_EMAIL"]);
			CovidAutodichiarazioneObj.ContattoPec = new SiarLibrary.NullTypes.StringNT(db.DataReader["CONTATTO_PEC"]);
			CovidAutodichiarazioneObj.ContattoTelefono = new SiarLibrary.NullTypes.StringNT(db.DataReader["CONTATTO_TELEFONO"]);
			CovidAutodichiarazioneObj.ContattoSitoWeb = new SiarLibrary.NullTypes.StringNT(db.DataReader["CONTATTO_SITO_WEB"]);
			CovidAutodichiarazioneObj.LocalizzazioneComune = new SiarLibrary.NullTypes.IntNT(db.DataReader["LOCALIZZAZIONE_COMUNE"]);
			CovidAutodichiarazioneObj.LocalizzazioneProvincia = new SiarLibrary.NullTypes.StringNT(db.DataReader["LOCALIZZAZIONE_PROVINCIA"]);
			CovidAutodichiarazioneObj.LocalizzazioneCap = new SiarLibrary.NullTypes.IntNT(db.DataReader["LOCALIZZAZIONE_CAP"]);
			CovidAutodichiarazioneObj.LocalizzazioneVia = new SiarLibrary.NullTypes.StringNT(db.DataReader["LOCALIZZAZIONE_VIA"]);
			CovidAutodichiarazioneObj.MarcaBolloData = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["MARCA_BOLLO_DATA"]);
			CovidAutodichiarazioneObj.MarcaBolloEstremi = new SiarLibrary.NullTypes.StringNT(db.DataReader["MARCA_BOLLO_ESTREMI"]);
			CovidAutodichiarazioneObj.Definitiva = new SiarLibrary.NullTypes.BoolNT(db.DataReader["DEFINITIVA"]);
			CovidAutodichiarazioneObj.DataDefinitiva = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_DEFINITIVA"]);
			CovidAutodichiarazioneObj.IdFileDomanda = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_FILE_DOMANDA"]);
			CovidAutodichiarazioneObj.TokenCohesion = new SiarLibrary.NullTypes.StringNT(db.DataReader["TOKEN_COHESION"]);
			CovidAutodichiarazioneObj.FlagDelegatoAbilitatoSigef = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FLAG_DELEGATO_ABILITATO_SIGEF"]);
			CovidAutodichiarazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			CovidAutodichiarazioneObj.IsDirty = false;
			CovidAutodichiarazioneObj.IsPersistent = true;
			return CovidAutodichiarazioneObj;
		}

		//Find Select

		public static CovidAutodichiarazioneCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.IntNT OperatoreInserimentoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis,
SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdBandoEqualThis,
SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, SiarLibrary.NullTypes.StringNT CodiceFiscaleEqualThis, SiarLibrary.NullTypes.StringNT PartitaIvaEqualThis,
SiarLibrary.NullTypes.DatetimeNT DataInizioAttivitaEqualThis, SiarLibrary.NullTypes.StringNT RagioneSocialeEqualThis, SiarLibrary.NullTypes.StringNT FormaGiuridicaEqualThis,
SiarLibrary.NullTypes.StringNT CodiceAtecoEqualThis, SiarLibrary.NullTypes.IntNT DimensioneImpresaEqualThis, SiarLibrary.NullTypes.StringNT NumeroRegistroImpreseEqualThis,
SiarLibrary.NullTypes.StringNT NumeroReaEqualThis, SiarLibrary.NullTypes.IntNT AnnoReaEqualThis, SiarLibrary.NullTypes.StringNT IndirizzoSedeLegaleEqualThis,
SiarLibrary.NullTypes.IntNT ComuneEqualThis, SiarLibrary.NullTypes.StringNT DenominazioneComuneEqualThis, SiarLibrary.NullTypes.StringNT ProvinciaEqualThis,
SiarLibrary.NullTypes.IntNT CapEqualThis, SiarLibrary.NullTypes.StringNT TelefonoEqualThis, SiarLibrary.NullTypes.StringNT EmailEqualThis,
SiarLibrary.NullTypes.StringNT PecEqualThis, SiarLibrary.NullTypes.StringNT NominativoRappresentanteLegaleEqualThis, SiarLibrary.NullTypes.StringNT CfRappresentanteLegaleEqualThis,
SiarLibrary.NullTypes.DatetimeNT DataDiNascitaRappresentanteLegaleEqualThis, SiarLibrary.NullTypes.IntNT ComuneNascitaRappresentanteLegaleEqualThis, SiarLibrary.NullTypes.StringNT DenominazioneComuneNascitaRappresentanteLegaleEqualThis,
SiarLibrary.NullTypes.StringNT ProvinciaNascitaRappresentanteLegaleEqualThis, SiarLibrary.NullTypes.IntNT CapComuneNascitaRappresentanteLegaleEqualThis, SiarLibrary.NullTypes.StringNT IbanEqualThis,
SiarLibrary.NullTypes.StringNT ContattoNominativoEqualThis, SiarLibrary.NullTypes.StringNT ContattoEmailEqualThis, SiarLibrary.NullTypes.StringNT ContattoPecEqualThis,
SiarLibrary.NullTypes.StringNT ContattoTelefonoEqualThis, SiarLibrary.NullTypes.StringNT ContattoSitoWebEqualThis, SiarLibrary.NullTypes.IntNT LocalizzazioneComuneEqualThis,
SiarLibrary.NullTypes.StringNT LocalizzazioneProvinciaEqualThis, SiarLibrary.NullTypes.IntNT LocalizzazioneCapEqualThis, SiarLibrary.NullTypes.StringNT LocalizzazioneViaEqualThis,
SiarLibrary.NullTypes.DatetimeNT MarcaBolloDataEqualThis, SiarLibrary.NullTypes.StringNT MarcaBolloEstremiEqualThis, SiarLibrary.NullTypes.BoolNT DefinitivaEqualThis,
SiarLibrary.NullTypes.DatetimeNT DataDefinitivaEqualThis, SiarLibrary.NullTypes.IntNT IdFileDomandaEqualThis, SiarLibrary.NullTypes.BoolNT FlagDelegatoAbilitatoSigefEqualThis)

		{

			CovidAutodichiarazioneCollection CovidAutodichiarazioneCollectionObj = new CovidAutodichiarazioneCollection();

			IDbCommand findCmd = db.InitCmd("Zcovidautodichiarazionefindselect", new string[] {"Idequalthis", "OperatoreInserimentoequalthis", "DataInserimentoequalthis",
"DataModificaequalthis", "IdProgettoequalthis", "IdBandoequalthis",
"IdImpresaequalthis", "CodiceFiscaleequalthis", "PartitaIvaequalthis",
"DataInizioAttivitaequalthis", "RagioneSocialeequalthis", "FormaGiuridicaequalthis",
"CodiceAtecoequalthis", "DimensioneImpresaequalthis", "NumeroRegistroImpreseequalthis",
"NumeroReaequalthis", "AnnoReaequalthis", "IndirizzoSedeLegaleequalthis",
"Comuneequalthis", "DenominazioneComuneequalthis", "Provinciaequalthis",
"Capequalthis", "Telefonoequalthis", "Emailequalthis",
"Pecequalthis", "NominativoRappresentanteLegaleequalthis", "CfRappresentanteLegaleequalthis",
"DataDiNascitaRappresentanteLegaleequalthis", "ComuneNascitaRappresentanteLegaleequalthis", "DenominazioneComuneNascitaRappresentanteLegaleequalthis",
"ProvinciaNascitaRappresentanteLegaleequalthis", "CapComuneNascitaRappresentanteLegaleequalthis", "Ibanequalthis",
"ContattoNominativoequalthis", "ContattoEmailequalthis", "ContattoPecequalthis",
"ContattoTelefonoequalthis", "ContattoSitoWebequalthis", "LocalizzazioneComuneequalthis",
"LocalizzazioneProvinciaequalthis", "LocalizzazioneCapequalthis", "LocalizzazioneViaequalthis",
"MarcaBolloDataequalthis", "MarcaBolloEstremiequalthis", "Definitivaequalthis",
"DataDefinitivaequalthis", "IdFileDomandaequalthis", "FlagDelegatoAbilitatoSigefequalthis"}, new string[] {"int", "int", "DateTime",
"DateTime", "int", "int",
"int", "string", "string",
"DateTime", "string", "string",
"string", "int", "string",
"string", "int", "string",
"int", "string", "string",
"int", "string", "string",
"string", "string", "string",
"DateTime", "int", "string",
"string", "int", "string",
"string", "string", "string",
"string", "string", "int",
"string", "int", "string",
"DateTime", "string", "bool",
"DateTime", "int", "bool"}, "");

			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "OperatoreInserimentoequalthis", OperatoreInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodiceFiscaleequalthis", CodiceFiscaleEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "PartitaIvaequalthis", PartitaIvaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataInizioAttivitaequalthis", DataInizioAttivitaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "RagioneSocialeequalthis", RagioneSocialeEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "FormaGiuridicaequalthis", FormaGiuridicaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodiceAtecoequalthis", CodiceAtecoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DimensioneImpresaequalthis", DimensioneImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "NumeroRegistroImpreseequalthis", NumeroRegistroImpreseEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "NumeroReaequalthis", NumeroReaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "AnnoReaequalthis", AnnoReaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IndirizzoSedeLegaleequalthis", IndirizzoSedeLegaleEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Comuneequalthis", ComuneEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DenominazioneComuneequalthis", DenominazioneComuneEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Provinciaequalthis", ProvinciaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Capequalthis", CapEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Telefonoequalthis", TelefonoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Emailequalthis", EmailEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Pecequalthis", PecEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "NominativoRappresentanteLegaleequalthis", NominativoRappresentanteLegaleEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CfRappresentanteLegaleequalthis", CfRappresentanteLegaleEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataDiNascitaRappresentanteLegaleequalthis", DataDiNascitaRappresentanteLegaleEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ComuneNascitaRappresentanteLegaleequalthis", ComuneNascitaRappresentanteLegaleEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DenominazioneComuneNascitaRappresentanteLegaleequalthis", DenominazioneComuneNascitaRappresentanteLegaleEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ProvinciaNascitaRappresentanteLegaleequalthis", ProvinciaNascitaRappresentanteLegaleEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CapComuneNascitaRappresentanteLegaleequalthis", CapComuneNascitaRappresentanteLegaleEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Ibanequalthis", IbanEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ContattoNominativoequalthis", ContattoNominativoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ContattoEmailequalthis", ContattoEmailEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ContattoPecequalthis", ContattoPecEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ContattoTelefonoequalthis", ContattoTelefonoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ContattoSitoWebequalthis", ContattoSitoWebEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "LocalizzazioneComuneequalthis", LocalizzazioneComuneEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "LocalizzazioneProvinciaequalthis", LocalizzazioneProvinciaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "LocalizzazioneCapequalthis", LocalizzazioneCapEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "LocalizzazioneViaequalthis", LocalizzazioneViaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "MarcaBolloDataequalthis", MarcaBolloDataEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "MarcaBolloEstremiequalthis", MarcaBolloEstremiEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Definitivaequalthis", DefinitivaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataDefinitivaequalthis", DataDefinitivaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdFileDomandaequalthis", IdFileDomandaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "FlagDelegatoAbilitatoSigefequalthis", FlagDelegatoAbilitatoSigefEqualThis);
			CovidAutodichiarazione CovidAutodichiarazioneObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				CovidAutodichiarazioneObj = GetFromDatareader(db);
				CovidAutodichiarazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CovidAutodichiarazioneObj.IsDirty = false;
				CovidAutodichiarazioneObj.IsPersistent = true;
				CovidAutodichiarazioneCollectionObj.Add(CovidAutodichiarazioneObj);
			}
			db.Close();
			return CovidAutodichiarazioneCollectionObj;
		}

		//Find Find

		public static CovidAutodichiarazioneCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT OperatoreInserimentoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdBandoEqualThis,
SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, SiarLibrary.NullTypes.StringNT CodiceFiscaleEqualThis, SiarLibrary.NullTypes.StringNT PartitaIvaEqualThis,
SiarLibrary.NullTypes.BoolNT DefinitivaEqualThis)

		{

			CovidAutodichiarazioneCollection CovidAutodichiarazioneCollectionObj = new CovidAutodichiarazioneCollection();

			IDbCommand findCmd = db.InitCmd("Zcovidautodichiarazionefindfind", new string[] {"OperatoreInserimentoequalthis", "IdProgettoequalthis", "IdBandoequalthis",
"IdImpresaequalthis", "CodiceFiscaleequalthis", "PartitaIvaequalthis",
"Definitivaequalthis"}, new string[] {"int", "int", "int",
"int", "string", "string",
"bool"}, "");

			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "OperatoreInserimentoequalthis", OperatoreInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodiceFiscaleequalthis", CodiceFiscaleEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "PartitaIvaequalthis", PartitaIvaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Definitivaequalthis", DefinitivaEqualThis);
			CovidAutodichiarazione CovidAutodichiarazioneObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				CovidAutodichiarazioneObj = GetFromDatareader(db);
				CovidAutodichiarazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CovidAutodichiarazioneObj.IsDirty = false;
				CovidAutodichiarazioneObj.IsPersistent = true;
				CovidAutodichiarazioneCollectionObj.Add(CovidAutodichiarazioneObj);
			}
			db.Close();
			return CovidAutodichiarazioneCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for CovidAutodichiarazioneCollectionProvider:ICovidAutodichiarazioneProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class CovidAutodichiarazioneCollectionProvider : ICovidAutodichiarazioneProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di CovidAutodichiarazione
		protected CovidAutodichiarazioneCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public CovidAutodichiarazioneCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new CovidAutodichiarazioneCollection(this);
		}

		//Costruttore 2: popola la collection
		public CovidAutodichiarazioneCollectionProvider(IntNT OperatoreinserimentoEqualThis, IntNT IdprogettoEqualThis, IntNT IdbandoEqualThis,
IntNT IdimpresaEqualThis, StringNT CodicefiscaleEqualThis, StringNT PartitaivaEqualThis,
BoolNT DefinitivaEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(OperatoreinserimentoEqualThis, IdprogettoEqualThis, IdbandoEqualThis,
IdimpresaEqualThis, CodicefiscaleEqualThis, PartitaivaEqualThis,
DefinitivaEqualThis);
		}

		//Costruttore3: ha in input covidautodichiarazioneCollectionObj - non popola la collection
		public CovidAutodichiarazioneCollectionProvider(CovidAutodichiarazioneCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public CovidAutodichiarazioneCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new CovidAutodichiarazioneCollection(this);
		}

		//Get e Set
		public CovidAutodichiarazioneCollection CollectionObj
		{
			get
			{
				return _CollectionObj;
			}
			set
			{
				_CollectionObj = value;
			}
		}

		public DbProvider DbProviderObj
		{
			get
			{
				return _dbProviderObj;
			}
			set
			{
				_dbProviderObj = value;
			}
		}

		//Operazioni

		//Save1: registra l'intera collection
		public int SaveCollection()
		{
			return SaveCollection(_CollectionObj);
		}

		//Save2: registra una collection
		public int SaveCollection(CovidAutodichiarazioneCollection collectionObj)
		{
			return CovidAutodichiarazioneDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(CovidAutodichiarazione covidautodichiarazioneObj)
		{
			return CovidAutodichiarazioneDAL.Save(_dbProviderObj, covidautodichiarazioneObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(CovidAutodichiarazioneCollection collectionObj)
		{
			return CovidAutodichiarazioneDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(CovidAutodichiarazione covidautodichiarazioneObj)
		{
			return CovidAutodichiarazioneDAL.Delete(_dbProviderObj, covidautodichiarazioneObj);
		}

		//getById
		public CovidAutodichiarazione GetById(IntNT IdValue)
		{
			CovidAutodichiarazione CovidAutodichiarazioneTemp = CovidAutodichiarazioneDAL.GetById(_dbProviderObj, IdValue);
			if (CovidAutodichiarazioneTemp != null) CovidAutodichiarazioneTemp.Provider = this;
			return CovidAutodichiarazioneTemp;
		}

		//Select: popola la collection
		public CovidAutodichiarazioneCollection Select(IntNT IdEqualThis, IntNT OperatoreinserimentoEqualThis, DatetimeNT DatainserimentoEqualThis,
DatetimeNT DatamodificaEqualThis, IntNT IdprogettoEqualThis, IntNT IdbandoEqualThis,
IntNT IdimpresaEqualThis, StringNT CodicefiscaleEqualThis, StringNT PartitaivaEqualThis,
DatetimeNT DatainizioattivitaEqualThis, StringNT RagionesocialeEqualThis, StringNT FormagiuridicaEqualThis,
StringNT CodiceatecoEqualThis, IntNT DimensioneimpresaEqualThis, StringNT NumeroregistroimpreseEqualThis,
StringNT NumeroreaEqualThis, IntNT AnnoreaEqualThis, StringNT IndirizzosedelegaleEqualThis,
IntNT ComuneEqualThis, StringNT DenominazionecomuneEqualThis, StringNT ProvinciaEqualThis,
IntNT CapEqualThis, StringNT TelefonoEqualThis, StringNT EmailEqualThis,
StringNT PecEqualThis, StringNT NominativorappresentantelegaleEqualThis, StringNT CfrappresentantelegaleEqualThis,
DatetimeNT DatadinascitarappresentantelegaleEqualThis, IntNT ComunenascitarappresentantelegaleEqualThis, StringNT DenominazionecomunenascitarappresentantelegaleEqualThis,
StringNT ProvincianascitarappresentantelegaleEqualThis, IntNT CapcomunenascitarappresentantelegaleEqualThis, StringNT IbanEqualThis,
StringNT ContattonominativoEqualThis, StringNT ContattoemailEqualThis, StringNT ContattopecEqualThis,
StringNT ContattotelefonoEqualThis, StringNT ContattositowebEqualThis, IntNT LocalizzazionecomuneEqualThis,
StringNT LocalizzazioneprovinciaEqualThis, IntNT LocalizzazionecapEqualThis, StringNT LocalizzazioneviaEqualThis,
DatetimeNT MarcabollodataEqualThis, StringNT MarcabolloestremiEqualThis, BoolNT DefinitivaEqualThis,
DatetimeNT DatadefinitivaEqualThis, IntNT IdfiledomandaEqualThis, BoolNT FlagdelegatoabilitatosigefEqualThis)
		{
			CovidAutodichiarazioneCollection CovidAutodichiarazioneCollectionTemp = CovidAutodichiarazioneDAL.Select(_dbProviderObj, IdEqualThis, OperatoreinserimentoEqualThis, DatainserimentoEqualThis,
DatamodificaEqualThis, IdprogettoEqualThis, IdbandoEqualThis,
IdimpresaEqualThis, CodicefiscaleEqualThis, PartitaivaEqualThis,
DatainizioattivitaEqualThis, RagionesocialeEqualThis, FormagiuridicaEqualThis,
CodiceatecoEqualThis, DimensioneimpresaEqualThis, NumeroregistroimpreseEqualThis,
NumeroreaEqualThis, AnnoreaEqualThis, IndirizzosedelegaleEqualThis,
ComuneEqualThis, DenominazionecomuneEqualThis, ProvinciaEqualThis,
CapEqualThis, TelefonoEqualThis, EmailEqualThis,
PecEqualThis, NominativorappresentantelegaleEqualThis, CfrappresentantelegaleEqualThis,
DatadinascitarappresentantelegaleEqualThis, ComunenascitarappresentantelegaleEqualThis, DenominazionecomunenascitarappresentantelegaleEqualThis,
ProvincianascitarappresentantelegaleEqualThis, CapcomunenascitarappresentantelegaleEqualThis, IbanEqualThis,
ContattonominativoEqualThis, ContattoemailEqualThis, ContattopecEqualThis,
ContattotelefonoEqualThis, ContattositowebEqualThis, LocalizzazionecomuneEqualThis,
LocalizzazioneprovinciaEqualThis, LocalizzazionecapEqualThis, LocalizzazioneviaEqualThis,
MarcabollodataEqualThis, MarcabolloestremiEqualThis, DefinitivaEqualThis,
DatadefinitivaEqualThis, IdfiledomandaEqualThis, FlagdelegatoabilitatosigefEqualThis);
			CovidAutodichiarazioneCollectionTemp.Provider = this;
			return CovidAutodichiarazioneCollectionTemp;
		}

		//Find: popola la collection
		public CovidAutodichiarazioneCollection Find(IntNT OperatoreinserimentoEqualThis, IntNT IdprogettoEqualThis, IntNT IdbandoEqualThis,
IntNT IdimpresaEqualThis, StringNT CodicefiscaleEqualThis, StringNT PartitaivaEqualThis,
BoolNT DefinitivaEqualThis)
		{
			CovidAutodichiarazioneCollection CovidAutodichiarazioneCollectionTemp = CovidAutodichiarazioneDAL.Find(_dbProviderObj, OperatoreinserimentoEqualThis, IdprogettoEqualThis, IdbandoEqualThis,
IdimpresaEqualThis, CodicefiscaleEqualThis, PartitaivaEqualThis,
DefinitivaEqualThis);
			CovidAutodichiarazioneCollectionTemp.Provider = this;
			return CovidAutodichiarazioneCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<COVID_AUTODICHIARAZIONE>
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
    <Find OrderBy="ORDER BY RAGIONE_SOCIALE">
      <OPERATORE_INSERIMENTO>Equal</OPERATORE_INSERIMENTO>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_BANDO>Equal</ID_BANDO>
      <ID_IMPRESA>Equal</ID_IMPRESA>
      <CODICE_FISCALE>Equal</CODICE_FISCALE>
      <PARTITA_IVA>Equal</PARTITA_IVA>
      <DEFINITIVA>Equal</DEFINITIVA>
    </Find>
  </Finds>
  <Filters>
    <Filter>
      <OPERATORE_INSERIMENTO>Equal</OPERATORE_INSERIMENTO>
      <FORMA_GIURIDICA>Equal</FORMA_GIURIDICA>
      <CODICE_ATECO>Equal</CODICE_ATECO>
      <DIMENSIONE_IMPRESA>Equal</DIMENSIONE_IMPRESA>
      <COMUNE>Equal</COMUNE>
    </Filter>
  </Filters>
  <externalFields />
  <AddedFkFields />
</COVID_AUTODICHIARAZIONE>
*/
