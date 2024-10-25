<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    Inherits="web.Private.IPagamento.IVariante.FirmaRichiesta" CodeBehind="FirmaRichiesta.aspx.cs" %>

<%@ Register Src="~/CONTROLS/CardVariantiIstruttoria.ascx" TagName="CardVariantiIstruttoria" TagPrefix="uc1" %>
<%@ Register Src="~/CONTROLS/WorkFlowVariantiIstruttoria.ascx" TagName="WorkFlowVariantiIstruttoria" TagPrefix="uc2" %>

<%@ Register Src="~/CONTROLS/FirmaDocumento.ascx" TagName="FirmaDocumento" TagPrefix="uc3" %>
<%@ Register Src="~/CONTROLS/SiarNewZoomPunteggio.ascx" TagName="SiarNewZoomPunteggio" TagPrefix="uc4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {
            let $el = $('.steppers-nav').clone();
            $('#containerCopiaPulsanti').append($el);
        });
    </script>
    <uc1:CardVariantiIstruttoria ID="ucCardVarianti" runat="server" />
    <div class="row pt-5">
        <div class="col-sm-12">
            <div class="steppers">
                <uc2:WorkFlowVariantiIstruttoria ID="ucWorkflowVarianti" runat="server" />
                <div class="steppers-content" aria-live="polite">
                    <div class="row bd-form py-5 mx-2">
                      <h2 class="pb-5">CheckList Istruttoria </h2>
                        <div class="row">
                                <div class="col-sm-12 text-end pb-3">
                                    <Siar:Button ID="btnStampa" Text="Stampa checklist" OnClick="btnStampa_Click" runat="server" class="btn btn-secondary"
                                        Modifica="false" CausesValidation="false"
                                        Enabled="False" />
                                </div>
                        <div class="col-sm-12">
                            <Siar:DataGridAgid ID="dgRequisiti" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" PageSize="20" Width="100%">
                                <ItemStyle Height="24px" />
                                <Columns>
                                    <Siar:NumberColumn HeaderText="Nr.">
                                        <ItemStyle Width="35px" HorizontalAlign="center" />
                                    </Siar:NumberColumn>
                                    <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione requisito"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="Obbligatorio" DataFormatString="{0:SI|NO}" HeaderText="Obbligatorio">
                                        <ItemStyle HorizontalAlign="center" Width="90px" />
                                    </asp:BoundColumn>
                                    <asp:TemplateColumn HeaderText="Esito Verifica">
                                        <ItemStyle HorizontalAlign="Center" Width="110px" />
                                        <ItemTemplate>
                                            <Siar:ComboSiNo ID="lstEsitoRequisito" runat="server" DataColumn="IdRequisito" NoBlankItem="true">
                                            </Siar:ComboSiNo>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:BoundColumn HeaderText="Note">
                                        <ItemStyle Width="365px" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                </Columns>
                            </Siar:DataGridAgid>
                        </div>
                        <div class="form-group col-sm-12 mt-5" >
                            <Siar:TextArea Label=" Valutazione dell'istruttore: (max 1000 caratteri)" ID="txtValutazioneLunga" runat="server" Rows="5" MaxLength="1000" ExpandableRows="5" NomeCampo="Valutazione investimento" />
                        </div>
                        <div class="form-group col-sm-6">
                            <Siar:TextBox  Label="Funzionario istruttore: (max 1000 caratteri)" ID="txtIstruttore" runat="server" ReadOnly="True" />
                        </div>
                        <div class="form-group col-sm-6">
                            <Siar:TextBox  Label="Numero identificativo del documento interno (ID Paleo):" ID="txtSegnatura" runat="server" ReadOnly="True" />
                        </div>
                        <div class="col-sm-12">
                            <Siar:Button ID="btnVerifica" runat="server" Modifica="True" Text="Verifica requisiti" OnClick="btnVerifica_Click" CausesValidation="false" />

                            <Siar:Button ID="btnPredisponiValutazione" runat="server" OnClick="btnPredisponiValutazione_Click" Text="Predisponi alla valutazione" Modifica="true" />
                            <Siar:Button ID="btnFirma" runat="server" Conferma="Attenzione! Lo stato della domanda verrà cambiato e non sarà più possibile modificare i dati. Proseguire?"
                               Text="Rendi definitiva" OnClick="btnFirma_Click" Enabled="False" />
                            <input id="btnBackToPagamento" runat="server" class="Button" style="width: 200px" visible="false" type="button" value="Ritorna al pagamento" />
                           
                          
                          <%--  <Siar:Button ID="btnStampa" Text="Stampa checklist" OnClick="btnStampa_Click" runat="server" class="btn btn-secondary py-1"
                                 Modifica="false" Width="120px" CausesValidation="false"
                                Enabled="False" />--%>
                            <input id="btnPunteggio" runat="server" class="btn btn-secondary py-1" type="button"
                                value="Calcola punteggio" />
                        </div>
                        <div id="trPredisposizione" runat="server"></div>
                        </div>
                        <div class="row py-5 mx-2">
                            <h4 class="pb-5">Predisposizione alla firma della variante/ variazione finanziaria da parte del Responsabile di Misura:</h4>
                            <p>
                                <b>FACOLTATIVO</b>: la predisposizione alla firma è la modalità di presentazione
                            della variante per i casi di <b>firma differita.</b>
                            </p>

                            <p>
                                Ovvero questa modalità prevede il congelamento della domanda in tutte le sue sezioni,
                            quindi non piu&#39; modificabile, in attesa della firma finale da parte del <b>RUP Responsabile di misura</b>, che potrà eseguire
                            il successivo rilascio da una qualsiasi postazione egli abbia a disposizione.
                            </p>
                            <p>
                                Ciò è utile nei casi in cui il firmatario non può essere presente nella stessa sede in cui si trova l&#39;istruttore che compila e istruisce la pratica.
                            </p>
                            <p>
                                Tale predisposizione può essere sempre annullata <b>prima del rilascio</b> per eseguire correzioni o adeguamenti finali.
                            </p>
                            <p>
                            </p>
                             <div class="col-sm-12 text-center">
                                <Siar:Button ID="btnPredisponiFirma" runat="server" Width="220px" Text="Predisponi alla firma"
                                    CausesValidation="false" Conferma="Attenzione! Predisporre la variante alla firma da remoto?"
                                    OnClick="btnPredisponiFirma_Click" Modifica="False" Enabled="False" />
                            </div>

                            <uc4:SiarNewZoomPunteggio ID="ucSiarNewZoomPunteggio" runat="server" />
                            <uc3:FirmaDocumento ID="ucFirmaDocumento" runat="server" Titolo="FIRMA DIGITALE DI ISTRUTTORIA VARIANTE\A.T." DoppiaFirma="true" />

                        </div>                  
                </div>
                    <div id="containerCopiaPulsanti" class="row py-5 steppers">
                </div>
            </div>
        </div>
    </div>
</div>
       <%-- <tr>
            <td style="padding: 10px">
                <table width="100%">
                    <tr>
                        <td style="width: 360px">
                            Funzionario istruttore:
                            <br />
                            
                        </td>
                        <td>
                            Numero identificativo del documento interno (ID Paleo):<br />
                            <Siar:TextBox  ID="txtSegnatura" runat="server" ReadOnly="True" Width="484px" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>--%>
      <%--  <tr>
            <td align="center" style="height: 107px;">
                <Siar:Button ID="btnVerifica" runat="server" Modifica="True" Text="Verifica requisiti"
                    Width="200px" OnClick="btnVerifica_Click" CausesValidation="false" />&nbsp;&nbsp;&nbsp;
                <Siar:Button ID="btnPredisponiValutazione" runat="server" OnClick="btnPredisponiValutazione_Click" 
                Text="Predisponi alla valutazione" Width="200px" Modifica="true" />&nbsp;&nbsp;&nbsp;
                <Siar:Button ID="btnFirma" runat="server" Conferma="Attenzione! Lo stato della domanda verrà cambiato e non sarà più possibile modificare i dati. Proseguire?"
                    Width=" 200px" Text="Rendi definitiva" OnClick="btnFirma_Click" Enabled="False" />
                <input id="btnBackToPagamento" runat="server" class="Button" style="width: 200px"
                    visible="false" type="button" value="Ritorna al pagamento" /><br />
                &nbsp;<br />
                <Siar:Button ID="btnStampa" Text="Stampa checklist" OnClick="btnStampa_Click" runat="server"
                    Style="width: 200px" Modifica="false" Width="120px" CausesValidation="false"
                    Enabled="False" />&nbsp;&nbsp;&nbsp;
                <input id="btnPunteggio" runat="server" class="Button" style="width: 200px" type="button"
                    value="Calcola punteggio" />
                <br />
            </td>
        </tr>--%>
    <%--    <tr id="trPredisposizione" runat="server">--%>
           <%-- <td>
                <table width="100%">
                    <tr>
                        <td class="separatore_big">
                            Predisposizione alla firma della variante/ variazione finanziaria da parte del Responsabile di Misura:
                        </td>
                    </tr>
                    <tr>
                        <td class="testo_pagina">
                            <b>FACOLTATIVO</b>: la predisposizione alla firma è la modalità di presentazione
                            della variante per i casi di <b>firma differita.</b><br />
                            Ovvero questa modalità prevede il congelamento della domanda in tutte le sue sezioni,
                            quindi non piu&#39; modificabile,
                            <br />
                            in attesa della firma finale da parte del <b>RUP Responsabile di misura</b> , che potrà eseguire<br />
                            il successivo rilascio da una qualsiasi postazione egli abbia a disposizione. Ciò
                            è utile nei casi in cui il firmatario<br />
                            non può essere presente nella stessa sede in cui si trova l&#39;istruttore che compila
                            istruisce la pratica.<br />
                            Tale predisposizione può essere sempre annullata <b>prima del rilascio</b> per eseguire
                            correzioni o adeguamenti finali.
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="padding-bottom: 20px;" valign="top">
                            <Siar:Button ID="btnPredisponiFirma" runat="server" Width="220px" Text="Predisponi alla firma"
                                CausesValidation="false" Conferma="Attenzione! Predisporre la variante alla firma da remoto?"
                                OnClick="btnPredisponiFirma_Click" Modifica="False" Enabled="False" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>--%>
    
</asp:Content>
