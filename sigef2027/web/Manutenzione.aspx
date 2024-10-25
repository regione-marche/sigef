<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="Manutenzione.aspx.cs" Inherits="web.Manutenzione" %>

<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />

    <link rel="stylesheet" href="<%= Page.ResolveUrl("~/bootstrap-italia/css/bootstrap-italia.min.css")%>" />

    <link href="<%= Page.ResolveUrl("~/css/AgidStyle.css")%>" type="text/css" rel="stylesheet" />

    <link rel="icon" href="<%= Page.ResolveUrl("~/images/favicon.png")%>" type="image/png" />
</head>
<header>
    <div id="title-bar" class="container-fluid">
        <div class="row">
            <div class="col-sm-12">
                <div id="titolo-rm" class="fw-semibold float-start py-2">
                    <span>Regione Marche</span>
                </div>
            </div>
        </div>
    </div>
    <div id="header-bar" class="container-fluid">
        <div class="container">
            <a runat="server" class="navbar-brand py-2 text-decoration-none text-white" href="HomePageAgid.aspx" aria-label="Sistema Integrato GEstione Fondi" title="Sistema Integrato GEstione Fondi" data-focus-mouse="false">
                <div class="d-flex flex-row py-4">
                    <img id="logo" runat="server" src="img/logo.png" class="img-fluid" alt="Sigef Regione Marche">
                    <div class="d-flex flex-column ps-3 ps-sm-4">
                        <h2 class="bd-logo-title">SIGEF</h2>
                        <h6 class="bd-logo-subtitle">Sistema Integrato GEstione Fondi</h6>
                    </div>
                </div>
            </a>
        </div>
    </div>
</header>
<body>
    <div class="container">
        <div id="in-evidenza-bar" class="container-fluid index-foreground py-5">
        </div>
        <div class="container-fluid in-evidenza-bar shadow rounded-2">
            <div class="row justify-content-center py-2">
                <div class="col-md-12 col-sm-12">
                    <h1 class="fw-bold">Attenzione !</h1>
                </div>
            </div>
            <div class="row justify-content-center py-2">
                <div class="col-md-12 col-sm-12">
                    <h2 class="fw-bold">Il sito &#232; in fase di aggiornamento, ritorner&#224; attivo il prima possibile.</h2>

                </div>
            </div>

        </div>
        <div class="row justify-content-center py-4">
            <div class="col-sm-12 pt-5 m-1">
                <h6>Copyright &#169; 2007-2016 Regione Marche - Tutti i diritti riservati</h6>
            </div>
        </div>
    </div>
    <div id="footer-bar" class="container-fluid">
        <div class="container">
            <a class="navbar-brand py-2 text-decoration-none" href="HomePageAgid.aspx" runat="server" aria-label="Sistema Integrato GEstione Fondi" title="Sistema Integrato GEstione Fondi" data-focus-mouse="false">
                <div class="d-flex flex-row py-4">
                    <img runat="server" id="logofooter" src="img/logo.png" class="img-fluid" alt="Sigef Regione Marche">
                    <div class="d-flex flex-column ps-3 ps-sm-4 text-white">
                        <h2 class="bd-logo-title">SIGEF</h2>
                        <h6 class="bd-logo-subtitle">Sistema Integrato GEstione Fondi</h6>
                    </div>
                </div>
            </a>
            <div class="row">
                <div class="col-lg-4 col-md-4 col-sm-6 py-2 px-4">
                    <div class="border-bottom">
                        <h6 class="text-white">INFORMAZIONI</h6>
                    </div>
                    <p class="text-white">
                        Per informazioni in merito ai contenuti tematici di ciascun bando si rimanda al referente indicato nello stesso.
                    </p>
                </div>
                <div class="col-lg-8 col-md-8 col-sm-6 py-2 px-4">
                    <div class="border-bottom">
                        <h6 class="text-white">AVVERTENZE</h6>
                    </div>
                    <p class="text-white">
                        La configurazione della postazione pc di lavoro da utilizzare per l’apposizione della firma digitale tramite smart-card deve avvenire con qualche giorno di anticipo rispetto alla data di scadenza del bando per non incorrere nella formazione di code di chiamata ai numeri sopra indicati. 
                        Considerati I tempi usuali per le operazioni di assistenza necessarie, gli operatori di help desk non garantiscono la soluzione dei problemi relativi alla configurazione delle postazioni di lavoro nel giorno di scadenza del bando di interesse per l’utente.
                    </p>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-12 py-2 px-4">
                    <div class="border-bottom">
                        <h6 class="text-white">CONTATTI</h6>
                    </div>
                </div>
                <div class="col-lg-4 col-md-4 col-sm-6 py-2 px-4">
                    <p class="text-white fw-semibold p-0 m-0">Helpdesk SIGEF</p>
                    <p class="fw-semibold text-white p-0 m-0">Abilitazioni</p>
                    <p class="text-white p-0 m-0">Numero di telefono: 071 806 3995</p>
                    <p class="text-white p-0 m-0">Email: <a class="text-white" href="mailto:helpdesk.sigef@regione.marche.it">helpdesk.sigef@regione.marche.it</a></p>
                </div>
                <div class="col-lg-8 col-md-8 col-sm-6 py-2 px-4">
                    <p class="text-white fw-semibold p-0 m-0">Carta Raffaello e autenticazione</p>
                    <p class="text-white fw-semibold p-0 m-0">Autenticazione, firma digitale</p>
                    <p class="text-white p-0 m-0">Numero di telefono: 071 806 6800 (int.  "3")</p>
                    <p class="text-white p-0 m-0">Sito Web: <a class="text-white" href="https://cittadinanzadigitale.regione.marche.it" target="_blank">https://cittadinanzadigitale.regione.marche.it</a></p>
                </div>
            </div>
        </div>
    </div>
</body>
