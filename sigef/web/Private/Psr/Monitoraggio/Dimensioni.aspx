<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    CodeBehind="Dimensioni.aspx.cs" Inherits="web.Private.Psr.Programmazione.Dimensioni" %>
   
<%@ Register Src="../../../CONTROLS/SiarNewTab.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <script type="text/javascript">
        function selezionaDimensione(id) 
        {
            //$('[id$=hdnIdDimensione]').val($('[id$=hdnIdDimensione]').val() == id ? '' : id);
            //$('[id$=btnProgrammazionePost]').click();
            $('[id$=hdnIdDimensione]').val(id);
            $('[id$=btnSelezionaDimensione]').click();
        }
    </script>

    <div style="display: none">       
        <asp:HiddenField ID="hdnIdDimensione" runat="server" />
        <asp:Button ID="btnProgrammazionePost" runat="server" OnClick="btnProgrammazionePost_Click" CausesValidation="false" />
        <asp:Button ID="btnSelezionaDimensione" runat="server" OnClick="btnSelezionaDimensione_Click" CausesValidation="false" />
    </div>
    <table width="950px" class="tableNoTab">
        <tr>
            <td class="separatore_big">
                ANAGRAFICA DIMENSIONI
            </td>
        </tr>
        <tr>
            <td class="testo_pagina">
                Gestione delle dimensioni.<br />
                Selezionare il "Tipo Dimensione" e quindi inserire o editare le dimensioni.<br />
            </td>
        </tr>
    </table>
    <uc1:SiarNewTab ID="ucSiarNewTab" runat="server" TabNames="Elenco Dimensioni|Dettaglio\Nuovo" Width="950px" />

    <table class="tableTab" id="tbElenco" runat="server" width="950px">
        <tr>
            <td>
                <b>Selezionare il Tipo Dimensione</b><br />
                <Siar:ComboZTipoDimensioni ID="cmbTipo" runat="server" AutoPostBack="true"></Siar:ComboZTipoDimensioni>
            </td>
        </tr>
        <tr>
            <td>
                <br />
                <Siar:DataGrid ID="dgDimensioni" runat="server" AutoGenerateColumns="false" Width="100%">
                    <ItemStyle Height="24px" />
                    <Columns>
                        <Siar:NumberColumn>
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="DesDim" HeaderText="Tipo Dimensione" HeaderStyle-HorizontalAlign="Center"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Codice" HeaderText="Codice" HeaderStyle-HorizontalAlign="Center"></asp:BoundColumn>
                        <Siar:ColonnaLink DataField="Descrizione" HeaderText="Descrizione" HeaderStyle-HorizontalAlign="Center"
                            IsJavascript="true" LinkFields="Id" LinkFormat="selezionaDimensione({0});">
                        </Siar:ColonnaLink>
                        <asp:BoundColumn DataField="Metodo" HeaderText="Metodo" HeaderStyle-HorizontalAlign="Center"></asp:BoundColumn>
                        <asp:BoundColumn DataField="ValoreBase" HeaderText="Valore Base" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Valore" HeaderText="Valore Obiettivo" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="UM" HeaderText="U.M." HeaderStyle-HorizontalAlign="Center"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Richiedibile" HeaderText="Rich." HeaderStyle-HorizontalAlign="Center"></asp:BoundColumn>
                        <asp:BoundColumn DataField="ProceduraCalcolo" HeaderText="Calcolo" HeaderStyle-HorizontalAlign="Center"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Ordine" HeaderText="Ordine" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
                &nbsp;
            </td>
        </tr>
    </table>

    <table id="tbDettaglio" class="tableTab" runat="server" width="950px">
        <tr>
            <td style="width:150px">
                Tipo Dimensione
            </td>
            <td>
                <Siar:ComboZTipoDimensioni ID="cmbTipoDettaglio" runat="server" width="400px"></Siar:ComboZTipoDimensioni>
            </td>
        </tr>
        <tr>
            <td>
                Codice
            </td>
            <td>
                <asp:TextBox ID="txtCodice" runat="server" width="400px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Descrizione
            </td>
            <td>
                <asp:TextBox ID="txtDescrizione" runat="server" Rows="4" TextMode="MultiLine" width="400px"></asp:TextBox>               
            </td>
        </tr>
        <tr>
            <td>
                Unità di misura
            </td>
            <td>
                <asp:TextBox ID="txtUM" runat="server" width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Valore Base
            </td>
            <td>
                <Siar:DecimalBox ID="txtValoreBase" runat="server" width="200px"/>
            </td>
        </tr>
        <tr>
            <td>
                Valore Obiettivo
            </td>
            <td>
                <Siar:DecimalBox ID="txtValore" runat="server" width="200px"/>
            </td>
        </tr>
        <tr>
            <td>
                Richiedibile
            </td>
            <td>
                <asp:TextBox ID="txtRichiedibile" runat="server" width="50px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Procedura Calcolo
            </td>
            <td>
                <asp:TextBox ID="txtProCalcolo" runat="server" width="400px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Metodo
            </td>
            <td>
                <asp:TextBox ID="txtMetodo" runat="server" Rows="4" TextMode="MultiLine" width="400px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Ordine
            </td>
            <td>
                <asp:TextBox ID="txtOrdine" runat="server" width="50px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnSalva" runat="server" Text="Salva" OnClick="btnSalvaDimensione" />
                <asp:Button ID="btnCancella" runat="server" Text="Cancella" OnClick="btnCancellaDimensione" />
                <asp:Button ID="btnNuova" runat="server" Text="Nuova" OnClick="btnNuovaDimensione" />
            </td>
        </tr>
    </table>
    
</asp:Content>
