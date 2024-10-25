using System;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for FilieraCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class FilieraCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private FilieraCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((Filiera) info.GetValue(i.ToString(),typeof(Filiera)));
			}
		}

		//Costruttore
		public FilieraCollection()
		{
			this.ItemType = typeof(Filiera);
		}

		//Costruttore con provider
		public FilieraCollection(IFilieraProvider providerObj)
		{
			this.ItemType = typeof(Filiera);
			this.Provider = providerObj;
		}

		//Get e Set
		public new Filiera this[int index]
		{
			get { return (Filiera)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new FilieraCollection GetChanges()
		{
			return (FilieraCollection) base.GetChanges();
		}

		[NonSerialized] private IFilieraProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IFilieraProvider Provider
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
		public int Add(Filiera FilieraObj)
		{
			if (FilieraObj.Provider == null) FilieraObj.Provider = this.Provider;
			return base.Add(FilieraObj);
		}

		//AddCollection
		public void AddCollection(FilieraCollection FilieraCollectionObj)
		{
			foreach (Filiera FilieraObj in FilieraCollectionObj)
				this.Add(FilieraObj);
		}

		//Insert
		public void Insert(int index, Filiera FilieraObj)
		{
			if (FilieraObj.Provider == null) FilieraObj.Provider = this.Provider;
			base.Insert(index, FilieraObj);
		}

		//CollectionGetById
		public Filiera CollectionGetById(NullTypes.IntNT IdFilieraValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdFiliera == IdFilieraValue))
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
		public FilieraCollection SubSelect(NullTypes.IntNT IdFilieraEqualThis, NullTypes.StringNT CodTipoFilieraEqualThis, NullTypes.StringNT DenominazioneEqualThis, 
NullTypes.IntNT NumCertificatoEqualThis, NullTypes.DatetimeNT DataCertificatoEqualThis, NullTypes.DatetimeNT DataInserimentoEqualThis, 
NullTypes.DatetimeNT DataUltimaModificaEqualThis, NullTypes.StringNT OperatoreEqualThis)
		{
			FilieraCollection FilieraCollectionTemp = new FilieraCollection();
			foreach (Filiera FilieraItem in this)
			{
				if (((IdFilieraEqualThis == null) || ((FilieraItem.IdFiliera != null) && (FilieraItem.IdFiliera.Value == IdFilieraEqualThis.Value))) && ((CodTipoFilieraEqualThis == null) || ((FilieraItem.CodTipoFiliera != null) && (FilieraItem.CodTipoFiliera.Value == CodTipoFilieraEqualThis.Value))) && ((DenominazioneEqualThis == null) || ((FilieraItem.Denominazione != null) && (FilieraItem.Denominazione.Value == DenominazioneEqualThis.Value))) && 
((NumCertificatoEqualThis == null) || ((FilieraItem.NumCertificato != null) && (FilieraItem.NumCertificato.Value == NumCertificatoEqualThis.Value))) && ((DataCertificatoEqualThis == null) || ((FilieraItem.DataCertificato != null) && (FilieraItem.DataCertificato.Value == DataCertificatoEqualThis.Value))) && ((DataInserimentoEqualThis == null) || ((FilieraItem.DataInserimento != null) && (FilieraItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) && 
((DataUltimaModificaEqualThis == null) || ((FilieraItem.DataUltimaModifica != null) && (FilieraItem.DataUltimaModifica.Value == DataUltimaModificaEqualThis.Value))) && ((OperatoreEqualThis == null) || ((FilieraItem.Operatore != null) && (FilieraItem.Operatore.Value == OperatoreEqualThis.Value))))
				{
					FilieraCollectionTemp.Add(FilieraItem);
				}
			}
			return FilieraCollectionTemp;
		}



	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<FILIERA>
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
  <Finds />
  <Filters />
  <externalFields />
  <AddedFkFields />
</FILIERA>
*/