<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    CodeBehind="Statistiche.aspx.cs" Inherits="web.Private.Istruttoria.Statistiche" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">
    <div class="row pt-5">
        <div class="col-sm-12">
            <div class="steppers">
                <div class="steppers-header">
                    <ul>
                        <li class="active">
                            <a class="steppers-link" title="Statistiche" type="button" href="../istruttoria/statistiche.aspx">
                                <svg class="icon icon-lg">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-chart-line"></use></svg>
                                <span class="steppers-text">Statistiche<span class="visually-hidden">Attivo</span></span>
                            </a>
                        </li>
                        <li>
                            <a class="steppers-link" type="button" title='Collaboratori istruttoria' href="../istruttoria/Collaboratori.aspx">
                                <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-user"></use></svg>
                                <span class="steppers-text">Collaboratori istruttoria</span>
                            </a>
                        </li>
                        <li>
                            <a class="steppers-link" type="button" title='Ricevibilità domande' href="../istruttoria/Ricevibilita.aspx">
                                <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-check-circle"></use>
                            </svg>
                                <span class="steppers-text">Ricevibilità domande</span>
                            </a>
                        </li>
                        <li>
                            <a class="steppers-link" type="button" title='Ammissibilità domande' href="../istruttoria/Ammissibilita.aspx">
                                <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-check"></use>
                            </svg>
                                <span class="steppers-text">Ammissibilità domande</span>
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
                    <button type="button" disabled="disabled" onclick="location = 'DatiGenerali.aspx'" class="btn btn-outline-primary btn-sm steppers-btn-prev"><svg class="icon icon-primary"><use href="/web/bootstrap-italia/svg/sprites.svg#it-chevron-left"></use></svg>Indietro</button>
                    <button type="button" onclick="location = 'Collaboratori.aspx'" class="btn btn-outline-primary btn-sm steppers-btn-next">Avanti<svg class="icon icon-primary"><use href="/web/bootstrap-italia/svg/sprites.svg#it-chevron-right"></use></svg></button>                
                </nav>
                <div class="steppers-content" aria-live="polite">
                    <div class="row py-5 mx-2">
                        <h2 class="pb-5">Statistiche del bando</h2>
                        <div class="col-sm-12">
                            <Siar:DataGridAgid CssClass="table table-striped" ID="dgStatistiche" runat="server" AutoGenerateColumns="False" Width="100%"
                                EnableViewState="False" NrColumnSearch="False">
                                <Columns>
                                    <asp:BoundColumn DataField="Fase" HeaderText="Fase procedurale">
                                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Stato" HeaderText="Stato">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="IdProgetto" HeaderText="Nr.domande">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="SegnaturaAllegati" HeaderText="Stato">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="IdBando" HeaderText="Nr.domande">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                </Columns>
                            </Siar:DataGridAgid>
                        </div>
                    </div>
                </div>
                <nav class="steppers-nav">
                   <button type="button" disabled="disabled" onclick="location = 'DatiGenerali.aspx'" class="btn btn-outline-primary btn-sm steppers-btn-prev"><svg class="icon icon-primary"><use href="/web/bootstrap-italia/svg/sprites.svg#it-chevron-left"></use></svg>Indietro</button>
                    <button type="button" onclick="location = 'Collaboratori.aspx'" class="btn btn-outline-primary btn-sm steppers-btn-next">Avanti<svg class="icon icon-primary"><use href="/web/bootstrap-italia/svg/sprites.svg#it-chevron-right"></use></svg></button>                
                </nav>
            </div>
        </div>
    </div>
</asp:Content>
