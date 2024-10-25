<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.Psr.Bandi.BandoSettoriProduttiviPriorita" CodeBehind="BandoSettoriProduttiviPriorita.aspx.cs" %>

<%@ Register Src="../../../CONTROLS/SiarNewTab.ascx" TagName="SiarNewTab" TagPrefix="uc2" %>
<%@ Register Src="../../../CONTROLS/ZoomLoader.ascx" TagName="ZoomLoader" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
        function SNCVZCercaSettoriProduttivi_onselect(obj) { if(obj&&obj.IdSettoreProduttivo) { $('[id$=hdnIdSettoreProduttivo]').val(obj.IdSettoreProduttivo);$('[id$=txtDescrizioneSettore_text]').val(obj.Descrizione); } else alert('L`elemento selezionato non è valido.'); }
        function SNCVZCercaSettoriProduttivi_onprepare() { $('[id$=hdnIdSettoreProduttivo]').val(''); }
        function ctrlSettoreProduttivo(ev) { if($('[id$=txtDescrizioneSettore_text]').val()=='') { alert('Attenzione! L ambito tematico selezionato non è valido.');return stopEvent(ev); } }
        function eliminaSettoreProduttivo(idsettore) { if(confirm('Attenzione! Eliminare l ambito tematico e tutte le priorità ad esso associate?')) { $('[id$=hdnIdSettoreProduttivo]').val(idsettore);$('[id$=btnEliminaSettoreProduttivo]').click(); } }
        function eliminaPrioritaSettoriale(idbxp) { if(confirm('Eliminare la priorità selezionata?')) { $('[id$=hdnIdBandoSettoreProduttivo]').val(idbxp);$('[id$=btnEliminaPrioritaSettoriale]').click(); } }
        function ctrlPriorita(ev) { if($('[id$=txtDescrizionePriorita_text]').val()=='') { alert('Specificare la descrizione della priorità.');return stopEvent(ev); } }        
    //--></script>

    <div style="display: none">
        <Siar:Hidden ID="hdnIdSettoreProduttivo" runat="server">
        </Siar:Hidden>
        <Siar:Button ID="btnEliminaSettoreProduttivo" runat="server" OnClick="btnEliminaSettoreProduttivo_Click" />
        <Siar:Hidden ID="hdnIdBandoSettoreProduttivo" runat="server">
        </Siar:Hidden>
        <Siar:Button ID="btnEliminaPrioritaSettoriale" runat="server" OnClick="btnEliminaPrioritaSettoriale_Click"
            CausesValidation="false" /></div>
    <br />
    <uc2:SiarNewTab ID="ucSiarNewTab" runat="server" Width="800px" TabNames="Ambiti tematici|Priorità|Codici Ateco|Comuni Localizzazione" />
    <table id="tbSettoriProduttivi" runat="server" class="tableTab" width="800px">
        <tr>
            <td class="testo_pagina">
                Di seguito vengono elencati gli <b>ambiti tematici</b> previsti dal bando. Le voci
                di questo elenco saranno<br />
                selezionabili nella pagina di dettaglio degli investimenti ai fini della completa
                <b>classificazione</b> settoriale degli stessi.<br />
                Ad ognuna di tali voci è possibile associare una o piu&#39; <b>priorità</b>,
                le quali hanno la facoltà, qualora previsto dalla scheda<br />
                di valutazione, di aumentare sia la <b>quota di contributo</b> pubblico del singolo
                investimento, sia il <b>punteggio</b> in graduatoria<br />
                della domanda di aiuto relativa.
            </td>
        </tr>
        <tr>
            <td class="paragrafo">
                Nuovo ambito tematico:
            </td>
        </tr>
        <tr>
            <td class="testo_pagina">
                Digitare la descrizione:<br />
                <Siar:TextBox ID="txtDescrizioneSettore" runat="server" Width="320px" />
                <Siar:Button ID="btnSalvaSettori" runat="server" Text="Inserisci" Modifica="true"
                    OnClick="btnSalvaSettori_Click" Width="100px" OnClientClick="return ctrlSettoreProduttivo(event);" />
            </td>
        </tr>
        <tr>
            <td class="separatore">
                Elenco ambiti associati al bando:
            </td>
        </tr>
        <tr>
            <td style="padding-top: 10px; padding-bottom: 10px">
                <Siar:DataGrid ID="dgSettoriProduttivi" runat="server" Width="100%" PageSize="20"
                    AutoGenerateColumns="False" AllowPaging="True">
                    <ItemStyle Height="30px" />
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle Width="40px" HorizontalAlign="Center" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="SettoreProduttivo" HeaderText="Ambito Tematico"></asp:BoundColumn>
                        <Siar:JsButtonColumn Arguments="IdSettoreProduttivo" ButtonText="Elimina" ButtonType="TextButton"
                            JsFunction="eliminaSettoreProduttivo">
                            <ItemStyle Width="150px" HorizontalAlign="Center" />
                        </Siar:JsButtonColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
    </table>
    <table id="tbPrioritaSettoriali" runat="server" class="tableTab" width="800px">
        <tr>
            <td class="testo_pagina">
                Elenco delle priorità
            </td>
        </tr>
        <tr>
            <td class="paragrafo">
                Dettaglio/Nuova priorità:
            </td>
        </tr>
        <tr>
            <td style="padding: 10px">
                <table style="width: 100%">
                    <tr>
                        <td>
                            Ambito Tematico (facoltativo, non indicato la priorità verrà intesa come comune
                            a tutti gli ambiti):
                            <br />
                            <Siar:ComboSettoreProduttivo runat="server" ID="lstSettoreProduttivo">
                            </Siar:ComboSettoreProduttivo>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Descrizione:<br />
                            <Siar:TextArea ID="txtDescrizionePriorita" runat="server" Width="430px" Rows="3"
                                NomeCampo="Descrizione" Obbligatorio="True" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 50px; padding-right: 50px;" align="right">
                            <Siar:Button ID="btnSalvaPriorita" runat="server" Text="Salva" Modifica="true" OnClick="btnSalvaPriorita_Click"
                                Width="150px" OnClientClick="return ctrlPriorita(event);" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="separatore">
                Elenco priorità:
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dgPrioritaSettoriali" runat="server" Width="100%" AutoGenerateColumns="False"
                    AllowPaging="True" PageSize="10">
                    <ItemStyle Height="30px" />
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle Width="30px" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="PrioritaSettoriale" HeaderText="Priorita">
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="SettoreProduttivo" HeaderText="Ambito Tematico">
                            <ItemStyle Width="260px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <Siar:JsButtonColumn Arguments="IdBandoXSettoreProduttivo" ButtonText="Elimina" ButtonType="TextButton"
                            JsFunction="eliminaPrioritaSettoriale" AbilitaModifica="true">
                            <ItemStyle Width="140px" HorizontalAlign="Center" />
                        </Siar:JsButtonColumn>
                    </Columns>
                </Siar:DataGrid><br />
            </td>
        </tr>
    </table>
    <table id="tbCodiciAteco" runat="server" class="tableTab" width="800px">
        <tr>
            <td>
                <table width="100%">
                    <tr>
                        <td class="testo_pagina" style="width: 400px;" >
                            Di seguito vengono elencati i <b>codici Ateco</b> previsti dal bando.<br>
                            Se nessun codice Ateco è selezionato verrano presi tutti i valori.
                        </td>
                        <td style="text-align:center;">
                            <Siar:Button ID="btnSalvaAteco" runat="server" OnClick="btnSalvaAteco_Click" Text="Salva Codici Ateco"
                                Width="250px" />
                        </td>
                    </tr>
                </table>
            </td>
            
        </tr>
        <tr>
            <td >
                <table width="100%">
                    <tr>
                        <td style="padding-left: 10px;">
                            <asp:CheckBox ID="chkGruppo" runat="server" Checked="True" Text="Gruppo" />
                        </td>
                        <td style="padding-left: 10px;">
                            <asp:CheckBox ID="chkClasse" runat="server" Checked="True" Text="Classe" />
                        </td>
                        <td style="padding-left: 10px;">
                            <asp:CheckBox ID="chkCategoria" runat="server" Checked="True" Text="Categoria" />
                        </td>
                        <td style="padding-left: 10px;">
                            <asp:CheckBox ID="chkSottocategoria" runat="server" Checked="True" Text="Sotto Categoria" />
                        </td>
                        <td style="padding-left: 10px;">
                             <b>Sezione</b>:&nbsp;
                            <asp:TextBox ID="txtSezione" runat="server" Width="40px"></asp:TextBox>
                             &nbsp;&nbsp;&nbsp;&nbsp;<b>Ateco</b>:&nbsp;
                            <asp:TextBox ID="txtAteco" runat="server" Width="80px"></asp:TextBox>

                        </td>
                        <td style="padding-left: 10px; align-content:right;">
                            <Siar:Button ID="btnFiltra" runat="server" OnClick="btnFiltra_Click" Text="Filtra"
                                Width="80px" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dgBandoAteco" runat="server" AllowPaging="false" AutoGenerateColumns="False"
                    PageSize="4000" Width="100%">
                    <Columns>
                        <asp:TemplateColumn HeaderText="N°" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="center" />
                            <ItemTemplate>                                
                                <%# Container.ItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="IdAteco2007" HeaderText="Codice Ateco"  >
                            <ItemStyle HorizontalAlign="center" Font-Bold="true" Width="100px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Sezione" HeaderText="Sezione">
                            <ItemStyle HorizontalAlign="center"/>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Divisione" HeaderText="Divisione">
                            <ItemStyle HorizontalAlign="center"/>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Gruppo" HeaderText="Gruppo">
                            <ItemStyle HorizontalAlign="center"/>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Classe" HeaderText="Classe">
                            <ItemStyle HorizontalAlign="center"/>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Categoria" HeaderText="Categoria">
                            <ItemStyle HorizontalAlign="center"/>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Sottocategoria" HeaderText="Sottocategoria">
                            <ItemStyle HorizontalAlign="center"/>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione"></asp:BoundColumn>                      
                        <Siar:CheckColumn DataField="IdAteco2007" Name="chkIdAteco2007" HeaderSelectAll="true">
                            <ItemStyle Width="80px" HorizontalAlign="center" />
                        </Siar:CheckColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
    </table>

    <table id="tbComuniLocaliz" runat="server" class="tableTab" width="800px">
        <tr>
            <td>
                <table width="100%">
                    <tr>
                        <td class="testo_pagina" style="width: 400px;" >
                            Di seguito vengono elencati i <b>Comuni</b> previsti dal bando per la localizzazione del progetto.<br>
                            Se nessun comune è selezionato verrano presi tutti i valori.
                        </td>
                        <td style="text-align:center;">
                            <Siar:Button ID="btSalvaComuni" runat="server" OnClick="btnSalvaComuni_Click" Text="Salva Comuni"
                                Width="250px" />
                        </td>
                    </tr>
                </table>
            </td>
            
        </tr>
        <tr>
            <td >
                <table width="100%">
                    <tr>
                        <td style="padding-left: 10px;">
                            <asp:CheckBox ID="chkCratere" runat="server"  Text="Comuni Cratere" />
                        </td>
                        <td style="padding-left: 10px;">
                            <b>Provincia</b>:&nbsp;
                            <Siar:ComboProvinceMarche ID="lstProvincia" runat="server" style="width: 100px;" >
                            </Siar:ComboProvinceMarche>
                        </td>
                        <td style="padding-left: 10px;">
                             <b>Denominazione</b>:&nbsp;
                            <asp:TextBox ID="txtDenominazione" runat="server" Width="200px"></asp:TextBox>
                        </td>
                        <td style="padding-left: 10px; align-content:right;">
                            <Siar:Button ID="btnFiltraComuni" runat="server" OnClick="btnFiltraComuni_Click" Text="Filtra"
                                Width="80px" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dgComuniLocaliz" runat="server" AllowPaging="false" AutoGenerateColumns="False"
                    PageSize="4000" Width="100%">
                    <Columns>
                        <asp:TemplateColumn HeaderText="N°" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="center" />
                            <ItemTemplate>                                
                                <%# Container.ItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="CodBelfiore" HeaderText="Cod Belfiore"  >
                            <ItemStyle HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Denominazione" HeaderText="Denominazione">
                            <ItemStyle HorizontalAlign="left"  Width="450px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Sigla" HeaderText="Prov">
                            <ItemStyle HorizontalAlign="center"/>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Cap" HeaderText="CAP">
                            <ItemStyle HorizontalAlign="center"/>
                        </asp:BoundColumn>
                        <Siar:CheckColumn DataField="IdComune" Name="chkIdComune" HeaderSelectAll="true">
                            <ItemStyle Width="80px" HorizontalAlign="center" />
                        </Siar:CheckColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
    </table>
</asp:Content>
