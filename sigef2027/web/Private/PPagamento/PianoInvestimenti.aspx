<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true" Inherits="web.Private.PPagamento.PianoInvestimenti" CodeBehind="PianoInvestimenti.aspx.cs" %>

<%@ Register Src="~/CONTROLS/SiarNewToolTip.ascx" TagName="SiarNewToolTip" TagPrefix="uc2" %>
<%@ Register Src="~/CONTROLS/WorkflowPagamento.ascx" TagName="WorkflowPagamento" TagPrefix="uc1" %>
<%@ Register Src="~/CONTROLS/PianoInvestimentiAggregazioneDomanda.ascx" TagName="PianoInvestimentiAggregazioneDomanda" TagPrefix="uc3" %>
<%@ Register Src="~/CONTROLS/PianoInvestimentiCodificaDomanda.ascx" TagName="PianoInvestimentiCodificaDomanda" TagPrefix="uc4" %>
<%@ Register Src="~/CONTROLS/PianoInvestimentiInterventoDomanda.ascx" TagName="PianoInvestimentiInterventoDomanda" TagPrefix="uc5" %>
<%@ Register Src="~/CONTROLS/CardPagamento.ascx" TagName="CardPagamento" TagPrefix="uc6" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <style type="text/css">
        .positivo {
            color: green;
        }

        .negativo {
            color: red;
        }
    </style>

    <script type="text/javascript"><!--
    function visualizzaIntegrazioneSingola(id) {
        $('[id$=hdnIdIntegrazioneSingolaSelezionata]').val($('[id$=hdnIdIntegrazioneSingolaSelezionata]').val() == id ? '' : id);
        $('[id$=btnPost]').click();
    }

    $(document).ready(function () {
        let $el = $('.steppers-nav').clone();
        $('#containerCopiaPulsanti').append($el);
    });


//--></script>
    <uc6:CardPagamento ID="ucCardPagamento" runat="server" />
    <div class="row pt-5">
        <div class="col-sm-12">
            <div class="steppers">
                <uc1:WorkflowPagamento ID="ucWorkflowPagamento" runat="server" />
            </div>
            <div class="steppers-content" aria-live="polite">
                <div style="display: none">
                    <asp:Button ID="btnPost" runat="server" OnClick="btnPost_Click" />
                    <asp:HiddenField ID="hdnIdIntegrazioneSingolaSelezionata" runat="server" />
                </div>
                <div class="row py-5 mx-2" id="tbElenco" runat="server">
                    <h3 class="pb-5">Piano degli investimenti</h3>
                    <p>
                        Di seguito vengono elencati tutti gli investimenti previsti dalla domanda di aiuto nella sua versione più recente, ovvero comprensiva di <b>varianti/variazioni finanziarie</b>. Per richiedere il pagamento delle spese sostenute per uno specifico investimento fare click sulla riga relativa. 
                    </p>
                    <div class="col-sm-12">
                        <p>N.B.: se il piano degli investimenti risultasse grande l'estrazione potrebbe richiedere alcuni minuti.</p>
                        <Siar:Button ID="btnEstrai" runat="server" Text="Estrai in XLS" OnClick="btnEstrai_Click" />
                    </div>
                    <div class="row" id="tbAmmissibilitaRendicontazione" runat="server">
                        <h4>Verifica ammissibilità rendicontazione:</h4>
                        <p>Ai fini della validità del controllo accertarsi di aver completato la rendicontazione richiesta.</p>
                        <div class="col-sm-12 text-center">
                            <input class="btn btn-primary py-1" type="button" value="Prosegui &gt;&gt;"
                                onclick="location = 'VerificaFinaleRendicontazione.aspx'" />
                        </div>
                    </div>
                    <div class="row mt-2">
                        <div class="col-sm-12">
                            <div class="accordion" id="collapseExample">
                                <div class="accordion-item">
                                    <h2 class="accordion-header " id="heading3c">
                                        <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapse3c" aria-expanded="false" aria-controls="collapse3c">
                                            Dati complessivi per l'intera domanda di contributo
                                        </button>
                                    </h2>
                                    <div id="collapse3c" class="accordion-collapse collapse" role="region" aria-labelledby="heading3c">
                                        <div class="accordion-body">
                                            <div class="row bd-form pt-5">
                                                <div class="col-sm-3 form-group form-riepilogo">
                                                    <Siar:CurrencyBox Label="Spesa totale ammessa" ID="txtTotaleInvestimenti" runat="server" ReadOnly="True" />
                                                </div>
                                                <div class="col-sm-3 form-group form-riepilogo">
                                                    <Siar:CurrencyBox Label="Contributo totale ammesso" ID="txtTotaleContributo" runat="server" ReadOnly="True" />
                                                </div>
                                                <div class="col-sm-3 form-group form-riepilogo">
                                                    <Siar:CurrencyBox Label="Contributo erogato fino ad ora complessivo di tutte le domande di pagamento approvate:" ID="txtErogato" runat="server" ReadOnly="True" />
                                                    <Siar:QuotaBox Visible="false" ID="txtErogatoQuota" runat="server" ReadOnly="True" />
                                                </div>
                                                <div class="col-sm-3">
                                                    <Siar:Button ID="btnDettaglioMisura" runat="server" CausesValidation="False" OnClick="btnDettaglioMisura_Click"
                                                        Text="Dettagli di misura" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="accordion-item">
                                    <h2 class="accordion-header " id="heading1c">
                                        <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapse1c" aria-expanded="false" aria-controls="collapse1c">
                                            Dati della spesa dell'attuale domanda di pagamento
                                        </button>
                                    </h2>
                                    <div id="collapse1c" class="accordion-collapse collapse" role="region" aria-labelledby="heading1c">
                                        <div class="accordion-body">
                                            <div class="row bd-form pt-5">
                                                <div class="col-sm-6 form-group form-riepilogo">
                                                    <Siar:CurrencyBox Label="Spesa rendicontata (€):" ID="txtTotaleImportoRichiesto" runat="server" ReadOnly="True" />
                                                </div>
                                                <div class="col-sm-6 form-group form-riepilogo">
                                                    <Siar:QuotaBox Label="% della spesa rendicontata sul totale dichiarato" ID="txtQuotaImportoRichiesta" runat="server" ReadOnly="True" />
                                                </div>
                                                <div class="col-sm-6 form-group form-riepilogo">
                                                    <Siar:CurrencyBox Label="Spesa ammessa (€)" ID="txtTotaleImportoAmmesso" runat="server" ReadOnly="True" />
                                                </div>
                                                <div class="col-sm-6 form-group form-riepilogo">
                                                    <Siar:QuotaBox Label="% della spesa ammessa sul totale dichiarato" ID="txtQuotaImportoAmmessa" runat="server" ReadOnly="True" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="accordion-item">
                                    <h2 class="accordion-header " id="heading2c">
                                        <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapse2c" aria-expanded="false" aria-controls="collapse2c">
                                            Dati del contributo dell'attuale domanda di pagamento
                                        </button>
                                    </h2>
                                    <div id="collapse2c" class="accordion-collapse collapse" role="region" aria-labelledby="heading2c">
                                        <div class="accordion-body">
                                            <div class="row bd-form pt-5">
                                                <div class="col-sm-6 form-group form-riepilogo">
                                                    <Siar:CurrencyBox Label="Contributo da spesa rendicontata (€)" ID="txtTotaleContributoRichiesto" runat="server" ReadOnly="True" />
                                                </div>
                                                <div class="col-sm-6 form-group form-riepilogo">
                                                    <Siar:QuotaBox Label="% del contributo sul totale dichiarato" ID="txtQuotaContributoRichiesta" runat="server" ReadOnly="True" />
                                                </div>
                                                <div class="col-sm-6 form-group form-riepilogo">
                                                    <Siar:CurrencyBox Label="Contributo ammesso (€)" ID="txtTotaleContributoAmmissibile" runat="server" ReadOnly="True" />
                                                </div>
                                                <div class="col-sm-6 form-group form-riepilogo">
                                                    <Siar:QuotaBox Label="% del contributo ammesso sul totale dichiarato" ID="txtQuotaContributoAmmessa" runat="server" ReadOnly="True" />
                                                </div>
                                                <div class="col-sm-12 form-group form-riepilogo">
                                                    <Siar:CurrencyBox ID="txtImportoSanzione" runat="server" ReadOnly="True" Visible="false" />
                                                    <Siar:CurrencyBox Label="Recupero sull'anticipo" ID="txtRecuperoAnticipo" runat="server" ReadOnly="True" />
                                                </div>
                                                <div class="col-sm-12 form-group form-riepilogo">
                                                    <Siar:CurrencyBox Label="Contributo ammesso al netto del recupero anticipo" ID="txtTotaleContributoAmmesso" runat="server" ReadOnly="True" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <h4 class="py-5">Investimenti ammessi a finanziamento:</h4>
                    <div class="row mt-2">
                        <div class="col-sm-12">
                            <div class="accordion accordion-background-active" id="collapseRaggruppamenti">
                                <div class="accordion-item">
                                    <h2 class="accordion-header " id="headingInvestimenti">
                                        <button class="accordion-button rounded-2" type="button" data-bs-toggle="collapse" data-bs-target="#collapseInvestimenti" aria-expanded="true" aria-controls="collapseInvestimenti">
                                            Investimenti ammessi a finanziamento:
                                        </button>
                                    </h2>
                                    <div id="collapseInvestimenti" class="accordion-collapse collapse show" data-bs-parent="#accordionExampleHa" role="region" aria-labelledby="headingInvestimenti">
                                        <div class="accordion-body">
                                            <div class="col-sm-12">
                                                <Siar:DataGridAgid ID="dgInvestimenti" runat="server" AutoGenerateColumns="False" PageSize="20" CssClass="table table-striped">
                                                    <Columns>
                                                        <Siar:NumberColumn HeaderText="Nr.">
                                                            <FooterStyle HorizontalAlign="center" />
                                                        </Siar:NumberColumn>

                                                        <asp:BoundColumn DataField="Misura" HeaderText="Misura"></asp:BoundColumn>

                                                        <asp:BoundColumn HeaderText="Descrizione"></asp:BoundColumn>

                                                        <Siar:ColonnaLink DataField="SettoreProduttivo" HeaderText="" IsJavascript="false"
                                                            LinkFields="IdInvestimento" LinkFormat="PagamentoInvestimento.aspx?idinv={0}">
                                                            <ItemStyle Width="1px" HorizontalAlign="center" />
                                                        </Siar:ColonnaLink>

                                                        <asp:BoundColumn HeaderText="Costo totale investimento" DataFormatString="{0:c}">
                                                            <FooterStyle HorizontalAlign="right" />
                                                            <ItemStyle HorizontalAlign="right" />
                                                        </asp:BoundColumn>

                                                        <asp:BoundColumn HeaderText="Contributo ammesso" DataField="ContributoRichiesto" DataFormatString="{0:c}">
                                                            <FooterStyle HorizontalAlign="right" />
                                                            <ItemStyle HorizontalAlign="right" />
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn DataField="QuotaContributoRichiesto" HeaderText="% Quota contributo ammesso">
                                                            <FooterStyle HorizontalAlign="right" />
                                                            <ItemStyle HorizontalAlign="right" />
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn HeaderText="Importo pagamento richiesto" DataFormatString="{0:c}">
                                                            <FooterStyle HorizontalAlign="right" />
                                                            <ItemStyle HorizontalAlign="right" />
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn HeaderText="Contributo pagamento richiesto" DataFormatString="{0:c}">
                                                            <FooterStyle HorizontalAlign="right" />
                                                            <ItemStyle HorizontalAlign="right" />
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn HeaderText="Contributo pagamento ammissibile" DataFormatString="{0:c}">
                                                            <FooterStyle HorizontalAlign="right" />
                                                            <ItemStyle HorizontalAlign="right" />
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn HeaderText="% rendicon- tazione">
                                                            <ItemStyle HorizontalAlign="right" />
                                                        </asp:BoundColumn>
                                                        <Siar:JsButtonColumn Arguments="IdInvestimento" ButtonType="ImageButton" ButtonText="Richiesta integrazione"
                                                            JsFunction="" HeaderText="Richiesta integrazione" ButtonImage="warning.png">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </Siar:JsButtonColumn>
                                                    </Columns>
                                                </Siar:DataGridAgid>
                                                <table width="100%" id="tbLegendaInvestimenti" runat="server" visible="false">
                                                    <tr>
                                                        <td style="width: 400px">(*) = investimenti <b>NON</b> cofinanziati
                                                        </td>
                                                        <td>(**) = contributo troncato per superamento <b>massimali</b> di domanda
                                                        </td>
                                                        <td align="right">(***) = bando a <b>quota fissa</b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding-bottom: 20px; width: 400px;">la stella
                                                        <img id="imgRedStar" runat="server" />
                                                            evidenzia gli <b>investimenti prioritari</b> di settore
                                                        </td>
                                                        <td style="padding-bottom: 20px;" align="right">per la legenda completa cliccare
                                                        <uc2:SiarNewToolTip ID="SiarNewToolTip1" runat="server" Codice="legenda_pianoinvestimenti" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <uc3:PianoInvestimentiAggregazioneDomanda ID="PianoInvestimentiAggregazioneDomanda" runat="server" />
                                <uc4:PianoInvestimentiCodificaDomanda ID="PianoInvestimentiCodificaDomanda" runat="server" />
                                <uc5:PianoInvestimentiInterventoDomanda ID="PianoInvestimentiInterventoDomanda" runat="server" />
                            </div>
                        </div>
                        <%--<table id="tableBrevetti" width="100%" runat="server" visible="false">
                        <tr>
                            <td class="separatore">Brevetti &amp; licenze:
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-bottom: 20px">
                                <Siar:DataGrid ID="dgBrevetti" runat="server" AutoGenerateColumns="False" PageSize="20" Width="100%">
                                    <ItemStyle Height="30px" />
                                    <Columns>
                                        <asp:BoundColumn DataField="Misura" HeaderText="Programmazione">
                                            <ItemStyle HorizontalAlign="center" Width="130px" />
                                        </asp:BoundColumn>
                                        <Siar:ColonnaLink DataField="Descrizione" HeaderText="Descrizione tecnica" IsJavascript="false"
                                            LinkFields="IdInvestimento" LinkFormat="PagamentoInvestimento.aspx?idinv={0}">
                                        </Siar:ColonnaLink>
                                        <asp:BoundColumn DataField="CostoInvestimento" HeaderText="Ammontare spese" DataFormatString="{0:c}">
                                            <ItemStyle HorizontalAlign="right" Width="120px" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="Contributo ammesso" DataField="ContributoRichiesto"
                                            DataFormatString="{0:c}">
                                            <ItemStyle HorizontalAlign="right" Width="120px" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="QuotaContributoRichiesto" HeaderText="% Quota contributo ammesso">
                                            <ItemStyle HorizontalAlign="right" Width="120px" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="Importo pagamento richiesto" DataFormatString="{0:c}">
                                            <FooterStyle HorizontalAlign="right" Width="100px" />
                                            <ItemStyle HorizontalAlign="right" Width="100px" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="Contributo pagamento richiesto" DataFormatString="{0:c}">
                                            <FooterStyle HorizontalAlign="right" Width="100px" />
                                            <ItemStyle HorizontalAlign="right" Width="100px" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="Contributo pagamento ammissibile" DataFormatString="{0:c}">
                                            <FooterStyle HorizontalAlign="right" Width="100px" />
                                            <ItemStyle HorizontalAlign="right" Width="100px" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="% rendicon- tazione">
                                            <ItemStyle Font-Bold="true" Font-Size="12px" HorizontalAlign="right" Width="70px" />
                                        </asp:BoundColumn>
                                    </Columns>
                                </Siar:DataGrid>
                            </td>
                        </tr>
                    </table>
                    <table id="tableMutuo" runat="server" width="100%" visible="false">
                        <tr>
                            <td class="separatore">Dettagli del mutuo:
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-bottom: 20px">
                                <Siar:DataGrid ID="dgMutuo" runat="server" AutoGenerateColumns="False" PageSize="20"
                                    Width="100%">
                                    <ItemStyle Height="30px" />
                                    <Columns>
                                        <asp:BoundColumn DataField="Misura" HeaderText="Programmazione">
                                            <ItemStyle HorizontalAlign="center" Width="90px" />
                                        </asp:BoundColumn>
                                        <Siar:ColonnaLink DataField="Descrizione" HeaderText="Descrizione tecnica" IsJavascript="false"
                                            LinkFields="IdInvestimento" LinkFormat="PagamentoInvestimento.aspx?idinv={0}">
                                        </Siar:ColonnaLink>
                                        <asp:BoundColumn DataField="SpeseGenerali" HeaderText="Ammontare degli investimenti per cui si richiede il mutuo"
                                            DataFormatString="{0:c}">
                                            <ItemStyle HorizontalAlign="right" Width="120px" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="CostoInvestimento" HeaderText="Ammontare del mutuo" DataFormatString="{0:c}">
                                            <ItemStyle HorizontalAlign="right" Width="120px" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="Contributo ammesso" DataField="ContributoRichiesto"
                                            DataFormatString="{0:c}">
                                            <ItemStyle HorizontalAlign="right" Width="100px" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="Importo pagamento richiesto" DataFormatString="{0:c}">
                                            <FooterStyle HorizontalAlign="right" Width="100px" />
                                            <ItemStyle HorizontalAlign="right" Width="100px" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="Contributo pagamento richiesto" DataFormatString="{0:c}">
                                            <FooterStyle HorizontalAlign="right" Width="100px" />
                                            <ItemStyle HorizontalAlign="right" Width="100px" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="Contributo pagamento ammissibile" DataFormatString="{0:c}">
                                            <FooterStyle HorizontalAlign="right" Width="100px" />
                                            <ItemStyle HorizontalAlign="right" Width="100px" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="% rendicon- tazione">
                                            <ItemStyle Font-Bold="true" Font-Size="12px" HorizontalAlign="right" Width="70px" />
                                        </asp:BoundColumn>
                                    </Columns>
                                </Siar:DataGrid>
                            </td>
                        </tr>
                    </table>
                    <table id="tableFidejussione" width="100%" runat="server" visible="false">
                        <tr>
                            <td class="separatore">Polizza fidejussoria:
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-bottom: 20px">
                                <Siar:DataGrid ID="dgFidejussione" runat="server" AutoGenerateColumns="False" Width="100%">
                                    <ItemStyle Height="30px" />
                                    <Columns>
                                        <asp:BoundColumn DataField="Misura" HeaderText="Programmazione">
                                            <ItemStyle HorizontalAlign="center" Width="90px" />
                                        </asp:BoundColumn>
                                        <Siar:ColonnaLink DataField="Descrizione" HeaderText="Descrizione tecnica" IsJavascript="false"
                                            LinkFields="IdInvestimento" LinkFormat="PagamentoInvestimento.aspx?idinv={0}">
                                        </Siar:ColonnaLink>
                                        <asp:BoundColumn DataField="CostoInvestimento" HeaderText="Ammontare spese" DataFormatString="{0:c}">
                                            <ItemStyle HorizontalAlign="right" Width="120px" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="Contributo ammesso" DataField="ContributoRichiesto"
                                            DataFormatString="{0:c}">
                                            <ItemStyle HorizontalAlign="right" Width="120px" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="QuotaContributoRichiesto" HeaderText="% Quota contributo ammesso">
                                            <ItemStyle HorizontalAlign="right" Width="120px" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="Importo pagamento richiesto" DataFormatString="{0:c}">
                                            <FooterStyle HorizontalAlign="right" Width="100px" />
                                            <ItemStyle HorizontalAlign="right" Width="100px" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="Contributo pagamento richiesto" DataFormatString="{0:c}">
                                            <FooterStyle HorizontalAlign="right" Width="100px" />
                                            <ItemStyle HorizontalAlign="right" Width="100px" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="Contributo pagamento ammissibile" DataFormatString="{0:c}">
                                            <FooterStyle HorizontalAlign="right" Width="100px" />
                                            <ItemStyle HorizontalAlign="right" Width="100px" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="% rendicon- tazione">
                                            <ItemStyle Font-Bold="true" Font-Size="12px" HorizontalAlign="right" Width="70px" />
                                        </asp:BoundColumn>
                                    </Columns>
                                </Siar:DataGrid>
                            </td>
                        </tr>
                    </table>
                    <table id="tablePremio" runat="server" width="100%" visible="false">
                        <tr>
                            <td class="separatore">Premio in conto capitale:
                            </td>
                        </tr>
                        <tr>
                            <td style="padding: 10px">
                                <table width="100%">
                                    <tr>
                                        <td style="width: 220px">Programmazione:<br />
                                            <Siar:TextBox  ID="txtPCCProgrammazione" runat="server" ReadOnly="True" Width="190px" />
                                        </td>
                                        <td style="width: 150px">Ammontare raggiunto €:<br />
                                            <Siar:CurrencyBox ID="txtPCCAmmontare" runat="server" Width="130px" ReadOnly="True" />
                                        </td>
                                        <td style="width: 150px">Anticipo percepito €:<br />
                                            <Siar:CurrencyBox ID="txtPCCAnticipo" runat="server" Width="130px" ReadOnly="True" />
                                        </td>
                                        <td>Ammontare rimanente €:<br />
                                            <Siar:CurrencyBox ID="txtPCCRimanente" runat="server" Width="130px" ReadOnly="True" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>--%>
                        <div class="row mt-2" id="trIntegrazioniRichieste" runat="server" visible="false">
                            <h4 class="py-5">Elenco integrazioni da risolvere:</h4>
                            <div class="col-sm-12">
                                <Siar:Button ID="btnAllegati" runat="server" OnClick="btnAllegati_Click" Text="Allegati" />
                                <Siar:Button ID="btnSpese" runat="server" OnClick="btnSpese_Click" Text="Spese sostenute" />
                                <Siar:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Indietro" />
                            </div>
                            <div class="col-sm-12">
                                <Siar:DataGrid ID="dgIntegrazioni" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                    PageSize="15" CssClass="table table-striped" ShowFooter="true">
                                    <FooterStyle CssClass="coda" HorizontalAlign="Right" />
                                    <Columns>
                                        <asp:BoundColumn DataField="IdSingolaIntegrazione" HeaderText="ID singola integrazione">
                                            <ItemStyle Font-Bold="True" Font-Size="Small" HorizontalAlign="Center" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="DataRichiestaIntegrazioneIstruttore" HeaderText="Data richiesta">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="DescrizioneTipoIntegrazione" HeaderText="Tipo integrazione">
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="NoteIntegrazioneIstruttore" HeaderText="Note istruttore">
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="SingolaIntegrazioneCompletataIstruttore" HeaderText="Completata istruttore">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="DataRilascioIntegrazioneBeneficiario" HeaderText="Data rilascio beneficiario">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="NoteIntegrazioneBeneficiario" HeaderText="Note beneficiario">
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="SingolaIntegrazioneCompletataBeneficiario" HeaderText="Completata beneficiario">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundColumn>
                                        <Siar:JsButtonColumn Arguments="IdSingolaIntegrazione" ButtonType="TextButton" ButtonText="Apri" JsFunction="visualizzaIntegrazioneSingola" HeaderText="Apri">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </Siar:JsButtonColumn>
                                    </Columns>
                                </Siar:DataGrid>
                            </div>
                        </div>
                        <div class="row mt-2" id="trDettaglioIntegrazioneSingolaSelezionata" runat="server" visible="false">
                            <h4 class="py-5">Dettaglio singola integrazione selezionata:</h4>
                            <h5 class="py-5">Dati di competenza dell'istruttore:</h5>
                            <div class="form-group col-sm-12">
                                <Siar:DateTextBox Label="Data richiesta:" ID="txtDataRichiesta" runat="server" Width="120px" ReadOnly="true" />
                            </div>
                            <div class="form-group col-sm-12">
                                <Siar:TextBox  Label="Tipo integrazione:" ID="txtTipoIntegrazione" runat="server" Width="180px" ReadOnly="true" />
                            </div>
                            <div class="form-group col-sm-12">
                                <label for="<% =comboCompletataSingolaIntegrazioneDomandaIstruttore.ClientID %>">Integrazione completata:</label>
                                <asp:DropDownList ID="comboCompletataSingolaIntegrazioneDomandaIstruttore" runat="server"
                                    Enabled="False">
                                    <asp:ListItem Text="No" Value="false"></asp:ListItem>
                                    <asp:ListItem Text="Si" Value="true"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group col-sm-12">
                                <Siar:TextArea Label="Note integrazione:" ID="txtNoteSingolaIntegrazioneIstruttore" runat="server" NomeCampo="Note singola integrazione"
                                    Obbligatorio="false" Width="600px" Rows="4" ExpandableRows="5" ReadOnly="true" MaxLength="10000" />
                            </div>
                            <h5 class="py-5">Dati di competenza del beneficiario:</h5>

                            <div class="form-group col-sm-12">
                                <Siar:DateTextBox Label="Data rilascio:" ID="txtDataRilascio" runat="server" Width="120px" />
                            </div>
                            <div class="form-group col-sm-12">

                                <label for="<% =comboCompletataSingolaIntegrazioneDomandaBeneficiario.ClientID %>">Integrazione completata beneficiario:</label>
                                <asp:DropDownList ID="comboCompletataSingolaIntegrazioneDomandaBeneficiario" runat="server">
                                    <asp:ListItem Text="No" Value="false"></asp:ListItem>
                                    <asp:ListItem Text="Si" Value="true"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group col-sm-12">

                                <Siar:TextArea Label="Note beneficiario:" ID="txtNoteSingolaIntegrazioneBeneficiario" runat="server" NomeCampo="Note singola integrazione beneficiario"
                                    Obbligatorio="false" Width="600px" Rows="4" ExpandableRows="5" MaxLength="10000" />
                            </div>
                            <div class="col-sm-12">
                                <Siar:Button ID="btnSalvaSingolaIntegrazione" runat="server" OnClick="btnSalvaSingolaIntegrazione_Click"
                                    Text="Salva dati singola integrazione" Width="190px" />

                            </div>
                        </div>
                    </div>
                    <div id='divIstPagForm' class="row mt-2" style="position: absolute; display: none">
                        <h4 class="py-5">Importi totali della domanda di pagamento dettagliati per misura:</h4>
                        <div class="col-sm-12">
                            <Siar:DataGridAgid ID="dgDettaglioMisura" runat="server" AutoGenerateColumns="False" CssClass="table table-striped">
                                <Columns>
                                    <asp:BoundColumn HeaderText="Programmazione" DataField="Misura">
                                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="12px" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText=" " DataFormatString="{0:c}" DataField="CostoTotaleProgettoCorrelato">
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="(A) Contributo totale" DataFormatString="{0:c}" DataField="ContributoTotaleProgettoCorrelato">
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Importo richiesto" DataFormatString="{0:c}" DataField="ImportoRichiesto">
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="(B) Contributo richiesto" DataFormatString="{0:c}" DataField="ContributoRichiesto">
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="% su totale (B/A)" DataFormatString="{0:n}">
                                        <ItemStyle HorizontalAlign="Right" Font-Bold="true" Font-Size="12px" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Contributo ammissibile" DataFormatString="{0:c}" DataField="ContributoAmmissibile">
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Totale sanzioni" DataFormatString="{0:c}" DataField="AmmontareSanzione">
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Recupero anticipo" DataFormatString="{0:c}" DataField="RecuperoAnticipo">
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Contributo ammesso" DataFormatString="{0:c}" DataField="ContributoAmmesso">
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundColumn>
                                </Columns>
                            </Siar:DataGridAgid>
                            <table width="100%">
                                <tr>
                                    <td style="width: 20px" align="right">(
                                    </td>
                                    <td style="width: 10px; background-color: #ccccb3"></td>
                                    <td>= misure per cui non è stato richiesto il pagamento)
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="col-sm-12">
                            <input id="btnChiudi" class="btn btn-secondary py-5" type="button" value="Chiudi" onclick="chiudiPopupTemplate()" />
                        </div>
                    </div>
                </div>
                <div id="containerCopiaPulsanti" class="row py-5 steppers">
                </div>
            </div>
        </div>
    </div>
</asp:Content>
