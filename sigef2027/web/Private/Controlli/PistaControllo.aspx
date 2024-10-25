<%@ Page Title="" Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    CodeBehind="PistaControllo.aspx.cs" Inherits="web.Private.Controlli.PistaControllo" %>

<%@ Register Src="~/CONTROLS/SiarNewTabAgid.ascx" TagName="SiarNewTab" TagPrefix="uc3" %>
<%@ Register Src="../../CONTROLS/ZoomLoader.ascx" TagName="ZoomLoader" TagPrefix="uc1" %>
<%@ Register Src="../../CONTROLS/ProgettoIndicatori.ascx" TagName="ProgettoIndicatori" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <script type="text/javascript">
        function zoomBandoSelectFn(obj, clear) { var dec_bando = ""; if (!clear && typeof (obj) != "undefined") dec_bando = obj.Descrizione; $('[id$=txtDescrizioneBando_text]').val(dec_bando); }
        //     function estraiInXLS() {
        //            SNCVisualizzaReport('rptRicercaGeneraleDomande',2,
        //            'DPagamento='+$('[id$=chkPagamenti]')[0].checked
        //            +'|Varianti='+$('[id$=chkVarianti]')[0].checked
        //            +'|AT='+$('[id$=chkAdeguamentiTecnici]')[0].checked
        //            +'|IstConclusa='+$('[id$=chkIstruttoriaConclusa]')[0].checked
        //            +'|IstInCorso='+$('[id$=chkIstruttoriaInCorso]')[0].checked
        //            +'|Annullati='+$('[id$=chkAnnullati]')[0].checked
        //            +($('[id$=txtIdProgetto_text]').val()!=''?'|IdProgetto='+$('[id$=txtIdProgetto_text]').val():'')
        //            +($('[id$=lstStatoProgetto]').val()!=''?'|CodStato='+$('[id$=lstStatoProgetto]').val():'')
        //            +($('[id$=hdnSNZSelectedValue]').val()!=''?'|IdBando='+$('[id$=hdnSNZSelectedValue]').val():'')
        //            +($('[id$=txtCuaa_text]').val()!=''?'|Cuaa='+$('[id$=txtCuaa_text]').val():'')
        //            +($('[id$=txtRagioneSociale_text]').val()!=''?'|RagSociale='+$('[id$=txtRagioneSociale_text]').val():'')
        //            +($('[id$=lstProvince]').val()!=''?'|Provincia='+$('[id$=lstProvince]').val():'')
        //            +($('[id$=lstProgrammazione]').val()!=''?'|IdProgrammazione='+$('[id$=lstProgrammazione]').val():'')
        //            +($('[id$=lstEntiBando]').val()!=''?'|CodEnteBando='+$('[id$=lstEntiBando]').val():'')
        //            +($('[id$=lstIstruttoreAssegnato]').val()!=''?'|IdIstruttore='+$('[id$=lstIstruttoreAssegnato]').val():'')
        //            +($('[id$=lstRespProvinciale]').val()!=''?'|CfRespProvinciale='+$('[id$=lstRespProvinciale]').val():'')
        //);

        function selezionaProgetto(IdProgetto) { $('[id$=hdnIdProgetto]').val(IdProgetto); swapTab(2); }

        //function selezionaProgetto(IdProgetto) {
        //    $('[id$=hdnIdProgetto]').val(IdProgetto);
        //    __doPostBack('visualizza_pista', '');
        //}
    </script>

    <%--   <style>
     table.elenco
        {
            width: 100%;
            border: 4px solid #89BBDB;
            border-collapse: collapse;
        }
        td.elenco
        {
            width: 45%;
            padding: 5px;
            border: 2px solid #89BBDB;
        }
        td.edata
        {
            width: 10%;
            padding: 5px;
            border: 2px solid #89BBDB;
            text-align: center;
        }
        input.elenco
        {
            width: 20px;
            height: 20px;
            cursor: pointer;
            padding-left: 10px;
            padding-right: 10px;
        }
        imageButton.elenco, image.elenco
        {
            width: 20px;
            height: 20px;
            cursor: pointer;
            padding-left: 10px;
            padding-right: 10px;
        }
        label.elenco
        {
            padding-left: 10px;
            padding-right: 10px;
        }
    </style>--%>

    <input id="hdnIdProgetto" type="hidden" name="hdnIdProgetto" runat="server" />


    <uc3:SiarNewTab ID="tabDettaglio" runat="server" TabNames="Elenco Domande di Aiuto|Pista di Controllo" Titolo="Piste di Controllo" />
    <div id="tbElencoBando" class="tableTab pt-5 " runat="server" visible="true">
        <h3 class="py-4">Ricerca Generale Domande di Aiuto</h3>
        <div class="accordion accordion-background-active" id="divRicerca">
            <div class="accordion-item shadow rounded-2 p-2 mb-3">
                <h2 class="accordion-header " id="divRicercaDomande" runat="server">
                    <button class="accordion-button rounded-2" type="button" data-bs-toggle="collapse" data-bs-target="#collapseRicercaDomanda" aria-expanded="true" aria-controls="collapseRicercaDomanda">
                        <b>Ricerca Generale Domande di Aiuto</b>
                    </button>
                </h2>
                <div id="collapseRicercaDomanda" class="accordion-collapse collapse show" role="region" aria-labelledby="divRicercaDomande">
                    <div class="accordion-body rounded bd-form">
                        <div class="container-fluid container-no-margin">
                            <div class="d-flex flex-row justify-content-start align-items-center py-4">
                                <div class="col-md-5">
                                    <label class="active fw-semibold" for="lstProgrammazione">Programmazione</label>
                                    <Siar:ComboZProgrammazione ID="lstProgrammazione" AttivazioneBandi="true" runat="server" CodicePsr="PORFESR20212027">
                                    </Siar:ComboZProgrammazione>
                                </div>
                            </div>
                            <div class="row justify-content-start align-items-center py-4 px-1">
                                <div class="col-md-3">
                                    <label class="active fw-semibold" for="txtIdProgetto">N° Domanda</label>
                                    <Siar:TextBox ID="txtIdProgetto" runat="server" />
                                </div>
                                <div class="col-md-3">
                                    <label class="active fw-semibold" for="lstStatoProgetto">Stato</label>
                                    <Siar:ComboSql ID="lstStatoProgetto" runat="server" DataTextField="DESCRIZIONE" DataValueField="COD_STATO" />
                                </div>
                                <div class="col-md-3">
                                    <label class="active fw-semibold" for="lstIstruttoreAssegnato">Istruttore assegnato</label>
                                    <Siar:ComboSql ID="lstIstruttoreAssegnato" runat="server" DataTextField="NOMINATIVO" DataValueField="ID_UTENTE" />
                                </div>
                                <div class="col-md-3">
                                    <label class="active fw-semibold" for="lstRespProvinciale">Responsabile provinciale</label>

                                    <Siar:ComboSql ID="lstRespProvinciale" runat="server" DataTextField="NOMINATIVO"
                                        DataValueField="ID_UTENTE">
                                    </Siar:ComboSql>
                                </div>
                            </div>

                            <div class="row justify-content-start align-items-center py-5">
                                <div class="col-md-1">
                                    <label class="active fw-semibold">Ricerca tra:</label>
                                </div>
                                <div class="col-md-2">
                                    <asp:CheckBox ID="chkPagamenti" runat="server" CssClass="fw-semibold" Text="Domande di pagamento" />
                                </div>
                                <div class="col-md-2">
                                    <asp:CheckBox ID="chkVarianti" runat="server" CssClass="fw-semibold" Text="Varianti" />
                                </div>
                                <div class="col-md-2">
                                    <asp:CheckBox ID="chkAdeguamentiTecnici" CssClass="fw-semibold" runat="server" Text="Adeguamenti tecnici" />
                                </div>
                            </div>

                            <div class="row justify-content-start align-items-center py-5">
                                <div class="col-md-1">
                                    <label class="active fw-semibold">Con Istruttoria:</label>
                                </div>
                                <div class="col-md-2">
                                    <asp:CheckBox ID="chkIstruttoriaConclusa" CssClass="fw-semibold" runat="server" Text="Conclusa" />
                                </div>
                                <div class="col-md-2">
                                    <asp:CheckBox ID="chkIstruttoriaInCorso" CssClass="fw-semibold" runat="server" Text="In corso" />
                                </div>
                                <div class="col-md-2">
                                    <asp:CheckBox ID="chkAnnullati" CssClass="fw-semibold" runat="server" Text="Annullati" />
                                </div>
                            </div>

                            <div class="paragrafo_bold h5 pt-5">Bando</div>
                            <div class="d-flex flex-row justify-content-start align-items-center py-4">
                                <div class="col-md-3">
                                    <label class="active fw-semibold" for="lstEntiBando">Ente emettitore</label>
                                    <Siar:ComboEntiBando ID="lstEntiBando" runat="server"></Siar:ComboEntiBando>
                                </div>
                                <div class="col-md-1"></div>
                                <div class="col-md-2 justify-content-center">
                                    <uc1:ZoomLoader ID="ucZoomBando" runat="server" AutomaticSearch="True" ColumnsToBind="Descrizione|Scadenza:DataScadenza:d"
                                        KeySearch="Data scadenza <=:DataScadenza:d|Data scadenza >=:DataScadenzaMag:d|Parole chiave:ParoleChiave|Descrizione:Descrizione"
                                        KeyText="Parole chiave" KeyValue="IdBando" SearchMethod="GetBandi" NoClear="false"
                                        JsSelectedItemHandler="zoomBandoSelectFn" IconaPiccola="true" />
                                </div>
                                <div class="col-md-3">
                                    <Siar:TextBox ID="txtDescrizioneBando" runat="server" ReadOnly="True" />
                                </div>

                            </div>

                            <div class="paragrafo_bold h5 pt-5">Impresa</div>
                            <div class="row justify-content-start align-items-center py-4">
                                <div class="col-md-3">
                                    <label class="active fw-semibold" for="txtCuaa">Codice Fiscale/P.Iva</label>
                                    <Siar:TextBox ID="txtCuaa" runat="server" />
                                </div>
                                <div class="col-md-3">
                                    <label class="active fw-semibold" for="txtRagioneSociale">Ragione sociale</label>
                                    <Siar:TextBox ID="txtRagioneSociale" runat="server" />
                                </div>
                                <div class="col-md-3">
                                    <label class="active fw-semibold" for="lstProvince">Provincia sede legale</label>
                                    <Siar:ComboProvince ID="lstProvince" runat="server">
                                    </Siar:ComboProvince>
                                </div>
                            </div>

                            <div class="d-flex flex-row justify-content-start align-items-center py-4">
                                <div class="flex-column p-2">
                                    <Siar:Button ID="btnCerca" runat="server" OnClick="btnCerca_Click" Text="Cerca" Width="150px" />
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <%--  <div class="container-fluid container-no-margin">--%>

        <div class="d-flex flex-row justify-content-between align-items-center pt-5">
            <div class="p-2">
                <asp:Label ID="lblNrElementi" runat="server" Font-Size="Smaller"></asp:Label>
            </div>
            <div class="p-2">
                <input id="btnEstraiXLS" class="btn btn-primary py-2" onclick="return estraiInXLS();" type="button" value="Estrai in XLS" />
            </div>
        </div>
        <div class="row pt-1">
            <div class="table-responsive">
                <Siar:DataGridAgid ID="dgDomande" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" AllowPaging="true" PageSize="15">
                    <HeaderStyle CssClass="headerStyle" />
                    <Columns>
                        <asp:BoundColumn DataField="IdBando" HeaderText="Id Bando">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <Siar:ColonnaLink LinkFields="IdProgetto" LinkFormat="javascript:selezionaProgetto({0});"
                            DataField="IdProgetto" ItemStyle-Font-Bold="true" ItemStyle-Font-Size="13px"
                            HeaderText="N° Domanda" ItemStyle-HorizontalAlign="Center">
                        </Siar:ColonnaLink>
                        <%--<asp:BoundColumn DataField="IdProgetto" HeaderText="Nr. domanda">
                                    <ItemStyle Font-Bold="true" Font-Size="13px" HorizontalAlign="Center" Width="70px" />
                                </asp:BoundColumn>--%>
                        <asp:BoundColumn DataField="Data" HeaderText="Data presentazione">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Stato" HeaderText="Stato">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Misura">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Impresa"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Provincia" HeaderText="Pv sede legale">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGridAgid>
            </div>
        </div>
    </div>
    <div class="tableTab" id="tbPistaControllo" runat="server" visible="false">
        <div class="accordion accordion-background-active" id="collapseExample">
            <div class="accordion-item shadow p-2 mb-3">
                <h2 class="accordion-header" id="divTitolarita" runat="server">
                    <button class="accordion-button rounded-2" type="button" data-bs-toggle="collapse" data-bs-target="#collapseTitoloarita" aria-expanded="true" aria-controls="collapseTitoloarita">
                        <b id="lbTipologia" runat="server"></b>
                    </button>
                </h2>
                  <div id="collapseTitoloarita" class="accordion-collapse collapse show" role="region" aria-labelledby="divTitolarita">
                      <div class="accordion-body bd-form">
                          <asp:Label ID="lblAsse" runat="server"></asp:Label>
                          <br />                       
                          <asp:Label ID="lblAzione" runat="server"></asp:Label>
                          <br />
                          <asp:Label ID="lblIntervento" runat="server"></asp:Label>
                          <br />
                          <asp:Label ID="lblBando" runat="server"></asp:Label>
                          <br />
                          <asp:Label ID="lbAzienda" runat="server"></asp:Label>
                          <br />
                          <asp:Label ID="lbProgetto" runat="server"></asp:Label>
                      </div>
                </div>
            </div>
            <div class="accordion-item shadow p-2 mb-3">
                <h2 class="accordion-header" id="divMonitoraggio" runat="server">
                    <button class="accordion-button rounded-2" type="button" data-bs-toggle="collapse" data-bs-target="#collapseMonitoraggio" aria-expanded="true" aria-controls="collapseMonitoraggio">
                        <b>Monitoraggio</b>
                    </button>
                </h2>
                <div id="collapseMonitoraggio" class="accordion-collapse collapse show" role="region" aria-labelledby="divMonitoraggio">
                    <div class="accordion-body bd-form">               
                            <table class="table">
                                <tr>
                                    <td class="elenco">Stato del progetto
                                    </td>
                                    <td class="elenco">
                                        <asp:Label ID="lblStatoProgetto" runat="server">
                                        </asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="elenco">Data inizio
                                    </td>
                                    <td class="elenco">
                                        <asp:Label ID="lblDataInizioProgetto" runat="server">
                                        </asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="elenco">Data fine prevista
                                    </td>
                                    <td class="elenco">
                                        <asp:Label ID="lblDataFinePrevistaProgetto" runat="server">
                                        </asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="elenco">Data fine effettiva
                                    </td>
                                    <td class="elenco">
                                        <asp:Label ID="lblDataFineEffettivaProgetto" runat="server">
                                        </asp:Label>
                                    </td>
                                </tr>
                            </table>
                       
             

                        <uc2:ProgettoIndicatori ID="ucProgettoInd" runat="server" style="margin-top: 10px; margin-bottom: 10px;" />


                    </div>
                </div>
            </div>
            <div class="accordion-item shadow p-2 mb-3">
                <h2 class="accordion-header" id="divProgrammazione" runat="server">
                    <button class="accordion-button rounded-2" type="button" data-bs-toggle="collapse" data-bs-target="#collapseProgrammazione" aria-expanded="true" aria-controls="collapseProgrammazione">
                        <b>Programmzione</b>
                    </button>
                </h2>
                <div id="collapseProgrammazione" class="accordion-collapse collapse show" role="region" aria-labelledby="divProgrammazione">
                    <div class="accordion-body bd-form">
                        
                            <table class="table">
                                <tr>
                                    <td class="elenco">Riferimento al quadro strategico comune
                                    </td>
                                    <td class="edata">17/12/2013
                                    </td>
                                    <td class="elenco"><a href="https://eur-lex.europa.eu/legal-content/IT/TXT/PDF/?uri=CELEX:32013R1303&from=IT" target="_blank">
                                        <asp:Image ID="Image1" ImageUrl="../../images/lente24.png" class="elenco" runat="server" /></a>
                                        Reg. UE N. 1303/2013
                                    </td>
                                </tr>
                                <tr>
                                    <td class="elenco">Accordo di partenariato
                                    </td>
                                    <td class="edata">29/10/2014
                                    </td>
                                    <td class="elenco">
                                        <a href="http://www.agenziacoesione.gov.it/it/AccordoPartenariato/index.html" target="_blank">
                                            <asp:Image ID="Image2" ImageUrl="../../images/lente24.png" class="elenco" runat="server" /></a>
                                        Accordo di partenariato
                                    </td>
                                </tr>
                                <tr>
                                    <td class="elenco">Valutazione ex ante
                                    </td>
                                    <td class="edata">22/07/2014
                                    </td>
                                    <td class="elenco">
                                        <a href="http://www.regione.marche.it/Portals/0/Europa_Estero/Fondi europei/FESR 14-20/Relazioni di Attuazione e Valutazione/Valutazione_exante_POR FESR Marche2014_2020.pdf?ver=2017-10-02-122443-603" target="_blank">
                                            <asp:Image ID="Image3" ImageUrl="../../images/lente24.png" class="elenco" runat="server" /></a>
                                        Valutazione Ex Ante 2015
                                    </td>
                                </tr>
                                <tr>
                                    <td class="elenco">Approvazione Programma operativo
                                    </td>
                                    <td class="edata">19/12/2017
                                    </td>
                                    <td class="elenco">
                                        <a href="https://opencoesione.gov.it/media/uploads/decisione_por_marche_fesr_2017_12_19.pdf" target="_blank">
                                            <asp:Image ID="Image4" ImageUrl="../../images/lente24.png" class="elenco" runat="server" /></a>
                                        Decisione di esecuzione C(2017) 8948
                                    </td>
                                </tr>
                                <tr>
                                    <td class="elenco">Delibera di Giunta Regionale di presa d'atto dell'approvazione del POR
                                    </td>
                                    <td class="edata">28/12/2017
                                    </td>
                                    <td class="elenco">
                                        <a href="http://www.norme.marche.it/Delibere/2017/DGR1597_17.pdf" target="_blank">
                                            <asp:Image ID="Image5" ImageUrl="../../images/lente24.png" class="elenco" runat="server" /></a>
                                        DGR 1597/2017
                                    </td>
                                </tr>
                            </table>
                    </div>
                </div>
            </div>

            <div class="accordion-item shadow p-2 mb-3">
                <h2 class="accordion-header" id="divSelezioneInterventi" runat="server">
                    <button class="accordion-button rounded-2" type="button" data-bs-toggle="collapse" data-bs-target="#collapseSelezioneInterventi" aria-expanded="true" aria-controls="collapseSelezioneInterventi">
                        <b>Selezione degli Interventi</b>
                    </button>
                </h2>
                <div id="collapseSelezioneInterventi" class="accordion-collapse collapse show" role="region" aria-labelledby="divSelezioneInterventi">
                    <div class="accordion-body bd-form">
                        <table class="table">
                            <tr>
                                <td class="elenco">Criteri di selezione approvati dal Comitato di Sorveglianza
                                </td>
                                <td class="edata"></td>
                                <td class="elenco"></td>
                            </tr>
                            <tr>
                                <td class="elenco">Parere sul bando da parte di Autorità Ambientale e PF Pari Opportunità
                                </td>
                                <td class="edata"></td>
                                <td class="elenco"></td>
                            </tr>
                            <tr>
                                <td class="elenco">Parere di conformità del bando da parte dell’AdG
                                </td>
                                <td class="edata">
                                    <asp:Label ID="lbDataParereAdg" runat="server">
                                    </asp:Label>
                                </td>
                                <td class="elenco">
                                    <input id="btnParereAdg" runat="server" type="image" src="../../images/lente24.png"
                                        value="Visualizza Parere" class="elenco" visible="false" />
                                    <asp:Label ID="lbParereAdg" runat="server"> </asp:Label>
                                </td>
                            </tr>
                            <tr id="tdA1" runat="server">
                                <td class="elenco">Tipo di procedura
                                </td>
                                <td class="edata"></td>
                                <td class="elenco">
                                    <asp:Label ID="lbTipoProcedura" runat="server">
                                    </asp:Label>
                                </td>
                            </tr>
                            <tr id="tdA2" runat="server">
                                <td class="elenco">Decreto di aggiudicazione/affidamento
                                </td>
                                <td class="edata">
                                    <asp:Label ID="lbDataAttoGraduatoria" runat="server">
                                    </asp:Label>
                                </td>
                                <td class="elenco">
                                    <input id="btnVisualizzaAttoGraduatoria" runat="server" type="image" src="../../images/lente24.png"
                                        value="Visualizza atto" class="elenco" visible="false" />
                                    <asp:Label ID="lbAttoGraduatoria" runat="server">
                                    </asp:Label>
                                </td>
                            </tr>
                            <tr id="tdA3" runat="server">
                                <td class="elenco">Stipula del Contratto/Convenzione
                                </td>
                                <td class="edata"></td>
                                <td class="elenco"></td>
                            </tr>
                            <tr id="tdA4" runat="server">
                                <td class="elenco">Data di avvio (tra i requisiti soggettivi)
                                </td>
                                <td class="edata"></td>
                                <td class="elenco"></td>
                            </tr>
                            <tr id="tdA5" runat="server">
                                <td class="elenco">Data di conclusione
                                </td>
                                <td class="edata"></td>
                                <td class="elenco"></td>
                            </tr>
                            <tr id="tdB1" runat="server">
                                <td class="elenco">Bando/Convenzione
                                </td>
                                <td class="edata">
                                    <asp:Label ID="lbDataAttoBandoPubblicazione" runat="server">
                                    </asp:Label>
                                </td>
                                <td class="elenco">
                                    <input id="btnVisualizzaAttoBandoPubblicazione" runat="server" type="image" src="../../images/lente24.png"
                                        value="Visualizza atto" class="elenco" visible="false" />
                                    <asp:Label ID="lbAttoBandoPubblicazione" runat="server">
                                    </asp:Label>
                                </td>
                            </tr>
                            <tr id="tdB2" runat="server">
                                <td class="elenco">Pubblicazione sul BUR del bando
                                </td>
                                <td class="edata">
                                    <asp:Label ID="lbDataAttoBandoPubblicazioneBur" runat="server">
                                    </asp:Label>
                                </td>
                                <td class="elenco">
                                    <asp:Label ID="lbAttoBandoPubblicazioneBur" runat="server">
                                    </asp:Label>
                                </td>
                            </tr>
                            <tr id="tdB3" runat="server">
                                <td class="elenco">Eventuale nomina della commissione di valutazione
                                </td>
                                <td class="edata"></td>
                                <td class="elenco"></td>
                            </tr>
                            <tr id="tdB4" runat="server">
                                <td class="elenco">Domanda di aiuto
                                </td>
                                <td class="edata">
                                    <asp:Label ID="lbDataDomandaAituo" runat="server">
                                    </asp:Label>
                                </td>
                                <td class="elenco">
                                    <input id="btnVisualizzaProgetto" runat="server" type="image" src="../../images/lente24.png"
                                        value="Visualizza Domanda" class="elenco" visible="false" />
                                    <asp:Label ID="lbDomandaAituo" runat="server">
                                    </asp:Label>
                                </td>
                            </tr>
                            <tr id="tdB5" runat="server">
                                <td class="elenco">Valutazione delle proposte
                                </td>
                                <td class="edata">
                                    <asp:Label ID="lbDataVerbaleComitato" runat="server"> </asp:Label>
                                </td>
                                <td class="elenco">
                                    <input id="btnVisualizzaVerbale" runat="server" type="image" src="../../images/lente24.png"
                                        value="Visualizza Verbale" class="elenco" visible="false" />
                                    <asp:Label ID="lbVerbaleComitato" runat="server"> </asp:Label>
                                </td>
                            </tr>
                            <tr id="tdB6" runat="server">
                                <td class="elenco">Eventuale graduatoria
                                </td>
                                <td class="edata">
                                    <asp:Label ID="lbDataGraduatoria" runat="server"> </asp:Label>
                                </td>
                                <td class="elenco">
                                    <input id="btnVisualizzaGraduatoria" runat="server" type="image" src="../../images/lente24.png"
                                        value="Visualizza Verbale" class="elenco" visible="false" />
                                    <asp:Label ID="lbVisualizzaGraduatoria" runat="server"> </asp:Label>
                                </td>
                            </tr>
                            <tr id="tdB7" runat="server">
                                <td class="elenco">Decreto di concessione del contributo
                                </td>
                                <td class="edata">
                                    <asp:Repeater ID="rptAttoGraduatoriaData" runat="server">
                                        <ItemTemplate>
                                            <div style="height: 25px;">
                                                <span><%# Eval("Data", "{0:dd/MM/yyyy}")%></span>
                                            </div>
                                            <hr />
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    <%--                                                        <asp:Label ID="lbDataAttoGraduatoriaSchedaB" runat="server">
                                                        </asp:Label>--%>
                                </td>
                                <td class="elenco">
                                    <asp:Repeater ID="rptAttoGraduatoria" runat="server" OnItemDataBound="rptAttoGraduatoria_ItemDataBound">
                                        <ItemTemplate>
                                            <div style="height: 25px;">
                                                <input id="btnDecretoLiqRpt" type="image" src="../../images/lente24.png" value="Visualizza Decreto" class="elenco" onclick="<%# ProcessMyDataItem(Eval("LinkEsterno"), Eval("IdAtto"))%>;" />
                                                <span>
                                                    <asp:Label ID="lbAttoGraduatoriaRpt" runat="server" />
                                                </span>
                                            </div>
                                            <hr />
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    <%--<input id="btnVisualizzaAttoGraduatoriaSchedaB" runat="server" type="image" src="../../images/lente24.png"
                                                            value="Visualizza atto" class="elenco" visible="false" />
                                                        <asp:Label ID="lbAttoGraduatoriaSchedaB" runat="server">
                                                        </asp:Label>--%>
                                </td>
                            </tr>
                            <tr id="tdB8" runat="server">
                                <td class="elenco">Accettazione/rinuncia del contributo
                                </td>
                                <td class="edata"></td>
                                <td class="elenco"></td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>

            <div class="accordion-item shadow p-2 mb-3">
                <h2 class="accordion-header" id="H1" runat="server">
                    <button class="accordion-button rounded-2" type="button" data-bs-toggle="collapse" data-bs-target="#collapseAttuazioneInterventi" aria-expanded="true" aria-controls="collapseAttuazioneInterventi">
                        <b>Attuazione fisica e finanziaria degli interventi</b>
                    </button>
                </h2>
                <div id="collapseAttuazioneInterventi" class="accordion-collapse collapse show" role="region" aria-labelledby="divSelezioneInterventi">
                    <div class="accordion-body bd-form">
                        <table class="table" id="tbFideVar" runat="server">
                            <tr>
                                <td class="elenco">Estremi della polizza di Fidejussione
                                </td>
                                <td class="edata">
                                    <asp:Repeater ID="rptFidejData" runat="server">
                                        <ItemTemplate>
                                            <div style="height: 25px;">
                                                <span><%# Eval("DataSottoscrizione", "{0:dd/MM/yyyy}")%></span>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </td>
                                <td class="elenco">
                                    <asp:Repeater ID="rptFidej" runat="server">
                                        <ItemTemplate>
                                            <div style="height: 25px;">
                                                <span>Num. <%# Eval("Numero")%> del <%# Eval("DataSottoscrizione", "{0:dd/MM/yyyy}")%> c/o <%# Eval("LuogoSottoscrizione")%> 
                                                </span>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </td>
                            </tr>
                            <tr>
                                <td class="elenco">Contratti
                                </td>
                                <td class="edata"></td>
                                <td class="elenco"></td>
                            </tr>
                            <tr>
                                <td class="elenco">Eventuali Varianti/Variazioni Finanziarie
                                </td>
                                <td class="edata">
                                    <asp:Repeater ID="rptVariantiData" runat="server">
                                        <ItemTemplate>
                                            <div style="height: 25px;">
                                                <br />
                                                <span><%# Eval("DataApprovazione", "{0:dd/MM/yyyy}")%></span>
                                            </div>
                                            <hr />
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </td>
                                <td class="elenco">
                                    <asp:Repeater ID="rptVarianti" runat="server">
                                        <ItemTemplate>
                                            <div style="height: 25px;">

                                                <input type="image" src="../../images/lente24.png" value="Visualizza Variante"
                                                    class="elenco" onclick="sncAjaxCallVisualizzaProtocollo('<%# Eval("SegnaturaApprovazione") %>');" />
                                                <span>
                                                    <%# Eval("SegnaturaApprovazione")%> 
                                                </span>

                                            </div>
                                            <hr />
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </td>
                            </tr>
                        </table>
                        <table class="table" id="tbFideVar2" visibile="false" runat="server">
                            <tr>
                                <td class="elenco">Eventuali Varianti/Variazioni Finanziarie
                                </td>
                                <td class="edata">
                                    <asp:Repeater ID="rptVarianti2Data" runat="server">
                                        <ItemTemplate>
                                            <div style="height: 25px;">
                                                <br />
                                                <span><%# Eval("DataApprovazione", "{0:dd/MM/yyyy}")%></span>
                                            </div>
                                            <hr />
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </td>
                                <td class="elenco">
                                    <asp:Repeater ID="rptVarianti2" runat="server">
                                        <ItemTemplate>
                                            <div style="height: 25px;">

                                                <input type="image" src="../../images/lente24.png" value="Visualizza Variante"
                                                    class="elenco" onclick="sncAjaxCallVisualizzaProtocollo('<%# Eval("SegnaturaApprovazione") %>');" />
                                                <span>
                                                    <%# Eval("SegnaturaApprovazione")%> 
                                                </span>

                                            </div>
                                            <hr />
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </td>
                            </tr>
                        </table>


                        <asp:Repeater ID="rptDomandePagamento" OnItemDataBound="rptDomandePagamento_ItemDataBound" runat="server">
                            <ItemTemplate>
                                <asp:HiddenField ID="hdnIdDomPag" Value='<%# Eval("IdDomandaPagamento") %>' runat="server" />
                                <table id="Table1" class="table" runat="server">
                                    <tr>
                                        <td class="elenco">
                                            <asp:Label ID="lbTipoPagamento" Text='<%# Eval("CodTipo")%>' runat="server"></asp:Label>
                                        </td>
                                        <td class="edata">
                                            <asp:Label ID="lbDataDomandaPag" Text='<%# Eval("DataModifica")%>' runat="server"></asp:Label>
                                        </td>
                                        <td class="elenco">
                                            <input type="image" src="../../images/lente24.png" value="Visualizza Domanda di Pagamento"
                                                class="elenco" onclick="sncAjaxCallVisualizzaProtocollo('<%# Eval("Segnatura") %>');" />
                                            <span>
                                                <%# Eval("Segnatura")%>
                                            </span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="elenco">Decreto di liquidazione
                                        </td>
                                        <td class="edata">
                                            <asp:Repeater ID="rptDecretoLiqData" runat="server">
                                                <ItemTemplate>
                                                    <div style="height: 25px;">
                                                        <br />
                                                        <span><%# Eval("Data","{0:dd/MM/yyyy}")%></span>
                                                    </div>
                                                    <hr />
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </td>
                                        <td class="elenco">
                                            <asp:Repeater ID="rptDecretoLiq" runat="server" OnItemDataBound="rptDecretoLiq_ItemDataBound">
                                                <ItemTemplate>

                                                    <input id="btnDecretoLiqRpt" type="image" src="../../images/lente24.png" value="Visualizza Decreto" class="elenco" onclick="<%# ProcessMyDataItem(Eval("LinkEsterno"),Eval("IdAtto"))%>" />
                                                    <span>
                                                        <asp:Label ID="lbDecretoLiqRpt" runat="server" />
                                                    </span>
                                                    </div>
                                                                              <hr />
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </td>
                                    </tr>
                                    <%--<tr>
                                                            <td class="elenco">
                                                                Richiesta emissione mandato
                                                            </td>
                                                            <td class="edata">
                                                                <asp:Repeater ID="rptRichiestaMandatoData" runat="server">
                                                                    <ItemTemplate>
                                                                        <br /><span><%# Eval("RichiestaMandatoData", "{0:dd/MM/yyyy}")%></span><br />
                                                                    </ItemTemplate>
                                                                </asp:Repeater>
                                                            </td>
                                                            <td class="elenco">
                                                                <asp:Repeater ID="rptRichiestaMandato" runat="server">
                                                                    <ItemTemplate>
                                                                        <input type="image" src="../../images/lente24.png" value="Visualizza Decreto"
                                                                            class="elenco" onclick="sncAjaxCallVisualizzaProtocollo('<%# Eval("RichiestaMandatoSegnatura") %>');" />
                                                                        <span>
                                                                            <%# Eval("RichiestaMandatoSegnatura")%>
                                                                        </span>
                                                                        <br />
                                                                    </ItemTemplate>
                                                                </asp:Repeater>
                                                            </td>
                                                        </tr>--%>
                                    <tr>
                                        <td class="elenco">Mandato
                                        </td>
                                        <td class="edata">
                                            <asp:Repeater ID="rptMandatoData" runat="server">
                                                <ItemTemplate>
                                                    <div style="height: 25px;">
                                                        <br />
                                                        <span><%# Eval("MandatoData", "{0:dd/MM/yyyy}")%></span>
                                                    </div>
                                                    <hr />
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </td>
                                        <td class="elenco">
                                            <asp:Repeater ID="rptMandato" runat="server">
                                                <ItemTemplate>
                                                    <div style="height: 25px;">

                                                        <input type="image" src="../../images/lente24.png" value="Visualizza Decreto"
                                                            class="elenco" onclick="SNCUFVisualizzaFile(<%# Eval("MandatoIdFile") %>);" />
                                                        <span>Numero <%# Eval("MandatoNumero")%> 
                                                        </span>

                                                    </div>
                                                    <hr />
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="elenco">Check list di Validazione
                                        </td>
                                        <td class="edata">
                                            <asp:Label ID="lbDataValidazione" runat="server"></asp:Label>
                                        </td>
                                        <td class="elenco">
                                            <asp:ImageButton ID="ImgValidazione" ImageUrl="../../images/lente24.png" class="elenco"
                                                runat="server" /><asp:Label ID="lbValidazione" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="elenco">Cert. Spesa - Ricezione della dichiarazione di spesa prodotta dall'ADG
                                        </td>
                                        <td class="edata">
                                            <asp:Label ID="lbDataCSAdg" runat="server"></asp:Label>
                                        </td>
                                        <td class="elenco">
                                            <asp:ImageButton ID="ImgCSAdg" ImageUrl="../../images/lente24.png" class="elenco"
                                                runat="server" />

                                            <span>
                                                <asp:Label ID="lbCSAdg" runat="server"></asp:Label>
                                            </span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="elenco">Cert. Spesa - Verbale della funzione di Certificazione
                                        </td>
                                        <td class="edata">
                                            <asp:Label ID="lbDataCSVerbale" runat="server"></asp:Label>
                                        </td>
                                        <td class="elenco">
                                            <asp:ImageButton ID="ImgCSVerbale" ImageUrl="../../images/lente24.png" class="elenco"
                                                runat="server" />
                                            <span>
                                                <asp:Label ID="lbCSVerbale" runat="server"></asp:Label>
                                            </span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="elenco">Cert. Spesa - Periodo contabile di riferimento
                                        </td>
                                        <td class="edata">
                                            <asp:Label ID="lbDataCSContab" runat="server"></asp:Label>
                                        </td>
                                        <td class="elenco">
                                            <asp:Label ID="lbCSContab" runat="server"></asp:Label>
                                        </td>
                                    </tr>

                                </table>
                            </ItemTemplate>
                        </asp:Repeater>

                        <table id="Table2" class="table" runat="server">
                            <tr>
                                <td class="elenco">Verbale di estrazione dei controlli in loco
                                </td>
                                <td class="edata">
                                    <asp:Repeater ID="rptEstrazControlloData" runat="server">
                                        <ItemTemplate>
                                            <div style="height: 25px;">
                                                <br />
                                                <span><%# Eval("Datasegnatura", "{0:dd/MM/yyyy}")%></span>
                                            </div>
                                            <hr />
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </td>
                                <td class="elenco">
                                    <asp:Repeater ID="rptEstrazControllo" runat="server">
                                        <ItemTemplate>
                                            <div style="height: 25px;">

                                                <input type="image" src="../../images/lente24.png" value="Visualizza Verbale Controlli in Loco"
                                                    class="elenco" onclick="sncAjaxCallVisualizzaProtocollo('<%# Eval("Segnatura") %>');" />
                                                <span>
                                                    <%# Eval("Segnatura")%> 
                                                </span>
                                            </div>
                                            <hr />
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </td>
                            </tr>
                            <tr>
                                <td class="elenco">Attestazione e Verbale del controllo in loco
                                </td>
                                <td class="edata">
                                    <asp:Repeater ID="rptVerbControlloData" runat="server">
                                        <ItemTemplate>
                                            <div style="height: 25px;">
                                                <br />
                                                <span><%# Eval("DataSopralluogo", "{0:dd/MM/yyyy}")%></span>
                                            </div>
                                            <hr />
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </td>
                                <td class="elenco">
                                    <asp:Repeater ID="rptVerbControllo" runat="server">
                                        <ItemTemplate>
                                            <div style="height: 25px;">
                                                <input type="image" src="../../images/lente24.png" value="Visualizza Attestazione"
                                                    class="elenco" onclick="SNCUFVisualizzaFile(<%# Eval("IdFileAttestazione") %>);" />
                                                <span>Attestazione  -  
                                                </span>
                                                <input type="image" src="../../images/lente24.png" value="Visualizza Verbale"
                                                    class="elenco" onclick="SNCUFVisualizzaFile(<%# Eval("IdFileVerbale") %>);" />
                                                <span>Verbale  
                                                </span>
                                            </div>
                                            <hr />
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </td>
                            </tr>
                            <tr>
                                <td class="elenco">Check list controllo in loco
                                </td>
                                <td class="edata">
                                    <asp:Repeater ID="rptCkControlloData" runat="server">
                                        <ItemTemplate>
                                            <div style="height: 25px;">
                                                <br />
                                                <span><%# Eval("Datasegnatura", "{0:dd/MM/yyyy}")%></span>
                                            </div>
                                            <hr />
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </td>
                                <td class="elenco">
                                    <asp:Repeater ID="rptCkControllo" runat="server">
                                        <ItemTemplate>
                                            <div style="height: 25px;">
                                                <input type="image" src="../../images/lente24.png" value="Visualizza CheckList"
                                                    class="elenco" onclick="sncAjaxCallVisualizzaProtocollo('<%# Eval("SegnaturaTestata") %>');" />
                                                <span>
                                                    <%# Eval("SegnaturaTestata")%> 
                                                </span>
                                            </div>
                                            <hr />
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>

        </div>

    </div>

</asp:Content>
