<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    Inherits="web.Private.PDomanda.RicercaDomanda" CodeBehind="RicercaDomanda.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <div class="container-fluid shadow bd-form rounded-2 py-2">
        <div class="row pt-5 mx-2 bg-100 ">
            <div class="col-sm-12">
                <h3 class="pb-5">Ricerca domanda di contributo</h3>
                <p class="fw-normal">Indicare il numero identificativo della domanda.</p>
                <div class="row pt-3">
                    <div class="form-group col-sm-3">
                        <Siar:IntegerTextBox Label="Numero domanda:" ID="txtNumDomanda" runat="server" Obbligatorio="true"
                            NoCurrency="true" NomeCampo="Numero domanda" />
                    </div>
                    <div class="col-sm-2 pt-2">
                        <Siar:Button ID="btnCerca" runat="server" Text="Cerca" OnClick="btnCerca_Click"
                            CausesValidation="true"></Siar:Button>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row py-2">
       <%-- <h6 class="py-5">Risultato della ricerca</h6>--%>
        <div class="col-sm-12 py-2"  id="tdDomanda" runat="server"></div>
        <div class="col-sm-12 mt-5 text-center" id="tdPulsantiBando" runat="server">
            <div class="row">
                <div class="col-lg-3" id="card1" runat="server" visible="false">
                    <!--start card-->
                    <div class="card-wrapper">
                        <div class="card card-bg">
                            <div class="card-body">
                                <div class="categoryicon-top">
                                    <svg class="icon">
                                        <use href="/web/bootstrap-italia/svg/sprites.svg#it-arrow-right-circle"></use>
                                    </svg>
                                    <span class="text">Sezione dettagli bando</span>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12" id="btnCard1" runat="server">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3" id="card2" runat="server" visible="false">
                    <!--start card-->
                    <div class="card-wrapper">
                        <div class="card card-bg">
                            <div class="card-body">
                                <div class="categoryicon-top">
                                    <svg class="icon">
                                        <use href="/web/bootstrap-italia/svg/sprites.svg#it-arrow-right-circle"></use>
                                    </svg>
                                    <span class="text">Sezione istruttoria bando</span>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12" id="btnCard2" runat="server">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3" id="card3" runat="server" visible="false">
                    <!--start card-->
                    <div class="card-wrapper">
                        <div class="card card-bg">
                            <div class="card-body">
                                <div class="categoryicon-top">
                                    <svg class="icon">
                                                        <use href="/web/bootstrap-italia/svg/sprites.svg#it-arrow-right-circle"></use>
                                                    </svg>
                                    <span class="text">Checklist istruttoria ammissibilità</span>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12" id="btnCard3" runat="server">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3" id="card4" runat="server" visible="false">
                    <!--start card-->
                    <div class="card-wrapper">
                        <div class="card card-bg">
                            <div class="card-body">
                                <div class="categoryicon-top">
                                    <svg class="icon">
                                                        <use href="/web/bootstrap-italia/svg/sprites.svg#it-arrow-right-circle"></use>
                                                    </svg>
                                    <span class="text">Valutazione del bando</span>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12" id="btnCard4" runat="server">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3" id="card5" runat="server" visible="false">
                    <!--start card-->
                    <div class="card-wrapper">
                        <div class="card card-bg">
                            <div class="card-body">
                                <div class="categoryicon-top">
                                    <svg class="icon">
                                                        <use href="/web/bootstrap-italia/svg/sprites.svg#it-arrow-right-circle"></use>
                                                    </svg>
                                    <span class="text">Protocolla gli allegati</span>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12" id="btnCard5" runat="server">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    <div class="col-sm-12" id="tdFase2" runat="server"></div>
    </div>
</asp:Content>
