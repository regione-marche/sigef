<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    Inherits="web.Private.Psr.Bandi.BandoPubblicazione" CodeBehind="BandoPubblicazione.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--

    function mostraChecklist(id) { $('[id$=hdnIdChecklist]').val(id); $('[id$=btnVisualizzachecklist]').click(); }
    function chiudiPopup() { $('[id$=hdnIdChecklist]').val(''); $('[id$=hdnIdscheda]').val(''); chiudiPopupTemplate(); }
    function vaiChecklist() { var id = $('[id$=hdnIdChecklist]').val(); self.location = '../../regione/CheckList.aspx?action=visualizza&id=' + id; }
    function mostraScheda() { var id = Number($('[id$=lstSchedaValutazione]').val()); if (id > 0) { $('[id$=hdnIdscheda]').val(id); $('[id$=btnVisualizzaScheda]').click(); } else alert('Per proseguire è necessario selezionare una scheda di valutazione.'); }
    function vaiScheda() { document.location = '../../regione/schedavalutazione.aspx?ids=' + $('[id$=hdnIdscheda]').val(); }
//--></script>
    <div class="row">
        <div style="display: none">
            <Siar:Button ID="btnVisualizzachecklist" runat="server" OnClick="btnVisualizzachecklist_Click"
                CausesValidation="False" />
            <Siar:Button ID="btnVisualizzaScheda" runat="server" OnClick="btnVisualizzaScheda_Click"
                CausesValidation="False" />
            <asp:HiddenField ID="hdnIdChecklist" runat="server" />
            <asp:HiddenField ID="hdnIdscheda" runat="server" />
        </div>
        <h3 class="pb-5 mt-5">Scheda procedurale del bando</h3>
        <div class="col-sm-12 form-group">
            <Siar:ComboSchedaValutazione Label="Selezionare la scheda di valutazione:" ID="lstSchedaValutazione" runat="server" Obbligatorio="true"
                NomeCampo="Scheda di valutazione" DataColumn="IdSchedaValutazione">
            </Siar:ComboSchedaValutazione>
        </div>
        <div class="col-sm-12">
            <input type="button" value="Visualizza" onclick="mostraScheda()" class="btn btn-primary py-1" />
        </div>

        <h4 class="pb-5 mt-5">Checklist operative:</h4>
        <p>Selezionare per ognuna delle fasi della domanda la check list operativa corrispondente:</p>
        <div class="col-sm-12">
            <Siar:DataGridAgid ID="dgChecklist" runat="server" AllowPaging="False" AutoGenerateColumns="False"
                CssClass="table table-striped">
                <Columns>
                    <asp:BoundColumn DataField="CodFase" HeaderText="Codice Fase">
                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="FaseProcedurale" HeaderText="Descrizione Fase"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Checklist associata">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                </Columns>
            </Siar:DataGridAgid>
        </div>
        <div class="col-sm-12 pb-5">
            <Siar:Button ID="btnSalva" runat="server" OnClick="btnSalva_Click" Text="Salva"
                Modifica="true" />
        </div>
    </div>
    <div id="divSchedaForm" style="display: none; position: absolute;" class="modal it-dialog" tabindex="-1" role="dialog">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    Dettaglio scheda di valutazione
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-sm-12 form-group">
                            <Siar:TextArea Label="Descrizione:" ID="txtScheda" runat="server" Width="700px" ReadOnly="true"></Siar:TextArea>
                        </div>
                        <div class="col-sm-12">
                            <Siar:DataGridAgid CssClass="table table-striped" ID="dgPriorita" runat="server" Width="100%" AutoGenerateColumns="False"
                                AllowPaging="true" PageSize="8">
                                <Columns>
                                    <Siar:NumberColumn HeaderText="Nr.">
                                        <ItemStyle Width="35px" HorizontalAlign="center" />
                                    </Siar:NumberColumn>
                                    <asp:BoundColumn HeaderText="Descrizione" DataField="Priorita"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="CodLivello" HeaderText="Livello di dettaglio" DataFormatString="{0:D=Domanda|I=Investimento|S=Settoriale|Z=Zona svantaggiata|T=Zona montanta|F=Investimento fisso|M=Investimento mobile}">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Peso" HeaderText="Peso %">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="AiutoAddizionale" HeaderText="Aiuto Addizionale">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="PluriValore" HeaderText="Pluri Valore" DataFormatString="{0:SI|NO}">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Selezionabile" HeaderText="Visualizza" DataFormatString="{0:SI|NO}">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                </Columns>
                            </Siar:DataGridAgid>
                        </div>
                        <div class="col-sm-12 mb-5">
                            <input id="btnVaiScheda" class="btn btn-secondary py-1" onclick="vaiScheda()"
                                type="button" value="Vai alla scheda" />&nbsp;&nbsp;
                            <input id="Button2" class="btn btn-secondary py-1" onclick="chiudiPopup()" type="button"
                                value="Chiudi" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="divCheckListForm" style="display: none; position: absolute;" class="modal it-dialog" tabindex="-1" role="dialog">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    Dettaglio checklist
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-sm-12 form-group">
                            <Siar:TextArea Label="Descrizione:" ID="txtDescrizione" runat="server" Width="500px" ReadOnly="true"></Siar:TextArea>
                        </div>
                        <div class="col-sm-12 mt-3">
                            <p>
                                >Elementi trovati:
                                <Siar:Label ID="lblNumeroStep" runat="server"></Siar:Label>
                            </p>
                        </div>
                        <div class="col-sm-12">
                            <Siar:DataGridAgid CssClass="table table-striped" ID="dgStep" runat="server" Width="100%" AutoGenerateColumns="False"
                                AllowPaging="true" PageSize="13">
                                <Columns>
                                    <Siar:NumberColumn HeaderText="Nr.">
                                        <ItemStyle HorizontalAlign="center" />
                                    </Siar:NumberColumn>
                                    <asp:BoundColumn HeaderText="Descrizione" DataField="Step"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="FaseProcedurale" HeaderText="Fase Procedurale">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Misura" HeaderText="Misura">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Automatico" HeaderText="Automatico" DataFormatString="{0:SI|NO}">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Obbligatorio" DataField="Obbligatorio" DataFormatString="{0:SI|NO}">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                </Columns>
                            </Siar:DataGridAgid>
                        </div>
                        <div class="col-sm-12 mb-5">
                            <input id="btnVaiChecklist" class="btn btn-secondary py-1" onclick="vaiChecklist()"
                                type="button" value="Vai alla cheklist" />&nbsp;&nbsp;
                            <input id="btnChiudi" class="btn btn-secondary py-1" onclick="chiudiPopup()"
                                type="button" value="Chiudi" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
