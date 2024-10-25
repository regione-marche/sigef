<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.Istruttoria.CollaboratoreDettaglio" CodeBehind="CollaboratoreDettaglio.aspx.cs" %>

<%@ Register Src="../../CONTROLS/SiarNewTab.ascx" TagName="SiarNewTab" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
        function eliminaDomanda(id) { if(confirm('Attenzione! Eliminare l`assegnazione della domanda all`operatore selezionato?')) { $('[id$=hdnEliminaDomanda]').val(id);$('[id$=btnEliminaDomanda]').click(); } }        
//--></script>

    <br />
    <uc2:SiarNewTab ID="ucSiarNewTab" runat="server" TabNames="Assegnazioni attuali|Nuova assegnazione"
        Width="900px" />
    <table id="tbAssegnazioniAttuali" runat="server" class="tableTab" width="900px">
        <tr>
            <td>
                &nbsp;
                <Siar:DataGrid ID="dgOperatore" runat="server" AllowPaging="false" AutoGenerateColumns="False"
                    PageSize="20" Width="100%">
                    <ItemStyle Height="24px" />
                    <Columns>
                        <asp:BoundColumn DataField="Nominativo" HeaderText="Nominativo"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Profilo" HeaderText="Ruolo">
                            <ItemStyle Width="200px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Ente" HeaderText="Ente">
                            <ItemStyle Width="200px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Provincia" HeaderText="Provincia">
                            <ItemStyle HorizontalAlign="Center" Width="120px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Valido fino a">
                            <ItemStyle HorizontalAlign="Center" Width="110px" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
        <tr>
            <td>
                <br />
                &nbsp;Domande di aiuto assegnate:&nbsp;<b>
                    <Siar:Label ID="lblNumeroProgetti" runat="server">
                    </Siar:Label>
                </b>(su un totale di <b>
                    <Siar:Label ID="lblNumeroPresentati" runat="server">
                    </Siar:Label>
                </b>domande pervenute).
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="right">
                <Siar:Button ID="btnElimina" runat="server" OnClick="btnElimina_Click" Text="Elimina operatore"
                    Width="170px" Conferma="Eliminare l`istruttore dal bando?" Modifica="True" CausesValidation="False" />
                &nbsp; &nbsp;&nbsp;
                <input type="button" class="Button" value="Indietro" style="width: 125px" onclick="location='Collaboratori.aspx'" />&nbsp;
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="separatore">
                &nbsp; Lista domande di aiuto assegnate:
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%">
                    <tr>
                        <td align="center">
                            STATO DI DOMANDA<asp:RadioButtonList ID="rblProgetti" runat="server" RepeatDirection="Horizontal">
                            </asp:RadioButtonList>
                            <br />
                            PROVINCIA DI ASSEGNAZIONE DELL'ISTRUTTORE<asp:RadioButtonList ID="rblFiltroProvincia"
                                runat="server" RepeatDirection="Horizontal">
                            </asp:RadioButtonList>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <Siar:Button ID="btnFiltro" runat="server" OnClick="btnFiltro_Click" Text="Applica filtro"
                                Width="174px" CausesValidation="False" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;<Siar:DataGrid ID="dg" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    PageSize="20" Width="100%">
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle HorizontalAlign="Center" Width="35px" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn HeaderText="Domanda"></asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Visualizza">
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Data di presentazione">
                            <ItemStyle HorizontalAlign="Center" Width="120px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Provincia di presentazione">
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Stato procedurale">
                            <ItemStyle HorizontalAlign="Center" Width="120px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Rimuovi assegnazione">
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>&nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <div style="display: none">
                    <asp:Button ID="btnEliminaDomanda" runat="server" OnClick="btnEliminaDomanda_Click" />
                    <asp:HiddenField ID="hdnEliminaDomanda" runat="server" />
                </div>
            </td>
        </tr>
    </table>
    <table id="tbNuovaAssegnazione" runat="server" class="tableTab" width="900px">
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="paragrafo">
                &nbsp;Ricerca domande di aiuto da assegnare:
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width: 174px">
                            <b>
                                <br />
                                &nbsp;Provincia: </b>
                        </td>
                        <td>
                            <b>
                                <br />
                                &nbsp;Comune:&nbsp; </b>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 174px">
                            &nbsp;<Siar:ComboProvinceMarche ID="lstProvincia" runat="server" AutoPostBack="True"
                                EnableTheming="False" NomeCampo="Provincia" Obbligatorio="True">
                            </Siar:ComboProvinceMarche>
                        </td>
                        <td style="height: 27px">
                            &nbsp;<Siar:ComboComuniMarche ID="lstComune" runat="server">
                            </Siar:ComboComuniMarche>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 52px">
                <Siar:Button ID="btnCerca" runat="server" OnClick="btnCerca_Click" Text="Cerca" Width="170px"
                    CausesValidation="False" />
            </td>
        </tr>
        <tr>
            <td class="separatore">
                &nbsp;Trovate
                <Siar:Label ID="lblSearchResult" runat="server">
                </Siar:Label>
                &nbsp;domande non ancora assegnate.
            </td>
        </tr>
        <tr>
            <td>
                <table id="tabProgetti" runat="server" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td>
                            &nbsp;&nbsp;
                            <Siar:DataGrid ID="dgProgettiDaAssegnare" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                PageSize="20" Width="100%">
                                <Columns>
                                    <Siar:NumberColumn HeaderText="Nr.">
                                        <ItemStyle HorizontalAlign="Center" Width="35px" />
                                    </Siar:NumberColumn>
                                    <asp:BoundColumn HeaderText="Domanda"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="Data" HeaderText="Data di presentazione">
                                        <ItemStyle HorizontalAlign="Center" Width="120px" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ProvinciaDiPresentazione" HeaderText="Provincia">
                                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Stato" HeaderText="Stato procedurale">
                                        <ItemStyle HorizontalAlign="Center" Width="120px" />
                                    </asp:BoundColumn>
                                    <Siar:CheckColumn DataField="IdProgetto" Name="chkAssegnaDomanda" HeaderSelectAll="true">
                                        <ItemStyle HorizontalAlign="Center" Width="80px" />
                                    </Siar:CheckColumn>
                                </Columns>
                            </Siar:DataGrid>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="height: 60px">
                            <Siar:Button ID="btnAssegna" runat="server" OnClick="btnAssegna_Click" Text="Assegna domande selezionate"
                                Width="230px" Modifica="true" />&nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
