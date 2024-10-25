<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.Istruttoria.ComunicazioneFinanziabilita" CodeBehind="ComunicazioneFinanziabilita.aspx.cs" %>

<%@ Register Src="../../CONTROLS/FirmaDocumento.ascx" TagName="FirmaDocumento" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript">
<!--
        function firmaDocumento(idprogetto) {

            $('#ctl00_cphContenuto_hdnIdProgetto').val(idprogetto);
            $('#ctl00_cphContenuto_btnFirmaComunicazione').click();
        }
        function viewProtocollo(segnatura) {
            document.getElementById("ctl00_cphContenuto_hdnSegnatura").value=segnatura;
            document.getElementById("ctl00_cphContenuto_btnViewProtocollo").click();
        }

//-->
    </script>

    <br />
    <table width="1000px" class="tableNoTab">
        <tr>
            <td class="separatore_big">
                COMUNICAZIONE DI FINANZIABILITA'
            </td>
        </tr>
        <tr>
            <td>
                <div style="display: none">
                    <Siar:Button ID="btnFirmaComunicazione" runat="server" OnClick="btnFirmaComunicazione_Click" />
                    <Siar:Hidden ID="hdnIdProgetto" runat="server">
                    </Siar:Hidden>
                    <asp:Button ID="btnViewProtocollo" runat="server" OnClick="btnViewProtocollo_Click" />
                    <Siar:Hidden ID="hdnSegnatura" runat="server">
                    </Siar:Hidden>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%">
                    <tr>
                        <td class="testo_pagina" style="width: 414px">
                            Elenco delle domande finanziabili e non ed eventuale comunicazione effettuata<br />
                            <br />
                            - Numero domande finanziabili:&nbsp;<b>
                                <asp:Label ID="lblDomande" runat="server"></asp:Label></b><br />
                            - Comunicazioni da effettuare:&nbsp;<b>
                                <asp:Label ID="lblComunicazioni" runat="server"></asp:Label></b>
                        </td>
                        <td style="width: 300px" valign="bottom">
                            <table width="100%" style="border-right: black 1px solid; border-top: black 1px solid;
                                border-left: black 1px solid; border-bottom: black 1px solid">
                                <tr>
                                    <td align="left" class="separatore" style="height: 17px">
                                        &nbsp;Applica filtro per stato:
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 45px" align="center">
                                        &nbsp;<Siar:ComboBase ID="lstStato" runat="server" AutoPostBack="True">
                                        </Siar:ComboBase>
                                    </td>
                                </tr>
                            </table>
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
                <Siar:DataGrid ID="dg" runat="server" AutoGenerateColumns="False" DataKeyField="IdProgetto"
                    PageSize="15" Width="100%" AllowPaging="True">
                    <ItemStyle Height="28px" />
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
                        <asp:BoundColumn HeaderText="Comunicazione di finanziabilità">
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
    <uc2:FirmaDocumento ID="ucFirmaComunicazione" Titolo="COMUNICAZIONE DI FINANZIABILITA`"
        runat="server" />
</asp:Content>
