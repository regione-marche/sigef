<%@ Page Title="" Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    CodeBehind="Psr.aspx.cs" Inherits="web.Private.regione.zProgrammazione" %>

<%@ Register Src="../../../CONTROLS/SiarNewTabAgid.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <script type="text/javascript">
        function selezionaPsr(codice) { $('[id$=hdnCodicePsr]').val(codice); swapTab(1); }
        function modificaPsr(codice) { $('[id$=hdnCodicePsr]').val(codice); swapTab(2); }
        function selezionaPsrAlbero(codice) { $('[id$=hdnCodicePsrAlbero]').val(codice); swapTab(2); }
        function espandiProgrammazionePost() { var codici_espansi = $('[id$=hdnDgProgrammazioneEspansione]').val().split('|'); $('[id$=hdnDgProgrammazioneEspansione]').val(''); for (var i = 0; i < codici_espansi.length; i++) espandiProgrammazione(codici_espansi[i]); }
        function espandiProgrammazione(path_label) {
            var tr = $('[PathLabel=' + path_label + ']'), espandi = !eval($(tr).attr("ElemEspanso")); var arr = $('[PathLabel^=' + path_label + '][PathLabel!=' + path_label + ']');
            for (var i = 0; i < arr.length; i++) { var pl = $(arr[i]).attr('PathLabel'); if (espandi == true) { if (pl.length == path_label.length + 1) arr[i].style.display = ''; } else { arr[i].style.display = 'none'; $(arr[i]).attr("ElemEspanso", false); aggiornaHiddenEspansione($(arr[i]).attr("PathLabel"), false); } }
            $(tr).attr("ElemEspanso", espandi); aggiornaHiddenEspansione(path_label, espandi);
        }
        function aggiornaHiddenEspansione(path_label, insert) { if (path_label != '') { var codici_espansi = $('[id$=hdnDgProgrammazioneEspansione]').val().split('|'); if (insert == true) codici_espansi.push(path_label); else if (codici_espansi.indexOf(path_label) >= 0) codici_espansi.splice(codici_espansi.indexOf(path_label), 1); $('[id$=hdnDgProgrammazioneEspansione]').val(codici_espansi.join('|')); } }
        function mostraDettaglioProgrammazione(id_programmazione) { $('[id$=hdnIdProgrammazione]').val(id_programmazione); swapTab(1); }
        function chiudiDettaglioProgrammazione() { $('[id$=hdnIdProgrammazione]').val(''); chiudiPopupTemplate(); }
        function nuovoSEProgrammazione() { $('[id$=txtDPSEDescrizione_text]').val(''); $('[id$=txtDPSECodice_text]').val(''); }
    </script>

    <asp:HiddenField ID="hdnCodicePsr" runat="server" />
    <asp:HiddenField ID="hdnIdProgrammazione" runat="server" />
    <asp:HiddenField ID="hdnCodicePsrAlbero" runat="server" />
    <asp:HiddenField ID="hdnDgProgrammazioneEspansione" runat="server" />
    <uc1:SiarNewTab ID="ucSiarNewTab" runat="server" TabNames="PROGRAMMAZIONE|Modifica programma" />
    <div id="tableElenco" runat="server" class="row">
        <div class="col-sm-12">
            <Siar:DataGridAgid ID="dgPsr" runat="server" AutoGenerateColumns="False" CssClass="table table-striped">
                <Columns>
                    <Siar:NumberColumnAgid>
                    </Siar:NumberColumnAgid>
                    <asp:BoundColumn DataField="Descrizione"></asp:BoundColumn>
                    <asp:BoundColumn DataField="AnnoDa" HeaderText="Anno da">
                        <ItemStyle Width="90px" HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="AnnoA" HeaderText="Anno a">
                        <ItemStyle Width="90px" HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Cci" HeaderText="CCI"></asp:BoundColumn>
                    <Siar:JsButtonColumnAgid Arguments="Codice" JsFunction="selezionaPsr" ButtonText="Programmazione">
                        <ItemStyle Width="150px" HorizontalAlign="Center" />
                    </Siar:JsButtonColumnAgid>
                    <Siar:JsButtonColumnAgid Arguments="Codice" JsFunction="modificaPsr" ButtonText="Modifica">
                        <ItemStyle Width="150px" HorizontalAlign="Center" />
                    </Siar:JsButtonColumnAgid>
                </Columns>
            </Siar:DataGridAgid>
        </div>
        <div class="col-sm-12" id="trProgrammazione" runat="server">
            <h3 class="pb-5 mt-5">Programmazione:</h3>
            <div class="col-sm-12 text-center">
                <input type="button" class="btn btn-secondary py-1" value="Aggiungi elemento di primo livello" onclick='mostraDettaglioProgrammazione(0);'/>
            </div>
            <div class="col-sm-12">
                <Siar:DataGridAgid ID="dgProgrammazione" runat="server" AutoGenerateColumns="False" CssClass="table table-striped">
                    <Columns>
                        <asp:BoundColumn HeaderText="Descrizione"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Tipo" HeaderText="Livello">
                            <ItemStyle Width="100px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="AttivazioneBandi" HeaderText="Attivazione bandi" DataFormatString="{0:X|}">
                            <ItemStyle Width="70px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="AttivazioneFa" HeaderText="Aggancio Focus Area" DataFormatString="{0:X|}">
                            <ItemStyle Width="70px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="AttivazioneObMisura" HeaderText="Obiettivi di Misura"
                            DataFormatString="{0:X|}">
                            <ItemStyle Width="70px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="AttivazioneInvestimenti" HeaderText="Aggancio Investimenti"
                            DataFormatString="{0:X|}">
                            <ItemStyle Width="70px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="AttivazioneFF" HeaderText="Aggancio Fonti Finanziarie"
                            DataFormatString="{0:X|}">
                            <ItemStyle Width="70px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <Siar:JsButtonColumnAgid Arguments="Id" JsFunction="mostraDettaglioProgrammazione" ButtonType="ImageButton"
                            ButtonText="Dettaglio elemento" ButtonImage="it-search">
                            <ItemStyle Width="50px" HorizontalAlign="Center" />
                        </Siar:JsButtonColumnAgid>
                    </Columns>
                </Siar:DataGridAgid>
            </div>
        </div>
    </div>
    <div class="row bd-form py-5" id="tableModifica" runat="server">
        <h3 class="pb-5">Dettaglio programma:</h3>
        <div class="col-sm-3 form-group">
            <Siar:TextBox  Label="Codice:" ID="txtPsrCodice" runat="server" MaxLength="20" NomeCampo="Codice"
                Obbligatorio="True" />
        </div>
        <div class="col-sm-3 form-group">
            <Siar:IntegerTextBox Label="Anno da:" ID="txtPsrAnnoDa" runat="server" NoCurrency="True"
                NomeCampo="Anno da" Obbligatorio="True" MaxValue="2100" MinValue="1950" />
        </div>
        <div class="col-sm-3 form-group">
            <Siar:IntegerTextBox Label="Anno a:" ID="txtPsrAnnoA" runat="server" NoCurrency="True"
                NomeCampo="Anno a" Obbligatorio="True" MaxValue="2200" MinValue="1950" />
        </div>
        <div class="col-sm-3 form-group">
            <Siar:TextBox  Label="CCI:" ID="txtPsrCci" runat="server" MaxLength="50" NomeCampo="Cci" />
        </div>
        <div class="col-sm-12 form-group">
            <Siar:TextArea Label="Descrizione:" ID="txtPsrDescrizione" runat="server" Rows="5" NomeCampo="Descrizione"
                Obbligatorio="True" MaxLength="2000" />
        </div>
        <div class="col-sm-12">
            <Siar:Button ID="btnPsrSalva" runat="server" OnClick="btnPsrSalva_Click" Text="Salva"
                Modifica="True" />
            <Siar:Button ID="btnPsrElimina" runat="server" OnClick="btnPsrElimina_Click"
                Text="Elimina" Modifica="True" CausesValidation="False" Conferma="Attenzione! Eliminare il programma selezionato e la sua struttura a livelli?" />
            <Siar:Button ID="btnPsrNuovo" runat="server" OnClick="btnPsrNuovo_Click" Text="Nuovo" Modifica="True" CausesValidation="False" />
        </div>
        <div class="row mt-5" id="trPsrAlbero" runat="server">
            <h3 class="pb-5">Struttura programmazione:</h3>

            <div class="col-sm-3 form-group">
                <Siar:TextBox  Label="Codice:" ID="txtPrgCodice" runat="server" MaxLength="30" ReadOnly="True" />
            </div>
            <div class="col-sm-3 form-group">
                <Siar:IntegerTextBox Label="Livello:" ID="txtPrgLivello" runat="server" NoCurrency="False"
                    ReadOnly="True" />
            </div>
            <div class="col-sm-2 form-check">
                <asp:CheckBox ID="chkPrgAttivazioneBandi" runat="server" Text="Attivazione nei bandi" />
            </div>
            <div class="col-sm-2 form-check">
                <asp:CheckBox ID="chkPrgAttivazioneFA" runat="server" Text="Aggancio Focus Area" />
            </div>
            <div class="col-sm-2 form-check">
                <asp:CheckBox ID="chkPrgAttivazioneOBMisura" runat="server" Text="Aggancio Obiettivi di Misura" />
            </div>
            <div class="col-sm-6 form-group">
                <Siar:TextBox  Label="Descrizione:" ID="txtPrgDescrizione" runat="server" MaxLength="50" />
            </div>
            <div class="col-sm-3 form-check">
                <asp:CheckBox ID="chkPrgAttivazioneInvestimenti" runat="server" Text="Aggancio Investimenti" />
            </div>
            <div class="col-sm-3 form-check">
                <asp:CheckBox ID="chkPrgAttivazioneFF" runat="server" Text="Aggancio Fonti Finanziarie" />
            </div>
            <div class="col-sm-12">
                <Siar:Button ID="btnPrgSalva" runat="server" OnClick="btnPrgSalva_Click" Text="Salva"
                    Modifica="True" CausesValidation="False" />
                <Siar:Button ID="btnPrgElimina" runat="server" OnClick="btnPrgElimina_Click"
                    Text="Elimina" Modifica="True" CausesValidation="False" />
                <Siar:Button ID="btnPrgNuovo" runat="server" OnClick="btnPrgNuovo_Click" Text="Nuovo"
                    Modifica="True" CausesValidation="False" />
            </div>
            <div class="col-sm-12">
                <Siar:DataGridAgid ID="dgPsrAlbero" runat="server" AutoGenerateColumns="False" CssClass="table table-striped">
                    <Columns>
                        <asp:BoundColumn DataField="Livello" HeaderText="Livello">
                            <ItemStyle Width="40px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione"></asp:BoundColumn>
                        <asp:BoundColumn DataField="AttivazioneBandi" HeaderText="Attivazione bandi" DataFormatString="{0:X|}">
                            <ItemStyle Width="80px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="AttivazioneFa" HeaderText="Aggancio Focus Area" DataFormatString="{0:X|}">
                            <ItemStyle Width="80px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="AttivazioneObMisura" HeaderText="Obiettivi di Misura"
                            DataFormatString="{0:X|}">
                            <ItemStyle Width="80px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="AttivazioneInvestimenti" HeaderText="Aggancio Investimenti"
                            DataFormatString="{0:X|}">
                            <ItemStyle Width="80px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="AttivazioneFF" HeaderText="Aggancio Fonti Finanziarie"
                            DataFormatString="{0:X|}">
                            <ItemStyle Width="80px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <Siar:JsButtonColumnAgid Arguments="Codice" JsFunction="selezionaPsrAlbero" ButtonText="Seleziona">
                            <ItemStyle HorizontalAlign="Center" />
                        </Siar:JsButtonColumnAgid>
                    </Columns>
                </Siar:DataGridAgid>
            </div>
        </div>
    </div>
    <div id="divDettaglioProgrammazione" class="modal it-dialog-scrollable" tabindex="-1" role="dialog" style="position: absolute; display: none">
        <div class="modal-dialog modal-xl" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h2 class="modal-title h5 " id="modal3Title">Dettaglio elemento di programmazione:</h2>
                </div>
                <div class="modal-body">
                    <div class="row bd-form">
                        <div class="col-sm-4 form-group">
                            <Siar:TextBox  Label="Codice:" ID="txtDPCodice" runat="server"/>
                        </div>
                        <div class="col-sm-4 form-group">
                            <Siar:TextBox  Label="Livello:" ID="txtDPTipo" runat="server" ReadOnly="true" />
                        </div>
                        <div class="col-sm-4">
                            <input id="btnDPSelezionaPadre" runat="server" type="button" class="btn btn-secondary py-1" value="Livello superiore"
                                disabled="disabled" />
                        </div>
                        <div class="col-sm-12 form-group">
                            <Siar:TextArea Label="Descrizione:" ID="txtDPDescrizione" MaxLength="2000" runat="server" Rows="3" />
                        </div>
                        <%-- <td ID="tdTxtDotazione"  runat="server" visible="false">
                                Importo Dotazione:<br />
                                <Siar:TextArea ID="txtDotazione" runat="server" Width="151px"/>
                            </td>--%>
                        <div class="col-sm-12 form-group" id="tdTxtDotazione" runat="server" visible="false">
                            <Siar:TextBox  Label="Importo Dotazione:" ID="txtDotazione" runat="server" />
                        </div>

                        <div class="col-sm-12">
                            <Siar:Button ID="btnDPSalva" runat="server" Text="Salva" Modifica="True"
                                CausesValidation="False" OnClick="btnDPSalva_Click" />
                            <Siar:Button ID="btnDPElimina" runat="server" Text="Elimina"
                                Modifica="True" CausesValidation="False" OnClick="btnDPElimina_Click" Conferma="Attenzione! Eliminare l`elemento di programmazione selezionato?" />
                            <input type="button" class="btn btn-secondary py-1" value="Chiudi" style="width: 120px" onclick="chiudiDettaglioProgrammazione();" />
                        </div>

                        <div class="row" id="trDPSottoelemento" runat="server">
                            <h4 class="pb-5">Aggiungi sottoelemento:</h4>
                            <div class="col-sm-6 form-group">
                                <Siar:TextBox  Label="Codice:" ID="txtDPSECodice" runat="server" />
                            </div>
                            <div class="col-sm-6 form-group">
                                <Siar:ComboSql Label="Livello:" ID="lstDPLivello" runat="server" DataTextField="DESCRIZIONE" DataValueField="CODICE">
                                </Siar:ComboSql>
                            </div>
                            <div class="col-sm-12 form-group">
                                <Siar:TextArea Label="Descrizione:" ID="txtDPSEDescrizione" MaxLength="2000" runat="server" Rows="3"/>
                            </div>
                            <div class="col-sm-12 form-group" id="tdTxtDPImporto" runat="server" visible="false">
                                <Siar:TextBox  Label="Importo Dotazione:" ID="txtDPImporto" runat="server"/>
                            </div>
                            <div class="col-sm-12">
                                <Siar:Button ID="btnDPSESalva" runat="server" Text="Aggiungi" Width="160px" Modifica="True"
                                    CausesValidation="False" OnClick="btnDPSESalva_Click" />
                            </div>
                            <div class="col-sm-12">
                                <Siar:DataGridAgid CssClass="table table-striped" ID="dgDPProgrammazione" runat="server" AutoGenerateColumns="False"
                                   AllowPaging="true" PageSize="5">
                                    <Columns>
                                        <asp:BoundColumn DataField="Codice" HeaderText="Codice">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="Tipo" HeaderText="Livello">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="AttivazioneBandi" HeaderText="Attivazione bandi" DataFormatString="{0:X|}">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="AttivazioneFa" HeaderText="Aggancio Focus Area" DataFormatString="{0:X|}">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="AttivazioneObMisura" HeaderText="Obiettivi di Misura"
                                            DataFormatString="{0:X|}">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="AttivazioneInvestimenti" HeaderText="Aggancio Investimenti"
                                            DataFormatString="{0:X|}">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="AttivazioneFF" HeaderText="Aggancio Fonti Finanziarie"
                                            DataFormatString="{0:X|}">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundColumn>
                                        <Siar:JsButtonColumnAgid Arguments="Id" ButtonImage="it-search" ButtonType="ImageButton"
                                            ButtonText="Seleziona" JsFunction="mostraDettaglioProgrammazione">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </Siar:JsButtonColumnAgid>
                                    </Columns>
                                </Siar:DataGridAgid>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
