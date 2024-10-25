<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.Istruttoria.ComunicazioneNonAmmissibilita" CodeBehind="ComunicazioneNonAmmissibilita.aspx.cs" %>

<%@ Register Src="../../CONTROLS/FirmaDocumento.ascx" TagName="FirmaDocumento" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
        function firmaDocumento(idprogetto,tipo) { $('[id$=hdnIdProgetto]').val(idprogetto);$('[id$=hdnTipoSegnatura]').val(tipo);$('[id$=btnFirmaComunicazione]').click(); }
        function ctrlCampiRicercaNormeMarche(ev) { if($('[id$=txtAttoNumero_text]').val()==""||$('[id$=txtAttoData_text]').val()==""||$('[id$=lstAttoRegistro]').val()=="") { alert('Per la ricerca degli atti è necessario specificare numero, data e registro.');return stopEvent(ev); } }
        function ctrlTipoAtto(ev) {
            if($('[id$=hdnIdAtto]').val()=="") { alert('Per proseguire è necessario specificare un atto.');return stopEvent(ev); }
            else if($('[id$=lstAttoTipo]').val()=="") { alert('Per proseguire è necessario specificare la tipologia dell`atto.');return stopEvent(ev); }
        }
        function chiudiPopup() { $('[id$=hdnIdAtto]').val('');$('[id$=txtAttoDescrizione_text]').val('');$('[id$=lstAttoOrgIstituzionale]').val('');$('[id$=lstAttoTipo]').val('');chiudiPopupTemplate(); }
//--></script>

    <br />
    <asp:HiddenField ID="hdnIdAtto" runat="server" />
    <table width="1000px" class="tableNoTab">
        <tr>
            <td class="separatore_big">
                COMUNICAZIONE DI NON AMMISSIBILITA'
            </td>
        </tr>
        <tr>
            <td>
                <div style="display: none">
                    <Siar:Button ID="btnFirmaComunicazione" runat="server" OnClick="btnFirmaComunicazione_Click" />
                    <Siar:Hidden ID="hdnIdProgetto" runat="server">
                    </Siar:Hidden>
                    <Siar:Hidden ID="hdnTipoSegnatura" runat="server">
                    </Siar:Hidden>
                </div>
                <table width="100%">
                    <tr>
                        <td class="testo_pagina">
                            Elenco delle domande non ammissibili ed eventuali comunicazioni effettuate. L'invio
                            di tali comunicazioni
                            <br />
                            è in capo al Responsabile del Bando.<br />
                            <br />
                            - Numero domande non ammissibili:&nbsp;<b>
                                <asp:Label ID="lblDomande" runat="server"></asp:Label></b><br />
                            - Comunicazioni di non ammissibilità da effettuare:&nbsp;<b>
                                <asp:Label ID="lblComunicazioni" runat="server"></asp:Label></b><br />
                            - Comunicazioni di non ammissibilità (provvedimento) da effettuare:&nbsp;<b>
                                <asp:Label ID="lblProvvedimenti" runat="server"></asp:Label></b>
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
                <Siar:DataGrid ID="dg" runat="server" AutoGenerateColumns="False" PageSize="15" Width="100%"
                    AllowPaging="True">
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle HorizontalAlign="Center" Width="35px" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn HeaderText="Domanda">
                            <ItemStyle Width="280px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Provincia">
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Stato procedurale attuale">
                            <ItemStyle HorizontalAlign="Center" Width="150px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Comunicazione di non ammissibilità">
                            <ItemStyle HorizontalAlign="Center" Width="150px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Comunicazione del PROVVEDIMENTO di non ammissibilità">
                            <ItemStyle HorizontalAlign="Center" Width="150px" />
                        </asp:BoundColumn>
                        <Siar:CheckColumn DataField="IdProgetto" Name="chkDecreto" HeaderText="Decreto di non ammissibilità"
                            HeaderSelectAll="true">
                        </Siar:CheckColumn>
                    </Columns>
                </Siar:DataGrid><br />
            </td>
        </tr>
        <tr>
            <td align="right" style="height: 60px; padding-right: 30px">
                <Siar:Button ID="btnDecreto" runat="server" Text="Carica Decreto" OnClick="btnDecreto_Click"
                    Width="220px" Modifica="true" />
                <input type="button" onclick="location='Collaboratori.aspx'" value="Indietro" style="width: 180px;
                    margin-left: 30px;" class="Button" />
            </td>
        </tr>
    </table>
    <div id="divDecreto" style="width: 850px; position: absolute; display: none">
        <table class="tableNoTab" width="100%">
            <tr>
                <td class="separatore">
                    Caricamento Atto di Non Ammissibilità
                </td>
            </tr>
            <tr>
                <td style="padding: 10px">
                    <table width="100%">
                        <tr>
                            <td style="width: 100px">
                                Definizione:<br />
                                <Siar:ComboDefinizioneAtto ID="lstAttoDefinizione" runat="server" NoBlankItem="True"
                                    Width="80px">
                                </Siar:ComboDefinizioneAtto>
                            </td>
                            <td style="width: 100px">
                                Numero:<br />
                                <Siar:IntegerTextBox ID="txtAttoNumero" NoCurrency="True" runat="server" Width="80px" NomeCampo="Numero decreto" />
                            </td>
                            <td style="width: 120px">
                                Data:<br />
                                <Siar:DateTextBox ID="txtAttoData" runat="server" Width="100px" NomeCampo="Data decreto" />
                            </td>
                            <td style="width: 155px">
                                Registro:<br />
                                <Siar:ComboRegistriAtto ID="lstAttoRegistro" runat="server" Width="120px">
                                </Siar:ComboRegistriAtto>
                            </td>
                            <td>
                                <br />
                                <Siar:Button ID="btnCercaDecreto" runat="server" OnClick="btnCercaDecreto_Click"
                                    Text="Ricerca" Width="120px" OnClientClick="return ctrlCampiRicercaNormeMarche(event);" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="padding-left: 10px">
                    <table style="width: 100%">
                        <tr>
                            <td>
                                Descrizione:<br />
                                <Siar:TextArea ID="txtAttoDescrizione" runat="server" Width="650px" ReadOnly="True"
                                    Rows="4" ExpandableRows="5"></Siar:TextArea>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table width="100%">
                                    <tr>
                                        <td style="width: 260px">
                                            Organo Istituzionale:<br />
                                            <Siar:ComboOrganoIstituzionale ID="lstAttoOrgIstituzionale" runat="server" Width="210px"
                                                Enabled="False">
                                            </Siar:ComboOrganoIstituzionale>
                                        </td>
                                        <td>
                                            Tipo atto:<br />
                                            <Siar:ComboTipoAtto ID="lstAttoTipo" runat="server" NomeCampo="Tipo Atto">
                                            </Siar:ComboTipoAtto>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table width="350px">
                                    <tr>
                                        <td class="paragrafo" colspan="2">
                                            Pubblicazione B.U.R.
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 150px">
                                            Numero:<br />
                                            <Siar:IntegerTextBox ID="txtAttoBurNumero" runat="server" Width="120px" ReadOnly="True" />
                                        </td>
                                        <td>
                                            Data:<br />
                                            <Siar:DateTextBox ID="txtAttoBurData" runat="server" Width="120px" ReadOnly="True" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr id="trDataComunicazione" runat="server" visible="false">
                <td style="padding-left: 10px">
                    Data del CDA per i GAL / Determina per le Province:<br />
                    <Siar:DateTextBox ID="txtAttoDataXComunicazione" runat="server" Width="100px" NomeCampo="Data per Comunicazione" />
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="separatore_light">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="height: 58px; padding-right: 40px" align="right">
                    &nbsp;
                    <Siar:Button ID="btnSalvaDecreto" runat="server" OnClick="btnSalvaDecreto_Click"
                        OnClientClick="return ctrlTipoAtto(event);" Enabled="false" Text="Associa il decreto"
                        Width="180px" Modifica="true" Conferma="Associare l`atto specificato alle domande selezionate?" />
                    <input class="Button" onclick="chiudiPopup()" style="width: 120px; margin-left: 40px"
                        type="button" value="Chiudi" />
                </td>
            </tr>
        </table>
    </div>
    <uc2:FirmaDocumento runat="server" ID="ucFirmaComunicazione" />
</asp:Content>
