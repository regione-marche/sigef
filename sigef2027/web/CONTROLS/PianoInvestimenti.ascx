<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PianoInvestimenti.ascx.cs"
    Inherits="web.CONTROLS.PianoInvestimenti" %>
<%@ Register Src="SiarNewToolTip.ascx" TagName="SiarNewToolTip" TagPrefix="uc1" %>

<script type="text/javascript"><!--
    function mostraMisura(id) { $('[id$=hdnIdDASelezionata]').val(id); $('[id$=btnPost]').click(); }
    function calcolaPolizza(idp) { $('[id$=btnRicalcolaPolizza]').click(); }
    function deletePolizza(idp) { if (confirm('Attenzione! Eliminare la polizza fidejussoria?')) $('[id$=btnDelPolizza]').click(); }

    $(document).ready(function () {
        $()
        var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'))
        var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
            return new bootstrap.Tooltip(tooltipTriggerEl)
        })
    });
//--></script>
<div style="display: none">
    <asp:Button ID="btnPost" runat="server" OnClick="btnPost_Click" CausesValidation="False" />
    <asp:HiddenField ID="hdnButton" runat="server" />
    <%--<asp:Button ID="btnRicalcolaPolizza" runat="server" OnClick="btnPolizza_Click" />
    <asp:Button ID="btnDelPolizza" runat="server" OnClick="btnDelPolizza_Click" CausesValidation="False" />--%>
</div>
<div class="accordion" id="collapseExample">
    <div class="accordion-item">
        <h2 class="accordion-header " id="pianoInvestimentiHeading">
            <button class="accordion-button rounded-2" type="button" data-bs-toggle="collapse" data-bs-target="#collapsePianoInvestimenti" aria-expanded="true" aria-controls="collapse1c">
                Piano degli investimenti
            </button>
        </h2>
        <div id="collapsePianoInvestimenti" class="accordion-collapse collapse show" role="region" aria-labelledby="pianoInvestimentiHeading">
            <div class="accordion-body">
                <ul id="tbMisura" runat="server" class="nav nav-tabs auto">
                    <%--                <li class="nav-item">
                    <a class="nav-link" onclick="mostraMisura(0);" >
                        VISUALIZZA TUTTI
                    </a>                    
                </li>--%>
                </ul>
                <%--<table id="tbMisura" runat="server" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="tdMisura" style="border-left: 1px solid #1380c4;" onclick="mostraMisura(0);">VISUALIZZA TUTTI<br />
                        GLI INVESTIMENTI
                    </td>
                </tr>
            </table>--%>
                <asp:HiddenField ID="hdnIdDASelezionata" runat="server" />

                <div id="tdButtons" runat="server" style="height: 60px; padding-right: 30px" align="right" visible="false"></div>
                <div id="tableInvestimenti" width="100%" runat="server" visible="false">
                    <h3 class="pb-5">Elenco investimenti:</h3>
                    <Siar:DataGridAgid ID="dgInvestimenti" CssClass="table table-striped" runat="server" AutoGenerateColumns="False" EnableViewState="False">
                        <ItemStyle Height="30px" />
                        <Columns>
                            <Siar:NumberColumn HeaderText="Nr.">
                                <FooterStyle HorizontalAlign="center" />
                                <ItemStyle HorizontalAlign="center" />
                            </Siar:NumberColumn>
                            <asp:BoundColumn HeaderText="Programmazione Intervento">
                                <ItemStyle HorizontalAlign="center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Descrizione"></asp:BoundColumn>
                            <Siar:ColonnaLink DataField="SettoreProduttivo" IsJavascript="false"
                                LinkFields="IdProgetto|IdInvestimento" LinkFormat="InvestimentiFondoPerduto.aspx?idpcurrent={0}&idinv={1}">
                                <ItemStyle Width="1px" HorizontalAlign="center" />
                            </Siar:ColonnaLink>
                            <asp:BoundColumn DataField="CostoInvestimento" HeaderText="Costo investimento" DataFormatString="{0:c}">
                                <FooterStyle HorizontalAlign="right" />
                                <ItemStyle HorizontalAlign="right" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="SpeseGenerali" HeaderText="Spese tecniche" DataFormatString="{0:c}" Visible="false">
                                <FooterStyle HorizontalAlign="right" />
                                <ItemStyle HorizontalAlign="right" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Contributo ammissibile" DataField="ContributoRichiesto"
                                DataFormatString="{0:c}">
                                <FooterStyle HorizontalAlign="right" />
                                <ItemStyle HorizontalAlign="right" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="QuotaContributoRichiesto" HeaderText="% Quota contributo ammissibile">
                                <FooterStyle HorizontalAlign="right" />
                                <ItemStyle HorizontalAlign="right" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Rata di reintegrazione" Visible="false">
                                <FooterStyle HorizontalAlign="right" />
                                <ItemStyle HorizontalAlign="right" />
                            </asp:BoundColumn>
                        </Columns>
                    </Siar:DataGridAgid>
                    <div class="col-sm-12" runat="server" id="tbLegendaInvestimenti" visible="false">
                        <ul>
                            <li><small>(*) = investimenti <b>NON</b> cofinanziati</small></li>
                            <li><small>(**) = contributo troncato per superamento <b>massimali</b> di domanda</small></li>
                            <li><small>(***) = contributo a <b>quota fissa</b></small></li>
                        </ul>
                        <p>
                            <span><small>legenda piano degli investimenti:</small></span>
                            <a data-bs-toggle="tooltip" data-bs-html="true" title="<div class='text-start'><h4>Legenda completa del piano degli investimenti</h4><p>La prima colonna della griglia del piano investimenti, oltre al numero, indica paricolari caratteristiche che si intende evidenziare. Tali, ma non tutte, indicazioni si applicano anche alle sottostanti griglie trattanti i vari tipi di spesa.</p><ul><li><b>Investimento con priorita di settore:</b><span> viene indicato con <b>una stella</b> ed evidenzia gli investimenti che insistono su settori produttivi con priorità;</span></li><li><b>Investimento ammesso in fase istruttoria:</b><span> viene indicato con <b>una check (v)</b> ed evidenzia gli investimenti istruiti dal funzionario regionale o provinciale addetto;</span></li><li><b>Investimento annullato: (solo per varianti ed adeguamenti tecnici)</b><span> indicato con (A) non concorre al calcolo dell'ammontare della spesa totale di domanda;</span></li><li><b>Investimento con economia: (solo per varianti ed adeguamenti tecnici)</b><span> indicato con (E) evidenzia l`investimento a cui è stata ridotta la spesa totale;</span></li><li><b>Investimento con spesa maggiorata: (solo per varianti ed adeguamenti tecnici)</b><span> indicato con (M) evidenzia  l'investimento a cui è stata aumentata la spesa totale;</span></li><li><b>Nuovo investimento: (solo per varianti ed adeguamenti tecnici)</b><span> indicato con (N) evidenzia un'investimento nuovo introdotto in questa variante;</span></li><li><b>Investimento variato: (solo per varianti ed adeguamenti tecnici)</b><span> indicato con (V) evidenzia un'investimento modificato in questa variante;</span></li><li><b>Investimento ripristinato: (solo per varianti ed adeguamenti tecnici)</b><span> indicato con (R) evidenzia un'investimento ripristinato dall'istruttore;</span></li></ul></div>">
                                <svg class="icon">
                                    <use href="/web/bootstrap-italia/svg/sprites.svg#it-info-circle"></use></svg>
                            </a>
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
