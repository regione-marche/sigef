<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.Impresa.ValutazionePianoSviluppo" CodeBehind="ValutazionePianoSviluppo.aspx.cs" %>

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

    </script>

    <asp:HiddenField ID="hdnCurrentYear" runat="server" />
    <Siar:SiarTab ID="TAB1" runat="server" Tabs="Valutazione finanziaria del piano di sviluppo"
        FullValidate="True" Width="800px">
        <table class="tableTab" id="Table2" style="width: 100%;">
            <tr>
                <td>
                    <br />
                    <table style="width: 100%">
                        <tr>
                            <td class="separatore">
                                FABBISOGNI/COPERTURE
                            </td>
                            <td style="text-align: center" class="separatore">
                                Anno
                                <Siar:Label ID="lblAnno1" runat="server">
                                </Siar:Label>
                            </td>
                            <td style="text-align: center" class="separatore">
                                Anno
                                <Siar:Label ID="lblAnno2" runat="server">
                                </Siar:Label>
                            </td>
                            <td style="text-align: center" class="separatore">
                                ANNO
                                <Siar:Label ID="lblAnno3" runat="server">
                                </Siar:Label>
                            </td>
                            <td style="text-align: center" class="separatore">
                                Anno
                                <Siar:Label ID="lblAnno4" runat="server">
                                </Siar:Label>
                            </td>
                            <td style="text-align: center" class="separatore">
                                Anno
                                <Siar:Label ID="lblAnno5" runat="server">
                                </Siar:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold;">
                                <br />
                                INVESTIMENTO
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-decoration: underline">
                                A) Fabbisogno
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left: 10px">
                                A1) Costo dell'investimento
                            </td>
                            <td>
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
                            <td>
                                <Siar:CurrencyBox ID="txtA1Anno5" runat="server" Width="90px" Text="0,00" />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-decoration: underline">
                                B) Copertura
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left: 10px">
                                B1) Mezzi propri
                            </td>
                            <td>
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
                            <td>
                                <Siar:CurrencyBox ID="txtB1Anno5" runat="server" Width="90px" Text="0,00" />
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left: 10px">
                                B2) Risorse di terzi
                            </td>
                            <td>
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
                            <td>
                                <Siar:CurrencyBox ID="txtB2Anno5" runat="server" Width="90px" Text="0,00" />
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left: 10px">
                                B3) Contributi pubblici
                            </td>
                            <td>
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
                            <td>
                                <Siar:CurrencyBox ID="txtB3Anno5" runat="server" Width="90px" Text="0,00" />
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left: 10px">
                                <br />
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td class="separatore" colspan="6">
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold;">
                                <br />
                                FLUSSI DI CASSA DELLA GESTIONE
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-decoration: underline">
                                C) Fabbisogno
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left: 10px">
                                C1) Spese della gestione generate dagli investimenti
                            </td>
                            <td>
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
                            <td>
                                <Siar:CurrencyBox ID="txtC1Anno5" runat="server" Width="90px" Text="0,00" />
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left: 10px">
                                C2) Rimborso del debito (quota capitale e quota interessi)
                            </td>
                            <td>
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
                            <td>
                                <Siar:CurrencyBox ID="txtC2Anno5" runat="server" Width="90px" Text="0,00" />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-decoration: underline">
                                D) Copertura
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                D1) Entrata dalla gestione
                            </td>
                            <td>
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
                            <td>
                                <Siar:CurrencyBox ID="txtD1Anno5" runat="server" Width="90px" Text="0,00" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                D2) Altre coperture
                            </td>
                            <td>
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
                            <td>
                                <Siar:CurrencyBox ID="txtD2Anno5" runat="server" Width="90px" Text="0,00" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td class="separatore" colspan="6">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                E) Totale fabbisogno (A+C)
                            </td>
                            <td>
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
                            <td>
                                <Siar:CurrencyBox ID="txtEAnno5" runat="server" Width="90px" Text="0,00" ReadOnly="True" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                F) Totale copertura (B+D)
                            </td>
                            <td>
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
                            <td>
                                <Siar:CurrencyBox ID="txtFAnno5" runat="server" Width="90px" Text="0,00" ReadOnly="True" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                I) SALDO NETTO (F-E)
                            </td>
                            <td>
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
                            <td>
                                <Siar:CurrencyBox ID="txtIAnno5" runat="server" Width="90px" Text="0,00" ReadOnly="True" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td class="separatore" colspan="6">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                            </td>
                            <td colspan="2">
                                <asp:LinkButton ID="lnkPrev" runat="server" Font-Bold="True" OnClick="lnkPrev_Click"><< Anno Precedente</asp:LinkButton>
                            </td>
                            <td>
                            </td>
                            <td style="text-align: right" colspan="2">
                                <asp:LinkButton ID="lnkNext" runat="server" Font-Bold="True" OnClick="lnkNext_Click">Anno Successivo >></asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <div style="text-align: right;">
                        <br />
                        <Siar:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Indietro"
                            Width="130px" Modifica="False" />
                        &nbsp;&nbsp;
                        <Siar:Button ID="btnSalva" runat="server" Text="Salva" Conferma="Confermare il salvataggio del piano?"
                            Modifica="True" Width="130px" OnClick="btnSalva_Click" /><br />
                        <br />
                    </div>
                </td>
            </tr>
        </table>
    </Siar:SiarTab>
</asp:Content>
