<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    CodeBehind="ProgrammazioneSanzioni.aspx.cs" Inherits="web.Private.Psr.Programmazione.ProgrammazioneSanzioni" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <script type="text/javascript">
        function selezionaProgrammazione(id) 
        {
            $('[id$=hdnIdProgrammazione]').val($('[id$=hdnIdProgrammazione]').val() == id ? '' : id);
            $('[id$=btnProgrammazionePost]').click(); 
        }
        function selezionaSanzione(id) 
        {
            $('[id$=hdnIdSanzione]').val(id);
            $('[id$=btnProgrammazionePost]').click(); 
        }
        function nuovaSanzione() 
        {
            $('[id$=hdnIdSanzione]').val('');
            $('[id$=txtCod_Sanzione]').val('');
            $('[id$=txtAttiva]').val('');
            $('[id$=btnElimina]')[0].disabled = 'disabled'; 
        }
    </script>

    <div style="display: none">
        <asp:HiddenField ID="hdnIdProgrammazione" runat="server" />
        <asp:HiddenField ID="hdnIdSanzione" runat="server" />
        <asp:Button ID="btnProgrammazionePost" runat="server" OnClick="btnProgrammazionePost_Click"
            CausesValidation="false" />
    </div>
    <table width="950px" class="tableNoTab">
        <tr>
            <td class="separatore_big">
                PROGRAMMAZIONE SANZIONI
            </td>
        </tr>
        <tr>
            <td class="testo_pagina">
                Gestione delle Sanzioni collegate alle Azioni della Programmazione.<br />
                Selezionando un programma si avrà l'elenco delle "Azioni" a cui è collegato; selezionando una "Azione" si avrà a disposizione l'elenco delle "Sanzioni" ad essa collegabili. Per attivare una "Sanzione" compilare il campo "Ordine", marcare il campo di spunta ed infine cliccare "Salva Sanzioni"<br />
            </td>
        </tr>
        <tr>
            <td>
                <b>Selezionare il programma desiderato:</b><br />
                <Siar:ComboZPsr ID="lstPsr" runat="server" AutoPostBack="true">
                </Siar:ComboZPsr>
            </td>
        </tr>
        <tr>
            <td>
                <br />
                <Siar:DataGrid ID="dgProgrammazione" runat="server" AutoGenerateColumns="False" Width="100%">
                    <ItemStyle Height="24px" />
                    <Columns>
                        <Siar:NumberColumn>
                            <ItemStyle Width="30px" HorizontalAlign="Center" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="Codice" HeaderText="Codice">
                            <ItemStyle Width="100px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Tipo" HeaderText="Livello">
                            <ItemStyle Width="130px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <Siar:ColonnaLink DataField="Descrizione" HeaderText="Descrizione" IsJavascript="true"
                            LinkFields="Id" LinkFormat="selezionaProgrammazione({0});">
                        </Siar:ColonnaLink>
                        <Siar:CheckColumn DataField="Id" Name="chkProgrammazioneSelect" OnCheckClick="return false;">
                            <ItemStyle Width="60px" HorizontalAlign="Center" />
                        </Siar:CheckColumn>
                    </Columns>
                </Siar:DataGrid>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <table id="tbSanzioni" runat="server" width="100%" visible="false" cellpadding="0"
                    cellspacing="0">
                    <tr>
                        <td style="width: 100%; padding-right: 3px; vertical-align: top; border-right: solid 1px black">
                            <table width="100%">
                                <tr>
                                    <td class="separatore_light">
                                        Elenco Sanzioni associate:
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                        <Siar:DataGrid ID="dgSanzioni" runat="server" AutoGenerateColumns="False" Width="100%">
                                            <ItemStyle Height="24px" />
                                            <Columns>
                                                <Siar:NumberColumn>
                                                    <ItemStyle Width="30px" HorizontalAlign="Center" />
                                                </Siar:NumberColumn>
                                                <asp:BoundColumn DataField="CodSanzione" HeaderText="Cod. Sanzione">
                                                    <ItemStyle Width="75px" HorizontalAlign="Center" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="SanzioneTitolo" HeaderText="Titolo Sanzione">
                                                    <ItemStyle Width="200px" HorizontalAlign="Left" />
                                                </asp:BoundColumn>
                                                <Siar:IntegerColumn DataField="CodSanzione" Valore="Ordine" Name="dgTxtOrdine" NoCurrency="true" HeaderText="Ordine" >
                                                    <ItemStyle HorizontalAlign="Right" Width="50px" />
                                                </Siar:IntegerColumn>
                                                <asp:BoundColumn DataField="DataInizio" HeaderText="Data Inizio">
                                                    <ItemStyle Width="60px" HorizontalAlign="Center" />
                                                </asp:BoundColumn>
                                                <Siar:CheckColumn DataField="CodSanzione" HeaderSelectAll="true" Name="chkSanzioneAttiva">
                                                    <ItemStyle Width="60px" HorizontalAlign="Center" />
                                                </Siar:CheckColumn> 
                                            </Columns>
                                        </Siar:DataGrid>
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 60px; padding-right: 50px" align="right">
                                        <Siar:Button ID="btnSanzioniSalva" runat="server" OnClick="btnSanzioniSalva_Click"
                                                   Text="Salva Sanzioni" Width="175px" Modifica="True" />
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
