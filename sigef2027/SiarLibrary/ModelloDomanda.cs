using System;
using System.ComponentModel;

namespace SiarLibrary
{

	// interfaccia provider per ModelloDomanda
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IModelloDomandaProvider
	{
		int Save(ModelloDomanda ModelloDomandaObj);
		int SaveCollection(ModelloDomandaCollection collectionObj);
		int Delete(ModelloDomanda ModelloDomandaObj);
		int DeleteCollection(ModelloDomandaCollection collectionObj);
	}
	/// <summary>
	/// Summary description for ModelloDomanda
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public class ModelloDomanda: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdDomanda;
		private NullTypes.IntNT _IdBando;
		private NullTypes.BoolNT _Definitivo;
		private NullTypes.StringNT _Operatore;
		private NullTypes.StringNT _Denominazione;
		private NullTypes.StringNT _Descrizione;
		[NonSerialized] private IModelloDomandaProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IModelloDomandaProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public ModelloDomanda()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_DOMANDA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdDomanda
		{
			get { return _IdDomanda; }
			set {
				if (IdDomanda != value)
				{
					_IdDomanda = value;
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
			set {
				if (IdBando != value)
				{
					_IdBando = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DEFINITIVO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Definitivo
		{
			get { return _Definitivo; }
			set {
				if (Definitivo != value)
				{
					_Definitivo = value;
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
		/// Corrisponde al campo:DENOMINAZIONE
		/// Tipo sul db:VARCHAR(50)
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
<MODELLO_DOMANDA>
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
    <Find>
      <ID_DOMANDA>Equal</ID_DOMANDA>
      <ID_BANDO>Equal</ID_BANDO>
      <DEFINITIVO>Equal</DEFINITIVO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</MODELLO_DOMANDA>
*/