<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.Istruttoria.ChecklistRevisione" CodeBehind="ChecklistRevisione.aspx.cs" %>

<%@ Register Src="../../CONTROLS/InfoDomanda.ascx" TagName="InfoDomanda" TagPrefix="uc2" %>
<%@ Register Src="../../CONTROLS/FirmaDocumento.ascx" TagName="FirmaDocumento" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
        function showPopupNote(numero) {
            var popup=window.createPopup(),text=document.getElementById('hdnNoteStep'+numero).value;
            popup.document.body.innerHTML="<table style='border: #000000 1px solid;background-color:#fefeee;font-size: 11px;font-family: Tahoma, Verdana, Arial;width:100%;height:100%;'>"
                +"<tr><td valign=top><b>Note per lo step nr. "+numero+":</b><br /><br /><textarea id='TextArea1' style='width:"+(window.screen.width/3-8)+"' rows='5'>"+text+"</textarea></td></tr></table>";
            popup.show(window.screen.width/3,window.screen.height/3,window.screen.width/3,window.screen.height/8,true);
        }
        function firmaDocumento() {
            //controllo che tutte le combo siano state valorizzate
            var combo=$('[id$=lstEsitoStep]');
            for(var i=0;i<combo.length;i++)
                if(combo[i].value==""||combo[i].value==null) {
                alert('Attenzione! Per proseguire con la firma è necessario valorizzare gli esiti di tutti gli step della checklist.');
                return;
            }
            document.getElementById("ctl00_cphContenuto_btnFirmaRevisione").click();
        }
//--></script>

    <br />
    <uc2:InfoDomanda ID="ucInfoDomanda" runat="server" />
    <br />
    <table width="1200px" class="tableNoTab">
        <tr>
            <td class="separatore_big">
                Revisione degli esiti degli step di ammissibilità
            </td>
        </tr>
        <tr>
            <td>
                <div style="display: none">
                    <asp:Button ID="btnFirmaRevisione" runat="server" OnClick="btnFirmaRevisione_Click"
                        CausesValidation="False" />
                </div>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="testo_pagina">
                Di seguito elencati gli <b>step operativi</b> della fase di ammissibilità con indicata
                la valutazione dell'istruttore assegnato.
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dgSteps" runat="server" AllowPaging="false" AutoGenerateColumns="False"
                    Width="100%" OnItemDataBound="dgSteps_ItemDataBound" FooterText="(la modifica è abilitata solo per il responsabile provinciale di istruttoria)">
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <HeaderStyle Width="25px" />
                            <ItemStyle HorizontalAlign="center" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="Step" HeaderText="Descrizione"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Obbligatorio" DataFormatString="{0:SI|NO}" HeaderText="Obbligatorio">
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Automatico" DataFormatString="{0:SI|NO}" HeaderText="Automatico">
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Valutazione istruttore">
                            <ItemStyle Width="120px" />
                        </asp:BoundColumn>
                        <asp:TemplateColumn HeaderText="Azione">
                            <ItemStyle HorizontalAlign="Center" Width="130px" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Valutazione revisore">
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                            <ItemTemplate>
                                <Siar:ComboSiNo ID="lstEsitoStep" runat="server" DataColumn="IdStep" NoBlankItem="true">
                                </Siar:ComboSiNo>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <Siar:TextAreaColumn DataField="IdStep" HeaderText="Motivazioni del revisore" Name="txtAreaLungaCKL">
                            <ItemStyle HorizontalAlign="Center" Width="400px" />
                        </Siar:TextAreaColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnPostBack" runat="server" OnClick="btnPostBack_Click" Style="display: none"
                    Text="Button" />
                <Siar:Hidden ID="hdnUrlFirma" runat="server">
                </Siar:Hidden>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;ID del <strong>documento interno</strong> di Paleo (compare solo se resa definitiva):&nbsp;
                <b>
                    <Siar:Label ID="lblIdPaleo" runat="server">
                    </Siar:Label>
                </b>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center">
                <Siar:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Salva" Width="200px"
                    Modifica="true" />&nbsp; &nbsp; &nbsp;
                <input id="btnDefinitiva" runat="server" type="button" class="Button" value="Rendi definitiva"
                    onclick="firmaDocumento()" style="width: 200px" /><br />
                <br />
                <Siar:Button ID="btnVisualizza" runat="server" OnClick="btnVisualizza_Click" Text="Stampa"
                    Width="160px" Modifica="False" />
                &nbsp; &nbsp; &nbsp; &nbsp;<input id="btnBack" class="Button" style="width: 160px"
                    type="button" onclick="location='RevisioneDomande.aspx'" value="Indietro" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <uc3:FirmaDocumento ID="ucFirmaRevisione" TipoDocumento="CKL_REVISIONE" Titolo="PAGINA DI FIRMA DELLA CHECKLIST DI REVISIONE"
        runat="server" />
</asp:Content>
