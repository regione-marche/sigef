<%@ Control Language="C#" AutoEventWireup="true" Inherits="web.CONTROLS.SezioneBando"
    CodeBehind="SezioneBando.ascx.cs" %>

<div class="row pt-5">
    <div class="col-lg-12">
        <div class="card-wrapper card-space">
            <div class="card card-bg card-big">
                <div class="card-body">
                    <div class="top-icon">
                        <span class="card-title h5 ">
                            <svg class="icon">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-note"></use>
                            </svg>
                            <span>Sezione bando</span>
                        </span>
                    </div>
                    <div class="row">
                        <div class="col-sm-12">
                            <p>
                                <span class="fw-bold">Ente:</span>
                                <asp:Label ID="lblEnte" runat="server"></asp:Label>

                            </p>
                        </div>
                        <div class="col-sm-2">
                            <p>
                                <span class="fw-bold">Id:</span>
                                <asp:Label ID="lblId" runat="server"></asp:Label>
                            </p>
                        </div>
                        <div class="col-sm-10">
                            <p>
                                <span class="fw-bold">Descrizione del bando</span>
                                <asp:Label ID="lblDesc" runat="server">
                                </asp:Label>
                            </p>
                        </div>
                        <div class="col-sm-2">
                            <p>
                                <span class="fw-bold">Documenti:</span>
                                <a id="lnkDocumentiBando" runat="server" title="Visualizza il bando" class="" data-focus-mouse="false">
                                    <svg class="icon">
                                        <use href="/web/bootstrap-italia/svg/sprites.svg#it-info-circle"></use></svg>
                                </a>
                            </p>
                        </div>
                        <div class="col-sm-2">
                            <p>
                                <span class="fw-bold">Scadenza:</span>
                                <asp:Label ID="lblScadenza" runat="server"></asp:Label>
                            </p>
                        </div>
                        <div class="col-sm-2">
                            <p>
                                <span class="fw-bold">Importo:</span>
                                <asp:Label ID="lblImporto" runat="server"></asp:Label>
                            </p>
                        </div>
                        <div class="col-sm-2">
                            <p>
                                <span class="fw-bold">Stato:</span>
                                <asp:Label ID="lblStato" runat="server"></asp:Label>
                            </p>
                        </div>
                        <div class="col-sm-2">
                            <p>
                                <span class="fw-bold">Nr. atto:</span>
                                <asp:Label ID="lblNumAtto" runat="server"></asp:Label>
                            </p>
                        </div>
                        <div class="col-sm-2">
                            <p>
                                <span class="fw-bold">Data atto:</span>
                                <asp:Label ID="lblDataAtto" runat="server"></asp:Label>
                            </p>
                        </div>
                        <div class="col-sm-2">
                            <input id="btnSezioneIstruttoria" runat="server" class="btn btn-secondary py-1" type="button" value="Sezione istruttoria" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<div class="row">
    <div class="col-sm-12">
        <div class="pt-2">
            <ul class="nav nav-tabs auto">  
                <li class="nav-item">
                    <a class="nav-link" onclick="location='dettaglio.aspx'">Dati generali</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" onclick="location='BandoSettoriProduttiviPriorita.aspx'">Ambiti tematici</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" onclick="location='CodificaInvestimento.aspx'">Codifica investimenti</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" onclick="location='ModelloDomanda.aspx'">Modello di domanda</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" onclick="location='DettaglioPagamento.aspx'">Domande di Pagamento</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" onclick="location='BandoVarianti.aspx'">Varianti / A.T.</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" onclick="location='BandoPubblicazione.aspx'">Procedurale</a>
                </li>
            </ul>
        </div>
    </div>
</div>
<%--<table width="950" cellpadding="0" cellspacing="0">
    <tr>
        <td style="width: 309px; border: #142952 1px solid; border-top-style: none; background-color: #E6E6FF">&nbsp; &nbsp;&nbsp;
        </td>
        <td class="tdSchedaMenu" onclick="location='dettaglio.aspx'">Dati generali
        </td>
        <td class="tdSchedaMenu" onclick="location='BandoSettoriProduttiviPriorita.aspx'">Ambiti tematici
        </td>
        <td class="tdSchedaMenu" onclick="location='CodificaInvestimento.aspx'">Codifica investimenti
        </td>
        <td class="tdSchedaMenu" onclick="location='ModelloDomanda.aspx'">Modello di domanda
        </td>
        <td class="tdSchedaMenu" onclick="location='DettaglioPagamento.aspx'">Domande di Pagamento
        </td>
        <td class="tdSchedaMenu" onclick="location='BandoVarianti.aspx'">Varianti / A.T.
        </td>
        <td class="tdSchedaMenu" onclick="location='BandoPubblicazione.aspx'">Procedurale
        </td>
    </tr>
</table>--%>
<div id="divDocumentiBando" style="position: absolute; display: none" class="modal it-dialog" tabindex="-1" role="dialog">
    <div class="modal-dialog modal-lg" role="document">
        <div class="modal-content">
            <div class="modal-header">
                Elenco documenti relativi al bando selezionato:
            </div>
            <div class="modal-body">
                <div class="row">
                    <div id="tdGridDocumentiBando" class="col-sm-12"></div>
                    <div class="col-sm-12">
                        <input type="button" value="Chiudi" class="btn btn-secondary py-1" onclick="chiudiPopupTemplate()" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
