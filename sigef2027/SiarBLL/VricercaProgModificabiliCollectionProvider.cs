using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

    /// <summary>
    /// Summary description for VricercaProgModificabili
    /// Class Autogenerata
    /// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
    /// con delle partial class contenenti i metodi aggiunti, in questo modo 
    /// non verranno sovrascritti quando si rigenera la classe 
    /// </summary>

    [Serializable]
    [System.Xml.Serialization.XmlType(Namespace = "")]

    public partial class VricercaProgModificabili : BaseObject
    {

        //Definizione dei campi 'base'
        private NullTypes.IntNT _IdBando;
        private NullTypes.StringNT _DescrizioneBando;
        private NullTypes.StringNT _CodEnteBando;
        private NullTypes.StringNT _EnteBando;
        private NullTypes.IntNT _IdRup;
        private NullTypes.StringNT _Rup;
        private NullTypes.StringNT _CfRup;
        private NullTypes.DatetimeNT _DataAperturaBando;
        private NullTypes.DatetimeNT _DataScadenzaBando;
        private NullTypes.StringNT _CodStatoBando;
        private NullTypes.StringNT _StatoBando;
        private NullTypes.StringNT _SegnaturaBando;
        private NullTypes.IntNT _IdProgetto;
        private NullTypes.StringNT _CodStatoProgetto;
        private NullTypes.StringNT _StatoProgetto;
        private NullTypes.StringNT _SegnaturaProgetto;
        private NullTypes.IntNT _IdImpresa;
        private NullTypes.StringNT _Impresa;
        private NullTypes.StringNT _CfImpresa;
        private NullTypes.StringNT _CuaaImpresa;
        private NullTypes.IntNT _IdIstruttoreProgetto;
        private NullTypes.StringNT _IstruttoreProgetto;


        //Costruttore
        public VricercaProgModificabili()
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
        /// Corrisponde al campo:ENTE_BANDO
        /// Tipo sul db:VARCHAR(255)
        /// </summary>
        public NullTypes.StringNT EnteBando
        {
            get { return _EnteBando; }
            set
            {
                if (EnteBando != value)
                {
                    _EnteBando = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_RUP
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdRup
        {
            get { return _IdRup; }
            set
            {
                if (IdRup != value)
                {
                    _IdRup = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:RUP
        /// Tipo sul db:VARCHAR(511)
        /// </summary>
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

        /// <summary>
        /// Corrisponde al campo:CF_RUP
        /// Tipo sul db:VARCHAR(16)
        /// </summary>
        public NullTypes.StringNT CfRup
        {
            get { return _CfRup; }
            set
            {
                if (CfRup != value)
                {
                    _CfRup = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_APERTURA_BANDO
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataAperturaBando
        {
            get { return _DataAperturaBando; }
            set
            {
                if (DataAperturaBando != value)
                {
                    _DataAperturaBando = value;
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
        /// Corrisponde al campo:COD_STATO_BANDO
        /// Tipo sul db:CHAR(1)
        /// </summary>
        public NullTypes.StringNT CodStatoBando
        {
            get { return _CodStatoBando; }
            set
            {
                if (CodStatoBando != value)
                {
                    _CodStatoBando = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:STATO_BANDO
        /// Tipo sul db:VARCHAR(50)
        /// </summary>
        public NullTypes.StringNT StatoBando
        {
            get { return _StatoBando; }
            set
            {
                if (StatoBando != value)
                {
                    _StatoBando = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:SEGNATURA_BANDO
        /// Tipo sul db:VARCHAR(100)
        /// </summary>
        public NullTypes.StringNT SegnaturaBando
        {
            get { return _SegnaturaBando; }
            set
            {
                if (SegnaturaBando != value)
                {
                    _SegnaturaBando = value;
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
        /// Corrisponde al campo:SEGNATURA_PROGETTO
        /// Tipo sul db:VARCHAR(100)
        /// </summary>
        public NullTypes.StringNT SegnaturaProgetto
        {
            get { return _SegnaturaProgetto; }
            set
            {
                if (SegnaturaProgetto != value)
                {
                    _SegnaturaProgetto = value;
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
        /// Corrisponde al campo:IMPRESA
        /// Tipo sul db:VARCHAR(255)
        /// </summary>
        public NullTypes.StringNT Impresa
        {
            get { return _Impresa; }
            set
            {
                if (Impresa != value)
                {
                    _Impresa = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:CF_IMPRESA
        /// Tipo sul db:VARCHAR(16)
        /// </summary>
        public NullTypes.StringNT CfImpresa
        {
            get { return _CfImpresa; }
            set
            {
                if (CfImpresa != value)
                {
                    _CfImpresa = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:CUAA_IMPRESA
        /// Tipo sul db:VARCHAR(16)
        /// </summary>
        public NullTypes.StringNT CuaaImpresa
        {
            get { return _CuaaImpresa; }
            set
            {
                if (CuaaImpresa != value)
                {
                    _CuaaImpresa = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_ISTRUTTORE_PROGETTO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdIstruttoreProgetto
        {
            get { return _IdIstruttoreProgetto; }
            set
            {
                if (IdIstruttoreProgetto != value)
                {
                    _IdIstruttoreProgetto = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ISTRUTTORE_PROGETTO
        /// Tipo sul db:VARCHAR(511)
        /// </summary>
        public NullTypes.StringNT IstruttoreProgetto
        {
            get { return _IstruttoreProgetto; }
            set
            {
                if (IstruttoreProgetto != value)
                {
                    _IstruttoreProgetto = value;
                    SetDirtyFlag();
                }
            }
        }




    }
}

namespace SiarLibrary
{

    /// <summary>
    /// Summary description for VricercaProgModificabiliCollection
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class VricercaProgModificabiliCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
        private VricercaProgModificabiliCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((VricercaProgModificabili)info.GetValue(i.ToString(), typeof(VricercaProgModificabili)));
            }
        }

        //Costruttore
        public VricercaProgModificabiliCollection()
        {
            this.ItemType = typeof(VricercaProgModificabili);
        }

        //Get e Set
        public new VricercaProgModificabili this[int index]
        {
            get { return (VricercaProgModificabili)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new VricercaProgModificabiliCollection GetChanges()
        {
            return (VricercaProgModificabiliCollection)base.GetChanges();
        }

        //Add
        public int Add(VricercaProgModificabili VricercaProgModificabiliObj)
        {
            return base.Add(VricercaProgModificabiliObj);
        }

        //AddCollection
        public void AddCollection(VricercaProgModificabiliCollection VricercaProgModificabiliCollectionObj)
        {
            foreach (VricercaProgModificabili VricercaProgModificabiliObj in VricercaProgModificabiliCollectionObj)
                this.Add(VricercaProgModificabiliObj);
        }

        //Insert
        public void Insert(int index, VricercaProgModificabili VricercaProgModificabiliObj)
        {
            base.Insert(index, VricercaProgModificabiliObj);
        }

        //filter: effettua una ricerca all'interno della collection
        // se il parametro di ricerca è null, prende tutto,
        // anche i record che hanno quel campo null
        // altrimenti scarta i record che hanno quel campo null ...
        // ...e confronta gli altri
        public VricercaProgModificabiliCollection SubSelect(NullTypes.IntNT IdBandoEqualThis, NullTypes.StringNT DescrizioneBandoEqualThis, NullTypes.StringNT CodEnteBandoEqualThis,
NullTypes.StringNT EnteBandoEqualThis, NullTypes.IntNT IdRupEqualThis, NullTypes.StringNT RupEqualThis,
NullTypes.StringNT CfRupEqualThis, NullTypes.DatetimeNT DataAperturaBandoEqualThis, NullTypes.DatetimeNT DataScadenzaBandoEqualThis,
NullTypes.StringNT CodStatoBandoEqualThis, NullTypes.StringNT StatoBandoEqualThis, NullTypes.StringNT SegnaturaBandoEqualThis,
NullTypes.IntNT IdProgettoEqualThis, NullTypes.StringNT CodStatoProgettoEqualThis, NullTypes.StringNT StatoProgettoEqualThis,
NullTypes.StringNT SegnaturaProgettoEqualThis, NullTypes.IntNT IdImpresaEqualThis, NullTypes.StringNT ImpresaEqualThis,
NullTypes.StringNT CfImpresaEqualThis, NullTypes.StringNT CuaaImpresaEqualThis, NullTypes.IntNT IdIstruttoreProgettoEqualThis,
NullTypes.StringNT IstruttoreProgettoEqualThis)
        {
            VricercaProgModificabiliCollection VricercaProgModificabiliCollectionTemp = new VricercaProgModificabiliCollection();
            foreach (VricercaProgModificabili VricercaProgModificabiliItem in this)
            {
                if (((IdBandoEqualThis == null) || ((VricercaProgModificabiliItem.IdBando != null) && (VricercaProgModificabiliItem.IdBando.Value == IdBandoEqualThis.Value))) && ((DescrizioneBandoEqualThis == null) || ((VricercaProgModificabiliItem.DescrizioneBando != null) && (VricercaProgModificabiliItem.DescrizioneBando.Value == DescrizioneBandoEqualThis.Value))) && ((CodEnteBandoEqualThis == null) || ((VricercaProgModificabiliItem.CodEnteBando != null) && (VricercaProgModificabiliItem.CodEnteBando.Value == CodEnteBandoEqualThis.Value))) &&
((EnteBandoEqualThis == null) || ((VricercaProgModificabiliItem.EnteBando != null) && (VricercaProgModificabiliItem.EnteBando.Value == EnteBandoEqualThis.Value))) && ((IdRupEqualThis == null) || ((VricercaProgModificabiliItem.IdRup != null) && (VricercaProgModificabiliItem.IdRup.Value == IdRupEqualThis.Value))) && ((RupEqualThis == null) || ((VricercaProgModificabiliItem.Rup != null) && (VricercaProgModificabiliItem.Rup.Value == RupEqualThis.Value))) &&
((CfRupEqualThis == null) || ((VricercaProgModificabiliItem.CfRup != null) && (VricercaProgModificabiliItem.CfRup.Value == CfRupEqualThis.Value))) && ((DataAperturaBandoEqualThis == null) || ((VricercaProgModificabiliItem.DataAperturaBando != null) && (VricercaProgModificabiliItem.DataAperturaBando.Value == DataAperturaBandoEqualThis.Value))) && ((DataScadenzaBandoEqualThis == null) || ((VricercaProgModificabiliItem.DataScadenzaBando != null) && (VricercaProgModificabiliItem.DataScadenzaBando.Value == DataScadenzaBandoEqualThis.Value))) &&
((CodStatoBandoEqualThis == null) || ((VricercaProgModificabiliItem.CodStatoBando != null) && (VricercaProgModificabiliItem.CodStatoBando.Value == CodStatoBandoEqualThis.Value))) && ((StatoBandoEqualThis == null) || ((VricercaProgModificabiliItem.StatoBando != null) && (VricercaProgModificabiliItem.StatoBando.Value == StatoBandoEqualThis.Value))) && ((SegnaturaBandoEqualThis == null) || ((VricercaProgModificabiliItem.SegnaturaBando != null) && (VricercaProgModificabiliItem.SegnaturaBando.Value == SegnaturaBandoEqualThis.Value))) &&
((IdProgettoEqualThis == null) || ((VricercaProgModificabiliItem.IdProgetto != null) && (VricercaProgModificabiliItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((CodStatoProgettoEqualThis == null) || ((VricercaProgModificabiliItem.CodStatoProgetto != null) && (VricercaProgModificabiliItem.CodStatoProgetto.Value == CodStatoProgettoEqualThis.Value))) && ((StatoProgettoEqualThis == null) || ((VricercaProgModificabiliItem.StatoProgetto != null) && (VricercaProgModificabiliItem.StatoProgetto.Value == StatoProgettoEqualThis.Value))) &&
((SegnaturaProgettoEqualThis == null) || ((VricercaProgModificabiliItem.SegnaturaProgetto != null) && (VricercaProgModificabiliItem.SegnaturaProgetto.Value == SegnaturaProgettoEqualThis.Value))) && ((IdImpresaEqualThis == null) || ((VricercaProgModificabiliItem.IdImpresa != null) && (VricercaProgModificabiliItem.IdImpresa.Value == IdImpresaEqualThis.Value))) && ((ImpresaEqualThis == null) || ((VricercaProgModificabiliItem.Impresa != null) && (VricercaProgModificabiliItem.Impresa.Value == ImpresaEqualThis.Value))) &&
((CfImpresaEqualThis == null) || ((VricercaProgModificabiliItem.CfImpresa != null) && (VricercaProgModificabiliItem.CfImpresa.Value == CfImpresaEqualThis.Value))) && ((CuaaImpresaEqualThis == null) || ((VricercaProgModificabiliItem.CuaaImpresa != null) && (VricercaProgModificabiliItem.CuaaImpresa.Value == CuaaImpresaEqualThis.Value))) && ((IdIstruttoreProgettoEqualThis == null) || ((VricercaProgModificabiliItem.IdIstruttoreProgetto != null) && (VricercaProgModificabiliItem.IdIstruttoreProgetto.Value == IdIstruttoreProgettoEqualThis.Value))) &&
((IstruttoreProgettoEqualThis == null) || ((VricercaProgModificabiliItem.IstruttoreProgetto != null) && (VricercaProgModificabiliItem.IstruttoreProgetto.Value == IstruttoreProgettoEqualThis.Value))))
                {
                    VricercaProgModificabiliCollectionTemp.Add(VricercaProgModificabiliItem);
                }
            }
            return VricercaProgModificabiliCollectionTemp;
        }



    }
}

namespace SiarDAL
{

    /// <summary>
    /// Summary description for VricercaProgModificabiliDAL
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>


    internal class VricercaProgModificabiliDAL
    {

        //Operazioni

        //getFromDatareader
        public static VricercaProgModificabili GetFromDatareader(DbProvider db)
        {
            VricercaProgModificabili VricercaProgModificabiliObj = new VricercaProgModificabili();
            VricercaProgModificabiliObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
            VricercaProgModificabiliObj.DescrizioneBando = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_BANDO"]);
            VricercaProgModificabiliObj.CodEnteBando = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_ENTE_BANDO"]);
            VricercaProgModificabiliObj.EnteBando = new SiarLibrary.NullTypes.StringNT(db.DataReader["ENTE_BANDO"]);
            VricercaProgModificabiliObj.IdRup = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_RUP"]);
            VricercaProgModificabiliObj.Rup = new SiarLibrary.NullTypes.StringNT(db.DataReader["RUP"]);
            VricercaProgModificabiliObj.CfRup = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_RUP"]);
            VricercaProgModificabiliObj.DataAperturaBando = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_APERTURA_BANDO"]);
            VricercaProgModificabiliObj.DataScadenzaBando = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_SCADENZA_BANDO"]);
            VricercaProgModificabiliObj.CodStatoBando = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_STATO_BANDO"]);
            VricercaProgModificabiliObj.StatoBando = new SiarLibrary.NullTypes.StringNT(db.DataReader["STATO_BANDO"]);
            VricercaProgModificabiliObj.SegnaturaBando = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_BANDO"]);
            VricercaProgModificabiliObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
            VricercaProgModificabiliObj.CodStatoProgetto = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_STATO_PROGETTO"]);
            VricercaProgModificabiliObj.StatoProgetto = new SiarLibrary.NullTypes.StringNT(db.DataReader["STATO_PROGETTO"]);
            VricercaProgModificabiliObj.SegnaturaProgetto = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_PROGETTO"]);
            VricercaProgModificabiliObj.IdImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA"]);
            VricercaProgModificabiliObj.Impresa = new SiarLibrary.NullTypes.StringNT(db.DataReader["IMPRESA"]);
            VricercaProgModificabiliObj.CfImpresa = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_IMPRESA"]);
            VricercaProgModificabiliObj.CuaaImpresa = new SiarLibrary.NullTypes.StringNT(db.DataReader["CUAA_IMPRESA"]);
            VricercaProgModificabiliObj.IdIstruttoreProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ISTRUTTORE_PROGETTO"]);
            VricercaProgModificabiliObj.IstruttoreProgetto = new SiarLibrary.NullTypes.StringNT(db.DataReader["ISTRUTTORE_PROGETTO"]);
            VricercaProgModificabiliObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            VricercaProgModificabiliObj.IsDirty = false;
            VricercaProgModificabiliObj.IsPersistent = true;
            return VricercaProgModificabiliObj;
        }

        //Find Select

        public static VricercaProgModificabiliCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneBandoEqualThis, SiarLibrary.NullTypes.StringNT CodEnteBandoEqualThis,
SiarLibrary.NullTypes.StringNT EnteBandoEqualThis, SiarLibrary.NullTypes.IntNT IdRupEqualThis, SiarLibrary.NullTypes.StringNT RupEqualThis,
SiarLibrary.NullTypes.StringNT CfRupEqualThis, SiarLibrary.NullTypes.DatetimeNT DataAperturaBandoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataScadenzaBandoEqualThis,
SiarLibrary.NullTypes.StringNT CodStatoBandoEqualThis, SiarLibrary.NullTypes.StringNT StatoBandoEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaBandoEqualThis,
SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.StringNT CodStatoProgettoEqualThis, SiarLibrary.NullTypes.StringNT StatoProgettoEqualThis,
SiarLibrary.NullTypes.StringNT SegnaturaProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, SiarLibrary.NullTypes.StringNT ImpresaEqualThis,
SiarLibrary.NullTypes.StringNT CfImpresaEqualThis, SiarLibrary.NullTypes.StringNT CuaaImpresaEqualThis, SiarLibrary.NullTypes.IntNT IdIstruttoreProgettoEqualThis,
SiarLibrary.NullTypes.StringNT IstruttoreProgettoEqualThis)

        {

            VricercaProgModificabiliCollection VricercaProgModificabiliCollectionObj = new VricercaProgModificabiliCollection();

            IDbCommand findCmd = db.InitCmd("Zvricercaprogmodificabilifindselect", new string[] {"IdBandoequalthis", "DescrizioneBandoequalthis", "CodEnteBandoequalthis",
"EnteBandoequalthis", "IdRupequalthis", "Rupequalthis",
"CfRupequalthis", "DataAperturaBandoequalthis", "DataScadenzaBandoequalthis",
"CodStatoBandoequalthis", "StatoBandoequalthis", "SegnaturaBandoequalthis",
"IdProgettoequalthis", "CodStatoProgettoequalthis", "StatoProgettoequalthis",
"SegnaturaProgettoequalthis", "IdImpresaequalthis", "Impresaequalthis",
"CfImpresaequalthis", "CuaaImpresaequalthis", "IdIstruttoreProgettoequalthis",
"IstruttoreProgettoequalthis"}, new string[] {"int", "string", "string",
"string", "int", "string",
"string", "DateTime", "DateTime",
"string", "string", "string",
"int", "string", "string",
"string", "int", "string",
"string", "string", "int",
"string"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DescrizioneBandoequalthis", DescrizioneBandoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodEnteBandoequalthis", CodEnteBandoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "EnteBandoequalthis", EnteBandoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdRupequalthis", IdRupEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Rupequalthis", RupEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CfRupequalthis", CfRupEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataAperturaBandoequalthis", DataAperturaBandoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataScadenzaBandoequalthis", DataScadenzaBandoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodStatoBandoequalthis", CodStatoBandoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "StatoBandoequalthis", StatoBandoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "SegnaturaBandoequalthis", SegnaturaBandoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodStatoProgettoequalthis", CodStatoProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "StatoProgettoequalthis", StatoProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "SegnaturaProgettoequalthis", SegnaturaProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Impresaequalthis", ImpresaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CfImpresaequalthis", CfImpresaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CuaaImpresaequalthis", CuaaImpresaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdIstruttoreProgettoequalthis", IdIstruttoreProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IstruttoreProgettoequalthis", IstruttoreProgettoEqualThis);
            VricercaProgModificabili VricercaProgModificabiliObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                VricercaProgModificabiliObj = GetFromDatareader(db);
                VricercaProgModificabiliObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                VricercaProgModificabiliObj.IsDirty = false;
                VricercaProgModificabiliObj.IsPersistent = true;
                VricercaProgModificabiliCollectionObj.Add(VricercaProgModificabiliObj);
            }
            db.Close();
            return VricercaProgModificabiliCollectionObj;
        }

        //Find FindGrande

        public static VricercaProgModificabiliCollection FindGrande(DbProvider db, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.StringNT CodEnteBandoEqualThis, SiarLibrary.NullTypes.StringNT EnteBandoEqualThis,
SiarLibrary.NullTypes.IntNT IdRupEqualThis, SiarLibrary.NullTypes.StringNT RupEqualThis, SiarLibrary.NullTypes.StringNT StatoBandoEqualThis,
SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.StringNT CodStatoProgettoEqualThis, SiarLibrary.NullTypes.StringNT StatoProgettoEqualThis,
SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, SiarLibrary.NullTypes.StringNT ImpresaEqualThis, SiarLibrary.NullTypes.IntNT IdIstruttoreProgettoEqualThis,
SiarLibrary.NullTypes.StringNT IstruttoreProgettoEqualThis)

        {

            VricercaProgModificabiliCollection VricercaProgModificabiliCollectionObj = new VricercaProgModificabiliCollection();

            IDbCommand findCmd = db.InitCmd("Zvricercaprogmodificabilifindfindgrande", new string[] {"IdBandoequalthis", "CodEnteBandoequalthis", "EnteBandoequalthis",
"IdRupequalthis", "Rupequalthis", "StatoBandoequalthis",
"IdProgettoequalthis", "CodStatoProgettoequalthis", "StatoProgettoequalthis",
"IdImpresaequalthis", "Impresaequalthis", "IdIstruttoreProgettoequalthis",
"IstruttoreProgettoequalthis"}, new string[] {"int", "string", "string",
"int", "string", "string",
"int", "string", "string",
"int", "string", "int",
"string"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodEnteBandoequalthis", CodEnteBandoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "EnteBandoequalthis", EnteBandoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdRupequalthis", IdRupEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Rupequalthis", RupEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "StatoBandoequalthis", StatoBandoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodStatoProgettoequalthis", CodStatoProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "StatoProgettoequalthis", StatoProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Impresaequalthis", ImpresaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdIstruttoreProgettoequalthis", IdIstruttoreProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IstruttoreProgettoequalthis", IstruttoreProgettoEqualThis);
            VricercaProgModificabili VricercaProgModificabiliObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                VricercaProgModificabiliObj = GetFromDatareader(db);
                VricercaProgModificabiliObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                VricercaProgModificabiliObj.IsDirty = false;
                VricercaProgModificabiliObj.IsPersistent = true;
                VricercaProgModificabiliCollectionObj.Add(VricercaProgModificabiliObj);
            }
            db.Close();
            return VricercaProgModificabiliCollectionObj;
        }

    }
}


namespace SiarBLL
{

    /// <summary>
    /// Summary description for VricercaProgModificabiliCollectionProvider:IVricercaProgModificabiliProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class VricercaProgModificabiliCollectionProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di VricercaProgModificabili
        protected VricercaProgModificabiliCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public VricercaProgModificabiliCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new VricercaProgModificabiliCollection();
        }

        //Costruttore 2: popola la collection
        public VricercaProgModificabiliCollectionProvider(IntNT IdbandoEqualThis, StringNT CodentebandoEqualThis, StringNT EntebandoEqualThis,
IntNT IdrupEqualThis, StringNT RupEqualThis, StringNT StatobandoEqualThis,
IntNT IdprogettoEqualThis, StringNT CodstatoprogettoEqualThis, StringNT StatoprogettoEqualThis,
IntNT IdimpresaEqualThis, StringNT ImpresaEqualThis, IntNT IdistruttoreprogettoEqualThis,
StringNT IstruttoreprogettoEqualThis)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = FindGrande(IdbandoEqualThis, CodentebandoEqualThis, EntebandoEqualThis,
IdrupEqualThis, RupEqualThis, StatobandoEqualThis,
IdprogettoEqualThis, CodstatoprogettoEqualThis, StatoprogettoEqualThis,
IdimpresaEqualThis, ImpresaEqualThis, IdistruttoreprogettoEqualThis,
IstruttoreprogettoEqualThis);
        }

        //Costruttore3: ha in input vricercaprogmodificabiliCollectionObj - non popola la collection
        public VricercaProgModificabiliCollectionProvider(VricercaProgModificabiliCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public VricercaProgModificabiliCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new VricercaProgModificabiliCollection();
        }

        //Get e Set
        public VricercaProgModificabiliCollection CollectionObj
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
        public VricercaProgModificabiliCollection Select(IntNT IdbandoEqualThis, StringNT DescrizionebandoEqualThis, StringNT CodentebandoEqualThis,
StringNT EntebandoEqualThis, IntNT IdrupEqualThis, StringNT RupEqualThis,
StringNT CfrupEqualThis, DatetimeNT DataaperturabandoEqualThis, DatetimeNT DatascadenzabandoEqualThis,
StringNT CodstatobandoEqualThis, StringNT StatobandoEqualThis, StringNT SegnaturabandoEqualThis,
IntNT IdprogettoEqualThis, StringNT CodstatoprogettoEqualThis, StringNT StatoprogettoEqualThis,
StringNT SegnaturaprogettoEqualThis, IntNT IdimpresaEqualThis, StringNT ImpresaEqualThis,
StringNT CfimpresaEqualThis, StringNT CuaaimpresaEqualThis, IntNT IdistruttoreprogettoEqualThis,
StringNT IstruttoreprogettoEqualThis)
        {
            VricercaProgModificabiliCollection VricercaProgModificabiliCollectionTemp = VricercaProgModificabiliDAL.Select(_dbProviderObj, IdbandoEqualThis, DescrizionebandoEqualThis, CodentebandoEqualThis,
EntebandoEqualThis, IdrupEqualThis, RupEqualThis,
CfrupEqualThis, DataaperturabandoEqualThis, DatascadenzabandoEqualThis,
CodstatobandoEqualThis, StatobandoEqualThis, SegnaturabandoEqualThis,
IdprogettoEqualThis, CodstatoprogettoEqualThis, StatoprogettoEqualThis,
SegnaturaprogettoEqualThis, IdimpresaEqualThis, ImpresaEqualThis,
CfimpresaEqualThis, CuaaimpresaEqualThis, IdistruttoreprogettoEqualThis,
IstruttoreprogettoEqualThis);
            return VricercaProgModificabiliCollectionTemp;
        }

        //FindGrande: popola la collection
        public VricercaProgModificabiliCollection FindGrande(IntNT IdbandoEqualThis, StringNT CodentebandoEqualThis, StringNT EntebandoEqualThis,
IntNT IdrupEqualThis, StringNT RupEqualThis, StringNT StatobandoEqualThis,
IntNT IdprogettoEqualThis, StringNT CodstatoprogettoEqualThis, StringNT StatoprogettoEqualThis,
IntNT IdimpresaEqualThis, StringNT ImpresaEqualThis, IntNT IdistruttoreprogettoEqualThis,
StringNT IstruttoreprogettoEqualThis)
        {
            VricercaProgModificabiliCollection VricercaProgModificabiliCollectionTemp = VricercaProgModificabiliDAL.FindGrande(_dbProviderObj, IdbandoEqualThis, CodentebandoEqualThis, EntebandoEqualThis,
IdrupEqualThis, RupEqualThis, StatobandoEqualThis,
IdprogettoEqualThis, CodstatoprogettoEqualThis, StatoprogettoEqualThis,
IdimpresaEqualThis, ImpresaEqualThis, IdistruttoreprogettoEqualThis,
IstruttoreprogettoEqualThis);
            return VricercaProgModificabiliCollectionTemp;
        }


    }
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<VRICERCA_PROG_MODIFICABILI>
  <ViewName>VRICERCA_PROG_MODIFICABILI</ViewName>
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
    <FindGrande OrderBy="ORDER BY COD_ENTE_BANDO ASC, DATA_SCADENZA_BANDO ASC, ID_PROGETTO ASC">
      <ID_BANDO>Equal</ID_BANDO>
      <COD_ENTE_BANDO>Equal</COD_ENTE_BANDO>
      <ENTE_BANDO>Equal</ENTE_BANDO>
      <ID_RUP>Equal</ID_RUP>
      <RUP>Equal</RUP>
      <STATO_BANDO>Equal</STATO_BANDO>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <COD_STATO_PROGETTO>Equal</COD_STATO_PROGETTO>
      <STATO_PROGETTO>Equal</STATO_PROGETTO>
      <ID_IMPRESA>Equal</ID_IMPRESA>
      <IMPRESA>Equal</IMPRESA>
      <ID_ISTRUTTORE_PROGETTO>Equal</ID_ISTRUTTORE_PROGETTO>
      <ISTRUTTORE_PROGETTO>Equal</ISTRUTTORE_PROGETTO>
    </FindGrande>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</VRICERCA_PROG_MODIFICABILI>
*/
