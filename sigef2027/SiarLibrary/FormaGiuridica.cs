using System;
using System.ComponentModel;

namespace SiarLibrary
{

	// interfaccia provider per FormaGiuridica
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IFormaGiuridicaProvider
	{
		int Save(FormaGiuridica FormaGiuridicaObj);
		int SaveCollection(FormaGiuridicaCollection collectionObj);
		int Delete(FormaGiuridica FormaGiuridicaObj);
		int DeleteCollection(FormaGiuridicaCollection collectionObj);
	}
	/// <summary>
	/// Summary description for FormaGiuridica
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public class FormaGiuridica: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.StringNT _CodIstat;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.BoolNT _Foglia;
		[NonSerialized] private IFormaGiuridicaProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IFormaGiuridicaProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public FormaGiuridica()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:COD_ISTAT
		/// Tipo sul db:VARCHAR(10)
		/// </summary>
		public NullTypes.StringNT CodIstat
		{
			get { return _CodIstat; }
			set {
				if (CodIstat != value)
				{
					_CodIstat = value;
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
		/// Corrisponde al campo:FOGLIA
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Foglia
		{
			get { return _Foglia; }
			set {
				if (Foglia != value)
				{
					_Foglia = value;
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
<FORMA_GIURIDICA>
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
      <COD_ISTAT>Equal</COD_ISTAT>
    </Find>
  </Finds>
  <Filters>
    <FiltroFoglia>
      <FOGLIA>Equal</FOGLIA>
    </FiltroFoglia>
  </Filters>
  <externalFields />
  <AddedFkFields />
</FORMA_GIURIDICA>
*/