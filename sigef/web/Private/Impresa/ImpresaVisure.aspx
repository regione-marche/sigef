<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true" Inherits="web.Private.Impresa.ImpresaVisure" CodeBehind="ImpresaVisure.aspx.cs" %>

<%@ Register Src="~/CONTROLS/SNCUploadFileControl.ascx" TagName="SNCUploadFileControl" TagPrefix="uc4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <style type="text/css">

        h1 {
            display: block;
            font-size: 22px;/*font-size: 2em;*/
            margin-top: 10px;/*margin-top: 0.67em;*/
            margin-bottom: 10px;/*margin-bottom: 0.67em;*/
            margin-left: 10px;
            margin-right: 0;
            font-weight: bold;
        }

        .first_elem_block {
            /*width: 250px;*/
            display: inline-block;
            *display: inline;
            zoom: 1;
            padding-bottom: 5px;
        }

        .elem_block {
            /*width: 250px;*/
            vertical-align: top;
            display: inline-block;
            *display: inline;
            zoom: 1;
            padding-left: 20px;
            padding-bottom: 5px;
        }

        .paragrafo_light {
            border-bottom: solid 1px #084600;
            font-size: 14px;
        }

        .box_ricerca {
            background-color: #cfcfd6; 
            padding: 7px;
        }

        label {
            display: inline;
            float: left;
            min-width: 200px;
            max-width: 200px;
            width: 200px;
            text-align: right;
            vertical-align: middle;
        }

        .value {
            float: right;
            margin-left: 5px;
        }

        .nascondi {
            display: none;
        }

    </style>

    <br />

    <div class="dBox" width="800px">
        <div class="separatore">
            GESTIONE VISURE DELL'IMPRESA
        </div>
       
        <div id="divInserimentoVisura" runat="server" style="padding: 15px;">
            <div class="paragrafo">
                Inserimento nuova visura
            </div>
            <br />

            <p>E' possibile inserire qui una nuova visura o un altro documento atto a verificare la veridicità dell'anagrafica dell'impresa.</p>
            <br />
            <br />

            <div class="first_elem_block" style="visibility:hidden;">
                <label>Data visura:</label>
                <div class="value">
                    <Siar:DateTextBox ID="txtDataVisura" runat="server" Width="100px" />
                </div>
            </div>
            <br />

            <div class="first_elem_block">
                <uc4:SNCUploadFileControl ID="ufNuovaVisura" runat="server" TipoFile="Documento" Modifica="True" />
            </div>            
            <br />

            <div class="first_elem_block">
                <Siar:Button ID="btnInserisciVisura" runat="server" CausesValidation="False" Width="200px"
                    OnClick="btnInserisciVisura_Click" Text="Inserisci la nuova visura" />
            </div>
            <br />
        </div>

       <%-- <div id="divVisuraAttuale" runat="server" style="padding: 15px;">
             <div class="paragrafo">
                Visura attuale
            </div>
            <br />

            <div class="first_elem_block">
                <uc4:SNCUploadFileControl ID="ufVisuraAttuale" runat="server" TipoFile="Documento" />
            </div>            
            <br />
        </div>--%>
        
        <div id="divElencoVisure" runat="server" style="padding: 15px;">
             <div class="paragrafo">
                Elenco visure
            </div>
            <br />

            <p>Elenco delle visure o degli atti dell'impresa ordinate per data visura in maniera decrescente.<br />
            La prima visura dell'elenco dall'alto sarà la più recente e verrà confrontata con i dati dell'anagrafica in fase istruttoria.
            </p>
            <br />
            <br />

            <Siar:DataGrid ID="dgElencoVisure" runat="server" Width="100%" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundColumn HeaderText="Data caricamento" DataField="DataVisura">
                        <ItemStyle Width="100px" HorizontalAlign="center"/>
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="File" DataField="IdFileVisura">
                        <ItemStyle Width="100px" HorizontalAlign="center"/>
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Nome file" DataField="NomeFile" >
                    </asp:BoundColumn>
                </Columns>
            </Siar:DataGrid>
        </div>
    </div>
</asp:Content>