<%@ Page Title="" Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    CodeBehind="PistaControllo.aspx.cs" Inherits="web.Private.Controlli.PistaControllo" %>

<%--<%@ Register Src="../../CONTROLS/SiarNewTab.ascx" TagName="SiarNewTab" TagPrefix="uc2" %>--%>
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
        function selezionaProgetto(IdProgetto) {
            $('[id$=hdnIdProgetto]').val(IdProgetto);
            __doPostBack('visualizza_pista', '');
        }
    </script>

    <style>
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
    </style>
    <input id="hdnIdProgetto" type="hidden" name="hdnIdProgetto" runat="server" />
    <Siar:SiarTab ID="SiarNewTab" runat="server" Tabs="Elenco Domande di Aiuto|Pista di Controllo"
        FullValidate="True" Width="1100px">
        <table class="tableTab" id="tbElencoBando" width="1100px" runat="server">
            <tr>
                <td>
                    <table width="100%">
                        <tr>
                            <td class="separatore_big">
                                RICERCA GENERALE DOMANDE DI AIUTO
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-top: 10px; padding-left: 10px">
                                <table style="width: 100%">
                                    <tr>
                                        <td style="height: 50px">
                                            Programmazione:<br />
                                            <Siar:ComboZProgrammazione ID="lstProgrammazione" AttivazioneBandi="true" runat="server"
                                                Width="670px" CodicePsr="POR20142020">
                                            </Siar:ComboZProgrammazione>
                                        </td>
                                    </tr>
                                </table>
                                <table style="width: 100%">
                                    <tr>
                                        <td style="width: 80px; padding-right: 10px">
                                            Nr. domanda:<br />
                                            <Siar:IntegerTextBox ID="txtIdProgetto" runat="server" NoCurrency="True" Width="80px" />
                                        </td>
                                        <%--<td style="width: 50px; padding-right: 20px">
                                        Stato:<br />
                                        <Siar:ComboStatoProgetto ID="lstStatoProgetto" runat="server">
                                        </Siar:ComboStatoProgetto>
                                    </td>--%>
                                        <td style="width: 50px; padding-right: 20px">
                                            Stato:<br />
                                            <Siar:ComboSql ID="lstStatoProgetto" runat="server" Width="136px" DataTextField="DESCRIZIONE"
                                                DataValueField="COD_STATO">
                                            </Siar:ComboSql>
                                        </td>
                                        <td style="width: 210px; padding-right: 20px">
                                            Istruttore assegnato:<br />
                                            <Siar:ComboSql ID="lstIstruttoreAssegnato" runat="server" DataTextField="NOMINATIVO"
                                                DataValueField="ID_UTENTE" Width="220px">
                                            </Siar:ComboSql>
                                        </td>
                                        <td>
                                            Responsabile provinciale:<br />
                                            <Siar:ComboSql ID="lstRespProvinciale" runat="server" DataTextField="NOMINATIVO"
                                                DataValueField="ID_UTENTE" Width="200px">
                                            </Siar:ComboSql>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left: 10px">
                                <table>
                                    <tr>
                                        <td style="width: 120px; height: 25px;">
                                            <b>RICERCA TRA:</b>
                                        </td>
                                        <td style="padding-right: 10px; height: 25px;">
                                            <asp:CheckBox ID="chkPagamenti" runat="server" Text="Domande di pagamento" />
                                        </td>
                                        <td style="padding-right: 10px; height: 25px;">
                                            <asp:CheckBox ID="chkVarianti" runat="server" Text="Varianti" />
                                        </td>
                                        <td style="padding-right: 10px; height: 25px;">
                                            <asp:CheckBox ID="chkAdeguamentiTecnici" runat="server" Text="Adeguamenti tecnici" />
                                        </td>
                                    </tr>
                                </table>
                                <table>
                                    <tr>
                                        <td style="width: 120px; height: 25px;">
                                            <b>CON ISTRUTTORIA:</b>
                                        </td>
                                        <td style="padding-right: 10px; height: 25px;">
                                            <asp:CheckBox ID="chkIstruttoriaConclusa" runat="server" Text="Conclusa" />
                                        </td>
                                        <td style="padding-right: 10px; height: 25px;">
                                            <asp:CheckBox ID="chkIstruttoriaInCorso" runat="server" Text="In corso" />
                                        </td>
                                        <td style="padding-right: 10px; height: 25px;">
                                            <asp:CheckBox ID="chkAnnullati" runat="server" Text="Annullati" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left: 10px">
                                <table>
                                    <tr>
                                        <td class="paragrafo" colspan="2">
                                            Bando:
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 200px">
                                            Ente emettitore:<br />
                                            <Siar:ComboEntiBando ID="lstEntiBando" runat="server" Width="180px">
                                            </Siar:ComboEntiBando>
                                        </td>
                                        <td>
                                            <br />
                                            <table style="width: 100%;" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td style="width: 40px">
                                                        <uc1:ZoomLoader ID="ucZoomBando" runat="server" AutomaticSearch="True" ColumnsToBind="Descrizione|Scadenza:DataScadenza:d"
                                                            KeySearch="Data scadenza <=:DataScadenza:d|Data scadenza >=:DataScadenzaMag:d|Parole chiave:ParoleChiave|Descrizione:Descrizione"
                                                            KeyText="Parole chiave" KeyValue="IdBando" SearchMethod="GetBandi" NoClear="false"
                                                            JsSelectedItemHandler="zoomBandoSelectFn" IconaPiccola="true" Width="800px" />
                                                    </td>
                                                    <td>
                                                        <Siar:TextBox ID="txtDescrizioneBando" runat="server" ReadOnly="True" Width="400px" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left: 10px">
                                <table>
                                    <tr>
                                        <td class="paragrafo" colspan="3">
                                            Impresa:
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 180px">
                                            Codice Fiscale/P.Iva:<br />
                                            <Siar:TextBox ID="txtCuaa" runat="server" Style="margin-right: 21px" Width="150px" />
                                        </td>
                                        <td style="width: 230px">
                                            Ragione sociale:<br />
                                            <Siar:TextBox ID="txtRagioneSociale" runat="server" Style="margin-right: 21px" Width="200px" />
                                        </td>
                                        <td>
                                            Provincia sede legale:<br />
                                            <Siar:ComboProvince ID="lstProvince" runat="server">
                                            </Siar:ComboProvince>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="height: 61px">
                                <Siar:Button ID="btnCerca" runat="server" OnClick="btnCerca_Click" Text="Cerca" Width="150px" />
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <input id="btnEstraiXLS" class="Button" onclick="estraiInXLS();" style="width: 150px"
                                    type="button" value="Estrai in XLS" />
                            </td>
                        </tr>
                        <tr>
                            <td class="separatore_light">
                                Elementi trovati:
                                <asp:Label ID="lblNrElementi" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-top: 15px; padding-bottom: 15px">
                                <Siar:DataGrid ID="dgDomande" runat="server" Width="100%" AllowPaging="true" PageSize="15"
                                    AutoGenerateColumns="false">
                                    <ItemStyle Height="28px" />
                                    <Columns>
                                        <asp:BoundColumn DataField="IdBando" HeaderText="Id Bando">
                                            <ItemStyle HorizontalAlign="Center" Width="40px" />
                                        </asp:BoundColumn>
                                        <Siar:ColonnaLink LinkFields="IdProgetto" LinkFormat="javascript:selezionaProgetto({0});"
                                            DataField="IdProgetto" ItemStyle-Font-Bold="true" ItemStyle-Font-Size="13px"
                                            HeaderText="Nr. domanda" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="70px">
                                        </Siar:ColonnaLink>
                                        <%--<asp:BoundColumn DataField="IdProgetto" HeaderText="Nr. domanda">
                                        <ItemStyle Font-Bold="true" Font-Size="13px" HorizontalAlign="Center" Width="70px" />
                                    </asp:BoundColumn>--%>
                                        <asp:BoundColumn DataField="Data" HeaderText="Data presentazione">
                                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="Stato" HeaderText="Stato">
                                            <ItemStyle HorizontalAlign="Center" Width="130px" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="Misura">
                                            <ItemStyle HorizontalAlign="Center" Width="90px" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="Impresa"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="Provincia" HeaderText="Pv sede legale">
                                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                                        </asp:BoundColumn>
                                    </Columns>
                                </Siar:DataGrid>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table width="100%">
                        <tr>
                            <td class="separatore_big">
                                <label id="lbTipologia" runat="server">
                                </label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table style="width: 100%">
                                    <tr>
                                        <td style="padding-left: 10px">
                                            <br />
                                            <asp:Label ID="lblAsse" runat="server"></asp:Label>
                                            <br />
                                            <br />
                                            <asp:Label ID="lblAzione" runat="server"></asp:Label>
                                            <br />
                                            <br />
                                            <asp:Label ID="lblIntervento" runat="server"></asp:Label>
                                            <br />
                                            <br />
                                            <asp:Label ID="lblBando" runat="server"></asp:Label>
                                            <br />
                                            <br />
                                            <asp:Label ID="lbAzienda" runat="server"></asp:Label>
                                            <br />
                                            <br />
                                            <asp:Label ID="lbProgetto" runat="server"></asp:Label>
                                            <br />
                                            <br />
                                        </td>
                                    </tr>
                                </table>
                                <table style="width: 100%">
                                    <tr>
                                        <td class="separatore">
                                            Monitoraggio
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px">
                                            <table class="elenco">
                                                <tr>
                                                    <td class="elenco">
                                                        Stato del progetto
                                                    </td>
                                                    <td class="elenco">
                                                        <asp:Label ID="lblStatoProgetto" runat="server">
                                                        </asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="elenco">
                                                        Data inizio
                                                    </td>
                                                    <td class="elenco">
                                                        <asp:Label ID="lblDataInizioProgetto" runat="server">
                                                        </asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="elenco">
                                                        Data fine prevista
                                                    </td>
                                                    <td class="elenco">
                                                        <asp:Label ID="lblDataFinePrevistaProgetto" runat="server">
                                                        </asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="elenco">
                                                        Data fine effettiva
                                                    </td>
                                                    <td class="elenco">
                                                        <asp:Label ID="lblDataFineEffettivaProgetto" runat="server">
                                                        </asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px">
                                            <uc2:ProgettoIndicatori ID="ucProgettoInd" runat="server" style="margin-top:10px; margin-bottom:10px;" />
                                        </td>
                                    </tr>
                                </table>
                                <table style="width: 100%">
                                    <tr>
                                        <td class="separatore">
                                            Programmazione
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px">
                                            <table class="elenco">
                                                <tr>
                                                    <td class="elenco">
                                                        Riferimento al quadro strategico comune
                                                    </td>
                                                    <td class="edata">17/12/2013
                                                    </td>
                                                    <td class="elenco"><a href="https://eur-lex.europa.eu/legal-content/IT/TXT/PDF/?uri=CELEX:32013R1303&from=IT" target="_blank">
                                                        <asp:Image ID="Image1"  ImageUrl="../../images/lente24.png" class="elenco" runat="server"   /></a>
                                                        Reg. UE N. 1303/2013
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="elenco">
                                                        Accordo di partenariato
                                                    </td>
                                                    <td class="edata">29/10/2014
                                                    </td>
                                                    <td class="elenco">
                                                        <a href="http://www.agenziacoesione.gov.it/it/AccordoPartenariato/index.html" target="_blank">
                                                        <asp:Image ID="Image2"  ImageUrl="../../images/lente24.png" class="elenco" runat="server"  /></a>
                                                        Accordo di partenariato
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="elenco">
                                                        Valutazione ex ante
                                                    </td>
                                                    <td class="edata">22/07/2014
                                                    </td>
                                                    <td class="elenco">
                                                        <a href="http://www.regione.marche.it/Portals/0/Europa_Estero/Fondi europei/FESR 14-20/Relazioni di Attuazione e Valutazione/Valutazione_exante_POR FESR Marche2014_2020.pdf?ver=2017-10-02-122443-603" target="_blank">
                                                        <asp:Image ID="Image3"  ImageUrl="../../images/lente24.png" class="elenco" runat="server"  /></a>
                                                        Valutazione Ex Ante 2015
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="elenco">
                                                        Approvazione Programma operativo
                                                    </td>
                                                    <td class="edata">19/12/2017
                                                    </td>
                                                    <td class="elenco">
                                                        <a href="https://opencoesione.gov.it/media/uploads/decisione_por_marche_fesr_2017_12_19.pdf" target="_blank">
                                                        <asp:Image ID="Image4"  ImageUrl="../../images/lente24.png" class="elenco" runat="server"  /></a>
                                                        Decisione di esecuzione C(2017) 8948
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="elenco">
                                                        Delibera di Giunta Regionale di presa d'atto dell'approvazione del POR
                                                    </td>
                                                    <td class="edata">28/12/2017
                                                    </td>
                                                    <td class="elenco">
                                                        <a href="http://www.norme.marche.it/Delibere/2017/DGR1597_17.pdf" target="_blank">
                                                        <asp:Image ID="Image5"  ImageUrl="../../images/lente24.png" class="elenco" runat="server"  /></a>
                                                        DGR 1597/2017
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                <table style="width: 100%">
                                    <tr>
                                        <td class="separatore">
                                            Selezione degli interventi
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px">
                                            <table class="elenco">
                                                <tr>
                                                    <td class="elenco">
                                                        Criteri di selezione approvati dal Comitato di Sorveglianza
                                                    </td>
                                                    <td class="edata">
                                                    </td>
                                                    <td class="elenco">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="elenco">
                                                        Parere sul bando da parte di Autorità Ambientale e PF Pari Opportunità
                                                    </td>
                                                    <td class="edata">
                                                    </td>
                                                    <td class="elenco">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="elenco">
                                                        Parere di conformità del bando da parte dell’AdG
                                                    </td>
                                                    <td class="edata">
                                                        <asp:Label ID="lbDataParereAdg" runat="server">
                                                        </asp:Label>
                                                    </td>
                                                    <td class="elenco">
                                                        <input id="btnParereAdg" runat="server" type="image" src="../../images/lente24.png"
                                                            value="Visualizza Parere" class="elenco" visible="false"/>
                                                        <asp:Label ID="lbParereAdg" runat="server"> </asp:Label>
                                                    </td>
                                                </tr>
                                                <tr id="tdA1" runat="server">
                                                    <td class="elenco">
                                                        Tipo di procedura
                                                    </td>
                                                    <td class="edata">
                                                    </td>
                                                    <td class="elenco">
                                                        <asp:Label ID="lbTipoProcedura" runat="server">
                                                        </asp:Label>
                                                    </td>
                                                </tr>
                                                <tr id="tdA2" runat="server">
                                                    <td class="elenco">
                                                        Decreto di aggiudicazione/affidamento
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
                                                    <td class="elenco">
                                                        Stipula del Contratto/Convenzione
                                                    </td>
                                                    <td class="edata">
                                                    </td>
                                                    <td class="elenco">
                                                    </td>
                                                </tr>
                                                <tr id="tdA4" runat="server">
                                                    <td class="elenco">
                                                        Data di avvio (tra i requisiti soggettivi)
                                                    </td>
                                                    <td class="edata">
                                                    </td>
                                                    <td class="elenco">
                                                    </td>
                                                </tr>
                                                <tr id="tdA5" runat="server">
                                                    <td class="elenco">
                                                        Data di conclusione
                                                    </td>
                                                    <td class="edata">
                                                    </td>
                                                    <td class="elenco">
                                                    </td>
                                                </tr>
                                                <tr id="tdB1" runat="server">
                                                    <td class="elenco">
                                                        Bando/Convenzione
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
                                                    <td class="elenco">
                                                        Pubblicazione sul BUR del bando
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
                                                    <td class="elenco">
                                                        Eventuale nomina della commissione di valutazione
                                                    </td>
                                                    <td class="edata">
                                                    </td>
                                                    <td class="elenco">
                                                    </td>
                                                </tr>
                                                <tr id="tdB4" runat="server">
                                                    <td class="elenco">
                                                        Domanda di aiuto
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
                                                    <td class="elenco">
                                                        Valutazione delle proposte
                                                    </td>
                                                    <td class="edata">
                                                        <asp:Label ID="lbDataVerbaleComitato" runat="server"> </asp:Label>
                                                    </td>
                                                    <td class="elenco">
                                                        <input id="btnVisualizzaVerbale" runat="server" type="image" src="../../images/lente24.png"
                                                            value="Visualizza Verbale" class="elenco" visible="false"/>
                                                        <asp:Label ID="lbVerbaleComitato" runat="server"> </asp:Label>
                                                    </td>
                                                </tr>
                                                <tr id="tdB6" runat="server">
                                                    <td class="elenco">
                                                        Eventuale graduatoria
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
                                                    <td class="elenco">
                                                        Decreto di concessione del contributo
                                                    </td>
                                                    <td class="edata">
                                                        <asp:Repeater ID="rptAttoGraduatoriaData" runat="server">
                                                            <ItemTemplate>
                                                                <div style="height:25px;">
                                                                    <span><%# Eval("Data", "{0:dd/MM/yyyy}")%></span>
                                                                </div><hr />
                                                            </ItemTemplate>                                                        
                                                        </asp:Repeater>
<%--                                                        <asp:Label ID="lbDataAttoGraduatoriaSchedaB" runat="server">
                                                        </asp:Label>--%>
                                                    </td>
                                                    <td class="elenco">
                                                        <asp:Repeater ID="rptAttoGraduatoria" runat="server" OnItemDataBound="rptAttoGraduatoria_ItemDataBound">
                                                            <ItemTemplate>
                                                                <div style="height:25px;">
                                                                    <input id="btnAttoGraduatoriaRpt" type="image" src="../../images/lente24.png" value="Visualizza Decreto"
                                                                        class="elenco" onclick="<%# ProcessMyDataItem(Eval("LinkEsterno"), Eval("IdAtto")) %>" />
                                                                    <span>
                                                                        <asp:Label ID="lbAttoGraduatoriaRpt" runat="server" />
                                                                    </span>
                                                                </div><hr />
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                        <%--<input id="btnVisualizzaAttoGraduatoriaSchedaB" runat="server" type="image" src="../../images/lente24.png"
                                                            value="Visualizza atto" class="elenco" visible="false" />
                                                        <asp:Label ID="lbAttoGraduatoriaSchedaB" runat="server">
                                                        </asp:Label>--%>
                                                    </td>
                                                </tr>
                                                <tr id="tdB8" runat="server">
                                                    <td class="elenco">
                                                        Accettazione/rinuncia del contributo
                                                    </td>
                                                    <td class="edata">
                                                    </td>
                                                    <td class="elenco">
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                <table style="width: 100%">
                                    <tr>
                                        <td class="separatore">
                                            Attuazione fisica e finanziaria degli interventi
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px">
                                            <table class="elenco" id="tbFideVar" runat="server">
                                                <tr>
                                                    <td class="elenco">
                                                        Estremi della polizza di Fidejussione
                                                    </td>
                                                    <td class="edata">
                                                        <asp:Repeater ID="rptFidejData" runat="server">
                                                            <ItemTemplate>
                                                                <div style="height:25px;">
                                                                    <span><%# Eval("DataSottoscrizione", "{0:dd/MM/yyyy}")%></span>
                                                                </div>
                                                            </ItemTemplate>                                                        
                                                        </asp:Repeater>
                                                    </td>
                                                    <td class="elenco">
                                                        <asp:Repeater ID="rptFidej" runat="server">
                                                            <ItemTemplate>
                                                                <div style="height:25px;">
                                                                    <span>
                                                                        Num. <%# Eval("Numero")%> del <%# Eval("DataSottoscrizione", "{0:dd/MM/yyyy}")%> c/o <%# Eval("LuogoSottoscrizione")%> 
                                                                    </span>
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="elenco">
                                                        Contratti
                                                    </td>
                                                    <td class="edata">
                                                    </td>
                                                    <td class="elenco">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="elenco">
                                                        Eventuali Varianti/Variazioni Finanziarie
                                                    </td>
                                                    <td class="edata">
                                                       <asp:Repeater ID="rptVariantiData" runat="server">
                                                            <ItemTemplate>
                                                                <div style="height:25px;">
                                                                <br />
                                                                    <span><%# Eval("DataApprovazione", "{0:dd/MM/yyyy}")%></span>
                                                                </div><hr />
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </td>
                                                    <td class="elenco">
                                                        <asp:Repeater ID="rptVarianti" runat="server">
                                                            <ItemTemplate>
                                                                <div style="height:25px;">

                                                                <input type="image" src="../../images/lente24.png" value="Visualizza Variante"
                                                                    class="elenco" onclick="sncAjaxCallVisualizzaProtocollo('<%# Eval("SegnaturaApprovazione") %>');" />
                                                                <span>
                                                                    <%# Eval("SegnaturaApprovazione")%> 
                                                                </span>
                                                                        
                                                                </div><hr />
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table class="elenco" id="tbFideVar2" visibile="false" runat="server">
                                                <tr>
                                                    <td class="elenco">
                                                        Eventuali Varianti/Variazioni Finanziarie
                                                    </td>
                                                    <td class="edata">
                                                       <asp:Repeater ID="rptVarianti2Data" runat="server">
                                                            <ItemTemplate>
                                                                <div style="height:25px;">
                                                                <br />
                                                                    <span><%# Eval("DataApprovazione", "{0:dd/MM/yyyy}")%></span>
                                                                </div><hr />
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </td>
                                                    <td class="elenco">
                                                        <asp:Repeater ID="rptVarianti2" runat="server">
                                                            <ItemTemplate>
                                                                <div style="height:25px;">

                                                                <input type="image" src="../../images/lente24.png" value="Visualizza Variante"
                                                                    class="elenco" onclick="sncAjaxCallVisualizzaProtocollo('<%# Eval("SegnaturaApprovazione") %>');" />
                                                                <span>
                                                                    <%# Eval("SegnaturaApprovazione")%> 
                                                                </span>
                                                                        
                                                                </div><hr />
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px">
                                            <asp:Repeater ID="rptDomandePagamento" OnItemDataBound="rptDomandePagamento_ItemDataBound"
                                                runat="server">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="hdnIdDomPag" Value='<%# Eval("IdDomandaPagamento") %>' runat="server" />
                                                    <table id="Table1" class="elenco" runat="server">
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
                                                            <td class="elenco">
                                                                Decreto di liquidazione
                                                            </td>
                                                            <td class="edata">
                                                                <asp:Repeater ID="rptDecretoLiqData" runat="server">
                                                                    <ItemTemplate>
                                                                    <div style="height:25px;">
                                                                        <br /><span><%# Eval("Data","{0:dd/MM/yyyy}")%></span>
                                                                    </div><hr />
                                                                    </ItemTemplate>
                                                                </asp:Repeater>
                                                            </td>
                                                            <td class="elenco">
                                                                <asp:Repeater ID="rptDecretoLiq" runat="server" OnItemDataBound="rptDecretoLiq_ItemDataBound">
                                                                    <ItemTemplate>
                                                                        <div style="height:25px;">
                                                                            <input id="btnDecretoLiqRpt" type="image" src="../../images/lente24.png" value="Visualizza Decreto"
                                                                                class="elenco" onclick="<%# ProcessMyDataItem(Eval("LinkEsterno"), Eval("IdAtto")) %>" />
                                                                            <span>
                                                                                <asp:Label ID="lbDecretoLiqRpt" runat="server" />
                                                                            </span>
                                                                        </div><hr />
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
                                                            <td class="elenco">
                                                                Mandato
                                                            </td>
                                                            <td class="edata">
                                                                <asp:Repeater ID="rptMandatoData" runat="server">
                                                                    <ItemTemplate>
                                                                        <div style="height:25px;">
                                                                        <br />
                                                                            <span><%# Eval("MandatoData", "{0:dd/MM/yyyy}")%></span>
                                                                        </div><hr />
                                                                    </ItemTemplate>
                                                                </asp:Repeater>
                                                            </td>
                                                            <td class="elenco">
                                                                <asp:Repeater ID="rptMandato" runat="server">
                                                                    <ItemTemplate>
                                                                        <div style="height:25px;">

                                                                        <input type="image" src="../../images/lente24.png" value="Visualizza Decreto"
                                                                            class="elenco" onclick="SNCUFVisualizzaFile(<%# Eval("MandatoIdFile") %>);" />
                                                                        <span>
                                                                            Numero <%# Eval("MandatoNumero")%> 
                                                                        </span>
                                                                        
                                                                        </div><hr />
                                                                    </ItemTemplate>
                                                                </asp:Repeater>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="elenco">
                                                                Check list di Validazione
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
                                                            <td class="elenco">
                                                                Cert. Spesa - Ricezione della dichiarazione di spesa prodotta dall'ADG
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
                                                            <td class="elenco">
                                                                Cert. Spesa - Verbale della funzione di Certificazione
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
                                                            <td class="elenco">
                                                                Cert. Spesa - Periodo contabile di riferimento
                                                            </td>
                                                            <td class="edata">
                                                                <asp:Label ID="lbDataCSContab" runat="server"></asp:Label>
                                                            </td>
                                                            <td class="elenco">
                                                                <asp:Label ID="lbCSContab" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>




                                                    </table>
                                                    <br />
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px">
                                            <table id="Table2" class="elenco" runat="server">
                                                <tr>
                                                    <td class="elenco">
                                                        Verbale di estrazione dei controlli in loco
                                                    </td>
                                                    <td class="edata">
                                                       <asp:Repeater ID="rptEstrazControlloData" runat="server">
                                                            <ItemTemplate>
                                                                <div style="height:25px;">
                                                                <br />
                                                                    <span><%# Eval("Datasegnatura", "{0:dd/MM/yyyy}")%></span>
                                                                </div><hr />
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </td>
                                                    <td class="elenco">
                                                        <asp:Repeater ID="rptEstrazControllo" runat="server">
                                                            <ItemTemplate>
                                                                <div style="height:25px;">

                                                                <input type="image" src="../../images/lente24.png" value="Visualizza Verbale Controlli in Loco"
                                                                    class="elenco" onclick="sncAjaxCallVisualizzaProtocollo('<%# Eval("Segnatura") %>');" />
                                                                <span>
                                                                    <%# Eval("Segnatura")%> 
                                                                </span>    
                                                                </div><hr />
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="elenco">
                                                        Attestazione e Verbale del controllo in loco
                                                    </td>
                                                    <td class="edata">
                                                        <asp:Repeater ID="rptVerbControlloData" runat="server">
                                                            <ItemTemplate>
                                                                <div style="height:25px;">
                                                                <br />
                                                                    <span><%# Eval("DataSopralluogo", "{0:dd/MM/yyyy}")%></span>
                                                                </div><hr />
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </td>
                                                    <td class="elenco">
                                                        <asp:Repeater ID="rptVerbControllo" runat="server">
                                                            <ItemTemplate>
                                                                <div style="height:25px;">
                                                                    <input type="image" src="../../images/lente24.png" value="Visualizza Attestazione"
                                                                        class="elenco" onclick="SNCUFVisualizzaFile(<%# Eval("IdFileAttestazione") %>);" />
                                                                    <span>
                                                                        Attestazione  -  
                                                                    </span>
                                                                    <input type="image" src="../../images/lente24.png" value="Visualizza Verbale"
                                                                    class="elenco" onclick="SNCUFVisualizzaFile(<%# Eval("IdFileVerbale") %>);" />
                                                                    <span>
                                                                        Verbale  
                                                                    </span>   
                                                                </div><hr />
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="elenco">
                                                        Check list controllo in loco
                                                    </td>
                                                    <td class="edata">
                                                       <asp:Repeater ID="rptCkControlloData" runat="server">
                                                            <ItemTemplate>
                                                                <div style="height:25px;">
                                                                <br />
                                                                    <span><%# Eval("Datasegnatura", "{0:dd/MM/yyyy}")%></span>
                                                                </div><hr />
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </td>
                                                    <td class="elenco">
                                                        <asp:Repeater ID="rptCkControllo" runat="server">
                                                            <ItemTemplate>
                                                                <div style="height:25px;">
                                                                    <input type="image" src="../../images/lente24.png" value="Visualizza CheckList"
                                                                        class="elenco" onclick="sncAjaxCallVisualizzaProtocollo('<%# Eval("SegnaturaTestata") %>');" />
                                                                    <span>
                                                                        <%# Eval("SegnaturaTestata")%> 
                                                                    </span>    
                                                                </div><hr />
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                <%--<table style="width: 100%">
                                    <tr>
                                        <td class="separatore">
                                            Certificazione della spesa
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px">
                                            <table class="elenco">
                                                
                                            </table>
                                        </td>
                                    </tr>
                                </table>--%>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 52px" align="center">
                                <Siar:Button ID="btnFinanziario" runat="server" CausesValidation="False" OnClick="btnStampaFinanz_Click"
                                    Text="Pista Finanziaria" Width="180px" />
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <Siar:Button ID="btnStampa" runat="server" CausesValidation="False" OnClick="btnStampa_Click"
                                    Text="Stampa" Width="180px" />

                            </td>

                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </Siar:SiarTab>
    <table class="tableTab" id="tbPistaControllo" runat="server" width="1100px">
    </table>
</asp:Content>
