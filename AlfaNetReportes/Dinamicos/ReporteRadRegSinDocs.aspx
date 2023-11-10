<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="ReporteRadRegSinDocs.aspx.cs" Inherits="ReporteRadRegSinDocs" Title="Reporte de Radicados y Registros sin documentos asociados" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.1" Namespace="DevExpress.Web.ASPxGridView"
    TagPrefix="dxwgv" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.1" Namespace="DevExpress.Web.ASPxEditors"
    TagPrefix="dxe" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.1.Export, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView.Export" TagPrefix="dxwgv" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>

<%@ Register Assembly="DevExpress.XtraCharts.v9.1.Web, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.XtraCharts.Web" TagPrefix="dxchartsui" %>
<%@ Register Assembly="DevExpress.XtraCharts.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.XtraCharts" TagPrefix="cc2" %>

<%--<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.1" Namespace="DevExpress.Web.ASPxEditors"
    TagPrefix="dxe" %>

<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v9.1" Namespace="DevExpress.Web.ASPxPivotGrid"
    TagPrefix="dxwpg" %>--%>

<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPivotGrid" TagPrefix="dxwpg" %>
<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v9.1.Export, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraPivotGrid.Web" TagPrefix="dxpgw" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register Assembly="DevExpress.Web.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dxp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1"
        DisplayAfter="100">
        <ProgressTemplate>
            Loading...
        </ProgressTemplate>
    </asp:UpdateProgress>
    <div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table class="style1">
                    <tbody>
                        <tr>
                            <td>
                                <dxe:ASPxComboBox id="listExportFormat" runat="server" ValueType="System.String" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" CssPostfix="Office2003_Blue" ImageFolder="~/App_Themes/Office2003 Blue/{0}/">
                                    <items>
<dxe:ListEditItem Text="Pdf" Value="0"></dxe:ListEditItem>
<dxe:ListEditItem Text="Excel" Value="1"></dxe:ListEditItem>
<dxe:ListEditItem Text="Rtf" Value="2"></dxe:ListEditItem>
<dxe:ListEditItem Text="Csv" Value="3"></dxe:ListEditItem>
</items>

                                    <buttonstyle width="13px"></buttonstyle>
                                </dxe:ASPxComboBox>
                            </td>
                            <td>
                                <dxe:ASPxButton id="ButtonOpen" onclick="ButtonOpen_Click" runat="server" Text="Abrir" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" CssPostfix="Office2003_Blue">
                                </dxe:ASPxButton>
                            </td>
                            <td>
                                <dxe:ASPxButton id="ButtonSaveAs" onclick="ButtonSaveAs_Click" runat="server" Text="Guardar" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" CssPostfix="Office2003_Blue">
                                </dxe:ASPxButton>
                            </td>
                            <td>
                                 <asp:Label id="ExceptionDetails" runat="server" Text="" Font-Size="10pt" ForeColor="Red"   Width="100%"></asp:Label>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <dxwgv:ASPxGridViewExporter id="ASPxGridViewExporter1" runat="server"></dxwgv:ASPxGridViewExporter>

                &nbsp;
                <table style="width: 100%">
                    <tr>
                        <td style="width: 20%"></td>
                        <td>
                            <table style="width: 100%">
                                <tr>
                                    <td style="width: 100px; height: 36px">
                                        <asp:Label ID="Label1" runat="server" Text="Fecha Inicial:" Width="73px"></asp:Label></td>
                                    <td style="width: 100px; height: 36px">
                                        <telerik:RadDatePicker ID="RadDatePicker1" runat="server" Skin="Outlook">
                                            <calendar skin="Outlook" usecolumnheadersasselectors="False" userowheadersasselectors="False"
                                                viewselectortext="x">
                                </calendar>
                                            <datepopupbutton hoverimageurl="" imageurl="" />
                                            <DateInput DateFormat="yyyy/MM/dd" DisplayDateFormat="yyyy/MM/dd">
                                </dateinput>
                                        </telerik:RadDatePicker>
                                    </td>
                                    <td style="width: 100px; height: 36px">
                                        <asp:Label ID="Label2" runat="server" Text="Fecha Final:" Width="74px"></asp:Label></td>
                                    <td style="width: 100px; height: 36px">
                                        <telerik:RadDatePicker ID="RadDatePicker2" runat="server" Skin="Outlook">
                                            <calendar skin="Outlook" usecolumnheadersasselectors="False" userowheadersasselectors="False"
                                                viewselectortext="x">
                                </calendar>
                                            <datepopupbutton hoverimageurl="" imageurl="" />
                                            <DateInput DateFormat="yyyy/MM/dd" DisplayDateFormat="yyyy/MM/dd">
                                </dateinput>
                                        </telerik:RadDatePicker>
                                    </td>
                                    <td style="width: 1014px; height: 36px">
                                        <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Buscar:"></asp:Label></td>
                                    <td style="width: 1332px; height: 36px">
                                        <asp:ImageButton ID="ImageButton2" runat="server" Height="34px" ImageUrl="~/AlfaNetImagen/ToolBar/buscarnew2.gif"
                                            Width="35px" OnClick="ImageButton2_Click" /></td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 20%"></td>
                    </tr>
                </table>

                <asp:CheckBox ID="CheckBox1" runat="server" Width="343px" Visible="False" Text="Intercambiar Filas y Columnas en Grafica" OnCheckedChanged="CheckBox1_CheckedChanged" AutoPostBack="True"></asp:CheckBox>
                <dxwgv:ASPxGridView id="ASPxGridView1" runat="server" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" CssPostfix="Office2003_Blue" AutoGenerateColumns="False" DataSourceID="ODSRadYRegSinDoc">
                    <styles csspostfix="Office2003_Blue" cssfilepath="~/App_Themes/Office2003 Blue/{0}/styles.css">
<Header SortingImageSpacing="5px" ImageSpacing="5px"></Header>

<LoadingPanel ImageSpacing="10px"></LoadingPanel>
</styles>

                    <settingsloadingpanel text="Cargando&amp;hellip;" showimage="False"></settingsloadingpanel>

                    <settingspager showseparators="True">
<Summary AllPagesText="Paginas: {0} - {1} ({2} Registros)" Text="Pagina {0} de {1} ({2} Registros)"></Summary>
</settingspager>

                    <imagesfiltercontrol>
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
</imagesfiltercontrol>
                    <totalsummary>
<dxwgv:ASPxSummaryItem SummaryType="Count" FieldName="RegistroCodigo" DisplayFormat="Total" ShowInColumn="Registro" ShowInGroupFooterColumn="Registro" Tag="Total"></dxwgv:ASPxSummaryItem>
</totalsummary>

                    <images imagefolder="~/App_Themes/Office2003 Blue/{0}/">
<CollapsedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvCollapsedButton.png"></CollapsedButton>

<ExpandedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvExpandedButton.png"></ExpandedButton>

<DetailCollapsedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvCollapsedButton.png"></DetailCollapsedButton>

<DetailExpandedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvExpandedButton.png"></DetailExpandedButton>

<FilterRowButton Height="13px" Width="13px"></FilterRowButton>
</images>

                    <settingstext title="Medio" grouppanel="Coloque la Columna por la que desea agrugar" confirmdelete="Confirmar Eliminar" popupeditformcaption="Editar Formulario" emptyheaders="Encabezados Vacios" groupcontinuedonnextpage="Grupo Continua En la Siguiente Pagina" emptydatarow="No se han Encontrado registros que Cumplan con este Criterio" commandedit="Editar" commandnew="Nuevo" commanddelete="Eliminar" commandselect="Seleccionar" commandcancel="Cancelar" commandupdate="Actualizar" commandclearfilter="Borrar Filtro" headerfiltershowall="Mostrar todos los Encabezados de Filtro" filtercontrolpopupcaption="Filtro Aplicado" filterbarclear="Limpiar Barra de Filtro" filterbarcreatefilter="Crear Filtro"></settingstext>
                    <columns>
<dxwgv:GridViewDataTextColumn FieldName="DocumentoNumero" ReadOnly="True" VisibleIndex="0"></dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="GrupoCodigo" ReadOnly="True" VisibleIndex="1"></dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="Grupo" ReadOnly="True" VisibleIndex="2"></dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataDateColumn FieldName="Fecha" ReadOnly="True" VisibleIndex="3"></dxwgv:GridViewDataDateColumn>
<dxwgv:GridViewDataTextColumn FieldName="Radicador" ReadOnly="True" VisibleIndex="4"><Settings AutoFilterCondition="Contains" /></dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="Naturaleza" ReadOnly="True" VisibleIndex="5"></dxwgv:GridViewDataTextColumn>
</columns>

                    <settings showfilterrow="True" showgrouppanel="True" showfilterbar="Visible"></settings>

                    <styleseditors>
<ProgressBar Height="25px"></ProgressBar>
</styleseditors>
                </dxwgv:ASPxGridView>
                <asp:ObjectDataSource ID="ODSRadYRegSinDoc" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetData_RadicYRegistSinDocs" TypeName="DSReportesTableAdapters.Reporte_RadicYRegist_SinDocumentoAsociadosTableAdapter"></asp:ObjectDataSource>
                <asp:SqlDataSource ID="AlfaWeb" runat="server" SelectCommand="Reporte_RadicYRegist_SinDocumentoAsociadosDinamico" ConnectionString="<%$ ConnectionStrings:ConnStrSQLServer %>" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="RadDatePicker1" DbType="DateTime" DefaultValue="2011/01/01"
                            Name="WFMovimientoFecha" PropertyName="SelectedDate" />
                        <asp:ControlParameter ControlID="RadDatePicker2" DbType="DateTime" DefaultValue="2011/12/31"
                            Name="WFMovimientoFecha1" PropertyName="SelectedDate" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </ContentTemplate>

            <Triggers>
                <asp:PostBackTrigger ControlID="ButtonOpen"></asp:PostBackTrigger>
                <asp:PostBackTrigger ControlID="ButtonSaveAs"></asp:PostBackTrigger>
            </Triggers>

        </asp:UpdatePanel>
        <br />

    </div>

</asp:Content>

