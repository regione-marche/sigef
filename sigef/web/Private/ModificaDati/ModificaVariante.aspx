<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true" CodeBehind="ModificaVariante.aspx.cs" Inherits="web.Private.ModificaDati.ModificaVariante" %>

<%@ Register Src="../../CONTROLS/IVariantiControl.ascx" TagName="IVariantiControl" TagPrefix="uc1" %>
<%@ Register Src="~/CONTROLS/ProgettoIndicatori.ascx" TagName="ProgettoIndicatori" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <script type="text/javascript">

        function MostraNascondiDiv(id) {
            var div;
            var img;
            switch (id) {
                case 0:
                    div = $('[id$=divMostraRequisitiVariante]');
                    img = $('[id$=imgMostraRequisitiVariante]')[0];
                    break;
                case 1:
                    div = $('[id$=divMostraVarianteIndicatori]');
                    img = $('[id$=imgMostraVarianteIndicatori]')[0];
                    break;
            }

            if (img.style.transform == "")
                img.style.transform = "rotate(180deg)";
            else
                img.style.transform = "";

            if (div[0].style.display === "none") {
                div.show("fast");
            } else {
                div.hide("fast");
            }
        }

    </script>

    <div style="padding-left: 10px; padding-bottom: 10px;">
        <uc1:IVariantiControl id="ucRiepilogoDomandaPagamento" runat="server" />
    </div>

    <div class="dBox">

        <div class="separatore" style="padding-bottom: 3px;">
            Modifica dati variante
        </div>

        <div id="divMostraModificaVariante" style="padding: 10px;">

            <div id="divVarianteRequisiti" runat="server" class="dBox">

                <div class="separatore" style="padding-bottom: 3px; cursor: pointer;" onclick="MostraNascondiDiv(0); return false;">
                    <img id="imgMostraRequisitiVariante" runat="server" style="width: 23px; height: 23px;" />
                    Requisiti della variante
                </div>

                <div id="divMostraRequisitiVariante" style="padding: 10px;">
                    <div id="divDisposizioniAttuative" runat="server" style="margin-top: 10px;">
                    </div>

                    <div>
                        Note modifiche requisiti:<br />
                        <Siar:TextArea ID="txtNoteRequisitiVariante" runat="server" NomeCampo="Note indicatori variante"
                            Obbligatorio="false" Width="800px" Rows="4" ExpandableRows="5" MaxLength="10000" />
                    </div>

                    <input type="button" class="Button" value="Indietro" style="width: 120px; margin-left: 10px; margin-right: 10px;" onclick="history.back();" />
                    <Siar:Button ID="btnSalvaRequisitiVariante" runat="server" Modifica="True" Width="120px" Text="Salva requisiti" OnClick="btnSalvaRequisitiVariante_Click" />
                </div>
            </div>

            <div id="divVarianteIndicatori" runat="server" class="dBox">

                <div class="separatore" style="padding-bottom: 3px; cursor: pointer;" onclick="MostraNascondiDiv(1); return false;">
                    <img id="imgMostraVarianteIndicatori" runat="server" style="width: 23px; height: 23px;" />
                    Indicatori della variante
                </div>

                <div id="divMostraVarianteIndicatori" style="padding: 10px;">
                    <uc2:ProgettoIndicatori ID="ucVarianteInd" runat="server" style="margin-top: 10px;" />

                    <div>
                        Note modifiche indicatori:<br />
                        <Siar:TextArea ID="txtNoteIndicatoriVariante" runat="server" NomeCampo="Note indicatori variante"
                            Obbligatorio="false" Width="800px" Rows="4" ExpandableRows="5" MaxLength="10000" />
                    </div>

                    <input type="button" class="Button" value="Indietro" style="width: 120px; margin-top: 10px; margin-left: 10px; margin-right: 10px;" onclick="history.back();" />
                    <Siar:Button ID="btnSalvaIndicatoriVariante" runat="server" Modifica="True" Width="120px" Text="Salva indicatori" OnClick="btnSalvaIndicatoriVariante_Click" />
                </div>
            </div>

        </div>

    </div>

</asp:Content>
