<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    CodeBehind="CatalogoQuadriDomanda.aspx.cs" Inherits="web.Private.regione.CatalogoQuadriDomanda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">
    <script type="text/javascript"><!--
    function caricaQuadro(id) {
        $('[id$=hdnQuadro]').val(id);
        $('[id$=btnPost]').click();
    }
    function nuovoQuadro() {
        $('[id$=txtDenominazione]').val('');
        $('[id$=txtDescrizione]').val('');
        $('[id$=hdnQuadro]').val('');
    }
    function chkQuadroPresente(ev) {
        if ($('[id$=hdnQuadro]').val() == null || $('[id$="hdnQuadro"]').val() == '') { alert("Selezionare il quadro."); stopEvent(ev); }
    }
//--></script>
    <div class="rowpy-5 mx-2" id="tblElenco">
        <div class="bd-form">
            <div style="display: none">
                <Siar:Hidden ID="hdnQuadro" runat="server"></Siar:Hidden>
                <asp:Button ID="btnPost" runat="server" Text="Button" CausesValidation="false" OnClick="btnPost_Click" />
            </div>
            <h3 class="pb-5">Nuovo/modifica Quadro Domanda:</h3>
            <div class="form-group col-sm-12">

                <Siar:TextBox  Label="Denominazione" ID="txtDenominazione" runat="server" Obbligatorio="True"
                    NomeCampo="Denominazione" />
            </div>
            <div class="form-group col-sm-12">

                <Siar:TextArea Label="Descrizione:" ID="txtDescrizione" runat="server" Obbligatorio="True"
                    NomeCampo="Descrizione"></Siar:TextArea>
            </div>
            <div class="col-sm-12">
                <Siar:Button ID="btnSalva" runat="server" Text="Salva" OnClick="btnSalva_Click"
                    Modifica="true"></Siar:Button>

                <Siar:Button ID="btnElimina" runat="server" Text="Elimina" OnClick="btnElimina_Click"
                    Modifica="true" CausesValidation="False" OnClientClick="chkQuadroPresente(event)"></Siar:Button>

                <input class="btn btn-secondary py-1" onclick="nuovoQuadro()" type="button" value="Nuovo" />

            </div>
        </div>
        <div class="row">
            <div class="col-sm-12">
                <Siar:DataGridAgid ID="dg" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False"
                    CssClass="table table-striped" EnableViewState="False"
                    PageSize="15">
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <HeaderStyle Width="35px"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="Denominazione" HeaderText="Denominazione"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione"></asp:BoundColumn>
                        <asp:BoundColumn></asp:BoundColumn>
                    </Columns>
                </Siar:DataGridAgid>
            </div>
        </div>
    </div>
</asp:Content>
