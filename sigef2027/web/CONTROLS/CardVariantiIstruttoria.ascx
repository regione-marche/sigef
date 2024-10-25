<%@ Control Language="C#" AutoEventWireup="true" Inherits="web.CONTROLS.CardVariantiIstruttoria"
    CodeBehind="CardVariantiIstruttoria.ascx.cs" %>
<%@ Register Src="SNCVisualizzaProtocollo.ascx" TagName="SNCVisualizzaProtocollo"
    TagPrefix="uc1" %>
<%@ Register Src="VisualizzaReport.ascx" TagName="VisualizzaReport" TagPrefix="uc2" %>

<div class="row pt-5">
    <div class="col-lg-6">
        <!--start card-->
        <div class="card-wrapper card-space">
            <div class="card card-bg card-big">
                <div class="card-body">
                    <div class="top-icon">
                        <span class="card-title h5 ">
                            <svg class="icon">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-card"></use>
                            </svg>
                            <span>Dati domanda di contributo</span></span>
                    </div>
                    <div class="row">
                        <div class="col-sm-12">
                            <p>
                                <span class="fw-bold">Informazioni del bando: </span><a title="Visualizza il bando" id="lnkDocumentiBando" runat="server">
                                    <svg class="icon">
                                        <use href="/web/bootstrap-italia/svg/sprites.svg#it-info-circle"></use></svg>
                                </a>
                            </p>
                        </div>
                        <div class="col-sm-12">
                            <p>
                                <span class="fw-bold">Numero: </span>
                                <asp:Label ID="lblNumero" runat="server">
                                </asp:Label>
                            </p>
                        </div>
                        <div class="col-sm-12">
                            <p>
                                <span class="fw-bold">Codice CUP: </span>
                                <asp:Label ID="lblCup" runat="server">
                                </asp:Label>
                            </p>
                        </div>
                        <div>
                            <p>
                                <span class="fw-bold">Beneficiario: </span>
                                <Siar:Label ID="lblCodiceFiscale" runat="server">
                                </Siar:Label>
                                -
                                <Siar:Label ID="lblRagioneSociale" runat="server">
                                </Siar:Label>
                            </p>
                        </div>
                        <div class="col-sm-12">
                            <p>
                                <span class="fw-bold">Stato: </span>
                                <asp:Label ID="lblStato" runat="server">
                                </asp:Label>
                            </p>
                        </div>
                        <div class="col-sm-12">
                            <p>
                                <span class="fw-bold">Visualizza documento firmato: </span>
                                <uc1:SNCVisualizzaProtocollo ID="ucSNCVPPDomanda" runat="server" TipoVisualizzazione="Immagine"
                                    VisualizzaMenu="true" />
                            </p>
                        </div>
                    </div>
                </div>
                <div class="card-footer">
                    <input class="btn btn-secondary py-1 m-1" onclick="location = '../GestioneLavori.aspx'"
                        type="button" value="Vai a gestione lavori" />
                    <input class="btn btn-secondary py-1 m-1" onclick="location = '../../PDomanda/DatiGenerali.aspx'"
                        type="button" value="Vai alla sezione domanda" />
                </div>
            </div>
        </div>
    </div>
    <div class="col-lg-6">
        <!--start card-->
        <div class="card-wrapper card-space">
            <div class="card card-bg card-big">
                <div class="card-body">
                    <div class="top-icon">
                        <span class="card-title h5 ">
                            <svg class="icon">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-bookmark"></use>
                            </svg>
                            <span>Dati della variante</span></span>
                    </div>
                    <div class="row">
                        <div class="col-sm-6">
                            <p>
                                <span class="fw-bold">Numero: </span>
                                <asp:Label ID="lblNumeroVariante" runat="server">
                                </asp:Label>
                            </p>
                        </div>
                        <div class="col-sm-6">
                            <p>
                                <span class="fw-bold">Descrizione: </span>
                                <asp:Label ID="lblDescrizione" runat="server"></asp:Label>
                            </p>
                        </div>
                        <div class="col-sm-6">
                            <p>
                                <span class="fw-bold">Operatore: </span>
                                <asp:Label ID="lblOperatore" runat="server"></asp:Label>
                            </p>
                        </div>
                        <div class="col-sm-6">
                            <p>
                                <span class="fw-bold">Approvata: </span>
                                <asp:Label ID="lblApprovazione" runat="server"></asp:Label>
                            </p>
                        </div>
                        <div class="col-sm-6">
                            <p>
                                <span class="fw-bold">Visualizza documento firmato: </span>
                                <uc1:SNCVisualizzaProtocollo ID="ucSNCVPVariante" runat="server" TipoVisualizzazione="Invisibile"
                                    VisualizzaMenu="true" />

                            </p>
                        </div>
                        <div class="col-sm-6">
                            <p>
                                <span class="fw-bold">Ricevuta di protocollazione: </span>
                                <uc2:VisualizzaReport ID="ucVRRicevutaProtocollazione" runat="server" ReportFormat="PDF"
                                    ReportViewOptions="Invisibile" Text="Stampa la ricevuta di protocollazione" ReportName="rptRicevutaProtocollazioneVariante" />
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="divDocumentiBando" class="modal it-dialog-scrollable" tabindex="-1" role="dialog" style="position: absolute; display: none">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h2 class="modal-title h5 " id="modal1Title">Elenco dei documenti relativi al bando selezionato:</h2>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-sm-12">
                            <span class="fw-bold">Id: </span>
                            <asp:Label ID="lblIdBando" runat="server"></asp:Label>
                        </div>
                        <div class="col-sm-12">
                            <span class="fw-bold">Descrizione: </span>
                            <asp:Label ID="lblDescBando" runat="server"></asp:Label>
                        </div>
                        <div class="col-sm-12">
                            <span class="fw-bold">Scadenza: </span>
                            <asp:Label ID="lblScadenzaBando" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class="col-sm-12" id="tdGridDocumentiBando"></div>
                </div>
                <div class="modal-footer">
                    <input type="button" value="Chiudi" class="btn btn-primary btn-sm" onclick="chiudiPopupTemplate()" />
                </div>
            </div>
        </div>
    </div>
</div>
