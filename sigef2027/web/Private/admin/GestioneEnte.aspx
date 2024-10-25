<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    Inherits="web.Private.admin.GestioneEnte" CodeBehind="GestioneEnte.aspx.cs" %>

<%@ Register Src="../../CONTROLS/SiarNewTab.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
        function ctrlProvincia() {
            if(document.getElementById("ctl00_cphContenuto_lstProvincia").value=="") {
                if(document.getElementById("ctl00_cphContenuto_lstProfilo").value=="40") {
                    alert('Attenzione! Per operatori di inserimento è necessario selezionare la provincia di appartenenza.');
                    event.returnValue=0;
                }
                else if(!confirm('Attenzione! Non è stata selezionata la provincia di appartenenza dell`operatore. Continuare?'))
                    event.returnValue=0;
            }
        }
        function delUtente(id) {
            if(confirm('Attenzione! Si sta per eliminare l`operatore dall`ente di appartenenza. Continuare?')) {
                document.getElementById('ctl00_cphContenuto_hdnIdOperatore').value=id;
                document.getElementById('ctl00_cphContenuto_btnDelUtente').click();
            }
        }
        function delCuaa(id) {
            if(confirm('Attenzione! Si sta per eliminare il codice fiscale dalla lista delle aziende abilitate. Continuare?')) {
                document.getElementById('ctl00_cphContenuto_hdnDelCuaa').value=id;
                document.getElementById('ctl00_cphContenuto_btnDelCuaa').click();
            }
        }
        function ctrlCasellaCF() {
            var cf=document.getElementById("ctl00_cphContenuto_txtCodFiscale_text").value;
            if(cf==""||cf==null) {
                alert('Attenzione! Inserire un codice fiscale.');
                event.returnValue=0;
            }
        }
        function ctrlCF() {
            var cf=document.getElementById("ctl00_cphContenuto_txtCodFiscale_text").value;
            if(cf!="") {
                if(!(ctrlCodiceFiscale(cf))) {
                    alert('Attenzione! Codice fiscale non valido.');
                    document.getElementById("ctl00_cphContenuto_txtCodFiscale_text").select();
                }
            }
        }
        function ctrlCUAA() {
            var cf=document.getElementById("ctl00_cphContenuto_txtCFabilitato_text").value;
            if(cf!="") {
                if(!(ctrlPIVA(cf))&&!(ctrlCodiceFiscale(cf))) {
                    alert('Attenzione! Codice Fiscale non verificato!');
                    document.getElementById("ctl00_cphContenuto_txtCFabilitato_text").select();
                }
            }
        }
//--></script>

    <table class="tableNoTab" width="900">
        <tr>
            <td class="separatore">
                &nbsp;PAGINA DI GESTIONE ENTE DI APPARTENZA: (solo per coordinatori o responsabili)
            </td>
        </tr>
        <tr>
            <td>
                <br />
                &nbsp;- Questa pagina permette di gestire e monitorare l'attività dell'ente di appartenenza
                e dei suoi operatori. Questa sezione<br />
                &nbsp; &nbsp;è visibile solo ai coordinatori regionali o provinciali e le funzionalità
                sono suddivise per provincia a seconda dell'operatore<br />
                &nbsp;&nbsp; attualmente online.<br />
                <div style="display: none">
                    <asp:Button ID="btnPost" runat="server" OnClick="btnPost_Click" CausesValidation="False" />
                    <asp:Button ID="btnDelUtente" runat="server" OnClick="btnDelUtente_Click" CausesValidation="False" />&nbsp;
                    <Siar:Hidden ID="hdnIdOperatore" runat="server">
                    </Siar:Hidden>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;<table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td style="width: 490px">
                            <strong>&nbsp;Ente:<br />
                            </strong>
                            <Siar:TextBox  ID="txtNomeEnte" runat="server" Width="456px" ReadOnly="True" />
                        </td>
                        <td>
                            <strong>&nbsp;Provincia:<br />
                            </strong>
                            <Siar:ComboProvince ID="lstProvincia" runat="server">
                            </Siar:ComboProvince>
                        </td>
                    </tr>
                </table>
                &nbsp;
            </td>
        </tr>
    </table>
    <br />
    <uc1:SiarNewTab ID="ucSiarNewTab" runat="server" TabNames="Statistiche|Operatori|Abilitazioni Cod.Fiscale" />
    <table id="tabStatistiche" class="tableTab" runat="server" width="1050px">
        <tr>
            <td style="height: 28px">
            </td>
        </tr>
        <tr>
            <td style="height: 43px">
                <strong>&nbsp;Numero operatori:</strong> &nbsp;&nbsp;<Siar:IntegerTextBox ID="txtNumeroOperatori"
                    runat="server" ReadOnly="True" Width="59px" />
                &nbsp; &nbsp; &nbsp;&nbsp; <strong>Numero coordinatori/responsabili: &nbsp;
                    <Siar:IntegerTextBox ID="txtNumeroCoordinatori" runat="server" ReadOnly="True" Width="59px" />
                </strong>
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dgStatistiche" runat="server" AllowPaging="True" AllowSorting="true"
                    AutoGenerateColumns="False" PageSize="30" Width="100%">
                    <FooterStyle CssClass="coda" HorizontalAlign="Right" />
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle Width="40px" HorizontalAlign="center" />
                            <FooterStyle Width="40px" HorizontalAlign="center" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="Nominativo" HeaderText="Nominativo"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Profilo" HeaderText="Profilo">
                            <ItemStyle Width="150px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Provincia" HeaderText="Provincia">
                            <ItemStyle HorizontalAlign="Center" Width="70px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Nr. domande di aiuto in lavorazione">
                            <ItemStyle HorizontalAlign="Right" Width="90px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Nr. domande di aiuto presentate">
                            <ItemStyle HorizontalAlign="Right" Width="90px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Nr. domande di pagamento in lavorazione">
                            <ItemStyle HorizontalAlign="Right" Width="90px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Nr. domande di pagamento presentate">
                            <ItemStyle HorizontalAlign="Right" Width="90px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Nr. varianti/a.t. in lavorazione">
                            <ItemStyle HorizontalAlign="Right" Width="90px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Nr. varianti/a.t. presentate">
                            <ItemStyle HorizontalAlign="Right" Width="90px" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
                <table width="100%">
                    <tr>
                        <td align="right">
                            (
                        </td>
                        <td style="width: 11px; background-color: #d7d7d2">
                        </td>
                        <td style="width: 200px">
                            = operatori con mandato scaduto)
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
    </table>
    <table id="tabOperatori" class="tableTab" runat="server" width="900px">
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="paragrafo">
                &nbsp;Registrazione nuovo operatore:
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;<br />
                <table width="100%">
                    <tr>
                        <td style="width: 210px">
                            &nbsp;Codice fiscale:
                        </td>
                        <td style="width: 281px">
                            <Siar:Hidden ID="hdnIdPersona" runat="server">
                            </Siar:Hidden>
                        </td>
                        <td align="center" style="width: 19px">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 210px">
                            <Siar:TextBox  ID="txtCodFiscale" runat="server" MaxLength="16" NomeCampo="Codice fiscale"
                                Obbligatorio="True" Width="146px" />
                        </td>
                        <td style="width: 281px" align="center">
                            <Siar:Button ID="btnScarica" runat="server" Modifica="true" CausesValidation="False"
                                OnClick="btnScarica_Click" Text="Scarica da anagrafe tributaria" Width="200px"
                                OnClientClick="javascript:ctrlCasellaCF()" />
                        </td>
                        <td align="center" style="width: 19px">
                            &nbsp;<strong>(1)</strong>
                        </td>
                        <td>
                            &nbsp;Inserire il codice fiscale della persona e scaricare i dati dall&#39;anagrafe
                            tributaria
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 210px">
                            &nbsp;Nome:<Siar:TextBox  ID="txtNome" runat="server" NomeCampo="Nome" Obbligatorio="True"
                                ReadOnly="True" Width="184px" />
                        </td>
                        <td style="width: 281px">
                            &nbsp;Cognome:&nbsp;<br />
                            <Siar:TextBox  ID="txtCognome" runat="server" NomeCampo="Cognome" Obbligatorio="True"
                                ReadOnly="True" Width="249px" />
                        </td>
                        <td align="center" style="width: 19px">
                            &nbsp;<strong>(3)</strong>
                        </td>
                        <td>
                            &nbsp;Se il download dei dati è riuscito, automaticamente saranno<br />
                            &nbsp;visualizzati nome e cognome
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 210px; height: 42px">
                            &nbsp;Data fine validità:&nbsp; (click con il destro per il calendario)<br />
                            <Siar:DateTextBox ID="txtDataFVOperatore" runat="server" NomeCampo="Data fine validità"
                                Obbligatorio="True" Width="104px" />
                        </td>
                        <td style="width: 281px; height: 42px">
                            <br />
                            &nbsp;Profilo:&nbsp;<br />
                            <Siar:ComboProfilo ID="lstProfilo" runat="server" NomeCampo="Profilo" Obbligatorio="True">
                            </Siar:ComboProfilo>
                        </td>
                        <td align="center" style="width: 19px; height: 42px">
                            <strong>(4)</strong>
                        </td>
                        <td>
                            &nbsp;Scegliere profilo, data scadenza e provincia
                            <br />
                            &nbsp;(menu a tendina in alto, necessaria per operatori inserimento)
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 210px; height: 42px">
                        </td>
                        <td style="width: 281px; height: 42px">
                        </td>
                        <td align="center" style="width: 19px; height: 42px">
                            <strong>(5)</strong>
                        </td>
                        <td style="height: 42px">
                            <Siar:Button ID="btnNuovoOperatore" runat="server" Modifica="true" OnClick="btnNuovoOperatore_Click"
                                Text="Inserisci operatore" Width="198px" OnClientClick="ctrlProvincia()" />
                        </td>
                    </tr>
                </table>
                &nbsp;<br />
            </td>
        </tr>
        <tr>
            <td class="paragrafo">
                &nbsp;Lista degli operatori attualmente attivi costituenti l'ente (&nbsp;<Siar:Label
                    ID="lblNumeroOperatori" runat="server">
                </Siar:Label>
                )
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;<br />
                <Siar:DataGrid ID="dgUtenti" runat="server" AllowPaging="True" AllowSorting="true"
                    AutoGenerateColumns="False" PageSize="30" Width="100%">
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle Width="30px" HorizontalAlign="center" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="CfUtente" HeaderText="CF">
                            <ItemStyle Width="130px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Nominativo" HeaderText="Nominativo"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Profilo" HeaderText="Profilo">
                            <ItemStyle Width="180px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Provincia" HeaderText="Provincia">
                            <ItemStyle HorizontalAlign="Center" Width="70px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Attivo" HeaderText="Attivo">
                            <ItemStyle HorizontalAlign="Right" Width="90px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn>
                            <ItemStyle Width="120px" HorizontalAlign="center" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>&nbsp;
            </td>
        </tr>
    </table>
    <table id="tabCuaa" class="tableTab" runat="server" width="100%">
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="paragrafo">
                &nbsp;Registrazione nuovo Codice Fiscale:
            </td>
        </tr>
        <tr>
            <td style="height: 67px">
                <%--&nbsp;<table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td style="width: 205px">
                            &nbsp;CUAA da abilitare:
                        </td>
                        <td style="width: 167px">
                            &nbsp;Data inizio validità:
                        </td>
                        <td>
                            &nbsp;Data fine validità:&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 205px">
                            <Siar:TextBox  ID="txtCFabilitato" runat="server" Obbligatorio="True" MaxLength="16"
                                NomeCampo="CF da abilitare" Width="150px" />
                        </td>
                        <td style="width: 167px">
                            <Siar:DateTextBox ID="txtDataInizio" runat="server" NomeCampo="Data inizio validità"
                                Obbligatorio="True" Width="120px" />
                        </td>
                        <td>
                            <Siar:DateTextBox ID="txtDataFV" runat="server" Width="120px" NomeCampo="Data fine validità"
                                Obbligatorio="True"></Siar:DateTextBox>
                            <Siar:Button ID="btnNuovoCuaa" runat="server" Modifica="True" OnClick="btnNuovoCuaa_Click"
                                Text="Inserisci" Width="150px" />
                        </td>
                    </tr>
                </table>--%>
                <table id="Table3" width="100%">
                    <tr>
                        <td>
                            Cod.Fiscale:&nbsp;<Siar:TextBox  ID="txtCFabilitato" runat="server" Obbligatorio="True" MaxLength="16"
                                NomeCampo="Codice Fiscale dell`azienda" Width="150px" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Data inizio validità:&nbsp;<Siar:DateTextBox
                                ID="txtDataInizio" runat="server" NomeCampo="Data inizio validità" Obbligatorio="True"
                                Width="100px" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Data fine validità:&nbsp;<Siar:DateTextBox
                                ID="txtDataFV" runat="server" Width="100px" NomeCampo="Data fine validità" Obbligatorio="True">
                            </Siar:DateTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Ragione Sociale:&nbsp;<Siar:TextBox  ID="txtRagSociale" runat="server" Style="width: 500px"
                                ReadOnly="true" Width="450px" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <Siar:Button ID="btnNuovoCuaa" runat="server" Width="120px" Text="Salva" OnClick="btnNuovoCuaa_Click"
                                Modifica="True"></Siar:Button>&nbsp; &nbsp;&nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;<div style="display: none">
                    <asp:Button ID="btnDelCuaa" runat="server" OnClick="btnDelCuaa_Click" CausesValidation="False" />
                    <Siar:Hidden ID="hdnDelCuaa" runat="server">
                    </Siar:Hidden>
                </div>
            </td>
        </tr>
        <tr>
            <td class="paragrafo">
                &nbsp;Lista aziende abilitate: &nbsp;
                <Siar:Label ID="lblNumeroCuaaAbilitati" runat="server">
                </Siar:Label>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;&nbsp;<br />
                <Siar:DataGrid ID="dgCuaaAbilitati" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    PageSize="15" Width="100%">
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle HorizontalAlign="Center" Width="35px" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="CfAbilitato" HeaderText="Codice Fiscale"></asp:BoundColumn>
                        <asp:BoundColumn DataField="RagioneSociale" HeaderText="RagioneSociale"></asp:BoundColumn>
                        <asp:BoundColumn DataField="DataFineValidita" HeaderText="Valido fino">
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn>
                            <ItemStyle HorizontalAlign="Center" Width="150px" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>&nbsp; &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
