<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true" CodeBehind="ModificaVariante.aspx.cs" Inherits="web.Private.ModificaDati.ModificaVariante" %>

<%@ Register Src="../../CONTROLS/IVariantiControl.ascx" TagName="IVariantiControl" TagPrefix="uc1" %>
<%@ Register Src="~/CONTROLS/ProgettoIndicatori.ascx" TagName="ProgettoIndicatori" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <uc1:IVariantiControl ID="ucRiepilogoDomandaPagamento" runat="server" />
    <div class="accordion accordion-background-active" id="collapseRaggruppamenti">
        <div class="accordion-item">
            <h2 class="accordion-header " id="headingVariante">
                <button class="accordion-button rounded-2" type="button" data-bs-toggle="collapse" data-bs-target="#collapseVariante" aria-expanded="true" aria-controls="collapseVariante">
                    Modifica dati variante
                </button>
            </h2>
            <div id="collapseVariante" class="accordion-collapse collapse show" data-bs-parent="#accordionExampleHa" role="region" aria-labelledby="headingVariante">
                <div class="accordion-body">
                    <div class="accordion accordion-background-active" id="collapseRaggruppamenti">
                        <div class="accordion-item">
                            <h2 class="accordion-header " id="headingVariante">
                                <button class="accordion-button rounded-2" type="button" data-bs-toggle="collapse" data-bs-target="#collapseVariante" aria-expanded="true" aria-controls="collapseVariante">
                                    Requisiti della variante
                                </button>
                            </h2>
                            <div id="collapseVariante" class="accordion-collapse collapse show" data-bs-parent="#accordionExampleHa" role="region" aria-labelledby="headingVariante">
                                <div class="accordion-body">
                                    <div class="row">
                                        <div id="divDisposizioniAttuative" runat="server" class="col-sm-12">
                                        </div>
                                        <div class="col-sm-12 form-group">
                                            <Siar:TextArea Label="Note modifiche requisiti:" ID="txtNoteRequisitiVariante" runat="server" NomeCampo="Note indicatori variante"
                                                Obbligatorio="false" Rows="4" ExpandableRows="5" MaxLength="10000" />
                                        </div>
                                        <div class="col-sm-12">
                                            <input type="button" class="btn btn-secondary py-1" value="Indietro" onclick="history.back();" />
                                            <Siar:Button ID="btnSalvaRequisitiVariante" runat="server" Modifica="True" Text="Salva requisiti" OnClick="btnSalvaRequisitiVariante_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="accordion accordion-background-active" id="collapseRaggruppamenti">
                            <div class="accordion-item">
                                <h2 class="accordion-header " id="headingIndicatoriVariante">
                                    <button class="accordion-button rounded-2" type="button" data-bs-toggle="collapse" data-bs-target="#collapseIndicatoriVariante" aria-expanded="true" aria-controls="collapseIndicatoriVariante">
                                        Indicatori della variante
                                    </button>
                                </h2>
                                <div id="collapseIndicatoriVariante" class="accordion-collapse collapse show" data-bs-parent="#accordionExampleHa" role="region" aria-labelledby="headingIndicatoriVariante">
                                    <div class="accordion-body">
                                        <div class="col-sm-12">
                                            <uc2:ProgettoIndicatori ID="ucVarianteInd" runat="server" class="col-sm-12" />

                                            <div class="col-sm-12 form-group">
                                                <Siar:TextArea Label="Note modifiche indicatori:" ID="txtNoteIndicatoriVariante" runat="server" NomeCampo="Note indicatori variante"
                                                    Obbligatorio="false" Width="800px" Rows="4" ExpandableRows="5" MaxLength="10000" />
                                            </div>
                                            <div class="col-sm-12">
                                                <input type="button" class="btn btn-secondary py-1" value="Indietro" onclick="history.back();" />
                                                <Siar:Button ID="btnSalvaIndicatoriVariante" runat="server" Modifica="True" Text="Salva indicatori" OnClick="btnSalvaIndicatoriVariante_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
