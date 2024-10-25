<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    CodeBehind="AmmissibilitaAnagraficaVisura.aspx.cs" Inherits="web.Private.Istruttoria.AmmissibilitaAnagraficaVisura" %>

<%@ Register Src="../../CONTROLS/InfoDomanda.ascx" TagName="InfoDomanda" TagPrefix="uc1" %>
<%@ Register Src="../../CONTROLS/ImpresaControl.ascx" TagName="ImpresaControl" TagPrefix="uc4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <script type="text/javascript">

        function switchMostraVisureImpresa() {
            var div = $('[id$=divMostraVisure]');
            var btn = $('[id$=btnMostraVisure]')[0];

            if (div[0].style.display === "none") {
                div.show("fast");
                btn.value = "Nascondi visure impresa";
            } else {
                div.hide("fast");
                btn.value = "Mostra visure impresa";
            }
        }

    </script>
    <uc1:InfoDomanda ID="ucInfoDomanda" runat="server" />
    <nav class="breadcrumb-container" aria-label="Percorso di navigazione">
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a onclick="location='Ammissibilita.aspx'">
            <svg class="icon icon-breadcrumb icon-secondary align-top me-1" aria-hidden="true">
                <use href="/web/bootstrap-italia/svg/sprites.svg#it-check""></use>
            </svg>
            Ammissibilità</a><span class="separator">/</span></li>
        <li class="breadcrumb-item"><a onclick="history.back()">
            <svg class="icon icon-breadcrumb icon-secondary align-top me-1" aria-hidden="true">
                <use href="/web/bootstrap-italia/svg/sprites.svg#it-list""></use>
            </svg>
            Checklist d'istruttoria d'ammissibilità</a><span class="separator">/</span></li>
        <li class="breadcrumb-item active" aria-current="page">Ammissibilità dell'anagrafica</li>
    </ol>
    </nav>
    <div class="row py-5 mx-2">
        <div class="col-sm-12 text-end">
            <a id="btnAmmissibilita" runat="server" class="btn btn-secondary py-1">
                <svg class="icon icon-breadcrumb icon-secondary icon-white me-1" aria-hidden="true">
                            <use href="/web/bootstrap-italia/svg/sprites.svg#it-list"></use>
                        </svg>
                Torna alla checjklist di ammissibilità</a>
        </div>
        <h2 class="pb-5">Ammissibilità dell'anagrafica dell'impresa e delle visure
        </h2>
        <div class="col-sm-12">
            <input runat="server" id="btnMostraVisure" type="button" class="btn btn-secondary py-1" value="Mostra visure impresa"
                onclick="switchMostraVisureImpresa();" />
        </div>
        <div class="row" runat="server" id="divMostraVisure" style="display: none;">
            <h3 class="py-5">Elenco visure impresa</h3>
            <p>
                Elenco delle visure o degli atti dell'impresa ordinate per data visura in maniera decrescente.<br />
                La prima visura dell'elenco dall'alto sarà la più recente e verrà confrontata con i dati dell'anagrafica in fase istruttoria.
            </p>
            <div class="col-sm-12">
                <Siar:DataGridAgid ID="dgElencoVisure" CssClass="table table-striped" runat="server" Width="100%" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundColumn HeaderText="Data caricamento" DataField="DataVisura">
                            <ItemStyle Width="100px" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="File" DataField="IdFileVisura">
                            <ItemStyle Width="100px" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Nome file" DataField="NomeFile"></asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Istruita" DataField="Istruita"></asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Data istruttoria" DataField="DataIstruttoria"></asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Istruttore" DataField="NominativoIstruttore"></asp:BoundColumn>
                    </Columns>
                </Siar:DataGridAgid>
            </div>
        </div>
        <uc4:ImpresaControl ID="ucImpresaControl" runat="server" ClassificazioneUmaVisibile="True"
            ContoCorrenteVisibile="True" SalvaIstruttoria="True" />
        <div class="col-sm-12 text-end mt-5">
            <a id="btnAmmissibilitaDown" runat="server" class="btn btn-secondary py-1">
                <svg class="icon icon-breadcrumb icon-secondary icon-white me-1" aria-hidden="true">
                        <use href="/web/bootstrap-italia/svg/sprites.svg#it-list"></use>
                    </svg>
                Torna alla checklist di ammissibilità</a>
        </div>
    </div>
</asp:Content>
