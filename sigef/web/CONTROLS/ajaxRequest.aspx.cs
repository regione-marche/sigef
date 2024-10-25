using System;
using System.Web;
using System.Web.UI.WebControls;
using SiarLibrary.Extensions;

namespace web.CONTROLS
{
    public partial class ajaxRequest : System.Web.UI.Page
    {
        private SiarLibrary.Operatore Operatore
        {
            get { return (SiarLibrary.Operatore)(Session["OperatoreAlias"] ?? Session["Operatore"]); }
        }
        SNCOptions.ReturnJSONObject return_object = new SNCOptions.ReturnJSONObject();

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ClearHeaders();
            Response.ClearContent();
            ctrlRequest();
            Response.Write(return_object.getReturnMessage());
            Response.End();
        }

        private void ctrlRequest()
        {
            string metodo = Request.Form["type"];
            try
            {
                if (string.IsNullOrEmpty(metodo)) throw new Exception("Metodo non specificato.");
                System.Reflection.MethodInfo mi = this.GetType().GetMethod(metodo);
                object[] r_attributes = mi.GetCustomAttributes(typeof(SNCOptions.ReturnTypeObjectAttribute), false);
                if (r_attributes.Length > 0) return_object.ReturnTypeObject = ((SNCOptions.ReturnTypeObjectAttribute)r_attributes[0]).ReturnTypeObject;
                object[] c_attributes = mi.GetCustomAttributes(typeof(SNCOptions.AuthenticationRequiredAttribute), false);
                if (c_attributes.Length == 0) throw new Exception("Il metodo specificato non è accessibile.");
                if (((SNCOptions.AuthenticationRequiredAttribute)c_attributes[0]).AuthenticationRequired &&
                    Operatore == null) throw new Exception("Operatore non abilitato.");
                mi.Invoke(this, null);
            }
            catch (Exception ex) { return_object.setException(ex, -2); }
        }

        System.Text.StringBuilder sb; System.IO.StringWriter sw; System.Web.UI.HtmlTextWriter tw;
        private string getHtmlStringControl(System.Web.UI.Control c)
        {
            sb = new System.Text.StringBuilder();
            sw = new System.IO.StringWriter(sb);
            tw = new System.Web.UI.HtmlTextWriter(sw);
            c.RenderControl(tw);
            return sb.ToString();
        }

        #region metodi con autenticazione

        [SNCOptions.AuthenticationRequiredAttribute(true)]
        [SNCOptions.ReturnTypeObject(web.CONTROLS.SNCOptions.ReturnTypeObject.Json)]
        public void getDatiDomanda()
        {
            try
            {
                int iddomanda;
                if (int.TryParse(Request.Form["iddom"], out iddomanda))
                {
                    SiarLibrary.CollaboratoriXBandoCollection progetti = new SiarBLL.CollaboratoriXBandoCollectionProvider().
                        GetCollabBandoDatiProgettoImpresa(null, iddomanda, null, null, null);
                    if (progetti.Count > 0)
                    {
                        return_object.Html = @"<table width='100%' class=tableNoTab>
<tr><td class=separatore_light colspan=2>&nbsp;Dettaglio della domanda:</td></tr>
<tr><td style='width:89px'>&nbsp;&nbsp;</td><td>&nbsp;</td></tr>
<tr><td style='width:89px'>&nbsp;<b>Numero:</b></td><td><b>" + progetti[0].IdProgetto + @"</b></td></tr>
<tr><td style='width:89px'>&nbsp;<b>Partita iva/Codice fiscale:</b></td><td><b>" + progetti[0].AdditionalAttributes["CUAA"] + @"</b></td></tr>
<tr><td style='width:89px'><b>&nbsp;Rag.soc:</b></td><td>" + progetti[0].AdditionalAttributes["RAGIONE_SOCIALE"] + @"</td></tr>
<tr><td style='width:89px'><b>&nbsp;Sede:</b></td><td>" + progetti[0].AdditionalAttributes["COMUNE"] + " (" + progetti[0].AdditionalAttributes["SIGLA"]
                                                        + ") - " + progetti[0].AdditionalAttributes["CAP"] + @"</td></tr>
<tr><td style='width:89px'>&nbsp;<b>Stato attuale:</b></td><td>" + progetti[0].AdditionalAttributes["STATO"] + @"</td></tr>
<tr><td style='width:89px'><b>&nbsp;Istruttore:</b></td><td>" + progetti[0].Nominativo + " (" + progetti[0].Provincia + @")</td></tr>
<tr><td style='width:89px'>&nbsp;</td><td>&nbsp;</td></tr></table>";
                    }
                    else throw new Exception("La domanda di aiuto selezionata non è valida. Impossibile continuare.");
                }
                else throw new Exception("La domanda di aiuto selezionata non è valida. Impossibile continuare.");
            }
            catch (Exception ex) { return_object.setException(ex); }
        }

        [SNCOptions.AuthenticationRequiredAttribute(true)]
        public void getSelezioneParametroSanzioniPagamento()
        {
            try
            {
                string html = "NESSUN PARAMETRO TROVATO.";
                int id_sanzione;
                string cod_tipo_sanzione = Request.Form["cod_tipo_sanzione"], cod_tipo_parametro = Request.Form["cod_tipo_parametro"];
                if (!int.TryParse(Request.Form["id_sanzione"], out id_sanzione) || cod_tipo_sanzione.Length > 10 || cod_tipo_parametro.Length != 1)
                    return_object.Html = "ATTENZIONE! ERRORE NELLA DEFINIZIONE DEL PARAMETRO DA RICERCARE. IMPOSSIBILE CONTINUARE.";
                else
                {
                    SiarLibrary.TipoSanzioniParametriCollection parametri = new SiarBLL.TipoSanzioniParametriCollectionProvider().
                        Find(null, cod_tipo_sanzione, cod_tipo_parametro == "D", cod_tipo_parametro == "G", cod_tipo_parametro == "E");
                    if (parametri.Count > 0)
                    {
                        html = @"<table class='tabella' cellspacing='0' border='1' style='width:100%;border-collapse:collapse;'>
<tr class='TESTA1'><td>Nr.</td><td>Descrizione</td><td>&nbsp;</td></tr>";
                        int counter = 1;
                        foreach (SiarLibrary.TipoSanzioniParametri p in parametri)
                        {
                            html += "<tr class='DataGridRow' style='height:24px'><td align='center' style='width:30px;'>" + counter.ToString()
                                + "</td><td align='left'>" + p.Descrizione + "</td><td align=center style='width:140px;'><a href=\"javascript:selezionaParametro("
                                + id_sanzione.ToString() + ",'" + cod_tipo_parametro + "'," + p.Codice + ",'" + p.Descrizione + "');\">seleziona</a></td></tr>";
                            counter++;
                        }
                        html += "</table>";
                    }
                    else html = "<br /><b> - Nessun elemento trovato.</b>";
                    return_object.Html = html;
                }
            }
            catch (Exception ex) { return_object.setException(ex); }
        }

        //        [SNCOptions.AuthenticationRequiredAttribute(true)]
        //        public void getSelezionePlurivalorePriorita()
        //        {
        //            try
        //            {
        //                string html = "NESSUN VALORE TROVATO.";
        //                int id_priorita;
        //                if (!int.TryParse(Request.Form["idppl"], out id_priorita))
        //                    return_object.Html = "ATTENZIONE! ERRORE NELLA DEFINIZIONE DELLA PRIORITA DA RICERCARE. IMPOSSIBILE CONTINUARE.";
        //                else
        //                {
        //                    SiarLibrary.ValoriPrioritaCollection plurivalori = new SiarBLL.ValoriPrioritaCollectionProvider().Find(null, id_priorita, null);
        //                    if (plurivalori.Count > 0)
        //                    {
        //                        html = @"<table class='tabella' cellspacing='0' border='1' style='width:100%;border-collapse:collapse;'>
        //<tr class='TESTA1'><td>Nr.</td><td>Descrizione</td><td>&nbsp;</td></tr>";
        //                        int counter = 1;
        //                        foreach (SiarLibrary.ValoriPriorita p in plurivalori)
        //                        {
        //                            html += "<tr class='DataGridRow' style='height:24px'><td align='center' style='width:30px;'>" + counter.ToString()
        //                                + "</td><td align='left'>" + p.Descrizione + "</td><td align=center style='width:140px;'><a href=\"javascript:selezionaPlurivalore("
        //                                + id_priorita.ToString() + "," + p.IdValore + ",'" + p.Descrizione + "');\">seleziona</a></td></tr>";
        //                            counter++;
        //                        }
        //                        html += "</table>";
        //                    }
        //                    else html = "<br /><b> - Nessun elemento trovato.</b>";
        //                    return_object.Html = html;
        //                }
        //            }
        //            catch (Exception ex) { return_object.setException(ex); }
        //        }

        [SNCOptions.AuthenticationRequiredAttribute(true)]
        public void cercaImpresaByCuaa()
        {
            string cuaa_impresa = Request.Params["cuaa"];
            try
            {
                SiarLibrary.Impresa i = new SiarBLL.ImpresaCollectionProvider().GetByCuaa(cuaa_impresa);
                if (i == null) //scarico da anagrafe tributaria
                {
                    SianWebSrv.TraduzioneSianToSiar t = new SianWebSrv.TraduzioneSianToSiar();
                    t.ScaricaDatiAzienda(cuaa_impresa, null, Operatore.Utente.CfUtente);
                    i = new SiarBLL.ImpresaCollectionProvider().GetByCuaa(cuaa_impresa);
                }
                if (i != null) return_object.Html = i.IdImpresa + "|" + i.RagioneSociale;
                else return_object.Html = "0|Nessuna impresa trovata.";
            }
            catch (Exception ex) { return_object.Html = "0|" + ex.Message; }
        }

        [SNCOptions.AuthenticationRequiredAttribute(true)]
        public void ZoomComuniFind()
        {
            try
            {
                string descrizione = Request.Params["descrizione"];
                if (string.IsNullOrEmpty(descrizione)) descrizione = "%";
                bool cerca_nelle_marche;
                bool.TryParse(Request.Params["cerca_nelle_marche"], out cerca_nelle_marche);

                return_object.Html = "<tr><td class='CompAutHeader'><table width=100% cellpadding=0 cellspacing=0><tr><td align=left>&nbsp;SELEZIONA IL COMUNE:</td><td align=right>";
                return_object.Html += "cerca nelle Marche <input id='chkZCCercaMarche' onclick='ZCcerca();' type=checkbox" + (cerca_nelle_marche ? " checked=checked" : "") + " /></td></tr></table>";
                //return_object.Html += "<a href='javascript:cercaMarche();'>cerca nelle Marche <input id='chkZCCercaMarche' type=checkbox" + (cerca_nelle_marche ? " checked=checked" : "") + " /></a></td></tr></table>";
                System.Collections.ArrayList results = SiarLibrary.DbStaticProvider.ZoomComuniFind(descrizione, (cerca_nelle_marche ? 10 : 0), null);
                int elementi_trovati = 0;
                foreach (object o in results)
                {
                    return_object.Html += "<tr><td";
                    if (o == null) return_object.Html += " class='CompAutVoidResult'>&nbsp;";
                    else
                    {
                        System.Collections.DictionaryEntry de = (System.Collections.DictionaryEntry)o;
                        return_object.Html += " class='CompAutResult' onclick=\"selezionaComune(" + de.Key /*+ "," + de.Value*/ + ",this);\">&nbsp;" + de.Value;
                        elementi_trovati++;
                    }
                    return_object.Html += "</td></tr>";
                }
                return_object.Html += "<tr class='coda'><td>&nbsp;" + (elementi_trovati > 0 ? "Tasto TAB seleziona primo elemento" : "Nessun elemento trovato.") + "</td></tr>";
            }
            catch (Exception ex) { return_object.Html = "<tr><td class='CompAutHeader'>errore:" + ex.Message + "</td></tr>"; }
        }

        [SNCOptions.AuthenticationRequiredAttribute(false)]
        [SNCOptions.ReturnTypeObject(web.CONTROLS.SNCOptions.ReturnTypeObject.String)]
        public void SNCZoomComuniFind() 
        {
            string descrizione = Request.Params["descrizione"];
            bool cerca_nelle_marche;
            bool.TryParse(Request.Params["cerca_nelle_marche"], out cerca_nelle_marche);
            SiarLibrary.DbProvider db = new SiarLibrary.DbProvider();
            System.Data.IDbCommand cmd = db.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpZoomComuniFind";
            if (!string.IsNullOrEmpty(descrizione)) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DESCRIZIONE", descrizione));
            if (cerca_nelle_marche) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COD_REGIONE", "11"));
            db.InitDatareader(cmd);
            return_object.Html = "[";
            while (db.DataReader.Read()) return_object.Html += "{'IdComune':" + db.DataReader["ID_COMUNE"].ToString() + ",'Denominazione':'"
                + db.DataReader["DENOMINAZIONE"].ToString().Replace("'", "`") + "','Provincia':'" + db.DataReader["SIGLA"].ToString() + "','Cap':'" + db.DataReader["CAP"] + "'},";
            db.Close();
            if (return_object.Html.EndsWith(",")) return_object.Html = return_object.Html.Substring(0, return_object.Html.Length - 1);
            return_object.Html += "]";
        }

        [SNCOptions.AuthenticationRequiredAttribute(false)]
        [SNCOptions.ReturnTypeObject(web.CONTROLS.SNCOptions.ReturnTypeObject.String)]
        public void SNCZoomUtentiFind()
        {
            string descrizione = Request.Params["descrizione"];
            if (!string.IsNullOrEmpty(descrizione))
                descrizione = descrizione + "%";
            SiarLibrary.UtentiCollection uc;
            uc = new SiarBLL.UtentiCollectionProvider().Find(null, null, descrizione, null, null, null, true);
            return_object.Html = "[";
            int iLimit = uc.Count;
            if (iLimit > 10)
                iLimit = 10;
            for (int i = 0; i < iLimit; i++)
            {
                return_object.Html += uc[i].ConvertToJSonObject() + ",";
            }
            if (return_object.Html.EndsWith(","))
                return_object.Html = return_object.Html.Substring(0, return_object.Html.Length - 1);
            return_object.Html = return_object.Html + "]";
        }

        [SNCOptions.AuthenticationRequiredAttribute(true)]
        public void getPianoInvestimenti()
        {
            try
            {
                //System.Threading.Thread.Sleep(2000);
                string html = "NESSUN INVESTIMENTO TROVATO.";
                SiarLibrary.DomandaDiPagamento d = (SiarLibrary.DomandaDiPagamento)Session["domanda_pagamento"];
                SiarLibrary.PianoInvestimentiCollection investimenti = new SiarBLL.PianoInvestimentiCollectionProvider().GetPianoInvestimentiDomandaPagamento(
                    d.IdProgetto, d.IdDomandaPagamento);
                html = "<table class='tabella' cellspacing='0' border='1' style='width:100%;border-collapse:collapse'><tr class='TESTA1'><td>Nr.</td><td>Prioritario</td><td>Descrizione</td><td>Costo totale</td><td>Contributo</td><td>Contributo %</td></tr>";
                int counter = 1;
                int indice_pagina, page_size = 8;
                int.TryParse(Request.Form["zoomdg_page_index"], out indice_pagina);

                foreach (SiarLibrary.PianoInvestimenti i in investimenti)
                {
                    if (counter > page_size * indice_pagina && counter <= page_size * (indice_pagina + 1))
                    {
                        decimal costo_investimento = i.CostoInvestimento + (i.SpeseGenerali != null && i.CodTipoInvestimento != 2 ? i.SpeseGenerali.Value : 0);
                        html += "<tr class='DataGridRow selectable' style='height:24px' onclick=\"scegliInvestimento("
                            + i.IdInvestimento + ")\"'><td align=center style='width:30px'>" + counter.ToString()
                            + "</td><td align=center style='width:30px'>" + (i.IdPrioritaSettoriale != null ? "<img src='../../images/star_red.gif'>" : "")
                            + "</td><td>Codifica: <b>" + i.CodificaInvestimento + "</b><br />Dettaglio: <b>" + i.DettaglioInvestimenti + "</b><br />Descrizione: <b>"
                            + i.Descrizione + "</b></td><td align=right style='width:100px'>" + string.Format("{0:c}", costo_investimento) +
                            "</td><td align=right style='width:100px'>" + string.Format("{0:c}", i.ContributoRichiesto)
                            + "</td><td align=right style='width:100px'>" + string.Format("{0:N}", i.QuotaContributoRichiesto) + "</td></tr>";
                    }
                    counter++;
                }
                if (investimenti.Count == 0) html += "<tr class=DataGridRow><td colspan=6 style='height:24px;font-style:italic'> - Nessun elemento trovato.</td></tr>";
                else
                {
                    int nr_pagine = 1 + investimenti.Count / page_size;
                    string link_pagina = "<tr class=coda><td colspan=6>";
                    for (int j = 0; j < nr_pagine; j++)
                        link_pagina += "<a " + (j != indice_pagina ? "href=\"javascript:cercaInvestimenti(" + j.ToString() + ");\"" : "style='color:white'")
                            + ">" + (j + 1).ToString() + "</a>&nbsp;";
                    html += link_pagina + "</td></tr>";
                }
                html += "</table>";
                return_object.Html = html;
            }
            catch (Exception ex) { return_object.setException(ex); }
        }

        [SNCOptions.AuthenticationRequiredAttribute(true)]
        public void CalcoloPunteggio()
        {
            try
            {
                int id_progetto;
                bool calcola;
                if (!int.TryParse(Request.Form["iddom"], out id_progetto) || !bool.TryParse(Request.Form["calc"], out calcola))
                    throw new Exception("Attenzione! La domanda di aiuto selezionata non è valida. Impossibile continuare.");
                string messaggio_finale = null;
                SiarBLL.ProgettoCollectionProvider progetto_provider = new SiarBLL.ProgettoCollectionProvider();
                SiarLibrary.Progetto p = progetto_provider.GetById(id_progetto);
                SiarLibrary.Bando b = new SiarBLL.BandoCollectionProvider().GetById(p.IdBando);
                SiarLibrary.SchedaValutazione scheda = new SiarBLL.SchedaValutazioneCollectionProvider().GetById(b.IdSchedaValutazione);
                return_object.Html = "<table width='100%' cellpadding=1 cellspacing=0><tr class='TESTA'><td width='200px'>Nr. domanda di aiuto: " + p.IdProgetto
                    + "</td><td align=right>(punteggio minimo richiesto: " + scheda.ValoreMin + ")</td></tr><tr><td>&nbsp;</td><td></td></tr></table>";

                //Controllo se il bando ha la valutazione del comitato e se è gia stata firmata
                bool continua = true;
                if (b.AbilitaValutazione)
                {
                    SiarBLL.ProgettoValutazioneCollectionProvider valutazione_prov = new SiarBLL.ProgettoValutazioneCollectionProvider();
                    SiarLibrary.ProgettoValutazioneCollection valut_coll = valutazione_prov.Find(p.IdProgetto, null, true, null, false);
                    int Count_valutaz = valut_coll.Count;
                    bool firmato = false;
                    foreach (SiarLibrary.ProgettoValutazione v in valut_coll)
                    {
                        if (v.Segnatura != null)
                            firmato = true;
                    }

                    if(firmato && Count_valutaz > 0)
                    { 
                        messaggio_finale = "Il punteggio del comitato di valutazione è stato firmato e calcolato.";
                        continua = false;
                        if (calcola)
                            messaggio_finale += " Impossibile calcolare.";
                    }

                }


                if (calcola && continua)
                {
                    if (b.OrdineStato > 4)
                    {
                        //controllo se la graduatoria è in scorrimento
                        SiarLibrary.GraduatoriaBandoScorrimentoCollection scorr_coll =new SiarBLL.GraduatoriaBandoScorrimentoCollectionProvider().Find(b.IdBando, false);
                        if (scorr_coll.Count > 0)
                        { //calcolo punteggio
                            progetto_provider.CalcoloPunteggioDomandaDiAiuto(id_progetto, null, Request.Form["str_params"], 1, Operatore.Utente.CfUtente);
                            messaggio_finale = "Punteggio calcolato correttamente.";
                        }
                        else
                            messaggio_finale = "Attenzione! La graduatoria del bando è stata resa definitiva. Punteggio non calcolato.";
                    }
                    else if (new SiarBLL.CollaboratoriXBandoCollectionProvider().Find(b.IdBando, p.IdProgetto, Operatore.Utente.IdUtente, null, true)
                        .Count == 0) messaggio_finale = "Attenzione! Solo il funzionario istruttore assegnato alla pratica può eseguire calcolare il punteggio.";
                    else
                    {
                        try
                        {
                            //calcolo punteggio
                            progetto_provider.CalcoloPunteggioDomandaDiAiuto(id_progetto, null, Request.Form["str_params"], 1, Operatore.Utente.CfUtente);
                            messaggio_finale = "Punteggio calcolato correttamente.";
                        }
                        catch (Exception ex) { messaggio_finale = ex.Message; }
                    }
                }
                SiarLibrary.GraduatoriaProgettiDettaglioCollection priorita = new SiarBLL.GraduatoriaProgettiDettaglioCollectionProvider()
                    .Find(null, id_progetto, null);
                if (priorita.Count > 0)
                {
                    decimal totale = 0;
                    return_object.Html += "<table class='tabella' cellspacing='0' border='1' style='width:100%;border-collapse:collapse'><tr class='TESTA1'><td>Nr.</td><td>Descrizione</td><td>Punteggio</td></tr>";
                    int counter = 1;
                    foreach (SiarLibrary.GraduatoriaProgettiDettaglio d in priorita)
                    {
                        decimal punteggio_priorita = (d.Punteggio != null ? Math.Round(d.Punteggio.Value, 3, MidpointRounding.AwayFromZero) : 0);
                        totale += punteggio_priorita;
                        return_object.Html += "<tr class=DataGridRow style='height:24px'><td align=center width='30px'>" + counter.ToString() + "</td><td>"
                            + d.Descrizione + "</td><td align=right width='160px'>"
                            + "<span id='txtPunteggioPriorita" + d.IdPriorita + "' class='PunteggioBox'><input type='text' id='txtPunteggioPriorita"
                            + d.IdPriorita + "_text' name='txtPunteggioPriorita" + d.IdPriorita + "_text' value=\""
                            + punteggio_priorita.ToString() + "\" style='text-align:right;width:110px' "
                            + (!d.FlagManuale ? "disabled=disabled" : "txtPunteggioManuale='" + d.IdPriorita + "'") + " /></span></td></tr>";
                        counter++;
                    }
                    //return_object.Html += "<tr class='coda'><td colspan=2 align=right>TOTALE</td><td align=right>" + string.Format("{0:N}", totale)
                    //    + "</td></tr></table>";
                    return_object.Html += "<tr class='coda'><td colspan=2 align=right>TOTALE</td><td align=right>" + string.Format("{0:#,0.000}", totale)
                        + "</td></tr></table>";                    
                }
                else return_object.Html += "<b><em>Punteggio non ancora calcolato.</em></b>";
                if (!string.IsNullOrEmpty(messaggio_finale)) return_object.Html += "<p><b><em>" + messaggio_finale + "</em></b></p>";
            }
            catch { return_object.setException("La domanda di aiuto selezionata non è valida. Impossibile continuare."); }
        }

        [SNCOptions.AuthenticationRequiredAttribute(true)]
        public void CalcoloPunteggioVariante()
        {
            try
            {
                int id_progetto, id_variante;
                bool calcola;
                if (!int.TryParse(Request.Form["iddom"], out id_progetto) || !int.TryParse(Request.Form["idvar"], out id_variante) ||
                    !bool.TryParse(Request.Form["calc"], out calcola)) throw new Exception("");
                string messaggio_finale = null;
                SiarLibrary.Varianti v = new SiarBLL.VariantiCollectionProvider().GetById(id_variante);
                if (v.IdProgetto != id_progetto) throw new Exception("");
                SiarBLL.ProgettoCollectionProvider progetto_provider = new SiarBLL.ProgettoCollectionProvider();
                SiarLibrary.Progetto p = progetto_provider.GetById(id_progetto);
                SiarLibrary.Bando b = new SiarBLL.BandoCollectionProvider().GetById(p.IdBando);
                SiarLibrary.SchedaValutazione scheda = new SiarBLL.SchedaValutazioneCollectionProvider().GetById(b.IdSchedaValutazione);
                return_object.Html = "<table width='100%' cellpadding=1 cellspacing=0><tr class='TESTA'><td width='200px'>Nr. domanda di aiuto: " + p.IdProgetto
                    + "</td><td align=right>(punteggio minimo richiesto: " + scheda.ValoreMin + ")</td></tr><tr class='TESTA'><td width='200px'>Tipo richiesta: "
                    + v.TipoVariante + "</td><td></td></tr><tr><td>&nbsp;</td><td></td></tr></table>";
                if (calcola)
                {
                    if (new SiarBLL.CollaboratoriXBandoCollectionProvider().Find(b.IdBando, p.IdProgetto, Operatore.Utente.IdUtente, null, true)
                        .Count == 0) messaggio_finale = "Attenzione! Solo il funzionario istruttore assegnato alla pratica può eseguire calcolare il punteggio.";
                    else
                    {
                        try
                        {
                            //calcolo punteggio
                            progetto_provider.CalcoloPunteggioDomandaDiAiuto(id_progetto, id_variante, Request.Form["str_params"], 1, Operatore.Utente.CfUtente);
                            messaggio_finale = "Punteggio calcolato correttamente.";
                        }
                        catch (Exception ex) { messaggio_finale = ex.Message; }
                    }
                }
                SiarLibrary.VariantiXPrioritaCollection priorita = new SiarBLL.VariantiXPrioritaCollectionProvider().Find(id_variante, null);
                if (priorita.Count > 0)
                {
                    decimal totale = 0;
                    return_object.Html += "<table class='tabella' cellspacing='0' border='1' style='width:100%;border-collapse:collapse'><tr class='TESTA1'><td>Nr.</td><td>Descrizione</td><td>Punteggio</td></tr>";
                    int counter = 1;
                    foreach (SiarLibrary.VariantiXPriorita d in priorita)
                    {
                        decimal punteggio_priorita = (d.Punteggio != null ? Math.Round(d.Punteggio.Value, 3, MidpointRounding.AwayFromZero) : 0);
                        totale += punteggio_priorita;
                        return_object.Html += "<tr class=DataGridRow style='height:24px'><td align=center width='30px'>" + counter.ToString() + "</td><td>"
                            + d.Descrizione + "</td><td align=right width='160px'>"
                            + "<span id='txtPunteggioPriorita" + d.IdPriorita + "' class='CurrencyBox'><input type='text' id='txtPunteggioPriorita"
                            + d.IdPriorita + "_text' name='txtPunteggioPriorita" + d.IdPriorita + "_text' value=\""
                            + punteggio_priorita.ToString() + "\" style='text-align:right;width:110px' "
                            + (!d.FlagManuale ? "disabled=disabled" : "txtPunteggioManuale='" + d.IdPriorita + "'") + " /></span></td></tr>";
                        counter++;
                    }
                    return_object.Html += "<tr class='coda'><td colspan=2 align=right>TOTALE</td><td align=right>" + string.Format("{0:N}", totale)
                        + "</td></tr></table>";
                }
                else return_object.Html += "<b><em>Punteggio non ancora calcolato.</em></b>";
                if (!string.IsNullOrEmpty(messaggio_finale)) return_object.Html += "<p><b><em>" + messaggio_finale + "</em></b></p>";
            }
            catch { return_object.setException("La domanda di aiuto selezionata non è valida. Impossibile continuare."); }
        }

        [SNCOptions.AuthenticationRequiredAttribute(true)]
        [SNCOptions.ReturnTypeObject(web.CONTROLS.SNCOptions.ReturnTypeObject.Json)]
        public void ZoomPrioritaFind()
        {
            try
            {
                int id_priorita, indice_pagina;
                if (!int.TryParse(Request.Params["idprt"], out id_priorita)) throw new Exception("Nessun requisito selezionato.");
                if (!int.TryParse(Request.Params["indpag"], out indice_pagina) || indice_pagina == 0) indice_pagina = 1;
                return_object.Html = "<table class='tableNoTab' width='600px'><tr><td><table cellpadding=0 cellspacing=0 width='100%'><tr><td class='separatore_big' style='width:575px'>SELEZIONE DEL REQUISITO</td><td style='background-color:#084600;padding:5px'><img src='"
                    + Request.ApplicationPath + "/images/close.png' alt='Chiudi' style='width:20px;height:20px' onmouseover=\"this.style.cursor='pointer';\" onclick='chiudiZoomPrioritaPopup();' /></td></tr></table></td></tr>";
                //return_object.Html = "<table class='tableNoTab' width='600px'><tr><td class='separatore_big' valign='middle'>Elenco valori predefiniti per il requisito<img src='" + Request.ApplicationPath + "/images/close.png' alt='Chiudi' style='width:20px;height:20px;position:relative;left:320px' /></td></tr>";
                SiarLibrary.ValoriPrioritaCollection valori = new SiarBLL.ValoriPrioritaCollectionProvider().Find(null, id_priorita, null);
                if (valori.Count > 0)
                {
                    return_object.Html += "<tr><td><table cellpadding=0 cellspacing=0 width='100%'><tr class='TESTA'><td style='width:60px;height:24px'>Codice</td><td style='width:540px'>Descrizione</td></tr>";
                    int counter = 1, page_size = 10;
                    foreach (SiarLibrary.ValoriPriorita v in valori)
                    {
                        if (counter > page_size * (indice_pagina - 1) && counter <= page_size * indice_pagina)
                        {
                            return_object.Html += "<tr class='DataGridRow' onmouseover=\"selectRow(this,'#fefeee');\" onmouseout='unselectRow(this);' onclick=\"selectZoomPrioritaValore("
                                + v.ConvertToJSonObject() + ");\"><td style='width:60px;height:24px' align='center'>" + v.Codice + "</td><td style='width:540px'>" + v.Descrizione + "</td></tr>";
                        }
                        counter++;
                    }
                    // footer con paginazione
                    int nr_elementi = valori.Count; counter = 1; return_object.Html += "<tr class=coda><td colspan=2>&nbsp;";
                    if (nr_elementi > page_size)
                    {
                        return_object.Html += "<table cellspacing=0 cellpadding=0 width='100%'><tr>";
                        while (nr_elementi > 0)
                        {
                            if (counter == indice_pagina) return_object.Html += "<td style='width:15px;padding-left:10px;color:#fefeee'>" + counter.ToString() + "</td>";
                            else return_object.Html += "<td style='width:15px;padding-left:10px' onmouseover=\"selectRow(this,'#fefeee');\" onmouseout='unselectRow(this)' onclick='runZoomPrioritaSearch("
                                + id_priorita.ToString() + "," + counter.ToString() + ");'>" + counter.ToString() + "</td>";
                            nr_elementi -= page_size;
                            counter++;
                        }
                        return_object.Html += "<td>&nbsp;</td></tr></table>";
                    }
                    return_object.Html += "</td></tr></table></td></tr>";
                }
                else return_object.Html += "<tr><td style='height:60px;padding-left:10px;font-style:italic;font-weight:bold;' valign=middle>Nessun elemento trovato.</td></tr>";
                return_object.Html += "</table>";
            }
            catch (Exception ex) { return_object.setException(ex); }
        }

        [SNCOptions.AuthenticationRequiredAttribute(true)]
        [SNCOptions.ReturnTypeObject(web.CONTROLS.SNCOptions.ReturnTypeObject.Json)]
        public void ZoomRequisitoPagamentoFind()
        {
            try
            {
                int id_requisito, indice_pagina;
                if (!int.TryParse(Request.Params["idreq"], out id_requisito)) throw new Exception("Nessun requisito selezionato.");
                if (!int.TryParse(Request.Params["indpag"], out indice_pagina) || indice_pagina == 0) indice_pagina = 1;
                return_object.Html = "<table class='tableNoTab' width='600px'><tr><td><table cellpadding=0 cellspacing=0 width='100%'><tr><td class='separatore_big' style='width:575px'>SELEZIONE DEL REQUISITO</td><td style='background-color:#084600;padding:5px'><img src='"
                    + Request.ApplicationPath + "/images/close.png' alt='Chiudi' style='width:20px;height:20px' onmouseover=\"this.style.cursor='pointer';\" onclick='chiudiZoomPrioritaPopup();' /></td></tr></table></td></tr>";
                //return_object.Html = "<table class='tableNoTab' width='600px'><tr><td class='separatore_big' valign='middle'>Elenco valori predefiniti per il requisito<img src='" + Request.ApplicationPath + "/images/close.png' alt='Chiudi' style='width:20px;height:20px;position:relative;left:320px' /></td></tr>";
                SiarLibrary.RequisitiPagamentoPlurivaloreCollection requisiti = new SiarBLL.RequisitiPagamentoPlurivaloreCollectionProvider().Find(null, id_requisito, null);
                if (requisiti.Count > 0)
                {
                    return_object.Html += "<tr><td><table cellpadding=0 cellspacing=0 width='100%'><tr class='TESTA'><td style='width:60px;height:24px'>Codice</td><td style='width:540px'>Descrizione</td></tr>";
                    int counter = 1, page_size = 10;
                    foreach (SiarLibrary.RequisitiPagamentoPlurivalore r in requisiti)
                    {
                        if (counter > page_size * (indice_pagina - 1) && counter <= page_size * indice_pagina)
                        {
                            return_object.Html += "<tr class='DataGridRow' onmouseover=\"selectRow(this,'#fefeee');\" onmouseout='unselectRow(this);' onclick=\"selectZoomRequisitoValore("
                                + r.ConvertToJSonObject() + ");\"><td style='width:60px;height:24px' align='center'>" + r.Codice + "</td><td style='width:540px'>" + r.Descrizione + "</td></tr>";
                        }
                        counter++;
                    }
                    // footer con paginazione
                    int nr_elementi = requisiti.Count; counter = 1; return_object.Html += "<tr class=coda><td colspan=2>&nbsp;";
                    if (nr_elementi > page_size)
                    {
                        return_object.Html += "<table cellspacing=0 cellpadding=0 width='100%'><tr>";
                        while (nr_elementi > 0)
                        {
                            if (counter == indice_pagina) return_object.Html += "<td style='width:15px;padding-left:10px;color:#fefeee'>" + counter.ToString() + "</td>";
                            else return_object.Html += "<td style='width:15px;padding-left:10px' onmouseover=\"selectRow(this,'#fefeee');\" onmouseout='unselectRow(this)' onclick='runZoomRequisitoPagamentoSearch("
                                + id_requisito.ToString() + "," + counter.ToString() + ");'>" + counter.ToString() + "</td>";
                            nr_elementi -= page_size;
                            counter++;
                        }
                        return_object.Html += "<td>&nbsp;</td></tr></table>";
                    }
                    return_object.Html += "</td></tr></table></td></tr>";
                }
                else return_object.Html += "<tr><td style='height:60px;padding-left:10px;font-style:italic;font-weight:bold;' valign=middle>Nessun elemento trovato.</td></tr>";
                return_object.Html += "</table>";
            }
            catch (Exception ex) { return_object.setException(ex); }
        }

        [SNCOptions.AuthenticationRequiredAttribute(true)]
        [SNCOptions.ReturnTypeObject(SNCOptions.ReturnTypeObject.Json)]
        public void sncVisualizzaReport()
        {
            try
            {
                string nome = Request.Params["sncRptNome"];
                if (string.IsNullOrEmpty(nome)) throw new Exception("Il documento cercato non è disponibile.");
                int formato;
                int.TryParse(Request.Params["sncRptFormato"], out formato);
                string[] parametri = Request.Params["sncRptParametri"].Split('|');
                SiarLibrary.Web.ReportTemplates rt = new SiarLibrary.Web.ReportTemplates();
                byte[] report = rt.getReportByName(nome, formato, parametri);
                rt.Dispose();
                if (report == null || report.Length == 0) throw new Exception("Il documento cercato non è stato trovato.");
                SiarLibrary.ArchivioFile af = new SiarLibrary.ArchivioFile();
                af.Contenuto = report;
                af.NomeCompleto = "nomecompleto.";
                switch (formato)
                {
                    case 1: af.NomeCompleto += "pdf"; break;
                    case 2: af.NomeCompleto += "xls"; break;
                    case 3: af.NomeCompleto += "doc"; break;
                    case 4: af.NomeCompleto += "csv"; break;
                }
                SiarLibrary.ArchivioFileCollection docs = new SiarLibrary.ArchivioFileCollection();
                docs.Add(af);
                Session["siar_view_file"] = docs;
            }
            catch (Exception ex) { return_object.setException(ex); }
        }

        [SNCOptions.AuthenticationRequiredAttribute(true)]
        [SNCOptions.ReturnTypeObject(SNCOptions.ReturnTypeObject.Json)]
        public void VisualizzaProtocollo()
        {
            try
            {
                string segnatura = Request.Form["segnatura"];
                if (string.IsNullOrEmpty(segnatura) || segnatura == "undefined") 
                    throw new Exception("Impossibile visualizzare il documento.");
                
                SiarLibrary.Protocollo doc = new SiarLibrary.Protocollo();
                SiarLibrary.ArchivioFileCollection docs = new SiarLibrary.ArchivioFileCollection();

                var segnatureMultipleCollectionProvider = new SiarBLL.SegnatureMultipleCollectionProvider();
                var segnatureMultipleCollection = segnatureMultipleCollectionProvider.FindPerSignaturaPrincipale(segnatura);

                docs = doc.AF_RicercaProtocollo(segnatura, true);

                if (docs == null) 
                    throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.DocumentoNonValido);

                Session["siar_view_file"] = docs;

                return_object.Html = "[";
                foreach (SiarLibrary.ArchivioFile af in docs)
                    return_object.Html += "{'Titolo':'" + af.NomeFile + "','Formato':'" + af.Tipo + "'},";

                if (return_object.Html.EndsWith(",")) 
                    return_object.Html = return_object.Html.Substring(0, return_object.Html.Length - 1);

                return_object.Html += "]";
            }
            catch (Exception ex) { return_object.setException(ex); }
        }

        [SNCOptions.AuthenticationRequiredAttribute(true)]
        [SNCOptions.ReturnTypeObject(SNCOptions.ReturnTypeObject.Json)]
        public void SNCUFVisualizzaFile()
        {
            try
            {
                SiarLibrary.ArchivioFile file_selezionato = null;
                int id_file;
                if (int.TryParse(Request.Params["id_file"], out id_file))
                    file_selezionato = new SiarBLL.ArchivioFileCollectionProvider().GetById(id_file);
                if (file_selezionato == null || file_selezionato.Contenuto == null || file_selezionato.Contenuto.Length == 0)
                    throw new Exception("Il file selezionato non è valido.");
                SiarLibrary.ArchivioFileCollection docs = new SiarLibrary.ArchivioFileCollection();
                docs.Add(file_selezionato);
                Session["siar_view_file"] = docs;
                return_object.Html = "OK";
            }
            catch (Exception ex) { return_object.setException(ex); }
        }

        [SNCOptions.AuthenticationRequiredAttribute(true)]
        [SNCOptions.ReturnTypeObject(SNCOptions.ReturnTypeObject.Json)]
        public void SNCVZCercaUtenti()
        {
            try
            {
                string pattern = Request.Params["pattern"];

                SiarLibrary.DbProvider db = new SiarLibrary.DbProvider();
                System.Data.IDbCommand cmd = db.GetCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SpZoomUtentiFind";
                if (!string.IsNullOrEmpty(pattern)) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@NOMINATIVO", "%" + pattern + "%"));
                db.InitDatareader(cmd);
                SiarLibrary.UtentiCollection cc = new SiarLibrary.UtentiCollection();
                while (db.DataReader.Read())
                {
                    SiarLibrary.Utenti u = new SiarLibrary.Utenti();
                    u.Profilo = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROFILO"]);
                    u.Ente = new SiarLibrary.NullTypes.StringNT(db.DataReader["ENTE"]);
                    u.IdUtente = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_UTENTE"]);
                    u.CfUtente = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_UTENTE"]);
                    u.IdProfilo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROFILO"]);
                    u.Nominativo = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOMINATIVO"]);
                    u.CodEnte = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_ENTE"]);
                    u.Provincia = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROVINCIA"]);
                    u.IdPersonaFisica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PERSONA_FISICA"]);
                    u.CodTipoEnte = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO_ENTE"]);
                    u.AdditionalAttributes.Add("Descrizione", new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]));
                    cc.Add(u);
                }
                db.Close();
                return_object.Html = cc.ConvertToJSonObject();
            }
            catch (Exception ex) { return_object.setException(ex); }
        }

        [SNCOptions.AuthenticationRequiredAttribute(true)]
        [SNCOptions.ReturnTypeObject(SNCOptions.ReturnTypeObject.Json)]
        public void SNCVZCercaValidatori()
        {
            try
            {
                string pattern = Request.Params["pattern"];

                SiarLibrary.DbProvider db = new SiarLibrary.DbProvider();
                System.Data.IDbCommand cmd = db.GetCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SpZoomValidatoriFind";

                if (!string.IsNullOrEmpty(pattern)) 
                    cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@NOMINATIVO", "%" + pattern + "%"));
                if (Session["idBandoValidazione"] != null)
                {
                    int idBando = (int)Session["idBandoValidazione"];
                    cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_BANDO", idBando));
                }
                
                db.InitDatareader(cmd);
                SiarLibrary.UtentiCollection cc = new SiarLibrary.UtentiCollection();
                while (db.DataReader.Read())
                {
                    SiarLibrary.Utenti u = new SiarLibrary.Utenti();
                    u.Profilo = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROFILO"]);
                    u.Ente = new SiarLibrary.NullTypes.StringNT(db.DataReader["ENTE"]);
                    u.IdUtente = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_UTENTE"]);
                    u.CfUtente = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_UTENTE"]);
                    u.IdProfilo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROFILO"]);
                    u.Nominativo = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOMINATIVO"]);
                    u.CodEnte = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_ENTE"]);
                    u.Provincia = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROVINCIA"]);
                    u.IdPersonaFisica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PERSONA_FISICA"]);
                    u.CodTipoEnte = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO_ENTE"]);
                    u.AdditionalAttributes.Add("Descrizione", new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]));
                    cc.Add(u);
                }
                db.Close();
                return_object.Html = cc.ConvertToJSonObject();
            }
            catch (Exception ex) { return_object.setException(ex); }
        }

        [SNCOptions.AuthenticationRequiredAttribute(true)]
        [SNCOptions.ReturnTypeObject(SNCOptions.ReturnTypeObject.Json)]
        public void SNCVZCercaImpresa()
        {
            try
            {
                string pattern = Request.Params["pattern"];

                SiarLibrary.DbProvider db = new SiarLibrary.DbProvider();
                System.Data.IDbCommand cmd = db.GetCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SpZoomRicercaImpresa";
                if (!string.IsNullOrEmpty(pattern)) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PATTERN", "%" + pattern + "%"));
                db.InitDatareader(cmd);
                SiarLibrary.ImpresaCollection imprese = new SiarLibrary.ImpresaCollection();
                while (db.DataReader.Read())
                {
                    SiarLibrary.Impresa i = new SiarLibrary.Impresa();
                    i.IdImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA"]);
                    i.Cuaa = new SiarLibrary.NullTypes.StringNT(db.DataReader["CUAA"]);
                    i.CodiceFiscale = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE_FISCALE"]);
                    i.RagioneSociale = new SiarLibrary.NullTypes.StringNT(db.DataReader["RAGIONE_SOCIALE"]);
                    i.AdditionalAttributes.Add("Descrizione", i.CodiceFiscale + " - " + i.RagioneSociale);
                    imprese.Add(i);
                }
                db.Close();
                return_object.Html = imprese.ConvertToJSonObject();
            }
            catch (Exception ex) { return_object.setException(ex); }
        }

        [SNCOptions.AuthenticationRequiredAttribute(true)]
        [SNCOptions.ReturnTypeObject(SNCOptions.ReturnTypeObject.Json)]
        public void SNCVZCercaFornitoriProgetto()
        {
            try
            {
                string pattern = Request.Params["pattern"];

                SiarLibrary.DbProvider db = new SiarLibrary.DbProvider();
                System.Data.IDbCommand cmd = db.GetCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SpZoomRicercaFornitoriProgetto";

                if (!string.IsNullOrEmpty(pattern))
                    cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PATTERN", "%" + pattern + "%"));
                
                if (Session["id_progetto"] != null)
                {
                    int idProgetto = (int)Session["id_progetto"];
                    cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IDPROGETTO", idProgetto));
                }

                db.InitDatareader(cmd);
                SiarLibrary.GiustificativiCollection giustificativi = new SiarLibrary.GiustificativiCollection();
                while (db.DataReader.Read())
                {
                    SiarLibrary.Giustificativi g = new SiarLibrary.Giustificativi();
                    g.CfFornitore = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_FORNITORE"]);
                    g.DescrizioneFornitore = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_FORNITORE"]);
                    g.AdditionalAttributes.Add("Descrizione", g.CfFornitore + " - " + g.DescrizioneFornitore);
                    giustificativi.Add(g);
                }
                db.Close();
                return_object.Html = giustificativi.ConvertToJSonObject();
            }
            catch (Exception ex) { return_object.setException(ex); }
        }

        [SNCOptions.AuthenticationRequiredAttribute(true)]
        [SNCOptions.ReturnTypeObject(SNCOptions.ReturnTypeObject.Json)]
        public void SNCCercaImpresa()
        {
            try
            {
                string cuaa = Request.Params["SNCRICuaa"];
                if (string.IsNullOrEmpty(cuaa)) throw new Exception("Digitare il codice fiscale o la p.iva dell`impresa cercata.");
                SiarBLL.ImpresaCollectionProvider impresa_provider = new SiarBLL.ImpresaCollectionProvider();
                SiarLibrary.Impresa impresa = impresa_provider.GetByCuaa(cuaa);
                if (impresa == null)
                {
                    new SianWebSrv.TraduzioneSianToSiar().ScaricaDatiAzienda(cuaa, null, Operatore.Utente.CfUtente);
                    impresa = impresa_provider.GetByCuaa(cuaa);
                }
                if (impresa == null) throw new Exception("L`impresa cercata non è stata trovata.");
                return_object.Html = impresa.ConvertToJSonObject();
            }
            catch (Exception ex) { return_object.setException(ex); }
        }

        [SNCOptions.AuthenticationRequiredAttribute(true)]
        [SNCOptions.ReturnTypeObject(SNCOptions.ReturnTypeObject.Json)]
        public void SNCVZCercaSettoriProduttivi()
        {
            try
            {
                string pattern = null;
                if (!string.IsNullOrEmpty(Request.Params["pattern"])) pattern = "%" + Request.Params["pattern"] + "%";
                SiarLibrary.SettoriProduttiviCollection settori = new SiarBLL.SettoriProduttiviCollectionProvider().
                    Find(null, pattern);
                if (settori.Count > 8)
                {
                    SiarLibrary.SettoriProduttiviCollection settori_temp = new SiarLibrary.SettoriProduttiviCollection();
                    for (int i = 0; i < 8; i++) settori_temp.Add(settori[i]);
                    settori = settori_temp;
                }
                return_object.Html = settori.ConvertToJSonObject();
            }
            catch (Exception ex) { return_object.setException(ex); }
        }

        [SNCOptions.AuthenticationRequiredAttribute(true)]
        [SNCOptions.ReturnTypeObject(SNCOptions.ReturnTypeObject.Json)]
        public void SNCVZCercaAmministrazione()
        {
            try
            {
                string pattern = Request.Params["pattern"];
                string parametri = Request.Params["params"], cod_tipo_amministrazione = null;
                if (!string.IsNullOrEmpty(parametri))
                {
                    System.Web.Script.Serialization.JavaScriptSerializer jsser = new System.Web.Script.Serialization.JavaScriptSerializer();
                    object o = jsser.DeserializeObject(parametri);
                    object s = ((System.Collections.Generic.Dictionary<string, object>)(o))["CodTipoEnte"];
                    if (s != null) cod_tipo_amministrazione = s.ToString();
                }
                SiarLibrary.DbProvider db = new SiarLibrary.DbProvider();
                System.Data.IDbCommand cmd = db.GetCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SpZoomCercaAmministrazione";
                if (!string.IsNullOrEmpty(pattern)) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PATTERN", pattern));
                if (string.IsNullOrEmpty(cod_tipo_amministrazione)) throw new Exception("Per proseguire è necessario specificare la categoria di amministrazione.");
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TIPO_AMMINISTRAZIONE", cod_tipo_amministrazione));
                db.InitDatareader(cmd);
                SiarLibrary.EnteCollection enti = new SiarLibrary.EnteCollection();
                while (db.DataReader.Read())
                {
                    SiarLibrary.Ente e = SiarDAL.EnteDAL.GetFromDatareader(db);
                    e.AdditionalAttributes.Add("IdComune", new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_COMUNE"]));
                    enti.Add(e);
                }
                db.Close();
                return_object.Html = enti.ConvertToJSonObject();
            }
            catch (Exception ex) { return_object.setException(ex); }
        }


        [SNCOptions.AuthenticationRequiredAttribute(true)]
        [SNCOptions.ReturnTypeObject(SNCOptions.ReturnTypeObject.Json)]
        public void ICtrlRecuperoDatiBanca()
        {
            try
            {
                string abi = Request.Params["cabi"], cab = Request.Params["ccab"];
                if (string.IsNullOrEmpty(abi)) return;
                System.Collections.Generic.Dictionary<string, object> dt = SiarLibrary.DbStaticProvider.GetDatiBancaByCC(abi, cab);
                System.Web.Script.Serialization.JavaScriptSerializer jsser = new System.Web.Script.Serialization.JavaScriptSerializer();
                return_object.Html = jsser.Serialize(dt);
            }
            catch (Exception ex) { return_object.setException(ex); }
        }

        [SNCOptions.AuthenticationRequiredAttribute(true)]
        [SNCOptions.ReturnTypeObject(SNCOptions.ReturnTypeObject.Json)]
        public void sncCercaPersonaFisica()
        {
            try
            {
                string cf = Request.Params["SNCCPFCF"];
                if (string.IsNullOrEmpty(cf)) throw new Exception("Il codice fiscale digitato non è valido.");
                SiarLibrary.PersonaFisica pf;
                SiarLibrary.PersonaFisicaCollection persone = new SiarBLL.PersonaFisicaCollectionProvider().Find(cf);
                if (persone.Count == 0 || persone[0].Nome == null) pf = new SianWebSrv.TraduzioneSianToSiar().ScaricaDatiPersonaFisica(cf, Operatore.Utente.CfUtente);
                else pf = persone[0];
                if (pf == null) return_object.setException("Nessun elemento trovato.");
                else return_object.Html = "{'Id':'" + pf.IdPersona + "','Cf':'" + pf.CodiceFiscale.Value.ToUpper() + "','Nominativo':'" + pf.Cognome.ToCleanJsString() + " " + pf.Nome.ToCleanJsString() + "'}";
            }
            catch (Exception ex) { return_object.setException(ex); }
        }

        [SNCOptions.AuthenticationRequiredAttribute(true)]
        [SNCOptions.ReturnTypeObject(SNCOptions.ReturnTypeObject.Json)]
        public void getPlurivaloriRequisitiDomanda()
        {
            try
            {
                int id_requisito;
                if (!int.TryParse(Request.Params["id_requisito"], out id_requisito)) throw new Exception("Il requisito selezionato non è valido.");
                SiarLibrary.ValoriPrioritaCollection cc = new SiarBLL.ValoriPrioritaCollectionProvider().Find(null, id_requisito, null);
                return_object.Html = cc.ConvertToJSonObject();
            }
            catch (Exception ex) { return_object.setException(ex); }
        }

        [SNCOptions.AuthenticationRequiredAttribute(true)]
        [SNCOptions.ReturnTypeObject(SNCOptions.ReturnTypeObject.Json)]
        public void getPlurivaloriSql()
        {
            try
            {
                int id_progetto;
                if (!int.TryParse(Request.Params["id_progetto"], out id_progetto)) throw new Exception("Il progetto selezionato non è valido.");
                bool fase_istruttoria = bool.Parse(Request.Params["fase_istruttoria"]);
                int id_requisito;
                if (!int.TryParse(Request.Params["id_requisito"], out id_requisito)) throw new Exception("Il requisito selezionato non è valido.");
                SiarLibrary.ValoriPrioritaCollection cc = new SiarBLL.ValoriPrioritaCollectionProvider().GetValoriPrioritaSql(id_progetto, fase_istruttoria, id_requisito, null);
                return_object.Html = cc.ConvertToJSonObject();
            }
            catch (Exception ex) { return_object.setException(ex); }
        }

        [SNCOptions.AuthenticationRequiredAttribute(true)]
        [SNCOptions.ReturnTypeObject(SNCOptions.ReturnTypeObject.Json)]
        public void getPlurivaloriBandoConfig()
        {
            try
            {
                string cod_tipo = Request.Params["id_requisito"];
                if (string.IsNullOrEmpty(cod_tipo) || cod_tipo.Length > 30) throw new Exception("L`elemento selezionato non è valido.");
                SiarLibrary.DbProvider db = new SiarLibrary.DbProvider();
                System.Data.IDbCommand cmd = db.GetCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "SELECT COD_TIPO,CODICE,DESCRIZIONE FROM BANDO_CONFIG_TIPO_PARAMETRI WHERE COD_TIPO=@COD_TIPO ORDER BY ORDINE";
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COD_TIPO", cod_tipo));
                db.InitDatareader(cmd);
                System.Text.StringBuilder sb = new System.Text.StringBuilder("[");
                while (db.DataReader.Read()) sb.Append("{'CodTipo':'" + db.DataReader["COD_TIPO"].ToCleanJsString() + "','Codice':'"
                    + db.DataReader["CODICE"].ToCleanJsString() + "','Descrizione':'" + db.DataReader["DESCRIZIONE"].ToCleanJsString() + "'},");
                db.Close();
                sb.Append("]").Replace(",", "", sb.Length - 1, 1);
                return_object.Html = sb.ToString();
            }
            catch (Exception ex) { return_object.setException(ex); }
        }

        [SNCOptions.AuthenticationRequiredAttribute(true)]
        [SNCOptions.ReturnTypeObject(SNCOptions.ReturnTypeObject.Json)]
        public void getMultivaloriBandoConfig()
        {
            try
            {
                string cod_tipo = Request.Params["id_requisito"];
                if (string.IsNullOrEmpty(cod_tipo) || cod_tipo.Length > 30) throw new Exception("L`elemento selezionato non è valido.");
                SiarLibrary.DbProvider db = new SiarLibrary.DbProvider();
                System.Data.IDbCommand cmd = db.GetCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = 
                    @"SELECT COD_TIPO, 
                        CODICE,
                        DESCRIZIONE 
                    FROM BANDO_CONFIG_TIPO_PARAMETRI 
                    WHERE COD_TIPO = @COD_TIPO 
                    ORDER BY ORDINE";
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COD_TIPO", cod_tipo));
                db.InitDatareader(cmd);
                System.Text.StringBuilder sb = new System.Text.StringBuilder("[");
                while (db.DataReader.Read())
                    sb.Append("{'CodTipo':'" + db.DataReader["COD_TIPO"].ToCleanJsString() + "','Codice':'"
                        + db.DataReader["CODICE"].ToCleanJsString() + "','Descrizione':'" + db.DataReader["DESCRIZIONE"].ToCleanJsString() + "'},");
                db.Close();
                sb.Append("]").Replace(",", "", sb.Length - 1, 1);
                return_object.Html = sb.ToString();
            }
            catch (Exception ex) { return_object.setException(ex); }
        }

        [SNCOptions.AuthenticationRequiredAttribute(true)]
        [SNCOptions.ReturnTypeObject(SNCOptions.ReturnTypeObject.Json)]
        public void getPlurivaloriRequisitiPagamento()
        {
            try
            {
                int id_requisito;
                if (!int.TryParse(Request.Params["id_requisito"], out id_requisito)) throw new Exception("Il requisito selezionato non è valido.");
                SiarLibrary.RequisitiPagamentoPlurivaloreCollection cc = new SiarBLL.RequisitiPagamentoPlurivaloreCollectionProvider().Find(null, id_requisito, null);
                return_object.Html = cc.ConvertToJSonObject();
            }
            catch (Exception ex) { return_object.setException(ex); }
        }

        [SNCOptions.AuthenticationRequiredAttribute(true)]
        [SNCOptions.ReturnTypeObject(SNCOptions.ReturnTypeObject.Json)]
        public void CAAREQ_GetDatiFromCF()
        {
            try
            {
                string cf = Request.Params["cf"], tipo_cf = Request.Params["tipo_cf"];
                if (string.IsNullOrEmpty(cf)) throw new Exception("Codice fiscale/P.Iva non valido.");
                if (string.IsNullOrEmpty(tipo_cf) || !tipo_cf.FindValueIn("F", "G")) throw new Exception("Selezionare la tipologia del soggetto da ricercare.");

                if (tipo_cf == "F")
                {
                    SiarLibrary.PersonaFisica pf;
                    SiarLibrary.PersonaFisicaCollection pfcollection = new SiarBLL.PersonaFisicaCollectionProvider().Find(cf);
                    if (pfcollection.Count > 0) pf = pfcollection[0];
                    else
                    {
                        SianWebSrv.TraduzioneSianToSiar trad = new SianWebSrv.TraduzioneSianToSiar();
                        pf = trad.ScaricaDatiPersonaFisica(cf, Operatore.Utente.CfUtente);
                    }
                    if (pf == null) throw new Exception("La persona fisica cercata non è presente in anagrafe tributaria.");
                    return_object.Html = pf.ConvertToJSonObject();
                }
                else
                {
                    SiarBLL.ImpresaCollectionProvider impresa_provider = new SiarBLL.ImpresaCollectionProvider();
                    SiarLibrary.Impresa i = impresa_provider.GetByCuaa(cf);
                    if (i == null)
                    {
                        SianWebSrv.TraduzioneSianToSiar trad = new SianWebSrv.TraduzioneSianToSiar();
                        trad.ScaricaDatiAzienda(cf, null, Operatore.Utente.CfUtente);
                        i = impresa_provider.GetByCuaa(cf);
                    }
                    if (i == null) throw new Exception("La persona giuridica cercata non è presente in anagrafe tributaria.");
                    return_object.Html = i.ConvertToJSonObject();
                }
            }
            catch (Exception ex) { return_object.setException(ex); }
        }

        [SNCOptions.AuthenticationRequiredAttribute(true)]
        [SNCOptions.ReturnTypeObject(web.CONTROLS.SNCOptions.ReturnTypeObject.String)]
        public void getStoricoInvestimento()
        {
            try
            {
                int id_investimento_originale;
                if (!int.TryParse(Request.Form["idinvor"], out id_investimento_originale))
                    throw new Exception("L`investimento cercato non è valido.");
                SiarLibrary.PianoInvestimentiCollection investimenti = new SiarBLL.PianoInvestimentiCollectionProvider().
                    GetStoricoInvestimento(id_investimento_originale);
                string html_str = @"<table width='100%' class=tableNoTab><tr><td class=separatore_big>Elenco delle varizioni effettuate sull'investimento</td></tr><tr><td style='padding-top:10px;padding-bottom:10px'>";
                if (investimenti.Count > 0)
                {
                    html_str += "<table class='tabella' cellspacing='0' border='1' style='width:100%;border-collapse:collapse'><tr class='TESTA1'><td>Nr.</td><td>Priori- tario</td><td>Data</td><td>Fase procedurale</td><td>Valutazione istruttore</td><td>Visualizza</td></tr>";
                    int counter = 1;
                    foreach (SiarLibrary.PianoInvestimenti i in investimenti)
                    {
                        html_str += "<tr class='" + ((decimal)counter / 2 > counter / 2 ? "DataGridRow" : "DataGridRowAlt")
                            + "' style='height:28px'><td align='center' style='width:25px'>" + counter.ToString() + "</td><td style='width:40px;' align='center'>"
                            + (i.IdPrioritaSettoriale == null ? "" : "<img src='" + Request.ApplicationPath + "/images/star_red.gif' />") + "</td><td style='width:70px;' align='center'>" +
                            (i.DataVariazione == null ? i.DataValutazione : i.DataVariazione) + "</td><td style='width:150px;'>"
                            + (i.IdInvestimentoOriginale == null && i.IdVariante == null ? "Rilascio domanda di aiuto" :
                            (i.IdInvestimentoOriginale != null && i.IdVariante == null ? "Istruttoria domanda di aiuto" : (i.CodVariazione == null ?
                            "Variante/A.T.: investimento non modificato" : "Variante/A.T.: investimento modificato (" + i.CodVariazione
                            + ")"))) + "</td><td>" + (i.ValutazioneInvestimento == null ? "" : (i.ValutazioneInvestimento.Value.Length < 180 ?
                            i.ValutazioneInvestimento.Value : i.ValutazioneInvestimento.Value.Substring(0, 177) + "...")) + "</td><td style='width:60px;' align='center'>"
                            + "<img alt='Visualizza' src='" + Request.ApplicationPath + "/images/acrobat.gif' style='cursor:pointer;' onclick=\"SNCVisualizzaReport('rptInvestimentoOriginale',1,'IdInvestimento="
                            + i.IdInvestimento + "');/*return stopEvent(event);*/\" /></td></tr>";
                        counter++;
                    }
                    html_str += "</table>";
                }
                else html_str += "<br /><b> - Nessun elemento trovato.</b>";
                html_str += "</td></tr></table>";
                return_object.Html = /*"'HtmlContent':" +*/ html_str;
            }
            catch (Exception ex) { return_object.setException(ex); }
        }

        [SNCOptions.AuthenticationRequiredAttribute(true)]
        [SNCOptions.ReturnTypeObject(web.CONTROLS.SNCOptions.ReturnTypeObject.Json)]
        public void scaricaVisuraRNA()
        {
            //mi serve idProgetto, idImpresa, tipoV
            try
            {
                int idFile = int.Parse(Request.Form["idFile"]);
                SiarBLL.ArchivioFileCollectionProvider archivioFileCollectionProvider = new SiarBLL.ArchivioFileCollectionProvider();
                SiarLibrary.ArchivioFile af = archivioFileCollectionProvider.GetById(idFile);
                SiarLibrary.ArchivioFileCollection docs = new SiarLibrary.ArchivioFileCollection();
                docs.Add(af);
                Session["siar_view_file"] = docs;
            }
            catch (Exception e)
            { throw new Exception(e.Message); }
        }

        #endregion

        #region metodi senza autenticazione

        [SNCOptions.AuthenticationRequiredAttribute(false)]
        public void getDocumentiBando()
        {
            try
            {
                return_object.Html = "<br /><b> - Nessun elemento trovato.</b>";
                int id_bando;
                if (int.TryParse(Request.Form["idb"], out id_bando))
                {
                    bool Organismi_intermedi = false;
                    string Str_Organismi_intermedi = "";
                    Str_Organismi_intermedi = new SiarBLL.BandoConfigCollectionProvider().GetBandoConfig_OrganismiIntermedi(id_bando);
                    if (Str_Organismi_intermedi == "True")
                        Organismi_intermedi = true;
                    if (Organismi_intermedi)
                    {
                        SiarLibrary.AttiCollection atti_col = new SiarBLL.AttiCollectionProvider().SpPsrGetDocumentiBandoOrganismiInter(id_bando);
                        if(atti_col.Count >0)
                        {
                            return_object.Html = @"<br /><b>Numero documenti trovati: " + atti_col.Count.ToString() + "</b><br />&nbsp;<table class='tabella' style='width:100%;border-collapse:collapse;'><tr class='TESTA1'><td>Nr. atto</td><td>Data</td><td>Descrizione</td></tr>";
                            int counter = 1;
                            foreach (SiarLibrary.Atti a in atti_col)
                            {
                                //return_object.Html += "<tr class='DataGridRow selectable' style='height:40px' onclick=\"location.href='" + a.LinkEsterno
                                return_object.Html += "<tr class='DataGridRow selectable' style='height:40px' onclick=\"window.open('" + a.LinkEsterno
                                    + "','_blank');\"><td align='center' style='width:50px;'>" + a.Numero
                                    + "</td><td align='center' style='width:80px'>" + a.Data + "</td><td align='left'>" + a.Descrizione + "</td></tr>";
                                counter++;
                            }
                            return_object.Html += "</table>";
                        }
                    }
                    else
                    {
                        SiarLibrary.BandoStoricoCollection doc_bando = new SiarBLL.BandoCollectionProvider().GetStoricoDocumentale(id_bando);
                        if (doc_bando.Count > 0)
                        {
                            return_object.Html = @"<br /><b>Numero documenti trovati: " + doc_bando.Count.ToString() + "</b><br />&nbsp;<table class='tabella' style='width:100%;border-collapse:collapse;'><tr class='TESTA1'><td>Nr. atto</td><td>Data</td><td>Descrizione</td></tr>";
                            int counter = 1;
                            foreach (SiarLibrary.BandoStorico s in doc_bando)
                            {
                                return_object.Html += "<tr class='DataGridRow selectable' style='height:40px' onclick=\"visualizzaAtto(" + s.IdAtto
                                    + ");\"><td align='center' style='width:50px;'>" + s.NumeroAtto
                                    + "</td><td align='center' style='width:80px'>" + s.DataAtto + "</td><td align='left'>" + s.Stato + "</td></tr>";
                                counter++;
                            }
                            return_object.Html += "</table>";
                        }
                    }
                }
            }
            catch (Exception ex) { return_object.setException(ex); }
        }

        [SNCOptions.AuthenticationRequiredAttribute(false)]
        [SNCOptions.ReturnTypeObject(SNCOptions.ReturnTypeObject.Json)]
        public void VisualizzaAtto()
        {
            try
            {
                int id_atto;
                if (!int.TryParse(Request.Params["id_atto"], out id_atto)) throw new Exception("Il documento selezionato non è valido.");
                SiarLibrary.Atti a = new SiarBLL.AttiCollectionProvider().GetById(id_atto);
                if (a == null) throw new Exception("Il documento selezionato non è valido.");
                return_object.Html = SiarLibrary.DbStaticProvider.GetJsUrlDecreto(a);
            }
            catch (Exception ex) { return_object.setException(ex); }
        }

        [SNCOptions.AuthenticationRequiredAttribute(false)]
        [SNCOptions.ReturnTypeObject(SNCOptions.ReturnTypeObject.Json)]
        public void SNCGetDocumentoFromOpenAct()
        {
            try
            {
                int id_atto;
                if (!int.TryParse(Request.Params["id_atto"], out id_atto)) throw new Exception("Il documento selezionato non è valido.");
                SiarLibrary.ArchivioFileCollection docs = new SiarBLL.AttiCollectionProvider().GetDocumentoFromOpenAct(id_atto);
                Session["siar_view_file"] = docs;
                return_object.Html = "[";
                foreach (SiarLibrary.ArchivioFile af in docs)
                    return_object.Html += "{'Titolo':'" + af.NomeFile + "','Formato':'" + af.Tipo + "'},";
                if (return_object.Html.EndsWith(",")) return_object.Html = return_object.Html.Substring(0, return_object.Html.Length - 1);
                return_object.Html += "]";
            }
            catch (Exception ex) { return_object.setException(ex); }
        }

        [SNCOptions.AuthenticationRequiredAttribute(false)]
        public void getToolTip()
        {
            try
            {
                string codice = Request.Params["codice"];
                if (!string.IsNullOrEmpty(codice)) return_object.Html = SiarLibrary.DbStaticProvider.GetToolTipByCode(codice, null);
            }
            catch { return_object.Html = string.Empty; }
        }

        #endregion
    }
}