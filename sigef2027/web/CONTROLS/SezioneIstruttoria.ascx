<%@ Control Language="C#" AutoEventWireup="true" Inherits="web.CONTROLS.SezioneIstruttoria"
    CodeBehind="SezioneIstruttoria.ascx.cs" %>

<div class="row pt-5">
    <div class="col-lg-12">
        <div class="card-wrapper card-space">
            <div class="card card-bg card-big">
                <div class="card-body">
                    <div class="top-icon">
                        <span class="card-title h5 ">
                            <svg class="icon">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-piattaforme"></use>
                            </svg>
                            <span>Sezione istruttoria</span>
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
                                <span class="fw-bold">Scadenza dell'istruttoria: </span>
                                <Siar:Label ID="lblDataScadenzaIstruttoria" runat="server"></Siar:Label>
                            </p>
                        </div>
                        <div class="col-sm-12">
                            <p>
                                <span class="fw-bold">Numero delle domande presentate: </span>
                                <Siar:Label ID="lblNumeroPresentate" runat="server"></Siar:Label>
                            </p>
                        </div>
                    </div>
                </div>
                <div class="card-footer">
                    <div class="col-sm-12">
                        <input class="btn btn-secondary py-1" type="button" value="Riepilogo del bando"
                            onclick="location = '../psr/bandi/dettaglio.aspx'" />
                        <input class="btn btn-secondary py-1" type="button" value="Sezione rendicontazione"
                            onclick="location = '../ipagamento/SelezioneDomande.aspx'" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<%--<table class="table" width="800px">
    <tr>
        <td align="center" style="height: 20px">
            <strong>SEZIONE ISTRUTTORIA</strong>
        </td>
    </tr>
    <tr>
        <td align="left">
            <table border="1" cellspacing="0" style="width: 100%; border-collapse: collapse; margin-bottom: 20px">
                <tr class="TESTA1">
                    <td align="center" colspan="5">Bando di gara
                    </td>
                    <td align="center">Domande
                    </td>
                </tr>
                <tr class="TESTA">
                    <td></td>
                    <td>Descrizione del bando
                    </td>
                    <td>Importo
                    </td>
                    <td>Scadenza
                    </td>
                    <td>Scadenza istruttoria
                    </td>
                    <td>Numero domande presentate&nbsp;
                    </td>
                </tr>
                <tr class="DataGridRow" style="height: 26px">
                    <td align="center" style="width: 30px">
                        <a id="lnkDocumentiBando" runat="server">
                            <img src='../../images/info.ico' alt='Visualizza il bando' />
                        </a>
                    </td>
                    <td width="270px">
                        <asp:Label ID="lblDesc" runat="server">
                        </asp:Label>
                    </td>
                    <td align="center" width="100px"></td>
                    <td align="center" width="100px"></td>
                    <td align="center" style="width: 100px"></td>
                    <td align="center" style="width: 110px"></td>
                </tr>
            </table>
            <table width="100%">
                <tr>
                    <td style="width: 40px">
                        <a href="../istruttoria/statistiche.aspx">
                            <img alt="Statistiche bando" src="../../images/diagramma.png" /></a>
                    </td>
                    <td style="width: 40px">
                        <a href="../istruttoria/Collaboratori.aspx">
                            <img alt="Assegna collaboratori al bando" src="../../images/collaboratori.ico" /></a>
                    </td>
                    <td style="width: 40px">
                        <a href="../istruttoria/Ricevibilita.aspx">
                            <img alt="Istruttoria di ricevibilità" src="../../images/Ricevibilita.ico" /></a>
                    </td>
                    <td style="width: 40px">
                        <a href="../istruttoria/Ammissibilita.aspx">
                            <img alt="Istruttoria di ammissibilità" src="../../images/Ammissibilita.ico" /></a>
                    </td>
                    <!--
                    <td style="width: 40px">
                        <a href="../istruttoria/RevisioneDomande.aspx">
                            <img alt="Revisione domande" src="../../images/revisore.gif" /></a>
                    </td>
                    -->
                    <td style="width: 50px">
                        <a href="../istruttoria/Graduatoria.aspx">
                            <img alt="Visualizza graduatoria" src="../../images/Graduatoria.ico" /></a>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>--%>
<%--<div id="divDocumentiBando" style="width: 700px; position: absolute; display: none">
    <table class="tableNoTab" width="100%">
        <tr>
            <td class="separatore">&nbsp;Lista documenti relativi al bando selezionato:
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
