<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.PPagamento.Variante.Riepilogo" CodeBehind="Riepilogo.aspx.cs" %>

<%@ Register Src="~/CONTROLS/WorkFlowVarianti.ascx" TagName="WorkFlowVarianti" TagPrefix="uc2" %>
<%@ Register Src="~/CONTROLS/ProgettoIndicatori.ascx" TagName="ProgettoIndicatori" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
        function ctrlCuaa(ev) {
            var text_box_cuaa=$('[id$=txtCuaaEntrante_text]');var cuaa=$(text_box_cuaa).val().replace(/\s/g,'');
            if(cuaa!=''&&!ctrlCodiceFiscale(cuaa)&&!ctrlPIVA(cuaa)) { alert('Attenzione! Il Codice fiscale specificato non è valido.'); return stopEvent(ev); }
        }
 //--></script>

    <uc2:WorkFlowVarianti ID="ucWorkFlowVarianti" runat="server" />
    <br />
    <input type="hidden" id="hdnIdImpresaEntrante" runat="server" />
    <table class="tableNoTab" width="800">
        <tr>
            <td class="separatore_big">
                Riepilogo dati della richiesta:
            </td>
        </tr>
        <tr>
            <td class="testo_pagina">
                In questa pagina e' possibile <b>modificare</b> la modalità della modifica al piano
                degli investimenti che si intende<br />
                richiedere ed inserire una breve <b>descrizione tecnica</b> della stessa. E' inoltre
                possibile <b>annullare</b> l'attuale richiesta<br />
                e <b>cambiare il beneficiario</b> dell'aiuto.
            </td>
        </tr>
        <tr>
            <td style="padding: 10px">
                <table width="100%">
                    <tr>
                        <td>
                            <b>Modalità:</b><br />
                            <Siar:ComboBase ID="lstModalita" runat="server" NomeCampo="Modalita" 
                                Obbligatorio="True" Enabled="False">
                            </Siar:ComboBase>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>Descrizione tecnica:</b> (max 1000 caratteri)
                            <Siar:TextArea ID="txtDescrizione" runat="server" Rows="7" Width="650px" MaxLength="1000"
                                ExpandableRows="10" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <uc1:ProgettoIndicatori ID="ucProgettoInd" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="height: 60px">
                            <Siar:Button ID="btnSalva" runat="server" Modifica="True" Text="Salva le modifiche"
                                Width="200px" OnClick="btnSalva_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="separatore">
                Annullamento della richiesta:
            </td>
        </tr>
        <tr>
            <td class="testo_pagina">
                Questa procedura <b>cancellerà completamente</b> dal sistema la presente richiesta
                come se non fosse mai stata inserita e<br />
                &nbsp;&nbsp; l`impresa potrà inserirne una nuova. E' possibile utilizzarla quando
                ancora non è stata firmata ed è consigliato utilizzarla quando
                <br />
                &nbsp;&nbsp; le modifiche da eseguire sulla stessa siano più onerose che inserirne
                una nuova.
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 60px">
                <Siar:Button ID="btnAnnullamento" runat="server" Modifica="True" Text="Annulla la richiesta"
                    Width="200px" CausesValidation="False" Conferma="Attenzione! La richiesta verrà cancellata dal sistema con tutte le modifiche effettuate. Continuare?"
                    OnClick="btnAnnullamento_Click" />
            </td>
        </tr>
        <tr>
            <td class="separatore">
                Richiesta di cambio beneficiario dell'aiuto:
            </td>
        </tr>
        <tr>
            <td class="testo_pagina">
                La richiesta deve essere effettuata dal <b>beneficiario uscente</b> che attribuisce
                all'entrante l'assegnazione<br />
                del contributo alla domanda di aiuto relativa. Tale domanda e tutte le relative
                richieste di pagamento cambieranno<br />
                intestazione e l'azienda uscente comparira' solo nello storico dell'iter procedurale.<br />
                Per continuare digitare il <b>nuovo codice fiscale</b> nella casella relativa e
                click su <b>Ottieni Dati Anagrafici.</b>
            </td>
        </tr>
        <tr>
            <td class="paragrafo">
                Beneficiario uscente:
            </td>
        </tr>
        <tr>
            <td style="padding: 10px">
                <table width="100%">
                    <tr>
                        <td>
                            Codice fiscale:<br />
                            <Siar:TextBox ID="txtCuaaUscente" runat="server" Width="140px" ReadOnly="True" />
                        </td>
                        <td>
                            Ragione sociale:<br />
                            <Siar:TextBox ID="txtRagSocUscente" runat="server" Width="440px" ReadOnly="True" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="paragrafo">
                Beneficiario entrante:
            </td>
        </tr>
        <tr>
            <td style="padding: 10px">
                <table width="100%">
                    <tr>
                        <td style="width: 170px">
                            Codice fiscale:<br />
                            <Siar:TextBox ID="txtCuaaEntrante" runat="server" Width="140px" />
                        </td>
                        <td>
                            <Siar:Button ID="btnScarica" runat="server" Modifica="True" Text="Ottieni dati anagrafici"
                                Width="200px" OnClick="btnScarica_Click" OnClientClick="return ctrlCuaa(event);" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 170px">
                            P.Iva:<br />
                            <Siar:TextBox ID="txtPivaEntrante" runat="server" Width="140px" ReadOnly="True" />
                        </td>
                        <td>
                            Ragione sociale:<br />
                            <Siar:TextBox ID="txtRagSocEntrante" runat="server" Width="440px" ReadOnly="True" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 60px">
                <Siar:Button ID="btnCambiaBeneficiario" runat="server" Modifica="False" Text="Assegna nuovo beneficiario"
                    Width="200px" OnClick="btnCambiaBeneficiario_Click" Enabled="False" />
            </td>
        </tr>
    </table>
</asp:Content>
