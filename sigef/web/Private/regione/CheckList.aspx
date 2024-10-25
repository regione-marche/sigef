<%@ Page Language="c#" MasterPageFile="~/SiarPage.master" Inherits="web.Private.regione.CheckList"
    CodeBehind="CheckList.aspx.cs" %>

<%@ Register Src="../../CONTROLS/SiarNewTab.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
        function selezionaChecklist(id) { $('[id$=hdnIdChecklist]').val(id); $('[id$=btnPost]').click(); }
        function selezionaTutti(elem, nome_check) {
            var chkValue = $(elem)[0].checked; $.each($('[id=' + nome_check + ']'), function() { this.checked = chkValue; });
        }
        function estraiChecklistXLS() { 
            if ($('[id$=hdnIdChecklist]').val() == "") {
                alert('Per l estrazione in XLS è necessario aver selezionato una checklist.');
            }
            else SNCVisualizzaReport('rptChecklistXStep', 2, 'IdChecklist=' + $('[id$=hdnIdChecklist]').val());
        }

        function Copia(IdStep)//,CodFase,desc,automatico,query,query_post,code,url,valMin,valMax)
        {
            const el = document.createElement('textarea');
            el.value = IdStep;
            el.setAttribute('readonly', '');
            el.style.position = 'absolute';
            el.style.left = '-9999px';
            document.body.appendChild(el);
            el.select();
            document.execCommand('copy');
            document.body.removeChild(el);
        }

//--></script>

    <uc1:SiarNewTab ID="ucSiarNewTab" runat="server" TabNames="Elenco checkList|Nuova/Modifica"
        Width="900px" />
    <div style="display: none">
        <asp:HiddenField ID="hdnIdChecklist" runat="server" />
        <asp:Button ID="btnPost" runat="server" OnClick="btnPost_Click" />
    </div>
    <table id="tbElenco" runat="server" class="tableTab" width="900px">
        <tr>
            <td align="right">
                <div style="width: 429px; height: 54px; border-bottom: #142952 1px solid; border-left: #142952 1px solid;
                    text-align: left; padding-left: 30px;">
                    &nbsp;&nbsp;<strong>Descrizione :</strong>&nbsp;<br />
                    <Siar:TextBox runat="server" ID="txtDescrizioneRicerca" Width="283px" />
                    &nbsp; &nbsp; &nbsp;<Siar:Button ID="btnFiltro" Width="100px" runat="server" Text="Applica Filtro"
                        CausesValidation="false" OnClick="btnFiltro_Click" />
                </div>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dg" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="True"
                    PageSize="20">
                    <ItemStyle Height="24px" />
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle Width="30px" HorizontalAlign="Center" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="IdCheckList" HeaderText="ID CkL">
                            <ItemStyle Width="40px" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <Siar:ColonnaLink DataField="Descrizione" HeaderText="Descrizione" LinkFields="IdCheckList"
                            LinkFormat="javascript:selezionaChecklist({0});">
                        </Siar:ColonnaLink>
                        <asp:BoundColumn HeaderText="Template">
                            <ItemStyle Width="80px" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Data ultima modifica" DataField="DataModifica">
                            <ItemStyle Width="120px" HorizontalAlign="center" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
    </table>
    <table id="tbModifica" runat="server" class="tableTab" width="1300px">
        <tr>
            <td style="padding: 15px">
                <table width="100%">
                    <tr>
                        <td style="width: 471px">
                            <b>
                                <br />
                                Descrizione: </b>
                            <br />
                            <Siar:TextArea ID="txtDescrizione" runat="server" Width="430px" Obbligatorio="True"
                                NomeCampo="Descrizione"></Siar:TextArea>
                        </td>
                        <td>
                            <br />
                            &nbsp;<b>Salva come modello&nbsp;</b>
                            <asp:CheckBox ID="chkTemplate" runat="server" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right: 30px; padding-left: 15px; height: 54px;">
                <table style="width: 100%;">
                    <tr>
                        <td id="tdAvvisoModifica" runat="server" style="width: 357px" class="testoRosso"
                            align="left">
                            &nbsp;
                        </td>
                        <td>
                            <Siar:Button ID="btnSalva" runat="server" Width="136px" Text="Salva" OnClick="btnSalva_Click"
                                Modifica="true" Conferma="" />
                            &nbsp;&nbsp;&nbsp;
                               <input id="btnEstraiInXls" class="Button" style="width: 100px" type="button" value="Estrai in XLS" onclick="estraiChecklistXLS();" />
                                &nbsp;&nbsp;&nbsp;
                            <Siar:Button ID="btnElimina" runat="server" Width="136px" Text="Elimina" OnClick="btnElimina_Click"
                                Modifica="true" Conferma="Attenzione! Eliminare la checklist selezionata?" CausesValidation="False" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <Siar:Button ID="btnNuova" runat="server" Width="120px" Text="Nuova" OnClick="btnNuova_Click"
                                Modifica="False" Conferma="" CausesValidation="False" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table id="tbStep" runat="server" width="100%">
                    <tr>
                        <td class="separatore_light">
                            Elenco step operativi associati:
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table width="100%">
                                <tr>
                                    <td style="width: 550px">
                                        <b>
                                            <br />
                                            Carica da modello: </b>
                                        <br />
                                        <Siar:ComboCheckList ID="lstModelloChecklist" runat="server" Width="470px">
                                        </Siar:ComboCheckList>
                                        &nbsp;<Siar:Button ID="btnCaricaModello" Width="57px" runat="server" Text="Carica"
                                            CausesValidation="false" OnClick="btnCaricaModello_Click" />
                                    </td>
                                    <td style="width: 250px">
                                        <b>
                                            <br />
                                            Seleziona la fase procedurale:<br />
                                            <Siar:ComboFasiProcedurali ID="lstFaseProgetto" runat="server" Obbligatorio="true"
                                                NomeCampo="Fase procedurale">
                                            </Siar:ComboFasiProcedurali>
                                            &nbsp;<Siar:Button ID="btnCaricaFaseProcedurale" Width="60px" runat="server" Text="Carica"
                                                CausesValidation="false" OnClick="btnCaricaFaseProcedurale_Click" />
                                        </b>
                                    </td>
                                    <td style="width: 250px">
                                    <br />
                                        &nbsp;<b>&nbsp;&nbsp;Descrizione:</b><br />
                                        &nbsp;
                                        <Siar:TextBox runat="server" ID="txtFiltroDescrizione" Width="230px" />&nbsp;
                                    </td>
                                    <td style="width: 199px">
                                        <br />
                                        &nbsp;<b>&nbsp;&nbsp;Misura:</b><br />
                                        &nbsp;
                                        <Siar:TextBox runat="server" ID="txtFiltroMisura" Width="119px" />
                                        &nbsp;
                                        <Siar:Button ID="btnFiltroMisura" Width="60px" runat="server" Text="Filtra" CausesValidation="false"
                                            OnClick="btnPost_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="border-top-style: solid; border-top-width: 1px; border-top-color: #000000">
                            &nbsp;
                            <br />
                            <Siar:DataGrid ID="dgStep" runat="server" Width="100%" AutoGenerateColumns="False"
                                PageSize="30" AllowPaging="true">
                                <Columns>
                                    <Siar:NumberColumn HeaderText="Nr.">
                                        <ItemStyle Width="35px" HorizontalAlign="center" />
                                    </Siar:NumberColumn>
                                    <%--<asp:BoundColumn DataField="IdStep" HeaderText="ID Step">
                                        <ItemStyle Width="40px" HorizontalAlign="Center" />
                                    </asp:BoundColumn>--%>
                                    <asp:BoundColumn DataField="IdStep" HeaderText="ID Step">
                                        <ItemStyle Width="40px" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Descrizione" DataField="Step"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="FaseProcedurale" HeaderText="Fase Procedurale">
                                        <ItemStyle Width="130px" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Misura" HeaderText="Misura">
                                        <ItemStyle HorizontalAlign="Center" Width="60px" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Automatico" HeaderText="Automatico" DataFormatString="{0:SI|NO}">
                                        <ItemStyle Width="80px" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <Siar:CheckColumn DataField="IdStep" Name="chkObb" HeaderText="Obbligatorio">
                                        <ItemStyle Width="80px" />
                                    </Siar:CheckColumn>
                                    <Siar:CheckColumn DataField="IdStep" Name="chkVisita" HeaderText="Selez. per verbale visita">
                                        <ItemStyle Width="80px" />
                                    </Siar:CheckColumn>
                                    <Siar:IntegerColumn DataField="IdStep" HeaderText="Ordine" Valore="Ordine" Name="Ordine">
                                        <ItemStyle Width="50" HorizontalAlign="center" />
                                    </Siar:IntegerColumn>
                                    <Siar:CheckColumn DataField="IdStep" Name="chkInclusione" HeaderText="Includi">
                                        <ItemStyle Width="80px" />
                                    </Siar:CheckColumn>
                                </Columns>
                            </Siar:DataGrid>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
