<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.Istruttoria.ComunicazioneNonRicevibilita" CodeBehind="ComunicazioneNonRicevibilita.aspx.cs" %>

<%@ Register Src="../../CONTROLS/FirmaDocumento.ascx" TagName="FirmaDocumento" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
        function firmaDocumento(idprogetto) { $('[id$=hdnIdProgetto]').val(idprogetto);$('[id$=btnFirmaComunicazione]').click(); }
 //--></script>

    <br />
    <table width="1000px" class="tableNoTab">
        <tr>
            <td class="separatore_big">
                COMUNICAZIONE DI NON RICEVIBILITA'
            </td>
        </tr>
        <tr>
            <td>
                <Siar:Button ID="btnFirmaComunicazione" runat="server" OnClick="btnFirmaComunicazione_Click"
                    Style="display: none" />
                <Siar:Hidden ID="hdnIdProgetto" runat="server">
                </Siar:Hidden>
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%">
                    <tr>
                        <td class="testo_pagina">
                            Elenco delle domande non ricevibili ed eventuale comunicazione effettuata<br /><br />
                            - Numero domande non ricevibili: <b>
                                <asp:Label ID="lblDomande" runat="server"></asp:Label></b><br />
                            - Numero comunicazioni da effettuare: <b>
                                <asp:Label ID="lblComunicazioni" runat="server"></asp:Label></b>
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
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dg" runat="server" AutoGenerateColumns="False" PageSize="20" Width="100%"
                    FooterText="(la modifica è abilitata solo per i responsabili provinciali di istruttoria)">
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle HorizontalAlign="Center" Width="35px" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn HeaderText="Domanda">
                            <ItemStyle Width="280px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Provincia">
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Stato procedurale attuale">
                            <ItemStyle HorizontalAlign="Center" Width="120px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Segnatura del documento">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
        <tr>
            <td align="right" style="height: 60px; padding-right: 30px">
                &nbsp;
                <input type="button" onclick="location='Collaboratori.aspx'" value="Indietro" style="width: 180px"
                    class="Button" />&nbsp;&nbsp;&nbsp;
            </td>
        </tr>
    </table>
    <uc2:FirmaDocumento runat="server" ID="ucFirmaComunicazione" Titolo="COMUNICAZIONE DI NON RICEVIBILITA`"
        TipoDocumento="NON_RICEVIBILITA" />
</asp:Content>
