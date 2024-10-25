using System;
using System.ComponentModel;

namespace SiarLibrary
{

	// interfaccia provider per PartecipantiIndirettiFatturato
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IPartecipantiIndirettiFatturatoProvider
	{
		int Save(PartecipantiIndirettiFatturato PartecipantiIndirettiFatturatoObj);
		int SaveCollection(PartecipantiIndirettiFatturatoCollection collectionObj);
		int Delete(PartecipantiIndirettiFatturato PartecipantiIndirettiFatturatoObj);
		int DeleteCollection(PartecipantiIndirettiFatturatoCollection collectionObj);
	}
	/// <summary>
	/// Summary description for PartecipantiIndirettiFatturato
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public class PartecipantiIndirettiFatturato: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _Id;
		private NullTypes.StringNT _CuaaPromotore;
		private NullTypes.IntNT _IdImpresa;
		private NullTypes.StringNT _Cuaa;
		private NullTypes.StringNT _CodProdotto;
		private NullTypes.StringNT _CodVarieta;
		private NullTypes.DecimalNT _ProduzioneTotale;
		private NullTypes.DecimalNT _PrezzoMedio;
		private NullTypes.DecimalNT _Fatturato;
		private NullTypes.StringNT _Varieta;
		private NullTypes.StringNT _Prodotto;
		private NullTypes.StringNT _CodiceFiscale;
		private NullTypes.StringNT _RagioneSociale;
		private NullTypes.StringNT _CodFormaGiuridica;
		private NullTypes.IntNT _IdDimensione;
		private NullTypes.StringNT _DimensioneImpresa;
		private NullTypes.StringNT _FormaGiuridica;
		private NullTypes.IntNT _IdClasseAllevamento;
		private NullTypes.IntNT _IdAttivitaConnessa;
		private NullTypes.StringNT _CuaaTrasformatore;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.DecimalNT _PrezzoUnitario;
		private NullTypes.StringNT _AttivitaConnesse;
		private NullTypes.DecimalNT _PrezzoAttivita;
		private NullTypes.DecimalNT _ProduzioneInFiliera;
		private NullTypes.IntNT _NumeroCapi;
		[NonSerialized] private IPartecipantiIndirettiFatturatoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IPartecipantiIndirettiFatturatoProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public PartecipantiIndirettiFatturato()
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
		/// Corrisponde al campo:CUAA_PROMOTORE
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT CuaaPromotore
		{
			get { return _CuaaPromotore; }
			set {
				if (CuaaPromotore != value)
				{
					_CuaaPromotore = value;
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
			set {
				if (IdImpresa != value)
				{
					_IdImpresa = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CUAA
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT Cuaa
		{
			get { return _Cuaa; }
			set {
				if (Cuaa != value)
				{
					_Cuaa = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_PRODOTTO
		/// Tipo sul db:VARCHAR(3)
		/// </summary>
		public NullTypes.StringNT CodProdotto
		{
			get { return _CodProdotto; }
			set {
				if (CodProdotto != value)
				{
					_CodProdotto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_VARIETA
		/// Tipo sul db:VARCHAR(3)
		/// </summary>
		public NullTypes.StringNT CodVarieta
		{
			get { return _CodVarieta; }
			set {
				if (CodVarieta != value)
				{
					_CodVarieta = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PRODUZIONE_TOTALE
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT ProduzioneTotale
		{
			get { return _ProduzioneTotale; }
			set {
				if (ProduzioneTotale != value)
				{
					_ProduzioneTotale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PREZZO_MEDIO
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT PrezzoMedio
		{
			get { return _PrezzoMedio; }
			set {
				if (PrezzoMedio != value)
				{
					_PrezzoMedio = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:FATTURATO
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT Fatturato
		{
			get { return _Fatturato; }
			set {
				if (Fatturato != value)
				{
					_Fatturato = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:VARIETA
		/// Tipo sul db:VARCHAR(500)
		/// </summary>
		public NullTypes.StringNT Varieta
		{
			get { return _Varieta; }
			set {
				if (Varieta != value)
				{
					_Varieta = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PRODOTTO
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT Prodotto
		{
			get { return _Prodotto; }
			set {
				if (Prodotto != value)
				{
					_Prodotto = value;
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
			set {
				if (CodiceFiscale != value)
				{
					_CodiceFiscale = value;
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
			set {
				if (RagioneSociale != value)
				{
					_RagioneSociale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_FORMA_GIURIDICA
		/// Tipo sul db:VARCHAR(10)
		/// </summary>
		public NullTypes.StringNT CodFormaGiuridica
		{
			get { return _CodFormaGiuridica; }
			set {
				if (CodFormaGiuridica != value)
				{
					_CodFormaGiuridica = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_DIMENSIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdDimensione
		{
			get { return _IdDimensione; }
			set {
				if (IdDimensione != value)
				{
					_IdDimensione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DIMENSIONE_IMPRESA
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT DimensioneImpresa
		{
			get { return _DimensioneImpresa; }
			set {
				if (DimensioneImpresa != value)
				{
					_DimensioneImpresa = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:FORMA_GIURIDICA
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT FormaGiuridica
		{
			get { return _FormaGiuridica; }
			set {
				if (FormaGiuridica != value)
				{
					_FormaGiuridica = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_CLASSE_ALLEVAMENTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdClasseAllevamento
		{
			get { return _IdClasseAllevamento; }
			set {
				if (IdClasseAllevamento != value)
				{
					_IdClasseAllevamento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_ATTIVITA_CONNESSA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdAttivitaConnessa
		{
			get { return _IdAttivitaConnessa; }
			set {
				if (IdAttivitaConnessa != value)
				{
					_IdAttivitaConnessa = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CUAA_TRASFORMATORE
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT CuaaTrasformatore
		{
			get { return _CuaaTrasformatore; }
			set {
				if (CuaaTrasformatore != value)
				{
					_CuaaTrasformatore = value;
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
		/// Corrisponde al campo:PREZZO_UNITARIO
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT PrezzoUnitario
		{
			get { return _PrezzoUnitario; }
			set {
				if (PrezzoUnitario != value)
				{
					_PrezzoUnitario = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ATTIVITA_CONNESSE
		/// Tipo sul db:VARCHAR(500)
		/// </summary>
		public NullTypes.StringNT AttivitaConnesse
		{
			get { return _AttivitaConnesse; }
			set {
				if (AttivitaConnesse != value)
				{
					_AttivitaConnesse = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PREZZO_ATTIVITA
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT PrezzoAttivita
		{
			get { return _PrezzoAttivita; }
			set {
				if (PrezzoAttivita != value)
				{
					_PrezzoAttivita = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PRODUZIONE_IN_FILIERA
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT ProduzioneInFiliera
		{
			get { return _ProduzioneInFiliera; }
			set {
				if (ProduzioneInFiliera != value)
				{
					_ProduzioneInFiliera = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NUMERO_CAPI
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT NumeroCapi
		{
			get { return _NumeroCapi; }
			set {
				if (NumeroCapi != value)
				{
					_NumeroCapi = value;
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
<PARTECIPANTI_INDIRETTI_FATTURATO>
  <ViewName>vPARECIPANTI_INDIRETTI_FATTURATO</ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>True</chkDataModifica>
  <txtNomeCampoDataModifica>DATA_MODIFICA</txtNomeCampoDataModifica>
  <chkOptimisticCouncurrency>True</chkOptimisticCouncurrency>
  <chkShortNames>False</chkShortNames>
  <chkCase>False</chkCase>
  <chkCache>False</chkCache>
  <PLName>SiarPLL</PLName>
  <DALName>SiarDAL</DALName>
  <BLLName>SiarBLL</BLLName>
  <TypeNameSpaceName>SiarLibrary</TypeNameSpaceName>
  <Finds>
    <Find OrderBy="ORDER BY ">
      <ID_IMPRESA>Equal</ID_IMPRESA>
      <CUAA>Equal</CUAA>
      <CUAA_TRASFORMATORE>Equal</CUAA_TRASFORMATORE>
    </Find>
  </Finds>
  <Filters>
    <FiltroProdotto>
      <COD_PRODOTTO>IsNull</COD_PRODOTTO>
    </FiltroProdotto>
    <FiltroAllevamento>
      <ID_CLASSE_ALLEVAMENTO>IsNull</ID_CLASSE_ALLEVAMENTO>
    </FiltroAllevamento>
    <FiltroAttivita>
      <ID_ATTIVITA_CONNESSA>IsNull</ID_ATTIVITA_CONNESSA>
    </FiltroAttivita>
  </Filters>
  <externalFields />
  <AddedFkFields />
</PARTECIPANTI_INDIRETTI_FATTURATO>
*/