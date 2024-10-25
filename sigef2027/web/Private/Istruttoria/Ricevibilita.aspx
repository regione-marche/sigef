<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    Inherits="web.Private.Istruttoria.Ricevibilita" CodeBehind="Ricevibilita.aspx.cs" %>

<%@ Register Src="../../CONTROLS/FiltroRicercaDomande.ascx" TagName="FiltroRicercaDomande"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <script type="text/javascript"> 
        function createUrlChecklistRicevibilita(iddom) {
            createBaseUrl('private/istruttoria/ChecklistRicevibilita.aspx?iddom=' + iddom);
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
                        <li class="active">
                            <a class="steppers-link" type="button" title='RicevibilitÓ domande' href="../istruttoria/Ricevibilita.aspx">
                                <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-check-circle"></use>
                            </svg>
                                <span class="steppers-text">RicevibilitÓ domande<span class="visually-hidden">Attivo</span></span>
                            </a>
                        </li>
                        <li>
                            <a class="steppers-link" type="button" title='AmmissibilitÓ domande' href="../istruttoria/Ammissibilita.aspx">
                                <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-check"></use>
                            </svg>
                                <span class="steppers-text">AmmissibilitÓ domande</span>
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
                    <button type="button" onclick="location = 'Collaboratori.aspx'" class="btn btn-outline-primary btn-sm steppers-btn-prev"><svg class="icon icon-primary"><use href="/web/bootstrap-italia/svg/sprites.svg#it-chevron-left"></use></svg>Indietro</button>
                    <button type="button" onclick="location = 'Ammissibilita.aspx'" class="btn btn-outline-primary btn-sm steppers-btn-next">Avanti<svg class="icon icon-primary"><use href="/web/bootstrap-italia/svg/sprites.svg#it-chevron-right"></use></svg></button>                
                </nav>
                <div class="steppers-content" aria-live="polite">
                    <div class="row py-5 bd-form mx-2">
                        <h2 class="pb-5">Istruttoria di ricevibilitÓ</h2>
                        <div class="col-sm-12">
                            <uc2:FiltroRicercaDomande ID="ucFiltroRicercaDomande" runat="server" />
                        </div>
                        <div class="col-sm-12">
                            <Siar:DataGridAgid CssClass="table table-striped" ID="dg" DataKeyField="IdProgetto" runat="server" AllowPaging="True"
                                AutoGenerateColumns="False" PageSize="15" OnItemDataBound="dg_ItemDataBound">
                                <ItemStyle Height="50px" />
                                <Columns>
                                    <Siar:NumberColumn HeaderText="Nr.">
                                        <ItemStyle HorizontalAlign="Center" Width="30px" />
                                    </Siar:NumberColumn>
                                    <asp:BoundColumn HeaderText="Domanda"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="Stato" HeaderText="Stato procedurale">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Istruttore" HeaderText="Istruttore assegnato">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ProvinciaAssegnazione" HeaderText="Provincia di assegnazione">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <Siar:JsButtonColumnAgid Arguments="IdProgetto" HeaderText="Vai alla checklist di ricevibilita" ButtonImage="it-check-circle"
                                        ButtonType="ImageButton" ButtonText="Vai alla checklist di ricevibilita" JsFunction="createUrlChecklistRicevibilita">
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
                    <button type="button" onclick="location = 'Collaboratori.aspx'" class="btn btn-outline-primary btn-sm steppers-btn-prev"><svg class="icon icon-primary"><use href="/web/bootstrap-italia/svg/sprites.svg#it-chevron-left"></use></svg>Indietro</button>
                    <button type="button" onclick="location = 'Ammissibilita.aspx'" class="btn btn-outline-primary btn-sm steppers-btn-next">Avanti<svg class="icon icon-primary"><use href="/web/bootstrap-italia/svg/sprites.svg#it-chevron-right"></use></svg></button>                
                </nav>
            </div>
        </div>
    </div>
</asp:Content>
