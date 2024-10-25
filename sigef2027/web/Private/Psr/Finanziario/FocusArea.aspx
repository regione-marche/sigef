<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    CodeBehind="FocusArea.aspx.cs" Inherits="web.Private.Psr.Finanziario.FocusArea" %>

<%@ Register Src="../../../CONTROLS/SiarNewTabAgid.ascx" TagName="SiarNewTabAgid" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <script type="text/javascript">
        function selezionaFA(codice) { $('[id$=hdnCodFA]').val(codice); swapTab(2); }
        function nuovaFA() { $('[id$=hdnCodFA]').val(''); $('[id$=txtCodice_text]').val(''); $('[id$=txtDescrizione_text]').val(''); $('[id$=lstPsr]').val(''); $('[id$=chkObTrasversale]')[0].checked = false; $('[id$=btnElimina]')[0].disabled = 'disabled'; $('[id$=trDotazioneFinanziaria]').hide(); }
        function checkDgProgInputColumnsOnLoad_handler() { $('[id*=_dglstContributoFA_]').each(function () { lstChange_handler(this); }); }
        function lstChange_handler(elem) { var id_programmazione = elem.id.substring(elem.id.lastIndexOf('_') + 1); dgTxtDotFinanziariaEnable(document.getElementById('dgTxtDotFinanziaria' + id_programmazione + '_text'), elem.value == "D"); }
        function dgTxtDotFinanziariaEnable(txt, enable) { if (enable) { txt.disabled = ''; txt.onblur = ricalcolaTotale; } else { txt.value = 0; txt.disabled = 'disabled'; txt.onblur = null; } }
        function ricalcolaTotale() { var txts = $('[id^=dgTxtDotFinanziaria][id$=_text]'), totale = 0; for (var i = 0; i < txts.length; i++) { var parziale = FromCurrencyToNumber(txts[i].value); if (!isNaN(parziale)) totale += parziale; } $('[id$=dgTotFooterDotFinanziaria_text]').val(FromNumberToCurrency(totale)); }
    </script>

    <input type="hidden" id="hdnCodFA" runat="server" />
    <uc1:SiarNewTabAgid ID="ucSiarNewTab" runat="server" TabNames="Elenco|Dettaglio|Ricerca per Operazione" />
    <div class="row tableTab py-5 mx-2" id="tabElenco" runat="server" visible="false">
        <h4 class="pl-5">Elenco generale delle Focus Area</h4>
        <div class="row">
            <div class="col-sm-12">
                <Siar:DataGridAgid ID="dgFA" runat="server" CssClass="table table-striped" PageSize="20" AllowPaging="True" AutoGenerateColumns="False">
                    <ItemStyle Height="30px" />
                    <Columns>
                        <Siar:NumberColumn>
                            <ItemStyle Width="50px" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="CodPsr" HeaderText="Codice programma">
                            <ItemStyle Width="90px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Codice" HeaderText="Codice">
                            <ItemStyle Width="90px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <Siar:ColonnaLink DataField="Descrizione" HeaderText="Descrizione" IsJavascript="true"
                            LinkFields="Codice" LinkFormat="selezionaFA('{0}');">
                        </Siar:ColonnaLink>
                        <asp:BoundColumn DataField="Trasversale" HeaderText="Obiettivo trasversale" DataFormatString="{0:SI|NO}">
                            <ItemStyle Width="100px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="DotFinanziaria" HeaderText="Totale dotazione finanziaria"
                            DataFormatString="{0:c}">
                            <ItemStyle Width="100px" HorizontalAlign="Right" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGridAgid>
            </div>
        </div>
    </div>
    <div class="row tableTab py-5 mx-2" id="tabDettaglio" runat="server" visible="false">
        <h4 class="pb-5">Dettaglio Focus Area selezionata:</h4>
        <div class="row bd-form pt-5">
            <div class="form-group col-sm-6">
                <Siar:TextBox  Label="Codice" ID="txtCodice" runat="server" NomeCampo="Codice" Obbligatorio="True" MaxLength="10" />
            </div>
            <div class="form-check col-sm-6">
                <asp:CheckBox ID="chkObTrasversale" runat="server" Text="Obiettivo trasversale" />
            </div>
            <div class="form-group col-sm-12">
                <Siar:ComboZPsr Label="Programma:" ID="lstPsr" runat="server" Obbligatorio="True"></Siar:ComboZPsr>
            </div>
            <div class="form-group col-sm-12">
                <Siar:TextArea Label="Descrizione" ID="txtDescrizione" runat="server" NomeCampo="Descrizione"
                    Obbligatorio="True" MaxLength="255" Rows="7" />
            </div>
            <div class="col-sm-12 pb-5 pe-5 text-center">
                <Siar:Button ID="btnSalva" runat="server" Modifica="True" Text="Salva" Width="137px"
                    OnClick="btnSalva_Click" />
                <Siar:Button ID="btnElimina" runat="server" Modifica="True" Text="Elimina" Width="137px"
                    CausesValidation="false" OnClick="btnElimina_Click" Conferma="Attenzione! Eliminare la Focus Area selezionata?" />
                <button type="button" class="btn btn-primary py-1" title="pulisci" style="width: 137px" onclick="nuovaFA();">Pulisci</button>
            </div>
        </div>
        <div class="row">
            <div id="trDotazioneFinanziaria" runat="server" visible="false">
                <h4 class="pb-5">Dotazione finanziaria</h4>
                <div class="col-sm-12 pb-10 pt-10">
                    <Siar:DataGridAgid ID="dgProgrammazione" runat="server" CssClass="table table-striped" PageSize="20" AllowPaging="True" AutoGenerateColumns="False"
                        ShowFooter="true" FooterStyle-CssClass="TotaliFooter">
                        <ItemStyle Height="28px" />
                        <Columns>
                            <Siar:NumberColumn>
                                <ItemStyle Width="30px" />
                            </Siar:NumberColumn>
                            <asp:BoundColumn DataField="ProgCodice" HeaderText="Codice">
                                <ItemStyle Width="70px" HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="ProgTipo" HeaderText="Livello">
                                <ItemStyle Width="120px" HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="ProgDescrizione" HeaderText="Descrizione"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Contributo">
                                <ItemStyle Width="120px" HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <Siar:ImportoColumn DataField="IdProgrammazione" Importo="DotFinanziaria" Name="dgTxtDotFinanziaria"
                                HeaderText="Dotazione finanziaria €" ReadOnly="true">
                                <ItemStyle Width="150px" HorizontalAlign="Center" />
                            </Siar:ImportoColumn>
                        </Columns>
                    </Siar:DataGridAgid>
                </div>
                <div class="col-sm-12 pb-5 pe-5 text-end">
                    <Siar:Button ID="btnSalvaDotazione" runat="server" Modifica="True" Text="Salva" Width="150px" />
                </div>
            </div>
        </div>
    </div>
    <div class="row bd-form tableTab py-5 mx-2" id="tabOperazione" runat="server" visible="false">
        <h4 class="pb-5">Selezionare la programmazione desiderata:</h4>
        <div class="form-group col-sm-12">
            <Siar:ComboGroupZProgrammazione ID="lstProgrammazione" runat="server" AttivazioneBandi="true"></Siar:ComboGroupZProgrammazione>
        </div>
        <div class="col-sm-2">
            <Siar:DataGridAgid ID="dgFAXOperazione" runat="server" AutoGenerateColumns="False" Width="100%">
                <ItemStyle Height="30px" />
                <Columns>
                    <Siar:NumberColumn>
                        <ItemStyle Width="50px" />
                    </Siar:NumberColumn>
                    <asp:BoundColumn DataField="CodFa" HeaderText="Codice">
                        <ItemStyle Width="90px" HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="FaDescrizione" HeaderText="Descrizione"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Trasversale" HeaderText="Obiettivo trasversale" DataFormatString="{0:SI|NO}">
                        <ItemStyle Width="70px" HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="TipoContributo" HeaderText="Tipo contributo" DataFormatString="{0:D=Diretto|I=Indiretto}">
                        <ItemStyle Width="100px" HorizontalAlign="Right" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="DotFinanziaria" HeaderText="Totale dotazione finanziaria"
                        DataFormatString="{0:c}">
                        <ItemStyle Width="100px" HorizontalAlign="Right" />
                    </asp:BoundColumn>
                </Columns>
            </Siar:DataGridAgid>
        </div>
    </div>
</asp:Content>
