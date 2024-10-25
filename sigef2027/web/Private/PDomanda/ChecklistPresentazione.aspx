<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    EnableViewState="true" Inherits="web.Private.PDomanda.ChecklistPresentazione"
    CodeBehind="ChecklistPresentazione.aspx.cs" %>

<%@ Register Src="../../CONTROLS/ChecklistNew.ascx" TagName="Checklist" TagPrefix="siar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <nav class="breadcrumb-container" aria-label="Percorso di navigazione">
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="../PDomanda/RiepilogoDomanda.aspx">
            <svg class="icon icon-breadcrumb icon-secondary align-top me-1" aria-hidden="true">
                <use href="/web/bootstrap-italia/svg/sprites.svg#it-check""></use>
            </svg>
            Presentazione</a><span class="separator">/</span></li>
        <li class="breadcrumb-item active" aria-current="page">ChecklistPresentazione</li>
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
        <h2 class="pb-5">Checklist di presentazione</h2>
        <p class="testo_pagina" style="height: 64px">
            Elenco dei requisiti finali: per procedere alla presentazione della domanda è indispensabile che            
            tutti i requisiti <b>obbligatori</b> abbiano esito positivo.
        </p>
        <div class="col-sm-12">
            <Siar:Checklist ID="ucChecklist" runat="server" Fase="P" NoteColumnVisible="false"
                DefaultRedirect="~/Private/PDomanda/RicercaDomanda.aspx" />
        </div>


        <div class="col-sm-12">
            <Siar:Button ID="btnVerifica" runat="server" OnClick="btnVerifica_Click" Text="Verifica dei requisiti" Modifica="true" />
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
