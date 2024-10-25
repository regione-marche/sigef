using System;
using System.ComponentModel;

/* STORIA
 * Data: 2016-05-24; Statoo: Creazione; Autore: 
*/

namespace SiarLibrary
{

    // interfaccia provider per DatiMonitoraggioFESR
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
    public interface IDatiMonitoraggioFESRProvider
	{
        int Save(DatiMonitoraggioFESR DatiMonitoraggioFESRObj);
        int SaveCollection(DatiMonitoraggioFESRCollection collectionObj);
        int Delete(DatiMonitoraggioFESR DatiMonitoraggioFESRObj);
        int DeleteCollection(DatiMonitoraggioFESRCollection collectionObj);
	}
	/// <summary>
    /// Summary description for DatiMonitoraggioFESR
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public class DatiMonitoraggioFESR: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdDatiMonitoraggioFESR;
		private NullTypes.IntNT _IdProgetto;
        private NullTypes.StringNT _IdCUPCategoria;
        private NullTypes.StringNT _IdCUPCategoriaSoggetto;
        private NullTypes.StringNT _IdTemaPrioritario;
        private NullTypes.StringNT _IdAteco2007;
        private NullTypes.StringNT _IdAttivitaEcon;
        private NullTypes.StringNT _IdCPTSettore;
        private NullTypes.StringNT _IdDimensioneTerr;
        private NullTypes.StringNT _IdCUPNatura;
        private NullTypes.StringNT _IdCUPCategoriaTipoOperazione;

		[NonSerialized] private IDatiMonitoraggioFESRProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IDatiMonitoraggioFESRProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
        public DatiMonitoraggioFESR()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_BILANCIO_AGRICOLO
		/// Tipo sul db:INT
		/// </summary>
        public NullTypes.IntNT IdDatiMonitoraggioFESR
		{
            get { return _IdDatiMonitoraggioFESR; }
			set {
                if (IdDatiMonitoraggioFESR != value)
				{
                    _IdDatiMonitoraggioFESR = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_PROGETTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdProgetto
		{
			get { return _IdProgetto; }
			set {
				if (IdProgetto != value)
				{
					_IdProgetto = value;
					SetDirtyFlag();
				}
			}
		}

        /// <summary>
        /// Corrisponde al campo:CUP_CATEGORIA
        /// Tipo sul db:CHAR(7)
        /// </summary>
        public NullTypes.StringNT IdCUPCategoria
        {
            get { return _IdCUPCategoria; }
            set
            {
                if (IdCUPCategoria != value)
                {
                    _IdCUPCategoria = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:CUP_CATEGORIA_SOGGETTO
        /// Tipo sul db:CHAR(6)
        /// </summary>
        public NullTypes.StringNT IdCUPCategoriaSoggetto
        {
            get { return _IdCUPCategoriaSoggetto; }
            set
            {
                if (IdCUPCategoriaSoggetto != value)
                {
                    _IdCUPCategoriaSoggetto = value;
                    SetDirtyFlag();
                }
            }
        }


        /// <summary>
        /// Corrisponde al campo:TEMA_PRIORITARIO
        /// Tipo sul db:CHAR(2)
        /// </summary>
        public NullTypes.StringNT IdTemaPrioritario
        {
            get { return _IdTemaPrioritario; }
            set
            {
                if (IdTemaPrioritario != value)
                {
                    _IdTemaPrioritario = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_ATECO
        /// Tipo sul db:CHAR(9)
        /// </summary>
        public NullTypes.StringNT IdAteco2007
        {
            get { return _IdAteco2007; }
            set
            {
                if (IdAteco2007 != value)
                {
                    _IdAteco2007 = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ATTIVITA_ECON
        /// Tipo sul db:CHAR(2)
        /// </summary>
        public NullTypes.StringNT IdAttivitaEcon
        {
            get { return _IdAttivitaEcon; }
            set
            {
                if (IdAttivitaEcon != value)
                {
                    _IdAttivitaEcon = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:CPT_SETTORE
        /// Tipo sul db:CHAR(2)
        /// </summary>
        public NullTypes.StringNT IdCPTSettore
        {
            get { return _IdCPTSettore; }
            set
            {
                if (IdCPTSettore != value)
                {
                    _IdCPTSettore = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:CUP_DIMENSIONE_TERR
        /// Tipo sul db:CHAR(2)
        /// </summary>
        public NullTypes.StringNT IdDimensioneTerr 
        {
            get { return _IdDimensioneTerr; }
            set
            {
                if (IdDimensioneTerr != value)
                {
                    _IdDimensioneTerr = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:CUP_NATURA
        /// Tipo sul db:CHAR(2)
        /// </summary>
        public NullTypes.StringNT IdCUPNatura
        {
            get { return _IdCUPNatura; }
            set
            {
                if (IdCUPNatura != value)
                {
                    _IdCUPNatura = value;
                    SetDirtyFlag();
                }
            }
        }


        /// <summary>
        /// Corrisponde al campo:CUP_CATEGORIA_TIPOOPER
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.StringNT IdCUPCategoriaTipoOperazione
        {
            get { return _IdCUPCategoriaTipoOperazione; }
            set
            {
                if (IdCUPCategoriaTipoOperazione != value)
                {
                    _IdCUPCategoriaTipoOperazione = value;
                    SetDirtyFlag();
                }
            }
        }  


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
<DATI_MONITORAGGIO_FESR>
  <ViewName>
  </ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>True</chkDataModifica>
  <chkOptimisticCouncurrency>False</chkOptimisticCouncurrency>
  <chkShortNames>False</chkShortNames>
  <chkCase>False</chkCase>
  <chkCache>False</chkCache>
  <PLName>SiarPLL</PLName>
  <DALName>SiarDAL</DALName>
  <BLLName>SiarBLL</BLLName>
  <TypeNameSpaceName>SiarLibrary</TypeNameSpaceName>
  <Finds>
    <Find OrderBy="ORDER BY ">
      <ID_DATI_MONIT>Equal</ID_DATI_MONIT>
      <ID_PROGETTO>Equal</ID_PROGETTO>
    </Find>
  </Finds>
  <Filters>
  </Filters>
  <externalFields />
  <AddedFkFields />
</DATI_MONITORAGGIO_FESR>
*/