<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    CodeBehind="IndicatoriRisultato.aspx.cs" Inherits="web.Private.Psr.Programmazione.IndicatoriRisultato" %>
   
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">
<%--
    <script type="text/javascript">
        function selezionaDimensione(id) 
        {
            $('[id$=hdnIdDimensione]').val(id);
            $('[id$=btnSelezionaDimensione]').click();
        }
    </script>
--%>
    <div style="display: none">       

    </div>
    <table width="950px" class="tableNoTab">
        <tr>
            <td class="separatore_big">
                INDICATORI DI RISULTATO
            </td>
        </tr>
        <tr>
            <td class="testo_pagina">
                Compilazione Indicatori di Risultato.<br />
                Selezionare il POR e l'anno da compilare e quindi inserire il Valore Realizzato.<br />
            </td>
        </tr>
    </table>

    <table class="tableTab" id="tbElenco" runat="server" width="950px">
        <tr>
            <td>
                <b>Selezionare POR</b><br />
                <Siar:ComboZPsr ID="cmbPsr" runat="server" AutoPostBack="true"></Siar:ComboZPsr>
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
                <br />
                <Siar:DataGrid ID="dgDimensioni" runat="server" AutoGenerateColumns="false" Width="100%">
                    <Columns>
                        <%-- <Siar:NumberColumn></Siar:NumberColumn> --%>
                        <asp:BoundColumn DataField="CodiceObmisura" HeaderText="OS" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle Width="50px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="DimensioneCodice" HeaderText="Codice IR" HeaderStyle-HorizontalAlign="Center"></asp:BoundColumn>
                        <asp:BoundColumn DataField="DimensioneDescrizione" HeaderText="Descrizione IR" HeaderStyle-HorizontalAlign="Center"></asp:BoundColumn>
                        <asp:BoundColumn DataField="UM" HeaderText="U.M." HeaderStyle-HorizontalAlign="Center"></asp:BoundColumn>
                        <asp:BoundColumn DataField="ValoreBase" HeaderText="Valore Base" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ValoreObbiettivo" HeaderText="Valore Obiettivo" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundColumn>
                        <Siar:ImportoColumn DataField="IdDimensione" Importo="ValoreRealizzato" HeaderText="Valore Realizzato" Name="ValoreRealizzato"></Siar:ImportoColumn>
                    </Columns>
                </Siar:DataGrid>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="right">
                <Siar:Button ID="btnSalva" runat="server" Text="Salva" Enabled="false" OnClick="btnSalvaDimensione" Modifica="true" />
            </td>
        </tr>
    </table>
    
</asp:Content>
