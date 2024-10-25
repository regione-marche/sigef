<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    Inherits="web.Private.Istruttoria.AllegatiEsiti" CodeBehind="AllegatiEsiti.aspx.cs" %>

<%@ Register Src="../../CONTROLS/InfoDomanda.ascx" TagName="InfoDomanda" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <uc2:InfoDomanda ID="ucInfoDomanda" runat="server" />
    <nav class="breadcrumb-container" aria-label="Percorso di navigazione">
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a onclick="location='Ammissibilita.aspx'">
            <svg class="icon icon-breadcrumb icon-secondary align-top me-1" aria-hidden="true">
                <use href="/web/bootstrap-italia/svg/sprites.svg#it-check""></use>
            </svg>
            Ammissibilità</a><span class="separator">/</span></li>
        <li class="breadcrumb-item"><a onclick="history.back()">
            <svg class="icon icon-breadcrumb icon-secondary align-top me-1" aria-hidden="true">
                <use href="/web/bootstrap-italia/svg/sprites.svg#it-list""></use>
            </svg>
            Checklist d'istruttoria d'ammissibilità</a><span class="separator">/</span></li>
        <li class="breadcrumb-item active" aria-current="page">Istruttoria allegati</li>
    </ol>
    </nav>
    <div class="row py-5 mx-2 bd-form">
        <div class="col-sm-12 text-end">
            <a onclick="history.back()" class="btn btn-secondary py-1">
                <svg class="icon icon-breadcrumb icon-secondary icon-white me-1" aria-hidden="true">
                    <use href="/web/bootstrap-italia/svg/sprites.svg#it-arrow-left"></use>
                </svg>
                Torna indietro</a>
        </div>
        <h2 class="pb-2">Istruttoria degli allegati alla domanda di contributo:</h2>
        <p>
            Per predisporre la richiesta di certificazione al comune/provincia è necessario selezionare gli allegati di interesse e poi il pulsante "Richiedi certificazione".
        </p>
        <p>
            Per predisporre la richiesta di documentazione integrazione è possibile selezionando gli allegati di interesse o meno e poi il pulsante "Richiedi documentazione integrativa".
        </p>
        <div class="col-sm-12 form-group pt-5">
            <Siar:TextBox  Label="Digitare la segnatura della busta chiusa pervenuta:" runat="server" ID="txtNumProtocollo" MaxLength="80" NomeCampo="Segnatura degli allegati"
                ReadOnly="True" />
        </div>
        <div class="col-sm-12">
            <Siar:DataGridAgid ID="dgAllegato" runat="server" AutoGenerateColumns="False" CssClass="table table-striped">
                <Columns>
                    <Siar:NumberColumn HeaderText="Nr.">
                        <ItemStyle HorizontalAlign="Center" />
                    </Siar:NumberColumn>
                    <asp:BoundColumn DataField="CodTipo" HeaderText="Formato">
                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Dettaglio documento"></asp:BoundColumn>
                    <Siar:JsButtonColumn Arguments="IdFile" ButtonImage="lente.png" ButtonText="Visualizza"
                        ButtonType="ImageButton" JsFunction="SNCUFVisualizzaFile">
                        <ItemStyle HorizontalAlign="Center" />
                    </Siar:JsButtonColumn>
                    <asp:BoundColumn HeaderText="Esito"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Note"></asp:BoundColumn>
                    <Siar:CheckColumnAgid Name="chkSelezionaPerRichiedeIntegrazione" HeaderSelectAll="true"
                        DataField="Id">
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </Siar:CheckColumnAgid>
                </Columns>
            </Siar:DataGridAgid>
        </div>
        <div class="col-sm-12">
            <Siar:Button ID="btnSalva" runat="server" Text="Salva" OnClick="btnSalva_Click" Modifica="true" />
            <Siar:Button ID="btnRichiestaCertificazione" runat="server" Text="Richiedi Certificazione"
                OnClick="btnRichiestaCertificazione_Click" Modifica="true" />
            <Siar:Button ID="btnRichiestaDocumentiIntegrativi" runat="server" Text="Richiedi Documentazione Integrativa"
                OnClick="btnRichiestaDocumentiIntegrativi_Click" Modifica="true" />
        </div>
        <h3 class="py-5">Elenco delle richieste di certificazione e comunicazioni inviate</h3>
        <div class="col-sm-12">
            <Siar:DataGridAgid CssClass="table table-striped" ID="dgComunicazioniInviate" runat="server" AllowPaging="True" AutoGenerateColumns="False" PageSize="15">
                <Columns>
                    <Siar:NumberColumn HeaderText="Nr.">
                        <ItemStyle HorizontalAlign="Center" />
                    </Siar:NumberColumn>
                    <asp:BoundColumn DataField="TipoSegnatura" HeaderText="Tipo"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Ente" DataField="Ente">
                        <ItemStyle HorizontalAlign="left" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Data" HeaderText="Data">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="NominativoOperatore" HeaderText="Operatore">
                        <ItemStyle HorizontalAlign="left" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Stato">
                        <ItemStyle HorizontalAlign="left" />
                    </asp:BoundColumn>
                    <asp:BoundColumn>
                        <ItemStyle HorizontalAlign="center" />
                    </asp:BoundColumn>
                </Columns>
            </Siar:DataGridAgid>
        </div>
        <div class="col-sm-12 text-end">
            <a onclick="history.back()" class="btn btn-secondary py-1">
                <svg class="icon icon-breadcrumb icon-secondary icon-white me-1" aria-hidden="true">
                    <use href="/web/bootstrap-italia/svg/sprites.svg#it-arrow-left"></use>
                </svg>
                Torna indietro</a>
        </div>
    </div>
</asp:Content>
