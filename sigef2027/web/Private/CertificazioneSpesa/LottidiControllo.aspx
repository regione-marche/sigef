<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SigefAgidPrivate.master" CodeBehind="LottidiControllo.aspx.cs" 
Inherits="web.Private.CertificazioneSpesa.LottidiControllo" %>

<%@ Register Src="../../CONTROLS/SiarNewTab.ascx" TagName="SiarNewTab" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
        function chkClick(id,elem) { if(elem.checked) $('[id$=hdnIdLotto]').val(id);else $('[id$=hdnIdLotto]').val('');$('[id$=btnPost]').click(); }
        function mostraParametriXDomanda(idDomandaPagamento) { $('[id$=hdnIdDomandaPagamento]').val(idDomandaPagamento);$('[id$=btnCaricaParametriDomanda]').click(); }
        function chiudi() { $('[id$=hdnIdDomandaPagamento]').val('');$('[id$=lblParametriDomandaMessaggio]').text('');chiudiPopupTemplate(); }
//--></script>

    <br />
    <table class="tableNoTab" width="900">
        <tr>
            <td class="separatore_big">
                LOTTI DI CONTROLLO
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width: 539px" class="testo_pagina">
                            Di seguito viene visualizzata l'elenco dei lotti di controllo creati fino ad ora
                            e il loro stato attuale, la lista delle domande di pagamento che lo compongono,
                            gli operatori assegnati e loro gestione.<br />
                            Per cominciare selezionare un lotto esistente spuntando la casella relativa o definirne
                            uno nuovo selezionando la <b>programmazione</b>di riferimento.
                        </td>
                        <td>
                            <table width="100%" style="border-left: solid 1px black; border-bottom: solid 1px black;
                                padding-bottom: 10px">
                                <tr>
                                    <td class="separatore">
                                        Opzioni:
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-left: 10px">
                                        Programmazione:<br />
                                        <Siar:ComboGroupZProgrammazioneShort ID="lstProgrammazione" runat="server">
                                        </Siar:ComboGroupZProgrammazioneShort>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="height: 37px">
                                        <Siar:Button ID="btnCerca" runat="server" CausesValidation="False" OnClick="btnCerca_Click"
                                            Text="Cerca" Width="71px" />&nbsp;&nbsp;&nbsp;
                                        <Siar:Button ID="btnCreaLotto" runat="server" OnClick="btnCreaLotto_Click" Text="Crea nuovo"
                                            Width="120px" Modifica="True" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="padding-bottom: 10px; padding-top: 10px">
                <Siar:DataGridAgid ID="dgLotti" runat="server" CssClass="table table-striped" AutoGenerateColumns="False" AllowPaging="true" PageSize="10">
                    <ItemStyle Height="30px" />
                    <Columns>
                        <asp:BoundColumn DataField="Id" HeaderText="ID">
                            <ItemStyle HorizontalAlign="Center" Width="40px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Programmazione" HeaderText="Programmazione">
                            <ItemStyle HorizontalAlign="Center" Font-Bold="true" Width="120px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="DataCreazione" HeaderText="Data creazione">
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Nominativo" HeaderText="Operatore"></asp:BoundColumn>
                        <asp:BoundColumn DataField="ControlloConcluso" DataFormatString="{0:Concluso|In corso}"
                            HeaderText="Stato del controllo">
                            <ItemStyle HorizontalAlign="Center" Width="130px" Font-Bold="true" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="DomandeAssegnate" HeaderText="Numero domande assegnate">
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="DomandeEstratte" HeaderText="Numero domande estratte">
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="DataEstrazione" HeaderText="Data di estrazione">
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn>
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGridAgid><div style="display: none">
                    <Siar:Button ID="btnPost" runat="server" CausesValidation="False" OnClick="btnPost_Click" />
                    <asp:HiddenField ID="hdnIdLotto" runat="server" />
                </div>
            </td>
        </tr>
    </table>
    <br />
    <uc2:SiarNewTab ID="ucSiarNewTab" runat="server" TabNames="Elenco domande|Parametri di rischio" />
    <table width="1050px" class="tableTab" id="tableDomande" runat="server">
        <tr>
            <td class="testo_pagina">
                <span style="text-decoration: underline">
                    <br />
                    Elenco delle domande assegnate al lotto selezionato:</span><br />
                - se non sono presenti elementi utilizzare il pulsante Seleziona domande per assegnare
                tutte le domande di pagamento che sono state predisposte al controllo<br />
                - utilizzare lo stesso pulsante per aggiungerne altre qualora richiesto (abilitato
                fino ad estrazione del campione)<br />
                - successivamente calcolare il valore di rischio per ciascuna domanda del lotto<br />
                - al termine, estrarre il campione su cui verra' effettuato il controllo.
            </td>
        </tr>
        <tr>
            <td style="height: 60px" align="center">
                <Siar:Button ID="btnSelezionaDomande" runat="server" CausesValidation="False" Modifica="True"
                    OnClick="btnSelezionaDomande_Click" Text="Seleziona domande" Width="200px" />
                &nbsp;&nbsp;
                <Siar:Button ID="btnCampione" runat="server" CausesValidation="False" Modifica="True"
                    OnClick="btnCampione_Click" Text="Estrai campione" Width="200px" />
                &nbsp;&nbsp;
                <Siar:Button ID="btnEstrazioneAggiuntiva" runat="server" CausesValidation="False"
                    Modifica="True" OnClick="btnEstrazioneAggiuntiva_Click" Text="Estrai a rischio"
                    Width="200px" />
                &nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;<Siar:Button ID="btnSalvaOperatori"
                    runat="server" CausesValidation="False" Modifica="True" OnClick="btnSalvaOperatori_Click"
                    Text="Salva operatori" Width="147px" />
                &nbsp;&nbsp;
                <Siar:Button ID="btnEliminaLotto" runat="server" CausesValidation="False" Modifica="True"
                    OnClick="btnEliminaLotto_Click" Text="Elimina lotto" Width="147px" Conferma="Attenzione! Eliminare il lotto?" />
            </td>
        </tr>
        <tr>
            <td class="separatore">
                Elementi trovati:
                <Siar:Label ID="lblNumeroDomande" runat="server">
                </Siar:Label>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;<Siar:DataGridAgid ID="dgDomande" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" PageSize="20">
                    <ItemStyle Height="24px" />
                    <Columns>
                        <asp:BoundColumn DataField="IdProgetto" HeaderText="Numero domanda di aiuto">
                            <ItemStyle Font-Bold="True" Font-Size="Small" HorizontalAlign="Center" Width="90px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Descrizione" HeaderText="Modalit&#224; della richiesta">
                            <ItemStyle HorizontalAlign="Center" Width="120px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn>
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="DataPresentazioneDomandaPagamento" HeaderText="Data di presentazione">
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ContributoRichiesto" HeaderText="Contributo richiesto"
                            DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" Width="90px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="SelezionataXControllo" DataFormatString="{0:SI|NO}" HeaderText="Estratta a campione">
                            <ItemStyle HorizontalAlign="Center" Width="110px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Valore di rischio (classe)">
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Operatore assegnato">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Visita in azienda">
                            <ItemStyle HorizontalAlign="Center" Width="140px" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGridAgid>
                <div style="display: none">
                    <Siar:Hidden ID="hdnIdDomandaPagamento" runat="server">
                    </Siar:Hidden>
                    <Siar:Button ID="btnCaricaParametriDomanda" runat="server" CausesValidation="false"
                        OnClick="btnCaricaParametriDomanda_Click" /></div>
            </td>
        </tr>
        <tr>
            <td align="right">
                <span style="color: #bc3333"><strong>C</strong></span> = estrazione in modalita
                <strong>casuale</strong> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp;
                <br />
                <span style="color: #bc3333"><strong>R</strong></span> = estrazione con calcolo
                dei valori di <strong>rischio<br />
                    &nbsp;</strong>
            </td>
        </tr>
    </table>
    <table width="900px" class="tableTab" id="tableParametri" runat="server">
        <tr>
            <td class="testo_pagina">
                <span style="text-decoration: underline">
                    <br />
                    Selezione dei parametri di rischio per il lotto selezionato:</span><br />
                - la <b>spunta</b> nella casella dell'ultima colonna denota l'<b>associazione</b>
                del relativo parametro al lotto<br />
                - all'atto della <b>selezione</b> di un singolo parametro verranno <b>ricalcolati tutti
                    i pesi normalizzati</b><br />
                - per terminare il lavoro usare il pulsante <b>Salva</b>.
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGridAgid ID="dgParametri" runat="server"  AutoGenerateColumns="False" CssClass="table table-striped" PageSize="20">
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle Width="50px" HorizontalAlign="center" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn HeaderText="Descrizione" DataField="Descrizione"></asp:BoundColumn>
                        <Siar:IntegerColumn DataField="Id" Valore="Peso" Name="txtPesoBox" HeaderText="Peso"
                            ReadOnly="true">
                            <ItemStyle Width="120px" HorizontalAlign="center" />
                        </Siar:IntegerColumn>
                        <Siar:IntegerColumn DataField="Id" Valore="PesoReale" Name="txtPesoRealeBox"
                            HeaderText="Peso normalizzato" ReadOnly="true">
                            <ItemStyle Width="120px" HorizontalAlign="center" />
                        </Siar:IntegerColumn>
                        <Siar:CheckColumn Name="chkParametro" DataField="Id" HeaderSelectAll="true">
                            <ItemStyle HorizontalAlign="Center" Width="70px" />
                        </Siar:CheckColumn>
                    </Columns>
                </Siar:DataGridAgid><br />
            </td>
        </tr>
        <tr>
            <td style="height: 39px" align="right">
                <Siar:Button ID="btnSalvaParametri" runat="server" CausesValidation="False" Modifica="True"
                    OnClick="btnSalvaParametri_Click" Text="Salva i valori" Width="189px" Conferma="Attenzione! Questa operazione cancellerà i valori di rischio già calcolati su tutte le domande del lotto. Continuare?" />
                &nbsp; &nbsp;&nbsp;
            </td>
        </tr>
    </table>
    <div id='divParametriDomanda' style="width: 573px; position: absolute; display: none">
        <table width="100%" class="tableNoTab">
            <tr>
                <td class="separatore_big">
                    Calcolo del valore di rischio della domanda di pagamento selezionata
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                    <Siar:DataGridAgid ID="dgParametriDomanda" runat="server" ShowFooter="true" AutoGenerateColumns="False" CssClass="table table-striped" PageSize="20"> 
                        <ItemStyle Height="30px" />
                        <Columns>
                            <Siar:NumberColumn HeaderText="Nr.">
                                <ItemStyle HorizontalAlign="Center" Width="30px" />
                            </Siar:NumberColumn>
                            <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione"></asp:BoundColumn>
                            <Siar:IntegerColumn Name="txtPunteggioParametroDomanda" DataField="Id" Valore="Punteggio"
                                HeaderText="Punteggio">
                                <ItemStyle HorizontalAlign="Center" Width="160px" />
                            </Siar:IntegerColumn>
                        </Columns>
                    </Siar:DataGridAgid>
                </td>
            </tr>
            <tr>
                <td>
                    <b>
                        <asp:Label ID="lblParametriDomandaMessaggio" runat="server"></asp:Label></b>
                </td>
            </tr>
            <tr>
                <td align="right" style="height: 50px">
                    <Siar:Button ID="btnCalcolaPunteggioDomanda" runat="server" CausesValidation="False" Modifica="True" 
                                 OnClick="btnCalcolaPunteggioDomanda_Click" Text="Calcola" Width="140px" />
                    <input class="Button" style="width: 105px; margin-left: 20px; margin-right: 20px" type="button" 
                           value="Chiudi" onclick="chiudi()" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
