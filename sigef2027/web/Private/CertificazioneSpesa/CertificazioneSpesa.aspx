<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SigefAgidPrivate.master"
    CodeBehind="CertificazioneSpesa.aspx.cs" Inherits="web.Private.CertificazioneSpesa.CertificazioneSpesa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript">
        function estraiInXls() {
            var psr = $('[id$=lstPsr]').val(),
                data_inizio = $('[id$=txtDataInizio_text]').val(),
                data_fine = $('[id$=txtDataFine_text]').val();
            if (psr == '')
                alert("Specificare il Programma di sviluppo desiderato.");
            else if (data_inizio == '') 
                alert("Specificare la data di inizio del periodo.");
            else 
                SNCVisualizzaReport('rptCertificazioniRiepilogoSpesa',2,"CodPsr="+psr+"|DataInizio="+data_inizio+(data_fine==''?'':"|DataFine="+data_fine));
        }
    </script>


    <div class="row">
        <div class="col-2">
            Programmazione:<br />
            <Siar:ComboZPsr ID="lstPsr" runat="server" Obbligatorio="true" NomeCampo="Psr" Width="350px"></Siar:ComboZPsr>
        </div>

        <div class="col-2">
            Data inizio:<br />
            <Siar:DateTextBox ID="txtDataInizio" runat="server" Width="104px" />
        </div>
        <div class="col-2">
            Data fine:<br />
            <Siar:DateTextBox ID="txtDataFine" runat="server" Width="104px" />
            <div class="col-2">
                <br />
                <Siar:Button ID="btnCerca" runat="server" OnClick="btnCerca_Click" Text="Cerca" Width="140px" />
            </div>
            <div class="col-2">
                <br />
                <input type="button" class="Button" value="Estrai in xls" style="width: 140px" onclick="return estraiInXls();" />
            </div>
        </div>
    </div>

       
    
        <h4>Spesa suddivisa per priorità e per categoria di regioni, come contabilizzata dall'autorità di certificazione</h4>
            
        <p>
        compresi gli importi dei contributi per programma erogati agli strumenti finanziari
        (articolo 41 del regolamento (UE) n. 1303/2013) e gli anticipi versati nel quadro
        di aiuti di Stato (articolo 131, paragrafo 5, del regolamento (UE) n. 1303/2013)
        </p>

        <div class="row">
            <div class="col-12">
                <div class="table-responsive">
                    <Siar:DataGridAgid ID="dgSpese" runat="server" ShowFooter="true" AutoGenerateColumns="False" CssClass="table table-striped" PageSize="20">
                        <itemstyle height="30px" />
                        <footerstyle cssclass="coda" horizontalalign="Right" />
                        <columns>
                            <Siar:NumberColumn HeaderText="Nr.">
                                <itemstyle width="50px" horizontalalign="center" />
                                <footerstyle width="50px" horizontalalign="center" />
                            </Siar:NumberColumn>
                            <asp:BoundColumn HeaderText="Asse">
                                <itemstyle width="200px" horizontalalign="center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Base calcolo (solo contributo pubblico o spesa totale compresa quella dei privati o altro pubblico)">
                                <itemstyle width="200px" horizontalalign="center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Importo totale delle spese ammissibili sostenute dai beneficiari e pagate nell'attuazione delle operazioni">
                                <itemstyle width="200px" horizontalalign="center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Importo totale della spesa pubblica relativa all'attuazione delle operazioni">
                                <itemstyle width="200px" horizontalalign="center" />
                            </asp:BoundColumn>
                        </columns>
                    </Siar:DataGridAgid>
                </div>
            </div>
        </div>

       
        <p>
            Informazioni sugli importi dei contributi per programma erogati agli strumenti finanziari
                        e inclusi nelle domande di pagamento
        </p>


        <p class="testo_pagina">
            Come da articolo 41 del regolamento (UE) n. 1303/2013. I dati sono cumulativi dall'inizio
                del programma.
        </p>
        
       <div class="row">
            <div class="col-12">
                <div class="table-responsive">
                <Siar:DataGridAgid ID="dgSpeseStrumentiFinanziari" ShowFooter="true" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" PageSize="20">
                    <ItemStyle Height="30px" />
                    <FooterStyle CssClass="coda" HorizontalAlign="Right" />
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle Width="50px" HorizontalAlign="center" />
                            <FooterStyle Width="50px" HorizontalAlign="center" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn HeaderText="Asse">
                            <ItemStyle Width="200px" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Importo complessivo dei contributi per programma erogati agli strumenti finanziari">
                            <ItemStyle Width="200px" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Importo della spesa pubblica corrispondente">
                            <ItemStyle Width="200px" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Importo complessivo dei contributi del programma effettivamente erogati o, nel caso delle garanzie, impegnati a titolo di spesa ammissibile ai sensi dell'articolo 42, paragrafo 1, lettere a), b) e d), del regolamento (UE) n. 1303/2013">
                            <ItemStyle Width="200px" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Importo della spesa pubblica corrispondente">
                            <ItemStyle Width="200px" HorizontalAlign="center" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGridAgid>
          </div>
        </div>
    </div>

    <h4>Anticipi versati nel quadro di aiuti di Stato</h4>                    
        <p>Articolo 131, paragrafo 5, del regolamento (UE) n. 1303/2013) e inclusi nelle domande
            di pagamento (dati cumulativi dall'inizio del programmma.
        </p>
      <div class="row">
            <div class="col-12">
                <div class="table-responsive">
                <Siar:DataGridAgid ID="dgSpeseAnticipi" runat="server" ShowFooter="true" AutoGenerateColumns="False" CssClass="table table-striped" PageSize="20">
                    <ItemStyle Height="30px" />
                    <FooterStyle CssClass="coda" HorizontalAlign="Right" />
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle Width="50px" HorizontalAlign="center" />
                            <FooterStyle Width="50px" HorizontalAlign="center" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn HeaderText="Asse">
                            <ItemStyle Width="200px" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Importo complessivo versato come anticipo dal programma operativo">
                            <ItemStyle Width="200px" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Importo che è stato coperto dalle spese sostenute dai beneficiari entro tre anni dal pagamento dell'anticipo">
                            <ItemStyle Width="200px" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Importo che non è stato coperto dalle spese sostenute dai beneficiari e per il quale il periodo di tre anni non è ancora trascorso">
                            <ItemStyle Width="200px" HorizontalAlign="center" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGridAgid>
            </div>
        </div>
    </div>
</asp:Content>
