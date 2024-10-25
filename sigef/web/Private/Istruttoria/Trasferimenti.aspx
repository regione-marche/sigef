<%@ Page Title="" Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true" CodeBehind="Trasferimenti.aspx.cs" Inherits="web.Private.Istruttoria.Trasferimenti" %>
<%@ Register Src="../../CONTROLS/SNCUploadFileControl.ascx" TagName="SNCUploadFileControl"
    TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">
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

        .first_elem_block {
            padding-left: 25px;
            width: 200px;
            display: inline-block;
            *display: inline;
            zoom: 1;
            padding-bottom: 5px;
        }

        .first_elem_block2 {
            padding-left: 25px;
            width: 100%;
            display: inline-block;
            *display: inline;
            zoom: 1;
            padding-bottom: 5px;
        }

        .elem_block {
            width: 200px;
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
    </style>
    <script type="text/javascript">
        function ctrlCuaaDitta() {
            var text_box_cuaa=$('[id$=txtCuaaRicerca_text]');var cuaa=$(text_box_cuaa).val().replace(/\s/g,'');
            if(cuaa!=null&&cuaa!=""&&!ctrlCodiceFiscale(cuaa)&&!ctrlPIVA(cuaa)) {
                alert('Attenzione! Il Codice Fiscale inserito per la ricerca della ditta non è valido.');
            }
        }


       
        function ctrlCampiRicercaNormeMarche(ev) { if ($('[id$=txtAttoNumero_text]').val() == "" || $('[id$=txtAttoData_text]').val() == "" || $('[id$=lstAttoRegistro]').val() == "") { alert('Per la ricerca degli atti è necessario specificare numero, data e registro.'); return stopEvent(ev); } }

        function ctrlTipoAtto(ev) {
            if ($('[id$=hdnIdAtto]').val() == "") { alert('Per proseguire è necessario specificare un atto.'); return stopEvent(ev); }
            else if ($('[id$=lstAttoTipo]').val() == "") { alert('Per proseguire è necessario specificare la tipologia dell`atto.'); }
            else if ($('[id$=txtAttoImporto]').val() == "") { alert('Per proseguire è necessario specificare l`importo dell`atto.');  return stopEvent(ev);
        }
            if (!confirm("Si sta per inserire il decreto di pagamento per la domanda selezionata. Continuare?")) return stopEvent(ev);
        } 

        function selezionaTrasferimento(erog) {
            $('[id$=hdnIdTrasferimento]').val(erog);   
            $('[id$=hdnIdTrasferimentoMandato]').val('');
            $('[id$=btnSelezionaTrasf]').click();
        }

        function MostraNascondiDiv(id) {
            var div;
            var img;
            switch (id) {
                case 0:
                    div = $('[id$=divMostraTrasf_new]');
                    img = $('[id$=imgTrasf_new]')[0];
                    break;
                case 1:
                    div = $('[id$=divMostraProgetti]');
                    img = $('[id$=imgProgetti]')[0];
                    break;
                case 2:
                    div = $('[id$=divMostraBandi]');
                    img = $('[id$=imgdivBandi]')[0];
                    break;


                
            }

            if (img.style.transform == "")
                img.style.transform = "rotate(180deg)";
            else
                img.style.transform = "";

            //if (div.style.display === "none") {
            //    div.style.display = "block";
            //} else {
            //    div.style.display = "none";
            //}
            if (div[0].style.display === "none") {
                div.show("fast");
            } else {
                div.hide("fast");
            }
        }

        
        function visualizzaTraferimento(id) {
            
            $('[id$=hdnIdTrasferimento]').val($('[id$=hdnIdTrasferimento]').val() == id ? '' : id);
            $('[id$=hdnIdTrasferimentoMandato]').val('');
            $('[id$=btnPost]').click();
        }
            
        function selezionaMandato(id) {
            $('[id$=hdnIdTrasferimentoMandato]').val(id);
            $('[id$=btnPostNull]').click();
        }

        function ctrlMandato(ev) { if ($('[id$=txtMandatoData_text]').val() == "" || $('[id$=txtMandatoImporto_text]').val() == "" || $('[id$=txtMandatoNumero_text]').val() == "" || $('[id$=ufMandato_hdnSNCUFUploadFile]').val() == "") { alert('Per proseguire è necessario specificare numero, data, importo e file digitale del mandato.'); return stopEvent(ev); } }

    </script>


     <div style="display: none">
        <asp:HiddenField ID="hdnIdImpresa" runat="server" />     
        <asp:HiddenField ID="hdnIdTrasferimento" runat="server" />    
        <asp:HiddenField ID="hdnIdTrasferimentoMandato" runat="server" /> 
        <asp:HiddenField ID="hdnIdAtto" runat="server" />     
        <asp:Button ID="btnPost" CausesValidation="false" runat="server" OnClick="btnPost_Click" />
        <asp:Button ID="btnPostNull" CausesValidation="false" runat="server" OnClick="btnPostNull_Click" />


     <%--   <asp:Button ID="btnPost" runat="server" OnClick="btnPost_Click" />
     <asp:Button ID="btnPost2" runat="server" OnClick="btnPost2_Click" />
        <asp:Button ID="btnSelezionaProgetto" runat="server" OnClick="btnSelezionaProgetto_Click" />--%>

        <asp:Button ID="btnSelezionaTrasf" runat="server" OnClick="btnSelezionaTrasf_Click" />
    </div>

    <div class="dBox" id="divRicerca" visible="true" runat="server">

        <div class="separatore" style="padding-bottom: 3px;">
            Inserimento dei trasferimenti ad enti pubblici / organismi intermedi
        </div>
        <div>
            <div class="first_elem_block"><br /> 
                <b>Ricerca per CF/P.IVA:</b> <br /> 
                 <Siar:TextBox ID="txtCuaaRicerca" runat="server" Obbligatorio="true" NomeCampo="Partita iva/Codice fiscale"
                            Width="150px" Style="text-align: left" />
            </div>
            <br />
            <div class="first_elem_block">
                <br />
                <Siar:Button ID="btnCercaDB" runat="server" Width="220px" Text="Cerca sul database locale"
                        CausesValidation="False" OnClick="btnCercaDB_Click"></Siar:Button>
            </div>
            <table cellpadding="0" cellspacing="0" style="width: 100%;padding-left:25px">
                <tr>
                    <td style="width: 160px">
                        <br />
                        &nbsp; Codice Fiscale:<br />
                        <Siar:TextBox ID="txtCuaa" runat="server" ReadOnly="True" Width="140px" TextAlign="right" />
                    </td>
                    <td style="width: 160px">
                        <br />
                        &nbsp; P.Iva:<br />
                        <Siar:TextBox ID="txtPiva" runat="server" ReadOnly="True" Width="140px" TextAlign="right" />
                    </td>
                    <td style="width: 500px">
                        <br />
                        &nbsp; Ragione sociale:<br />
                         <Siar:TextBox ID="txtRagioneSociale" runat="server" ReadOnly="True" Width="450px" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
            </table>
            <table width="100%" visible="false" id="tbImpresa" runat="server" style="padding-left:15px;padding-right:15px">
                <tr>
                    <td class="separatore">
                        Elenco dei Trasferimenti:
                    </td>
                </tr>
                <tr>
                    <td >
                        <Siar:DataGrid ID="dgTrasferimenti" runat="server" Width="100%"  AllowPaging="false"
                            AutoGenerateColumns="False" ShowFooter="true">
                            <ItemStyle Height="28px" />
                                <FooterStyle CssClass="coda" HorizontalAlign="Right" />
                            <Columns>
                                <asp:BoundColumn DataField="IdTrasferimento" HeaderText="ID">
                                    <ItemStyle HorizontalAlign="Center" Width="20px" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Numero" HeaderText="Numero Decreto">
                                    <ItemStyle HorizontalAlign="Center" Width="80px" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Data" HeaderText="Data Decreto">
                                    <ItemStyle HorizontalAlign="Center" Width="80px" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Registro" HeaderText="Registro">
                                    <ItemStyle HorizontalAlign="Center" Width="80px" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Importo" HeaderText="Importo" HeaderStyle-HorizontalAlign="Right" >
                                    <ItemStyle HorizontalAlign="Right" Width="80px" />
                                </asp:BoundColumn>
                                <asp:BoundColumn  HeaderText="Causale Trasferimento">
                                    <ItemStyle HorizontalAlign="Left" Width="150px" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Nominativo" HeaderText="Operatore Inserimento">
                                    <ItemStyle HorizontalAlign="Center" Width="150px" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Importo Mandati">
					                <ItemStyle HorizontalAlign="Right" Width="150px" />
				                </asp:BoundColumn>
                                <asp:BoundColumn  HeaderText="Importo Quietanza">
					                <ItemStyle HorizontalAlign="Right" Width="150px" />
				                </asp:BoundColumn>
                                <Siar:JsButtonColumn Arguments="IdTrasferimento" ButtonType="TextButton" ButtonText="Seleziona" JsFunction="visualizzaTraferimento" HeaderText="Visualizza">
                                    <ItemStyle HorizontalAlign="Center" Width="120px" />
                                </Siar:JsButtonColumn>
                            </Columns>
                        </Siar:DataGrid>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <Siar:Button ID="btnInserisciNew" runat="server" Width="220px" Text="Inserisci nuovo trasferimento"
                        CausesValidation="False" OnClick="btnInserisciNew_Click"></Siar:Button>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div class="dBox" id="divTrasf_new"  runat="server">
        <div class="separatore" style="padding-bottom: 3px; cursor: pointer;" onclick="MostraNascondiDiv(0); return false;">
            <img id="imgTrasf_new" runat="server" style="width: 23px; height: 23px;" />
            Trasferimento:
        </div>
        <div  id="divMostraTrasf_new">
            <div class="first_elem_block"><br /> 
                <table width="100%" id="tbTrasf_new" visible="false" runat="server">
                    <tr>
                        <td >
                            <table width="100%">
                                <tr>
                                    <td style="width: 100px">
                                        Definizione:<br />
                                        <Siar:ComboDefinizioneAtto ID="lstAttoDefinizione" runat="server" NoBlankItem="True"
                                            Width="80px">
                                        </Siar:ComboDefinizioneAtto>
                                    </td>
                                    <td style="width: 100px">
                                        Numero:<br />
                                        <Siar:IntegerTextBox NoCurrency="True" ID="txtAttoNumero" runat="server" Width="80px" NomeCampo="Numero decreto" />
                                    </td>
                                    <td style="width: 120px">
                                        Data:<br />
                                        <Siar:DateTextBox ID="txtAttoData" runat="server" Width="100px" NomeCampo="Data decreto" />
                                    </td>
                                    <td style="width: 146px">
                                        Registro:<br />
                                        <Siar:ComboRegistriAtto ID="lstAttoRegistro" runat="server" Width="100px">
                                        </Siar:ComboRegistriAtto>
                                    </td>
                                    <td style="width: 150px">
                                        <br />
                                        <Siar:Button ID="btnCercaDecreto" runat="server" OnClick="btnCercaDecreto_Click"
                                            Text="Ricerca" Width="100px" OnClientClick="return ctrlCampiRicercaNormeMarche(event);" />
                                    </td>
                                    <td style="width: 260px">
                                        Organo Istituzionale:<br />
                                        <Siar:ComboOrganoIstituzionale ID="lstAttoOrgIstituzionale" runat="server" Width="210px"
                                            Enabled="False">
                                        </Siar:ComboOrganoIstituzionale>
                                    </td>
                                    <td>
                                        Tipo atto:<br />
                                        <Siar:ComboTipoAtto ID="lstAttoTipo" runat="server" NomeCampo="Tipo Atto">
                                        </Siar:ComboTipoAtto>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table style="width: 100%">
                                <tr>
                                    <td style="width: 1000px">
                                        Descrizione:<br />
                                        <Siar:TextArea ID="txtAttoDescrizione" runat="server" Width="600px" ReadOnly="True"
                                            Rows="4" ExpandableRows="5"></Siar:TextArea>
                                    </td>

                                    <td style="width: 450px;padding-left:25px">
                                        <table >
                                            <tr>
                                                <td class="paragrafo" colspan="2">
                                                    Pubblicazione B.U.R.
                                                </td>
                                                <td rowspan="2">
                                                    <br />
                                                    <br />
                                                    <input id="btnVidualizzaDecreto" runat="server" class="Button" style="width: 130px;
                                                        margin-left: 30px; margin-right: 20px" type="button" disabled="disabled" value="Visualizza atto" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 150px">
                                                    Numero:<br />
                                                    <Siar:IntegerTextBox ID="txtAttoBurNumero" runat="server" Width="120px" ReadOnly="True" />
                                                </td>
                                                <td style="width: 150px">
                                                    Data:<br />
                                                    <Siar:DateTextBox ID="txtAttoBurData" runat="server" Width="120px" ReadOnly="True" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>                                
                                <tr>
                                    <td colspan="3">
                                        <br />
                                        <table>
                                            <tr>
                                                <td class="paragrafo" colspan="3">
                                                    Dati del trasferimento
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Causale trasferimento:<br>
                                                    <asp:DropDownList ID="ddlCausale" AutoPostBack="True" runat="server">
                                                        <asp:ListItem Selected="True" Value="1">Trasferimento a titolo di anticipazione</asp:ListItem>
                                                        <asp:ListItem Value="2">Trasferimento intermedio</asp:ListItem>
                                                        <asp:ListItem Value="3">Trasferimento a saldo</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 10px">

                                                </td>
                                                <td style="width: 200px">
												    Importo €:<br />
												    <Siar:CurrencyBox ID="txtAttoImporto" runat="server" Width="160px" />
											    </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan ="3">
                                        <br />
                                        <Siar:Button ID="btnAssociaDecreto" runat="server" OnClick="btnAssociaDecreto_Click"
                                                        Text="Associa decreto" Width="220px" Modifica="True" OnClientClick="return ctrlTipoAtto(event);" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
 

            </div>
            <div  style="padding-left: 25px;padding-right: 25px; padding-bottom: 25px; ">
               <div id="divMostraMandati" visible="false" runat="server" style="width:100%" ><br />
	                <div class="paragrafo_light">
		                Elenco dei mandati del trasferimento:
	                </div>

	                <div style="width:100%" ><br />
		                <Siar:DataGrid ID="dgTrasferimentoMandato" runat="server" AllowPaging="True" AutoGenerateColumns="False"
		                PageSize="15" Width="100%"  ShowFooter="true" >
			                <ItemStyle Height="28px" />
			                <FooterStyle CssClass="coda" HorizontalAlign="Right" />
			                <Columns>
				                <Siar:ColonnaLink  LinkFields="IdTrasferimentoMandato" LinkFormat="javascript:selezionaMandato({0});" 
					                DataField="IdTrasferimentoMandato" ItemStyle-Width = "20px">
				                </Siar:ColonnaLink>
				                <asp:BoundColumn DataField="MandatoNumero" HeaderText="Numero">
					                <ItemStyle HorizontalAlign="Center" Width="150px" />
				                </asp:BoundColumn>
				                <asp:BoundColumn DataField="MandatoData" HeaderText="Data">
					                <ItemStyle HorizontalAlign="Center" Width="150px" />
				                </asp:BoundColumn>
				                <asp:BoundColumn DataField="MandatoImporto" HeaderText="Importo">
					                <ItemStyle HorizontalAlign="Right" Width="150px" />
				                </asp:BoundColumn>
				                <asp:BoundColumn >
					                <ItemStyle HorizontalAlign="Center" Width="50px" />
				                </asp:BoundColumn>
				                <asp:BoundColumn DataField="QuietanzaData" HeaderText="Data">
					                <ItemStyle HorizontalAlign="Center" Width="150px" />
				                </asp:BoundColumn>
				                <asp:BoundColumn DataField="QuietanzaImporto" HeaderText="Importo">
					                <ItemStyle HorizontalAlign="Right" Width="150px" />
				                </asp:BoundColumn>
			                </Columns>
		                </Siar:DataGrid>
	                </div>
	                <div>
		                <br />
		                <Siar:Button ID="btnNuovoMandato" runat="server" OnClick="btnNuovoMandato_Click"
			                Text="Aggiungi nuovo mandato" Width="220px"  />
	                </div>
	                <div runat="server" visible="false" id="divMandato">
		                <div class="paragrafo_light">
		                <br />Dettaglio del mandato:<br />
		                </div>
		                <br /> 
		                <div class="first_elem_block">
			                <b>Caricare il file digitale:</b><br />
			                <uc1:SNCUploadFileControl ID="ufMandato" runat="server" AbilitaModifica ="true" TipoFile="Documento"  />
		                </div>
		                <br /> 
		                <div class="first_elem_block">
			                 <b>Data:</b><br />
			                <Siar:DateTextBox ID="txtMandatoData" runat="server" Width="120px" />
		                </div>
		                <div class="elem_block">
			                 <b>Importo €:</b><br />
			                <Siar:CurrencyBox ID="txtMandatoImporto" runat="server" Width="160px" />
		                </div>
		                <div class="elem_block">
			                 <b>Numero:</b><br />
			                <Siar:TextBox ID="txtMandatoNumero" runat="server" Width="160px" />
		                </div>
		                <div class="paragrafo_light">
		                <br />Dettaglio della quietanza:<br />
		                </div>
		                <br /> 
		                <div class="first_elem_block">
			                 <b>Data:</b><br />
			                <Siar:DateTextBox ID="txtQuietanzaData" runat="server" Width="120px" />
		                </div>
		                <div class="elem_block">
			                 <b>Importo €:</b><br />
			                <Siar:CurrencyBox ID="txtQuietanzaImporto" runat="server" Width="160px" />
		                </div>
		                <br />
		                <br />
		                <div class="elem_block">
			                <Siar:Button ID="btnSalvaMandato" runat="server" OnClick="btnSalvaMandato_Click"
			                Text="Salva" Width="220px" OnClientClick="return ctrlMandato(event);"  />
		                </div>
		                <div class="elem_block" >
			                <Siar:Button ID="btnEliminaMandato" runat="server" OnClick="btnEliminaMandato_Click"
			                Text="Elimina" Width="220px"  Conferma="Sei sicuro di voler eliminare il mandato?"
				                />
		                </div>
		 
																		 
	                </div>
                </div>
            </div>
        </div>
    </div>
    <div class="dBox" id="divProgetti" visible="false" runat="server"> 
        <div class="separatore" style="padding-bottom: 3px; cursor: pointer;" onclick="MostraNascondiDiv(1); return false;"> 
            <img id="imgProgetti" runat="server" style="width: 23px; height: 23px;" /> 
            Elenco dei progetti collegati al trasferimento selezionato: 
        </div> 
        <div id="divMostraProgetti" width="100%"  style="padding:25px;"> 
            <div  style="width:100%" ><br /> 
                <Siar:DataGrid ID="dgTrasfDettaglioProgetti" Width ="100%"  runat="server" PageSize="20" AllowPaging="True"
                    AutoGenerateColumns="False" ShowFooter="true" >
                    <ItemStyle Height="28px" />
                        <FooterStyle CssClass="coda" HorizontalAlign="Right" />
                    <Columns>
                        <asp:BoundColumn DataField="IdProgetto" HeaderText="Num. Progetto">
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn  HeaderText="Bando">
                            <ItemStyle HorizontalAlign="Left" Width="200px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn  HeaderText="Stato Progetto">
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn  HeaderText="Operatore Inserimento">
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid> 
            </div> 
            <br /> 
            <div > 
                <b><br />&nbsp;ID Progetto:</b>
                <Siar:IntegerTextBox ID="txtIdProgetto" runat="server" NomeCampo="ID Progetto"
                    Width="150px" Style="text-align: left"  NoCurrency="true" /> 
                <br /><br /> 
                <Siar:Button ID="btnAggiungiProgetto" runat="server" Width="220px" Text="Aggiungi Progetto"
                    CausesValidation="False" OnClick="btnAggiungiProgetto_Click" ></Siar:Button>   
                 <br /><br /> 
            </div> 
        </div> 
    </div> 
    <div class="dBox" id="divBandi" visible="false" runat="server"> 
        <div class="separatore" style="padding-bottom: 3px; cursor: pointer;" onclick="MostraNascondiDiv(2); return false;"> 
            <img id="imgdivBandi" runat="server" style="width: 23px; height: 23px;" /> 
            Elenco delle Procedure di Attivazione collegate al trasferimento selezionato - Organismi Intermedi : 
        </div> 
        <div id="divMostraBandi" style="padding:25px;"> 
            <div ><br />  
                <Siar:DataGrid ID="dgTrasfDettaglioBando" runat="server" Width="100%" PageSize="20" AllowPaging="True"
                    AutoGenerateColumns="False" ShowFooter="true">
                    <ItemStyle Height="28px" />
                        <FooterStyle CssClass="coda" HorizontalAlign="Right" />
                    <Columns>
                        <asp:BoundColumn DataField="IdBando" HeaderText="Id Bando">
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn  HeaderText="Bando">
                            <ItemStyle HorizontalAlign="Left" Width="200px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn  HeaderText="Stato Bando">
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn  HeaderText="Operatore Inserimento">
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid> 
            </div> 
            <div > 
                <b><br />&nbsp;Selezionare la Procedura di Attivazione:</b><br />
                <siar:ComboBandiOrganismiIntermedi ID="lstBandi" runat="server" Width="1000px"></siar:ComboBandiOrganismiIntermedi> 
                <br /><br /> 
                <Siar:Button ID="btnAggiungiBando" runat="server" Width="220px" Text="Aggiungi Bando"
                    CausesValidation="False" OnClick="btnAggiungiBando_Click"></Siar:Button> 
                 <br /><br /> 
            </div> 
        </div> 
    </div> 
</asp:Content>
