<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    CodeBehind="DecretiVarianti.aspx.cs" Inherits="web.Private.IPagamento.DecretiVarianti" %>

<%@ Register Src="../../CONTROLS/SNCVisualizzaProtocollo.ascx" TagName="SNCVisualizzaProtocollo"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <script type="text/javascript"><!--
        function ctrlCampiRicercaNormeMarche(ev) { if($('[id$=txtNumeroDecreto_text]').val()==""||$('[id$=txtDataDecreto_text]').val()==""||$('[id$=lstRegistro]').val()=="") { alert('Per la ricerca dei decreti è necessario digitare sia numero che data che registro dell`atto.');return stopEvent(ev); } }
        function StampaXLS(id_bando) {
            var parametri=[];parametri.push("IdBando="+id_bando);var id_progetto=$('[id$=txtIdProgetto_text]').val();if(id_progetto!='') parametri.push('IdProgetto='+id_progetto);
            var esito_var=$('[id*=rblEsitoVarianti][checked]').val();if(esito_var==''||esito_var==null) esito_var='T';parametri.push('Approvate='+esito_var);
            var chkInseriti=$('[id$=chkDecretiInseriti]')[0].checked;parametri.push('NascondiDecretiInseriti='+(chkInseriti?1:0));SNCVisualizzaReport('rptDecretiVarianti',2,parametri.join('|'));
        }
        function selezionaDecreto(obj) { $('[id$=hdnDecretoJson]').val(sjsConvertiOggettoToJsonString(obj));$('[id$=btnPost]').click(); }
//--></script>

    <br />
    <uc2:SNCVisualizzaProtocollo ID="ucSNCVisualizzaProtocollo" VisualizzaMenu="true"
        TipoVisualizzazione="Invisibile" runat="server" />
    <table class="tableNoTab" width="950">
        <tr>
            <td class="separatore_big">
                DECRETI DI APPROVAZIONE VARIANTI/VARIAZIONI FINANZIARIE
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width: 495px" class="testo_pagina">
                            In questa pagina e&#39; possibile registrare a sistema il provvedimento di approvazione<br />
                            delle varianti/variazioni finanziarie presentate per questo bando. Tale provvedimento consiste in un decreto
                            <br />
                            del servizio che, viene richiesto, sia stato <b>pubblicato</b> su norme marche.<br />
                            Di seguito vengono listate le varianti/variazioni finanziarie con istruttoria conclusa <b>approvate e non.
                            </b>
                            <br />
                            Per cominciare, una volta effettuata la ricerca, spuntare la casella relativa alla
                            variante/variazione finanziaria
                            <br />
                            desiderata.
                        </td>
                        <td style="padding-left: 5px; padding-bottom: 5px">
                            <table style="border-bottom: solid 1px black; border-left: solid 1px black; width: 100%">
                                <tr>
                                    <td class="separatore">
                                        Parametri di ricerca
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-left: 10px;">
                                        Nr.domanda:<br />
                                        <Siar:IntegerTextBox ID="txtIdProgetto" runat="server" Width="102px" NoCurrency="true" />
                                        &nbsp;&nbsp;
                                        <asp:CheckBox ID="chkDecretiInseriti" runat="server" Checked="True" Text="Nascondi decreti inseriti" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-left: 10px">
                                        <asp:RadioButtonList ID="rblEsitoVarianti" ToolTip="esito" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Text="Tutte le varianti/variazioni finanziarie" Value="T" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="Approvate" Value="A"></asp:ListItem>
                                            <asp:ListItem Text="Non approvate" Value="N"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="height: 45px; padding-right: 20px">
                                        <Siar:Button ID="btnCerca" runat="server" OnClick="btnCerca_Click" Text="Cerca" Width="91px"
                                            CausesValidation="False" />
                                        <input type="button" class="Button" id="btnStampa" runat="server" value="Esporta in excels"
                                            style="width: 155px; margin-left: 20px" />
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
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dgVarianti" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    PageSize="10" Width="100%">
                    <ItemStyle Height="36px" />
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle HorizontalAlign="Center" Width="30px" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="IdProgetto" HeaderText="Nr. domanda">
                            <ItemStyle HorizontalAlign="Center" Width="80px" Font-Bold="true" Font-Size="12px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Approvata" HeaderText="Approvata" DataFormatString="{0:SI|NO}">
                            <ItemStyle HorizontalAlign="Center" Width="70px" Font-Bold="true" Font-Size="12px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Segnatura presentazione">
                            <ItemStyle HorizontalAlign="Center" Width="90px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Segnatura checklist">
                            <ItemStyle HorizontalAlign="Center" Width="90px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Decreto di approvazione">
                            <ItemStyle HorizontalAlign="Center" Width="110px" />
                        </asp:BoundColumn>
                        <Siar:CheckColumn DataField="IdVariante" Name="chkIdVariante" OnCheckClick="$('[id$=btnPost]').click();">
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                        </Siar:CheckColumn>
                    </Columns>
                </Siar:DataGrid>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <div style="display: none">
                    <asp:HiddenField ID="hdnDecretoJson" runat="server" />
                    <asp:Button ID="btnPost" runat="server" OnClick="btnPost_Click" CausesValidation="false" />
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <table id="tbDettaglioDecreto" runat="server" visible="false" width="100%" cellpadding="0"
                    cellspacing="0">
                    <tr>
                        <td class="separatore">
                            Dettaglio decreto
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 10px">
                            <table width="100%">
                                <tr>
                                    <td style="width: 108px">
                                        Numero:<br />
                                        <Siar:IntegerTextBox ID="txtNumeroDecreto" runat="server" Width="80px" NomeCampo="Numero decreto"
                                            Obbligatorio="True" />
                                    </td>
                                    <td style="width: 120px">
                                        Data:<br />
                                        <Siar:DateTextBox ID="txtDataDecreto" runat="server" Width="100px" NomeCampo="Data decreto"
                                            Obbligatorio="True" />
                                    </td>
                                    <td style="width: 155px">
                                        Registro:<br />
                                        <Siar:ComboRegistriAtto ID="lstRegistro" runat="server" Width="120px">
                                        </Siar:ComboRegistriAtto>
                                    </td>
                                    <td>
                                        <br />
                                        <Siar:Button ID="btnCercaDecreto" runat="server" OnClick="btnCercaDecreto_Click"
                                            Text="Importa" Width="122px" OnClientClick="return ctrlCampiRicercaNormeMarche(event)"
                                            CausesValidation="False" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr id="trElencoDecreti" runat="server" visible="false">
                        <td>
                            &nbsp;
                            <Siar:DataGrid ID="dgDecreti" runat="server" Width="100%" EnableViewState="False"
                                AutoGenerateColumns="False" AllowPaging="false">
                                <Columns>
                                    <asp:BoundColumn DataField="Numero" HeaderText="Numero" Visible="True">
                                        <ItemStyle HorizontalAlign="center" Width="70px" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Data" HeaderText="Data" DataFormatString="{0:d}">
                                        <ItemStyle HorizontalAlign="center" Width="90px" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Registro" HeaderText="Registro">
                                        <ItemStyle HorizontalAlign="center" Width="90px" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione"></asp:BoundColumn>
                                    <asp:BoundColumn>
                                        <ItemStyle HorizontalAlign="center" Width="130px" />
                                    </asp:BoundColumn>
                                </Columns>
                            </Siar:DataGrid>
                        </td>
                    </tr>
                    <tr id="trDettaglioDecreto" runat="server" visible="false">
                        <td>
                            &nbsp;<table style="width: 100%;">
                                <tr>
                                    <td style="width: 118px">
                                        &nbsp;
                                    </td>
                                    <td style="width: 463px">
                                        &nbsp;
                                    </td>
                                    <td rowspan="6" align="center" valign="middle">
                                        <table class="tableNoTab">
                                            <tr>
                                                <td class="separatore" colspan="2">
                                                    &nbsp;Pubblicazione B.U.R.&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 58px">
                                                    &nbsp;
                                                </td>
                                                <td style="width: 107px">
                                                    &nbsp;&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" valign="middle" style="width: 58px">
                                                    Numero:
                                                </td>
                                                <td align="left" style="width: 107px">
                                                    <Siar:IntegerTextBox ID="txtNumeroBur" runat="server" Width="75px" ReadOnly="True" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 58px">
                                                    Data:
                                                </td>
                                                <td align="left" style="width: 107px">
                                                    <Siar:DateTextBox ID="txtDataBur" runat="server" Width="76px" ReadOnly="True" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 58px">
                                                    &nbsp;
                                                </td>
                                                <td style="width: 107px">
                                                    &nbsp;&nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 118px">
                                        Definizione Atto:
                                    </td>
                                    <td style="height: 24px; width: 463px;">
                                        <Siar:ComboDefinizioneAtto ID="lstDefAtto" runat="server" DataColumn="IdDefinizioneAtto"
                                            Width="210px" Enabled="False">
                                        </Siar:ComboDefinizioneAtto>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 118px">
                                        Organo Istituzionale:
                                    </td>
                                    <td style="width: 463px">
                                        <Siar:ComboOrganoIstituzionale ID="lstOrgIstituzionale" runat="server" DataColumn="IdOrganoIstituzionale"
                                            Width="210px" Enabled="False">
                                        </Siar:ComboOrganoIstituzionale>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 118px">
                                        Registro:
                                    </td>
                                    <td style="height: 26px; width: 463px;">
                                        <Siar:TextBox ID="txtRegistro" runat="server" Width="145px" DataColumn="Registro"
                                            ReadOnly="True"></Siar:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 118px">
                                        Tipo Atto:
                                    </td>
                                    <td style="width: 463px">
                                        <Siar:ComboTipoAtto ID="lstTipoAtto" runat="server" Obbligatorio="True" NomeCampo="Tipo Atto"
                                            DataColumn="IdTipoAtto">
                                        </Siar:ComboTipoAtto>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 118px" valign="top">
                                        Descrizione:
                                    </td>
                                    <td style="width: 463px">
                                        <Siar:TextArea ID="txtDescrizione" runat="server" Width="437px" DataColumn="Descrizione"
                                            ReadOnly="True"></Siar:TextArea>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 118px; height: 58px;" valign="top">
                                        &nbsp;
                                    </td>
                                    <td style="height: 58px;" align="right" colspan="2">
                                        &nbsp;
                                        <Siar:Button ID="btnInserisciDecreto" runat="server" OnClick="btnInserisciDecreto_Click"
                                            Text="Inserisci decreto" Width="178px" Modifica="False" />
                                        &nbsp;&nbsp;&nbsp;
                                        <Siar:Button ID="btnEliminaDecreto" runat="server" OnClick="btnEliminaDecreto_Click"
                                            Text="Elimina decreto" Width="156px" Modifica="False" Conferma="Attenzione! Eliminare il decreto dalla variante/variazione finanziaria selezionata?"
                                            CausesValidation="true" />
                                        &nbsp;&nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <div id="divPopupDomanda" class='ajaxResp'>
    </div>
</asp:Content>
