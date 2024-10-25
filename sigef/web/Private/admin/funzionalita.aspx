<%@ Page Language="c#" MasterPageFile="~/SiarPage.master" Inherits="web.Private.admin.Funzionalita"
    CodeBehind="Funzionalita.aspx.cs" %>

<%@ Register Src="../../CONTROLS/SiarNewTab.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
        function selezionaFunzionalita(id) { $('[id$=hdnIdFunzionalita]').val(id);$('[id$=btnPost]').click(); }
        function nuovaFun() {
            $('[id$=txtDescrizione]').val('');$('[id$=txtDescMenu]').val('');$('[id$=txtLivello]').val('');$('[id$=txtOrdine]').val('');
            $('[id$=lstFPadre]').val('');$('[id$=txtLink]').val('');$('[id$=hdnIdFunzionalita]').val('');$('[id$=chkMenu]').attr('checked',false);
            $('[id$=chkModificaPXF]').attr('checked',false);$('[id$=chkSelezionaPXF]').attr('checked',false);$('[id$=tbProfili]').hide();
        }
        function selezionaCheckBoxes(nome_colonna,elem) { $('[id$='+nome_colonna+']').attr('checked',$(elem).attr('checked')); }
//--></script>

    <div style="display: none">
        <input id="hdnIdFunzionalita" type="hidden" runat="server" />
        <asp:Button ID="btnPost" runat="server" OnClick="btnPost_Click" CausesValidation="false" />
    </div>
    <uc1:SiarNewTab ID="ucSiarNewTab" runat="server" TabNames="Elenco completo|Dettaglio selezione"
        Width="800px" />
    <table id="tbElenco" runat="server" width="800px" class="tableTab">
        <tr>
            <td>
                &nbsp;<Siar:DataGrid ID="dg" runat="server" Width="100%" AutoGenerateColumns="False"
                    AllowPaging="false">
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle HorizontalAlign="center" Width="30px" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione"></asp:BoundColumn>
                        <asp:BoundColumn DataField="DescMenu" HeaderText="DescMenu">
                            <ItemStyle Width="200px"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="FlagMenu" HeaderText="Flag Menu" DataFormatString="{0:SI|NO}">
                            <ItemStyle Width="70px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn>
                            <ItemStyle Width="150px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>&nbsp;
            </td>
        </tr>
    </table>
    <table id="tbDettaglio" runat="server" width="800px" class="tableTab">
        <tr>
            <td>
                &nbsp;
                <table width="100%">
                    <tr>
                        <td style="width: 300px">
                            Descrizione:
                            <br />
                            <Siar:TextBox ID="txtDescrizione" runat="server" Width="264px" NomeCampo="Descrizione"
                                Obbligatorio="True"></Siar:TextBox>
                        </td>
                        <td colspan="2" style="width: 177px">
                            Funzionalità padre:
                            <br />
                            <Siar:ComboFunzionalita ID="lstFPadre" runat="server">
                            </Siar:ComboFunzionalita>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 300px">
                            Desc menu:
                            <br />
                            <Siar:TextBox ID="txtDescMenu" runat="server" NomeCampo="Descrizione menu" Obbligatorio="True"
                                Width="264px" />
                        </td>
                        <td style="width: 102px">
                            Ordine:
                            <br />
                            <Siar:IntegerTextBox ID="txtOrdine" runat="server" Width="40px" NomeCampo="Ordine"
                                Obbligatorio="True" MaxLength="3"></Siar:IntegerTextBox>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 300px">
                            Link:
                            <br />
                            <Siar:TextBox ID="txtLink" runat="server" Width="263px" NomeCampo="Link"></Siar:TextBox>
                        </td>
                        <td style="width: 102px">
                            Livello:
                            <br />
                            <Siar:IntegerTextBox ID="txtLivello" runat="server" Width="40px" NomeCampo="Livello"
                                Obbligatorio="True" MaxLength="2"></Siar:IntegerTextBox>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </td>
                        <td>
                            <br />
                            <asp:CheckBox ID="chkMenu" runat="server" Text="Flag menu" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="right" style="text-align: center; height: 57px;">
                &nbsp;
                <Siar:Button ID="btnSalva" runat="server" Width="140px" Text="Salva" OnClick="btnSalva_Click"
                    Modifica="true"></Siar:Button>&nbsp;&nbsp; &nbsp;
                <Siar:Button ID="btnElimina" runat="server" Width="140px" Text="Elimina" OnClick="btnElimina_Click"
                    Modifica="true" Conferma="Attenzione! Eliminare la funzionalità selezionata insieme ai profili associati?">
                </Siar:Button>&nbsp; &nbsp;
                <input style="width: 140px" onclick="nuovaFun();" type="button" class="Button" value="Nuovo" />
            </td>
        </tr>
        <tr>
            <td>
                <table id="tbProfili" runat="server" width="100%">
                    <tr>
                        <td class="paragrafo">
                            <br />
                            Profili associati:
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <Siar:DataGrid ID="dgProfili" runat="server" AllowPaging="false" AutoGenerateColumns="False"
                                Width="100%" ShowFooter="true" FooterStyle-CssClass="coda">
                                <Columns>
                                    <Siar:NumberColumn HeaderText="Nr.">
                                        <ItemStyle HorizontalAlign="center" Width="30px" />
                                    </Siar:NumberColumn>
                                    <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="CodTipoEnte" HeaderText="Cod Tipo Ente">
                                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                                    </asp:BoundColumn>
                                    <Siar:CheckColumn DataField="IdProfilo" Name="chkModificaPXF" HeaderText="Abilita modifica">
                                        <ItemStyle HorizontalAlign="Center" Width="70px" />
                                    </Siar:CheckColumn>
                                    <Siar:CheckColumn DataField="IdProfilo" Name="chkSelezionaPXF" HeaderText="Seleziona">
                                        <ItemStyle HorizontalAlign="Center" Width="70px" />
                                    </Siar:CheckColumn>
                                </Columns>
                            </Siar:DataGrid>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="height: 50px">
                            <Siar:Button ID="btnSalvaProfili" runat="server" Width="150px" Text="Salva profili"
                                OnClick="btnSalvaProfili_Click" Modifica="true"></Siar:Button>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
