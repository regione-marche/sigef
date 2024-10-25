using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

    // interfaccia provider per DecretiXDomPagEsportazioneModifiche
    // Interfaccia Autogenerata
    // Inserire eventuali operazioni aggiuntive
    public interface IDecretiXDomPagEsportazioneModificheProvider
    {
        int Save(DecretiXDomPagEsportazioneModifiche DecretiXDomPagEsportazioneModificheObj);
        int SaveCollection(DecretiXDomPagEsportazioneModificheCollection collectionObj);
        int Delete(DecretiXDomPagEsportazioneModifiche DecretiXDomPagEsportazioneModificheObj);
        int DeleteCollection(DecretiXDomPagEsportazioneModificheCollection collectionObj);
    }
    /// <summary>
    /// Summary description for DecretiXDomPagEsportazioneModifiche
    /// Class Autogenerata
    /// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
    /// con delle partial class contenenti i metodi aggiunti, in questo modo 
    /// non verranno sovrascritti quando si rigenera la classe 
    /// </summary>

    [Serializable]
    [System.Xml.Serialization.XmlType(Namespace = "")]

    public partial class DecretiXDomPagEsportazioneModifiche : BaseObject
    {

        //Definizione dei campi 'base'
        private NullTypes.IntNT _IdDecretiXDomPagEsportazione;
        private NullTypes.IntNT _IdDomandaPagamento;
        private NullTypes.IntNT _IdProgetto;
        private NullTypes.IntNT _IdDecreto;
        private NullTypes.DecimalNT _Importo;
        private NullTypes.DatetimeNT _DataInserimento;
        private NullTypes.DatetimeNT _DataModifica;
        private NullTypes.IntNT _IdAtto;
        private NullTypes.IntNT _Numero;
        private NullTypes.DatetimeNT _Data;
        private NullTypes.StringNT _Descrizione;
        private NullTypes.StringNT _Servizio;
        private NullTypes.StringNT _Registro;
        private NullTypes.StringNT _CodTipo;
        private NullTypes.StringNT _CodDefinizione;
        private NullTypes.StringNT _CodOrganoIstituzionale;
        private NullTypes.DatetimeNT _DataBur;
        private NullTypes.IntNT _NumeroBur;
        private NullTypes.StringNT _AwDocnumber;
        private NullTypes.IntNT _AwDocnumberNuovo;
        private NullTypes.StringNT _DefinizioneAtto;
        private NullTypes.StringNT _TipoAtto;
        private NullTypes.StringNT _OrganoIstituzionale;
        private NullTypes.StringNT _LinkEsterno;
        private NullTypes.IntNT _Id;
        private NullTypes.IntNT _IdModifica;
        [NonSerialized] private IDecretiXDomPagEsportazioneModificheProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IDecretiXDomPagEsportazioneModificheProvider Provider
        {
            get { return _provider; }
            set { _provider = value; }
        }


        //Costruttore
        public DecretiXDomPagEsportazioneModifiche()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //Get e Set dei campi 'base'
        /// <summary>
        /// Corrisponde al campo:ID_DECRETI_X_DOM_PAG_ESPORTAZIONE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdDecretiXDomPagEsportazione
        {
            get { return _IdDecretiXDomPagEsportazione; }
            set
            {
                if (IdDecretiXDomPagEsportazione != value)
                {
                    _IdDecretiXDomPagEsportazione = value;
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
        /// Corrisponde al campo:ID_DECRETO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdDecreto
        {
            get { return _IdDecreto; }
            set
            {
                if (IdDecreto != value)
                {
                    _IdDecreto = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IMPORTO
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT Importo
        {
            get { return _Importo; }
            set
            {
                if (Importo != value)
                {
                    _Importo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_INSERIMENTO
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataInserimento
        {
            get { return _DataInserimento; }
            set
            {
                if (DataInserimento != value)
                {
                    _DataInserimento = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_MODIFICA
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataModifica
        {
            get { return _DataModifica; }
            set
            {
                if (DataModifica != value)
                {
                    _DataModifica = value;
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

        /// <summary>
        /// Corrisponde al campo:NUMERO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT Numero
        {
            get { return _Numero; }
            set
            {
                if (Numero != value)
                {
                    _Numero = value;
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
        /// Corrisponde al campo:DESCRIZIONE
        /// Tipo sul db:VARCHAR(3000)
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
        /// Corrisponde al campo:SERVIZIO
        /// Tipo sul db:VARCHAR(255)
        /// </summary>
        public NullTypes.StringNT Servizio
        {
            get { return _Servizio; }
            set
            {
                if (Servizio != value)
                {
                    _Servizio = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:REGISTRO
        /// Tipo sul db:VARCHAR(10)
        /// </summary>
        public NullTypes.StringNT Registro
        {
            get { return _Registro; }
            set
            {
                if (Registro != value)
                {
                    _Registro = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:COD_TIPO
        /// Tipo sul db:CHAR(1)
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
        /// Corrisponde al campo:COD_DEFINIZIONE
        /// Tipo sul db:CHAR(1)
        /// </summary>
        public NullTypes.StringNT CodDefinizione
        {
            get { return _CodDefinizione; }
            set
            {
                if (CodDefinizione != value)
                {
                    _CodDefinizione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:COD_ORGANO_ISTITUZIONALE
        /// Tipo sul db:CHAR(2)
        /// </summary>
        public NullTypes.StringNT CodOrganoIstituzionale
        {
            get { return _CodOrganoIstituzionale; }
            set
            {
                if (CodOrganoIstituzionale != value)
                {
                    _CodOrganoIstituzionale = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_BUR
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataBur
        {
            get { return _DataBur; }
            set
            {
                if (DataBur != value)
                {
                    _DataBur = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:NUMERO_BUR
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT NumeroBur
        {
            get { return _NumeroBur; }
            set
            {
                if (NumeroBur != value)
                {
                    _NumeroBur = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:AW_DOCNUMBER
        /// Tipo sul db:VARCHAR(30)
        /// </summary>
        public NullTypes.StringNT AwDocnumber
        {
            get { return _AwDocnumber; }
            set
            {
                if (AwDocnumber != value)
                {
                    _AwDocnumber = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:AW_DOCNUMBER_NUOVO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT AwDocnumberNuovo
        {
            get { return _AwDocnumberNuovo; }
            set
            {
                if (AwDocnumberNuovo != value)
                {
                    _AwDocnumberNuovo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DEFINIZIONE_ATTO
        /// Tipo sul db:VARCHAR(100)
        /// </summary>
        public NullTypes.StringNT DefinizioneAtto
        {
            get { return _DefinizioneAtto; }
            set
            {
                if (DefinizioneAtto != value)
                {
                    _DefinizioneAtto = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:TIPO_ATTO
        /// Tipo sul db:VARCHAR(80)
        /// </summary>
        public NullTypes.StringNT TipoAtto
        {
            get { return _TipoAtto; }
            set
            {
                if (TipoAtto != value)
                {
                    _TipoAtto = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ORGANO_ISTITUZIONALE
        /// Tipo sul db:VARCHAR(100)
        /// </summary>
        public NullTypes.StringNT OrganoIstituzionale
        {
            get { return _OrganoIstituzionale; }
            set
            {
                if (OrganoIstituzionale != value)
                {
                    _OrganoIstituzionale = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:LINK_ESTERNO
        /// Tipo sul db:VARCHAR(3000)
        /// </summary>
        public NullTypes.StringNT LinkEsterno
        {
            get { return _LinkEsterno; }
            set
            {
                if (LinkEsterno != value)
                {
                    _LinkEsterno = value;
                    SetDirtyFlag();
                }
            }
        }

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
    /// Summary description for DecretiXDomPagEsportazioneModificheCollection
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class DecretiXDomPagEsportazioneModificheCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
        private DecretiXDomPagEsportazioneModificheCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((DecretiXDomPagEsportazioneModifiche)info.GetValue(i.ToString(), typeof(DecretiXDomPagEsportazioneModifiche)));
            }
        }

        //Costruttore
        public DecretiXDomPagEsportazioneModificheCollection()
        {
            this.ItemType = typeof(DecretiXDomPagEsportazioneModifiche);
        }

        //Costruttore con provider
        public DecretiXDomPagEsportazioneModificheCollection(IDecretiXDomPagEsportazioneModificheProvider providerObj)
        {
            this.ItemType = typeof(DecretiXDomPagEsportazioneModifiche);
            this.Provider = providerObj;
        }

        //Get e Set
        public new DecretiXDomPagEsportazioneModifiche this[int index]
        {
            get { return (DecretiXDomPagEsportazioneModifiche)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new DecretiXDomPagEsportazioneModificheCollection GetChanges()
        {
            return (DecretiXDomPagEsportazioneModificheCollection)base.GetChanges();
        }

        [NonSerialized] private IDecretiXDomPagEsportazioneModificheProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IDecretiXDomPagEsportazioneModificheProvider Provider
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
        public int Add(DecretiXDomPagEsportazioneModifiche DecretiXDomPagEsportazioneModificheObj)
        {
            if (DecretiXDomPagEsportazioneModificheObj.Provider == null) DecretiXDomPagEsportazioneModificheObj.Provider = this.Provider;
            return base.Add(DecretiXDomPagEsportazioneModificheObj);
        }

        //AddCollection
        public void AddCollection(DecretiXDomPagEsportazioneModificheCollection DecretiXDomPagEsportazioneModificheCollectionObj)
        {
            foreach (DecretiXDomPagEsportazioneModifiche DecretiXDomPagEsportazioneModificheObj in DecretiXDomPagEsportazioneModificheCollectionObj)
                this.Add(DecretiXDomPagEsportazioneModificheObj);
        }

        //Insert
        public void Insert(int index, DecretiXDomPagEsportazioneModifiche DecretiXDomPagEsportazioneModificheObj)
        {
            if (DecretiXDomPagEsportazioneModificheObj.Provider == null) DecretiXDomPagEsportazioneModificheObj.Provider = this.Provider;
            base.Insert(index, DecretiXDomPagEsportazioneModificheObj);
        }

        //CollectionGetById
        public DecretiXDomPagEsportazioneModifiche CollectionGetById(NullTypes.IntNT IdValue)
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
        public DecretiXDomPagEsportazioneModificheCollection SubSelect(NullTypes.IntNT IdDecretiXDomPagEsportazioneEqualThis, NullTypes.IntNT IdDomandaPagamentoEqualThis, NullTypes.IntNT IdProgettoEqualThis,
NullTypes.IntNT IdDecretoEqualThis, NullTypes.DecimalNT ImportoEqualThis, NullTypes.DatetimeNT DataInserimentoEqualThis,
NullTypes.DatetimeNT DataModificaEqualThis, NullTypes.IntNT IdAttoEqualThis, NullTypes.IntNT NumeroEqualThis,
NullTypes.DatetimeNT DataEqualThis, NullTypes.StringNT DescrizioneEqualThis, NullTypes.StringNT ServizioEqualThis,
NullTypes.StringNT RegistroEqualThis, NullTypes.StringNT CodTipoEqualThis, NullTypes.StringNT CodDefinizioneEqualThis,
NullTypes.StringNT CodOrganoIstituzionaleEqualThis, NullTypes.DatetimeNT DataBurEqualThis, NullTypes.IntNT NumeroBurEqualThis,
NullTypes.StringNT AwDocnumberEqualThis, NullTypes.IntNT AwDocnumberNuovoEqualThis, NullTypes.StringNT DefinizioneAttoEqualThis,
NullTypes.StringNT TipoAttoEqualThis, NullTypes.StringNT OrganoIstituzionaleEqualThis, NullTypes.StringNT LinkEsternoEqualThis,
NullTypes.IntNT IdEqualThis, NullTypes.IntNT IdModificaEqualThis)
        {
            DecretiXDomPagEsportazioneModificheCollection DecretiXDomPagEsportazioneModificheCollectionTemp = new DecretiXDomPagEsportazioneModificheCollection();
            foreach (DecretiXDomPagEsportazioneModifiche DecretiXDomPagEsportazioneModificheItem in this)
            {
                if (((IdDecretiXDomPagEsportazioneEqualThis == null) || ((DecretiXDomPagEsportazioneModificheItem.IdDecretiXDomPagEsportazione != null) && (DecretiXDomPagEsportazioneModificheItem.IdDecretiXDomPagEsportazione.Value == IdDecretiXDomPagEsportazioneEqualThis.Value))) && ((IdDomandaPagamentoEqualThis == null) || ((DecretiXDomPagEsportazioneModificheItem.IdDomandaPagamento != null) && (DecretiXDomPagEsportazioneModificheItem.IdDomandaPagamento.Value == IdDomandaPagamentoEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((DecretiXDomPagEsportazioneModificheItem.IdProgetto != null) && (DecretiXDomPagEsportazioneModificheItem.IdProgetto.Value == IdProgettoEqualThis.Value))) &&
((IdDecretoEqualThis == null) || ((DecretiXDomPagEsportazioneModificheItem.IdDecreto != null) && (DecretiXDomPagEsportazioneModificheItem.IdDecreto.Value == IdDecretoEqualThis.Value))) && ((ImportoEqualThis == null) || ((DecretiXDomPagEsportazioneModificheItem.Importo != null) && (DecretiXDomPagEsportazioneModificheItem.Importo.Value == ImportoEqualThis.Value))) && ((DataInserimentoEqualThis == null) || ((DecretiXDomPagEsportazioneModificheItem.DataInserimento != null) && (DecretiXDomPagEsportazioneModificheItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) &&
((DataModificaEqualThis == null) || ((DecretiXDomPagEsportazioneModificheItem.DataModifica != null) && (DecretiXDomPagEsportazioneModificheItem.DataModifica.Value == DataModificaEqualThis.Value))) && ((IdAttoEqualThis == null) || ((DecretiXDomPagEsportazioneModificheItem.IdAtto != null) && (DecretiXDomPagEsportazioneModificheItem.IdAtto.Value == IdAttoEqualThis.Value))) && ((NumeroEqualThis == null) || ((DecretiXDomPagEsportazioneModificheItem.Numero != null) && (DecretiXDomPagEsportazioneModificheItem.Numero.Value == NumeroEqualThis.Value))) &&
((DataEqualThis == null) || ((DecretiXDomPagEsportazioneModificheItem.Data != null) && (DecretiXDomPagEsportazioneModificheItem.Data.Value == DataEqualThis.Value))) && ((DescrizioneEqualThis == null) || ((DecretiXDomPagEsportazioneModificheItem.Descrizione != null) && (DecretiXDomPagEsportazioneModificheItem.Descrizione.Value == DescrizioneEqualThis.Value))) && ((ServizioEqualThis == null) || ((DecretiXDomPagEsportazioneModificheItem.Servizio != null) && (DecretiXDomPagEsportazioneModificheItem.Servizio.Value == ServizioEqualThis.Value))) &&
((RegistroEqualThis == null) || ((DecretiXDomPagEsportazioneModificheItem.Registro != null) && (DecretiXDomPagEsportazioneModificheItem.Registro.Value == RegistroEqualThis.Value))) && ((CodTipoEqualThis == null) || ((DecretiXDomPagEsportazioneModificheItem.CodTipo != null) && (DecretiXDomPagEsportazioneModificheItem.CodTipo.Value == CodTipoEqualThis.Value))) && ((CodDefinizioneEqualThis == null) || ((DecretiXDomPagEsportazioneModificheItem.CodDefinizione != null) && (DecretiXDomPagEsportazioneModificheItem.CodDefinizione.Value == CodDefinizioneEqualThis.Value))) &&
((CodOrganoIstituzionaleEqualThis == null) || ((DecretiXDomPagEsportazioneModificheItem.CodOrganoIstituzionale != null) && (DecretiXDomPagEsportazioneModificheItem.CodOrganoIstituzionale.Value == CodOrganoIstituzionaleEqualThis.Value))) && ((DataBurEqualThis == null) || ((DecretiXDomPagEsportazioneModificheItem.DataBur != null) && (DecretiXDomPagEsportazioneModificheItem.DataBur.Value == DataBurEqualThis.Value))) && ((NumeroBurEqualThis == null) || ((DecretiXDomPagEsportazioneModificheItem.NumeroBur != null) && (DecretiXDomPagEsportazioneModificheItem.NumeroBur.Value == NumeroBurEqualThis.Value))) &&
((AwDocnumberEqualThis == null) || ((DecretiXDomPagEsportazioneModificheItem.AwDocnumber != null) && (DecretiXDomPagEsportazioneModificheItem.AwDocnumber.Value == AwDocnumberEqualThis.Value))) && ((AwDocnumberNuovoEqualThis == null) || ((DecretiXDomPagEsportazioneModificheItem.AwDocnumberNuovo != null) && (DecretiXDomPagEsportazioneModificheItem.AwDocnumberNuovo.Value == AwDocnumberNuovoEqualThis.Value))) && ((DefinizioneAttoEqualThis == null) || ((DecretiXDomPagEsportazioneModificheItem.DefinizioneAtto != null) && (DecretiXDomPagEsportazioneModificheItem.DefinizioneAtto.Value == DefinizioneAttoEqualThis.Value))) &&
((TipoAttoEqualThis == null) || ((DecretiXDomPagEsportazioneModificheItem.TipoAtto != null) && (DecretiXDomPagEsportazioneModificheItem.TipoAtto.Value == TipoAttoEqualThis.Value))) && ((OrganoIstituzionaleEqualThis == null) || ((DecretiXDomPagEsportazioneModificheItem.OrganoIstituzionale != null) && (DecretiXDomPagEsportazioneModificheItem.OrganoIstituzionale.Value == OrganoIstituzionaleEqualThis.Value))) && ((LinkEsternoEqualThis == null) || ((DecretiXDomPagEsportazioneModificheItem.LinkEsterno != null) && (DecretiXDomPagEsportazioneModificheItem.LinkEsterno.Value == LinkEsternoEqualThis.Value))) &&
((IdEqualThis == null) || ((DecretiXDomPagEsportazioneModificheItem.Id != null) && (DecretiXDomPagEsportazioneModificheItem.Id.Value == IdEqualThis.Value))) && ((IdModificaEqualThis == null) || ((DecretiXDomPagEsportazioneModificheItem.IdModifica != null) && (DecretiXDomPagEsportazioneModificheItem.IdModifica.Value == IdModificaEqualThis.Value))))
                {
                    DecretiXDomPagEsportazioneModificheCollectionTemp.Add(DecretiXDomPagEsportazioneModificheItem);
                }
            }
            return DecretiXDomPagEsportazioneModificheCollectionTemp;
        }



    }
}

namespace SiarDAL
{

    /// <summary>
    /// Summary description for DecretiXDomPagEsportazioneModificheDAL
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>


    internal class DecretiXDomPagEsportazioneModificheDAL
    {

        //Operazioni

        //internal CompileIUCmd compila un command con i parametri per l'insert o l'update
        protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, DecretiXDomPagEsportazioneModifiche DecretiXDomPagEsportazioneModificheObj, string firstChar)
        {
            if (forUpdate)
            {
                // campi identity valorizzati solo per l'update
                DbProvider.SetCmdParam(cmd, firstChar + "Id", DecretiXDomPagEsportazioneModificheObj.Id);
                // altri campi sempre valorizzati
            }
            DbProvider.SetCmdParam(cmd, firstChar + "IdDecretiXDomPagEsportazione", DecretiXDomPagEsportazioneModificheObj.IdDecretiXDomPagEsportazione);
            DbProvider.SetCmdParam(cmd, firstChar + "IdDomandaPagamento", DecretiXDomPagEsportazioneModificheObj.IdDomandaPagamento);
            DbProvider.SetCmdParam(cmd, firstChar + "IdProgetto", DecretiXDomPagEsportazioneModificheObj.IdProgetto);
            DbProvider.SetCmdParam(cmd, firstChar + "IdDecreto", DecretiXDomPagEsportazioneModificheObj.IdDecreto);
            DbProvider.SetCmdParam(cmd, firstChar + "Importo", DecretiXDomPagEsportazioneModificheObj.Importo);
            DbProvider.SetCmdParam(cmd, firstChar + "DataInserimento", DecretiXDomPagEsportazioneModificheObj.DataInserimento);
            DbProvider.SetCmdParam(cmd, firstChar + "DataModifica", DecretiXDomPagEsportazioneModificheObj.DataModifica);
            DbProvider.SetCmdParam(cmd, firstChar + "IdAtto", DecretiXDomPagEsportazioneModificheObj.IdAtto);
            DbProvider.SetCmdParam(cmd, firstChar + "Numero", DecretiXDomPagEsportazioneModificheObj.Numero);
            DbProvider.SetCmdParam(cmd, firstChar + "Data", DecretiXDomPagEsportazioneModificheObj.Data);
            DbProvider.SetCmdParam(cmd, firstChar + "Descrizione", DecretiXDomPagEsportazioneModificheObj.Descrizione);
            DbProvider.SetCmdParam(cmd, firstChar + "Servizio", DecretiXDomPagEsportazioneModificheObj.Servizio);
            DbProvider.SetCmdParam(cmd, firstChar + "Registro", DecretiXDomPagEsportazioneModificheObj.Registro);
            DbProvider.SetCmdParam(cmd, firstChar + "CodTipo", DecretiXDomPagEsportazioneModificheObj.CodTipo);
            DbProvider.SetCmdParam(cmd, firstChar + "CodDefinizione", DecretiXDomPagEsportazioneModificheObj.CodDefinizione);
            DbProvider.SetCmdParam(cmd, firstChar + "CodOrganoIstituzionale", DecretiXDomPagEsportazioneModificheObj.CodOrganoIstituzionale);
            DbProvider.SetCmdParam(cmd, firstChar + "DataBur", DecretiXDomPagEsportazioneModificheObj.DataBur);
            DbProvider.SetCmdParam(cmd, firstChar + "NumeroBur", DecretiXDomPagEsportazioneModificheObj.NumeroBur);
            DbProvider.SetCmdParam(cmd, firstChar + "AwDocnumber", DecretiXDomPagEsportazioneModificheObj.AwDocnumber);
            DbProvider.SetCmdParam(cmd, firstChar + "AwDocnumberNuovo", DecretiXDomPagEsportazioneModificheObj.AwDocnumberNuovo);
            DbProvider.SetCmdParam(cmd, firstChar + "DefinizioneAtto", DecretiXDomPagEsportazioneModificheObj.DefinizioneAtto);
            DbProvider.SetCmdParam(cmd, firstChar + "TipoAtto", DecretiXDomPagEsportazioneModificheObj.TipoAtto);
            DbProvider.SetCmdParam(cmd, firstChar + "OrganoIstituzionale", DecretiXDomPagEsportazioneModificheObj.OrganoIstituzionale);
            DbProvider.SetCmdParam(cmd, firstChar + "LinkEsterno", DecretiXDomPagEsportazioneModificheObj.LinkEsterno);
            DbProvider.SetCmdParam(cmd, firstChar + "IdModifica", DecretiXDomPagEsportazioneModificheObj.IdModifica);
        }
        //Insert
        private static int Insert(DbProvider db, DecretiXDomPagEsportazioneModifiche DecretiXDomPagEsportazioneModificheObj)
        {
            int i = 1;
            try
            {
                IDbCommand insertCmd = db.InitCmd("ZDecretiXDomPagEsportazioneModificheInsert", new string[] {"IdDecretiXDomPagEsportazione", "IdDomandaPagamento", "IdProgetto",
"IdDecreto", "Importo", "DataInserimento",
"DataModifica", "IdAtto", "Numero",
"Data", "Descrizione", "Servizio",
"Registro", "CodTipo", "CodDefinizione",
"CodOrganoIstituzionale", "DataBur", "NumeroBur",
"AwDocnumber", "AwDocnumberNuovo", "DefinizioneAtto",
"TipoAtto", "OrganoIstituzionale", "LinkEsterno",
"IdModifica"}, new string[] {"int", "int", "int",
"int", "decimal", "DateTime",
"DateTime", "int", "int",
"DateTime", "string", "string",
"string", "string", "string",
"string", "DateTime", "int",
"string", "int", "string",
"string", "string", "string",
"int"}, "");
                CompileIUCmd(false, insertCmd, DecretiXDomPagEsportazioneModificheObj, db.CommandFirstChar);
                db.InitDatareader(insertCmd);
                if (db.DataReader.Read())
                {
                    DecretiXDomPagEsportazioneModificheObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
                }
                DecretiXDomPagEsportazioneModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                DecretiXDomPagEsportazioneModificheObj.IsDirty = false;
                DecretiXDomPagEsportazioneModificheObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //update
        private static int Update(DbProvider db, DecretiXDomPagEsportazioneModifiche DecretiXDomPagEsportazioneModificheObj)
        {
            int i = 1;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZDecretiXDomPagEsportazioneModificheUpdate", new string[] {"IdDecretiXDomPagEsportazione", "IdDomandaPagamento", "IdProgetto",
"IdDecreto", "Importo", "DataInserimento",
"DataModifica", "IdAtto", "Numero",
"Data", "Descrizione", "Servizio",
"Registro", "CodTipo", "CodDefinizione",
"CodOrganoIstituzionale", "DataBur", "NumeroBur",
"AwDocnumber", "AwDocnumberNuovo", "DefinizioneAtto",
"TipoAtto", "OrganoIstituzionale", "LinkEsterno",
"Id", "IdModifica"}, new string[] {"int", "int", "int",
"int", "decimal", "DateTime",
"DateTime", "int", "int",
"DateTime", "string", "string",
"string", "string", "string",
"string", "DateTime", "int",
"string", "int", "string",
"string", "string", "string",
"int", "int"}, "");
                CompileIUCmd(true, updateCmd, DecretiXDomPagEsportazioneModificheObj, db.CommandFirstChar);
                SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
                if (d != null)
                {
                    i = 1;
                    DecretiXDomPagEsportazioneModificheObj.DataModifica = d;
                }
                DecretiXDomPagEsportazioneModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                DecretiXDomPagEsportazioneModificheObj.IsDirty = false;
                DecretiXDomPagEsportazioneModificheObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //Save
        public static int Save(DbProvider db, DecretiXDomPagEsportazioneModifiche DecretiXDomPagEsportazioneModificheObj)
        {
            switch (DecretiXDomPagEsportazioneModificheObj.ObjectState)
            {
                case BaseObject.ObjectStateType.Added: return Insert(db, DecretiXDomPagEsportazioneModificheObj);
                case BaseObject.ObjectStateType.Changed: return Update(db, DecretiXDomPagEsportazioneModificheObj);
                case BaseObject.ObjectStateType.Deleted: return Delete(db, DecretiXDomPagEsportazioneModificheObj);
                default: return 0;
            }
        }

        public static int SaveCollection(DbProvider db, DecretiXDomPagEsportazioneModificheCollection DecretiXDomPagEsportazioneModificheCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZDecretiXDomPagEsportazioneModificheUpdate", new string[] {"IdDecretiXDomPagEsportazione", "IdDomandaPagamento", "IdProgetto",
"IdDecreto", "Importo", "DataInserimento",
"DataModifica", "IdAtto", "Numero",
"Data", "Descrizione", "Servizio",
"Registro", "CodTipo", "CodDefinizione",
"CodOrganoIstituzionale", "DataBur", "NumeroBur",
"AwDocnumber", "AwDocnumberNuovo", "DefinizioneAtto",
"TipoAtto", "OrganoIstituzionale", "LinkEsterno",
"Id", "IdModifica"}, new string[] {"int", "int", "int",
"int", "decimal", "DateTime",
"DateTime", "int", "int",
"DateTime", "string", "string",
"string", "string", "string",
"string", "DateTime", "int",
"string", "int", "string",
"string", "string", "string",
"int", "int"}, "");
                IDbCommand insertCmd = db.InitCmd("ZDecretiXDomPagEsportazioneModificheInsert", new string[] {"IdDecretiXDomPagEsportazione", "IdDomandaPagamento", "IdProgetto",
"IdDecreto", "Importo", "DataInserimento",
"DataModifica", "IdAtto", "Numero",
"Data", "Descrizione", "Servizio",
"Registro", "CodTipo", "CodDefinizione",
"CodOrganoIstituzionale", "DataBur", "NumeroBur",
"AwDocnumber", "AwDocnumberNuovo", "DefinizioneAtto",
"TipoAtto", "OrganoIstituzionale", "LinkEsterno",
"IdModifica"}, new string[] {"int", "int", "int",
"int", "decimal", "DateTime",
"DateTime", "int", "int",
"DateTime", "string", "string",
"string", "string", "string",
"string", "DateTime", "int",
"string", "int", "string",
"string", "string", "string",
"int"}, "");
                IDbCommand deleteCmd = db.InitCmd("ZDecretiXDomPagEsportazioneModificheDelete", new string[] { "Id" }, new string[] { "int" }, "");
                for (int i = 0; i < DecretiXDomPagEsportazioneModificheCollectionObj.Count; i++)
                {
                    switch (DecretiXDomPagEsportazioneModificheCollectionObj[i].ObjectState)
                    {
                        case BaseObject.ObjectStateType.Added:
                            {
                                CompileIUCmd(false, insertCmd, DecretiXDomPagEsportazioneModificheCollectionObj[i], db.CommandFirstChar);
                                db.InitDatareader(insertCmd);
                                if (db.DataReader.Read())
                                {
                                    DecretiXDomPagEsportazioneModificheCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
                                }
                                db.DataReader.Close();
                                returnValue++;
                            }
                            break;
                        case BaseObject.ObjectStateType.Changed:
                            {
                                CompileIUCmd(true, updateCmd, DecretiXDomPagEsportazioneModificheCollectionObj[i], db.CommandFirstChar);
                                SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
                                if (d != null)
                                {
                                    returnValue++;
                                    DecretiXDomPagEsportazioneModificheCollectionObj[i].DataModifica = d;
                                }
                            }
                            break;
                        case BaseObject.ObjectStateType.Deleted:
                            {
                                if (DecretiXDomPagEsportazioneModificheCollectionObj[i].IsPersistent)
                                {
                                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)DecretiXDomPagEsportazioneModificheCollectionObj[i].Id);
                                    returnValue = returnValue + db.Execute(deleteCmd);
                                }
                            }
                            break;
                    }
                }
                db.Commit();
                for (int i = 0; i < DecretiXDomPagEsportazioneModificheCollectionObj.Count; i++)
                {
                    if ((DecretiXDomPagEsportazioneModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (DecretiXDomPagEsportazioneModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        DecretiXDomPagEsportazioneModificheCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
                        DecretiXDomPagEsportazioneModificheCollectionObj[i].IsDirty = false;
                        DecretiXDomPagEsportazioneModificheCollectionObj[i].IsPersistent = true;
                    }
                    if ((DecretiXDomPagEsportazioneModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
                    {
                        DecretiXDomPagEsportazioneModificheCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        DecretiXDomPagEsportazioneModificheCollectionObj[i].IsDirty = false;
                        DecretiXDomPagEsportazioneModificheCollectionObj[i].IsPersistent = false;
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
        public static int Delete(DbProvider db, DecretiXDomPagEsportazioneModifiche DecretiXDomPagEsportazioneModificheObj)
        {
            int returnValue = 0;
            if (DecretiXDomPagEsportazioneModificheObj.IsPersistent)
            {
                returnValue = Delete(db, DecretiXDomPagEsportazioneModificheObj.Id);
            }
            DecretiXDomPagEsportazioneModificheObj.ObjectState = BaseObject.ObjectStateType.Deleted;
            DecretiXDomPagEsportazioneModificheObj.IsDirty = false;
            DecretiXDomPagEsportazioneModificheObj.IsPersistent = false;
            return returnValue;
        }

        //Delete
        private static int Delete(DbProvider db, int IdValue)
        {
            int i = 1;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZDecretiXDomPagEsportazioneModificheDelete", new string[] { "Id" }, new string[] { "int" }, "");
                DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
                i = db.Execute(deleteCmd);
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        public static int DeleteCollection(DbProvider db, DecretiXDomPagEsportazioneModificheCollection DecretiXDomPagEsportazioneModificheCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZDecretiXDomPagEsportazioneModificheDelete", new string[] { "Id" }, new string[] { "int" }, "");
                for (int i = 0; i < DecretiXDomPagEsportazioneModificheCollectionObj.Count; i++)
                {
                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "Id", DecretiXDomPagEsportazioneModificheCollectionObj[i].Id);
                    returnValue = returnValue + db.Execute(deleteCmd);
                }
                db.Commit();
                for (int i = 0; i < DecretiXDomPagEsportazioneModificheCollectionObj.Count; i++)
                {
                    if ((DecretiXDomPagEsportazioneModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (DecretiXDomPagEsportazioneModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        DecretiXDomPagEsportazioneModificheCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        DecretiXDomPagEsportazioneModificheCollectionObj[i].IsDirty = false;
                        DecretiXDomPagEsportazioneModificheCollectionObj[i].IsPersistent = false;
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
        public static DecretiXDomPagEsportazioneModifiche GetById(DbProvider db, int IdValue)
        {
            DecretiXDomPagEsportazioneModifiche DecretiXDomPagEsportazioneModificheObj = null;
            IDbCommand readCmd = db.InitCmd("ZDecretiXDomPagEsportazioneModificheGetById", new string[] { "Id" }, new string[] { "int" }, "");
            DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
            db.InitDatareader(readCmd);
            if (db.DataReader.Read())
            {
                DecretiXDomPagEsportazioneModificheObj = GetFromDatareader(db);
                DecretiXDomPagEsportazioneModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                DecretiXDomPagEsportazioneModificheObj.IsDirty = false;
                DecretiXDomPagEsportazioneModificheObj.IsPersistent = true;
            }
            db.Close();
            return DecretiXDomPagEsportazioneModificheObj;
        }

        //getFromDatareader
        public static DecretiXDomPagEsportazioneModifiche GetFromDatareader(DbProvider db)
        {
            DecretiXDomPagEsportazioneModifiche DecretiXDomPagEsportazioneModificheObj = new DecretiXDomPagEsportazioneModifiche();
            DecretiXDomPagEsportazioneModificheObj.IdDecretiXDomPagEsportazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DECRETI_X_DOM_PAG_ESPORTAZIONE"]);
            DecretiXDomPagEsportazioneModificheObj.IdDomandaPagamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA_PAGAMENTO"]);
            DecretiXDomPagEsportazioneModificheObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
            DecretiXDomPagEsportazioneModificheObj.IdDecreto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DECRETO"]);
            DecretiXDomPagEsportazioneModificheObj.Importo = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO"]);
            DecretiXDomPagEsportazioneModificheObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
            DecretiXDomPagEsportazioneModificheObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
            DecretiXDomPagEsportazioneModificheObj.IdAtto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ATTO"]);
            DecretiXDomPagEsportazioneModificheObj.Numero = new SiarLibrary.NullTypes.IntNT(db.DataReader["NUMERO"]);
            DecretiXDomPagEsportazioneModificheObj.Data = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA"]);
            DecretiXDomPagEsportazioneModificheObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
            DecretiXDomPagEsportazioneModificheObj.Servizio = new SiarLibrary.NullTypes.StringNT(db.DataReader["SERVIZIO"]);
            DecretiXDomPagEsportazioneModificheObj.Registro = new SiarLibrary.NullTypes.StringNT(db.DataReader["REGISTRO"]);
            DecretiXDomPagEsportazioneModificheObj.CodTipo = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO"]);
            DecretiXDomPagEsportazioneModificheObj.CodDefinizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_DEFINIZIONE"]);
            DecretiXDomPagEsportazioneModificheObj.CodOrganoIstituzionale = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_ORGANO_ISTITUZIONALE"]);
            DecretiXDomPagEsportazioneModificheObj.DataBur = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_BUR"]);
            DecretiXDomPagEsportazioneModificheObj.NumeroBur = new SiarLibrary.NullTypes.IntNT(db.DataReader["NUMERO_BUR"]);
            DecretiXDomPagEsportazioneModificheObj.AwDocnumber = new SiarLibrary.NullTypes.StringNT(db.DataReader["AW_DOCNUMBER"]);
            DecretiXDomPagEsportazioneModificheObj.AwDocnumberNuovo = new SiarLibrary.NullTypes.IntNT(db.DataReader["AW_DOCNUMBER_NUOVO"]);
            DecretiXDomPagEsportazioneModificheObj.DefinizioneAtto = new SiarLibrary.NullTypes.StringNT(db.DataReader["DEFINIZIONE_ATTO"]);
            DecretiXDomPagEsportazioneModificheObj.TipoAtto = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO_ATTO"]);
            DecretiXDomPagEsportazioneModificheObj.OrganoIstituzionale = new SiarLibrary.NullTypes.StringNT(db.DataReader["ORGANO_ISTITUZIONALE"]);
            DecretiXDomPagEsportazioneModificheObj.LinkEsterno = new SiarLibrary.NullTypes.StringNT(db.DataReader["LINK_ESTERNO"]);
            DecretiXDomPagEsportazioneModificheObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
            DecretiXDomPagEsportazioneModificheObj.IdModifica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_MODIFICA"]);
            DecretiXDomPagEsportazioneModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            DecretiXDomPagEsportazioneModificheObj.IsDirty = false;
            DecretiXDomPagEsportazioneModificheObj.IsPersistent = true;
            return DecretiXDomPagEsportazioneModificheObj;
        }

        //Find Select

        public static DecretiXDomPagEsportazioneModificheCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdDecretiXDomPagEsportazioneEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis,
SiarLibrary.NullTypes.IntNT IdDecretoEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis,
SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis, SiarLibrary.NullTypes.IntNT IdAttoEqualThis, SiarLibrary.NullTypes.IntNT NumeroEqualThis,
SiarLibrary.NullTypes.DatetimeNT DataEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, SiarLibrary.NullTypes.StringNT ServizioEqualThis,
SiarLibrary.NullTypes.StringNT RegistroEqualThis, SiarLibrary.NullTypes.StringNT CodTipoEqualThis, SiarLibrary.NullTypes.StringNT CodDefinizioneEqualThis,
SiarLibrary.NullTypes.StringNT CodOrganoIstituzionaleEqualThis, SiarLibrary.NullTypes.DatetimeNT DataBurEqualThis, SiarLibrary.NullTypes.IntNT NumeroBurEqualThis,
SiarLibrary.NullTypes.StringNT AwDocnumberEqualThis, SiarLibrary.NullTypes.IntNT AwDocnumberNuovoEqualThis, SiarLibrary.NullTypes.StringNT DefinizioneAttoEqualThis,
SiarLibrary.NullTypes.StringNT TipoAttoEqualThis, SiarLibrary.NullTypes.StringNT OrganoIstituzionaleEqualThis, SiarLibrary.NullTypes.StringNT LinkEsternoEqualThis,
SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.IntNT IdModificaEqualThis)

        {

            DecretiXDomPagEsportazioneModificheCollection DecretiXDomPagEsportazioneModificheCollectionObj = new DecretiXDomPagEsportazioneModificheCollection();

            IDbCommand findCmd = db.InitCmd("Zdecretixdompagesportazionemodifichefindselect", new string[] {"IdDecretiXDomPagEsportazioneequalthis", "IdDomandaPagamentoequalthis", "IdProgettoequalthis",
"IdDecretoequalthis", "Importoequalthis", "DataInserimentoequalthis",
"DataModificaequalthis", "IdAttoequalthis", "Numeroequalthis",
"Dataequalthis", "Descrizioneequalthis", "Servizioequalthis",
"Registroequalthis", "CodTipoequalthis", "CodDefinizioneequalthis",
"CodOrganoIstituzionaleequalthis", "DataBurequalthis", "NumeroBurequalthis",
"AwDocnumberequalthis", "AwDocnumberNuovoequalthis", "DefinizioneAttoequalthis",
"TipoAttoequalthis", "OrganoIstituzionaleequalthis", "LinkEsternoequalthis",
"Idequalthis", "IdModificaequalthis"}, new string[] {"int", "int", "int",
"int", "decimal", "DateTime",
"DateTime", "int", "int",
"DateTime", "string", "string",
"string", "string", "string",
"string", "DateTime", "int",
"string", "int", "string",
"string", "string", "string",
"int", "int"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdDecretiXDomPagEsportazioneequalthis", IdDecretiXDomPagEsportazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdDecretoequalthis", IdDecretoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Importoequalthis", ImportoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdAttoequalthis", IdAttoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Numeroequalthis", NumeroEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Dataequalthis", DataEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Servizioequalthis", ServizioEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Registroequalthis", RegistroEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodTipoequalthis", CodTipoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodDefinizioneequalthis", CodDefinizioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodOrganoIstituzionaleequalthis", CodOrganoIstituzionaleEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataBurequalthis", DataBurEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "NumeroBurequalthis", NumeroBurEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "AwDocnumberequalthis", AwDocnumberEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "AwDocnumberNuovoequalthis", AwDocnumberNuovoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DefinizioneAttoequalthis", DefinizioneAttoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "TipoAttoequalthis", TipoAttoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "OrganoIstituzionaleequalthis", OrganoIstituzionaleEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "LinkEsternoequalthis", LinkEsternoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Idequalthis", IdEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdModificaequalthis", IdModificaEqualThis);
            DecretiXDomPagEsportazioneModifiche DecretiXDomPagEsportazioneModificheObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                DecretiXDomPagEsportazioneModificheObj = GetFromDatareader(db);
                DecretiXDomPagEsportazioneModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                DecretiXDomPagEsportazioneModificheObj.IsDirty = false;
                DecretiXDomPagEsportazioneModificheObj.IsPersistent = true;
                DecretiXDomPagEsportazioneModificheCollectionObj.Add(DecretiXDomPagEsportazioneModificheObj);
            }
            db.Close();
            return DecretiXDomPagEsportazioneModificheCollectionObj;
        }

    }
}


namespace SiarBLL
{

    /// <summary>
    /// Summary description for DecretiXDomPagEsportazioneModificheCollectionProvider:IDecretiXDomPagEsportazioneModificheProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class DecretiXDomPagEsportazioneModificheCollectionProvider : IDecretiXDomPagEsportazioneModificheProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di DecretiXDomPagEsportazioneModifiche
        protected DecretiXDomPagEsportazioneModificheCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public DecretiXDomPagEsportazioneModificheCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new DecretiXDomPagEsportazioneModificheCollection(this);
        }

        //Costruttore3: ha in input decretixdompagesportazionemodificheCollectionObj - non popola la collection
        public DecretiXDomPagEsportazioneModificheCollectionProvider(DecretiXDomPagEsportazioneModificheCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public DecretiXDomPagEsportazioneModificheCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new DecretiXDomPagEsportazioneModificheCollection(this);
        }

        //Get e Set
        public DecretiXDomPagEsportazioneModificheCollection CollectionObj
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
        public int SaveCollection(DecretiXDomPagEsportazioneModificheCollection collectionObj)
        {
            return DecretiXDomPagEsportazioneModificheDAL.SaveCollection(_dbProviderObj, collectionObj);
        }

        //Save3: registra l'elemento i-esimo della collection
        public int Save(int i)
        {
            return Save(_CollectionObj[i]);
        }

        //Save4: registra un elemento singolo
        public int Save(DecretiXDomPagEsportazioneModifiche decretixdompagesportazionemodificheObj)
        {
            return DecretiXDomPagEsportazioneModificheDAL.Save(_dbProviderObj, decretixdompagesportazionemodificheObj);
        }

        //delete1: elimina l'intera collection
        public int DeleteCollection()
        {
            return DeleteCollection(_CollectionObj);
        }

        //delete2: elimina una collection
        public int DeleteCollection(DecretiXDomPagEsportazioneModificheCollection collectionObj)
        {
            return DecretiXDomPagEsportazioneModificheDAL.DeleteCollection(_dbProviderObj, collectionObj);
        }

        //delete3: elimina l'elemento i-esimo della collection
        public int Delete(int i)
        {
            return Delete(_CollectionObj[i]);
        }

        //delete4: elimina un elemento singolo
        public int Delete(DecretiXDomPagEsportazioneModifiche decretixdompagesportazionemodificheObj)
        {
            return DecretiXDomPagEsportazioneModificheDAL.Delete(_dbProviderObj, decretixdompagesportazionemodificheObj);
        }

        //getById
        public DecretiXDomPagEsportazioneModifiche GetById(IntNT IdValue)
        {
            DecretiXDomPagEsportazioneModifiche DecretiXDomPagEsportazioneModificheTemp = DecretiXDomPagEsportazioneModificheDAL.GetById(_dbProviderObj, IdValue);
            if (DecretiXDomPagEsportazioneModificheTemp != null) DecretiXDomPagEsportazioneModificheTemp.Provider = this;
            return DecretiXDomPagEsportazioneModificheTemp;
        }

        //Select: popola la collection
        public DecretiXDomPagEsportazioneModificheCollection Select(IntNT IddecretixdompagesportazioneEqualThis, IntNT IddomandapagamentoEqualThis, IntNT IdprogettoEqualThis,
IntNT IddecretoEqualThis, DecimalNT ImportoEqualThis, DatetimeNT DatainserimentoEqualThis,
DatetimeNT DatamodificaEqualThis, IntNT IdattoEqualThis, IntNT NumeroEqualThis,
DatetimeNT DataEqualThis, StringNT DescrizioneEqualThis, StringNT ServizioEqualThis,
StringNT RegistroEqualThis, StringNT CodtipoEqualThis, StringNT CoddefinizioneEqualThis,
StringNT CodorganoistituzionaleEqualThis, DatetimeNT DataburEqualThis, IntNT NumeroburEqualThis,
StringNT AwdocnumberEqualThis, IntNT AwdocnumbernuovoEqualThis, StringNT DefinizioneattoEqualThis,
StringNT TipoattoEqualThis, StringNT OrganoistituzionaleEqualThis, StringNT LinkesternoEqualThis,
IntNT IdEqualThis, IntNT IdmodificaEqualThis)
        {
            DecretiXDomPagEsportazioneModificheCollection DecretiXDomPagEsportazioneModificheCollectionTemp = DecretiXDomPagEsportazioneModificheDAL.Select(_dbProviderObj, IddecretixdompagesportazioneEqualThis, IddomandapagamentoEqualThis, IdprogettoEqualThis,
IddecretoEqualThis, ImportoEqualThis, DatainserimentoEqualThis,
DatamodificaEqualThis, IdattoEqualThis, NumeroEqualThis,
DataEqualThis, DescrizioneEqualThis, ServizioEqualThis,
RegistroEqualThis, CodtipoEqualThis, CoddefinizioneEqualThis,
CodorganoistituzionaleEqualThis, DataburEqualThis, NumeroburEqualThis,
AwdocnumberEqualThis, AwdocnumbernuovoEqualThis, DefinizioneattoEqualThis,
TipoattoEqualThis, OrganoistituzionaleEqualThis, LinkesternoEqualThis,
IdEqualThis, IdmodificaEqualThis);
            DecretiXDomPagEsportazioneModificheCollectionTemp.Provider = this;
            return DecretiXDomPagEsportazioneModificheCollectionTemp;
        }


    }
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<DECRETI_X_DOM_PAG_ESPORTAZIONE_MODIFICHE>
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
</DECRETI_X_DOM_PAG_ESPORTAZIONE_MODIFICHE>
*/
