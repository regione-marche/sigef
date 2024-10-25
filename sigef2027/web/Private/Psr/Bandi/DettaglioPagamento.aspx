<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" Inherits="web.Private.Psr.Bandi.DettaglioPagamento"
    CodeBehind="DettaglioPagamento.aspx.cs" %>

<%@ Register Src="../../../CONTROLS/SiarNewTabAgid.ascx" TagName="SiarNewTab" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
    function caricaPagamento(tipo) { $('[id$=hdnTipoPagamento]').val(tipo); $('[id$=btnCaricaPagamento]').click(); }
    function caricaRequisito(id) { $('[id$=hdnIdRequisito]').val(id); $('[id$=btnCaricaRequisito]').click(); }
    function caricaPlurivalore(id) { $('[id$=hdnIdPlurivalore]').val(id); $('[id$=btnCaricaPlurivalore]').click(); }
    function pulisciCampiRequisito() {
        $('[id$=hdnIdRequisito]').val(''); $('[id$=txtDescrizione_text]').val(''); $('[id$=txtMisura_text]').val(''); $('[id$=txtQueryLungaSQL_text]').val('');
        $('[id$=txtQueryInsertLunga_text]').val(''); $('[id$=btnEliminaRequisito]').attr("disabled", "disabled"); $('[type=radio]').attr('checked', '');
        $('[id$=txtUrl_text]').val(''); $('[id$=trUrl]').hide(); pulisciCampiPlurivalore(); $('[id$=tbPlurivalori]').hide("fast");
    }
    function pulisciCampiPlurivalore() {
        $('[id$=txtdescValoreMultiplo_text]').val(''); $('[id$=txtCodiceValoreMupltiplo_text]').val('');
        $('[id$=hdnIdPlurivalore]').val(''); $('[id$=btnEliminaValore]').attr("disabled", "disabled");
    }
    function ctrlCheckBoxTipologie(elem, ev) {
        if ($(elem).val() == 'U') $('[id$=trUrl]').show();
        else {
            if ($('[id$=trUrl]').css("display") != 'none' && $('[id$=txtUrl_text]').val() != '' &&
                !confirm('Attenzione! Il campo Url è valorizzato se si prosegue verrà azzerato. Continuare?')) { stopEvent(ev); $('[type=radio][value=U]').attr('checked', 'checked'); }
            else { $('[id$=txtUrl_text]').val(''); $('[id$=trUrl]').hide(); }
        }
    }
    //--></script>    
    <div style="display: none">
        <asp:HiddenField ID="hdnIdPlurivalore" runat="server" />
        <asp:HiddenField ID="hdnIdRequisito" runat="server" />
        <asp:Button ID="btnCaricaRequisito" runat="server" OnClick="btnCaricaRequisito_Click" />
        <asp:HiddenField ID="hdnTipoPagamento" runat="server" />
        <asp:Button ID="btnCaricaPagamento" runat="server" OnClick="btnCaricaPagamento_Click" />
        <asp:Button ID="btnCaricaPlurivalore" runat="server" OnClick="btnCaricaPlurivalore_Click" />
    </div>
    <uc2:SiarNewTab ID="ucSiarNewTab" runat="server" TabNames="Tipologia domande di pagamento|Nuovo Requisito" />
    <div class="tableTab row" id="tbPagamenti" runat="server" width="950px">
        <p class="mt-5">
            - Selezionare le tipologie di pagamento ammesse dal bando e per oguna di esse inserire gli importi, le quote di contributo massimi e minimi da attribuire e l'eventuale tipologia di polizza fidejussoria. Il pulsante di dettaglio visualizza i requisiti associati alla tipologia selezionata.
        </p>
        <div class="col-sm-12">
            <Siar:DataGridAgid CssClass="table table-striped" ID="dgTipoPagamento" runat="server" Width="100%" AutoGenerateColumns="False"
                EnableViewState="False">
                <Columns>
                    <asp:BoundColumn HeaderText="Tipologia" DataField="Descrizione">
                        <ItemStyle Width="150px" HorizontalAlign="center" />
                    </asp:BoundColumn>
                    <Siar:PercentualeColumn DataField="CodTipo" Name="QuotaMin" HeaderText="Quota Minima %"
                        Quota="QuotaMin">
                        <ItemStyle HorizontalAlign="center" />
                    </Siar:PercentualeColumn>
                    <Siar:PercentualeColumn DataField="CodTipo" Name="QuotaMax" HeaderText="Quota Massima %"
                        Quota="QuotaMax">
                        <ItemStyle HorizontalAlign="center" />
                    </Siar:PercentualeColumn>
                    <Siar:ImportoColumn DataField="CodTipo" Name="ImportoMin" HeaderText="Importo Minimo"
                        Importo="ImportoMin">
                        <ItemStyle HorizontalAlign="center" />
                    </Siar:ImportoColumn>
                    <Siar:ImportoColumn DataField="CodTipo" Name="ImportoMax" HeaderText="Importo Massimo"
                        Importo="ImportoMax">
                        <ItemStyle HorizontalAlign="center" />
                    </Siar:ImportoColumn>
                    <Siar:IntegerColumn DataField="CodTipo" Valore="Numero" HeaderText="Numero massimo"
                        Name="Numero">
                        <ItemStyle HorizontalAlign="Center" />
                    </Siar:IntegerColumn>
                    <asp:BoundColumn HeaderText="Tipo Polizza">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <Siar:CheckColumnAgid DataField="CodTipo" Name="chkIncludi" HeaderText="Includi">
                        <ItemStyle HorizontalAlign="center" />
                    </Siar:CheckColumnAgid>
                    <asp:BoundColumn HeaderText="Requisiti">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                </Columns>
            </Siar:DataGridAgid>
        </div>
        <div>
            <Siar:Button ID="btnSalvaTipoPagamento" runat="server" Width="170px" Text="Salva"
                Modifica="true" OnClick="btnSalvaTipoPagamento_Click" Conferma="Salvare le tipologie di pagamento?"></Siar:Button>
        </div>
        <div class="row" id="tbRequisitiBando" runat="server" visible="false">
            <p class="pb-5 mt-5">
                <label>Lista completa dei requisiti di pagamento:</label><Siar:Label ID="lblTipoPagamento" runat="server" />
            </p>
            <div class="col-sm-6 form-group">
                <Siar:TextBox  Label="Filtra per misura:" ID="txtMisuraCerca" runat="server" />
            </div>
            <div class="col-sm-6">
                <Siar:Button ID="btnMisuraCerca" runat="server" CausesValidation="False" Text="Cerca" OnClick="btnMisuraCerca_Click" />
            </div>
            <div class="col-sm-12">
                <Siar:DataGridAgid ID="dgRequisiti" CssClass="table table-striped" runat="server" PageSize="15" AllowPaging="True"
                    AutoGenerateColumns="False">
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle HorizontalAlign="center" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="IdRequisito" HeaderText="Id">
                            <ItemStyle HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Requisito" HeaderText="Descrizione"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Misura" HeaderText="Misura">
                            <ItemStyle HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <Siar:CheckColumnAgid DataField="IdRequisito" Name="chkRequisitoObbligatorio" HeaderText="Obbligatorio"
                            HeaderSelectAll="true">
                        </Siar:CheckColumnAgid>
                        <Siar:CheckColumnAgid DataField="IdRequisito" Name="chkRequisitoControllo" HeaderText="Requisito di Controllo"
                            HeaderSelectAll="true">
                        </Siar:CheckColumnAgid>
                        <Siar:CheckColumnAgid DataField="IdRequisito" Name="chkRequisitoInserimento" HeaderText="Requisito di Inserimento"
                            HeaderSelectAll="true">
                        </Siar:CheckColumnAgid>
                        <Siar:IntegerColumn DataField="IdRequisito" HeaderText="Ordine" Valore="Ordine" Name="txtRequisitoOrdine">
                            <ItemStyle HorizontalAlign="center" />
                        </Siar:IntegerColumn>
                        <Siar:CheckColumnAgid DataField="IdRequisito" Name="chkRequisitoIncludi" HeaderText="Includi"
                            HeaderSelectAll="true">
                        </Siar:CheckColumnAgid>
                        <Siar:JsButtonColumnAgid Arguments="IdRequisito" JsFunction="caricaRequisito" ButtonType="TextButton"
                            ButtonText="Modifica">
                            <ItemStyle HorizontalAlign="Center" />
                        </Siar:JsButtonColumnAgid>
                    </Columns>
                </Siar:DataGridAgid>
            </div>
            <div class="col-sm-12 pb-5">
                <Siar:Button ID="btnSalvaRequisitiBando" runat="server" Text="Salva"
                    Modifica="true" OnClick="btnSalvaRequisitiBando_Click" Conferma="Salvare i requisiti selezionati?"></Siar:Button>
            </div>
        </div>
    </div>
    <div class="tableTab row bd-form" id="tbRequisiti" runat="server">
        <h3 class="pb-5 mt-5">Dettagli del requisito:</h3>
        <div>
            <asp:ValidationSummary ID="vsRequisito" runat="server" ShowMessageBox="True" ShowSummary="false"
                ValidationGroup="vgRequisito" />
        </div>
        <div class="col-sm-12 form-group">
            <Siar:TextArea Label="Descrizione requisito:" ID="txtDescrizione" NomeCampo="Descrizione" runat="server" />
            <asp:RequiredFieldValidator ID="rfvDescRequisito" runat="server" ControlToValidate="txtDescrizione" ErrorMessage="Descrizione obbligatoria" ValidationGroup="vgRequisito">*</asp:RequiredFieldValidator>
        </div>
        <div class="col-sm-12 form-group">
            <Siar:TextBox  Label="Misura:" ID="txtMisura" runat="server" NomeCampo="Misura" MaxLength="20" />
            <asp:RequiredFieldValidator ID="rfvMisRequisito" runat="server" ControlToValidate="txtMisura"
                ErrorMessage="Misura obbligatoria" ValidationGroup="vgRequisito">*</asp:RequiredFieldValidator>
        </div>
        <div class="col-sm-12 form-group">
            <Siar:TextArea Label="Query Eval:" ID="txtQueryLungaSQL" runat="server" Rows="8" />
        </div>
        <div class="col-sm-12 form-group">
            <Siar:TextArea Label="Query Insert:" ID="txtQueryInsertLunga" runat="server" Rows="8" />
        </div>
        <div class="col-sm-12 check-form">
            <asp:RadioButtonList ID="rblTipologia" runat="server" RepeatDirection="Horizontal"
                RepeatLayout="Flow">
                <asp:ListItem Text="Url" Value="U"></asp:ListItem>
                <asp:ListItem Text="Plurivalore" Value="P"></asp:ListItem>
                <asp:ListItem Text="Numerico" Value="N"></asp:ListItem>
                <asp:ListItem Text="Datetime" Value="D"></asp:ListItem>
                <asp:ListItem Text="Testo Semplice" Value="T"></asp:ListItem>
                <asp:ListItem Text="Testo Area" Value="A"></asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <div class="col-sm-12 form-group mt-5" id="trUrl" runat="server" style="display: none">
            <Siar:TextBox  ID="txtUrl" Label="Url:" runat="server" MaxLength="100" Width="330px" />
        </div>
        <div class="col-sm-12">
            <Siar:Button ID="btnSalvaRequisito" runat="server" Text="Salva" OnClick="btnSalvaRequisito_Click"
                Conferma="" ValidationGroup="vgRequisito" Modifica="True"></Siar:Button>
            <Siar:Button ID="btnEliminaRequisito" runat="server" Text="Elimina"
                Modifica="true" OnClick="btnEliminaRequisito_Click" Conferma="Eliminazione il requisito selezionato?"></Siar:Button>
            <input type="button" class="btn btn-secondary py-1" value="Nuovo" onclick="pulisciCampiRequisito()" />
        </div>
        <div id="tbPlurivalori" class="row" runat="server" visible="false">
            <h4 class="pb-5 mt-5">Requisito Plurivalore:</h4>
            <p>Modifica/Nuovo valore:</p>
            <div class="col-sm-2 form-group">                <Siar:TextBox  Label="Codice:" ID="txtCodiceValoreMupltiplo" runat="server" MaxLength="10" />
                <asp:RequiredFieldValidator ID="rvfCodice" runat="server" ControlToValidate="txtCodiceValoreMupltiplo"
                    ErrorMessage="Codice obbligatorio" ValidationGroup="vgPlurivalore">*</asp:RequiredFieldValidator>
            </div>
            <div class="col-sm-10 form-group">
                <Siar:TextBox  Label="Descrizione:" runat="server" ID="txtdescValoreMultiplo" />
                <asp:RequiredFieldValidator ID="rfvDescrizioneValoreM" runat="server" ErrorMessage="Descrizione obbligatoria"
                    ValidationGroup="vgPlurivalore" ControlToValidate="txtdescValoreMultiplo">*</asp:RequiredFieldValidator>
            </div>

            <div class="col-sm-12 form-group">
                <asp:ValidationSummary ID="vsPlurivalore" runat="server" ShowMessageBox="True" ShowSummary="false"
                    ValidationGroup="vgPlurivalore" />
            </div>
            <div class="col-sm-12">
                <Siar:Button ID="btnAssociaValoreMultiplo" runat="server" Text="Salva Valore" ValidationGroup="vgPlurivalore"
                    OnClick="btnAssociaValoreMultiplo_Click" Modifica="true" />
                <Siar:Button ID="btnEliminaValore" runat="server" Text="Elimina" Modifica="true"
                    Conferma="Eliminare il valore selezionato?" OnClick="btnEliminaValoreMultipli_Click"></Siar:Button>
                <input id="btnNewValoreMultiplo" type="button" value="Nuovo"
                    onclick="pulisciCampiPlurivalore()" class="btn btn-secondary py-1" />
            </div>
            <h4 class="pb-5 mt-5">Lista valori associati:</h4>

            <div class="col-sm-12">
                <Siar:DataGridAgid ID="dgValoriMultipli" runat="server" Width="100%" PageSize="20"
                    AllowPaging="True" CssClass="table table-striped" AutoGenerateColumns="False">
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle HorizontalAlign="center" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="Codice" HeaderText="Codice">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione"></asp:BoundColumn>
                        <asp:BoundColumn>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGridAgid>
            </div>
        </div>
    </div>
</asp:Content>
