<%@ Control Language="C#" AutoEventWireup="true" Inherits="ucChecklistGenerica" CodeBehind="ucChecklistGenerica.ascx.cs" %>

<%@ Register Src="SiarNewTab.ascx" TagName="SiarNewTab" TagPrefix="uc10" %>

<%--<%@ Register Src="ucAccordion.ascx" TagName="Accordion" TagPrefix="uc5" %>--%>

<uc10:SiarNewTab id="ucSiarNewTab" runat="server" TabNames="" TabPerRiga="3" />
<br />

<%--<uc5:Accordion ID="ucAccordion" runat="server" DivNames="" NomeContenuto="divContenitoreChecklist" />--%>

<div id="divContenitoreChecklist" runat="server" style="padding:10px;">

    <style type="text/css">
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

        .customTooltipCss {
            position: absolute;
            width: 600px;
            margin: 1px;
            padding: 2px;
            background-color: rgba(0, 0, 0, 0.7);
            color: white;
            border: 1px solid white;
            -moz-border-radius: 6px;
		    -webkit-border-radius: 6px;
		    border-radius: 6px;
        }

    </style>

    <div class="first_elem_block">
        <div class="value">
            <asp:Label Font-Bold="true" Font-Size="Large" ID="txtDescrizioneChecklist" runat="server" />
        </div>
    </div>
    <br />

    <Siar:DataGrid ID="dgVociXCheck" runat="server" AutoGenerateColumns="False" AllowPaging="false" Width="100%" OnItemDataBound="dgVociXCheck_ItemDataBound">
        <ItemStyle Height="24px" />
        <Columns>
            <Siar:NumberColumn HeaderText="Nr.">
                <HeaderStyle Width="25px" />
                <ItemStyle HorizontalAlign="center" />
            </Siar:NumberColumn>
            <asp:BoundColumn HeaderText="Descrizione" DataField="DescrizioneVoce"></asp:BoundColumn>
            <asp:BoundColumn>
                <ItemStyle Width="30px" />
                <ItemStyle HorizontalAlign="center" />
            </asp:BoundColumn>
            <asp:BoundColumn HeaderText="Obbligatorio" DataField="Obbligatorio" DataFormatString="{0:SI|NO}">
                <ItemStyle HorizontalAlign="Center" Width="80px" />
            </asp:BoundColumn>
            <asp:TemplateColumn HeaderText="Esito Verifica">
                <ItemStyle HorizontalAlign="Center" Width="100px" />
                <ItemTemplate>
                    <Siar:ComboSiNo ID="lstEsitoVoce" runat="server" DataColumn="IdVoceGenerica" NoBlankItem="true">
                    </Siar:ComboSiNo>
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Valore">
                <ItemStyle HorizontalAlign="Center" Width="100px" />
            </asp:TemplateColumn>
            <asp:BoundColumn HeaderText="Valore min" DataField="ValMinimoVoce"></asp:BoundColumn>
            <asp:BoundColumn HeaderText="Valore max" DataField="ValMassimoVoce"></asp:BoundColumn>
            <asp:TemplateColumn HeaderText="Azione">
                <ItemStyle HorizontalAlign="Center" Width="130px" />
            </asp:TemplateColumn>
            <Siar:TextAreaColumn HeaderText="Note" DataField="IdVoceGenerica" Name="txtAreaLungaCKL">
                <ItemStyle Width="400px" HorizontalAlign="Center" />
            </Siar:TextAreaColumn>
        </Columns>
    </Siar:DataGrid>
    <br />

    <Siar:Button ID="btnSalvaScheda" runat="server" Text="Salva esito scheda selezionata" Modifica="true" OnClick="btnSalvaScheda_Click" />
    <br />
    <br />

    <div id="divOperazioniMassive" runat="server">
        <div class="first_elem_block">
            <div class="label">Imposta esito per tutte le voci manuali:</div>
            <div class="value">
                <Siar:ComboSiNo id="lstEsitoMassivo" runat="server" ></Siar:ComboSiNo>
            </div>
            
        </div>

        <div class="elem_block">
            <Siar:Button ID="btnEsitoMassivoScheda" runat="server" Modifica="true" Text="Applica alla scheda selezionata" OnClientClick="return confirm('Sei sicuro di voler applicare il valore selezionato su tutte le voci della scheda?');" OnClick="btnEsitoMassivoScheda_Click" />
        </div>

        <div class="elem_block">
            <Siar:Button ID="btnEsitoMassivo" runat="server" Modifica="true" Text="Applica a tutte le schede" OnClientClick="return confirm('Sei sicuro di voler applicare il valore selezionato su tutte le voci delle schede della checklist?');" OnClick="btnEsitoMassivo_Click" />
        </div>
        <br />
    </div>

</div>
