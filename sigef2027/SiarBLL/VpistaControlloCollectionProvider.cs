using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

    /// <summary>
    /// Summary description for VpistaControllo
    /// Class Autogenerata
    /// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
    /// con delle partial class contenenti i metodi aggiunti, in questo modo 
    /// non verranno sovrascritti quando si rigenera la classe 
    /// </summary>

    [Serializable]
    [System.Xml.Serialization.XmlType(Namespace = "")]

    public partial class VpistaControllo : BaseObject
    {

        //Definizione dei campi 'base'
        private NullTypes.IntNT _Idbando;
        private NullTypes.StringNT _Descrizionebando;
        private NullTypes.IntNT _Idprogetto;
        private NullTypes.StringNT _Assecod;
        private NullTypes.StringNT _Assedescr;
        private NullTypes.StringNT _Azionecod;
        private NullTypes.StringNT _Azionedescr;
        private NullTypes.StringNT _Interventocod;
        private NullTypes.StringNT _Interventodescr;
        private NullTypes.StringNT _Ragionesociale;
        private NullTypes.StringNT _Partitaivacf;
        private NullTypes.StringNT _Tipoprocedura;
        private NullTypes.StringNT _CupNatura;
        private NullTypes.StringNT _Codicetitolaritaregia;
        private NullTypes.DatetimeNT _Datapubblicazionebando;
        private NullTypes.IntNT _Attopubblicazionebando;
        private NullTypes.IntNT _Attopubblicazionebandonum;
        private NullTypes.DatetimeNT _Attopubblicazionebandodata;
        private NullTypes.StringNT _Attopubblicazionebandoregistro;
        private NullTypes.IntNT _Attopubblicazionebandobur;
        private NullTypes.DatetimeNT _Attopubblicazionebandoburdata;
        private NullTypes.StringNT _Segnaturadomanda;
        private NullTypes.DatetimeNT _Domandadata;
        private NullTypes.StringNT _Segnaturavalutazionecomitato;
        private NullTypes.DatetimeNT _Datavalutazionecomitato;
        private NullTypes.StringNT _Segnaturavalutazionevariantecomitato;
        private NullTypes.DatetimeNT _Datavalutazionevariantecomitato;
        private NullTypes.IntNT _Attodecretograduatoria;
        private NullTypes.IntNT _Attodecretograduatorianum;
        private NullTypes.DatetimeNT _Attodecretograduatoriadata;
        private NullTypes.StringNT _Attodecretograduatoriaregistro;
        private NullTypes.IntNT _Attodecretograduatoriaindividuale;
        private NullTypes.IntNT _Attodecretograduatoriaindividualenum;
        private NullTypes.DatetimeNT _Attodecretograduatoriaindividualedata;
        private NullTypes.StringNT _Attodecretograduatoriaindividualeregistro;
        private NullTypes.StringNT _Segnaturagraduatoria;
        private NullTypes.DatetimeNT _Datagraduatoria;
        private NullTypes.StringNT _Parereadg;
        private NullTypes.StringNT _Dataparereadg;


        //Costruttore
        public VpistaControllo()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //Get e Set dei campi 'base'
        /// <summary>
        /// Corrisponde al campo:IdBando
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT Idbando
        {
            get { return _Idbando; }
            set
            {
                if (Idbando != value)
                {
                    _Idbando = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DescrizioneBando
        /// Tipo sul db:VARCHAR(2000)
        /// </summary>
        public NullTypes.StringNT Descrizionebando
        {
            get { return _Descrizionebando; }
            set
            {
                if (Descrizionebando != value)
                {
                    _Descrizionebando = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IdProgetto
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT Idprogetto
        {
            get { return _Idprogetto; }
            set
            {
                if (Idprogetto != value)
                {
                    _Idprogetto = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:AsseCod
        /// Tipo sul db:VARCHAR(20)
        /// </summary>
        public NullTypes.StringNT Assecod
        {
            get { return _Assecod; }
            set
            {
                if (Assecod != value)
                {
                    _Assecod = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:AsseDescr
        /// Tipo sul db:VARCHAR(2000)
        /// </summary>
        public NullTypes.StringNT Assedescr
        {
            get { return _Assedescr; }
            set
            {
                if (Assedescr != value)
                {
                    _Assedescr = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:AzioneCod
        /// Tipo sul db:VARCHAR(20)
        /// </summary>
        public NullTypes.StringNT Azionecod
        {
            get { return _Azionecod; }
            set
            {
                if (Azionecod != value)
                {
                    _Azionecod = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:AzioneDescr
        /// Tipo sul db:VARCHAR(2000)
        /// </summary>
        public NullTypes.StringNT Azionedescr
        {
            get { return _Azionedescr; }
            set
            {
                if (Azionedescr != value)
                {
                    _Azionedescr = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:InterventoCod
        /// Tipo sul db:VARCHAR(20)
        /// </summary>
        public NullTypes.StringNT Interventocod
        {
            get { return _Interventocod; }
            set
            {
                if (Interventocod != value)
                {
                    _Interventocod = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:InterventoDescr
        /// Tipo sul db:VARCHAR(2000)
        /// </summary>
        public NullTypes.StringNT Interventodescr
        {
            get { return _Interventodescr; }
            set
            {
                if (Interventodescr != value)
                {
                    _Interventodescr = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:RagioneSociale
        /// Tipo sul db:VARCHAR(255)
        /// </summary>
        public NullTypes.StringNT Ragionesociale
        {
            get { return _Ragionesociale; }
            set
            {
                if (Ragionesociale != value)
                {
                    _Ragionesociale = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:PartitaIvaCF
        /// Tipo sul db:VARCHAR(16)
        /// </summary>
        public NullTypes.StringNT Partitaivacf
        {
            get { return _Partitaivacf; }
            set
            {
                if (Partitaivacf != value)
                {
                    _Partitaivacf = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:TipoProcedura
        /// Tipo sul db:VARCHAR(255)
        /// </summary>
        public NullTypes.StringNT Tipoprocedura
        {
            get { return _Tipoprocedura; }
            set
            {
                if (Tipoprocedura != value)
                {
                    _Tipoprocedura = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:CUP_NATURA
        /// Tipo sul db:CHAR(2)
        /// </summary>
        public NullTypes.StringNT CupNatura
        {
            get { return _CupNatura; }
            set
            {
                if (CupNatura != value)
                {
                    _CupNatura = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:CodiceTitolaritaRegia
        /// Tipo sul db:VARCHAR(50)
        /// </summary>
        public NullTypes.StringNT Codicetitolaritaregia
        {
            get { return _Codicetitolaritaregia; }
            set
            {
                if (Codicetitolaritaregia != value)
                {
                    _Codicetitolaritaregia = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DataPubblicazioneBando
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT Datapubblicazionebando
        {
            get { return _Datapubblicazionebando; }
            set
            {
                if (Datapubblicazionebando != value)
                {
                    _Datapubblicazionebando = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:AttoPubblicazioneBando
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT Attopubblicazionebando
        {
            get { return _Attopubblicazionebando; }
            set
            {
                if (Attopubblicazionebando != value)
                {
                    _Attopubblicazionebando = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:AttoPubblicazioneBandoNum
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT Attopubblicazionebandonum
        {
            get { return _Attopubblicazionebandonum; }
            set
            {
                if (Attopubblicazionebandonum != value)
                {
                    _Attopubblicazionebandonum = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:AttoPubblicazioneBandoData
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT Attopubblicazionebandodata
        {
            get { return _Attopubblicazionebandodata; }
            set
            {
                if (Attopubblicazionebandodata != value)
                {
                    _Attopubblicazionebandodata = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:AttoPubblicazioneBandoRegistro
        /// Tipo sul db:VARCHAR(10)
        /// </summary>
        public NullTypes.StringNT Attopubblicazionebandoregistro
        {
            get { return _Attopubblicazionebandoregistro; }
            set
            {
                if (Attopubblicazionebandoregistro != value)
                {
                    _Attopubblicazionebandoregistro = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:AttoPubblicazioneBandoBur
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT Attopubblicazionebandobur
        {
            get { return _Attopubblicazionebandobur; }
            set
            {
                if (Attopubblicazionebandobur != value)
                {
                    _Attopubblicazionebandobur = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:AttoPubblicazioneBandoBurData
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT Attopubblicazionebandoburdata
        {
            get { return _Attopubblicazionebandoburdata; }
            set
            {
                if (Attopubblicazionebandoburdata != value)
                {
                    _Attopubblicazionebandoburdata = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:SegnaturaDomanda
        /// Tipo sul db:VARCHAR(100)
        /// </summary>
        public NullTypes.StringNT Segnaturadomanda
        {
            get { return _Segnaturadomanda; }
            set
            {
                if (Segnaturadomanda != value)
                {
                    _Segnaturadomanda = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DomandaData
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT Domandadata
        {
            get { return _Domandadata; }
            set
            {
                if (Domandadata != value)
                {
                    _Domandadata = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:SegnaturaValutazioneComitato
        /// Tipo sul db:VARCHAR(100)
        /// </summary>
        public NullTypes.StringNT Segnaturavalutazionecomitato
        {
            get { return _Segnaturavalutazionecomitato; }
            set
            {
                if (Segnaturavalutazionecomitato != value)
                {
                    _Segnaturavalutazionecomitato = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DataValutazioneComitato
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT Datavalutazionecomitato
        {
            get { return _Datavalutazionecomitato; }
            set
            {
                if (Datavalutazionecomitato != value)
                {
                    _Datavalutazionecomitato = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:SegnaturaValutazioneVarianteComitato
        /// Tipo sul db:VARCHAR(100)
        /// </summary>
        public NullTypes.StringNT Segnaturavalutazionevariantecomitato
        {
            get { return _Segnaturavalutazionevariantecomitato; }
            set
            {
                if (Segnaturavalutazionevariantecomitato != value)
                {
                    _Segnaturavalutazionevariantecomitato = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DataValutazioneVarianteComitato
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT Datavalutazionevariantecomitato
        {
            get { return _Datavalutazionevariantecomitato; }
            set
            {
                if (Datavalutazionevariantecomitato != value)
                {
                    _Datavalutazionevariantecomitato = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:AttoDecretoGraduatoria
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT Attodecretograduatoria
        {
            get { return _Attodecretograduatoria; }
            set
            {
                if (Attodecretograduatoria != value)
                {
                    _Attodecretograduatoria = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:AttoDecretoGraduatoriaNum
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT Attodecretograduatorianum
        {
            get { return _Attodecretograduatorianum; }
            set
            {
                if (Attodecretograduatorianum != value)
                {
                    _Attodecretograduatorianum = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:AttoDecretoGraduatoriaData
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT Attodecretograduatoriadata
        {
            get { return _Attodecretograduatoriadata; }
            set
            {
                if (Attodecretograduatoriadata != value)
                {
                    _Attodecretograduatoriadata = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:AttoDecretoGraduatoriaRegistro
        /// Tipo sul db:VARCHAR(10)
        /// </summary>
        public NullTypes.StringNT Attodecretograduatoriaregistro
        {
            get { return _Attodecretograduatoriaregistro; }
            set
            {
                if (Attodecretograduatoriaregistro != value)
                {
                    _Attodecretograduatoriaregistro = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:AttoDecretoGraduatoriaIndividuale
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT Attodecretograduatoriaindividuale
        {
            get { return _Attodecretograduatoriaindividuale; }
            set
            {
                if (Attodecretograduatoriaindividuale != value)
                {
                    _Attodecretograduatoriaindividuale = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:AttoDecretoGraduatoriaIndividualeNum
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT Attodecretograduatoriaindividualenum
        {
            get { return _Attodecretograduatoriaindividualenum; }
            set
            {
                if (Attodecretograduatoriaindividualenum != value)
                {
                    _Attodecretograduatoriaindividualenum = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:AttoDecretoGraduatoriaIndividualeData
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT Attodecretograduatoriaindividualedata
        {
            get { return _Attodecretograduatoriaindividualedata; }
            set
            {
                if (Attodecretograduatoriaindividualedata != value)
                {
                    _Attodecretograduatoriaindividualedata = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:AttoDecretoGraduatoriaIndividualeRegistro
        /// Tipo sul db:VARCHAR(10)
        /// </summary>
        public NullTypes.StringNT Attodecretograduatoriaindividualeregistro
        {
            get { return _Attodecretograduatoriaindividualeregistro; }
            set
            {
                if (Attodecretograduatoriaindividualeregistro != value)
                {
                    _Attodecretograduatoriaindividualeregistro = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:SegnaturaGraduatoria
        /// Tipo sul db:VARCHAR(100)
        /// </summary>
        public NullTypes.StringNT Segnaturagraduatoria
        {
            get { return _Segnaturagraduatoria; }
            set
            {
                if (Segnaturagraduatoria != value)
                {
                    _Segnaturagraduatoria = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DataGraduatoria
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT Datagraduatoria
        {
            get { return _Datagraduatoria; }
            set
            {
                if (Datagraduatoria != value)
                {
                    _Datagraduatoria = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ParereAdg
        /// Tipo sul db:VARCHAR(50)
        /// </summary>
        public NullTypes.StringNT Parereadg
        {
            get { return _Parereadg; }
            set
            {
                if (Parereadg != value)
                {
                    _Parereadg = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DataParereAdg
        /// Tipo sul db:VARCHAR(10)
        /// </summary>
        public NullTypes.StringNT Dataparereadg
        {
            get { return _Dataparereadg; }
            set
            {
                if (Dataparereadg != value)
                {
                    _Dataparereadg = value;
                    SetDirtyFlag();
                }
            }
        }




    }
}

namespace SiarLibrary
{

    /// <summary>
    /// Summary description for VpistaControlloCollection
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class VpistaControlloCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
        private VpistaControlloCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((VpistaControllo)info.GetValue(i.ToString(), typeof(VpistaControllo)));
            }
        }

        //Costruttore
        public VpistaControlloCollection()
        {
            this.ItemType = typeof(VpistaControllo);
        }

        //Get e Set
        public new VpistaControllo this[int index]
        {
            get { return (VpistaControllo)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new VpistaControlloCollection GetChanges()
        {
            return (VpistaControlloCollection)base.GetChanges();
        }

        //Add
        public int Add(VpistaControllo VpistaControlloObj)
        {
            return base.Add(VpistaControlloObj);
        }

        //AddCollection
        public void AddCollection(VpistaControlloCollection VpistaControlloCollectionObj)
        {
            foreach (VpistaControllo VpistaControlloObj in VpistaControlloCollectionObj)
                this.Add(VpistaControlloObj);
        }

        //Insert
        public void Insert(int index, VpistaControllo VpistaControlloObj)
        {
            base.Insert(index, VpistaControlloObj);
        }

        //filter: effettua una ricerca all'interno della collection
        // se il parametro di ricerca è null, prende tutto,
        // anche i record che hanno quel campo null
        // altrimenti scarta i record che hanno quel campo null ...
        // ...e confronta gli altri
        public VpistaControlloCollection SubSelect(NullTypes.IntNT IdbandoEqualThis, NullTypes.StringNT DescrizionebandoEqualThis, NullTypes.IntNT IdprogettoEqualThis,
NullTypes.StringNT AssecodEqualThis, NullTypes.StringNT AssedescrEqualThis, NullTypes.StringNT AzionecodEqualThis,
NullTypes.StringNT AzionedescrEqualThis, NullTypes.StringNT InterventocodEqualThis, NullTypes.StringNT InterventodescrEqualThis,
NullTypes.StringNT RagionesocialeEqualThis, NullTypes.StringNT PartitaivacfEqualThis, NullTypes.StringNT TipoproceduraEqualThis,
NullTypes.StringNT CupNaturaEqualThis, NullTypes.StringNT CodicetitolaritaregiaEqualThis, NullTypes.DatetimeNT DatapubblicazionebandoEqualThis,
NullTypes.IntNT AttopubblicazionebandoEqualThis, NullTypes.IntNT AttopubblicazionebandonumEqualThis, NullTypes.DatetimeNT AttopubblicazionebandodataEqualThis,
NullTypes.StringNT AttopubblicazionebandoregistroEqualThis, NullTypes.IntNT AttopubblicazionebandoburEqualThis, NullTypes.DatetimeNT AttopubblicazionebandoburdataEqualThis,
NullTypes.StringNT SegnaturadomandaEqualThis, NullTypes.DatetimeNT DomandadataEqualThis, NullTypes.StringNT SegnaturavalutazionecomitatoEqualThis,
NullTypes.DatetimeNT DatavalutazionecomitatoEqualThis, NullTypes.StringNT SegnaturavalutazionevariantecomitatoEqualThis, NullTypes.DatetimeNT DatavalutazionevariantecomitatoEqualThis,
NullTypes.IntNT AttodecretograduatoriaEqualThis, NullTypes.IntNT AttodecretograduatorianumEqualThis, NullTypes.DatetimeNT AttodecretograduatoriadataEqualThis,
NullTypes.StringNT AttodecretograduatoriaregistroEqualThis, NullTypes.IntNT AttodecretograduatoriaindividualeEqualThis, NullTypes.IntNT AttodecretograduatoriaindividualenumEqualThis,
NullTypes.DatetimeNT AttodecretograduatoriaindividualedataEqualThis, NullTypes.StringNT AttodecretograduatoriaindividualeregistroEqualThis, NullTypes.StringNT SegnaturagraduatoriaEqualThis,
NullTypes.DatetimeNT DatagraduatoriaEqualThis, NullTypes.StringNT ParereadgEqualThis, NullTypes.StringNT DataparereadgEqualThis)
        {
            VpistaControlloCollection VpistaControlloCollectionTemp = new VpistaControlloCollection();
            foreach (VpistaControllo VpistaControlloItem in this)
            {
                if (((IdbandoEqualThis == null) || ((VpistaControlloItem.Idbando != null) && (VpistaControlloItem.Idbando.Value == IdbandoEqualThis.Value))) && ((DescrizionebandoEqualThis == null) || ((VpistaControlloItem.Descrizionebando != null) && (VpistaControlloItem.Descrizionebando.Value == DescrizionebandoEqualThis.Value))) && ((IdprogettoEqualThis == null) || ((VpistaControlloItem.Idprogetto != null) && (VpistaControlloItem.Idprogetto.Value == IdprogettoEqualThis.Value))) &&
((AssecodEqualThis == null) || ((VpistaControlloItem.Assecod != null) && (VpistaControlloItem.Assecod.Value == AssecodEqualThis.Value))) && ((AssedescrEqualThis == null) || ((VpistaControlloItem.Assedescr != null) && (VpistaControlloItem.Assedescr.Value == AssedescrEqualThis.Value))) && ((AzionecodEqualThis == null) || ((VpistaControlloItem.Azionecod != null) && (VpistaControlloItem.Azionecod.Value == AzionecodEqualThis.Value))) &&
((AzionedescrEqualThis == null) || ((VpistaControlloItem.Azionedescr != null) && (VpistaControlloItem.Azionedescr.Value == AzionedescrEqualThis.Value))) && ((InterventocodEqualThis == null) || ((VpistaControlloItem.Interventocod != null) && (VpistaControlloItem.Interventocod.Value == InterventocodEqualThis.Value))) && ((InterventodescrEqualThis == null) || ((VpistaControlloItem.Interventodescr != null) && (VpistaControlloItem.Interventodescr.Value == InterventodescrEqualThis.Value))) &&
((RagionesocialeEqualThis == null) || ((VpistaControlloItem.Ragionesociale != null) && (VpistaControlloItem.Ragionesociale.Value == RagionesocialeEqualThis.Value))) && ((PartitaivacfEqualThis == null) || ((VpistaControlloItem.Partitaivacf != null) && (VpistaControlloItem.Partitaivacf.Value == PartitaivacfEqualThis.Value))) && ((TipoproceduraEqualThis == null) || ((VpistaControlloItem.Tipoprocedura != null) && (VpistaControlloItem.Tipoprocedura.Value == TipoproceduraEqualThis.Value))) &&
((CupNaturaEqualThis == null) || ((VpistaControlloItem.CupNatura != null) && (VpistaControlloItem.CupNatura.Value == CupNaturaEqualThis.Value))) && ((CodicetitolaritaregiaEqualThis == null) || ((VpistaControlloItem.Codicetitolaritaregia != null) && (VpistaControlloItem.Codicetitolaritaregia.Value == CodicetitolaritaregiaEqualThis.Value))) && ((DatapubblicazionebandoEqualThis == null) || ((VpistaControlloItem.Datapubblicazionebando != null) && (VpistaControlloItem.Datapubblicazionebando.Value == DatapubblicazionebandoEqualThis.Value))) &&
((AttopubblicazionebandoEqualThis == null) || ((VpistaControlloItem.Attopubblicazionebando != null) && (VpistaControlloItem.Attopubblicazionebando.Value == AttopubblicazionebandoEqualThis.Value))) && ((AttopubblicazionebandonumEqualThis == null) || ((VpistaControlloItem.Attopubblicazionebandonum != null) && (VpistaControlloItem.Attopubblicazionebandonum.Value == AttopubblicazionebandonumEqualThis.Value))) && ((AttopubblicazionebandodataEqualThis == null) || ((VpistaControlloItem.Attopubblicazionebandodata != null) && (VpistaControlloItem.Attopubblicazionebandodata.Value == AttopubblicazionebandodataEqualThis.Value))) &&
((AttopubblicazionebandoregistroEqualThis == null) || ((VpistaControlloItem.Attopubblicazionebandoregistro != null) && (VpistaControlloItem.Attopubblicazionebandoregistro.Value == AttopubblicazionebandoregistroEqualThis.Value))) && ((AttopubblicazionebandoburEqualThis == null) || ((VpistaControlloItem.Attopubblicazionebandobur != null) && (VpistaControlloItem.Attopubblicazionebandobur.Value == AttopubblicazionebandoburEqualThis.Value))) && ((AttopubblicazionebandoburdataEqualThis == null) || ((VpistaControlloItem.Attopubblicazionebandoburdata != null) && (VpistaControlloItem.Attopubblicazionebandoburdata.Value == AttopubblicazionebandoburdataEqualThis.Value))) &&
((SegnaturadomandaEqualThis == null) || ((VpistaControlloItem.Segnaturadomanda != null) && (VpistaControlloItem.Segnaturadomanda.Value == SegnaturadomandaEqualThis.Value))) && ((DomandadataEqualThis == null) || ((VpistaControlloItem.Domandadata != null) && (VpistaControlloItem.Domandadata.Value == DomandadataEqualThis.Value))) && ((SegnaturavalutazionecomitatoEqualThis == null) || ((VpistaControlloItem.Segnaturavalutazionecomitato != null) && (VpistaControlloItem.Segnaturavalutazionecomitato.Value == SegnaturavalutazionecomitatoEqualThis.Value))) &&
((DatavalutazionecomitatoEqualThis == null) || ((VpistaControlloItem.Datavalutazionecomitato != null) && (VpistaControlloItem.Datavalutazionecomitato.Value == DatavalutazionecomitatoEqualThis.Value))) && ((SegnaturavalutazionevariantecomitatoEqualThis == null) || ((VpistaControlloItem.Segnaturavalutazionevariantecomitato != null) && (VpistaControlloItem.Segnaturavalutazionevariantecomitato.Value == SegnaturavalutazionevariantecomitatoEqualThis.Value))) && ((DatavalutazionevariantecomitatoEqualThis == null) || ((VpistaControlloItem.Datavalutazionevariantecomitato != null) && (VpistaControlloItem.Datavalutazionevariantecomitato.Value == DatavalutazionevariantecomitatoEqualThis.Value))) &&
((AttodecretograduatoriaEqualThis == null) || ((VpistaControlloItem.Attodecretograduatoria != null) && (VpistaControlloItem.Attodecretograduatoria.Value == AttodecretograduatoriaEqualThis.Value))) && ((AttodecretograduatorianumEqualThis == null) || ((VpistaControlloItem.Attodecretograduatorianum != null) && (VpistaControlloItem.Attodecretograduatorianum.Value == AttodecretograduatorianumEqualThis.Value))) && ((AttodecretograduatoriadataEqualThis == null) || ((VpistaControlloItem.Attodecretograduatoriadata != null) && (VpistaControlloItem.Attodecretograduatoriadata.Value == AttodecretograduatoriadataEqualThis.Value))) &&
((AttodecretograduatoriaregistroEqualThis == null) || ((VpistaControlloItem.Attodecretograduatoriaregistro != null) && (VpistaControlloItem.Attodecretograduatoriaregistro.Value == AttodecretograduatoriaregistroEqualThis.Value))) && ((AttodecretograduatoriaindividualeEqualThis == null) || ((VpistaControlloItem.Attodecretograduatoriaindividuale != null) && (VpistaControlloItem.Attodecretograduatoriaindividuale.Value == AttodecretograduatoriaindividualeEqualThis.Value))) && ((AttodecretograduatoriaindividualenumEqualThis == null) || ((VpistaControlloItem.Attodecretograduatoriaindividualenum != null) && (VpistaControlloItem.Attodecretograduatoriaindividualenum.Value == AttodecretograduatoriaindividualenumEqualThis.Value))) &&
((AttodecretograduatoriaindividualedataEqualThis == null) || ((VpistaControlloItem.Attodecretograduatoriaindividualedata != null) && (VpistaControlloItem.Attodecretograduatoriaindividualedata.Value == AttodecretograduatoriaindividualedataEqualThis.Value))) && ((AttodecretograduatoriaindividualeregistroEqualThis == null) || ((VpistaControlloItem.Attodecretograduatoriaindividualeregistro != null) && (VpistaControlloItem.Attodecretograduatoriaindividualeregistro.Value == AttodecretograduatoriaindividualeregistroEqualThis.Value))) && ((SegnaturagraduatoriaEqualThis == null) || ((VpistaControlloItem.Segnaturagraduatoria != null) && (VpistaControlloItem.Segnaturagraduatoria.Value == SegnaturagraduatoriaEqualThis.Value))) &&
((DatagraduatoriaEqualThis == null) || ((VpistaControlloItem.Datagraduatoria != null) && (VpistaControlloItem.Datagraduatoria.Value == DatagraduatoriaEqualThis.Value))) && ((ParereadgEqualThis == null) || ((VpistaControlloItem.Parereadg != null) && (VpistaControlloItem.Parereadg.Value == ParereadgEqualThis.Value))) && ((DataparereadgEqualThis == null) || ((VpistaControlloItem.Dataparereadg != null) && (VpistaControlloItem.Dataparereadg.Value == DataparereadgEqualThis.Value))))
                {
                    VpistaControlloCollectionTemp.Add(VpistaControlloItem);
                }
            }
            return VpistaControlloCollectionTemp;
        }



    }
}

namespace SiarDAL
{

    /// <summary>
    /// Summary description for VpistaControlloDAL
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>


    internal class VpistaControlloDAL
    {

        //Operazioni

        //getFromDatareader
        public static VpistaControllo GetFromDatareader(DbProvider db)
        {
            VpistaControllo VpistaControlloObj = new VpistaControllo();
            VpistaControlloObj.Idbando = new SiarLibrary.NullTypes.IntNT(db.DataReader["IdBando"]);
            VpistaControlloObj.Descrizionebando = new SiarLibrary.NullTypes.StringNT(db.DataReader["DescrizioneBando"]);
            VpistaControlloObj.Idprogetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["IdProgetto"]);
            VpistaControlloObj.Assecod = new SiarLibrary.NullTypes.StringNT(db.DataReader["AsseCod"]);
            VpistaControlloObj.Assedescr = new SiarLibrary.NullTypes.StringNT(db.DataReader["AsseDescr"]);
            VpistaControlloObj.Azionecod = new SiarLibrary.NullTypes.StringNT(db.DataReader["AzioneCod"]);
            VpistaControlloObj.Azionedescr = new SiarLibrary.NullTypes.StringNT(db.DataReader["AzioneDescr"]);
            VpistaControlloObj.Interventocod = new SiarLibrary.NullTypes.StringNT(db.DataReader["InterventoCod"]);
            VpistaControlloObj.Interventodescr = new SiarLibrary.NullTypes.StringNT(db.DataReader["InterventoDescr"]);
            VpistaControlloObj.Ragionesociale = new SiarLibrary.NullTypes.StringNT(db.DataReader["RagioneSociale"]);
            VpistaControlloObj.Partitaivacf = new SiarLibrary.NullTypes.StringNT(db.DataReader["PartitaIvaCF"]);
            VpistaControlloObj.Tipoprocedura = new SiarLibrary.NullTypes.StringNT(db.DataReader["TipoProcedura"]);
            VpistaControlloObj.CupNatura = new SiarLibrary.NullTypes.StringNT(db.DataReader["CUP_NATURA"]);
            VpistaControlloObj.Codicetitolaritaregia = new SiarLibrary.NullTypes.StringNT(db.DataReader["CodiceTitolaritaRegia"]);
            VpistaControlloObj.Datapubblicazionebando = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DataPubblicazioneBando"]);
            VpistaControlloObj.Attopubblicazionebando = new SiarLibrary.NullTypes.IntNT(db.DataReader["AttoPubblicazioneBando"]);
            VpistaControlloObj.Attopubblicazionebandonum = new SiarLibrary.NullTypes.IntNT(db.DataReader["AttoPubblicazioneBandoNum"]);
            VpistaControlloObj.Attopubblicazionebandodata = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["AttoPubblicazioneBandoData"]);
            VpistaControlloObj.Attopubblicazionebandoregistro = new SiarLibrary.NullTypes.StringNT(db.DataReader["AttoPubblicazioneBandoRegistro"]);
            VpistaControlloObj.Attopubblicazionebandobur = new SiarLibrary.NullTypes.IntNT(db.DataReader["AttoPubblicazioneBandoBur"]);
            VpistaControlloObj.Attopubblicazionebandoburdata = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["AttoPubblicazioneBandoBurData"]);
            VpistaControlloObj.Segnaturadomanda = new SiarLibrary.NullTypes.StringNT(db.DataReader["SegnaturaDomanda"]);
            VpistaControlloObj.Domandadata = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DomandaData"]);
            VpistaControlloObj.Segnaturavalutazionecomitato = new SiarLibrary.NullTypes.StringNT(db.DataReader["SegnaturaValutazioneComitato"]);
            VpistaControlloObj.Datavalutazionecomitato = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DataValutazioneComitato"]);
            VpistaControlloObj.Segnaturavalutazionevariantecomitato = new SiarLibrary.NullTypes.StringNT(db.DataReader["SegnaturaValutazioneVarianteComitato"]);
            VpistaControlloObj.Datavalutazionevariantecomitato = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DataValutazioneVarianteComitato"]);
            VpistaControlloObj.Attodecretograduatoria = new SiarLibrary.NullTypes.IntNT(db.DataReader["AttoDecretoGraduatoria"]);
            VpistaControlloObj.Attodecretograduatorianum = new SiarLibrary.NullTypes.IntNT(db.DataReader["AttoDecretoGraduatoriaNum"]);
            VpistaControlloObj.Attodecretograduatoriadata = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["AttoDecretoGraduatoriaData"]);
            VpistaControlloObj.Attodecretograduatoriaregistro = new SiarLibrary.NullTypes.StringNT(db.DataReader["AttoDecretoGraduatoriaRegistro"]);
            VpistaControlloObj.Attodecretograduatoriaindividuale = new SiarLibrary.NullTypes.IntNT(db.DataReader["AttoDecretoGraduatoriaIndividuale"]);
            VpistaControlloObj.Attodecretograduatoriaindividualenum = new SiarLibrary.NullTypes.IntNT(db.DataReader["AttoDecretoGraduatoriaIndividualeNum"]);
            VpistaControlloObj.Attodecretograduatoriaindividualedata = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["AttoDecretoGraduatoriaIndividualeData"]);
            VpistaControlloObj.Attodecretograduatoriaindividualeregistro = new SiarLibrary.NullTypes.StringNT(db.DataReader["AttoDecretoGraduatoriaIndividualeRegistro"]);
            VpistaControlloObj.Segnaturagraduatoria = new SiarLibrary.NullTypes.StringNT(db.DataReader["SegnaturaGraduatoria"]);
            VpistaControlloObj.Datagraduatoria = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DataGraduatoria"]);
            VpistaControlloObj.Parereadg = new SiarLibrary.NullTypes.StringNT(db.DataReader["ParereAdg"]);
            VpistaControlloObj.Dataparereadg = new SiarLibrary.NullTypes.StringNT(db.DataReader["DataParereAdg"]);
            VpistaControlloObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            VpistaControlloObj.IsDirty = false;
            VpistaControlloObj.IsPersistent = true;
            return VpistaControlloObj;
        }

        //Find Select

        public static VpistaControlloCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdbandoEqualThis, SiarLibrary.NullTypes.StringNT DescrizionebandoEqualThis, SiarLibrary.NullTypes.IntNT IdprogettoEqualThis,
SiarLibrary.NullTypes.StringNT AssecodEqualThis, SiarLibrary.NullTypes.StringNT AssedescrEqualThis, SiarLibrary.NullTypes.StringNT AzionecodEqualThis,
SiarLibrary.NullTypes.StringNT AzionedescrEqualThis, SiarLibrary.NullTypes.StringNT InterventocodEqualThis, SiarLibrary.NullTypes.StringNT InterventodescrEqualThis,
SiarLibrary.NullTypes.StringNT RagionesocialeEqualThis, SiarLibrary.NullTypes.StringNT PartitaivacfEqualThis, SiarLibrary.NullTypes.StringNT TipoproceduraEqualThis,
SiarLibrary.NullTypes.StringNT CupNaturaEqualThis, SiarLibrary.NullTypes.StringNT CodicetitolaritaregiaEqualThis, SiarLibrary.NullTypes.DatetimeNT DatapubblicazionebandoEqualThis,
SiarLibrary.NullTypes.IntNT AttopubblicazionebandoEqualThis, SiarLibrary.NullTypes.IntNT AttopubblicazionebandonumEqualThis, SiarLibrary.NullTypes.DatetimeNT AttopubblicazionebandodataEqualThis,
SiarLibrary.NullTypes.StringNT AttopubblicazionebandoregistroEqualThis, SiarLibrary.NullTypes.IntNT AttopubblicazionebandoburEqualThis, SiarLibrary.NullTypes.DatetimeNT AttopubblicazionebandoburdataEqualThis,
SiarLibrary.NullTypes.StringNT SegnaturadomandaEqualThis, SiarLibrary.NullTypes.DatetimeNT DomandadataEqualThis, SiarLibrary.NullTypes.StringNT SegnaturavalutazionecomitatoEqualThis,
SiarLibrary.NullTypes.DatetimeNT DatavalutazionecomitatoEqualThis, SiarLibrary.NullTypes.StringNT SegnaturavalutazionevariantecomitatoEqualThis, SiarLibrary.NullTypes.DatetimeNT DatavalutazionevariantecomitatoEqualThis,
SiarLibrary.NullTypes.IntNT AttodecretograduatoriaEqualThis, SiarLibrary.NullTypes.IntNT AttodecretograduatorianumEqualThis, SiarLibrary.NullTypes.DatetimeNT AttodecretograduatoriadataEqualThis,
SiarLibrary.NullTypes.StringNT AttodecretograduatoriaregistroEqualThis, SiarLibrary.NullTypes.IntNT AttodecretograduatoriaindividualeEqualThis, SiarLibrary.NullTypes.IntNT AttodecretograduatoriaindividualenumEqualThis,
SiarLibrary.NullTypes.DatetimeNT AttodecretograduatoriaindividualedataEqualThis, SiarLibrary.NullTypes.StringNT AttodecretograduatoriaindividualeregistroEqualThis, SiarLibrary.NullTypes.StringNT SegnaturagraduatoriaEqualThis,
SiarLibrary.NullTypes.DatetimeNT DatagraduatoriaEqualThis, SiarLibrary.NullTypes.StringNT ParereadgEqualThis, SiarLibrary.NullTypes.StringNT DataparereadgEqualThis)

        {

            VpistaControlloCollection VpistaControlloCollectionObj = new VpistaControlloCollection();

            IDbCommand findCmd = db.InitCmd("Zvpistacontrollofindselect", new string[] {"Idbandoequalthis", "Descrizionebandoequalthis", "Idprogettoequalthis",
"Assecodequalthis", "Assedescrequalthis", "Azionecodequalthis",
"Azionedescrequalthis", "Interventocodequalthis", "Interventodescrequalthis",
"Ragionesocialeequalthis", "Partitaivacfequalthis", "Tipoproceduraequalthis",
"CupNaturaequalthis", "Codicetitolaritaregiaequalthis", "Datapubblicazionebandoequalthis",
"Attopubblicazionebandoequalthis", "Attopubblicazionebandonumequalthis", "Attopubblicazionebandodataequalthis",
"Attopubblicazionebandoregistroequalthis", "Attopubblicazionebandoburequalthis", "Attopubblicazionebandoburdataequalthis",
"Segnaturadomandaequalthis", "Domandadataequalthis", "Segnaturavalutazionecomitatoequalthis",
"Datavalutazionecomitatoequalthis", "Segnaturavalutazionevariantecomitatoequalthis", "Datavalutazionevariantecomitatoequalthis",
"Attodecretograduatoriaequalthis", "Attodecretograduatorianumequalthis", "Attodecretograduatoriadataequalthis",
"Attodecretograduatoriaregistroequalthis", "Attodecretograduatoriaindividualeequalthis", "Attodecretograduatoriaindividualenumequalthis",
"Attodecretograduatoriaindividualedataequalthis", "Attodecretograduatoriaindividualeregistroequalthis", "Segnaturagraduatoriaequalthis",
"Datagraduatoriaequalthis", "Parereadgequalthis", "Dataparereadgequalthis"}, new string[] {"int", "string", "int",
"string", "string", "string",
"string", "string", "string",
"string", "string", "string",
"string", "string", "DateTime",
"int", "int", "DateTime",
"string", "int", "DateTime",
"string", "DateTime", "string",
"DateTime", "string", "DateTime",
"int", "int", "DateTime",
"string", "int", "int",
"DateTime", "string", "string",
"DateTime", "string", "string"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Idbandoequalthis", IdbandoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Descrizionebandoequalthis", DescrizionebandoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Idprogettoequalthis", IdprogettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Assecodequalthis", AssecodEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Assedescrequalthis", AssedescrEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Azionecodequalthis", AzionecodEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Azionedescrequalthis", AzionedescrEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Interventocodequalthis", InterventocodEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Interventodescrequalthis", InterventodescrEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Ragionesocialeequalthis", RagionesocialeEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Partitaivacfequalthis", PartitaivacfEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Tipoproceduraequalthis", TipoproceduraEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CupNaturaequalthis", CupNaturaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Codicetitolaritaregiaequalthis", CodicetitolaritaregiaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Datapubblicazionebandoequalthis", DatapubblicazionebandoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Attopubblicazionebandoequalthis", AttopubblicazionebandoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Attopubblicazionebandonumequalthis", AttopubblicazionebandonumEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Attopubblicazionebandodataequalthis", AttopubblicazionebandodataEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Attopubblicazionebandoregistroequalthis", AttopubblicazionebandoregistroEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Attopubblicazionebandoburequalthis", AttopubblicazionebandoburEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Attopubblicazionebandoburdataequalthis", AttopubblicazionebandoburdataEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Segnaturadomandaequalthis", SegnaturadomandaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Domandadataequalthis", DomandadataEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Segnaturavalutazionecomitatoequalthis", SegnaturavalutazionecomitatoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Datavalutazionecomitatoequalthis", DatavalutazionecomitatoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Segnaturavalutazionevariantecomitatoequalthis", SegnaturavalutazionevariantecomitatoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Datavalutazionevariantecomitatoequalthis", DatavalutazionevariantecomitatoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Attodecretograduatoriaequalthis", AttodecretograduatoriaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Attodecretograduatorianumequalthis", AttodecretograduatorianumEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Attodecretograduatoriadataequalthis", AttodecretograduatoriadataEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Attodecretograduatoriaregistroequalthis", AttodecretograduatoriaregistroEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Attodecretograduatoriaindividualeequalthis", AttodecretograduatoriaindividualeEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Attodecretograduatoriaindividualenumequalthis", AttodecretograduatoriaindividualenumEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Attodecretograduatoriaindividualedataequalthis", AttodecretograduatoriaindividualedataEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Attodecretograduatoriaindividualeregistroequalthis", AttodecretograduatoriaindividualeregistroEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Segnaturagraduatoriaequalthis", SegnaturagraduatoriaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Datagraduatoriaequalthis", DatagraduatoriaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Parereadgequalthis", ParereadgEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Dataparereadgequalthis", DataparereadgEqualThis);
            VpistaControllo VpistaControlloObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                VpistaControlloObj = GetFromDatareader(db);
                VpistaControlloObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                VpistaControlloObj.IsDirty = false;
                VpistaControlloObj.IsPersistent = true;
                VpistaControlloCollectionObj.Add(VpistaControlloObj);
            }
            db.Close();
            return VpistaControlloCollectionObj;
        }

        //Find Find

        public static VpistaControlloCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdprogettoEqualThis)

        {

            VpistaControlloCollection VpistaControlloCollectionObj = new VpistaControlloCollection();

            IDbCommand findCmd = db.InitCmd("Zvpistacontrollofindfind", new string[] { "Idprogettoequalthis" }, new string[] { "int" }, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Idprogettoequalthis", IdprogettoEqualThis);
            VpistaControllo VpistaControlloObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                VpistaControlloObj = GetFromDatareader(db);
                VpistaControlloObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                VpistaControlloObj.IsDirty = false;
                VpistaControlloObj.IsPersistent = true;
                VpistaControlloCollectionObj.Add(VpistaControlloObj);
            }
            db.Close();
            return VpistaControlloCollectionObj;
        }

    }
}


namespace SiarBLL
{

    /// <summary>
    /// Summary description for VpistaControlloCollectionProvider:IVpistaControlloProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class VpistaControlloCollectionProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di VpistaControllo
        protected VpistaControlloCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public VpistaControlloCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new VpistaControlloCollection();
        }

        //Costruttore 2: popola la collection
        public VpistaControlloCollectionProvider(IntNT IdprogettoEqualThis)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = Find(IdprogettoEqualThis);
        }

        //Costruttore3: ha in input vpistacontrolloCollectionObj - non popola la collection
        public VpistaControlloCollectionProvider(VpistaControlloCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public VpistaControlloCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new VpistaControlloCollection();
        }

        //Get e Set
        public VpistaControlloCollection CollectionObj
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
        public VpistaControlloCollection Select(IntNT IdbandoEqualThis, StringNT DescrizionebandoEqualThis, IntNT IdprogettoEqualThis,
StringNT AssecodEqualThis, StringNT AssedescrEqualThis, StringNT AzionecodEqualThis,
StringNT AzionedescrEqualThis, StringNT InterventocodEqualThis, StringNT InterventodescrEqualThis,
StringNT RagionesocialeEqualThis, StringNT PartitaivacfEqualThis, StringNT TipoproceduraEqualThis,
StringNT CupnaturaEqualThis, StringNT CodicetitolaritaregiaEqualThis, DatetimeNT DatapubblicazionebandoEqualThis,
IntNT AttopubblicazionebandoEqualThis, IntNT AttopubblicazionebandonumEqualThis, DatetimeNT AttopubblicazionebandodataEqualThis,
StringNT AttopubblicazionebandoregistroEqualThis, IntNT AttopubblicazionebandoburEqualThis, DatetimeNT AttopubblicazionebandoburdataEqualThis,
StringNT SegnaturadomandaEqualThis, DatetimeNT DomandadataEqualThis, StringNT SegnaturavalutazionecomitatoEqualThis,
DatetimeNT DatavalutazionecomitatoEqualThis, StringNT SegnaturavalutazionevariantecomitatoEqualThis, DatetimeNT DatavalutazionevariantecomitatoEqualThis,
IntNT AttodecretograduatoriaEqualThis, IntNT AttodecretograduatorianumEqualThis, DatetimeNT AttodecretograduatoriadataEqualThis,
StringNT AttodecretograduatoriaregistroEqualThis, IntNT AttodecretograduatoriaindividualeEqualThis, IntNT AttodecretograduatoriaindividualenumEqualThis,
DatetimeNT AttodecretograduatoriaindividualedataEqualThis, StringNT AttodecretograduatoriaindividualeregistroEqualThis, StringNT SegnaturagraduatoriaEqualThis,
DatetimeNT DatagraduatoriaEqualThis, StringNT ParereadgEqualThis, StringNT DataparereadgEqualThis)
        {
            VpistaControlloCollection VpistaControlloCollectionTemp = VpistaControlloDAL.Select(_dbProviderObj, IdbandoEqualThis, DescrizionebandoEqualThis, IdprogettoEqualThis,
AssecodEqualThis, AssedescrEqualThis, AzionecodEqualThis,
AzionedescrEqualThis, InterventocodEqualThis, InterventodescrEqualThis,
RagionesocialeEqualThis, PartitaivacfEqualThis, TipoproceduraEqualThis,
CupnaturaEqualThis, CodicetitolaritaregiaEqualThis, DatapubblicazionebandoEqualThis,
AttopubblicazionebandoEqualThis, AttopubblicazionebandonumEqualThis, AttopubblicazionebandodataEqualThis,
AttopubblicazionebandoregistroEqualThis, AttopubblicazionebandoburEqualThis, AttopubblicazionebandoburdataEqualThis,
SegnaturadomandaEqualThis, DomandadataEqualThis, SegnaturavalutazionecomitatoEqualThis,
DatavalutazionecomitatoEqualThis, SegnaturavalutazionevariantecomitatoEqualThis, DatavalutazionevariantecomitatoEqualThis,
AttodecretograduatoriaEqualThis, AttodecretograduatorianumEqualThis, AttodecretograduatoriadataEqualThis,
AttodecretograduatoriaregistroEqualThis, AttodecretograduatoriaindividualeEqualThis, AttodecretograduatoriaindividualenumEqualThis,
AttodecretograduatoriaindividualedataEqualThis, AttodecretograduatoriaindividualeregistroEqualThis, SegnaturagraduatoriaEqualThis,
DatagraduatoriaEqualThis, ParereadgEqualThis, DataparereadgEqualThis);
            return VpistaControlloCollectionTemp;
        }

        //Find: popola la collection
        public VpistaControlloCollection Find(IntNT IdprogettoEqualThis)
        {
            VpistaControlloCollection VpistaControlloCollectionTemp = VpistaControlloDAL.Find(_dbProviderObj, IdprogettoEqualThis);
            return VpistaControlloCollectionTemp;
        }


    }
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<vPISTA_CONTROLLO>
  <ViewName>vPISTA_CONTROLLO</ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>False</chkDataModifica>
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
    <Find OrderBy="ORDER BY ">
      <IdProgetto>Equal</IdProgetto>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</vPISTA_CONTROLLO>
*/
