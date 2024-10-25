<%@ Page Language="c#" MasterPageFile="~/SiarPage.master" Inherits="web.Private.admin.Utente"
    CodeBehind="Utente.aspx.cs" %>

<%@ Register Src="../../CONTROLS/SiarNewTab.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>
<%@ Register Src="../../CONTROLS/GroupBoxProfilo.ascx" TagName="GroupBoxProfilo"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
        function checkCF(ev) { if($('[id$=txtCodFiscale_text]').val()=='') { alert('Digitare il codice fiscale dell`utente.'); return stopEvent(ev); } }
        function ctrlCF(elem,ev) { var cf=$(elem).val();if(cf!=""&&!ctrlCodiceFiscale(cf)) { alert('Attenzione! Codice fiscale non corretto.'); return stopEvent(ev); } }
        function selezionaUtente(id) { $('[id$=hdnIdUtente]').val(id); swapTab(2); }
        function selezionaRuolo(id) { $('[id$=hdnIdUtenteStorico]').val(id); swapTab(3); }
        function pulisciStorico() {$('[id$=hdnIdUtenteStorico]').val('');  swapTab(3); }
//--></script>

    <asp:HiddenField ID="hdnIdUtente" runat="server" />
    <asp:HiddenField ID="hdnIdUtenteStorico" runat="server" />
    <uc1:SiarNewTab ID="ucSiarNewTab" runat="server" TabNames="Elenco utenti|Dettaglio utente|Ruolo"
        Width="800px" />
    <table id="tbElenco" runat="server" class="tableTab" width="800px">
        <tr>
            <td class="paragrafo">
                <br />
                <br />
                &nbsp;Selezione parametri di ricerca:
            </td>
        </tr>
        <tr>
            <td style="padding: 5px">
                <table style="width: 100%;">
                    <tr>
                        <td style="width: 224px">
                            &nbsp;Codice fiscale:<br />
                            <Siar:TextBox ID="txtRicercaCF" runat="server" MaxLength="16" Width="150px" />
                        </td>
                        <td style="width: 319px">
                            &nbsp;Nominativo:<br />
                            <Siar:TextBox ID="txtRicercaNominativo" runat="server" MaxLength="30" Width="290px" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 224px">
                            &nbsp;Ruolo:<br />
                            <Siar:ComboProfilo ID="lstRicercaProfilo" runat="server">
                            </Siar:ComboProfilo>
                        </td>
                        <td style="width: 319px">
                            &nbsp;Ente:<br />
                            <Siar:ComboEnte ID="lstRicercaEnte" runat="server" Width="290px">
                            </Siar:ComboEnte>
                        </td>
                        <td align="center">
                            <Siar:Button ID="btnCerca" runat="server" Modifica="False" OnClick="btnCerca_Click"
                                Text="Cerca" Width="150px" CausesValidation="False" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="paragrafo">
                <br />
                &nbsp;Elementi trovati: &nbsp;<asp:Label ID="lblNrUtenti" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dgUtenti" runat="server" Width="100%" PageSize="20" AllowPaging="True"
                    AutoGenerateColumns="False">
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle Width="30px" HorizontalAlign="center" />
                        </Siar:NumberColumn>
                        <Siar:ColonnaLink HeaderText="Nominativo" DataField="Nominativo" LinkFields="IdUtente"
                            LinkFormat="selezionaUtente({0});" IsJavascript="true">
                        </Siar:ColonnaLink>
                        <asp:BoundColumn HeaderText="CF" DataField="CfUtente">
                            <ItemStyle Width="120px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Profilo" DataField="Profilo">
                            <ItemStyle Width="120px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Ente" DataField="Ente">
                            <ItemStyle Width="120px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Provincia" DataField="Provincia">
                            <ItemStyle Width="50px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Attivo" DataField="Attivo" DataFormatString="{0:SI|NO}">
                            <ItemStyle Width="70px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>&nbsp;
            </td>
        </tr>
    </table>
    <table id="tbDettaglio" runat="server" class="tableTab" width="800px">
        <tr>
            <td class="paragrafo">
                <br />
                &nbsp;Inserire i dati dell&#39;operatore:
            </td>
        </tr>
        <tr>
            <td style="padding: 5px">
                <table width="100%">
                    <tr>
                        <td style="width: 225px">
                            Codice fiscale:
                            <br />
                            <Siar:TextBox ID="txtCodFiscale" runat="server" Width="150px" MaxLength="16" NomeCampo="Codice fiscale"
                                Obbligatorio="True"></Siar:TextBox>
                        </td>
                        <td>
                            <br />
                            <Siar:Button ID="btnScarica" runat="server" CausesValidation="False" OnClick="btnScarica_Click"
                                Text="Scarica dati anagrafici" OnClientClick="return checkCF(event);" />
                            <asp:HiddenField ID="hdnIdPersonaFisica" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 270px" colspan="2">
                            Nominativo:
                            <br />
                            <Siar:TextBox ID="txtNominativo" runat="server" Width="468px" ReadOnly="True" />
                        </td>
                    </tr>  
                </table>
            </td>
        </tr>
        <tr>
            <td align="right" style="height: 80px;padding-right:30px">
                <Siar:Button ID="btnSalva" runat="server" Width="180px" Text="Salva dati operatore"
                    OnClick="btnSalva_Click" Modifica="true"></Siar:Button>                
                &nbsp;&nbsp;&nbsp;&nbsp;
                <Siar:Button ID="btnNuovo" runat="server" Width="135px" Text="Nuovo operatore" CausesValidation="false"
                    OnClick="btnNuovo_Click" Modifica="true"></Siar:Button>
            </td>
        </tr>
        <tr>
            <td class="separatore">
                Elenco Ruoli
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right:30px;height: 40px" id="td1" colspan="2">
                <asp:CheckBox ID="chkAttivo" runat="server" Text="Attivo" />
                <Siar:Button ID="btnFiltra" runat="server" CausesValidation="False" OnClick="btnFiltra_Click" Text="Filtra" Width="140px" />
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right:30px;height: 40px" id="td2" colspan="2">
                <input type="button" class="Button"  id="btnNuovoRuolo" value="Nuovo Ruolo"  style="width: 140px;" onclick="pulisciStorico();" />
            </td>
        </tr>
        
        <tr>
            <td style="padding-bottom: 10px; padding-top: 10px">
                <Siar:DataGrid ID="dgUtentiStorico" runat="server" Width="100%" AllowPaging="True"
                    AutoGenerateColumns="False">
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle Width="30px" HorizontalAlign="center" />
                        </Siar:NumberColumn>
                        <Siar:ColonnaLink HeaderText="Profilo" DataField="Profilo" LinkFields="Id"
                            LinkFormat="selezionaRuolo({0});" IsJavascript="true">
                        </Siar:ColonnaLink>
                        <asp:BoundColumn HeaderText="Ente" DataField="Ente">
                            <ItemStyle Width="270px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Provincia" DataField="Provincia">
                            <ItemStyle Width="100px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Data inizio" DataField="Data">
                            <ItemStyle Width="100px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Attivo" HeaderText="Attivo" DataFormatString="{0:SI|NO}">
                            <ItemStyle Width="60px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
    </table>
    <table id="tbDettaglioRuolo" runat="server" class="tableTab" width="800px">
        <tr>
            <td class="paragrafo">
                <br />
                &nbsp;Inserire i ruoli dell&#39;operatore:
            </td>
        </tr>
        <tr>
            <td style="padding: 5px">
                <table width="100%">
                    <tr>
                        <td style="width: 270px" colspan="2">
                            Nominativo:
                            <br />
                            <Siar:TextBox ID="txtNominativoDett" runat="server" Width="468px" ReadOnly="True" />
                        </td>
                    </tr>
                </table>
                <table id="tbRuoloEsistente" runat="server" width="100%">        
                    <tr>
                        <td style="width: 270px" colspan="2">
                            Ente:
                            <br />
                            <Siar:TextBox ID="txtEnteDett" runat="server" Width="468px" ReadOnly="True" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 270px" colspan="2">
                            Ruolo:
                            <br />
                            <Siar:TextBox ID="txtRuoloDett" runat="server" Width="468px" ReadOnly="True" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 270px" colspan="2">
                            Provincia:
                            <br />
                            <Siar:TextBox ID="txtRuoloProv" runat="server" Width="468px" ReadOnly="True" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 270px" colspan="2">
                            Email:
                            <br />
                            <Siar:TextBox ID="txtEmailRO" runat="server" Width="468px" ReadOnly="True" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="height: 80px;padding-left:10px">
                            <Siar:Button ID="btnDisabilita" runat="server" Width="179px" Text="Disabilita operatore"
                                OnClick="btnDisabilita_Click" Modifica="true"></Siar:Button>
                            <Siar:Button ID="btnRiabilita" runat="server" Width="179px" Text="Riabilita operatore"
                                OnClick="btnRiabilita_Click" Modifica="true"></Siar:Button>
                            <Siar:Button ID="btnAggiornaEmail" runat="server" Width="179px" Text="Aggiorna Email"
                                OnClick="btnAggiornaEmail_click"  Modifica="true"></Siar:Button>
                        </td>
                    </tr>    
                </table>
                <table id="tbRuoloNuovo" runat="server" width="100%">
                    <tr>
                        <td style="width: 270px" colspan="2">
                            <uc2:GroupBoxProfilo ID="ucProfilo" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 225px">
                            Provincia:
                            <br />
                            <Siar:ComboProvince ID="lstProvincia" runat="server" CodRegione="11">
                            </Siar:ComboProvince>
                        </td>
                        <td>
<%--                            <br />
                            <asp:CheckBox ID="chkAttivo" runat="server" Text="Attivo" />
                            <Siar:TextBox ID="txtAttivo" runat="server" Width="150px" MaxLength="16" ReadOnly="True" Visible="false">
                            </Siar:TextBox>--%>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 270px" colspan="2">
                            Email:
                            <br />
                            <Siar:TextBox ID="txtEmail" runat="server" Width="468px" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="2" style="height: 80px;padding-left:10px">
                            <Siar:Button ID="btnSalvaRuolo" runat="server" Width="179px" Text="Salva Ruolo"
                                OnClick="btnSalvaRuolo_click" Modifica="true"></Siar:Button>
                        </td>
                    </tr>  
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
