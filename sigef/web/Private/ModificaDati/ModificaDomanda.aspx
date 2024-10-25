<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true" CodeBehind="ModificaDomanda.aspx.cs" Inherits="web.Private.ModificaDati.ModificaDomanda" %>

<%@ Register Src="../../CONTROLS/DatiDomanda.ascx" TagName="DatiDomanda" TagPrefix="uc1" %>
<%@ Register Src="../../CONTROLS/ProgettoIndicatori.ascx" TagName="ProgettoIndicatori" TagPrefix="uc2" %>
<%@ Register Src="../../CONTROLS/IDomandaPagamento.ascx" TagName="IDomandaPagamento" TagPrefix="uc3" %>

<asp:content id="Content1" contentplaceholderid="cphContenuto" runat="server">

    <script type="text/javascript">

        function MostraNascondiDiv(id) {
            var div;
            var img;
            switch (id) {
                case 0:
                    div = $('[id$=divMostraRequisitiSoggettivi]');
                    img = $('[id$=imgMostraRequisitiSoggettivi]')[0];
                    break;
                case 1:
                    div = $('[id$=divMostraDomandaIndicatori]');
                    img = $('[id$=imgMostraDomandaIndicatori]')[0];
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
        <uc3:IDomandaPagamento ID="ucRiepilogoDomandaPagamento" runat="server" />
    </div>

    <div class="dBox">

        <div class="separatore" style="padding-bottom: 3px;">
            Modifica dati domanda di pagamento
        </div>

        <div id="divMostraModificaDomanda" style="padding: 10px;">

            <div id="divRequisitiDomanda" runat="server" class="dBox">

                <div class="separatore" style="padding-bottom: 3px; cursor: pointer;" onclick="MostraNascondiDiv(0); return false;">
                    <img id="imgMostraRequisitiSoggettivi" runat="server" style="width: 23px; height: 23px;" />
                    Requisiti della domanda di pagamento
                </div>

                <div id="divMostraRequisitiSoggettivi" style="padding: 10px;">
                    <div id="divDisposizioniAttuative" runat="server" style="margin-top: 10px;">
                    </div>

                    <div>
                        Note modifiche requisiti:<br />
                        <Siar:TextArea ID="txtNoteRequisitiDomanda" runat="server" NomeCampo="Note requisiti domanda"
                            Obbligatorio="false" Width="800px" Rows="4" ExpandableRows="5" MaxLength="10000" />
                    </div>

                    <input type="button" class="Button" value="Indietro" style="width: 120px; margin-left: 10px; margin-right: 10px;" onclick="history.back();" />
                    <Siar:Button ID="btnSalvaRequisitiDomanda" runat="server" Modifica="True" Width="120px" Text="Salva requisiti" OnClick="btnSalvaRequisitiDomanda_Click" />
                </div>
            </div>

            <div id="divDomandaIndicatori" runat="server" class="dBox">

                <div class="separatore" style="padding-bottom: 3px; cursor: pointer;" onclick="MostraNascondiDiv(1); return false;">
                    <img id="imgMostraDomandaIndicatori" runat="server" style="width: 23px; height: 23px;" />
                    Indicatori della domanda di pagamento
                </div>

                <div id="divMostraDomandaIndicatori" style="padding: 10px;">
                    <uc2:ProgettoIndicatori ID="ucDomandaInd" runat="server" style="margin-top:10px; margin-bottom:10px;" />

                    <div style="margin-top: 10px;">
                        Note modifiche indicatori:<br />
                        <Siar:TextArea ID="txtNoteIndicatoriDomanda" runat="server" NomeCampo="Note indicatori domanda"
                            Obbligatorio="false" Width="800px" Rows="4" ExpandableRows="5" MaxLength="10000" />
                    </div>

                    <input type="button" class="Button" value="Indietro" style="width: 120px; margin-top: 10px; margin-left: 10px; margin-right: 10px;" onclick="history.back();" />
                    <Siar:Button ID="btnSalvaIndicatoriDomanda" runat="server" Modifica="True" Width="120px" Text="Salva indicatori" OnClick="btnSalvaIndicatoriDomanda_Click" />
                </div>
            </div>
        </div>

    </div>

</asp:content>
