using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

    // interfaccia provider per ProgettoStoricoModifiche
    // Interfaccia Autogenerata
    // Inserire eventuali operazioni aggiuntive
    public interface IProgettoStoricoModificheProvider
    {
        int Save(ProgettoStoricoModifiche ProgettoStoricoModificheObj);
        int SaveCollection(ProgettoStoricoModificheCollection collectionObj);
        int Delete(ProgettoStoricoModifiche ProgettoStoricoModificheObj);
        int DeleteCollection(ProgettoStoricoModificheCollection collectionObj);
    }
    /// <summary>
    /// Summary description for ProgettoStoricoModifiche
    /// Class Autogenerata
    /// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
    /// con delle partial class contenenti i metodi aggiunti, in questo modo 
    /// non verranno sovrascritti quando si rigenera la classe 
    /// </summary>

    [Serializable]
    [System.Xml.Serialization.XmlType(Namespace = "")]

    public partial class ProgettoStoricoModifiche : BaseObject
    {

        //Definizione dei campi 'base'
        private NullTypes.IntNT _Id;
        private NullTypes.IntNT _IdModifica;
        private NullTypes.IntNT _IdProgettoStorico;
        private NullTypes.IntNT _IdProgetto;
        private NullTypes.StringNT _CodStato;
        private NullTypes.DatetimeNT _Data;
        private NullTypes.IntNT _Operatore;
        private NullTypes.StringNT _Segnatura;
        private NullTypes.BoolNT _Revisione;
        private NullTypes.BoolNT _Riesame;
        private NullTypes.BoolNT _Ricorso;
        private NullTypes.BoolNT _RiaperturaProvinciale;
        private NullTypes.DatetimeNT _DataRi;
        private NullTypes.IntNT _OperatoreRi;
        private NullTypes.StringNT _SegnaturaRi;
        private NullTypes.StringNT _Stato;
        private NullTypes.StringNT _CodFase;
        private NullTypes.IntNT _OrdineStato;
        private NullTypes.StringNT _Fase;
        private NullTypes.IntNT _OrdineFase;
        private NullTypes.StringNT _Nominativo;
        private NullTypes.StringNT _CodEnte;
        private NullTypes.StringNT _Provincia;
        private NullTypes.IntNT _IdProfilo;
        private NullTypes.StringNT _Profilo;
        private NullTypes.StringNT _Ente;
        private NullTypes.StringNT _CodTipoEnte;
        private NullTypes.IntNT _IdAtto;
        [NonSerialized] private IProgettoStoricoModificheProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IProgettoStoricoModificheProvider Provider
        {
            get { return _provider; }
            set { _provider = value; }
        }


        //Costruttore
        public ProgettoStoricoModifiche()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //Get e Set dei campi 'base'
        /// <summary>
        /// Corrisponde al campo:ID
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT Id
        {
            get { return _Id; }
            set
            {
                if (Id != value)
                {
                    _Id = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_MODIFICA
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdModifica
        {
            get { return _IdModifica; }
            set
            {
                if (IdModifica != value)
                {
                    _IdModifica = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_PROGETTO_STORICO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdProgettoStorico
        {
            get { return _IdProgettoStorico; }
            set
            {
                if (IdProgettoStorico != value)
                {
                    _IdProgettoStorico = value;
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
            set
            {
                if (IdProgetto != value)
                {
                    _IdProgetto = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:COD_STATO
        /// Tipo sul db:CHAR(1)
        /// </summary>
        public NullTypes.StringNT CodStato
        {
            get { return _CodStato; }
            set
            {
                if (CodStato != value)
                {
                    _CodStato = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT Data
        {
            get { return _Data; }
            set
            {
                if (Data != value)
                {
                    _Data = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:OPERATORE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT Operatore
        {
            get { return _Operatore; }
            set
            {
                if (Operatore != value)
                {
                    _Operatore = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:SEGNATURA
        /// Tipo sul db:VARCHAR(100)
        /// </summary>
        public NullTypes.StringNT Segnatura
        {
            get { return _Segnatura; }
            set
            {
                if (Segnatura != value)
                {
                    _Segnatura = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:REVISIONE
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT Revisione
        {
            get { return _Revisione; }
            set
            {
                if (Revisione != value)
                {
                    _Revisione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:RIESAME
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT Riesame
        {
            get { return _Riesame; }
            set
            {
                if (Riesame != value)
                {
                    _Riesame = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:RICORSO
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT Ricorso
        {
            get { return _Ricorso; }
            set
            {
                if (Ricorso != value)
                {
                    _Ricorso = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:RIAPERTURA_PROVINCIALE
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT RiaperturaProvinciale
        {
            get { return _RiaperturaProvinciale; }
            set
            {
                if (RiaperturaProvinciale != value)
                {
                    _RiaperturaProvinciale = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_RI
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataRi
        {
            get { return _DataRi; }
            set
            {
                if (DataRi != value)
                {
                    _DataRi = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:OPERATORE_RI
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT OperatoreRi
        {
            get { return _OperatoreRi; }
            set
            {
                if (OperatoreRi != value)
                {
                    _OperatoreRi = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:SEGNATURA_RI
        /// Tipo sul db:VARCHAR(100)
        /// </summary>
        public NullTypes.StringNT SegnaturaRi
        {
            get { return _SegnaturaRi; }
            set
            {
                if (SegnaturaRi != value)
                {
                    _SegnaturaRi = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:STATO
        /// Tipo sul db:VARCHAR(80)
        /// </summary>
        public NullTypes.StringNT Stato
        {
            get { return _Stato; }
            set
            {
                if (Stato != value)
                {
                    _Stato = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:COD_FASE
        /// Tipo sul db:CHAR(1)
        /// </summary>
        public NullTypes.StringNT CodFase
        {
            get { return _CodFase; }
            set
            {
                if (CodFase != value)
                {
                    _CodFase = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ORDINE_STATO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT OrdineStato
        {
            get { return _OrdineStato; }
            set
            {
                if (OrdineStato != value)
                {
                    _OrdineStato = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:FASE
        /// Tipo sul db:VARCHAR(100)
        /// </summary>
        public NullTypes.StringNT Fase
        {
            get { return _Fase; }
            set
            {
                if (Fase != value)
                {
                    _Fase = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ORDINE_FASE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT OrdineFase
        {
            get { return _OrdineFase; }
            set
            {
                if (OrdineFase != value)
                {
                    _OrdineFase = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:NOMINATIVO
        /// Tipo sul db:VARCHAR(511)
        /// </summary>
        public NullTypes.StringNT Nominativo
        {
            get { return _Nominativo; }
            set
            {
                if (Nominativo != value)
                {
                    _Nominativo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:COD_ENTE
        /// Tipo sul db:VARCHAR(10)
        /// </summary>
        public NullTypes.StringNT CodEnte
        {
            get { return _CodEnte; }
            set
            {
                if (CodEnte != value)
                {
                    _CodEnte = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:PROVINCIA
        /// Tipo sul db:CHAR(2)
        /// </summary>
        public NullTypes.StringNT Provincia
        {
            get { return _Provincia; }
            set
            {
                if (Provincia != value)
                {
                    _Provincia = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_PROFILO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdProfilo
        {
            get { return _IdProfilo; }
            set
            {
                if (IdProfilo != value)
                {
                    _IdProfilo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:PROFILO
        /// Tipo sul db:VARCHAR(255)
        /// </summary>
        public NullTypes.StringNT Profilo
        {
            get { return _Profilo; }
            set
            {
                if (Profilo != value)
                {
                    _Profilo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ENTE
        /// Tipo sul db:VARCHAR(255)
        /// </summary>
        public NullTypes.StringNT Ente
        {
            get { return _Ente; }
            set
            {
                if (Ente != value)
                {
                    _Ente = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:COD_TIPO_ENTE
        /// Tipo sul db:VARCHAR(10)
        /// </summary>
        public NullTypes.StringNT CodTipoEnte
        {
            get { return _CodTipoEnte; }
            set
            {
                if (CodTipoEnte != value)
                {
                    _CodTipoEnte = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_ATTO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdAtto
        {
            get { return _IdAtto; }
            set
            {
                if (IdAtto != value)
                {
                    _IdAtto = value;
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

namespace SiarLibrary
{

    /// <summary>
    /// Summary description for ProgettoStoricoModificheCollection
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class ProgettoStoricoModificheCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
        private ProgettoStoricoModificheCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((ProgettoStoricoModifiche)info.GetValue(i.ToString(), typeof(ProgettoStoricoModifiche)));
            }
        }

        //Costruttore
        public ProgettoStoricoModificheCollection()
        {
            this.ItemType = typeof(ProgettoStoricoModifiche);
        }

        //Costruttore con provider
        public ProgettoStoricoModificheCollection(IProgettoStoricoModificheProvider providerObj)
        {
            this.ItemType = typeof(ProgettoStoricoModifiche);
            this.Provider = providerObj;
        }

        //Get e Set
        public new ProgettoStoricoModifiche this[int index]
        {
            get { return (ProgettoStoricoModifiche)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new ProgettoStoricoModificheCollection GetChanges()
        {
            return (ProgettoStoricoModificheCollection)base.GetChanges();
        }

        [NonSerialized] private IProgettoStoricoModificheProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IProgettoStoricoModificheProvider Provider
        {
            get { return _provider; }
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
        public int Add(ProgettoStoricoModifiche ProgettoStoricoModificheObj)
        {
            if (ProgettoStoricoModificheObj.Provider == null) ProgettoStoricoModificheObj.Provider = this.Provider;
            return base.Add(ProgettoStoricoModificheObj);
        }

        //AddCollection
        public void AddCollection(ProgettoStoricoModificheCollection ProgettoStoricoModificheCollectionObj)
        {
            foreach (ProgettoStoricoModifiche ProgettoStoricoModificheObj in ProgettoStoricoModificheCollectionObj)
                this.Add(ProgettoStoricoModificheObj);
        }

        //Insert
        public void Insert(int index, ProgettoStoricoModifiche ProgettoStoricoModificheObj)
        {
            if (ProgettoStoricoModificheObj.Provider == null) ProgettoStoricoModificheObj.Provider = this.Provider;
            base.Insert(index, ProgettoStoricoModificheObj);
        }

        //CollectionGetById
        public ProgettoStoricoModifiche CollectionGetById(NullTypes.IntNT IdValue)
        {
            int i = 0;
            bool find = false;
            while ((i < this.Count) && (!find))
            {
                if ((this[i].Id == IdValue))
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
        public ProgettoStoricoModificheCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.IntNT IdModificaEqualThis, NullTypes.IntNT IdProgettoStoricoEqualThis,
NullTypes.IntNT IdProgettoEqualThis, NullTypes.StringNT CodStatoEqualThis, NullTypes.DatetimeNT DataEqualThis,
NullTypes.IntNT OperatoreEqualThis, NullTypes.StringNT SegnaturaEqualThis, NullTypes.BoolNT RevisioneEqualThis,
NullTypes.BoolNT RiesameEqualThis, NullTypes.BoolNT RicorsoEqualThis, NullTypes.BoolNT RiaperturaProvincialeEqualThis,
NullTypes.DatetimeNT DataRiEqualThis, NullTypes.IntNT OperatoreRiEqualThis, NullTypes.StringNT SegnaturaRiEqualThis,
NullTypes.StringNT StatoEqualThis, NullTypes.StringNT CodFaseEqualThis, NullTypes.IntNT OrdineStatoEqualThis,
NullTypes.StringNT FaseEqualThis, NullTypes.IntNT OrdineFaseEqualThis, NullTypes.StringNT NominativoEqualThis,
NullTypes.StringNT CodEnteEqualThis, NullTypes.StringNT ProvinciaEqualThis, NullTypes.IntNT IdProfiloEqualThis,
NullTypes.StringNT ProfiloEqualThis, NullTypes.StringNT EnteEqualThis, NullTypes.StringNT CodTipoEnteEqualThis,
NullTypes.IntNT IdAttoEqualThis)
        {
            ProgettoStoricoModificheCollection ProgettoStoricoModificheCollectionTemp = new ProgettoStoricoModificheCollection();
            foreach (ProgettoStoricoModifiche ProgettoStoricoModificheItem in this)
            {
                if (((IdEqualThis == null) || ((ProgettoStoricoModificheItem.Id != null) && (ProgettoStoricoModificheItem.Id.Value == IdEqualThis.Value))) && ((IdModificaEqualThis == null) || ((ProgettoStoricoModificheItem.IdModifica != null) && (ProgettoStoricoModificheItem.IdModifica.Value == IdModificaEqualThis.Value))) && ((IdProgettoStoricoEqualThis == null) || ((ProgettoStoricoModificheItem.IdProgettoStorico != null) && (ProgettoStoricoModificheItem.IdProgettoStorico.Value == IdProgettoStoricoEqualThis.Value))) &&
((IdProgettoEqualThis == null) || ((ProgettoStoricoModificheItem.IdProgetto != null) && (ProgettoStoricoModificheItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((CodStatoEqualThis == null) || ((ProgettoStoricoModificheItem.CodStato != null) && (ProgettoStoricoModificheItem.CodStato.Value == CodStatoEqualThis.Value))) && ((DataEqualThis == null) || ((ProgettoStoricoModificheItem.Data != null) && (ProgettoStoricoModificheItem.Data.Value == DataEqualThis.Value))) &&
((OperatoreEqualThis == null) || ((ProgettoStoricoModificheItem.Operatore != null) && (ProgettoStoricoModificheItem.Operatore.Value == OperatoreEqualThis.Value))) && ((SegnaturaEqualThis == null) || ((ProgettoStoricoModificheItem.Segnatura != null) && (ProgettoStoricoModificheItem.Segnatura.Value == SegnaturaEqualThis.Value))) && ((RevisioneEqualThis == null) || ((ProgettoStoricoModificheItem.Revisione != null) && (ProgettoStoricoModificheItem.Revisione.Value == RevisioneEqualThis.Value))) &&
((RiesameEqualThis == null) || ((ProgettoStoricoModificheItem.Riesame != null) && (ProgettoStoricoModificheItem.Riesame.Value == RiesameEqualThis.Value))) && ((RicorsoEqualThis == null) || ((ProgettoStoricoModificheItem.Ricorso != null) && (ProgettoStoricoModificheItem.Ricorso.Value == RicorsoEqualThis.Value))) && ((RiaperturaProvincialeEqualThis == null) || ((ProgettoStoricoModificheItem.RiaperturaProvinciale != null) && (ProgettoStoricoModificheItem.RiaperturaProvinciale.Value == RiaperturaProvincialeEqualThis.Value))) &&
((DataRiEqualThis == null) || ((ProgettoStoricoModificheItem.DataRi != null) && (ProgettoStoricoModificheItem.DataRi.Value == DataRiEqualThis.Value))) && ((OperatoreRiEqualThis == null) || ((ProgettoStoricoModificheItem.OperatoreRi != null) && (ProgettoStoricoModificheItem.OperatoreRi.Value == OperatoreRiEqualThis.Value))) && ((SegnaturaRiEqualThis == null) || ((ProgettoStoricoModificheItem.SegnaturaRi != null) && (ProgettoStoricoModificheItem.SegnaturaRi.Value == SegnaturaRiEqualThis.Value))) &&
((StatoEqualThis == null) || ((ProgettoStoricoModificheItem.Stato != null) && (ProgettoStoricoModificheItem.Stato.Value == StatoEqualThis.Value))) && ((CodFaseEqualThis == null) || ((ProgettoStoricoModificheItem.CodFase != null) && (ProgettoStoricoModificheItem.CodFase.Value == CodFaseEqualThis.Value))) && ((OrdineStatoEqualThis == null) || ((ProgettoStoricoModificheItem.OrdineStato != null) && (ProgettoStoricoModificheItem.OrdineStato.Value == OrdineStatoEqualThis.Value))) &&
((FaseEqualThis == null) || ((ProgettoStoricoModificheItem.Fase != null) && (ProgettoStoricoModificheItem.Fase.Value == FaseEqualThis.Value))) && ((OrdineFaseEqualThis == null) || ((ProgettoStoricoModificheItem.OrdineFase != null) && (ProgettoStoricoModificheItem.OrdineFase.Value == OrdineFaseEqualThis.Value))) && ((NominativoEqualThis == null) || ((ProgettoStoricoModificheItem.Nominativo != null) && (ProgettoStoricoModificheItem.Nominativo.Value == NominativoEqualThis.Value))) &&
((CodEnteEqualThis == null) || ((ProgettoStoricoModificheItem.CodEnte != null) && (ProgettoStoricoModificheItem.CodEnte.Value == CodEnteEqualThis.Value))) && ((ProvinciaEqualThis == null) || ((ProgettoStoricoModificheItem.Provincia != null) && (ProgettoStoricoModificheItem.Provincia.Value == ProvinciaEqualThis.Value))) && ((IdProfiloEqualThis == null) || ((ProgettoStoricoModificheItem.IdProfilo != null) && (ProgettoStoricoModificheItem.IdProfilo.Value == IdProfiloEqualThis.Value))) &&
((ProfiloEqualThis == null) || ((ProgettoStoricoModificheItem.Profilo != null) && (ProgettoStoricoModificheItem.Profilo.Value == ProfiloEqualThis.Value))) && ((EnteEqualThis == null) || ((ProgettoStoricoModificheItem.Ente != null) && (ProgettoStoricoModificheItem.Ente.Value == EnteEqualThis.Value))) && ((CodTipoEnteEqualThis == null) || ((ProgettoStoricoModificheItem.CodTipoEnte != null) && (ProgettoStoricoModificheItem.CodTipoEnte.Value == CodTipoEnteEqualThis.Value))) &&
((IdAttoEqualThis == null) || ((ProgettoStoricoModificheItem.IdAtto != null) && (ProgettoStoricoModificheItem.IdAtto.Value == IdAttoEqualThis.Value))))
                {
                    ProgettoStoricoModificheCollectionTemp.Add(ProgettoStoricoModificheItem);
                }
            }
            return ProgettoStoricoModificheCollectionTemp;
        }



    }
}

namespace SiarDAL
{

    /// <summary>
    /// Summary description for ProgettoStoricoModificheDAL
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>


    internal class ProgettoStoricoModificheDAL
    {

        //Operazioni

        //internal CompileIUCmd compila un command con i parametri per l'insert o l'update
        protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, ProgettoStoricoModifiche ProgettoStoricoModificheObj, string firstChar)
        {
            if (forUpdate)
            {
                // campi identity valorizzati solo per l'update
                DbProvider.SetCmdParam(cmd, firstChar + "Id", ProgettoStoricoModificheObj.Id);
                // altri campi sempre valorizzati
            }
            DbProvider.SetCmdParam(cmd, firstChar + "IdModifica", ProgettoStoricoModificheObj.IdModifica);
            DbProvider.SetCmdParam(cmd, firstChar + "IdProgettoStorico", ProgettoStoricoModificheObj.IdProgettoStorico);
            DbProvider.SetCmdParam(cmd, firstChar + "IdProgetto", ProgettoStoricoModificheObj.IdProgetto);
            DbProvider.SetCmdParam(cmd, firstChar + "CodStato", ProgettoStoricoModificheObj.CodStato);
            DbProvider.SetCmdParam(cmd, firstChar + "Data", ProgettoStoricoModificheObj.Data);
            DbProvider.SetCmdParam(cmd, firstChar + "Operatore", ProgettoStoricoModificheObj.Operatore);
            DbProvider.SetCmdParam(cmd, firstChar + "Segnatura", ProgettoStoricoModificheObj.Segnatura);
            DbProvider.SetCmdParam(cmd, firstChar + "Revisione", ProgettoStoricoModificheObj.Revisione);
            DbProvider.SetCmdParam(cmd, firstChar + "Riesame", ProgettoStoricoModificheObj.Riesame);
            DbProvider.SetCmdParam(cmd, firstChar + "Ricorso", ProgettoStoricoModificheObj.Ricorso);
            DbProvider.SetCmdParam(cmd, firstChar + "RiaperturaProvinciale", ProgettoStoricoModificheObj.RiaperturaProvinciale);
            DbProvider.SetCmdParam(cmd, firstChar + "DataRi", ProgettoStoricoModificheObj.DataRi);
            DbProvider.SetCmdParam(cmd, firstChar + "OperatoreRi", ProgettoStoricoModificheObj.OperatoreRi);
            DbProvider.SetCmdParam(cmd, firstChar + "SegnaturaRi", ProgettoStoricoModificheObj.SegnaturaRi);
            DbProvider.SetCmdParam(cmd, firstChar + "Stato", ProgettoStoricoModificheObj.Stato);
            DbProvider.SetCmdParam(cmd, firstChar + "CodFase", ProgettoStoricoModificheObj.CodFase);
            DbProvider.SetCmdParam(cmd, firstChar + "OrdineStato", ProgettoStoricoModificheObj.OrdineStato);
            DbProvider.SetCmdParam(cmd, firstChar + "Fase", ProgettoStoricoModificheObj.Fase);
            DbProvider.SetCmdParam(cmd, firstChar + "OrdineFase", ProgettoStoricoModificheObj.OrdineFase);
            DbProvider.SetCmdParam(cmd, firstChar + "Nominativo", ProgettoStoricoModificheObj.Nominativo);
            DbProvider.SetCmdParam(cmd, firstChar + "CodEnte", ProgettoStoricoModificheObj.CodEnte);
            DbProvider.SetCmdParam(cmd, firstChar + "Provincia", ProgettoStoricoModificheObj.Provincia);
            DbProvider.SetCmdParam(cmd, firstChar + "IdProfilo", ProgettoStoricoModificheObj.IdProfilo);
            DbProvider.SetCmdParam(cmd, firstChar + "Profilo", ProgettoStoricoModificheObj.Profilo);
            DbProvider.SetCmdParam(cmd, firstChar + "Ente", ProgettoStoricoModificheObj.Ente);
            DbProvider.SetCmdParam(cmd, firstChar + "CodTipoEnte", ProgettoStoricoModificheObj.CodTipoEnte);
            DbProvider.SetCmdParam(cmd, firstChar + "IdAtto", ProgettoStoricoModificheObj.IdAtto);
        }
        //Insert
        private static int Insert(DbProvider db, ProgettoStoricoModifiche ProgettoStoricoModificheObj)
        {
            int i = 1;
            try
            {
                IDbCommand insertCmd = db.InitCmd("ZProgettoStoricoModificheInsert", new string[] {"IdModifica", "IdProgettoStorico",
"IdProgetto", "CodStato", "Data",
"Operatore", "Segnatura", "Revisione",
"Riesame", "Ricorso", "RiaperturaProvinciale",
"DataRi", "OperatoreRi", "SegnaturaRi",
"Stato", "CodFase", "OrdineStato",
"Fase", "OrdineFase", "Nominativo",
"CodEnte", "Provincia", "IdProfilo",
"Profilo", "Ente", "CodTipoEnte",
"IdAtto"}, new string[] {"int", "int",
"int", "string", "DateTime",
"int", "string", "bool",
"bool", "bool", "bool",
"DateTime", "int", "string",
"string", "string", "int",
"string", "int", "string",
"string", "string", "int",
"string", "string", "string",
"int"}, "");
                CompileIUCmd(false, insertCmd, ProgettoStoricoModificheObj, db.CommandFirstChar);
                db.InitDatareader(insertCmd);
                if (db.DataReader.Read())
                {
                    ProgettoStoricoModificheObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
                }
                ProgettoStoricoModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ProgettoStoricoModificheObj.IsDirty = false;
                ProgettoStoricoModificheObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //update
        private static int Update(DbProvider db, ProgettoStoricoModifiche ProgettoStoricoModificheObj)
        {
            int i = 1;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZProgettoStoricoModificheUpdate", new string[] {"Id", "IdModifica", "IdProgettoStorico",
"IdProgetto", "CodStato", "Data",
"Operatore", "Segnatura", "Revisione",
"Riesame", "Ricorso", "RiaperturaProvinciale",
"DataRi", "OperatoreRi", "SegnaturaRi",
"Stato", "CodFase", "OrdineStato",
"Fase", "OrdineFase", "Nominativo",
"CodEnte", "Provincia", "IdProfilo",
"Profilo", "Ente", "CodTipoEnte",
"IdAtto"}, new string[] {"int", "int", "int",
"int", "string", "DateTime",
"int", "string", "bool",
"bool", "bool", "bool",
"DateTime", "int", "string",
"string", "string", "int",
"string", "int", "string",
"string", "string", "int",
"string", "string", "string",
"int"}, "");
                CompileIUCmd(true, updateCmd, ProgettoStoricoModificheObj, db.CommandFirstChar);
                i = db.Execute(updateCmd);
                ProgettoStoricoModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ProgettoStoricoModificheObj.IsDirty = false;
                ProgettoStoricoModificheObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //Save
        public static int Save(DbProvider db, ProgettoStoricoModifiche ProgettoStoricoModificheObj)
        {
            switch (ProgettoStoricoModificheObj.ObjectState)
            {
                case BaseObject.ObjectStateType.Added: return Insert(db, ProgettoStoricoModificheObj);
                case BaseObject.ObjectStateType.Changed: return Update(db, ProgettoStoricoModificheObj);
                case BaseObject.ObjectStateType.Deleted: return Delete(db, ProgettoStoricoModificheObj);
                default: return 0;
            }
        }

        public static int SaveCollection(DbProvider db, ProgettoStoricoModificheCollection ProgettoStoricoModificheCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZProgettoStoricoModificheUpdate", new string[] {"Id", "IdModifica", "IdProgettoStorico",
"IdProgetto", "CodStato", "Data",
"Operatore", "Segnatura", "Revisione",
"Riesame", "Ricorso", "RiaperturaProvinciale",
"DataRi", "OperatoreRi", "SegnaturaRi",
"Stato", "CodFase", "OrdineStato",
"Fase", "OrdineFase", "Nominativo",
"CodEnte", "Provincia", "IdProfilo",
"Profilo", "Ente", "CodTipoEnte",
"IdAtto"}, new string[] {"int", "int", "int",
"int", "string", "DateTime",
"int", "string", "bool",
"bool", "bool", "bool",
"DateTime", "int", "string",
"string", "string", "int",
"string", "int", "string",
"string", "string", "int",
"string", "string", "string",
"int"}, "");
                IDbCommand insertCmd = db.InitCmd("ZProgettoStoricoModificheInsert", new string[] {"IdModifica", "IdProgettoStorico",
"IdProgetto", "CodStato", "Data",
"Operatore", "Segnatura", "Revisione",
"Riesame", "Ricorso", "RiaperturaProvinciale",
"DataRi", "OperatoreRi", "SegnaturaRi",
"Stato", "CodFase", "OrdineStato",
"Fase", "OrdineFase", "Nominativo",
"CodEnte", "Provincia", "IdProfilo",
"Profilo", "Ente", "CodTipoEnte",
"IdAtto"}, new string[] {"int", "int",
"int", "string", "DateTime",
"int", "string", "bool",
"bool", "bool", "bool",
"DateTime", "int", "string",
"string", "string", "int",
"string", "int", "string",
"string", "string", "int",
"string", "string", "string",
"int"}, "");
                IDbCommand deleteCmd = db.InitCmd("ZProgettoStoricoModificheDelete", new string[] { "Id" }, new string[] { "int" }, "");
                for (int i = 0; i < ProgettoStoricoModificheCollectionObj.Count; i++)
                {
                    switch (ProgettoStoricoModificheCollectionObj[i].ObjectState)
                    {
                        case BaseObject.ObjectStateType.Added:
                            {
                                CompileIUCmd(false, insertCmd, ProgettoStoricoModificheCollectionObj[i], db.CommandFirstChar);
                                db.InitDatareader(insertCmd);
                                if (db.DataReader.Read())
                                {
                                    ProgettoStoricoModificheCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
                                }
                                db.DataReader.Close();
                                returnValue++;
                            }
                            break;
                        case BaseObject.ObjectStateType.Changed:
                            {
                                CompileIUCmd(true, updateCmd, ProgettoStoricoModificheCollectionObj[i], db.CommandFirstChar);
                                returnValue = returnValue + db.Execute(updateCmd);
                            }
                            break;
                        case BaseObject.ObjectStateType.Deleted:
                            {
                                if (ProgettoStoricoModificheCollectionObj[i].IsPersistent)
                                {
                                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)ProgettoStoricoModificheCollectionObj[i].Id);
                                    returnValue = returnValue + db.Execute(deleteCmd);
                                }
                            }
                            break;
                    }
                }
                db.Commit();
                for (int i = 0; i < ProgettoStoricoModificheCollectionObj.Count; i++)
                {
                    if ((ProgettoStoricoModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ProgettoStoricoModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        ProgettoStoricoModificheCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
                        ProgettoStoricoModificheCollectionObj[i].IsDirty = false;
                        ProgettoStoricoModificheCollectionObj[i].IsPersistent = true;
                    }
                    if ((ProgettoStoricoModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
                    {
                        ProgettoStoricoModificheCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        ProgettoStoricoModificheCollectionObj[i].IsDirty = false;
                        ProgettoStoricoModificheCollectionObj[i].IsPersistent = false;
                    }
                }
            }
            catch
            {
                db.Rollback();
                throw;
            }
            finally
            {
                db.Close();
            }
            return returnValue;
        }

        //Delete
        public static int Delete(DbProvider db, ProgettoStoricoModifiche ProgettoStoricoModificheObj)
        {
            int returnValue = 0;
            if (ProgettoStoricoModificheObj.IsPersistent)
            {
                returnValue = Delete(db, ProgettoStoricoModificheObj.Id);
            }
            ProgettoStoricoModificheObj.ObjectState = BaseObject.ObjectStateType.Deleted;
            ProgettoStoricoModificheObj.IsDirty = false;
            ProgettoStoricoModificheObj.IsPersistent = false;
            return returnValue;
        }

        //Delete
        private static int Delete(DbProvider db, int IdValue)
        {
            int i = 1;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZProgettoStoricoModificheDelete", new string[] { "Id" }, new string[] { "int" }, "");
                DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
                i = db.Execute(deleteCmd);
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        public static int DeleteCollection(DbProvider db, ProgettoStoricoModificheCollection ProgettoStoricoModificheCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZProgettoStoricoModificheDelete", new string[] { "Id" }, new string[] { "int" }, "");
                for (int i = 0; i < ProgettoStoricoModificheCollectionObj.Count; i++)
                {
                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "Id", ProgettoStoricoModificheCollectionObj[i].Id);
                    returnValue = returnValue + db.Execute(deleteCmd);
                }
                db.Commit();
                for (int i = 0; i < ProgettoStoricoModificheCollectionObj.Count; i++)
                {
                    if ((ProgettoStoricoModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ProgettoStoricoModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        ProgettoStoricoModificheCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        ProgettoStoricoModificheCollectionObj[i].IsDirty = false;
                        ProgettoStoricoModificheCollectionObj[i].IsPersistent = false;
                    }
                }
            }
            catch
            {
                db.Rollback();
                throw;
            }
            finally
            {
                db.Close();
            }
            return returnValue;
        }

        //getById
        public static ProgettoStoricoModifiche GetById(DbProvider db, int IdValue)
        {
            ProgettoStoricoModifiche ProgettoStoricoModificheObj = null;
            IDbCommand readCmd = db.InitCmd("ZProgettoStoricoModificheGetById", new string[] { "Id" }, new string[] { "int" }, "");
            DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
            db.InitDatareader(readCmd);
            if (db.DataReader.Read())
            {
                ProgettoStoricoModificheObj = GetFromDatareader(db);
                ProgettoStoricoModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ProgettoStoricoModificheObj.IsDirty = false;
                ProgettoStoricoModificheObj.IsPersistent = true;
            }
            db.Close();
            return ProgettoStoricoModificheObj;
        }

        //getFromDatareader
        public static ProgettoStoricoModifiche GetFromDatareader(DbProvider db)
        {
            ProgettoStoricoModifiche ProgettoStoricoModificheObj = new ProgettoStoricoModifiche();
            ProgettoStoricoModificheObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
            ProgettoStoricoModificheObj.IdModifica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_MODIFICA"]);
            ProgettoStoricoModificheObj.IdProgettoStorico = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO_STORICO"]);
            ProgettoStoricoModificheObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
            ProgettoStoricoModificheObj.CodStato = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_STATO"]);
            ProgettoStoricoModificheObj.Data = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA"]);
            ProgettoStoricoModificheObj.Operatore = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE"]);
            ProgettoStoricoModificheObj.Segnatura = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA"]);
            ProgettoStoricoModificheObj.Revisione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["REVISIONE"]);
            ProgettoStoricoModificheObj.Riesame = new SiarLibrary.NullTypes.BoolNT(db.DataReader["RIESAME"]);
            ProgettoStoricoModificheObj.Ricorso = new SiarLibrary.NullTypes.BoolNT(db.DataReader["RICORSO"]);
            ProgettoStoricoModificheObj.RiaperturaProvinciale = new SiarLibrary.NullTypes.BoolNT(db.DataReader["RIAPERTURA_PROVINCIALE"]);
            ProgettoStoricoModificheObj.DataRi = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_RI"]);
            ProgettoStoricoModificheObj.OperatoreRi = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE_RI"]);
            ProgettoStoricoModificheObj.SegnaturaRi = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_RI"]);
            ProgettoStoricoModificheObj.Stato = new SiarLibrary.NullTypes.StringNT(db.DataReader["STATO"]);
            ProgettoStoricoModificheObj.CodFase = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_FASE"]);
            ProgettoStoricoModificheObj.OrdineStato = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE_STATO"]);
            ProgettoStoricoModificheObj.Fase = new SiarLibrary.NullTypes.StringNT(db.DataReader["FASE"]);
            ProgettoStoricoModificheObj.OrdineFase = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE_FASE"]);
            ProgettoStoricoModificheObj.Nominativo = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOMINATIVO"]);
            ProgettoStoricoModificheObj.CodEnte = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_ENTE"]);
            ProgettoStoricoModificheObj.Provincia = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROVINCIA"]);
            ProgettoStoricoModificheObj.IdProfilo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROFILO"]);
            ProgettoStoricoModificheObj.Profilo = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROFILO"]);
            ProgettoStoricoModificheObj.Ente = new SiarLibrary.NullTypes.StringNT(db.DataReader["ENTE"]);
            ProgettoStoricoModificheObj.CodTipoEnte = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO_ENTE"]);
            ProgettoStoricoModificheObj.IdAtto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ATTO"]);
            ProgettoStoricoModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            ProgettoStoricoModificheObj.IsDirty = false;
            ProgettoStoricoModificheObj.IsPersistent = true;
            return ProgettoStoricoModificheObj;
        }

        //Find Select

        public static ProgettoStoricoModificheCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.IntNT IdModificaEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoStoricoEqualThis,
SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.StringNT CodStatoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataEqualThis,
SiarLibrary.NullTypes.IntNT OperatoreEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaEqualThis, SiarLibrary.NullTypes.BoolNT RevisioneEqualThis,
SiarLibrary.NullTypes.BoolNT RiesameEqualThis, SiarLibrary.NullTypes.BoolNT RicorsoEqualThis, SiarLibrary.NullTypes.BoolNT RiaperturaProvincialeEqualThis,
SiarLibrary.NullTypes.DatetimeNT DataRiEqualThis, SiarLibrary.NullTypes.IntNT OperatoreRiEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaRiEqualThis,
SiarLibrary.NullTypes.StringNT StatoEqualThis, SiarLibrary.NullTypes.StringNT CodFaseEqualThis, SiarLibrary.NullTypes.IntNT OrdineStatoEqualThis,
SiarLibrary.NullTypes.StringNT FaseEqualThis, SiarLibrary.NullTypes.IntNT OrdineFaseEqualThis, SiarLibrary.NullTypes.StringNT NominativoEqualThis,
SiarLibrary.NullTypes.StringNT CodEnteEqualThis, SiarLibrary.NullTypes.StringNT ProvinciaEqualThis, SiarLibrary.NullTypes.IntNT IdProfiloEqualThis,
SiarLibrary.NullTypes.StringNT ProfiloEqualThis, SiarLibrary.NullTypes.StringNT EnteEqualThis, SiarLibrary.NullTypes.StringNT CodTipoEnteEqualThis,
SiarLibrary.NullTypes.IntNT IdAttoEqualThis)

        {

            ProgettoStoricoModificheCollection ProgettoStoricoModificheCollectionObj = new ProgettoStoricoModificheCollection();

            IDbCommand findCmd = db.InitCmd("Zprogettostoricomodifichefindselect", new string[] {"Idequalthis", "IdModificaequalthis", "IdProgettoStoricoequalthis",
"IdProgettoequalthis", "CodStatoequalthis", "Dataequalthis",
"Operatoreequalthis", "Segnaturaequalthis", "Revisioneequalthis",
"Riesameequalthis", "Ricorsoequalthis", "RiaperturaProvincialeequalthis",
"DataRiequalthis", "OperatoreRiequalthis", "SegnaturaRiequalthis",
"Statoequalthis", "CodFaseequalthis", "OrdineStatoequalthis",
"Faseequalthis", "OrdineFaseequalthis", "Nominativoequalthis",
"CodEnteequalthis", "Provinciaequalthis", "IdProfiloequalthis",
"Profiloequalthis", "Enteequalthis", "CodTipoEnteequalthis",
"IdAttoequalthis"}, new string[] {"int", "int", "int",
"int", "string", "DateTime",
"int", "string", "bool",
"bool", "bool", "bool",
"DateTime", "int", "string",
"string", "string", "int",
"string", "int", "string",
"string", "string", "int",
"string", "string", "string",
"int"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Idequalthis", IdEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdModificaequalthis", IdModificaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoStoricoequalthis", IdProgettoStoricoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodStatoequalthis", CodStatoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Dataequalthis", DataEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Operatoreequalthis", OperatoreEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Segnaturaequalthis", SegnaturaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Revisioneequalthis", RevisioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Riesameequalthis", RiesameEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Ricorsoequalthis", RicorsoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "RiaperturaProvincialeequalthis", RiaperturaProvincialeEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataRiequalthis", DataRiEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "OperatoreRiequalthis", OperatoreRiEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "SegnaturaRiequalthis", SegnaturaRiEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Statoequalthis", StatoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodFaseequalthis", CodFaseEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "OrdineStatoequalthis", OrdineStatoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Faseequalthis", FaseEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "OrdineFaseequalthis", OrdineFaseEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Nominativoequalthis", NominativoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodEnteequalthis", CodEnteEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Provinciaequalthis", ProvinciaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProfiloequalthis", IdProfiloEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Profiloequalthis", ProfiloEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Enteequalthis", EnteEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodTipoEnteequalthis", CodTipoEnteEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdAttoequalthis", IdAttoEqualThis);
            ProgettoStoricoModifiche ProgettoStoricoModificheObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                ProgettoStoricoModificheObj = GetFromDatareader(db);
                ProgettoStoricoModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ProgettoStoricoModificheObj.IsDirty = false;
                ProgettoStoricoModificheObj.IsPersistent = true;
                ProgettoStoricoModificheCollectionObj.Add(ProgettoStoricoModificheObj);
            }
            db.Close();
            return ProgettoStoricoModificheCollectionObj;
        }

    }
}


namespace SiarBLL
{

    /// <summary>
    /// Summary description for ProgettoStoricoModificheCollectionProvider:IProgettoStoricoModificheProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class ProgettoStoricoModificheCollectionProvider : IProgettoStoricoModificheProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di ProgettoStoricoModifiche
        protected ProgettoStoricoModificheCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public ProgettoStoricoModificheCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new ProgettoStoricoModificheCollection(this);
        }

        //Costruttore3: ha in input progettostoricomodificheCollectionObj - non popola la collection
        public ProgettoStoricoModificheCollectionProvider(ProgettoStoricoModificheCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public ProgettoStoricoModificheCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new ProgettoStoricoModificheCollection(this);
        }

        //Get e Set
        public ProgettoStoricoModificheCollection CollectionObj
        {
            get
            {
                return _CollectionObj;
            }
            set
            {
                _CollectionObj = value;
            }
        }

        public DbProvider DbProviderObj
        {
            get
            {
                return _dbProviderObj;
            }
            set
            {
                _dbProviderObj = value;
            }
        }

        //Operazioni

        //Save1: registra l'intera collection
        public int SaveCollection()
        {
            return SaveCollection(_CollectionObj);
        }

        //Save2: registra una collection
        public int SaveCollection(ProgettoStoricoModificheCollection collectionObj)
        {
            return ProgettoStoricoModificheDAL.SaveCollection(_dbProviderObj, collectionObj);
        }

        //Save3: registra l'elemento i-esimo della collection
        public int Save(int i)
        {
            return Save(_CollectionObj[i]);
        }

        //Save4: registra un elemento singolo
        public int Save(ProgettoStoricoModifiche progettostoricomodificheObj)
        {
            return ProgettoStoricoModificheDAL.Save(_dbProviderObj, progettostoricomodificheObj);
        }

        //delete1: elimina l'intera collection
        public int DeleteCollection()
        {
            return DeleteCollection(_CollectionObj);
        }

        //delete2: elimina una collection
        public int DeleteCollection(ProgettoStoricoModificheCollection collectionObj)
        {
            return ProgettoStoricoModificheDAL.DeleteCollection(_dbProviderObj, collectionObj);
        }

        //delete3: elimina l'elemento i-esimo della collection
        public int Delete(int i)
        {
            return Delete(_CollectionObj[i]);
        }

        //delete4: elimina un elemento singolo
        public int Delete(ProgettoStoricoModifiche progettostoricomodificheObj)
        {
            return ProgettoStoricoModificheDAL.Delete(_dbProviderObj, progettostoricomodificheObj);
        }

        //getById
        public ProgettoStoricoModifiche GetById(IntNT IdValue)
        {
            ProgettoStoricoModifiche ProgettoStoricoModificheTemp = ProgettoStoricoModificheDAL.GetById(_dbProviderObj, IdValue);
            if (ProgettoStoricoModificheTemp != null) ProgettoStoricoModificheTemp.Provider = this;
            return ProgettoStoricoModificheTemp;
        }

        //Select: popola la collection
        public ProgettoStoricoModificheCollection Select(IntNT IdEqualThis, IntNT IdmodificaEqualThis, IntNT IdprogettostoricoEqualThis,
IntNT IdprogettoEqualThis, StringNT CodstatoEqualThis, DatetimeNT DataEqualThis,
IntNT OperatoreEqualThis, StringNT SegnaturaEqualThis, BoolNT RevisioneEqualThis,
BoolNT RiesameEqualThis, BoolNT RicorsoEqualThis, BoolNT RiaperturaprovincialeEqualThis,
DatetimeNT DatariEqualThis, IntNT OperatoreriEqualThis, StringNT SegnaturariEqualThis,
StringNT StatoEqualThis, StringNT CodfaseEqualThis, IntNT OrdinestatoEqualThis,
StringNT FaseEqualThis, IntNT OrdinefaseEqualThis, StringNT NominativoEqualThis,
StringNT CodenteEqualThis, StringNT ProvinciaEqualThis, IntNT IdprofiloEqualThis,
StringNT ProfiloEqualThis, StringNT EnteEqualThis, StringNT CodtipoenteEqualThis,
IntNT IdattoEqualThis)
        {
            ProgettoStoricoModificheCollection ProgettoStoricoModificheCollectionTemp = ProgettoStoricoModificheDAL.Select(_dbProviderObj, IdEqualThis, IdmodificaEqualThis, IdprogettostoricoEqualThis,
IdprogettoEqualThis, CodstatoEqualThis, DataEqualThis,
OperatoreEqualThis, SegnaturaEqualThis, RevisioneEqualThis,
RiesameEqualThis, RicorsoEqualThis, RiaperturaprovincialeEqualThis,
DatariEqualThis, OperatoreriEqualThis, SegnaturariEqualThis,
StatoEqualThis, CodfaseEqualThis, OrdinestatoEqualThis,
FaseEqualThis, OrdinefaseEqualThis, NominativoEqualThis,
CodenteEqualThis, ProvinciaEqualThis, IdprofiloEqualThis,
ProfiloEqualThis, EnteEqualThis, CodtipoenteEqualThis,
IdattoEqualThis);
            ProgettoStoricoModificheCollectionTemp.Provider = this;
            return ProgettoStoricoModificheCollectionTemp;
        }


    }
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<PROGETTO_STORICO_MODIFICHE>
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
</PROGETTO_STORICO_MODIFICHE>
*/
