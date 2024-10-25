<%@ Page Title="" Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true" CodeBehind="ControlliSecondoLivello.aspx.cs" Inherits="web.Private.Controlli.ControlliSecondoLivello" %>

<%@ Register Src="../../CONTROLS/FirmaDocumento.ascx" TagName="FirmaDocumento" TagPrefix="uc3" %>
<%@ Register Src="../../CONTROLS/SiarNewTabAgid.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>
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
    <div id="divControlli" class="row pt-5 mx-2 bd-form">
        <uc1:SiarNewTab runat="server" ID="ucSiarNewTab" TabNames="Lista controlli di secondo livello|Nuovo controllo di secondo livello" />
        <div id="tbControlli" runat="server" class="tableTab pt-5" visible="false">
            <%--<div class="separatore" style="padding-bottom: 3px;">
                Lista controlli:
            </div>--%>
            <div class="row p-2">
                <div class="col-md-12" style="text-align: end;" visible="true">
                    <input type="button" class="btn btn-primary" value="Estrai in xls" onclick="return estraiInXls();" />
                </div>
            </div>
            <div class="row p-2">
                <div class="col-12">
                    <div class="table-responsive">
                        <Siar:DataGridAgid ID="dgControlli" runat="server" AutoGenerateColumns="False" ShowFooter="true" CssClass="table table-striped" PageSize="20">
                            <HeaderStyle  CssClass="headerStyle" />
                               <ItemStyle CssClass="DataGridRow itemStyle" />
                            <AlternatingItemStyle CssClass="itemStyle" /> 
                            <Columns>
                                <Siar:NumberColumn HeaderText="Nr." HeaderStyle-Font-Size="Small" ItemStyle-CssClass="fw-semibold" ItemStyle-Font-Size="Small">
                                    <ItemStyle Width="35px" HorizontalAlign="center" VerticalAlign="Middle"></ItemStyle>
                                </Siar:NumberColumn>
                                <asp:BoundColumn HeaderStyle-Font-Size="Small" ItemStyle-CssClass="fw-semibold" ItemStyle-Font-Size="Small" DataField="Asse" HeaderText="Asse">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderStyle-Font-Size="Small" ItemStyle-CssClass="fw-semibold" ItemStyle-Font-Size="Small" DataField="Azione" HeaderText="Azione">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderStyle-Font-Size="Small" ItemStyle-CssClass="fw-semibold" ItemStyle-Font-Size="Small" DataField="Intervento" HeaderText="Intervento">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <%--                    <asp:BoundColumn DataField="DescrizioneIntervento" HeaderText="Descrizione intervento">
                        <ItemStyle HorizontalAlign="Center" />
                        <ItemStyle Width="300px" HorizontalAlign="Center" />
                    </asp:BoundColumn>--%>
                                <asp:BoundColumn HeaderStyle-Font-Size="Small" ItemStyle-CssClass="fw-semibold" ItemStyle-Font-Size="Small" DataField="IdProgetto" HeaderText="IdProgetto">
                                    <ItemStyle Width="240px" HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <Siar:ColonnaLink HeaderStyle-Font-Size="Small" ItemStyle-CssClass="fw-semibold" ItemStyle-Font-Size="Small" IsJavascript="true" LinkFields="Id" LinkFormat="selezionaControllo({0});"
                                    DataField="DataLottoCert" HeaderText="Data Lotto">
                                    <ItemStyle Width="240px" HorizontalAlign="Center" />
                                </Siar:ColonnaLink>
                                <asp:BoundColumn HeaderStyle-Font-Size="Small" ItemStyle-CssClass="fw-semibold" ItemStyle-Font-Size="Small" DataField="IdLottoCert" HeaderText="Id lotto">
                                    <ItemStyle Width="240px" HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderStyle-Font-Size="Small" ItemStyle-CssClass="fw-semibold" ItemStyle-Font-Size="Small" DataField="SpesaAmmessaIrregolare" HeaderText="Spesa ammessa irregolare">
                                    <ItemStyle Width="240px" HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderStyle-Font-Size="Small" ItemStyle-CssClass="fw-semibold" ItemStyle-Font-Size="Small" DataField="ContributoAmmessoIrregolare" HeaderText="Contributo ammesso irregolare">
                                    <ItemStyle Width="240px" HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderStyle-Font-Size="Small" ItemStyle-CssClass="fw-semibold" ItemStyle-Font-Size="Small" DataField="DataControllo" HeaderText="Data controllo">
                                    <ItemStyle Width="240px" HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderStyle-Font-Size="Small" ItemStyle-CssClass="fw-semibold" ItemStyle-Font-Size="Small" DataField="Esito" HeaderText="Esito">
                                    <ItemStyle Width="240px" HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderStyle-Font-Size="Small" ItemStyle-CssClass="fw-semibold" ItemStyle-Font-Size="Small" DataField="Nominativo" HeaderText="Controllore">
                                    <ItemStyle Width="240px" HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderStyle-Font-Size="Small" ItemStyle-CssClass="fw-semibold" ItemStyle-Font-Size="Small" DataField="SegnaturaVerbale" HeaderText="Segnatura verbale">
                                    <ItemStyle Width="240px" HorizontalAlign="Center" />
                                </asp:BoundColumn>
                            </Columns>
                        </Siar:DataGridAgid>
                    </div>
                </div>
            </div>
        </div>
        <div id="tbNuovoControllo" class="tableTab pt-5"  runat="server"  visible="false">
            <h4 class="pb-5">Controllo di secondo livello (Nuovo)</h4>

            <h5 class="pb-5">Dati domande di aiuto</h5>
     
            <div class="d-flex flex-row justify-content-start align-items-center py-2">
                 <div class="flex-column">
                      <div class="d-flex flex-row justify-content-start align-items-center py-4">
                        <div class="flex-column  mx-2">
                            <label class="active fw-semibold" for="txtProgetto">Id Progetto:</label>
                            <Siar:TextBox  ID="txtProgetto" runat="server" NomeCampo="Id Progetto" />
                        </div>
                        <div class="flex-column pt-4 mx-2">
                            <Siar:Button ID="btnSearch" runat="server" Text="Cerca certificazioni di spesa" CausesValidation="false" Modifica="True" OnClick="btnCercaProgetto_Click" />
                        </div>
                      </div>
                      <div class="d-flex flex-row justify-content-start align-items-center py-4">
                        <div class="flex-column  mx-2">
                            <label class="active fw-semibold" for="lstLottiCert">Seleziona lotto di certificazione</label>
                            <Siar:ComboCertSpProgetto ID="lstLottiCert" runat="server" NomeCampo="Lotto"></Siar:ComboCertSpProgetto>
                        </div>
                        <div class="flex-column pt-4  mx-2">                            
                            <Siar:Button ID="btnSelezionaLotto" runat="server" Text="Visualizza domande di pagamento" CausesValidation="false" Modifica="True" OnClick="btnCercaDomande_Click" />
                      </div>
                    </div>
                  </div>
                <div class="flex-column mx-5">
                    <div class="row justify-content-start align-items-center py-2">
                        <div class="flex-column m-2">
                            <label class="active fw-semibold" for="lstDomandePagamento">Domande di pagamento presenti nel lotto</label>
                        </div>
                        <div class="flex-column m-2">
                            <asp:ListBox ID="lstDomandePagamento" Width="100px"  runat="server"></asp:ListBox>
                        </div>
                    </div>
                </div>
            </div>
          






             <%--   <div class="col-1">
                    <label class="active fw-semibold" for="txtProgetto">Id Progetto:</label>
                    <Siar:TextBox  ID="txtProgetto" runat="server" NomeCampo="Id Progetto" />
                </div>
                <div class="col-2 pt-4 mx-2">
                    <Siar:Button ID="btnSearch" runat="server" Text="Cerca certificazioni di spesa" CausesValidation="false" Modifica="True" OnClick="btnCercaProgetto_Click" />
                </div>
                <div class="col-2">
                    <label class="active fw-semibold" for="lstLottiCert">Seleziona lotto di certificazione</label>
                    <Siar:ComboCertSpProgetto ID="lstLottiCert" runat="server" NomeCampo="Lotto"></Siar:ComboCertSpProgetto>
                </div>
                <div class="col-2 pt-4 mx-2">
                    <Siar:Button ID="btnSelezionaLotto" runat="server" Text="Visualizza domande di pagamento" CausesValidation="false" Modifica="True" OnClick="btnCercaDomande_Click" />
                </div>
                <div class="col-5 p-2">--%>
                    
               <%-- </div>
                <div class="col-5 p-2">--%>

                <%-- <asp:ListBox  ID="lstDomandePagamento"  DataTextField="Domande di pagamento presenti nel lotto" runat="server"></asp:ListBox>
                   <label class="active fw-semibold" for="lstDomandePagamento">Domande di pagamento presenti nel lotto</label>
                </div>
            </div>
            <%--<div class="d-flex flex-row justify-content-start align-items-center">

                <div class="col-2 p-2">
                    <label class="active fw-semibold" for="lstDomandePagamento">Domande di pagamento presenti nel lotto</label>
                </div>
                <div class="col-5 p-2">
                    <asp:ListBox ID="lstDomandePagamento" runat="server"></asp:ListBox>
                </div>
            </div>--%>
     
           
           <div class="d-flex  justify-content-start py-2">
                <div class="p-2">
                    <label class="active fw-semibold" for="txtSpesaAmmessa">Spesa ammessa</label>
                    <Siar:DecimalBox ID="txtSpesaAmmessa" runat="server" Obbligatorio="true" NomeCampo="Spesa ammessa" ReadOnly="true" />
                </div>
                <div class="p-2">
                    <label class="active fw-semibold" for="txtContributoRendicontato">Contributo rendicontato</label>
                    <Siar:DecimalBox ID="txtContributoRendicontato"  runat="server" Obbligatorio="true" NomeCampo="Contributo rendicontato" ReadOnly="true" />
                </div>
                <div class="p-2">
                    <label class="active fw-semibold" for="txtSpesaIrregolare">Spesa ammessa irregolare</label>
                    <Siar:DecimalBox ID="txtSpesaIrregolare" Obbligatorio="true" NomeCampo="Spesa ammessa irregolare" runat="server" />
                </div>
                <div class="p-2">
                    <label class="active fw-semibold" for="txtContributoIrregolare">Contributo ammesso irregolare</label>
                    <Siar:DecimalBox ID="txtContributoIrregolare" Obbligatorio="true" NomeCampo="Contributo ammesso irregolare" runat="server" />
                </div>
                <div class="p-2">
                        <label class="active fw-semibold" for="txtControllore">Controllore</label>
                        <Siar:TextBox  ID="txtControllore" runat="server" Obbligatorio="true" NomeCampo="Controllore" />
                        <asp:HiddenField ID="hdnIdControllore" runat="server" />
                </div>
            </div>
        
            <div class="d-flex align-items-center">
                <div class="p-2">
                    <label class="active fw-semibold" for="txtDataControllo">Data del controllo</label>
                    <Siar:DateTextBox ID="txtDataControllo"  Obbligatorio="true" NomeCampo="Data controllo" runat="server" />
                </div>
                 <div class="p-2">
                    <label class="active fw-semibold" for="ddlEsito">Esito</label>
                    <asp:DropDownList ID="ddlEsito" runat="server" Obbligatorio="true">
                        <asp:ListItem Text="-- selezionare un esito --" Value="-1"></asp:ListItem>
                        <asp:ListItem Text="Positivo" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Parzialmente positivo" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Negativo" Value="3"></asp:ListItem>
                        <asp:ListItem Text="Parzialmente negativo" Value="4"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="p-2">
                    <label class="active fw-semibold" for="txtSegnatura">Verbale</label>
                    <asp:TextBox CssClass="rounded" ID="txtSegnatura"  runat="server" style="width:400px" Obbligatorio="true" NomeCampo="Verbale" />                   
                 </div>
                  <div class="p-2">
                     <Siar:Button ID="btnVerifica" runat="server" Modifica="False" Text="Verifica la segnatura" OnClick="btnVerifica_Click" CausesValidation="False" OnClientClick="return ctrlSegnaturaEsterna(event);" />
                        <Siar:Button ID="btnNuovo" runat="server" Text="Nuovo" CausesValidation="false" Modifica="True" OnClick="btnNuovo_Click" />
                        <Siar:Button ID="btnSave" runat="server" Text="Salva" CausesValidation="true" Modifica="True" OnClick="btnSalvaControllo_Click" />
                        <Siar:Button ID="btnElimina" runat="server" Text="Elimina" CausesValidation="false" Modifica="True" OnClick="btnElimina_Click" />
                    </div>
              </div>
          </div>
        </div>

</asp:Content>
