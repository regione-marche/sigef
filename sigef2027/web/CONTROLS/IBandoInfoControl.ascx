<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="IBandoInfoControl.ascx.cs" Inherits="web.CONTROLS.IBandoInfoControl" %>

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
                        <div class="col-sm-12">
                            <p>
                                <span class="fw-bold">Numero delle domande presentate: </span>
                                <Siar:Label ID="lblDomandePresentate" runat="server"></Siar:Label>
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

<%--<table class="tableNoTab" width="950px">
    <tr>
        <td align="left">
            <table style="width: 100%;">
                <tr class="TESTA1">
                    <td align="center" colspan="7">&nbsp;<b>SEZIONE RENDICONTAZIONE</b>
                    </td>
                </tr>
                <tr class="TESTA">
                    <td></td>
                    <td>Descrizione del bando
                    </td>
                    <td>Nr. atto
                    </td>
                    <td>Data atto
                    </td>
                    <td>Importo
                    </td>
                    <td>Scadenza
                    </td>
                    <td>Domande presentate
                    </td>
                </tr>
                <tr class="DataGridRow" style="height: 26px">
                    <td align="center" style="width: 30px"></td>
                    <td></td>
                    <td align="center" width="80px"></td>
                    <td align="center" width="80px"></td>
                    <td align="center" width="100px"></td>
                    <td align="center" width="80px"></td>
                    <td align="center" width="80"></td>
                </tr>
            </table>
        </td>
    </tr>
</table>--%>
