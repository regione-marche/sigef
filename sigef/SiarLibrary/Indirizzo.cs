using System;
using System.ComponentModel;

namespace SiarLibrary
{

	// interfaccia provider per Indirizzo
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IIndirizzoProvider
	{
		int Save(Indirizzo IndirizzoObj);
		int SaveCollection(IndirizzoCollection collectionObj);
		int Delete(Indirizzo IndirizzoObj);
		int DeleteCollection(IndirizzoCollection collectionObj);
	}
	/// <summary>
	/// Summary description for Indirizzo
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public class Indirizzo: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdIndirizzo;
		private NullTypes.StringNT _Via;
		private NullTypes.StringNT _Localita;
		private NullTypes.IntNT _IdComune;
		private NullTypes.StringNT _Denominazione;
		[NonSerialized] private IIndirizzoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IIndirizzoProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public Indirizzo()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_INDIRIZZO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdIndirizzo
		{
			get { return _IdIndirizzo; }
			set {
				if (IdIndirizzo != value)
				{
					_IdIndirizzo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:VIA
		/// Tipo sul db:VARCHAR(500)
		/// </summary>
		public NullTypes.StringNT Via
		{
			get { return _Via; }
			set {
				if (Via != value)
				{
					_Via = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:LOCALITA
		/// Tipo sul db:VARCHAR(500)
		/// </summary>
		public NullTypes.StringNT Localita
		{
			get { return _Localita; }
			set {
				if (Localita != value)
				{
					_Localita = value;
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
<INDIRIZZO>
  <ViewName>
  </ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>True</chkDataModifica>
  <chkCase>False</chkCase>
  <chkCache>False</chkCache>
  <PLName>SiarPLL</PLName>
  <DALName>SiarDAL</DALName>
  <BLLName>SiarBLL</BLLName>
  <TypeNameSpaceName>SiarLibrary</TypeNameSpaceName>
  <Finds>
    <Find>
      <ID_INDIRIZZO>Equal</ID_INDIRIZZO>
      <ID_COMUNE>Equal</ID_COMUNE>
      <VIA>Like</VIA>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</INDIRIZZO>
*/