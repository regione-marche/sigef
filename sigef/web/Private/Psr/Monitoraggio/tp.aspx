<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true" 
    CodeBehind="tp.aspx.cs" Inherits="web.Private.Psr.Monitoraggio.tp" %>
    
<%@ Register Src="../../../CONTROLS/SiarNewTab.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <script type="text/javascript"><!--
        function pulisciCampi() { $('[id$=hdnIdTp]').val(''); $('[id$=txtDescrizione]').val(''); $('[id$=txtCodice]').val(''); $('[id$=txtCodice_text]').removeAttr('readonly').css('backgroundColor', ''); $('[id$=lstProgrammazione]').val(''); }
        function selezionaTP(id) { $('[id$=hdnIdTp]').val(id); swapTab(2); }
//--></script>

<uc1:SiarNewTab ID="ucSiarNewTab" runat="server" TabNames="Elenco Tipologie di Progetto|Dettaglio tipologia" />

    <input type="hidden" id="hdnIdTp" runat="server" />
    <input type="hidden" id="hdnCercaCodice" runat="server" />
    <input type="hidden" id="hdnCercaDescrizione" runat="server" />
    

    <table class="tableTab" id="tbElenco" width="1000px" runat="server" visible="false">
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="padding: 10px">
                <table width="100%">
                    <tr>
                        <td style="width: 111px">
                            Codice:
                            <br />
                            <Siar:TextBox ID="txtCercaCodice" runat="server" MaxLength="10" Width="100px" />
                        </td>
                        <td style="width: 370px">
                            Descrizione:<br />
                            <Siar:TextBox ID="txtCercaDescrizione" runat="server" MaxLength="80" Width="350px" />
                        </td>
                        <td>
                            <br />
                            <Siar:Button ID="btnCerca" runat="server" OnClick="btnCerca_Click" Text="Cerca" Width="120px"
                                CausesValidation="false" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dg" runat="server" Width="100%" PageSize="20" AllowPaging="True"
                    AutoGenerateColumns="false">
                    <Columns>
                        <Siar:NumberColumn>
                            <ItemStyle HorizontalAlign="Center" Width="30px" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="Codice" HeaderText="Codice" >
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                        </asp:BoundColumn>
                        <Siar:ColonnaLink DataField="Descrizione" LinkFields="Id" IsJavascript="true"
                            HeaderText="Descrizione" LinkFormat="selezionaTP({0});">
                            <ItemStyle  Width="350px" Height="28px" />
                        </Siar:ColonnaLink>
                        <asp:BoundColumn DataField="Programmazione" HeaderText="Programmazione">
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Psr" HeaderText="Psr">
                        <ItemStyle  Width="220px" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>&nbsp;
            </td>
        </tr>
    </table>
    <table class="tableTab" id="tbDettaglio" width="1000px" runat="server" visible="false">
        <tr>
            <td style="padding: 10px">
                <table width="100%">
                    <tr>
                        <td>
                            <table width="100%">
                                <tr>
                                    <td style="width: 120px">
                                        Codice:<br />
                                        <Siar:TextBox ID="txtCodice" runat="server" Width="99px" NomeCampo="Misura" Obbligatorio="true" />
                                    </td>
                                    <td>
                                        PROGRAMMAZIONE:<br />
                                        <Siar:ComboGroupZProgrammazione ID="lstProgrammazione" runat="server" Width="700px"
                                        Obbligatorio="true" >
                                        </Siar:ComboGroupZProgrammazione>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Descrizione:
                            <br />
                            <Siar:TextArea ID="txtDescrizione" runat="server" Width="820px" NomeCampo="Descrizione"
                                Obbligatorio="True" Rows="6" MaxLength="1000"></Siar:TextArea>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right: 30px; height: 64px">
                <Siar:Button ID="btnSalva" runat="server" Width="140px" Text="Salva" OnClick="btnSalva_Click"
                    Modifica="True"></Siar:Button>&nbsp;&nbsp;&nbsp; &nbsp;<Siar:Button ID="btnElimina"
                        runat="server" Width="140px" Text="Elimina" OnClick="btnElimina_Click" Modifica="True"
                        Conferma="Attenzione! Eliminare la Tipologia di Progetto selezionata?" CausesValidation="false">
                    </Siar:Button>
                <input class="Button" onclick="pulisciCampi();" type="button" value="Nuovo" style="width: 120px;
                    margin-left: 20px" />
            </td>
        </tr>
    </table>

</asp:Content>
