<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true" Inherits="web.Private.PDomanda.ValutazionePianoSviluppo" Codebehind="ValutazionePianoSviluppo.aspx.cs" %>
 
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript">

function calc_totals(anno)
{    
    var a1 = document.getElementById("ctl00_cphContenuto_txtA1" + anno + "_text");                
    var b1 = document.getElementById("ctl00_cphContenuto_txtB1" + anno + "_text");
    var b2 = document.getElementById("ctl00_cphContenuto_txtB2" + anno + "_text");
    var b3 = document.getElementById("ctl00_cphContenuto_txtB3" + anno + "_text");
    var c1 = document.getElementById("ctl00_cphContenuto_txtC1" + anno + "_text");
    var c2 = document.getElementById("ctl00_cphContenuto_txtC2" + anno + "_text");
    var d1 = document.getElementById("ctl00_cphContenuto_txtD1" + anno + "_text");
    var d2 = document.getElementById("ctl00_cphContenuto_txtD2" + anno + "_text");
    
    var e = document.getElementById("ctl00_cphContenuto_txtE" + anno + "_text");
    var f = document.getElementById("ctl00_cphContenuto_txtF" + anno + "_text");
    var i = document.getElementById("ctl00_cphContenuto_txtI" + anno + "_text");
             
    var TotFabbisogno = cleanValue(a1.value) + cleanValue(c1.value) + cleanValue(c2.value);             
    e.value = TotFabbisogno;
    e.value = e.value.replace(".",",");
        
    var TotCopertura = cleanValue(b1.value) + cleanValue(b2.value) + cleanValue(b3.value) + cleanValue(d1.value) + cleanValue(d2.value);
    f.value = TotCopertura;
    f.value = f.value.replace(".",",");
           
    var SaldoNetto = TotCopertura - TotFabbisogno;
    i.value = SaldoNetto;   
    i.value = i.value.replace(".",","); 
           
    setPuntini(e);
    setPuntini(f);
    setPuntini(i);    
}

function TotaleRiga(index)
{
var i=1;
var tot = 0;
  while( i<= 5)
  { 
 
   var a1 = document.getElementById("ctl00_cphContenuto_txt"+index+"Anno" + i + "_text");     
   tot += cleanValue( a1.value);    
   i++;
    }
  
   var totale =  document.getElementById("ctl00$cphContenuto$lbl"+index+"Anno_text");
   var totale_puntini = document.all['ctl00$cphContenuto$lbl'+index+'Anno'];
  totale_puntini.value = tot;
   totale_puntini.value =  totale_puntini.value.replace(".",",");
  setPuntiniLabel(totale_puntini,totale );
  // totale.innerHTML= tot + '';
   

//totale dei totali
var totE=0;
var totF = 0;
var totI= 0 ;
var c=1;
while (c<=5 )
{
    var e = document.getElementById("ctl00_cphContenuto_txtEAnno" + c + "_text");
    var f = document.getElementById("ctl00_cphContenuto_txtFAnno" + c + "_text");
    var i = document.getElementById("ctl00_cphContenuto_txtIAnno" + c + "_text");
         totE += cleanValue( e.value);
         totF += cleanValue( f.value);
         totI += cleanValue( i.value);
   c++;
}
  var totaleE =  document.getElementById("ctl00$cphContenuto$lblEAnno_text");
   var tot_e_puntini =  document.all.ctl00$cphContenuto$lblEAnno;
   tot_e_puntini.value=totE;
   tot_e_puntini.value=tot_e_puntini.value.replace (".",",");
   setPuntiniLabel(tot_e_puntini, totaleE);
   
   var totaleF =  document.getElementById("ctl00$cphContenuto$lblFAnno_text");
   var tot_F_puntini =  document.all.ctl00$cphContenuto$lblFAnno;
   tot_F_puntini.value= totF  ;
   tot_F_puntini.value = tot_F_puntini.value.replace (".",",");
   setPuntiniLabel(tot_F_puntini, totaleF);
   
   var totaleI =  document.getElementById("ctl00$cphContenuto$lblIAnno_text");
   var tot_I_puntini =  document.all.ctl00$cphContenuto$lblIAnno;
   tot_I_puntini.value= totI ;
   tot_I_puntini.value =tot_I_puntini.value.replace (".",",");
    setPuntiniLabel(tot_I_puntini, totaleI);
}


function controlloAnno(index, ev)
{
 
 var oggi=new Date();
 var anno = oggi.getFullYear();
   
    var annoInserito=document.getElementById("ctl00_cphContenuto_txt"+index+"_text").value;
    if(annoInserito!="")
   if(annoInserito <= anno )
   {
        alert ("Attenzione l'anno inserito non è corretto.\nIl piano di sviluppo si riferisce ad anni successivi il "+ anno);
        return stopEvent(ev);
   }

}

function cleanValue(textbox_value)
{
  while(textbox_value.indexOf(".")!=-1)
  textbox_value= textbox_value.replace(".","");
  textbox_value= textbox_value.replace(",",".");
  textbox_value = parseFloat(textbox_value);
  if(isNaN(textbox_value))textbox_value=0;   
  return textbox_value;  
}

function setPuntini(obj)
{
  if (obj.value == '0') obj.value = '0,00';

  if(obj.value=='-'||obj.value==',') { obj.value=''; }
  else
  {    
    var index = obj.value.indexOf(',');
    if(index > 0)
    {
      if (index == obj.value.length-1) obj.value = obj.value.substring(0,index);
      if (index < obj.value.length-3) obj.value=obj.value.substring(0,index+3);
    }
   
  }  

  var negativo=false;
  if(obj.value.indexOf('-') >= 0)
  {
    obj.value=obj.value.replace('-','');
    negativo=true;
  }

  while (obj.value.indexOf('0') == 0 && obj.value.length > 1) obj.value=obj.value.replace('0','');

  while (obj.value.indexOf('.') >= 0) obj.value=obj.value.replace('.','');
  
  if(obj.value.indexOf(',') == 0) obj.value='0'+obj.value;
  var parteintera=obj.value;
  var partefrazionaria='';
  var nuova='';
  if(obj.value.indexOf(',')>0)
  {
    parteintera = obj.value.substring(0,obj.value.indexOf(','));
    partefrazionaria = obj.value.substring(obj.value.indexOf(','),obj.value.length);
  }
  while(parteintera.length-3 > 0)
  {  
    nuova = '.' + parteintera.substring(parteintera.length-3,parteintera.length) + nuova;
    parteintera = parteintera.substring(0,parteintera.length-3);  
  }
  
  obj.value = parteintera + nuova + partefrazionaria;
  if (negativo) obj.value='-'+obj.value;
  
}

function setPuntiniLabel(obj, objInner)
{
 
  if (obj.value == '0') obj.value = '0,00';

  if(obj.value=='-'||obj.value==',') { obj.value=''; }
  else
  {    
    var index = obj.value.indexOf(',');
    if(index > 0)
    {
      if (index == obj.value.length-1) obj.value = obj.value.substring(0,index);
      if (index < obj.value.length-3) obj.value=obj.value.substring(0,index+3);
    }
   
  }  

  var negativo=false;
  if(obj.value.indexOf('-') >= 0)
  {
    obj.value=obj.value.replace('-','');
    negativo=true;
  }

  while (obj.value.indexOf('0') == 0 && obj.value.length > 1) obj.value=obj.value.replace('0','');

  while (obj.value.indexOf('.') >= 0) obj.value=obj.value.replace('.','');
  
  if(obj.value.indexOf(',') == 0) obj.value='0'+obj.value;
  var parteintera=obj.value;
  var partefrazionaria='';
  var nuova='';
  if(obj.value.indexOf(',')>0)
  {
    parteintera = obj.value.substring(0,obj.value.indexOf(','));
    partefrazionaria = obj.value.substring(obj.value.indexOf(','),obj.value.length);
  }
  while(parteintera.length-3 > 0)
  {  
    nuova = '.' + parteintera.substring(parteintera.length-3,parteintera.length) + nuova;
    parteintera = parteintera.substring(0,parteintera.length-3);  
  }
  
  obj.value = parteintera + nuova + partefrazionaria;
  objInner.innerHTML = parteintera + nuova + partefrazionaria+'';
  if (negativo)
  { obj.value='-'+obj.value;
  objInner.innerHTML = '-'+  objInner.innerHTML;
  }
}

    </script>

  
    &nbsp;<br />
    <Siar:SiarTab ID="TAB1" runat="server" Tabs="Valutazione finanziaria del piano di sviluppo"
        FullValidate="True" Width="900px">
        <table class="tableTab" id="Table2" style="width: 100%;">
            <tr>
                <td>
                    <br />
                       <table style="width: 100%">
                        <tr>
                            <td class="separatore" style="width: 240px">
                                FABBISOGNI/COPERTURE</td>
                            <td style="text-align: center; width: 110px;" class="separatore">
                                Anno N+1&nbsp;
                            </td>
                            <td style="text-align: center; width: 110px;" class="separatore">
                                Anno N+2&nbsp;
                            </td>
                            <td style="text-align: center; width: 110px;" class="separatore">
                                Anno N+3&nbsp;
                            </td>
                            <td style="text-align: center; width: 110px;" class="separatore">
                                Anno N+4&nbsp;
                            </td>
                            <td style="text-align: center; width: 110px;" class="separatore">
                                Anno N+5&nbsp;
                            </td>
                            <td class="separatore" style="text-align: center; width: 110px;" align="right">
                                TOTALE
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 240px">
                            </td>
                            <td style="text-align: center;">
                                <Siar:Hidden ID="hdnIdPiano1" runat="server" />
                                <Siar:TextBox ID="txtanno1" runat="server" Width="33px" MaxLength="4" />
                            </td>
                            <td style="text-align: center">
                                <Siar:Hidden ID="hdnIdPiano2" runat="server" />
                                <Siar:TextBox ID="txtanno2" runat="server" Width="33px" MaxLength="4" />
                            </td>
                            <td style="text-align: center">
                                <Siar:Hidden ID="hdnIdPiano3" runat="server" />
                                <Siar:TextBox ID="txtanno3" runat="server" Width="33px" MaxLength="4" />
                            </td>
                            <td style="text-align: center">
                                <Siar:Hidden ID="hdnIdPiano4" runat="server" />
                                <Siar:TextBox ID="txtanno4" runat="server" Width="33px" MaxLength="4" />
                            </td>
                            <td style="text-align: center; width: 108px;">
                                <Siar:Hidden ID="hdnIdPiano5" runat="server" />
                                <Siar:TextBox ID="txtanno5" runat="server" Width="33px" MaxLength="4" />
                            </td>
                            <td style="text-align: center; width: 110px;" align="right">
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold; width: 240px;">
                                <br />
                                INVESTIMENTO</td>
                            <td style="width: 110px">
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td align="right">
                            </td>
                        </tr>
                        <tr>
                            <td style="text-decoration: underline; width: 240px;">
                                A) Fabbisogno</td>
                            <td style="width: 110px">
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td style="width: 110px" align="right">
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left: 10px; width: 240px;">
                                A1) Esborso per l'investimento</td>
                            <td style="width: 110px">
                                <Siar:CurrencyBox ID="txtA1Anno1" runat="server" Width="90px" Text="0,00" />
                            </td>
                            <td>
                                <Siar:CurrencyBox ID="txtA1Anno2" runat="server" Width="90px" Text="0,00" />
                            </td>
                            <td>
                                <Siar:CurrencyBox ID="txtA1Anno3" runat="server" Width="90px" Text="0,00" />
                            </td>
                            <td>
                                <Siar:CurrencyBox ID="txtA1Anno4" runat="server" Width="90px" Text="0,00" />
                            </td>
                            <td style="width: 110px">
                                <Siar:CurrencyBox ID="txtA1Anno5" runat="server" Width="90px" Text="0,00" />
                            </td>
                            <td style="width: 110px" align="right">
                                <b>
                                    <Siar:Label ID="lblA1Anno" runat="server" CurrencyFormat="{0:C}" >
                                    </Siar:Label>
                                </b>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-decoration: underline; width: 240px;">
                                B) Copertura</td>
                            <td style="width: 110px">
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td style="width: 110px">
                            </td>
                            <td style="width: 110px" align="right">
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left: 10px; width: 240px;">
                                B1) Mezzi propri</td>
                            <td style="width: 110px">
                                <Siar:CurrencyBox ID="txtB1Anno1" runat="server" Width="90px" Text="0,00" />
                            </td>
                            <td>
                                <Siar:CurrencyBox ID="txtB1Anno2" runat="server" Width="90px" Text="0,00" />
                            </td>
                            <td>
                                <Siar:CurrencyBox ID="txtB1Anno3" runat="server" Width="90px" Text="0,00" />
                            </td>
                            <td>
                                <Siar:CurrencyBox ID="txtB1Anno4" runat="server" Width="90px" Text="0,00" />
                            </td>
                            <td style="width: 110px">
                                <Siar:CurrencyBox ID="txtB1Anno5" runat="server" Width="90px" Text="0,00" />
                            </td>
                            <td style="width: 110px" align="right">
                                <b>
                                    <Siar:Label ID="lblB1Anno" runat="server" CurrencyFormat="{0:C}">
                                    </Siar:Label>
                                </b>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left: 10px; width: 240px;">
                                B2) Risorse di terzi</td>
                            <td style="width: 110px">
                                <Siar:CurrencyBox ID="txtB2Anno1" runat="server" Width="90px" Text="0,00" />
                            </td>
                            <td>
                                <Siar:CurrencyBox ID="txtB2Anno2" runat="server" Width="90px" Text="0,00" />
                            </td>
                            <td>
                                <Siar:CurrencyBox ID="txtB2Anno3" runat="server" Width="90px" Text="0,00" />
                            </td>
                            <td>
                                <Siar:CurrencyBox ID="txtB2Anno4" runat="server" Width="90px" Text="0,00" />
                            </td>
                            <td style="width: 110px">
                                <Siar:CurrencyBox ID="txtB2Anno5" runat="server" Width="90px" Text="0,00" />
                            </td>
                            <td style="width: 110px" align="right">
                                <b>
                                    <Siar:Label ID="lblB2Anno" runat="server" CurrencyFormat="{0:C}">
                                    </Siar:Label>
                                </b>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left: 10px; width: 240px;">
                                B3) Contributi pubblici</td>
                            <td style="width: 110px">
                                <Siar:CurrencyBox ID="txtB3Anno1" runat="server" Width="90px" Text="0,00" />
                            </td>
                            <td>
                                <Siar:CurrencyBox ID="txtB3Anno2" runat="server" Width="90px" Text="0,00" />
                            </td>
                            <td>
                                <Siar:CurrencyBox ID="txtB3Anno3" runat="server" Width="90px" Text="0,00" />
                            </td>
                            <td>
                                <Siar:CurrencyBox ID="txtB3Anno4" runat="server" Width="90px" Text="0,00" />
                            </td>
                            <td style="width: 110px">
                                <Siar:CurrencyBox ID="txtB3Anno5" runat="server" Width="90px" Text="0,00" />
                            </td>
                            <td style="width: 110px" align="right">
                                <b>
                                    <Siar:Label ID="lblB3Anno" runat="server">
                                    </Siar:Label>
                                </b>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left: 10px; width: 240px;">
                                <br />
                            </td>
                            <td style="width: 110px">
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td style="width: 110px">
                            </td>
                            <td style="width: 110px" align="right">
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="separatore" colspan="7">
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold; width: 240px;">
                            </td>
                            <td style="width: 110px">
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td style="width: 110px">
                            </td>
                            <td style="width: 110px" align="right">
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold; width: 240px;">
                                <br />
                                FLUSSI DI CASSA DELLA GESTIONE</td>
                            <td style="width: 110px">
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td style="width: 110px">
                            </td>
                            <td style="width: 110px" align="right">
                            </td>
                        </tr>
                        <tr>
                            <td style="text-decoration: underline; width: 240px;">
                                C) Fabbisogno</td>
                            <td style="width: 110px">
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td style="width: 110px">
                            </td>
                            <td style="width: 110px" align="right">
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left: 10px; width: 240px;">
                                C1) Esborsi dovuti alla gestione generati dagli investimenti</td>
                            <td style="width: 110px">
                                <Siar:CurrencyBox ID="txtC1Anno1" runat="server" Width="90px" Text="0,00" />
                            </td>
                            <td>
                                <Siar:CurrencyBox ID="txtC1Anno2" runat="server" Width="90px" Text="0,00" />
                            </td>
                            <td>
                                <Siar:CurrencyBox ID="txtC1Anno3" runat="server" Width="90px" Text="0,00" />
                            </td>
                            <td>
                                <Siar:CurrencyBox ID="txtC1Anno4" runat="server" Width="90px" Text="0,00" />
                            </td>
                            <td style="width: 110px">
                                <Siar:CurrencyBox ID="txtC1Anno5" runat="server" Width="90px" Text="0,00" />
                            </td>
                            <td style="width: 110px" align="right">
                                <b>
                                    <Siar:Label ID="lblC1Anno" runat="server">
                                    </Siar:Label>
                                </b>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left: 10px; width: 240px;">
                                C2) Rimborso del debito (quota capitale e quota interessi)</td>
                            <td style="width: 110px">
                                <Siar:CurrencyBox ID="txtC2Anno1" runat="server" Width="90px" Text="0,00" />
                            </td>
                            <td>
                                <Siar:CurrencyBox ID="txtC2Anno2" runat="server" Width="90px" Text="0,00" />
                            </td>
                            <td>
                                <Siar:CurrencyBox ID="txtC2Anno3" runat="server" Width="90px" Text="0,00" />
                            </td>
                            <td>
                                <Siar:CurrencyBox ID="txtC2Anno4" runat="server" Width="90px" Text="0,00" />
                            </td>
                            <td style="width: 110px">
                                <Siar:CurrencyBox ID="txtC2Anno5" runat="server" Width="90px" Text="0,00" />
                            </td>
                            <td style="width: 110px" align="right">
                                <b>
                                    <Siar:Label ID="lblC2Anno" runat="server">
                                    </Siar:Label>
                                </b>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-decoration: underline; width: 240px;">
                                D) Copertura</td>
                            <td style="width: 110px">
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td style="width: 110px">
                            </td>
                            <td style="width: 110px" align="right">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 240px">
                                &nbsp;&nbsp; D1) Entrata dalla gestione</td>
                            <td style="width: 110px">
                                <Siar:CurrencyBox ID="txtD1Anno1" runat="server" Width="90px" Text="0,00" />
                            </td>
                            <td>
                                <Siar:CurrencyBox ID="txtD1Anno2" runat="server" Width="90px" Text="0,00" />
                            </td>
                            <td>
                                <Siar:CurrencyBox ID="txtD1Anno3" runat="server" Width="90px" Text="0,00" />
                            </td>
                            <td>
                                <Siar:CurrencyBox ID="txtD1Anno4" runat="server" Width="90px" Text="0,00" />
                            </td>
                            <td style="width: 110px">
                                <Siar:CurrencyBox ID="txtD1Anno5" runat="server" Width="90px" Text="0,00" />
                            </td>
                            <td style="width: 110px" align="right">
                                <b>
                                    <Siar:Label ID="lblD1Anno" runat="server">
                                    </Siar:Label>
                                </b>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 240px">
                                &nbsp;&nbsp; D2) Altre coperture</td>
                            <td style="width: 110px">
                                <Siar:CurrencyBox ID="txtD2Anno1" runat="server" Width="90px" Text="0,00" />
                            </td>
                            <td>
                                <Siar:CurrencyBox ID="txtD2Anno2" runat="server" Width="90px" Text="0,00" />
                            </td>
                            <td>
                                <Siar:CurrencyBox ID="txtD2Anno3" runat="server" Width="90px" Text="0,00" />
                            </td>
                            <td>
                                <Siar:CurrencyBox ID="txtD2Anno4" runat="server" Width="90px" Text="0,00" />
                            </td>
                            <td style="width: 110px">
                                <Siar:CurrencyBox ID="txtD2Anno5" runat="server" Width="90px" Text="0,00" />
                            </td>
                            <td style="width: 110px" align="right">
                                <b>
                                    <Siar:Label ID="lblD2Anno" runat="server">
                                    </Siar:Label>
                                </b>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 240px">
                                <br />
                            </td>
                            <td style="width: 110px">
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td style="width: 110px">
                            </td>
                            <td style="width: 110px" align="right">
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="separatore" colspan="7">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 240px">
                                <br />
                            </td>
                            <td style="width: 110px">
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td style="width: 110px">
                            </td>
                            <td style="width: 110px" align="right">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 240px">
                                E) Totale fabbisogno (A+C)</td>
                            <td style="width: 110px">
                                <Siar:CurrencyBox ID="txtEAnno1" runat="server" Width="90px" Text="0,00" ReadOnly="True" />
                            </td>
                            <td>
                                <Siar:CurrencyBox ID="txtEAnno2" runat="server" Width="90px" Text="0,00" ReadOnly="True" />
                            </td>
                            <td>
                                <Siar:CurrencyBox ID="txtEAnno3" runat="server" Width="90px" Text="0,00" ReadOnly="True" />
                            </td>
                            <td>
                                <Siar:CurrencyBox ID="txtEAnno4" runat="server" Width="90px" Text="0,00" ReadOnly="True" />
                            </td>
                            <td style="width: 110px">
                                <Siar:CurrencyBox ID="txtEAnno5" runat="server" Width="90px" Text="0,00" ReadOnly="True" />
                            </td>
                            <td style="width: 110px" align="right">
                                <Siar:Label ID="lblEAnno" runat="server">
                                </Siar:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 240px">
                                F) Totale copertura (B+D)</td>
                            <td style="width: 110px">
                                <Siar:CurrencyBox ID="txtFAnno1" runat="server" Width="90px" Text="0,00" ReadOnly="True" />
                            </td>
                            <td>
                                <Siar:CurrencyBox ID="txtFAnno2" runat="server" Width="90px" Text="0,00" ReadOnly="True" />
                            </td>
                            <td>
                                <Siar:CurrencyBox ID="txtFAnno3" runat="server" Width="90px" Text="0,00" ReadOnly="True" />
                            </td>
                            <td>
                                <Siar:CurrencyBox ID="txtFAnno4" runat="server" Width="90px" Text="0,00" ReadOnly="True" />
                            </td>
                            <td style="width: 110px">
                                <Siar:CurrencyBox ID="txtFAnno5" runat="server" Width="90px" Text="0,00" ReadOnly="True" />
                            </td>
                            <td style="width: 110px" align="right">
                                <Siar:Label ID="lblFAnno" runat="server">
                                </Siar:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 240px">
                                I) SALDO NETTO (F-E)</td>
                            <td style="width: 110px">
                                <Siar:CurrencyBox ID="txtIAnno1" runat="server" Width="90px" Text="0,00" ReadOnly="True" />
                            </td>
                            <td>
                                <Siar:CurrencyBox ID="txtIAnno2" runat="server" Width="90px" Text="0,00" ReadOnly="True" />
                            </td>
                            <td>
                                <Siar:CurrencyBox ID="txtIAnno3" runat="server" Width="90px" Text="0,00" ReadOnly="True" />
                            </td>
                            <td>
                                <Siar:CurrencyBox ID="txtIAnno4" runat="server" Width="90px" Text="0,00" ReadOnly="True" />
                            </td>
                            <td style="width: 110px">
                                <Siar:CurrencyBox ID="txtIAnno5" runat="server" Width="90px" Text="0,00" ReadOnly="True" />
                            </td>
                            <td style="width: 110px" align="right">
                                <Siar:Label ID="lblIAnno" runat="server">
                                </Siar:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 240px">
                                <br />
                            </td>
                            <td style="width: 110px">
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td style="width: 110px">
                            </td>
                            <td style="width: 110px">
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="separatore" colspan="7">
                            </td>
                        </tr>
                    </table>
                    <br />
                    <div style="text-align: center;">
                        <br />
                        &nbsp;
                        &nbsp;&nbsp;
                        <Siar:Button ID="btnSalva" runat="server" Text="Salva" Conferma="Confermare il salvataggio del piano?"
                            Modifica="True" Width="130px" OnClick="btnSalva_Click" />
                        &nbsp;&nbsp;
                        <Siar:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Indietro"
                            Width="130px" Modifica="False" /><br />
                        <br />
                    </div>
                </td>
            </tr>
        </table>
    </Siar:SiarTab>
</asp:Content>
