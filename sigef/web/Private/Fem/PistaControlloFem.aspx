<%@ Page Title="" Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true" CodeBehind="PistaControlloFem.aspx.cs" Inherits="web.Private.Fem.PistaControlloFem" %>

<%@ Register Src="../../CONTROLS/SiarNewTab.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>

<%@ Register Src="../../CONTROLS/SNCUploadFileControl.ascx" TagName="SNCUploadFileControl"
    TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">
    <script type="text/javascript">

        function selezionaBando(id, elem) {
            if (elem.checked == false) {
                $('[id$=hdnIdBando]').val('');

            }
            else {
                $('[id$=hdnIdBando]').val(id);
            }
            $('[id$=hdnIdProgetto]').val('');
            $('[id$=btnPost]').click();
        }

        function selezionaProgetto(id, elem) {
            if (elem.checked == false) {
                $('[id$=hdnIdProgetto]').val('');
            }
            else {
                $('[id$=hdnIdProgetto]').val(id);
            }
            $('[id$=btnPost]').click();
        }

        function changeTipoInserimento() {
            var radiovalue = $('[id$=rblTipoVoce]').find(":checked").val();

            if (radiovalue == "1") {
                $('[id$=divSegnatura]').hide();
                $('[id$=divDecreto]').show();
                $('[id$=divLink]').hide();
                $('[id$=divTesto]').hide();
                $('[id$=divImmagine]').hide();
                $('[id$=divSigef]').hide();
            }
            else if (radiovalue == "2") {
                $('[id$=divSegnatura]').hide();
                $('[id$=divDecreto]').hide();
                $('[id$=divLink]').show();
                $('[id$=divTesto]').hide();
                $('[id$=divImmagine]').hide();
                $('[id$=divSigef]').hide();
            }
            else if (radiovalue == "3") {
                $('[id$=divSegnatura]').hide();
                $('[id$=divDecreto]').hide();
                $('[id$=divLink]').hide();
                $('[id$=divTesto]').show();
                $('[id$=divImmagine]').hide();
                $('[id$=divSigef]').hide();
            }
            else if (radiovalue == "4") {
                $('[id$=divSegnatura]').hide();
                $('[id$=divDecreto]').hide();
                $('[id$=divLink]').hide();
                $('[id$=divTesto]').hide();
                $('[id$=divImmagine]').show();
                $('[id$=divSigef]').hide();
            }
            else if (radiovalue == "5") {
                $('[id$=divSegnatura]').hide();
                $('[id$=divDecreto]').hide();
                $('[id$=divLink]').hide();
                $('[id$=divTesto]').hide();
                $('[id$=divImmagine]').hide();
                $('[id$=divSigef]').show();
            }
            else {
                $('[id$=divSegnatura]').show();
                $('[id$=divDecreto]').hide();
                $('[id$=divLink]').hide();
                $('[id$=divTesto]').hide();
                $('[id$=divImmagine]').hide();
                $('[id$=divSigef]').hide();
            }
        }

        function readyFn(jQuery) {
            $('[id$=rblTipoVoce]').change(changeTipoInserimento);
            $('[id$=rblTipoVoce]').change();
        }

        function pageLoad() {
            readyFn();
        }

        function VerificaDati(ev) {

            if ($('[id$=lstTipoPistaLiv1]').find(":selected").val() == "") { alert('Per proseguire è necessario selezionare la tipologia.'); return stopEvent(ev); }
            if ($('[id$=lstTipoPistaLiv2]').find(":selected").val() == "") { alert('Per proseguire è necessario selezionare il dettaglio della tipologia.'); return stopEvent(ev); }
            if ($('[id$=txtDescrizione]').val() == "") { alert('Per proseguire è necessario specificare la descrizione.'); return stopEvent(ev); }
            if ($('[id$=txtOrdine]').val() == "") { alert('Per proseguire è necessario specificare l ordine.'); return stopEvent(ev); }

            var radiovalue = $('[id$=rblTipoVoce]').find(":checked").val();

            if (radiovalue == "1") {
                if ($('[id$=txtAttoNumero]').val() == "") { alert('Per proseguire è necessario specificare il numero del decreto/delibera.'); return stopEvent(ev); }
                if ($('[id$=txtAttoData]').val() == "") { alert('Per proseguire è necessario specificare la data del decreto/delibera.'); return stopEvent(ev); }
                if (($('[id$=lstAttoDefinizione]').find(":selected").val() == "D") && ($('[id$=lstAttoRegistro]').find(":selected").val() == "")) { alert('Per proseguire è necessario specificare il registro del decreto/delibera.'); return stopEvent(ev); }
            }
            else if (radiovalue == "2") {
                if ($('[id$=txtTestoLink]').val() == "") { alert('Per proseguire è necessario specificare il testo del link.'); return stopEvent(ev); }
                if ($('[id$=txtLink]').val() == "") { alert('Per proseguire è necessario specificare il link.'); return stopEvent(ev); }
            }
            else if (radiovalue == "3") {
                if ($('[id$=txtTesto]').val() == "") { alert('Per proseguire è necessario specificare il testo.'); return stopEvent(ev); }
            }
            else if (radiovalue == "4") {
                if ($('[id$=ufImmagine_hdnSNCUFUploadFile]').val() == "") { alert('Per proseguire è necessario specificare il file dell immagine.'); return stopEvent(ev); }
            }
            else if (radiovalue == "5") {
                if ($('[id$=txtQuery]').val() == "") { alert('Per proseguire è necessario inserire la query.'); return stopEvent(ev); }
            }
            else {
                if ($('[id$=txtSegnatura]').val() == "") { alert('Per proseguire è necessario specificare la segnatura.'); return stopEvent(ev); }
            }
        }
        function SelezionaVoce(id) {
            $('[id$=hdnIdPistaControllo]').val(id);
            
            swapTab(2);
        }

        function StampaReport(tipo) {
            var idProgetto = $('[id$=hdnIdProgetto]').val();

            var param = "IdProgetto=" + idProgetto;
            SNCVisualizzaReport('rptPistaControlloFem', tipo, param );
        }

        //function StampaReportXls() {
        //    var idProgetto = $('[id$=hdnIdProgetto]').val();

        //    var param = "IdProgetto=" + idProgetto;
        //    SNCVisualizzaReport('rptPistaControlloFem', 2, param);
        //}

    </script>
    <style type="text/css">
        h1 {
            display: block;
            font-size: 2em;
            margin-top: 0.67em;
            margin-bottom: 0.67em;
            margin-left: 10px;
            margin-right: 0;
            font-weight: bold;
        }
        td.SNTEnd {
            background-color: #E6E6EE;
        }
        .first_elem_block {
            /*width: 200px;*/
            display: inline-block;
            *display: inline;
            zoom: 1;
            padding-bottom: 5px;
        }

        .elem_block {
            /*width: 200px;*/
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

        .label {
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

        table.elenco
        {
            width: 100%;
            border: 2px solid #89BBDB;
            border-collapse: collapse;
        }
        td.elenco
        {
            width: 55%;
            padding: 5px;
            border: 2px solid #89BBDB;
        }
        td.voce
        {
            width: 35%;
            padding: 5px;
            border: 2px solid #89BBDB;
        }
        td.modifica
        {
            width: 10%;
            padding: 5px;
            border: 2px solid #89BBDB;
        }
        td.edata
        {
            width: 10%;
            padding: 5px;
            border: 2px solid #89BBDB;
            text-align: center;
        }
        input.elenco
        {
            width: 20px;
            height: 20px;
            cursor: pointer;
            padding-left: 10px;
            padding-right: 10px;
        }
        imageButton.elenco, image.elenco
        {
            width: 20px;
            height: 20px;
            cursor: pointer;
            padding-left: 10px;
            padding-right: 10px;
        }
        label.elenco
        {
            padding-left: 10px;
            padding-right: 10px;
        }

        .nascondi {
            display: none;
            width: 2px;
        }
    </style>
    
    <div style="display: none">
        <asp:HiddenField ID="hdnIdBando" runat="server" />     
        <asp:HiddenField ID="hdnIdProgetto" runat="server" />
        <asp:HiddenField ID="hdnIdPistaControllo" runat="server" />
        
        <asp:Button ID="btnPost" runat="server" OnClick="btnPost_Click" />
    </div>
    <div style="text-align:center">
        <h1>Pista di Controllo</h1>
    </div>
    <div class="dBox" style="padding:20px" runat="server">
        <Siar:DataGrid ID="dgBandi" runat="server" Width="100%" PageSize="20" AllowPaging="True"
            AutoGenerateColumns="False" ShowFooter="false">
            <ItemStyle Height="28px" />
                <FooterStyle CssClass="coda" HorizontalAlign="Right" />
                <Columns>
                    <asp:BoundColumn DataField="IdBando" HeaderText="ID">
                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Descrizione" HeaderText="Oggetto">
                        <ItemStyle HorizontalAlign="left" Width="500px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Importo" HeaderText="Importo" HeaderStyle-HorizontalAlign="Right" >
                        <ItemStyle HorizontalAlign="Right" Width="80px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Nominativo" HeaderText="RUP">
                        <ItemStyle HorizontalAlign="left" Width="100px" />
                    </asp:BoundColumn>
                    <Siar:CheckColumn DataField="IdBando" Name="chkIdBando">
                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                    </Siar:CheckColumn>
                </Columns>
        </Siar:DataGrid>
    </div>
    <div class="dBox" id="divProg" style="padding:20px" runat="server">
        <Siar:DataGrid ID="dgProgetti" runat="server" Width="100%" PageSize="20" AllowPaging="True"
            AutoGenerateColumns="False" ShowFooter="false">
            <ItemStyle Height="28px" />
                <FooterStyle CssClass="coda" HorizontalAlign="Right" />
            <Columns>
                <asp:BoundColumn DataField="IdProgetto" HeaderText="ID Progetto">
                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                </asp:BoundColumn>
                <asp:BoundColumn  HeaderText="Ragione Sociale">
                    <ItemStyle HorizontalAlign="left" Width="500px" />
                </asp:BoundColumn>
                <asp:BoundColumn  HeaderText="Importo" HeaderStyle-HorizontalAlign="Right" >
                    <ItemStyle HorizontalAlign="Right" Width="80px" />
                </asp:BoundColumn>
                <Siar:CheckColumn DataField="IdProgetto" Name="chkIdProgetto">
                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                </Siar:CheckColumn>
            </Columns>
        </Siar:DataGrid>

    </div>
    <div class="dBox" id="divTab" style="padding:20px" runat="server">
        <uc1:SiarNewTab ID="ucSiarNewTab" runat="server" TabNames="SF A REGIA|Voce"  />
        <div id="divPista"  runat="server" style="padding:10px; border:1px solid grey ;border-radius:5px">
            <input id="btnEstrai" class="Button" onclick="return StampaReport(1);" style="width: 150px"
                                    type="button" value="Stampa PDF" />
            <input id="btnEstraiXLS" class="Button" onclick="return StampaReport(2);" style="width: 150px"
                                    type="button" value="Stampa XLS" />
            <br /><br />
            <%--<h2 style="font-size:larger" ><b><Siar:Label id="txtTitolo"  runat="server" ></Siar:Label></h2></b> 
            <br />--%>
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
            <asp:Label ID="lbAzienda" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lbProgetto" runat="server"></asp:Label>
            <br />
            <br />
            
            <asp:Repeater ID="rptTipoLiv1" OnItemDataBound="rptTipoLiv1_ItemDataBound"  runat="server">
                <ItemTemplate>
                    <div class="separatore" style="height:25px">
                        <asp:Label Font-Size="Medium" Text=<%# Eval("Descrizione")%> Font-Bold="true" runat="server" ID="lbTitoloLiv2" ></asp:Label>
                    </div>
                    <asp:Repeater ID="rptTipoLiv2" OnItemDataBound="rptTipoLiv2_ItemDataBound"  runat="server">
                        <ItemTemplate>
                            <div style="text-align-last:center;padding-top:5px" >
                                <asp:Label Font-Size="Medium" Font-Bold="true" runat="server" ID="lbTitoloLiv2" ></asp:Label>
                            </div>
                            <Siar:DataGrid ID="dgPista" runat="server" Width="100%"  AllowPaging="false"
                            AutoGenerateColumns="False" ShowFooter="false">
                                <ItemStyle Height="40px" />
                                <Columns>
                                    <asp:BoundColumn DataField="Descrizione" >
                                        <ItemStyle  HorizontalAlign="Left" Width="40%" />
                                        <HeaderStyle CssClass="nascondi"  />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn>
                                        <ItemStyle HorizontalAlign="Left" Width="45%" />
                                        <HeaderStyle CssClass="nascondi" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Ordine" >
                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                        <HeaderStyle CssClass="nascondi" />
                                    </asp:BoundColumn>
                                    <Siar:JsButtonColumn Arguments="IdPistaControllo" ButtonType="TextButton" ButtonText="Modifica" JsFunction="SelezionaVoce">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                        <HeaderStyle CssClass="nascondi" />
                                    </Siar:JsButtonColumn>
                                </Columns>
                            </Siar:DataGrid>                            
                            <br />
                        </ItemTemplate>
                     </asp:Repeater>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div id="divVoce"  runat="server" style="padding:10px; border:1px solid grey ;border-radius:5px">
            <h2 style="font-size:larger" ><b>Voce della Pista di Controllo</h2></b><br />
            <div class="first_elem_block">
                Tipologia della voce :<br />
                <Siar:ComboTipoPistaControlloFem ID="lstTipoPistaLiv1" runat="server" AutoPostBack="True"  Width="700px">
                </Siar:ComboTipoPistaControlloFem>
            </div>
            <div class="first_elem_block">
                Dettaglio della tipologia :<br />
                <Siar:ComboTipoPistaControlloFem ID="lstTipoPistaLiv2" runat="server" AutoPostBack="True"  Width="700px">
                </Siar:ComboTipoPistaControlloFem>
            </div>
            <div class="first_elem_block">
                Descrizione:<br />
                <Siar:TextArea ID="txtDescrizione" runat="server"  Rows="2" Width="700px"  ExpandableRows="10" />
            </div>
            <div></div>
            <div class="first_elem_block">
                Ordine:<br />
                <Siar:IntegerTextBox ID="txtOrdine" runat="server"  Width="100px"  />
            </div>
            <div class="elem_block">
                Data (solo per tipologia Programmazione):<br />
                <Siar:DateTextBox ID="txtData" runat="server"  Width="100px"  />
            </div>
            <div></div>
            <div class="first_elem_block">
                Tipo Voce
                <asp:RadioButtonList RepeatDirection="Horizontal" ID="rblTipoVoce" runat="server">
                <asp:ListItem Selected="True" Text="Segnatura" Value="0" />
                <asp:ListItem Text="Decreto/atto" Value="1" />
                <asp:ListItem Text="Link" Value="2" />
                <asp:ListItem Text="Testo" Value="3" />
                <asp:ListItem Text="Immagine" Value="4" />
                <asp:ListItem Text="SIGEF" Value="5"  />
            </asp:RadioButtonList>
            </div>
            <div id="divSegnatura" runat="server">
                <div class="first_elem_block">
                    Segnatura:<br />
                    <Siar:TextBox id="txtSegnatura" runat="server" Width ="500px" />
                </div>
            </div>
            <div id="divDecreto" runat="server">
               <div class="first_elem_block">
                    Definizione:<br />
                    <Siar:ComboDefinizioneAtto ID="lstAttoDefinizione" runat="server" NoBlankItem="True"
                        Width="80px">
                    </Siar:ComboDefinizioneAtto>
                </div>
                <div class="elem_block">
                    Numero:<br />
                    <Siar:IntegerTextBox NoCurrency="True" ID="txtAttoNumero" runat="server" Width="80px" NomeCampo="Numero decreto" />
                </div>
                <div class="elem_block">
                    Data:<br />
                    <Siar:DateTextBox ID="txtAttoData" runat="server" Width="100px" NomeCampo="Data decreto" />
                </div>
                <div class="elem_block">
                    Registro:<br />
                    <Siar:ComboRegistriAtto ID="lstAttoRegistro" runat="server" Width="100px">
                    </Siar:ComboRegistriAtto>
                </div>
            </div>
            <div id="divLink" runat="server">
                <div class="first_elem_block">
                    Testo:<br />
                    <Siar:TextBox id="txtTestoLink" runat="server" Width ="500px" />
                </div>
                <div class="elem_block">
                    Link:<br />
                    <Siar:TextBox id="txtLink" runat="server" Width ="500px" />
                </div>
            </div>
            <div id="divTesto" runat="server">
                <div class="first_elem_block">
                    Testo:<br />
                    <Siar:TextBox id="txtTesto" runat="server" Width ="500px" />
                </div>
            </div>
            <div id="divImmagine" runat="server">
                <div class="first_elem_block">
                    Caricare il file digitale:<br />
			        <uc2:SNCUploadFileControl ID="ufImmagine" runat="server" AbilitaModifica ="true"  TipoFile="Immagine"  />
                </div>
            </div>
            <div id="divSigef" runat="server">
                <div class="first_elem_block">
                    <b>SOLO PER AMMINISTRATORI DEL SISTEMA</b><br />
                    <div class="paragrafo_light">
                        NOTE: La select può restituire anche piu di una riga,ma devono esserci 2 Colonne :<br />
                        1° colonna: Impostare l'alias con 'Tipo' ed il valore ('Segnatura','Atto','File','Testo')<br />
                        2° colonna: Impostare l'alias con 'Valore'<br />
                        <br />
                        Query:<br />
                    </div>
                    <Siar:TextArea ID="txtQuery" runat="server" Width="750px" Rows="10" MaxLength="15000"/>
                </div>      
            </div>
            <div>
                <br />
            </div>
            <div>
                <div class="first_elem_block">
                    <Siar:Button ID="btnAggiungiVoce" runat="server" Width="220px" Text="Salva"
                    CausesValidation="False" OnClick="btnAggiungiVoce_Click" OnClientClick="return VerificaDati(event);"></Siar:Button> 
                </div>
                <div class="elem_block">
                    <Siar:Button ID="btnEliminaVoce" runat="server" Width="220px" Text="Elimina" Conferma="Si è sicuri di voler eliminare la voce?"
                    CausesValidation="False" OnClick="btnEliminaVoce_Click"></Siar:Button> 
                </div>
                <div class="elem_block">
                    <Siar:Button ID="btnNuovaVoce" runat="server" Width="220px" Text="Nuova"
                    CausesValidation="False" OnClick="btnNuovaVoce_Click"></Siar:Button> 
                </div>
            </div>
        </div>
    </div>
</asp:Content>
