<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PianoInvestimentiCovid.ascx.cs" Inherits="web.CONTROLS.PianoInvestimentiCovid" %>
<%@ Register Src="SiarNewToolTip.ascx" TagName="SiarNewToolTip" TagPrefix="uc1" %>

<script type="text/javascript"><!--
    function mostraMisura(id) { $('[id$=hdnIdDASelezionata]').val(id);$('[id$=btnPost]').click(); }
    function calcolaPolizza(idp) { $('[id$=btnRicalcolaPolizza]').click(); }
    function deletePolizza(idp) { if (confirm('Attenzione! Eliminare la polizza fidejussoria?')) $('[id$=btnDelPolizza]').click(); }

    function MostraNascondiDivPiano() {
            var div;
            var img;
            div = $('[id$=divMostraPiano]')[0];
            img = $('[id$=imgMostraPiano]')[0];

            if (img.style.transform == "")
                img.style.transform = "rotate(180deg)";
            else
                img.style.transform = "";

            if (div.style.display === "none") {
                div.style.display = "block";
            } else {
                div.style.display = "none";
            }
        }
//--></script>

<style type="text/css">
    .tdMisura { width: 160px; height: 80px; text-align: center; border: 1px solid #1380c4; border-left: 0; background-color: #1380c4; font-weight: bold; }
    .tdMisura:Hover, .tdMisura.selected { background-color: #ffffff; border-bottom-color: #1380c4; cursor: pointer; }
    .tdMisuraFoot { height: 5px; border: 1px solid #1380c4; border-top: 0; background-color: #ffffff; }
</style>
<div style="display: none">
    <asp:Button ID="btnPost" runat="server" OnClick="btnPost_Click" CausesValidation="False" />
    <asp:HiddenField ID="hdnButton" runat="server" />
    <asp:Button ID="btnRicalcolaPolizza" runat="server" OnClick="btnPolizza_Click" />
    <asp:Button ID="btnDelPolizza" runat="server" OnClick="btnDelPolizza_Click" CausesValidation="False" />
</div>
<%--<div class="dBox" id="dBoxPaino" runat="server">
    <div class="separatore" style="cursor: pointer; padding-bottom: 3px;" onclick="MostraNascondiDivPiano();">
        <img id="imgMostraPiano" runat="server" style="width: 23px; height: 23px;" />
        Piano degli investimenti 
    </div>
    <div class="dSezione" id="divMostraPiano">--%>
        <div width="60%">
            <div>
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td>
                            <table id="tbMisura" runat="server" cellpadding="0" cellspacing="0" visible="false">
                                <tr>
                                    <td class="tdMisura" style="border-left: 1px solid #1380c4;" onclick="mostraMisura(0);">VISUALIZZA TUTTI<br />
                                        GLI INVESTIMENTI
                                    </td>
                                </tr>
                            </table>
                            <asp:HiddenField ID="hdnIdDASelezionata" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td id="tdButtons" runat="server" style="height: 60px; padding-right: 30px" align="right" visible="false"></td>
                    </tr>
                    <tr>
                        <td>
                            <table id="tableInvestimenti" width="100%" runat="server" visible="false">
                                <tr>
                                    <td class="separatore">Contributo:
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-bottom: 10px">
                                        <Siar:DataGrid ID="dgInvestimenti" runat="server" AutoGenerateColumns="False" EnableViewState="False"
                                            Width="100%">
                                            <ItemStyle Height="30px" />
                                            <Columns>
                                                <Siar:NumberColumn HeaderText="Nr.">
                                                    <FooterStyle HorizontalAlign="center" Width="40px" />
                                                    <ItemStyle HorizontalAlign="center" Width="40px" />
                                                </Siar:NumberColumn>
                                                <asp:BoundColumn DataField="Misura" HeaderText="Programmazione">
                                                    <ItemStyle HorizontalAlign="center" Width="100px" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn HeaderText="Descrizione"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="SettoreProduttivo" HeaderText="Settore produttivo" Visible="false">
                                                    <ItemStyle Width="80px" HorizontalAlign="center" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="CostoInvestimento" HeaderText="Costo investimento" DataFormatString="{0:c}">
                                                    <FooterStyle HorizontalAlign="right" Width="100px" />
                                                    <ItemStyle HorizontalAlign="right" Width="100px" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="SpeseGenerali" HeaderText="Spese tecniche" DataFormatString="{0:c}" Visible="false">
                                                    <FooterStyle HorizontalAlign="right" Width="100px" />
                                                    <ItemStyle HorizontalAlign="right" Width="100px" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn HeaderText="Contributo ammissibile" DataField="ContributoRichiesto"
                                                    DataFormatString="{0:c}">
                                                    <FooterStyle HorizontalAlign="right" Width="100px" />
                                                    <ItemStyle HorizontalAlign="right" Width="100px" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="QuotaContributoRichiesto" HeaderText="% Quota contributo ammissibile">
                                                    <FooterStyle HorizontalAlign="right" Width="80px" />
                                                    <ItemStyle HorizontalAlign="right" Width="80px" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn HeaderText="Rata di reintegrazione" Visible="false">
                                                    <FooterStyle HorizontalAlign="right" Width="100px" />
                                                    <ItemStyle HorizontalAlign="right" Width="100px" />
                                                </asp:BoundColumn>
                                            </Columns>
                                        </Siar:DataGrid>
                                        <table width="100%" id="tbLegendaInvestimenti" runat="server" visible="false">
                                            <tr>
                                                <td style="width: 400px">(*) = investimenti <b>NON</b> cofinanziati
                                                </td>
                                                <td>(**) = contributo troncato per superamento <b>massimali</b> di domanda
                                                </td>
                                                <td align="right">(***) = contributo a <b>quota fissa</b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-bottom: 20px; width: 400px;">la stella
                                                   
                                                    <img id="imgRedStar" runat="server" />
                                                    evidenzia gli <b>investimenti prioritari</b> di settore
                                                </td>
                                                <td style="padding-bottom: 20px;" align="right">per la legenda completa cliccare
                                                   
                                                    <uc1:SiarNewToolTip ID="SiarNewToolTip1" runat="server" Codice="legenda_pianoinvestimenti" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <table id="tableBrevetti" width="100%" runat="server" visible="false">
                                <tr>
                                    <td class="separatore">Brevetti & licenze:
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-bottom: 20px">
                                        <Siar:DataGrid ID="dgBrevetti" runat="server" AutoGenerateColumns="False" Width="100%">
                                            <ItemStyle Height="30px" />
                                            <Columns>
                                                <asp:BoundColumn DataField="Misura" HeaderText="Programmazione">
                                                    <ItemStyle HorizontalAlign="center" Width="130px" />
                                                </asp:BoundColumn>
                                                <Siar:ColonnaLink DataField="Descrizione" HeaderText="Descrizione tecnica" IsJavascript="false"
                                                    LinkFields="IdProgetto|IdInvestimento" LinkFormat="InvestimentiBrevettiLicenze.aspx?idpcurrent={0}&idinv={1}">
                                                </Siar:ColonnaLink>
                                                <asp:BoundColumn DataField="CostoInvestimento" HeaderText="Ammontare spese" DataFormatString="{0:c}">
                                                    <ItemStyle HorizontalAlign="right" Width="120px" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn HeaderText="Contributo ammissibile" DataField="ContributoRichiesto"
                                                    DataFormatString="{0:c}">
                                                    <ItemStyle HorizontalAlign="right" Width="120px" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="QuotaContributoRichiesto" HeaderText="% Quota contributo ammissibile">
                                                    <ItemStyle HorizontalAlign="right" Width="120px" />
                                                </asp:BoundColumn>
                                            </Columns>
                                        </Siar:DataGrid>
                                    </td>
                                </tr>
                            </table>
                            <table id="tableMutuo" runat="server" width="100%" visible="false">
                                <tr>
                                    <td class="separatore">Dettagli del mutuo:
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-bottom: 20px">
                                        <Siar:DataGrid ID="dgMutuo" runat="server" AutoGenerateColumns="False" Width="100%">
                                            <ItemStyle Height="30px" />
                                            <Columns>
                                                <asp:BoundColumn DataField="Misura" HeaderText="Programmazione">
                                                    <ItemStyle HorizontalAlign="center" Width="90px" />
                                                </asp:BoundColumn>
                                                <Siar:ColonnaLink DataField="Descrizione" HeaderText="Descrizione tecnica" IsJavascript="false"
                                                    LinkFields="IdProgetto" LinkFormat="InvestimentiContoInteressi.aspx?idpcurrent={0}">
                                                </Siar:ColonnaLink>
                                                <asp:BoundColumn DataField="SpeseGenerali" HeaderText="Ammontare degli investimenti per cui si richiede il mutuo"
                                                    DataFormatString="{0:c}">
                                                    <ItemStyle HorizontalAlign="right" Width="120px" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="CostoInvestimento" HeaderText="Ammontare del mutuo" DataFormatString="{0:c}">
                                                    <ItemStyle HorizontalAlign="right" Width="120px" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn HeaderText="Contributo ammissibile" DataField="ContributoRichiesto"
                                                    DataFormatString="{0:c}">
                                                    <ItemStyle HorizontalAlign="right" Width="100px" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="QuotaContributoRichiesto" HeaderText="Tasso di attualizzazione %">
                                                    <ItemStyle HorizontalAlign="right" Width="100px" />
                                                </asp:BoundColumn>
                                            </Columns>
                                        </Siar:DataGrid>
                                    </td>
                                </tr>
                            </table>
                            <table id="tableFidejussione" width="100%" runat="server" visible="false">
                                <tr>
                                    <td class="separatore">Polizza fidejussoria:
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-bottom: 20px">
                                        <Siar:DataGrid ID="dgFidejussione" runat="server" AutoGenerateColumns="False" Width="100%">
                                            <ItemStyle Height="30px" />
                                            <Columns>
                                                <asp:BoundColumn DataField="Misura" HeaderText="Programmazione">
                                                    <ItemStyle HorizontalAlign="center" Width="90px" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione tecnica"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="CostoInvestimento" HeaderText="Ammontare spese" DataFormatString="{0:c}">
                                                    <ItemStyle HorizontalAlign="right" Width="120px" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn HeaderText="Contributo ammissibile" DataField="ContributoRichiesto"
                                                    DataFormatString="{0:c}">
                                                    <ItemStyle HorizontalAlign="right" Width="120px" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="QuotaContributoRichiesto" HeaderText="% Quota contributo ammissibile">
                                                    <ItemStyle HorizontalAlign="right" Width="120px" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn>
                                                    <ItemStyle HorizontalAlign="center" Width="80px" />
                                                </asp:BoundColumn>
                                            </Columns>
                                        </Siar:DataGrid>
                                    </td>
                                </tr>
                            </table>
                            <table id="tablePremio" runat="server" width="100%" visible="false">
                                <tr>
                                    <td class="separatore">Premio in conto capitale:
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding: 10px">
                                        <table width="100%">
                                            <tr>
                                                <td style="width: 220px">Programmazione:<br />
                                                    <Siar:TextBox ID="txtPCCProgrammazione" runat="server" ReadOnly="True" Width="190px" />
                                                </td>
                                                <td>Ammontare raggiunto €:<br />
                                                    <Siar:CurrencyBox ID="txtPCCAmmontare" runat="server" Width="130px" ReadOnly="True" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
<%--    </div>
</div>--%>
