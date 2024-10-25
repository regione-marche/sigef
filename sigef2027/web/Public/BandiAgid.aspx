<%@ Page Language="C#" MasterPageFile="~/SigefAgid.master" AutoEventWireup="true"
    Inherits="web.Public.BandiAgid" CodeBehind="BandiAgid.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.13.4/css/dataTables.bootstrap5.min.css" />
    <script type="text/javascript" src="https://cdn.datatables.net/1.13.4/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.13.4/js/dataTables.bootstrap5.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#example').DataTable({
                "ordering": false,
                "searching": false,
                "language": {
                    "sEmptyTable": "Nessun dato presente nella tabella",
                    "sInfo": "Vista da _START_ a _END_ di _TOTAL_ elementi",
                    "sInfoEmpty": "Vista da 0 a 0 di 0 elementi",
                    "sInfoFiltered": "(filtrati da _MAX_ elementi totali)",
                    "sInfoPostFix": "",
                    "sInfoThousands": ".",
                    "sLengthMenu": "Visualizza _MENU_ elementi",
                    "sLoadingRecords": "Caricamento...",
                    "sProcessing": "Elaborazione...",
                    "sSearch": "Cerca:",
                    "sZeroRecords": "La ricerca non ha portato alcun risultato.",
                    "oPaginate": {
                        "sFirst": "Inizio",
                        "sPrevious": "Precedente",
                        "sNext": "Successivo",
                        "sLast": "Fine"
                    },
                    "oAria": {
                        "sSortAscending": ": attiva per ordinare la colonna in ordine crescente",
                        "sSortDescending": ": attiva per ordinare la colonna in ordine decrescente"
                    }
                }
            });
        });

        var prm = Sys.WebForms.PageRequestManager.getInstance();

        prm.add_endRequest(function () {
            $('#example').DataTable({
                "ordering": false,
                "searching": false,
                "language": {
                    "sEmptyTable": "Nessun dato presente nella tabella",
                    "sInfo": "Vista da _START_ a _END_ di _TOTAL_ elementi",
                    "sInfoEmpty": "Vista da 0 a 0 di 0 elementi",
                    "sInfoFiltered": "(filtrati da _MAX_ elementi totali)",
                    "sInfoPostFix": "",
                    "sInfoThousands": ".",
                    "sLengthMenu": "Visualizza _MENU_ elementi",
                    "sLoadingRecords": "Caricamento...",
                    "sProcessing": "Elaborazione...",
                    "sSearch": "Cerca:",
                    "sZeroRecords": "La ricerca non ha portato alcun risultato.",
                    "oPaginate": {
                        "sFirst": "Inizio",
                        "sPrevious": "Precedente",
                        "sNext": "Successivo",
                        "sLast": "Fine"
                    },
                    "oAria": {
                        "sSortAscending": ": attiva per ordinare la colonna in ordine crescente",
                        "sSortDescending": ": attiva per ordinare la colonna in ordine decrescente"
                    }
                }
            });
        });

    </script>

    <div class="container-fluid">
        <div class="container p-5">
            <div id="breadcrumb" class="col-sm-12">
                <a class="fw-semibold" runat="server" href="~/HomePageAgid.aspx">Home</a><span class="fw-semibold"> / </span><span class="fw-semibold">Bandi pubblici</span>
            </div>
            <div class="col-sm-6">
                <h1>Bandi pubblici</h1>
            </div>
        </div>
        <div class="container p-2">
            <div class="row bd-form pt-5">
                <div class="form-group col-md-3 col-sm-6">
                    <Siar:ComboEntiBando Label="Ente emettitore del bando" ID="lstEntiBando" runat="server" Width="180px">
                    </Siar:ComboEntiBando>
                </div>
                <div class="form-group col-md-6 col-sm-6">
                    <Siar:ComboGroupZProgrammazione Label="Programmazione" ID="lstZProgrammazione" runat="server">
                    </Siar:ComboGroupZProgrammazione>
                </div>
                <div class="form-check col-md-3 col-sm-6">
                    <asp:CheckBox ID="chkScaduti" runat="server" Checked="True" Text="Nascondi bandi scaduti" />
                </div>
                <div class="form-group col-md-3 col-sm-6">
                    <Siar:DateTextBox ID="txtScadenza" Label="Data di scadenza(<=)" runat="server" />
                </div>
                <div class="form-group col-md-3 col-sm-6">
                    <Siar:IntegerTextBox ID="txtNumero" Label="Numero decreto" runat="server" NoCurrency="true" />
                </div>
                <div class="form-group col-md-3 col-sm-6">
                    <Siar:DateTextBox ID="txtDataAtto" Label="Data decreto" runat="server" />
                </div>
                <div class="form-group col-md-3 col-sm-6">
                    <div class="select-wrapper">
                        <label for="orderBy">Ordinamento</label>
                        <select runat="server" name="orderBy" id="orderBy">
                            <option value="DATA_SCADENZA">Data Scadenza</option>
                            <option value="DATA_APERTURA">Data Apertura</option>
                        </select>
                    </div>
                </div>
                <div class="col-sm-12">
                    <div class="float-end">
                        <Siar:Button ID="btnCerca" Text="Avvia ricerca" runat="server" OnClick="btnCerca_Click" />
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-12">

                    <asp:Repeater ID="rptBandi" runat="server">
                        <HeaderTemplate>
                            <table id="example" class="table table-striped" style="width: 100%">
                                <thead>
                                    <tr>
                                        <th></th>
                                    </tr>
                                </thead>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <h5 class="primary-color-a5"><%# Eval("Descrizione") %></h5>
                                    <p>Importo: <%# string.Format("{0:c}",Eval("Importo")) %></p>
                                    <p class="fw-bold m-0">Scadenza: <%# Eval("DataScadenza") %></p>
                                    <%# DateTime.Parse(Eval("DataScadenza").ToString()) > DateTime.Now ? "<input type=button value='Presenta domanda' class='btn btn-primary py-1' onclick=\"location='../Private/PDomanda/SelezioneAzienda.aspx?idb=" + Eval("IdBando")  + "'\" />" : "<span class=testoRosso>SCADUTO</span>"%>
                                    <%# Eval("CodStato").ToString() == "G" ? "<input type=button value='Vedi graduatoria' class='btn btn-secondary py-1' onclick=\"visualizzaAtto(" + Eval("IdAtto") + ");\" />" : ""%>                                    
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <div id="divDocumentiBando" style="width: 700px; position: absolute; display: none">
                <table class="tableNoTab" width="100%">
                    <tr>
                        <td class="separatore">&nbsp;Elenco dei documenti relativi al bando selezionato:
                        </td>
                    </tr>
                    <tr>
                        <td id="tdGridDocumentiBando" style="padding: 5px"></td>
                    </tr>
                    <tr>
                        <td style="height: 40px; padding-right: 40px;" align="right">
                            <input style="width: 155px" type="button" value="Chiudi" class="Button" onclick="chiudiPopupTemplate()" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
