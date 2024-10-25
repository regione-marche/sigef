<%@ Page Title="" Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    CodeBehind="Psr.aspx.cs" Inherits="web.Private.regione.zProgrammazione" %>

<%@ Register Src="../../../CONTROLS/SiarNewTab.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>
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
    <uc1:SiarNewTab ID="ucSiarNewTab" runat="server" TabNames="PROGRAMMAZIONE|Modifica programma"
        Width="1000px" />
    <table id="tableElenco" runat="server" class="tableTab" width="1000px">
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="padding-top: 20px; padding-bottom: 20px">
                <Siar:DataGrid ID="dgPsr" runat="server" AutoGenerateColumns="False" Width="100%">
                    <ItemStyle Height="30px" />
                    <Columns>
                        <Siar:NumberColumn>
                            <ItemStyle Width="35px" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="Descrizione"></asp:BoundColumn>
                        <asp:BoundColumn DataField="AnnoDa" HeaderText="Anno da">
                            <ItemStyle Width="90px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="AnnoA" HeaderText="Anno a">
                            <ItemStyle Width="90px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Cci" HeaderText="CCI"></asp:BoundColumn>
                        <Siar:JsButtonColumn Arguments="Codice" JsFunction="selezionaPsr" ButtonText="Programmazione">
                            <ItemStyle Width="150px" HorizontalAlign="Center" />
                        </Siar:JsButtonColumn>
                        <Siar:JsButtonColumn Arguments="Codice" JsFunction="modificaPsr" ButtonText="Modifica">
                            <ItemStyle Width="150px" HorizontalAlign="Center" />
                        </Siar:JsButtonColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
        <tr id="trProgrammazione" runat="server">
            <td>
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="paragrafo">
                            <br />
                            Programmazione:
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-top: 10px; padding-bottom: 10px">
                            <input type="button" class="Button" value="Aggiungi elemento di primo livello" onclick='mostraDettaglioProgrammazione(0);'
                                style="width: 230px; position: relative; left: 650px" />
                            <Siar:DataGrid ID="dgProgrammazione" runat="server" AutoGenerateColumns="False" Width="100%">
                                <ItemStyle Height="22px" />
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
                                    <Siar:JsButtonColumn Arguments="Id" JsFunction="mostraDettaglioProgrammazione" ButtonType="ImageButton"
                                        ButtonText="Dettaglio elemento" ButtonImage="lente.png">
                                        <ItemStyle Width="50px" HorizontalAlign="Center" />
                                    </Siar:JsButtonColumn>
                                </Columns>
                            </Siar:DataGrid>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table id="tableModifica" runat="server" class="tableTab" width="1000px">
        <tr>
            <td class="paragrafo">
                <br />
                Dettaglio programma:
            </td>
        </tr>
        <tr>
            <td style="padding: 10px">
                <table width="100%">
                    <tr>
                        <td>
                            <table width="100%">
                                <tr>
                                    <td style="width: 185px">
                                        Codice:
                                        <br />
                                        <Siar:TextBox ID="txtPsrCodice" runat="server" Width="150px" MaxLength="20" NomeCampo="Codice"
                                            Obbligatorio="True" />
                                        <br />
                                    </td>
                                    <td style="width: 100px">
                                        Anno da:
                                        <br />
                                        <Siar:IntegerTextBox ID="txtPsrAnnoDa" runat="server" NoCurrency="True" Width="80px"
                                            NomeCampo="Anno da" Obbligatorio="True" MaxValue="2100" MinValue="1950" />
                                        <br />
                                    </td>
                                    <td style="width: 100px">
                                        Anno a:
                                        <br />
                                        <Siar:IntegerTextBox ID="txtPsrAnnoA" runat="server" NoCurrency="True" Width="80px"
                                            NomeCampo="Anno a" Obbligatorio="True" MaxValue="2200" MinValue="1950" />
                                    </td>
                                    <td>
                                        CCI:
                                        <br />
                                        <Siar:TextBox ID="txtPsrCci" runat="server" Width="200px" MaxLength="50" NomeCampo="Cci" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Descrizione:
                            <br />
                            <Siar:TextArea ID="txtPsrDescrizione" runat="server" Width="700px" Rows="5" NomeCampo="Descrizione"
                                Obbligatorio="True" MaxLength="2000" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 60px; padding-right: 50px; text-align: right">
                            &nbsp;
                            <Siar:Button ID="btnPsrSalva" runat="server" OnClick="btnPsrSalva_Click" Text="Salva"
                                Width="160px" Modifica="True" />
                            &nbsp;&nbsp; &nbsp;<Siar:Button ID="btnPsrElimina" runat="server" OnClick="btnPsrElimina_Click"
                                Text="Elimina" Width="160px" Modifica="True" CausesValidation="False" Conferma="Attenzione! Eliminare il programma selezionato e la sua struttura a livelli?" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <Siar:Button ID="btnPsrNuovo" runat="server" OnClick="btnPsrNuovo_Click" Text="Nuovo"
                                Width="140px" Modifica="True" CausesValidation="False" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr id="trPsrAlbero" runat="server">
            <td>
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="paragrafo">
                            <br />
                            Struttura programmazione:
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 10px">
                            <table width="100%">
                                <tr>
                                    <td>
                                        <table width="100%">
                                            <tr>
                                                <td style="width: 256px">
                                                    Codice:
                                                    <br />
                                                    <Siar:TextBox ID="txtPrgCodice" runat="server" Width="201px" MaxLength="30" ReadOnly="True" />
                                                    <br />
                                                </td>
                                                <td style="width: 120px">
                                                    Livello:
                                                    <br />
                                                    <Siar:IntegerTextBox ID="txtPrgLivello" runat="server" NoCurrency="False" Width="80px"
                                                        ReadOnly="True" />
                                                </td>
                                                <td>
                                                    <br />
                                                    <asp:CheckBox ID="chkPrgAttivazioneBandi" runat="server" Text="Attivazione nei bandi" />
                                                    &nbsp;<asp:CheckBox ID="chkPrgAttivazioneFA" runat="server" Text="Aggancio Focus Area" />
                                                    &nbsp;<asp:CheckBox ID="chkPrgAttivazioneOBMisura" runat="server" Text="Aggancio Obiettivi di Misura" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Descrizione:
                                        <br />
                                        <Siar:TextBox ID="txtPrgDescrizione" runat="server" Width="493px" MaxLength="50" />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:CheckBox ID="chkPrgAttivazioneInvestimenti" runat="server" Text="Aggancio Investimenti" />
                                        &nbsp;&nbsp;
                                        <asp:CheckBox ID="chkPrgAttivazioneFF" runat="server" Text="Aggancio Fonti Finanziarie" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 60px; padding-right: 50px; text-align: right">
                                        &nbsp;
                                        <Siar:Button ID="btnPrgSalva" runat="server" OnClick="btnPrgSalva_Click" Text="Salva"
                                            Width="160px" Modifica="True" CausesValidation="False" />
                                        &nbsp;&nbsp; &nbsp;<Siar:Button ID="btnPrgElimina" runat="server" OnClick="btnPrgElimina_Click"
                                            Text="Elimina" Width="160px" Modifica="True" CausesValidation="False" />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <Siar:Button ID="btnPrgNuovo" runat="server" OnClick="btnPrgNuovo_Click" Text="Nuovo"
                                            Width="140px" Modifica="True" CausesValidation="False" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                            <Siar:DataGrid ID="dgPsrAlbero" runat="server" AutoGenerateColumns="False" Width="100%">
                                <ItemStyle Height="24px" />
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
                                    <Siar:JsButtonColumn Arguments="Codice" JsFunction="selezionaPsrAlbero" ButtonText="Seleziona">
                                        <ItemStyle Width="150px" HorizontalAlign="Center" />
                                    </Siar:JsButtonColumn>
                                </Columns>
                            </Siar:DataGrid>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <div id="divDettaglioProgrammazione" class="hidden" style="width: 900px">
        <table width="100%" class="tableNoTab">
            <tr>
                <td class="separatore">
                    Dettaglio elemento di programmazione:
                </td>
            </tr>
            <tr>
                <td style="padding: 10px">
                    <table width="100%">
                        <tr>
                            <td>
                                <table width="100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="width: 190px">
                                            Codice:
                                            <br />
                                            <Siar:TextBox ID="txtDPCodice" runat="server" Width="151px" />
                                        </td>
                                        <td style="width: 210px">
                                            Livello:
                                            <br />
                                            <Siar:TextBox ID="txtDPTipo" runat="server" Width="190px" ReadOnly="true" />
                                        </td>
                                        <td>
                                            <br />
                                            <input id="btnDPSelezionaPadre" runat="server" type="button" class="ButtonGrid" value="Livello superiore"
                                                style="width: 120px" disabled="disabled" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Descrizione:<br />
                                <Siar:TextArea ID="txtDPDescrizione" MaxLength="2000" runat="server" Rows="3" Width="585px" />
                            </td>
                        </tr>
                        <tr>
                            <%-- <td ID="tdTxtDotazione"  runat="server" visible="false">
                                Importo Dotazione:<br />
                                <Siar:TextArea ID="txtDotazione" runat="server" Width="151px"/>
                            </td>--%>
                            <td style="width: 190px" id="tdTxtDotazione" runat="server" visible="false">
                                Importo Dotazione:
                                <br />
                                <Siar:TextBox ID="txtDotazione" runat="server" Width="151px" />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 60px; padding-right: 30px" align="right">
                                <Siar:Button ID="btnDPSalva" runat="server" Text="Salva" Width="160px" Modifica="True"
                                    CausesValidation="False" OnClick="btnDPSalva_Click" />
                                &nbsp;&nbsp;&nbsp;<Siar:Button ID="btnDPElimina" runat="server" Text="Elimina" Width="160px"
                                    Modifica="True" CausesValidation="False" OnClick="btnDPElimina_Click" Conferma="Attenzione! Eliminare l`elemento di programmazione selezionato?" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <input type="button" class="Button" value="Chiudi" style="width: 120px" onclick="chiudiDettaglioProgrammazione();" />
                            </td>
                        </tr>
                        <tr id="trDPSottoelemento1" runat="server">
                            <td class="paragrafo">
                                Aggiungi sottoelemento:
                            </td>
                        </tr>
                        <tr id="trDPSottoelemento2" runat="server">
                            <td>
                                <table width="100%">
                                    <tr>
                                        <td style="width: 190px">
                                            Codice:
                                            <br />
                                            <Siar:TextBox ID="txtDPSECodice" runat="server" Width="151px" />
                                        </td>
                                        <td>
                                            Livello:
                                            <br />
                                            <Siar:ComboSql ID="lstDPLivello" runat="server" DataTextField="DESCRIZIONE" DataValueField="CODICE">
                                            </Siar:ComboSql>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            Descrizione:<br />
                                            <Siar:TextArea ID="txtDPSEDescrizione" MaxLength="2000" runat="server" Rows="3" Width="585px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 190px" id="tdTxtDPImporto" runat="server" visible="false">
                                            Importo Dotazione:
                                            <br />
                                            <Siar:TextBox ID="txtDPImporto" runat="server" Width="151px" />
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td style="padding-right: 30px" align="right" colspan="2">
                                            <br />
                                            <Siar:Button ID="btnDPSESalva" runat="server" Text="Aggiungi" Width="160px" Modifica="True"
                                                CausesValidation="False" OnClick="btnDPSESalva_Click" />
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
                    <Siar:DataGrid ID="dgDPProgrammazione" runat="server" AutoGenerateColumns="False"
                        Width="100%" AllowPaging="true" PageSize="5">
                        <Columns>
                            <asp:BoundColumn DataField="Codice" HeaderText="Codice">
                                <ItemStyle Width="70px" HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione"></asp:BoundColumn>
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
                            <Siar:JsButtonColumn Arguments="Id" ButtonImage="lente.png" ButtonType="ImageButton"
                                ButtonText="Seleziona" JsFunction="mostraDettaglioProgrammazione">
                                <ItemStyle Width="50px" HorizontalAlign="Center" />
                            </Siar:JsButtonColumn>
                        </Columns>
                    </Siar:DataGrid>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
