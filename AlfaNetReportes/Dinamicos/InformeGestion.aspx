<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="InformeGestion.aspx.cs" Inherits="AlfaNetReportes_Dinamicos_InformeGestion" Title="Informe de Gestion de Documentos" %>

<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v9.1" Namespace="DevExpress.Web.ASPxPivotGrid"
    TagPrefix="dxwpg" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.1" Namespace="DevExpress.Web.ASPxGridView"
    TagPrefix="dxwgv" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.1" Namespace="DevExpress.Web.ASPxEditors"
    TagPrefix="dxe" %>

<%@ Register Assembly="DevExpress.XtraCharts.v9.1.Web, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.XtraCharts.Web" TagPrefix="dxchartsui" %>
<%@ Register Assembly="DevExpress.XtraCharts.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.XtraCharts" TagPrefix="cc2" %>

<%--<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.1" Namespace="DevExpress.Web.ASPxEditors"
    TagPrefix="dxe" %>

<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v9.1" Namespace="DevExpress.Web.ASPxPivotGrid"
    TagPrefix="dxwpg" %>--%>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>

<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPivotGrid" TagPrefix="dxwpg" %>
<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v9.1.Export, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraPivotGrid.Web" TagPrefix="dxpgw" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register Assembly="DevExpress.Web.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dxp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="100">
                    <ProgressTemplate>
                        Cargando...
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/App_Themes/Office2003 Blue/Web/Loading.gif"></asp:Image>
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <dxpgw:ASPxPivotGridExporter id="ASPxPivotGridExporter1" runat="server" ASPxPivotGridID="ConsultaRegistros">
                </dxpgw:ASPxPivotGridExporter>
                <table class="style1">
                    <tbody>
                        <tr>
                            <td>
                                <dxe:ASPxComboBox id="listExportFormat" runat="server" ValueType="System.String" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" CssPostfix="Office2003_Blue" ImageFolder="~/App_Themes/Office2003 Blue/{0}/">
                                    <items>
                            <dxe:ListEditItem Text="Pdf" Value="0" />
                            <dxe:ListEditItem Text="Excel" Value="1" />
                            <dxe:ListEditItem Text="Mht" Value="2" />
                            <dxe:ListEditItem Text="Rtf" Value="3" />
                            <dxe:ListEditItem Text="Text" Value="4" />
                            <dxe:ListEditItem Text="Html" Value="5" />
                        </items>
                                    <buttonstyle width="13px">
        </buttonstyle>
                                </dxe:ASPxComboBox>
                            </td>
                            <td>
                                <dxe:ASPxButton id="ButtonOpen" onclick="ButtonOpen_Click" runat="server" Text="Abrir" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" CssPostfix="Office2003_Blue">
                                </dxe:ASPxButton>
                            </td>
                            <td style="width: 67px">
                                <dxe:ASPxButton id="ButtonSaveAs" onclick="ButtonSaveAs_Click" runat="server" Text="Guardar" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" CssPostfix="Office2003_Blue">
                                </dxe:ASPxButton>
                            </td>
                            <td>
                                <asp:Label id="ExceptionDetails" runat="server" Text="" Font-Size="10pt" ForeColor="Red"
                        Width="100%"></asp:Label>
                            </td>
                            <td style="width: 3px">&nbsp; </td>
                            <td style="width: 716px">Seleecione el año&nbsp;que&nbsp;desea&nbsp;consultar
                                <dxe:ASPxComboBox id="ASPxComboBox1" runat="server" DataSourceID="SqlDataSource1" ValueType="System.String" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" CssPostfix="Office2003_Blue" ImageFolder="~/App_Themes/Office2003 Blue/{0}/" AutoPostBack="True" OnSelectedIndexChanged="ASPxComboBox1_SelectedIndexChanged" ValueField="Expr1" TextField="Expr1" OnDataBound="ASPxComboBox1_DataBound">
                                    <buttonstyle width="13px">
</buttonstyle>
                                </dxe:ASPxComboBox>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnStrSQLServer %>" SelectCommand="SELECT DISTINCT YEAR(WFMovimientoFecha) AS Expr1 FROM WFMovimientos"></asp:SqlDataSource>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <dxwpg:ASPxPivotGrid id="ConsultaRegistros" runat="server" Width="800px" DataSourceID="AlfaWeb" EnableCallbackCompression="True">

                    <prefilter enabled="False"></prefilter>
                    <fields>
<dxwpg:PivotGridField FieldName="WFMovimientoFecha" ID="PivotGridField1" GroupIndex="0" InnerGroupIndex="1" Area="RowArea" AreaIndex="1" UnboundFieldName="fieldRadicadoFecha" Caption="F. Radicacion"></dxwpg:PivotGridField>
<dxwpg:PivotGridField FieldName="DependenciaNombre" ID="fieldActualmenteEn" GroupIndex="0" InnerGroupIndex="5" Area="RowArea" AreaIndex="5" Caption="Dep Actual"></dxwpg:PivotGridField>
<dxwpg:PivotGridField FieldName="NaturalezaNombre" ID="fieldRadicadoNaturaleza" GroupIndex="0" InnerGroupIndex="4" Area="RowArea" AreaIndex="4" Caption="Naturaleza"></dxwpg:PivotGridField>
<dxwpg:PivotGridField FieldName="RadicadoCodigo" ID="fieldRadicadoNumero" GroupIndex="0" InnerGroupIndex="0" Area="RowArea" AreaIndex="0" Caption="Radicado" SummaryType="Count"></dxwpg:PivotGridField>
<dxwpg:PivotGridField FieldName="RadicadoFechaVencimiento" ID="fieldRadicadoFechaVencimiento" GroupIndex="0" InnerGroupIndex="2" Area="RowArea" AreaIndex="2" GroupInterval="Date" UnboundFieldName="fieldRadicadoFechaVencimiento" Caption="F. Vencimiento"></dxwpg:PivotGridField>
<dxwpg:PivotGridField FieldName="MaxPaso" ID="fieldRadicadoMaxPaso" GroupIndex="0" InnerGroupIndex="7" Area="RowArea" AreaIndex="7" GroupInterval="DateYear" UnboundFieldName="fieldRadicadoMaxPaso" Caption="Paso Actual"></dxwpg:PivotGridField>
<dxwpg:PivotGridField FieldName="ProcedenciaNombre" ID="fieldRadicadoProcedencia" GroupIndex="0" InnerGroupIndex="3" Area="RowArea" AreaIndex="3" Caption="Procedencia"></dxwpg:PivotGridField>
<dxwpg:PivotGridField FieldName="RadicadoDetalle" ID="fieldRadicadoDetalle" GroupIndex="0" InnerGroupIndex="6" Area="RowArea" AreaIndex="6" Caption="Detalle"></dxwpg:PivotGridField>
<dxwpg:PivotGridField FieldName="SerieNombre" ID="fieldRespuestaTipo" GroupIndex="0" InnerGroupIndex="8" Area="RowArea" AreaIndex="8" Caption="Serie"></dxwpg:PivotGridField>
<dxwpg:PivotGridField FieldName="Respuesta" ID="fieldRespuestaNumero" Area="RowArea" AreaIndex="9" Caption="Respuesta"></dxwpg:PivotGridField>
<dxwpg:PivotGridField FieldName="FechaRespuesta" ID="field" Area="RowArea" AreaIndex="10" Caption="F. Respuesta"></dxwpg:PivotGridField>
<dxwpg:PivotGridField FieldName="DiasVencimiento" ID="fieldRespuestaDV" Area="RowArea" AreaIndex="11" Caption="DV."></dxwpg:PivotGridField>
</fields>

                    <styles csspostfix="Office2003_Blue" cssfilepath="~/App_Themes/Office2003 Blue/{0}/styles.css">
<CustomizationFieldsHeaderStyle>
<Paddings PaddingLeft="12px" PaddingRight="6px"></Paddings>
</CustomizationFieldsHeaderStyle>
</styles>

                    <optionsdata casesensitive="False"></optionsdata>

                    <optionsview dataheadersdisplaymode="Popup" showcontextmenus="False" showcolumntotals="False" showrowtotals="False" showcolumngrandtotals="False" showrowgrandtotals="False" showdataheaders="False" showfilterheaders="False" showcolumnheaders="False" showrowheaders="False" drawfocusedcellrect="False" showfilterseparatorbar="False"></optionsview>

                    <optionschartdatasource chartdatavertical="False" showcolumncustomtotals="False" showcolumngrandtotals="False" showcolumntotals="False" showrowcustomtotals="False" showrowgrandtotals="False" showrowtotals="False"></optionschartdatasource>

                    <images imagefolder="~/App_Themes/Office2003 Blue/{0}/">
<FieldValueCollapsed Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/PivotGrid/pgCollapsedButton.png"></FieldValueCollapsed>

<FieldValueExpanded Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/PivotGrid/pgExpandedButton.png"></FieldValueExpanded>

<HeaderSortDown Height="8px" Width="7px" Url="~/App_Themes/Office2003 Blue/PivotGrid/pgHeaderSortDown.png"></HeaderSortDown>

<HeaderSortUp Height="8px" Width="7px" Url="~/App_Themes/Office2003 Blue/PivotGrid/pgHeaderSortUp.png"></HeaderSortUp>

<SortByColumn Height="7px" Width="11px" Url="~/App_Themes/Office2003 Blue/PivotGrid/pgSortByColumn.png"></SortByColumn>
</images>
                    <groups>
<dxwpg:PivotGridWebGroup></dxwpg:PivotGridWebGroup>
</groups>

                    <optionscustomization allowdrag="False" allowexpand="False" allowsortbysummary="False"></optionscustomization>

                    <optionspager>
<Summary AllPagesText="Paginas: {0} - {1} ({2} Documentos pendientes)" Text="Pagina {0} of {1} ({2} Documentos pendientes)"></Summary>
</optionspager>
                </dxwpg:ASPxPivotGrid>
                <asp:SqlDataSource ID="AlfaWeb" runat="server" ConnectionString="<%$ ConnectionStrings:ConnStrSQLServer %>" SelectCommand="Radicado_ReadRadicadoInformeGestion" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:Parameter DbType="DateTime" DefaultValue="01/01/2010" Name="WFMovimientoFecha"></asp:Parameter>
                        <asp:Parameter DbType="DateTime" DefaultValue="01/01/2011" Name="WFMovimientoFecha1"></asp:Parameter>
                    </SelectParameters>
                </asp:SqlDataSource>
            </ContentTemplate>

            <Triggers>
                <asp:PostBackTrigger ControlID="ButtonOpen"></asp:PostBackTrigger>
                <asp:PostBackTrigger ControlID="ButtonSaveAs"></asp:PostBackTrigger>
                <asp:AsyncPostBackTrigger ControlID="ASPxComboBox1" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
            </Triggers>

        </asp:UpdatePanel>

    </div>

</asp:Content>

