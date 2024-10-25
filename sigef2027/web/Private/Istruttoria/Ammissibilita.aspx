<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    EnableViewState="true" Inherits="web.Private.Istruttoria.Ammissibilita" CodeBehind="Ammissibilita.aspx.cs" %>

<%@ Register Src="../../CONTROLS/FiltroRicercaDomande.ascx" TagName="FiltroRicercaDomande"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <script type="text/javascript"> 
        function createUrlChecklistAmmissibilita(iddom) {
            createBaseUrl('private/istruttoria/ChecklistAmmissibilita.aspx?iddom=' + iddom);
        }
        function createUrlMonitoraggioStatoProgetto(iddom) {
            createBaseUrl('private/istruttoria/MonitoraggioStatoProgetto.aspx?iddom=' + iddom);
        }
        function createBaseUrl(url) { document.location = getBaseUrl() + url; }
    </script>
    <div class="row pt-5">
        <div class="col-sm-12">
            <div class="steppers">
                <div class="steppers-header">
                    <ul>
                        <li class="confirmed">
                            <a class="steppers-link" title="Statistiche" type="button" href="../istruttoria/statistiche.aspx">
                                <svg class="icon icon-lg">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-chart-line"></use></svg>
                                <span class="steppers-text">Statistiche<svg class="icon steppers-success"><use href="/web/bootstrap-italia/svg/sprites.svg#it-check"></use></svg><span class="visually-hidden">Confermato</span></span>
                            </a>
                        </li>
                        <li class="confirmed">
                            <a class="steppers-link" type="button" title='Collaboratori istruttoria' href="../istruttoria/Collaboratori.aspx">
                                <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-user"></use></svg>
                                <span class="steppers-text">Collaboratori istruttoria<svg class="icon steppers-success"><use href="/web/bootstrap-italia/svg/sprites.svg#it-check"></use></svg><span class="visually-hidden">Confermato</span></span>
                            </a>
                        </li>
                        <li class="confirmed">
                            <a class="steppers-link" type="button" title='Ricevibilità domande' href="../istruttoria/Ricevibilita.aspx">
                                <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-check-circle"></use>
                            </svg>
                                <span class="steppers-text">Ricevibilità domande<svg class="icon steppers-success"><use href="/web/bootstrap-italia/svg/sprites.svg#it-check"></use></svg><span class="visually-hidden">Confermato</span></span>
                            </a>
                        </li>
                        <li class="active">
                            <a class="steppers-link" type="button" title='Ammissibilità domande' href="../istruttoria/Ammissibilita.aspx">
                                <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-check"></use>
                            </svg>
                                <span class="steppers-text">Ammissibilità domande<span class="visually-hidden">Attivo</span></span>
                            </a>
                        </li>
                        <li>
                            <a class="steppers-link" type="button" title='Graduatoria' href="../istruttoria/Graduatoria.aspx">
                                <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-list"></use>
                            </svg>
                                <span class="steppers-text">Graduatoria</span>
                            </a>
                        </li>
                    </ul>
                </div>
                <nav class="steppers-nav">
                    <button type="button" onclick="location = 'Ricevibilita.aspx'" class="btn btn-outline-primary btn-sm steppers-btn-prev"><svg class="icon icon-primary"><use href="/web/bootstrap-italia/svg/sprites.svg#it-chevron-left"></use></svg>Indietro</button>
                    <button type="button" onclick="location = 'Graduatoria.aspx'" class="btn btn-outline-primary btn-sm steppers-btn-next">Avanti<svg class="icon icon-primary"><use href="/web/bootstrap-italia/svg/sprites.svg#it-chevron-right"></use></svg></button>                
                </nav>
                <div class="steppers-content" aria-live="polite">
                    <div class="row py-5 bd-form mx-2">
                        <h2 class="pb-5">Istruttoria di ammissibilità</h2>
                        <div class="col-sm-12">
                            <uc2:FiltroRicercaDomande ID="ucFiltroRicercaDomande" runat="server" />
                        </div>
                        <div class="col-sm-12">
                            <Siar:DataGridAgid ID="dg" CssClass="table table-striped" DataKeyField="IdProgetto" runat="server" AllowPaging="True"
                                AutoGenerateColumns="False" PageSize="15" OnItemDataBound="dg_ItemDataBound">                                
                                <Columns>
                                    <Siar:NumberColumn HeaderText="Nr.">
                                        <ItemStyle HorizontalAlign="Center" Width="30px" />
                                    </Siar:NumberColumn>
                                    <asp:BoundColumn HeaderText="Domanda"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="Stato" HeaderText="Stato procedurale">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Istruttore" HeaderText="Istruttore assegnato">
                                        <ItemStyle Width="130px" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ProvinciaAssegnazione" HeaderText="Provincia di assegnazione">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <Siar:JsButtonColumnAgid Arguments="IdProgetto" HeaderText="Vai alla checklist di ammissibilità" ButtonImage="it-check"
                                        ButtonType="ImageButton" ButtonText="Vai alla checklist di ammissibilità" JsFunction="createUrlChecklistAmmissibilita">
                                    </Siar:JsButtonColumnAgid>
                                    <Siar:JsButtonColumnAgid Arguments="IdProgetto" HeaderText="Iter procedurale della domanda" ButtonImage="it-inbox"
                                        ButtonType="ImageButton" ButtonText="Sezione rendicontazione" JsFunction="createUrlMonitoraggioStatoProgetto">
                                    </Siar:JsButtonColumnAgid>
                                </Columns>
                            </Siar:DataGridAgid>
                        </div>
                    </div>
                </div>
                <nav class="steppers-nav">
                    <button type="button" onclick="location = 'Ricevibilita.aspx'" class="btn btn-outline-primary btn-sm steppers-btn-prev"><svg class="icon icon-primary"><use href="/web/bootstrap-italia/svg/sprites.svg#it-chevron-left"></use></svg>Indietro</button>
                    <button type="button" onclick="location = 'Graduatoria.aspx'" class="btn btn-outline-primary btn-sm steppers-btn-next">Avanti<svg class="icon icon-primary"><use href="/web/bootstrap-italia/svg/sprites.svg#it-chevron-right"></use></svg></button>                
                </nav>
            </div>
        </div>
    </div>
</asp:Content>
