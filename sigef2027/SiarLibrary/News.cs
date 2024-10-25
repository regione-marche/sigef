using System;
using System.ComponentModel;

namespace SiarLibrary
{

	// interfaccia provider per News
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface INewsProvider
	{
		int Save(News NewsObj);
		int SaveCollection(NewsCollection collectionObj);
		int Delete(News NewsObj);
		int DeleteCollection(NewsCollection collectionObj);
	}
	/// <summary>
	/// Summary description for News
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public class News: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdNews;
		private NullTypes.StringNT _Titolo;
		private NullTypes.StringNT _Testo;
		private NullTypes.StringNT _Url;
		private NullTypes.DatetimeNT _Data;
		private NullTypes.StringNT _Operatore;
		private NullTypes.BoolNT _InterruzioneSistema;
		private NullTypes.DatetimeNT _DataInizio;
		private NullTypes.DatetimeNT _DataFine;
		[NonSerialized] private INewsProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public INewsProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public News()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_NEWS
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdNews
		{
			get { return _IdNews; }
			set {
				if (IdNews != value)
				{
					_IdNews = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TITOLO
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT Titolo
		{
			get { return _Titolo; }
			set {
				if (Titolo != value)
				{
					_Titolo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TESTO
		/// Tipo sul db:NVARCHAR
		/// </summary>
		public NullTypes.StringNT Testo
		{
			get { return _Testo; }
			set {
				if (Testo != value)
				{
					_Testo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:URL
		/// Tipo sul db:VARCHAR(255)
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

		/// <summary>
		/// Corrisponde al campo:INTERRUZIONE_SISTEMA
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT InterruzioneSistema
		{
			get { return _InterruzioneSistema; }
			set {
				if (InterruzioneSistema != value)
				{
					_InterruzioneSistema = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_INIZIO
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataInizio
		{
			get { return _DataInizio; }
			set {
				if (DataInizio != value)
				{
					_DataInizio = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_FINE
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataFine
		{
			get { return _DataFine; }
			set {
				if (DataFine != value)
				{
					_DataFine = value;
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
<NEWS>
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
    <Find OrderBy="ORDER BY DATA DESC">
      <TITOLO>Like</TITOLO>
      <TESTO>Like</TESTO>
      <INTERRUZIONE_SISTEMA>Equal</INTERRUZIONE_SISTEMA>
    </Find>
  </Finds>
  <Filters>
    <FiltroInterruzioneDiSistema>
      <INTERRUZIONE_SISTEMA>Equal</INTERRUZIONE_SISTEMA>
      <DATA_INIZIO>EqLessThan</DATA_INIZIO>
      <DATA_FINE>EqGreaterThan</DATA_FINE>
    </FiltroInterruzioneDiSistema>
  </Filters>
  <externalFields />
  <AddedFkFields />
</NEWS>
*/