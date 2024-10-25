<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    CodeBehind="CalcoloIndicatori.aspx.cs" Inherits="web.Private.Psr.Monitoraggio.CalcoloIndicatori" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <script type="text/javascript">
        function selezionaDimensione(id) 
        {
            $('[id$=hdnIdDimensione]').val(id);
            $('[id$=btnSelezionaDimensione]').click();
        }
    </script>

     <table width="950px" class="tableNoTab">
        <tr>
            <td class="separatore_big">
                CALCOLO INDICATORI DI OUTPUT COMUNI E SPECIFICI
            </td>
        </tr>
        <tr>
            <td class="testo_pagina">
                Confronto tra Valore Programmato previsto dal Fondo e Valore Realizzato Ammesso, sui Progetti Finanziabili.<br />
                Per ogni anno è possibile eseguire il calcolo; al successivo accesso verranno visualizzati i dati calcolati 
                precedentemente e sarà possibile effettuarne il Ricalcolo, finchè non vengono Bloccati, rendendoli ufficiali.
            </td>
        </tr>
        <tr>
            <td>
                <b>Selezionare POR</b><br />
                <Siar:ComboZPsr ID="cmbPsr" runat="server" AutoPostBack="true"></Siar:ComboZPsr>
                <div style="float: right; margin-right: 100px;">
                    <Siar:Button ID="btnDownloadRptIN01" runat="server" Visible="false" Width="150px" Text="Download dettaglio xls" /></div>
            </td>
        </tr>
        <tr>
            <td>
                <b>Selezionare Anno</b><br />
                <Siar:ComboAnno ID="cmbAnno" runat="server" AutoPostBack="true" Width="70px"></Siar:ComboAnno> 
            </td>
        </tr>

        <tr>
            <td>
                <table id="tbCalcIndic" runat="server" width="100%" visible="false" cellpadding="0"
                    cellspacing="0">
                    <tr>
                        <td style="width: 550px; padding-right: 3px; vertical-align: top; border-right: solid 1px black">
                            <table width="100%">
                                <tr>
                                    <td>
                                        <br />
                                        <Siar:DataGrid ID="dgCalcIndic" runat="server" AutoGenerateColumns="False" Width="100%">
                                            <ItemStyle Height="24px" />
                                            <Columns>
                                               <%-- <Siar:NumberColumn>
                                                    <ItemStyle Width="30px" HorizontalAlign="Center" />
                                                </Siar:NumberColumn> --%> 
                                               <asp:BoundColumn DataField="CodPriorita" HeaderText="Priorità">
                                                    <ItemStyle Width="30px" HorizontalAlign="Center" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="CodIndicatore" HeaderText="Indicatore">
                                                    <ItemStyle Width="30px" HorizontalAlign="Center" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="DesIndicatore" HeaderText="Indicatore di Output">
                                                    <ItemStyle Width="300px" HorizontalAlign="Left" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="UM" HeaderText="Unità di misura">
                                                    <ItemStyle Width="30px" HorizontalAlign="Left" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="ValoreF" HeaderText="Valore Programmato" DataFormatString="{0:N2}">
                                                    <ItemStyle Width="30px"  HorizontalAlign="Right" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="ValorePF" HeaderText="Valore al 2018" DataFormatString="{0:N2}">
                                                    <ItemStyle Width="30px"  HorizontalAlign="Right" />
                                                </asp:BoundColumn>
                                                 <asp:BoundColumn DataField="ValoreRTot" HeaderText="Valore Realizzato" DataFormatString="{0:N2}">
                                                    <ItemStyle Width="30px" HorizontalAlign="Right" />
                                                </asp:BoundColumn>
                                            </Columns>
                                        </Siar:DataGrid>
                                        <br />
                                    </td>
                               </tr>
                               <tr>
                                    <td align="right">
                                        <Siar:Button ID="btnRicalcola" runat="server" Text="Ricalcola" Enabled="false" OnClick="btnRicalcola_Click" Modifica="true" />
                                       <%-- <Siar:Button ID="btnSalva" runat="server" Text="Salva" Enabled="false" OnClick="btnSalva_Click" Modifica="true" />--%>
                                        <Siar:Button Conferma="Attenzione! I dati verranno resi non più modificabili. Continuare?" ID="btnBlocca" runat="server" Text="Blocca" Enabled="false" OnClick="btnBlocca_Click" Modifica="true" />
                                    </td>
                               </tr>
                           </table>
                        </td>
                     </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
