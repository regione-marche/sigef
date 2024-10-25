<%@ Page Language="C#" MasterPageFile="~/SigefAgid.master" AutoEventWireup="true"
    CodeBehind="NewsComunicazioniAgid.aspx.cs" Inherits="web.Public.NewsComunicazioniAgid" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">
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
    <div class="container-fluid border-bottom">
        <div class="container p-5">
            <div id="breadcrumb" class="col-sm-12">
                <a class="fw-semibold" runat="server" href="~/HomePageAgid.aspx">Home</a><span class="fw-semibold"> / </span><span class="fw-semibold">News e comunicazioni</span>
            </div>
            <div class="col-sm-6">
                <h1>News e comunicazioni</h1>
                <p>Le notizie e le comunicazioni per restare aggiornati sulle ultime novità che vengono pubblicate periodicamente da parte della Regione Marche.</p>
            </div>
        </div>
    </div>
    <div id="latest-news" class="container-fluid">
        <div id="news-bar" class="container">
            <div class="row py-3">
                <div class="col-sm-12 text-secondary">
                    <h2>Ultime notizie</h2>
                </div>
            </div>
            <div class="row">
                <asp:Repeater ID="rptNews" runat="server">
                    <ItemTemplate>
                        <div class="col-md-4 col-sm-12">
                            <div class="shadow-sm p-3 mb-5">
                                <p><span class="primary-color-a3">NOTIZIE</span> - <%# DateTime.Parse(Eval("Data").ToString()).ToString("dd/MM/yyyy") %></p>
                                <h4 class="primary-color-a5 fw-bold"><%# Eval("Titolo") %></h4>
                                <p>
                                    <%# Eval("Testo") %>
                                </p>
                                <a href="newscomunicazioniagid.aspx">Apri</a>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
    <div id="news-list" class="container-fluid">
        <div class="container">
            <div class="row py-3">
                <div class="col-sm-12 text-secondary mb-5">
                    <h2>Esplora tutte le novità</h2>
                </div>
                <div class="col-sm-10 form-group">
                    <Siar:TextBox  Label="Ricerca testo:" ID="txtTestoLibero" runat="server" />
                </div>
                <div class="col-sm-2">
                    <Siar:Button ID="btnCerca" Text="Filtra" runat="server" OnClick="btnCerca_Click" />
                </div>
            </div>
        </div>
        <div class="container">
            <div class="row py-3">
                <asp:Repeater ID="rptNewsComplete" runat="server">
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
                                <h5 class="primary-color-a5"><%# Eval("Titolo") %></h5>
                                <p><span class="primary-color-a3">NOTIZIE</span> - <%# DateTime.Parse(Eval("Data").ToString()).ToString("dd/MM/yyyy") %></p>
                                <p>
                                    <%# Eval("Testo") %>
                                </p>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
                <Siar:DataGrid ID="dg" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    EnableViewState="False" PageSize="10" Width="100%">
                    <Columns>
                        <asp:BoundColumn></asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
            </div>
        </div>
    </div>
</asp:Content>
