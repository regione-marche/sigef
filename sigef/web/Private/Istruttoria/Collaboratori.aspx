<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.Istruttoria.Collaboratori" CodeBehind="Collaboratori.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <script type="text/javascript">
        function SNCVZCercaUtenti_onselect(obj) { if (obj) { $('[id$=hdnIdUtente]').val(obj.IdUtente); $('[id$=txtNominativo_text]').val(obj.Nominativo); } else alert('L`elemento selezionato non è valido.'); }
        function SNCVZCercaUtenti_onprepare() { $('[id$=hdnIdUtente]').val(''); }
        function selezionaMembro(id) { $('[id$=hdnIdCollaboratorePost').val(id); $('[id$=btnPost]').click(); }
    </script>
    <div style="display: none">
        <asp:HiddenField ID="hdnIdCollaboratorePost" runat="server" />
        <asp:Button ID="btnPost" runat="server" OnClick="btnPost_Click" />
    </div>
    <br />
    <table class="tableNoTab" width="900">
        <tr>
            <td class="separatore_big">Elenco dei funzionari istruttori per il bando
            </td>
        </tr>
        <tr>
            <td style="height: 39px">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width: 169px; height: 49px;" align="left">&nbsp; <strong>Applica filtro per provincia:</strong>
                        </td>
                        <td style="width: 248px; height: 49px;" align="left">
                            <Siar:ComboProvince ID="lstProvincia" runat="server" CodRegione="11" AutoPostBack="true">
                            </Siar:ComboProvince>
                        </td>
                        <td align="right" style="height: 49px">
                            <Siar:Button ID="btnVisualizzaListaIstruttori" runat="server" Width="191px" Text="Visualizza lista istruttori"
                                OnClick="btnVisualizzaListaIstruttori_Click" />
                            &nbsp;&nbsp;&nbsp;
                            <input id="btnNuovo" runat="server" type="button" onclick="location = 'AssegnazioneDomande.aspx'"
                                value="Assegnazione domande pervenute" style="width: 212px" class="Button" />&nbsp;&nbsp;&nbsp;&nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <asp:HiddenField ID="hdnVisualizzaListaIstruttori" runat="server" />
                <Siar:DataGrid ID="dgIstruttori" runat="server" AutoGenerateColumns="False" Width="100%"
                    ShowFooter="true">
                    <Columns>
                        <Siar:ColonnaLink DataField="Nominativo" HeaderText="Istruttore" IsJavascript="true"
                            LinkFields="IdUtente" LinkFormat="alert('L`operatore non possiede i necessari permessi per proseguire.');">
                        </Siar:ColonnaLink>
                        <asp:BoundColumn DataField="Provincia" HeaderText="Provincia">
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Nr. domande assegnate">
                            <ItemStyle HorizontalAlign="Center" Width="90px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Nr. domande ricevibili">
                            <ItemStyle HorizontalAlign="Center" Width="90px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Nr. domande NON ricevibili">
                            <ItemStyle HorizontalAlign="Center" Width="90px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Nr. domande ammissibili">
                            <ItemStyle HorizontalAlign="Center" Width="90px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Nr. domande NON ammissibili">
                            <ItemStyle HorizontalAlign="Center" Width="90px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Nr. domande istruite da altri">
                            <ItemStyle HorizontalAlign="Center" Width="90px" />
                        </asp:BoundColumn>
                        <%--<asp:BoundColumn HeaderText="Totale">
                            <ItemStyle HorizontalAlign="Center" Width="90px" />
                        </asp:BoundColumn>--%>
                    </Columns>
                </Siar:DataGrid>&nbsp;
            </td>
        </tr>
        <tr>
            <td>&nbsp;Domande presentate: &nbsp;<b><Siar:Label ID="lblDomandePresentate" runat="server">
            </Siar:Label>
            </b>
            </td>
        </tr>
        <tr>
            <td>&nbsp;Domande non ancora assegnate:<b>
                <Siar:Label ID="lblDomande" runat="server">
                </Siar:Label>
            </b>
            </td>
        </tr>
        <tr>
            <td>&nbsp;
            </td>
        </tr>
        <tr>
            <td class="separatore_big">Elenco dei funzionari collaboratori all'istruttoria del bando
            </td>
        </tr>
        <tr>            
            <td style="padding-left: 10px; height: 43px;">
                <br />
                <p>I collaboratori all'istruttoria vengono nominati a livello di Bando e collaborano con gli istruttori all'istruttoria delle domande. I collaboratori all'istruttoria non possono firmare le istruttoria ma solo istruire le pratiche, pertanto non ha senso inserire tra i collaboratori all'istruttoria qualcuno che sia già istruttore di una o più domande, in quanto questo lo inibirebbe alla firma delle istruttorie stesse. Quindi è sempre bene inserire come collaboratori all'istruttoria funzionari che non siano istruttori di nessuna domanda ne RUP.</p>
                <br />
                <Siar:TextBox ID="txtNominativo" runat="server" Width="524px" />
                <asp:HiddenField ID="hdnIdUtente" runat="server" />
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right: 30px; height: 60px">
                <Siar:Button ID="btnAssegna" runat="server" OnClick="btnAssegna_Click" Text="Assegna collaboratore"
                    Width="230px" Modifica="True" />&nbsp;
                <Siar:Button ID="btnEliminaCollaboratore" runat="server" OnClick="btnEliminaCollaboratore_Click"
                    Conferma="Attenzione! Eliminare il collaboratore selezionato?" Text="Elimina collabotatore"
                    Width="200px" Modifica="True" />&nbsp;
                            <Siar:Button ID="btnNewCollaboratore" runat="server" Text="Nuovo" OnClick="btnNewCollaboratore_Click"
                                Width="127px" CausesValidation="false" Modifica="true" />
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dgCollaboratoriIstruttoriaBando" runat="server" AutoGenerateColumns="False" Width="100%"
                    ShowFooter="true">
                    <Columns>
                        <Siar:ColonnaLink DataField="Nominativo" HeaderText="Nominativo" LinkFields="Id"
                            LinkFormat='javascript:selezionaMembro({0})'>
                        </Siar:ColonnaLink>
                        <asp:BoundColumn DataField="Attivo" HeaderText="Attivo" DataFormatString="{0:SI|NO}">
                            <ItemStyle Width="80px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>&nbsp;
            </td>
        </tr>
        <tr>
            <td>&nbsp;
            </td>
        </tr>
        <tr>
            <td class="separatore">&nbsp; Vai alle pagine:
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 150px">
                <table>
                    <tr>
                        <td style="height: 34px; width: 759px;">
                            <input type="button" onclick="location = 'ComunicazioneNonRicevibilita.aspx'" value="Comunicazione non ricevibilità"
                                style="width: 230px" class="Button" />
                            &nbsp;&nbsp;
                            <input type="button" onclick="location = 'ComunicazioneNonAmmissibilita.aspx'" value="Comunicazione non ammissibilità"
                                style="width: 230px" class="Button" />
                            &nbsp; &nbsp;<input type="button" onclick="location = 'ComunicazioneEsitoIstruttorio.aspx'"
                                value="Comunicazione esito istruttorio" style="width: 230px" class="Button" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 34px; width: 759px;">
                            <input type="button" onclick="location = 'ComunicazioniEntrata.aspx'" value="Comunicazioni in entrata"
                                style="width: 230px" class="Button" />
                            &nbsp;&nbsp;
                            <input type="button" onclick="location = 'RapportoIstruttorio.aspx'" value="Rapporto istruttorio"
                                style="width: 230px" class="Button" />&nbsp;&nbsp;&nbsp;
                            <input type="button" onclick="location = 'ComunicazioneFinanziabilita.aspx'" value="Comunicazione di finanziabilità"
                                style="width: 230px" class="Button" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 34px; width: 759px;">
                            <input type="button" onclick="location = 'DecretiDecadenza.aspx'" value="Decreti di decadenza"
                                style="width: 230px; display: none;" class="Button" />
                            <%--&nbsp;&nbsp;&nbsp;--%>
                            <input type="button" onclick="location = 'ListaComunicazioni.aspx'" value="Richieste documentali"
                                style="width: 230px" class="Button" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
