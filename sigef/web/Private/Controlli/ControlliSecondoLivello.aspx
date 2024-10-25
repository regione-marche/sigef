<%@ Page Title="" Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true" CodeBehind="ControlliSecondoLivello.aspx.cs" Inherits="web.Private.Controlli.ControlliSecondoLivello" %>

<%@ Register Src="../../CONTROLS/FirmaDocumento.ascx" TagName="FirmaDocumento" TagPrefix="uc3" %>
<%@ Register Src="../../CONTROLS/SiarNewTab.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>
<%@ Register Src="../../CONTROLS/SNCUploadFileControl.ascx" TagName="SNCUploadFileControl" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">
    <script type="text/javascript">
        function selezionaControllo(id) { $('[id$=hdnIdControllo]').val(id); swapTab(2); }

        function pulisciCampi() { $('[id$=btnNuovoPost]').click(); /*debugger;SNCUFRimuoviFile('ctl00_cphContenuto_ufcNAAllegato');*/ }

        function SNCVZCercaUtenti_onselect(obj) {
            if (obj) {
                $('[id$=hdnIdControllore]').val(obj.IdUtente);
                $('[id$=txtControllore_text]').val(obj.Nominativo);
            }
            else
                alert('L`elemento selezionato non è valido.');
        }

        function SNCVZCercaUtenti_onprepare() {
            $('[id$=hdnIdControllore]').val('');
        }

         function controlliSecondoLivello() {
            SNCVisualizzaReport('rptControlliSecondoLivello', 2, null);
        }

        function checkAlias() {
            var txtOperatoreAlias = $('[id$=txtControllore]').val();
            var IdUtenteAlias = $('[id$=hdnIdControllore]').val();

            if (txtOperatoreAlias == "" || IdUtenteAlias == "") {
                alert("Selezionare un controllore.");
                return false;
            }

            return true;
        }
    </script>
    <div style="display: none;">
        <asp:HiddenField ID="hdnIdControllo" runat="server" />
        <asp:Button ID="btnNuovoPost" runat="server" OnClick="btnNuovoPost_Click" />
    </div>
    <div class="dBox" id="divControlli">
        <uc1:SiarNewTab runat="server" ID="ucSiarNewTab" TabNames="Lista controlli di secondo livello|Nuovo controllo di secondo livello"
            Width="100%" />
        <div id="tbControlli" runat="server" class="tableTab" visible="false" width="100%">
            <div class="separatore" style="padding-bottom: 3px;">
                Lista controlli:
            </div>
            <div>
                <br />
                <input type="button" class="Button" value="Estrai in xls" style="width: 250px" onclick="return controlliSecondoLivello();" />
                <br />
                <br />
            </div>
            <Siar:DataGrid ID="dgControlli" runat="server" AutoGenerateColumns="False" Width="100%">
                <Columns>
                    <Siar:NumberColumn HeaderText="Nr.">
                        <ItemStyle Width="35px" HorizontalAlign="center" VerticalAlign="Middle"></ItemStyle>
                    </Siar:NumberColumn>
                    <asp:BoundColumn DataField="Asse" HeaderText="Asse">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Azione" HeaderText="Azione">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Intervento" HeaderText="Intervento">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
<%--                    <asp:BoundColumn DataField="DescrizioneIntervento" HeaderText="Descrizione intervento">
                        <ItemStyle HorizontalAlign="Center" />
                        <ItemStyle Width="300px" HorizontalAlign="Center" />
                    </asp:BoundColumn>--%>
                    <asp:BoundColumn DataField="IdProgetto" HeaderText="IdProgetto">
                        <ItemStyle Width="240px" HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <Siar:ColonnaLink IsJavascript="true" LinkFields="Id" LinkFormat="selezionaControllo({0});"
                        DataField="DataLottoCert" HeaderText="Data Lotto">
                        <ItemStyle Width="240px" HorizontalAlign="Center" />
                    </Siar:ColonnaLink>
                    <asp:BoundColumn DataField="IdLottoCert" HeaderText="Id lotto">
                        <ItemStyle Width="240px" HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="SpesaAmmessaIrregolare" HeaderText="Spesa ammessa irregolare">
                        <ItemStyle Width="240px" HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ContributoAmmessoIrregolare" HeaderText="Contributo ammesso irregolare">
                        <ItemStyle Width="240px" HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="DataControllo" HeaderText="Data controllo">
                        <ItemStyle Width="240px" HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Esito" HeaderText="Esito">
                        <ItemStyle Width="240px" HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Nominativo" HeaderText="Controllore">
                        <ItemStyle Width="240px" HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="SegnaturaVerbale" HeaderText="Segnatura verbale">
                        <ItemStyle Width="240px" HorizontalAlign="Center" />
                    </asp:BoundColumn>
                </Columns>
            </Siar:DataGrid>&nbsp;
        </div>
        <div id="tbNuovoControllo" runat="server" class="tableTab" visible="false" width="100%">
            <div>
                <div class="separatore" style="padding-bottom: 3px;">
                    Nuova controllo di secondo livello:
                </div>
                <div style="padding: 15px;" id="divMostraRichieste">
                    <div id="divRicercaRichieste" runat="server">
                        <div class="paragrafo_light">DATI DOMANDE DI AIUTO</div>
                        <br />
                        <div>
                            <br />
                            <b>Id Progetto:</b><br />
                            <Siar:TextBox ID="txtProgetto" runat="server" NomeCampo="Id Progetto" Width="150px" />
                            &nbsp;&nbsp;&nbsp;<Siar:Button ID="btnSearch" runat="server"
                                Text="Cerca certificazioni di spesa" Width="220px" CausesValidation="false" Modifica="True" OnClick="btnCercaProgetto_Click" /><br />
                        </div>
                        <div>
                            <br />
                            <b>Seleziona lotto di certificazione:</b><br />
                            <Siar:ComboCertSpProgetto ID="lstLottiCert" runat="server" NomeCampo="Lotto"></Siar:ComboCertSpProgetto>&nbsp;&nbsp;<Siar:Button ID="btnSelezionaLotto" runat="server"
                                Text="Visualizza domande di pagamento" Width="220px" CausesValidation="false" Modifica="True" OnClick="btnCercaDomande_Click" />
                        </div>
                        <div>
                            <br />
                            <b>Domande di pagamento presenti nel lotto:</b><br />
                            <asp:ListBox ID="lstDomandePagamento" Width="200" Height="200" runat="server"></asp:ListBox>
                        </div>
                        <div>
                            <br />
                            <b>Spesa ammessa:</b><br />
                            <Siar:DecimalBox ID="txtSpesaAmmessa" runat="server" Width="150px" Obbligatorio="true" NomeCampo="Spesa ammessa" ReadOnly="true" />
                        </div>
                        <div>
                            <br />
                            <b>Contributo rendicontato:</b><br />
                            <Siar:DecimalBox ID="txtContributoRendicontato" Width="150px" runat="server" Obbligatorio="true" NomeCampo="Contributo rendicontato" ReadOnly="true" />
                        </div>
                        <div>
                            <br />
                            <b>Spesa ammessa irregolare:</b><br />
                            <Siar:DecimalBox ID="txtSpesaIrregolare" Width="150px" Obbligatorio="true" NomeCampo="Spesa ammessa irregolare" runat="server" />
                        </div>
                        <div>
                            <br />
                            <b>Contributo ammesso irregolare:</b><br />
                            <Siar:DecimalBox ID="txtContributoIrregolare" Width="150px" Obbligatorio="true" NomeCampo="Contributo ammesso irregolare" runat="server" />
                        </div>
                        <div>
                            <br />
                            <b>Controllore:</b><br />
                            <Siar:TextBox ID="txtControllore" Width="200px" runat="server" Obbligatorio="true" NomeCampo="Controllore" />
                            <asp:HiddenField ID="hdnIdControllore" runat="server" />
                        </div>
                        <div>
                            <br />
                            <b>Data del controllo:</b><br />
                            <Siar:DateTextBox ID="txtDataControllo" Width="150px" Obbligatorio="true" NomeCampo="Data controllo" runat="server" />
                        </div>
                        <div>
                            <br />
                            <b>Esito:</b><br />
                            <asp:DropDownList ID="ddlEsito" runat="server" Obbligatorio="true">
                                <asp:ListItem Text="-- selezionare un esito --" Value="-1"></asp:ListItem>
                                <asp:ListItem Text="Positivo" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Parzialmente positivo" Value="2"></asp:ListItem>
                                <asp:ListItem Text="Negativo" Value="3"></asp:ListItem>
                                <asp:ListItem Text="Parzialmente negativo" Value="4"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div>
                            <br />
                            <b>Verbale</b><br />
                            <Siar:TextBox ID="txtSegnatura" runat="server" Width="300px" Obbligatorio="true" NomeCampo="Verbale" />
                            &nbsp;
                           
                            <Siar:Button ID="btnVerifica" runat="server" Modifica="False" Text="Verifica la segnatura"
                                Width="150px" OnClick="btnVerifica_Click" CausesValidation="False" OnClientClick="return ctrlSegnaturaEsterna(event);" />
                        </div>
                        <br />
                        <div class="first_elem_block">
                            <Siar:Button ID="btnNuovo" runat="server"
                                Text="Nuovo" Width="170px" CausesValidation="false" Modifica="True" OnClick="btnNuovo_Click" />
                            <Siar:Button ID="btnSave" runat="server"
                                Text="Salva" Width="170px" CausesValidation="true" Modifica="True" OnClick="btnSalvaControllo_Click" />
                            <Siar:Button ID="btnElimina" runat="server"
                                Text="Elimina" Width="170px" CausesValidation="false" Modifica="True" OnClick="btnElimina_Click" />

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
