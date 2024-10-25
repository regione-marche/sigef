<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true" CodeBehind="GestioneBanche.aspx.cs" Inherits="web.Private.admin.GestioneBanche" Title="Untitled Page" %>
<%@ Register Src="../../CONTROLS/SiarNewTab.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>
<%@ Register Src="../../CONTROLS/Indirizzo.ascx" TagName="Indirizzo" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

<script type="text/javascript">
        function selezionaAbi(abi) { 
            $('[id$=hdnIdBanca]').val(abi); 
            swapTab(2); 
        }
        
        function pulisciCampiAbi(){
            $('[id$=hdnIdBanca]').val('');
            $('[id$=txtAbi2]').val('');
            $('[id$=txtDenominazione2]').val('');
            $('[id$=txtDataInizio]').val('');
            $('[id$=txtDataFine]').val('');            
            swapTab(2); 
        }
        
        function selezionaCab(abi) { 
            $('[id$=hdnIdFiliale]').val(abi); 
            swapTab(3); 
        }
        
        function pulisciCampiCab(){
            $('[id$=hdnIdFiliale]').val('');
            $('[id$=txtCab3]').val('');
            $('[id$=txtFiliale3]').val('');
            $('[id$=txtIndirizzo3]').val('');
            $('[id$=txtComune3]').val('');
            $('[id$=txtProv3]').val('');
            $('[id$=txtCap3]').val('');
            $('[id$=IdComuneHide]').val('');
            $('[id$=txtDataInizio3]').val('');
            $('[id$=txtDataFine3]').val('');
            swapTab(3); 
            
        }
        
        
    var text_box_comuni, ajax_callback_complete = true, selezione_comuni;
    function apriSNCZoomComuni(elem, e) { if (cm_getKeyCode(e) == 9/*tasto tab*/) { selezionaSNCZCComune(0); stopEvent(e); } else { $('[id$=txtProv3_text]').val(''); $('[id$=txtCap3_text]').val(''); $('[id$=IdComuneHide_text]').val(''); text_box_comuni = elem; window.setTimeout("SNCZCCerca();", 200); } }
    function SNCZCCerca() {
        if (ajax_callback_complete) {
            ajax_callback_complete = false; $.post(getBaseUrl() + 'CONTROLS/ajaxRequest.aspx', { type: 'SNCZoomComuniFind', descrizione: $(text_box_comuni).val(), cerca_nelle_marche: $('#chkSNCZCCercaMarche').attr('checked') }, function(msg) {
                ajax_callback_complete = true; selezione_comuni = eval('(' + msg + ')'); mostraSNCZCPannelloRisultato();
            });
        } 
    }

    function mostraSNCZCPannelloRisultato() {
 
        var pos = $(text_box_comuni).offset(); popolaSNCZCComuni(); $('#divSNCZCResults').css({ 'left': pos.left + 'px', 'top': (pos.top - 235) + 'px' }).show(300);
        $(document).click(function(e) { if (mouseX < pos.left || mouseX > pos.left + 370 || mouseY < pos.top - 235 || mouseY > pos.top + 20) chiudiSNCZoomComuni(); });
    }
    function popolaSNCZCComuni() {
 
        var html = "<table style='width:100%' cellpadding='0' cellspacing='0'>";
        for (var i = 0; i < selezione_comuni.length; i++) html += "<tr class='DataGridRow selectable'><td style='height:20px' onclick='selezionaSNCZCComune(" + i + ")'>" + selezione_comuni[i].Denominazione + " (" + selezione_comuni[i].Provincia + ") " + " - " + selezione_comuni[i].Cap + "</td></tr>";
        if (selezione_comuni.length < 8) html += "<tr class='DataGridRow'><td style='height:" + (22 * (8 - selezione_comuni.length)) + "px'>&nbsp;</td></tr>";
        $('#tdSNCZCResults').html(html + "<tr class='coda'><td>&nbsp;" + (selezione_comuni.length > 0 ? "Tasto TAB seleziona primo elemento" : "Nessun elemento trovato.") + "</td></tr></table>");
    }
    function chiudiSNCZoomComuni() { $('#divSNCZCResults').hide(); }
    function selezionaSNCZCComune(indice_comune) {
        if (indice_comune >= 0 && selezione_comuni[indice_comune] && selezione_comuni[indice_comune].IdComune > 0) {
            chiudiSNCZoomComuni(); $('[id$=IdComuneHide]').val(selezione_comuni[indice_comune].IdComune); $('[id$=txtComune3_text]').val(selezione_comuni[indice_comune].Denominazione);
            $('[id$=txtProv3]').val(selezione_comuni[indice_comune].Provincia); $('[id$=txtCap3]').val(selezione_comuni[indice_comune].Cap);
        }
    }       

        
</script>



<input id="hdnIdBanca" type="hidden" name="hdnIdBanca" runat="server" />
<input id="hdnIdFiliale" type="hidden" name="hdnIdFiliale" runat="server" />
<uc1:SiarNewTab ID="ucSiarNewTab" runat="server" TabNames="Istituti|Dettaglio-Istituti|Dettaglio-Filiale"
        Width="900px" />
        <table class="tableTab" width="900px" id="tabIstituti" runat="server" >
        <tr>
            <td>
                <table id="Table1" width="100%">
                    <tr>
                        <td class="separatore" colspan="3">  RICERCA ISTITUTI
                        </td>
                    </tr>
                    <tr>
	                    <td style="width: 10%; padding-bottom: 10px; padding-left: 10px;">
                            ABI:
                            <br/>
                            <Siar:TextBox ID="txtAbi" runat="server" MaxLength="5" Width="50px" />
                        </td>
	                    <td style="width: 55%; padding-bottom: 10px; padding-left: 10px;">
                            Descrizione:
                            <br/>
                            <Siar:TextBox ID="txtDenominazione" runat="server" MaxLength="100" Width="400px" />
                        </td>
	                    <td align="center" id="tdPulsanti" style="width: 35%;">
	                    <Siar:Button ID="btnCerca" runat="server" CausesValidation="False" OnClick="btnCerca_Click"
                                Text="Cerca" Width="140px" />
                        <input type="button" class="Button"  id="btnNuovaBanca" value="Nuovo Istituto"  
                                style="width: 140px;" onclick="pulisciCampiAbi();" />
                            
                        </td>
                    </tr>
                    <tr>
	                    <td colspan="3">  
	                        <table id="tbBanche" width="100%">
		                    <tr>
		    	                <td class="separatore">
                                    Elenco Istituti
                                </td>
		                    </tr>
		                    <tr>
			                    <td>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td valign="top">
                                            <Siar:DataGrid ID="dgbanche" runat="server" Width="100%" AutoGenerateColumns="False" PageSize="20" AllowPaging="True">
                                                <ItemStyle Height="24px" />
                                                <ItemStyle CssClass="DataGridRow"></ItemStyle>
                                                <HeaderStyle Font-Bold="True" ForeColor="White" CssClass="TESTA1"></HeaderStyle>
                                                    <Columns>
                                                        <Siar:NumberColumn HeaderText="Nr.">
                                                            <ItemStyle Width="15px" HorizontalAlign="center" ></ItemStyle>
                                                        </Siar:NumberColumn>   
                                                        <Siar:ColonnaLink  LinkFields="Abi" LinkFormat="javascript:selezionaAbi('{0}');"
                                                            DataField="Abi" HeaderText="ABI" ItemStyle-Width="50px" >
                                                        </Siar:ColonnaLink>
                                                        <asp:BoundColumn DataField="Denominazione" HeaderText="Denominazione">
                                                            <ItemStyle  Width="300px" />
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn HeaderText="Data Inizio Validità" DataField="DataInizioValidita">
                                                            <ItemStyle Width="40px" HorizontalAlign="Center" />
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn HeaderText="Data Fine Validità" DataField="DataFineValidita">
                                                            <ItemStyle Width="40px" HorizontalAlign="Center" />
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn DataField="Attivo" HeaderText="Attivo" DataFormatString="{0:SI|NO}">
                                                            <ItemStyle Width="30px" HorizontalAlign="Center" />
                                                        </asp:BoundColumn>
                                                    </Columns>
                                            </Siar:DataGrid>
		                                    </td>
                                        </tr>
                                    </table>
	                            </td>
	                        </tr>
                            </table>
                        </td>
                    </tr>      
                </table>
             </td>
        </tr>
        </table>
        <table class="tableTab" id="tabElencoIstituti" width="900px" runat="server" >
        <tr>
            <td>
                <table id="Table2" width="100%">
                    <tr>
                        <td class="separatore" colspan="3">  DETTAGLIO ISTITUTI
                        </td>
                    </tr>
                    <tr>
	                    <td style="width: 15%; padding-bottom: 10px; padding-left: 10px;">
                            ABI:
                            <br/>
                            <Siar:TextBox ID="txtAbi2" runat="server" MaxLength="5" Width="50px" 
                            Obbligatorio="true" NomeCampo="Abi"/>
                        </td>
	                    <td style="width: 40%; padding-bottom: 10px; padding-left: 10px;">
                            Descrizione:
                            <br/>
                            <Siar:TextBox ID="txtDenominazione2" runat="server" MaxLength="100" Width="300px" 
                            Obbligatorio="true" NomeCampo="Descrizione Istituto"/>
                        </td>
                        <td style="width: 45%; padding-bottom: 5px; padding-left: 10px;"> 
                            <asp:CheckBox ID="ckAttivo" Text ="Attivo" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 15%; padding-bottom: 10px; padding-left: 10px;">
                            Data inizio validità
                            <br/>
                            <Siar:DateTextBox ID="txtDataInizio" runat="server"  Width="100px" 
                            Obbligatorio="true" NomeCampo="Data inizio validità"/>
                        </td>
                        <td style="width: 15%; padding-bottom: 10px; padding-left: 10px;">
                            Data fine validità
                            <br/>
                            <Siar:DateTextBox ID="txtDataFine" runat="server"  Width="100px" Height="22px" />
                        </td>
	                    <td align="right" style="padding-right:30px;" id="tdPulsanti2">
	                    <Siar:Button ID="btnSalvaIstituto" runat="server" CausesValidation="False" OnClick="btnSalvaIstituto_Click"
                                Text="Salva" Width="140px" />
                        <input type="button" class="Button"  id="btnNuovoIstituto" value="Nuovo Istituto"  
                                style="width: 140px;" onclick="pulisciCampiAbi();" />
                        </td>
                    </tr>
                </table>
                <br />
                <table id="TableIst" width="100%">
                    <tr>
                        <td class="separatore"  colspan="4">
                            Elenco Filiali
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 15%; padding-bottom: 10px; padding-top: 10px; padding-left: 10px;">
                            CAB:
                            <br/>
                            <Siar:TextBox ID="txtCab" runat="server" MaxLength="5" Width="50px" />
                        </td>
                        <td style="width: 30%; padding-bottom: 10px; padding-top: 10px; padding-left: 10px;">
                            Filiale:
                            <br/>
                            <Siar:TextBox ID="txtFiliale" runat="server" MaxLength="100" Width="300px" />
                        </td>
                        <td style="width: 20%; padding-bottom: 10px; padding-top: 10px; padding-left: 10px;">
                            Provincia:
                            <br/>
                            <Siar:ComboProvince ID="lstProvincia" runat="server" style="width: 100px;" >
                            </Siar:ComboProvince>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td>
                        <td align="right" style="padding-right:30px;" id="td1" colspan="2">
	                        <Siar:Button ID="btnFiltra" runat="server" CausesValidation="False" OnClick="btnFiltra_Click"
                                Text="Filtra" Width="140px" />
                            <input type="button" class="Button"  id="btnNuovaFiliale" value="Nuova Filiale"  
                                style="width: 140px;" onclick="pulisciCampiCab();" />
                        </td>
                    </tr>
                </table>
                 <br />
                 <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td valign="top">
                        <Siar:DataGrid ID="dgFiliali" runat="server" Width="100%" AutoGenerateColumns="False" PageSize="20" AllowPaging="True">
                            <ItemStyle Height="24px" />
                            <ItemStyle CssClass="DataGridRow"></ItemStyle>
                            <HeaderStyle Font-Bold="True" ForeColor="White" CssClass="TESTA1"></HeaderStyle>
                                <Columns>
                                    <Siar:NumberColumn HeaderText="Nr.">
                                        <ItemStyle Width="15px" HorizontalAlign="center" ></ItemStyle>
                                    </Siar:NumberColumn>  
                                    <asp:BoundColumn DataField="Abi" HeaderText="ABI">
                                        <ItemStyle  Width="50px" />
                                    </asp:BoundColumn> 
                                    <Siar:ColonnaLink  LinkFields="Id" LinkFormat="javascript:selezionaCab({0});"
                                        DataField="Cab" HeaderText="CAB" ItemStyle-Width="50px" >
                                    </Siar:ColonnaLink>
                                    <asp:BoundColumn DataField="Note" HeaderText="Filiale">
                                        <ItemStyle  Width="150px" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Indirizzo" HeaderText="Indirizzo">
                                        <ItemStyle  Width="100px" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Comune" HeaderText="Comune">
                                        <ItemStyle  Width="80px" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Provincia" HeaderText="Prov.">
                                        <ItemStyle  Width="80px" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Attivo" HeaderText="Attivo" DataFormatString="{0:SI|NO}">
                                        <ItemStyle Width="30px" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                </Columns>
                        </Siar:DataGrid>
                        </td>
                    </tr>
                </table>
            </td>
       </tr>
       </table>
       <table class="tableTab" id="tabFiliali" width="900px" runat="server" >
            <tr>
                <td>
                    <table id="Table3" width="100%">
                        <tr>
                            <td class="separatore" id="tdDettaglioFiliale" runat="server" colspan="5">  DETTAGLIO FILIALE
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 25%; padding-bottom: 10px; padding-left: 10px;">
                                ABI:
                                <br/>
                                <Siar:TextBox ID="txtAbi3" runat="server" MaxLength="5" Width="50px" ReadOnly="true"  />
                            </td>
                            <td style="width: 25%; padding-bottom: 10px; padding-left: 10px;">
                                CAB:
                                <br/>
                                <Siar:TextBox ID="txtCab3" runat="server" MaxLength="5" Width="50px" 
                                Obbligatorio="true" NomeCampo="CAB" />
                            </td>
                            <td style="width: 50%;" colspan="3">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="width: 50%; padding-bottom: 10px; padding-left: 10px;">
                                Note:
                                <br />
                                <Siar:TextArea ID="txtFiliale3" Rows="2" runat="server" Width="300px"
                                Obbligatorio="true" NomeCampo="Nome Filiale"/> 
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="width: 50%; padding-bottom: 10px; padding-left: 10px;">
                                Indirizzo:
                                <br />
                                <Siar:TextBox ID="txtIndirizzo3" runat="server" Width="300px"
                                Obbligatorio="true" NomeCampo="Indirizzo filiale"/> 
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="width: 50%; padding-bottom: 10px; padding-left: 10px;">
                                Comune:
                                <br />
                                <Siar:TextBox ID="txtComune3" runat="server" Width="300px"
                                Obbligatorio="true" NomeCampo="Comune filiale"/> 
                            </td>
                            <td style="width: 12%; padding-bottom: 10px; padding-left: 10px;">
                                Prov.:
                                <br/>
                                <Siar:TextBox ID="txtProv3" runat="server" MaxLength="5" Width="50px" ReadOnly="true" />
                            </td>
                            <td style="width: 12%; padding-bottom: 10px; padding-left: 10px;">
                                CAP:
                                <br/>
                                <Siar:TextBox ID="txtCap3" runat="server" MaxLength="5" Width="50px" ReadOnly="true" />
                                <asp:HiddenField ID="IdComuneHide" runat="server" />
                            </td>
                            <td style="width: 25%;">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 25%; padding-bottom: 10px; padding-left: 10px;" >
                                Data inizio validità:
                                <br/>
                                <Siar:DateTextBox ID="txtDataInizio3" runat="server"  Width="80px" 
                                Obbligatorio="true" NomeCampo="Data inizio validità"/>
                            </td>
                            <td style="width: 25%; padding-bottom: 10px; padding-left: 10px;">
                                Data fine validità:
                                <br/>
                                <Siar:DateTextBox ID="txtDataFine3" runat="server"  Width="80px" />
                            </td>
                            
                        </tr>
                        <tr >
                            <td > 
                                <asp:CheckBox ID="ckAttivo3"  style="padding-left: 10px;" Text ="Attivo" runat="server" />
                            </td>
                            <td colspan="4">
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td align="center" colspan="4" id="td2" style="padding-bottom: 20px;" >
	                            <%--<Siar:Button ID="btnDisattivaFiliale" runat="server" CausesValidation="False" OnClick="btnDisattivaFiliale_Click"
                                        Text="Disattiva" Width="140px" />--%>
                                <Siar:Button ID="btnSalvaFiliale" runat="server" CausesValidation="False" OnClick="btnSalvaFiliale_Click"
                                    Text="Salva" Width="140px" />
                                <input type="button" class="Button"  id="btnNuovaFiliale2" value="Nuova"  
                                    style="width: 140px;" onclick="pulisciCampiCab();" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
       </table>  
       <div id="divSNCZCResults" style="position: absolute; display: none; width: 370px">
            <table class="tableNoTab" style="width: 100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <table width="100%" cellpadding="0" cellspacing="0">
                            <tr class='TESTA1'>
                                <td style="border: 0">
                                    SELEZIONA IL COMUNE:
                                </td>
                                <td align="right" style="border: 0">
                                    cerca nelle Marche
                                    <input id='chkSNCZCCercaMarche' onclick='SNCZCCerca();' type="checkbox" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td id="tdSNCZCResults">
                        &nbsp;
                    </td>
                </tr>
            </table>
        </div>
</asp:Content>
