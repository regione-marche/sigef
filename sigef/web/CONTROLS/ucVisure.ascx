<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucVisure.ascx.cs" Inherits="web.CONTROLS.ucVisure" %>

<script type="text/javascript">

    var tableRow;

    function MostraNascondiDivVisure() {
        var divVisure;
        var imgVisure;
        divVisure = $('[id$=divMostraVisure]')[0];
        imgVisure = $('[id$=imgMostraVisure]')[0];


        if (imgVisure.style.transform == "")
            imgVisure.style.transform = "rotate(180deg)";
        else
            imgVisure.style.transform = "";

        if (divVisure.style.display === "none") {
            divVisure.style.display = "block";
        } else {
            divVisure.style.display = "none";
        }
    }

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

<div class="dBox" id="divVisure" runat="server">
    <div class="separatore" style="cursor: pointer; padding-bottom: 3px;" onclick="MostraNascondiDivVisure();">
        <img id="imgMostraVisure" runat="server" style="width: 23px; height: 23px;" />
        Download Visure:
    </div>
    <div class="dSezione" id="divMostraVisure">
        <div class="dContenutoFloat">
            <Siar:DataGrid runat="server" ID="dgDownloadVisure" Visible="false" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundColumn HeaderText="P.IVA" DataField="CodiceFiscale"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Ragione Sociale" DataField="RagioneSociale"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Aiuti"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="De Minimis"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Deggendorf"></asp:BoundColumn>
                    <asp:BoundColumn></asp:BoundColumn>
                    <Siar:JsButtonColumn ButtonText="Invia Richiesta" JsFunction="richiediVisura">
                        <ItemStyle Width="180" />
                    </Siar:JsButtonColumn>
                </Columns>
            </Siar:DataGrid>
        </div>
    </div>
</div>
