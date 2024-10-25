<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    Inherits="web.Private.Istruttoria.Collaboratori" CodeBehind="Collaboratori.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <script type="text/javascript">
        function SNCVZCercaUtenti_onselect(obj) { if (obj) { $('[id$=hdnIdUtente]').val(obj.IdUtente); $('[id$=txtNominativo_text]').val(obj.Nominativo); } else alert('L`elemento selezionato non è valido.'); }
        function SNCVZCercaUtenti_onprepare() { $('[id$=hdnIdUtente]').val(''); }
        function selezionaMembro(id) { $('[id$=hdnIdCollaboratorePost').val(id); $('[id$=btnPost]').click(); }
    </script>
    <div style="display: none">
        <asp:HiddenField ID="hdnIdCollaboratorePost" runat="server" />
        <asp:Button ID="btnPost" runat="server" OnClick="btnPost_Click" />
    </div>
    <div class="row pt-5">
        <div class="col-sm-12">
            <div class="steppers">
                <div class="steppers-header">
                    <ul>
                        <li class="confirmed">
                            <a class="steppers-link" title="Statistiche" type="button" href="../istruttoria/statistiche.aspx">
                                <svg class="icon icon-lg">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-chart-line"></use></svg>
                                <span class="steppers-text">Statistiche<svg class="icon steppers-success"><use href="/web/bootstrap-italia/svg/sprites.svg#it-check"></use></svg><span class="visually-hidden">Confermato</span></span>
                            </a>
                        </li>
                        <li class="active">
                            <a class="steppers-link" type="button" title='Collaboratori istruttoria' href="../istruttoria/Collaboratori.aspx">
                                <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-user"></use></svg>
                                <span class="steppers-text">Collaboratori istruttoria<span class="visually-hidden">Attivo</span></span>
                            </a>
                        </li>
                        <li>
                            <a class="steppers-link" type="button" title='Ricevibilità domande' href="../istruttoria/Ricevibilita.aspx">
                                <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-check-circle"></use>
                            </svg>
                                <span class="steppers-text">Ricevibilità domande</span>
                            </a>
                        </li>
                        <li>
                            <a class="steppers-link" type="button" title='Ammissibilità domande' href="../istruttoria/Ammissibilita.aspx">
                                <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-check"></use>
                            </svg>
                                <span class="steppers-text">Ammissibilità domande</span>
                            </a>
                        </li>
                        <li>
                            <a class="steppers-link" type="button" title='Graduatoria' href="../istruttoria/Graduatoria.aspx">
                                <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-list"></use>
                            </svg>
                                <span class="steppers-text">Graduatoria</span>
                            </a>
                        </li>
                    </ul>
                </div>
                <nav class="steppers-nav">
                    <button type="button" onclick="location = 'statistiche.aspx'" class="btn btn-outline-primary btn-sm steppers-btn-prev"><svg class="icon icon-primary"><use href="/web/bootstrap-italia/svg/sprites.svg#it-chevron-left"></use></svg>Indietro</button>
                    <button type="button" onclick="location = 'Ricevibilita.aspx'" class="btn btn-outline-primary btn-sm steppers-btn-next">Avanti<svg class="icon icon-primary"><use href="/web/bootstrap-italia/svg/sprites.svg#it-chevron-right"></use></svg></button>                
                </nav>
                <div class="steppers-content" aria-live="polite">
                    <div class="row py-5 bd-form mx-2">
                        <h2 class="pb-5">Elenco dei funzionari istruttori per il bando</h2>
                        <div class="col-sm-12">
                            <div class="row">
                                <div class="col-sm-6">
                                    <Siar:ComboProvince Label="Applica filtro per provincia:" ID="lstProvincia" runat="server" CodRegione="11" AutoPostBack="true">
                                    </Siar:ComboProvince>
                                </div>
                                <div class="col-sm-3">
                                    <Siar:Button ID="btnVisualizzaListaIstruttori" runat="server" Text="Visualizza lista istruttori"
                                        OnClick="btnVisualizzaListaIstruttori_Click" />
                                </div>
                                <div class="col-sm-3">
                                    <input id="btnNuovo" runat="server" type="button" onclick="location = 'AssegnazioneDomande.aspx'"
                                        value="Assegnazione domande pervenute" class="btn btn-secondary py-1" />
                                </div>
                                <div class="col-sm-12 mt-5">
                                    <asp:HiddenField ID="hdnVisualizzaListaIstruttori" runat="server" />
                                    <Siar:DataGridAgid CssClass="table table-striped" ID="dgIstruttori" runat="server" AutoGenerateColumns="False" Width="100%"
                                        ShowFooter="true">
                                        <Columns>
                                            <Siar:ColonnaLink DataField="Nominativo" HeaderText="Istruttore" IsJavascript="true"
                                                LinkFields="IdUtente" LinkFormat="alert('L`operatore non possiede i necessari permessi per proseguire.');">
                                            </Siar:ColonnaLink>
                                            <asp:BoundColumn DataField="Provincia" HeaderText="Provincia">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn HeaderText="Nr. domande assegnate">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn HeaderText="Nr. domande ricevibili">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn HeaderText="Nr. domande NON ricevibili">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn HeaderText="Nr. domande ammissibili">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn HeaderText="Nr. domande NON ammissibili">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn HeaderText="Nr. domande istruite da altri">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundColumn>
                                            <%--<asp:BoundColumn HeaderText="Totale">
                            <ItemStyle HorizontalAlign="Center" Width="90px" />
                        </asp:BoundColumn>--%>
                                        </Columns>
                                    </Siar:DataGridAgid>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-12 mt-5">
                            <span>Domande presentate: <b>
                                <Siar:Label ID="lblDomandePresentate" runat="server"></Siar:Label>
                            </b></span>
                        </div>
                        <div class="col-sm-12">
                            <span>Domande non ancora assegnate:<b><Siar:Label ID="lblDomande" runat="server"></Siar:Label>
                            </b></span>
                        </div>
                        <div class="col-sm-12">
                            <span></span>
                        </div>
                        <h3 class="pb-5">Elenco dei funzionari collaboratori all'istruttoria del bando</h3>
                        <p>I collaboratori all'istruttoria vengono nominati a livello di Bando e collaborano con gli istruttori all'istruttoria delle domande. I collaboratori all'istruttoria non possono firmare le istruttoria ma solo istruire le pratiche, pertanto non ha senso inserire tra i collaboratori all'istruttoria qualcuno che sia già istruttore di una o più domande, in quanto questo lo inibirebbe alla firma delle istruttorie stesse. Quindi è sempre bene inserire come collaboratori all'istruttoria funzionari che non siano istruttori di nessuna domanda ne RUP.</p>
                        <div class="col-sm-12 form-group">
                            <Siar:TextBox  Label="Nominativo" ID="txtNominativo" runat="server" />
                            <asp:HiddenField ID="hdnIdUtente" runat="server" />
                        </div>
                        <div class="col-sm-12">
                            <Siar:Button ID="btnAssegna" runat="server" OnClick="btnAssegna_Click" Text="Assegna collaboratore" Modifica="True" />
                            <Siar:Button ID="btnEliminaCollaboratore" runat="server" OnClick="btnEliminaCollaboratore_Click"
                                Conferma="Attenzione! Eliminare il collaboratore selezionato?" Text="Elimina collabotatore" Modifica="True" />
                            <Siar:Button ID="btnNewCollaboratore" runat="server" Text="Nuovo" OnClick="btnNewCollaboratore_Click"
                                CausesValidation="false" Modifica="true" />
                        </div>
                        <div class="col-sm-12">
                            <Siar:DataGridAgid CssClass="table table-striped" ID="dgCollaboratoriIstruttoriaBando" runat="server" AutoGenerateColumns="False" Width="100%"
                                ShowFooter="true">
                                <Columns>
                                    <Siar:ColonnaLink DataField="Nominativo" HeaderText="Nominativo" LinkFields="Id"
                                        LinkFormat='javascript:selezionaMembro({0})'>
                                    </Siar:ColonnaLink>
                                    <asp:BoundColumn DataField="Attivo" HeaderText="Attivo" DataFormatString="{0:SI|NO}">
                                        <ItemStyle Width="80px" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                </Columns>
                            </Siar:DataGridAgid>
                        </div>
                        <h3 class="pb-5">Vai alle pagine:</h3>
                        <div class="row">
                            <div class="col-lg-3">
                                <!--start card-->
                                <div class="card-wrapper">
                                    <div class="card card-bg">
                                        <div class="card-body">
                                            <div class="categoryicon-top">
                                                <svg class="icon">
                                                        <use href="/web/bootstrap-italia/svg/sprites.svg#it-arrow-right-circle"></use>
                                                    </svg>
                                                <span class="text">Comunicazione non ricevibilità</span>
                                            </div>
                                            <div class="row">
                                                <div class="col-sm-12 text-center">
                                                    <input type="button" class="btn btn-outline-primary btn-sm steppers-btn-next" onclick="location = 'ComunicazioneNonRicevibilita.aspx'" value="Vai alla sezione" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <!--start card-->
                                <div class="card-wrapper">
                                    <div class="card card-bg">
                                        <div class="card-body">
                                            <div class="categoryicon-top">
                                                <svg class="icon">
                                                        <use href="/web/bootstrap-italia/svg/sprites.svg#it-arrow-right-circle"></use>
                                                    </svg>
                                                <span class="text">Comunicazione non ammissibilità</span>
                                            </div>
                                            <div class="row">
                                                <div class="col-sm-12 text-center">
                                                    <input type="button" class="btn btn-outline-primary btn-sm steppers-btn-next" onclick="location = 'ComunicazioneNonAmmissibilita.aspx'" value="Vai alla sezione" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <!--start card-->
                                <div class="card-wrapper">
                                    <div class="card card-bg">
                                        <div class="card-body">
                                            <div class="categoryicon-top">
                                                <svg class="icon">
                                                        <use href="/web/bootstrap-italia/svg/sprites.svg#it-arrow-right-circle"></use>
                                                    </svg>
                                                <span class="text">Comunicazione esito istruttorio</span>
                                            </div>
                                            <div class="row">
                                                <div class="col-sm-12 text-center">
                                                    <input type="button" class="btn btn-outline-primary btn-sm steppers-btn-next" onclick="location = 'ComunicazioneEsitoIstruttorio.aspx'" value="Vai alla sezione" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <!--start card-->
                                <div class="card-wrapper">
                                    <div class="card card-bg">
                                        <div class="card-body">
                                            <div class="categoryicon-top">
                                                <svg class="icon">
                                                        <use href="/web/bootstrap-italia/svg/sprites.svg#it-arrow-right-circle"></use>
                                                    </svg>
                                                <span class="text">Comunicazioni in entrata</span>
                                            </div>
                                            <div class="row">
                                                <div class="col-sm-12 text-center">
                                                    <input type="button" class="btn btn-outline-primary btn-sm steppers-btn-next" onclick="location = 'ComunicazioniEntrata.aspx'" value="Vai alla sezione" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row pt-3">
                            <div class="col-lg-3">
                                <!--start card-->
                                <div class="card-wrapper">
                                    <div class="card card-bg">
                                        <div class="card-body">
                                            <div class="categoryicon-top">
                                                <svg class="icon">
                                                        <use href="/web/bootstrap-italia/svg/sprites.svg#it-arrow-right-circle"></use>
                                                    </svg>
                                                <span class="text">Rapporto istruttorio</span>
                                            </div>
                                            <div class="row">
                                                <div class="col-sm-12 text-center">
                                                    <input type="button" class="btn btn-outline-primary btn-sm steppers-btn-next" onclick="location = 'RapportoIstruttorio.aspx'" value="Vai alla sezione" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <!--start card-->
                                <div class="card-wrapper">
                                    <div class="card card-bg">
                                        <div class="card-body">
                                            <div class="categoryicon-top">
                                                <svg class="icon">
                                                        <use href="/web/bootstrap-italia/svg/sprites.svg#it-arrow-right-circle"></use>
                                                    </svg>
                                                <span class="text">Comunicazione di finanziabilità</span>
                                            </div>
                                            <div class="row">
                                                <div class="col-sm-12 text-center">
                                                    <input type="button" class="btn btn-outline-primary btn-sm steppers-btn-next" onclick="location = 'ComunicazioneFinanziabilita.aspx'" value="Vai alla sezione" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <!--start card-->
                                <div class="card-wrapper">
                                    <div class="card card-bg">
                                        <div class="card-body">
                                            <div class="categoryicon-top">
                                                <svg class="icon">
                                                        <use href="/web/bootstrap-italia/svg/sprites.svg#it-arrow-right-circle"></use>
                                                    </svg>
                                                <span class="text">Richieste documentali</span>
                                            </div>
                                            <div class="row">
                                                <div class="col-sm-12 text-center">
                                                    <input type="button" class="btn btn-outline-primary btn-sm steppers-btn-next" onclick="location = 'ListaComunicazioni.aspx'" value="Vai alla sezione" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
<%--                            <table>
                                <tr>
                                    <td style="height: 34px; width: 759px;">
                                        <input type="button" onclick="location = 'ComunicazioneNonRicevibilita.aspx'" value="Comunicazione non ricevibilità"
                                            style="width: 230px" class="Button" />
                                        &nbsp;&nbsp;
                            <input type="button" onclick="location = 'ComunicazioneNonAmmissibilita.aspx'" value="Comunicazione non ammissibilità"
                                style="width: 230px" class="Button" />
                                        &nbsp; &nbsp;<input type="button" onclick="location = 'ComunicazioneEsitoIstruttorio.aspx'"
                                            value="Comunicazione esito istruttorio" style="width: 230px" class="Button" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 34px; width: 759px;">
                                        <input type="button" onclick="location = 'ComunicazioniEntrata.aspx'" value="Comunicazioni in entrata"
                                            style="width: 230px" class="Button" />
                                        &nbsp;&nbsp;
                            <input type="button" onclick="location = 'RapportoIstruttorio.aspx'" value="Rapporto istruttorio"
                                style="width: 230px" class="Button" />&nbsp;&nbsp;&nbsp;
                            <input type="button" onclick="location = 'ComunicazioneFinanziabilita.aspx'" value="Comunicazione di finanziabilità"
                                style="width: 230px" class="Button" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 34px; width: 759px;">
                                        <input type="button" onclick="location = 'DecretiDecadenza.aspx'" value="Decreti di decadenza"
                                            style="width: 230px; display: none;" class="Button" />                                        
                                        <input type="button" onclick="location = 'ListaComunicazioni.aspx'" value="Richieste documentali"
                                            style="width: 230px" class="Button" />
                                    </td>
                                </tr>
                            </table>--%>
                        </div>
                    </div>

                </div>
                <nav class="steppers-nav">
                    <button type="button" onclick="location = 'statistiche.aspx'" class="btn btn-outline-primary btn-sm steppers-btn-prev"><svg class="icon icon-primary"><use href="/web/bootstrap-italia/svg/sprites.svg#it-chevron-left"></use></svg>Indietro</button>
                    <button type="button" onclick="location = 'Ricevibilita.aspx'" class="btn btn-outline-primary btn-sm steppers-btn-next">Avanti<svg class="icon icon-primary"><use href="/web/bootstrap-italia/svg/sprites.svg#it-chevron-right"></use></svg></button>                
                </nav>
            </div>
        </div>
    </div>
</asp:Content>
