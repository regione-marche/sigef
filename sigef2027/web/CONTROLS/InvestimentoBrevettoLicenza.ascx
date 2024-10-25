<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InvestimentoBrevettoLicenza.ascx.cs"
    Inherits="web.CONTROLS.InvestimentoBrevettoLicenza" %>

<script type="text/javascript"><!--
    function controllaDatiInvestimento(ev) {
        if($('[id$=txtCostoInvestimento_text]').val()=='') { alert("Inserire il costo dell'investimento.");return stopEvent(ev); }
        else if($('[id$=txtDescTecnica_text]').val()=='') { alert("Inserire la descrizione tecnica.");return stopEvent(ev); }
        else if($('[id$=txtQuantita_text]').val()=='') { alert("Inserire il numero di brevetti/licenze che si intende acquistare.");return stopEvent(ev); }
    }
//--></script>

<table width='100%' cellpadding="0" cellspacing="0">
    <tr>
        <td style="padding: 10px">
            <table width="100%">
                <tr>
                    <td>
                        Descrizione tecnica:<br />
                        <Siar:TextArea Rows="7" ID="txtDescTecnica" runat="server" Width="700px" Obbligatorio="True"
                            NomeCampo="Descrizione tecnica" MaxLength="2000" ExpandableRows="10" />
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
        <td style="padding: 15px">
            <table style="border-collapse: collapse" width="100%">
                <tr>
                    <td style="width: 20px">
                        &nbsp;
                    </td>
                    <td style="width: 150px">
                        Costo €:<br />
                        <Siar:CurrencyBox ID="txtCostoInvestimento" runat="server" NomeCampo="Costo investimento"
                            Obbligatorio="True" Width="120px" />
                    </td>
                    <td style="width: 150px">
                        Quantità:
                        <br />
                        <Siar:IntegerTextBox ID="txtQuantita" NomeCampo="Quantità" Obbligatorio="true" runat="server"
                            Width="78px" />
                    </td>
                    <td style="width: 200px">
                        Unità di misura:
                        <br />
                        <Siar:ComboUnitaMisura ID="lstUnitaDiMisura" runat="server" NomeCampo="Unità di misura"
                            Obbligatorio="True" Enabled="False" NoBlankItem="True">
                        </Siar:ComboUnitaMisura>
                    </td>
                </tr>
                <tr>
                    <td style="width: 20px; font-weight: bold" align="center">
                        <br />
                        €
                    </td>
                    <td style="width: 150px">
                        Ammontare disponibile:<br />
                        <Siar:CurrencyBox ID="txtAmmontareDisponibile" runat="server" Width="120px" ReadOnly="True" />
                    </td>
                    <td style="width: 150px">
                        Contributo:<br />
                        <Siar:CurrencyBox ID="txtContributoRichiesto" runat="server" Width="120px" ReadOnly="True" />
                    </td>
                    <td style="width: 200px">
                        Quota %:<br />
                        <Siar:CurrencyBox ID="txtQuotaContributo" runat="server" Width="120px" ReadOnly="True" />
                    </td>
                    <td>
                        <br />
                        <Siar:Button ID="btnCalcolaContributo" runat="server" Modifica="False" OnClick="btnCalcolaContributo_Click"
                            Text="Calcola contributo" Width="159px" OnClientClick="return controllaDatiInvestimento(event);"
                            CausesValidation="False" />
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
