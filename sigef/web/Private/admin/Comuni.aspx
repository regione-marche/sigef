<%@ Page Language="c#" MasterPageFile="~/SiarPage.master" Inherits="web.Private.admin.Comuni"
    CodeBehind="Comuni.aspx.cs" %>

<%@ Register Src="../../CONTROLS/SiarNewTab.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript">
        function selezionaComune(idComune) { $('[id$=hdnIdComune]').val(idComune);swapTab(2); }
        function pulisciCampi() {
            $('[id$=hdnIdComune]').val('');$('[id$=txtDenominazione_text]').val('');$('[id$=txtCap_text]').val('');$('[id$=lstProvince]').val('');
            $('[id$=txtCodBelfiore_text]').css({ "background-color": "#FFFFFF" }).removeAttr('readonly').val('');
            $('[id$=txtIstat_text]').val('');$('[id$=txtTipoArea_text]').val('');$('[id$=txtCodRubricaPaleo_text]').val('');
        }
    </script>

    <input type="hidden" id="hdnIdComune" runat="server" />
    <uc1:SiarNewTab ID="ucSiarNewTab" runat="server" TabNames="Elenco Comuni|Dettaglio"
        Width="900px" />
    <table id="tbRicerca" runat="server" class="tableTab" width="900px">
        <tr>
            <td class="testo_pagina">
                Elenco generale dei comuni presente nella banca dati del sistema.
                <br />
                Selezionarne uno dall'elenco per modificarne i valori. Se non lo trovi prova con
                la ricerca.
            </td>
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
                        <td style="width: 120px">
                            Codice Belfiore:<br />
                            <Siar:TextBox ID="txtRCodBelfiore" runat="server" MaxLength="4" Width="100px" />
                        </td>
                        <td style="width: 200px">
                            Denominazione:<br />
                            <Siar:TextBox ID="txtRDenominazione" runat="server" Width="180px" />
                        </td>
                        <td style="width: 200px">
                            Provincia:<br />
                            <Siar:ComboSql ID="lstRProvince" runat="server" Width="250px" CommandText="SELECT CODICE,DENOMINAZIONE+' ('+SIGLA+')' AS PROVINCIA FROM PROVINCE WHERE CODICE NOT IN ('EE','XX') ORDER BY DENOMINAZIONE"
                                DataTextField="PROVINCIA" DataValueField="CODICE">
                            </Siar:ComboSql>
                        </td>
                        <td style="width: 134px">
                            <br />
                            <asp:CheckBox ID="chkRAttivi" runat="server" Text="In corso di validità" />
                        </td>
                        <td>
                            <br />
                            <Siar:Button ID="btnCerca" runat="server" CausesValidation="False" OnClick="btnCerca_Click"
                                Text="Cerca" Width="140px" />
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
                        <Siar:NumberColumn>
                            <ItemStyle Width="30px" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="CodBelfiore" HeaderText="Cod. Belfiore">
                            <ItemStyle HorizontalAlign="center" Width="50px" />
                        </asp:BoundColumn>
                        <Siar:ColonnaLink IsJavascript="true" LinkFields="IdComune" LinkFormat="selezionaComune({0});"
                            DataField="Denominazione" HeaderText="Comune">
                        </Siar:ColonnaLink>
                        <asp:BoundColumn DataField="Sigla" HeaderText="Prov.">
                            <ItemStyle HorizontalAlign="center" Width="40px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Cap" HeaderText="CAP">
                            <ItemStyle HorizontalAlign="center" Width="60px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Cod. Istat">
                            <ItemStyle Width="90px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="TipoArea" HeaderText="Tipo Area">
                            <ItemStyle Width="60px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Regione" HeaderText="Regione">
                            <ItemStyle Width="140px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Attivo" HeaderText="Attivo" DataFormatString="{0:SI|NO}">
                            <ItemStyle Width="60px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
    </table>
    <table id="tbDettaglio" runat="server" class="tableTab" width="900px">
        <tr>
            <td class="paragrafo">
                &nbsp;
                <br />
                &nbsp;Dati Comune:
            </td>
        </tr>
        <tr>
            <td style="padding: 10px">
                <table style="width: 100%">
                    <tr>
                        <td style="width: 120px;">
                            Codice Belfiore:<br />
                            <Siar:TextBox ID="txtCodBelfiore" runat="server" Width="100px" Obbligatorio="true"
                                MaxLength="4" NomeCampo="Codice Belfiore" />
                        </td>
                        <td>
                            Denominazione:<br />
                            <Siar:TextBox ID="txtDenominazione" Width="500px" runat="server" Obbligatorio="true"
                                NomeCampo="Denominazione" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 120px">
                            CAP:<br />
                            <Siar:TextBox ID="txtCap" runat="server" Width="100px" MaxLength="5" NomeCampo="Cap"
                                Obbligatorio="True" />
                        </td>
                        <td>
                            Provincia:<br />
                            <Siar:ComboSql ID="lstProvince" runat="server" Obbligatorio="True" NomeCampo="Provincia"
                                Width="250px" CommandText="SELECT CODICE,DENOMINAZIONE+' ('+SIGLA+')' AS PROVINCIA FROM PROVINCE WHERE CODICE NOT IN ('EE','XX') ORDER BY DENOMINAZIONE"
                                DataTextField="PROVINCIA" DataValueField="CODICE">
                            </Siar:ComboSql>
                        </td>
                    </tr>
                </table>
                <table style="width: 100%">
                    <tr>
                        <td style="width: 120px">
                            Codice ISTAT:<br />
                            <Siar:TextBox ID="txtIstat" runat="server" Obbligatorio="True" NomeCampo="Istat comune"
                                Width="100px" MaxLength="3" />
                        </td>
                        <td style="width: 140px">
                            Tipo Area:<br />
                            <Siar:TextBox ID="txtTipoArea" runat="server" Width="100px" NomeCampo="Tipo Area"
                                MaxLength="2" />
                        </td>
                        <td style="width: 191px">
                            Cod. Rubrica Paleo:<br />
                            <Siar:TextBox ID="txtCodRubricaPaleo" runat="server" NomeCampo="Cod Rubrica Paleo"
                                Width="160px" MaxLength="10" />
                        </td>
                        <td>
                            Stato:<br />
                            <Siar:TextBox ID="txtStatoComune" runat="server" Width="163px" MaxLength="0" ReadOnly="True" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="padding-right: 50px; height: 60px" align="right">
                <Siar:Button ID="btnSalva" runat="server" Width="160px" Text="Salva" OnClick="btnSalva_Click"
                    Modifica="true"></Siar:Button>
                &nbsp;&nbsp;
                <Siar:Button ID="btnDisattiva" runat="server" Width="160px" Text="Disattiva" Modifica="true"
                    CausesValidation="false" Conferma="Attenzione! Disattivare il comune selezionato?"
                    OnClick="btnDisattiva_Click"></Siar:Button>
                <input type="button" class="Button" value="Nuovo" style="width: 140px; margin-left: 20px"
                    onclick="pulisciCampi();" />
            </td>
        </tr>
        <tr>
            <td class="paragrafo">
                Dettaglio storico:
            </td>
        </tr>
        <tr>
            <td>
                <br />
                <Siar:DataGrid ID="dgStoricoComune" runat="server" Width="100%" AutoGenerateColumns="False">
                    <ItemStyle Height="24px" />
                    <Columns>
                        <Siar:NumberColumn>
                            <ItemStyle Width="30px" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="CodBelfiore" HeaderText="Cod. Belfiore">
                            <ItemStyle HorizontalAlign="center" Width="50px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Denominazione" HeaderText="Denominazione"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Sigla" HeaderText="Prov.">
                            <ItemStyle HorizontalAlign="center" Width="40px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Cap" HeaderText="CAP">
                            <ItemStyle HorizontalAlign="center" Width="60px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Cod. Istat">
                            <ItemStyle Width="90px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="TipoArea" HeaderText="Tipo Area">
                            <ItemStyle Width="60px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Regione" HeaderText="Regione">
                            <ItemStyle Width="140px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Attivo" HeaderText="Attivo" DataFormatString="{0:SI|NO}">
                            <ItemStyle Width="60px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid><br />
            </td>
        </tr>
    </table>
</asp:Content>
