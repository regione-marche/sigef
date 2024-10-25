<%@ Page Language="c#" MasterPageFile="~/SigefAgidPrivate.master" Inherits="web.Private.admin.Utente"
    CodeBehind="Utente.aspx.cs" %>

<%@ Register Src="~/CONTROLS/SiarNewTabAgid.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>
<%--<%@ Register Src="../../CONTROLS/Siar.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>--%>
<%@ Register Src="../../CONTROLS/GroupBoxProfilo.ascx" TagName="GroupBoxProfilo"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
    function checkCF(ev) { if ($('[id$=txtCodFiscale_text]').val() == '') { alert('Digitare il codice fiscale dell`utente.'); return stopEvent(ev); } }
    function ctrlCF(elem, ev) { var cf = $(elem).val(); if (cf != "" && !ctrlCodiceFiscale(cf)) { alert('Attenzione! Codice fiscale non corretto.'); return stopEvent(ev); } }
    function selezionaUtente(id) { $('[id$=hdnIdUtente]').val(id); swapTab(2); }
    function selezionaRuolo(id) { $('[id$=hdnIdUtenteStorico]').val(id); swapTab(3); }
    function pulisciStorico() { $('[id$=hdnIdUtenteStorico]').val(''); swapTab(3); }
//--></script>

    <asp:HiddenField ID="hdnIdUtente" runat="server" />
    <asp:HiddenField ID="hdnIdUtenteStorico" runat="server" />


    <uc1:SiarNewTab ID="ucSiarNewTab" runat="server" TabNames="Elenco utenti|Dettaglio utente|Ruolo" />
    <div class="row tableTab"  id="tbElenco" runat="server">
        <p class="fw-semibold py-3">Selezione parametri di ricerca</p>

        <div class="row py-3">
            <div class="col-sm-2 form-group">
                <Siar:TextBox ID="txtRicercaCF" Label="Codice fiscale" runat="server" MaxLength="16" />
            </div>
            <div class="col-sm-2 form-group">
                <Siar:TextBox Label="Nominativo" ID="txtRicercaNominativo" runat="server" MaxLength="30" Width="290px" />
            </div>
            <div class="col-sm-2 form-group">
                <Siar:ComboProfilo ID="lstRicercaProfilo" Label="Ruolo" runat="server"></Siar:ComboProfilo>
            </div>
            <div class="col-sm-4 form-group">
                <Siar:ComboEnte ID="lstRicercaEnte" Label="Ente" runat="server">
                </Siar:ComboEnte>
            </div>
            <div class="col-sm-2">
                <Siar:Button ID="btnCerca" runat="server" Modifica="False" OnClick="btnCerca_Click" Text="Cerca" CausesValidation="False" />
            </div>
        </div>

        <div class="row">
            <div class="col-sm-3">
                Elementi trovati:
                <asp:Label Font-Size="Smaller" ID="lblNrUtenti" runat="server"></asp:Label>
            </div>
        </div>

        <div class="row py-2">
            <div class="table-responsive">
                <Siar:DataGridAgid ID="dgUtenti" runat="server" CssClass="table table-striped" PageSize="20" AllowPaging="True"
                    AutoGenerateColumns="False">
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemStyle CssClass="DataGridRow itemStyle" />
                    <AlternatingItemStyle CssClass="DataGridRowAlt itemStyle" />
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle HorizontalAlign="center" />
                        </Siar:NumberColumn>
                        <Siar:ColonnaLink HeaderText="Nominativo" DataField="Nominativo" LinkFields="IdUtente"
                            LinkFormat="selezionaUtente({0});" IsJavascript="true">
                        </Siar:ColonnaLink>
                        <asp:BoundColumn HeaderText="CF" DataField="CfUtente">
                            <ItemStyle />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Profilo" DataField="Profilo">
                            <ItemStyle />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Ente" DataField="Ente">
                            <ItemStyle />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Provincia" DataField="Provincia">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Attivo" DataField="Attivo" DataFormatString="{0:SI|NO}">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGridAgid>&nbsp;
       
            </div>
        </div>
    </div>
    <div class="row tableTab py-3" id="tbDettaglio" runat="server">
        <div class="paragrafo_bold">Inserire i dati dell'operatore</div>
        <div class="container-fluid bd-form">
        <div class="row justify-content-start align-items-center px-2 py-4">
            <div class="col-sm-3">
                <Siar:TextBox ID="txtCodFiscale" Label="Codice Fiscale" runat="server" MaxLength="16" NomeCampo="Codice fiscale" Obbligatorio="true"></Siar:TextBox>
            </div>
            <div class="col-sm-3 pt-4">
                <Siar:Button ID="btnScarica" runat="server" CausesValidation="False" OnClick="btnScarica_Click"
                    Text="Scarica dati anagrafici" OnClientClick="return checkCF(event);" />
                <asp:HiddenField ID="hdnIdPersonaFisica" runat="server" />
            </div>
        </div>
        <div class="row justify-content-start align-items-center py-3">
            <Siar:TextBox CssClass="col-sm-3" ID="txtNominativo" Label="Nominativo" runat="server" ReadOnly="True" />
        </div>
        <div class="d-flex flex-row justify-content-start align-items-center pt-5 px-2">
            <div class="flex-column">
                <Siar:Button ID="btnSalva" runat="server" Text="Salva dati operatore"
                    OnClick="btnSalva_Click" Modifica="true"></Siar:Button>
                <Siar:Button ID="btnNuovo" runat="server" Text="Nuovo operatore" CausesValidation="false"
                    OnClick="btnNuovo_Click" Modifica="true"></Siar:Button>
            </div>
        </div>
        </div>    

        <div class="paragrafo_bold">Elenco Ruoli</div>
        <div class="container-fluid bd-form">
            <div class="d-flex flex-row justify-content-start align-items-center py-2 px-2">
                <div class="flex-column px-2">
                    <asp:CheckBox ID="chkAttivo" runat="server" Text="Attivo" />
                </div>
               <div class="flex-column px-2">
                    <Siar:Button ID="btnFiltra" CssClass="bt-btn-primary py-1" runat="server" CausesValidation="False" OnClick="btnFiltra_Click" Text="Filtra"  />
                </div>
                <div class="flex-column px-2">
                    <input type="button"  class="btn btn-primary py-1" id="btnNuovoRuolo" value="Nuovo Ruolo"  onclick="pulisciStorico();" />
                </div>
            </div>

            <div class="row justify-content-start align-items-center py-2">
                <div class="table-striped">
                    <Siar:DataGridAgid ID="dgUtentiStorico" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" PageSize="20">
                        <HeaderStyle CssClass="headerStyle" />
                        <ItemStyle CssClass="DataGridRow itemStyle" />
                        <AlternatingItemStyle CssClass="DataGridRowAlt itemStyle" />
                        <Columns>
                            <Siar:NumberColumn HeaderText="Nr.">
                                <ItemStyle HorizontalAlign="center" />
                            </Siar:NumberColumn>
                            <Siar:ColonnaLink HeaderText="Profilo" DataField="Profilo" LinkFields="Id"
                                LinkFormat="selezionaRuolo({0});" IsJavascript="true">
                            </Siar:ColonnaLink>
                            <asp:BoundColumn HeaderText="Ente" DataField="Ente">
                                <ItemStyle />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Provincia" DataField="Provincia">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Data inizio" DataField="Data">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Attivo" HeaderText="Attivo" DataFormatString="{0:SI|NO}">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                        </Columns>
                    </Siar:DataGridAgid>
                </div>
            </div>
        </div>
    </div>
    <div class="row tableTab py-5" id="tbDettaglioRuolo" runat="server">
        <div class="paragrafo_bold">Inserire i ruoli dell'operatore</div>
        <div class="container-fluid bd-form">
            <div class="row justify-content-start align-items-center py-2">
                <div class="form-group col-sm-3">
                    <label class="active fw-semibold" for="txtNominativoDett">Nominativo</label>
                    <Siar:TextBox ID="txtNominativoDett" runat="server" ReadOnly="True" />
                </div>

                <div id="tbRuoloEsistente" class="row py-2" runat="server">
                    <div class="row py-2">
                        <div class="form-group col-sm-3">
                            <label class="active fw-semibold" for="txtEnteDett">Ente</label>
                            <Siar:TextBox ID="txtEnteDett" runat="server" ReadOnly="True" />
                        </div>

                        <div class="form-group col-sm-3">
                            <label class="active fw-semibold" for="txtRuoloDett">Ruolo</label>
                            <Siar:TextBox ID="txtRuoloDett" runat="server" ReadOnly="True" />
                        </div>
                        <div class="form-group col-sm-3">
                            <label class="active fw-semibold" for="txtRuoloProv">Provincia</label>
                            <Siar:TextBox ID="txtRuoloProv" runat="server" ReadOnly="True" />
                        </div>
                        <div class="form-group col-sm-3">
                            <label class="active fw-semibold" for="txtEmailRO">Email</label>
                            <Siar:TextBox ID="txtEmailRO" runat="server" ReadOnly="True" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-4">
                            <Siar:Button ID="btnDisabilita" runat="server" CssClass="btn btn-secondary" Text="Disabilita operatore"
                                OnClick="btnDisabilita_Click" Modifica="true"></Siar:Button>
                            <Siar:Button ID="btnRiabilita" runat="server" CssClass="btn btn-secondary" Text="Riabilita operatore"
                                OnClick="btnRiabilita_Click" Modifica="true"></Siar:Button>
                            <Siar:Button ID="btnAggiornaEmail" runat="server" CssClass="btn btn-secondary" Text="Aggiorna Email"
                                OnClick="btnAggiornaEmail_click" Modifica="true"></Siar:Button>
                        </div>
                    </div>
                </div>

                <div id="tbRuoloNuovo" class="row py-2" runat="server">
                    <div class="row py-2">
                        <uc2:GroupBoxProfilo ID="ucProfilo" runat="server" />
                        <div class="form-group col-sm-3">
                            <Siar:ComboProvince Label="Provincia" ID="lstProvincia" runat="server" CodRegione="11"></Siar:ComboProvince>
                        </div>
                        <%--<br />
            <asp:CheckBox ID="chkAttivo" runat="server" Text="Attivo" />
            <Siar:TextBox  ID="txtAttivo" runat="server" Width="150px" MaxLength="16" ReadOnly="True" Visible="false">
            </Siar:TextBox>--%>
                        <div class="form-group col-sm-3">
                            <Siar:TextBox Label="Email" ID="txtEmail" runat="server" />
                        </div>
                    </div>
                </div>
                <div class="row pt-5">
                    <div class="col-sm-3">
                        <Siar:Button ID="btnSalvaRuolo" runat="server" Text="Salva Ruolo"  OnClick="btnSalvaRuolo_click" Modifica="true"></Siar:Button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
