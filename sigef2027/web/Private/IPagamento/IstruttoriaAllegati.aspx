<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    Inherits="web.Private.IPagamento.IstruttoriaAllegati" CodeBehind="IstruttoriaAllegati.aspx.cs" %>

<%@ Register Src="../../CONTROLS/IDomandaPagamento.ascx" TagName="IDomandaPagamento"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <uc2:IDomandaPagamento ID="ucIDomandaPagamento" runat="server"></uc2:IDomandaPagamento>
    <div class="row p-5 ">
        <div class="col-sm-12 text-end mt-5">
            <a runat="server" id="btnBack" class="btn btn-secondary py-1" onclick="javascript: location = 'CheckListPagamento.aspx'">
                <svg class="icon icon-breadcrumb icon-secondary icon-white me-1" aria-hidden="true">
                    <use href="/web/bootstrap-italia/svg/sprites.svg#it-check"></use>
                </svg>
                Torna alla checklist di pagamento</a>
        </div>
        <h2 class="pb-5">Istruttoria degli allegati della domanda di pagamento
        </h2>
        <div class="col-sm-12 form-group">
            <Siar:TextBox  Label="Digitare la segnatura della documentazione pervenuta:" ID="txtNumProtocollo" runat="server" MaxLength="80" NomeCampo="Segnatura degli allegati"></Siar:TextBox>
        </div>
        <div class="col-sm-12">
            <Siar:DataGridAgid class="table table-striped" ID="dgAllegati" runat="server" AutoGenerateColumns="False">
                <PagerStyle Mode="NumericPages" CssClass="coda"></PagerStyle>
                <Columns>
                    <Siar:NumberColumn HeaderText="Nr.">
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </Siar:NumberColumn>
                    <asp:BoundColumn DataField="Formato" HeaderText="Formato">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Dettaglio documento"></asp:BoundColumn>
                    <Siar:JsButtonColumnAgid Arguments="IdFile" ButtonImage="it-search" ButtonText="Visualizza"
                        ButtonType="ImageButton" JsFunction="SNCUFVisualizzaFile">
                        <ItemStyle HorizontalAlign="Center" />
                    </Siar:JsButtonColumnAgid>
                    <asp:BoundColumn HeaderText="Esito">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Note">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <Siar:CheckColumnAgid Name="chkSelezionaPerRichiedeIntegrazione" HeaderSelectAll="true"
                        DataField="IdAllegato">
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </Siar:CheckColumnAgid>
                </Columns>
            </Siar:DataGridAgid>
        </div>
        <div class="col-sm-12">
            <Siar:Button ID="btnSalva" runat="server" Modifica="true" OnClick="btnSalva_Click"
                Text="Ammetti" Width="200px"></Siar:Button>
            <Siar:Button ID="btnRichiestaCertificazione" runat="server" Text="Richiedi Certificazione"
                OnClick="btnRichiestaCertificazione_Click" Modifica="true" />
            <Siar:Button ID="btnRichiestaDocumentiIntegrativi" runat="server" Text="Richiedi Documentazione Integrativa"
                OnClick="btnRichiestaDocumentiIntegrativi_Click" Modifica="true" Visible="false" />
        </div>
        <div class="row bd-form mt-5" id="trIntegrazioneDomanda" runat="server" visible="false">
            <h3 class="pb-5">Richiedi integrazione di documentazione:
            </h3>
            <div class="col-sm-12 form-group">
                <Siar:DateTextBox Label="Data richiesta:" ID="txtDataIntegrazione" runat="server" Width="120px" />
                <br />
            </div>
            <div class="col-sm-12 form-group">
                <Siar:TextArea Label="Richiedi l'integrazione o la modifica della documentazione:" ID="txtNoteIntegrazioneAllegati" runat="server" NomeCampo="Richiedi l'integrazione o la modifica della documentazione"
                    Obbligatorio="false" Width="600px" Rows="4" ExpandableRows="5" MaxLength="10000" />
                <br />
            </div>
            <div class="col-sm-12 text-start">
                <Siar:Button ID="btnRichiediIntegrazioneAllegati" runat="server" Modifica="True"
                    OnClick="btnRichiediIntegrazioneAllegati_Click" Text="Richiedi integrazione" />
            </div>
        </div>
        <h3 class="pb-5 mt-5">Elenco delle richieste di certificazione e comunicazioni inviate
        </h3>
        <div class="col-sm-12">
            <Siar:DataGridAgid class="table table-striped" ID="dgComunicazioniInviate" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                PageSize="15">
                <ItemStyle Height="50px" />
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
        <div class="col-sm-12 text-end mt-5">
            <a id="btnBackDown" runat="server" class="btn btn-secondary py-1" onclick="javascript: location = 'CheckListPagamento.aspx'">
                <svg class="icon icon-breadcrumb icon-secondary icon-white me-1" aria-hidden="true">
                    <use href="/web/bootstrap-italia/svg/sprites.svg#it-check"></use>
                </svg>
                Torna alla checklist di pagamento</a>
        </div>
    </div>
</asp:Content>
