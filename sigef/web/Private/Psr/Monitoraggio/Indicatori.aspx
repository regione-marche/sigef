<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    CodeBehind="Indicatori.aspx.cs" Inherits="web.Private.Psr.Monitoraggio.Indicatori" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <script type="text/javascript">
       function selezionaIntervento(id) 
       {
            $('[id$=hdnIdIntervento]').val($('[id$=hdnIdIntervento]').val() == id ? '' : id);
            //$('[id$=hdnIdIntervento]').val(id);
            $('[id$=btnInterventoPost]').click(); 
        }
    </script>

    <div style="display: none">
        <asp:HiddenField ID="hdnIdAzione" runat="server" />
        <asp:HiddenField ID="hdnIdIntervento" runat="server" />
        <asp:Button ID="btnAzionePost" runat="server" OnClick="btnAzionePost_Click"
            CausesValidation="false" />
        <asp:Button ID="btnInterventoPost" runat="server" OnClick="btnInterventoPost_Click"
            CausesValidation="false" />
    </div>

    <table class="tableNoTab" width="950px">
        <tr>
            <td class="separatore_light" style="height: 33px">INDICATORI DI OUTPUT PER TIPOLOGIA INTERVENTO
            </td>
        </tr>
        <tr>
            <td class="testo_pagina">Gestione degli Indicatori di Output collegati alla Tipologia Intervento.<br />
                Per ogni Tipologia Intervento selezionare gli Indicatori collegati ad esso, quindi salvare.<br />
            </td>
        </tr>
        <tr>
            <td style="padding: 10px">Selezionare il Por di riferimento:
                <br />
                <Siar:ComboZPsr ID="lstPsr" runat="server" AutoPostBack="true">
                </Siar:ComboZPsr>
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%" cellpadding="0" cellspacing="0" id="tbAzioni" runat="server"
                    visible="false">
                    <tr>
                        <td style="padding: 10px">Selezionare l'Azione:
                            <br />
                            <Siar:ComboZProgrammazione ID="lstAzione" runat="server" AutoPostBack="True"
                                Width="700px">
                            </Siar:ComboZProgrammazione>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table width="100%" cellpadding="0" cellspacing="0" id="tbInterventi" runat="server"
                                visible="false">
                                <tr>
                                    <td>
                                        <Siar:DataGrid ID="dgInterventi" runat="server" Width="100%" AutoGenerateColumns="False">
                                            <ItemStyle Height="30px" />
                                            <Columns>
                                                <asp:BoundColumn DataField="Codice" HeaderText="Codice">
                                                    <ItemStyle HorizontalAlign="Center" Width="110px" Font-Bold="True" Font-Size="14px" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="Tipo" HeaderText="Livello">
                                                    <ItemStyle HorizontalAlign="Center" Width="180px" />
                                                </asp:BoundColumn>
                                                <Siar:ColonnaLink DataField="Descrizione" HeaderText="Descrizione" IsJavascript="true"
                                                    LinkFields="Id" LinkFormat="selezionaIntervento({0});">
                                                </Siar:ColonnaLink>
                                                <Siar:CheckColumn DataField="Id" Name="chkIdIntervento" HeaderSelectAll="true">
                                                    <ItemStyle Width="50px" />
                                                </Siar:CheckColumn>
                                            </Columns>
                                        </Siar:DataGrid>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table id="tbIndicatori" runat="server" width="100%" visible="false" cellpadding="0"
                    cellspacing="0">
                    <tr>
                        <td style="width: 550px; padding-right: 3px; vertical-align: top; border-right: solid 1px black">
                            <table width="100%">
                                <tr>
                                    <td class="separatore_light">Elenco Indicatori di Output:
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                        <Siar:DataGrid ID="dgIndicatori" runat="server" AutoGenerateColumns="False" Width="100%">
                                            <ItemStyle Height="24px" />
                                            <Columns>
                                                <Siar:NumberColumn>
                                                    <ItemStyle Width="30px" HorizontalAlign="Center" />
                                                </Siar:NumberColumn>

                                                <asp:BoundColumn DataField="CodDimensione" HeaderText="Codice">
                                                    <ItemStyle Width="50px" HorizontalAlign="Left" />
                                                </asp:BoundColumn>

                                                <asp:BoundColumn DataField="CodDim" HeaderText="Cod_DIM">
                                                    <ItemStyle Width="50px" HorizontalAlign="Left" />
                                                </asp:BoundColumn>

                                                <asp:BoundColumn DataField="DesDimensione" HeaderText="Descrizione">
                                                    <ItemStyle Width="150px" HorizontalAlign="Left" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="Um" HeaderText="UM">
                                                    <ItemStyle Width="40px" HorizontalAlign="Left" />
                                                </asp:BoundColumn>

                                                <Siar:CheckColumn DataField="IdDimensione" HeaderSelectAll="true" Name="chkIdIndicatore" HeaderText="Seleziona">
                                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                </Siar:CheckColumn>

                                            </Columns>
                                        </Siar:DataGrid>
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="height: 60px; padding-right: 50px">
                                        <Siar:Button ID="btnSalva" runat="server" Width="158px" Text="Salva" OnClick="btnSalva_Click"
                                            Modifica="true" />
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
