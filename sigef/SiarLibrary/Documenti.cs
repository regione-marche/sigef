using System;
using System.ComponentModel;

namespace SiarLibrary
{

	// interfaccia provider per Documenti
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IDocumentiProvider
	{
		int Save(Documenti DocumentiObj);
		int SaveCollection(DocumentiCollection collectionObj);
		int Delete(Documenti DocumentiObj);
		int DeleteCollection(DocumentiCollection collectionObj);
	}
	/// <summary>
	/// Summary description for Documenti
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public class Documenti: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdDocumento;
		private NullTypes.StringNT _Titolo;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.DatetimeNT _DataModifica;
		private NullTypes.StringNT _Operatore;
		private NullTypes.DatetimeNT _DataFineValidita;
		[NonSerialized] private IDocumentiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IDocumentiProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public Documenti()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_DOCUMENTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdDocumento
		{
			get { return _IdDocumento; }
			set {
				if (IdDocumento != value)
				{
					_IdDocumento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TITOLO
		/// Tipo sul db:VARCHAR(500)
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
		/// Corrisponde al campo:DESCRIZIONE
		/// Tipo sul db:VARCHAR(1000)
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
		/// Corrisponde al campo:DATA_MODIFICA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataModifica
		{
			get { return _DataModifica; }
			set {
				if (DataModifica != value)
				{
					_DataModifica = value;
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
		/// Corrisponde al campo:DATA_FINE_VALIDITA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataFineValidita
		{
			get { return _DataFineValidita; }
			set {
				if (DataFineValidita != value)
				{
					_DataFineValidita = value;
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
<DOCUMENTI>
  <ViewName>
  </ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>False</chkDataModifica>
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
    <Find OrderBy="ORDER BY DATA_MODIFICA DESC">
      <TITOLO>Like</TITOLO>
      <DESCRIZIONE>Like</DESCRIZIONE>
      <DATA_FINE_VALIDITA>EqGreaterThan</DATA_FINE_VALIDITA>
    </Find>
  </Finds>
  <Filters>
    <FiltroDescrizione>
      <TITOLO>Like</TITOLO>
      <DESCRIZIONE>Like</DESCRIZIONE>
    </FiltroDescrizione>
  </Filters>
  <externalFields />
  <AddedFkFields />
</DOCUMENTI>
*/