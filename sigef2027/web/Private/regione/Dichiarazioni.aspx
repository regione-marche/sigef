<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    Inherits="web.Private.regione.Dichiarazioni" CodeBehind="Dichiarazioni.aspx.cs" %>

<%@ Register Src="../../CONTROLS/SiarNewTabAgid.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript">
		<!--
    function nuovo() {
        $('[id$=hdnEdit]').val('');
        $('[id$=txtMisura_text]').val('');
        $('[id$=txtDescrizioneLunga_text]').val('');

    }
    function modifica(id) {
        $('[id$=hdnEdit]').val(id);
        $('[id$=btnPost]').click();
    }
		//-->
    </script>

    <div style="display: none">
        <input id="hdnEdit" type="hidden" name="hdnEdit" runat="server" />
        <asp:Button ID="btnPost" runat="server" OnClick="btnPost_Click" />
    </div>
    <uc1:SiarNewTab ID="ucSiarNewTab1" runat="server" TabNames="Dichiarazioni|Nuova dichiarazione" />
    <div class="row tableTab py-5 mx-2" id="tblElenco" runat="server">
        <div class="row">
            <div class="form-group col-sm-2">
                <Siar:TextBox  Label="Misura" ID="txtMisuraFind" runat="server"></Siar:TextBox>
            </div>
            <div class="form-group col-sm-6">
                <Siar:TextBox  Label="Descrizione" ID="txtDescrizioneFind" runat="server"></Siar:TextBox>
            </div>
            <div class="col-sm-4">
                <Siar:Button ID="btnCerca" runat="server" OnClick="btnCerca_Click" Text="Cerca" />

                <Siar:Button ID="btnNoFilter" runat="server" OnClick="btnNoFilter_Click" Text="Annulla Ricerca" />
            </div>
        </div>
    <div class="row">
        <div class="col-sm-12">
            <Siar:DataGridAgid ID="dg" runat="server" Width="100%" ShowShadow="False" PageSize="20"
                AllowPaging="True" CssClass="table table-striped" AutoGenerateColumns="False">
                <AlternatingItemStyle CssClass="DataGridRow"></AlternatingItemStyle>
                <ItemStyle CssClass="DataGridRow"></ItemStyle>
                <HeaderStyle Font-Bold="True" ForeColor="White" CssClass="TESTA1"></HeaderStyle>
                <Columns>
                    <Siar:NumberColumn HeaderText="Nr.">
                        <HeaderStyle Width="35px"></HeaderStyle>
                        <ItemStyle HorizontalAlign="center"></ItemStyle>
                    </Siar:NumberColumn>
                    <Siar:ColonnaLink DataField="Descrizione" LinkFields="IdDichiarazione|Descrizione|Misura"
                        HeaderText="Descrizione" LinkFormat="javascript:modifica({0})">
                    </Siar:ColonnaLink>
                    <asp:BoundColumn DataField="Misura" HeaderText="Misura">
                        <ItemStyle HorizontalAlign="Center" Width="80px"></ItemStyle>
                    </asp:BoundColumn>
                    <asp:TemplateColumn>
                        <HeaderStyle Width="50px"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        <ItemTemplate>
                            <asp:HyperLink ID="HyperLink1" runat="server" EnableViewState="False" NavigateUrl='<%# getElimina(Container) %>'>Elimina</asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                </Columns>
                <PagerStyle CssClass="coda" Mode="NumericPages"></PagerStyle>
            </Siar:DataGridAgid>&nbsp;
        </div>
    </div>
    </div>
    <div class="row tableTab py-5 mx-2 bd-form" id="tblNuovo" runat="server">

        <div class="form-group col-sm-12">
            <Siar:TextArea Label="Descrizione" ID="txtDescrizioneLunga" runat="server" NomeCampo="Descrizione"
                Obbligatorio="True" Rows="10"></Siar:TextArea>
        </div>
        <div class="form-group col-sm-12">
            <Siar:TextBox  Label="Misura" ID="txtMisura" runat="server" NomeCampo="Misura" />
        </div>
        <div class="col-sm-12">
            <Siar:Button ID="btnSalva" runat="server" Text="Salva" OnClick="btnSalva_Click"
                Modifica="true"></Siar:Button>
            <input class="btn btn-secondary py-1" onclick="javascript: nuovo()" type="button" value="Nuovo" />
        </div>
    </div>

</asp:Content>
