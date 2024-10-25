using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

    /// <summary>
    /// Summary description for Vcertrendicontazione
    /// Class Autogenerata
    /// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
    /// con delle partial class contenenti i metodi aggiunti, in questo modo 
    /// non verranno sovrascritti quando si rigenera la classe 
    /// </summary>

    [Serializable]
    [System.Xml.Serialization.XmlType(Namespace = "")]

    public partial class Vcertrendicontazione : BaseObject
    {

        //Definizione dei campi 'base'
        private NullTypes.StringNT _CodPsr;
        private NullTypes.IntNT _IdDomandaPagamento;
        private NullTypes.DatetimeNT _DataApprovazione;
        private NullTypes.DatetimeNT _DataVerdocum;
        private NullTypes.StringNT _AsseCodice;
        private NullTypes.IntNT _IdBando;
        private NullTypes.StringNT _Intervento;
        private NullTypes.StringNT _Azione;
        private NullTypes.IntNT _IdProgetto;
        private NullTypes.StringNT _CodiceCup;
        private NullTypes.IntNT _TipoOperazione;
        private NullTypes.StringNT _Stato;
        private NullTypes.IntNT _Comune;
        private NullTypes.DecimalNT _CostoTotale;
        private NullTypes.DecimalNT _ImportoAmmesso;
        private NullTypes.DecimalNT _ImportoConcesso;
        private NullTypes.IntNT _OperazioniBeneficiario;
        private NullTypes.IntNT _ContributoRichiesto;
        private NullTypes.StringNT _Beneficiario;
        private NullTypes.DecimalNT _SpesaAmmessa;
        private NullTypes.DecimalNT _ContributoConcesso;
        private NullTypes.DecimalNT _ImportoContributoPubblico;
        private NullTypes.DecimalNT _SpesaAmmessaIncrementale;
        private NullTypes.DecimalNT _ImportoContributoPubblicoIncrementale;
        private NullTypes.IntNT _ImportoLiquidato;
        private NullTypes.IntNT _OperazioneEsclusa;
        private NullTypes.IntNT _MotivoEsclusione;
        private NullTypes.BoolNT _DomandaPagamentoIstruita;
        private NullTypes.BoolNT _RdpApprovata;
        private NullTypes.BoolNT _InIntegrazione;
        private NullTypes.DecimalNT _ImportoPrivato;
        private NullTypes.DecimalNT _Percreal;
        private NullTypes.DecimalNT _Rischioir;
        private NullTypes.DecimalNT _Rischiocr;
        private NullTypes.StringNT _Rischio;
        private NullTypes.StringNT _DomandaTipo;


        //Costruttore
        public Vcertrendicontazione()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //Get e Set dei campi 'base'
        /// <summary>
        /// Corrisponde al campo:Cod_Psr
        /// Tipo sul db:VARCHAR(20)
        /// </summary>
        public NullTypes.StringNT CodPsr
        {
            get { return _CodPsr; }
            set
            {
                if (CodPsr != value)
                {
                    _CodPsr = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:Id_Domanda_Pagamento
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
        /// Corrisponde al campo:Data_Approvazione
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataApprovazione
        {
            get { return _DataApprovazione; }
            set
            {
                if (DataApprovazione != value)
                {
                    _DataApprovazione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:Data_VerDocum
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataVerdocum
        {
            get { return _DataVerdocum; }
            set
            {
                if (DataVerdocum != value)
                {
                    _DataVerdocum = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:Asse_Codice
        /// Tipo sul db:VARCHAR(20)
        /// </summary>
        public NullTypes.StringNT AsseCodice
        {
            get { return _AsseCodice; }
            set
            {
                if (AsseCodice != value)
                {
                    _AsseCodice = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:Id_Bando
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
        /// Corrisponde al campo:Intervento
        /// Tipo sul db:VARCHAR(20)
        /// </summary>
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

        /// <summary>
        /// Corrisponde al campo:Azione
        /// Tipo sul db:VARCHAR(20)
        /// </summary>
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

        /// <summary>
        /// Corrisponde al campo:Id_Progetto
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
        /// Corrisponde al campo:Codice_CUP
        /// Tipo sul db:VARCHAR(50)
        /// </summary>
        public NullTypes.StringNT CodiceCup
        {
            get { return _CodiceCup; }
            set
            {
                if (CodiceCup != value)
                {
                    _CodiceCup = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:Tipo_Operazione
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT TipoOperazione
        {
            get { return _TipoOperazione; }
            set
            {
                if (TipoOperazione != value)
                {
                    _TipoOperazione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:Stato
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
        /// Corrisponde al campo:Comune
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT Comune
        {
            get { return _Comune; }
            set
            {
                if (Comune != value)
                {
                    _Comune = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:Costo_Totale
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT CostoTotale
        {
            get { return _CostoTotale; }
            set
            {
                if (CostoTotale != value)
                {
                    _CostoTotale = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:Importo_Ammesso
        /// Tipo sul db:DECIMAL(19,2)
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
        /// Corrisponde al campo:Importo_Concesso
        /// Tipo sul db:DECIMAL(38,2)
        /// </summary>
        public NullTypes.DecimalNT ImportoConcesso
        {
            get { return _ImportoConcesso; }
            set
            {
                if (ImportoConcesso != value)
                {
                    _ImportoConcesso = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:Operazioni_Beneficiario
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT OperazioniBeneficiario
        {
            get { return _OperazioniBeneficiario; }
            set
            {
                if (OperazioniBeneficiario != value)
                {
                    _OperazioniBeneficiario = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:Contributo_Richiesto
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT ContributoRichiesto
        {
            get { return _ContributoRichiesto; }
            set
            {
                if (ContributoRichiesto != value)
                {
                    _ContributoRichiesto = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:Beneficiario
        /// Tipo sul db:VARCHAR(255)
        /// </summary>
        public NullTypes.StringNT Beneficiario
        {
            get { return _Beneficiario; }
            set
            {
                if (Beneficiario != value)
                {
                    _Beneficiario = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:Spesa_Ammessa
        /// Tipo sul db:DECIMAL(38,2)
        /// </summary>
        public NullTypes.DecimalNT SpesaAmmessa
        {
            get { return _SpesaAmmessa; }
            set
            {
                if (SpesaAmmessa != value)
                {
                    _SpesaAmmessa = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:Contributo_Concesso
        /// Tipo sul db:DECIMAL(38,2)
        /// </summary>
        public NullTypes.DecimalNT ContributoConcesso
        {
            get { return _ContributoConcesso; }
            set
            {
                if (ContributoConcesso != value)
                {
                    _ContributoConcesso = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:Importo_Contributo_Pubblico
        /// Tipo sul db:DECIMAL(38,2)
        /// </summary>
        public NullTypes.DecimalNT ImportoContributoPubblico
        {
            get { return _ImportoContributoPubblico; }
            set
            {
                if (ImportoContributoPubblico != value)
                {
                    _ImportoContributoPubblico = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:Spesa_Ammessa_Incrementale
        /// Tipo sul db:DECIMAL(38,2)
        /// </summary>
        public NullTypes.DecimalNT SpesaAmmessaIncrementale
        {
            get { return _SpesaAmmessaIncrementale; }
            set
            {
                if (SpesaAmmessaIncrementale != value)
                {
                    _SpesaAmmessaIncrementale = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:Importo_Contributo_Pubblico_Incrementale
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT ImportoContributoPubblicoIncrementale
        {
            get { return _ImportoContributoPubblicoIncrementale; }
            set
            {
                if (ImportoContributoPubblicoIncrementale != value)
                {
                    _ImportoContributoPubblicoIncrementale = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:Importo_Liquidato
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT ImportoLiquidato
        {
            get { return _ImportoLiquidato; }
            set
            {
                if (ImportoLiquidato != value)
                {
                    _ImportoLiquidato = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:Operazione_Esclusa
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT OperazioneEsclusa
        {
            get { return _OperazioneEsclusa; }
            set
            {
                if (OperazioneEsclusa != value)
                {
                    _OperazioneEsclusa = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:Motivo_Esclusione
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT MotivoEsclusione
        {
            get { return _MotivoEsclusione; }
            set
            {
                if (MotivoEsclusione != value)
                {
                    _MotivoEsclusione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:domanda_pagamento_istruita
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT DomandaPagamentoIstruita
        {
            get { return _DomandaPagamentoIstruita; }
            set
            {
                if (DomandaPagamentoIstruita != value)
                {
                    _DomandaPagamentoIstruita = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:rdp_approvata
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT RdpApprovata
        {
            get { return _RdpApprovata; }
            set
            {
                if (RdpApprovata != value)
                {
                    _RdpApprovata = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IN_INTEGRAZIONE
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT InIntegrazione
        {
            get { return _InIntegrazione; }
            set
            {
                if (InIntegrazione != value)
                {
                    _InIntegrazione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:Importo_Privato
        /// Tipo sul db:DECIMAL(38,2)
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

        /// <summary>
        /// Corrisponde al campo:PercReal
        /// Tipo sul db:DECIMAL(38,6)
        /// </summary>
        public NullTypes.DecimalNT Percreal
        {
            get { return _Percreal; }
            set
            {
                if (Percreal != value)
                {
                    _Percreal = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:RischioIR
        /// Tipo sul db:DECIMAL(5,2)
        /// </summary>
        public NullTypes.DecimalNT Rischioir
        {
            get { return _Rischioir; }
            set
            {
                if (Rischioir != value)
                {
                    _Rischioir = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:RischioCR
        /// Tipo sul db:DECIMAL(5,2)
        /// </summary>
        public NullTypes.DecimalNT Rischiocr
        {
            get { return _Rischiocr; }
            set
            {
                if (Rischiocr != value)
                {
                    _Rischiocr = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:Rischio
        /// Tipo sul db:VARCHAR(5)
        /// </summary>
        public NullTypes.StringNT Rischio
        {
            get { return _Rischio; }
            set
            {
                if (Rischio != value)
                {
                    _Rischio = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:Domanda_Tipo
        /// Tipo sul db:CHAR(3)
        /// </summary>
        public NullTypes.StringNT DomandaTipo
        {
            get { return _DomandaTipo; }
            set
            {
                if (DomandaTipo != value)
                {
                    _DomandaTipo = value;
                    SetDirtyFlag();
                }
            }
        }




    }
}

namespace SiarLibrary
{

    /// <summary>
    /// Summary description for VcertrendicontazioneCollection
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class VcertrendicontazioneCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
        private VcertrendicontazioneCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((Vcertrendicontazione)info.GetValue(i.ToString(), typeof(Vcertrendicontazione)));
            }
        }

        //Costruttore
        public VcertrendicontazioneCollection()
        {
            this.ItemType = typeof(Vcertrendicontazione);
        }

        //Get e Set
        public new Vcertrendicontazione this[int index]
        {
            get { return (Vcertrendicontazione)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new VcertrendicontazioneCollection GetChanges()
        {
            return (VcertrendicontazioneCollection)base.GetChanges();
        }

        //Add
        public int Add(Vcertrendicontazione VcertrendicontazioneObj)
        {
            return base.Add(VcertrendicontazioneObj);
        }

        //AddCollection
        public void AddCollection(VcertrendicontazioneCollection VcertrendicontazioneCollectionObj)
        {
            foreach (Vcertrendicontazione VcertrendicontazioneObj in VcertrendicontazioneCollectionObj)
                this.Add(VcertrendicontazioneObj);
        }

        //Insert
        public void Insert(int index, Vcertrendicontazione VcertrendicontazioneObj)
        {
            base.Insert(index, VcertrendicontazioneObj);
        }

        //filter: effettua una ricerca all'interno della collection
        // se il parametro di ricerca è null, prende tutto,
        // anche i record che hanno quel campo null
        // altrimenti scarta i record che hanno quel campo null ...
        // ...e confronta gli altri
        public VcertrendicontazioneCollection SubSelect(NullTypes.StringNT CodPsrEqualThis, NullTypes.IntNT IdDomandaPagamentoEqualThis, NullTypes.DatetimeNT DataApprovazioneEqualThis,
NullTypes.DatetimeNT DataVerdocumEqualThis, NullTypes.StringNT AsseCodiceEqualThis, NullTypes.IntNT IdBandoEqualThis,
NullTypes.StringNT InterventoEqualThis, NullTypes.StringNT AzioneEqualThis, NullTypes.IntNT IdProgettoEqualThis,
NullTypes.StringNT CodiceCupEqualThis, NullTypes.IntNT TipoOperazioneEqualThis, NullTypes.StringNT StatoEqualThis,
NullTypes.IntNT ComuneEqualThis, NullTypes.DecimalNT CostoTotaleEqualThis, NullTypes.DecimalNT ImportoAmmessoEqualThis,
NullTypes.DecimalNT ImportoConcessoEqualThis, NullTypes.IntNT OperazioniBeneficiarioEqualThis, NullTypes.IntNT ContributoRichiestoEqualThis,
NullTypes.StringNT BeneficiarioEqualThis, NullTypes.DecimalNT SpesaAmmessaEqualThis, NullTypes.DecimalNT ContributoConcessoEqualThis,
NullTypes.DecimalNT ImportoContributoPubblicoEqualThis, NullTypes.DecimalNT SpesaAmmessaIncrementaleEqualThis, NullTypes.DecimalNT ImportoContributoPubblicoIncrementaleEqualThis,
NullTypes.IntNT ImportoLiquidatoEqualThis, NullTypes.IntNT OperazioneEsclusaEqualThis, NullTypes.IntNT MotivoEsclusioneEqualThis,
NullTypes.BoolNT DomandaPagamentoIstruitaEqualThis, NullTypes.BoolNT RdpApprovataEqualThis, NullTypes.BoolNT InIntegrazioneEqualThis,
NullTypes.DecimalNT ImportoPrivatoEqualThis, NullTypes.DecimalNT PercrealEqualThis, NullTypes.DecimalNT RischioirEqualThis,
NullTypes.DecimalNT RischiocrEqualThis, NullTypes.StringNT RischioEqualThis, NullTypes.StringNT DomandaTipoEqualThis)
        {
            VcertrendicontazioneCollection VcertrendicontazioneCollectionTemp = new VcertrendicontazioneCollection();
            foreach (Vcertrendicontazione VcertrendicontazioneItem in this)
            {
                if (((CodPsrEqualThis == null) || ((VcertrendicontazioneItem.CodPsr != null) && (VcertrendicontazioneItem.CodPsr.Value == CodPsrEqualThis.Value))) && ((IdDomandaPagamentoEqualThis == null) || ((VcertrendicontazioneItem.IdDomandaPagamento != null) && (VcertrendicontazioneItem.IdDomandaPagamento.Value == IdDomandaPagamentoEqualThis.Value))) && ((DataApprovazioneEqualThis == null) || ((VcertrendicontazioneItem.DataApprovazione != null) && (VcertrendicontazioneItem.DataApprovazione.Value == DataApprovazioneEqualThis.Value))) &&
((DataVerdocumEqualThis == null) || ((VcertrendicontazioneItem.DataVerdocum != null) && (VcertrendicontazioneItem.DataVerdocum.Value == DataVerdocumEqualThis.Value))) && ((AsseCodiceEqualThis == null) || ((VcertrendicontazioneItem.AsseCodice != null) && (VcertrendicontazioneItem.AsseCodice.Value == AsseCodiceEqualThis.Value))) && ((IdBandoEqualThis == null) || ((VcertrendicontazioneItem.IdBando != null) && (VcertrendicontazioneItem.IdBando.Value == IdBandoEqualThis.Value))) &&
((InterventoEqualThis == null) || ((VcertrendicontazioneItem.Intervento != null) && (VcertrendicontazioneItem.Intervento.Value == InterventoEqualThis.Value))) && ((AzioneEqualThis == null) || ((VcertrendicontazioneItem.Azione != null) && (VcertrendicontazioneItem.Azione.Value == AzioneEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((VcertrendicontazioneItem.IdProgetto != null) && (VcertrendicontazioneItem.IdProgetto.Value == IdProgettoEqualThis.Value))) &&
((CodiceCupEqualThis == null) || ((VcertrendicontazioneItem.CodiceCup != null) && (VcertrendicontazioneItem.CodiceCup.Value == CodiceCupEqualThis.Value))) && ((TipoOperazioneEqualThis == null) || ((VcertrendicontazioneItem.TipoOperazione != null) && (VcertrendicontazioneItem.TipoOperazione.Value == TipoOperazioneEqualThis.Value))) && ((StatoEqualThis == null) || ((VcertrendicontazioneItem.Stato != null) && (VcertrendicontazioneItem.Stato.Value == StatoEqualThis.Value))) &&
((ComuneEqualThis == null) || ((VcertrendicontazioneItem.Comune != null) && (VcertrendicontazioneItem.Comune.Value == ComuneEqualThis.Value))) && ((CostoTotaleEqualThis == null) || ((VcertrendicontazioneItem.CostoTotale != null) && (VcertrendicontazioneItem.CostoTotale.Value == CostoTotaleEqualThis.Value))) && ((ImportoAmmessoEqualThis == null) || ((VcertrendicontazioneItem.ImportoAmmesso != null) && (VcertrendicontazioneItem.ImportoAmmesso.Value == ImportoAmmessoEqualThis.Value))) &&
((ImportoConcessoEqualThis == null) || ((VcertrendicontazioneItem.ImportoConcesso != null) && (VcertrendicontazioneItem.ImportoConcesso.Value == ImportoConcessoEqualThis.Value))) && ((OperazioniBeneficiarioEqualThis == null) || ((VcertrendicontazioneItem.OperazioniBeneficiario != null) && (VcertrendicontazioneItem.OperazioniBeneficiario.Value == OperazioniBeneficiarioEqualThis.Value))) && ((ContributoRichiestoEqualThis == null) || ((VcertrendicontazioneItem.ContributoRichiesto != null) && (VcertrendicontazioneItem.ContributoRichiesto.Value == ContributoRichiestoEqualThis.Value))) &&
((BeneficiarioEqualThis == null) || ((VcertrendicontazioneItem.Beneficiario != null) && (VcertrendicontazioneItem.Beneficiario.Value == BeneficiarioEqualThis.Value))) && ((SpesaAmmessaEqualThis == null) || ((VcertrendicontazioneItem.SpesaAmmessa != null) && (VcertrendicontazioneItem.SpesaAmmessa.Value == SpesaAmmessaEqualThis.Value))) && ((ContributoConcessoEqualThis == null) || ((VcertrendicontazioneItem.ContributoConcesso != null) && (VcertrendicontazioneItem.ContributoConcesso.Value == ContributoConcessoEqualThis.Value))) &&
((ImportoContributoPubblicoEqualThis == null) || ((VcertrendicontazioneItem.ImportoContributoPubblico != null) && (VcertrendicontazioneItem.ImportoContributoPubblico.Value == ImportoContributoPubblicoEqualThis.Value))) && ((SpesaAmmessaIncrementaleEqualThis == null) || ((VcertrendicontazioneItem.SpesaAmmessaIncrementale != null) && (VcertrendicontazioneItem.SpesaAmmessaIncrementale.Value == SpesaAmmessaIncrementaleEqualThis.Value))) && ((ImportoContributoPubblicoIncrementaleEqualThis == null) || ((VcertrendicontazioneItem.ImportoContributoPubblicoIncrementale != null) && (VcertrendicontazioneItem.ImportoContributoPubblicoIncrementale.Value == ImportoContributoPubblicoIncrementaleEqualThis.Value))) &&
((ImportoLiquidatoEqualThis == null) || ((VcertrendicontazioneItem.ImportoLiquidato != null) && (VcertrendicontazioneItem.ImportoLiquidato.Value == ImportoLiquidatoEqualThis.Value))) && ((OperazioneEsclusaEqualThis == null) || ((VcertrendicontazioneItem.OperazioneEsclusa != null) && (VcertrendicontazioneItem.OperazioneEsclusa.Value == OperazioneEsclusaEqualThis.Value))) && ((MotivoEsclusioneEqualThis == null) || ((VcertrendicontazioneItem.MotivoEsclusione != null) && (VcertrendicontazioneItem.MotivoEsclusione.Value == MotivoEsclusioneEqualThis.Value))) &&
((DomandaPagamentoIstruitaEqualThis == null) || ((VcertrendicontazioneItem.DomandaPagamentoIstruita != null) && (VcertrendicontazioneItem.DomandaPagamentoIstruita.Value == DomandaPagamentoIstruitaEqualThis.Value))) && ((RdpApprovataEqualThis == null) || ((VcertrendicontazioneItem.RdpApprovata != null) && (VcertrendicontazioneItem.RdpApprovata.Value == RdpApprovataEqualThis.Value))) && ((InIntegrazioneEqualThis == null) || ((VcertrendicontazioneItem.InIntegrazione != null) && (VcertrendicontazioneItem.InIntegrazione.Value == InIntegrazioneEqualThis.Value))) &&
((ImportoPrivatoEqualThis == null) || ((VcertrendicontazioneItem.ImportoPrivato != null) && (VcertrendicontazioneItem.ImportoPrivato.Value == ImportoPrivatoEqualThis.Value))) && ((PercrealEqualThis == null) || ((VcertrendicontazioneItem.Percreal != null) && (VcertrendicontazioneItem.Percreal.Value == PercrealEqualThis.Value))) && ((RischioirEqualThis == null) || ((VcertrendicontazioneItem.Rischioir != null) && (VcertrendicontazioneItem.Rischioir.Value == RischioirEqualThis.Value))) &&
((RischiocrEqualThis == null) || ((VcertrendicontazioneItem.Rischiocr != null) && (VcertrendicontazioneItem.Rischiocr.Value == RischiocrEqualThis.Value))) && ((RischioEqualThis == null) || ((VcertrendicontazioneItem.Rischio != null) && (VcertrendicontazioneItem.Rischio.Value == RischioEqualThis.Value))) && ((DomandaTipoEqualThis == null) || ((VcertrendicontazioneItem.DomandaTipo != null) && (VcertrendicontazioneItem.DomandaTipo.Value == DomandaTipoEqualThis.Value))))
                {
                    VcertrendicontazioneCollectionTemp.Add(VcertrendicontazioneItem);
                }
            }
            return VcertrendicontazioneCollectionTemp;
        }



    }
}

namespace SiarDAL
{

    /// <summary>
    /// Summary description for VcertrendicontazioneDAL
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>


    internal class VcertrendicontazioneDAL
    {

        //Operazioni

        //getFromDatareader
        public static Vcertrendicontazione GetFromDatareader(DbProvider db)
        {
            Vcertrendicontazione VcertrendicontazioneObj = new Vcertrendicontazione();
            VcertrendicontazioneObj.CodPsr = new SiarLibrary.NullTypes.StringNT(db.DataReader["Cod_Psr"]);
            VcertrendicontazioneObj.IdDomandaPagamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["Id_Domanda_Pagamento"]);
            VcertrendicontazioneObj.DataApprovazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["Data_Approvazione"]);
            VcertrendicontazioneObj.DataVerdocum = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["Data_VerDocum"]);
            VcertrendicontazioneObj.AsseCodice = new SiarLibrary.NullTypes.StringNT(db.DataReader["Asse_Codice"]);
            VcertrendicontazioneObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["Id_Bando"]);
            VcertrendicontazioneObj.Intervento = new SiarLibrary.NullTypes.StringNT(db.DataReader["Intervento"]);
            VcertrendicontazioneObj.Azione = new SiarLibrary.NullTypes.StringNT(db.DataReader["Azione"]);
            VcertrendicontazioneObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["Id_Progetto"]);
            VcertrendicontazioneObj.CodiceCup = new SiarLibrary.NullTypes.StringNT(db.DataReader["Codice_CUP"]);
            VcertrendicontazioneObj.TipoOperazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["Tipo_Operazione"]);
            VcertrendicontazioneObj.Stato = new SiarLibrary.NullTypes.StringNT(db.DataReader["Stato"]);
            VcertrendicontazioneObj.Comune = new SiarLibrary.NullTypes.IntNT(db.DataReader["Comune"]);
            VcertrendicontazioneObj.CostoTotale = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["Costo_Totale"]);
            VcertrendicontazioneObj.ImportoAmmesso = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["Importo_Ammesso"]);
            VcertrendicontazioneObj.ImportoConcesso = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["Importo_Concesso"]);
            VcertrendicontazioneObj.OperazioniBeneficiario = new SiarLibrary.NullTypes.IntNT(db.DataReader["Operazioni_Beneficiario"]);
            VcertrendicontazioneObj.ContributoRichiesto = new SiarLibrary.NullTypes.IntNT(db.DataReader["Contributo_Richiesto"]);
            VcertrendicontazioneObj.Beneficiario = new SiarLibrary.NullTypes.StringNT(db.DataReader["Beneficiario"]);
            VcertrendicontazioneObj.SpesaAmmessa = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["Spesa_Ammessa"]);
            VcertrendicontazioneObj.ContributoConcesso = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["Contributo_Concesso"]);
            VcertrendicontazioneObj.ImportoContributoPubblico = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["Importo_Contributo_Pubblico"]);
            VcertrendicontazioneObj.SpesaAmmessaIncrementale = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["Spesa_Ammessa_Incrementale"]);
            VcertrendicontazioneObj.ImportoContributoPubblicoIncrementale = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["Importo_Contributo_Pubblico_Incrementale"]);
            VcertrendicontazioneObj.ImportoLiquidato = new SiarLibrary.NullTypes.IntNT(db.DataReader["Importo_Liquidato"]);
            VcertrendicontazioneObj.OperazioneEsclusa = new SiarLibrary.NullTypes.IntNT(db.DataReader["Operazione_Esclusa"]);
            VcertrendicontazioneObj.MotivoEsclusione = new SiarLibrary.NullTypes.IntNT(db.DataReader["Motivo_Esclusione"]);
            VcertrendicontazioneObj.DomandaPagamentoIstruita = new SiarLibrary.NullTypes.BoolNT(db.DataReader["domanda_pagamento_istruita"]);
            VcertrendicontazioneObj.RdpApprovata = new SiarLibrary.NullTypes.BoolNT(db.DataReader["rdp_approvata"]);
            VcertrendicontazioneObj.InIntegrazione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["IN_INTEGRAZIONE"]);
            VcertrendicontazioneObj.ImportoPrivato = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["Importo_Privato"]);
            VcertrendicontazioneObj.Percreal = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["PercReal"]);
            VcertrendicontazioneObj.Rischioir = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["RischioIR"]);
            VcertrendicontazioneObj.Rischiocr = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["RischioCR"]);
            VcertrendicontazioneObj.Rischio = new SiarLibrary.NullTypes.StringNT(db.DataReader["Rischio"]);
            VcertrendicontazioneObj.DomandaTipo = new SiarLibrary.NullTypes.StringNT(db.DataReader["Domanda_Tipo"]);
            VcertrendicontazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            VcertrendicontazioneObj.IsDirty = false;
            VcertrendicontazioneObj.IsPersistent = true;
            return VcertrendicontazioneObj;
        }

        //Find Select

        public static VcertrendicontazioneCollection Select(DbProvider db, SiarLibrary.NullTypes.StringNT CodPsrEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataApprovazioneEqualThis,
SiarLibrary.NullTypes.DatetimeNT DataVerdocumEqualThis, SiarLibrary.NullTypes.StringNT AsseCodiceEqualThis, SiarLibrary.NullTypes.IntNT IdBandoEqualThis,
SiarLibrary.NullTypes.StringNT InterventoEqualThis, SiarLibrary.NullTypes.StringNT AzioneEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis,
SiarLibrary.NullTypes.StringNT CodiceCupEqualThis, SiarLibrary.NullTypes.IntNT TipoOperazioneEqualThis, SiarLibrary.NullTypes.StringNT StatoEqualThis,
SiarLibrary.NullTypes.IntNT ComuneEqualThis, SiarLibrary.NullTypes.DecimalNT CostoTotaleEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoAmmessoEqualThis,
SiarLibrary.NullTypes.DecimalNT ImportoConcessoEqualThis, SiarLibrary.NullTypes.IntNT OperazioniBeneficiarioEqualThis, SiarLibrary.NullTypes.IntNT ContributoRichiestoEqualThis,
SiarLibrary.NullTypes.StringNT BeneficiarioEqualThis, SiarLibrary.NullTypes.DecimalNT SpesaAmmessaEqualThis, SiarLibrary.NullTypes.DecimalNT ContributoConcessoEqualThis,
SiarLibrary.NullTypes.DecimalNT ImportoContributoPubblicoEqualThis, SiarLibrary.NullTypes.DecimalNT SpesaAmmessaIncrementaleEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoContributoPubblicoIncrementaleEqualThis,
SiarLibrary.NullTypes.IntNT ImportoLiquidatoEqualThis, SiarLibrary.NullTypes.IntNT OperazioneEsclusaEqualThis, SiarLibrary.NullTypes.IntNT MotivoEsclusioneEqualThis,
SiarLibrary.NullTypes.BoolNT DomandaPagamentoIstruitaEqualThis, SiarLibrary.NullTypes.BoolNT RdpApprovataEqualThis, SiarLibrary.NullTypes.BoolNT InIntegrazioneEqualThis,
SiarLibrary.NullTypes.DecimalNT ImportoPrivatoEqualThis, SiarLibrary.NullTypes.DecimalNT PercrealEqualThis, SiarLibrary.NullTypes.DecimalNT RischioirEqualThis,
SiarLibrary.NullTypes.DecimalNT RischiocrEqualThis, SiarLibrary.NullTypes.StringNT RischioEqualThis, SiarLibrary.NullTypes.StringNT DomandaTipoEqualThis)

        {

            VcertrendicontazioneCollection VcertrendicontazioneCollectionObj = new VcertrendicontazioneCollection();

            IDbCommand findCmd = db.InitCmd("Zvcertrendicontazionefindselect", new string[] {"CodPsrequalthis", "IdDomandaPagamentoequalthis", "DataApprovazioneequalthis",
"DataVerdocumequalthis", "AsseCodiceequalthis", "IdBandoequalthis",
"Interventoequalthis", "Azioneequalthis", "IdProgettoequalthis",
"CodiceCupequalthis", "TipoOperazioneequalthis", "Statoequalthis",
"Comuneequalthis", "CostoTotaleequalthis", "ImportoAmmessoequalthis",
"ImportoConcessoequalthis", "OperazioniBeneficiarioequalthis", "ContributoRichiestoequalthis",
"Beneficiarioequalthis", "SpesaAmmessaequalthis", "ContributoConcessoequalthis",
"ImportoContributoPubblicoequalthis", "SpesaAmmessaIncrementaleequalthis", "ImportoContributoPubblicoIncrementaleequalthis",
"ImportoLiquidatoequalthis", "OperazioneEsclusaequalthis", "MotivoEsclusioneequalthis",
"DomandaPagamentoIstruitaequalthis", "RdpApprovataequalthis", "InIntegrazioneequalthis",
"ImportoPrivatoequalthis", "Percrealequalthis", "Rischioirequalthis",
"Rischiocrequalthis", "Rischioequalthis", "DomandaTipoequalthis"}, new string[] {"string", "int", "DateTime",
"DateTime", "string", "int",
"string", "string", "int",
"string", "int", "string",
"int", "decimal", "decimal",
"decimal", "int", "int",
"string", "decimal", "decimal",
"decimal", "decimal", "decimal",
"int", "int", "int",
"bool", "bool", "bool",
"decimal", "decimal", "decimal",
"decimal", "string", "string"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodPsrequalthis", CodPsrEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataApprovazioneequalthis", DataApprovazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataVerdocumequalthis", DataVerdocumEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "AsseCodiceequalthis", AsseCodiceEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Interventoequalthis", InterventoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Azioneequalthis", AzioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodiceCupequalthis", CodiceCupEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "TipoOperazioneequalthis", TipoOperazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Statoequalthis", StatoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Comuneequalthis", ComuneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CostoTotaleequalthis", CostoTotaleEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoAmmessoequalthis", ImportoAmmessoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoConcessoequalthis", ImportoConcessoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "OperazioniBeneficiarioequalthis", OperazioniBeneficiarioEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ContributoRichiestoequalthis", ContributoRichiestoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Beneficiarioequalthis", BeneficiarioEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "SpesaAmmessaequalthis", SpesaAmmessaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ContributoConcessoequalthis", ContributoConcessoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoContributoPubblicoequalthis", ImportoContributoPubblicoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "SpesaAmmessaIncrementaleequalthis", SpesaAmmessaIncrementaleEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoContributoPubblicoIncrementaleequalthis", ImportoContributoPubblicoIncrementaleEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoLiquidatoequalthis", ImportoLiquidatoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "OperazioneEsclusaequalthis", OperazioneEsclusaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "MotivoEsclusioneequalthis", MotivoEsclusioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DomandaPagamentoIstruitaequalthis", DomandaPagamentoIstruitaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "RdpApprovataequalthis", RdpApprovataEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "InIntegrazioneequalthis", InIntegrazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoPrivatoequalthis", ImportoPrivatoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Percrealequalthis", PercrealEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Rischioirequalthis", RischioirEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Rischiocrequalthis", RischiocrEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Rischioequalthis", RischioEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DomandaTipoequalthis", DomandaTipoEqualThis);
            Vcertrendicontazione VcertrendicontazioneObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                VcertrendicontazioneObj = GetFromDatareader(db);
                VcertrendicontazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                VcertrendicontazioneObj.IsDirty = false;
                VcertrendicontazioneObj.IsPersistent = true;
                VcertrendicontazioneCollectionObj.Add(VcertrendicontazioneObj);
            }
            db.Close();
            return VcertrendicontazioneCollectionObj;
        }

        //Find Find

        public static VcertrendicontazioneCollection Find(DbProvider db, SiarLibrary.NullTypes.StringNT CodPsrEqualThis)

        {

            VcertrendicontazioneCollection VcertrendicontazioneCollectionObj = new VcertrendicontazioneCollection();

            IDbCommand findCmd = db.InitCmd("Zvcertrendicontazionefindfind", new string[] { "CodPsrequalthis" }, new string[] { "string" }, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodPsrequalthis", CodPsrEqualThis);
            Vcertrendicontazione VcertrendicontazioneObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                VcertrendicontazioneObj = GetFromDatareader(db);
                VcertrendicontazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                VcertrendicontazioneObj.IsDirty = false;
                VcertrendicontazioneObj.IsPersistent = true;
                VcertrendicontazioneCollectionObj.Add(VcertrendicontazioneObj);
            }
            db.Close();
            return VcertrendicontazioneCollectionObj;
        }

    }
}


namespace SiarBLL
{

    /// <summary>
    /// Summary description for VcertrendicontazioneCollectionProvider:IVcertrendicontazioneProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class VcertrendicontazioneCollectionProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di Vcertrendicontazione
        protected VcertrendicontazioneCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public VcertrendicontazioneCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new VcertrendicontazioneCollection();
        }

        //Costruttore 2: popola la collection
        public VcertrendicontazioneCollectionProvider(StringNT CodpsrEqualThis)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = Find(CodpsrEqualThis);
        }

        //Costruttore3: ha in input vcertrendicontazioneCollectionObj - non popola la collection
        public VcertrendicontazioneCollectionProvider(VcertrendicontazioneCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public VcertrendicontazioneCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new VcertrendicontazioneCollection();
        }

        //Get e Set
        public VcertrendicontazioneCollection CollectionObj
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
        public VcertrendicontazioneCollection Select(StringNT CodpsrEqualThis, IntNT IddomandapagamentoEqualThis, DatetimeNT DataapprovazioneEqualThis,
DatetimeNT DataverdocumEqualThis, StringNT AssecodiceEqualThis, IntNT IdbandoEqualThis,
StringNT InterventoEqualThis, StringNT AzioneEqualThis, IntNT IdprogettoEqualThis,
StringNT CodicecupEqualThis, IntNT TipooperazioneEqualThis, StringNT StatoEqualThis,
IntNT ComuneEqualThis, DecimalNT CostototaleEqualThis, DecimalNT ImportoammessoEqualThis,
DecimalNT ImportoconcessoEqualThis, IntNT OperazionibeneficiarioEqualThis, IntNT ContributorichiestoEqualThis,
StringNT BeneficiarioEqualThis, DecimalNT SpesaammessaEqualThis, DecimalNT ContributoconcessoEqualThis,
DecimalNT ImportocontributopubblicoEqualThis, DecimalNT SpesaammessaincrementaleEqualThis, DecimalNT ImportocontributopubblicoincrementaleEqualThis,
IntNT ImportoliquidatoEqualThis, IntNT OperazioneesclusaEqualThis, IntNT MotivoesclusioneEqualThis,
BoolNT DomandapagamentoistruitaEqualThis, BoolNT RdpapprovataEqualThis, BoolNT InintegrazioneEqualThis,
DecimalNT ImportoprivatoEqualThis, DecimalNT PercrealEqualThis, DecimalNT RischioirEqualThis,
DecimalNT RischiocrEqualThis, StringNT RischioEqualThis, StringNT DomandatipoEqualThis)
        {
            VcertrendicontazioneCollection VcertrendicontazioneCollectionTemp = VcertrendicontazioneDAL.Select(_dbProviderObj, CodpsrEqualThis, IddomandapagamentoEqualThis, DataapprovazioneEqualThis,
DataverdocumEqualThis, AssecodiceEqualThis, IdbandoEqualThis,
InterventoEqualThis, AzioneEqualThis, IdprogettoEqualThis,
CodicecupEqualThis, TipooperazioneEqualThis, StatoEqualThis,
ComuneEqualThis, CostototaleEqualThis, ImportoammessoEqualThis,
ImportoconcessoEqualThis, OperazionibeneficiarioEqualThis, ContributorichiestoEqualThis,
BeneficiarioEqualThis, SpesaammessaEqualThis, ContributoconcessoEqualThis,
ImportocontributopubblicoEqualThis, SpesaammessaincrementaleEqualThis, ImportocontributopubblicoincrementaleEqualThis,
ImportoliquidatoEqualThis, OperazioneesclusaEqualThis, MotivoesclusioneEqualThis,
DomandapagamentoistruitaEqualThis, RdpapprovataEqualThis, InintegrazioneEqualThis,
ImportoprivatoEqualThis, PercrealEqualThis, RischioirEqualThis,
RischiocrEqualThis, RischioEqualThis, DomandatipoEqualThis);
            return VcertrendicontazioneCollectionTemp;
        }

        //Find: popola la collection
        public VcertrendicontazioneCollection Find(StringNT CodpsrEqualThis)
        {
            VcertrendicontazioneCollection VcertrendicontazioneCollectionTemp = VcertrendicontazioneDAL.Find(_dbProviderObj, CodpsrEqualThis);
            return VcertrendicontazioneCollectionTemp;
        }


    }
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<vCertRendicontazione>
  <ViewName>vCertRendicontazione</ViewName>
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
    <Find OrderBy="ORDER BY ">
      <Cod_Psr>Equal</Cod_Psr>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</vCertRendicontazione>
*/
