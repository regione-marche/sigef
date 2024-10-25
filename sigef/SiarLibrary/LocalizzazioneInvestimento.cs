using System;
using System.ComponentModel;

namespace SiarLibrary
{

	// interfaccia provider per LocalizzazioneInvestimento
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface ILocalizzazioneInvestimentoProvider
	{
		int Save(LocalizzazioneInvestimento LocalizzazioneInvestimentoObj);
		int SaveCollection(LocalizzazioneInvestimentoCollection collectionObj);
		int Delete(LocalizzazioneInvestimento LocalizzazioneInvestimentoObj);
		int DeleteCollection(LocalizzazioneInvestimentoCollection collectionObj);
	}
	/// <summary>
	/// Summary description for LocalizzazioneInvestimento
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public class LocalizzazioneInvestimento: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdLocalizzazione;
		private NullTypes.IntNT _IdInvestimento;
		private NullTypes.IntNT _IdCatasto;
		private NullTypes.IntNT _IdComune;
		private NullTypes.StringNT _FoglioCatastale;
		private NullTypes.StringNT _Particella;
		private NullTypes.StringNT _Sezione;
		private NullTypes.StringNT _Subalterno;
		private NullTypes.IntNT _SuperficieCatastale;
		private NullTypes.StringNT _Svantaggio;
		[NonSerialized] private ILocalizzazioneInvestimentoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ILocalizzazioneInvestimentoProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public LocalizzazioneInvestimento()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_LOCALIZZAZIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdLocalizzazione
		{
			get { return _IdLocalizzazione; }
			set {
				if (IdLocalizzazione != value)
				{
					_IdLocalizzazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_INVESTIMENTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdInvestimento
		{
			get { return _IdInvestimento; }
			set {
				if (IdInvestimento != value)
				{
					_IdInvestimento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_CATASTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdCatasto
		{
			get { return _IdCatasto; }
			set {
				if (IdCatasto != value)
				{
					_IdCatasto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_COMUNE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdComune
		{
			get { return _IdComune; }
			set {
				if (IdComune != value)
				{
					_IdComune = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:FOGLIO_CATASTALE
		/// Tipo sul db:VARCHAR(4)
		/// </summary>
		public NullTypes.StringNT FoglioCatastale
		{
			get { return _FoglioCatastale; }
			set {
				if (FoglioCatastale != value)
				{
					_FoglioCatastale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PARTICELLA
		/// Tipo sul db:VARCHAR(5)
		/// </summary>
		public NullTypes.StringNT Particella
		{
			get { return _Particella; }
			set {
				if (Particella != value)
				{
					_Particella = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SEZIONE
		/// Tipo sul db:CHAR(1)
		/// </summary>
		public NullTypes.StringNT Sezione
		{
			get { return _Sezione; }
			set {
				if (Sezione != value)
				{
					_Sezione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SUBALTERNO
		/// Tipo sul db:VARCHAR(3)
		/// </summary>
		public NullTypes.StringNT Subalterno
		{
			get { return _Subalterno; }
			set {
				if (Subalterno != value)
				{
					_Subalterno = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SUPERFICIE_CATASTALE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT SuperficieCatastale
		{
			get { return _SuperficieCatastale; }
			set {
				if (SuperficieCatastale != value)
				{
					_SuperficieCatastale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SVANTAGGIO
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT Svantaggio
		{
			get { return _Svantaggio; }
			set {
				if (Svantaggio != value)
				{
					_Svantaggio = value;
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
<LOCALIZZAZIONE_INVESTIMENTO>
  <ViewName>vLOCALIZZAZIONE_INVESTIMENTO</ViewName>
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
      <ID_LOCALIZZAZIONE>Equal</ID_LOCALIZZAZIONE>
      <ID_INVESTIMENTO>Equal</ID_INVESTIMENTO>
      <ID_CATASTO>Equal</ID_CATASTO>
      <ID_COMUNE>Equal</ID_COMUNE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</LOCALIZZAZIONE_INVESTIMENTO>
*/