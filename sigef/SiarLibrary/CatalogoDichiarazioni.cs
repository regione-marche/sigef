using System;
using System.ComponentModel;

namespace SiarLibrary
{

	// interfaccia provider per CatalogoDichiarazioni
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface ICatalogoDichiarazioniProvider
	{
		int Save(CatalogoDichiarazioni CatalogoDichiarazioniObj);
		int SaveCollection(CatalogoDichiarazioniCollection collectionObj);
		int Delete(CatalogoDichiarazioni CatalogoDichiarazioniObj);
		int DeleteCollection(CatalogoDichiarazioniCollection collectionObj);
	}
	/// <summary>
	/// Summary description for CatalogoDichiarazioni
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public class CatalogoDichiarazioni: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdDichiarazione;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.StringNT _Misura;
		[NonSerialized] private ICatalogoDichiarazioniProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ICatalogoDichiarazioniProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public CatalogoDichiarazioni()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_DICHIARAZIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdDichiarazione
		{
			get { return _IdDichiarazione; }
			set {
				if (IdDichiarazione != value)
				{
					_IdDichiarazione = value;
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
		/// Corrisponde al campo:MISURA
		/// Tipo sul db:VARCHAR(10)
		/// </summary>
		public NullTypes.StringNT Misura
		{
			get { return _Misura; }
			set {
				if (Misura != value)
				{
					_Misura = value;
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
<CATALOGO_DICHIARAZIONI>
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
    <Find OrderBy="ORDER BY ID_DICHIARAZIONE">
      <ID_DICHIARAZIONE>Equal</ID_DICHIARAZIONE>
      <MISURA>Like</MISURA>
      <DESCRIZIONE>Like</DESCRIZIONE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</CATALOGO_DICHIARAZIONI>
*/