function CFisc(cognome,nome,data_n,codsesso,istat)
{

 var gs=0;
 var i=0;
 var somma=0;
 codice="";
 chcodice="";
 chcognome="";
 chnome="";
 codmese="";
 chmese="";
 chgiorno="";
 chrcontrollo='';
 
 
if(trim(cognome)=='' ||  trim(nome)=='' || trim(data_n)=='' || trim(codsesso)=='' || trim(istat)=='')
{
	//alert("Per calcolare il codice fiscale e' necessario indicare i seguenti campi:\nCognome;\nNome;\nData nascita;\nSesso;\nComune nascita.")
	return ""
}

cognome=cognome.toUpperCase();
nome=nome.toUpperCase();
//cognome = thisForm.COGNOME.value; 
//nome = thisForm.NOME.value;  
//data_n=thisForm.DATA_NASCITA.value

giorno=parseInt(data_n.substring(0,2),10); 
anno=data_n.substring(6,10);
annofine=anno.substring(2,4);
mese=data_n.substring(3,5);
//codsesso=thisForm.SESSO.options[thisForm.SESSO.selectedIndex].value;
//istat=thisForm.ISTAT_N.value.toUpperCase();


  // Processa il cognome
  //----------------------------------------------------------------
    for (i=0; i<cognome.length; i++) 
        {
         switch (cognome.charAt(i)) 
                {
                  case 'A':
                  case 'E':
                  case 'I':
                  case 'O':
                  case 'U': break;            
                  default : 
                  if((cognome.charAt(i)<='Z')&& (cognome.charAt(i)>'A'))
                   chcognome = chcognome + cognome.charAt(i);
                }
        }
    if (chcognome.length < 3) 
      {
       for (i=0; i<cognome.length; i++) 
          {
           switch (cognome.charAt(i)) 
                 {
                  case 'A':
                  case 'E':
                  case 'I':
                  case 'O':
                  case 'U': chcognome = chcognome + cognome.charAt(i);
                 }
          }
       if (chcognome.length < 3) 
         {
          for (i=chcognome.length; i<=3; i++) 
             { chcognome = chcognome + 'X'; }
         }
      }
   chcognome = chcognome.substring(0,3);
 //------------------------------------------------------------ 
  // processa il nome
  //----------------------------------------------------------------
    for (i=0; i<nome.length; i++) 
       {
        switch (nome.charAt(i)) 
              {
               case 'A':
               case 'E':
               case 'I':
               case 'O':
               case 'U': break;
               default:
 if((nome.charAt(i)<='Z')&& (nome.charAt(i)>'A'))
                  chnome = chnome + nome.charAt(i);
              }
       }
    if (chnome.length > 3) 
      {
        chnome = chnome.substring(0,1) + chnome.substring(2,4);
      } 
    else {
          if (chnome.length < 3) 
            {
             for (i=0; i<nome.length; i++) 
                {
                  switch (nome.charAt(i)) 
                        {
                         case 'A':
                         case 'E':
                         case 'I':
                         case 'O':
                         case 'U': chnome = chnome + nome.charAt(i);
                        }
                }
             if (chnome.length < 3) 
               {
                for (i=chnome.length; i<=3; i++) 
                   {chnome = chnome + 'X';}
               }
            }
          chnome = chnome.substring(0,3);
         }

//------------------------------------------
//processa mese

switch (mese)
	   	 {
		 case "01":{codmese="A"; break;}
		 case "02":{codmese="B"; break;}
		 case "03":{codmese="C"; break;}
		 case "04":{codmese="D"; break;}
		 case "05":{codmese="E"; break;}
		 case "06":{codmese="H"; break;}
		 case "07":{codmese="L"; break;}
		 case "08":{codmese="M"; break;}
		 case "09":{codmese="P"; break;}
		 case "10":{codmese="R"; break;}
		 case "11":{codmese="S"; break;}
		 case "12":{codmese="T"; break;}
		}

 //--------------------------------------------
 // processa giorno e sesso
  if (codsesso=="M") {
	Sesso=0;
    chgiorno = giorno + (40 * Sesso);
    if(chgiorno<10) {chgiorno = "0" + chgiorno;}
	else chgiorno =  giorno;
}
  else {
  Sesso=1;
  chgiorno = giorno + (40 * Sesso);
 } 
 //--------------------------------------------

 //chcodice = thisForm.COD_FISCALE.value.toUpperCase();
 chcodice= chcognome+chnome+annofine+codmese+chgiorno+istat 
 // calcola la cifra di controllo
 //--------------------------------------------
    for (i=0; i<15; i++) 
       { 
        if (((i+1) % 2) != 0) //caratteri dispari
          {
           switch (chcodice.charAt(i)) 
                 {
                  case '0':
                  case 'A':{ somma += 1; break;}
                  case '1':
                  case 'B':{ somma += 0; break;}
                  case '2':
                  case 'C':{ somma += 5; break;}
                  case '3':
                  case 'D':{ somma += 7; break;}
                  case '4':
                  case 'E':{ somma += 9; break;}
                  case '5':
                  case 'F':{ somma += 13; break;}
                  case '6':
                  case 'G':{ somma += 15; break;}
                  case '7':
                  case 'H':{ somma += 17; break;}
                  case '8':
                  case 'I':{ somma += 19; break;}
                  case '9':
                  case 'J':{ somma += 21; break;}
                  case 'K':{ somma += 2; break;}
                  case 'L':{ somma += 4; break;}
                  case 'M':{ somma += 18; break;}
                  case 'N':{ somma += 20; break;}
                  case 'O':{ somma += 11; break;}
                  case 'P':{ somma += 3; break;}
                  case 'Q':{ somma += 6; break;}
                  case 'R':{ somma += 8; break;}
                  case 'S':{ somma += 12; break;}
                  case 'T':{ somma += 14; break;}
                  case 'U':{ somma += 16; break;}
                  case 'V':{ somma += 10; break;}
                  case 'W':{ somma += 22; break;}
                  case 'X':{ somma += 25; break;}
                  case 'Y':{ somma += 24; break;}
                  case 'Z':{ somma += 23; break;}
                 }
          } 
        else //caratteri pari
            {
              switch (chcodice.charAt(i)) 
                 {
                  case '0':
                  case 'A':{ somma += 0; break;}
                  case '1':
                  case 'B':{ somma += 1; break;}
                  case '2':
                  case 'C':{ somma += 2; break;}
                  case '3':
                  case 'D':{ somma += 3; break;}
                  case '4':
                  case 'E':{ somma += 4; break;}
                  case '5':
                  case 'F':{ somma += 5; break;}
                  case '6':
                  case 'G':{ somma += 6; break;}
                  case '7':
                  case 'H':{ somma += 7; break;}
                  case '8':
                  case 'I':{ somma += 8; break;}
                  case '9':
                  case 'J':{ somma += 9; break;}
                  case 'K':{ somma += 10; break;}
                  case 'L':{ somma += 11; break;}
                  case 'M':{ somma += 12; break;}
                  case 'N':{ somma += 13; break;}
                  case 'O':{ somma += 14; break;}
                  case 'P':{ somma += 15; break;}
                  case 'Q':{ somma += 16; break;}
                  case 'R':{ somma += 17; break;}
                  case 'S':{ somma += 18; break;}
                  case 'T':{ somma += 19; break;}
                  case 'U':{ somma += 20; break;}
                  case 'V':{ somma += 21; break;}
                  case 'W':{ somma += 22; break;}
                  case 'X':{ somma += 23; break;}
                  case 'Y':{ somma += 24; break;}
                  case 'Z':{ somma += 25; break;}
                 }
            }
    }
   somma %= 26;
   switch (somma) 
         {
          case 0: {chrcontrollo='A'; break;}
          case 1: {chrcontrollo='B'; break;}
          case 2: {chrcontrollo='C'; break;}
          case 3: {chrcontrollo='D'; break;}
          case 4: {chrcontrollo='E'; break;}
          case 5: {chrcontrollo='F'; break;}
          case 6: {chrcontrollo='G'; break;}
          case 7: {chrcontrollo='H'; break;}
          case 8: {chrcontrollo='I'; break;}
          case 9: {chrcontrollo='J'; break;}
          case 10: {chrcontrollo='K'; break;}
          case 11: {chrcontrollo='L'; break;}
          case 12: {chrcontrollo='M'; break;}
          case 13: {chrcontrollo='N'; break;}
          case 14: {chrcontrollo='O'; break;}
          case 15: {chrcontrollo='P'; break;}
          case 16: {chrcontrollo='Q'; break;}
          case 17: {chrcontrollo='R'; break;}
          case 18: {chrcontrollo='S'; break;}
          case 19: {chrcontrollo='T'; break;}
          case 20: {chrcontrollo='U'; break;}
          case 21: {chrcontrollo='V'; break;}
          case 22: {chrcontrollo='W'; break;}
          case 23: {chrcontrollo='X'; break;}
          case 24: {chrcontrollo='Y'; break;}
          case 25: {chrcontrollo='Z'; break;}
         }
 //--------------------------------------------

chcodice = chcodice + chrcontrollo.toUpperCase();

return chcodice.toUpperCase(); 
}

function codiceFISCALE(cfins)
{
   var cf = cfins.toUpperCase();
   var cfReg = /^[A-Z]{6}\d{2}[A-Z]\d{2}[A-Z]\d{3}[A-Z]$/;
   if (!cfReg.test(cf))
      return false;
   var set1 = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
   var set2 = "ABCDEFGHIJABCDEFGHIJKLMNOPQRSTUVWXYZ";
   var setpari = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
   var setdisp = "BAKPLCQDREVOSFTGUHMINJWZYX";
   var s = 0;
   for( i = 1; i <= 13; i += 2 )
      s += setpari.indexOf( set2.charAt( set1.indexOf( cf.charAt(i) )));
   for( i = 0; i <= 14; i += 2 )
      s += setdisp.indexOf( set2.charAt( set1.indexOf( cf.charAt(i) )));
   if ( s%26 != cf.charCodeAt(15)-'A'.charCodeAt(0) )
      return false;
   return true;
}

function checkPIVA(sz_Codice)
{
   var n_Val,n_Som1=0,n_Som2=0,lcv;
   if (sz_Codice.length!=11 || isNaN(parseFloat(sz_Codice)) || parseFloat(sz_Codice)<parseFloat(0))
      return false;
   for (lcv=0;lcv<9;lcv+=2)
   {
      n_Val=parseInt(sz_Codice.charAt(lcv));
      n_Som1+=n_Val;
      n_Val=parseInt(sz_Codice.charAt(lcv+1));
      n_Som1+=Math.floor(n_Val/5) + (n_Val<<1) % 10;
   }
   n_Som2 = 10 - (n_Som1 % 10);
   n_Val=parseInt(sz_Codice.charAt(10));
   if(n_Som2==10)
	  n_Som2=0;
   if (n_Som2==n_Val)
      return true;
   return false;
}

function trim(s) {
     return s.replace(/^\s+/, '').replace(/\s+$/, '');
}
function _checkMinorenne(a,b)
{
  var anno_n=parseInt(b.Value.substr(6,4),10);
  var mese_n=parseInt(b.Value.substr(3,2),10);
  var giorno_n=parseInt(b.Value.substr(0,2),10);
  var oggi=new Date();
  var anno=oggi.getFullYear();
  var mese=oggi.getUTCMonth()+1;
  var giorno=oggi.getUTCDate();
  var OK=false;
  if(anno-anno_n>18)
    OK=true;
  else
  {
    if(anno-anno_n==18)
	{
	  if(mese_n<mese)
	    OK=true;
	  else
	  {
	    if(mese_n==mese)
		{
		  if(giorno_n<=giorno)
		    OK=true;
	    }
	  }
	}
  }
  b.IsValid=OK;
}