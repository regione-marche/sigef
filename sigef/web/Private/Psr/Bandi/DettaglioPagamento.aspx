<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" Inherits="web.Private.Psr.Bandi.DettaglioPagamento"
    CodeBehind="DettaglioPagamento.aspx.cs" %>

<%@ Register Src="../../../CONTROLS/SiarNewTab.ascx" TagName="SiarNewTab" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
        function caricaPagamento(tipo) { $('[id$=hdnTipoPagamento]').val(tipo);$('[id$=btnCaricaPagamento]').click(); }
        function caricaRequisito(id) { $('[id$=hdnIdRequisito]').val(id);$('[id$=btnCaricaRequisito]').click(); }
        function caricaPlurivalore(id) { $('[id$=hdnIdPlurivalore]').val(id);$('[id$=btnCaricaPlurivalore]').click(); }
        function pulisciCampiRequisito() {
            $('[id$=hdnIdRequisito]').val('');$('[id$=txtDescrizione_text]').val('');$('[id$=txtMisura_text]').val('');$('[id$=txtQueryLungaSQL_text]').val('');
            $('[id$=txtQueryInsertLunga_text]').val('');$('[id$=btnEliminaRequisito]').attr("disabled","disabled");$('[type=radio]').attr('checked','');
            $('[id$=txtUrl_text]').val('');$('[id$=trUrl]').hide();pulisciCampiPlurivalore();$('[id$=tbPlurivalori]').hide("fast");
        }
        function pulisciCampiPlurivalore() {
            $('[id$=txtdescValoreMultiplo_text]').val('');$('[id$=txtCodiceValoreMupltiplo_text]').val('');
            $('[id$=hdnIdPlurivalore]').val('');$('[id$=btnEliminaValore]').attr("disabled","disabled");
        }
        function ctrlCheckBoxTipologie(elem,ev) {
            if($(elem).val()=='U') $('[id$=trUrl]').show();
            else {
                if($('[id$=trUrl]').css("display")!='none'&&$('[id$=txtUrl_text]').val()!=''&&
                    !confirm('Attenzione! Il campo Url è valorizzato se si prosegue verrà azzerato. Continuare?'))
                { stopEvent(ev);$('[type=radio][value=U]').attr('checked','checked'); }
                else { $('[id$=txtUrl_text]').val('');$('[id$=trUrl]').hide(); }
            }
        }
    //--></script>

    &nbsp;
    <div style="display: none">
        <asp:HiddenField ID="hdnIdPlurivalore" runat="server" />
        <asp:HiddenField ID="hdnIdRequisito" runat="server" />
        <asp:Button ID="btnCaricaRequisito" runat="server" OnClick="btnCaricaRequisito_Click" />
        <asp:HiddenField ID="hdnTipoPagamento" runat="server" />
        <asp:Button ID="btnCaricaPagamento" runat="server" OnClick="btnCaricaPagamento_Click" />
        <asp:Button ID="btnCaricaPlurivalore" runat="server" OnClick="btnCaricaPlurivalore_Click" />
    </div>
    <uc2:SiarNewTab ID="ucSiarNewTab" runat="server" Width="950px" TabNames="Tipologia domande di pagamento|Nuovo Requisito" />
    <table class="tableTab" id="tbPagamenti" runat="server" width="950px">
        <tr>
            <td>
                <br />
                &nbsp;<br />
                &nbsp;- Selezionare le tipologie di pagamento ammesse dal bando e per oguna di esse
                inserire gli importi, le quote di contributo<br />
                &nbsp;&nbsp; massimi e minimi da attribuire e l'eventuale tipologia di polizza fidejussoria.<br />
                &nbsp;&nbsp; Il pulsante di dettaglio visualizza i requisiti associati alla tipologia
                selezionata.
                <br />
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dgTipoPagamento" runat="server" Width="100%" AutoGenerateColumns="False"
                    EnableViewState="False">
                    <Columns>
                        <asp:BoundColumn HeaderText="Tipologia" DataField="Descrizione">
                            <ItemStyle Width="150px" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <Siar:PercentualeColumn DataField="CodTipo" Name="QuotaMin" HeaderText="Quota Minima %"
                            Quota="QuotaMin">
                            <ItemStyle HorizontalAlign="center" Width="110px" />
                        </Siar:PercentualeColumn>
                        <Siar:PercentualeColumn DataField="CodTipo" Name="QuotaMax" HeaderText="Quota Massima %"
                            Quota="QuotaMax">
                            <ItemStyle HorizontalAlign="center" Width="110px" />
                        </Siar:PercentualeColumn>
                        <Siar:ImportoColumn DataField="CodTipo" Name="ImportoMin" HeaderText="Importo Minimo"
                            Importo="ImportoMin">
                            <ItemStyle HorizontalAlign="center" Width="130px" />
                        </Siar:ImportoColumn>
                        <Siar:ImportoColumn DataField="CodTipo" Name="ImportoMax" HeaderText="Importo Massimo"
                            Importo="ImportoMax">
                            <ItemStyle HorizontalAlign="center" Width="130px" />
                        </Siar:ImportoColumn>
                        <Siar:IntegerColumn DataField="CodTipo" Valore="Numero" HeaderText="Numero massimo"
                            Name="Numero">
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </Siar:IntegerColumn>
                        <asp:BoundColumn HeaderText="Tipo Polizza">
                            <ItemStyle HorizontalAlign="Center" Width="130px" />
                        </asp:BoundColumn>
                        <Siar:CheckColumn DataField="CodTipo" Name="chkIncludi" HeaderText="Includi">
                            <ItemStyle HorizontalAlign="center" Width="60px" />
                        </Siar:CheckColumn>
                        <asp:BoundColumn HeaderText="Requisiti">
                            <ItemStyle HorizontalAlign="Center" Width="120px" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
        <tr>
            <td style="height: 55px; padding-right: 50px;" align="right" valign="middle">
                <Siar:Button ID="btnSalvaTipoPagamento" runat="server" Width="170px" Text="Salva"
                    Modifica="true" OnClick="btnSalvaTipoPagamento_Click" Conferma="Salvare le tipologie di pagamento?">
                </Siar:Button>
            </td>
        </tr>
        <tr>
            <td>
                <table id="tbRequisitiBando" runat="server" width="100%" visible="false" cellpadding="0"
                    cellspacing="0">
                    <tr>
                        <td class="paragrafo">
                            Lista completa dei requisiti di pagamento:&nbsp;
                            <Siar:Label ID="lblTipoPagamento" runat="server" />
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="middle">
                            <br />
                            <table style="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid;
                                width: 209px; border-bottom: black 1px solid">
                                <tr>
                                    <td class="separatore">
                                        &nbsp;Filtra per misura:
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 20px">
                                        &nbsp;
                                        <Siar:TextBox ID="txtMisuraCerca" runat="server" Width="98px" />
                                        &nbsp;&nbsp;
                                        <Siar:Button ID="btnMisuraCerca" runat="server" CausesValidation="False" Text="Cerca"
                                            Width="71px" OnClick="btnMisuraCerca_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <Siar:DataGrid ID="dgRequisiti" runat="server" Width="100%" PageSize="15" AllowPaging="True"
                                AutoGenerateColumns="False">
                                <Columns>
                                    <Siar:NumberColumn HeaderText="Nr.">
                                        <ItemStyle Width="30px" HorizontalAlign="center" />
                                    </Siar:NumberColumn>
                                    <asp:BoundColumn DataField="IdRequisito" HeaderText="Id">
                                        <ItemStyle Width="50px" HorizontalAlign="center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Requisito" HeaderText="Descrizione"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="Misura" HeaderText="Misura">
                                        <ItemStyle Width="50px" HorizontalAlign="center" />
                                    </asp:BoundColumn>
                                    <Siar:CheckColumn DataField="IdRequisito" Name="chkRequisitoObbligatorio" HeaderText="Obbligatorio"
                                        HeaderSelectAll="true">
                                        <ItemStyle Width="70px" />
                                    </Siar:CheckColumn>
                                    <Siar:CheckColumn DataField="IdRequisito" Name="chkRequisitoControllo" HeaderText="Requisito di Controllo"
                                        HeaderSelectAll="true">
                                        <ItemStyle Width="70px" />
                                    </Siar:CheckColumn>
                                    <Siar:CheckColumn DataField="IdRequisito" Name="chkRequisitoInserimento" HeaderText="Requisito di Inserimento"
                                        HeaderSelectAll="true">
                                        <ItemStyle Width="70px" />
                                    </Siar:CheckColumn>
                                    <Siar:IntegerColumn DataField="IdRequisito" HeaderText="Ordine" Valore="Ordine" Name="txtRequisitoOrdine">
                                        <ItemStyle Width="70" HorizontalAlign="center" />
                                    </Siar:IntegerColumn>
                                    <Siar:CheckColumn DataField="IdRequisito" Name="chkRequisitoIncludi" HeaderText="Includi"
                                        HeaderSelectAll="true">
                                        <ItemStyle Width="70px" />
                                    </Siar:CheckColumn>
                                    <Siar:JsButtonColumn Arguments="IdRequisito" JsFunction="caricaRequisito" ButtonType="TextButton"
                                        ButtonText="Modifica">
                                        <ItemStyle HorizontalAlign="Center" Width="120px" />
                                    </Siar:JsButtonColumn>
                                </Columns>
                            </Siar:DataGrid>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 55px; padding-right: 50px;" align="right">
                            <Siar:Button ID="btnSalvaRequisitiBando" runat="server" Width="170px" Text="Salva"
                                Modifica="true" OnClick="btnSalvaRequisitiBando_Click" Conferma="Salvare i requisiti selezionati?">
                            </Siar:Button>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table class="tableTab" id="tbRequisiti" runat="server" width="950px">
        <tr>
            <td class="paragrafo">
                <br />
                <br />
                &nbsp;Dettagli del requisito:
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;&nbsp;
                <asp:ValidationSummary ID="vsRequisito" runat="server" ShowMessageBox="True" ShowSummary="false"
                    ValidationGroup="vgRequisito" />
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%">
                    <tr>
                        <td style="width: 86px">
                            <b>Descrizione requisito:</b>
                        </td>
                        <td>
                            <Siar:TextArea ID="txtDescrizione" NomeCampo="Descrizione" runat="server" Width="600px" />
                            &nbsp;&nbsp;&nbsp;<asp:RequiredFieldValidator ID="rfvDescRequisito" runat="server"
                                ControlToValidate="txtDescrizione" ErrorMessage="Descrizione obbligatoria" ValidationGroup="vgRequisito">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 86px">
                            <b>Misura: </b>
                        </td>
                        <td>
                            <Siar:TextBox ID="txtMisura" runat="server" Width="150px" NomeCampo="Misura" MaxLength="20" />
                            &nbsp;&nbsp;<asp:RequiredFieldValidator ID="rfvMisRequisito" runat="server" ControlToValidate="txtMisura"
                                ErrorMessage="Misura obbligatoria" ValidationGroup="vgRequisito">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 86px">
                            &nbsp;
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 86px">
                            <b>Query Eval:</b>
                        </td>
                        <td>
                            <Siar:TextArea ID="txtQueryLungaSQL" runat="server" Width="650px" Rows="8" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 86px">
                            <b>Query Insert:</b>
                        </td>
                        <td>
                            <Siar:TextArea ID="txtQueryInsertLunga" runat="server" Width="650px" Rows="8" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 86px;">
                            &nbsp;<strong>Tipologia:</strong>
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rblTipologia" runat="server" RepeatDirection="Horizontal"
                                RepeatLayout="Flow">
                                <asp:ListItem Text="Url" Value="U"></asp:ListItem>
                                <asp:ListItem Text="Plurivalore" Value="P"></asp:ListItem>
                                <asp:ListItem Text="Numerico" Value="N"></asp:ListItem>
                                <asp:ListItem Text="Datetime" Value="D"></asp:ListItem>
                                <asp:ListItem Text="Testo Semplice" Value="T"></asp:ListItem>
                                <asp:ListItem Text="Testo Area" Value="A"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr id="trUrl" runat="server" style="display: none">
                        <td style="width: 86px">
                            &nbsp;<b>Url:</b>
                        </td>
                        <td>
                            <Siar:TextBox ID="txtUrl" runat="server" MaxLength="100" Width="330px" />
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="right" style="height: 59px">
                <Siar:Button ID="btnSalvaRequisito" runat="server" Width="127px" Text="Salva" OnClick="btnSalvaRequisito_Click"
                    Conferma="" ValidationGroup="vgRequisito" Modifica="True"></Siar:Button>
                &nbsp;&nbsp;
                <Siar:Button ID="btnEliminaRequisito" runat="server" Width="127px" Text="Elimina"
                    Modifica="true" OnClick="btnEliminaRequisito_Click" Conferma="Eliminazione il requisito selezionato?">
                </Siar:Button>
                &nbsp;&nbsp;&nbsp;
                <input type="button" class="Button" style="width: 110px" value="Nuovo" onclick="pulisciCampiRequisito()" />&nbsp;&nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <table id="tbPlurivalori" width="100%" runat="server" visible="false">
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="separatore">
                            &nbsp;Requisito Plurivalore:
                        </td>
                    </tr>
                    <tr>
                        <td class="paragrafo">
                            &nbsp;
                            <br />
                            &nbsp;Modifica/Nuovo valore:
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table width="100%">
                                <tr>
                                    <td align="left" style="width: 81px">
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 81px">
                                        <strong>&nbsp;Codice: </strong>
                                    </td>
                                    <td>
                                        <Siar:TextBox ID="txtCodiceValoreMupltiplo" runat="server" Width="87px" MaxLength="10" />
                                        &nbsp; &nbsp;<asp:RequiredFieldValidator ID="rvfCodice" runat="server" ControlToValidate="txtCodiceValoreMupltiplo"
                                            ErrorMessage="Codice obbligatorio" ValidationGroup="vgPlurivalore">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 81px">
                                        <strong>&nbsp;Descrizione: </strong>
                                    </td>
                                    <td>
                                        <Siar:TextBox runat="server" ID="txtdescValoreMultiplo" Width="462px" />
                                        &nbsp;
                                        <asp:RequiredFieldValidator ID="rfvDescrizioneValoreM" runat="server" ErrorMessage="Descrizione obbligatoria"
                                            ValidationGroup="vgPlurivalore" ControlToValidate="txtdescValoreMultiplo">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                            <asp:ValidationSummary ID="vsPlurivalore" runat="server" ShowMessageBox="True" ShowSummary="false"
                                ValidationGroup="vgPlurivalore" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <Siar:Button ID="btnAssociaValoreMultiplo" runat="server" Text="Salva Valore" ValidationGroup="vgPlurivalore"
                                OnClick="btnAssociaValoreMultiplo_Click" Width="127px" Modifica="true" />
                            &nbsp;
                            <Siar:Button ID="btnEliminaValore" runat="server" Width="127px" Text="Elimina" Modifica="true"
                                Conferma="Eliminare il valore selezionato?" OnClick="btnEliminaValoreMultipli_Click">
                            </Siar:Button>
                            &nbsp;&nbsp;&nbsp;
                            <input id="btnNewValoreMultiplo" style="width: 110px" type="button" value="Nuovo"
                                onclick="pulisciCampiPlurivalore()" class="Button" />
                        </td>
                    </tr>
                    <tr>
                        <td class="paragrafo">
                            <br />
                            &nbsp;Lista valori associati:
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;<Siar:DataGrid ID="dgValoriMultipli" runat="server" Width="100%" PageSize="20"
                                AllowPaging="True" CssClass="tabella" AutoGenerateColumns="False">
                                <Columns>
                                    <Siar:NumberColumn HeaderText="Nr.">
                                        <ItemStyle Width="30px" HorizontalAlign="center" />
                                    </Siar:NumberColumn>
                                    <asp:BoundColumn DataField="Codice" HeaderText="Codice">
                                        <ItemStyle HorizontalAlign="Left" Width="80px" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione"></asp:BoundColumn>
                                    <asp:BoundColumn>
                                        <ItemStyle HorizontalAlign="Center" Width="120px" />
                                    </asp:BoundColumn>
                                </Columns>
                            </Siar:DataGrid>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
