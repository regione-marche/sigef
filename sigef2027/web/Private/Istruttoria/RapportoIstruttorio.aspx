<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.Istruttoria.RapportoIstruttorio" CodeBehind="RapportoIstruttorio.aspx.cs" %>

<%@ Register Src="../../CONTROLS/FirmaDocumento.ascx" TagName="FirmaDocumento" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
        function firmaDocumento(idprogetto) {
            $('[id$=hdnIdProgetto]').val(idprogetto);
            $('#ctl00_cphContenuto_btnFirmaRapporto').click();
        }
        function viewProtocollo(segnatura) { document.getElementById("ctl00_cphContenuto_hdnSegnatura").value=segnatura;document.getElementById("ctl00_cphContenuto_btnViewProtocollo").click(); }
//--></script>

    <br />
    <table width="900px" class="tableNoTab">
        <tr>
            <td class="separatore_big">
                RAPPORTO ISTRUTTORIO
            </td>
        </tr>
        <tr>
            <td style="height: 96px">
                <table width="100%">
                    <tr>
                        <td class="testo_pagina">
                            Elenco delle domande ammissibili e non ammissibili ed eventuale rapporto firmato<br />
                            <br />
                            - Numero istruttorie di competenza da sottoscrivere:&nbsp;<b>
                                <asp:Label ID="lblCompetenza" runat="server"></asp:Label></b><br />
                            - Numero istruttorie totali da sottoscrivere:&nbsp;<b>
                                <asp:Label ID="lblTotali" runat="server"></asp:Label>
                                <div style="display: none">
                                    <asp:Button ID="btnFirmaRapporto" runat="server" OnClick="btnFirmaRapporto_Click" />
                                    <asp:HiddenField ID="hdnIdProgetto" runat="server" />
                                </div>
                            </b>
                        </td>
                        <td style="width: 300px">
                            <table width="100%" style="border-right: black 1px solid; border-top: black 1px solid;
                                border-left: black 1px solid; border-bottom: black 1px solid">
                                <tr>
                                    <td align="left" class="separatore">
                                        &nbsp;Applica filtro per provincia:
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 45px" align="center">
                                        <Siar:ComboProvince ID="lstProvincia" runat="server" CodRegione="11" AutoPostBack="true">
                                        </Siar:ComboProvince>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dg" runat="server" AutoGenerateColumns="False" PageSize="15" Width="100%"
                    FooterText="(la modifica è abilitata solo per i responsabili provinciali di istruttoria)"
                    AllowPaging="True">
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle HorizontalAlign="Center" Width="35px" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn HeaderText="Domanda">
                            <ItemStyle Width="300px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ProvinciaAssegnazione" HeaderText="Provincia">
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Stato" HeaderText="Stato procedurale attuale">
                            <ItemStyle HorizontalAlign="Center" Width="120px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Segnatura rapporto istruttorio">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>&nbsp;
            </td>
        </tr>
        <tr>
            <td align="right">
                <input id="btnIndietro" runat="server" type="button" onclick="javascript:location='Collaboratori.aspx'"
                    value="Indietro" style="width: 180px" class="Button" />&nbsp;&nbsp;
            </td>
        </tr>
    </table>
    <uc2:FirmaDocumento ID="ucFirmaRapportoIstruttorio" runat="server" TipoDocumento="RAPPORTO_ISTRUTTORIO"
        Titolo="FIRMA RAPPORTO ISTRUTTORIO" DoppiaFirma="true" />
</asp:Content>
