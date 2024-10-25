<%@ Page Language="c#" MasterPageFile="~/SiarPage.master" Inherits="web.Private.admin.Profilo"
    CodeBehind="Profilo.aspx.cs" %>

<%@ Register Src="../../CONTROLS/SiarNewTab.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
        function selezionaProfilo(id) { $('[id$=hdnIdProfilo]').val(id);$('[id$=btnSelezionaProfilo]').click(); }
        function eliminaProfilo(ev) {
            if($('[id$=hdnIdProfilo]').val()=='') { alert('Il profilo selezionato non è valido.');return stopEvent(ev); }
            else if(!confirm('Attenzione! Eliminando il profilo selezionato verranno eliminate anche tutte le correlazioni alle funzionalità. Continuare?'))return stopEvent(ev);
        }
        function pulisciCampi() { $('[id$=hdnIdProfilo]').val('');$('[id$=txtDescrizione_text]').val('');$('[id$=txtOrdine_text]').val('');$('[id$=lstTipoEnte]').val(''); }
//--></script>

    <uc1:SiarNewTab ID="ucSiarNewTab" runat="server" TabNames="Elenco profili|Dettaglio\Nuovo"
        Width="600px" />
    <div style="display: none">
        <asp:HiddenField ID="hdnIdProfilo" runat="server" />
        <asp:Button ID="btnSelezionaProfilo" runat="server" CausesValidation="False" OnClick="btnSelezionaProfilo_Click" /></div>
    <table class="tableTab" id="tbProfili" runat="server" width="600px">
        <tr>
            <td>
                &nbsp;<Siar:DataGrid ID="dgProfili" runat="server" Width="100%" AllowPaging="false"
                    AutoGenerateColumns="False">
                    <ItemStyle Height="22px" />
                    <Columns>
                        <Siar:NumberColumn>
                            <ItemStyle Width="35px" HorizontalAlign="center" />
                        </Siar:NumberColumn>
                        <Siar:ColonnaLink HeaderText="Descrizione" DataField="Descrizione" LinkFields="IdProfilo"
                            IsJavascript="true" LinkFormat="selezionaProfilo({0});">
                        </Siar:ColonnaLink>
                        <asp:BoundColumn HeaderText="Tipo ente" DataField="CodTipoEnte">
                            <ItemStyle Width="150px" HorizontalAlign="center" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>&nbsp;
            </td>
        </tr>
    </table>
    <table class="tableTab" id="tbDettaglio" runat="server" width="750px">
        <tr>
            <td style="padding-left: 10px">
                <table width="100%">
                    <tr>
                        <td>
                            Tipologia ente:
                            <br />
                            <Siar:ComboTipoEnte ID="lstTipoEnte" runat="server" NomeCampo="Tipo ente">
                            </Siar:ComboTipoEnte>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Descrizione:
                            <br />
                            <Siar:TextBox ID="txtDescrizione" runat="server" Width="264px" NomeCampo="Descrizione"
                                Obbligatorio="True"></Siar:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Ordine:
                            <br />
                            <Siar:IntegerTextBox ID="txtOrdine" runat="server" NomeCampo="Ordine" Width="64px"
                                DataColumn="Ordine" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right: 30px; height: 46px;">
                <Siar:Button ID="btnSalva" runat="server" Modifica="true" OnClick="btnSalva_Click"
                    Text="Salva" Width="150px" />
                &nbsp;&nbsp;
                <Siar:Button ID="btnElimina" runat="server" Modifica="true" OnClick="btnElimina_Click"
                    Text="Elimina" Width="150px" OnClientClick="return eliminaProfilo(event);" CausesValidation="false" />
                &nbsp;&nbsp; &nbsp; &nbsp;<input type="button" class="Button" style="width: 120px"
                    value="Nuovo" onclick="pulisciCampi()" />
            </td>
        </tr>
        <tr>
            <td class="paragrafo">
                Selezionare le funzionalità da associare al profilo:
            </td>
        </tr>
        <tr>
            <td style="height: 45px">
                <Siar:ComboProfilo ID="lstProfili" runat="server">
                </Siar:ComboProfilo>
                &nbsp;
                <Siar:Button ID="btnCaricaProfilo" runat="server" Modifica="False" OnClick="btnCaricaProfilo_Click"
                    Text="Carica profilo" Width="150px" CausesValidation="False" />
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dgFunzionalita" runat="server" AutoGenerateColumns="False" Width="100%"
                    AllowPaging="false">
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle HorizontalAlign="center" Width="30px" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione"></asp:BoundColumn>
                        <asp:BoundColumn DataField="DescMenu" HeaderText="DescMenu">
                            <ItemStyle HorizontalAlign="Center" Width="220px" />
                        </asp:BoundColumn>
                        <Siar:CheckColumn DataField="CodFunzione" Name="chkModifica" HeaderText="In modifica"
                            HeaderSelectAll="true">
                            <ItemStyle HorizontalAlign="Center" Width="70px" />
                        </Siar:CheckColumn>
                        <Siar:CheckColumn DataField="CodFunzione" Name="chkFunzionalita" HeaderText="Seleziona"
                            HeaderSelectAll="true">
                            <ItemStyle HorizontalAlign="Center" Width="70px" />
                        </Siar:CheckColumn>
                    </Columns>
                </Siar:DataGrid>&nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
