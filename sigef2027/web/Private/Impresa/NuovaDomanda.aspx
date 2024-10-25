<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    CodeBehind="NuovaDomanda.aspx.cs" Inherits="web.Private.Impresa.NuovaDomanda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">
    <div class="row pb-5 mx-2">
        <h3 class="pb-5">CONFERMA DELL&#39;INSERIMENTO DI UNA NUOVA DOMANDA DI AIUTO</h3>
        <h4 class="pb-5 text-center">SI STA PER INSERIRE LA DOMANDA DI ADESIONE AL BANDO:</h4>
        <div class="col-sm-12">
            <Siar:DataGridAgid CssClass="table table-striped" ID="dgBandi" runat="server" AutoGenerateColumns="False" Width="100%">                    
                    <Columns>
                        <Siar:JsButtonColumn Arguments="IdBando" ButtonImage="Info.ico" ButtonType="ImageButton"
                            ButtonText="Info sul bando" JsFunction="mostraPopupDocumentiBando">
                            <ItemStyle HorizontalAlign="center" />
                        </Siar:JsButtonColumn>
                        <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Ente" HeaderText="Emesso da">
                            <ItemStyle HorizontalAlign="center"/>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Importo" HeaderText="Importo" DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="center"/>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="DataScadenza" HeaderText="Scadenza">
                            <ItemStyle HorizontalAlign="center"/>
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGridAgid>
        </div>
        <h4 class="pb-5 text-center">CONTINUARE?</h4>
        <div class="col-sm-12">
            <Siar:Button ID="btnConferma" runat="server" OnClick="btnConferma_Click" Text="Conferma"
                     Modifica="True" />
                <input class="btn btn-secondary py-1" type="button" value="Indietro"
                    onclick="history.back();" />
        </div>
    </div>
     <div id="divDocumentiBando" class="modal it-dialog-scrollable" tabindex="-1" role="dialog" style="position: absolute; display: none">
        <div class="modal-dialog modal-lg" role="document">
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
</asp:Content>
