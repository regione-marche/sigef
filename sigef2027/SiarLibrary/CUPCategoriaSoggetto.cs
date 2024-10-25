using System;
using System.ComponentModel;

/* STORIA
 * Data: 2016-05-26; Stato: Creazione; Autore: 
*/

namespace SiarLibrary
{

    // interfaccia provider per CUPCategoriaSoggetto
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
    public interface ICUPCategoriaSoggettoProvider
	{
        int Save(CUPCategoriaSoggetto CUPCategoriaSoggettoObj);
        int SaveCollection(CUPCategoriaSoggettoCollection collectionObj);
        int Delete(CUPCategoriaSoggetto CUPCategoriaSoggettoObj);
        int DeleteCollection(CUPCategoriaSoggettoCollection collectionObj);
	}
	/// <summary>
	/// Summary description for Indirizzo
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public class CUPCategoriaSoggetto: BaseObject
	{

		//Definizione dei campi 'base'
        private NullTypes.StringNT _IdCategoria;
        private NullTypes.StringNT _CodiceCategoria;
        private NullTypes.StringNT _CodiceSottocategoria;
		private NullTypes.StringNT _Descrizione;
		[NonSerialized] private ICUPCategoriaSoggettoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ICUPCategoriaSoggettoProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
        public CUPCategoriaSoggetto()
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
        public NullTypes.StringNT CodiceCategoria
        {
            get { return _CodiceCategoria; }
            set
            {
                if (CodiceCategoria != value)
                {
                    _CodiceCategoria = value;
                    SetDirtyFlag();
                }
            }
        }


        /// <summary>
        /// Corrisponde al campo: SottoSettore
        /// Tipo sul db:CHAR(2)
        /// </summary>
        public NullTypes.StringNT CodiceSottocategoria
        {
            get { return _CodiceSottocategoria; }
            set
            {
                if (CodiceSottocategoria != value)
                {
                    _CodiceSottocategoria = value;
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
<TIPO_CUP_CATEGORIE_SOGGETTI>
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
      <COD_CUP_CATEGORIE_SOGGETTI>Equal</COD_CUP_CATEGORIE_SOGGETTI>
      <Descrizione>Like</Descrizione>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</TIPO_CUP_CATEGORIE_SOGGETTI>
*/