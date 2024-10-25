using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

    /// <summary>
    /// Summary description for VcruscottoDomandeBeneficiario
    /// Class Autogenerata
    /// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
    /// con delle partial class contenenti i metodi aggiunti, in questo modo 
    /// non verranno sovrascritti quando si rigenera la classe 
    /// </summary>

    [Serializable]
    [System.Xml.Serialization.XmlType(Namespace = "")]

    public partial class VcruscottoDomandeBeneficiario : BaseObject
    {

        //Definizione dei campi 'base'
        private NullTypes.IntNT _IdBando;
        private NullTypes.StringNT _DescrizioneBando;
        private NullTypes.DatetimeNT _DataScadenzaBando;
        private NullTypes.StringNT _CodEnteBando;
        private NullTypes.IntNT _IdProgrammazioneBando;
        private NullTypes.IntNT _IdProgetto;
        private NullTypes.StringNT _CodStatoProgetto;
        private NullTypes.StringNT _StatoProgetto;
        private NullTypes.IntNT _IdImpresa;
        private NullTypes.StringNT _RagioneSocialeImpresa;
        private NullTypes.IntNT _IdUtente;
        private NullTypes.StringNT _NominativoUtenteImpresa;
        private NullTypes.StringNT _CfUtenteImpresa;
        private NullTypes.BoolNT _UtenteAttivo;
        private NullTypes.StringNT _CodRuoloUtenteImpresa;
        private NullTypes.StringNT _RuoloUtenteImpresa;
        private NullTypes.DatetimeNT _DataInizioUtenteImpresa;
        private NullTypes.DatetimeNT _DataFineUtenteImpresa;
        private NullTypes.BoolNT _PotereDiFirmaUtenteImpresa;


        //Costruttore
        public VcruscottoDomandeBeneficiario()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //Get e Set dei campi 'base'
        /// <summary>
        /// Corrisponde al campo:ID_BANDO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdBando
        {
            get { return _IdBando; }
            set
            {
                if (IdBando != value)
                {
                    _IdBando = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DESCRIZIONE_BANDO
        /// Tipo sul db:VARCHAR(2000)
        /// </summary>
        public NullTypes.StringNT DescrizioneBando
        {
            get { return _DescrizioneBando; }
            set
            {
                if (DescrizioneBando != value)
                {
                    _DescrizioneBando = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_SCADENZA_BANDO
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataScadenzaBando
        {
            get { return _DataScadenzaBando; }
            set
            {
                if (DataScadenzaBando != value)
                {
                    _DataScadenzaBando = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:COD_ENTE_BANDO
        /// Tipo sul db:VARCHAR(10)
        /// </summary>
        public NullTypes.StringNT CodEnteBando
        {
            get { return _CodEnteBando; }
            set
            {
                if (CodEnteBando != value)
                {
                    _CodEnteBando = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_PROGRAMMAZIONE_BANDO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdProgrammazioneBando
        {
            get { return _IdProgrammazioneBando; }
            set
            {
                if (IdProgrammazioneBando != value)
                {
                    _IdProgrammazioneBando = value;
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
        /// Corrisponde al campo:COD_STATO_PROGETTO
        /// Tipo sul db:CHAR(1)
        /// </summary>
        public NullTypes.StringNT CodStatoProgetto
        {
            get { return _CodStatoProgetto; }
            set
            {
                if (CodStatoProgetto != value)
                {
                    _CodStatoProgetto = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:STATO_PROGETTO
        /// Tipo sul db:VARCHAR(80)
        /// </summary>
        public NullTypes.StringNT StatoProgetto
        {
            get { return _StatoProgetto; }
            set
            {
                if (StatoProgetto != value)
                {
                    _StatoProgetto = value;
                    SetDirtyFlag();
                }
            }
        }

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
        /// Corrisponde al campo:RAGIONE_SOCIALE_IMPRESA
        /// Tipo sul db:VARCHAR(255)
        /// </summary>
        public NullTypes.StringNT RagioneSocialeImpresa
        {
            get { return _RagioneSocialeImpresa; }
            set
            {
                if (RagioneSocialeImpresa != value)
                {
                    _RagioneSocialeImpresa = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_UTENTE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdUtente
        {
            get { return _IdUtente; }
            set
            {
                if (IdUtente != value)
                {
                    _IdUtente = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:NOMINATIVO_UTENTE_IMPRESA
        /// Tipo sul db:VARCHAR(511)
        /// </summary>
        public NullTypes.StringNT NominativoUtenteImpresa
        {
            get { return _NominativoUtenteImpresa; }
            set
            {
                if (NominativoUtenteImpresa != value)
                {
                    _NominativoUtenteImpresa = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:CF_UTENTE_IMPRESA
        /// Tipo sul db:VARCHAR(16)
        /// </summary>
        public NullTypes.StringNT CfUtenteImpresa
        {
            get { return _CfUtenteImpresa; }
            set
            {
                if (CfUtenteImpresa != value)
                {
                    _CfUtenteImpresa = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:UTENTE_ATTIVO
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT UtenteAttivo
        {
            get { return _UtenteAttivo; }
            set
            {
                if (UtenteAttivo != value)
                {
                    _UtenteAttivo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:COD_RUOLO_UTENTE_IMPRESA
        /// Tipo sul db:CHAR(1)
        /// </summary>
        public NullTypes.StringNT CodRuoloUtenteImpresa
        {
            get { return _CodRuoloUtenteImpresa; }
            set
            {
                if (CodRuoloUtenteImpresa != value)
                {
                    _CodRuoloUtenteImpresa = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:RUOLO_UTENTE_IMPRESA
        /// Tipo sul db:VARCHAR(255)
        /// </summary>
        public NullTypes.StringNT RuoloUtenteImpresa
        {
            get { return _RuoloUtenteImpresa; }
            set
            {
                if (RuoloUtenteImpresa != value)
                {
                    _RuoloUtenteImpresa = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_INIZIO_UTENTE_IMPRESA
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataInizioUtenteImpresa
        {
            get { return _DataInizioUtenteImpresa; }
            set
            {
                if (DataInizioUtenteImpresa != value)
                {
                    _DataInizioUtenteImpresa = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_FINE_UTENTE_IMPRESA
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataFineUtenteImpresa
        {
            get { return _DataFineUtenteImpresa; }
            set
            {
                if (DataFineUtenteImpresa != value)
                {
                    _DataFineUtenteImpresa = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:POTERE_DI_FIRMA_UTENTE_IMPRESA
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT PotereDiFirmaUtenteImpresa
        {
            get { return _PotereDiFirmaUtenteImpresa; }
            set
            {
                if (PotereDiFirmaUtenteImpresa != value)
                {
                    _PotereDiFirmaUtenteImpresa = value;
                    SetDirtyFlag();
                }
            }
        }




    }
}

namespace SiarLibrary
{

    /// <summary>
    /// Summary description for VcruscottoDomandeBeneficiarioCollection
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class VcruscottoDomandeBeneficiarioCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
        private VcruscottoDomandeBeneficiarioCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((VcruscottoDomandeBeneficiario)info.GetValue(i.ToString(), typeof(VcruscottoDomandeBeneficiario)));
            }
        }

        //Costruttore
        public VcruscottoDomandeBeneficiarioCollection()
        {
            this.ItemType = typeof(VcruscottoDomandeBeneficiario);
        }

        //Get e Set
        public new VcruscottoDomandeBeneficiario this[int index]
        {
            get { return (VcruscottoDomandeBeneficiario)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new VcruscottoDomandeBeneficiarioCollection GetChanges()
        {
            return (VcruscottoDomandeBeneficiarioCollection)base.GetChanges();
        }

        //Add
        public int Add(VcruscottoDomandeBeneficiario VcruscottoDomandeBeneficiarioObj)
        {
            return base.Add(VcruscottoDomandeBeneficiarioObj);
        }

        //AddCollection
        public void AddCollection(VcruscottoDomandeBeneficiarioCollection VcruscottoDomandeBeneficiarioCollectionObj)
        {
            foreach (VcruscottoDomandeBeneficiario VcruscottoDomandeBeneficiarioObj in VcruscottoDomandeBeneficiarioCollectionObj)
                this.Add(VcruscottoDomandeBeneficiarioObj);
        }

        //Insert
        public void Insert(int index, VcruscottoDomandeBeneficiario VcruscottoDomandeBeneficiarioObj)
        {
            base.Insert(index, VcruscottoDomandeBeneficiarioObj);
        }

        //filter: effettua una ricerca all'interno della collection
        // se il parametro di ricerca è null, prende tutto,
        // anche i record che hanno quel campo null
        // altrimenti scarta i record che hanno quel campo null ...
        // ...e confronta gli altri
        public VcruscottoDomandeBeneficiarioCollection SubSelect(NullTypes.IntNT IdBandoEqualThis, NullTypes.StringNT DescrizioneBandoEqualThis, NullTypes.DatetimeNT DataScadenzaBandoEqualThis,
NullTypes.StringNT CodEnteBandoEqualThis, NullTypes.IntNT IdProgrammazioneBandoEqualThis, NullTypes.IntNT IdProgettoEqualThis,
NullTypes.StringNT CodStatoProgettoEqualThis, NullTypes.StringNT StatoProgettoEqualThis, NullTypes.IntNT IdImpresaEqualThis,
NullTypes.StringNT RagioneSocialeImpresaEqualThis, NullTypes.IntNT IdUtenteEqualThis, NullTypes.StringNT NominativoUtenteImpresaEqualThis,
NullTypes.StringNT CfUtenteImpresaEqualThis, NullTypes.BoolNT UtenteAttivoEqualThis, NullTypes.StringNT CodRuoloUtenteImpresaEqualThis,
NullTypes.StringNT RuoloUtenteImpresaEqualThis, NullTypes.DatetimeNT DataInizioUtenteImpresaEqualThis, NullTypes.DatetimeNT DataFineUtenteImpresaEqualThis,
NullTypes.BoolNT PotereDiFirmaUtenteImpresaEqualThis)
        {
            VcruscottoDomandeBeneficiarioCollection VcruscottoDomandeBeneficiarioCollectionTemp = new VcruscottoDomandeBeneficiarioCollection();
            foreach (VcruscottoDomandeBeneficiario VcruscottoDomandeBeneficiarioItem in this)
            {
                if (((IdBandoEqualThis == null) || ((VcruscottoDomandeBeneficiarioItem.IdBando != null) && (VcruscottoDomandeBeneficiarioItem.IdBando.Value == IdBandoEqualThis.Value))) && ((DescrizioneBandoEqualThis == null) || ((VcruscottoDomandeBeneficiarioItem.DescrizioneBando != null) && (VcruscottoDomandeBeneficiarioItem.DescrizioneBando.Value == DescrizioneBandoEqualThis.Value))) && ((DataScadenzaBandoEqualThis == null) || ((VcruscottoDomandeBeneficiarioItem.DataScadenzaBando != null) && (VcruscottoDomandeBeneficiarioItem.DataScadenzaBando.Value == DataScadenzaBandoEqualThis.Value))) &&
((CodEnteBandoEqualThis == null) || ((VcruscottoDomandeBeneficiarioItem.CodEnteBando != null) && (VcruscottoDomandeBeneficiarioItem.CodEnteBando.Value == CodEnteBandoEqualThis.Value))) && ((IdProgrammazioneBandoEqualThis == null) || ((VcruscottoDomandeBeneficiarioItem.IdProgrammazioneBando != null) && (VcruscottoDomandeBeneficiarioItem.IdProgrammazioneBando.Value == IdProgrammazioneBandoEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((VcruscottoDomandeBeneficiarioItem.IdProgetto != null) && (VcruscottoDomandeBeneficiarioItem.IdProgetto.Value == IdProgettoEqualThis.Value))) &&
((CodStatoProgettoEqualThis == null) || ((VcruscottoDomandeBeneficiarioItem.CodStatoProgetto != null) && (VcruscottoDomandeBeneficiarioItem.CodStatoProgetto.Value == CodStatoProgettoEqualThis.Value))) && ((StatoProgettoEqualThis == null) || ((VcruscottoDomandeBeneficiarioItem.StatoProgetto != null) && (VcruscottoDomandeBeneficiarioItem.StatoProgetto.Value == StatoProgettoEqualThis.Value))) && ((IdImpresaEqualThis == null) || ((VcruscottoDomandeBeneficiarioItem.IdImpresa != null) && (VcruscottoDomandeBeneficiarioItem.IdImpresa.Value == IdImpresaEqualThis.Value))) &&
((RagioneSocialeImpresaEqualThis == null) || ((VcruscottoDomandeBeneficiarioItem.RagioneSocialeImpresa != null) && (VcruscottoDomandeBeneficiarioItem.RagioneSocialeImpresa.Value == RagioneSocialeImpresaEqualThis.Value))) && ((IdUtenteEqualThis == null) || ((VcruscottoDomandeBeneficiarioItem.IdUtente != null) && (VcruscottoDomandeBeneficiarioItem.IdUtente.Value == IdUtenteEqualThis.Value))) && ((NominativoUtenteImpresaEqualThis == null) || ((VcruscottoDomandeBeneficiarioItem.NominativoUtenteImpresa != null) && (VcruscottoDomandeBeneficiarioItem.NominativoUtenteImpresa.Value == NominativoUtenteImpresaEqualThis.Value))) &&
((CfUtenteImpresaEqualThis == null) || ((VcruscottoDomandeBeneficiarioItem.CfUtenteImpresa != null) && (VcruscottoDomandeBeneficiarioItem.CfUtenteImpresa.Value == CfUtenteImpresaEqualThis.Value))) && ((UtenteAttivoEqualThis == null) || ((VcruscottoDomandeBeneficiarioItem.UtenteAttivo != null) && (VcruscottoDomandeBeneficiarioItem.UtenteAttivo.Value == UtenteAttivoEqualThis.Value))) && ((CodRuoloUtenteImpresaEqualThis == null) || ((VcruscottoDomandeBeneficiarioItem.CodRuoloUtenteImpresa != null) && (VcruscottoDomandeBeneficiarioItem.CodRuoloUtenteImpresa.Value == CodRuoloUtenteImpresaEqualThis.Value))) &&
((RuoloUtenteImpresaEqualThis == null) || ((VcruscottoDomandeBeneficiarioItem.RuoloUtenteImpresa != null) && (VcruscottoDomandeBeneficiarioItem.RuoloUtenteImpresa.Value == RuoloUtenteImpresaEqualThis.Value))) && ((DataInizioUtenteImpresaEqualThis == null) || ((VcruscottoDomandeBeneficiarioItem.DataInizioUtenteImpresa != null) && (VcruscottoDomandeBeneficiarioItem.DataInizioUtenteImpresa.Value == DataInizioUtenteImpresaEqualThis.Value))) && ((DataFineUtenteImpresaEqualThis == null) || ((VcruscottoDomandeBeneficiarioItem.DataFineUtenteImpresa != null) && (VcruscottoDomandeBeneficiarioItem.DataFineUtenteImpresa.Value == DataFineUtenteImpresaEqualThis.Value))) &&
((PotereDiFirmaUtenteImpresaEqualThis == null) || ((VcruscottoDomandeBeneficiarioItem.PotereDiFirmaUtenteImpresa != null) && (VcruscottoDomandeBeneficiarioItem.PotereDiFirmaUtenteImpresa.Value == PotereDiFirmaUtenteImpresaEqualThis.Value))))
                {
                    VcruscottoDomandeBeneficiarioCollectionTemp.Add(VcruscottoDomandeBeneficiarioItem);
                }
            }
            return VcruscottoDomandeBeneficiarioCollectionTemp;
        }



    }
}

namespace SiarDAL
{

    /// <summary>
    /// Summary description for VcruscottoDomandeBeneficiarioDAL
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>


    internal class VcruscottoDomandeBeneficiarioDAL
    {

        //Operazioni

        //getFromDatareader
        public static VcruscottoDomandeBeneficiario GetFromDatareader(DbProvider db)
        {
            VcruscottoDomandeBeneficiario VcruscottoDomandeBeneficiarioObj = new VcruscottoDomandeBeneficiario();
            VcruscottoDomandeBeneficiarioObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
            VcruscottoDomandeBeneficiarioObj.DescrizioneBando = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_BANDO"]);
            VcruscottoDomandeBeneficiarioObj.DataScadenzaBando = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_SCADENZA_BANDO"]);
            VcruscottoDomandeBeneficiarioObj.CodEnteBando = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_ENTE_BANDO"]);
            VcruscottoDomandeBeneficiarioObj.IdProgrammazioneBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGRAMMAZIONE_BANDO"]);
            VcruscottoDomandeBeneficiarioObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
            VcruscottoDomandeBeneficiarioObj.CodStatoProgetto = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_STATO_PROGETTO"]);
            VcruscottoDomandeBeneficiarioObj.StatoProgetto = new SiarLibrary.NullTypes.StringNT(db.DataReader["STATO_PROGETTO"]);
            VcruscottoDomandeBeneficiarioObj.IdImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA"]);
            VcruscottoDomandeBeneficiarioObj.RagioneSocialeImpresa = new SiarLibrary.NullTypes.StringNT(db.DataReader["RAGIONE_SOCIALE_IMPRESA"]);
            VcruscottoDomandeBeneficiarioObj.IdUtente = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_UTENTE"]);
            VcruscottoDomandeBeneficiarioObj.NominativoUtenteImpresa = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOMINATIVO_UTENTE_IMPRESA"]);
            VcruscottoDomandeBeneficiarioObj.CfUtenteImpresa = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_UTENTE_IMPRESA"]);
            VcruscottoDomandeBeneficiarioObj.UtenteAttivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["UTENTE_ATTIVO"]);
            VcruscottoDomandeBeneficiarioObj.CodRuoloUtenteImpresa = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_RUOLO_UTENTE_IMPRESA"]);
            VcruscottoDomandeBeneficiarioObj.RuoloUtenteImpresa = new SiarLibrary.NullTypes.StringNT(db.DataReader["RUOLO_UTENTE_IMPRESA"]);
            VcruscottoDomandeBeneficiarioObj.DataInizioUtenteImpresa = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INIZIO_UTENTE_IMPRESA"]);
            VcruscottoDomandeBeneficiarioObj.DataFineUtenteImpresa = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_FINE_UTENTE_IMPRESA"]);
            VcruscottoDomandeBeneficiarioObj.PotereDiFirmaUtenteImpresa = new SiarLibrary.NullTypes.BoolNT(db.DataReader["POTERE_DI_FIRMA_UTENTE_IMPRESA"]);
            VcruscottoDomandeBeneficiarioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            VcruscottoDomandeBeneficiarioObj.IsDirty = false;
            VcruscottoDomandeBeneficiarioObj.IsPersistent = true;
            return VcruscottoDomandeBeneficiarioObj;
        }

        //Find Select

        public static VcruscottoDomandeBeneficiarioCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneBandoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataScadenzaBandoEqualThis,
SiarLibrary.NullTypes.StringNT CodEnteBandoEqualThis, SiarLibrary.NullTypes.IntNT IdProgrammazioneBandoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis,
SiarLibrary.NullTypes.StringNT CodStatoProgettoEqualThis, SiarLibrary.NullTypes.StringNT StatoProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis,
SiarLibrary.NullTypes.StringNT RagioneSocialeImpresaEqualThis, SiarLibrary.NullTypes.IntNT IdUtenteEqualThis, SiarLibrary.NullTypes.StringNT NominativoUtenteImpresaEqualThis,
SiarLibrary.NullTypes.StringNT CfUtenteImpresaEqualThis, SiarLibrary.NullTypes.BoolNT UtenteAttivoEqualThis, SiarLibrary.NullTypes.StringNT CodRuoloUtenteImpresaEqualThis,
SiarLibrary.NullTypes.StringNT RuoloUtenteImpresaEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInizioUtenteImpresaEqualThis, SiarLibrary.NullTypes.DatetimeNT DataFineUtenteImpresaEqualThis,
SiarLibrary.NullTypes.BoolNT PotereDiFirmaUtenteImpresaEqualThis)

        {

            VcruscottoDomandeBeneficiarioCollection VcruscottoDomandeBeneficiarioCollectionObj = new VcruscottoDomandeBeneficiarioCollection();

            IDbCommand findCmd = db.InitCmd("Zvcruscottodomandebeneficiariofindselect", new string[] {"IdBandoequalthis", "DescrizioneBandoequalthis", "DataScadenzaBandoequalthis",
"CodEnteBandoequalthis", "IdProgrammazioneBandoequalthis", "IdProgettoequalthis",
"CodStatoProgettoequalthis", "StatoProgettoequalthis", "IdImpresaequalthis",
"RagioneSocialeImpresaequalthis", "IdUtenteequalthis", "NominativoUtenteImpresaequalthis",
"CfUtenteImpresaequalthis", "UtenteAttivoequalthis", "CodRuoloUtenteImpresaequalthis",
"RuoloUtenteImpresaequalthis", "DataInizioUtenteImpresaequalthis", "DataFineUtenteImpresaequalthis",
"PotereDiFirmaUtenteImpresaequalthis"}, new string[] {"int", "string", "DateTime",
"string", "int", "int",
"string", "string", "int",
"string", "int", "string",
"string", "bool", "string",
"string", "DateTime", "DateTime",
"bool"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DescrizioneBandoequalthis", DescrizioneBandoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataScadenzaBandoequalthis", DataScadenzaBandoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodEnteBandoequalthis", CodEnteBandoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgrammazioneBandoequalthis", IdProgrammazioneBandoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodStatoProgettoequalthis", CodStatoProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "StatoProgettoequalthis", StatoProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "RagioneSocialeImpresaequalthis", RagioneSocialeImpresaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdUtenteequalthis", IdUtenteEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "NominativoUtenteImpresaequalthis", NominativoUtenteImpresaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CfUtenteImpresaequalthis", CfUtenteImpresaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "UtenteAttivoequalthis", UtenteAttivoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodRuoloUtenteImpresaequalthis", CodRuoloUtenteImpresaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "RuoloUtenteImpresaequalthis", RuoloUtenteImpresaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataInizioUtenteImpresaequalthis", DataInizioUtenteImpresaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataFineUtenteImpresaequalthis", DataFineUtenteImpresaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "PotereDiFirmaUtenteImpresaequalthis", PotereDiFirmaUtenteImpresaEqualThis);
            VcruscottoDomandeBeneficiario VcruscottoDomandeBeneficiarioObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                VcruscottoDomandeBeneficiarioObj = GetFromDatareader(db);
                VcruscottoDomandeBeneficiarioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                VcruscottoDomandeBeneficiarioObj.IsDirty = false;
                VcruscottoDomandeBeneficiarioObj.IsPersistent = true;
                VcruscottoDomandeBeneficiarioCollectionObj.Add(VcruscottoDomandeBeneficiarioObj);
            }
            db.Close();
            return VcruscottoDomandeBeneficiarioCollectionObj;
        }

        //Find FindBandiOperatore

        public static VcruscottoDomandeBeneficiarioCollection FindBandiOperatore(DbProvider db, SiarLibrary.NullTypes.IntNT IdUtenteEqualThis, SiarLibrary.NullTypes.StringNT CodEnteBandoEqualThis, SiarLibrary.NullTypes.IntNT IdProgrammazioneBandoEqualThis,
SiarLibrary.NullTypes.BoolNT UtenteAttivoEqualThis, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis,
SiarLibrary.NullTypes.StringNT CodStatoProgettoEqualThis, SiarLibrary.NullTypes.StringNT StatoProgettoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataScadenzaBandoEqGreaterThanThis,
SiarLibrary.NullTypes.DatetimeNT DataScadenzaBandoEqLessThanThis, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis)

        {

            VcruscottoDomandeBeneficiarioCollection VcruscottoDomandeBeneficiarioCollectionObj = new VcruscottoDomandeBeneficiarioCollection();

            IDbCommand findCmd = db.InitCmd("Zvcruscottodomandebeneficiariofindfindbandioperatore", new string[] {"IdUtenteequalthis", "CodEnteBandoequalthis", "IdProgrammazioneBandoequalthis",
"UtenteAttivoequalthis", "IdBandoequalthis", "IdProgettoequalthis",
"CodStatoProgettoequalthis", "StatoProgettoequalthis", "DataScadenzaBandoeqgreaterthanthis",
"DataScadenzaBandoeqlessthanthis", "IdImpresaequalthis"}, new string[] {"int", "string", "int",
"bool", "int", "int",
"string", "string", "DateTime",
"DateTime", "int"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdUtenteequalthis", IdUtenteEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodEnteBandoequalthis", CodEnteBandoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgrammazioneBandoequalthis", IdProgrammazioneBandoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "UtenteAttivoequalthis", UtenteAttivoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodStatoProgettoequalthis", CodStatoProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "StatoProgettoequalthis", StatoProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataScadenzaBandoeqgreaterthanthis", DataScadenzaBandoEqGreaterThanThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataScadenzaBandoeqlessthanthis", DataScadenzaBandoEqLessThanThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
            VcruscottoDomandeBeneficiario VcruscottoDomandeBeneficiarioObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                VcruscottoDomandeBeneficiarioObj = GetFromDatareader(db);
                VcruscottoDomandeBeneficiarioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                VcruscottoDomandeBeneficiarioObj.IsDirty = false;
                VcruscottoDomandeBeneficiarioObj.IsPersistent = true;
                VcruscottoDomandeBeneficiarioCollectionObj.Add(VcruscottoDomandeBeneficiarioObj);
            }
            db.Close();
            return VcruscottoDomandeBeneficiarioCollectionObj;
        }

    }
}


namespace SiarBLL
{

    /// <summary>
    /// Summary description for VcruscottoDomandeBeneficiarioCollectionProvider:IVcruscottoDomandeBeneficiarioProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class VcruscottoDomandeBeneficiarioCollectionProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di VcruscottoDomandeBeneficiario
        protected VcruscottoDomandeBeneficiarioCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public VcruscottoDomandeBeneficiarioCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new VcruscottoDomandeBeneficiarioCollection();
        }

        //Costruttore 2: popola la collection
        public VcruscottoDomandeBeneficiarioCollectionProvider(IntNT IdutenteEqualThis, StringNT CodentebandoEqualThis, IntNT IdprogrammazionebandoEqualThis,
BoolNT UtenteattivoEqualThis, IntNT IdbandoEqualThis, IntNT IdprogettoEqualThis,
StringNT CodstatoprogettoEqualThis, StringNT StatoprogettoEqualThis, DatetimeNT DatascadenzabandoEqGreaterThanThis,
DatetimeNT DatascadenzabandoEqLessThanThis, IntNT IdimpresaEqualThis)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = FindBandiOperatore(IdutenteEqualThis, CodentebandoEqualThis, IdprogrammazionebandoEqualThis,
UtenteattivoEqualThis, IdbandoEqualThis, IdprogettoEqualThis,
CodstatoprogettoEqualThis, StatoprogettoEqualThis, DatascadenzabandoEqGreaterThanThis,
DatascadenzabandoEqLessThanThis, IdimpresaEqualThis);
        }

        //Costruttore3: ha in input vcruscottodomandebeneficiarioCollectionObj - non popola la collection
        public VcruscottoDomandeBeneficiarioCollectionProvider(VcruscottoDomandeBeneficiarioCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public VcruscottoDomandeBeneficiarioCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new VcruscottoDomandeBeneficiarioCollection();
        }

        //Get e Set
        public VcruscottoDomandeBeneficiarioCollection CollectionObj
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

        //Select: popola la collection
        public VcruscottoDomandeBeneficiarioCollection Select(IntNT IdbandoEqualThis, StringNT DescrizionebandoEqualThis, DatetimeNT DatascadenzabandoEqualThis,
StringNT CodentebandoEqualThis, IntNT IdprogrammazionebandoEqualThis, IntNT IdprogettoEqualThis,
StringNT CodstatoprogettoEqualThis, StringNT StatoprogettoEqualThis, IntNT IdimpresaEqualThis,
StringNT RagionesocialeimpresaEqualThis, IntNT IdutenteEqualThis, StringNT NominativoutenteimpresaEqualThis,
StringNT CfutenteimpresaEqualThis, BoolNT UtenteattivoEqualThis, StringNT CodruoloutenteimpresaEqualThis,
StringNT RuoloutenteimpresaEqualThis, DatetimeNT DatainizioutenteimpresaEqualThis, DatetimeNT DatafineutenteimpresaEqualThis,
BoolNT PoteredifirmautenteimpresaEqualThis)
        {
            VcruscottoDomandeBeneficiarioCollection VcruscottoDomandeBeneficiarioCollectionTemp = VcruscottoDomandeBeneficiarioDAL.Select(_dbProviderObj, IdbandoEqualThis, DescrizionebandoEqualThis, DatascadenzabandoEqualThis,
CodentebandoEqualThis, IdprogrammazionebandoEqualThis, IdprogettoEqualThis,
CodstatoprogettoEqualThis, StatoprogettoEqualThis, IdimpresaEqualThis,
RagionesocialeimpresaEqualThis, IdutenteEqualThis, NominativoutenteimpresaEqualThis,
CfutenteimpresaEqualThis, UtenteattivoEqualThis, CodruoloutenteimpresaEqualThis,
RuoloutenteimpresaEqualThis, DatainizioutenteimpresaEqualThis, DatafineutenteimpresaEqualThis,
PoteredifirmautenteimpresaEqualThis);
            return VcruscottoDomandeBeneficiarioCollectionTemp;
        }

        //FindBandiOperatore: popola la collection
        public VcruscottoDomandeBeneficiarioCollection FindBandiOperatore(IntNT IdutenteEqualThis, StringNT CodentebandoEqualThis, IntNT IdprogrammazionebandoEqualThis,
BoolNT UtenteattivoEqualThis, IntNT IdbandoEqualThis, IntNT IdprogettoEqualThis,
StringNT CodstatoprogettoEqualThis, StringNT StatoprogettoEqualThis, DatetimeNT DatascadenzabandoEqGreaterThanThis,
DatetimeNT DatascadenzabandoEqLessThanThis, IntNT IdimpresaEqualThis)
        {
            VcruscottoDomandeBeneficiarioCollection VcruscottoDomandeBeneficiarioCollectionTemp = VcruscottoDomandeBeneficiarioDAL.FindBandiOperatore(_dbProviderObj, IdutenteEqualThis, CodentebandoEqualThis, IdprogrammazionebandoEqualThis,
UtenteattivoEqualThis, IdbandoEqualThis, IdprogettoEqualThis,
CodstatoprogettoEqualThis, StatoprogettoEqualThis, DatascadenzabandoEqGreaterThanThis,
DatascadenzabandoEqLessThanThis, IdimpresaEqualThis);
            return VcruscottoDomandeBeneficiarioCollectionTemp;
        }


    }
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<VCRUSCOTTO_DOMANDE_BENEFICIARIO>
  <ViewName>VCRUSCOTTO_DOMANDE_BENEFICIARIO</ViewName>
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
    <FindBandiOperatore OrderBy="ORDER BY DATA_SCADENZA_BANDO ASC, ID_BANDO ASC, ID_PROGETTO ASC">
      <ID_UTENTE>Equal</ID_UTENTE>
      <COD_ENTE_BANDO>Equal</COD_ENTE_BANDO>
      <ID_PROGRAMMAZIONE_BANDO>Equal</ID_PROGRAMMAZIONE_BANDO>
      <UTENTE_ATTIVO>Equal</UTENTE_ATTIVO>
      <ID_BANDO>Equal</ID_BANDO>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <COD_STATO_PROGETTO>Equal</COD_STATO_PROGETTO>
      <STATO_PROGETTO>Equal</STATO_PROGETTO>
      <DATA_SCADENZA_BANDO>EqGreaterThan</DATA_SCADENZA_BANDO>
      <DATA_SCADENZA_BANDO>EqLessThan</DATA_SCADENZA_BANDO>
      <ID_IMPRESA>Equal</ID_IMPRESA>
    </FindBandiOperatore>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</VCRUSCOTTO_DOMANDE_BENEFICIARIO>
*/
