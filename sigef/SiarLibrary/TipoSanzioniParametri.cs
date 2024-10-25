using System;
using System.ComponentModel;

namespace SiarLibrary
{

	// interfaccia provider per TipoSanzioniParametri
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface ITipoSanzioniParametriProvider
	{
		int Save(TipoSanzioniParametri TipoSanzioniParametriObj);
		int SaveCollection(TipoSanzioniParametriCollection collectionObj);
		int Delete(TipoSanzioniParametri TipoSanzioniParametriObj);
		int DeleteCollection(TipoSanzioniParametriCollection collectionObj);
	}
	/// <summary>
	/// Summary description for TipoSanzioniParametri
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public class TipoSanzioniParametri: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _Codice;
		private NullTypes.StringNT _CodTipoSanzione;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.BoolNT _NonComportaSanzione;
		private NullTypes.BoolNT _Durata;
		private NullTypes.BoolNT _Gravita;
		private NullTypes.BoolNT _Entita;
		private NullTypes.IntNT _ClasseViolazione;
		private NullTypes.StringNT _Tooltip;
		[NonSerialized] private ITipoSanzioniParametriProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ITipoSanzioniParametriProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public TipoSanzioniParametri()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:CODICE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Codice
		{
			get { return _Codice; }
			set {
				if (Codice != value)
				{
					_Codice = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_TIPO_SANZIONE
		/// Tipo sul db:VARCHAR(10)
		/// </summary>
		public NullTypes.StringNT CodTipoSanzione
		{
			get { return _CodTipoSanzione; }
			set {
				if (CodTipoSanzione != value)
				{
					_CodTipoSanzione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE
		/// Tipo sul db:VARCHAR(500)
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
		/// Corrisponde al campo:NON_COMPORTA_SANZIONE
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT NonComportaSanzione
		{
			get { return _NonComportaSanzione; }
			set {
				if (NonComportaSanzione != value)
				{
					_NonComportaSanzione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DURATA
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT Durata
		{
			get { return _Durata; }
			set {
				if (Durata != value)
				{
					_Durata = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:GRAVITA
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT Gravita
		{
			get { return _Gravita; }
			set {
				if (Gravita != value)
				{
					_Gravita = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ENTITA
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT Entita
		{
			get { return _Entita; }
			set {
				if (Entita != value)
				{
					_Entita = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CLASSE_VIOLAZIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT ClasseViolazione
		{
			get { return _ClasseViolazione; }
			set {
				if (ClasseViolazione != value)
				{
					_ClasseViolazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TOOLTIP
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT Tooltip
		{
			get { return _Tooltip; }
			set {
				if (Tooltip != value)
				{
					_Tooltip = value;
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
<TIPO_SANZIONI_PARAMETRI>
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
    <Find OrderBy="ORDER BY CLASSE_VIOLAZIONE">
      <CODICE>Equal</CODICE>
      <COD_TIPO_SANZIONE>Equal</COD_TIPO_SANZIONE>
      <DURATA>Equal</DURATA>
      <GRAVITA>Equal</GRAVITA>
      <ENTITA>Equal</ENTITA>
    </Find>
  </Finds>
  <Filters>
    <FiltroTipoParametro>
      <DURATA>Equal</DURATA>
      <GRAVITA>Equal</GRAVITA>
      <ENTITA>Equal</ENTITA>
    </FiltroTipoParametro>
  </Filters>
  <externalFields />
  <AddedFkFields />
</TIPO_SANZIONI_PARAMETRI>
*/