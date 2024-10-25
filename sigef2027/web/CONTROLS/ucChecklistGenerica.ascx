<%@ Control Language="C#" AutoEventWireup="true" Inherits="ucChecklistGenerica" CodeBehind="ucChecklistGenerica.ascx.cs" %>

<%@ Register Src="SiarNewTabAgid.ascx" TagName="SiarNewTab" TagPrefix="uc10" %>

<%--<%@ Register Src="ucAccordion.ascx" TagName="Accordion" TagPrefix="uc5" %>--%>

<uc10:SiarNewTab id="ucSiarNewTab" runat="server" TabNames="" TabPerRiga="3" />
<br />

<%--<uc5:Accordion ID="ucAccordion" runat="server" DivNames="" NomeContenuto="divContenitoreChecklist" />--%>

<div id="divContenitoreChecklist" runat="server" class="row">

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

    <p>
        <asp:Label Font-Bold="true" Font-Size="Large" ID="txtDescrizioneChecklist" runat="server" />
    </p>
    <div class="table-responsive">
        <Siar:DataGridAgid CssClass="table table-striped" ID="dgVociXCheck" runat="server" AutoGenerateColumns="False" AllowPaging="false" Width="100%" OnItemDataBound="dgVociXCheck_ItemDataBound">
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
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundColumn>
                <asp:TemplateColumn HeaderText="Esito Verifica">
                    <ItemStyle HorizontalAlign="Center" Width="165px" />
                    <ItemTemplate>
                        <Siar:ComboSiNo ID="lstEsitoVoce" runat="server" DataColumn="IdVoceGenerica" NoBlankItem="true" >
                        </Siar:ComboSiNo>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Valore">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateColumn>
                <asp:BoundColumn HeaderText="Valore min" DataField="ValMinimoVoce"></asp:BoundColumn>
                <asp:BoundColumn HeaderText="Valore max" DataField="ValMassimoVoce"></asp:BoundColumn>
                <asp:TemplateColumn HeaderText="Azione">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateColumn>
                <Siar:TextAreaColumn HeaderText="Note" DataField="IdVoceGenerica" Name="txtAreaLungaCKL">
                    <ItemStyle HorizontalAlign="Center" />
                </Siar:TextAreaColumn>
            </Columns>
        </Siar:DataGridAgid>
    </div>
    <div class="col-sm-12">
        <Siar:Button ID="btnSalvaScheda" runat="server" Text="Salva esito scheda selezionata" Modifica="true" OnClick="btnSalvaScheda_Click" />
    </div>
    <div id="divOperazioniMassive" runat="server" class="row bd-form">
        <div class="col-sm-12 form-group my-5">
            <Siar:ComboSiNo Label="Imposta esito per tutte le voci manuali:" ID="lstEsitoMassivo" runat="server"></Siar:ComboSiNo>
        </div>
        <div class="col-sm-12">
            <Siar:Button ID="btnEsitoMassivoScheda" runat="server" Modifica="true" Text="Applica alla scheda selezionata" OnClientClick="return confirm('Sei sicuro di voler applicare il valore selezionato su tutte le voci della scheda?');" OnClick="btnEsitoMassivoScheda_Click" />
            <Siar:Button ID="btnEsitoMassivo" runat="server" Modifica="true" Text="Applica a tutte le schede" OnClientClick="return confirm('Sei sicuro di voler applicare il valore selezionato su tutte le voci delle schede della checklist?');" OnClick="btnEsitoMassivo_Click" />
        </div>
    </div>
</div>
