<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" Inherits="web.Private.Psr.Bandi.BandoVarianti"
    CodeBehind="BandoVarianti.aspx.cs" %>

<%@ Register Src="../../../CONTROLS/SiarNewTab.ascx" TagName="SiarNewTab" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
        function caricaTipoVariante(cod_tipo) { $('[id$=hdnCodTipoVariante]').val(cod_tipo);$('[id$=btnCaricaTipoVariante]').click(); }
        function caricaRequisito(id) { $('[id$=hdnIdRequisito]').val(id);$('[id$=btnCaricaRequisito]').click(); }
        function pulisciCampiRequisito() {
            $('[id$=txtDescrizione_text]').val('');$('[id$=txtMisura_text]').val('');$('[id$=chkAutomatico]').attr('checked','');
            $('[id$=txtQueryLungaSQL_text]').val('');$('[id$=txtQueryInsertLunga_text]').val('');$('[id$=txtValoreMinimo_text]').val('');
            $('[id$=txtValoreMassimo_text]').val('');$('[id$=btnEliminaRequisito]').attr('disabled','disabled');$('[id$=hdnIdRequisito]').val('');
        }
//--></script>

    &nbsp;<uc2:SiarNewTab ID="ucSiarNewTab" runat="server" Width="900px" TabNames="Varianti - A.T|Requisiti" />
    <div style="display: none">
        <asp:Button ID="btnCaricaTipoVariante" runat="server" OnClick="btnCaricaTipoVariante_Click" />
        <asp:Button ID="btnCaricaRequisito" runat="server" OnClick="btnCaricaRequisito_Click" />
        <asp:HiddenField ID="hdnCodTipoVariante" runat="server" />
        <asp:HiddenField ID="hdnIdRequisito" runat="server" />
    </div>
    <table id="tbVarianti" class="tableTab" runat="server" width="900px">
        <tr>
            <td>
                &nbsp;<br />
                &nbsp; - Selezionare le tipologie richieste dal bando specificando il numero massimo
                previsto.&nbsp;
                <br />
                &nbsp;&nbsp;&nbsp; Impostare 0 per permettere l`inserimento di un numero indefinito
                di richieste per la tipologia relativa.<br />
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dg" runat="server" Width="800px" AutoGenerateColumns="False" EnableViewState="False">
                    <Columns>
                        <asp:BoundColumn HeaderText="Tipo Variante" DataField="CodTipo" DataFormatString="{0:AT=ADEGUAMENTO TECNICO|VA=VARIANTE|VI=VARIAZIONE ACCERTATA IN FASE ISTRUTTORIA|AR=RIDEFINIZIONE DI ESITO ISTRUTTORIO}">
                        </asp:BoundColumn>
                        <Siar:ImportoColumn DataField="CodTipo" Name="NumeroMassimo" HeaderText="Numero Massimo"
                            Importo="NumeroMassimo">
                            <ItemStyle HorizontalAlign="center" Width="150px" />
                        </Siar:ImportoColumn>
                        <Siar:CheckColumn DataField="CodTipo" Name="chkTipoVariantiSelezionate" HeaderText="Seleziona">
                            <ItemStyle Width="90px" HorizontalAlign="Center" />
                        </Siar:CheckColumn>
                        <asp:BoundColumn>
                            <ItemStyle Width="150px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="text-align: right; height: 51px; padding-right: 150px;">
                <Siar:Button ID="btnSalvaTipoVariante" runat="server" Width="127px" Text="Salva"
                    OnClick="btnSalvaTipoVariante_Click" Modifica="True"></Siar:Button>
            </td>
        </tr>
        <tr>
            <td>
                <table id="tbRequisitiVariante" runat="server" width="100%" visible="false">
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
                                    <td style="height: 25px">
                                        &nbsp;
                                        <Siar:TextBox ID="txtDMisuraCerca" runat="server" Width="98px" />
                                        &nbsp;&nbsp;
                                        <Siar:Button ID="btnDMisuraCerca" runat="server" CausesValidation="False" Text="Cerca"
                                            Width="71px" OnClick="btnDMisuraCerca_Click" />
                                    </td>
                                </tr>
                            </table>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <Siar:DataGrid ID="dgRequisitiVariante" runat="server" Width="100%" PageSize="25"
                                AllowPaging="True" AutoGenerateColumns="False">
                                <Columns>
                                    <Siar:NumberColumn HeaderText="Nr.">
                                        <ItemStyle Width="35px" HorizontalAlign="center" />
                                    </Siar:NumberColumn>
                                    <asp:BoundColumn DataField="IdRequisito" HeaderText="Id">
                                        <ItemStyle Width="50px" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="Misura" HeaderText="Misura">
                                        <ItemStyle Width="50px" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <Siar:CheckColumn DataField="IdRequisito" Name="chkRequisitoObbligatorio" HeaderText="Obbligatorio">
                                        <ItemStyle Width="80px" />
                                    </Siar:CheckColumn>
                                    <Siar:CheckColumn DataField="IdRequisito" Name="chkRequisitoPresentazione" HeaderText="Requisito di Presentazione">
                                        <ItemStyle Width="80px" HorizontalAlign="center" />
                                    </Siar:CheckColumn>
                                    <Siar:CheckColumn DataField="IdRequisito" Name="chkRequisitoIstruttoria" HeaderText="Requisito di Istruttoria">
                                        <ItemStyle Width="80px" HorizontalAlign="center" />
                                    </Siar:CheckColumn>
                                    <Siar:IntegerColumn DataField="IdRequisito" HeaderText="Ordine" Valore="Ordine" Name="txtRequisitoOrdine">
                                        <ItemStyle Width="100px" HorizontalAlign="center" />
                                    </Siar:IntegerColumn>
                                    <Siar:CheckColumn DataField="IdRequisito" Name="chkRequisitiSelezionati" HeaderText="Seleziona">
                                        <ItemStyle Width="80px" HorizontalAlign="center" />
                                    </Siar:CheckColumn>
                                    <Siar:JsButtonColumn Arguments="IdRequisito" JsFunction="caricaRequisito" ButtonType="TextButton"
                                        ButtonText="Dettaglio">
                                        <ItemStyle Width="100px" HorizontalAlign="Center" />
                                    </Siar:JsButtonColumn>
                                </Columns>
                            </Siar:DataGrid>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; height: 57px; padding-right: 50px;">
                            <Siar:Button ID="btnSalvaRequisitiVariante" runat="server" Width="127px" Text="Salva"
                                Modifica="true" OnClick="btnSalvaRequisitiVariante_Click"></Siar:Button>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table id="tbRequisiti" class="tableTab" runat="server" width="900px">
        <tr>
            <td class="paragrafo" colspan="2">
                <br />
                &nbsp;Dettaglio del requisito:
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                    ShowSummary="False" ValidationGroup="vgRequisito" />
                <br />
            </td>
        </tr>
        <tr>
            <td style="width: 103px">
                <b>Descrizione:</b>
            </td>
            <td>
                <Siar:TextArea ID="txtDescrizione" NomeCampo="Descrizione" runat="server" Width="600px"
                    DataColumn="Descrizione" />
                &nbsp;&nbsp;&nbsp;
                <asp:RequiredFieldValidator ID="rfvDescRequisito" runat="server" ControlToValidate="txtDescrizione"
                    ErrorMessage="Descrizione obbligatoria" ValidationGroup="vgRequisito">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 103px">
                <b>Misura: </b>
            </td>
            <td>
                <Siar:TextBox ID="txtMisura" runat="server" Width="150px" NomeCampo="Misura" MaxLength="20" />
                &nbsp;&nbsp;&nbsp;
                <asp:RequiredFieldValidator ID="rfvMisRequisito" runat="server" ControlToValidate="txtMisura"
                    ErrorMessage="Misura obbligatoria" ValidationGroup="vgRequisito">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 103px">
                &nbsp;
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 103px">
                Valore Minimo:
            </td>
            <td>
                <Siar:CurrencyBox ID="txtValoreMinimo" NomeCampo="Valore Minimo" runat="server" DataColumn="ValMinimo" />
            </td>
        </tr>
        <tr>
            <td style="width: 103px">
                Valore Massimo:
            </td>
            <td>
                <Siar:CurrencyBox ID="txtValoreMassimo" NomeCampo="Valore Massimo" runat="server"
                    DataColumn="ValMassimo" />
            </td>
        </tr>
        <tr>
            <td style="width: 103px">
                &nbsp;
            </td>
            <td>
                <asp:CheckBox ID="chkAutomatico" runat="server" Text="    Automatico" Width="106px" />
            </td>
        </tr>
        <tr>
            <td style="width: 103px">
                &nbsp;
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 103px">
                <b>Query Eval:</b>
            </td>
            <td>
                <Siar:TextArea ID="txtQueryLungaSQL" runat="server" Width="650px" Rows="10" />
            </td>
        </tr>
        <tr>
            <td style="width: 103px">
                <b>Query Insert:</b>
            </td>
            <td>
                <Siar:TextArea ID="txtQueryInsertLunga" runat="server" Width="650px" Rows="10" />
            </td>
        </tr>
        <tr>
            <td valign="top" style="width: 103px; height: 63px">
            </td>
            <td style="height: 63px;" align="right">
                <Siar:Button ID="btnSalvaRequisito" runat="server" Width="127px" Text="Salva" OnClick="btnSalvaRequisito_Click"
                    ValidationGroup="vgRequisito" Modifica="true"></Siar:Button>
                &nbsp;&nbsp;
                <Siar:Button ID="btnEliminaRequisito" runat="server" Width="127px" Text="Elimina"
                    Modifica="true" OnClick="btnEliminaRequisito_Click" Conferma="Eliminare il requisito?">
                </Siar:Button>
                &nbsp;&nbsp;
                <input class="Button" onclick="pulisciCampiRequisito()" type="button" value="Nuovo"
                    style="width: 140px" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
