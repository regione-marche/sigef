<%@ Page Language="c#" MasterPageFile="~/SigefAgid.master" Inherits="web.HomePageAgid"
    CodeBehind="HomePageAgid.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <div id="in-evidenza-bar" class="container-fluid p-0 m-0">
        <div id="in-evidenza-background" class="container-fluid p-0 m-0">
        </div>
        <div class="container index-foreground">
            <div class="row py-3">
                <div class="col-sm-12 text-white">
                    <h1>Argomenti in evidenza</h1>
                </div>
            </div>
            <div class="row p-4">
                <div class="col-md-4 col-sm-12">
                    <div class="p-3 m-1 box-home border">
                        <h3>Area riservata</h3>
                        <p>L'accesso all'area riservata è consentito ai soli utenti registrati, consultare i seguenti dcumenti per le procedure di autorizzazione</p>
                        <div class="shadow-sm p-3 mb-5 bg-white box-attachements">
                            <a href='../Public/Download/Procedura_Accesso_SIGEF.pdf' target='_blank'>
                                <svg class="icon icon-sm icon-dark"><use href="bootstrap-italia/svg/sprites.svg#it-link" xlink:href="bootstrap-italia/svg/sprites.svg#it-link"></use></svg>
                                Procedura accesso sigef</a>
                            <p>(File pdf 120 kB)</p>
                        </div>
                        <a onclick="location='private/welcome.aspx'" class="btn full-width btn-primary primary-bg-a11 m-1">
                            <svg class="icon icon-sm icon-white"><use href="bootstrap-italia/svg/sprites.svg#it-user"></use></svg>
                            Accedi all'area riservata</a>
                    </div>
                </div>
                <div class="col-md-4 col-sm-12">
                    <div class="p-3 m-1 box-home border">
                        <h3>Firma digitale</h3>
                        <div class="shadow-sm p-3 mb-5 bg-white box-attachements">
                            <a href='../Public/Download/Manuale_firma_digitale_Calamaio_vers1_2.pdf' target='_blank'>
                                <svg class="icon icon-sm icon-dark"><use href="bootstrap-italia/svg/sprites.svg#it-link" xlink:href="bootstrap-italia/svg/sprites.svg#it-link"></use></svg>
                                Manuale firma calamaio</a>
                            <p>(File pdf 120 kB)</p>
                        </div>
                        <a id="linkTestFirmaDigitale" runat="server" href='../Public/Download/TestFirmaDigitale.html' class="btn full-width btn-primary m-1 text-start">
                            <svg class="icon icon-sm icon-white"><use href="bootstrap-italia/svg/sprites.svg#it-external-link"></use></svg>
                            Esegui il test della firma digitale</a>
                        <a id="linkTestFirmaDigitaleRemota" runat="server" href="../Public/Download/TestFirmaDigitaleRemota.aspx" class="btn full-width btn-primary m-1 text-start">
                            <svg class="icon icon-sm icon-white"><use href="bootstrap-italia/svg/sprites.svg#it-external-link"></use></svg>
                            Esegui il test della firma digitale remota</a>
                    </div>
                </div>
                <div class="col-md-4 col-sm-12">
                    <div class="p-3 m-1 box-home border">
                        <h3>Modalità per l'abilitazione dei consulenti</h3>
                        <p>La richiesta per l'abilitazione di nuovi consulenti può essere fatta direttamente online in via telematica all'interno del sito dal rappresentante legale nella Sezione Beneficiario -> Gestione Consulenti.  Inoltre in questa pagina il rappresentante legale può revocare il mandato a qualsiasi consulente in totale autonomia</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="assistenza-bar" class="container-fluid">
        <div class="container">
            <div class="row justify-content-center p-4">
                <div class="col-sm-6 p-3 m-1 box-home">
                    <h3>Assistenza agli utenti</h3>
                    <p class="primary-color-a5 fw-semibold p-0 m-0">Helpdesk SIGEF</p>
                    <p class="fw-semibold p-0 m-0">Abilitazioni</p>
                    <p class="p-0 m-0">Numero di telefono: 071 806 3995</p>
                    <p class="p-0 m-0">Email: <a href="mailto:helpdesk.sigef@regione.marche.it">helpdesk.sigef@regione.marche.it</a></p>

                    <p class="primary-color-a5 fw-semibold p-0 m-0">Carta Raffaello e autenticazione</p>
                    <p class="fw-semibold p-0 m-0">Autenticazione, firma digitale</p>
                    <p class="p-0 m-0">Numero di telefono: 071 806 6800 (int.  "3")</p>
                    <p class="p-0 m-0">Sito Web: <a href="https://cittadinanzadigitale.regione.marche.it" target="_blank">https://cittadinanzadigitale.regione.marche.it</a></p>
                </div>
            </div>
        </div>
    </div>

    <div id="news-bar" class="container">
        <input type="hidden" id="hdnInterruzioneSistema" runat="server" />
        <div class="row py-3">
            <div class="col-sm-12">
                <h1>Ultime notizie</h1>
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
                            <a href="public/newscomunicazioniagid.aspx">Apri</a>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
