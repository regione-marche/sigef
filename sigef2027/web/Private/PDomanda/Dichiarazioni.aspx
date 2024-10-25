<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    Inherits="web.Private.PDomanda.Dichiarazioni" CodeBehind="Dichiarazioni.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">    
    <div style="display: none">
        <input id="hdnAltriAllegati" type="hidden" name="hdnAltriAllegati" runat="server" />
    </div>
    <nav class="breadcrumb-container" aria-label="Percorso di navigazione">
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="../PDomanda/RiepilogoDomanda.aspx">
            <svg class="icon icon-breadcrumb icon-secondary align-top me-1" aria-hidden="true">
                <use href="/web/bootstrap-italia/svg/sprites.svg#it-check""></use>
            </svg>
            Presentazione</a><span class="separator">/</span></li>
        <li class="breadcrumb-item active" aria-current="page">Dichiarazioni</li>
    </ol>
    </nav>
   <div class="row bd-form pt-5 mx-2">
       <div class="col-sm-12 text-end">
            <a href="../PDomanda/RiepilogoDomanda.aspx" class="btn btn-secondary py-1">
                <svg class="icon icon-breadcrumb icon-secondary icon-white me-1" aria-hidden="true">
                    <use href="/web/bootstrap-italia/svg/sprites.svg#it-check"></use>
                </svg>
                Torna alla Presentazione</a>
        </div>
       <h2 class="pb-5">Dichiarazioni & impegni</h2>
       <p class="testo_pagina">
           Elenco delle dichiarazioni e degli impegni che verranno sottoscritti digitalmente al momento
                della presentazione della domanda.
       </p>     
        <div class="form-group col-sm-12">
            Accettazione delle dichiarazioni OBBLIGATORIE per la presentazione della domanda:
        </div>  
       <div class="form-group col-sm-12">
           <Siar:DataGridAgid CssClass="table table-striped" ID="dgObbligatorie" runat="server" AutoGenerateColumns="False" Width="100%" AllowPaging="true" PageSize="10">
               <Columns>
                   <Siar:NumberColumn HeaderText="Nr.">
                       <ItemStyle Width="35px" HorizontalAlign="center" />
                   </Siar:NumberColumn>
                   <asp:BoundColumn DataField="Descrizione" HeaderText="Dichiarazione"></asp:BoundColumn>
               </Columns>
           </Siar:DataGridAgid>
           <br />
       </div>
       <div class="form-group col-sm-12">
           Selezione delle dichiarazioni CON SCELTA OPZIONALE per la presentazione della domanda:
       </div>
       <div>
           <Siar:DataGridAgid ID="dgFacoltative" CssClass="table table-striped" runat="server" AutoGenerateColumns="False" Width="100%" AllowPaging="true" PageSize="10">
               <Columns>
                   <Siar:NumberColumn HeaderText="Nr.">
                       <ItemStyle Width="35px" HorizontalAlign="center" />
                   </Siar:NumberColumn>
                   <asp:BoundColumn DataField="Descrizione" HeaderText="Dichiarazione"></asp:BoundColumn>
                   <Siar:CheckColumn DataField="IdDichiarazione" Name="chkFacolt" HeaderText=" ">
                       <ItemStyle HorizontalAlign="Center" Width="70px" />
                   </Siar:CheckColumn>
               </Columns>
           </Siar:DataGridAgid><br />
       </div>
       <div class=" col-sm-12">
           <Siar:Button ID="btnSalva" Text="Accettazione dichiarazioni" runat="server" OnClick="btnAccettazione_Click"
               CausesValidation="false" Modifica="True" />           
       </div>
        <div class="col-sm-12 text-end pt-3">
            <a href="../PDomanda/RiepilogoDomanda.aspx" class="btn btn-secondary py-1">
                <svg class="icon icon-breadcrumb icon-secondary icon-white me-1" aria-hidden="true">
                    <use href="/web/bootstrap-italia/svg/sprites.svg#it-check"></use>
                </svg>
                Torna alla Presentazione</a>
        </div>
    </div>
</asp:Content>
