using System;
using System.ComponentModel;

namespace SiarLibrary
{

	// interfaccia provider per SettoriProduttivi
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface ISettoriProduttiviProvider
	{
		int Save(SettoriProduttivi SettoriProduttiviObj);
		int SaveCollection(SettoriProduttiviCollection collectionObj);
		int Delete(SettoriProduttivi SettoriProduttiviObj);
		int DeleteCollection(SettoriProduttiviCollection collectionObj);
	}
	/// <summary>
	/// Summary description for SettoriProduttivi
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public class SettoriProduttivi: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdSettoreProduttivo;
		private NullTypes.StringNT _Descrizione;
		[NonSerialized] private ISettoriProduttiviProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ISettoriProduttiviProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public SettoriProduttivi()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_SETTORE_PRODUTTIVO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdSettoreProduttivo
		{
			get { return _IdSettoreProduttivo; }
			set {
				if (IdSettoreProduttivo != value)
				{
					_IdSettoreProduttivo = value;
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
<SETTORI_PRODUTTIVI>
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
    <Find OrderBy="ORDER BY DESCRIZIONE">
      <ID_SETTORE_PRODUTTIVO>Equal</ID_SETTORE_PRODUTTIVO>
      <DESCRIZIONE>Like</DESCRIZIONE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</SETTORI_PRODUTTIVI>
*/