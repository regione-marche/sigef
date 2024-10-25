<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SiarPage.master" CodeBehind="ParametriRischio.aspx.cs" Inherits="web.Private.CertificazioneSpesa.ParametriRischio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
        function modificaParametro(id) { if(confirm('Attenzione! Modificare il parametro?')) { $('[id$=hdnIdParametro]').val(id);$('[id$=btnModifica]').click(); } }
        function eliminaParametro(id) { if(confirm('Attenzione! Eliminare il parametro?')) { $('[id$=hdnIdParametro]').val(id);$('[id$=btnElimina]').click(); } }
        function pulisciCampi() { $('[id$=txtDescrizione]').val('');$('[id$=txtQueryParametro_text]').val('');$('[id$=hdnIdParametro]').val('');$('[id$=chkManuale]')[0].checked=false; }
//--></script>

    <br />
    <table class="tableNoTab" width="900">
        <tr>
            <td class="separatore_big">
                PARAMETRI DI RISCHIO
            </td>
        </tr>
        <tr>
            <td class="testo_pagina">
                Di seguito viene visualizzata la lista completa dei parametri di rischio inseriti.
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dgParametri" runat="server" AutoGenerateColumns="False" Width="100%"
                    AllowPaging="true" PageSize="10">
                    <ItemStyle Height="30px" />
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle Width="50px" HorizontalAlign="center" />
                            <FooterStyle Width="50px" HorizontalAlign="center" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn HeaderText="Descrizione" DataField="Descrizione"></asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Assegnazione punteggio">
                            <ItemStyle Width="150px" HorizontalAlign="center" />
                            <FooterStyle HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn>
                            <ItemStyle Width="150px" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn>
                            <ItemStyle Width="150px" HorizontalAlign="center" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid><br />
                <div style="display: none">
                    <Siar:Button ID="btnModifica" runat="server" CausesValidation="False" OnClick="btnModifica_Click" />
                    <Siar:Button ID="btnElimina" runat="server" CausesValidation="False" OnClick="btnElimina_Click" />
                    <Siar:Hidden ID="hdnIdParametro" runat="server">
                    </Siar:Hidden>
                </div>
            </td>
        </tr>
        <tr>
            <td class="separatore">
                Inserimento nuovo/modifica di un parametro di rischio:
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="padding-left: 10px">
                <table width="100%">
                    <tr>
                        <td>
                            Descrizione:<br />
                            <Siar:TextArea ID="txtDescrizione" runat="server" NomeCampo="Descrizione" Obbligatorio="True"
                                Width="511px" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Query SQL:<br />
                            <Siar:TextBox ID="txtQueryParametro" runat="server" ReadOnly="True" Width="337px" />
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                            <asp:CheckBox ID="chkManuale" runat="server" Text="Assegnazione manuale del punteggio " />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="height: 24px">
                            &nbsp;<br />
                            &nbsp;<Siar:Button ID="btnSalva" runat="server" Modifica="True" OnClick="btnSalva_Click"
                                Text="Salva" Width="170px" />
                            &nbsp; &nbsp;<input id="Button1" class="Button" style="width: 155px" type="button"
                                value="Pulisci campi" onclick="pulisciCampi()" />
                            &nbsp;&nbsp;
                        </td>
                    </tr>
                </table>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
