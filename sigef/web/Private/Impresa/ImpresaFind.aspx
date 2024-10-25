<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.Impresa.ImpresaFind" CodeBehind="ImpresaFind.aspx.cs" %>

<%@ Register Src="~/CONTROLS/ImpresaControl.ascx" TagName="ImpresaControl" TagPrefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
        function ctrlCuaaDitta() {
            var text_box_cuaa=$('[id$=txtCuaaRicerca_text]');var cuaa=$(text_box_cuaa).val().replace(/\s/g,'');
            if(cuaa!=null&&cuaa!=""&&!ctrlCodiceFiscale(cuaa)&&!ctrlPIVA(cuaa)) {
                alert('Attenzione! Il Codice Fiscale inserito per la ricerca della ditta non è valido.');
            }
        }

        function scaricaAnagrafica(cuaa) { $('[id$=txtCuaaRicerca_text]').val(cuaa); $('[id$=btnCercaWS]').click(); }

        function switchMostraInserisciImpresa() {
            var div = $('[id$=divInserisciImpresa]');
            var btn = $('[id$=btnInserisciImpresa]')[0];

            if (div[0].style.display === "none") {
                div.show("fast");
                btn.value = "Nascondi inserisci impresa";
            } else {
                div.hide("fast");
                btn.value = "Mostra inserisci impresa";
            }
        }
//--></script>

    <table class="tableNoTab" width="800px">
        <tr>
            <td class="separatore">
                &nbsp;PAGINA DI SELEZIONE BENEFICIARIO:
            </td>
        </tr>
        <tr>
            <td>
                <table style="width: 100%;">
                    <tr>
                        <td style="width: 251px; height: 33px;">
                            <b>
                                <br />
                                &nbsp;Ricerca per Codice Fiscale:</b>
                        </td>
                        <td style="height: 33px">
                            <b>
                                <br />
                                &nbsp;Ricerca per ragione sociale:</b>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 251px">
                            <Siar:TextBox ID="txtCuaaRicerca" runat="server" Obbligatorio="true" NomeCampo="Partita iva/Codice fiscale"
                                Width="150px" Style="text-align: left" />
                        </td>
                        <td>
                            <Siar:TextBox ID="txtRagSociale" runat="server" Width="236px" />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 251px">
                            (inserire il codice fiscale del beneficiario da ricercare)
                        </td>
                        <td>
                            (consigliato digitare una sola parola o parte di essa)
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%">
                    <tr>
                        <td align="center" style="height: 52px">
                            <Siar:Button ID="btnCercaDB" runat="server" Width="220px" Text="Cerca sul database locale"
                                CausesValidation="False" OnClick="btnCercaDB_Click"></Siar:Button>
                            &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;
                            <Siar:Button ID="btnCercaWS" runat="server" Visible="false"
                                Width="220px" Text="Cerca su Anagrafe Tributaria" OnClick="btnCercaWS_Click"
                                CausesValidation="TRUE"></Siar:Button>
                            <%--<Siar:Button ID="btnInserisciImpresa" runat="server" Visible="false"
                                Width="220px" Text="Inserisci una nuova impresa" OnClick="btnInserisciImpresa_Click"
                                CausesValidation="TRUE"></Siar:Button>--%>
                            <input runat="server" id="btnInserisciImpresa" type="button" style="width:220px" Visible="false"
                                class="ButtonGrid" value="Mostra inserisci impresa"
                                onclick="switchMostraInserisciImpresa();"
                                />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="separatore">
                &nbsp;Elementi trovati :
                <Siar:Label ID="lblRisultato" runat="server">
                </Siar:Label>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dg" runat="server" Width="100%" PageSize="15" AllowPaging="True"
                    AutoGenerateColumns="False">
                    <ItemStyle Height="26px"></ItemStyle>
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle Width="30px" HorizontalAlign="Center" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="RagioneSociale" HeaderText="Ragione sociale"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Cuaa" HeaderText="Cod.Fiscale">
                            <ItemStyle Width="120px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="CodiceFiscale" HeaderText="Cf/P.Iva">
                            <ItemStyle Width="120px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn>
                            <ItemStyle HorizontalAlign="Center" Width="160px" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
    </table>
    <br />
    <br />

    <div runat="server" id="divInserisciImpresa" class="dBox" style="display: none; width: 800px;" >
        <div class="separatore" >
            Inserisci una nuova impresa
        </div>
        <br />
        
        <div style="padding: 5px;">
            <p>Prima di inserire una nuova impresa verificare che non esista già!</p>
            <br />

            <uc3:ImpresaControl ID="ucImpresaControl" runat="server" ContoCorrenteVisibile="True"
                                        ClassificazioneUmaVisibile="false"  />
        </div>
    </div>
</asp:Content>
