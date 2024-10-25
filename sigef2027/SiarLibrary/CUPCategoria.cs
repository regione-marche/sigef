using System;
using System.ComponentModel;

/* STORIA
 * Data: 2016-05-24; Stato: Creazione; Autore: 
*/

namespace SiarLibrary
{

	// interfaccia provider per CUPCategoria
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
    public interface ICUPCategoriaProvider
	{
        int Save(CUPCategoria CUPCategoriaObj);
		int SaveCollection(CUPCategoriaCollection collectionObj);
        int Delete(CUPCategoria CUPCategoriaObj);
		int DeleteCollection(CUPCategoriaCollection collectionObj);
	}
	/// <summary>
	/// Summary description for Indirizzo
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public class CUPCategoria: BaseObject
	{

		//Definizione dei campi 'base'
        private NullTypes.StringNT _IdCategoria;
        private NullTypes.StringNT _Settore;
        private NullTypes.StringNT _SottoSettore;
        private NullTypes.StringNT _Categoria;
		private NullTypes.StringNT _Descrizione;
		[NonSerialized] private ICUPCategoriaProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ICUPCategoriaProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
        public CUPCategoria()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
        /// Corrisponde al campo: ID_CUP_CATEGORIA
		/// Tipo sul db:INT
		/// </summary>
        public NullTypes.StringNT IdCategoria
		{
            get { return _IdCategoria; }
			set {
                if (IdCategoria != value)
				{
                    _IdCategoria = value;
					SetDirtyFlag();
				}
			}
		}

        /// <summary>
        /// Corrisponde al campo: Settore
        /// Tipo sul db:CHAR(2)
        /// </summary>
        public NullTypes.StringNT Settore
        {
            get { return _Settore; }
            set
            {
                if (Settore != value)
                {
                    _Settore = value;
                    SetDirtyFlag();
                }
            }
        }


        /// <summary>
        /// Corrisponde al campo: SottoSettore
        /// Tipo sul db:CHAR(2)
        /// </summary>
        public NullTypes.StringNT SottoSettore
        {
            get { return _SottoSettore; }
            set
            {
                if (SottoSettore != value)
                {
                    _SottoSettore = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo: Categoria
        /// Tipo sul db:CHAR(3)
        /// </summary>
        public NullTypes.StringNT Categoria
        {
            get { return _Categoria; }
            set
            {
                if (Categoria != value)
                {
                    _Categoria = value;
                    SetDirtyFlag();
                }
            }
        }


        /// <summary>
        /// Corrisponde al campo: Descrizione
        /// Tipo sul db:NVARCHAR(255)(3)
        /// </summary>
        public NullTypes.StringNT Descrizione
        {
            get { return _Descrizione; }
            set
            {
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
      <Descrizione>Like</Descrizione>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</TIPO_CUP_CATEGORIE>
*/