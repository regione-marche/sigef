<%@ Page Language="c#" MasterPageFile="~/SiarPage.master" Inherits="web.Private.regione.Atti"
    CodeBehind="Atti.aspx.cs" %>

<%@ Register Src="../../CONTROLS/SiarNewTab.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript">
        function selezionaAtto(idatto) { $('[id$=hdnIdAtto]').val(idatto);swapTab(2); }
        function salvaAtto(obj) { $('[id$=hdnIdAtto]').val(sjsConvertiOggettoToJsonString(obj));$('[id$=btnSalvaAttoImportato]').click(); }
        function ctrlAWClick(ev) {
            if($('[id$=txtRNum_text]').val()==''||$('[id$=txtRData_text]').val()=='') { alert('Specificare numero e data dell`atto.');return stopEvent(ev); }
            if($('[id$=lstRDefinizione]').val()=='D'&&$('[id$=lstRRegistro]').val()=='') { alert('Specificare il codice registro da cui importare il decreto.');return stopEvent(ev); }
        }
    </script>

    <div style="display: none">
        <input type="hidden" id="hdnIdAtto" runat="server" />
        <asp:Button ID="btnSalvaAttoImportato" runat="server" OnClick="btnSalvaAttoImportato_click" />
    </div>
    <uc1:SiarNewTab ID="ucSiarNewTab" runat="server" TabNames="Archivio atti|Dettaglio"
        Width="800px" />
    <table id="tbRicerca" runat="server" class="tableTab" width="800px">
        <tr>
            <td class="testo_pagina">
                Archivio degli atti utilizzati sul portale e importati dai sistemi informatici della
                regione (ATTIWEB, NORMEMARCHE, OPEN ACT).<br />
                La ricerca degli atti su tali sistemi (pulsante Importa) richiede obbligatoriamente
                la specifica del <b>numero</b> e della <b>data</b>,
                <br />
                e qualora si intenda ricercare un <b>decreto</b> e&#39; obbligatorio specificare
                anche il <b>registro</b>.
                <br />
                Una volta trovato l&#39;atto desiderato è necessario selezionarlo e <b>completare 
                l&#39;importazione</b> specificando, nella maschera
                <br />
                di dettaglio, il <b>tipo</b> (di approvazione, di revoca, di impegno, ecc).</td>
        </tr>
        <tr>
            <td class="paragrafo">
                <br />
                Digitare i parametri di ricerca:
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%">
                    <tr>
                        <td style="width: 100px">
                            Numero:<br />
                            <Siar:IntegerTextBox ID="txtRNum" runat="server" MaxLength="30" NoCurrency="true"
                                Width="80px" />
                        </td>
                        <td style="width: 100px">
                            Data:<br />
                            <Siar:DateTextBox ID="txtRData" runat="server" Width="80px" />
                        </td>
                        <td style="width: 100px">
                            Definizione:<br />
                            <Siar:ComboDefinizioneAtto ID="lstRDefinizione" runat="server" NoBlankItem="True"
                                Width="80px">
                            </Siar:ComboDefinizioneAtto>
                        </td>
                        <td style="width: 150px">
                            Registro:<br />
                            <Siar:ComboRegistriAtto ID="lstRRegistro" runat="server" Width="120px">
                            </Siar:ComboRegistriAtto>
                        </td>
                        <td>
                            <br />
                            <Siar:Button ID="btnCerca" runat="server" CausesValidation="False" OnClick="btnCerca_Click"
                                Text="Cerca" Width="130px" />
                            &nbsp;
                            <Siar:Button ID="btnCercaAW" runat="server" CausesValidation="False" OnClick="btnCercaAW_Click"
                                Text="Importa" Width="150px" OnClientClick="return ctrlAWClick(event);" />
                        </td>
                    </tr>
                </table>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dg" runat="server" Width="100%" AutoGenerateColumns="False" PageSize="15"
                    AllowPaging="True">
                    <ItemStyle Height="24px" />
                    <Columns>
                        <asp:BoundColumn DataField="Numero" HeaderText="Numero">
                            <ItemStyle HorizontalAlign="center" Width="50px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Data" HeaderText="Data">
                            <ItemStyle HorizontalAlign="Right" Width="70px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Registro" HeaderText="Registro">
                            <ItemStyle HorizontalAlign="center" Width="50px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione"></asp:BoundColumn>
                        <asp:BoundColumn DataField="TipoAtto" HeaderText="Tipo Atto">
                            <ItemStyle Width="100px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="DefinizioneAtto" HeaderText="Definizione Atto">
                            <ItemStyle Width="100px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="OrganoIstituzionale" HeaderText="Organo Istituzionale">
                            <ItemStyle Width="100px" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
    </table>
    <table id="tbDettaglio" runat="server" class="tableTab" width="800px">
        <tr>
            <td class="paragrafo">
                &nbsp;
                <br />
                &nbsp;Dati generali:
            </td>
        </tr>
        <tr>
            <td style="padding: 10px">
                <table cellpadding="0" cellspacing="0" style="width: 100%">
                    <tr>
                        <td style="width: 141px">
                            Numero:<br />
                            <Siar:IntegerTextBox ID="txtNumeroAtto" runat="server" Width="100px" NoCurrency="true"
                                MaxLength="30" ReadOnly="True" />
                        </td>
                        <td style="width: 224px">
                            Data:
                            <br />
                            <Siar:DateTextBox ID="txtdataAtto" runat="server" Width="100px" ReadOnly="True">
                            </Siar:DateTextBox>
                        </td>
                        <td>
                            Definizione:<br />
                            <Siar:ComboDefinizioneAtto ID="lstDefAtto" runat="server" Obbligatorio="True" NomeCampo="Definizione Atto"
                                Width="105px" Enabled="False">
                            </Siar:ComboDefinizioneAtto>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 141px">
                            <br />
                            Registro:<br />
                            <Siar:TextBox ID="txtRegistro" runat="server" Width="100px" MaxLength="30" ReadOnly="True" />
                        </td>
                        <td style="width: 224px">
                            <br />
                            Organo Istituzionale:<br />
                            <Siar:ComboOrganoIstituzionale ID="lstOrgIstituzionale" runat="server" Obbligatorio="True"
                                NomeCampo="Organo Istituzionale" Width="200px" Enabled="False">
                            </Siar:ComboOrganoIstituzionale>
                        </td>
                        <td>
                            <br />
                            Tipo:<br />
                            <Siar:ComboTipoAtto ID="lstTipoAtto" runat="server" Obbligatorio="True" NomeCampo="Tipo Atto"
                                Width="200px">
                            </Siar:ComboTipoAtto>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <br />
                            &nbsp; Descrizione:<br />
                            <Siar:TextArea ID="txtDescrizione" runat="server" Width="447px" NomeCampo="Descrizione"
                                Obbligatorio="True" ReadOnly="True"></Siar:TextArea>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" class="paragrafo">
                            <br />
                            &nbsp;Pubblicazione B.U.R.:
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 141px">
                            <br />
                            Numero:<br />
                            <Siar:IntegerTextBox ID="txtNumBoll" runat="server" Width="100px" NomeCampo="Numero Bollettino"
                                MaxLength="30" ReadOnly="True" />
                        </td>
                        <td style="width: 224px">
                            <br />
                            Data:<br />
                            <Siar:DateTextBox ID="txtDataBur" runat="server" NomeCampo="Data BUR" Width="100px"
                                ReadOnly="True" />
                        </td>
                        <td>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-right: 50px; height: 50px" colspan="3" align="right">
                            <input id="btnVisualizzaDocumento" runat="server" class="Button" disabled="disabled"
                                style="margin-right: 15px" type="button" value="Visualizza documento" /><Siar:Button
                                    ID="btnSalva" runat="server" Width="140px" Text="Salva" OnClick="btnSalva_Click"
                                    Modifica="true"></Siar:Button>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
