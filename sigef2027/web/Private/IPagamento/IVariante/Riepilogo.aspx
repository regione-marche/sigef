<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    Inherits="web.Private.IPagamento.IVariante.Riepilogo" CodeBehind="Riepilogo.aspx.cs" %>


<%@ Register Src="~/CONTROLS/WorkFlowVariantiIstruttoria.ascx" TagName="WorkFlowVariantiIstruttoria" TagPrefix="uc2" %>
<%@ Register Src="~/CONTROLS/CardVariantiIstruttoria.ascx" TagName="CardVariantiIstruttoria" TagPrefix="uc3" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
   <script type="text/javascript">

    $(document).ready(function () {
        let $el = $('.steppers-nav').clone();
        $('#containerCopiaPulsanti').append($el);
    });
   </script>

    <div style="display: none">
        <input type="hidden" id="hdnIdImpresaEntrante" runat="server" />
    </div>
    <uc3:CardVariantiIstruttoria ID="ucCardVariantiIstruttoria" runat="server" />
    <div class="row pt-5">
        <div class="col-sm-12">
            <div class="steppers">
                <uc2:WorkFlowVariantiIstruttoria ID="ucWorkFlowVarianti" runat="server" />
                <div class="steppers-content" aria-live="polite">
                    <div class="row bd-form pt-5 mx-2">
                        <div class="form-group col-sm-12">
                            <h2 class="pb-5">Riepilogo dati della richiesta</h2>
                            <p>
                                In questa pagina e' possibile visualizzare la modalità della modifica al piano degli investimenti che è stata richiesta
                       ed avere una breve descrizione tecnica della stessa.
                            </p>

                        </div>
                        <div class="form-group col-sm-4">
                            <Siar:ComboBase Label="Modalità:" ID="lstModalita" runat="server" NomeCampo="Modalita" Enabled="false" Obbligatorio="True"></Siar:ComboBase>
                        </div>
                        <div class="form-group col-sm-12">
                            <Siar:TextArea Label="Descrizione tecnica: (max 1000 caratteri)" ID="txtDescrizione" runat="server" Rows="5" MaxLength="1000" ExpandableRows="5" />
                        </div>
                        <Siar:Button ID="btnSalvaMotivazioni" runat="server" CausesValidation="False" Modifica="True"
                            OnClick="btnSalvaMotivazioni_Click" Text="Salva le motivazioni" Conferma="" Visible="False" />

                        <Siar:Button ID="btnEliminaVariazione" runat="server" CausesValidation="False" Modifica="True"
                            OnClick="btnEliminaVariazione_Click" Text="Elimina la variazione" Conferma="Attenzione! Eliminare la variazione di istruttoria?"
                            Visible="False" />
                    </div>
                    <div class="row bd-form pt-5 mx-2">
                        <h4 class="pb-5">Richiesta di cambio beneficiario dell'aiuto</h4>
                        <p>
                            Qualori i campi sottostanti fossero <b>compilati </b>significa che tale variante
                        include la richiesta di cambio beneficiario<br />
                            della domanda di aiuto relativa e di tutte le domande di pagamento successive.
                        </p>
                        <h5 class="pb-5">Beneficiario uscente:</h5>
                        <div class="form-group col-sm-12">
                            <div class="row">
                                <div class="form-group col-sm-4">
                                    <Siar:TextBox  Label=" Partita iva/Codice fiscale" ID="txtCuaaUscente" runat="server" ReadOnly="True" />
                                </div>
                                <div class="form-group col-sm-4">
                                    <Siar:TextBox  Label="Ragione Sociale" ID="txtRagSocUscente" runat="server" ReadOnly="True" />
                                </div>
                            </div>
                        </div>
                        <h5 class="pb-5">Beneficiario entrante:</h5>
                        <div class="col-sm-12">
                            <div class="row">
                                <div class="form-group col-sm-4">
                                    <Siar:TextBox  Label="Partita iva/Codice fiscale:" ID="txtCuaaEntrante" runat="server" />
                                </div>
                                <div class="form-group col-sm-4">
                                    <Siar:TextBox  Label="P.Iva:" ID="txtPivaEntrante" runat="server" />
                                </div>
                                 <div class="form-group col-sm-4">
                                     <Siar:TextBox  Label="Ragione sociale:" ID="txtRagSocEntrante" runat="server" />
                                 </div>

                            </div>                        
                        </div>
                    </div>
                    <div class="row bd-form pt-5 mx-2">
                        <h4 class="pb-5">Fascicolo aziendale:</h4>
                        <div class="col-sm-12">
                            <div class="row">
                                <div class="form-group col-sm-4">
                                    <Siar:DateTextBox Label="Data Validazione:" ID="txtDataValidazione" runat="server" ReadOnly="True"/>
                                </div>
                                <div class="form-group col-sm-4">
                                    <Siar:DateTextBox Label="Data scheda validazione:" ID="txtDataSchedaValidazione" runat="server" ReadOnly="True"/>
                                </div>
                                <div class="form-group col-sm-4">
                                    <Siar:DateTextBox Label=" Barcode scheda validazione:" ID="txtBarcode" runat="server" ReadOnly="True"/>
                                </div>
                            </div>
                        </div>
                    </div>
                     <div id="containerCopiaPulsanti" class="row py-5 steppers"></div>
                </div>
            </div>
        </div>
    </div>


        <%-- <tr>
            <td class="separatore_big">
                Riepilogo dati della richiesta:
            </td>
        </tr>
        <tr>
            <td class="testo_pagina">
                In questa pagina e' possibile visualizzare la modalità della modifica al piano degli
                investimenti che è stata richiesta<br />
                ed avere una breve descrizione tecnica della stessa.
            </td>
        </tr>--%>
       <%-- <tr>
            <td style="padding: 10px">
                <table width="100%">
                    <tr>
                        <td>
                          <%--  <b>Modalità:</b><br />
                            <Siar:ComboBase ID="lstModalita" runat="server" NomeCampo="Modalita" Obbligatorio="True">
                            </Siar:ComboBase>--%>
            <%--            </td>
                    </tr>
                    <tr>
                        <td>
                            <b>Descrizione tecnica\Motivazioni:</b> (max 1000 caratteri)
                            <Siar:TextArea ID="txtDescrizione" runat="server" Rows="7" Width="650px" MaxLength="1000"
                                ExpandableRows="10" />
                        </td>
                    </tr>--%>
                   <%-- <tr>
                        <td align="center" style="height: 60px">--%>
                         <%--   <Siar:Button ID="btnSalvaMotivazioni" runat="server" CausesValidation="False" Modifica="True"
                                OnClick="btnSalvaMotivazioni_Click" Text="Salva le motivazioni" Conferma="" Visible="False" />
                            &nbsp;&nbsp; &nbsp;
                            <Siar:Button ID="btnEliminaVariazione" runat="server" CausesValidation="False" Modifica="True"
                                OnClick="btnEliminaVariazione_Click" Text="Elimina la variazione" Conferma="Attenzione! Eliminare la variazione di istruttoria?"
                                Visible="False" />--%>
                <%--        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="separatore">
                Richiesta di cambio beneficiario dell'aiuto:
            </td>
        </tr>
        <tr>
            <td class="testo_pagina">
                Qualori i campi sottostanti fossero <b>compilati </b>significa che tale variante
                include la richiesta di cambio beneficiario<br />
                della domanda di aiuto relativa e di tutte le domande di pagamento successive.
            </td>
        </tr>--%>
       <%-- <tr>
            <td class="paragrafo">
                Beneficiario uscente:
            </td>
        </tr>
        <tr>
            <td style="padding: 10px">
                <table width="100%">
                    <tr>
                        <td>
                            Partita iva/Codice fiscale:<br />
                            <Siar:TextBox  ID="txtCuaaUscente" runat="server" Width="140px" ReadOnly="True" />
                        </td>
                        <td>
                            Ragione sociale:<br />
                            <Siar:TextBox  ID="txtRagSocUscente" runat="server" Width="440px" ReadOnly="True" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>--%>
        <%--<tr>
            <td class="paragrafo">
                Beneficiario entrante:
            </td>
        </tr>
        <tr>
            <td style="padding: 10px">
                <table width="100%">
                    <tr>
                        <td style="width: 180px">
                            Partita iva/Codice fiscale:<br />
                            <Siar:TextBox  ID="txtCuaaEntrante" runat="server" Width="140px" ReadOnly="true" />
                        </td>
                        <td>
                            P.Iva:<br />
                            <Siar:TextBox  ID="txtPivaEntrante" runat="server" Width="140px" ReadOnly="True" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            Ragione sociale:<br />
                            <Siar:TextBox  ID="txtRagSocEntrante" runat="server" Width="440px" ReadOnly="True" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="paragrafo">
               Fascicolo aziendale:
            </td>
        </tr>
        <tr>
            <td style="padding: 10px">
                <table width="100%">
                    <tr>
                        <td style="width: 170px">
                            Data validazione:<br />
                            <Siar:DateTextBox  ID="txtDataValidazione" runat="server" ReadOnly="True" />
                        </td>
                        <td style="width: 170px">
                            Data scheda validazione:<br />
                            <Siar:DateTextBox ID="txtDataSchedaValidazione" runat="server" ReadOnly="True" Width="100px" />
                        </td>
                        <td>
                            Barcode scheda validazione:<br />
                            <Siar:TextBox  ID="txtBarcode" runat="server" Width="140px" ReadOnly="True" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>--%>
</asp:Content>
