using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

    // interfaccia provider per Impresa
    // Interfaccia Autogenerata
    // Inserire eventuali operazioni aggiuntive
    public interface IImpresaProvider
    {
        int Save(Impresa ImpresaObj);
        int SaveCollection(ImpresaCollection collectionObj);
        int Delete(Impresa ImpresaObj);
        int DeleteCollection(ImpresaCollection collectionObj);
    }
    /// <summary>
    /// Summary description for Impresa
    /// Class Autogenerata
    /// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
    /// con delle partial class contenenti i metodi aggiunti, in questo modo 
    /// non verranno sovrascritti quando si rigenera la classe 
    /// </summary>

    [Serializable]
    [System.Xml.Serialization.XmlType(Namespace = "")]

    public partial class Impresa : BaseObject
    {

        //Definizione dei campi 'base'
        private NullTypes.IntNT _IdImpresa;
        private NullTypes.StringNT _Cuaa;
        private NullTypes.StringNT _CodiceFiscale;
        private NullTypes.IntNT _AnnoCostituzione;
        private NullTypes.StringNT _CodEnte;
        private NullTypes.StringNT _IscrizioneRegistroImprese;
        private NullTypes.StringNT _Presentazione;
        private NullTypes.StringNT _Descrizione;
        private NullTypes.IntNT _IdStoricoImpresa;
        private NullTypes.DatetimeNT _DataInizioValidita;
        private NullTypes.DatetimeNT _DataFineValidita;
        private NullTypes.StringNT _RagioneSociale;
        private NullTypes.StringNT _CodiceInps;
        private NullTypes.StringNT _CodFormaGiuridica;
        private NullTypes.IntNT _IdDimensione;
        private NullTypes.StringNT _DimensioneImpresa;
        private NullTypes.StringNT _FormaGiuridica;
        private NullTypes.BoolNT _Foglia;
        private NullTypes.DatetimeNT _DataInizioAttivita;
        private NullTypes.StringNT _RegistroImpreseNumero;
        private NullTypes.StringNT _ReaNumero;
        private NullTypes.IntNT _ReaAnno;
        private NullTypes.IntNT _IdStoricoUltimo;
        private NullTypes.IntNT _IdRapprlegaleUltimo;
        private NullTypes.IntNT _IdContoCorrenteUltimo;
        private NullTypes.IntNT _IdSedelegaleUltimo;
        private NullTypes.StringNT _CodClassificazioneUma;
        private NullTypes.BoolNT _Attiva;
        private NullTypes.DatetimeNT _DataCessazione;
        private NullTypes.StringNT _SegnaturaCessazione;
        private NullTypes.StringNT _CodTipoCessazione;
        private NullTypes.StringNT _CodAteco2007;
        [NonSerialized]
        private IImpresaProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IImpresaProvider Provider
        {
            get { return _provider; }
            set { _provider = value; }
        }


        //Costruttore
        public Impresa()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //Get e Set dei campi 'base'
        /// <summary>
        /// Corrisponde al campo:ID_IMPRESA
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdImpresa
        {
            get { return _IdImpresa; }
            set
            {
                if (IdImpresa != value)
                {
                    _IdImpresa = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:CUAA
        /// Tipo sul db:VARCHAR(16)
        /// </summary>
        public NullTypes.StringNT Cuaa
        {
            get { return _Cuaa; }
            set
            {
                if (Cuaa != value)
                {
                    _Cuaa = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:CODICE_FISCALE
        /// Tipo sul db:VARCHAR(16)
        /// </summary>
        public NullTypes.StringNT CodiceFiscale
        {
            get { return _CodiceFiscale; }
            set
            {
                if (CodiceFiscale != value)
                {
                    _CodiceFiscale = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ANNO_COSTITUZIONE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT AnnoCostituzione
        {
            get { return _AnnoCostituzione; }
            set
            {
                if (AnnoCostituzione != value)
                {
                    _AnnoCostituzione = value;
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
        /// Corrisponde al campo:ISCRIZIONE_REGISTRO_IMPRESE
        /// Tipo sul db:VARCHAR(16)
        /// </summary>
        public NullTypes.StringNT IscrizioneRegistroImprese
        {
            get { return _IscrizioneRegistroImprese; }
            set
            {
                if (IscrizioneRegistroImprese != value)
                {
                    _IscrizioneRegistroImprese = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:PRESENTAZIONE
        /// Tipo sul db:NTEXT
        /// </summary>
        public NullTypes.StringNT Presentazione
        {
            get { return _Presentazione; }
            set
            {
                if (Presentazione != value)
                {
                    _Presentazione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DESCRIZIONE
        /// Tipo sul db:NTEXT
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

        /// <summary>
        /// Corrisponde al campo:ID_STORICO_IMPRESA
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdStoricoImpresa
        {
            get { return _IdStoricoImpresa; }
            set
            {
                if (IdStoricoImpresa != value)
                {
                    _IdStoricoImpresa = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_INIZIO_VALIDITA
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataInizioValidita
        {
            get { return _DataInizioValidita; }
            set
            {
                if (DataInizioValidita != value)
                {
                    _DataInizioValidita = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_FINE_VALIDITA
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataFineValidita
        {
            get { return _DataFineValidita; }
            set
            {
                if (DataFineValidita != value)
                {
                    _DataFineValidita = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:RAGIONE_SOCIALE
        /// Tipo sul db:VARCHAR(255)
        /// </summary>
        public NullTypes.StringNT RagioneSociale
        {
            get { return _RagioneSociale; }
            set
            {
                if (RagioneSociale != value)
                {
                    _RagioneSociale = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:CODICE_INPS
        /// Tipo sul db:VARCHAR(15)
        /// </summary>
        public NullTypes.StringNT CodiceInps
        {
            get { return _CodiceInps; }
            set
            {
                if (CodiceInps != value)
                {
                    _CodiceInps = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:COD_FORMA_GIURIDICA
        /// Tipo sul db:VARCHAR(10)
        /// </summary>
        public NullTypes.StringNT CodFormaGiuridica
        {
            get { return _CodFormaGiuridica; }
            set
            {
                if (CodFormaGiuridica != value)
                {
                    _CodFormaGiuridica = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_DIMENSIONE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdDimensione
        {
            get { return _IdDimensione; }
            set
            {
                if (IdDimensione != value)
                {
                    _IdDimensione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DIMENSIONE_IMPRESA
        /// Tipo sul db:VARCHAR(50)
        /// </summary>
        public NullTypes.StringNT DimensioneImpresa
        {
            get { return _DimensioneImpresa; }
            set
            {
                if (DimensioneImpresa != value)
                {
                    _DimensioneImpresa = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:FORMA_GIURIDICA
        /// Tipo sul db:VARCHAR(255)
        /// </summary>
        public NullTypes.StringNT FormaGiuridica
        {
            get { return _FormaGiuridica; }
            set
            {
                if (FormaGiuridica != value)
                {
                    _FormaGiuridica = value;
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
            set
            {
                if (Foglia != value)
                {
                    _Foglia = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_INIZIO_ATTIVITA
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataInizioAttivita
        {
            get { return _DataInizioAttivita; }
            set
            {
                if (DataInizioAttivita != value)
                {
                    _DataInizioAttivita = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:REGISTRO_IMPRESE_NUMERO
        /// Tipo sul db:VARCHAR(16)
        /// </summary>
        public NullTypes.StringNT RegistroImpreseNumero
        {
            get { return _RegistroImpreseNumero; }
            set
            {
                if (RegistroImpreseNumero != value)
                {
                    _RegistroImpreseNumero = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:REA_NUMERO
        /// Tipo sul db:VARCHAR(20)
        /// </summary>
        public NullTypes.StringNT ReaNumero
        {
            get { return _ReaNumero; }
            set
            {
                if (ReaNumero != value)
                {
                    _ReaNumero = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:REA_ANNO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT ReaAnno
        {
            get { return _ReaAnno; }
            set
            {
                if (ReaAnno != value)
                {
                    _ReaAnno = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_STORICO_ULTIMO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdStoricoUltimo
        {
            get { return _IdStoricoUltimo; }
            set
            {
                if (IdStoricoUltimo != value)
                {
                    _IdStoricoUltimo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_RAPPRLEGALE_ULTIMO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdRapprlegaleUltimo
        {
            get { return _IdRapprlegaleUltimo; }
            set
            {
                if (IdRapprlegaleUltimo != value)
                {
                    _IdRapprlegaleUltimo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_CONTO_CORRENTE_ULTIMO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdContoCorrenteUltimo
        {
            get { return _IdContoCorrenteUltimo; }
            set
            {
                if (IdContoCorrenteUltimo != value)
                {
                    _IdContoCorrenteUltimo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_SEDELEGALE_ULTIMO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdSedelegaleUltimo
        {
            get { return _IdSedelegaleUltimo; }
            set
            {
                if (IdSedelegaleUltimo != value)
                {
                    _IdSedelegaleUltimo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:COD_CLASSIFICAZIONE_UMA
        /// Tipo sul db:VARCHAR(3)
        /// </summary>
        public NullTypes.StringNT CodClassificazioneUma
        {
            get { return _CodClassificazioneUma; }
            set
            {
                if (CodClassificazioneUma != value)
                {
                    _CodClassificazioneUma = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ATTIVA
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT Attiva
        {
            get { return _Attiva; }
            set
            {
                if (Attiva != value)
                {
                    _Attiva = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_CESSAZIONE
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataCessazione
        {
            get { return _DataCessazione; }
            set
            {
                if (DataCessazione != value)
                {
                    _DataCessazione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:SEGNATURA_CESSAZIONE
        /// Tipo sul db:VARCHAR(100)
        /// </summary>
        public NullTypes.StringNT SegnaturaCessazione
        {
            get { return _SegnaturaCessazione; }
            set
            {
                if (SegnaturaCessazione != value)
                {
                    _SegnaturaCessazione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:COD_TIPO_CESSAZIONE
        /// Tipo sul db:CHAR(1)
        /// </summary>
        public NullTypes.StringNT CodTipoCessazione
        {
            get { return _CodTipoCessazione; }
            set
            {
                if (CodTipoCessazione != value)
                {
                    _CodTipoCessazione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:COD_ATECO2007
        /// Tipo sul db:CHAR(9)
        /// </summary>
        public NullTypes.StringNT CodAteco2007
        {
            get { return _CodAteco2007; }
            set
            {
                if (CodAteco2007 != value)
                {
                    _CodAteco2007 = value;
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

namespace SiarLibrary
{

    /// <summary>
    /// Summary description for ImpresaCollection
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class ImpresaCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
        private ImpresaCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((Impresa)info.GetValue(i.ToString(), typeof(Impresa)));
            }
        }

        //Costruttore
        public ImpresaCollection()
        {
            this.ItemType = typeof(Impresa);
        }

        //Costruttore con provider
        public ImpresaCollection(IImpresaProvider providerObj)
        {
            this.ItemType = typeof(Impresa);
            this.Provider = providerObj;
        }

        //Get e Set
        public new Impresa this[int index]
        {
            get { return (Impresa)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new ImpresaCollection GetChanges()
        {
            return (ImpresaCollection)base.GetChanges();
        }

        [NonSerialized]
        private IImpresaProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IImpresaProvider Provider
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
        public int Add(Impresa ImpresaObj)
        {
            if (ImpresaObj.Provider == null) ImpresaObj.Provider = this.Provider;
            return base.Add(ImpresaObj);
        }

        //AddCollection
        public void AddCollection(ImpresaCollection ImpresaCollectionObj)
        {
            foreach (Impresa ImpresaObj in ImpresaCollectionObj)
                this.Add(ImpresaObj);
        }

        //Insert
        public void Insert(int index, Impresa ImpresaObj)
        {
            if (ImpresaObj.Provider == null) ImpresaObj.Provider = this.Provider;
            base.Insert(index, ImpresaObj);
        }

        //CollectionGetById
        public Impresa CollectionGetById(NullTypes.IntNT IdImpresaValue)
        {
            int i = 0;
            bool find = false;
            while ((i < this.Count) && (!find))
            {
                if ((this[i].IdImpresa == IdImpresaValue))
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
        public ImpresaCollection SubSelect(NullTypes.IntNT IdImpresaEqualThis, NullTypes.StringNT CuaaEqualThis, NullTypes.StringNT CodiceFiscaleEqualThis,
NullTypes.IntNT AnnoCostituzioneEqualThis, NullTypes.StringNT CodEnteEqualThis, NullTypes.StringNT IscrizioneRegistroImpreseEqualThis,
NullTypes.DatetimeNT DataInizioAttivitaEqualThis, NullTypes.IntNT IdStoricoUltimoEqualThis, NullTypes.IntNT IdSedelegaleUltimoEqualThis,
NullTypes.IntNT IdRapprlegaleUltimoEqualThis, NullTypes.IntNT IdContoCorrenteUltimoEqualThis)
        {
            ImpresaCollection ImpresaCollectionTemp = new ImpresaCollection();
            foreach (Impresa ImpresaItem in this)
            {
                if (((IdImpresaEqualThis == null) || ((ImpresaItem.IdImpresa != null) && (ImpresaItem.IdImpresa.Value == IdImpresaEqualThis.Value))) && ((CuaaEqualThis == null) || ((ImpresaItem.Cuaa != null) && (ImpresaItem.Cuaa.Value == CuaaEqualThis.Value))) && ((CodiceFiscaleEqualThis == null) || ((ImpresaItem.CodiceFiscale != null) && (ImpresaItem.CodiceFiscale.Value == CodiceFiscaleEqualThis.Value))) &&
((AnnoCostituzioneEqualThis == null) || ((ImpresaItem.AnnoCostituzione != null) && (ImpresaItem.AnnoCostituzione.Value == AnnoCostituzioneEqualThis.Value))) && ((CodEnteEqualThis == null) || ((ImpresaItem.CodEnte != null) && (ImpresaItem.CodEnte.Value == CodEnteEqualThis.Value))) && ((IscrizioneRegistroImpreseEqualThis == null) || ((ImpresaItem.IscrizioneRegistroImprese != null) && (ImpresaItem.IscrizioneRegistroImprese.Value == IscrizioneRegistroImpreseEqualThis.Value))) &&
((DataInizioAttivitaEqualThis == null) || ((ImpresaItem.DataInizioAttivita != null) && (ImpresaItem.DataInizioAttivita.Value == DataInizioAttivitaEqualThis.Value))) && ((IdStoricoUltimoEqualThis == null) || ((ImpresaItem.IdStoricoUltimo != null) && (ImpresaItem.IdStoricoUltimo.Value == IdStoricoUltimoEqualThis.Value))) && ((IdSedelegaleUltimoEqualThis == null) || ((ImpresaItem.IdSedelegaleUltimo != null) && (ImpresaItem.IdSedelegaleUltimo.Value == IdSedelegaleUltimoEqualThis.Value))) &&
((IdRapprlegaleUltimoEqualThis == null) || ((ImpresaItem.IdRapprlegaleUltimo != null) && (ImpresaItem.IdRapprlegaleUltimo.Value == IdRapprlegaleUltimoEqualThis.Value))) && ((IdContoCorrenteUltimoEqualThis == null) || ((ImpresaItem.IdContoCorrenteUltimo != null) && (ImpresaItem.IdContoCorrenteUltimo.Value == IdContoCorrenteUltimoEqualThis.Value))))
                {
                    ImpresaCollectionTemp.Add(ImpresaItem);
                }
            }
            return ImpresaCollectionTemp;
        }



    }
}

namespace SiarDAL
{

    /// <summary>
    /// Summary description for ImpresaDAL
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>


    internal class ImpresaDAL
    {

        //Operazioni

        //internal CompileIUCmd compila un command con i parametri per l'insert o l'update
        protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, Impresa ImpresaObj, string firstChar)
        {
            if (forUpdate)
            {
                // campi identity valorizzati solo per l'update
                DbProvider.SetCmdParam(cmd, firstChar + "IdImpresa", ImpresaObj.IdImpresa);
                // altri campi sempre valorizzati
            }
            DbProvider.SetCmdParam(cmd, firstChar + "Cuaa", ImpresaObj.Cuaa);
            DbProvider.SetCmdParam(cmd, firstChar + "CodiceFiscale", ImpresaObj.CodiceFiscale);
            DbProvider.SetCmdParam(cmd, firstChar + "AnnoCostituzione", ImpresaObj.AnnoCostituzione);
            DbProvider.SetCmdParam(cmd, firstChar + "CodEnte", ImpresaObj.CodEnte);
            DbProvider.SetCmdParam(cmd, firstChar + "IscrizioneRegistroImprese", ImpresaObj.IscrizioneRegistroImprese);
            DbProvider.SetCmdParam(cmd, firstChar + "Presentazione", ImpresaObj.Presentazione);
            DbProvider.SetCmdParam(cmd, firstChar + "Descrizione", ImpresaObj.Descrizione);
            DbProvider.SetCmdParam(cmd, firstChar + "DataInizioAttivita", ImpresaObj.DataInizioAttivita);
            DbProvider.SetCmdParam(cmd, firstChar + "IdStoricoUltimo", ImpresaObj.IdStoricoUltimo);
            DbProvider.SetCmdParam(cmd, firstChar + "IdRapprlegaleUltimo", ImpresaObj.IdRapprlegaleUltimo);
            DbProvider.SetCmdParam(cmd, firstChar + "IdContoCorrenteUltimo", ImpresaObj.IdContoCorrenteUltimo);
            DbProvider.SetCmdParam(cmd, firstChar + "IdSedelegaleUltimo", ImpresaObj.IdSedelegaleUltimo);
        }
        //Insert
        private static int Insert(DbProvider db, Impresa ImpresaObj)
        {
            int i = 1;
            try
            {
                IDbCommand insertCmd = db.InitCmd("ZImpresaInsert", new string[] {"Cuaa", "CodiceFiscale", 
"AnnoCostituzione", "CodEnte", "IscrizioneRegistroImprese", 
"Presentazione", "Descrizione", 



"DataInizioAttivita", 
"IdStoricoUltimo", "IdRapprlegaleUltimo", 
"IdContoCorrenteUltimo", "IdSedelegaleUltimo", 
}, new string[] {"string", "string", 
"int", "string", "string", 
"string", "string", 



"DateTime", 
"int", "int", 
"int", "int", 
}, "");
                CompileIUCmd(false, insertCmd, ImpresaObj, db.CommandFirstChar);
                db.InitDatareader(insertCmd);
                if (db.DataReader.Read())
                {
                    ImpresaObj.IdImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA"]);
                }
                ImpresaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ImpresaObj.IsDirty = false;
                ImpresaObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //update
        private static int Update(DbProvider db, Impresa ImpresaObj)
        {
            int i = 1;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZImpresaUpdate", new string[] {"IdImpresa", "Cuaa", "CodiceFiscale", 
"AnnoCostituzione", "CodEnte", "IscrizioneRegistroImprese", 
"Presentazione", "Descrizione", 



"DataInizioAttivita", 
"IdStoricoUltimo", "IdRapprlegaleUltimo", 
"IdContoCorrenteUltimo", "IdSedelegaleUltimo", 
}, new string[] {"int", "string", "string", 
"int", "string", "string", 
"string", "string", 



"DateTime", 
"int", "int", 
"int", "int", 
}, "");
                CompileIUCmd(true, updateCmd, ImpresaObj, db.CommandFirstChar);
                i = db.Execute(updateCmd);
                ImpresaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ImpresaObj.IsDirty = false;
                ImpresaObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //Save
        public static int Save(DbProvider db, Impresa ImpresaObj)
        {
            switch (ImpresaObj.ObjectState)
            {
                case BaseObject.ObjectStateType.Added: return Insert(db, ImpresaObj);
                case BaseObject.ObjectStateType.Changed: return Update(db, ImpresaObj);
                case BaseObject.ObjectStateType.Deleted: return Delete(db, ImpresaObj);
                default: return 0;
            }
        }

        public static int SaveCollection(DbProvider db, ImpresaCollection ImpresaCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZImpresaUpdate", new string[] {"IdImpresa", "Cuaa", "CodiceFiscale", 
"AnnoCostituzione", "CodEnte", "IscrizioneRegistroImprese", 
"Presentazione", "Descrizione", 



"DataInizioAttivita", 
"IdStoricoUltimo", "IdRapprlegaleUltimo", 
"IdContoCorrenteUltimo", "IdSedelegaleUltimo", 
}, new string[] {"int", "string", "string", 
"int", "string", "string", 
"string", "string", 



"DateTime", 
"int", "int", 
"int", "int", 
}, "");
                IDbCommand insertCmd = db.InitCmd("ZImpresaInsert", new string[] {"Cuaa", "CodiceFiscale", 
"AnnoCostituzione", "CodEnte", "IscrizioneRegistroImprese", 
"Presentazione", "Descrizione", 



"DataInizioAttivita", 
"IdStoricoUltimo", "IdRapprlegaleUltimo", 
"IdContoCorrenteUltimo", "IdSedelegaleUltimo", 
}, new string[] {"string", "string", 
"int", "string", "string", 
"string", "string", 



"DateTime", 
"int", "int", 
"int", "int", 
}, "");
                IDbCommand deleteCmd = db.InitCmd("ZImpresaDelete", new string[] { "IdImpresa" }, new string[] { "int" }, "");
                for (int i = 0; i < ImpresaCollectionObj.Count; i++)
                {
                    switch (ImpresaCollectionObj[i].ObjectState)
                    {
                        case BaseObject.ObjectStateType.Added:
                            {
                                CompileIUCmd(false, insertCmd, ImpresaCollectionObj[i], db.CommandFirstChar);
                                db.InitDatareader(insertCmd);
                                if (db.DataReader.Read())
                                {
                                    ImpresaCollectionObj[i].IdImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA"]);
                                }
                                db.DataReader.Close();
                                returnValue++;
                            }
                            break;
                        case BaseObject.ObjectStateType.Changed:
                            {
                                CompileIUCmd(true, updateCmd, ImpresaCollectionObj[i], db.CommandFirstChar);
                                returnValue = returnValue + db.Execute(updateCmd);
                            }
                            break;
                        case BaseObject.ObjectStateType.Deleted:
                            {
                                if (ImpresaCollectionObj[i].IsPersistent)
                                {
                                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdImpresa", (SiarLibrary.NullTypes.IntNT)ImpresaCollectionObj[i].IdImpresa);
                                    returnValue = returnValue + db.Execute(deleteCmd);
                                }
                            }
                            break;
                    }
                }
                db.Commit();
                for (int i = 0; i < ImpresaCollectionObj.Count; i++)
                {
                    if ((ImpresaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ImpresaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        ImpresaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
                        ImpresaCollectionObj[i].IsDirty = false;
                        ImpresaCollectionObj[i].IsPersistent = true;
                    }
                    if ((ImpresaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
                    {
                        ImpresaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        ImpresaCollectionObj[i].IsDirty = false;
                        ImpresaCollectionObj[i].IsPersistent = false;
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
        public static int Delete(DbProvider db, Impresa ImpresaObj)
        {
            int returnValue = 0;
            if (ImpresaObj.IsPersistent)
            {
                returnValue = Delete(db, ImpresaObj.IdImpresa);
            }
            ImpresaObj.ObjectState = BaseObject.ObjectStateType.Deleted;
            ImpresaObj.IsDirty = false;
            ImpresaObj.IsPersistent = false;
            return returnValue;
        }

        //Delete
        private static int Delete(DbProvider db, int IdImpresaValue)
        {
            int i = 1;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZImpresaDelete", new string[] { "IdImpresa" }, new string[] { "int" }, "");
                DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdImpresa", (SiarLibrary.NullTypes.IntNT)IdImpresaValue);
                i = db.Execute(deleteCmd);
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        public static int DeleteCollection(DbProvider db, ImpresaCollection ImpresaCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZImpresaDelete", new string[] { "IdImpresa" }, new string[] { "int" }, "");
                for (int i = 0; i < ImpresaCollectionObj.Count; i++)
                {
                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdImpresa", ImpresaCollectionObj[i].IdImpresa);
                    returnValue = returnValue + db.Execute(deleteCmd);
                }
                db.Commit();
                for (int i = 0; i < ImpresaCollectionObj.Count; i++)
                {
                    if ((ImpresaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ImpresaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        ImpresaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        ImpresaCollectionObj[i].IsDirty = false;
                        ImpresaCollectionObj[i].IsPersistent = false;
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
        public static Impresa GetById(DbProvider db, int IdImpresaValue)
        {
            Impresa ImpresaObj = null;
            IDbCommand readCmd = db.InitCmd("ZImpresaGetById", new string[] { "IdImpresa" }, new string[] { "int" }, "");
            DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "IdImpresa", (SiarLibrary.NullTypes.IntNT)IdImpresaValue);
            db.InitDatareader(readCmd);
            if (db.DataReader.Read())
            {
                ImpresaObj = GetFromDatareader(db);
                ImpresaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ImpresaObj.IsDirty = false;
                ImpresaObj.IsPersistent = true;
            }
            db.Close();
            return ImpresaObj;
        }

        //getFromDatareader
        public static Impresa GetFromDatareader(DbProvider db)
        {
            Impresa ImpresaObj = new Impresa();
            ImpresaObj.IdImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA"]);
            ImpresaObj.Cuaa = new SiarLibrary.NullTypes.StringNT(db.DataReader["CUAA"]);
            ImpresaObj.CodiceFiscale = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE_FISCALE"]);
            ImpresaObj.AnnoCostituzione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ANNO_COSTITUZIONE"]);
            ImpresaObj.CodEnte = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_ENTE"]);
            ImpresaObj.IscrizioneRegistroImprese = new SiarLibrary.NullTypes.StringNT(db.DataReader["ISCRIZIONE_REGISTRO_IMPRESE"]);
            ImpresaObj.Presentazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["PRESENTAZIONE"]);
            ImpresaObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
            ImpresaObj.IdStoricoImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_STORICO_IMPRESA"]);
            ImpresaObj.DataInizioValidita = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INIZIO_VALIDITA"]);
            ImpresaObj.DataFineValidita = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_FINE_VALIDITA"]);
            ImpresaObj.RagioneSociale = new SiarLibrary.NullTypes.StringNT(db.DataReader["RAGIONE_SOCIALE"]);
            ImpresaObj.CodiceInps = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE_INPS"]);
            ImpresaObj.CodFormaGiuridica = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_FORMA_GIURIDICA"]);
            ImpresaObj.IdDimensione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DIMENSIONE"]);
            ImpresaObj.DimensioneImpresa = new SiarLibrary.NullTypes.StringNT(db.DataReader["DIMENSIONE_IMPRESA"]);
            ImpresaObj.FormaGiuridica = new SiarLibrary.NullTypes.StringNT(db.DataReader["FORMA_GIURIDICA"]);
            ImpresaObj.Foglia = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FOGLIA"]);
            ImpresaObj.DataInizioAttivita = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INIZIO_ATTIVITA"]);
            ImpresaObj.RegistroImpreseNumero = new SiarLibrary.NullTypes.StringNT(db.DataReader["REGISTRO_IMPRESE_NUMERO"]);
            ImpresaObj.ReaNumero = new SiarLibrary.NullTypes.StringNT(db.DataReader["REA_NUMERO"]);
            ImpresaObj.ReaAnno = new SiarLibrary.NullTypes.IntNT(db.DataReader["REA_ANNO"]);
            ImpresaObj.IdStoricoUltimo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_STORICO_ULTIMO"]);
            ImpresaObj.IdRapprlegaleUltimo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_RAPPRLEGALE_ULTIMO"]);
            ImpresaObj.IdContoCorrenteUltimo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CONTO_CORRENTE_ULTIMO"]);
            ImpresaObj.IdSedelegaleUltimo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_SEDELEGALE_ULTIMO"]);
            ImpresaObj.CodClassificazioneUma = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_CLASSIFICAZIONE_UMA"]);
            ImpresaObj.Attiva = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVA"]);
            ImpresaObj.DataCessazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_CESSAZIONE"]);
            ImpresaObj.SegnaturaCessazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_CESSAZIONE"]);
            ImpresaObj.CodTipoCessazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO_CESSAZIONE"]);
            ImpresaObj.CodAteco2007 = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_ATECO2007"]);
            ImpresaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            ImpresaObj.IsDirty = false;
            ImpresaObj.IsPersistent = true;
            return ImpresaObj;
        }

        //Find Select

        public static ImpresaCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, SiarLibrary.NullTypes.StringNT CuaaEqualThis, SiarLibrary.NullTypes.StringNT CodiceFiscaleEqualThis,
SiarLibrary.NullTypes.IntNT AnnoCostituzioneEqualThis, SiarLibrary.NullTypes.StringNT CodEnteEqualThis, SiarLibrary.NullTypes.StringNT IscrizioneRegistroImpreseEqualThis,
SiarLibrary.NullTypes.DatetimeNT DataInizioAttivitaEqualThis, SiarLibrary.NullTypes.IntNT IdStoricoUltimoEqualThis, SiarLibrary.NullTypes.IntNT IdSedelegaleUltimoEqualThis,
SiarLibrary.NullTypes.IntNT IdRapprlegaleUltimoEqualThis, SiarLibrary.NullTypes.IntNT IdContoCorrenteUltimoEqualThis)
        {

            ImpresaCollection ImpresaCollectionObj = new ImpresaCollection();

            IDbCommand findCmd = db.InitCmd("Zimpresafindselect", new string[] {"IdImpresaequalthis", "Cuaaequalthis", "CodiceFiscaleequalthis", 
"AnnoCostituzioneequalthis", "CodEnteequalthis", "IscrizioneRegistroImpreseequalthis", 
"DataInizioAttivitaequalthis", "IdStoricoUltimoequalthis", "IdSedelegaleUltimoequalthis", 
"IdRapprlegaleUltimoequalthis", "IdContoCorrenteUltimoequalthis"}, new string[] {"int", "string", "string", 
"int", "string", "string", 
"DateTime", "int", "int", 
"int", "int"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Cuaaequalthis", CuaaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodiceFiscaleequalthis", CodiceFiscaleEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "AnnoCostituzioneequalthis", AnnoCostituzioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodEnteequalthis", CodEnteEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IscrizioneRegistroImpreseequalthis", IscrizioneRegistroImpreseEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataInizioAttivitaequalthis", DataInizioAttivitaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdStoricoUltimoequalthis", IdStoricoUltimoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdSedelegaleUltimoequalthis", IdSedelegaleUltimoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdRapprlegaleUltimoequalthis", IdRapprlegaleUltimoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdContoCorrenteUltimoequalthis", IdContoCorrenteUltimoEqualThis);
            Impresa ImpresaObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                ImpresaObj = GetFromDatareader(db);
                ImpresaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ImpresaObj.IsDirty = false;
                ImpresaObj.IsPersistent = true;
                ImpresaCollectionObj.Add(ImpresaObj);
            }
            db.Close();
            return ImpresaCollectionObj;
        }

        //Find Find

        public static ImpresaCollection Find(DbProvider db, SiarLibrary.NullTypes.StringNT CuaaEqualThis, SiarLibrary.NullTypes.StringNT CodiceFiscaleEqualThis, SiarLibrary.NullTypes.StringNT RagioneSocialeLikeThis)
        {

            ImpresaCollection ImpresaCollectionObj = new ImpresaCollection();

            IDbCommand findCmd = db.InitCmd("Zimpresafindfind", new string[] { "Cuaaequalthis", "CodiceFiscaleequalthis", "RagioneSocialelikethis" }, new string[] { "string", "string", "string" }, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Cuaaequalthis", CuaaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodiceFiscaleequalthis", CodiceFiscaleEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "RagioneSocialelikethis", RagioneSocialeLikeThis);
            Impresa ImpresaObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                ImpresaObj = GetFromDatareader(db);
                ImpresaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ImpresaObj.IsDirty = false;
                ImpresaObj.IsPersistent = true;
                ImpresaCollectionObj.Add(ImpresaObj);
            }
            db.Close();
            return ImpresaCollectionObj;
        }

    }
}


namespace SiarBLL
{

    /// <summary>
    /// Summary description for ImpresaCollectionProvider:IImpresaProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class ImpresaCollectionProvider : IImpresaProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di Impresa
        protected ImpresaCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public ImpresaCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new ImpresaCollection(this);
        }

        //Costruttore 2: popola la collection
        public ImpresaCollectionProvider(StringNT CuaaEqualThis, StringNT CodicefiscaleEqualThis, StringNT RagionesocialeLikeThis)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = Find(CuaaEqualThis, CodicefiscaleEqualThis, RagionesocialeLikeThis);
        }

        //Costruttore3: ha in input impresaCollectionObj - non popola la collection
        public ImpresaCollectionProvider(ImpresaCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public ImpresaCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new ImpresaCollection(this);
        }

        //Get e Set
        public ImpresaCollection CollectionObj
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
        public int SaveCollection(ImpresaCollection collectionObj)
        {
            return ImpresaDAL.SaveCollection(_dbProviderObj, collectionObj);
        }

        //Save3: registra l'elemento i-esimo della collection
        public int Save(int i)
        {
            return Save(_CollectionObj[i]);
        }

        //Save4: registra un elemento singolo
        public int Save(Impresa impresaObj)
        {
            return ImpresaDAL.Save(_dbProviderObj, impresaObj);
        }

        //delete1: elimina l'intera collection
        public int DeleteCollection()
        {
            return DeleteCollection(_CollectionObj);
        }

        //delete2: elimina una collection
        public int DeleteCollection(ImpresaCollection collectionObj)
        {
            return ImpresaDAL.DeleteCollection(_dbProviderObj, collectionObj);
        }

        //delete3: elimina l'elemento i-esimo della collection
        public int Delete(int i)
        {
            return Delete(_CollectionObj[i]);
        }

        //delete4: elimina un elemento singolo
        public int Delete(Impresa impresaObj)
        {
            return ImpresaDAL.Delete(_dbProviderObj, impresaObj);
        }

        //getById
        public Impresa GetById(IntNT IdImpresaValue)
        {
            Impresa ImpresaTemp = ImpresaDAL.GetById(_dbProviderObj, IdImpresaValue);
            if (ImpresaTemp != null) ImpresaTemp.Provider = this;
            return ImpresaTemp;
        }

        //Get e Set dei campi 'ForeignKey'
        //Select: popola la collection
        public ImpresaCollection Select(IntNT IdimpresaEqualThis, StringNT CuaaEqualThis, StringNT CodicefiscaleEqualThis,
IntNT AnnocostituzioneEqualThis, StringNT CodenteEqualThis, StringNT IscrizioneregistroimpreseEqualThis,
DatetimeNT DatainizioattivitaEqualThis, IntNT IdstoricoultimoEqualThis, IntNT IdsedelegaleultimoEqualThis,
IntNT IdrapprlegaleultimoEqualThis, IntNT IdcontocorrenteultimoEqualThis)
        {
            ImpresaCollection ImpresaCollectionTemp = ImpresaDAL.Select(_dbProviderObj, IdimpresaEqualThis, CuaaEqualThis, CodicefiscaleEqualThis,
AnnocostituzioneEqualThis, CodenteEqualThis, IscrizioneregistroimpreseEqualThis,
DatainizioattivitaEqualThis, IdstoricoultimoEqualThis, IdsedelegaleultimoEqualThis,
IdrapprlegaleultimoEqualThis, IdcontocorrenteultimoEqualThis);
            ImpresaCollectionTemp.Provider = this;
            return ImpresaCollectionTemp;
        }

        //Find: popola la collection
        public ImpresaCollection Find(StringNT CuaaEqualThis, StringNT CodicefiscaleEqualThis, StringNT RagionesocialeLikeThis)
        {
            ImpresaCollection ImpresaCollectionTemp = ImpresaDAL.Find(_dbProviderObj, CuaaEqualThis, CodicefiscaleEqualThis, RagionesocialeLikeThis);
            ImpresaCollectionTemp.Provider = this;
            return ImpresaCollectionTemp;
        }


    }
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<IMPRESA>
  <ViewName>vIMPRESA</ViewName>
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
    <Find OrderBy="ORDER BY ATTIVA DESC">
      <CUAA>Equal</CUAA>
      <CODICE_FISCALE>Equal</CODICE_FISCALE>
      <RAGIONE_SOCIALE>Like</RAGIONE_SOCIALE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</IMPRESA>
*/
