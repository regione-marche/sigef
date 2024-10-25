using System;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for FileDocumentoCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class FileDocumentoCollection : CustomCollection, System.Runtime.Serialization.ISerializable
	{

		//Serializzazione xml
		public void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
		{
			info.AddValue("_count",this.Count);
			for(int i=0;i<this.Count;i++)
			{
				info.AddValue(i.ToString(),this[i]);
			}
		}
		private FileDocumentoCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((FileDocumento) info.GetValue(i.ToString(),typeof(FileDocumento)));
			}
		}

		//Costruttore
		public FileDocumentoCollection()
		{
			this.ItemType = typeof(FileDocumento);
		}

		//Costruttore con provider
		public FileDocumentoCollection(IFileDocumentoProvider providerObj)
		{
			this.ItemType = typeof(FileDocumento);
			this.Provider = providerObj;
		}

		//Get e Set
		public new FileDocumento this[int index]
		{
			get { return (FileDocumento)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new FileDocumentoCollection GetChanges()
		{
			return (FileDocumentoCollection) base.GetChanges();
		}

		[NonSerialized] private IFileDocumentoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IFileDocumentoProvider Provider
		{
			get {return _provider;}
			set 
			{ 
				_provider = value;
				for (int i = 0; i < this.Count; i++)
				{
					this[i].Provider = value;
				}
			} 
		}

		public int SaveCollection()
		{
			return _provider.SaveCollection(this);
		}
		public int DeleteCollection()
		{
			return _provider.DeleteCollection(this);
		}
		//Add
		public int Add(FileDocumento FileDocumentoObj)
		{
			if (FileDocumentoObj.Provider == null) FileDocumentoObj.Provider = this.Provider;
			return base.Add(FileDocumentoObj);
		}

		//AddCollection
		public void AddCollection(FileDocumentoCollection FileDocumentoCollectionObj)
		{
			foreach (FileDocumento FileDocumentoObj in FileDocumentoCollectionObj)
				this.Add(FileDocumentoObj);
		}

		//Insert
		public void Insert(int index, FileDocumento FileDocumentoObj)
		{
			if (FileDocumentoObj.Provider == null) FileDocumentoObj.Provider = this.Provider;
			base.Insert(index, FileDocumentoObj);
		}

		//CollectionGetById
		public FileDocumento CollectionGetById(NullTypes.IntNT IdFileValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdFile == IdFileValue))
					find = true;
				else
					i++;
			}
			if (find)
				return this[i];
			else
				return null;
		}
		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public FileDocumentoCollection SubSelect(NullTypes.IntNT IdFileEqualThis, NullTypes.IntNT IdDocumentoEqualThis, NullTypes.StringNT NomeEqualThis, 
NullTypes.StringNT TipoEqualThis, NullTypes.IntNT SizeFileEqualThis, NullTypes.StringNT DescrizioneEqualThis, 
NullTypes.IntNT IdArchivioFileEqualThis)
		{
			FileDocumentoCollection FileDocumentoCollectionTemp = new FileDocumentoCollection();
			foreach (FileDocumento FileDocumentoItem in this)
			{
				if (((IdFileEqualThis == null) || ((FileDocumentoItem.IdFile != null) && (FileDocumentoItem.IdFile.Value == IdFileEqualThis.Value))) && ((IdDocumentoEqualThis == null) || ((FileDocumentoItem.IdDocumento != null) && (FileDocumentoItem.IdDocumento.Value == IdDocumentoEqualThis.Value))) && ((NomeEqualThis == null) || ((FileDocumentoItem.Nome != null) && (FileDocumentoItem.Nome.Value == NomeEqualThis.Value))) && 
((TipoEqualThis == null) || ((FileDocumentoItem.Tipo != null) && (FileDocumentoItem.Tipo.Value == TipoEqualThis.Value))) && ((SizeFileEqualThis == null) || ((FileDocumentoItem.SizeFile != null) && (FileDocumentoItem.SizeFile.Value == SizeFileEqualThis.Value))) && ((DescrizioneEqualThis == null) || ((FileDocumentoItem.Descrizione != null) && (FileDocumentoItem.Descrizione.Value == DescrizioneEqualThis.Value))) && 
((IdArchivioFileEqualThis == null) || ((FileDocumentoItem.IdArchivioFile != null) && (FileDocumentoItem.IdArchivioFile.Value == IdArchivioFileEqualThis.Value))))
				{
					FileDocumentoCollectionTemp.Add(FileDocumentoItem);
				}
			}
			return FileDocumentoCollectionTemp;
		}



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