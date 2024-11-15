﻿<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true"  CodeFile="MaestroWorkFlowAccion.aspx.cs" Inherits="_MaestroWorkFlowAccion" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebNavigator.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebNavigator" TagPrefix="ignav" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
<TABLE style="WIDTH: 100%"><TBODY><TR>
    <td style="width: 30%">
    </td>
    <TD 
style="WIDTH: 40%;"><asp:UpdatePanel id="UpdatePanel4" runat="server"><ContentTemplate>
<ajax:autocompleteextender id="AutoCompleteDepartamento" runat="server" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListItemCssClass="autocomplete_listItem" CompletionListCssClass="autocomplete_completionListElement" targetcontrolid="TxtGrupo" servicepath="../../AutoComplete.asmx" servicemethod="GetWFAccionTextByTextnull" minimumprefixlength="0" enablecaching="true" completionsetcount="12" completioninterval="1000"></ajax:autocompleteextender> <Ajax:TextBoxWatermarkExtender id="TxtBoxWatermarkDepartamento" watermarkText="Seleccione un WFAccion ..." runat="server" TargetControlID="TxtGrupo"></Ajax:TextBoxWatermarkExtender> &nbsp;
    <table style="width: 100%">
        <tr>
            <td>
            </td>
            <td style="width: 84%">
                <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ControlToValidate="TxtGrupo" ErrorMessage="RequiredFieldValidator" SetFocusOnError="True" ValidationGroup="ValGroup1">*</asp:RequiredFieldValidator><asp:Label id="LblGrupo" runat="server" Width="60px" Text="Accion" Font-Bold="False" CssClass="PropLabels"></asp:Label><asp:TextBox id="TxtGrupo" runat="server" CssClass="TxtAutoComplete"></asp:TextBox><asp:ImageButton id="ImageButton2" onclick="ImgBtnFind_Click" runat="server" ToolTip="Buscar" ImageUrl="~/AlfaNetImagen/ToolBar/zoom.png" ValidationGroup="ValGroup1"></asp:ImageButton>
            </td>
            <td style="width: 3%">
            </td>
        </tr>
    </table>
    <br />
    <table style="width: 100%">
        <tr>
            <td style="width: 30%">
            </td>
            <td style="width: 40%">
                <TABLE style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none" border=0><TBODY><TR><TD style="WIDTH: 57px; HEIGHT: 8px"><STRONG><EM><SPAN style="FONT-FAMILY: Poor Richard"></SPAN></EM></STRONG><asp:Label id="LblFindBy" runat="server" Width="67px" ForeColor="RoyalBlue" Text="Buscar Por: " Font-Size="Smaller" Font-Bold="True" BorderStyle="None"></asp:Label></TD><TD style="VERTICAL-ALIGN: middle; WIDTH: 115px; HEIGHT: 8px; TEXT-ALIGN: center"><asp:RadioButtonList id="RadBtnLstFindby" runat="server" Width="106px" ForeColor="RoyalBlue" Font-Size="Smaller" AutoPostBack="True" OnSelectedIndexChanged="RadBtnLstFindby_SelectedIndexChanged" Font-Italic="False" RepeatDirection="Horizontal"><asp:ListItem Selected="True" Value="1">Nombre</asp:ListItem>
<asp:ListItem Value="2">Codigo</asp:ListItem>
</asp:RadioButtonList></TD></TR></TBODY></TABLE>
            </td>
            <td style="width: 30%">
            </td>
        </tr>
    </table>
    <asp:HiddenField id="HFCodigoSeleccionado" runat="server"></asp:HiddenField> <Ajax:TabContainer style="TEXT-ALIGN: left" id="TCGrupo" runat="server" Width="500px" BackColor="White" AutoPostBack="True" ActiveTabIndex="0" OnActiveTabChanged="TCGrupo_ActiveTabChanged"><Ajax:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1"><HeaderTemplate>
                                <img src="../../AlfaNetImagen/ToolBar/user_edit.png"  />
                            
</HeaderTemplate>
<ContentTemplate>
<DIV align=center><asp:DetailsView style="VERTICAL-ALIGN: middle; TEXT-ALIGN: left" id="DVGrupo" runat="server" Width="460px" DataSourceID="GrupoByIdDataSource" ForeColor="#333333" Height="31px" OnItemUpdated="DVDepartamento_ItemUpdated" OnItemInserted="DVDepartamento_ItemInserted" OnItemDeleted="DVDepartamento_ItemDeleted" OnDataBound="DVDepartamento_DataBound" GridLines="None" DataKeyNames="WFAccionCodigo" CellPadding="4" AutoGenerateRows="False">
<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>

<CommandRowStyle BackColor="#D1DDF1" Font-Bold="True"></CommandRowStyle>

<EditRowStyle BackColor="#2461BF"></EditRowStyle>

<FieldHeaderStyle BackColor="#DEE8F5" Font-Bold="True"></FieldHeaderStyle>
<Fields>
<asp:TemplateField HeaderText="Codigo Accion" SortExpression="WFAccionCodigo"><EditItemTemplate>
<asp:Label id="Label1" runat="server" Text='<%# Eval("WFAccionCodigo") %>'></asp:Label> 
</EditItemTemplate>
<InsertItemTemplate>
<table><tr><td>
<asp:TextBox id="TextBox1" runat="server" Text='<%# Bind("WFAccionCodigo") %>'></asp:TextBox> <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Debe ingresar un codigo para la accion">*</asp:RequiredFieldValidator> 
   </td><td> <asp:FormView ID="FVAutoNum" runat="server" DataSourceID="SqlDataSource1">
        <ItemTemplate>
            <asp:TextBox ID="TxCons" runat="server" Text='<%# Eval("Consecutivo") %>' Visible="False"
                Width="13px"></asp:TextBox>
            <asp:CheckBox ID="CkAuto" runat="server" AutoPostBack="true" OnCheckedChanged="CheckBox2_CheckedChanged1"
                Text="Auto" Visible="true" />
        </ItemTemplate>
    </asp:FormView>
    </td></tr></table>
</InsertItemTemplate>
<ItemTemplate>
<asp:Label id="Label1" runat="server" Text='<%# Bind("WFAccionCodigo") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Accion" SortExpression="WFAccionNombre"><EditItemTemplate>
<asp:Label id="Label3" runat="server" Text='<%# Bind("WFAccionNombre") %>'></asp:Label> <asp:Label id="Label13" runat="server" ForeColor="White" Text="Accion Asociada"></asp:Label> <asp:TextBox id="TextBox1" runat="server" Text='<%# Bind("WFAccionNombre") %>' CssClass="TxtMaestro"></asp:TextBox> <asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox1" ErrorMessage="Debe ingresar un nombre para la accion">*</asp:RequiredFieldValidator> 
</EditItemTemplate>
<InsertItemTemplate>
<asp:TextBox id="TextBox3" runat="server" Text='<%# Bind("WFAccionNombre") %>' CssClass="TxtMaestro"></asp:TextBox> <asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3" ErrorMessage="Debe ingresar un nombre para la accion">*</asp:RequiredFieldValidator> 
</InsertItemTemplate>
<ItemTemplate>
<asp:Label id="Label3" runat="server" Text='<%# Bind("WFAccionNombre") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Habilitar/DesHabilitar" SortExpression="WFAccionHabilitar"><EditItemTemplate>
<asp:TextBox id="TextBox2" runat="server" Width="13px" Text='<%# Bind("WFAccionHabilitar") %>' Visible="False"></asp:TextBox> <asp:CheckBox id="CheckBox1" runat="server"></asp:CheckBox> 
</EditItemTemplate>
<InsertItemTemplate>
<asp:TextBox id="TextBox2" runat="server" Width="11px" Text='<%# Bind("WFAccionHabilitar") %>' Visible="False"></asp:TextBox> <asp:CheckBox id="CheckBox1" runat="server"></asp:CheckBox> 
</InsertItemTemplate>
<ItemTemplate>
<asp:Label id="Label2" runat="server" Text='<%# Bind("WFAccionHabilitar") %>' Visible="False"></asp:Label> <asp:CheckBox id="CheckBox1" runat="server" Enabled="False"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField ShowHeader="False"><EditItemTemplate>
<asp:ImageButton id="ImageButton5" onclick="ImgBtnUpdateActualizar_Click" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Accept.png" CommandName="Update"></asp:ImageButton>&nbsp;&nbsp;<asp:ImageButton id="ImageButton4" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Cancel.png" CommandName="Cancel" CausesValidation="False"></asp:ImageButton>&nbsp; 
</EditItemTemplate>
<InsertItemTemplate>
<asp:ImageButton id="ImgBtnInsert" onclick="ImgBtnInsert_Click" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Accept.png" CommandName="Insert"></asp:ImageButton>&nbsp;&nbsp;<asp:ImageButton id="ImageButton7" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Cancel.png" CommandName="Cancel" CausesValidation="False"></asp:ImageButton>&nbsp; 
</InsertItemTemplate>
<ItemTemplate>
<asp:ImageButton id="ImageButton1" onclick="ImgBtnEdit_Click" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Edit.png" CommandName="Edit" CausesValidation="False"></asp:ImageButton>&nbsp;&nbsp;<asp:ImageButton id="ImgBtnNew" onclick="ImgBtnNew_Click" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Add.png" CommandName="New" CausesValidation="False"></asp:ImageButton>&nbsp;&nbsp;<asp:ImageButton id="ImgBtnDelete" onclick="ImgBtnDelete_Click" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Delete.png" CausesValidation="False"></asp:ImageButton>&nbsp; 
</ItemTemplate>
</asp:TemplateField>
</Fields>

<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<RowStyle BackColor="#EFF3FB"></RowStyle>
</asp:DetailsView> <TABLE style="WIDTH: 100%; HEIGHT: 100%"><TBODY><TR><TD style="TEXT-ALIGN: left"><asp:ValidationSummary id="ValidationSummary1" runat="server" Width="100%"></asp:ValidationSummary> </TD></TR></TBODY></TABLE>&nbsp;&nbsp;</DIV>
</ContentTemplate>
</Ajax:TabPanel>
<Ajax:TabPanel runat="server" HeaderText="TabPanel2" ID="TabPanel2"><HeaderTemplate>
<IMG style="VISIBILITY: hidden" src="../../AlfaNetImagen/ToolBar/lock_edit.png"  /> 
</HeaderTemplate>
<ContentTemplate>
<STRONG>De forma predeterminada a todas las dependencias se les:<BR /></STRONG><TABLE style="FONT-WEIGHT: bold"><TBODY><TR><TD><BR /><IMG src="../../AlfaNetImagen/ToolBar/lock.png" /><BR /><BR /><IMG src="../../AlfaNetImagen/ToolBar/key.png" /><BR /></TD><TD style="WIDTH: 16px"><BR /><asp:RadioButtonList style="TEXT-ALIGN: left" id="RbtnLstPermiso" runat="server" Width="245px" ForeColor="Black" Font-Bold="False" CssClass="DVRbtnLstStyle" AutoPostBack="True" OnSelectedIndexChanged="RbtnLstPermiso_SelectedIndexChanged" Height="52px" Enabled="False"><asp:ListItem Selected="True" Value="0">Denegar&#225; acceso a la consulta</asp:ListItem>
<asp:ListItem Value="1">Permitir&#225; acceso a la consulta</asp:ListItem>
</asp:RadioButtonList> </TD></TR></TBODY></TABLE>
</ContentTemplate>
</Ajax:TabPanel>
</Ajax:TabContainer><Ajax:ModalPopupExtender id="MPEMensaje" runat="server" TargetControlID="LblGrupo" BackgroundCssClass="MessageStyle" PopupControlID="PnlMensaje"></Ajax:ModalPopupExtender> <asp:Panel style="DISPLAY: none" id="PnlMensaje" runat="server" Width="125px" Height="63px"><BR /><TABLE width=275 border=0><TBODY><TR><TD style="BACKGROUND-COLOR: activecaption" align=center><asp:Label id="Label5" runat="server" Width="120px" ForeColor="White" Text="Mensaje" Font-Size="14pt" Font-Bold="False"></asp:Label></TD><TD style="WIDTH: 12%; BACKGROUND-COLOR: activecaption"><asp:ImageButton style="VERTICAL-ALIGN: top" id="btnCerrar" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/cross.png" ImageAlign="Right" CausesValidation="False"></asp:ImageButton> </TD></TR><TR><TD style="HEIGHT: 45px; BACKGROUND-COLOR: highlighttext" align=center colSpan=2><BR /><IMG src="../../AlfaNetImagen/ToolBar/error.png" />&nbsp; &nbsp;<asp:Label id="LblMessageBox" runat="server" ForeColor="Red" Font-Size="12pt"></asp:Label><BR /></TD></TR></TBODY></TABLE></asp:Panel> 
    <br />
    <asp:Panel ID="Panel1" runat="server" Height="63px" Style="display: none" Width="125px">
        <br />
        <table border="0" width="275">
            <tbody>
                <tr>
                    <td align="center" style="background-color: activecaption">
                        <asp:Label ID="Label6" runat="server" Font-Bold="False" Font-Size="14pt" ForeColor="White"
                            Text="Mensaje" Width="120px"></asp:Label></td>
                    <td style="width: 12%; background-color: activecaption">
                        <asp:ImageButton ID="ImageButton3" runat="server" CausesValidation="False" ImageAlign="Right"
                            ImageUrl="~/AlfaNetImagen/ToolBar/cross.png" Style="vertical-align: top" />
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2" style="height: 45px; background-color: highlighttext">
                        <br />
                        <img src="../../AlfaNetImagen/ToolBar/error.png" />
                        &nbsp;&nbsp;
                        <asp:Label ID="Label7" runat="server" Font-Size="12pt" ForeColor="Red"></asp:Label>
                        &nbsp; &nbsp;<br />
                        <br />
                        &nbsp;
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Aceptar" />
                        &nbsp;&nbsp;
                        <asp:Button ID="Button2" runat="server" Text="Cancelar" /><br />
                        <br />
                    </td>
                </tr>
            </tbody>
        </table>
    </asp:Panel>
    <br />
    <Ajax:ModalPopupExtender ID="MPEPregunta" runat="server" BackgroundCssClass="MessageStyle"
        CancelControlID="Button2" OkControlID="Button1" PopupControlID="Panel1" TargetControlID="Button1">
    </Ajax:ModalPopupExtender>
    <Ajax:ConfirmButtonExtender ID="cbe" runat="server" ConfirmText="Are you sure you want to click this?"
        DisplayModalPopupID="MPEPregunta" OnClientCancel="cancelClick" TargetControlID="Button1">
    </Ajax:ConfirmButtonExtender>
    <asp:UpdateProgress id="UpdateProgress1" runat="server">
                        <progresstemplate>
<IMG style="VERTICAL-ALIGN: middle; TEXT-ALIGN: center" src="../../AlfaNetImagen/WFImagen/Load.gif"  />
</progresstemplate>
                    </asp:UpdateProgress> 
</ContentTemplate>
</asp:UpdatePanel> </TD>
    <td style="width: 30%">
    </td>
</TR></TBODY></TABLE>
   
        <asp:ObjectDataSource ID="GrupoByIdDataSource" runat="server" DeleteMethod="Delete"
            InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetWFAccionBy"
            TypeName="DSAccionTableAdapters.WFAccion_ReadWFAccionTableAdapter" UpdateMethod="Update">
            <SelectParameters>
                <asp:ControlParameter ControlID="HFCodigoSeleccionado" Name="WFAccionCodigo" PropertyName="Value"
                    Type="String" />
            </SelectParameters>
            <DeleteParameters>
                <asp:Parameter Name="Original_WFAccionCodigo" Type="String" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="WFAccionNombre" Type="String" />
                <asp:Parameter Name="WFAccionHabilitar" Type="String" />
                <asp:Parameter Name="Original_WFAccionCodigo" Type="String" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="WFAccionCodigo" Type="String" />
                <asp:Parameter Name="WFAccionNombre" Type="String" />
                <asp:Parameter Name="WFAccionHabilitar" Type="String" />
            </InsertParameters>
        </asp:ObjectDataSource>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnStrSQLServer %>"
        SelectCommand="SELECT MAX(CONVERT (bigint, dbo.UDF_ParseAlphaChars(WFAccionCodigo)) + 1) AS Consecutivo FROM WFAccion">
    </asp:SqlDataSource>
              
</asp:Content>

