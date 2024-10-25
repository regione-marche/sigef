using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SiarLibrary;



namespace SiarLibrary
{

    /// <summary>
    /// Summary description for DatiRiassuntiviRendicontazione
    /// Class Autogenerata
    /// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
    /// con delle partial class contenenti i metodi aggiunti, in questo modo 
    /// non verranno sovrascritti quando si rigenera la classe 
    /// </summary>

    [Serializable]
    [System.Xml.Serialization.XmlType(Namespace = "")]

    public partial class DatiRiassuntiviRendicontazione : BaseObject
    {

        //Definizione dei campi 'base'
        private NullTypes.IntNT _Dettaglio;
        private NullTypes.StringNT _Azione;
        private NullTypes.StringNT _Intervento;
        private NullTypes.StringNT _Bando;
        private NullTypes.DecimalNT _ImportoAmmesso;
        private NullTypes.DecimalNT _ContributoUE;
        private NullTypes.DecimalNT _ContributoStato;
        private NullTypes.DecimalNT _ContributoRegione;
        private NullTypes.DecimalNT _ImportoPrivato;
        private NullTypes.StringNT _Rup;

        //Costruttore
        public DatiRiassuntiviRendicontazione()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        /// <summary>
        /// Corrisponde al campo:Asse
        /// Tipo sul db:CHAR(3)
        /// </summary>
        /// 
        public NullTypes.IntNT Dettaglio
        {
            get { return _Dettaglio; }
            set
            {
                if (Dettaglio != value)
                {
                    _Dettaglio = value;
                    SetDirtyFlag();
                }
            }
        }
        public NullTypes.StringNT Azione
        {
            get { return _Azione; }
            set
            {
                if (Azione != value)
                {
                    _Azione = value;
                    SetDirtyFlag();
                }
            }
        }

        public NullTypes.StringNT Rup
        {
            get { return _Rup; }
            set
            {
                if (Rup != value)
                {
                    _Rup = value;
                    SetDirtyFlag();
                }
            }
        }
        public NullTypes.StringNT Intervento
        {
            get { return _Intervento; }
            set
            {
                if (Intervento != value)
                {
                    _Intervento = value;
                    SetDirtyFlag();
                }
            }
        }

        public NullTypes.StringNT Bando
        {
            get { return _Bando; }
            set
            {
                if (Bando != value)
                {
                    _Bando = value;
                    SetDirtyFlag();
                }
            }
        }
        /// <summary>
        /// Corrisponde al campo:ImportoAmmesso
        /// Tipo sul db:DECIMAL(10,2)
        /// </summary>
        public NullTypes.DecimalNT ImportoAmmesso
        {
            get { return _ImportoAmmesso; }
            set
            {
                if (ImportoAmmesso != value)
                {
                    _ImportoAmmesso = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ContributoUE
        /// Tipo sul db:DECIMAL(10,2)
        /// </summary>
        public NullTypes.DecimalNT ContributoUE
        {
            get { return _ContributoUE; }
            set
            {
                if (ContributoUE != value)
                {
                    _ContributoUE = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ContributoStato
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT ContributoStato
        {
            get { return _ContributoStato; }
            set
            {
                if (ContributoStato != value)
                {
                    _ContributoStato = value;
                    SetDirtyFlag();
                }
            }
        }
        /// <summary>
        /// Corrisponde al campo:ContributoRegione
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT ContributoRegione
        {
            get { return _ContributoRegione; }
            set
            {
                if (ContributoRegione != value)
                {
                    _ContributoRegione = value;
                    SetDirtyFlag();
                }
            }
        }
        /// <summary>
        /// Corrisponde al campo:ImportoPrivato
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT ImportoPrivato
        {
            get { return _ImportoPrivato; }
            set
            {
                if (ImportoPrivato != value)
                {
                    _ImportoPrivato = value;
                    SetDirtyFlag();
                }
            }
        }
        //getFromDatareader
        public static DatiRiassuntiviRendicontazione GetFromDatareader(DbProvider db)
        {
            DatiRiassuntiviRendicontazione RendiDettaglioObj = new DatiRiassuntiviRendicontazione();
            RendiDettaglioObj._Azione = new SiarLibrary.NullTypes.StringNT(db.DataReader["Azione"]);
            RendiDettaglioObj._Dettaglio= new SiarLibrary.NullTypes.IntNT(db.DataReader["Dettaglio"]);
            RendiDettaglioObj._Intervento = new SiarLibrary.NullTypes.StringNT(db.DataReader["Intervento"]);
            RendiDettaglioObj._Bando = new SiarLibrary.NullTypes.StringNT(db.DataReader["Bando"]);
            RendiDettaglioObj._ImportoAmmesso = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["Importo_Ammesso"]);
            RendiDettaglioObj._ContributoUE = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["contributo_ue"]);
            RendiDettaglioObj._ContributoStato = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["contributo_stato"]);
            RendiDettaglioObj._ContributoRegione = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["contributo_regione"]);
            RendiDettaglioObj._ImportoPrivato = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["Importo_Privato"]);
            RendiDettaglioObj._ImportoAmmesso = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["Importo_Ammesso"]);
            RendiDettaglioObj._ContributoUE = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["contributo_ue"]);
            RendiDettaglioObj._ContributoStato = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["contributo_stato"]);
            RendiDettaglioObj._ContributoRegione = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["contributo_regione"]);
            RendiDettaglioObj._ImportoPrivato = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["Importo_Privato"]);
            RendiDettaglioObj._Rup = new SiarLibrary.NullTypes.StringNT(db.DataReader["RUP"]);

            return RendiDettaglioObj;
        }
    }
}

namespace SiarLibrary
{

    /// <summary>
    /// Summary description for DatiRiassuntiviRendicontazioneCollection
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class DatiRiassuntiviRendicontazioneCollection : CustomCollection, System.Runtime.Serialization.ISerializable
    {

        //Serializzazione xml
        public void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
        {
            info.AddValue("_count", this.Count);
            for (int i = 0; i < this.Count; i++)
            {
                info.AddValue(i.ToString(), this[i]);
            }
        }
        private DatiRiassuntiviRendicontazioneCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((DatiRiassuntiviRendicontazione)info.GetValue(i.ToString(), typeof(DatiRiassuntiviRendicontazione)));
            }
        }

        //Costruttore
        public DatiRiassuntiviRendicontazioneCollection()
        {
            this.ItemType = typeof(DatiRiassuntiviRendicontazione);
        }
              
        //Get e Set
        public new DatiRiassuntiviRendicontazione this[int index]
        {
            get { return (DatiRiassuntiviRendicontazione)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new DatiRiassuntiviRendicontazioneCollection GetChanges()
        {
            return (DatiRiassuntiviRendicontazioneCollection)base.GetChanges();
        }

        //Add
        public int Add(DatiRiassuntiviRendicontazione DatiRiassuntiviRendicontazione)
        {
            return base.Add(DatiRiassuntiviRendicontazione);
        }
     
        //AddCollection
        public void AddCollection(DatiRiassuntiviRendicontazioneCollection DatiRiassuntiviRendicontazioneCollectionObj)
        {
            foreach (DatiRiassuntiviRendicontazione DatiRiassuntiviRendicontazioneObj in DatiRiassuntiviRendicontazioneCollectionObj)
                this.Add(DatiRiassuntiviRendicontazioneObj);
        }

        //Insert
        public void Insert(int index, DatiRiassuntiviRendicontazione DatiRiassuntiviRendicontazioneObj)
        {
            base.Insert(index, DatiRiassuntiviRendicontazioneObj);
        }
      
        //filter: effettua una ricerca all'interno della collection
        // se il parametro di ricerca è null, prende tutto,
        // anche i record che hanno quel campo null
        // altrimenti scarta i record che hanno quel campo null ...
        // ...e confronta gli altri
        public DatiRiassuntiviRendicontazioneCollection SubSelect(NullTypes.StringNT AzioneEqualThis, NullTypes.DecimalNT ImportoAmmessoEqualThis, NullTypes.DecimalNT ContributoUEEqualThis, NullTypes.DecimalNT ContributoStatoEqualThis,
NullTypes.DecimalNT ContributoRegioneEqualThis, NullTypes.DecimalNT ImportoPrivatoEqualThis)
        {
            DatiRiassuntiviRendicontazioneCollection DatiRiassuntiviRendicontazioneCollectionTemp = new DatiRiassuntiviRendicontazioneCollection();
            foreach (DatiRiassuntiviRendicontazione DatiRiassuntiviRendicontazioneItem in this)
            {
                if (((AzioneEqualThis == null) || ((DatiRiassuntiviRendicontazioneItem.Azione != null) && (DatiRiassuntiviRendicontazioneItem.Azione.Value == AzioneEqualThis.Value))) && ((ContributoUEEqualThis == null) || ((DatiRiassuntiviRendicontazioneItem.ContributoUE != null) && (DatiRiassuntiviRendicontazioneItem.ContributoUE.Value == ContributoUEEqualThis.Value))) &&
((ContributoStatoEqualThis == null) || ((DatiRiassuntiviRendicontazioneItem.ContributoStato != null) && (DatiRiassuntiviRendicontazioneItem.ContributoStato.Value == ContributoStatoEqualThis.Value))) && ((ContributoRegioneEqualThis == null) || ((DatiRiassuntiviRendicontazioneItem.ContributoRegione != null) && (DatiRiassuntiviRendicontazioneItem.ContributoRegione.Value == ContributoRegioneEqualThis.Value))) && ((ImportoPrivatoEqualThis == null) || ((DatiRiassuntiviRendicontazioneItem.ImportoAmmesso != null) && (DatiRiassuntiviRendicontazioneItem.ImportoAmmesso.Value == ImportoPrivatoEqualThis.Value))))
                {
                    DatiRiassuntiviRendicontazioneCollectionTemp.Add(DatiRiassuntiviRendicontazioneItem);
                }
            }
            return DatiRiassuntiviRendicontazioneCollectionTemp;
        }



    }
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<CertSp_Dettaglio>
  <ViewName>vCertSp_Dettaglio</ViewName>
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
</CertSp_Dettaglio>
*/
