<%@ Page Title="" Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true" CodeBehind="ModificaBando.aspx.cs" Inherits="web.Private.Gantt.ModificaBando" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">
    <link href="gantt.css" rel="stylesheet" type="text/css">
    <div class="Titolo2" style="padding: 10px; margin-left: 20px;">
        <br />
        <asp:Label ID="lblAsse" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblAzione" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblIntervento" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblBando" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblTipoOp" runat="server"></asp:Label>
    </div>
    <br />
    <div style="padding: 10px; margin-left: 20px;">
    
        <div class="row">
            <div class="col-15">
                <label for="edValorePrev">
                    Bando SIGEF:</label>
            </div>
            
        </div>
        <div class="row">
            <div class="col-25">
                <asp:DropDownList ID="edIdBandoSIGEF" runat="server" DataValueField="ID_BANDO" DataTextField="DESCRIZIONE" AppendDataBoundItems="true">
                    <asp:ListItem Value="" Text=""></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-10">
            </div>
        </div>
        <br />
        <br />    
    
        <div class="row">
            <div class="col-15">
                <label for="edValoreComplPrev">
                    Importo Complessivo previsto:</label>
            </div>
        </div>
        <div class="row">
            <div class="col-25">
                <asp:HiddenField runat="server" ID="HedValoreComplPrev" />
                <input type="text" pattern="-?\d+(,\d{1,2})?" runat="server" name="edValoreComplPrev"
                    id="edValoreComplPrev" />
            </div>
            <div class="col-10">
            </div>
        </div>
        <br />
        <br />
        <div class="row">
            <div class="col-15">
                <label for="edValorePrev">
                    Importo Fondo FESR:</label>
            </div>
        </div>
        <div class="row">
            <div class="col-25">
                <asp:HiddenField runat="server" ID="HedValorePrev" />
                <input type="text" pattern="-?\d+(,\d{1,2})?" runat="server" name="edValorePrev"
                    id="edValorePrev" />
            </div>
            <div class="col-10">
            </div>
        </div>
        <br />
        <br />
        <div class="row">
            <div class="col-15">
                <label for="edValoreFinanziato">
                    Importo Finanziato entro marzo 2018:</label>
            </div>
        </div>
        <div class="row">
            <div class="col-25">
                <asp:HiddenField runat="server" ID="HedValoreFinanziato" />
                <input type="text" pattern="-?\d+(,\d{1,2})?" runat="server" name="edValoreFinanziato"
                    id="edValoreFinanziato" />
            </div>
            <div class="col-10">
            </div>
        </div>
        <br />
        <br />
        <div class="row">
            <div class="col-15">
                <label for="edValoreCertificato">
                    Importo già certificato entro marzo 2018:</label>
            </div>
        </div>
        <div class="row">
            <div class="col-25">
                <asp:HiddenField runat="server" ID="HedValoreCertificato" />
                <input type="text" pattern="-?\d+(,\d{1,2})?" runat="server" name="edValoreCertificato"
                    id="edValoreCertificato" />
            </div>
            <div class="col-10">
            </div>
        </div>
        <br />
        <br />
        <div class="row">
            <div class="col-25" style="padding: 5px;">
                <a id="goBack" class="bottone bottoneCancel" href="ElencoBandi.aspx" style="float: left">
                    Indietro (Elenco Bandi)</a>
                <asp:LinkButton Style="float: left" CssClass="bottone bottoneOK" ID="bntSalvaBando"
                    runat="server" OnClick="SalvaBando_click">Salva</asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>
