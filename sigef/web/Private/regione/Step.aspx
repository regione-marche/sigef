<%@ Page Language="c#" MasterPageFile="~/SiarPage.master" Inherits="web.Private.regione.Step"
    CodeBehind="Step.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript">
		<!--

        function nuovo() {
            $('[id$=txtMisura_text]').val(''); $('[id$=txtDescrizione_text]').val(''); $('[id$=txtUrl_text]').val('');
            $('[id$=txtIdStepSel_text]').val('');            
            $('[id$=txtValoreMinimo_text]').val('');$('[id$=txtValoreMassimo_text]').val('');$('[id$=txtCode_text]').val('');
            $('[id$=txtQueryLungaSQL_text]').val('');$('[id$=txtQueryPost_text]').val('');
            $('[id$=hdnEdit]').val('');$('[id$=lstFase]').val('');$('[id$=chkAutomatico').removeAttr('checked');
            $('[id$=btnSalva]').removeAttr("disabled");$('[id$=btnElimina]').attr("disabled","disabled");
        }

        function modifica(IdStep)//,CodFase,desc,automatico,query,query_post,code,url,valMin,valMax)
        {/*
		ctl00_cphContenuto_txtDescrizione.value=desc;
		document.getElementById("ctl00_cphContenuto_hdnEdit").value=IdStep;
		document.getElementById("ctl00_cphContenuto_lstFase").value=CodFase;
		if(automatico=="False")automatico='';
		document.getElementById("ctl00_cphContenuto_chkAutomatico").status=automatico;
		ctl00_cphContenuto_txtCode.value=code;
		ctl00_cphContenuto_txtQuery.value=query;
		ctl00_cphContenuto_txtUrl.value=url;
		ctl00_cphContenuto_txtQueryPost.value=query_post;
		ctl00_cphContenuto_txtValoreMinimo.value=valMin;
		ctl00_cphContenuto_txtValoreMassimo.value=valMax;*/

            document.getElementById("ctl00_cphContenuto_hdnEdit").value=IdStep;
            __doPostBack('modifica_step','');
        }
		//-->
    </script>

    <input id="hdnEdit" type="hidden" name="hdnEdit" runat="server" />
    <Siar:SiarTab ID="TAB1" runat="server" Tabs="Step|Nuovo Step" FullValidate="True"
        Width="850px">
        <table class="tableTab" id="Table1" width="100%">
            <tr>
                <td>
                    <table id="Table2" width="100%">
                        <tr>
                            <td align="right">
                                <div style="width: 800px; height: 50px; border-bottom: #142952 1px solid; border-left: #142952 1px solid">
                                    <strong>
                                        <br />
                                        Fase Procedurale : </strong>
                                    <Siar:ComboFasiProcedurali ID="lstFaseProcedurale" runat="server">
                                    </Siar:ComboFasiProcedurali>
                                    &nbsp; &nbsp;&nbsp;<strong>Parole chiave:</strong>&nbsp;
                                    <Siar:TextBox runat="server" ID="txtFiltroMisura" Width="83px" />
                                    &nbsp; &nbsp;&nbsp;<strong>ID:</strong>&nbsp;
                                    <Siar:IntegerTextBox  NoCurrency="true" runat="server" ID="txtIdStep" Width="83px"   />
                                    &nbsp; &nbsp; &nbsp;<Siar:Button ID="btnFiltroMisura" Width="100px" runat="server"
                                        Text="Applica Filtro" CausesValidation="false" />&nbsp;
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <Siar:DataGrid ID="dg" runat="server" Width="100%" AllowPaging="True" PageSize="30"
                                    AutoGenerateColumns="False" EnableViewState="False">
                                    <AlternatingItemStyle CssClass="DataGridRow"></AlternatingItemStyle>
                                    <ItemStyle CssClass="DataGridRow"></ItemStyle>
                                    <HeaderStyle Font-Bold="True" ForeColor="White" CssClass="TESTA1"></HeaderStyle>
                                    <Columns>
                                        <Siar:NumberColumn HeaderText="Nr.">
                                            <ItemStyle Width="35px" HorizontalAlign="center"></ItemStyle>
                                        </Siar:NumberColumn>
                                        <asp:BoundColumn DataField="IdStep" HeaderText="ID Step">
                                            <ItemStyle HorizontalAlign="Center" Width="40px"></ItemStyle>
                                        </asp:BoundColumn>
                                        <Siar:ColonnaLink DataField="Descrizione" HeaderText="Descrizione" LinkFields="IdStep"
                                            LinkFormat='javascript:modifica({0})'>
                                        </Siar:ColonnaLink>
                                        <asp:BoundColumn DataField="Misura" HeaderText="Parola chiave">
                                            <ItemStyle HorizontalAlign="Center" Width="80px"></ItemStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="FaseProcedurale" HeaderText="Fase Procedurale">
                                            <ItemStyle HorizontalAlign="Center" Width="120px"></ItemStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="Automatico" HeaderText="Automatico" DataFormatString="{0:SI|NO}">
                                            <ItemStyle HorizontalAlign="Center" Width="80px"></ItemStyle>
                                        </asp:BoundColumn>
                                        <%-- <asp:TemplateColumn>
                                            <headerstyle width="50px"></headerstyle>
                                            <itemstyle horizontalalign="Center"></itemstyle>
                                            <itemtemplate>
												<asp:HyperLink id=HyperLink1 runat="server" EnableViewState="False" NavigateUrl='<%# getElimina(Container) %>'>Elimina</asp:HyperLink>
											</itemtemplate>
                                        </asp:TemplateColumn>--%>
                                    </Columns>
                                </Siar:DataGrid>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table id="Table3" width="100%">
                        <tr>
                            <td style="width: 139px; vertical-align: top;">
                                &nbsp;
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 139px;">
                                ID step:
                            </td>
                            <td>
                                <Siar:TextBox ID="txtIdStepSel" runat="server" Width="100px" ReadOnly="true" NomeCampo="IdStep" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 139px;">
                                Descrizione step:
                            </td>
                            <td>
                                <Siar:TextArea ID="txtDescrizione" runat="server" Width="500px" NomeCampo="Descrizione"
                                    Obbligatorio="True" DataColumn="Descrizione"></Siar:TextArea>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 139px;">
                                Parole chiave:
                            </td>
                            <td>
                                <Siar:TextBox ID="txtMisura" runat="server" Width="150px" NomeCampo="Misura" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 139px;">
                                Fase procedurale del progetto associato:
                            </td>
                            <td>
                                <Siar:ComboFasiProcedurali ID="lstFase" runat="server" Obbligatorio="true" NomeCampo="Fase Procedurale"
                                    DataColumn="CodFase">
                                </Siar:ComboFasiProcedurali>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 139px;">
                                Valore Minimo:
                            </td>
                            <td>
                                <Siar:CurrencyBox ID="txtValoreMinimo" NomeCampo="Valore Minimo" runat="server" DataColumn="ValMinimo" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 139px">
                                Valore Massimo:
                            </td>
                            <td>
                                <Siar:CurrencyBox ID="txtValoreMassimo" NomeCampo="Valore Massimo" runat="server"
                                    DataColumn="ValMassimo" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 139px; vertical-align: top;">
                                &nbsp;
                            </td>
                            <td>
                                <asp:CheckBox ID="chkAutomatico" runat="server" Text="    Automatico" Width="106px" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 139px; vertical-align: top;">
                                &nbsp;
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 139px; vertical-align: top;" class="separatore">
                            </td>
                            <td class="separatore">
                                (MESSAGGIO DA ADMINISTRATOR: NON MODIFICARE O INSERIRE &nbsp;NEI CAMPI QUI SOTTO
                                A MENO CHE NON SI SAPPIA QUELLO CHE SI STA FACENDO)
                            </td>
                        </tr>
                        <tr>
                            <td style="vertical-align: top; width: 139px">
                                &nbsp;
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 139px; vertical-align: top;">
                                Query SQL:
                            </td>
                            <td>
                                <Siar:TextArea ID="txtQueryLungaSQL" runat="server" Width="503px" Rows="10" />
                            </td>
                        </tr>
                        <tr>
                            <td style="vertical-align: top; width: 139px">
                                Query SQL Post:
                            </td>
                            <td>
                                <Siar:TextArea ID="txtQueryPost" runat="server" Width="502px" Rows="4" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 139px;">
                                Nome Metodo:
                            </td>
                            <td>
                                <Siar:TextBox ID="txtCode" runat="server" MaxLength="30" Width="330px" DataColumn="CodeMethod" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 139px;">
                                Url:
                            </td>
                            <td>
                                <Siar:TextBox ID="txtUrl" runat="server" MaxLength="100" Width="330px" DataColumn="Url" />
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="vertical-align: top; width: 139px">
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 139px; vertical-align: top;">
                            </td>
                            <td align="right">
                                <Siar:Button ID="btnSalva" runat="server" Width="140px" Text="Salva" OnClick="btnSalva_Click"
                                    Modifica="true"></Siar:Button>&nbsp;&nbsp; &nbsp;
                                <Siar:Button ID="btnElimina" runat="server" Width="140px" Text="Elimina" Modifica="true"
                                    OnClick="btnElimina_Click"></Siar:Button>&nbsp;&nbsp;&nbsp;
                                <input class="Button" onclick="javascript:nuovo()" type="button" value="Nuovo" style="width: 140px" />&nbsp;
                                &nbsp;&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 139px; vertical-align: top;">
                                &nbsp;
                            </td>
                            <td align="right">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </Siar:SiarTab>
</asp:Content>
