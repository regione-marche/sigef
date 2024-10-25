<%@ Control Language="C#" AutoEventWireup="true" Inherits="web.CONTROLS.SezioneImpresa"
    CodeBehind="SezioneImpresa.ascx.cs" %>
<div class="row pt-5">
    <div class="col-lg-12">
        <div class="card-wrapper card-space">
            <div class="card card-bg card-big">
                <div class="card-body">
                    <div class="top-icon">
                        <span class="card-title h5 ">
                            <svg class="icon">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-map-marker"></use>
                            </svg>
                            <span>Sezione beneficiario</span>
                        </span>
                    </div>
                    <div class="row">
                        <div class="col-sm-12">
                            <p>
                                <span class="fw-bold">Cod.Fiscale: </span>
                                <Siar:Label ID="lblCuaa" runat="server">
                                    </Siar:Label>                            

                            </p>
                        </div>
                        <div class="col-sm-12">
                            <p>
                                <span class="fw-bold">C.F./P.Iva: </span>
                                <Siar:Label ID="lblCodiceFiscale" runat="server">
                                    </Siar:Label>
                            </p>
                        </div>
                        <div class="col-sm-12">
                            <p>
                                <span class="fw-bold">Ragione Sociale: </span>
                                <Siar:Label ID="lblRagioneSociale" runat="server">
                                    </Siar:Label>
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

<%--<table class="tableNoTab" width="800" cellpadding="0" cellspacing="0">
    <tr>
        <td>--%>
<%--            <table width="100%" cellpadding="0" cellspacing="0">
                <tr class="TESTA1">
                    <td align="center">SEZIONE BENEFICIARIO
                    </td>
                </tr>
                <tr style="background-color: #1380c4; font-size: 12px;">
                    <td align="left">
                        <table width="100%" style="border-top: black 1px solid; border-bottom: black 1px solid"
                            cellpadding="0" cellspacing="0">
                            <tr class="banner_chiaro">
                                <td style="width: 180px; line-height: 1.4em">
                                    <strong>&nbsp;Cod.Fiscale:</strong>&nbsp;
                                    
                                </td>
                                <td>
                                    <strong>&nbsp;C.F./P.Iva:</strong>
                                    
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table width="100%" style="border-top: black 1px solid; border-bottom: black 1px solid"
                            cellpadding="0" cellspacing="0">
                            <tr class="banner_chiaro">
                                <td style="line-height: 1.4em">
                                    <strong>&nbsp;Ragione Sociale:</strong>&nbsp;
                                    
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>--%>
            <%--<table width="100%">
                <tr>
                    <td style="height: 34px">
                        <table width="100%" cellpadding="0" cellspacing="0">
                            <tr>
                                <td align="left" style="width: 110px">
                                    <b>Assistenza utenti:</b>
                                </td>
                                <td align="left" title="Assistenza agli utenti">
                                    <a href="AssistenzaUtenti.aspx">
                                        <img title="Riepilogo attività dell`impresa" src="../../images/help-desk.png" /></a>
                                </td>
                                <td align="right" style="padding-right: 20px">
                                    <b>vai alla pagina:</b>
                                </td>
                                <td style="width: 40px;" title="Riepilogo attività dell'impresa">
                                    <a href="ImpresaRiepilogo.aspx">
                                        <img title="Riepilogo attività dell`impresa" src="../../images/home.gif" /></a>
                                </td>
                                <td style="width: 40px;" title="Sezione PSR">
                                    <a href="ImpresaDomande.aspx">
                                        <img title="Domande" src="../../images/bandi.gif" /></a>
                                </td>
                                <td style="width: 40px;">
                                    <a href="ImpresaAnagrafe.aspx" title="Anagrafe dell'impresa">
                                        <img title="Dati anagrafici" src="../../images/codicefiscale.gif" /></a>
                                </td>
                                <td style="width: 40px;">
                                    <a href="ImpresaVisure.aspx" title="Visure">
                                        <img title="Visure" src="../../images/acrobat.gif" /></a>
                                </td>
                                <td style="width: 40px;">
                                    <a href="AggregazioneImprese.aspx" title="Gestione delle aggregazioni dell'impresa">
                                        <img title="Gestione soci" src="../../images/collaboratori.ico" /></a>
                                </td>
                                <td style="width: 40px;">
                                    <a href="ImpresaConsulente.aspx" title="Gestione e richieste dei consulenti dell'impresa">
                                        <img title="Gestione consulenti" src="../../images/soggetto.ico" /></a>
                                </td>
                                <td style="width: 40px;">
                                    <a href="ImpresaBusinessPlan.aspx" title="Presentazione e dettagli finanziari dell'impresa">
                                        <img title="Gestione finanziaria" src="../../images/euro.gif" /></a>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td align="center" style="border-left: #000000 1px solid; height: 34px; width: 60px;">
                        <a href="ImpresaFind.aspx" title="Ricerca altre imprese">
                            <img alt="Ricerca altre imprese" src="../../images/lente.ico" /></a>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>--%>
