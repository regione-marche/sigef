<%@ Page Language="c#" MasterPageFile="~/SiarPage.master" Inherits="web.Private.Psr.Bandi.CodificaInvestimento"
    AutoEventWireup="true" CodeBehind="CodificaInvestimento.aspx.cs" %>

<%@ Register Src="../../../CONTROLS/SiarNewTab.ascx" TagName="SiarNewTab" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
        function pulisciCampiCodifica() {
            $('[id$=txtDescrizione_text]').val(''); $('[id$=txtCodice_text]').val(''); $('[id$=hdnIdCodificaInvestimento]').val(''); $('[id$=txtValMinimo_text]').val(''); $('[id$=lstInterventiBando]').val('');
            //$('[id$=lstTipologiaProgetto]').val('');
            $('[id$=chkIsMax]')[0].checked = false; $('[id$=btnEliminaCodifica]').attr("disabled", "disabled");
        }
        function pulisciCampiDettaglio() {
            $('[id$=txtDescrizioneDettaglio_text]').val(''); $('[id$=txtCodDettaglio_text]').val(''); $('[id$=hdnIdDettaglioInvestimento]').val(''); $('[id$=txtPercSpeseGenerali_text]').val('');
            $('[id$=btnEliminaDettaglio]').attr("disabled","disabled");$('[id$=lstUdmDettaglio]').val('');
        }
        function pulisciCampiSpecifica() {
            $('[id$=txtDescrizioneSpecifica_text]').val('');$('[id$=txtCodiceSpecifica_text]').val('');
            $('[id$=hdnIdSpecificaInvestimento]').val('');$('[id$=btnEliminaSpecifica]').attr("disabled","disabled");
        }

        function pulisciCampiDettaglioQuery() {
            $('[id$=txtQuerySQL]').val(''); $('[id$=hdnIdCodificaInvestimentoXQuery]').val('');
        }
        function pulisciCampiDettaglioAltreFonti() {
            $('[id$=txtQuerySQLAltreFonti]').val(''); $('[id$=txtContributoAltreFonti]').val(''); $('[id$=hdnIdCodificaInvestimentoAltreFonti]').val('');
        }

        function pulisciCampiStrumentiRNA() {
            $('[id$=hdnIdComponenteSelezionata]').val("");
        }
        
        function caricaCodifica(id) { $('[id$=hdnIdCodificaInvestimento]').val(id);$('[id$=btnCaricaCodifica]').click(); }
        function caricaDettaglio(id) { $('[id$=hdnIdDettaglioInvestimento]').val(id);$('[id$=btnCaricaDettaglio]').click(); }
        function caricaSpecifica(id) { $('[id$=hdnIdSpecificaInvestimento]').val(id);$('[id$=btnCaricaSpecifica]').click(); }
        function ctrlCampiDettaglio(ev) {
            if($('[id$=lstCodificaInvestimenti]').val()==''||$('[id$=txtCodDettaglio_text]').val()==''||$('[id$=txtDescrizioneDettaglio_text]').val()==''
            ||$('[id$=txtPercSpeseGenerali_text]').val()==''||$('[id$=lstUdmDettaglio]').val()=='') { alert('Per proseguie è necessario specificare tutti i campi obbligatori.');return false; }
        }
        function ctrlCampiSpecifica(ev) {
            if($('[id$=lstGroupSpecificaInvestimenti]').val()==''||$('[id$=txtCodiceSpecifica_text]').val()==''||$('[id$=txtDescrizioneSpecifica_text]').val()=='') { alert('Per proseguie è necessario specificare tutti i campi obbligatori.');return false; }
        }
        function caricaCosto(idCod, idCosto) {
            $('[id$=hdnIdCodificaInvestimento]').val(idCod);
            $('[id$=hdnIdCosto]').val(idCosto);
            $('[id$=lstCodificaInvestimentiCosti]').val(idCod);
            $('[id$=lstCostiRNA]').val(idCosto);
        }
        function controllaInvioRegolamenti() {
            var corretto = true;
            $(':checkbox:checked').each(function () {
                var sThisVal = (this.checked ? $(this).val() : "");
                var idObiettivo = $('[name=idObiettivo_' + sThisVal + ']').val();
                if (idObiettivo == '' || idObiettivo == null)
                    corretto = false;
            });
            if (!corretto)
            {
                alert("Inserire un obiettivo per ogni regolamento selezionato.");
                return false;
            }
            return true;
        }
        function selezionaComponenteStrumenti(idComp)
        {
            if ($('[id$=hdnIdComponenteSelezionata]').val() == null || $('[id$=hdnIdComponenteSelezionata]').val() == "") {
                $('[id$=hdnIdComponenteSelezionata]').val(idComp);
                $('[id$=lstStrumentiRNA]').val(0);
                $('[id$=hdnStrumentoSelezionato]').val("");
            }
            else {
                $('[id$=hdnIdComponenteSelezionata]').val("");
                $('[id$=hdnStrumentoSelezionato]').val("");
            }
            $('[id$=btnProgrammazionePost]').click();
        }
        function caricaStrumento(idStrumentoComponente, codStrumento, intensita) {
            $('[id$=hdnStrumentoSelezionato]').val(idStrumentoComponente);
            $('[id$=lstStrumentiRNA]').val(codStrumento);
            $('[id$=percStrumentiRNA]').val(intensita);
        }
        function verificaEliminaStrumento() {
            if ($('[id$=lstStrumentiRNA]').val() == null || $('[id$=lstStrumentiRNA]').val() == "") {
                alert("Selezionare uno strumento da eliminare");
                return false;
            }
            return true;
        }
        function verificaSalvaStrumento() {
            var nuovaIntensita = parseFloat($('[id$=percStrumentiRNA]').val().replace(",","."));
            //var totIntensita = nuovaIntensita;
            if ($('[id$=lstStrumentiRNA]').val() == null || $('[id$=lstStrumentiRNA]').val() == "") {
                alert("Selezionare uno strumento da eliminare");
                return false;
            }
            if (nuovaIntensita == null || nuovaIntensita == "") {
                alert("Inserire un'intensità d'aiuto valida");
                return false;
            }
            //$('.intensitaStrumento').each(function () {
            //    totIntensita += parseFloat($(this).html().replace(",","."));
            //});
            //if (totIntensita > 100) {
            //    alert("La somma delle intensità non può superare il 100%");
            //    return false;
            //}
            //if (totIntensita < 100)
            //    alert("Attenzione, la somma delle intensità dovrà essere del 100%");
            return true;
        }
        function verificaSalvaCosto() {
            if($('[id$=lstCodificaInvestimentiCosti]').val() == null || $('[id$=lstCodificaInvestimentiCosti]').val() == "") {
                alert("Selezionare un investimento");
                return false;
            }
            if ($('[id$=lstCostiRNA]').val() == null || $('[id$=lstCostiRNA]').val() == "") {
                alert("Selezionare un costo da associare");
                return false;
            }
            return true;
        }
        function verificaEliminaCosto() {
            if ($('[id$=lstCodificaInvestimentiCosti]').val() == null || $('[id$=lstCodificaInvestimentiCosti]').val() == "") {
                alert("Selezionare un investimento da eliminare");
                return false;
            }
            if ($('[id$=lstCostiRNA]').val() == null || $('[id$=lstCostiRNA]').val() == "") {
                alert("Selezionare il costo da eliminare");
                return false;
            }
            return true;
        }
        
//--></script>

    <br />
    
    <uc2:SiarNewTab ID="ucSiarNewTab" runat="server" TabNames="Codifica investimenti|Dettaglio investimenti|Specifica investimenti|Query SQL|Altre Fonti|RNA Bando|RNA Costi|RNA Componenti|RNA Strumenti"
        Width="1200px" />
    
    <table id="tbCodifica" runat="server" width="1200" class="tableTab">
        <tr>
            <td class="paragrafo">
                <br />
                Nuova codifica:
            </td>
        </tr>
        <tr>
            <td style="padding: 10px">
                <div style="display: none">
                    <input type="hidden" id="hdnIdCodificaInvestimento" runat="server" />
                    <Siar:Button ID="btnCaricaCodifica" runat="server" OnClick="btnCaricaCodifica_Click"
                        Modifica="False" CausesValidation="False" /></div>
                <table width="100%">
                    <tr>
                        <td>
                            Intervento:<br />
                            <Siar:ComboInterventiBando ID="lstInterventiBando" runat="server" Obbligatorio="true" NomeCampo="Intervento"></Siar:ComboInterventiBando>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Codice:<br />
                            <Siar:TextBox ID="txtCodice" runat="server" MaxLength="20" Width="140px" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Descrizione:<br />
                            <Siar:TextArea ID="txtDescrizione" runat="server" Width="480px" NomeCampo="Descrizione Codifica"
                                Obbligatorio="True"></Siar:TextArea>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table id="tab">
                                <tr>
                                    <td style="width: 170px; height: 47px;">
                                        <strong>Contributo minimo %:</strong>
                                    </td>
                                    <td style="width: 120px; height: 47px;">
                                        <Siar:QuotaBox ID="txtValMinimo" NrDecimali="12" runat="server" Width="110px" NomeCampo="Aiuto minimo"
                                            Obbligatorio="True" />
                                    </td>
                                    <td align="right" style="height: 47px">
                                        <asp:CheckBox ID="chkIsMax" runat="server" Text="tale percentuale è la massima da attribuire : "
                                            TextAlign="Left" />
                                    </td>
                                </tr>
                            </table>
                            <%--(inserire la durati in anni del mutuo per il premio in conto interessi)<br />--%>
                        </td>
                    </tr>
                    <%--<tr>
                        <td style="height: 63px">
                            Tip. Progetto:<br />
                            <Siar:ComboZTp ID="lstTipologiaProgetto" runat="server" >
                            </Siar:ComboZTp>
                        </td>
                    </tr>--%>
                    <tr>
                        <td align="right" style="padding-right: 40px; height: 60px">
                            <Siar:Button ID="btnSalvaCodifica" runat="server" Text="Salva" Width="150px" OnClick="btnSalvaCodifica_Click"
                                Modifica="True" />&nbsp; &nbsp;<Siar:Button ID="btnEliminaCodifica" runat="server"
                                    Text="Elimina" Width="150px" Modifica="True" OnClick="btnEliminaCodifica_Click"
                                    CausesValidation="false" Conferma="Eliminare la codifica di investimento selezionata?" />&nbsp;&nbsp;&nbsp;&nbsp;
                            <input type="button" value="Nuovo" style="width: 110px" class="Button" onclick="pulisciCampiCodifica()" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="separatore">
                Elenco codifiche:
            </td>
        </tr>
        <tr>
            <td>
                <br />
                <Siar:DataGrid ID="dgCodificaInvestimento" runat="server" Width="100%" AllowPaging="True"
                    PageSize="15" AutoGenerateColumns="False">
                    <ItemStyle Height="28px" />
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle Width="30px" HorizontalAlign="center" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn  HeaderText="Intervento">
                            <ItemStyle HorizontalAlign="Center" Width="90px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Codice" HeaderText="Codice">
                            <ItemStyle HorizontalAlign="Center" Width="90px" />
                        </asp:BoundColumn>
                        <Siar:ColonnaLink DataField="Descrizione" HeaderText="Descrizione" IsJavascript="true"
                            LinkFields="IdCodificaInvestimento" LinkFormat="caricaCodifica({0});">
                        </Siar:ColonnaLink>
                        <asp:BoundColumn DataField="AiutoMinimo" HeaderText="% Aiuto Minimo">
                            <ItemStyle HorizontalAlign="Right" Width="100px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="IsMax" HeaderText="Quota massima" DataFormatString="{0:SI|NO}">
                            <ItemStyle HorizontalAlign="center" Width="100px" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid><br />
            </td>
        </tr>
    </table>
    
    <table id="tbDettaglio" runat="server" width="1200px" class="tableTab">
        <tr>
            <td style="padding: 10px">
                <b>Selezionare la codifica d&#39;investimento:</b><br />
                <Siar:ComboCodificaInvestimenti ID="lstCodificaInvestimenti" runat="server" AutoPostBack="true"
                    Width="600px">
                </Siar:ComboCodificaInvestimenti>
            </td>
        </tr>
        <tr>
            <td class="paragrafo">
                Nuovo dettaglio:
            </td>
        </tr>
        <tr>
            <td style="padding: 10px">
                <div style="display: none">
                    <asp:Button ID="btnCaricaDettaglio" runat="server" OnClick="btnCaricaDettaglio_Click"
                        Text="Button" />
                    <asp:HiddenField ID="hdnIdDettaglioInvestimento" runat="server" />
                </div>
                <table width="100%">
                    <tr>
                        <td>
                            Codice:<br />
                            <Siar:TextBox runat="server" ID="txtCodDettaglio" MaxLength="20" Width="140px" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Descrizione:<br />
                            <Siar:TextArea ID="txtDescrizioneDettaglio" DataColumn="Descrizione" runat="server"
                                Width="500px" Rows="2" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Unità di misura:<br />
                            <Siar:ComboUnitaMisura ID="lstUdmDettaglio" runat="server" Width="200px">
                            </Siar:ComboUnitaMisura>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:CheckBox ID="chkMobile" runat="server" Text="Investimento mobile:" TextAlign="Left"
                                Visible="False"></asp:CheckBox>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:CheckBox ID="chkParticella" runat="server" Text="Richiedi particella:" TextAlign="Left"
                                Visible="False"></asp:CheckBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right: 40px; height: 60px">
                <Siar:Button ID="btnSalvaDettaglio" runat="server" Modifica="true" Text="Salva" Width="150px"
                    OnClick="btnSalvaDettaglio_Click" CausesValidation="false" OnClientClick="return ctrlCampiDettaglio(event);" />
                &nbsp; &nbsp;<Siar:Button ID="btnEliminaDettaglio" runat="server" Text="Elimina"
                    Conferma="Eliminare il dettaglio di investimento selezionato?" Width="150px"
                    Modifica="True" OnClick="btnEliminaDettaglio_Click" CausesValidation="false" />&nbsp;&nbsp;&nbsp;&nbsp;
                <input type="button" value="Nuovo" style="width: 110px" class="Button" onclick="pulisciCampiDettaglio()" />
            </td>
        </tr>
        <tr>
            <td class="separatore">
                Elenco dettagli:
            </td>
        </tr>
        <tr>
            <td>
                <br/>
                <Siar:DataGrid ID="dgDettaglio" runat="server" Width="100%" AllowPaging="True" PageSize="15"
                    AutoGenerateColumns="False">
                    <ItemStyle Height="28px" />
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle HorizontalAlign="Center" Width="30px" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="CodDettaglio" HeaderText="Codice">
                            <ItemStyle HorizontalAlign="center" Width="50px" />
                        </asp:BoundColumn>
                        <Siar:ColonnaLink DataField="Descrizione" HeaderText="Descrizione" IsJavascript="true"
                            LinkFields="IdDettaglioInvestimento" LinkFormat="caricaDettaglio({0});">
                        </Siar:ColonnaLink>
                        <%--<asp:BoundColumn DataField="Mobile" HeaderText="Mobile" DataFormatString="{0:SI|NO}">
                            <ItemStyle HorizontalAlign="Center" Width="70px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="RichiediParticella" DataFormatString="{0:SI|NO}" HeaderText="Particella">
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                        </asp:BoundColumn>--%>
                        <asp:BoundColumn HeaderText="Unità di misura">
                            <ItemStyle HorizontalAlign="center" Width="100px" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid><br />
            </td>
        </tr>
    </table>

    <table id="tbSpecifica" runat="server" width="1200px" class="tableTab">
        <tr>
            <td style="padding: 10px">
                <b>Selezionare il dettaglio d'investimento:</b><br />
                <Siar:ComboGroupSpecificaInvestimenti ID="lstGroupSpecificaInvestimenti" PostBackOnChange="true"
                    runat="server" Width="600px">
                </Siar:ComboGroupSpecificaInvestimenti>
            </td>
        </tr>
        <tr>
            <td class="paragrafo">
                Nuova specifica:
            </td>
        </tr>
        <tr>
            <td style="padding: 10px">
                <div style="display: none">
                    <asp:Button ID="btnCaricaSpecifica" runat="server" OnClick="btnCaricaSpecifica_Click"
                        Text="Button" />
                    <asp:HiddenField ID="hdnIdSpecificaInvestimento" runat="server" />
                </div>
                <table width="100%">
                    <tr>
                        <td>
                            Codice:<br />
                            <Siar:TextBox MaxLength="20" runat="server" ID="txtCodiceSpecifica" Width="140px" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Descrizione:<br />
                            <Siar:TextArea ID="txtDescrizioneSpecifica" Rows="2" runat="server" Width="500px" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="padding-right: 40px; height: 60px">
                            <Siar:Button ID="btnSalvaSpecifica" runat="server" Text="Salva" Width="150px" OnClick="btnSalvaSpecifica_Click"
                                OnClientClick="return ctrlCampiSpecifica(event);" Modifica="True" CausesValidation="false" />
                            &nbsp;&nbsp;
                            <Siar:Button ID="btnEliminaSpecifica" runat="server" Text="Elimina" Width="150px"
                                Conferma="Eliminare la specifica di investimento selezionata?" Modifica="True"
                                CausesValidation="false" OnClick="btnEliminaSpecifica_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                            <input type="button" value="Nuovo" style="width: 110px" class="Button" onclick="pulisciCampiSpecifica()" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="separatore">
                Elenco specifiche:
            </td>
        </tr>
        <tr>
            <td>
                <br />
                <Siar:DataGrid ID="dgSpecifica" runat="server" Width="100%" AllowPaging="True" PageSize="15"
                    AutoGenerateColumns="False">
                    <ItemStyle Height="28px" />
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle HorizontalAlign="center" Width="30px"></ItemStyle>
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="CodSpecifica" HeaderText="Codice">
                            <ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
                        </asp:BoundColumn>
                        <Siar:ColonnaLink DataField="Descrizione" HeaderText="Descrizione" IsJavascript="true"
                            LinkFields="IdSpecificaInvestimento" LinkFormat="caricaSpecifica({0});">
                        </Siar:ColonnaLink>
                    </Columns>
                </Siar:DataGrid><br />
            </td>
        </tr>
    </table>

    <table id="tbQuery" runat="server" width="1200px" class="tableTab">
        <tr>
            <td style="padding: 10px">
                <div style="display: none">
                    <input type="hidden" id="hdnIdCodificaInvestimentoXQuery" runat="server" />
                </div>
                <b>Selezionare la codifica d&#39;investimento:</b><br />
                <Siar:ComboCodificaInvestimenti ID="ComboCodificaInvestimenti" runat="server" AutoPostBack="true"
                    Width="600px">
                </Siar:ComboCodificaInvestimenti>
            </td>
        </tr>
        <tr>
            <td class="paragrafo">
                Nuova Query:
            </td>
        </tr>
        <tr>
            <td style="padding: 10px">
                <table width="100%">
                    <tr>
                        <td>
                            Query SQL:<br />
                              <Siar:TextArea ID="txtQuerySQL" MaxLength="3000" runat="server" Width="715px" Rows="10" />                
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="padding-right: 40px; height: 60px">
                            <Siar:Button ID="btnSalvaCodificaQuery" runat="server" Text="Salva" Width="150px" OnClick="btnSalvaCodificaQuery_Click"
                                 Modifica="True" CausesValidation="false" />
                            &nbsp;&nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

    <table id="tbAltreFonti" runat="server" width="1200px" class="tableTab">
        <tr>
            <td style="padding: 10px">
                <div style="display: none">
                    <input type="hidden" id="hdnIdCodificaInvestimentoAltreFonti" runat="server" />
                </div>
                <b>Selezionare la codifica d&#39;investimento:</b><br />
                <Siar:ComboCodificaInvestimenti ID="ComboCodificaInvestimentiAltreFonti" runat="server" AutoPostBack="true"
                    Width="600px">
                </Siar:ComboCodificaInvestimenti>
            </td>
        </tr>
        <tr>
            <td class="paragrafo">
                Codifica Altre Fonti:
            </td>
        </tr>
        <tr>
            <td style="padding: 10px">
                <table width="100%">
                    <tr>
                        <td>
                            <table id="Table1">
                                <tr>
                                    <td style="width: 135px; height: 47px;">
                                        <strong>Contributo minimo %:</strong>
                                    </td>
                                    <td style="width: 150px; height: 47px;">
                                        <Siar:QuotaBox NrDecimali="12" ID="txtContributoAltreFonti" runat="server" Width="110px" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Query SQL:<br />
                              <Siar:TextArea ID="txtQuerySQLAltreFonti" MaxLength="3000" runat="server" Width="715px" Rows="10" />                
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="padding-right: 40px; height: 60px">
                            <Siar:Button ID="btnSalvaCodificaAltreFonti" runat="server" Text="Salva" Width="150px" OnClick="btnSalvaCodificaAltreFonti_Click"
                                 Modifica="True" CausesValidation="false" />
                            &nbsp;&nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    
    <table id="tbBandoRNA" runat="server" width="1200px" class="tableTab">
        <tr>
            <td><br />
                <div id="genericoBandoRNA" runat="server">
                    <div style="display: inline-block; padding-left: 20px; padding-bottom: 5px">
                        Codice Bando RNA:<br />
                        <asp:TextBox ID="txtCodiceBandoRNA" runat="server" Width="50px" Style="padding-left: 10px" />
                    </div>
                    <div style="display: inline-block; padding-left: 20px; padding-bottom: 5px; margin-right: 30px;">
                        Cumulabilità:<br />
                        <Siar:Combo ID="comboCumulabilita" runat="server" Width="100px"></Siar:Combo>
                    </div>
                    <div style="display: inline-block; padding-left: 20px; padding-bottom: 5px; margin-right: 30px;">
                        Descrizione Ente:<br />
                        <Siar:Combo ID="cmbEnteAccount" runat="server"></Siar:Combo>
                    </div>
                    <div style=" padding-left: 20px; padding-bottom: 5px; margin-right: 30px;">
                        Codice Bando RNA Collaudo (Solo per i bandi di test):<br />
                        <Siar:TextBox ID="txtCodiceBandoRnaCollaudo" runat="server" Width="100px"></Siar:TextBox>
                    </div>
                    <div style="padding-left: 20px; padding-bottom: 5px; margin-right: 30px;">
                        Data Prevista Concessione:<br />
                        <Siar:DateTextBox ID="txtDataConcessione" runat="server" Width="100px"></Siar:DateTextBox>
                    </div>
                    <div style=" padding-left: 20px; padding-bottom: 5px;">
                    <Siar:Button ID="salvaDatiBandoRna" runat="server" Text="Salva" Width="150px" OnClick="btnSalvaDatiBandoRna_Click"
                         CausesValidation="false" />
                        </div>
                </div><br />
            </td>
        </tr>
        <tr id="datiBandoRNA" style="display:none">
            <td>
                <div class="paragrafo"></div>
                <br /><b style="padding-left: 20px; padding-bottom: 5px">Dettagli:</b><br /><br />
                <div style="display: inline-block; padding-left: 20px; padding-bottom: 5px">
                    Codice Bando RNA:<br />
                    <asp:Label ID="lblCodBandoRNA" runat="server" Style="padding-left: 10px; " />
                </div>
                <div style="display: inline-block; padding-left: 20px; padding-bottom: 5px">
                    Cumulabilità:<br />
                    <asp:Label ID="lblCumulabilita" runat="server" Style="padding-left: 10px; " />
                </div>
                <div style="display: inline-block; padding-left: 20px; padding-bottom: 5px">
                    Codice Bando RNA Collaudo:<br />
                    <asp:Label ID="lblCodiceBandoRnaCollaudo" runat="server" Style="padding-left: 10px;" />
                </div>
                <div style="display: inline-block; padding-left: 20px; padding-bottom: 5px">
                    Data Prevista Concessione:<br />
                    <asp:Label ID="lblDataConcessione" runat="server" Style="padding-left: 10px;" />
                </div>
                <div style="display: inline-block; padding-left: 20px; padding-bottom: 5px">
                    Ente Bando:<br />
                    <asp:Label ID="lblDescrizioneEnte" runat="server" Style="padding-left: 10px;" />
                </div>
            </td>
        </tr>
    </table>
    
    <table id="tbCodificaRNA" runat="server" width="1200px" class="tableTab">
        <tr>
            <td style="padding: 10px">
                <b>Selezionare la codifica d&#39;investimento:</b><br />
                <Siar:ComboCodificaInvestimenti ID="lstCodificaInvestimentiCosti" runat="server"
                    Width="600px">
                </Siar:ComboCodificaInvestimenti>
            </td>
        </tr>
        <tr>
            <td style="padding: 10px">
                <b>Tipo Costo Investimento:</b><br />
                <Siar:ComboCostiRNA ID="lstCostiRNA" runat="server"
                    Width="600px">
                </Siar:ComboCostiRNA>
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right: 40px; height: 60px">
                <Siar:Button ID="SalvaCosto" runat="server" Text="Salva" Width="150px" OnClick="btnSalvaCosto_Click" OnClientClick="if(!verificaSalvaCosto()) return false;"
                    />&nbsp; &nbsp;
                <Siar:Button ID="EliminaCosto" runat="server"
                    Text="Elimina" Width="150px"  OnClick="btnEliminaCosto_Click" OnClientClick="if(!verificaEliminaCosto()) return false;"
                    CausesValidation="false" Conferma="Eliminare la codifica dell'investimento selezionata?" />&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td class="separatore">Elenco costi associati:
            </td>
        </tr>
        <tr>
            <td>
                <br />
                <Siar:DataGrid ID="dgCostixCodifica" runat="server" Width="100%" AllowPaging="True"
                    PageSize="15" AutoGenerateColumns="False">
                    <ItemStyle Height="28px" />
                    <Columns>
                        <Siar:ColonnaLink DataField="DescrizioneInvestimento" HeaderText="Descrizione Investimento" IsJavascript="true"
                            LinkFields="IdCodificaInvestimento|CodTipoSpesa" LinkFormat="caricaCosto({0},{1});">
                        </Siar:ColonnaLink>
                        <asp:BoundColumn DataField="Spesa" HeaderText="Descrizione Costo">
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid><br />
            </td>
        </tr>
    </table>
    <table id="tbRegolamentiRNA" runat="server" width="1200px" class="tableTab">
        <tr>
            <td style="padding: 10px">
                <b>Selezionare la codifica d&#39;investimento:</b><br />
                <Siar:ComboCodificaInvestimenti ID="lstCodificaInvestimentiRegolamenti" runat="server"
                    Width="600px" AutoPostBack="true">
                </Siar:ComboCodificaInvestimenti>
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dgRegolamentiRNA" runat="server" Width="100%" AllowPaging="false" AutoGenerateColumns="False">
                    <ItemStyle Height="26px" />
                    <Columns>
                        <asp:BoundColumn DataField="DescrizioneProcedura" HeaderText="Descrizione Procedura"></asp:BoundColumn>
                        <asp:BoundColumn DataField="CodiceRegolamento" HeaderText="Codice Regolamento">
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione"> <ItemStyle Width="450px" /></asp:BoundColumn>
                        <asp:BoundColumn DataField="Settore" HeaderText="Settore"></asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Obiettivo">
                            <ItemStyle Width="50px" /> 
                        </asp:BoundColumn>
                        <Siar:CheckColumn DataField="IdProcedimentiRegolamenti" HeaderSelectAll="false" Name="chkRegolamento"></Siar:CheckColumn>
                        <asp:BoundColumn DataField="IdProcedimentiRegolamenti" Visible="false"></asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right: 40px; height: 60px">
                <Siar:Button ID="salvaRegolamento" runat="server" Text="Salva" Width="150px" OnClick="btnSalvaRegolamento_Click" OnClientClick="if(!controllaInvioRegolamenti()) return false;"
                    />&nbsp; &nbsp;
                <Siar:Button ID="eliminaRegolamento" runat="server"
                        Text="Elimina" Width="150px"  OnClick="btnEliminaRegolamento_Click"
                        CausesValidation="false" Conferma="Rimuovere i regolamenti associati all'investimento selezionato?" />&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
        </tr>
    </table>
    
    <table id="tbStrumentiRNA" runat="server" width="1200px" class="tableTab">
        <tr>
            <td style="padding: 30px">
                <b>Selezionare la codifica d&#39;investimento:</b><br />
                <Siar:ComboCodificaInvestimenti ID="lstCodificaInvestimentiStrumenti" runat="server"
                    Width="600px" AutoPostBack="true">
                </Siar:ComboCodificaInvestimenti>
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dgRegolamentiXStrumentiRNA" runat="server" Width="100%" AllowPaging="false" AutoGenerateColumns="False">
                    <ItemStyle Height="26px" />
                    <Columns>
                        <Siar:ColonnaLink LinkFields="IdComponentiXCodifica" LinkFormat="selezionaComponenteStrumenti('{0}');" DataField="CodiceRegolamento" HeaderText="Codice Regolamento" IsJavascript="true"></Siar:ColonnaLink>
                        <asp:BoundColumn DataField="Settore" HeaderText="Settore"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione"><ItemStyle Width="450px" /></asp:BoundColumn>
                        <asp:BoundColumn DataField="Obiettivo" HeaderText="Obiettivo"></asp:BoundColumn>
                        <asp:BoundColumn DataField="IdComponentiXCodifica" HeaderText="IdComponentiXCodifica" Visible="false"></asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
        <tr id="trHideStrumentiRNA1" style="display: none;" runat="server">
            <td class="separatore">Nuovo strumento d&#39;aiuto
            </td>
        </tr>
        <tr id="trHideStrumentiRNA2" style="display: none;" runat="server">
            <td style="padding: 30px">
                <b>Inserisci un nuovo strumento d&#39;aiuto</b><br /><br />
                <div style="float:left; padding-right:20px;">
                    <b>Strumento d&#39;aiuto:</b><br /><br />
                    <div style="margin-top: 3px;"> <b>intensit&#224; strumento %:</b></div>
                </div>
                <div>
                    <Siar:ComboStrumentiRNA ID="lstStrumentiRNA" runat="server" Width="600px"></Siar:ComboStrumentiRNA><br />
                    <div style=" margin-top:10px;"><Siar:DecimalBox ID="percStrumentiRNA" Obbligatorio="true" runat="server" Width="50px" Text="100,00"/></div>
                </div>
            </td>
        </tr>
        <tr id="trHideStrumentiRNA3" style="display: none;" runat="server">
            <td align="right" style="padding-right: 40px; height: 60px">
                <Siar:Button ID="salvaStrumento" runat="server" Text="Salva" Width="150px" OnClick="btnSalvaStrumento_Click" OnClientClick="if(!verificaSalvaStrumento()) return false;"
                     />&nbsp; &nbsp;
                <Siar:Button ID="eliminaStrumento" runat="server"
                    Text="Elimina" Width="150px" OnClick="btnEliminaStrumento_Click" OnClientClick="if(!verificaEliminaStrumento()) return false;"
                    CausesValidation="false" Conferma="Eliminare lo strumento associato al componente?" />&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
        </tr>
        <tr id="trHideStrumentiRNA4" style="display: none;" runat="server">
            <td class="separatore">Elenco strumenti associati:
            </td>
        </tr>
        <tr id="trHideStrumentiRNA5" style="display: none;" runat="server">
            <td>
                <br />
                <Siar:DataGrid ID="dgStrumentiAssociati" runat="server" Width="100%" AllowPaging="True"
                    PageSize="15" AutoGenerateColumns="False">
                    <ItemStyle Height="28px" />
                    <Columns>
                        <Siar:ColonnaLink DataField="Strumento" HeaderText="Strumento" IsJavascript="true"
                            LinkFields="IdStrumentiXComponenti|CodTipoStrumentoAiuto|IntensitaStrumento" LinkFormat="caricaStrumento({0},{1},{2});">
                            </Siar:ColonnaLink>
                        <asp:BoundColumn DataField="IntensitaStrumento" HeaderText="Intensità strumento"><ItemStyle CssClass="intensitaStrumento" /></asp:BoundColumn>
                        <asp:BoundColumn DataField="Obiettivo" HeaderText="Obiettivo"></asp:BoundColumn>
                        <asp:BoundColumn DataField="CodiceRegolamento" HeaderText="Codice regolamento"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Investimento" HeaderText="Investimento"></asp:BoundColumn>
                        <asp:BoundColumn DataField="IdStrumentiXComponenti" Visible="false">
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid><br />
            </td>
        </tr>
        <tr>
            <td>
                <div style="display:none">
                    <asp:Button ID="btnProgrammazionePost" runat="server" OnClick="btnProgrammazionePost_Click"
                        CausesValidation="false" />
                    <asp:HiddenField ID="hdnIdComponenteSelezionata" runat="server" />
                    <asp:HiddenField ID="hdnStrumentoSelezionato" runat="server" />
                </div>
            </td>
        </tr>
    </table>
</asp:Content>