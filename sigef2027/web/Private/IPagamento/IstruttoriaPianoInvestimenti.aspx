<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    Inherits="web.Private.IPagamento.IstruttoriaPianoInvestimenti" CodeBehind="IstruttoriaPianoInvestimenti.aspx.cs" %>

<%@ Register Src="../../CONTROLS/IDomandaPagamento.ascx" TagName="IDomandaPagamento" TagPrefix="uc2" %>
<%@ Register Src="../../CONTROLS/SiarNewToolTip.ascx" TagName="SiarNewToolTip" TagPrefix="uc3" %>

<%@ Register Src="~/CONTROLS/PianoInvestimentiAggregazioneDomandaIstruttoria.ascx" TagName="PianoInvestimentiAggregazioneDomandaIstruttoria" TagPrefix="uc4" %>
<%@ Register Src="~/CONTROLS/PianoInvestimentiCodificaDomandaIstruttoria.ascx" TagName="PianoInvestimentiCodificaDomandaIstruttoria" TagPrefix="uc5" %>
<%@ Register Src="~/CONTROLS/ucVisure.ascx" TagName="ucVisure" TagPrefix="uc6" %>
<%@ Register Src="~/CONTROLS/PianoInvestimentiInterventoDomandaIstruttoria.ascx" TagName="PianoInvestimentiInterventoDomandaIstruttoria" TagPrefix="uc7" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <script type="text/javascript"><!--
    function selezionaIntegrazioneSingola(id, elem) {
        if (elem.checked == false) {
            $('[id$=hdnIdIntegrazioneSingolaSelezionata]').val('');
        }
        else {
            $('[id$=hdnIdIntegrazioneSingolaSelezionata]').val(id);
        }

        $('[id$=btnPost]').click();
    }
    //nascosta.val("true");
    //} else {
    //        divModale[0].style.width = "40%";
    //    divModale.css({
    //        'left': scrollLeft + ((clientWidth - divModale[0].offsetWidth) / 2),

    //});

    //nascosta.val("false");

//--></script>
    <uc2:IDomandaPagamento ID="ucIDomandaPagamento" runat="server" />
    <div class="row pt-5">
        <div class="col-sm-12 text-end">
            <a id="btnBack" runat="server" class="btn btn-secondary py-1" onclick="location = 'CheckListPagamento.aspx'">
                <svg class="icon icon-breadcrumb icon-secondary icon-white me-1" aria-hidden="true">
                    <use href="/web/bootstrap-italia/svg/sprites.svg#it-check"></use>
                </svg>
                Torna alla checklist di istruttoria</a>
        </div>
        <div class="row py-5">
            <h3 class="pb-5">Istruttoria del piano degli investimenti</h3>
            <p>
                Di seguito vengono elencati tutti gli investimenti previsti dalla domanda di aiuto nella sua versione più recente, ovvero comprensiva di <b>varianti/variazioni finanziarie</b>. Per istruire i pagamenti delle spese sostenute per uno specifico investimento fare click sulla riga relativa.
            </p>
            <div class="col-sm-12">
                <Siar:Button ID="btnEstrai" runat="server" Text="Estrai in XLS" OnClick="btnEstrai_Click" />
                <Siar:Button ID="btnModificaRecuperoAnticipo" runat="server" Text="Modifica recupero anticipo"
                    OnClick="btnModificaRecuperoAnticipo_Click" />
                <input id="btnAccorpamentoInvestimenti" runat="server" class="btn btn-secondary py-1" type="button" value="Accorpamento investimenti" title="Solo il Responsabile del bando può accorpare gli investimenti."
                    onclick="location = 'IstruttoriaPianoInvestimentiAccorpamentoInvestimenti.aspx'" />
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
                                            <Siar:QuotaBox Visible="false" ID="txtErogatoQuota" runat="server" NrDecimali="12" ReadOnly="True" />
                                        </div>
                                        <div class="col-sm-3 form-group form-riepilogo">
                                            <Siar:CurrencyBox ID="txtErogatoDisavanzo" Label="Contributo da adeguamento 10%:" runat="server" ReadOnly="True" />
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
                                            <Siar:QuotaBox Label="% della spesa rendicontata sul totale dichiarato" ID="txtQuotaImportoRichiesta" runat="server" NrDecimali="12" ReadOnly="True" />
                                        </div>
                                        <div class="col-sm-6 form-group form-riepilogo">
                                            <Siar:CurrencyBox Label="Spesa ammessa (€)" ID="txtTotaleImportoAmmesso" runat="server" ReadOnly="True" />
                                        </div>
                                        <div class="col-sm-6 form-group form-riepilogo">
                                            <Siar:QuotaBox Label="% della spesa ammessa sul totale dichiarato" ID="txtQuotaImportoAmmessa" runat="server" NrDecimali="12" ReadOnly="True" />
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
                                            <Siar:QuotaBox Label="% del contributo sul totale dichiarato" ID="txtQuotaContributoRichiesta" runat="server" NrDecimali="12" ReadOnly="True" />
                                        </div>
                                        <div class="col-sm-6 form-group form-riepilogo">
                                            <Siar:CurrencyBox Label="Contributo ammesso (€)" ID="txtTotaleContributoAmmissibile" runat="server" ReadOnly="True" />
                                        </div>
                                        <div class="col-sm-6 form-group form-riepilogo">
                                            <Siar:QuotaBox Label="% del contributo ammesso sul totale dichiarato" ID="txtQuotaContributoAmmessa" runat="server" NrDecimali="12" ReadOnly="True" />
                                        </div>
                                        <div class="col-sm-12 form-group form-riepilogo">
                                            <Siar:CurrencyBox ID="txtImportoSanzione" runat="server" ReadOnly="True" Visible="false" />
                                            <Siar:CurrencyBox Label="Recupero sull'anticipo" ID="txtRecuperoAnticipo" runat="server" ReadOnly="True" />
                                        </div>
                                        <div class="col-sm-12 form-group form-riepilogo">
                                            <Siar:CurrencyBox Label="Contributo ammesso al netto del recupero anticipo" ID="txtTotaleContributoAmmesso" runat="server" ReadOnly="True" />
                                            <p id="divContributoAmmessoRidottoGradutatoria" runat="server" visible="false">
                                                <b>*Il contributo ammesso è stato ridotto per non superare il contributo concesso in graduatoria</b>
                                            </p>
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
                                    <div class="col-sm-12" id="tableInvestimenti" runat="server" visible="false">
                                        <div class="table-responsive">
                                            <Siar:DataGridAgid CssClass="table table-striped" ID="dgInvestimenti" runat="server" AutoGenerateColumns="False" PageSize="20">
                                                <Columns>
                                                    <Siar:NumberColumn HeaderText="Nr.">
                                                        <FooterStyle HorizontalAlign="center" />
                                                        <ItemStyle HorizontalAlign="center" />
                                                    </Siar:NumberColumn>
                                                    <asp:BoundColumn DataField="Misura" HeaderText="Programmazione">
                                                        <ItemStyle HorizontalAlign="center" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn HeaderText="Descrizione"></asp:BoundColumn>
                                                    <Siar:ColonnaLink DataField="SettoreProduttivo" HeaderText="Settore produttivo" IsJavascript="false"
                                                        LinkFields="IdInvestimento" LinkFormat="IstruttoriaInvestimento.aspx?idinv={0}">
                                                        <ItemStyle Width="100px" HorizontalAlign="center" />
                                                    </Siar:ColonnaLink>
                                                    <asp:BoundColumn HeaderText="Costo totale investimento" DataFormatString="{0:c}">
                                                        <FooterStyle HorizontalAlign="right" />
                                                        <ItemStyle HorizontalAlign="right" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn HeaderText="Contributo ammesso" DataField="ContributoRichiesto"
                                                        DataFormatString="{0:c}">
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
                                                    <asp:BoundColumn HeaderText="Importo pagamento ammissibile" DataFormatString="{0:c}">
                                                        <FooterStyle HorizontalAlign="right" />
                                                        <ItemStyle HorizontalAlign="right" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn HeaderText="Contributo pagamento ammissibile" DataFormatString="{0:c}">
                                                        <FooterStyle HorizontalAlign="right" />
                                                        <ItemStyle HorizontalAlign="right" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn HeaderText="% rendicontazione">
                                                        <ItemStyle HorizontalAlign="right" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn Visible="false" HeaderText="Disavanzo richiesto/ammesso (limite 10% costo investimento)"
                                                        DataFormatString="{0:c}">
                                                        <FooterStyle HorizontalAlign="right" />
                                                        <ItemStyle HorizontalAlign="right" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn Visible="false" HeaderText="Disavanzo contributo richiesto/ammesso (limite 10% costo investimento)"
                                                        DataFormatString="{0:c}">
                                                        <FooterStyle HorizontalAlign="right" />
                                                        <ItemStyle HorizontalAlign="right" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn HeaderText="Contributo extra a copertura economie" DataFormatString="{0:c}">
                                                        <FooterStyle HorizontalAlign="right" />
                                                        <ItemStyle HorizontalAlign="right" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn Visible="false" HeaderText="Rimanenza da assegnare/coprire" DataFormatString="{0:c}">
                                                        <FooterStyle HorizontalAlign="right" />
                                                        <ItemStyle HorizontalAlign="right" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn HeaderText="% rendicontazione ammissibile">
                                                        <ItemStyle HorizontalAlign="right" />
                                                    </asp:BoundColumn>
                                                </Columns>
                                            </Siar:DataGridAgid>
                                        </div>
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
                                                        <uc3:SiarNewToolTip ID="SiarNewToolTip1" runat="server" Codice="legenda_pianoinvestimenti" />
                                                </td>
                                            </tr>
                                        </table>
                                        <%--<table id="tableBrevetti" width="100%" runat="server" visible="false">
                                            <tr>
                                                <td class="separatore">Brevetti &amp; licenze:
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-bottom: 20px">
                                                    <Siar:DataGrid ID="dgBrevetti" runat="server" AutoGenerateColumns="False" PageSize="20"
                                                        Width="100%">
                                                        <ItemStyle Height="30px" />
                                                        <Columns>
                                                            <asp:BoundColumn DataField="Misura" HeaderText="Programmazione">
                                                                <ItemStyle HorizontalAlign="center" Width="130px" />
                                                            </asp:BoundColumn>
                                                            <Siar:ColonnaLink DataField="Descrizione" HeaderText="Descrizione tecnica" IsJavascript="false"
                                                                LinkFields="IdInvestimento" LinkFormat="IstruttoriaInvestimento.aspx?idinv={0}">
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
                                                                LinkFields="IdInvestimento" LinkFormat="IstruttoriaInvestimento.aspx?idinv={0}">
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
                                                                LinkFields="IdInvestimento" LinkFormat="IstruttoriaInvestimento.aspx?idinv={0}">
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
                                                            <td style="width: 150px">Ammontare raggiunto &euro;:<br />
                                                                <Siar:CurrencyBox ID="txtPCCAmmontare" runat="server" Width="130px" ReadOnly="True" />
                                                            </td>
                                                            <td style="width: 150px">Anticipo percepito &euro;:<br />
                                                                <Siar:CurrencyBox ID="txtPCCAnticipo" runat="server" Width="130px" ReadOnly="True" />
                                                            </td>
                                                            <td>Ammontare rimanente &euro;:<br />
                                                                <Siar:CurrencyBox ID="txtPCCRimanente" runat="server" Width="130px" ReadOnly="True" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>--%>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <uc4:PianoInvestimentiAggregazioneDomandaIstruttoria ID="PianoInvestimentiAggregazioneDomandaIstruttoria" runat="server" />
                        <uc5:PianoInvestimentiCodificaDomandaIstruttoria ID="PianoInvestimentiCodificaDomandaIstruttoria" runat="server" />
                        <uc7:PianoInvestimentiInterventoDomandaIstruttoria ID="PianoInvestimentiInterventoDomandaIstruttoria" runat="server" />
                        <uc6:ucVisure ID="ucVisure" runat="server" />
                    </div>
                </div>
            </div>
        </div>
        <div class="col-sm-12 text-end mb-5">
            <a id="btnBackDown" runat="server" class="btn btn-secondary py-1" onclick="location = 'CheckListPagamento.aspx'">
                <svg class="icon icon-breadcrumb icon-secondary icon-white me-1" aria-hidden="true">
                    <use href="/web/bootstrap-italia/svg/sprites.svg#it-check"></use>
                </svg>
                Torna alla checklist di istruttoria</a>
        </div>
    </div>
    <div id='divIstPagForm' class="modal it-dialog-scrollable" tabindex="-1" role="dialog" style="position: absolute; display: none">
        <div class="modal-dialog modal-xl" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h2 class="modal-title h5 " id="modal1Title">Importi totali della domanda di pagamento dettagliati per misura:</h2>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-sm-12">
                            <Siar:DataGridAgid CssClass="table table-striped" ID="dgDettaglioMisura" runat="server" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:BoundColumn HeaderText="Programmazione" DataField="Misura">
                                        <ItemStyle HorizontalAlign="Center" />
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
                                    <asp:BoundColumn HeaderText="Contributo richiesto" DataFormatString="{0:c}" DataField="ContributoRichiesto">
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="(B) Contributo ammissibile" DataFormatString="{0:c}"
                                        DataField="ContributoAmmissibile">
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="% su totale (B/A)" DataFormatString="{0:n}">
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
                    </div>
                </div>
                <div class="modal-footer">
                    <input id="btnChiudi" class="btn btn-secondary py-1" type="button" value="Chiudi"
                        onclick="chiudiPopupTemplate()" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
