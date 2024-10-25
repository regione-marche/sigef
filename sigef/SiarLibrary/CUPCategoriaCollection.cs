using System;

/* STORIA
 * Data: 2016-05-24; Stato: Creazione; Autore: 
*/

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for CUPCategoriaCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class CUPCategoriaCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private CUPCategoriaCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
                this.Add((CUPCategoria)info.GetValue(i.ToString(), typeof(CUPCategoria)));
			}
		}

		//Costruttore
		public CUPCategoriaCollection()
		{
			this.ItemType = typeof(CUPCategoria);
		}

		//Costruttore con provider
        public CUPCategoriaCollection(ICUPCategoriaProvider providerObj)
		{
            this.ItemType = typeof(CUPCategoria);
			this.Provider = providerObj;
		}

		//Get e Set
        public new CUPCategoria this[int index]
		{
            get { return (CUPCategoria)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

        public new CUPCategoriaCollection GetChanges()
		{
            return (CUPCategoriaCollection)base.GetChanges();
		}

        [NonSerialized] private ICUPCategoriaProvider _provider;
        [System.Xml.Serialization.XmlIgnore] public ICUPCategoriaProvider Provider
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
        public int Add(CUPCategoria CUPCategoriaObj)
		{
            if (CUPCategoriaObj.Provider == null) CUPCategoriaObj.Provider = this.Provider;
            return base.Add(CUPCategoriaObj);
		}

		//AddCollection
        public void AddCollection(CUPCategoriaCollection ClassificazioneCUPCollectionObj)
		{
            foreach (CUPCategoria ClassificazioneCUPObj in ClassificazioneCUPCollectionObj)
                this.Add(ClassificazioneCUPObj);
		}

		//Insert
        public void Insert(int index, CUPCategoria CUPCategoriaObj)
		{
            if (CUPCategoriaObj.Provider == null) CUPCategoriaObj.Provider = this.Provider;
            base.Insert(index, CUPCategoriaObj);
		}

		//CollectionGetById
        public CUPCategoria CollectionGetById(NullTypes.StringNT IdCUPCategoriaValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
                if ((this[i].IdCategoria == IdCUPCategoriaValue))
					find = true;
				else
					i++;
			}
			if (find)
				return this[i];
			else
				return null;
		}
	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<TIPO_CUP_CATEGORIE>
  <ViewName>
  </ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>False</chkDataModifica>
  <chkCase>False</chkCase>
  <chkCache>False</chkCache>
  <PLName>SiarPLL</PLName>
  <DALName>SiarDAL</DALName>
  <BLLName>SiarBLL</BLLName>
  <TypeNameSpaceName>SiarLibrary</TypeNameSpaceName>
  <Finds>
    <Find>
      <COD_CUP_CATEGORIE>Equal</COD_CUP_CATEGORIE>
      <Settore>Equal</Settore>
      <Sottosettore>Equal</Sottosettore>
      <Descrizione>Like</Descrizione>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</TIPO_CUP_CATEGORIE>
*/