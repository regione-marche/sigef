<%@ Page Title="" Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    CodeBehind="MandatiImpresaUtente.aspx.cs" Inherits="web.Private.admin.MandatiImpresaUtente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <script type="text/javascript"><!--
        function revocaMandato(id_mandato) { if (confirm('Attenzione! Revocare il mandato aziendale?')) { $('[id$=hdnIdMandato]').val(id_mandato); $('[id$=btnRevocaMandato]').click(); } }
        function ctrlCuaa(elem, ev) { var cf = $(elem).val(); if (cf != "") { if (!ctrlPIVA(cf) && !ctrlCodiceFiscale(cf)) { alert('Attenzione! Codice fiscale/P.Iva non verificato!'); return stopEvent(ev); } } }
        function checkCuaa(ev) { if ($('[id$=txtCFabilitato_text]').val() == "") { alert('Attenzione! Digitare il Codice fiscale/P.Iva dell`impresa.'); return stopEvent(ev); } }
 //--></script>

    <table class="tableNoTab" width="900px">
        <tr>
            <td class="separatore_big">
                REGISTRAZIONE MANDATI IMPRESA
            </td>
        </tr>
        <tr>
            <td style="padding: 15px;">
                In questa pagina è possibile attribuire all'operatore selezionato le funzionalità
                <strong>gestione e inserimento/modifica</strong>
                <br />
                dei dati delle imprese agricole, ovvero la registrazione del mandato dell&#39;impresa.
                <br />
                A tal scopo è sufficiente inserire il <strong>Codice Fiscale</strong> (P.iva o C.F.) dell'impresa
                e definire l'intervallo temporaneo di validità,
                <br />
                trascorso il quale l'operatore non potrà più operare per conto dell&#39;azienda.
                <br />
                A seguire si visualizza l&#39;elenco completo dei mandati attivi e scaduti in carico
                all&#39;operatore.
            </td>
        </tr>
        <tr>
            <td class="paragrafo">
                &nbsp;Operatore selezionato:
            </td>
        </tr>
        <tr>
            <td style="padding: 5px">
                <table style="width: 100%;">
                    <tr>
                        <td style="width: 380px">
                            Ricerca C.F:<br />
                            <Siar:TextBox ID="txtCercaOperatore" runat="server" Width="350px"/>
                        </td>
                        <td>
                            <Siar:Button ID="btCercaOperatore" runat="server" Width="183px" 
                                Text="Cerca Consulente" Modifica="False" onclick="btCercaOperatore_Click" CausesValidation ="false"></Siar:Button>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 380px">
                            Nominativo:<br />
                            <Siar:TextBox ID="txtNominativoOperatore" runat="server" Width="350px" ReadOnly="True" />
                        </td>
                        <td>
                            C.F:<br />
                            <Siar:TextBox ID="txtCFOperatore" runat="server" Width="150px" ReadOnly="True" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 380px">
                            Ruolo:<br />
                            <Siar:TextBox ID="txtRuoloOperatore" runat="server" Width="350px" ReadOnly="True" />
                        </td>
                        <td>
                            Ente:<br />
                            <Siar:TextBox ID="txtEnteOperatore" runat="server" Width="350px" ReadOnly="True" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="paragrafo">
                <br />
                &nbsp;Selezione dell&#39;impresa:
            </td>
        </tr>
        <tr>
            <td style="padding: 5px">
                <table width="100%">
                    <tr>
                        <td style="width: 231px">
                            C.F./P.Iva:&nbsp;<br />
                            <Siar:TextBox ID="txtCFabilitato" runat="server" Obbligatorio="True" MaxLength="16"
                                NomeCampo="Codice Fiscale dell`azienda" Width="200px" />
                        </td>
                        <td style="width: 318px">
                            <br />
                            <Siar:Button ID="btnScaricaAT" runat="server" Width="193px" Text="Scarica dati anagrafici"
                                OnClick="btnScaricaAT_Click" Modifica="True" CausesValidation="False" OnClientClick="return checkCuaa(event);">
                            </Siar:Button>
                        </td>
                        <td style="width: 389px" valign="bottom">
                            <b>1)</b> Digitare il <b>Codice Fiscale</b> dell&#39;impresa desiderata e
                            <br />
                            &nbsp;&nbsp;&nbsp;&nbsp; scaricare i dati anagrafici
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            Ragione Sociale:&nbsp;<br />
                            <Siar:TextBox ID="txtRagSociale" runat="server" ReadOnly="True" Width="500px" />
                        </td>
                        <td style="width: 389px" valign="bottom">
                            <b>2)</b> Se la procedura ha successo verrà visualizzata
                            <br />
                            &nbsp;&nbsp;&nbsp;&nbsp; la ragione sociale dell&#39;impresa
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 231px">
                            Data inizio validità:<br />
                            <Siar:DateTextBox ID="txtDataInizio" runat="server" Width="120px" ReadOnly="True" />
                        </td>
                        <td style="width: 318px">
                            Data fine validità:<br />
                            <Siar:DateTextBox ID="txtDataFV" runat="server" Width="100px" NomeCampo="Data fine validità"
                                Obbligatorio="True"></Siar:DateTextBox>
                        </td>
                        <td style="width: 389px" valign="bottom">
                            <b>3)</b> Digitare data inizio e data fine validità del mandato<br />
                            &nbsp;&nbsp;&nbsp;&nbsp; e salvare i dati
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="height: 68px" colspan="3">
                            <Siar:Button ID="btnSalva" runat="server" Width="183px" Text="Salva" OnClick="btnSalva_Click"
                                Modifica="True"></Siar:Button>
                            <asp:HiddenField ID="hdnIdImpresa" runat="server" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="separatore">
                Elenco mandati in carico: (<asp:Label ID="lblNumeroAbilitati" runat="server"></asp:Label>)
            </td>
        </tr>
        <tr>
            <td>
                <table style="width: 100%;">
                    <tr>
                        <td style="width: 158px; height: 57px">
                            &nbsp;Codice Fiscale:<br />
                            <Siar:TextBox ID="txtRicercaCuaa" runat="server" MaxLength="16" Width="140px" />
                        </td>
                        <td style="width: 297px; height: 57px">
                            Ragione sociale:<br />
                            <Siar:TextBox ID="txtRicercaRagioneSociale" runat="server" Width="280px" />
                        </td>
                        <td style="height: 57px">
                            <br />
                            <Siar:Button ID="btnRicerca" runat="server" CausesValidation="False" OnClick="btnRicerca_Click"
                                Text="Filtra" Width="120px" OnClientClick="return ctrlCuaa($('[id$=txtRicercaCuaa_text]'),event);" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dgMandati" runat="server" Width="100%" PageSize="15" AllowPaging="True"
                    AutoGenerateColumns="False">
                    <ItemStyle Height="24px" />
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle Width="35px" HorizontalAlign="center" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn HeaderText="Codice Fiscale" DataField="Cuaa">
                            <ItemStyle Width="130px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="P.Iva" DataField="CodiceFiscale">
                            <ItemStyle Width="130px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Ragione Sociale" DataField="RagioneSociale"></asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Valido fino" DataField="DataFineValidita">
                            <ItemStyle Width="80px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn>
                            <ItemStyle Width="150px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>&nbsp;<div style="display: none">
                    <asp:HiddenField ID="hdnIdMandato" runat="server" />
                    <asp:Button ID="btnRevocaMandato" runat="server" OnClick="btnRevocaMandato_Click"
                        CausesValidation="false" />
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
