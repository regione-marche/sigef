using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

    // interfaccia provider per ProgettoIndicatori
    // Interfaccia Autogenerata
    // Inserire eventuali operazioni aggiuntive
    public interface IProgettoIndicatoriProvider
    {
        int Save(ProgettoIndicatori ProgettoIndicatoriObj);
        int SaveCollection(ProgettoIndicatoriCollection collectionObj);
        int Delete(ProgettoIndicatori ProgettoIndicatoriObj);
        int DeleteCollection(ProgettoIndicatoriCollection collectionObj);
    }
    /// <summary>
    /// Summary description for ProgettoIndicatori
    /// Class Autogenerata
    /// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
    /// con delle partial class contenenti i metodi aggiunti, in questo modo 
    /// non verranno sovrascritti quando si rigenera la classe 
    /// </summary>

    [Serializable]
    [System.Xml.Serialization.XmlType(Namespace = "")]

    public partial class ProgettoIndicatori : BaseObject
    {

        //Definizione dei campi 'base'
        private NullTypes.IntNT _IdProgettoIndicatori;
        private NullTypes.IntNT _IdDimXProgrammazione;
        private NullTypes.IntNT _IdProgetto;
        private NullTypes.IntNT _IdDomandaPagamento;
        private NullTypes.IntNT _IdVariante;
        private NullTypes.StringNT _CodTipo;
        private NullTypes.DecimalNT _ValoreProgrammatoRichiesto;
        private NullTypes.DecimalNT _ValoreRealizzatoRichiesto;
        private NullTypes.DatetimeNT _DataRegistrazione;
        private NullTypes.IntNT _Operatore;
        private NullTypes.DecimalNT _ValoreProgrammatoAmmesso;
        private NullTypes.DecimalNT _ValoreRealizzatoAmmesso;
        private NullTypes.DatetimeNT _DataIstruttoria;
        private NullTypes.IntNT _Istruttore;
        private NullTypes.StringNT _DimDescrizione;
        private NullTypes.StringNT _DimUm;
        private NullTypes.StringNT _Richiedibile;
        private NullTypes.StringNT _ProceduraCalcolo;
        private NullTypes.StringNT _DimCodice;
        private NullTypes.IntNT _IdProgrammazione;
        private NullTypes.StringNT _ProgrammazioneCodice;
        private NullTypes.StringNT _ProgrammazioneDescrizione;
        [NonSerialized]
        private IProgettoIndicatoriProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IProgettoIndicatoriProvider Provider
        {
            get { return _provider; }
            set { _provider = value; }
        }


        //Costruttore
        public ProgettoIndicatori()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //Get e Set dei campi 'base'
        /// <summary>
        /// Corrisponde al campo:ID_PROGETTO_INDICATORI
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdProgettoIndicatori
        {
            get { return _IdProgettoIndicatori; }
            set
            {
                if (IdProgettoIndicatori != value)
                {
                    _IdProgettoIndicatori = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_DIM_X_PROGRAMMAZIONE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdDimXProgrammazione
        {
            get { return _IdDimXProgrammazione; }
            set
            {
                if (IdDimXProgrammazione != value)
                {
                    _IdDimXProgrammazione = value;
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
        /// Corrisponde al campo:ID_DOMANDA_PAGAMENTO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdDomandaPagamento
        {
            get { return _IdDomandaPagamento; }
            set
            {
                if (IdDomandaPagamento != value)
                {
                    _IdDomandaPagamento = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_VARIANTE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdVariante
        {
            get { return _IdVariante; }
            set
            {
                if (IdVariante != value)
                {
                    _IdVariante = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:COD_TIPO
        /// Tipo sul db:VARCHAR(10)
        /// </summary>
        public NullTypes.StringNT CodTipo
        {
            get { return _CodTipo; }
            set
            {
                if (CodTipo != value)
                {
                    _CodTipo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:VALORE_PROGRAMMATO_RICHIESTO
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT ValoreProgrammatoRichiesto
        {
            get { return _ValoreProgrammatoRichiesto; }
            set
            {
                if (ValoreProgrammatoRichiesto != value)
                {
                    _ValoreProgrammatoRichiesto = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:VALORE_REALIZZATO_RICHIESTO
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT ValoreRealizzatoRichiesto
        {
            get { return _ValoreRealizzatoRichiesto; }
            set
            {
                if (ValoreRealizzatoRichiesto != value)
                {
                    _ValoreRealizzatoRichiesto = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_REGISTRAZIONE
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataRegistrazione
        {
            get { return _DataRegistrazione; }
            set
            {
                if (DataRegistrazione != value)
                {
                    _DataRegistrazione = value;
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
        /// Corrisponde al campo:VALORE_PROGRAMMATO_AMMESSO
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT ValoreProgrammatoAmmesso
        {
            get { return _ValoreProgrammatoAmmesso; }
            set
            {
                if (ValoreProgrammatoAmmesso != value)
                {
                    _ValoreProgrammatoAmmesso = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:VALORE_REALIZZATO_AMMESSO
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT ValoreRealizzatoAmmesso
        {
            get { return _ValoreRealizzatoAmmesso; }
            set
            {
                if (ValoreRealizzatoAmmesso != value)
                {
                    _ValoreRealizzatoAmmesso = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_ISTRUTTORIA
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataIstruttoria
        {
            get { return _DataIstruttoria; }
            set
            {
                if (DataIstruttoria != value)
                {
                    _DataIstruttoria = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ISTRUTTORE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT Istruttore
        {
            get { return _Istruttore; }
            set
            {
                if (Istruttore != value)
                {
                    _Istruttore = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:Dim_Descrizione
        /// Tipo sul db:VARCHAR(1000)
        /// </summary>
        public NullTypes.StringNT DimDescrizione
        {
            get { return _DimDescrizione; }
            set
            {
                if (DimDescrizione != value)
                {
                    _DimDescrizione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:Dim_Um
        /// Tipo sul db:VARCHAR(50)
        /// </summary>
        public NullTypes.StringNT DimUm
        {
            get { return _DimUm; }
            set
            {
                if (DimUm != value)
                {
                    _DimUm = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:RICHIEDIBILE
        /// Tipo sul db:CHAR(1)
        /// </summary>
        public NullTypes.StringNT Richiedibile
        {
            get { return _Richiedibile; }
            set
            {
                if (Richiedibile != value)
                {
                    _Richiedibile = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:PROCEDURA_CALCOLO
        /// Tipo sul db:VARCHAR(255)
        /// </summary>
        public NullTypes.StringNT ProceduraCalcolo
        {
            get { return _ProceduraCalcolo; }
            set
            {
                if (ProceduraCalcolo != value)
                {
                    _ProceduraCalcolo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:Dim_Codice
        /// Tipo sul db:VARCHAR(50)
        /// </summary>
        public NullTypes.StringNT DimCodice
        {
            get { return _DimCodice; }
            set
            {
                if (DimCodice != value)
                {
                    _DimCodice = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:Id_Programmazione
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdProgrammazione
        {
            get { return _IdProgrammazione; }
            set
            {
                if (IdProgrammazione != value)
                {
                    _IdProgrammazione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:Programmazione_Codice
        /// Tipo sul db:VARCHAR(20)
        /// </summary>
        public NullTypes.StringNT ProgrammazioneCodice
        {
            get { return _ProgrammazioneCodice; }
            set
            {
                if (ProgrammazioneCodice != value)
                {
                    _ProgrammazioneCodice = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:Programmazione_Descrizione
        /// Tipo sul db:VARCHAR(2000)
        /// </summary>
        public NullTypes.StringNT ProgrammazioneDescrizione
        {
            get { return _ProgrammazioneDescrizione; }
            set
            {
                if (ProgrammazioneDescrizione != value)
                {
                    _ProgrammazioneDescrizione = value;
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
    /// Summary description for ProgettoIndicatoriCollection
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class ProgettoIndicatoriCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
        private ProgettoIndicatoriCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((ProgettoIndicatori)info.GetValue(i.ToString(), typeof(ProgettoIndicatori)));
            }
        }

        //Costruttore
        public ProgettoIndicatoriCollection()
        {
            this.ItemType = typeof(ProgettoIndicatori);
        }

        //Costruttore con provider
        public ProgettoIndicatoriCollection(IProgettoIndicatoriProvider providerObj)
        {
            this.ItemType = typeof(ProgettoIndicatori);
            this.Provider = providerObj;
        }

        //Get e Set
        public new ProgettoIndicatori this[int index]
        {
            get { return (ProgettoIndicatori)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new ProgettoIndicatoriCollection GetChanges()
        {
            return (ProgettoIndicatoriCollection)base.GetChanges();
        }

        [NonSerialized]
        private IProgettoIndicatoriProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IProgettoIndicatoriProvider Provider
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
        public int Add(ProgettoIndicatori ProgettoIndicatoriObj)
        {
            if (ProgettoIndicatoriObj.Provider == null) ProgettoIndicatoriObj.Provider = this.Provider;
            return base.Add(ProgettoIndicatoriObj);
        }

        //AddCollection
        public void AddCollection(ProgettoIndicatoriCollection ProgettoIndicatoriCollectionObj)
        {
            foreach (ProgettoIndicatori ProgettoIndicatoriObj in ProgettoIndicatoriCollectionObj)
                this.Add(ProgettoIndicatoriObj);
        }

        //Insert
        public void Insert(int index, ProgettoIndicatori ProgettoIndicatoriObj)
        {
            if (ProgettoIndicatoriObj.Provider == null) ProgettoIndicatoriObj.Provider = this.Provider;
            base.Insert(index, ProgettoIndicatoriObj);
        }

        //CollectionGetById
        public ProgettoIndicatori CollectionGetById(NullTypes.IntNT IdProgettoIndicatoriValue)
        {
            int i = 0;
            bool find = false;
            while ((i < this.Count) && (!find))
            {
                if ((this[i].IdProgettoIndicatori == IdProgettoIndicatoriValue))
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
        public ProgettoIndicatoriCollection SubSelect(NullTypes.IntNT IdProgettoIndicatoriEqualThis, NullTypes.IntNT IdDimXProgrammazioneEqualThis, NullTypes.IntNT IdProgettoEqualThis,
NullTypes.IntNT IdDomandaPagamentoEqualThis, NullTypes.IntNT IdVarianteEqualThis, NullTypes.StringNT CodTipoEqualThis,
NullTypes.DecimalNT ValoreProgrammatoRichiestoEqualThis, NullTypes.DecimalNT ValoreRealizzatoRichiestoEqualThis, NullTypes.DatetimeNT DataRegistrazioneEqualThis,
NullTypes.IntNT OperatoreEqualThis, NullTypes.DecimalNT ValoreProgrammatoAmmessoEqualThis, NullTypes.DecimalNT ValoreRealizzatoAmmessoEqualThis,
NullTypes.DatetimeNT DataIstruttoriaEqualThis, NullTypes.IntNT IstruttoreEqualThis)
        {
            ProgettoIndicatoriCollection ProgettoIndicatoriCollectionTemp = new ProgettoIndicatoriCollection();
            foreach (ProgettoIndicatori ProgettoIndicatoriItem in this)
            {
                if (((IdProgettoIndicatoriEqualThis == null) || ((ProgettoIndicatoriItem.IdProgettoIndicatori != null) && (ProgettoIndicatoriItem.IdProgettoIndicatori.Value == IdProgettoIndicatoriEqualThis.Value))) && ((IdDimXProgrammazioneEqualThis == null) || ((ProgettoIndicatoriItem.IdDimXProgrammazione != null) && (ProgettoIndicatoriItem.IdDimXProgrammazione.Value == IdDimXProgrammazioneEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((ProgettoIndicatoriItem.IdProgetto != null) && (ProgettoIndicatoriItem.IdProgetto.Value == IdProgettoEqualThis.Value))) &&
((IdDomandaPagamentoEqualThis == null) || ((ProgettoIndicatoriItem.IdDomandaPagamento != null) && (ProgettoIndicatoriItem.IdDomandaPagamento.Value == IdDomandaPagamentoEqualThis.Value))) && ((IdVarianteEqualThis == null) || ((ProgettoIndicatoriItem.IdVariante != null) && (ProgettoIndicatoriItem.IdVariante.Value == IdVarianteEqualThis.Value))) && ((CodTipoEqualThis == null) || ((ProgettoIndicatoriItem.CodTipo != null) && (ProgettoIndicatoriItem.CodTipo.Value == CodTipoEqualThis.Value))) &&
((ValoreProgrammatoRichiestoEqualThis == null) || ((ProgettoIndicatoriItem.ValoreProgrammatoRichiesto != null) && (ProgettoIndicatoriItem.ValoreProgrammatoRichiesto.Value == ValoreProgrammatoRichiestoEqualThis.Value))) && ((ValoreRealizzatoRichiestoEqualThis == null) || ((ProgettoIndicatoriItem.ValoreRealizzatoRichiesto != null) && (ProgettoIndicatoriItem.ValoreRealizzatoRichiesto.Value == ValoreRealizzatoRichiestoEqualThis.Value))) && ((DataRegistrazioneEqualThis == null) || ((ProgettoIndicatoriItem.DataRegistrazione != null) && (ProgettoIndicatoriItem.DataRegistrazione.Value == DataRegistrazioneEqualThis.Value))) &&
((OperatoreEqualThis == null) || ((ProgettoIndicatoriItem.Operatore != null) && (ProgettoIndicatoriItem.Operatore.Value == OperatoreEqualThis.Value))) && ((ValoreProgrammatoAmmessoEqualThis == null) || ((ProgettoIndicatoriItem.ValoreProgrammatoAmmesso != null) && (ProgettoIndicatoriItem.ValoreProgrammatoAmmesso.Value == ValoreProgrammatoAmmessoEqualThis.Value))) && ((ValoreRealizzatoAmmessoEqualThis == null) || ((ProgettoIndicatoriItem.ValoreRealizzatoAmmesso != null) && (ProgettoIndicatoriItem.ValoreRealizzatoAmmesso.Value == ValoreRealizzatoAmmessoEqualThis.Value))) &&
((DataIstruttoriaEqualThis == null) || ((ProgettoIndicatoriItem.DataIstruttoria != null) && (ProgettoIndicatoriItem.DataIstruttoria.Value == DataIstruttoriaEqualThis.Value))) && ((IstruttoreEqualThis == null) || ((ProgettoIndicatoriItem.Istruttore != null) && (ProgettoIndicatoriItem.Istruttore.Value == IstruttoreEqualThis.Value))))
                {
                    ProgettoIndicatoriCollectionTemp.Add(ProgettoIndicatoriItem);
                }
            }
            return ProgettoIndicatoriCollectionTemp;
        }



    }
}

namespace SiarDAL
{

    /// <summary>
    /// Summary description for ProgettoIndicatoriDAL
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>


    internal class ProgettoIndicatoriDAL
    {

        //Operazioni

        //internal CompileIUCmd compila un command con i parametri per l'insert o l'update
        protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, ProgettoIndicatori ProgettoIndicatoriObj, string firstChar)
        {
            if (forUpdate)
            {
                // campi identity valorizzati solo per l'update
                DbProvider.SetCmdParam(cmd, firstChar + "IdProgettoIndicatori", ProgettoIndicatoriObj.IdProgettoIndicatori);
                // altri campi sempre valorizzati
            }
            DbProvider.SetCmdParam(cmd, firstChar + "IdDimXProgrammazione", ProgettoIndicatoriObj.IdDimXProgrammazione);
            DbProvider.SetCmdParam(cmd, firstChar + "IdProgetto", ProgettoIndicatoriObj.IdProgetto);
            DbProvider.SetCmdParam(cmd, firstChar + "IdDomandaPagamento", ProgettoIndicatoriObj.IdDomandaPagamento);
            DbProvider.SetCmdParam(cmd, firstChar + "IdVariante", ProgettoIndicatoriObj.IdVariante);
            DbProvider.SetCmdParam(cmd, firstChar + "CodTipo", ProgettoIndicatoriObj.CodTipo);
            DbProvider.SetCmdParam(cmd, firstChar + "ValoreProgrammatoRichiesto", ProgettoIndicatoriObj.ValoreProgrammatoRichiesto);
            DbProvider.SetCmdParam(cmd, firstChar + "ValoreRealizzatoRichiesto", ProgettoIndicatoriObj.ValoreRealizzatoRichiesto);
            DbProvider.SetCmdParam(cmd, firstChar + "DataRegistrazione", ProgettoIndicatoriObj.DataRegistrazione);
            DbProvider.SetCmdParam(cmd, firstChar + "Operatore", ProgettoIndicatoriObj.Operatore);
            DbProvider.SetCmdParam(cmd, firstChar + "ValoreProgrammatoAmmesso", ProgettoIndicatoriObj.ValoreProgrammatoAmmesso);
            DbProvider.SetCmdParam(cmd, firstChar + "ValoreRealizzatoAmmesso", ProgettoIndicatoriObj.ValoreRealizzatoAmmesso);
            DbProvider.SetCmdParam(cmd, firstChar + "DataIstruttoria", ProgettoIndicatoriObj.DataIstruttoria);
            DbProvider.SetCmdParam(cmd, firstChar + "Istruttore", ProgettoIndicatoriObj.Istruttore);
        }
        //Insert
        private static int Insert(DbProvider db, ProgettoIndicatori ProgettoIndicatoriObj)
        {
            int i = 1;
            try
            {
                IDbCommand insertCmd = db.InitCmd("ZProgettoIndicatoriInsert", new string[] {"IdDimXProgrammazione", "IdProgetto", 
"IdDomandaPagamento", "IdVariante", "CodTipo", 
"ValoreProgrammatoRichiesto", "ValoreRealizzatoRichiesto", "DataRegistrazione", 
"Operatore", "ValoreProgrammatoAmmesso", "ValoreRealizzatoAmmesso", 
"DataIstruttoria", "Istruttore", 

}, new string[] {"int", "int", 
"int", "int", "string", 
"decimal", "decimal", "DateTime", 
"int", "decimal", "decimal", 
"DateTime", "int", 

}, "");
                CompileIUCmd(false, insertCmd, ProgettoIndicatoriObj, db.CommandFirstChar);
                db.InitDatareader(insertCmd);
                if (db.DataReader.Read())
                {
                    ProgettoIndicatoriObj.IdProgettoIndicatori = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO_INDICATORI"]);
                }
                ProgettoIndicatoriObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ProgettoIndicatoriObj.IsDirty = false;
                ProgettoIndicatoriObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //update
        private static int Update(DbProvider db, ProgettoIndicatori ProgettoIndicatoriObj)
        {
            int i = 1;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZProgettoIndicatoriUpdate", new string[] {"IdProgettoIndicatori", "IdDimXProgrammazione", "IdProgetto", 
"IdDomandaPagamento", "IdVariante", "CodTipo", 
"ValoreProgrammatoRichiesto", "ValoreRealizzatoRichiesto", "DataRegistrazione", 
"Operatore", "ValoreProgrammatoAmmesso", "ValoreRealizzatoAmmesso", 
"DataIstruttoria", "Istruttore", 

}, new string[] {"int", "int", "int", 
"int", "int", "string", 
"decimal", "decimal", "DateTime", 
"int", "decimal", "decimal", 
"DateTime", "int", 

}, "");
                CompileIUCmd(true, updateCmd, ProgettoIndicatoriObj, db.CommandFirstChar);
                i = db.Execute(updateCmd);
                ProgettoIndicatoriObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ProgettoIndicatoriObj.IsDirty = false;
                ProgettoIndicatoriObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //Save
        public static int Save(DbProvider db, ProgettoIndicatori ProgettoIndicatoriObj)
        {
            switch (ProgettoIndicatoriObj.ObjectState)
            {
                case BaseObject.ObjectStateType.Added: return Insert(db, ProgettoIndicatoriObj);
                case BaseObject.ObjectStateType.Changed: return Update(db, ProgettoIndicatoriObj);
                case BaseObject.ObjectStateType.Deleted: return Delete(db, ProgettoIndicatoriObj);
                default: return 0;
            }
        }

        public static int SaveCollection(DbProvider db, ProgettoIndicatoriCollection ProgettoIndicatoriCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZProgettoIndicatoriUpdate", new string[] {"IdProgettoIndicatori", "IdDimXProgrammazione", "IdProgetto", 
"IdDomandaPagamento", "IdVariante", "CodTipo", 
"ValoreProgrammatoRichiesto", "ValoreRealizzatoRichiesto", "DataRegistrazione", 
"Operatore", "ValoreProgrammatoAmmesso", "ValoreRealizzatoAmmesso", 
"DataIstruttoria", "Istruttore", 

}, new string[] {"int", "int", "int", 
"int", "int", "string", 
"decimal", "decimal", "DateTime", 
"int", "decimal", "decimal", 
"DateTime", "int", 

}, "");
                IDbCommand insertCmd = db.InitCmd("ZProgettoIndicatoriInsert", new string[] {"IdDimXProgrammazione", "IdProgetto", 
"IdDomandaPagamento", "IdVariante", "CodTipo", 
"ValoreProgrammatoRichiesto", "ValoreRealizzatoRichiesto", "DataRegistrazione", 
"Operatore", "ValoreProgrammatoAmmesso", "ValoreRealizzatoAmmesso", 
"DataIstruttoria", "Istruttore", 

}, new string[] {"int", "int", 
"int", "int", "string", 
"decimal", "decimal", "DateTime", 
"int", "decimal", "decimal", 
"DateTime", "int", 

}, "");
                IDbCommand deleteCmd = db.InitCmd("ZProgettoIndicatoriDelete", new string[] { "IdProgettoIndicatori" }, new string[] { "int" }, "");
                for (int i = 0; i < ProgettoIndicatoriCollectionObj.Count; i++)
                {
                    switch (ProgettoIndicatoriCollectionObj[i].ObjectState)
                    {
                        case BaseObject.ObjectStateType.Added:
                            {
                                CompileIUCmd(false, insertCmd, ProgettoIndicatoriCollectionObj[i], db.CommandFirstChar);
                                db.InitDatareader(insertCmd);
                                if (db.DataReader.Read())
                                {
                                    ProgettoIndicatoriCollectionObj[i].IdProgettoIndicatori = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO_INDICATORI"]);
                                }
                                db.DataReader.Close();
                                returnValue++;
                            }
                            break;
                        case BaseObject.ObjectStateType.Changed:
                            {
                                CompileIUCmd(true, updateCmd, ProgettoIndicatoriCollectionObj[i], db.CommandFirstChar);
                                returnValue = returnValue + db.Execute(updateCmd);
                            }
                            break;
                        case BaseObject.ObjectStateType.Deleted:
                            {
                                if (ProgettoIndicatoriCollectionObj[i].IsPersistent)
                                {
                                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdProgettoIndicatori", (SiarLibrary.NullTypes.IntNT)ProgettoIndicatoriCollectionObj[i].IdProgettoIndicatori);
                                    returnValue = returnValue + db.Execute(deleteCmd);
                                }
                            }
                            break;
                    }
                }
                db.Commit();
                for (int i = 0; i < ProgettoIndicatoriCollectionObj.Count; i++)
                {
                    if ((ProgettoIndicatoriCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ProgettoIndicatoriCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        ProgettoIndicatoriCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
                        ProgettoIndicatoriCollectionObj[i].IsDirty = false;
                        ProgettoIndicatoriCollectionObj[i].IsPersistent = true;
                    }
                    if ((ProgettoIndicatoriCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
                    {
                        ProgettoIndicatoriCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        ProgettoIndicatoriCollectionObj[i].IsDirty = false;
                        ProgettoIndicatoriCollectionObj[i].IsPersistent = false;
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
        public static int Delete(DbProvider db, ProgettoIndicatori ProgettoIndicatoriObj)
        {
            int returnValue = 0;
            if (ProgettoIndicatoriObj.IsPersistent)
            {
                returnValue = Delete(db, ProgettoIndicatoriObj.IdProgettoIndicatori);
            }
            ProgettoIndicatoriObj.ObjectState = BaseObject.ObjectStateType.Deleted;
            ProgettoIndicatoriObj.IsDirty = false;
            ProgettoIndicatoriObj.IsPersistent = false;
            return returnValue;
        }

        //Delete
        private static int Delete(DbProvider db, int IdProgettoIndicatoriValue)
        {
            int i = 1;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZProgettoIndicatoriDelete", new string[] { "IdProgettoIndicatori" }, new string[] { "int" }, "");
                DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdProgettoIndicatori", (SiarLibrary.NullTypes.IntNT)IdProgettoIndicatoriValue);
                i = db.Execute(deleteCmd);
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        public static int DeleteCollection(DbProvider db, ProgettoIndicatoriCollection ProgettoIndicatoriCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZProgettoIndicatoriDelete", new string[] { "IdProgettoIndicatori" }, new string[] { "int" }, "");
                for (int i = 0; i < ProgettoIndicatoriCollectionObj.Count; i++)
                {
                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdProgettoIndicatori", ProgettoIndicatoriCollectionObj[i].IdProgettoIndicatori);
                    returnValue = returnValue + db.Execute(deleteCmd);
                }
                db.Commit();
                for (int i = 0; i < ProgettoIndicatoriCollectionObj.Count; i++)
                {
                    if ((ProgettoIndicatoriCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ProgettoIndicatoriCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        ProgettoIndicatoriCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        ProgettoIndicatoriCollectionObj[i].IsDirty = false;
                        ProgettoIndicatoriCollectionObj[i].IsPersistent = false;
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
        public static ProgettoIndicatori GetById(DbProvider db, int IdProgettoIndicatoriValue)
        {
            ProgettoIndicatori ProgettoIndicatoriObj = null;
            IDbCommand readCmd = db.InitCmd("ZProgettoIndicatoriGetById", new string[] { "IdProgettoIndicatori" }, new string[] { "int" }, "");
            DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "IdProgettoIndicatori", (SiarLibrary.NullTypes.IntNT)IdProgettoIndicatoriValue);
            db.InitDatareader(readCmd);
            if (db.DataReader.Read())
            {
                ProgettoIndicatoriObj = GetFromDatareader(db);
                ProgettoIndicatoriObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ProgettoIndicatoriObj.IsDirty = false;
                ProgettoIndicatoriObj.IsPersistent = true;
            }
            db.Close();
            return ProgettoIndicatoriObj;
        }

        //getFromDatareader
        public static ProgettoIndicatori GetFromDatareader(DbProvider db)
        {
            ProgettoIndicatori ProgettoIndicatoriObj = new ProgettoIndicatori();
            ProgettoIndicatoriObj.IdProgettoIndicatori = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO_INDICATORI"]);
            ProgettoIndicatoriObj.IdDimXProgrammazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DIM_X_PROGRAMMAZIONE"]);
            ProgettoIndicatoriObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
            ProgettoIndicatoriObj.IdDomandaPagamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA_PAGAMENTO"]);
            ProgettoIndicatoriObj.IdVariante = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_VARIANTE"]);
            ProgettoIndicatoriObj.CodTipo = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO"]);
            ProgettoIndicatoriObj.ValoreProgrammatoRichiesto = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["VALORE_PROGRAMMATO_RICHIESTO"]);
            ProgettoIndicatoriObj.ValoreRealizzatoRichiesto = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["VALORE_REALIZZATO_RICHIESTO"]);
            ProgettoIndicatoriObj.DataRegistrazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_REGISTRAZIONE"]);
            ProgettoIndicatoriObj.Operatore = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE"]);
            ProgettoIndicatoriObj.ValoreProgrammatoAmmesso = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["VALORE_PROGRAMMATO_AMMESSO"]);
            ProgettoIndicatoriObj.ValoreRealizzatoAmmesso = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["VALORE_REALIZZATO_AMMESSO"]);
            ProgettoIndicatoriObj.DataIstruttoria = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_ISTRUTTORIA"]);
            ProgettoIndicatoriObj.Istruttore = new SiarLibrary.NullTypes.IntNT(db.DataReader["ISTRUTTORE"]);
            ProgettoIndicatoriObj.DimDescrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["Dim_Descrizione"]);
            ProgettoIndicatoriObj.DimUm = new SiarLibrary.NullTypes.StringNT(db.DataReader["Dim_Um"]);
            ProgettoIndicatoriObj.Richiedibile = new SiarLibrary.NullTypes.StringNT(db.DataReader["RICHIEDIBILE"]);
            ProgettoIndicatoriObj.ProceduraCalcolo = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROCEDURA_CALCOLO"]);
            ProgettoIndicatoriObj.DimCodice = new SiarLibrary.NullTypes.StringNT(db.DataReader["Dim_Codice"]);
            ProgettoIndicatoriObj.IdProgrammazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["Id_Programmazione"]);
            ProgettoIndicatoriObj.ProgrammazioneCodice = new SiarLibrary.NullTypes.StringNT(db.DataReader["Programmazione_Codice"]);
            ProgettoIndicatoriObj.ProgrammazioneDescrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["Programmazione_Descrizione"]);
            ProgettoIndicatoriObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            ProgettoIndicatoriObj.IsDirty = false;
            ProgettoIndicatoriObj.IsPersistent = true;
            return ProgettoIndicatoriObj;
        }

        //Find Select

        public static ProgettoIndicatoriCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdProgettoIndicatoriEqualThis, SiarLibrary.NullTypes.IntNT IdDimXProgrammazioneEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis,
SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.IntNT IdVarianteEqualThis, SiarLibrary.NullTypes.StringNT CodTipoEqualThis,
SiarLibrary.NullTypes.DecimalNT ValoreProgrammatoRichiestoEqualThis, SiarLibrary.NullTypes.DecimalNT ValoreRealizzatoRichiestoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataRegistrazioneEqualThis,
SiarLibrary.NullTypes.IntNT OperatoreEqualThis, SiarLibrary.NullTypes.DecimalNT ValoreProgrammatoAmmessoEqualThis, SiarLibrary.NullTypes.DecimalNT ValoreRealizzatoAmmessoEqualThis,
SiarLibrary.NullTypes.DatetimeNT DataIstruttoriaEqualThis, SiarLibrary.NullTypes.IntNT IstruttoreEqualThis)
        {

            ProgettoIndicatoriCollection ProgettoIndicatoriCollectionObj = new ProgettoIndicatoriCollection();

            IDbCommand findCmd = db.InitCmd("Zprogettoindicatorifindselect", new string[] {"IdProgettoIndicatoriequalthis", "IdDimXProgrammazioneequalthis", "IdProgettoequalthis", 
"IdDomandaPagamentoequalthis", "IdVarianteequalthis", "CodTipoequalthis", 
"ValoreProgrammatoRichiestoequalthis", "ValoreRealizzatoRichiestoequalthis", "DataRegistrazioneequalthis", 
"Operatoreequalthis", "ValoreProgrammatoAmmessoequalthis", "ValoreRealizzatoAmmessoequalthis", 
"DataIstruttoriaequalthis", "Istruttoreequalthis"}, new string[] {"int", "int", "int", 
"int", "int", "string", 
"decimal", "decimal", "DateTime", 
"int", "decimal", "decimal", 
"DateTime", "int"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoIndicatoriequalthis", IdProgettoIndicatoriEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdDimXProgrammazioneequalthis", IdDimXProgrammazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdVarianteequalthis", IdVarianteEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodTipoequalthis", CodTipoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ValoreProgrammatoRichiestoequalthis", ValoreProgrammatoRichiestoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ValoreRealizzatoRichiestoequalthis", ValoreRealizzatoRichiestoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataRegistrazioneequalthis", DataRegistrazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Operatoreequalthis", OperatoreEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ValoreProgrammatoAmmessoequalthis", ValoreProgrammatoAmmessoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ValoreRealizzatoAmmessoequalthis", ValoreRealizzatoAmmessoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataIstruttoriaequalthis", DataIstruttoriaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Istruttoreequalthis", IstruttoreEqualThis);
            ProgettoIndicatori ProgettoIndicatoriObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                ProgettoIndicatoriObj = GetFromDatareader(db);
                ProgettoIndicatoriObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ProgettoIndicatoriObj.IsDirty = false;
                ProgettoIndicatoriObj.IsPersistent = true;
                ProgettoIndicatoriCollectionObj.Add(ProgettoIndicatoriObj);
            }
            db.Close();
            return ProgettoIndicatoriCollectionObj;
        }

        //Find Find

        public static ProgettoIndicatoriCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.IntNT IdVarianteEqualThis)
        {

            ProgettoIndicatoriCollection ProgettoIndicatoriCollectionObj = new ProgettoIndicatoriCollection();

            IDbCommand findCmd = db.InitCmd("Zprogettoindicatorifindfind", new string[] { "IdProgettoequalthis", "IdDomandaPagamentoequalthis", "IdVarianteequalthis" }, new string[] { "int", "int", "int" }, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdVarianteequalthis", IdVarianteEqualThis);
            ProgettoIndicatori ProgettoIndicatoriObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                ProgettoIndicatoriObj = GetFromDatareader(db);
                ProgettoIndicatoriObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ProgettoIndicatoriObj.IsDirty = false;
                ProgettoIndicatoriObj.IsPersistent = true;
                ProgettoIndicatoriCollectionObj.Add(ProgettoIndicatoriObj);
            }
            db.Close();
            return ProgettoIndicatoriCollectionObj;
        }

    }
}


namespace SiarBLL
{

    /// <summary>
    /// Summary description for ProgettoIndicatoriCollectionProvider:IProgettoIndicatoriProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class ProgettoIndicatoriCollectionProvider : IProgettoIndicatoriProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di ProgettoIndicatori
        protected ProgettoIndicatoriCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public ProgettoIndicatoriCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new ProgettoIndicatoriCollection(this);
        }

        //Costruttore 2: popola la collection
        public ProgettoIndicatoriCollectionProvider(IntNT IdprogettoEqualThis, IntNT IddomandapagamentoEqualThis, IntNT IdvarianteEqualThis)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = Find(IdprogettoEqualThis, IddomandapagamentoEqualThis, IdvarianteEqualThis);
        }

        //Costruttore3: ha in input progettoindicatoriCollectionObj - non popola la collection
        public ProgettoIndicatoriCollectionProvider(ProgettoIndicatoriCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public ProgettoIndicatoriCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new ProgettoIndicatoriCollection(this);
        }

        //Get e Set
        public ProgettoIndicatoriCollection CollectionObj
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
        public int SaveCollection(ProgettoIndicatoriCollection collectionObj)
        {
            return ProgettoIndicatoriDAL.SaveCollection(_dbProviderObj, collectionObj);
        }

        //Save3: registra l'elemento i-esimo della collection
        public int Save(int i)
        {
            return Save(_CollectionObj[i]);
        }

        //Save4: registra un elemento singolo
        public int Save(ProgettoIndicatori progettoindicatoriObj)
        {
            return ProgettoIndicatoriDAL.Save(_dbProviderObj, progettoindicatoriObj);
        }

        //delete1: elimina l'intera collection
        public int DeleteCollection()
        {
            return DeleteCollection(_CollectionObj);
        }

        //delete2: elimina una collection
        public int DeleteCollection(ProgettoIndicatoriCollection collectionObj)
        {
            return ProgettoIndicatoriDAL.DeleteCollection(_dbProviderObj, collectionObj);
        }

        //delete3: elimina l'elemento i-esimo della collection
        public int Delete(int i)
        {
            return Delete(_CollectionObj[i]);
        }

        //delete4: elimina un elemento singolo
        public int Delete(ProgettoIndicatori progettoindicatoriObj)
        {
            return ProgettoIndicatoriDAL.Delete(_dbProviderObj, progettoindicatoriObj);
        }

        //getById
        public ProgettoIndicatori GetById(IntNT IdProgettoIndicatoriValue)
        {
            ProgettoIndicatori ProgettoIndicatoriTemp = ProgettoIndicatoriDAL.GetById(_dbProviderObj, IdProgettoIndicatoriValue);
            if (ProgettoIndicatoriTemp != null) ProgettoIndicatoriTemp.Provider = this;
            return ProgettoIndicatoriTemp;
        }

        //Get e Set dei campi 'ForeignKey'
        //Select: popola la collection
        public ProgettoIndicatoriCollection Select(IntNT IdprogettoindicatoriEqualThis, IntNT IddimxprogrammazioneEqualThis, IntNT IdprogettoEqualThis,
IntNT IddomandapagamentoEqualThis, IntNT IdvarianteEqualThis, StringNT CodtipoEqualThis,
DecimalNT ValoreprogrammatorichiestoEqualThis, DecimalNT ValorerealizzatorichiestoEqualThis, DatetimeNT DataregistrazioneEqualThis,
IntNT OperatoreEqualThis, DecimalNT ValoreprogrammatoammessoEqualThis, DecimalNT ValorerealizzatoammessoEqualThis,
DatetimeNT DataistruttoriaEqualThis, IntNT IstruttoreEqualThis)
        {
            ProgettoIndicatoriCollection ProgettoIndicatoriCollectionTemp = ProgettoIndicatoriDAL.Select(_dbProviderObj, IdprogettoindicatoriEqualThis, IddimxprogrammazioneEqualThis, IdprogettoEqualThis,
IddomandapagamentoEqualThis, IdvarianteEqualThis, CodtipoEqualThis,
ValoreprogrammatorichiestoEqualThis, ValorerealizzatorichiestoEqualThis, DataregistrazioneEqualThis,
OperatoreEqualThis, ValoreprogrammatoammessoEqualThis, ValorerealizzatoammessoEqualThis,
DataistruttoriaEqualThis, IstruttoreEqualThis);
            ProgettoIndicatoriCollectionTemp.Provider = this;
            return ProgettoIndicatoriCollectionTemp;
        }

        //Find: popola la collection
        public ProgettoIndicatoriCollection Find(IntNT IdprogettoEqualThis, IntNT IddomandapagamentoEqualThis, IntNT IdvarianteEqualThis)
        {
            ProgettoIndicatoriCollection ProgettoIndicatoriCollectionTemp = ProgettoIndicatoriDAL.Find(_dbProviderObj, IdprogettoEqualThis, IddomandapagamentoEqualThis, IdvarianteEqualThis);
            ProgettoIndicatoriCollectionTemp.Provider = this;
            return ProgettoIndicatoriCollectionTemp;
        }


    }
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<PROGETTO_INDICATORI>
  <ViewName>vPROGETTO_INDICATORI</ViewName>
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
    <Find OrderBy="ORDER BY DATA_REGISTRAZIONE">
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
      <ID_VARIANTE>Equal</ID_VARIANTE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</PROGETTO_INDICATORI>
*/
