<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    CodeBehind="IstruttoriaCorrettivaRendicontazione.aspx.cs" Inherits="web.Private.IPagamento.IstruttoriaCorrettivaRendicontazione" %>

<%@ Register Src="../../CONTROLS/IDomandaPagamento.ascx" TagName="IDomandaPagamento"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <script type="text/javascript"><!--
        var SPS /*spostamento selezionato*/,selezione_investimento_partenza=true,ricalcola_pagamenti_richiesti=false;
        function deselezionaSpostamento() { $('[id$=hdnJsonDatiSpostamento]').val('');$('[id$=hdnIdSpostamentoSelezionato]').val('');$('[id$=btnPost]').click(); }
        function selezionaSpostamento(id) { $('[id$=hdnJsonDatiSpostamento]').val('');$('[id$=hdnIdSpostamentoSelezionato]').val(id);$('[id$=btnPost]').click(); }
        function nuovoSpostamento() { $('[id$=hdnIdSpostamentoSelezionato]').val('NuovoSpostamento');$('[id$=txtDescrizioneSpostamento_text]').val('');$('[id$=txtStatoSpostamento]').val('');clearInvestimentoPartenza();clearInvestimentoArrivo();$('[id$=btnPost]').click(); }
        function clearInvestimentoPartenza() { if(SPS) { SPS.PagamentoDa={};SPS.PagamentoDa.IdInvestimento=0; } $('#tdPagBenPartenza').html('');$('input[id*="txtIP"]').val(''); }
        function clearInvestimentoArrivo() { if(SPS) { SPS.PagamentoA={};SPS.PagamentoA.IdInvestimento=0; } $('#tdPagBenArrivo').html('');$('input[id*="txtIA"]').val(''); }
        function selezionaInvestimentoPartenza() { if(SPS.IdSpostamento>0) alert('Non è più possibile cambiare gli investimenti una volta che si siano modificati gli importi richiesti.');else { selezione_investimento_partenza=true;clearInvestimentoPartenza();caricaInvestimenti(0); } }
        function selezionaInvestimentoArrivo() { if(SPS.IdSpostamento>0) alert('Non è più possibile cambiare gli investimenti una volta che si siano modificati gli importi richiesti.');else { selezione_investimento_partenza=false;clearInvestimentoArrivo();caricaInvestimenti(0); } }
        function caricaInvestimenti(indice_pagina) { mostraPopupTemplate('divSelezionaInvestimento','divBKGMessaggio');$('#tdSelInvIntestazione').text("Seleziona investimento di "+(selezione_investimento_partenza?"PARTENZA:":"ARRIVO:"));cercaInvestimenti(indice_pagina); }
        function cercaInvestimenti(indice_pagina) { $('#tdDivSelInvDatagrid').html("<b>attendere prego..</b>");$.post('../../CONTROLS/ajaxRequest.aspx',{ "type": "getPianoInvestimenti","zoomdg_page_index": indice_pagina },function(msg) { $('#tdDivSelInvDatagrid').html(msg);mostraPopupTemplate('divSelezionaInvestimento','divBKGMessaggio'); },"html"); }
        function scegliInvestimento(id) { if(selezione_investimento_partenza) scegliInvestimentoPartenza(id);else scegliInvestimentoArrivo(id); }
        function scegliInvestimentoPartenza(id) { if(id==SPS.PagamentoA.IdInvestimento) alert('L`investimento di partenza coincide con quello di arrivo. Selezionarne un altro.');else { SPS.PagamentoDa.IdInvestimento=id;$('[id$=hdnJsonDatiSpostamento]').val(sjsConvertiOggettoToJsonString(SPS));chiudiPopupTemplate();$('[id$=btnPost]').click(); } }
        function scegliInvestimentoArrivo(id) { if(id==SPS.PagamentoDa.IdInvestimento) alert('L`investimento di arrivo coincide con quello di partenza. Selezionarne un altro.');else { SPS.PagamentoA.IdInvestimento=id;$('[id$=hdnJsonDatiSpostamento]').val(sjsConvertiOggettoToJsonString(SPS));chiudiPopupTemplate();$('[id$=btnPost]').click(); } }
        function visualizzaInvestimentoPartenza() { if(SPS.PagamentoDa.IdInvestimento>0) SNCVisualizzaReport('rptInvestimentoOriginale',1,'IdInvestimento='+SPS.PagamentoDa.IdInvestimento);else alert('Selezionare l`investimento di partenza.'); }
        function istruttoriaPagamentoPartenza() { if(SPS.PagamentoDa.IdInvestimento>0) location='IstruttoriaInvestimento.aspx?idinv='+SPS.PagamentoDa.IdInvestimento;else alert('Selezionare l`investimento di partenza.'); }
        function visualizzaInvestimentoArrivo() { if(SPS.PagamentoA.IdInvestimento>0) SNCVisualizzaReport('rptInvestimentoOriginale',1,'IdInvestimento='+SPS.PagamentoA.IdInvestimento);else alert('Selezionare l`investimento di partenza.'); }
        function istruttoriaPagamentoArrivo() { if(SPS.PagamentoA.IdInvestimento>0) location='IstruttoriaInvestimento.aspx?idinv='+SPS.PagamentoA.IdInvestimento;else alert('Selezionare l`investimento di partenza.'); }
        function loadSpostamentoJson() { ricalcola_pagamenti_richiesti=false;SPS=eval('('+$('[id$=hdnJsonDatiSpostamento]').val()+')');if(typeof (SPS)!='undefined') popolaPagamenti(); }
        function popolaPagamenti() { popolaPagamentiBeneficiarioPartenza();popolaPagamentiBeneficiarioArrivo(); }
        function salvaTutto(ev,chiudi_spostamento) {
            if($('[id$=txtDescrizioneSpostamento_text]').val()=='') { alert('Digitare una breve descrizione dello spostamento.');return stopEvent(ev); }
            else if(SPS.PagamentoDa.IdInvestimento<1) { alert('Selezionare l`investimento di partenza.');return stopEvent(ev); }
            else if(SPS.PagamentoA.IdInvestimento<1) { alert('Selezionare l`investimento di arrivo.');return stopEvent(ev); }
            else if(!confirm('Salvare le modifiche al pagamento?')) return stopEvent(ev);
            else {
                SPS.PagamentoDa.ImportoComputoMetrico=FromCurrencyToNumber($('[id$=txtIPPRComputoMetrico_text]').val());SPS.PagamentoA.ImportoComputoMetrico=FromCurrencyToNumber($('[id$=txtIAPRComputoMetrico_text]').val());
                if(((!SPS.PagamentoDa.InvestimentoMobile&&SPS.PagamentoDa.ImportoComputoMetrico<=0&&SPS.PagamentoDa.ImportoFatture>0)||(!SPS.PagamentoA.InvestimentoMobile&&SPS.PagamentoA.ImportoComputoMetrico<=0&&SPS.PagamentoA.ImportoFatture>0))&&!confirm('Attenzione! Non è stato specificato l`importo a Computo Metrico per almeno uno dei due investimenti, ciò significa che il contributo relativo sarà pari a zero. Continuare?')) return stopEvent(ev);
                else $('[id$=hdnJsonDatiSpostamento]').val(sjsConvertiOggettoToJsonString(SPS));
            }
        }
        var page_size=10;
        function popolaPagamentiBeneficiarioPartenza(indice_pagina) {
            var html="<br /><b>Nessun elemento trovato.</b><br />";
            //if(SPS.PagamentoDa.IdPagamentoRichiesto>0) {
            SPS.PagamentoDa.ImportoFatture=SPS.PagamentoDa.ImportoSpeseTecnicheRichieste=SPS.PagamentoDa.ImportoLavoriEconomia=0;
            var pben=SPS.PagamentoDa.PB;if(pben&&pben.length&&pben.length>0) {
                if(!indice_pagina) indice_pagina=0;
                html="&nbsp;<table style='width:100%;border-collapse:collapse' border=1 cellSpacing=0><tr class='TESTA1'><td>Nr.</td><td>&nbsp;</td><td>&nbsp;</td><td>Richiesto</td><td>Importo da spostare</td></tr>";
                for(var i=0;i<pben.length;i++) {
                    if(!isNaN(pben[i].ImportoRichiesto)) { // ricalcolo il pagamento richiesto
                        if(pben[i].SpesaTecnicaRichiesta) SPS.PagamentoDa.ImportoSpeseTecnicheRichieste+=pben[i].ImportoRichiesto;
                        else SPS.PagamentoDa.ImportoFatture+=pben[i].ImportoRichiesto;
                        if(pben[i].LavoriInEconomia) SPS.PagamentoDa.ImportoLavoriEconomia+=pben[i].ImportoRichiesto;
                    }
                    if(i>=page_size*indice_pagina&&i<page_size*(indice_pagina+1))
                        html+="<tr style='height:40px' class=DataGridRow><td style='width:20px' align=center>"+(i+1)
                        +"</td><td style='width:30px' align=center>"+(pben[i].LavoriInEconomia?"":"<IMG style='cursor:pointer' onclick=\"SNCVisualizzaReport('rptGiustificativo',1,'IdGiustificativo="
                        +pben[i].IdGiustificativo+"');\" alt='Visualizza giustificativo' src='../../images/acrobat.gif'>")+"</td><td><b>Tipo:</b> "+pben[i].TipoGiustificativo
                        +(pben[i].LavoriInEconomia?"":" nr. "+pben[i].Numero+" data: "+pben[i].Data+"<br /><b>D.D.T:</b> nr. "+pben[i].NumeroDoctrasporto+"data: "+pben[i].DataDoctrasporto
                        +"<br><b>Imponibile:</b> € "+FromNumberToCurrency(pben[i].Imponibile))+"<br /><b>Oggetto spesa:</b> "+pben[i].Descrizione
                        +"</td><td style='width:130px'><b>Importo:</b><span class='"+(pben[i].Modificato&&pben[i].ImportoSpostato>0?'testoRosso':'')+"'> € "+FromNumberToCurrency(pben[i].ImportoRichiesto)+"</span><br><b>Spesa tecnica:</b> "+(pben[i].SpesaTecnicaRichiesta?"SI":"NO")
                        +"</td><td style='width:150px' align=center><table width='120px'><tr><td style='border:0'><input style='text-align:right;width:100px' id='txtPagBenPAImporto"
                        +pben[i].IdPagamentoBeneficiario+"' value='0' onblur='cb_blur(this);' onfocus='this.isEnabled=function(){return !(this.disabled||this.readOnly);};cb_focus(this);' onkeypress='cb_keypress(this,event);' /></td><td style='border:0'>"
                        +"<img src='../../images/arrow_right.gif' alt='Sposta importo indicato' style='cursor:pointer' onclick=\"spostaPagamentoInArrivo("+pben[i].IdPagamentoBeneficiario+");\" /></td></tr></table></td></tr>";
                }
                html+="<tr class=coda><td style='padding-left:5px;width:100%' colSpan=5>";
                var nr_pagine=Math.ceil(pben.length/page_size);for(var j=0;j<nr_pagine;j++)
                    html+="<span"+(j==indice_pagina?"":" style='color:#084600' class='selectable' onclick='popolaPagamentiBeneficiarioPartenza("+j+")'")+">&nbsp;"+(j+1)+"&nbsp;</span>";
                html+="</td></tr></table>";
            }
            if(ricalcola_pagamenti_richiesti) {
                if(!SPS.PagamentoDa.InvestimentoMobile) SPS.PagamentoDa.ImportoComputoMetrico=FromCurrencyToNumber($('[id$=txtIPPRComputoMetrico_text]').val());
                SPS.PagamentoDa.ImportoRichiesto=(SPS.PagamentoDa.InvestimentoMobile?SPS.PagamentoDa.ImportoFatture:Math.min(SPS.PagamentoDa.ImportoComputoMetrico,SPS.PagamentoDa.ImportoFatture))+SPS.PagamentoDa.ImportoSpeseTecnicheRichieste;
                SPS.PagamentoDa.ContributoRichiesto=(SPS.PagamentoDa.ImportoRichiesto*SPS.PagamentoDa.QuotaContributoInvestimento)/100;
                if(SPS.PagamentoDa.ContributoRichiesto>SPS.PagamentoDa.ContributoInvestimento) SPS.PagamentoDa.ContributoRichiesto=SPS.PagamentoDa.ContributoInvestimento;
            }
            $('[id$=txtIPPRImporto_text]').val(FromNumberToCurrency(SPS.PagamentoDa.ImportoFatture));
            $('[id$=txtIPPRLavoriEconomia_text]').val(FromNumberToCurrency(SPS.PagamentoDa.ImportoLavoriEconomia));
            if(!SPS.PagamentoDa.InvestimentoMobile) $('[id$=txtIPPRComputoMetrico_text]').val(FromNumberToCurrency(SPS.PagamentoDa.ImportoComputoMetrico));
            $('[id$=txtIPPRSpeseTecniche_text]').val(FromNumberToCurrency(SPS.PagamentoDa.ImportoSpeseTecnicheRichieste));
            $('[id$=txtIPPRCosto_text]').val(FromNumberToCurrency(SPS.PagamentoDa.ImportoRichiesto));
            $('[id$=txtIPPRContributo_text]').val(FromNumberToCurrency(SPS.PagamentoDa.ContributoRichiesto));
            //}
            $('#tdPagBenPartenza').html(html);
        }
        function popolaPagamentiBeneficiarioArrivo(indice_pagina) {//debugger;
            var html="<br /><b>Nessun elemento trovato.</b><br /><br />";
            //if(SPS.PagamentoA.IdPagamentoRichiesto>0) {
            SPS.PagamentoA.ImportoFatture=SPS.PagamentoA.ImportoSpeseTecnicheRichieste=SPS.PagamentoA.ImportoLavoriEconomia=0;
            var pben=SPS.PagamentoA.PB;if(pben&&pben.length&&pben.length>0) {
                if(!indice_pagina) indice_pagina=0;
                html="&nbsp;<table style='width:100%;border-collapse:collapse' border=1 cellSpacing=0><tr class='TESTA1'><td>Nr.</td><td>&nbsp;</td><td>&nbsp;</td><td>Richiesto</td><td>Importo da spostare</td></tr>";
                for(var i=0;i<pben.length;i++) {
                    if(!isNaN(pben[i].ImportoRichiesto)) { // ricalcolo il pagamento richiesto
                        if(pben[i].SpesaTecnicaRichiesta) SPS.PagamentoA.ImportoSpeseTecnicheRichieste+=pben[i].ImportoRichiesto;
                        else SPS.PagamentoA.ImportoFatture+=pben[i].ImportoRichiesto;
                        if(pben[i].LavoriInEconomia) SPS.PagamentoA.ImportoLavoriEconomia+=pben[i].ImportoRichiesto;
                    }
                    if(i>=page_size*indice_pagina&&i<page_size*(indice_pagina+1))
                        html+="<tr style='height:40px' class=DataGridRow><td style='width:20px' align=center>"+(i+1)
                        +"</td><td style='width:30px' align=center>"+(pben[i].LavoriInEconomia?"":"<IMG style='cursor:pointer' onclick=\"SNCVisualizzaReport('rptGiustificativo',1,'IdGiustificativo="
                        +pben[i].IdGiustificativo+"');\" alt='Visualizza giustificativo' src='../../images/acrobat.gif'>")+"</td><td><b>Tipo:</b> "+pben[i].TipoGiustificativo
                        +(pben[i].LavoriInEconomia?"":" nr. "+pben[i].Numero+" data: "+pben[i].Data+"<br /><b>D.D.T:</b> nr. "+pben[i].NumeroDoctrasporto+"data: "
                        +pben[i].DataDoctrasporto+"<br><b>Imponibile:</b> € "+FromNumberToCurrency(pben[i].Imponibile))+"<br><b>Oggetto spesa:</b> "+pben[i].Descrizione
                        +"</td><td style='width:130px'><b>Importo:</b><span class='"+(pben[i].Modificato&&pben[i].ImportoSpostato>0?'testoRosso':'')+"'> € "+FromNumberToCurrency(pben[i].ImportoRichiesto)+"</span><br><b>Spesa tecnica:</b> "+(pben[i].SpesaTecnicaRichiesta?"SI":"NO")
                        +"</td><td style='width:150px' align=center>"+(pben[i].Modificato?"<table width='120px'><tr><td style='border:0'><img src='../../images/arrow_left.gif' alt='Sposta importo indicato' style='cursor:pointer' onclick=\"spostaPagamentoInPartenza("
                        +pben[i].IdPagamentoBeneficiario+");\" /></td><td style='border:0'><input style='text-align:right;width:100px' id='txtPagBenARImporto"+pben[i].IdPagamentoBeneficiario
                        +"' value='0' onblur='cb_blur(this);' onfocus='this.isEnabled=function(){return !(this.disabled||this.readOnly);};cb_focus(this);' onkeypress='cb_keypress(this,event);' /></td></tr></table>":"&nbsp;")+"</td></tr>";
                }
                html+="<tr class=coda><td style='padding-left:5px' colSpan=5>";
                var nr_pagine=Math.ceil(pben.length/page_size);for(var j=0;j<nr_pagine;j++)
                    html+="<span"+(j==indice_pagina?"":" style='color:#084600' class='selectable' onclick='popolaPagamentiBeneficiarioArrivo("+j+")'")+">&nbsp;"+(j+1)+"&nbsp;</span>";
                html+="</td></tr></table>";
            }
            if(ricalcola_pagamenti_richiesti) {
                if(!SPS.PagamentoA.InvestimentoMobile) SPS.PagamentoA.ImportoComputoMetrico=FromCurrencyToNumber($('[id$=txtIAPRComputoMetrico_text]').val());
                SPS.PagamentoA.ImportoRichiesto=(SPS.PagamentoA.InvestimentoMobile?SPS.PagamentoA.ImportoFatture:Math.min(SPS.PagamentoA.ImportoComputoMetrico,SPS.PagamentoA.ImportoFatture))+SPS.PagamentoA.ImportoSpeseTecnicheRichieste;
                SPS.PagamentoA.ContributoRichiesto=(SPS.PagamentoA.ImportoRichiesto*SPS.PagamentoA.QuotaContributoInvestimento)/100;
                if(SPS.PagamentoA.ContributoRichiesto>SPS.PagamentoA.ContributoInvestimento) SPS.PagamentoA.ContributoRichiesto=SPS.PagamentoA.ContributoInvestimento;
            }
            $('[id$=txtIAPRImporto_text]').val(FromNumberToCurrency(SPS.PagamentoA.ImportoFatture));
            $('[id$=txtIAPRLavoriEconomia_text]').val(FromNumberToCurrency(SPS.PagamentoA.ImportoLavoriEconomia));
            if(!SPS.PagamentoA.InvestimentoMobile) $('[id$=txtIAPRComputoMetrico_text]').val(FromNumberToCurrency(SPS.PagamentoA.ImportoComputoMetrico));
            $('[id$=txtIAPRSpeseTecniche_text]').val(FromNumberToCurrency(SPS.PagamentoA.ImportoSpeseTecnicheRichieste));
            $('[id$=txtIAPRCosto_text]').val(FromNumberToCurrency(SPS.PagamentoA.ImportoRichiesto));
            $('[id$=txtIAPRContributo_text]').val(FromNumberToCurrency(SPS.PagamentoA.ContributoRichiesto));
            //}
            $('#tdPagBenArrivo').html(html);
        }
        function spostaPagamentoInArrivo(idpagben) {
            if(SPS.PagamentoA.IdInvestimento<1) alert('Attenzione! E` obbligatorio selezionare l`investimento di arrivo.');
            else {
                var importo_da_spostare=FromCurrencyToNumber($('#txtPagBenPAImporto'+idpagben).val());
                if(importo_da_spostare<=0) alert('Attenzione! L`ammontare di spesa che si intende spostare deve essere maggiore di zero.');
                else {
                    // trovo il pagamento beneficiario da spostare
                    var pb_da;for(var i=0;i<SPS.PagamentoDa.PB.length;i++)
                        if(SPS.PagamentoDa.PB[i].IdPagamentoBeneficiario==idpagben) { pb_da=SPS.PagamentoDa.PB[i];break; }
                    if(!pb_da) alert('Attenzione! Pagamento non spostato.');
                    else {
                        if(pb_da.ImportoRichiesto<importo_da_spostare) alert('Attenzione! L`importo digitato supera l`ammontare del richiesto su questo giustificativo.');
                        else {
                            if(!pb_da.SpesaTecnicaRichiesta&&(!SPS.PagamentoDa.InvestimentoMobile||!SPS.PagamentoA.InvestimentoMobile)&&confirm('Aggiornare anche gli importi dei computi metrici relativi? Altrimenti le modifiche andranno fatte manualmente.')) aggiornaImportiComputiMetrici(importo_da_spostare);
                            pb_da.Modificato=true;pb_da.ImportoRichiesto-=importo_da_spostare;pb_da.ImportoSpostato+=importo_da_spostare;
                            var pb_a=sjsClonaOggetto(pb_da);var id_provvisorio=pb_da.IdPagamentoBeneficiario+'000'+(Math.floor(Math.random()*1000)+1000);
                            pb_a.IdPagamentoBeneficiario=Number(id_provvisorio);pb_a.ImportoRichiesto=importo_da_spostare;pb_a.IdPagBenOriginale=pb_da.IdPagamentoBeneficiario;
                            pb_a.ImportoSpostato=importo_da_spostare;if(!SPS.PagamentoA.PB) SPS.PagamentoA.PB=[];SPS.PagamentoA.PB.splice(0,0,pb_a);ricalcola_pagamenti_richiesti=true;popolaPagamenti();
                        }
                    }
                }
            }
        }
        function spostaPagamentoInPartenza(idpagben) {
            if(SPS.PagamentoDa.IdInvestimento<1) alert('Attenzione! E` obbligatorio selezionare l`investimento di partenza.');
            else {
                var importo_da_spostare=FromCurrencyToNumber($('#txtPagBenARImporto'+idpagben).val());
                if(importo_da_spostare<=0) alert('Attenzione! L`ammontare di spesa che si intende spostare deve essere maggiore di zero.');
                else {
                    // trovo il pagamento beneficiario da spostare
                    var pb_a;for(var i=0;i<SPS.PagamentoA.PB.length;i++) if(SPS.PagamentoA.PB[i].IdPagamentoBeneficiario==idpagben) pb_a=SPS.PagamentoA.PB[i];
                    if(!pb_a||!pb_a.Modificato) alert('Attenzione! E` possibile annullare le modifiche solo dei pagamenti precedentemente spostati in arrivo.');
                    else {
                        if(pb_a.ImportoRichiesto<importo_da_spostare) alert('Attenzione! L`importo digitato supera l`ammontare del richiesto su questo giustificativo.');
                        else {
                            // trovo il pagamento di partenza a cui ripristinare l'importo
                            var pb_da;for(var i=0;i<SPS.PagamentoDa.PB.length;i++)
                                if(SPS.PagamentoDa.PB[i].IdPagamentoBeneficiario==pb_a.IdPagBenOriginale) pb_da=SPS.PagamentoDa.PB[i];
                            if(!pb_da) alert('Attenzione! Non ho trovato nessun pagamento di partenza su cui ricaricare l`importo digitato.');
                            else {
                                if(!pb_a.SpesaTecnicaRichiesta&&(!SPS.PagamentoDa.InvestimentoMobile||!SPS.PagamentoA.InvestimentoMobile)&&confirm('Aggiornare anche gli importi dei computi metrici relativi? Altrimenti le modifiche andranno fatte manualmente.')) aggiornaImportiComputiMetrici(0-importo_da_spostare);
                                pb_a.ImportoRichiesto-=importo_da_spostare;pb_a.ImportoSpostato-=importo_da_spostare;
                                if(pb_a.ImportoRichiesto==0) { for(var i=0;i<SPS.PagamentoA.PB.length;i++) if(SPS.PagamentoA.PB[i].IdPagamentoBeneficiario==pb_a.IdPagamentoBeneficiario) { SPS.PagamentoA.PB.splice(i,1);break; } }
                                pb_da.ImportoRichiesto+=importo_da_spostare;pb_da.ImportoSpostato-=importo_da_spostare;ricalcola_pagamenti_richiesti=true;popolaPagamenti();
                            }
                        }
                    }
                }
            }
        }
        function aggiornaImportiComputiMetrici(importo/*se positivo da partenza in arrivo, altrimenti il contrario*/) {
            if(!SPS.PagamentoDa.InvestimentoMobile) { SPS.PagamentoDa.ImportoComputoMetrico-=importo;if(SPS.PagamentoDa.ImportoComputoMetrico<0) SPS.PagamentoDa.ImportoComputoMetrico=0;$('[id$=txtIPPRComputoMetrico_text]').val(FromNumberToCurrency(SPS.PagamentoDa.ImportoComputoMetrico)); }
            if(!SPS.PagamentoA.InvestimentoMobile) { SPS.PagamentoA.ImportoComputoMetrico+=importo;if(SPS.PagamentoA.ImportoComputoMetrico<0) SPS.PagamentoA.ImportoComputoMetrico=0;$('[id$=txtIAPRComputoMetrico_text]').val(FromNumberToCurrency(SPS.PagamentoA.ImportoComputoMetrico)); }
        }
//--></script>

    <br />
    <uc2:IDomandaPagamento ID="ucIDomandaPagamento" runat="server" />
    <div style="display: none">
        <asp:HiddenField ID="hdnIdSpostamentoSelezionato" runat="server" />
        <asp:HiddenField ID="hdnNuovoSpostamento" runat="server" />
        <asp:HiddenField ID="hdnJsonDatiSpostamento" runat="server" />
        <asp:Button ID="btnPost" runat="server" CausesValidation="False" OnClick="btnPost_Click" />
    </div>
    <br />
    <table class="tableNoTab" style="width: 1200px">
        <tr>
            <td class="separatore_big">
                CORRETTIVA DI RENDICONTAZIONE DELLA DOMANDA DI PAGAMENTO
            </td>
        </tr>
        <tr>
            <td style="padding: 10px">
                &nbsp;
                <table style="width: 100%;">
                    <tr>
                        <td style="width: 864px">
                            Questa pagina permette la &quot;correzione&quot; della rendicontazione dei <b>giustificativi</b>,
                            ovvero la modifica degli importi <b>richiesti</b> in domanda
                            <br />
                            di pagamento, portati a sostegno delle spese sul piano degli investimenti. Tale
                            correzione, si compone di uno o più <b>spostamenti di rendicontazione</b>,
                            <br />
                            elencati nella griglia apposita, ognuno dei quali interessa <b>2 investimenti</b>:
                            quello denominato <b>di partenza</b> riquadro a <b>sinistra</b> da cui
                            <br />
                            defalcare gli importi e quello denominato <b>di arrivo,</b> a cui attribuirli.
                            <br />
                            Una volta completata la definizione degli importi modificati tra i 2 investimenti
                            è necessario<b> chiudere</b> lo spostamento.
                            <br />
                            E&#39; possibile effettuare più spostamenti senza alcuna limitazione tranne il fatto
                            che quelli precedenti ad esso siano chiusi.<br />
                            E&#39; possibile <b>annullare</b> qualsiasi spostamento e ripristinare la situazione
                            precedente ad esso, purchè non ne sussistano altri successivi<br />
                            che interessino o l&#39;uno o l&#39;altro dei due investimenti, in tal caso risulta
                            necessario annullare anche questi.
                        </td>
                        <td align="center">
                            <input id="btnBack" class="Button" style="width: 140px" type="button" value="Indietro"
                                onclick="location='CheckListPagamento.aspx';" />&nbsp;
                        </td>
                    </tr>
                </table>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="paragrafo">
                &nbsp;Descrizione della correttiva: (è obbligatorio indicare anche la segnatura
                del verbale del C.C.M. o altro protocollo)
            </td>
        </tr>
        <tr>
            <td style="padding: 10px">
                <Siar:TextArea ID="txtDescrizioneLungaCorrettiva" runat="server" Rows="5" Width="800px"
                    Obbligatorio="true" NomeCampo="Descrizione della correttiva" />
                <br />
                <br />
                <div style="width: 783px; text-align: right;">
                    <Siar:Button ID="btnSalvaCorrettiva" runat="server" CausesValidation="true" Modifica="true"
                        OnClick="btnSalvaCorrettiva_Click" Text="Salva correttiva" Width="160px" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <input id="btnNuovoSpostamento" runat="server" class="Button" style="width: 180px"
                        type="button" value="Nuovo spostamento" onclick="nuovoSpostamento();" /></div>
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <table id="tableCorrettiva" runat="server" width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <table id="tableElencoSpostamenti" runat="server" width="100%" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td class="paragrafo">
                                        &nbsp;Elenco degli spostamenti già registrati:
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <Siar:DataGrid ID="dgSpostamenti" runat="server" AutoGenerateColumns="False" Width="1000px">
                                            <ItemStyle Height="20px" />
                                            <Columns>
                                                <Siar:NumberColumn>
                                                    <ItemStyle HorizontalAlign="Center" Width="35px" />
                                                </Siar:NumberColumn>
                                                <asp:BoundColumn HeaderText="Data" DataField="Data">
                                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="ImportoSpostato" HeaderText="Importo spostato" DataFormatString="{0:c}">
                                                    <ItemStyle HorizontalAlign="right" Width="110px" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn HeaderText="Stato">
                                                    <ItemStyle HorizontalAlign="Center" Width="150px" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn>
                                                    <ItemStyle HorizontalAlign="Center" Width="120px" />
                                                </asp:BoundColumn>
                                            </Columns>
                                        </Siar:DataGrid>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                            <table id="tableSpostamentoSelezionato" runat="server" width="100%" cellpadding="0"
                                cellspacing="0">
                                <tr>
                                    <td class="paragrafo">
                                        &nbsp;Dati spostamento selezionato:&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding: 10px">
                                        <table width="100%">
                                            <tr>
                                                <td style="width: 800px">
                                                    Descrizione:<br />
                                                    <Siar:TextBox ID="txtDescrizioneSpostamento" runat="server" Width="768px" />
                                                </td>
                                                <td>
                                                    Stato:<br />
                                                    <Siar:TextBox ID="txtStatoSpostamento" runat="server" ReadOnly="True" Width="180px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" style="height: 60px;">
                                        <Siar:Button ID="btnSalvaSpostamento" runat="server" CausesValidation="False" Modifica="False"
                                            OnClick="btnSalvaSpostamento_Click" Text="Salva spostamento" OnClientClick="return salvaTutto(event);"
                                            Width="180px" Enabled="False" />
                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                        <Siar:Button ID="btnChiudiSpostamento" runat="server" CausesValidation="False" Modifica="False"
                                            OnClick="btnChiudiSpostamento_Click" Text="Chiudi spostamento" OnClientClick="return salvaTutto(event);"
                                            Width="180px" Enabled="False" />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                                        <Siar:Button ID="btnAnnullaSpostamento" runat="server" CausesValidation="False" Modifica="False"
                                            OnClick="btnAnnullaSpostamento_Click" Text="Annulla spostamento" Conferma="Attenzione! Annullare lo spostamento selezionato e ripristinare la situazione precedente ad esso?"
                                            Width="180px" Enabled="False" />
                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                        <input id="btnDeselezionaSpostamento" class="Button" style="width: 180px" type="button"
                                            value="Deseleziona spostamento" onclick="deselezionaSpostamento();" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table style="width: 100%; border: solid 1px black" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td style="width: 50%; border-right: solid 1px black">
                                                    <table style="height: 40px; width: 100%" cellpadding="0" cellspacing="0">
                                                        <tr class="TESTA1">
                                                            <td style="width: 277px; padding-left: 6px; font-size: 14px; border: 0">
                                                                INVESTIMENTO DI PARTENZA
                                                            </td>
                                                            <td style="width: 50px; border: 0" align="center">
                                                                <img alt="Seleziona investimento" src="../../images/lente.gif" height="20" width="30"
                                                                    onmouseover="this.style.cursor='pointer';" onclick="selezionaInvestimentoPartenza();" />
                                                            </td>
                                                            <td style="width: 50px; border: 0" align="center">
                                                                <img alt="Visualizza in pdf" src="../../images/acrobat.gif" height="20" width="20"
                                                                    onmouseover="this.style.cursor='pointer';" onclick="visualizzaInvestimentoPartenza();" />
                                                            </td>
                                                            <td style="width: 50px; border: 0" align="center">
                                                                <img alt="Vai all`istruttoria del pagamento" src="../../images/timbro.gif" height="20"
                                                                    width="20" onmouseover="this.style.cursor='pointer';" onclick="istruttoriaPagamentoPartenza();" />
                                                            </td>
                                                            <td style="border: 0">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td>
                                                    <table style="height: 40px; width: 100%" cellpadding="0" cellspacing="0">
                                                        <tr class="TESTA1">
                                                            <td style="padding-left: 6px; font-size: 14px; width: 270px; border: 0">
                                                                INVESTIMENTO DI ARRIVO
                                                            </td>
                                                            <td style="width: 50px; border: 0" align="center">
                                                                <img alt="Seleziona investimento" src="../../images/lente.gif" height="20" width="30"
                                                                    onmouseover="this.style.cursor='pointer';" onclick="selezionaInvestimentoArrivo();" />
                                                            </td>
                                                            <td style="width: 50px; border: 0" align="center">
                                                                <img alt="Visualizza in pdf" src="../../images/acrobat.gif" height="20" width="20"
                                                                    onmouseover="this.style.cursor='pointer';" onclick="visualizzaInvestimentoArrivo();" />
                                                            </td>
                                                            <td style="width: 50px; border: 0" align="center">
                                                                <img alt="Vai all`istruttoria del pagamento" src="../../images/timbro.gif" height="20"
                                                                    width="20" onmouseover="this.style.cursor='pointer';" onclick="istruttoriaPagamentoArrivo();" />
                                                            </td>
                                                            <td style="border: 0">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 48%; border-right: solid 1px black; padding-left: 10px;">
                                                    <table style="width: 100%;">
                                                        <tr>
                                                            <td style="width: 130px">
                                                                <br />
                                                                Costo totale:<br />
                                                                <Siar:CurrencyBox ID="txtIPTOTCostoInvestimento" runat="server" ReadOnly="True" Width="110px" />
                                                            </td>
                                                            <td style="width: 130px">
                                                                <br />
                                                                Spese tecniche totali:<br />
                                                                <Siar:CurrencyBox ID="txtIPTOTSpeseTecniche" runat="server" ReadOnly="True" Width="110px" />
                                                            </td>
                                                            <td style="width: 130px">
                                                                <br />
                                                                Contributo totale:<br />
                                                                <Siar:CurrencyBox ID="txtIPTOTContributo" runat="server" ReadOnly="True" Width="110px" />
                                                            </td>
                                                            <td>
                                                                <br />
                                                                %<br />
                                                                <Siar:QuotaBox ID="txtIPTOTQuota" runat="server" ReadOnly="True" Width="40px" />
                                                                &nbsp;&nbsp;&nbsp;&nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td style="padding-left: 10px">
                                                    <table style="width: 100%;">
                                                        <tr>
                                                            <td style="width: 130px">
                                                                <br />
                                                                Costo totale:<br />
                                                                <Siar:CurrencyBox ID="txtIATOTCostoInvestimento" runat="server" ReadOnly="True" Width="110px" />
                                                            </td>
                                                            <td style="width: 130px">
                                                                <br />
                                                                Spese tecniche totali:<br />
                                                                <Siar:CurrencyBox ID="txtIATOTSpeseTecniche" runat="server" ReadOnly="True" Width="110px" />
                                                            </td>
                                                            <td style="width: 130px">
                                                                <br />
                                                                Contributo totale:<br />
                                                                <Siar:CurrencyBox ID="txtIATOTContributo" runat="server" ReadOnly="True" Width="110px" />
                                                            </td>
                                                            <td>
                                                                <br />
                                                                %<br />
                                                                <Siar:QuotaBox ID="txtIATOTQuota" runat="server" ReadOnly="True" Width="40px" />
                                                                &nbsp;&nbsp;&nbsp;&nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 50%; border-right: solid 1px black" class="paragrafo">
                                                    <br />
                                                    &nbsp;Pagamento richiesto:
                                                </td>
                                                <td class="paragrafo">
                                                    <br />
                                                    &nbsp;Pagamento richiesto:
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 50%; border-right: solid 1px black; padding-left: 10px;">
                                                    <table style="width: 100%;">
                                                        <tr>
                                                            <td style="width: 130px">
                                                                <br />
                                                                Importo:<br />
                                                                <Siar:CurrencyBox ID="txtIPPRImporto" runat="server" Width="110px" ReadOnly="True" />
                                                            </td>
                                                            <td style="width: 130px">
                                                                <br />
                                                                Computo metrico:<br />
                                                                <Siar:CurrencyBox ID="txtIPPRComputoMetrico" runat="server" Width="110px" ReadOnly="True" />
                                                            </td>
                                                            <td style="width: 130px">
                                                                <br />
                                                                Costo totale:<br />
                                                                <Siar:CurrencyBox ID="txtIPPRCosto" runat="server" ReadOnly="True" Width="110px" />
                                                            </td>
                                                            <td>
                                                                <br />
                                                                Contributo:<br />
                                                                <Siar:CurrencyBox ID="txtIPPRContributo" runat="server" ReadOnly="True" Width="110px" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 130px">
                                                                <br />
                                                                Spese tecniche:<br />
                                                                <Siar:CurrencyBox ID="txtIPPRSpeseTecniche" runat="server" ReadOnly="True" Width="110px" />
                                                            </td>
                                                            <td style="width: 130px">
                                                                <br />
                                                                Lavori in economia:<br />
                                                                <Siar:CurrencyBox ID="txtIPPRLavoriEconomia" runat="server" Width="110px" ReadOnly="True" />
                                                            </td>
                                                            <td colspan="2">
                                                                <br />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td style="padding-left: 10px">
                                                    <table style="width: 100%;">
                                                        <tr>
                                                            <td style="width: 130px">
                                                                <br />
                                                                Importo:<br />
                                                                <Siar:CurrencyBox ID="txtIAPRImporto" runat="server" Width="110px" ReadOnly="True" />
                                                            </td>
                                                            <td style="width: 130px">
                                                                <br />
                                                                Computo metrico:<br />
                                                                <Siar:CurrencyBox ID="txtIAPRComputoMetrico" runat="server" Width="110px" ReadOnly="True" />
                                                            </td>
                                                            <td style="width: 130px">
                                                                <br />
                                                                Costo totale:<br />
                                                                <Siar:CurrencyBox ID="txtIAPRCosto" runat="server" ReadOnly="True" Width="110px" />
                                                            </td>
                                                            <td>
                                                                <br />
                                                                Contributo:<br />
                                                                <Siar:CurrencyBox ID="txtIAPRContributo" runat="server" ReadOnly="True" Width="110px" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 130px">
                                                                <br />
                                                                Spese tecniche:<br />
                                                                <Siar:CurrencyBox ID="txtIAPRSpeseTecniche" runat="server" ReadOnly="True" Width="110px" />
                                                            </td>
                                                            <td style="width: 130px">
                                                                <br />
                                                                Lavori in economia:<br />
                                                                <Siar:CurrencyBox ID="txtIAPRLavoriEconomia" runat="server" Width="110px" ReadOnly="True" />
                                                            </td>
                                                            <td colspan="2">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 22px; border-right: solid 1px black">
                                                    &nbsp;
                                                </td>
                                                <td style="height: 22px">
                                                </td>
                                            </tr>
                                            <tr class="TESTA">
                                                <td style="width: 50%; border-right: solid 1px black;">
                                                    &nbsp;Elenco giustificativi associati:
                                                </td>
                                                <td>
                                                    &nbsp;Elenco giustificativi associati:
                                                </td>
                                            </tr>
                                            <tr>
                                                <td id="tdPagBenPartenza" style="padding: 3px; width: 50%; border-right: solid 1px black;
                                                    vertical-align: top">
                                                    &nbsp;
                                                </td>
                                                <td id="tdPagBenArrivo" style="padding: 3px; vertical-align: top">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <div id="divSelezionaInvestimento" style="width: 800px; display: none; position: absolute">
        <table class="tableNoTab" width="100%">
            <tr>
                <td>
                    <table cellpadding="2" cellspacing="0" width="100%">
                        <tr>
                            <td id="tdSelInvIntestazione" class="separatore">
                            </td>
                            <td style="width: 20px;" class="separatore">
                                <img src='../../images/close.png' alt='Chiudi' style='width: 20px; height: 20px'
                                    onmouseover="this.style.cursor='pointer';" onclick='chiudiPopupTemplate();' />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="padding: 10px">
                    Per selezionare l'investimento desiderato cliccare sulla riga corrispondente.
                </td>
            </tr>
            <tr>
                <td id="tdDivSelInvDatagrid">
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
