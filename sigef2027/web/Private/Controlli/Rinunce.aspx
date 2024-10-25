<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true" CodeBehind="Rinunce.aspx.cs" Inherits="web.Private.Controlli.Rinunce" %> 
<%@ Register Src="~/CONTROLS/ucGestioneLavori.ascx" TagName="GestioneLavori" TagPrefix="uc1" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server"> 
 
    <style type="text/css"> 
        .value { 
            float: right; 
            margin-left: 5px; 
        } 
 
        .nascondi { 
            display: none; 
        } 
    </style> 
 
    <script type="text/javascript"> 
 
        function confermaElimina() { 
            var r = confirm("Eliminare la rinuncia?"); 
            if (r == true) { 
                return true; 
            } else { 
                return false; 
            } 
        } 
 
        function eliminaProtocollo(idRinunciaProtocollo) { 
            $('[id$=hdnIdRinunciaProtocollo]').val(idRinunciaProtocollo); 
            $('[id$=btnEliminaProtocollo]').click(); 
        } 
 
        function visualizzaProtocollo(protocollo) { 
            sncAjaxCallVisualizzaProtocollo($(protocollo)); 
        } 
 
        function verificaProtocolloNonVuoto() { 
            var value = $('[id$=txtProtocollo]').val(); 
 
            if (value === '' || value === null) { 
                alert("Il protocollo non può essere vuoto."); 
                return false; 
            } 
            else 
                return true; 
        } 
 
    </script> 
 
    <div style="display: none"> 
        <asp:HiddenField ID="hdnIdRinunciaProtocollo" runat="server" /> 
        <asp:Button ID="btnEliminaProtocollo" runat="server" OnClick="btnEliminaProtocollo_Click" CausesValidation="false" /> 
    </div> 
 
    <div class="row" id="divRiepilogoRinuncia" runat="server"> 
        <h3 class="mt-5 pb-5">Scheda Rinuncia 
        </h3> 
        <div id="tdDomanda" runat="server" class="row"> 
        </div> 
 
        <div id="divDatiRinuncia" runat="server" class="row bd-form"> 
            <h4 class="mt-5 pb-5">Rinuncia 
            </h4> 
            <div class="col-sm-4 form-group"> 
                <Siar:TextBox  Label="ID Rinuncia:" ID="txtIdRinuncia" runat="server" ReadOnly="true" Enabled="false"></Siar:TextBox> 
            </div> 
 
            <div class="col-sm-4 form-group"> 
                <Siar:TextBox  Label="ID Progetto:" ID="txtIdProgetto" runat="server" ReadOnly="true" Enabled="false"></Siar:TextBox> 
            </div> 
 
            <div class="col-sm-4 form-group"> 
                <Siar:DateTextBox Label="Data Rinuncia:" ID="txtDataRinuncia" runat="server" /> 
            </div> 
        </div> 
        <h4 class="mt-5 pb-5">Beneficiari Rinunciatari: 
        </h4> 
        <div class="col-sm-12"> 
            <Siar:DataGridAgid CssClass="table table-striped" ID="dgBeneficiario" runat="server" AutoGenerateColumns="false"> 
                <ItemStyle Height="30px" /> 
                <Columns> 
                    <asp:BoundColumn DataField="IdImpresa" HeaderText="Id Impresa"> 
                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" /> 
                    </asp:BoundColumn> 
                    <asp:BoundColumn DataField="CodiceFiscale" HeaderText="Codice Fiscale"> 
                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" /> 
                    </asp:BoundColumn> 
                    <asp:BoundColumn DataField="RagioneSociale" HeaderText="Ragione Sociale"> 
                        <ItemStyle HorizontalAlign="Center" /> 
                    </asp:BoundColumn> 
                    <Siar:CheckColumnAgid DataField="IdImpresa" Name="chkIncludi" HeaderText=""> 
                        <ItemStyle HorizontalAlign="Center" /> 
                    </Siar:CheckColumnAgid> 
                </Columns> 
            </Siar:DataGridAgid> 
        </div> 
        <div id="divProtocolli" runat="server" style="display: none;"> 
            <h4 class="mt-5 pb-5">Protocolli di comunicazione rinuncia 
            </h4> 
 
            <div class="col-sm-6 form-group"> 
                <Siar:TextBox  ID="txtProtocollo" Label="Protocollo:" runat="server"></Siar:TextBox> 
            </div> 
 
            <div class="col-sm-6"> 
                <Siar:Button ID="btnAggiungiProtocollo" runat="server" Text="Salva Protocollo" 
                    OnClick="btnAggiungiProtocollo_Click" CausesValidation="false" OnClientClick="return verificaProtocolloNonVuoto();"></Siar:Button> 
            </div> 
            <div class="col-sm-12"> 
                <p> 
                    <asp:Label ID="lblDgProtocolli" runat="server" Text="" Font-Size="Smaller"></asp:Label> 
                </p> 
                <Siar:DataGridAgid CssClass="table table-striped" ID="dgProtocolli" runat="server" AutoGenerateColumns="false"> 
                    <Columns> 
                        <asp:BoundColumn DataField="Protocollo" HeaderText="Decreto"> 
                            <ItemStyle HorizontalAlign="Center" Font-Bold="true" /> 
                        </asp:BoundColumn> 
                        <Siar:JsButtonColumnAgid Arguments="Protocollo" ButtonText="Visualizza" JsFunction="sncAjaxCallVisualizzaProtocollo"> 
                            <ItemStyle HorizontalAlign="Center" /> 
                        </Siar:JsButtonColumnAgid> 
                        <Siar:JsButtonColumnAgid Arguments="IdRinunciaProtocollo" ButtonText="Elimina" JsFunction="eliminaProtocollo"> 
                            <ItemStyle HorizontalAlign="Center" /> 
                        </Siar:JsButtonColumnAgid> 
                    </Columns> 
                </Siar:DataGridAgid> 
            </div> 
        </div> 
        <h4 class="mt-5 pb-5">Elenco domande di pagamento certificate per successivo ritiro</h4> 
        <div id="divGestioneCertificazione" runat="server" class="row" visible="false"> 
            <!-- Lotti --> 
            <%--<div id="divTestaElenco" class="dContenuto" runat="server" visible="false"> 
                        <Siar:DataGrid ID="dgTesta" runat="server" AutoGenerateColumns="false" Width="100%"> 
                            <ItemStyle Height="24px" /> 
                            <Columns> 
                                <asp:BoundColumn DataField="Idcertsp" HeaderText="Id Lotto"></asp:BoundColumn> 
                                <asp:BoundColumn DataField="Datainizio" HeaderText="Data Inizio"></asp:BoundColumn> 
                                <asp:BoundColumn DataField="Datafine" HeaderText="Data Fine"></asp:BoundColumn> 
                                <asp:BoundColumn DataField="Tipo" HeaderText="Tipo"></asp:BoundColumn> 
                                <asp:BoundColumn DataField="Definitivo" HeaderText="Definitivo"></asp:BoundColumn> 
                                <asp:BoundColumn DataField="Idcertsp" HeaderText="Domanda di pagamento"></asp:BoundColumn> 
                                <asp:BoundColumn DataField="Idcertsp" HeaderText="Importo Certificazione"></asp:BoundColumn> 
                                <asp:BoundColumn DataField="Idcertsp" HeaderText="Importo da ritirare"></asp:BoundColumn> 
                            </Columns> 
                        </Siar:DataGrid> 
                    </div>--%> 
            <div id="divTestaElenco" class="col-sm-12" runat="server" visible="false"> 
                <Siar:DataGridAgid CssClass="table table-striped" ID="dgTesta" runat="server" AutoGenerateColumns="false" ShowFooter="true" FooterStyle-CssClass="TotaliFooter"> 
                    <Columns> 
                        <%--<asp:BoundColumn DataField="CodPsr" HeaderText="Programma"></asp:BoundColumn>--%> 
                        <asp:BoundColumn DataField="IdCertSp" HeaderText="Id Lotto"></asp:BoundColumn> 
                        <asp:BoundColumn DataField="IdcertspDettaglio" HeaderText="Data Inizio"></asp:BoundColumn> 
                        <asp:BoundColumn DataField="Datafine" HeaderText="Data Fine"></asp:BoundColumn> 
                        <asp:BoundColumn DataField="Tipo" HeaderText="Tipo"></asp:BoundColumn> 
                        <asp:BoundColumn DataField="Definitivo" HeaderText="Definitivo"></asp:BoundColumn> 
                        <asp:BoundColumn DataField="IdcertspDettaglio" HeaderText="Domanda di pagamento"></asp:BoundColumn> 
                        <asp:BoundColumn DataField="IdcertspDettaglio" HeaderText="Importo Certificazione"> 
                            <ItemStyle HorizontalAlign="Right" /> 
                        </asp:BoundColumn> 
                        <asp:BoundColumn DataField="IdcertspDettaglio" HeaderText="Importo liquidato beneficiario"></asp:BoundColumn> 
                        <%--<Siar:NewImportoColumn DataField="IdcertspDettaglio" HeaderText="Importo rinuncia domanda"></Siar:NewImportoColumn>--%> 
                        <asp:BoundColumn HeaderText="Importo rinuncia domanda"></asp:BoundColumn> 
                    </Columns> 
                </Siar:DataGridAgid> 
            </div> 
        </div> 
        <%--<label id="lblDomandeDecertificare" style="width: auto; min-width: inherit; max-width: inherit; padding-left: 100px" runat="server">(L'elenco viene aggiornato ad ogni salvataggio)</label> 
                <Siar:DataGrid ID="dgDomandeDecertificare" runat="server" AutoGenerateColumns="false" Width="100%"> 
                    <ItemStyle Height="30px" /> 
                    <Columns> 
                        <asp:BoundColumn DataField="IdCertSp" HeaderText="Id Certificazione Spesa"> 
                            <ItemStyle HorizontalAlign="Center" Font-Bold="true" /> 
                        </asp:BoundColumn> 
                        <asp:BoundColumn DataField="IdProgetto" HeaderText="Id Progetto"> 
                            <ItemStyle HorizontalAlign="Center" Font-Bold="true" /> 
                        </asp:BoundColumn> 
                        <asp:BoundColumn DataField="IdDomandaPagamento" HeaderText=""> 
                            <ItemStyle HorizontalAlign="Center" /> 
                        </asp:BoundColumn> 
                        <asp:BoundColumn DataField="Beneficiario" HeaderText=""> 
                            <ItemStyle HorizontalAlign="Center" /> 
                        </asp:BoundColumn> 
                    </Columns> 
                </Siar:DataGrid>--%> 
        <div class="col-sm-12 pb-5"> 
            <Siar:Button ID="btnSalvaRinuncia" runat="server" Text="Salva Rinuncia" 
                OnClick="btnSalvaRinuncia_Click" CausesValidation="false"></Siar:Button> 
            <Siar:Button ID="btnEliminaRinuncia" runat="server" Text="Elimina Rinuncia" OnClientClick="if(!confermaElimina()) return false;" 
                OnClick="btnEliminaRinuncia_Click" CausesValidation="false"></Siar:Button> 
            <Siar:Button ID="btnIndietro" runat="server" OnClick="btnIndietro_Click" Text="Indietro" CausesValidation="false" /> 
        </div> 
    </div> 
</asp:Content> 
