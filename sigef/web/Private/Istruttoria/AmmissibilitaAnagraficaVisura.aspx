<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    CodeBehind="AmmissibilitaAnagraficaVisura.aspx.cs" Inherits="web.Private.Istruttoria.AmmissibilitaAnagraficaVisura" %>

<%@ Register Src="../../CONTROLS/InfoDomanda.ascx" TagName="InfoDomanda" TagPrefix="uc1" %>
<%@ Register Src="../../CONTROLS/ImpresaControl.ascx" TagName="ImpresaControl" TagPrefix="uc4" %>

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

    <br />
    <uc1:InfoDomanda ID="ucInfoDomanda" runat="server" />
    <br />

    <div class="dBox" width="1050px">
        <div class="separatore">
            Ammissibilità dell'anagrafica dell'impresa e delle visure
        </div>
        <br />

        <div style="padding:5px;">
            <div class="first_elem_block">
                <input id="btnAmmissibilita" runat="server" type="button" class="Button"
                    value="Indietro" style="width: 160px" />
            </div>
            
            <div class="elem_block">
                <input runat="server" id="btnMostraVisure" type="button" style="width:220px" 
                    class="ButtonGrid" value="Mostra visure impresa"
                    onclick="switchMostraVisureImpresa();"
                />
            </div>
            <br />
            <br />

            <div runat="server" id="divMostraVisure" style="display: none; width: 800px; padding:5px;" >
                <div class="separatore" >
                    Elenco visure impresa
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
                         <asp:BoundColumn HeaderText="Istruita" DataField="Istruita" >
                         </asp:BoundColumn>
                         <asp:BoundColumn HeaderText="Data istruttoria" DataField="DataIstruttoria" >
                         </asp:BoundColumn>
                         <asp:BoundColumn HeaderText="Istruttore" DataField="NominativoIstruttore" >
                         </asp:BoundColumn>
                     </Columns>
                 </Siar:DataGrid>
            </div>

            <uc4:ImpresaControl ID="ucImpresaControl" runat="server" ClassificazioneUmaVisibile="True"
                ContoCorrenteVisibile="True" SalvaIstruttoria="True" />
        </div>
        
    </div>

</asp:Content>
