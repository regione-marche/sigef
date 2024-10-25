<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true" Inherits="web.Private.regione.PrioritaSettoriale"   Codebehind="PrioritaSettoriale.aspx.cs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" Runat="Server">


<input id="hdnEdit" type="hidden" runat="server" />
<Siar:SiarTab ID="TAB1" runat="server" Tabs="Priorità Settoriale|Nuova Priorità Settoriale"
        FullValidate="True" Width="600px">
       
        <table class="tableTab" id="Table1" width="100%">
            <tr>
                <td>
                    <table id="Table2" width="100%">
                        
                         
                        <tr>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <Siar:DataGrid ID="dgPrioSett" runat="server" Width="100%" ShowShadow="False" PageSize="20"
                                    AllowPaging="True" CssClass="tabella" AutoGenerateColumns="False">
                                    <AlternatingItemStyle CssClass="DataGridRow"></AlternatingItemStyle>
                                    <ItemStyle CssClass="DataGridRow"></ItemStyle>
                                    <HeaderStyle Font-Bold="True" ForeColor="White" CssClass="TESTA1"></HeaderStyle>
                                    <Columns>
                                        <Siar:NumberColumn HeaderText="Nr.">
                                            <HeaderStyle Width="35px"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="center"></ItemStyle>
                                        </Siar:NumberColumn>
                                        <Siar:ColonnaLink DataField="Descrizione" LinkFields="IdPrioritaSettoriale" HeaderText="Descrizione"
                                            LinkFormat="javascript:__doPostBack('Modifica','{0}')">
                                        </Siar:ColonnaLink>
                                    </Columns>
                                    <PagerStyle CssClass="coda" Mode="NumericPages"></PagerStyle>
                                </Siar:DataGrid>&nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table id="Table3" width="100%">
                        <tr>
                            <td colspan="2">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                - Inserisci la descrizione per la priorità settoriale.</td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 170px">
                                <strong>&nbsp;Priorità settoriale :</strong></td>
                            <td style="width: 380px">
                                <Siar:TextArea ID="txtDescrizione" runat="server" Width="350px" NomeCampo="Priorità settoriale"
                                    Obbligatorio="True" Rows="2"></Siar:TextArea>
                            </td>
                        </tr>
                        <tr>
                            <td style="border-bottom: #142952 1px solid" colspan="2">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right" colspan="2">
                            <br />
                                <Siar:Button ID="txtNuovo" Width="100px" runat="server" Text="Nuovo" OnClick="txtNuovo_Click"
                                    CausesValidation="false" />
                                &nbsp;&nbsp;
                                <Siar:Button ID="btnSalvaPrio" runat="server" Width="100px" Modifica="true" Text="Salva"
                                    OnClick="btnSalva_Click" />&nbsp;&nbsp;
                                <Siar:Button ID="btnElimina" Text="Elimina" runat="server" Modifica="true" Width="100px" OnClick="btnElimina_Click" />&nbsp;&nbsp;
                            </td>
                        </tr>
                    
                        
                    </table>
                </td>
            </tr>
        </table>
    </Siar:SiarTab>



</asp:Content>

