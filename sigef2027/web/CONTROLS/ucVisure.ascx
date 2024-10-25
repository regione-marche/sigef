<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucVisure.ascx.cs" Inherits="web.CONTROLS.ucVisure" %>

<script type="text/javascript">

    var tableRow;

    function richiediVisura(azioneVisura, idImpresa, tipoVisura, obj) {
        tableRow = $(obj).closest('tr');
        $('[id$=hdnAzioneVisura]').val(azioneVisura);
        $('[id$=hdnIdImpresa]').val(idImpresa);
        if (tipoVisura == '')
            $('[id$=hdnTipoVisura]').val($('[id$=cmbTipoVisura_' + idImpresa + ']').val());
        else
            $('[id$=hdnTipoVisura]').val(tipoVisura);
        $('[id$=btnDownloadVisura]').click();
    }

    function fnRNAScaricaVisura(idFile) {
        RNAScaricaVisura(idFile);
    }

    function confermaReinvio() {
        var visuraPresente = false;
        var tipoRichiesta = tableRow.find("td:eq(5)").find("select").val();

        if (tipoRichiesta == "aiuti")
            if (tableRow.find("td:eq(2)").text() != "")
                visuraPresente = true;
        if (tipoRichiesta == "deminimis")
            if (tableRow.find("td:eq(3)").text() != "")
                visuraPresente = true;
        if (tipoRichiesta == "deggendorf")
            if (tableRow.find("td:eq(4)").text() != "")
                visuraPresente = true;
        if (visuraPresente) {
            var r = confirm("Visura già presente, se si procede con la richiesta la visura sarà sovrascritta. Continuare?");
            if (r == true) {
                return true;
            } else {
                return false;
            }
        }
        else
            return true;
    }

</script>
<asp:HiddenField ID="hdnAzioneVisura" runat="server" />
<asp:HiddenField ID="hdnIdImpresa" runat="server" />
<asp:HiddenField ID="hdnTipoVisura" runat="server" />
<asp:Button ID="btnDownloadVisura" OnClientClick="if(!confermaReinvio()) return false;"
    OnClick="btnDownloadVisura_Click" runat="server" Style="display: none;" />

<div class="accordion-item" id="divVisure" runat="server">
    <h2 class="accordion-header " id="visureHeading">
        <button class="accordion-button rounded-2" type="button" data-bs-toggle="collapse" data-bs-target="#collapseVisure" aria-expanded="false" aria-controls="collapseVisure">
            Download Visure:
        </button>
    </h2>
    <div id="collapseVisure" class="accordion-collapse collapse" role="region" aria-labelledby="visureHeading">
        <div class="accordion-body">
            <div class="table-responsive">
                <Siar:DataGridAgid CssClass="table table-striped" runat="server" ID="dgDownloadVisure" Visible="false" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundColumn HeaderText="P.IVA" DataField="CodiceFiscale"></asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Ragione Sociale" DataField="RagioneSociale"></asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Aiuti"></asp:BoundColumn>
                        <asp:BoundColumn HeaderText="De Minimis"></asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Deggendorf"></asp:BoundColumn>
                        <asp:BoundColumn></asp:BoundColumn>
                        <Siar:JsButtonColumnAgid ButtonText="Invia Richiesta" JsFunction="richiediVisura">                            
                        </Siar:JsButtonColumnAgid>
                    </Columns>
                </Siar:DataGridAgid>
            </div>
        </div>
    </div>
</div>
