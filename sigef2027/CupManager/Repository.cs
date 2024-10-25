using System;
using System.Collections.Generic;

namespace CupManager
{
    internal partial class DatiGeneraliRichiestaCUP
    {
        public int id_progetto { get; set; }
        public string anno_decisione { get; set; }
        public string natura { get; set; }
        public string tipologia { get; set; }
        public string settore { get; set; }
        public string sottosettore { get; set; }
        public string categoria { get; set; }
        public string stato { get; set; }
        public string regione { get; set; }
        public string provincia { get; set; }
        public string sigla { get; set; }
        public string comune { get; set; }
        public short tipo_indirizzo { get; set; }
        public string indirizzo { get; set; }
        public string cap { get; set; }
        public string numero { get; set; }
        public string codice_ateco { get; set; }
        public string sezione_ateco { get; set; }
        public string divisione_ateco { get; set; }
        public string gruppo_ateco { get; set; }
        public string classe_ateco { get; set; }
        public string categoria_ateco { get; set; }
        public string sottocategoria_ateco { get; set; }
        public decimal? costo_progetto { get; set; }
        public decimal? finanziamento_progetto { get; set; }
        public bool check_quota_reg { get; set; }
    }


    internal partial class DescrizioneCupAcquistoBeni
    {
        public int id_progetto { get; set; }
        public string nome_stru_infrastr { get; set; }
        public string partita_iva { get; set; }
        public string bene { get; set; }
        public string ind_area_rif { get; set; }
        public string cap_area_rif { get; set; }
        public string numero_area_rif { get; set; }
    }


    internal partial class DescrizioneCupConcessioneContributiNoUnitaProduttive
    {
        public int id_progetto { get; set; }
        public string beneficiario { get; set; }
        public string partita_iva { get; set; }
        public string struttura { get; set; }
        public string desc_intervento { get; set; }
        public string ind_area_rif { get; set; }
        public string cap_area_rif { get; set; }
        public string numero_area_rif { get; set; }
    }


    internal partial class DescrizioneCupConcessioneIncentiviUnitaProduttive
    {
        public int id_progetto { get; set; }
        public string denominazione_impresa_stabilimento { get; set; }
        public string partita_iva { get; set; }
        public string descrizione_intervento { get; set; }
        public string ind_area_rif { get; set; }
        public string cap_area_rif { get; set; }
        public string numero_area_rif { get; set; }
    }


    internal partial class DescrizioneCupLavoriPubblici
    {
        public int id_progetto { get; set; }
        public string nome_stru_infrastr { get; set; }
        public string partita_iva { get; set; }
        public string ind_area_rif { get; set; }
        public string cap_area_rif { get; set; }
        public string numero_area_rif { get; set; }
        public string descrizione_intervento { get; set; }
        public int nr_imprese { get; set; }
        public string str_infrastr_unica { get; set; }
    }


    internal partial class DescrizioneCupPartecipAzionarieConferimCapitale
    {
        public int id_progetto { get; set; }
        public string ragione_sociale { get; set; }
        public string partita_iva { get; set; }
        public string finalita { get; set; }
        public string ind_area_rif { get; set; }
        public string cap_area_rif { get; set; }
        public string numero_area_rif { get; set; }
    }


    internal partial class DescrizioneCupRealizzAcquistoNoFormazioneRicerca
    {
        public int id_progetto { get; set; }
        public string nome_stru_infrastr { get; set; }
        public string partita_iva { get; set; }
        public string servizio { get; set; }
        public string ind_area_rif { get; set; }
        public string cap_area_rif { get; set; }
        public string numero_area_rif { get; set; }
        //public int nr_imprese { get; set; }
        //public string str_infrastr_unica { get; set; }
    }


    public class DescrizioneCupRealizzAcquistoServiziFormazione
    {
        public int id_progetto { get; set; }
        public string denom_ente_corso { get; set; }
        public string obiett_corso { get; set; }
        public string mod_intervento_frequenza { get; set; }
        public string partita_iva { get; set; }
        public string denom_progetto { get; set; }
        public string ind_area_rif { get; set; }
        public string cap_area_rif { get; set; }
        public string numero_area_rif { get; set; }
    }


    internal partial class DescrizioneCupRealizzAcquistoServiziRicerca
    {
        public int id_progetto { get; set; }
        public string denominazione_progetto { get; set; }
        public string ente { get; set; }
        public string partita_iva { get; set; }
        public string descrizione_intervento { get; set; }
        public string ind_area_rif { get; set; }
        public string cap_area_rif { get; set; }
        public string numero_area_rif { get; set; }
    }


    internal partial class CupRichieste
    {
        public int ID_CUP_RICHIESTA { get; set; }
        public int ID_RICHIESTA { get; set; }
        public int ID_PROGETTO { get; set; }
        public string CODICE_CUP { get; set; }
        public DateTime? DATA_RICHIESTA_CUP { get; set; }
        public string ISTANZA_RICHIESTA { get; set; }
        public string ISTANZA_RISPOSTA { get; set; }
        public int? ID_RICHIESTA_ASSEGNATA_CUP { get; set; }
        public string ESITO_ELABORAZIONE_CUP { get; set; }
        public string DESCRIZIONE_ESITO_ELABORAZIONE_CUP { get; set; }
        public string TIPO_ESITO { get; set; }
        public DateTime? DATA_INSERIMENTO { get; set; }
        public DateTime? DATA_AGGIORNAMENTO { get; set; }
    }


    public partial class ProgettiFinanziabili
    {
        public int ID_PROGETTO { get; set; }
        public string COD_STATO { get; set; }
    }


    public partial class ParametriRichiestaCupNoFesr
    {

        public ParametriRichiestaCupNoFesr()
        {
            FONTI_FINANZIAMENTO = new List<string>(); 
        }

        public int ID_PROGETTO { get; set; }
        public string COD_STRUMENTO_PROGRAMMAZIONE { get; set; }
        public string DESC_STRUMENTO_PROGRAMMAZIONE { get; set; }
        public string TITOLO_PROGETTO { get; set; }
        public List<string> FONTI_FINANZIAMENTO { get; set; }
    }

}
