<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="MaestroTipologia.aspx.cs" Inherits="AlfaNetAdministracion_AdminMaestros_MaestroTipologia" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %> 
<%@ Register Assembly="Infragistics2.WebUI.UltraWebNavigator.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"     Namespace="Infragistics.WebUI.UltraWebNavigator" TagPrefix="ignav" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="WIDTH: 100%">
        <tbody>
            <tr>
                <td style="width: 30%">
                </td>
                <td style="WIDTH: 40%;">
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                        <ContentTemplate>
                            <ajax:autocompleteextender id="AutoCompleteDepartamento" runat="server" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListItemCssClass="autocomplete_listItem" CompletionListCssClass="autocomplete_completionListElement" targetcontrolid="TxtTipologia" servicepath="../../AutoComplete.asmx" servicemethod="GetTipologiaTextByTextnull" minimumprefixlength="0" enablecaching="true" completionsetcount="12" completioninterval="1000">
                            </ajax:autocompleteextender>
                            <Ajax:TextBoxWatermarkExtender id="TxtBoxWatermarkDepartamento" watermarkText="Seleccione una Tipologia ..." runat="server" TargetControlID="TxtTipologia">
                            </Ajax:TextBoxWatermarkExtender>
                            &nbsp;
                            <table style="width: 100%">
                                <tr>
                                    <td>
                                    </td>
                                    <td style="width: 84%">
                                        <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ControlToValidate="TxtTipologia" ErrorMessage="RequiredFieldValidator" SetFocusOnError="True" ValidationGroup="ValGroup1">*</asp:RequiredFieldValidator>
                                        <asp:label id="LblTipologia" runat="server" Width="60px" Text="Tipologia" Font-Bold="False" CssClass="PropLabels">
                                        </asp:label>
                                        <asp:TextBox id="TxtTipologia" runat="server" CssClass="TxtAutoComplete">
                                        </asp:TextBox>
                                        <asp:ImageButton id="ImageButton2" onclick="ImgBtnFind_Click" runat="server" ToolTip="Buscar" ImageUrl="~/AlfaNetImagen/ToolBar/zoom.png" ValidationGroup="ValGroup1" />
                                    </td>
                                    <td style="width: 3%; height: 27px;">
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <table style="width: 100%">
                                <tr>
                                    <td style="width: 30%">
                                    </td>
                                    <td style="width: 40%">
                                        <table style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none" border=0>
                                            <tbody>
                                                <tr>
                                                <td style="WIDTH: 57px; HEIGHT: 8px">
                                                <STRONG><EM><SPAN style="FONT-FAMILY: Poor Richard"></SPAN></EM></STRONG>
                                                    <asp:Label id="LblFindBy" runat="server" Width="67px" ForeColor="RoyalBlue" Text="Buscar Por: " Font-Size="Smaller" Font-Bold="True" BorderStyle="None">
                                                    </asp:Label>
                                                </td>
                                                <td style="VERTICAL-ALIGN: middle; WIDTH: 115px; HEIGHT: 8px; TEXT-ALIGN: center">
                                                    <asp:RadioButtonList id="RadBtnLstFindby" runat="server" Width="106px" ForeColor="RoyalBlue" Font-Size="Smaller" AutoPostBack="True" OnSelectedIndexChanged="RadBtnLstFindby_SelectedIndexChanged" Font-Italic="False" RepeatDirection="Horizontal">
                                                        <asp:ListItem Selected="True" Value="1">
                                                            Nombre
                                                        </asp:ListItem>
                                                        <asp:ListItem Selected="True" Value="2">
                                                            Codigo
                                                        </asp:ListItem>
                                                    </asp:RadioButtonList>                                                    
                                                </td>
                                                </tr>
                                            </tbody>
                                        </table>  
                                    </td>
                                    <td style="width: 30%">
                                    </td>
                                </tr>
                            </table>
                            <asp:HiddenField id="HFCodigoSeleccionado" runat="server"/>
                            <Ajax:TabContainer style="TEXT-ALIGN: left" id="TCTipologia" runat="server" Width="500px" BackColor="White" AutoPostBack="True" ActiveTabIndex="0" OnActiveTabChanged="TCGrupo_ActiveTabChanged">
                                <Ajax:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                                    <HeaderTemplate>
                                        <img src="../../AlfaNetImagen/ToolBar/user_edit.png"/>
                                    </HeaderTemplate>
                                    <ContentTemplate>
                                    <div>
                                        <asp:DetailsView style="VERTICAL-ALIGN: middle; TEXT-ALIGN: left" id="DVTipologia" runat="server" Width="460px" DataSourceID="GrupoByIdDataSource" ForeColor="#333333" Height="31px" OnItemUpdated="DVDepartamento_ItemUpdated" OnItemInserted="DVDepartamento_ItemInserted" OnItemDeleted="DVDepartamento_ItemDeleted" OnDataBound="DVDepartamento_DataBound" GridLines="None" DataKeyNames="TipologiaCodigo" CellPadding="4" AutoGenerateRows="False" EnableModelValidation="True">
                                            <AlternatingRowStyle BackColor="White"/>
                                            <CommandRowStyle BackColor="#D1DDF1" Font-Bold="True"/>
                                            <EditRowStyle BackColor="#2461BF"/>
                                            <FieldHeaderStyle BackColor="#DEE8F5" Font-Bold="True"/>
                                            <Fields>
                                                <asp:TemplateField HeaderText="Codigo Tipologia" SortExpression="TipologiaCodigo">
                                                    <EditItemTemplate>
                                                        <asp:Label id="Label1" runat="server" Text='<%# Eval("TipologiaCodigo") %>'>
                                                        </asp:Label>
                                                    </EditItemTemplate>
                                                    <InsertItemTemplate>
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:TextBox id="TextBox1" runat="server" Text='<%# Bind("TipologiaCodigo") %>'>
                                                                    </asp:TextBox>
                                                                    <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Debe ingresar un codigo para la Tipologia">*</asp:RequiredFieldValidator>
                                                                </td>
                                                                <td>
                                                                    <asp:FormView ID="FVAutoNum" runat="server" DataSourceID="SqlDataSource1">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="TxCons" runat="server" Text='<%# Eval("Consecutivo") %>' Visible="False" Width="13px">
                                                                            </asp:TextBox>
                                                                            <asp:CheckBox ID="CkAuto" runat="server" AutoPostBack="true" OnCheckedChanged="CheckBox2_CheckedChanged1" Text="Auto" Visible="true"/>
                                                                        </ItemTemplate>
                                                                    </asp:FormView>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </InsertItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label id="Label1" runat="server" Text='<%# Bind("TipologiaCodigo") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Nombre Tipologia" SortExpression="TipologiaNombre">
                                                    <EditItemTemplate>
                                                        <asp:Label id="Label3" runat="server" Text='<%# Eval("TipologiaNombre") %>'>
                                                        </asp:Label>
                                                        <asp:Label id="Label13" runat="server" ForeColor="White" Text="Tipologia Asociada">
                                                        </asp:Label>
                                                        <asp:TextBox id="TextBox1" runat="server" Text='<%# Bind("TipologiaNombre") %>' CssClass="TxtMaestro">
                                                        </asp:TextBox>
                                                        <asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox1" ErrorMessage="Debe ingresar un nombre para la Tipologia">*</asp:RequiredFieldValidator>
                                                    </EditItemTemplate>
                                                    <InsertItemTemplate>                                                
                                                        <asp:TextBox id="TextBox3" runat="server" Text='<%# Bind("TipologiaNombre") %>' CssClass="TxtMaestro">
                                                        </asp:TextBox>
                                                        <asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3" ErrorMessage="Debe ingresar un nombre para la Tipologia">*</asp:RequiredFieldValidator>
                                                    </InsertItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label id="Label3" runat="server" Text='<%# Bind("TipologiaNombre") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Habilitar/DesHabilitar" SortExpression="TipologiaHabilitar">
                                                    <EditItemTemplate>
                                                        <asp:TextBox id="TextBox2" runat="server" Width="13px" Text='<%# Bind("TipologiaHabilitar") %>' Visible="False">
                                                        </asp:TextBox>
                                                        <asp:CheckBox id="CheckBox1" runat="server">
                                                        </asp:CheckBox>
                                                    </EditItemTemplate>
                                                    <InsertItemTemplate>
                                                        <asp:TextBox id="TextBox2" runat="server" Width="11px" Text='<%# Bind("TipologiaHabilitar") %>' Visible="False">
                                                        </asp:TextBox>
                                                        <asp:CheckBox id="CheckBox1" runat="server">
                                                        </asp:CheckBox>
                                                    </InsertItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label id="Label2" runat="server" Text='<%# Bind("TipologiaHabilitar") %>' Visible="False">
                                                        </asp:Label>
                                                        <asp:CheckBox id="CheckBox1" runat="server" Enabled="False">
                                                        </asp:CheckBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ShowHeader="False">
                                                    <EditItemTemplate>
                                                        <asp:ImageButton id="ImageButton5" onclick="ImgBtnUpdateActualizar_Click" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Accept.png" CommandName="Update">
                                                        </asp:ImageButton>
                                                        &nbsp;&nbsp;
                                                        <asp:ImageButton id="ImageButton4" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Cancel.png" CommandName="Cancel" CausesValidation="False">
                                                        </asp:ImageButton>
                                                        &nbsp;
                                                    </EditItemTemplate>
                                                    <InsertItemTemplate>
                                                        <asp:ImageButton id="ImgBtnInsert" onclick="ImgBtnInsert_Click" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Accept.png" CommandName="Insert">
                                                        </asp:ImageButton>
                                                        &nbsp;&nbsp;
                                                        <asp:ImageButton id="ImageButton7" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Cancel.png" CommandName="Cancel" CausesValidation="False">
                                                        </asp:ImageButton>
                                                        &nbsp;
                                                    </InsertItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:ImageButton id="ImageButton1" onclick="ImgBtnEdit_Click" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Edit.png" CommandName="Edit" CausesValidation="False">
                                                        </asp:ImageButton>
                                                        &nbsp;&nbsp;
                                                        <asp:ImageButton id="ImgBtnNew" onclick="ImgBtnNew_Click" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Add.png" CommandName="New" CausesValidation="False">
                                                        </asp:ImageButton>
                                                        &nbsp;&nbsp;
                                                        <asp:ImageButton id="ImgBtnDelete" onclick="ImgBtnDelete_Click" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Delete.png" CausesValidation="False">
                                                        </asp:ImageButton>
                                                        &nbsp;
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Fields>
                                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White">
                                            </FooterStyle>
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White">
                                            </HeaderStyle>
                                            <PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White">
                                            </PagerStyle>
                                            <RowStyle BackColor="#EFF3FB">
                                            </RowStyle>                                           
                                        </asp:DetailsView>
                                        <table style="WIDTH: 100%; HEIGHT: 100%">
                                            <tbody>
                                                <tr>
                                                    <td style="TEXT-ALIGN: left">
                                                        <asp:ValidationSummary id="ValidationSummary1" runat="server" Width="100%">
                                                        </asp:ValidationSummary>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                        &nbsp;&nbsp;
                                    </div>
                                    </ContentTemplate>
                                </Ajax:TabPanel>
                                <Ajax:TabPanel runat="server" HeaderText="TabPanel2" ID="TabPanel2">
                                    <HeaderTemplate>
                                        <img style="VISIBILITY: hidden" src="../../AlfaNetImagen/ToolBar/lock_edit.png"  />
                                    </HeaderTemplate>
                                    <ContentTemplate>   
                                        <table style="FONT-WEIGHT: bold">
                                            <tbody>
                                                <tr>
                                                    <td>
                                                    <br />
                                                        <img src="../../AlfaNetImagen/ToolBar/lock.png" />
                                                        <br />
                                                        <br />
                                                        <img src="../../AlfaNetImagen/ToolBar/key.png" />
                                                        <br />
                                                    </td>
                                                    <td style="WIDTH: 16px">
                                                    <br />
                                                        <asp:RadioButtonList style="TEXT-ALIGN: left" id="RbtnLstPermiso" runat="server" Width="245px" ForeColor="Black" Font-Bold="False" CssClass="DVRbtnLstStyle" AutoPostBack="True" OnSelectedIndexChanged="RbtnLstPermiso_SelectedIndexChanged" Height="52px" Enabled="False">
                                                            <asp:ListItem Selected="True" Value="0">
                                                            Denegar
                                                            &#225; 
                                                            acceso a la consulta
                                                            </asp:ListItem>
                                                            <asp:ListItem Value="1">
                                                            Permitir
                                                            &#225; 
                                                            acceso a la consulta
                                                            </asp:ListItem>
                                                        </asp:RadioButtonList>
                                                     </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </ContentTemplate>
                                </Ajax:TabPanel>
                            </Ajax:TabContainer>
                            <Ajax:ModalPopupExtender id="MPEMensaje" runat="server" TargetControlID="LblTipologia" BackgroundCssClass="MessageStyle" PopupControlID="PnlMensaje">
                            </Ajax:ModalPopupExtender>
                            <asp:Panel style="DISPLAY: none" id="PnlMensaje" runat="server" Width="125px" Height="63px">
                            <br />
                                <table>
                                    <tbody>
                                        <tr>
                                            <td style="BACKGROUND-COLOR: activecaption" >
                                                <asp:Label id="Label5" runat="server" Width="120px" ForeColor="White" Text="Mensaje" Font-Size="14pt" Font-Bold="False">
                                                </asp:Label>
                                            </td>
                                            <td style="WIDTH: 12%; BACKGROUND-COLOR: activecaption">
                                                <asp:ImageButton style="VERTICAL-ALIGN: top" id="btnCerrar" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/cross.png" ImageAlign="Right" CausesValidation="False">
                                                </asp:ImageButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="HEIGHT: 45px; BACKGROUND-COLOR: highlighttext" colspan="2">
                                            <br />
                                                <img src="../../AlfaNetImagen/ToolBar/error.png" />
                                                &nbsp; &nbsp;
                                                <asp:Label id="LblMessageBox" runat="server" ForeColor="Red" Font-Size="12pt">
                                                </asp:Label>
                                                <br />
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </asp:Panel>
                            <br />
                            <asp:Panel ID="Panel1" runat="server" Height="63px" Style="display: none" Width="125px">
                            <br />
                                <table>
                                    <tbody>
                                        <tr>
                                            <td style="background-color: activecaption">
                                                <asp:Label ID="Label6" runat="server" Font-Bold="False" Font-Size="14pt" ForeColor="White" Text="Mensaje" Width="120px">
                                                </asp:Label>
                                            </td>
                                            <td style="width: 12%; background-color: activecaption">
                                                <asp:ImageButton ID="ImageButton3" runat="server" CausesValidation="False" ImageAlign="Right" ImageUrl="~/AlfaNetImagen/ToolBar/cross.png" Style="vertical-align: top" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="height: 45px; background-color: highlighttext">
                                                <br />
                                                <img src="../../AlfaNetImagen/ToolBar/error.png" />
                                                &nbsp;&nbsp;
                                                <asp:Label ID="Label7" runat="server" Font-Size="12pt" ForeColor="Red">
                                                </asp:Label>
                                                &nbsp; &nbsp;
                                                <br />
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
                            <Ajax:ModalPopupExtender ID="MPEPregunta" runat="server" BackgroundCssClass="MessageStyle" CancelControlID="Button2" OkControlID="Button1" PopupControlID="Panel1" TargetControlID="Button1">
                            </Ajax:ModalPopupExtender>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td style="width: 30%">
                </td>
            </tr>
        </tbody>
    </table>
    <asp:ObjectDataSource ID="GrupoByIdDataSource" runat="server" DeleteMethod="Delete"
            InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetTipologiaBy"
            TypeName="DSTipologiaTableAdapters.Tipologia_ReadTipologiaTableAdapter" UpdateMethod="Update">
            <SelectParameters>
                <asp:ControlParameter ControlID="HFCodigoSeleccionado" Name="TipologiaCodigo" PropertyName="Value"
                    Type="String" />
            </SelectParameters>
            <DeleteParameters>
                <asp:Parameter Name="Original_TipologiaCodigo" Type="String" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="TipologiaNombre" Type="String" />
                <asp:Parameter Name="TipologiaHabilitar" Type="String" />
                <asp:Parameter Name="Original_TipologiaCodigo" Type="String" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="TipologiaCodigo" Type="String" />
                <asp:Parameter Name="TipologiaNombre" Type="String" />
                <asp:Parameter Name="TipologiaHabilitar" Type="String" />
            </InsertParameters>
        </asp:ObjectDataSource>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnStrSQLServer %>"
        SelectCommand="SELECT MAX(CONVERT (bigint, dbo.UDF_ParseAlphaChars(TipologiaCodigo)) + 1) AS Consecutivo FROM Tipologia">
    </asp:SqlDataSource>
</asp:Content>  