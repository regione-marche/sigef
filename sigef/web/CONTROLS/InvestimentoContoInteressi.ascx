<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InvestimentoContoInteressi.ascx.cs"
    Inherits="web.CONTROLS.InvestimentoContoInteressi" %>

<script type="text/javascript"><!--
//--></script>

<table width='100%' cellpadding="0" cellspacing="0">
    <tr>
        <td class="separatore">
            Descrizione del mutuo:
        </td>
    </tr>
    <tr>
        <td style="padding: 10px">
            <table width='100%'>
                <tr>
                    <td>
                        Finalità:<br />
                        <Siar:ComboZOBMisura ID="lstFinalita" runat="server" Obbligatorio="true" NomeCampo="Finalità"
                            Width="700px">
                        </Siar:ComboZOBMisura>
                    </td>
                </tr>
                <tr>
                    <td>
                        Tipologia:<br />
                        <Siar:ComboZProgrammazione ID="lstTipoIntervento" runat="server" Obbligatorio="true"
                            NomeCampo="Tipologia di intervento" Width="700px">
                        </Siar:ComboZProgrammazione>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>
                        Codifica investimento:
                        <br />
                        <Siar:ComboCodificaInvestimenti ID="lstCodificaInvestimenti" runat="server" NomeCampo="Codifica investimento"
                            Obbligatorio="True" Width="700px">
                        </Siar:ComboCodificaInvestimenti>
                    </td>
                </tr>
                <tr>
                    <td>
                        Descrizione tecnica:(max 2000 caratteri)<br />
                        <Siar:TextArea Rows="15" ID="txtDescrizioneTecnicaLunga" runat="server" Width="700px"
                            Obbligatorio="True" NomeCampo="Descrizione tecnica" MaxLength="2000" ExpandableRows="10" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="separatore">
            Dettaglio delle spese:
        </td>
    </tr>
    <tr>
        <td style="padding: 20px">
            <table width="100%">
                <tr>
                    <td align="center" style="width: 18px">
                        <strong>
                            <br />
                            <br />
                            €</strong>
                    </td>
                    <td style="width: 189px">
                        Ammontare degli investimenti<br />
                        per cui si richiede il mutuo:<br />
                        <Siar:CurrencyBox ID="txtAmmontareInvestimenti" runat="server" NomeCampo="Ammontare degli investimenti"
                            Obbligatorio="True" Width="120px" />
                    </td>
                    <td style="width: 167px">
                        <br />
                        Ammontare del mutuo:<br />
                        <Siar:CurrencyBox ID="txtAmmontare" runat="server" NomeCampo="Ammontare del mutuo"
                            Obbligatorio="True" Width="120px" />
                    </td>
                    <td style="width: 167px">
                        <br />
                        Tasso di abbuono %:<br />
                        <Siar:CurrencyBox ID="txtTasso" runat="server" NomeCampo="Tasso %" Width="55px" Obbligatorio="True" />
                    </td>
                    <td>
                        <br />
                        Tasso di attualizzazione %:<br />
                        <Siar:CurrencyBox ID="txtAttualizzazione" runat="server" NomeCampo="Tasso di attualizzazione"
                            Obbligatorio="True" Width="55px" />
                        <a style="margin-left: 10px" href="http://ec.europa.eu/comm/competition/state_aid/legislation/reference_rates.html"
                            target="_blank">visualizza tabella dei tassi attuali</a>
                    </td>
                </tr>
                <tr>
                    <td style="width: 18px">
                        &nbsp;
                    </td>
                    <td style="width: 189px">
                        Durata anni:<br />
                        <Siar:ComboInteger ID="lstAnni" runat="server" NomeCampo="Durata" Obbligatorio="True">
                        </Siar:ComboInteger>
                    </td>
                    <td style="width: 167px">
                        Nr. rate annuali:<br />
                        <Siar:CurrencyBox ID="txtRateAnnuali" runat="server" NomeCampo="NumeroRate" ReadOnly="True"
                            Width="73px" />
                    </td>
                    <td style="width: 167px">
                        Contributo:<br />
                        <Siar:CurrencyBox ID="txtContributoAmmissibile" runat="server" ReadOnly="True" Width="120px" />
                    </td>
                    <td>
                        <br />
                        <Siar:Button ID="btnCalcolaContributo" runat="server" CausesValidation="true" Modifica="False"
                            OnClick="btnCalcolaContributo_Click" Text="Calcola contributo" Width="159px" />
                    </td>
                </tr>
            </table>
            <table width="100%">
                <tr>
                    <td class="testoRosso" id="rowContributoMessaggio" runat="server">
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="separatore">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="padding: 10px">
            <table width="100%" id="tableValutazione" runat="server" visible="false">
                <tr>
                    <td>
                    </td>
                    <td style="width: 720px">
                        Valutazione dell`investimento (a cura del funzionario istruttore):<br />
                        <Siar:TextArea ID="txtValutazioneIstruttore" runat="server" NomeCampo="Valutazione investimento"
                            Rows="7" Width="706px" ReadOnly="True" ExpandableRows="10" />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td align="center" style="height: 39px">
                        <input id="btnVisualizzaOriginale" runat="server" class="Button" style="width: 250px"
                            type="button" value="Visualizza storico investimento" />
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
