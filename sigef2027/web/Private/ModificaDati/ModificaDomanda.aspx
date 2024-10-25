<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true" CodeBehind="ModificaDomanda.aspx.cs" Inherits="web.Private.ModificaDati.ModificaDomanda" %>

<%@ Register Src="../../CONTROLS/DatiDomanda.ascx" TagName="DatiDomanda" TagPrefix="uc1" %>
<%@ Register Src="../../CONTROLS/ProgettoIndicatori.ascx" TagName="ProgettoIndicatori" TagPrefix="uc2" %>
<%@ Register Src="../../CONTROLS/IDomandaPagamento.ascx" TagName="IDomandaPagamento" TagPrefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">
    <uc3:IDomandaPagamento ID="ucRiepilogoDomandaPagamento" runat="server" />
    <div class="row">
        <div class="col-sm-12">
            <div class="accordion accordion-background-active" id="collapseRaggruppamenti">
                <div class="accordion-item" id="divRequisitiProgetto" runat="server">
                    <h2 class="accordion-header " id="headingProgetto">
                        <button class="accordion-button rounded-2" type="button" data-bs-toggle="collapse" data-bs-target="#collapseProgetto" aria-expanded="true" aria-controls="collapseProgetto">
                            Requisiti della domanda di pagamento
                        </button>
                    </h2>
                    <div id="collapseProgetto" class="accordion-collapse collapse show" data-bs-parent="#accordionExampleHa" role="region" aria-labelledby="headingProgetto">
                        <div class="accordion-body">
                            <div class="row bd-form">
                                <div class="col-sm-12" id="divDisposizioniAttuative" runat="server">
                                </div>
                                <div class="col-sm-12 form-group my-2">
                                    <Siar:TextArea Label="Note modifiche requisiti:" ID="txtNoteRequisitiDomanda" runat="server" NomeCampo="Note requisiti domanda"
                                        Obbligatorio="false" Width="800px" Rows="4" ExpandableRows="5" MaxLength="10000" />
                                </div>
                                <div class="col-sm-12">
                                    <input type="button" class="btn btn-secondary py-1" value="Indietro" onclick="history.back();" />
                                    <Siar:Button ID="btnSalvaRequisitiDomanda" runat="server" Modifica="True" Text="Salva requisiti" OnClick="btnSalvaRequisitiDomanda_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="accordion-item" id="divProgettoIndicatori" runat="server">
                    <h2 class="accordion-header " id="headingIndicatori">
                        <button class="accordion-button rounded-2" type="button" data-bs-toggle="collapse" data-bs-target="#collapseIndicatori" aria-expanded="true" aria-controls="collapseIndicatori">
                            Indicatori della domanda di pagamento
                        </button>
                    </h2>
                    <div id="collapseIndicatori" class="accordion-collapse collapse show" data-bs-parent="#accordionExampleHa" role="region" aria-labelledby="headingIndicatori">
                        <div class="accordion-body">
                            <div class="row bd-form">
                                <uc2:ProgettoIndicatori ID="ucDomandaInd" runat="server" style="margin-top: 10px; margin-bottom: 10px;" />
                                <div class="col-sm-12 form-group my-2">                                    
                                    <Siar:TextArea Label="Note modifiche indicatori:" ID="txtNoteIndicatoriDomanda" runat="server" NomeCampo="Note indicatori domanda"
                                        Obbligatorio="false" Width="800px" Rows="4" ExpandableRows="5" MaxLength="10000" />
                                </div>
                                <div class="col-sm-12">
                                    <input type="button" class="btn btn-secondary py-1" value="Indietro" onclick="history.back();" />
                                    <Siar:Button ID="btnSalvaIndicatoriDomanda" runat="server" Modifica="True" Width="120px" Text="Salva indicatori" OnClick="btnSalvaIndicatoriDomanda_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
