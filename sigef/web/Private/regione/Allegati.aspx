<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.regione.Allegati" CodeBehind="Allegati.aspx.cs" %>

<%@ Register Src="../../CONTROLS/SiarNewTab.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
        function pulisciCampi() { $('[id$=hdnIdAllegato]').val('');$('[id$=txtDescrizione]').val('');$('[id$=txtMisura]').val('');$('[id$=lstTipoAllegato]').val('');$('[id$=lstTipoEnte]').val('');$('[id$=lstTipoEnte]')[0].disabled=true; }
        function selezionaAllegato(id) { $('[id$=hdnIdAllegato]').val(id);swapTab(2); }
        function checkEnteEmettitore(elem) { $('[id$=lstTipoEnte]')[0].disabled=$(elem).val()!='S';if($('[id$=lstTipoEnte]')[0].disabled==true) $('[id$=lstTipoEnte]').val(''); }
//--></script>

    <input id="hdnIdAllegato" type="hidden" runat="server" />
    <uc1:SiarNewTab ID="ucSiarNewTab" runat="server" TabNames="Elenco allegati|Dettaglio allegato" />
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
                            Misura:
                            <br />
                            <Siar:TextBox ID="txtCercaMisura" runat="server" MaxLength="10" Width="100px" />
                        </td>
                        <td style="width: 180px">
                            Tipo documento:<br />
                            <Siar:ComboSql ID="lstCercaTipoDocumento" runat="server" CommandText="SELECT CODICE,DESCRIZIONE FROM TIPO_ALLEGATO ORDER BY ATTIVO DESC,DESCRIZIONE"
                                DataTextField="DESCRIZIONE" DataValueField="CODICE">
                            </Siar:ComboSql>
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
                        <Siar:ColonnaLink DataField="Descrizione" LinkFields="IdAllegato" IsJavascript="true"
                            HeaderText="Descrizione" LinkFormat="selezionaAllegato({0});">
                        </Siar:ColonnaLink>
                        <asp:BoundColumn DataField="CodTipo" HeaderText="Tipo documento" DataFormatString="{0:S=Dichiarazione Sostitutiva|D=Supporto Digitale|C=Supporto Cartaceo}">
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="CodTipoEnteEmettitore" HeaderText="Ente emettitore" DataFormatString="{0:CM=Comune|PR=Provincia}">
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Misura" HeaderText="Misura">
                            <ItemStyle HorizontalAlign="Center" Width="90px" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>&nbsp;
            </td>
        </tr>
    </table>
    <table class="tableTab" id="tbDettaglio" width="700px" runat="server" visible="false">
        <tr>
            <td style="padding: 10px">
                <table width="100%">
                    <tr>
                        <td>
                            <table width="100%">
                                <tr>
                                    <td style="width: 120px">
                                        Misura:<br />
                                        <Siar:TextBox ID="txtMisura" runat="server" Width="99px" NomeCampo="Misura" />
                                    </td>
                                    <td style="width: 200px">
                                        Tipo documento:<br />
                                        <Siar:ComboSql ID="lstTipoAllegato" runat="server" CommandText="SELECT CODICE,DESCRIZIONE FROM TIPO_ALLEGATO ORDER BY ATTIVO DESC,DESCRIZIONE"
                                            DataTextField="DESCRIZIONE" DataValueField="CODICE" Obbligatorio="true" NomeCampo="Tipo documento">
                                        </Siar:ComboSql>
                                    </td>
                                    <td>
                                        Ente emettitore:
                                        <br />
                                        <Siar:Combo ID="lstTipoEnte" runat="server">
                                            <asp:ListItem Value="" />
                                            <asp:ListItem Value="CM">Comune</asp:ListItem>
                                            <asp:ListItem Value="PR">Provincia</asp:ListItem>
                                        </Siar:Combo>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Descrizione:
                            <br />
                            <Siar:TextArea ID="txtDescrizione" runat="server" Width="579px" NomeCampo="Descrizione"
                                Obbligatorio="True" Rows="10" MaxLength="1000"></Siar:TextArea>
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
                        Conferma="Attenzione! Eliminare l`allegato selezionato?" CausesValidation="false">
                    </Siar:Button>
                <input class="Button" onclick="pulisciCampi();" type="button" value="Nuovo" style="width: 120px;
                    margin-left: 20px" />
            </td>
        </tr>
    </table>
</asp:Content>
