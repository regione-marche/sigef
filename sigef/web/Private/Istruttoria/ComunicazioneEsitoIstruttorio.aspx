<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.Istruttoria.ComunicazioneEsitoIstruttorio" CodeBehind="ComunicazioneEsitoIstruttorio.aspx.cs" %>

<%@ Register Src="../../CONTROLS/FirmaDocumento.ascx" TagName="FirmaDocumento" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
        function firmaDocumento(idprogetto) { $('#ctl00_cphContenuto_hdnIdProgetto').val(idprogetto);$('#ctl00_cphContenuto_btnFirmaComunicazione').click(); }
        function viewProtocollo(segnatura) { document.getElementById("ctl00_cphContenuto_hdnSegnatura").value=segnatura;document.getElementById("ctl00_cphContenuto_btnViewProtocollo").click(); }
//--></script>

    <br />
    <table width="1000px" class="tableNoTab">
        <tr>
            <td class="separatore_big">
                COMUNICAZIONE DI ESITO ISTRUTTORIO
            </td>
        </tr>
        <tr>
            <td>
                <div style="display: none">
                    <Siar:Button ID="btnFirmaComunicazione" runat="server" OnClick="btnFirmaComunicazione_Click" />
                </div>
                <Siar:Hidden ID="hdnIdProgetto" runat="server">
                </Siar:Hidden>
                <asp:Button ID="btnViewProtocollo" runat="server" OnClick="btnViewProtocollo_Click"
                    Style="display: none" Text="Button" /><Siar:Hidden ID="hdnSegnatura" runat="server">
                    </Siar:Hidden>
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%">
                    <tr>
                        <td class="testo_pagina" style="width: 596px">
                            Elenco delle domande ammissibili ed eventuale comunicazione effettuata<br />
                            <br />
                            - Numero domande ammissibili:&nbsp;<b>
                                <asp:Label ID="lblDomande" runat="server"></asp:Label></b><br />
                            - Comunicazioni da effettuare:&nbsp;<b>
                                <asp:Label ID="lblComunicazioni" runat="server"></asp:Label></b>
                        </td>
                        <td>
                            <table width="100%" style="border-right: black 1px solid; border-top: black 1px solid;
                                border-left: black 1px solid; border-bottom: black 1px solid">
                                <tr>
                                    <td class="separatore" colspan="3" style="width: 137px">
                                        &nbsp;Applica filtro:
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 61px; width: 108px; padding-left: 20px;">
                                        Nr. domanda:<br />
                                        <Siar:IntegerTextBox ID="txtNrDomanda" runat="server" NoCurrency="True" Width="80px" />
                                    </td>
                                    <td style="height: 61px; width: 144px;">
                                        Provincia:<br />
                                        <Siar:ComboProvince ID="lstProvincia" runat="server" CodRegione="11">
                                        </Siar:ComboProvince>
                                    </td>
                                    <td style="height: 61px">
                                        <br />
                                        &nbsp;
                                        <Siar:Button ID="btnCerca" runat="server" OnClick="btnCerca_Click" Text="Cerca" Width="80px" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dg" runat="server" AutoGenerateColumns="False" PageSize="15" Width="100%"
                    FooterText="(la modifica è abilitata solo per il responsabile regionale di istruttoria)"
                    AllowPaging="True">
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle HorizontalAlign="Center" Width="35px" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn HeaderText="Domanda">
                            <ItemStyle Width="280px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ProvinciaAssegnazione" HeaderText="Provincia">
                            <ItemStyle HorizontalAlign="Center" Width="70px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Stato" HeaderText="Stato procedurale attuale">
                            <ItemStyle HorizontalAlign="Center" Width="120px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Comunicazione esito istruttorio">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>&nbsp;
            </td>
        </tr>
        <tr>
            <td align="right">
                <input id="btnIndietro" runat="server" type="button" onclick="location='Collaboratori.aspx'"
                    value="Indietro" style="width: 180px" class="Button" />&nbsp;&nbsp;
            </td>
        </tr>
    </table>
    <uc2:FirmaDocumento ID="ucFirmaComunicazione" TipoDocumento="COMUNICAZIONE_ESITO_ISTRUTTORIO"
        Titolo="COMUNICAZIONE DI ESITO ISTRUTTORIO" runat="server" />
</asp:Content>
