using System;
using System.ComponentModel;

namespace SiarLibrary
{

	// interfaccia provider per FileDocumento
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IFileDocumentoProvider
	{
		int Save(FileDocumento FileDocumentoObj);
		int SaveCollection(FileDocumentoCollection collectionObj);
		int Delete(FileDocumento FileDocumentoObj);
		int DeleteCollection(FileDocumentoCollection collectionObj);
	}
	/// <summary>
	/// Summary description for FileDocumento
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public class FileDocumento: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdFile;
		private NullTypes.IntNT _IdDocumento;
		private NullTypes.StringNT _Nome;
		private NullTypes.StringNT _Tipo;
		private NullTypes.IntNT _SizeFile;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.IntNT _IdArchivioFile;
		[NonSerialized] private IFileDocumentoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IFileDocumentoProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public FileDocumento()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_FILE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdFile
		{
			get { return _IdFile; }
			set {
				if (IdFile != value)
				{
					_IdFile = value;
					SetDirtyFlag();
				}
			}
		}

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
		/// Corrisponde al campo:NOME
		/// Tipo sul db:VARCHAR(80)
		/// </summary>
		public NullTypes.StringNT Nome
		{
			get { return _Nome; }
			set {
				if (Nome != value)
				{
					_Nome = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TIPO
		/// Tipo sul db:VARCHAR(10)
		/// </summary>
		public NullTypes.StringNT Tipo
		{
			get { return _Tipo; }
			set {
				if (Tipo != value)
				{
					_Tipo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SIZE_FILE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT SizeFile
		{
			get { return _SizeFile; }
			set {
				if (SizeFile != value)
				{
					_SizeFile = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE
		/// Tipo sul db:VARCHAR(100)
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
		/// Corrisponde al campo:ID_ARCHIVIO_FILE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdArchivioFile
		{
			get { return _IdArchivioFile; }
			set {
				if (IdArchivioFile != value)
				{
					_IdArchivioFile = value;
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
<FILE_DOCUMENTO>
  <ViewName>
  </ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>False</chkDataModifica>
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
    <Find OrderBy="ORDER BY DESCRIZIONE">
      <ID_DOCUMENTO>Equal</ID_DOCUMENTO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</FILE_DOCUMENTO>
*/