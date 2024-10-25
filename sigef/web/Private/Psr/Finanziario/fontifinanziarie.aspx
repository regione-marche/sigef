<%@ Page Language="c#" MasterPageFile="~/SiarPage.master" Inherits="web.Private.Psr.Finanziario.FontiFinanziarie"
    CodeBehind="FontiFinanziarie.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript">
        function selezionaFF(IdFonte) { $('[id$=hdnIdFonte]').val(IdFonte);$('[id$=btnFFPost]').click(); }
        function nuovaFF() { $('[id$=hdnIdFonte]').val('');$('[id$=txtPercentuale_text]').val('');$('[id$=txtDescrizione_text]').val('');$('[id$=btnElimina]')[0].disabled='disabled'; }
    </script>

    <div style="display: none">
        <input type="hidden" id="hdnIdFonte" runat="server" />
        <asp:Button ID="btnFFPost" runat="server" OnClick="btnFFPost_Click" CausesValidation="false" />
    </div>
    <table width="700px" class="tableNoTab">
        <tr>
            <td class="separatore_big">
                ELENCO GENERALE DELLE FONTI FINANZIARIE
            </td>
        </tr>
        <tr>
            <td class="paragrafo">
                <br />
                <br />
                Nuova/Dettaglio Fonte Finanziaria:
            </td>
        </tr>
        <tr>
            <td style="padding: 10px">
                <table style="width: 100%;">
                    <tr>
                        <td style="width: 399px">
                            Descrizione:
                            <br />
                            <Siar:TextBox ID="txtDescrizione" runat="server" NomeCampo="Descrizione" Obbligatorio="True"
                                Width="370px" />
                        </td>
                        <td>
                            Percentuale:<br />
                            <Siar:QuotaBox ID="txtPercentuale" runat="server" Width="64px" Obbligatorio="True"
                                NomeCampo="Percentuale" NrDecimali="3"></Siar:QuotaBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 61px; padding-right: 50px" colspan="2" align="right">
                            <Siar:Button ID="btnSalva" runat="server" Modifica="True" Text="Salva" Width="137px"
                                OnClick="btnSalva_Click" />
                            &nbsp;&nbsp;
                            <Siar:Button ID="btnElimina" runat="server" Modifica="True" Text="Elimina" Width="137px"
                                CausesValidation="false" OnClick="btnElimina_Click" Conferma="Attenzione! Eliminare la Fonte Finanziaria selezionata?" />
                            <input class="Button" style="width: 120px; margin-left: 20px" type="button" value="Nuova"
                                onclick="nuovaFF();" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="separatore">
                Elenco delle fonti esistenti:
            </td>
        </tr>
        <tr>
            <td>
                <br />
                <Siar:DataGrid ID="dg" runat="server" Width="100%" PageSize="15" AllowPaging="True"
                    AutoGenerateColumns="False">
                    <ItemStyle Height="30px" />
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle Width="35px" HorizontalAlign="Center" />
                        </Siar:NumberColumn>
                        <Siar:ColonnaLink DataField="Descrizione" LinkFields="IdFonte" IsJavascript="true"
                            HeaderText="Descrizione" LinkFormat="selezionaFF({0});">
                        </Siar:ColonnaLink>
                        <asp:BoundColumn DataField="Percentuale" HeaderText="%" DataFormatString="{0:N3}">
                            <ItemStyle Width="150px" HorizontalAlign="Right" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid><br />
            </td>
        </tr>
    </table>
</asp:Content>
