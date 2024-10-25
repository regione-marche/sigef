<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.IPagamento.CertificazioneAntimafia" CodeBehind="CertificazioneAntimafia.aspx.cs" %>

<%@ Register Src="../../CONTROLS/IDomandaPagamento.ascx" TagName="IDomandaPagamento"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript">
        function nuovo() {
            //document.getElementById("ctl00_cphContenuto_hdnIdAntimafia").value = '';
            $('[id$=txtDataInizioValidita_text]').val('');
            $('[id$=txtDataFineValidita_text]').val('');
            $('[id$=txtProtRichiesta_text]').val('');
            $('[id$=txtDataRichiesta_text]').val('');
            $('[id$=txtNumCamerale_text]').val('');
            $('[id$=txtDataCamerale_text]').val('');
            $('[id$=txtNumRaccomandata_text]').val('');
            $('[id$=txtDataRaccomandata_text]').val('');
            $('[id$=txtNumeroPrefettizio_text]').val('');
            $('[id$=txtDataPrefettizio_text]').val('');
            $('[id$=cmbEsenzionePagamento]').val('');
            $('[id$=cmbEsitoCamerale]').val('');
            $('[id$=cmbEsitoPrefettizio]').val('');
            $('[id$=txtProtAcquisizione_text]').val('');
            $('[id$=txtDataAcquisizione_text]').val('');
            $('[id$=hdnIdAntimafia]').val('');
        }
        function campicompilati(ev) {
            if($('[id$=cmbEsenzionePagamento]').val()=='') {
                alert("Attenzione! Selezionare l'esenzione per il certificato prefettizio.");
                return stopEvent(ev);
            }
            if(
            ($('[id$=txtNumeroPrefettizio_text]').val()==''||$('[id$=txtDataPrefettizio_text]').val()==''
                    ||$('[id$=cmbEsitoPrefettizio]').val()!='1'||$('[id$=txtProtAcquisizione_text]').val()==''
                    ||$('[id$=txtDataAcquisizione_text]').val()=='')
                    &&
                    ($('[id$=txtNumCamerale_text]').val()==''||$('[id$=txtDataCamerale_text]').val()==''
                    ||$('[id$=txtNumRaccomandata_text]').val()==''||$('[id$=txtDataRaccomandata_text]').val()==''
                    ||$('[id$=txtProtRichiesta_text]').val()==''||$('[id$=txtDataRichiesta_text]').val()==''
                    ||$('[id$=cmbEsitoCamerale]').val()!='1')

                    &&$('[id$=cmbEsenzionePagamento]').val()=='0') {
                alert('Attenzione! Non sono stati compilati correttamente i campi richiesti.');
                return stopEvent(ev);
            }
            //validità antimafia
            var data=new Date();
            var mm=data.getMonth()+1;
            var dd=data.getDate();
            if($('[id$=cmbEsenzionePagamento]').val()=='1') $('[id$=txtDataInizioValidita_text]').val((dd<10?'0':'')+dd+'/'+(mm<10?'0':'')+mm+'/'+data.getFullYear());
            else {
                if($('[id$=cmbEsenzionePagamento]').val()=='0') {
                    if($('[id$=txtDataAcquisizione_text]').val()!='') $('[id$=txtDataInizioValidita_text]').val($('[id$=txtDataAcquisizione_text]').val());
                    else {
                        if($('[id$=txtDataRichiesta_text]').val()!='') $('[id$=txtDataInizioValidita_text]').val($('[id$=txtDataRichiesta_text]').val());
                        else {
                            alert('Attenzione! Non state inserite le date di interesse.');
                            return stopEvent(ev);
                        }
                    }
                }
            }
            var partsDI=$('[id$=txtDataInizioValidita_text]').val().split("/");
            partsDI[2]=Number(partsDI[2])+1;
            $('[id$=txtDataFineValidita_text]').val(partsDI[0]+'/'+partsDI[1]+'/'+(partsDI[2]));
        }
    </script>

    <br />
    <uc2:IDomandaPagamento ID="ucIDomandaPagamento" runat="server" />
    <br />
    <table class="tableNoTab" width="950px">
        <tr>
            <td class="separatore_big" colspan="4">
                DATI DELLA CERTIFICAZIONE O DELLA RICHIESTA DI ANTIMAFIA
            </td>
        </tr>
        <tr>
            <td>
                <input id="hdnIdAntimafia" type="hidden" name="hdnIdAntimafia" runat="server" />&nbsp;
            </td>
        </tr>
        <tr>
            <td>
                Esito del controllo: <b>
                    <Siar:Label runat="server" ID="lblEsitoControllo" />
                </b>
            </td>
        </tr>
        <tr>
            <td>
                Esenzione certificato:&nbsp;&nbsp;
                <Siar:Combo runat="server" ID="cmbEsenzionePagamento" AutoPostBack="true" />
            </td>
            <td>
                Data Inizio Validita:&nbsp;&nbsp;
                <Siar:DateTextBox ID="txtDataInizioValidita" runat="server" Width="80px" ReadOnly="True" />
            </td>
            <td>
                Data Fine Validita:&nbsp;&nbsp;
                <Siar:DateTextBox ID="txtDataFineValidita" runat="server" Width="80px" ReadOnly="True" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <table runat="server" id="tbSenzaEsenzione" width="100%" visible="false">
                    <tr>
                        <td colspan="3" class="separatore_light" style="height: 20px">
                            &nbsp; Dati protocollo Prefettura relativi alla Richiesta di Certificato Prefettizio
                            presentata dalla Regione:
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td width="600px" colspan="2">
                            Numero Protocollo:&nbsp;&nbsp;&nbsp;
                            <Siar:TextBox ID="txtProtRichiesta" runat="server" Width="250px" MaxLength="30" />
                        </td>
                        <td width="300px">
                            Data:
                            <Siar:DateTextBox ID="txtDataRichiesta" runat="server" Width="70px" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <table id="tbCamerale" style="border: 1px solid #000000" width="100%">
                                <tr>
                                    <td colspan="3" class="separatore_light" style="height: 20px">
                                        &nbsp;(dati obbligatori solo nel caso di richiesta di certificato prefettizio)
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td width="600px" colspan="2">
                                        Numero Protocollo Certificato Camerale:&nbsp;&nbsp;
                                        <Siar:TextBox runat="server" ID="txtNumCamerale" Width="250px" MaxLength="30" />
                                    </td>
                                    <td width="300px">
                                        &nbsp;&nbsp;&nbsp; Data:
                                        <Siar:DateTextBox ID="txtDataCamerale" runat="server" Width="70px" />
                                        Esito:&nbsp;
                                        <Siar:Combo runat="server" ID="cmbEsitoCamerale" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" width="700px">
                                        <br />
                                        Numero Raccomandata della comunicazione al Beneficiario:&nbsp;
                                        <Siar:TextBox runat="server" ID="txtNumRaccomandata" Width="200px" MaxLength="30" />
                                    </td>
                                    <td width="200px">
                                        <br />
                                        &nbsp;&nbsp;&nbsp; Data:
                                        <Siar:DateTextBox ID="txtDataRaccomandata" runat="server" Width="70px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" class="separatore_light" style="height: 20px">
                            &nbsp;Dati Protocollo Rilascio del Certificato Prefettizio:
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td width="600px">
                            Numero Protocollo:&nbsp;&nbsp;
                            <Siar:TextBox ID="txtNumeroPrefettizio" runat="server" Width="250px" MaxLength="30" />
                        </td>
                        <td width="300px" colspan="2">
                            &nbsp; Data:
                            <Siar:DateTextBox ID="txtDataPrefettizio" runat="server" Width="70px" />
                            &nbsp;Esito:
                            <Siar:Combo runat="server" ID="cmbEsitoPrefettizio" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <table id="Table1" style="border: 1px solid #000000" width="100%">
                                <tr>
                                    <td colspan="3" class="separatore_light" style="height: 20px">
                                        &nbsp; Dati protocollo dell'acquisizione del Certificato Prefettizio: (dati obbligatori
                                        solo nel caso di rilascio del certificato prefettizio)
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td width="600px" colspan="1">
                                        Numero Protocollo:&nbsp;
                                        <Siar:TextBox ID="txtProtAcquisizione" runat="server" Width="250px" MaxLength="30" />
                                    </td>
                                    <td width="300px" colspan="2">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Data:
                                        <Siar:DateTextBox ID="txtDataAcquisizione" runat="server" Width="70px" />
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            ** Il certificato prefettizio rilasciato prima del 13 febbraio 2013 ha validità
                            temporale di 6 mesi, mentre dopo il 13 febbraio 2013 ha una validità di dodici mesi
                            con decorrenza dalla data dell'acquisizione.
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center" colspan="3">
                <Siar:Button ID="btnSalva" runat="server" Text="Salva" Width="140px" Modifica="True"
                    OnClick="btnSalva_Click" OnClientClick=" return campicompilati(event);" />
                &nbsp;&nbsp;&nbsp;
                <input id="btnNuovo" style="width: 140px" type="button" value="Nuovo" onclick="javascript:nuovo()"
                    class="Button" />
                &nbsp;&nbsp;&nbsp;
                <input id="btnBack" runat="server" class="Button" style="width: 140px" type="button"
                    onclick="javascript:location='CheckListPagamento.aspx'" value="Indietro" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
