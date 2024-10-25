<%@ Control Language="C#" AutoEventWireup="true" Inherits="web.CONTROLS.IPagamentoControl"
    CodeBehind="IPagamentoControl.ascx.cs" %>

<div class="row">
    <div class="col-lg-12">
        <div class="card-wrapper card-space">
            <div class="card card-bg card-big">
                <div class="card-body">
                    <div class="top-icon">
                        <span class="card-title h5 ">
                            <svg class="icon">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-piattaforme"></use>
                            </svg>
                            <span>Sezione rendicontazione</span>
                        </span>
                    </div>
                    <div class="row">
                        <div class="col-sm-12">
                            <p>
                                <span class="fw-bold">Descrizione del bando: </span>
                                <asp:Label ID="lblDesc" runat="server"></asp:Label>
                            </p>
                        </div>
                        <div class="col-sm-3">
                            <p>
                                <span class="fw-bold">Documenti del bando: </span><a title="Visualizza il bando" id="lnkDocumentiBando" runat="server">
                                    <svg class="icon">
                                        <use href="/web/bootstrap-italia/svg/sprites.svg#it-info-circle"></use></svg>
                                </a>
                            </p>
                        </div>
                        <div class="col-sm-3">
                            <p>
                                <span class="fw-bold">Numero atto: </span>
                                <asp:Label ID="lblNumAtto" runat="server"></asp:Label>
                            </p>
                        </div>
                        <div class="col-sm-3">
                            <p>
                                <span class="fw-bold">Data atto: </span>
                                <asp:Label ID="lblDataAtto" runat="server"></asp:Label>
                            </p>
                        </div>
                        <div class="col-sm-3">
                            <p>
                                <span class="fw-bold">Importo del bando: </span>
                                <asp:Label ID="lblImporto" runat="server"></asp:Label>
                            </p>
                        </div>
                        <div class="col-sm-3">
                            <p>
                                <span class="fw-bold">Scadenza del bando: </span>
                                <Siar:Label ID="lblScadenza" runat="server" DataColumn="DataScadenza"></Siar:Label>
                            </p>
                        </div>
                        <div class="col-sm-3">
                            <p>
                                <span class="fw-bold">Numero delle domande presentate: </span>
                                <Siar:Label ID="lblDomandePresentate" runat="server"></Siar:Label>
                            </p>
                        </div>
                    </div>
                </div>
                <div class="card-footer">
                    <div class="col-sm-12">
                        <input class="btn btn-secondary py-1" type="button" value="Dettaglio del bando"
                            onclick="location = '../psr/bandi/dettaglio.aspx'" />
                        <input class="btn btn-secondary py-1" type="button" value="Sezione istruttoria"
                            onclick="location = '../istruttoria/statistiche.aspx'" />
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
                    <a class="nav-link" onclick="location='SelezioneDomande.aspx'">Selezione delle domande</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" onclick="location='DecretiVarianti.aspx'">Approvazione varianti/variazioni finanziarie</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" onclick="location='DecretiPagamento.aspx'">Decreti di pagamento</a>
                </li>
            </ul>
        </div>
    </div>
</div>
<%--<table class="tableNoTab" style="border-bottom: none" width="950px">
    <tr>
        <td align="left">
            <table border="1" cellspacing="0" style="width: 100%; border-collapse: collapse">
                <tr class="TESTA1">
                    <td align="center" colspan="7">
                        &nbsp;<b>SEZIONE RENDICONTAZIONE</b>
                    </td>
                </tr>
                <tr class="TESTA">
                    <td>
                    </td>
                    <td>
                        Descrizione del bando
                    </td>
                    <td>
                        Nr. atto
                    </td>
                    <td>
                        Data atto
                    </td>
                    <td>
                        Importo
                    </td>
                    <td>
                        Scadenza
                    </td>
                    <td>
                        Domande presentate
                    </td>
                </tr>
                <tr class="DataGridRow" style="height: 26px">
                    <td align="center" style="width: 30px">
                        <a id="lnkDocumentiBando" runat="server">
                            <img src='../../images/info.ico' alt='Visualizza il bando' /></a>
                    </td>
                    <td>
                        <asp:Label ID="lblDesc" runat="server">
                        </asp:Label>
                    </td>
                    <td align="center" width="80px">
                        <asp:Label ID="lblNumAtto" runat="server">
                        </asp:Label>
                    </td>
                    <td align="center" width="80px">
                        <asp:Label ID="lblDataAtto" runat="server"></asp:Label>
                    </td>
                    <td align="center" width="100px">
                        <asp:Label ID="lblImporto" runat="server">
                        </asp:Label>
                    </td>
                    <td align="center" width="80px">
                        <Siar:Label ID="lblScadenza" runat="server" DataColumn="DataScadenza">
                        </Siar:Label>
                    </td>
                    <td align="center" width="80">
                        <Siar:Label ID="lblDomandePresentate" runat="server">
                        </Siar:Label>
                    </td>
                </tr>
            </table>
            <br />
        </td>
    </tr>
</table>--%>
<%--<table width="950" cellpadding="0" cellspacing="0">
    <tr>
        <td id="tdLeft" style="border: #142952 1px solid; border-top: none; background-color: #E6E6EE;">&nbsp;&nbsp;
        </td>
        <td class="tdSchedaMenu" onclick="location='SelezioneDomande.aspx'">Selezione delle domande
        </td>
        <td class="tdSchedaMenu" onclick="location='DecretiVarianti.aspx'">Approvazione varianti/variazioni finanziarie
        </td>
        <%--<td class="tdSchedaMenu" onclick="location='ValidazioneRiepilogo.aspx'">
            Riepilogo Validazione
        </td>
        <td class="tdSchedaMenu" onclick="location='ValidazioneLotti.aspx'">
            Lotti di validazione
        </td>
        <td class="tdSchedaMenu" onclick="location='RevisioneDomande.aspx'">
            Validazione domande
        </td>--%>
        <%--<td class="tdSchedaMenu" onclick="location='DecretiPagamento.aspx'">Decreti di pagamento
        </td>
    </tr>
</table>--%>
<%--<table style="height: 5px; width: 950px; border: #142952 1px solid; background-color: #fefeee; border-top: none"
    cellpadding="0" cellspacing="0">
    <tr>
        <td></td>
    </tr>
</table>--%>
<%--<div id="divDocumentiBando" style="width: 700px; position: absolute; display: none">
    <table class="tableNoTab" width="100%">
        <tr>
            <td class="separatore">Elenco dei documenti relativi al bando selezionato:
            </td>
        </tr>
        <tr>
            <td id="tdGridDocumentiBando" style="padding: 5px"></td>
        </tr>
        <tr>
            <td style="height: 40px; padding-right: 40px;" align="right">
                <input style="width: 155px" type="button" value="Chiudi" class="Button" onclick="chiudiPopupTemplate()" />
            </td>
        </tr>
    </table>
</div>--%>
<div id="divDocumentiBando" class="modal it-dialog-scrollable" tabindex="-1" role="dialog" style="position: absolute; display: none">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <h2 class="modal-title h5 " id="modal1Title">Elenco dei documenti relativi al bando selezionato:</h2>
            </div>
            <div class="modal-body">
                <div class="col-sm-12" id="tdGridDocumentiBando"></div>
            </div>
            <div class="modal-footer">
                <input type="button" value="Chiudi" class="btn btn-primary btn-sm" onclick="chiudiPopupTemplate()" />
            </div>
        </div>
    </div>
</div>