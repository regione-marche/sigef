<%@ Page Language="c#" MasterPageFile="~/SigefAgidPrivate.master" Inherits="web.Private.admin.Funzionalita"
    CodeBehind="Funzionalita.aspx.cs" %>

<%@ Register Src="../../CONTROLS/SiarNewTabAgid.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
        function selezionaFunzionalita(id) { $('[id$=hdnIdFunzionalita]').val(id);$('[id$=btnPost]').click(); }
        function nuovaFun() {
            $('[id$=txtDescrizione]').val('');$('[id$=txtDescMenu]').val('');$('[id$=txtLivello]').val('');$('[id$=txtOrdine]').val('');
            $('[id$=lstFPadre]').val('');$('[id$=txtLink]').val('');$('[id$=hdnIdFunzionalita]').val('');$('[id$=chkMenu]').attr('checked',false);
            $('[id$=chkModificaPXF]').attr('checked',false);$('[id$=chkSelezionaPXF]').attr('checked',false);$('[id$=tbProfili]').hide();
        }
        function selezionaCheckBoxes(nome_colonna,elem) { $('[id$='+nome_colonna+']').attr('checked',$(elem).attr('checked')); }
//--></script>

    <div style="display: none">
        <input id="hdnIdFunzionalita" type="hidden" runat="server" />
        <asp:Button ID="btnPost" runat="server" OnClick="btnPost_Click" CausesValidation="false" />
    </div>
    <uc1:SiarNewTab ID="ucSiarNewTab" runat="server" TabNames="Elenco completo|Dettaglio selezione"/>
    <div id="tbElenco" runat="server"  class="row tableTab">

     <p class="fw-semibold py-3">Elenco completo funzionalità</p>

    <div class="row py-3">
        <div class="table-responsive">
            <Siar:DataGridAgid ID="dg" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" PageSize="20">
                <HeaderStyle CssClass="headerStyle" />
                <ItemStyle CssClass="DataGridRow itemStyle" />
                <AlternatingItemStyle CssClass="DataGridRowAlt itemStyle" />
                <Columns>
                    <Siar:NumberColumn HeaderText="Nr.">
                        <ItemStyle HorizontalAlign="center" />
                    </Siar:NumberColumn>
                    <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione">
                            <ItemStyle HorizontalAlign="left"  />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="DescMenu" HeaderText="DescMenu">
                        <ItemStyle HorizontalAlign="left"  />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="FlagMenu" HeaderText="Flag Menu" DataFormatString="{0:SI|NO}">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn>
                        <ItemStyle Width="150px" HorizontalAlign="Center" />
                    </asp:BoundColumn>
                </Columns>
            </Siar:DataGridAgid>
        </div>
    </div>
    </div>
    <div id="tbDettaglio" runat="server" class="row tableTab">
      <div class="row align-items-center py-5">
            <div class="col-sm-2">
                <Siar:TextBox ID="txtDescrizione" Label="Descrizione" CssClass="fw-semibold" runat="server" NomeCampo="Descrizione" Obbligatorio="True"></Siar:TextBox>
            </div>
            <div class="col-sm-2">
                <label class="active fw-semibold" for="ComboFunzionalita1">Funzionalità padre</label>
                <Siar:ComboFunzionalita ID="lstFPadre" runat="server"></Siar:ComboFunzionalita>
            </div>
            <div class="col-sm-2">
                <Siar:TextBox ID="txtDescMenu" runat="server" CssClass="fw-semibold" Label="Desc menu" NomeCampo="Descrizione menu" Obbligatorio="True" />
            </div>
          
        </div>
          
         <div class="row align-content-center py-4">
             <div class="col-sm-1">
                <Siar:IntegerTextBox ID="txtOrdine" runat="server" Label="Ordine" CssClass="fw-semibold"  NomeCampo="Ordine" Obbligatorio="True" MaxLength="1"></Siar:IntegerTextBox>
            </div>
            <div class="col-sm-2 mb-4">
                <Siar:TextBox ID="txtLink"  runat="server" CssClass="fw-semibold" Label="Link" NomeCampo="Link"  Obbligatorio="True" ></Siar:TextBox>
            </div>
            <div class="col-sm-1">
                <Siar:IntegerTextBox ID="txtLivello" runat="server" CssClass="fw-semibold " Label="Livello" NomeCampo="Livello" Obbligatorio="True" MaxLength="1"></Siar:IntegerTextBox>
            </div>
            <div class="col-sm-2 pt-4">
                <asp:CheckBox ID="chkMenu" CssClass="px-2"  runat="server" Text="Flag menu" />
            </div>
        </div>
       <div class="grid-row align-items-center justify-content-center py-3">
            <Siar:Button ID="btnSalva" runat="server"  Text="Salva" OnClick="btnSalva_Click" Modifica="true"></Siar:Button>
            <Siar:Button ID="btnElimina" runat="server" Text="Elimina" OnClick="btnElimina_Click"
                Modifica="true" Conferma="Attenzione! Eliminare la funzionalità selezionata insieme ai profili associati?"></Siar:Button>
            <input onclick="nuovaFun();" type="button" class="btn btn-primary py-1" value="Nuovo" />
       </div>
       <div id="tbProfili" class="row align-items-center justify-content-start pt-3">
            <div class="table-responsive">
                <Siar:DataGridAgid ID="dgProfili" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" PageSize="20">
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemStyle CssClass="DataGridRow itemStyle" />
                    <AlternatingItemStyle CssClass="DataGridRowAlt itemStyle" />
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle HorizontalAlign="center"  />
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione">
                                <ItemStyle HorizontalAlign="left"  />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="CodTipoEnte" HeaderText="Cod Tipo Ente">
                            <ItemStyle HorizontalAlign="Center"  />
                        </asp:BoundColumn>
                        <Siar:CheckColumn DataField="IdProfilo" Name="chkModificaPXF" HeaderText="Abilita modifica">
                            <ItemStyle HorizontalAlign="Center"  />
                        </Siar:CheckColumn>
                        <Siar:CheckColumn DataField="IdProfilo" Name="chkSelezionaPXF" HeaderText="Seleziona">
                            <ItemStyle HorizontalAlign="Center" />
                        </Siar:CheckColumn>
                    </Columns>
                </Siar:DataGridAgid>
            </div>
        </div>
        <div class="row align-items-center justify-content-center py-3">
            <div class="col-sm-3">
                <Siar:Button ID="btnSalvaProfili" runat="server" Text="Salva profili" OnClick="btnSalvaProfili_Click" Modifica="true"></Siar:Button>
            </div>
        </div>
        </div>
</asp:Content>
