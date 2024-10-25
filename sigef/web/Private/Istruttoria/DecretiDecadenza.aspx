<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    CodeBehind="DecretiDecadenza.aspx.cs" Inherits="web.Private.Istruttoria.DecretiDecadenza" %>

<%@ Register Src="../../CONTROLS/InfoDomanda.ascx" TagName="InfoDomanda" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <script type="text/javascript"><!--
        function ctrlCampiRicercaNormeMarche(ev) { if($('[id$=txtAttoNumero_text]').val()==""||$('[id$=txtAttoData_text]').val()==""||$('[id$=lstAttoRegistro]').val()=="") { alert('Per la ricerca degli atti è necessario specificare numero, data e registro.');return stopEvent(ev); } }
        function ctrlTipoAtto(ev) {
            if($('[id$=hdnIdAtto]').val()=="") { alert('Per proseguire è necessario specificare un atto.');return stopEvent(ev); }
            else if($('[id$=lstAttoTipo]').val()=="") { alert('Per proseguire è necessario specificare la tipologia dell`atto.');return stopEvent(ev); }
        }
//--></script>

    <br />
    <div style="display: none">
        <asp:HiddenField ID="hdnIdProgetto" runat="server" />
        <asp:HiddenField ID="hdnIdAtto" runat="server" />
        <asp:HiddenField ID="hdnDecretoJson" runat="server" />
    </div>
    <table class="tableNoTab" width="900">
        <tr>
            <td class="separatore_big">
                Registrazione dei decreti di decadenza delle domande di aiuto
            </td>
        </tr>
        <tr>
            <td>
                <table style="width: 100%">
                    <tr>
                        <td style="width: 195px; height: 64px; padding-left: 20px">
                            <b>Selezione della domanda di aiuto: </b>
                        </td>
                        <td style="width: 117px; height: 64px;">
                            <Siar:IntegerTextBox ID="txtIdProgetto" runat="server" Obbligatorio="True" NomeCampo="Numero di domanda"
                                NoCurrency="true" Width="88px" />
                        </td>
                        <td style="height: 64px">
                            <Siar:Button ID="btnCercaProgetto" runat="server" CausesValidation="false" Text="Cerca"
                                Width="105px" OnClick="btnCercaProgetto_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center" style="padding: 20px">
                <uc2:InfoDomanda ID="ucInfoDomanda" runat="server" Visible="False" />
            </td>
        </tr>
        <tr>
            <td class="separatore">
                Specifica del decreto:
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
                            <table width="100%">
                                <tr>
                                    <td class="paragrafo" colspan="2">
                                        Pubblicazione B.U.R.
                                    </td>
                                    <td rowspan="2" style="padding-left: 80px">
                                        <br />
                                        <br />
                                        <input id="btnVidualizzaDecreto" runat="server" class="Button" style="width: 180px"
                                            type="button" disabled="disabled" value="Visualizza atto" /></td>
                                </tr>
                                <tr>
                                    <td style="width: 150px">
                                        Numero:<br />
                                        <Siar:IntegerTextBox ID="txtAttoBurNumero" runat="server" Width="120px" ReadOnly="True" />
                                    </td>
                                    <td style="width: 150px">
                                        Data:<br />
                                        <Siar:DateTextBox ID="txtAttoBurData" runat="server" Width="120px" ReadOnly="True" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <br />
            </td>
        </tr>
        <tr>
            <td class="separatore_light">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="right" style="height: 60px; padding-right: 50px">
                <Siar:Button ID="btnRegistraDecadenza" runat="server" Modifica="False" Text="Registra decadenza della domanda"
                    Width="245px" OnClick="btnRegistraDecadenza_Click" />
                &nbsp;&nbsp;
                <Siar:Button ID="btnNuovaDecadenza" runat="server" Modifica="False" Text="Nuova decadenza"
                    Width="245px" OnClick="btnNuovaDecadenza_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
