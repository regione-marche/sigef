<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    CodeBehind="RicercaGeneraleDomande.aspx.cs" Inherits="web.Private.Psr.Bandi.RicercaGeneraleDomande" %>

<%@ Register Src="../../../CONTROLS/ZoomLoader.ascx" TagName="ZoomLoader" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <script type="text/javascript"><!--
        function zoomBandoSelectFn(obj,clear) { var dec_bando="";if(!clear&&typeof (obj)!="undefined") dec_bando=obj.Descrizione;$('[id$=txtDescrizioneBando_text]').val(dec_bando); }
        function estraiInXLS() {
            SNCVisualizzaReport('rptRicercaGeneraleDomande',2,
            'DPagamento='+$('[id$=chkPagamenti]')[0].checked
            +'|Varianti='+$('[id$=chkVarianti]')[0].checked
            +'|AT='+$('[id$=chkAdeguamentiTecnici]')[0].checked
            +'|IstConclusa='+$('[id$=chkIstruttoriaConclusa]')[0].checked
            +'|IstInCorso='+$('[id$=chkIstruttoriaInCorso]')[0].checked
            +'|Annullati='+$('[id$=chkAnnullati]')[0].checked
            +($('[id$=txtIdProgetto_text]').val()!=''?'|IdProgetto='+$('[id$=txtIdProgetto_text]').val():'')
            +($('[id$=lstStatoProgetto]').val()!=''?'|CodStato='+$('[id$=lstStatoProgetto]').val():'')
            +($('[id$=hdnSNZSelectedValue]').val()!=''?'|IdBando='+$('[id$=hdnSNZSelectedValue]').val():'')
            +($('[id$=txtCuaa_text]').val()!=''?'|Cuaa='+$('[id$=txtCuaa_text]').val():'')
            +($('[id$=txtRagioneSociale_text]').val()!=''?'|RagSociale='+$('[id$=txtRagioneSociale_text]').val():'')
            +($('[id$=lstProvince]').val()!=''?'|Provincia='+$('[id$=lstProvince]').val():'')
            +($('[id$=lstProgrammazione]').val()!=''?'|IdProgrammazione='+$('[id$=lstProgrammazione]').val():'')
            +($('[id$=lstEntiBando]').val()!=''?'|CodEnteBando='+$('[id$=lstEntiBando]').val():'')
            +($('[id$=lstIstruttoreAssegnato]').val()!=''?'|IdIstruttore='+$('[id$=lstIstruttoreAssegnato]').val():'')
            + ($('[id$=lstRespProvinciale]').val() != '' ? '|CfRespProvinciale=' + $('[id$=lstRespProvinciale]').val() : '')
            + ($('[id$=lstTipoPag]').val() != '' ? '|TipoDomPag=' + $('[id$=lstTipoPag]').val() : '')
            
);
        }
//--></script>

    <table class="tableNoTab" width="1100px">
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
                            <Siar:ComboGroupZProgrammazione ID="lstProgrammazione" AttivazioneBandi="true" runat="server"
                                Width="670px">
                            </Siar:ComboGroupZProgrammazione>
                        </td>
                    </tr>
                </table>
                <table style="width: 100%">
                    <tr>
                        <td style="width: 80px; padding-right: 10px">
                            Nr. domanda:<br />
                            <Siar:IntegerTextBox ID="txtIdProgetto" runat="server" NoCurrency="True" Width="80px" />
                        </td>
                        <td style="width: 50px; padding-right: 20px">
                            Stato:<br />
                            <Siar:ComboStatoProgetto ID="lstStatoProgetto" runat="server">
                            </Siar:ComboStatoProgetto>
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
                    </tr>
                </table>
                <table>
                    <tr>
                        <td style="width: 120px; height: 25px;">
                           Tipo Domanda di Pagamento:
                        </td>
                        <td style="padding-right: 10px; height: 25px;">
                            <Siar:ComboTipoDomandaPagamento id="lstTipoPag" runat="server" ></Siar:ComboTipoDomandaPagamento>
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
                                        <uc1:ZoomLoader ID="ucZoomBando" runat="server" AutomaticSearch="True" ColumnsToBind="Descrizione|Scadenza:DataScadenza:d|Id Bando:Idbando"
                                            KeySearch="Data scadenza <=:DataScadenza:d|Data scadenza >=:DataScadenzaMag:d|Parole chiave:ParoleChiave|Descrizione:Descrizione|Id Bando:IdBando" KeyText="Parole chiave"
                                            KeyValue="IdBando" SearchMethod="GetBandi" NoClear="false" JsSelectedItemHandler="zoomBandoSelectFn"
                                            IconaPiccola="true" Width="800px"/>
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
                        <asp:BoundColumn DataField="IdProgetto" HeaderText="Nr. domanda">
                            <ItemStyle Font-Bold="true" Font-Size="13px" HorizontalAlign="Center" Width="70px" />
                        </asp:BoundColumn>
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
                        <asp:BoundColumn>
                            <ItemStyle HorizontalAlign="Center" Width="150px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn>
                            <ItemStyle HorizontalAlign="Center" Width="150px" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
    </table>
</asp:Content>
