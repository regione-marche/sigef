<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true" CodeBehind="Rinunce.aspx.cs" Inherits="web.Private.Controlli.Rinunce" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">
    
    <style type="text/css">

        h1 {
            display: block;
            font-size: 22px;/*font-size: 2em;*/
            margin-top: 10px;/*margin-top: 0.67em;*/
            margin-bottom: 10px;/*margin-bottom: 0.67em;*/
            margin-left: 10px;
            margin-right: 0;
            font-weight: bold;
        }

        .first_elem_block {
            /*width: 250px;*/
            display: inline-block;
            *display: inline;
            zoom: 1;
            padding-bottom: 5px;
        }

        .elem_block {
            /*width: 250px;*/
            vertical-align: top;
            display: inline-block;
            *display: inline;
            zoom: 1;
            padding-left: 20px;
            padding-bottom: 5px;
        }

        .paragrafo_light {
            border-bottom: solid 1px #084600;
            font-size: 14px;
        }

        .box_ricerca {
            background-color: #cfcfd6; 
            padding: 7px;
        }

        label {
            display: inline;
            float: left;
            min-width: 200px;
            max-width: 200px;
            width: 200px;
            text-align: right;
            vertical-align: middle;
        }

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

    <div id="divRiepilogoRinuncia" runat="server">
        <div style="text-align: center;">
            <h1>Scheda Rinuncia</h1>
        </div>
        <div id="tdDomanda" runat="server" style="margin: 10px; text-align: center;">
        </div>

        <div id="divDatiRinuncia" runat="server" class="dBox" style="margin-top: 10px; margin-bottom: 10px;">
            <div class="separatore" style="padding-bottom: 3px;">
                Rinuncia
            </div>
            <div id="divMostraRinuncia" style="padding: 15px;">
                <div class="first_elem_block">
                    <label>ID Rinuncia:</label>
                    <div class="value">
                        <Siar:TextBox ID="txtIdRinuncia" runat="server" ReadOnly="true" Enabled="false" Width="120px"></Siar:TextBox>
                    </div>
                </div>
                <br />
                <br />
                
                <div class="first_elem_block">
                    <label>ID Progetto:</label>
                    <div class="value">
                        <Siar:TextBox ID="txtIdProgetto" runat="server" ReadOnly="true" Enabled="false" Width="120px"></Siar:TextBox>
                    </div>
                </div>
                <br />
                <br />

                <div class="first_elem_block">
                    <label>Data Rinuncia:</label>
                    <div class="value">
                        <Siar:DateTextBox ID="txtDataRinuncia" runat="server" Width="120px" />
                    </div>
                </div>
                <br />
                <br />

                <label>Beneficiari Rinunciatari:</label>
                <br />
                <Siar:DataGrid ID="dgBeneficiario" runat="server" AutoGenerateColumns="false" Width="100%">
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
                        <Siar:CheckColumn DataField="IdImpresa" Name="chkIncludi"  HeaderText="">
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                        </Siar:CheckColumn>
                    </Columns>
                </Siar:DataGrid>
                <br />
                <br />
                

                <div id="divProtocolli" runat="server" style="display: none;">
                    <div class="paragrafo">Protocolli di comunicazione rinuncia</div>
                    <br />

                    <div class="first_elem_block">
                        <label>Protocollo:</label>
                        <div class="value">
                            <Siar:TextBox ID="txtProtocollo" runat="server" Width="160px"></Siar:TextBox>
                        </div>
                    </div>
                    <div class="elem_block">
                        <Siar:Button ID="btnAggiungiProtocollo" runat="server" Width="120px" Text="Salva Protocollo"
                            OnClick="btnAggiungiProtocollo_Click" CausesValidation="false" OnClientClick="return verificaProtocolloNonVuoto();"></Siar:Button>
                    </div>
                    <br />
                    <br />

                    <asp:Label ID="lblDgProtocolli" runat="server" Text="" Font-Size="Smaller"></asp:Label>
                    <br />
                    <Siar:DataGrid ID="dgProtocolli" runat="server" AutoGenerateColumns="false" Width="100%">
                        <ItemStyle Height="30px" />
                        <Columns>
                            <asp:BoundColumn DataField="Protocollo" HeaderText="Decreto">
                                <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                            </asp:BoundColumn>
                            <Siar:JsButtonColumn Arguments="Protocollo" ButtonText="Visualizza" JsFunction="sncAjaxCallVisualizzaProtocollo">
                                <ItemStyle HorizontalAlign="Center" Width="150px" />
                            </Siar:JsButtonColumn>
                            <Siar:JsButtonColumn Arguments="IdRinunciaProtocollo" ButtonText="Elimina" JsFunction="eliminaProtocollo">
                                <ItemStyle HorizontalAlign="Center" Width="150px" />
                            </Siar:JsButtonColumn>
                        </Columns>
                    </Siar:DataGrid>
                    <br />
                    <br />
                    
                </div>

                <div class="paragrafo">Elenco domande di pagamento certificate per successivo ritiro</div>
                <br />
                <div id="divGestioneCertificazione" runat="server" visible="false">
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
                <div id="divTestaElenco" class="dContenuto" runat="server" visible="false">
                    <Siar:DataGrid ID="dgTesta" runat="server" AutoGenerateColumns="false" Width="100%" ShowFooter="true" FooterStyle-CssClass="TotaliFooter">
                        <ItemStyle Height="24px" />
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
                    </Siar:DataGrid>
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
            </div>
        </div>
        <div class="first_elem_block" style="padding-left: 20px;">
            <Siar:Button ID="btnSalvaRinuncia" runat="server" Width="150px" Text="Salva Rinuncia"
                OnClick="btnSalvaRinuncia_Click" CausesValidation="false"></Siar:Button>
        </div>
        <div class="elem_block">
            <Siar:Button ID="btnEliminaRinuncia" runat="server" Width="150px" Text="Elimina Rinuncia" OnClientClick="if(!confermaElimina()) return false;"
                OnClick="btnEliminaRinuncia_Click" CausesValidation="false"></Siar:Button>
        </div>
        <div class="elem_block">
            <Siar:Button ID="btnIndietro" runat="server" Width="150px" OnClick="btnIndietro_Click" Text="Indietro" CausesValidation="false" />
        </div>
    </div>
</asp:Content>
