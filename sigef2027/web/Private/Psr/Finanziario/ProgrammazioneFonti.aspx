<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    CodeBehind="ProgrammazioneFonti.aspx.cs" Inherits="web.Private.Psr.Programmazione.ProgrammazioneFonti" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <script type="text/javascript">
        function selezionaProgrammazione(id) {
            $('[id$=hdnIdProgrammazione]').val($('[id$=hdnIdProgrammazione]').val() == id ? '' : id);
            $('[id$=btnProgrammazionePost]').click();
        }

    </script>

    <div style="display: none">
        <asp:HiddenField ID="hdnIdProgrammazione" runat="server" />
        <asp:HiddenField ID="hdnIdFonte" runat="server" />
        <asp:Button ID="btnProgrammazionePost" runat="server" OnClick="btnProgrammazionePost_Click"
            CausesValidation="false" />
    </div>

    <div class="row bd-form py-5 mx-2">

        <h2 class="pb-5">Fonti finanziarie per elemento di programmazione</h2>
        <p>
            Gestione delle Fonti Finanziarie collegate agli Assi della Programmazione.            
        </p>
        <p>
            Selezionando un Asse si avrà a disposizione l'elenco delle Fonti Finanziarie con la percentuale di default presente in anagrafica. 
        </p>
        <p>
            E' possibile modificare tali percentuali. 
        </p>
        <p>
            Per salvare, marcare il campo di spunta e cliccare "Salva".
        </p>


        <div class="form-group col-sm-12 pt-5">
            <Siar:ComboZPsr ID="lstPsr" Label="Selezionare il programma desiderato" runat="server" AutoPostBack="true"></Siar:ComboZPsr>
        </div>
        <div class="col-sm-12 form-group">
            <Siar:DataGridAgid CssClass="table table-striped" ID="dgProgrammazione" runat="server" AutoGenerateColumns="False" AllowPaging="true" PageSize="10">
                <ItemStyle Height="24px" />
                <Columns>
                    <Siar:NumberColumnAgid>
                        <ItemStyle Width="30px" HorizontalAlign="Center" />
                    </Siar:NumberColumnAgid>
                    <asp:BoundColumn DataField="Codice" HeaderText="Codice">
                        <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Tipo" HeaderText="Livello">
                        <ItemStyle Width="130px" HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <Siar:ColonnaLinkAgid DataField="Descrizione" HeaderText="Descrizione" IsJavascript="true"
                        LinkFields="Id" LinkFormat="selezionaProgrammazione({0});">
                    </Siar:ColonnaLinkAgid>
                    <Siar:CheckColumnAgid DataField="Id" Name="chkProgrammazioneSelect" OnCheckClick="return false;">
                        <ItemStyle Width="60px" HorizontalAlign="Center" />
                    </Siar:CheckColumnAgid>
                </Columns>
            </Siar:DataGridAgid>
        </div>
        <div id="tbFonti" runat="server" visible="false">
            <h4 class="pb-5">Elenco fonti associate:</h4>
            <Siar:DataGridAgid ID="dgFonti" CssClass="table table-striped" runat="server" AutoGenerateColumns="False" AllowPaging="true" PageSize="10">
                <ItemStyle Height="24px" />
                <Columns>
                    <Siar:NumberColumnAgid>
                        <ItemStyle Width="30px" HorizontalAlign="Center" />
                    </Siar:NumberColumnAgid>
                    <asp:BoundColumn DataField="Descrizione" HeaderText="Fonte">
                        <ItemStyle Width="150px" HorizontalAlign="Left" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="PercentualeFonte" HeaderText="%Fonte" DataFormatString="{0:N2}">
                        <ItemStyle Width="150px" HorizontalAlign="Right" />
                    </asp:BoundColumn>

                    <Siar:PercentualeColumnAgid DataField="IdFonte" HeaderText="%Fonte su Asse" Name="dgtxtPercentuale"
                        Quota="Percentuale" DataFormatString="{0:N2}">
                        <ItemStyle HorizontalAlign="center" Width="100px" />
                    </Siar:PercentualeColumnAgid>

                    <asp:BoundColumn DataField="DataInizio" HeaderText="Data inizio">
                        <ItemStyle Width="150px" HorizontalAlign="Left" />
                    </asp:BoundColumn>
                    <Siar:CheckColumnAgid DataField="IdFonte" HeaderSelectAll="true" Name="chkIdFonte" HeaderText="Attiva/Disattiva">
                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                    </Siar:CheckColumnAgid>
                </Columns>
            </Siar:DataGridAgid>
        </div>
        <div class="col-sm-12 pb-5 pe-5 text-lg-start">
            <Siar:Button ID="btnFonteSalva" runat="server" Modifica="True" OnClick="btnFonteSalva_Click" Text="Salva" />
        </div>
    </div>


    <%-- <table width="950px" class="tableNoTab">
         <tr>
            <td class="separatore_big">
                FONTI finanziarie per elemento di programmazione</td>
        </tr>
            <p>
                Gestione delle Fonti Finanziarie collegate agli Assi della Programmazione.<br />
                Selezionando un Asse si avrà a disposizione l'elenco delle Fonti Finanziarie con la percentuale di default presente in anagrafica. E' possibile modificare tali percentuali. Per salvare, marcare il campo di spunta e cliccare "Salva".<br />
            </p>
 
        <tr>
            <td>
                <b>
                <br />
                Selezionare il programma desiderato:</b><br />
                <Siar:ComboZPsr ID="lstPsr" runat="server" AutoPostBack="true">
                </Siar:ComboZPsr>
            </td>
        </tr>--%>
    <%-- <tr>
            <td>
                <br />
               
                &nbsp;
            </td>
        </tr>



        <tr>
            <td>
                <table id="tbFonti" runat="server" width="100%" visible="false" cellpadding="0"
                    cellspacing="0">
                    <tr>
                        <td style="width: 550px; padding-right: 3px; vertical-align: top; border-right: solid 1px black">
                            <table width="100%">
                                <tr>
                                    <td class="separatore_light">
                                        Elenco fonti associate:
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                        <Siar:DataGrid ID="dgFonti" runat="server" AutoGenerateColumns="False" Width="100%">
                                            <ItemStyle Height="24px" />
                                            <Columns>
                                                <Siar:NumberColumn>
                                                    <ItemStyle Width="30px" HorizontalAlign="Center" />
                                                </Siar:NumberColumn>


                                                <asp:BoundColumn DataField="Descrizione" HeaderText="Fonte">
                                                    <ItemStyle Width="150px" HorizontalAlign="Left" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="PercentualeFonte" HeaderText="%Fonte" DataFormatString="{0:N2}">
                                                    <ItemStyle Width="150px" HorizontalAlign="Right" />
                                                </asp:BoundColumn>

                                                <Siar:PercentualeColumn DataField="IdFonte" HeaderText="%Fonte su Asse" Name="dgtxtPercentuale"
                                                     Quota="Percentuale" DataFormatString="{0:N2}">
                                                    <ItemStyle HorizontalAlign="center" Width="100px" />
                                                </Siar:PercentualeColumn>

                                                <asp:BoundColumn DataField="DataInizio" HeaderText="Data inizio" >
                                                    <ItemStyle Width="150px" HorizontalAlign="Left" />
                                                </asp:BoundColumn>
                                                <Siar:CheckColumn DataField="IdFonte" HeaderSelectAll="true" Name="chkIdFonte" HeaderText="Attiva/Disattiva">
                                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                </Siar:CheckColumn>

                                            </Columns>
                                        </Siar:DataGrid>
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="height: 38px">
                                        &nbsp;
                                        <Siar:Button ID="btnFonteSalva" runat="server" Modifica="True" OnClick="btnFonteSalva_Click"
                                            Text="Salva" Width="100px" />
                                    </td>
                                </tr>                           
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>--%>
</asp:Content>
