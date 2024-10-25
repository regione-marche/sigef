<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    MaintainScrollPositionOnPostback="true" Inherits="web.Private.regione.Priorita"
    CodeBehind="Priorita.aspx.cs" %>

<%@ Register Src="~/CONTROLS/SiarNewTab.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
        function selezionaPriorita(id) { $('[id$=hdnIdPriorita]').val(id);$('[id$=btnPost]').click(); }
        function selezionaValorePriorita(id_valore) { $('[id$=hdnIdValoreMultiplo]').val(id_valore);$('[id$=btnEditPlurivalore]').click(); }
        function disabilita(manuale,pluri,numerico,tipodate,testosemplice,testoarea, plurivalorequery) {
            $('[id$=cbManuale]').attr('checked',manuale);$('[id$=cbPlurivalore]').attr('checked',pluri);$('[id$=cbNumerico]').attr('checked',numerico);
            $('[id$=cbDatetime]').attr('checked',tipodate);$('[id$=cbTestoSemplice]').attr('checked',testosemplice);
            $('[id$=cbTestoArea]').attr('checked',testoarea);$('[id$=cbPlurivaloreQuery]').attr('checked',plurivalorequery);
        }
    //--></script>

    <div style="display: none">
        <asp:HiddenField ID="hdnIdPriorita" runat="server" />
        <asp:HiddenField ID="hdnIdValoreMultiplo" runat="server" />
        <asp:Button ID="btnPost" runat="server" OnClick="btnPost_Click" />
        <asp:Button ID="btnEditPlurivalore" runat="server" OnClick="btnEditPlurivalore_Click" />
    </div>
    <uc1:SiarNewTab runat="server" ID="ucSiarNewTab" TabNames="Elenco delle priorità|Dettaglio selezione" />
    <table id="tbPriorita" width="800px" runat="server" class="tableTab" visible="false">
        <tr>
            <td>
                <table width="100%">
                    <tr>
                        <td style="width: 229px" class="testo_pagina">
                        </td>
                        <td style="border-bottom: black 1px solid; border-left: black 1px solid; padding-left: 10px;
                            padding-bottom: 10px">
                            <table width="100%">
                                <tr>
                                    <td style="width: 247px">
                                        Descrizione:<br />
                                        <Siar:TextBox runat="server" ID="txtFiltroDescrizione" Width="225px" />
                                    </td>
                                    <td style="width: 160px">
                                        Parole Chiave:<br />
                                        <Siar:TextBox runat="server" ID="txtFiltroMisura" Width="130px" />
                                    </td>
                                    <td align="left">
                                        <br />
                                        <Siar:Button ID="btnFiltroMisura" Width="89px" runat="server" Text="Filtra" CausesValidation="false" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dgPriorita" runat="server" Width="100%" PageSize="20" AllowPaging="True"
                    AutoGenerateColumns="False">
                    <ItemStyle Height="24px" />
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle Width="30px" HorizontalAlign="center" />
                        </Siar:NumberColumn>
                        <Siar:ColonnaLink DataField="Descrizione" HeaderText="Descrizione" LinkFields="IdPriorita"
                            LinkFormat="javascript:selezionaPriorita({0});">
                        </Siar:ColonnaLink>
                        <asp:BoundColumn DataField="CodLivello" HeaderText="Livello di dettaglio" DataFormatString="{0:D=Domanda|I=Investimento|F=Investimento fisso|P=Impresa}">
                            <ItemStyle HorizontalAlign="center" Width="140px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Misura" HeaderText="Parole chiave">
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid><br />
            </td>
        </tr>
    </table>
    <table id="tbNuovaPriorita" width="800px" runat="server" visible="false" class="tableTab">
        <tr>
            <td colspan="2" style="height: 52px">
            </td>
        </tr>
        <tr>
            <td valign="top" style="width: 184px">
                <b>Descrizione priorità:</b>
            </td>
            <td>
                <Siar:TextArea ID="txtDescrizionePrioritaMedia" NomeCampo="Descrizione" runat="server"
                    Obbligatorio="True" Width="400px" DataColumn="Descrizione" />
            </td>
        </tr>
        <tr>
            <td valign="top" style="width: 184px">
                <b>Parole chiave: </b>
            </td>
            <td>
                <Siar:TextBox ID="txtMisura" runat="server" Width="150px" NomeCampo="Misura" MaxLength="20" />
            </td>
        </tr>
        <tr>
            <td valign="top" style="width: 184px">
                <b>Livello:</b>
            </td>
            <td>
                <Siar:ComboLivelloPriorita ID="lstLivPriorita" runat="server" NomeCampo="Livello Priorità"
                    Obbligatorio="True" DataColumn="CodLivello">
                </Siar:ComboLivelloPriorita>
            </td>
        </tr>
        <tr>
            <td valign="top" style="width: 184px;">
                <b>Query SQL:</b>
            </td>
            <td>
                <Siar:TextArea ID="txtQueryLungaSQL" runat="server" Width="400px" Rows="10" />
            </td>
        </tr>
        <tr>
            <td align="left" style="vertical-align: middle; width: 184px;">
                <br />
                <b>Specificare un valore:</b>
            </td>
            <td>
                <br />
                <asp:CheckBox ID="cbManuale" Text="Manuale" runat="server" onclick="disabilita(this.checked,false,false,false,false,false,false);" />
                <asp:CheckBox ID="cbPlurivalore" Text="Plurivalore" runat="server" onclick="disabilita(false,this.checked,false,false,false,false,false);" />
                <asp:CheckBox ID="cbNumerico" Text="Numerico" runat="server" onclick="disabilita(false,false,this.checked,false,false,false,false);" />
                <asp:CheckBox ID="cbDatetime" Text="Datetime" runat="server" onclick="disabilita(false,false,false,this.checked,false,false,false);" />
                <asp:CheckBox ID="cbTestoSemplice" Text="Testo Semplice" runat="server" onclick="disabilita(false,false,false,false,this.checked,false,false);" />
                <asp:CheckBox ID="cbTestoArea" Text="Testo Area" runat="server" onclick="disabilita(false,false,false,false,false,this.checked,false);" />
                <asp:CheckBox ID="cbPlurivaloreQuery" Text="Plurivalore Dinamico" runat="server" onclick="disabilita(false,false,false,false,false,false,this.checked);" />
            </td>
        </tr>
        <tr>
            <td valign="top" style="width: 184px">
            </td>
            <td style="text-align: right; padding-right: 40px; height: 50px">
                <Siar:Button ID="btnSalva" runat="server" Width="127px" Text="Salva" Modifica="true"
                    OnClick="btnSalva_Click" Conferma="Salvare priorità?"></Siar:Button>
                &nbsp;&nbsp;
                <Siar:Button ID="btnEliminaPriorita" runat="server" Width="127px" Text="Elimina"
                    Modifica="true" OnClick="btnEliminaPriorita_Click" Enabled="False" Conferma="Confermare eliminazione priorità?">
                </Siar:Button>
                &nbsp;&nbsp;
                <Siar:Button ID="btnNewPriority" runat="server" Text="Nuovo" OnClick="NewPrioritySB_Click"
                    Width="127px" CausesValidation="false" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table id="TABLE4" width="100%" runat="server" visible="false">
                    <tr>
                        <td colspan="2" class="separatore">
                            Inserimento valori multipli per la priorita
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="testo_pagina">
                            Indicare la descrizione e il punteggio per singolo valore
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 81px">
                            <b>Codice:</b>
                        </td>
                        <td>
                            <Siar:TextBox ID="txtCodiceValoreMupltiplo" runat="server" Width="87px" MaxLength="10" />
                            &nbsp; &nbsp;<asp:RequiredFieldValidator ID="rvfCodice" runat="server" ControlToValidate="txtCodiceValoreMupltiplo"
                                ErrorMessage="Codice obbligatorio" ValidationGroup="vgValoreMultiplo">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 81px">
                            <b>Descrizione:</b>
                        </td>
                        <td>
                            <Siar:TextBox runat="server" ID="txtdescValoreMultiplo" Width="462px" />
                            &nbsp;
                            <asp:RequiredFieldValidator ID="rfvDescrizioneValoreM" runat="server" ErrorMessage="Descrizione obbligatoria"
                                ValidationGroup="vgValoreMultiplo" ControlToValidate="txtdescValoreMultiplo">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 81px">
                            &nbsp;<strong>Punteggio :</strong>
                        </td>
                        <td>
                            <Siar:CurrencyBox ID="txtPunteggioPluri" runat="server" Width="85px" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;
                            <asp:ValidationSummary ID="vsValoriMultipli" runat="server" ShowMessageBox="True"
                                ShowSummary="false" ValidationGroup="vgValoreMultiplo" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" colspan="2">
                            <Siar:Button ID="btnAssociaValoreMultiplo" runat="server" Modifica="True" Text="Salva Valore"
                                ValidationGroup="vgValoreMultiplo" OnClick="btnAssociaValoreMultiplo_Click" Width="127px" />
                            <Siar:Button ID="btnEliminaValore" runat="server" Width="127px" Text="Elimina" Modifica="true"
                                Enabled="False" Conferma="Confermare eliminazione ?" OnClick="btnElimina_Click">
                            </Siar:Button>
                            <Siar:Button ID="btnNewValoriMultiplo" runat="server" Text="Nuovo" CausesValidation="false"
                                OnClick="btnNewValoriMultiplo_Click" Width="127px" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" colspan="2">
                            &nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <Siar:DataGrid ID="dgValoriMultipli" runat="server" Width="100%" PageSize="20" AllowPaging="True"
                                AutoGenerateColumns="False">
                                <Columns>
                                    <Siar:NumberColumn HeaderText="Nr.">
                                        <ItemStyle Width="35px" HorizontalAlign="center" />
                                    </Siar:NumberColumn>
                                    <asp:BoundColumn DataField="Codice" HeaderText="Codice">
                                        <ItemStyle Width="80px" />
                                    </asp:BoundColumn>
                                    <Siar:ColonnaLink DataField="Descrizione" HeaderText="Descrizione" LinkFields="IdValore"
                                        LinkFormat="javascript:selezionaValorePriorita({0});">
                                    </Siar:ColonnaLink>
                                    <asp:BoundColumn DataField="Punteggio" HeaderText="Punteggio" DataFormatString="{0:N}">
                                        <ItemStyle Width="80px" />
                                    </asp:BoundColumn>
                                </Columns>
                            </Siar:DataGrid>
                            <br />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table id="tablePlurivaloreDinamico" width="100%" runat="server" visible="false">
                    <tr>
                        <td colspan="2" class="separatore">
                            Inserimento query per plurivalore dinamico
                        </td>
                    </tr>
                    <tr>
                        <td align="right" colspan="2">
                            &nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" style="width: 184px;">
                            <b>Query SQL plurivalore:</b>
                        </td>
                        <td>
                            <Siar:TextArea ID="txtQueryPlurivalore" runat="server" Width="400px" Rows="10" />&nbsp;
                            <asp:RequiredFieldValidator ID="rfvQueryPlurivalore" runat="server" ErrorMessage="Query obbligatoria"
                                ValidationGroup="vgQueryPlurivalore" ControlToValidate="txtQueryPlurivalore">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" colspan="2">
                            &nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="right" colspan="2">
                            <Siar:Button ID="btnSalvaQueryPlurivalore" runat="server" Modifica="True" Text="Salva Query"
                                ValidationGroup="vgQueryPlurivalore" OnClick="btnSalvaQueryPlurivalore_Click" Width="127px" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
