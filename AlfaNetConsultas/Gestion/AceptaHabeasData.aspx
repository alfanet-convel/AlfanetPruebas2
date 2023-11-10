<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true"
    CodeFile="AceptaHabeasData.aspx.cs" Inherits="AceptaHabeasData" %>

<%@ Register Assembly="DevExpress.Web.v9.1" Namespace="DevExpress.Web.ASPxPopupControl"
    TagPrefix="dxpc" %>

<%@ Register Assembly="DevExpress.Web.v9.1" Namespace="DevExpress.Web.ASPxCallbackPanel"
    TagPrefix="dxcp" %>
<%@ Register Assembly="DevExpress.Web.v9.1" Namespace="DevExpress.Web.ASPxPanel"
    TagPrefix="dxp" %>

<%--<%@ Register Assembly="Infragistics2.WebUI.UltraWebChart.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebChart" TagPrefix="igchart" %>
<%@ Register Assembly="Infragistics2.WebUI.UltraWebChart.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.UltraChart.Resources.Appearance" TagPrefix="igchartprop" %>
<%@ Register Assembly="Infragistics2.WebUI.UltraWebChart.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.UltraChart.Data" TagPrefix="igchartdata" %>--%>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=B03F5F7F11D50A3A"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Import Namespace="System.Configuration" %>
<%--<%@ Register Src="../NavDocRecibido.ascx" TagName="NavDocRecibido" TagPrefix="uc1" %>
<%@ Register Src="NavDocRecibido.ascx" TagName="NavDocRecibido" TagPrefix="uc2" %>--%>

<%--<%@ Register assembly="DevExpress.Web.ASPxPivotGrid.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPivotGrid" tagprefix="dxwpg" %>
<%@ Register assembly="DevExpress.Web.ASPxPivotGrid.v9.1.Export, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraPivotGrid.Web" tagprefix="dxpgw" %>--%>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register Assembly="DevExpress.Web.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dxp" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.1" Namespace="DevExpress.Web.ASPxEditors"
    TagPrefix="dxe" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.1" Namespace="DevExpress.Web.ASPxGridView"
    TagPrefix="dxwgv" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.1.Export, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView.Export" TagPrefix="dxwgv" %>

<%--<%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>--%>

<%--<%@ Register Assembly="DevExpress.XtraCharts.v9.1.Web, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.XtraCharts.Web" TagPrefix="dxchartsui" %>
<%@ Register Assembly="DevExpress.XtraCharts.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.XtraCharts" TagPrefix="cc2" %>--%>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>
<%@ Register Assembly="DevExpress.Web.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dxpc" %>
<%@ Register Assembly="DevExpress.Web.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dxcp" %>
<%@ Register Assembly="DevExpress.Web.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dxp" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <script language="javascript" type="text/javascript">
        // <!CDATA[
        // function url(evt) 
        //        {
        //            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
        //            hidden = open('../../AlfaNetDocumentos/DocRecibido/DocRecibidoReporte.aspx?TipoCodigo=1&RadicadoCodigo=1' + src.innerText + '&GrupoCodigo=1&ControlDias=1&Admon=S', 'NewWindow','top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');
        //        }
        //            function urlInt(evt) 
        //        {
        //            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
        //            hidden = open('../../AlfaNetDocumentos/DocEnviado/DocEnviadoReporte.aspx?TipoCodigo=1&RadicadoCodigo=1' + src.innerText + '&GrupoCodigo=1&ControlDias=1&Admon=S', 'NewWindow','top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');
        //        }
        //        //Respuesta
        //           function urlRpta(evt) 
        //        {
        //            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
        //            hidden = open('../../AlfaNetDocumentos/DocEnviado/NuevoDocEnviadoInt.aspx?Admon=S', 'NewWindow','top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');
        //        }
        //         //Visor de Imagenes Recibida
        //           function VImagenes(evt,NumeroDocumento) 
        //        {
        //            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
        //            hidden = open('../../AlfaNetImagen/VisorImagenes/VisorImagenes.aspx?DocumentoCodigo=' + NumeroDocumento + '&GrupoCodigo=1&GrupoPadreCodigo=1&Admon=S&ImagenFolio=1', 'NewWindow','top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');
        //            
        //        }
        //        //Visor de Imagenes Enviada
        //           function VImagenesReg(evt,NumeroDocumento) 
        //        {
        //            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
        //            hidden = open('../../AlfaNetImagen/VisorImagenes/VisorImagenes.aspx?DocumentoCodigo=' + NumeroDocumento + '&GrupoCodigo=2&GrupoPadreCodigo=2&Admon=S&ImagenFolio=1', 'NewWindow','top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');
        //
        //        }

        function url(evt, Grupo) {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            var Rad = src.innerText || src.innerHTML;
            hidden = open('../../AlfaNetDocumentos/DocRecibido/DocRecibidoReporte.aspx?TipoCodigo=1&RadicadoCodigo=1' + Rad + '&GrupoCodigo=' + Grupo + '&ControlDias=1&Admon=S', 'NewWindow', 'top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');
        }
        function urlInt(evt, Grupo) {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            var Rad = src.innerText || src.innerHTML;
            hidden = open('../../AlfaNetDocumentos/DocEnviado/DocEnviadoReporte.aspx?TipoCodigo=1&RadicadoCodigo=1' + Rad + '&GrupoCodigo=' + Grupo + '&ControlDias=1&Admon=S&RptaImg=S', 'NewWindow', 'top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');
        }
        //Respuesta
        function urlRpta(evt) {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            hidden = open('../../AlfaNetDocumentos/DocEnviado/NuevoDocEnviadoInt.aspx?Admon=S&RptaImg=S', 'NewWindow', 'top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');

        }
        //Visor de Imagenes Recibida
        function VImagenes(evt, NumeroDocumento, Grupo) {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            hidden = open('../../AlfaNetImagen/VisorImagenes/VisorImagenes.aspx?DocumentoCodigo=' + NumeroDocumento + '&GrupoCodigo=' + Grupo + '&GrupoPadreCodigo=1&Admon=S&ImagenFolio=1', 'NewWindow', 'top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');

        }
        //Visor de Imagenes Enviada
        function VImagenesReg(evt, NumeroDocumento, Grupo) {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            hidden = open('../../AlfaNetImagen/VisorImagenes/VisorImagenes.aspx?DocumentoCodigo=' + NumeroDocumento + '&GrupoCodigo=' + Grupo + '&GrupoPadreCodigo=2&Admon=S&ImagenFolio=1', 'NewWindow', 'top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');

        }
        //Historico Recibida
        function Historico(evt, NumeroDocumento, Grupo) {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            hidden = open('../../AlfaNetWorkFlow/AlfaNetWF/HistorialWF.aspx?RadicadoCodigo=' + NumeroDocumento + '&GrupoCodigo=' + Grupo + '&GrupoPadreCodigo=1&Admon=S', 'NewWindow', 'top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');

        }
        //Historico Recibida
        function HistoricoReg(evt, NumeroDocumento, Grupo) {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            hidden = open('../../AlfaNetWorkFlow/AlfaNetWF/HistorialWFEnviada.aspx?RadicadoCodigo=' + NumeroDocumento + '&GrupoCodigo=' + Grupo + '&GrupoPadreCodigo=1&Admon=S', 'NewWindow', 'top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');

        }
        //Expediente
        function Expediente(evt, NumeroDocumento, Expediente, Grupo) {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            //var Expediente1 = "101";
            hidden = open('../../AlfaNetConsultas/Gestion/Expediente.aspx?NumeroDocumento=' + NumeroDocumento + '&ExpedienteCodigo=' + Expediente + '&GrupoCodigo=' + Grupo + '&GrupoPadreCodigo=101&Admon=S', 'NewWindow', 'top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');

        }
        //Expediente
        function UrlAvisoPrivacidad(evt ) {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            //var Expediente1 = "101";
            hidden = open('https://www.unab.edu.co/aviso-de-privacidad', 'NewWindow', 'top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');

        }

        function OnMoreInfoClick(element, key) {
            callbackPanel.PerformCallback(key);
            popup.ShowAtElement(element);
        }
        function popup_Shown(s, e) {
            callbackPanel.AdjustControl();
        }

        //// ]]>

    </script>
    <style>
        .AreaAutorizo{
            height:30px;
            width:375px;
            border:1px;
            border-radius:2px;
        }
        .OcultaColumna{
            display:none;
        }
    </style>
    <table style="font-size: 8pt; width: 100%;">
        <tr>
            <td>
                <cc1:Accordion ID="MyAccordion" runat="server" Width="100%" TransitionDuration="250"
                    SuppressHeaderPostbacks="true" RequireOpenedPane="false" HeaderSelectedCssClass="accordionHeaderSelected"
                    HeaderCssClass="accordionHeader" FramesPerSecond="40" FadeTransitions="false"
                    ContentCssClass="accordionContent" AutoSize="None">
                    <Panes>
                        <cc1:AccordionPane ID="AccordionPane1" Font-Size="medium" runat="server" ContentCssClass="" HeaderCssClass="">
                            <Header>
                                <a class="accordionLink" href="">Habeas Data.:</a>
                            </Header>
                            <Content>
                                <table style="width: 100%; text-align: left"
                                    forecolor="White">
                                    <tbody>
                                        <tr>
                                            <td
                                                style="width: 489px; color: white; height: 16px; background-color: #507cd1; text-align: center">Consulta de Aceptación Habeas Data</td>
                                        </tr>
                                        <tr>
                                            <td
                                                style="width: 100%; height: 8px; background-color: #eff3fb" colspan="3">
                                                <asp:UpdatePanel ID="UpdatePanelFechas" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:CheckBox ID="ChBFechaRad" runat="server" Width="185px" Text="Entre Fechas de Radicacion" OnCheckedChanged="ChBFechaRad_CheckedChanged" AutoPostBack="True"></asp:CheckBox>
                                                        <br />
                                                        <cc1:CalendarExtender ID="CalendarFinal" runat="server" TargetControlID="TxtFechaFinal" Format="dd/MM/yyyy" PopupButtonID="ImgCalendarFinal">
                                                        </cc1:CalendarExtender>
                                                        <cc1:CalendarExtender ID="CalendarInicial" runat="server" TargetControlID="TxtFechaInicial" Format="dd/MM/yyyy" PopupButtonID="ImgCalendarInicial">
                                                        </cc1:CalendarExtender>
                                                        <asp:Label ID="LblFechaInicial" runat="server" Width="70px" Text="Fecha Inicial" Visible="False"></asp:Label>
                                                        <asp:TextBox ID="TxtFechaInicial" runat="server" Width="70px" Font-Size="8pt" Visible="False"></asp:TextBox>
                                                        <asp:Image ID="ImgCalendarInicial" runat="server" Width="27px" Height="20px" ImageUrl="~/AlfaNetImagen/ToolBar/calendario.png" Visible="False"></asp:Image>
                                                        <asp:Label ID="LblFechaFinal" runat="server" Width="70px" Visible="False">FechaFinal</asp:Label>
                                                        <asp:TextBox ID="TxtFechaFinal" runat="server" Width="70px" Font-Size="8pt" Visible="False"></asp:TextBox>
                                                        <asp:Image ID="ImgCalendarFinal" runat="server" Width="27px" Height="20px" ImageUrl="~/AlfaNetImagen/ToolBar/calendario.png" Visible="False"></asp:Image>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ChBFechaRad" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td
                                                style="width: 100%; background-color: #ffffff">
                                                <asp:UpdatePanel ID="UpdatePanelNroRad" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:CheckBox ID="ChBNroRad" runat="server" Text="Entre Numeros de Radicacion" Width="181px"
                                                            OnCheckedChanged="ChBNroRad_CheckedChanged" AutoPostBack="True" /><br />
                                                        <asp:Label ID="LblNroRadInicial" runat="server" Text="Numero Radicado Inicial" Visible="False"
                                                            Width="120px"></asp:Label><asp:TextBox ID="TxtNroRadInicial" runat="server" Font-Size="8pt"
                                                                Visible="False" Width="70px"></asp:TextBox><asp:Label ID="LblNroRadFinal" runat="server"
                                                                    Visible="False" Width="120px">Numero Radicado Final</asp:Label><asp:TextBox ID="TxtNroRadFinal"
                                                                        runat="server" Font-Size="8pt" Visible="False" Width="70px"></asp:TextBox>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ChBNroRad" EventName="CheckedChanged" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td
                                                style="width: 100%; background-color: #eff3fb">
                                                <asp:UpdatePanel ID="UpdatePanelDestino" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:CheckBox ID="ChBProcedId" runat="server" Width="300px" Text="Por Procedencia ...(Seleccione o ingrese criterio)" AutoPostBack="True" OnCheckedChanged="ChBProcedId_CheckedChanged"></asp:CheckBox><br />
                                                        <asp:Label ID="LblProcedId" runat="server" Width="60px" Visible="False" Text="Procedencia: "></asp:Label><cc1:PopupControlExtender ID="PopupControlProcedId" runat="server" PopupControlID="PnlProcedId" TargetControlID="TxtProcedId" Position="Right">
                                                        </cc1:PopupControlExtender>
                                                        <cc1:AutoCompleteExtender ID="AutoCompleteProcedId" runat="server" TargetControlID="TxtProcedId" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetProcedenciaByTextNombreNull" MinimumPrefixLength="1" CompletionSetCount="20" CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem " CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                                        </cc1:AutoCompleteExtender>
                                                        <asp:TextBox ID="TxtProcedId" runat="server" Width="400px" Font-Size="8pt" Visible="False" CssClass="TxtAutoComplete"></asp:TextBox>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ChBProcedId" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td
                                                style="width: 100%; background-color: #ffffff">
                                                <asp:UpdatePanel ID="UpdatePanelAcepta" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:CheckBox ID="chkAcepta" runat="server" Text="Por Autorización Habeas Data" AutoPostBack="True" OnCheckedChanged="chkAcepta_CheckedChanged" /><br />
                                                        <asp:Label ID="LblAcepta" runat="server" Width="120px" Visible="False" Text="Terminos Habeas Data:"></asp:Label>
                                                        <asp:RadioButtonList ID="RblAcepta" runat="server" RepeatDirection="Horizontal" Visible="False">
                                                            <asp:ListItem Selected="True" Value="1">Autorizó</asp:ListItem>
                                                            <%--<asp:ListItem Value="0">No Autorizó</asp:ListItem>--%>
                                                        </asp:RadioButtonList>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="chkAcepta" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td
                                                style="width: 100%; color: white; background-color: #507cd1" colspan="3">
                                                <table style="width: 100%">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Table ID="Table3" runat="server" Width="125px" ForeColor="White" Height="30px" CellSpacing="4" CellPadding="0">
                                                                    <asp:TableRow ID="TableRow1" runat="server">
                                                                        <asp:TableCell ID="clBuscar" runat="server" CssClass="BarButton">
                                                                            <asp:LinkButton ID="cmdBuscar" ForeColor="White" runat="server" BorderStyle="None"
                                                                                CssClass="CommandButton" OnClick="cmdBuscar_Click" TabIndex="24" Text="Buscar"></asp:LinkButton>
                                                                        </asp:TableCell>
                                                                        <asp:TableCell ID="clNuevo" runat="server" CssClass="BarButton">
                                                                            <asp:LinkButton ID="Nuevo" runat="server" ForeColor="White" BorderStyle="None" CausesValidation="False"
                                                                                CssClass="CommandButton" OnClick="BtnNuevo_Click" TabIndex="24" Text="Nueva Busqueda"></asp:LinkButton>
                                                                        </asp:TableCell>
                                                                    </asp:TableRow>
                                                                </asp:Table>
                                                            </td>
                                                            <td></td>
                                                            <td>
                                                                <asp:RadioButtonList ID="RBLTblRpt" runat="server" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Selected="True" Value="1">Tabla Resultados</asp:ListItem>
                                                                    <asp:ListItem Value="0">Reporte</asp:ListItem>
                                                                </asp:RadioButtonList></td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </Content>
                        </cc1:AccordionPane>
                        <cc1:AccordionPane ID="AccordionPane2" Font-Size="medium" runat="server" ContentCssClass="" HeaderCssClass="">
                            <Header>
                                <a class="accordionLink" href="">Resultados.:</a>
                            </Header>
                            <Content>
                                <table style="width: 100%; height: 100%">
                                    <tbody>
                                        <tr>
                                            <td>
                                                <dxwgv:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server">
                                                </dxwgv:ASPxGridViewExporter>
                                                <table class="style1">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <dxe:ASPxComboBox ID="listExportFormat" runat="server" ValueType="System.String" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" CssPostfix="Office2003_Blue" ImageFolder="~/App_Themes/Office2003 Blue/{0}/">
                                                                    <Items>
                                                                        <dxe:ListEditItem Text="Pdf" Value="0"></dxe:ListEditItem>
                                                                        <dxe:ListEditItem Text="Excel" Value="1"></dxe:ListEditItem>
                                                                        <dxe:ListEditItem Text="Rtf" Value="2"></dxe:ListEditItem>
                                                                        <dxe:ListEditItem Text="Csv" Value="3"></dxe:ListEditItem>
                                                                    </Items>

                                                                    <ButtonStyle Width="13px"></ButtonStyle>
                                                                </dxe:ASPxComboBox>
                                                            </td>
                                                            <td>
                                                                <dxe:ASPxButton ID="ButtonOpen" OnClick="ButtonOpen_Click" runat="server" Text="Abrir" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" CssPostfix="Office2003_Blue">
                                                                </dxe:ASPxButton>
                                                            </td>
                                                            <td style="width: 65px">
                                                                <dxe:ASPxButton ID="ButtonSaveAs" OnClick="ButtonSaveAs_Click" runat="server" Text="Guardar" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" CssPostfix="Office2003_Blue">
                                                                </dxe:ASPxButton>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                                <dxpc:ASPxPopupControl ID="popup" runat="server" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" CssPostfix="Office2003_Blue" ImageFolder="~/App_Themes/Office2003 Blue/{0}/" ClientInstanceName="popup" AllowDragging="True" PopupHorizontalAlign="OutsideRight" HeaderText="Vinculo a Respuesta">
                                                    <ClientSideEvents Shown="popup_Shown"></ClientSideEvents>
                                                    <ContentCollection>
                                                        <dxpc:PopupControlContentControl runat="server">
                                                            <dxcp:ASPxCallbackPanel runat="server" ClientInstanceName="callbackPanel" RenderMode="Table" Width="100%" Height="100%" ID="callbackPanel" OnCallback="callbackPanel_Callback">
                                                                <LoadingPanelImage Url="~/App_Themes/Office2003 Blue/Web/Loading.gif"></LoadingPanelImage>

                                                                <LoadingDivStyle Opacity="100" BackColor="White"></LoadingDivStyle>
                                                                <PanelCollection>
                                                                    <dxp:PanelContent runat="server">
                                                                        <table>
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td align="center">
                                                                                        <asp:Literal runat="server" ID="litText"></asp:Literal>

                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </dxp:PanelContent>
                                                                </PanelCollection>
                                                            </dxcp:ASPxCallbackPanel>
                                                        </dxpc:PopupControlContentControl>
                                                    </ContentCollection>
                                                </dxpc:ASPxPopupControl>
                                                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                                    <ContentTemplate>
                                                        <dxwgv:ASPxGridView ID="ASPxGridView1" runat="server" Width="100%" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" CssPostfix="Office2003_Blue" AutoGenerateColumns="False" KeyFieldName="RadicadoCodigo" OnHtmlRowPrepared="ASPxGridView1_HtmlRowPrepared">
                                                            <Styles CssPostfix="Office2003_Blue" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css">
                                                                <Header SortingImageSpacing="5px" ImageSpacing="5px"></Header>

                                                                <LoadingPanel ImageSpacing="10px"></LoadingPanel>
                                                            </Styles>

                                                            <SettingsLoadingPanel Text="Cargando&amp;hellip;" ShowImage="False"></SettingsLoadingPanel>

                                                            <SettingsPager ShowSeparators="True">
                                                                <Summary AllPagesText="Paginas: {0} - {1} ({2} Radicados)" Text="Pagina {0} de {1} ({2} Radicados)"></Summary>
                                                            </SettingsPager>

                                                            <ImagesFilterControl>
                                                                <AddButton AlternateText="Agregar"></AddButton>

                                                                <RemoveButton AlternateText="Remover"></RemoveButton>

                                                                <AddCondition AlternateText="Adicionar Condicion"></AddCondition>

                                                                <AddGroup AlternateText="Adiccionar Grupo"></AddGroup>

                                                                <RemoveGroup AlternateText="Remover Grupo"></RemoveGroup>

                                                                <OperationAnyOf AlternateText="Todos De"></OperationAnyOf>

                                                                <OperationBeginsWith AlternateText="Empezar por"></OperationBeginsWith>

                                                                <OperationBetween AlternateText="Entre"></OperationBetween>

                                                                <OperationContains AlternateText="Contiene"></OperationContains>

                                                                <OperationDoesNotContain AlternateText="No Contiene"></OperationDoesNotContain>

                                                                <OperationDoesNotEqual AlternateText="Diferente de"></OperationDoesNotEqual>

                                                                <OperationEndsWith AlternateText="Finaliza En"></OperationEndsWith>

                                                                <OperationEquals AlternateText="Igual A"></OperationEquals>

                                                                <OperationGreater AlternateText="Mayor Que"></OperationGreater>

                                                                <OperationGreaterOrEqual AlternateText="Mayor o Igual a"></OperationGreaterOrEqual>

                                                                <OperationIsNotNull AlternateText="No es Nulo"></OperationIsNotNull>

                                                                <OperationIsNull AlternateText="Es Nulo"></OperationIsNull>

                                                                <OperationLess AlternateText="Menor que"></OperationLess>

                                                                <OperationLessOrEqual AlternateText="Menor o Igual que"></OperationLessOrEqual>

                                                                <OperationLike AlternateText="Hace Parte de"></OperationLike>

                                                                <OperationNoneOf AlternateText="Nada de"></OperationNoneOf>

                                                                <OperationNotBetween AlternateText="Fuera de"></OperationNotBetween>

                                                                <OperationNotLike AlternateText="No Hace Parte de"></OperationNotLike>

                                                                <LoadingPanel AlternateText="Cargando..."></LoadingPanel>
                                                            </ImagesFilterControl>

                                                            <Images ImageFolder="~/App_Themes/Office2003 Blue/{0}/">
                                                                <CollapsedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvCollapsedButton.png"></CollapsedButton>

                                                                <ExpandedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvExpandedButton.png"></ExpandedButton>

                                                                <DetailCollapsedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvCollapsedButton.png"></DetailCollapsedButton>

                                                                <DetailExpandedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvExpandedButton.png"></DetailExpandedButton>

                                                                <FilterRowButton Height="13px" Width="13px"></FilterRowButton>
                                                            </Images>

                                                            <SettingsText Title="Medio" GroupPanel="Coloque la Columna por la que desea agrugar" ConfirmDelete="Confirmar Eliminar" PopupEditFormCaption="Editar Formulario" EmptyHeaders="Encabezados Vacios" GroupContinuedOnNextPage="Grupo Continua En la Siguiente Pagina" EmptyDataRow="No se han Encontrado registros que Cumplan con este Criterio" CommandEdit="Editar" CommandNew="Nuevo" CommandDelete="Eliminar" CommandSelect="Seleccionar" CommandCancel="Cancelar" CommandUpdate="Actualizar" CommandClearFilter="Borrar Filtro" HeaderFilterShowAll="Mostrar todos los Encabezados de Filtro" FilterControlPopupCaption="Filtro Aplicado" FilterBarClear="Limpiar Barra de Filtro" FilterBarCreateFilter="Crear Filtro"></SettingsText>
                                                            <Columns>
                                                                <dxwgv:GridViewCommandColumn VisibleIndex="0">
                                                                    <ClearFilterButton Visible="True"></ClearFilterButton>
                                                                </dxwgv:GridViewCommandColumn>
                                                                <dxwgv:GridViewDataTextColumn FieldName="RadicadoCodigo" Caption="Radicado" VisibleIndex="1">
                                                                    <Settings AutoFilterCondition="Contains"></Settings>
                                                                    <DataItemTemplate><br>
                                                                        <asp:HyperLink ID="HyperLink1" runat="server" Text='<%# Eval("RadicadoCodigo") %>' Font-Underline="True" CssClass="LinKBtnStyleBig"></asp:HyperLink><br />
                                                                        <asp:HiddenField ID="HFRad" runat="server" Value='<%# Eval("RadicadoCodigo") %>' ></asp:HiddenField>
                                                                    </DataItemTemplate>
                                                                </dxwgv:GridViewDataTextColumn>
                                                                <dxwgv:GridViewDataTextColumn FieldName="WFMovimientoFecha" Caption="Fecha Autorización" VisibleIndex="2">
                                                                    <Settings AutoFilterCondition="Contains"></Settings>
                                                                </dxwgv:GridViewDataTextColumn>
                                                                <dxwgv:GridViewDataTextColumn FieldName="Documento" Caption="Tipo de Identificación" VisibleIndex="3">
                                                                    <Settings AutoFilterCondition="Contains"></Settings>
                                                                </dxwgv:GridViewDataTextColumn>
                                                                <dxwgv:GridViewDataTextColumn FieldName="ProcedenciaCodigo" Caption="Identificación Titular" VisibleIndex="4">
                                                                    <Settings AutoFilterCondition="Contains"></Settings>
                                                                </dxwgv:GridViewDataTextColumn>
                                                                <dxwgv:GridViewDataTextColumn FieldName="ProcedenciaNombre" Caption="Nombre y Apellidos Titular" VisibleIndex="5">
                                                                    <Settings AutoFilterCondition="Contains"></Settings>
                                                                </dxwgv:GridViewDataTextColumn>
                                                                <dxwgv:GridViewDataTextColumn FieldName="Email" Caption="Email" VisibleIndex="6" CellStyle-CssClass="OcultaColumna" HeaderStyle-CssClass="OcultaColumna" FilterCellStyle-CssClass="OcultaColumna">
                                                                    <Settings AutoFilterCondition="Contains"></Settings>
                                                                </dxwgv:GridViewDataTextColumn>
                                                                <dxwgv:GridViewDataTextColumn FieldName="Telefono" Caption="Telefono" VisibleIndex="7" CellStyle-CssClass="OcultaColumna" HeaderStyle-CssClass="OcultaColumna" FilterCellStyle-CssClass="OcultaColumna">
                                                                    <Settings AutoFilterCondition="Contains"></Settings>
                                                                </dxwgv:GridViewDataTextColumn>
                                                                <dxwgv:GridViewDataTextColumn FieldName="Direccion" Caption="Direccion" VisibleIndex="8" CellStyle-CssClass="OcultaColumna" HeaderStyle-CssClass="OcultaColumna" FilterCellStyle-CssClass="OcultaColumna">
                                                                    <Settings AutoFilterCondition="Contains"></Settings>
                                                                </dxwgv:GridViewDataTextColumn>
                                                                <dxwgv:GridViewDataTextColumn FieldName="PaisNombre" Caption="Pais" VisibleIndex="9" CellStyle-CssClass="OcultaColumna" HeaderStyle-CssClass="OcultaColumna" FilterCellStyle-CssClass="OcultaColumna">
                                                                    <Settings AutoFilterCondition="Contains"></Settings>
                                                                </dxwgv:GridViewDataTextColumn>
                                                                <dxwgv:GridViewDataTextColumn FieldName="DepartamentoNombre" Caption="Departamento" VisibleIndex="10" CellStyle-CssClass="OcultaColumna" HeaderStyle-CssClass="OcultaColumna" FilterCellStyle-CssClass="OcultaColumna">
                                                                    <Settings AutoFilterCondition="Contains"></Settings>
                                                                </dxwgv:GridViewDataTextColumn>
                                                                <dxwgv:GridViewDataTextColumn FieldName="CiudadNombre" Caption="Ciudad" VisibleIndex="11" CellStyle-CssClass="OcultaColumna" HeaderStyle-CssClass="OcultaColumna" FilterCellStyle-CssClass="OcultaColumna">
                                                                    <Settings AutoFilterCondition="Contains"></Settings>
                                                                </dxwgv:GridViewDataTextColumn> 
                                                                <dxwgv:GridViewDataTextColumn FieldName="NaturalezaNombre" Caption="Naturaleza" VisibleIndex="12" CellStyle-CssClass="OcultaColumna" HeaderStyle-CssClass="OcultaColumna" FilterCellStyle-CssClass="OcultaColumna">
                                                                    <Settings AutoFilterCondition="Contains"></Settings>
                                                                </dxwgv:GridViewDataTextColumn>
                                                                <dxwgv:GridViewDataTextColumn FieldName="DetallePQR" Caption="DetallePQR" VisibleIndex="13" CellStyle-CssClass="OcultaColumna" HeaderStyle-CssClass="OcultaColumna" FilterCellStyle-CssClass="OcultaColumna">
                                                                    <Settings AutoFilterCondition="Contains"></Settings>
                                                                </dxwgv:GridViewDataTextColumn>
                                                                <dxwgv:GridViewDataTextColumn FieldName="AceptoHabeasData" Caption="Autorización Habeas Data" VisibleIndex="14">
                                                                    <Settings AutoFilterCondition="Contains"></Settings>
                                                                </dxwgv:GridViewDataTextColumn>
                                                                <dxwgv:GridViewDataTextColumn FieldName="TextoAutorizado" UnboundType="String" Caption="Texto Autorizado" VisibleIndex="15">
                                                                    <Settings AllowDragDrop="False" AllowAutoFilterTextInputTimer="False" AllowAutoFilter="False" ShowFilterRowMenu="False" AllowHeaderFilter="False" ShowInFilterControl="False" AllowSort="False" AllowGroup="False"></Settings>
                                                                    <DataItemTemplate>
                                                                        <asp:TextBox ID="TxtTextoAutorizo" runat="server" TextMode="MultiLine" Enabled="false" Text='<%# Eval("TextoAutorizado") %>' CssClass="AreaAutorizo"></asp:TextBox>
                                                                     </DataItemTemplate>
                                                                </dxwgv:GridViewDataTextColumn>

                                                            </Columns>

                                                            <Settings ShowFilterRow="True" ShowGroupPanel="True"></Settings>

                                                            <StylesEditors>
                                                                <ProgressBar Height="25px"></ProgressBar>
                                                            </StylesEditors>
                                                        </dxwgv:ASPxGridView>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:PostBackTrigger ControlID="ButtonSaveAs"></asp:PostBackTrigger>
                                                        <asp:PostBackTrigger ControlID="ButtonOpen"></asp:PostBackTrigger>
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </Content>
                        </cc1:AccordionPane>
                        <cc1:AccordionPane ID="AccordionPane3" Font-Size="medium" runat="server" ContentCssClass="" HeaderCssClass="">
                            <Header>
                                <a class="accordionLink" href="">Reporte.:</a>
                            </Header>
                            <Content>
                                <rsweb:ReportViewer ID="ReportViewer1" runat="server" BackColor="White" Width="100%" Height="400px" Font-Size="8pt" Font-Names="Verdana" AsyncRendering="false">
                                    <LocalReport ReportPath="AlfaNetConsultas\Gestion\DocRecibido.rdlc" EnableExternalImages="True">
                                        <DataSources>
                                            <rsweb:ReportDataSource DataSourceId="ODSBuscarGraph" Name="DSRadicado_Radicado_ConsultasHabeasData" />
                                        </DataSources>
                                    </LocalReport>
                                </rsweb:ReportViewer>
                            </Content>
                        </cc1:AccordionPane>
                    </Panes>
                </cc1:Accordion>
                <asp:ObjectDataSource ID="ODSBuscarGraph" runat="server" SelectMethod="GetConsultasHabeasData" TypeName="RadicadoBLL" OldValuesParameterFormatString="Original_{0}" InsertMethod="Update_Plantilla" UpdateMethod="UpdateRadicado">
                    <InsertParameters>
                        <asp:Parameter Name="DependenciaCodigo" Type="String"></asp:Parameter>
                        <asp:Parameter Name="ExpedienteCodigo" Type="String"></asp:Parameter>
                        <asp:Parameter Name="MedioCodigo" Type="String"></asp:Parameter>
                        <asp:Parameter Name="WFAccionCodigo" Type="String"></asp:Parameter>
                    </InsertParameters>
                    <SelectParameters>
                        <asp:Parameter Name="WFMovimientoFecha" Type="String" />
                        <asp:Parameter Name="WFMovimientoFecha1" Type="String" />
                        <asp:Parameter Name="RadicadoCodigo" Type="String" />
                        <asp:Parameter Name="RadicadoCodigo1" Type="String" />
                        <asp:Parameter Name="ProcedenciaCodigo" Type="String" />
                        <asp:Parameter Name="ProcedenciaNombre" Type="String" />
                        <asp:Parameter Name="DependenciaConsulta" Type="String" />
                        <asp:Parameter Name="AceptaHabeasData" Type="String" />
                    </SelectParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="RadicadoCodigo" Type="String"></asp:Parameter>
                        <asp:Parameter Name="GrupoCodigo" Type="String"></asp:Parameter>
                        <asp:Parameter Name="WFMovimientoFecha" Type="DateTime"></asp:Parameter>
                        <asp:Parameter Name="RadicadoFechaProcedencia" Type="DateTime"></asp:Parameter>
                        <asp:Parameter Name="ProcedenciaCodigo" Type="String"></asp:Parameter>
                        <asp:Parameter Name="RadicadoNumeroExterno" Type="String"></asp:Parameter>
                        <asp:Parameter Name="NaturalezaCodigo" Type="String"></asp:Parameter>
                        <asp:Parameter Name="DependenciaCodigo" Type="String"></asp:Parameter>
                        <asp:Parameter Name="RadicadoDetalle" Type="String"></asp:Parameter>
                        <asp:Parameter Name="RadicadoAnexo" Type="String"></asp:Parameter>
                        <asp:Parameter Name="RadicadoFechaVencimiento" Type="DateTime"></asp:Parameter>
                        <asp:Parameter Name="ExpedienteCodigo" Type="String"></asp:Parameter>
                        <asp:Parameter Name="MedioCodigo" Type="String"></asp:Parameter>
                        <asp:Parameter Name="DependenciaCodDestino" Type="String"></asp:Parameter>
                        <asp:Parameter Name="Original_RadicadoCodigo" Type="String"></asp:Parameter>
                        <asp:Parameter Name="Original_GrupoCodigo" Type="String"></asp:Parameter>
                        <asp:Parameter Name="NumeroGuia" Type="String"></asp:Parameter>
                    </UpdateParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="ExceptionDetails" runat="server" Font-Size="10pt" ForeColor="Red"
                    Width="100%"></asp:Label>
                <asp:Label ID="MyLabelTemp" runat="server" Width="100%"></asp:Label><asp:ValidationSummary Style="vertical-align: middle; text-align: left" ID="ValidationSummaryRadicado"
                    runat="server" Width="100%" Font-Size="10pt" DisplayMode="List"></asp:ValidationSummary>
            </td>
        </tr>
    </table>

</asp:Content>
