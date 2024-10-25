<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.IPagamento.IstruttoriaInvestimento" CodeBehind="IstruttoriaInvestimento.aspx.cs" %>

<%@ Register Src="../../CONTROLS/IDomandaPagamento.ascx" TagName="IDomandaPagamento" TagPrefix="uc2" %>
<%@ Register Src="../../CONTROLS/ucPagamentoInvestimento.ascx" TagName="ucPagamentoInvestimento" TagPrefix="uc3" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
        
        function ctrlAmmessoLavoriInEconomia(ev) { if($('[id$=txtLECImportoAmmesso_text]').val()=='') { alert('Attenzione! Inserire l`importo ammesso per i lavori in economia.');return stopEvent(ev); } }
        function chiudiPopup() { $('[id$=hdnIdPagamentoBeneficiario]').val('');chiudiPopupTemplate(); }
        function selezionaParametro(id_sanzione,cod_tipo_parametro,valore_parametro,descrizione) { $('[id$=hdnValoreParametro'+cod_tipo_parametro+id_sanzione+']').val(valore_parametro);$('[id$=lblValoreParametro'+cod_tipo_parametro+id_sanzione+']').text("  "+descrizione);chiudiPopupTemplate(); }
        function sceltaParametroSanzione(id_sanzione,cod_tipo_sanzione,cod_tipo_parametro) {
            mostraPopupTemplate('divSelezioneParametro','divBKGMessaggio');
            $('#divValoriParametro').ajaxStart(function() { $(this).html("<img src='../../images/ajaxroller.gif' />"); })
                .ajaxError(function() { $(this).css({ "background-color": "fefeee", "color": "red", "text-align": "center" }).html("ATTENZIONE! SI E' VERIFICATO UN ERRORE NELLA RICHIESTA."); })
                .load("../../CONTROLS/ajaxRequest.aspx", { "type": "getSelezioneParametroSanzioniPagamento", "id_sanzione": id_sanzione, "cod_tipo_sanzione": cod_tipo_sanzione,
                    "cod_tipo_parametro": cod_tipo_parametro
                }).show();
            }

        
        function btnCalcolaContributoAmmesso_Click() {
            if ($('[id$=txtIPImportoAmmesso]').val() == '') { alert('Attenzione! Inserire l`importo ammesso.'); }
            else {
                var importo = $('[id$=txtIPImportoAmmesso]').val();
                var i; 
                for (i = 0; i < 3; i++)
                {
                    importo = importo.replace(".", "");
                }                
                importo = importo.replace(",", ".");
                var contributoperc = $('[id$=txtIPContributoQuota]').val();
                contributoperc = contributoperc.replace(",", ".");
                var contributo = importo * contributoperc / 100;
                contributo = contributo.toFixed(2);
                contributo = contributo.replace(".", ",");

                $('[id$=txtIPContributoAmmesso]').val(contributo);
            }
        }
        
//--></script>
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
                <tr class="TESTA1">
            <td valign="middle">
                &nbsp;Totale fondi presi da disavanzi altri investimenti nel limite del 10%:
            </td>
        </tr>
        <tr>
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
        </tr>
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
                        <td align="left" runat="server" visible="false" id="tdAmmessoFinale">
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
        <tr class="TESTA1">
            <td>
                &nbsp;Sanzioni comminate per l'investimento:
            </td>
        </tr>
        <tr>
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
        </tr>
        <tr>
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
        </tr>
        <tr id="trIntegrazioneInvestimenti" runat="server" visible="false">
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
        </tr>
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
                <Siar:Button ID="btnSalva" runat="server" CausesValidation="False" OnClick="btnSaveRichiesto_Click"
                    Text="Ammetti" Width="180px" Modifica="True" />&nbsp; &nbsp;&nbsp;
                <Siar:Button ID="btnVariazioneInvestimento" runat="server" CausesValidation="False"
                    Modifica="True" OnClick="btnVariazioneInvestimento_Click" Text="Variazione investimento"
                    Width="180px" />
<%--                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
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
                Elenco giustificativi associati (<asp:Label ID="lblNumeroPagamenti" runat="server"></asp:Label>)
            </td>
        </tr>
        <tr>
            <td>
                <br />
                <Siar:DataGrid ID="dgPagamenti" runat="server" AutoGenerateColumns="False" Width="100%"
                    NrColumnSearch="true"  ShowFooter="true">
                    <ItemStyle Height="40px" />
                    <FooterStyle CssClass="coda" HorizontalAlign="Right" />
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle HorizontalAlign="Center" Width="30px" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn>
                            <ItemStyle HorizontalAlign="left" />
                        </asp:BoundColumn>
                        <asp:BoundColumn>
                            <ItemStyle HorizontalAlign="center" Width="30px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Imponibile" DataFormatString="{0:c}" HeaderText="Imponibile">
                            <ItemStyle HorizontalAlign="right" Width="90px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ImportoRichiesto" DataFormatString="{0:c}" HeaderText="Importo">
                            <ItemStyle HorizontalAlign="right" Width="90px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Contributo">
                            <ItemStyle HorizontalAlign="right" Width="90px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn>
                            <ItemStyle CssClass="testoRosso" HorizontalAlign="Center" Width="25px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Importo" DataField="ImportoAmmesso" DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" Width="90px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Contributo" DataField="ContributoAmmesso" DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" Width="90px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn>
                            <ItemStyle HorizontalAlign="Center" Width="90px" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid><div style="width: 100%; text-align: right">
                    <span class='testoRosso'>(V) </span>= pagamenti che costituiscono un effettiva <strong>
                        variazione</strong> dell'investimento&nbsp;
                </div>
                <br />
                <div style="display: none">
                    <Siar:Hidden ID="hdnIdPagamentoBeneficiario" runat="server">
                    </Siar:Hidden>
                    <Siar:Button ID="btnPost" runat="server" CausesValidation="False" OnClick="btnPost_Click" />
                </div>
            </td>
        </tr>
    </table>
    <div id='divIstPagForm' style="width: 950px; position: absolute; display: none">
        <table width="100%" class="tableNoTab">
            <tr>
                <td class="separatore">
                    Istruttoria della spesa richiesta a pagamento:
                </td>
            </tr>
            <tr>
                <td style="padding: 10px">
                    <table width="100%">
                        <tr>
                            <td style="width: 400px" rowspan="2">
                                Oggetto di spesa:<br />
                                <Siar:TextArea ID="txtGSOggetto" runat="server" Width="360px" ReadOnly="true" Rows="4" />
                            </td>
                            <td style="width: 130px">
                                Numero giustificativo:<br />
                                <Siar:TextBox ID="txtGSNumero" runat="server" Width="100px" TextAlign="right" ReadOnly="true" />
                            </td>
                            <td>
                                Data giustificativo:<br />
                                <Siar:DateTextBox ID="txtGSData" runat="server" Width="100px" ReadOnly="true" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 130px">
                                Imponibile &euro;:<br />
                                <Siar:CurrencyBox ID="txtGSImponibile" runat="server" Width="100px" ReadOnly="true" />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="separatore_light">
                    &nbsp;Pagamento richiesto:
                </td>
            </tr>
            <tr>
                <td style="padding: 10px">
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 130px">
                                Importo &euro;:<br />
                                <Siar:CurrencyBox ID="txtIPImportoRichiesto" runat="server" Width="100px" ReadOnly="true" />
                            </td>
                            <td style="width: 130px">
                                Contributo &euro;:<br />
                                <Siar:CurrencyBox ID="txtIPContributoRichiesto" runat="server" Width="100px" ReadOnly="True" />
                            </td>
                            <td style="width: 140px; display:none;">
                                <br />
                                <input id="chkIPSpesaTecnicaRichiesta" runat="server" style="width: 24px" type="checkbox"
                                    disabled="disabled" />Spesa tecnica
                            </td>
                            <td>
                            </td>
                            <td style="display:none;">
                                <br />
                                <input id="chkIPVariazione" runat="server" style="width: 24px" type="checkbox" disabled="disabled" />Costituisce
                                effettiva <b>variazione</b> di investimento
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="separatore_light">
                    Pagamento ammesso:
                </td>
            </tr>
            <tr>
                <td style="padding: 10px">
                    <table width="100%">
                        <tr>
                            <td style="width: 400px; vertical-align: top">
                                <table width="100%">
                                    <tr>
                                        <td style="width: 130px">
                                            <br />
                                            Importo &euro;:<br />
                                            <Siar:CurrencyBox ID="txtIPImportoAmmesso" runat="server" Width="100px" Obbligatorio="True"
                                                NomeCampo="Importo ammesso" />
                                        </td>
                                        <td style="width: 130px">
                                            <br />
                                            
                                             <input id="btnCalcolaContributoAmmesso" class="ButtonGrid" style="width: 95px;" type="button"
                        -                   value="Calcola" onclick="btnCalcolaContributoAmmesso_Click();" />
                                            <%--<Siar:Button ID="btnCalcolaContributoAmmesso"  onclick="btnCalcolaContributoAmmesso_Click();"
                                            Text="Calcola" Width="90px" Modifica="true" />--%>
                                        </td>
                                        <td style="width: 130px">
                                            <br />
                                            Non ammesso &euro;:<br />
                                            <Siar:CurrencyBox ID="txtIPImportoNonAmmesso" runat="server" Width="100px" ReadOnly="True" />
                                        </td>
                                        
                                        <td style="display:none;">
                                            Importo a<br />
                                            NON responsabilità:<br />
                                            <Siar:CurrencyBox ID="txtIPImportoNonresp" runat="server" Width="100px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 130px">
                                            <br />
                                            Contributo &euro;:<br />
                                            <Siar:CurrencyBox ID="txtIPContributoAmmesso" runat="server" Width="100px" />
                                        </td>
                                        <td style="width: 130px">
                                            <br />
                                            Contributo %:<br />
                                            <Siar:QuotaBox NrDecimali="12" ID="txtIPContributoQuota" runat="server" Width="50px"  Obbligatorio="True" />
                                        </td>
                                        <td style="width: 130px">
                                            <br />
                                            Contr Non ammesso &euro;:<br />
                                            <Siar:CurrencyBox ID="txtIPContributoNonAmmesso" runat="server" Width="100px" ReadOnly="True" />
                                        </td>
                                        
                                        <td style="display:none;">
                                            Contributo a<br />
                                            NON responsabilità:<br />
                                            <Siar:CurrencyBox ID="txtIPContributoNonresp" runat="server" Width="100px" ReadOnly="True" />
                                        </td>
                                    </tr>
                                    <tr style="display:none;">
                                        <td style="width: 130px; height: 30px; ">
                                            <input id="chkIPSpesaTecnica" runat="server" style="width: 24px" type="checkbox" />Spesa
                                            tecnica
                                        </td>
                                        <td style="height: 30px">
                                        </td>
                                        <td style="height: 30px">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <table style="width: 100%;">
                                    <tr>
                                        <td class="paragrafo">
                                            Motivazioni riduzione:
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <Siar:CheckBoxList ID="chklIPMotivazioniRiduzione" runat="server" RepeatDirection="Horizontal"
                                                RepeatColumns="2" RepeatLayout="Flow">
                                            </Siar:CheckBoxList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding-top: 5px">
                                            Note aggiuntive (max 500 caratteri):<br />
                                            <Siar:TextArea ID="txtIPNoteAggiuntive" runat="server" Width="440px" Rows="4" MaxLength="500" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr style="display: none">
                <td class="paragrafo">
                    Pagamento ammesso: (AdC - Controlli in loco)
                </td>
            </tr>
            <tr style="display: none">
                <td style="padding: 10px">
                    <table width="100%">
                        <tr>
                            <td style="width: 130px">
                                <br />
                                Importo &euro;:<br />
                                <Siar:CurrencyBox ID="txtIPImportoAmmessoInLoco" runat="server" Width="100px" ReadOnly="True" />
                            </td>
                            <td style="width: 130px">
                                <br />
                                Non ammesso &euro;:<br />
                                <Siar:CurrencyBox ID="txtIPImportoNonAmmessoContr" runat="server" Width="100px" ReadOnly="True" />
                            </td>
                            <td>
                                Importo a<br />
                                NON responsabilità:<br />
                                <Siar:CurrencyBox ID="txtIPImportoNonrespInLoco" runat="server" Width="100px" ReadOnly="True" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 130px">
                                <br />
                                Contributo &euro;:<br />
                                <Siar:CurrencyBox ID="txtIPContributoAmmessoInLoco" runat="server" Width="100px"
                                    ReadOnly="True" />
                                <br />
                            </td>
                            <td style="width: 130px">
                                <br />
                                Non ammesso &euro;:<br />
                                <Siar:CurrencyBox ID="txtIPContributoNonAmmessoContr" runat="server" Width="100px"
                                    ReadOnly="True" />
                            </td>
                            <td>
                                Contributo a<br />
                                NON responsabilità:<br />
                                <Siar:CurrencyBox ID="txtIPContributoNonrespInLoco" runat="server" Width="100px"
                                    ReadOnly="True" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 130px; height: 30px;">
                                <input id="chkIPSpesaTecnicaInLoco" runat="server" style="width: 24px" type="checkbox"
                                    disabled="disabled" />Spesa tecnica
                            </td>
                            <td style="height: 30px">
                            </td>
                            <td style="height: 30px">
                            </td>
                        </tr>
                    </table>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="right" style="padding: 10px">
                    <Siar:Button ID="btnAmmettiPagamento" runat="server" OnClick="btnAmmettiPagamento_Click"
                        Text="Salva" Width="162px" Modifica="true" />
                    <input id="btnChiudi" class="Button" style="width: 105px; margin-left: 20px" type="button"
                        value="Chiudi" onclick="chiudiPopup()" />
                </td>
            </tr>
            <tr>
                <td>
                </td>
            </tr>
        </table>
    </div>
    <div id='divNuovaSanzione' style="width: 700px; position: absolute; display: none">
        <table width="100%" class="tableNoTab">
            <tr>
                <td class="separatore">
                    Elenco delle sanzioni:
                </td>
            </tr>
            <tr>
                <td class="testo_pagina">
                    Di seguito vengono elencate tutte le sanzioni che possono essere comminate all'investimento<br />
                    in esame, previste dalla programmazione di appartenenza e dal livello di applicazione
                    delle stesse.<br />
                    Selezionare uno o più elementi a seconda delle violazioni degli impegni riscontrate.
                </td>
            </tr>
            <tr>
                <td>
                    <Siar:DataGrid ID="dgNuovaSanzione" runat="server" AutoGenerateColumns="False" Width="100%">
                        <Columns>
                            <Siar:NumberColumn HeaderText="Nr.">
                                <ItemStyle HorizontalAlign="Center" Width="30px" />
                            </Siar:NumberColumn>
                            <asp:BoundColumn DataField="Titolo" HeaderText="Descrizione"></asp:BoundColumn>
                            <asp:BoundColumn DataField="Livello" HeaderText="Livello applicazione" DataFormatString="{0:D=Domanda|O=Investimento}">
                                <ItemStyle Width="120px" HorizontalAlign="center" />
                            </asp:BoundColumn>
                            <Siar:CheckColumn DataField="CodTipo" Name="chkNuovaSanzione">
                                <ItemStyle Width="80px" HorizontalAlign="center" />
                            </Siar:CheckColumn>
                        </Columns>
                    </Siar:DataGrid>
                </td>
            </tr>
            <tr>
                <td align="right" style="height: 50px; padding-right: 40px">
                    <Siar:Button ID="btnAssegnaSanzioni" runat="server" OnClick="btnAssegnaSanzioni_Click"
                        Text="Assegna sanzioni" Width="181px" Modifica="true" CausesValidation="False" />
                    <input id="btnChiudiSanzione" class="Button" style="width: 105px; margin-left: 20px"
                        type="button" value="Chiudi" onclick="chiudiPopupTemplate();" />
                </td>
            </tr>
        </table>
    </div>
    <div id='divSelezioneParametro' style="width: 700px; position: absolute; display: none">
        <table width="100%" class="tableNoTab">
            <tr>
                <td class="separatore">
                    Scelta dei valori del parametro:
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;<div id='divValoriParametro' style="width: 100%">
                    </div>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="right" style="height: 49px">
                    <input id="Button2" class="Button" style="width: 105px" type="button" value="Chiudi"
                        onclick="chiudiPopupTemplate()" />
                    &nbsp; &nbsp; &nbsp;
                </td>
            </tr>
        </table>
    </div>
    <div id="divLavoriInEconomia" style="width: 900px; position: absolute; display: none">
        <table class="tableNoTab" width="100%">
            <tr>
                <td class="separatore">
                    Dettaglio del lavoro in economia:
                </td>
            </tr>
            <tr>
                <td class="testo_pagina">
                    Specificare l'<b>importo in euro</b> e la <b>descrizione</b> dei lavori effettuati
                    in tale modalità. E' possibile rendicontare importi fino, e non oltre,
                    <br />
                    ad un ammontare calcolato come la <b>differenza tra il computo metrico e contributo
                        totale</b> attribuito <b>( E = M - T )</b>.
                </td>
            </tr>
            <tr>
                <td style="padding: 10px">
                    <table width="100%">
                        <tr>
                            <td style="width: 200px">
                                <table width="100%">
                                    <tr>
                                        <td>
                                            Importo &euro;:<br />
                                            <Siar:CurrencyBox ID="txtLECImportoRichiesto" runat="server" Width="120px" ReadOnly="true" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Contributo &euro;:<br />
                                            <Siar:CurrencyBox ID="txtLECContributoRichiesto" runat="server" Width="120px" ReadOnly="true" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table width="100%">
                                                <tr>
                                                    <td style="height: 38px; width: 24px">
                                                        <input id="chkLECVariazioneInvestimento" runat="server" type="checkbox" disabled="disabled" />
                                                    </td>
                                                    <td style="height: 38px">
                                                        lavoro costituente effettiva <b>variazione</b> dell'investimento
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td style="vertical-align: top">
                                Descrizione:<br />
                                <Siar:TextArea ID="txtLECDescrizione" runat="server" Rows="6" Width="610px" ReadOnly="true" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="paragrafo">
                    Pagamento ammesso:
                </td>
            </tr>
            <tr>
                <td style="padding: 10px">
                    <table width="100%">
                        <tr>
                            <td style="width: 200px; vertical-align: top">
                                <table width="100%">
                                    <tr>
                                        <td>
                                            Importo &euro;:<br />
                                            <Siar:CurrencyBox ID="txtLECImportoAmmesso" runat="server" Width="120px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Contributo &euro;:<br />
                                            <Siar:CurrencyBox ID="txtLECContributoAmmesso" runat="server" Width="120px" ReadOnly="true" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <table width="100%">
                                    <tr>
                                        <td class="paragrafo">
                                            Motivazioni della riduzione:
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 4px">
                                            <Siar:CheckBoxList ID="chklLECMotivazioniRiduzione" runat="server" RepeatColumns="3"
                                                RepeatDirection="Horizontal" RepeatLayout="Flow">
                                            </Siar:CheckBoxList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Note aggiuntive:<br />
                                            <Siar:TextArea ID="txtLECNoteAggiuntive" runat="server" Rows="6" Width="610px" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="right" style="height: 70px">
                    <Siar:Button ID="btnSalvaLavoriInEconomia" runat="server" Modifica="true" OnClick="btnSalvaLavoriInEconomia_Click"
                        Text="Salva" Width="130px" CausesValidation="False" OnClientClick="return ctrlAmmessoLavoriInEconomia(event);" />
                    <input class="Button" onclick="chiudiPopup()" style="width: 100px; margin-left: 20px;
                        margin-right: 20px" type="button" value="Chiudi" />
                </td>
            </tr>
        </table>
    </div>
    <uc3:ucPagamentoInvestimento ID="modalePagamento" runat="server" />
    </div>
</asp:Content>
