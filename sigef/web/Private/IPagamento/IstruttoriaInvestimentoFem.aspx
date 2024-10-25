<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.IPagamento.IstruttoriaInvestimentoFem" CodeBehind="IstruttoriaInvestimentoFem.aspx.cs" %>

<%@ Register Src="../../CONTROLS/IDomandaPagamento.ascx" TagName="IDomandaPagamento" TagPrefix="uc2" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript">
        function salvaPagamento(idPagamento) {
            if (confirm('Confermi l\'importo ammesso del contratto selezionato?')) {
                $('[id$=hdnIdPagamentoFemSalvataggio]').val(idPagamento);
                $('[id$=btnSalvaPagamento]').click();
            }
        }

        function salvaPagamenti() {
            if (confirm('Confermi l\'importo ammesso di tutti i contratti associati?')) {
                return true;
            }

            return false;
        }
    </script>

    <div style="display: none">
        <Siar:Button ID="btnSalvaPagamento" runat="server" OnClick="btnSalvaPagamento_Click" CausesValidation="False" />
        <asp:HiddenField ID="hdnIdPagamentoFem" runat="server" />
        <asp:HiddenField ID="hdnIdPagamentoFemSalvataggio" runat="server" />
    </div>

    <br />
    <uc2:IDomandaPagamento ID="ucIDomandaPagamento" runat="server" />
    <br />
    <table class="tableNoTab" style="width: 1000px">
        <tr>
            <td class="separatore_big">
                ISTRUTTORIA DEI PAGAMENTI RICHIESTI PER L'INVESTIMENTO
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr class="TESTA1">
            <td style="width: 420px" valign="middle">
                &nbsp;Dettagli investimento:&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; <a href="" id="lnkInvestimento"
                    runat="server">[Visualizza storico dell`investimento]</a>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left" style="width: 466px" valign="top">
                            <table id="tbInvestimento" runat="server" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td align="center" style="width: 33px; height: 31px">
                                    </td>
                                    <td align="center" style="width: 33px; height: 31px">
                                    </td>
                                    <td align="center" style="width: 33px; height: 31px">
                                    </td>
                                    <td align="left" style="width: 367px; height: 31px">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="height: 23px" valign="middle">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="height: 23px" valign="middle">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="height: 23px" valign="middle">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="height: 23px" valign="middle">
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td valign="middle">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="width: 157px; height: 57px; ">
                                        <br />
                                        &nbsp; &nbsp; &nbsp;<strong>(A)</strong> Costo investimento:<br />
                                        &nbsp;
                                        &euro;
                                        <Siar:CurrencyBox ID="txtCostoInvestimento" runat="server" ReadOnly="True" Width="100px" />
                                    </td>
                                    <td style="width: 143px; height: 57px ; display:none;">
                                        <br />
                                        <strong>(B)</strong>&nbsp;<Siar:Label ID="lblSpeseTecniche" runat="server">
                                        </Siar:Label>
                                        <br />
                                        <Siar:CurrencyBox ID="txtSpeseTecniche" runat="server" ReadOnly="True" Width="100px" />
                                    </td>
                                    <td style="width: 132px; height: 57px">
                                        <br />
                                        Contributo:<br />
                                        <Siar:CurrencyBox ID="txtContributoAmmesso" runat="server" ReadOnly="True" Width="100px" />
                                    </td>
                                    <td style="width: 102px; height: 57px">
                                        <br />
                                        Aiuto %:<br />
                                        <Siar:QuotaBox NrDecimali="12" ID="txtQuotaAiuto" runat="server" ReadOnly="True" Width="50px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="paragrafo" colspan="4" style="height: 31px">
                                        <br />
                                        &nbsp;Totali richiesti fino ad ora per l'investimento:
                                    </td>
                                </tr>
                                <tr>
                                    <td style="border-left: black 1px solid; width: 157px; height: 57px">
                                        <br />
                                        &nbsp; &nbsp; <strong>(C)</strong> Importo totale:<br />
                                        &nbsp;
                                        &euro;
                                        <Siar:CurrencyBox ID="txtStoricoImportoRichiesto" runat="server" ReadOnly="True"
                                            Width="100px" />
                                        <br />
                                        &nbsp;
                                    </td>
                                    <td style="width: 143px; height: 57px">
                                        <br />
                                        Contributo:<br />
                                        <Siar:CurrencyBox ID="txtStoricoContributoRichiesto" runat="server" ReadOnly="True"
                                            Width="100px" />
                                        <br />
                                        &nbsp;
                                    </td>
                                    <td colspan="2" style="height: 57px">
                                        <br />
                                        <table cellpadding="0" cellspacing="0" width="100%">
                                            <tr>
                                                <td style="width: 87px">
                                                    &nbsp;Aiuto %:&nbsp;<br />
                                                    <Siar:QuotaBox ID="txtStoricoRichiestoQuota" NrDecimali="12" runat="server" ReadOnly="True" Width="50px" />
                                                </td>
                                                <td style="border-left: black 1px solid">
                                                    &nbsp; %&nbsp;Completamento:<br />
                                                    <strong>&nbsp; &nbsp;<asp:Label ID="lblFormulaCompletamento" runat="server" Text="(C/(A+B))"></asp:Label>&nbsp;
                                                    </strong>&nbsp;<Siar:QuotaBox NrDecimali="12" ID="txtCompletamentoInvestimento" runat="server"
                                                        ReadOnly="True" Width="50px" />
                                                </td>
                                            </tr>
                                        </table>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <%--<tr class="TESTA1" style="visibility: collapse;">
            <td valign="middle">
                &nbsp;Totale fondi presi da disavanzi altri investimenti nel limite del 10%:
            </td>
        </tr>
        <tr style="visibility: collapse;">
            <td>
                &nbsp;<table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="center" style="width: 33px">
                            <br />
                            &nbsp; &nbsp; &nbsp; &euro;
                        </td>
                        <td align="left" style="width: 150px">
                            Spesa Extra disponibile per economie:<br />
                            <Siar:CurrencyBox ID="txtDisavanzoInvestimento" runat="server" ReadOnly="True" Width="120px" />
                        </td>
                        <td align="left" style="width: 150px">
                            Contributo Extra disponibile per economie<br />
                            <Siar:CurrencyBox ID="txtDisavanzoInvestimentoContributo" runat="server" ReadOnly="True" Width="120px" />
                        </td>
                        <td align="left" style="width: 150px">
                            Economie totali da investimenti tagliati:<br />
                            <Siar:CurrencyBox ID="txtEconomieDaCoprire" runat="server" ReadOnly="true" Width="120px" />
                        </td>
                        <td align="left" style="width: 150px">
                            Economie rimanenti da coprire:<br />
                            <Siar:CurrencyBox ID="txtEconomieScoperte" runat="server" ReadOnly="true" Width="120px" />
                        </td>
                        <td>
                            Contributi riassegnati in altre domande per l'investimento:<br />
                            <Siar:CurrencyBox ID="txtImportoRiassegnatoInvestimento" runat="server" ReadOnly="true" Width="120px" />
                        </td>
                        <td align="left" style="width: 150px">
                            Costo spesa extra da assegnare:<br />
                            <Siar:CurrencyBox ID="txtCostoDaAssegnare" runat="server" Width="120px" />
                        </td>
                        <td align="left" style="width: 150px">
                            Contributo extra da assegnare:<br />
                            <Siar:CurrencyBox ID="txtContributoDaAssegnare" ReadOnly="true" runat="server" Width="120px" />
                        </td>
                        <td align="left" style="width: 150px">
                            &nbsp;
                        </td>
                    </tr>
                </table>
                &nbsp;
            </td>
        </tr>--%>
        <tr class="TESTA1">
            <td valign="middle">
                &nbsp;Totali pagamento richiesto:
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;<table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="center" style="width: 30px">
                            <br />
                            <br />
                            &nbsp; &nbsp; &nbsp; &euro;
                        </td>
                        <td style="width: 150px; display:none;" align="left">
                            <br />
                            Importo investimento:<br />
                            <Siar:CurrencyBox ID="txtImportoInvestimento" runat="server" ReadOnly="True" Width="120px" />
                        </td>
                        <td style="width: 150px;display:none;" align="left" >
                            Importo da
                            <br />
                            computo metrico:<strong>(*)</strong>&nbsp;<br />
                            <Siar:CurrencyBox ID="txtImportoComputoMetrico" runat="server" Width="120px" ReadOnly="True" />
                        </td>
                        <td align="left" style="width: 150px; display:none;">
                            <br />
                            Importo spese tecniche:<br />
                            <Siar:CurrencyBox ID="txtImportoSpeseTecniche" runat="server" ReadOnly="True" Width="120px" />
                        </td>
                        <td style="width: 150px" align="left">
                            <br />
                            Importo totale:<br />
                            <Siar:CurrencyBox ID="txtImportoTotaleRichiesto" runat="server" ReadOnly="True" Width="120px" />
                        </td>
                        <td align="left">
                            <br />
                            Contributo totale: &nbsp;&nbsp;<br />
                            <Siar:CurrencyBox ID="txtContributoTotaleRichiesto" runat="server" ReadOnly="True"
                                Width="120px" />
                        </td>
                        <td id="tdRichiestoAltreFonti" align="left" style="width: 150px" runat="server">
                            <br />
                            Contributo Altre Fonti:<br />
                            <Siar:CurrencyBox ID="txtContributoRichiestoAltreFonti" runat="server" ReadOnly="True" Width="120px" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="width: 30px">
                        </td>
                        <td align="left" style="width: 150px">
                            &nbsp;
                        </td>
                        <td align="left" style="width: 150px">
                            &nbsp;
                        </td>
                        <td align="left" style="width: 150px">
                        </td>
                        <td align="left" style="width: 150px">
                        </td>
                        <td align="left">
                        </td>
                    </tr>
                    <tr style="display:none;">
                        <td align="center" style="width: 30px">
                            <br />
                            <br />
                            &nbsp; &nbsp; &nbsp; &euro;
                        </td>
                        <td align="left" style="width: 150px ">
                            Importo<br />
                            lavori in economia: <b>(***)</b><br />
                            <Siar:CurrencyBox ID="txtImportoRichiestoLavoriInEconomia" runat="server" ReadOnly="True"
                                Width="120px" />
                        </td>
                        <td align="left" style="width: 150px">
                            % lavori in economia<br />
                            su totale:<br />
                            <Siar:CurrencyBox ID="txtQuotaRichiestoLavoriInEconomia" runat="server" ReadOnly="True"
                                Width="120px" />
                        </td>
                        <td align="left" style="width: 150px">
                        </td>
                        <td align="left" style="width: 150px">
                        </td>
                        <td align="left">
                        </td>
                    </tr>
                </table>
                &nbsp;
            </td>
        </tr>
        <tr class="TESTA1">
            <td valign="middle">
                &nbsp;Totali pagamento ammesso:
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;<table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="center" style="width: 29px">
                            <br />
                            <br />
                            &nbsp; &nbsp; &nbsp; &euro;
                        </td>
                        <td style="width: 150px; display:none;" align="left">
                            <br />
                            Importo investimento:<br />
                            <Siar:CurrencyBox ID="txtImportoInvestimentoAmmesso" runat="server" ReadOnly="True"
                                Width="120px" />
                        </td>
                        <td style="width: 150px; display:none;" align="left" >
                            <b>(M)</b> Importo da<br />
                            computo metrico:<strong>(*)</strong><br />
                            <Siar:CurrencyBox ID="txtImportoComputoMetricoAmmesso" runat="server" Width="120px" />
                        </td>
                        <td align="left" style="width: 150px; display:none;">
                            <br />
                            Importo spese tecniche:<br />
                            <Siar:CurrencyBox ID="txtImportoSpeseTecnicheAmmesse" runat="server" ReadOnly="True"
                                Width="120px" />
                        </td>
                        <td style="width: 150px" align="left">
                            <br />
                            Importo totale:<br />
                            <Siar:CurrencyBox ID="txtImportoTotaleAmmesso" runat="server" ReadOnly="True" Width="120px" />
                        </td>
                        <td align="left" style="width: 150px">
                            <b>
                                <br />
                                </b>&nbsp;Contributo totale: &nbsp;&nbsp;&nbsp;<br />
                            <Siar:CurrencyBox ID="txtContributoTotaleAmmesso" runat="server" ReadOnly="True"
                                Width="120px" />
                        </td>
                        <td align="left">
                            <br />
                            Contributo finale: <strong>(**)</strong><br />
                            <Siar:CurrencyBox ID="txtContributoAmmessoFinale" runat="server" ReadOnly="True"
                                Width="120px" />
                        </td>
                        <td id="tdAmmessoAltreFonti" align="left" style="width: 150px" runat="server">
                            <br />
                            Contributo Altre Fonti:<br />
                            <Siar:CurrencyBox ID="txtContributoAmmessoAltreFonti" runat="server" ReadOnly="True" Width="120px" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="width: 29px">
                        </td>
                        <td align="left" style="width: 150px">
                        </td>
                        <td align="left" style="width: 150px">
                            &nbsp;
                        </td>
                        <td align="left" style="width: 150px">
                        </td>
                        <td align="left" style="width: 150px">
                        </td>
                        <td align="left" style="width: 150px">
                        </td>
                        <td align="left">
                        </td>
                    </tr>
                    <tr  style="display:none;">
                        <td align="center" style="width: 29px">
                            <br />
                            <br />
                            &nbsp; &nbsp; &nbsp; &euro;
                        </td>
                        <td align="left" style="width: 150px">
                            <b>(E)</b>&nbsp;Importo<br />
                            lavori in economia: <b>(***)</b><br />
                            <Siar:CurrencyBox ID="txtImportoAmmessoLavoriInEconomia" runat="server" ReadOnly="True"
                                Width="120px" />
                        </td>
                        <td align="left" style="width: 150px">
                            % lavori in economia<br />
                            su totale:<br />
                            <Siar:CurrencyBox ID="txtQuotaAmmessoLavoriInEconomia" runat="server" ReadOnly="True"
                                Width="120px" />
                        </td>
                        <td align="left" style="width: 150px">
                        </td>
                        <td align="left" style="width: 150px">
                        </td>
                        <td align="left" style="width: 150px">
                        </td>
                        <td align="left">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <%--<tr>
            <td align="right">
                <b>(*)</b> =&nbsp; inserire l'importo da preventivo qualora il c.m. non fosse richiesto<br />
                &nbsp;<b>(**)</b> = importo al netto delle sanzioni<br />
                &nbsp;<b>(***)</b> = il contributo non puo&#39; superare la differenza tra rendicontato
                e importo lavori in economia <b>( T&lt;= M - E )<br />
                </b>
            </td>
        </tr>--%>
        <%--<tr class="TESTA1">
            <td>
                &nbsp;Sanzioni comminate per l'investimento:
            </td>
        </tr>--%>
        <%--<tr>
            <td>
                &nbsp;<br />
                <Siar:DataGrid ID="dgSanzioni" runat="server" AutoGenerateColumns="False" Width="100%"
                    ShowFooter="True">
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle HorizontalAlign="Center" Width="25px" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="Titolo" HeaderText="Descrizione">
                            <ItemStyle Width="275px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Entit&#224;">
                            <ItemStyle Width="200px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Gravit&#224;">
                            <ItemStyle Width="200px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Durata">
                            <ItemStyle Width="200px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Ammontare" HeaderText="Ammontare" DataFormatString="{0:c}">
                            <ItemStyle Width="100px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                    </Columns>
                    <FooterStyle CssClass="TotaliFooter" />
                    <PagerStyle CssClass="coda" />
                    <AlternatingItemStyle BackColor="#FFF0D2" CssClass="DataGridRow" />
                    <ItemStyle CssClass="DataGridRow" Height="18px" />
                    <HeaderStyle CssClass="TESTA1" Font-Bold="True" ForeColor="White" />
                </Siar:DataGrid>&nbsp;
            </td>
        </tr>--%>
        <%--<tr>
            <td align="right" style="height: 48px">
                <Siar:Button ID="btnCalcolaSanzioni" runat="server" CausesValidation="False" Modifica="True"
                    OnClick="btnCalcolaSanzioni_Click" Text="Calcola sanzioni" Width="180px" />
                &nbsp;&nbsp;
                <Siar:Button ID="btnDelSanzioni" runat="server" CausesValidation="False" Modifica="True"
                    OnClick="btnDelSanzioni_Click" Text="Annulla tutte le sanzioni" Conferma="Attenzione! Annullare tutte le sanzioni comminate?"
                    Width="180px" />
                &nbsp;
                <Siar:Button ID="btnNuovaSanzione" runat="server" CausesValidation="False" Modifica="True"
                    OnClick="btnNuovaSanzione_Click" Text="Nuova sanzione" Width="140px" />
                &nbsp; &nbsp;
            </td>
        </tr>--%>
        <%--<tr id="trIntegrazioneInvestimenti" runat="server" visible="false">
            <td>
                <table width="100%">
                    <tr class="TESTA1">
                        <td colspan="2">
                            &nbsp;Richiedi integrazione per l'investimento:
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;<br />
                            &nbsp;&nbsp;&nbsp;Data richiesta:<br />
                            &nbsp;&nbsp;&nbsp;<Siar:DateTextBox ID="txtDataRichiesta" runat="server" Width="120px" />
                            <br />
                            <br />
                            &nbsp;&nbsp;&nbsp;Note richiesta:<br />
                            &nbsp;&nbsp;&nbsp;<Siar:TextArea ID="txtNoteIntegrazioneRichiesta" runat="server"
                                Width="600px" Rows="4" ExpandableRows="5" MaxLength="10000" />
                        </td>
                        <td align="right">
                            <Siar:Button ID="btnNuovaRichiestaIntegrazioneInvestimenti" runat="server" CausesValidation="False"
                                Modifica="True" OnClick="btnNuovaRichiestaIntegrazioneInvestimenti_Click" Text="Nuova richiesta integrazione"
                                Width="180px" />
                            <br />
                        </td>
                    </tr>
                </table> 
            </td> 
        </tr>--%>
        <tr class="TESTA1">
            <td>
                &nbsp;Valutazione dell'istruttore:
            </td>
        </tr>
        <tr>
            <td align="center">
                &nbsp;<br />
                <Siar:TextArea ID="txtValutazioneLunga" runat="server" Rows="3" Width="780px" ExpandableRows="5" />
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 50px">
                <br />
                <Siar:Button ID="btnSalva" runat="server" CausesValidation="False" OnClick="btnSaveRichiesto_Click" OnClientClick="return salvaPagamenti();"
                    Text="Ammetti" Width="180px" Modifica="True" />&nbsp; &nbsp;&nbsp;
                <%--<Siar:Button ID="btnVariazioneInvestimento" runat="server" CausesValidation="False"
                    Modifica="True" OnClick="btnVariazioneInvestimento_Click" Text="Variazione investimento"
                    Width="180px" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <input type="button" class="Button" value="Correttiva rendicontazione" style="width: 180px"
                    onclick="location='IstruttoriaCorrettivaRendicontazione.aspx'" />--%>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <input id="btnBack" runat="server" class="Button" style="width: 130px" type="button"
                    onclick="location='IstruttoriaPianoInvestimenti.aspx'" value="Indietro" /><br />
                &nbsp;
            </td>
        </tr>
    </table>
    <br />
    <table class="tableNoTab" style="width: 1100px">
        <tr class="TESTA1">
            <td>
                Elenco contratti associati (<asp:Label ID="lblNumeroPagamenti" runat="server"></asp:Label>)
            </td>
        </tr>
        <tr>
            <td>
                <br />
                <Siar:DataGrid ID="dgPagamenti" runat="server" AutoGenerateColumns="False" Width="100%" ShowFooter="true">
                    <FooterStyle CssClass="coda" HorizontalAlign="Right" />
                    <Columns>
                        <asp:BoundColumn HeaderText="Id" DataField="IdPagamentoRichiestoFem">
                            <ItemStyle HorizontalAlign="Center" Width="30px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Tipologia" DataField="IdPagamentoRichiestoFem">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Riferimenti">
                            <ItemStyle HorizontalAlign="left" />
                        </asp:BoundColumn>
                        <Siar:JsButtonColumn Arguments="SegnaturaContratto" ButtonType="ImageButton" ButtonImage="/print_ico.gif" ButtonText="Visualizza protocollo" JsFunction="sncAjaxCallVisualizzaProtocollo">
                            <ItemStyle HorizontalAlign="Center" />
                        </Siar:JsButtonColumn>
                        <asp:BoundColumn DataField="ImportoContratto" HeaderText="Importo contratto/giustificativo" DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" Width="100px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ImportoRichiesto" HeaderText="Importo richiesto" DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" Width="100px" />
                        </asp:BoundColumn>
                        <Siar:NewImportoColumn DataField="IdPagamentoRichiestoFem" Name="ImportoAmmesso" Importo="ImportoAmmesso" HeaderText="Importo ammesso" DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" Width="100px" />
                        </Siar:NewImportoColumn>
                        <Siar:JsButtonColumn Arguments="IdPagamentoRichiestoFem" ButtonText="Salva pagamento" JsFunction="salvaPagamento">
                            <ItemStyle HorizontalAlign="Center" Width="140px" />
                        </Siar:JsButtonColumn>
                    </Columns>
                </Siar:DataGrid>
                <div style="width: 100%; text-align: right">
                    <span class='testoRosso'>(V) </span>= pagamenti che costituiscono un effettiva <strong>
                        variazione</strong> dell'investimento&nbsp;
                </div>
                <br />
            </td>
        </tr>
    </table>
</asp:Content>
