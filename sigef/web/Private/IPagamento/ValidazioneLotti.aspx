<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    CodeBehind="ValidazioneLotti.aspx.cs" Inherits="web.Private.IPagamento.ValidazioneLotti" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <script type="text/javascript"><!--
        function selezionaLotto(id) {
            $('[id$=hdnIdLotto]').val($('[id$=hdnIdLotto]').val() == id ? '' : id);
            $('[id$=btnPost]').click(); 
        }
//--></script>

    <div style="display: none">
        <Siar:Button ID="btnPost" runat="server" CausesValidation="False" OnClick="btnPost_Click" />
        <asp:HiddenField ID="hdnIdLotto" runat="server" />
    </div>
    <br />
    <table class="tableNoTab" style="width: 1000px">
        <tr>
            <td class="separatore_big">
                CONTROLLI DI VALIDAZIONE
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%">
                    <tr>
                        <td style="width: 566px" class="testo_pagina">
                            I controlli di validazione si effettuano sulle <b>domande di pagamento</b> pervenute,
                            ed istruite positivamente o negativamente, e sono vincolanti alla creazione dell&#39;elenco
                            di liquidazione regionale.<br />
                            Per avviare tali controlli è necessario creare dei <b>lotti di domande</b> sui quali
                            poi sara&#39; estratto un <b>campione</b>. La percentuale di domande da estrarre
                            (0%, 5%, 100%, ecc) è stabilito da bando.<br />
                            Le domande il cui esito del controllo sia negativo saranno riportate indietro all&#39;istruttoria
                            da parte del Rup. Alla conclusione dei controlli sulle domande di un lotto sarà
                            possibile creare un elenco regionale<br />
                            che verrà inviato all&#39;organismo pagatore per l&#39;effettiva <b>liquidazione dei
                            beneficiari</b>.<br />
                            <br />
                            <div style="width: 80%; text-align: center">
                                <Siar:Button ID="btnCreaLotto" runat="server" OnClick="btnCreaLotto_Click" Text="Nuovo lotto di validazione"
                                             Width="200px" CausesValidation="false" Conferma="Attenzione! Creare un nuovo lotto di domande per il controllo?" />
                            </div>
                        </td>
                        <td style="vertical-align: top; padding: 10px" align="center">
                            <table width="330px" class="tableNoTab">
                                <tr>
                                    <td class="separatore">
                                        Ricerca domanda nei lotti
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 50px">
                                        <table cellpadding="0" cellspacing="0" width="100%">
                                            <tr>
                                                <td style="width: 100px">
                                                    Nr. domanda:<br />
                                                    <Siar:IntegerTextBox ID="txtNumeroDomanda" runat="server" MaxLength="10" Width="68px"
                                                                         NoCurrency="True" NomeCampo="Numero di domanda" Obbligatorio="True" />
                                                </td>
                                                <td>
                                                    Tipo pagamento:<br />
                                                    <Siar:ComboTipoDomandaPagamento ID="lstTipoPagamento" runat="server" 
                                                        Width="200px">
                                                    </Siar:ComboTipoDomandaPagamento>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 33px" align="right">
                                        <Siar:Button ID="btnFiltra" runat="server" OnClick="btnFiltra_Click" Text="Applica filtro" Width="121px" />
                                        &nbsp; &nbsp;
                                        <Siar:Button ID="btnAzzeraRicerca" runat="server" OnClick="btnAzzeraRicerca_Click"
                                                     Text="Azzera ricerca" Width="110px" CausesValidation="False" />
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
                <br />
                <Siar:DataGrid ID="dgLotti" runat="server" AutoGenerateColumns="False" Width="100%" AllowPaging="True" PageSize="10">
                    <ItemStyle Height="30px" />
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle HorizontalAlign="Center" Width="30px" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="IdLotto" HeaderText="ID">
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Provincia" HeaderText="Provincia">
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="DataCreazione" HeaderText="Data creazione">
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundColumn>
                        <Siar:ColonnaLink DataField="Operatore" HeaderText="Operatore" IsJavascript="true"
                                          LinkFields="IdLotto" LinkFormat="selezionaLotto({0});">
                        </Siar:ColonnaLink>
                        <asp:BoundColumn DataField="RevisioneConclusa" HeaderText="Stato del controllo" DataFormatString="{0:Concluso|In corso}">
                            <ItemStyle HorizontalAlign="Center" Width="130px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="NumeroDomandeAssegnate" HeaderText="Numero domande assegnate">
                            <ItemStyle HorizontalAlign="Center" Width="90px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="NumeroDomandeEstratte" HeaderText="Numero domande estratte">
                            <ItemStyle HorizontalAlign="Center" Width="90px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="NumeroEstrazioni" HeaderText="Numero estrazioni">
                            <ItemStyle HorizontalAlign="Center" Width="90px" />
                        </asp:BoundColumn>
                        <Siar:CheckColumn DataField="IdLotto" OnCheckClick="return false;" ReadOnly="true" HeaderText=" ">
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                        </Siar:CheckColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
        <tr>
            <td id="tdPulsanti" runat="server" visible="false" align="right" style="height: 60px; padding-right: 10px;">
                <Siar:Button ID="btnSelezioneDomande" runat="server" Modifica="False" OnClick="btnSelezioneDomande_Click"
                             Text="Selezione domande" Width="180px" Enabled="False" CausesValidation="False" />
                &nbsp;
                <Siar:Button ID="btnEstrai" runat="server" Modifica="False" OnClick="btnEstrai_Click"
                             Text="Estrazione del campione" Width="180px" Enabled="False" CausesValidation="False" />
                &nbsp;
                <Siar:Button ID="btnVerifica" runat="server" Modifica="True" OnClick="btnVerifica_Click"
                             Text="Verifica completamento" Width="180px" CausesValidation="False" />
                &nbsp;&nbsp;
                <Siar:Button ID="btnChiudiControllo" runat="server"  Modifica="False" OnClick="btnChiudiControllo_Click" 
                             Text="Chiudi controllo" Width="180px" Enabled="False" CausesValidation="False"
                             Conferma="Attenzione! La procedura chiuderà i controlli sul lotto selezionato. Continuare?" />
                &nbsp;&nbsp; &nbsp;&nbsp;
                <Siar:Button ID="btnDel" runat="server" Modifica="True" OnClick="btnDel_Click" Text="Cancella lotto" 
                             Width="140px" Conferma="Attenzione! Si sta per cancellare il lotto dal sistema. Continuare?" 
                             CausesValidation="False" />
            </td>
        </tr>
    </table>
    <br />
    <table id="tabDomande" runat="server" class="tableNoTab" style="width: 1000px" visible="false">
        <tr>
            <td class="separatore">
                Elenco delle domande assegnate al lotto selezionato:
            </td>
        </tr>
        <tr>
            <td>
                <br />
                <Siar:DataGrid ID="dgDomande" runat="server" AllowPaging="True" AutoGenerateColumns="False" PageSize="20" Width="100%">
                    <ItemStyle Height="26px" />
                    <Columns>
                        <asp:BoundColumn DataField="IdProgetto" HeaderText="Numero domanda di aiuto">
                            <ItemStyle Font-Bold="True" Font-Size="Small" HorizontalAlign="Center" Width="110px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="TipoDomandaPagamento" HeaderText="Modalit&#224; della richiesta">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="DataPresentazioneDomandaPagamento" HeaderText="Data di presentazione">
                            <ItemStyle HorizontalAlign="Center" Width="120px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="SelezionataXRevisione" DataFormatString="{0:SI|NO}" HeaderText="Estratta a campione">
                            <ItemStyle HorizontalAlign="Center" Width="120px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Approvata" DataFormatString="{0:SI|NO}" HeaderText="Controllo positivo">
                            <ItemStyle HorizontalAlign="Center" Width="120px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="NumeroEstrazione" HeaderText="Numero estrazione">
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Vai alla checklist di controllo">
                            <ItemStyle HorizontalAlign="Center" Width="160px" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
                <br />
            </td>
        </tr>
    </table>
</asp:Content>
