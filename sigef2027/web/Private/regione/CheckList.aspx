<%@ Page Language="c#" MasterPageFile="~/SigefAgidPrivate.master" Inherits="web.Private.regione.CheckList"
    CodeBehind="CheckList.aspx.cs" %>

<%@ Register Src="../../CONTROLS/SiarNewTabAgid.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
    function selezionaChecklist(id) { $('[id$=hdnIdChecklist]').val(id); $('[id$=btnPost]').click(); }
    //function selezionaTutti(elem, nome_check) {
    //    var chkValue = $(elem)[0].checked; $.each($('[id=' + nome_check + ']'), function () { this.checked = chkValue; });
    //}
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

    <uc1:SiarNewTab ID="ucSiarNewTab" runat="server" TabNames="Elenco checkList|Nuova/Modifica" />
    <div style="display: none">
        <asp:HiddenField ID="hdnIdChecklist" runat="server" />
        <asp:Button ID="btnPost" runat="server" OnClick="btnPost_Click" />
    </div>
    <div id="tbElenco" runat="server" class="tableTab row pt-5">
        <div class="col-sm-6 form-group">
            <Siar:TextBox  Label="Descrizione:" runat="server" ID="txtDescrizioneRicerca" />
        </div>
        <div class="col-sm-6">
            <Siar:Button ID="btnFiltro" runat="server" Text="Applica Filtro"
                CausesValidation="false" OnClick="btnFiltro_Click" />
        </div>
        <div class="col-sm-12">
            <Siar:DataGridAgid CssClass="table table-striped" ID="dg" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="True"
                PageSize="20">
                <Columns>
                    <Siar:NumberColumn HeaderText="Nr.">
                        <ItemStyle HorizontalAlign="Center" />
                    </Siar:NumberColumn>
                    <asp:BoundColumn DataField="IdCheckList" HeaderText="ID CkL">
                        <ItemStyle HorizontalAlign="center" />
                    </asp:BoundColumn>
                    <Siar:ColonnaLinkAgid DataField="Descrizione" HeaderText="Descrizione" LinkFields="IdCheckList"
                        LinkFormat="javascript:selezionaChecklist({0});">
                    </Siar:ColonnaLinkAgid>
                    <asp:BoundColumn HeaderText="Template">
                        <ItemStyle HorizontalAlign="center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Data ultima modifica" DataField="DataModifica">
                        <ItemStyle HorizontalAlign="center" />
                    </asp:BoundColumn>
                </Columns>
            </Siar:DataGridAgid>
        </div>
    </div>
    <div id="tbModifica" runat="server" class="tableTab row bd-form pt-5">
        <div class="col-sm-12 form-group">
            <Siar:TextArea Label="Descrizione:" ID="txtDescrizione" runat="server" Obbligatorio="True"
                NomeCampo="Descrizione"></Siar:TextArea>
        </div>
        <div class="col-sm-12 form-check">
            <asp:CheckBox ID="chkTemplate" Text="Salva come modello" runat="server" />
        </div>
        <p id="tdAvvisoModifica" runat="server" class="text-danger fw-bold" align="left"></p>
        <div class="col-sm-12">
            <Siar:Button ID="btnSalva" runat="server" Text="Salva" OnClick="btnSalva_Click"
                Modifica="true" Conferma="" />
            <input id="btnEstraiInXls" class="btn btn-secondary py-1" type="button" value="Estrai in XLS" onclick="estraiChecklistXLS();" />
            <Siar:Button ID="btnElimina" runat="server" Text="Elimina" OnClick="btnElimina_Click"
                Modifica="true" Conferma="Attenzione! Eliminare la checklist selezionata?" CausesValidation="False" />
            <Siar:Button ID="btnNuova" runat="server" Text="Nuova" OnClick="btnNuova_Click"
                Modifica="False" Conferma="" CausesValidation="False" />
        </div>
        <div class="row" id="tbStep" runat="server">
            <h3 class="pb-5 mt-5">Elenco step operativi associati:</h3>
            <div class="col-sm-6 form-group">
                <Siar:ComboCheckList ID="lstModelloChecklist" Label="Carica da modello:" runat="server">
                </Siar:ComboCheckList>
            </div>
            <div class="col-sm-6">
                <Siar:Button ID="btnCaricaModello" runat="server" Text="Carica"
                    CausesValidation="false" OnClick="btnCaricaModello_Click" />
            </div>
            <div class="col-sm-6 form-group">
                <Siar:ComboFasiProcedurali Label="Seleziona la fase procedurale:" ID="lstFaseProgetto" runat="server" Obbligatorio="true"
                    NomeCampo="Fase procedurale">
                </Siar:ComboFasiProcedurali>
            </div>
            <div class="col-sm-6">
                <Siar:Button ID="btnCaricaFaseProcedurale" runat="server" Text="Carica"
                    CausesValidation="false" OnClick="btnCaricaFaseProcedurale_Click" />
            </div>
            <div class="col-sm-5 form-group">
                <Siar:TextBox  Label="Descrizione:" runat="server" ID="txtFiltroDescrizione" />
            </div>
            <div class="col-sm-5 form-group">
                <Siar:TextBox  Label="Misura:" runat="server" ID="txtFiltroMisura" />
            </div>
            <div class="col-sm-2">
                <Siar:Button ID="btnFiltroMisura" runat="server" Text="Filtra" CausesValidation="false"
                    OnClick="btnPost_Click" />
            </div>
            <div class="col-sm-12">
                <Siar:DataGridAgid CssClass="table table-striped" ID="dgStep" runat="server" Width="100%" AutoGenerateColumns="False"
                    PageSize="30" AllowPaging="true">
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle HorizontalAlign="center" />
                        </Siar:NumberColumn>
                        <%--<asp:BoundColumn DataField="IdStep" HeaderText="ID Step">
                                        <ItemStyle Width="40px" HorizontalAlign="Center" />
                                    </asp:BoundColumn>--%>
                        <asp:BoundColumn DataField="IdStep" HeaderText="ID Step">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Descrizione" DataField="Step"></asp:BoundColumn>
                        <asp:BoundColumn DataField="FaseProcedurale" HeaderText="Fase Procedurale">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Misura" HeaderText="Misura">
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Automatico" HeaderText="Automatico" DataFormatString="{0:SI|NO}">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <Siar:CheckColumnAgid DataField="IdStep" HeaderSelectAll="true" Name="chkObb" HeaderText="Obbligatorio">
                        </Siar:CheckColumnAgid>
                        <Siar:CheckColumnAgid DataField="IdStep" HeaderSelectAll="true" Name="chkVisita" HeaderText="Selez. per verbale visita">
                        </Siar:CheckColumnAgid>
                        <Siar:IntegerColumnAgid DataField="IdStep" HeaderText="Ordine" Valore="Ordine" Name="Ordine">
                            <ItemStyle HorizontalAlign="center" />
                        </Siar:IntegerColumnAgid>
                        <Siar:CheckColumnAgid DataField="IdStep" HeaderSelectAll="true" Name="chkInclusione" HeaderText="Includi">
                        </Siar:CheckColumnAgid>
                    </Columns>
                </Siar:DataGridAgid>
            </div>
        </div>
    </div>
</asp:Content>
