<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    Inherits="web.Private.Impresa.ImpresaFind" CodeBehind="ImpresaFind.aspx.cs" %>

<%@ Register Src="~/CONTROLS/ImpresaControl.ascx" TagName="ImpresaControl" TagPrefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
    function ctrlCuaaDitta() {
        var text_box_cuaa = $('[id$=txtCuaaRicerca_text]'); var cuaa = $(text_box_cuaa).val().replace(/\s/g, '');
        if (cuaa != null && cuaa != "" && !ctrlCodiceFiscale(cuaa) && !ctrlPIVA(cuaa)) {
            alert('Attenzione! Il Codice Fiscale inserito per la ricerca della ditta non è valido.');
        }
    }

    function scaricaAnagrafica(cuaa) { $('[id$=txtCuaaRicerca_text]').val(cuaa); $('[id$=btnCercaWS]').click(); }

    function switchMostraInserisciImpresa() {
        var div = $('[id$=divInserisciImpresa]');
        var btn = $('[id$=btnInserisciImpresa]')[0];

        if (div[0].style.display === "none") {
            div.show("fast");
            btn.value = "Nascondi inserisci impresa";
        } else {
            div.hide("fast");
            btn.value = "Mostra inserisci impresa";
        }
    }
//--></script>

    <div class="row py-5 mx-2">

        <h3 class="pb-5">Pagina di selezione Beneficiario</h3>
        <div class="row pt-3">
            <div class="form-group col-sm-6">
                <Siar:TextBox  Label="Ricerca per Codice Fiscale:" ID="txtCuaaRicerca" runat="server" Obbligatorio="true" NomeCampo="Partita iva/Codice fiscale" Style="text-align: left" />
                <p>
                    (inserire il codice fiscale dell'impresa/ente da ricercare)
                </p>
            </div>
            <div class="form-group col-sm-6">
                <Siar:TextBox  Label="Ricerca per ragione sociale:" ID="txtRagSociale" runat="server" />
                <p>
                    (consigliato digitare una sola parola o parte di essa)
                </p>
            </div>
        </div>
        <div class="row pt-3">
            <div class="col-sm-12">
                <Siar:Button ID="btnCercaDB" runat="server" Width="220px" Text="Cerca sul database locale"
                    CausesValidation="False" OnClick="btnCercaDB_Click"></Siar:Button>
                <input runat="server" id="btnInserisciImpresa" type="button" visible="false"
                    class="btn btn-primary py-1" value="Mostra inserisci impresa" onclick="switchMostraInserisciImpresa();" />
                <Siar:Button ID="btnCercaWS" runat="server" Visible="false"
                    Width="220px" Text="Cerca su Anagrafe Tributaria" OnClick="btnCercaWS_Click"
                    CausesValidation="TRUE"></Siar:Button>
            </div>
        </div>
        <div class="row pt-3">
            <div class="col-sm-12">
                <p>
                    Elementi trovati :<Siar:Label ID="lblRisultato" runat="server"></Siar:Label>
                </p>
                <Siar:DataGridAgid ID="dg" CssClass="table table-striped" runat="server" PageSize="15" AllowPaging="True"
                    AutoGenerateColumns="False">
                    <ItemStyle Height="26px"></ItemStyle>
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle HorizontalAlign="Center" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="RagioneSociale" HeaderText="Ragione sociale"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Cuaa" HeaderText="Cod.Fiscale">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="CodiceFiscale" HeaderText="Cf/P.Iva">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGridAgid>
            </div>
        </div>
    </div>

    <div runat="server" id="divInserisciImpresa" class="dBox" style="display: none; width: 800px;">
        <div class="separatore">
            Inserisci una nuova impresa
        </div>
        <br />

        <div style="padding: 5px;">
            <p>Prima di inserire una nuova impresa verificare che non esista già!</p>
            <br />

            <uc3:ImpresaControl ID="ucImpresaControl" runat="server" ContoCorrenteVisibile="True"
                ClassificazioneUmaVisibile="false" />
        </div>
    </div>
</asp:Content>
