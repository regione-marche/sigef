<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    CodeBehind="CatalogoQuadriDomanda.aspx.cs" Inherits="web.Private.regione.CatalogoQuadriDomanda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">
    <script type="text/javascript"><!--
        function caricaQuadro(id){
            $('[id$=hdnQuadro]').val(id);
            $('[id$=btnPost]').click();
            }
        function nuovoQuadro(){
            $('[id$=txtDenominazione]').val('');
            $('[id$=txtDescrizione]').val('');
            $('[id$=hdnQuadro]').val('');
            }
        function chkQuadroPresente(ev){
            if($('[id$=hdnQuadro]').val()==null || $('[id$="hdnQuadro"]').val()=='')
                {alert("Selezionare il quadro.");stopEvent(ev);}
            }
//--></script>
    <table class="tableNoTab" width="600px">
        <tr>
            <td>
                <div style="display: none">
                    <Siar:Hidden ID="hdnQuadro" runat="server"></Siar:Hidden>
                    <asp:Button ID="btnPost" runat="server" Text="Button" CausesValidation="false" OnClick="btnPost_Click" />
                </div>
            </td>
        </tr>
        <tr>
            <td class="separatore">
                &nbsp;Nuovo/modifica Quadro Domanda:&nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <table id="Table3" width="100%">
                    <tr>
                        <td style="height: 17px">
                            &nbsp;
                        </td>
                        <td style="width: 600px; height: 17px;">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Denominazione:
                        </td>
                        <td style="width: 600px">
                            <Siar:TextBox ID="txtDenominazione" runat="server" Width="432px" Obbligatorio="True"
                                NomeCampo="Denominazione" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Descrizione:
                        </td>
                        <td style="width: 600px">
                            <Siar:TextArea ID="txtDescrizione" runat="server" Width="432px" Obbligatorio="True"
                                NomeCampo="Descrizione"></Siar:TextArea>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" colspan="2">
                            <Siar:Button ID="btnSalva" Width="100px" runat="server" Text="Salva" OnClick="btnSalva_Click"
                                Modifica="true"></Siar:Button>
                            &nbsp;
                            <Siar:Button ID="btnElimina" Width="100px" runat="server" Text="Elimina" OnClick="btnElimina_Click"
                                Modifica="true" CausesValidation="False" OnClientClick="chkQuadroPresente(event)"></Siar:Button>
                            &nbsp;&nbsp;
                            <input class="Button" onclick="nuovoQuadro()" type="button" style="width: 100px; height: 24px" value="Nuovo" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="separatore">
                &nbsp;Catalogo Quadri Domanda:&nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <br />
                <Siar:DataGrid ID="dg" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False"
                    CssClass="tabella" EnableViewState="False"                    
                    PageSize="15">
                    <PagerStyle CssClass="coda"></PagerStyle>
                    <AlternatingItemStyle CssClass="DataGridRowAlt"></AlternatingItemStyle>
                    <ItemStyle CssClass="DataGridRow"></ItemStyle>
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <HeaderStyle Width="35px"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="Denominazione" HeaderText="Denominazione" ItemStyle-Width="35%">
<ItemStyle Width="35%"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione" ItemStyle-Width="45%">
<ItemStyle Width="45%"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn></asp:BoundColumn>
                    </Columns>
                    <HeaderStyle CssClass="TESTA1"></HeaderStyle>
                </Siar:DataGrid>
                <br />
            </td>
        </tr>
    </table>
</asp:Content>
