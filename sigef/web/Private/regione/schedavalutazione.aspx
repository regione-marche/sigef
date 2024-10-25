<%@ Page Language="c#" MasterPageFile="~/SiarPage.master" Inherits="web.Private.regione.SchedaValutazione"
    CodeBehind="SchedaValutazione.aspx.cs" %>

<%@ Register Src="../../CONTROLS/SiarNewTab.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
        function selezionaScheda(id) { $('[id$=hdnIdSchedaValutazione]').val(id);$('[id$=btnPost]').click(); }
        function ctrlCaricaModello(ev) { if($('[id$=lstCaricaSchedaTemplate]').val()=='') { alert('Seleziona il modello di scheda da caricare.');stopEvent(ev); } }
//--></script>

    <div style="display: none">
        <asp:HiddenField ID="hdnIdSchedaValutazione" runat="server" />
        <asp:Button ID="btnPost" runat="server" OnClick="btnPost_Click" />
    </div>
    <uc1:SiarNewTab ID="ucSiarNewTab" runat="server" TabNames="Ricerca scheda di valutazione|Dettaglio scheda selezionata/Nuova scheda" />
    <table class="tableTab" id="tbRicerca" runat="server" width="1020px">
        <tr>
            <td align="right">
                <table style="width: 65%; border-bottom: black 1px solid; border-left: black 1px solid;
                    margin-left: 0px;" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width: 11px">
                            &nbsp;
                        </td>
                        <td style="width: 237px">
                            &nbsp;
                        </td>
                        <td style="width: 189px">
                            &nbsp;
                        </td>
                        <td style="width: 88px">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 11px">
                            <br />
                        </td>
                        <td align="left" style="width: 237px">
                            Testo descrizione:<br />
                            <Siar:TextBox ID="txtRicercaDescrizione" runat="server" Width="215px" />
                        </td>
                        <td align="left" style="width: 189px">
                            Parole chiave:<br />
                            <Siar:TextBox ID="txtRicercaParoleChiave" runat="server" Width="166px" />
                        </td>
                        <td align="left" style="width: 88px">
                            <br />
                            <asp:CheckBox ID="chkRicercaTemplate" runat="server" Text="Modello" />
                        </td>
                        <td align="left">
                            <br />
                            <Siar:Button ID="btnFiltra" runat="server" OnClick="btnFiltra_Click" Text="Filtra"
                                Width="89px" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 11px">
                            &nbsp;
                        </td>
                        <td style="width: 237px">
                            &nbsp;
                        </td>
                        <td style="width: 189px">
                            &nbsp;
                        </td>
                        <td style="width: 88px">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dg" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="true"
                    PageSize="20">
                    <ItemStyle Height="24px" />
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle HorizontalAlign="center" Width="35px" />
                        </Siar:NumberColumn>
                        <Siar:ColonnaLink DataField="Descrizione" HeaderText="Descrizione" LinkFields="IdSchedaValutazione"
                            LinkFormat="javascript:selezionaScheda({0});">
                        </Siar:ColonnaLink>
                        <asp:BoundColumn DataField="ParoleChiave" HeaderText="Parole chiave">
                            <ItemStyle Width="260px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ValoreMax" HeaderText="Valore massimo">
                            <ItemStyle HorizontalAlign="right" Width="70px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ValoreMin" HeaderText="Valore minimo">
                            <ItemStyle HorizontalAlign="right" Width="70px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="FlagTemplate" HeaderText="Modello">
                            <ItemStyle HorizontalAlign="Center" Width="70px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="DataModifica" HeaderText="Ultima modifica">
                            <ItemStyle HorizontalAlign="center" Width="110px" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid><br />
            </td>
        </tr>
    </table>
    <table id="tbDettaglio" runat="server" class="tableTab" width="1100px">
        <tr>
            <td style="height: 28px">
            </td>
        </tr>
        <tr>
            <td class="separatore_light">
                Descrizione scheda:
            </td>
        </tr>
        <tr>
            <td style="padding-left: 10px">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td style="width: 425px">
                            <br />
                            Descrizione:
                            <br />
                            <Siar:TextArea ID="txtDescrizione" runat="server" Width="381px" Obbligatorio="True"
                                NomeCampo="Descrizione" Rows="3"></Siar:TextArea>
                        </td>
                        <td style="width: 134px">
                            <br />
                            Punteggio<br />
                            minimo:<br />
                            <Siar:CurrencyBox ID="txtValMinimo" runat="server" Obbligatorio="false" Width="100px" />
                        </td>
                        <td>
                            <br />
                            Punteggio<br />
                            massimo:
                            <br />
                            <Siar:CurrencyBox ID="txtValMax" runat="server" NomeCampo="Punteggio massimo" Obbligatorio="True"
                                Width="100px" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 425px">
                            <br />
                            Parole chiave:<br />
                            <Siar:TextBox ID="txtParoleChiave" runat="server" Width="381px" />
                        </td>
                        <td style="width: 134px">
                            <br />
                            <br />
                            <asp:CheckBox ID="chkTemplate" runat="server" Text="salva come modello"></asp:CheckBox>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="right" style="text-align: center; height: 68px;">
                <Siar:Button ID="btnSalva" runat="server" Width="130px" Text="Salva" OnClick="btnSalva_Click"
                    Modifica="True" />&nbsp; &nbsp;&nbsp; &nbsp;
                <Siar:Button ID="btnEliminaScheda" Text="Elimina" runat="server" Conferma="Attenzione! Eliminare la scheda di valutazione selezionata?"
                    OnClick="btnEliminaScheda_Click" Width="130px" CausesValidation="False" Modifica="True" />&nbsp;
                &nbsp; &nbsp;
                <Siar:Button ID="btnNuovo" Width="130px" runat="server" Text="Nuova scheda" OnClick="btnNuovo_Click"
                    CausesValidation="false" />
            </td>
        </tr>
        <tr>
            <td class="separatore_light">
                Elenco delle priorita:
            </td>
        </tr>
        <tr>
            <td style="padding-left: 10px">
                <table cellpadding="0" cellspacing="0" >
                    <tr>
                        <td style="border-right: #142952 1px solid; width: 600px; border-bottom: #142952 1px solid;">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="width: 125px">
                                        &nbsp; Misura:<br />
                                        <Siar:TextBox runat="server" ID="txtFiltroMisura" Width="83px" />
                                    </td>
                                    <td style="padding-left: 10px">
                                        &nbsp; Descrizione:<br />
                                        <Siar:TextBox runat="server" ID="txtFiltroDescrizione2" Width="381px" />
                                    </td>
                                    <td style="padding-left: 10px; padding-right: 10px" >
                                        &nbsp;
                                        <Siar:Button ID="btnFiltroMisura" Width="100px" runat="server" Text="Filtra" CausesValidation="false" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="border-bottom: #142952 1px solid; border-right: #142952 1px solid; padding: 20px;">
                            Seleziona modello:<br />
                            <Siar:ComboSchedaValutazione ID="lstCaricaSchedaTemplate" runat="server">
                            </Siar:ComboSchedaValutazione>
                            &nbsp;
                            <Siar:Button ID="btnCarica" Width="80px" runat="server" Text="Carica" CausesValidation="false"
                                OnClick="btnCarica_Click" OnClientClick="ctrlCaricaModello(event);" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="right">
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dgPriorita" runat="server" AutoGenerateColumns="False" Width="100%"
                    AllowPaging="True" PageSize="30">
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle Width="30px" HorizontalAlign="center" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="IdPriorita" HeaderText="ID">
                            <ItemStyle HorizontalAlign="center" Width="45px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Priorita" HeaderText="Descrizione"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Misura" HeaderText="Misura">
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="CodLivello" HeaderText="Livello di dettaglio" DataFormatString="{0:D=Domanda|I=Investimento|F=Investimento fisso|P=Impresa}">
                            <ItemStyle HorizontalAlign="center" Width="90px" />
                        </asp:BoundColumn>
                        <Siar:PercentualeColumn HeaderText="Peso %" Name="Peso" DataField="IdPriorita" Quota="Peso">
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                        </Siar:PercentualeColumn>
                        <Siar:PercentualeColumn HeaderText="Aiuto Addizionale" Name="AiutoAddizionale" DataField="IdPriorita"
                            Quota="AiutoAddizionale">
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                        </Siar:PercentualeColumn>
                        <Siar:CheckColumn DataField="IdPriorita" Name="chkMassimoValore" HeaderText="Massimo">
                            <ItemStyle HorizontalAlign="center" Width="70px" />
                        </Siar:CheckColumn>
                        <Siar:CheckColumn DataField="IdPriorita" Name="chk" HeaderText="Visualizza">
                            <ItemStyle HorizontalAlign="center" Width="70px" />
                        </Siar:CheckColumn>
                        <Siar:IntegerColumn DataField="IdPriorita" Valore="Ordine" Name="Ordine" HeaderText="Ordine"
                            NoCurrency="true">
                            <ItemStyle Width="60" HorizontalAlign="center" />
                        </Siar:IntegerColumn>
                        <Siar:CheckColumn DataField="IdPriorita" Name="chkAssocia" HeaderText="Associa alla scheda">
                            <ItemStyle HorizontalAlign="center" Width="80px" />
                        </Siar:CheckColumn>
                        <Siar:IntegerColumn DataField="IdPriorita" Name="idPrioritaSpeciale" HeaderText="ID Priorita Selezionata"
                            NoCurrency="true">
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </Siar:IntegerColumn>
                        <Siar:CheckColumn DataField="IdPriorita" Name="chkIsMax" HeaderText="Massimo valore">
                            <ItemStyle HorizontalAlign="center" Width="70px" />
                        </Siar:CheckColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
        <tr>
            <td align="right">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left">
                <strong>(*)</strong> = indicare l' <strong>ID Priorita</strong> da associare alla
                priorita per ottenere l'aiuto indicato.
            </td>
        </tr>
        <tr>
            <td align="right">
                &nbsp;
            </td>
        </tr>
    </table>
    </Siar:SiarTab>
</asp:Content>
