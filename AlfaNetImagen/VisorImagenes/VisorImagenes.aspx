<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VisorImagenes.aspx.cs" Inherits="VImagenes" %>

<%@ Register Assembly="Neodynamic.WebControls.ImageDraw" Namespace="Neodynamic.WebControls.ImageDraw"
    TagPrefix="neoimg" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Assembly="Infragistics2.Web.v8.1, Version=8.1.20081.1000, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.LayoutControls" TagPrefix="ig" %>

    <%@ Register Src="../../AlfaNetDocumentos/DocRecibido/NavDocRecibido.ascx" TagName="NavDocRecibido"
    TagPrefix="uc1" %>
<%@ Register Src="../../AlfaNetDocumentos/DocEnviado/NavDocEnviado.ascx" TagName="NavDocEnviado"
    TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title>Visor Imagenes AlfaNet</title>
        <script language="javascript" type="text/javascript">
            // <!CDATA[

        function exit()
        {

                window.close()

            }

            function confirmSubmit() {
                var agree = confirm("Esta Completamente Seguro que Desea Eliminar la Imagen?");
                if (agree)
                    return true;
                else
                    return false;
            }

            function Print(evt)
            {
                var src = window.event != window.undefined ? window.event.srcElement : evt.target;
                window.print();
            }

            function ClientSidePrint(idDiv) {
                var w = 600;
                var h = 400;
                var l = (window.screen.availWidth - w) / 2;
                var t = (window.screen.availHeight - h) / 2;

                var sOption = "toolbar=no,location=no,directories=no,menubar=no,scrollbars=yes,width=" + w + ",height=" + h + ",left=" + l + ",top=" + t;
                // Get the HTML content of the div
                var sDivText = window.document.getElementById(idDiv).innerHTML;
                // Open a new window
                //var objWindow = window.open("", "Print", sOption);
                var objWindow = window.open("", "Print", sOption);

                // Write the div element to the window
                objWindow.document.write(sDivText);
                objWindow.document.close();
                // Print the window            
                objWindow.print();
                // Close the window
                objWindow.close();
            }
            function ClientSideShow(idDiv) {

                var w = 600;
                var h = 400;
                var l = (window.screen.availWidth - w) / 2;
                var t = (window.screen.availHeight - h) / 2;
                
                var sOption = "width=" + w + ",height=" + h + ",left=" + l + ",top=" + t;
                

            if(window.frames.iframe1){
                    var FramePDF1 = window.frames.iframe1.document.location.href;
                    var objWindow = window.open(FramePDF1,'_blank',sOption);
                    objWindow.write(FramePDF1);
                    console.log(FramePDF1);
                    objWindow.document.close();
                    objWindow.stop();
                }
            else{
                var sDivText = window.document.getElementById(idDiv).innerHTML;
                var objWindow = window.open("","_blank",sOption);
                    objWindow.document.write(sDivText);
                    objWindow.document.close();
                    objWindow.stop();
                }   

            }
            // ]]>
        </script>
    </head>
    <body>
        <form id="form1" runat="server">



            <div class="Splitters">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <ig:WebSplitter id="VerticalSplitter" runat="server" StyleSetName="Default" DynamicResize="True" style="vertical-align: top; text-align: center">
                    <SplitterBar CssClass="Default">
                    </SplitterBar>
                    <Panes>
                        <ig:SplitterPane runat="server" CollapsedDirection="NextPane" Size="10%" MinSize="0px">
                            <Template>
                                <asp:PlaceHolder ID="PlaceHolder1" runat="server">
                                </asp:PlaceHolder>
                                <asp:Label ID="LNImagen"  runat="server">
                                </asp:Label>
                            </Template>
                        </ig:SplitterPane>
                        <ig:SplitterPane runat="server" CollapsedDirection="NextPane" Size="90%" MinSize="0px" ScrollBars="Hidden">
                            <Template>
                                <div style="VERTICAL-ALIGN: top; TEXT-ALIGN: left; height: 100%;">
                                    <table class="Container" cellPadding="2">
                                        <tbody>
                                            <tr class="viewerHeader">
                                                <td valign="top" align="left">

                                                    <asp:UpdatePanel id="UpdatePanel1" runat="server">
                                                        <contenttemplate>
                                                            <table style="WIDTH: 70%">
                                                                <tbody>
                                                                    <tr>
                                                                        <td style="WIDTH: 32647px">
                                                                            <asp:Label id="LblDocumentoNro" runat="server" Width="110px" Font-Size="Small" 
                                                                                    ForeColor="Red" Text="Label" Font-Bold="True">
                                                                            </asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <img id="imgclip" runat="server" src="../../AlfaNetImagen/ToolBar/file.gif" alt="" />
                                                                        </td>
                                                                        <td style="WIDTH: 339px">
                                                                            <asp:FileUpload id="FileUpload1" runat="server" Width="420px">
                                                                            </asp:FileUpload>
                                                                        </td>
                                                                        <td style="WIDTH: 1265px" align="right">
                                                                            <asp:Button style="BORDER-RIGHT: #3399ff thin solid; 
                                                                                    BORDER-TOP: #3399ff thin solid; BORDER-LEFT: #3399ff thin solid; 
                                                                                    BORDER-BOTTOM: #3399ff thin solid; BACKGROUND-COLOR: silver" 
                                                                                    id="BtnEnviar" onclick="BtnEnviar_Click" runat="server" 
                                                                                    Width="69px" Text="Adjuntar ..." CssClass="PointerCursor">
                                                                            </asp:Button>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                            <asp:Panel style="DISPLAY: none" id="PnlMensaje" runat="server" BackColor="ButtonHighlight">
                                                                <table>
                                                                    <tbody>
                                                                        <tr>
                                                                            <td style="BACKGROUND-COLOR: activecaption" align="center">
                                                                                <asp:Label id="Label555" runat="server" Width="120px" Font-Size="14pt" 
                                                                                        ForeColor="White" Text="Mensaje" Font-Bold="False">
                                                                                </asp:Label>
                                                                            </td>
                                                                            <td style="BACKGROUND-COLOR: activecaption">
                                                                                <asp:ImageButton style="VERTICAL-ALIGN: top" id="btnCerrar" runat="server" 
                                                                                        ImageUrl="~/AlfaNetImagen/ToolBar/cross.png" ImageAlign="Right" 
                                                                                        CausesValidation="False" ValidationGroup="789">
                                                                                </asp:ImageButton>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="center" colspan="2">
                                                                                <br />
                                                                                <asp:Label id="LblMessageBox" runat="server" Font-Size="Small" ForeColor="Black">
                                                                                </asp:Label>
                                                                                <br />
                                                                                <asp:Label id="LblUploadDetails" runat="server" Font-Size="Small" ForeColor="Red">
                                                                                </asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                            </asp:Panel>
                                                            <cc1:ModalPopupExtender id="MPEMensaje" runat="server" OkControlID="btnCerrar" DropShadow="True" 
                                                                    PopupControlID="PnlMensaje" BackgroundCssClass="MessageStyle" TargetControlID="LblMessageBox">
                                                            </cc1:ModalPopupExtender> 
                                                        </contenttemplate>  
                                                        <triggers>
                                                            <asp:PostBackTrigger ControlID="BtnEnviar">
                                                            </asp:PostBackTrigger>
                                                        </triggers>
                                                    </asp:UpdatePanel>

                                                    <table border="0">
                                                        <tbody>
                                                            <tr>
                                                                <td style="width: 26px;" valign="baseline">
                                                                    <asp:ImageButton id="prevButton" onclick="prevButton_Click" runat="server" 
                                                                            ImageUrl="~/AlfaNetImagen/ToolBar/prev.gif" CssClass="PointerCursor" 
                                                                            AlternateText="Pagina Anterior..." ToolTip="Pagina Anterior...">
                                                                    </asp:ImageButton>
                                                                </td>
                                                                <td vAlign="baseline">
                                                                    <asp:DropDownList id="ddlPages" runat="server" onselectedindexchanged="ddlPages_SelectedIndexChanged" 
                                                                            AutoPostBack="True" CssClass="PointerCursor" ToolTip="Ir a la página..">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td valign="baseline">
                                                                    <asp:ImageButton id="nextButton" onclick="nextButton_Click" runat="server" 
                                                                            ImageUrl="~/AlfaNetImagen/ToolBar/next.gif" CssClass="PointerCursor" 
                                                                            AlternateText="Pagina Siguiente..." ToolTip="Pagina Siguiente...">
                                                                    </asp:ImageButton>
                                                                </td>
                                                                <td align="left" style="width: 3px;" valign="middle">
                                                                    <asp:ImageButton ID="zoomMasButton" runat="server" AlternateText="Zoom In..." ToolTip="Acercar..." 
                                                                            CssClass="PointerCursor" onclick="zoomMasButton_Click"
                                                                            ImageUrl="~/AlfaNetImagen/ToolBar/zoommas.gif"/>
                                                                </td>
                                                                <td align="left" style="width: 3px;" valign="middle">
                                                                    <asp:ImageButton ID="zoomMenosButton" runat="server" AlternateText="Zoom Out..." 
                                                                            ToolTip="Disminuir..." CssClass="PointerCursor" onclick="zoomMenosButton_Click"
                                                                            ImageUrl="~/AlfaNetImagen/ToolBar/zoommenos.gif" />
                                                                </td>
                                                                <td valign="middle" align="left">
                                                                    <asp:ImageButton id="rotarIzqButton" onclick="rotarIzqButton_Click" runat="server" 
                                                                            ToolTip="Girar a la izquierda" ImageUrl="~/AlfaNetImagen/ToolBar/rotarizq.gif" 
                                                                            CssClass="PointerCursor" AlternateText="Rotar a la izquierda...">
                                                                    </asp:ImageButton>
                                                                    <asp:ImageButton id="rotarDerButton" onclick="rotarDerButton_Click" runat="server" 
                                                                            ToolTip="Girar a la derecha" ImageUrl="~/AlfaNetImagen/ToolBar/rotarder.gif" 
                                                                            CssClass="PointerCursor" AlternateText="Rotar a la derecha...">
                                                                    </asp:ImageButton>
                                                                </td>
                                                                <td vAlign=middle align=left>
                                                                </td>
                                                                <td style="WIDTH: 57px;" vAlign=middle align=left>
                                                                    <asp:DropDownList id="ddlZoom" runat="server" onselectedindexchanged="ddlZoom_SelectedIndexChanged" 
                                                                            AutoPostBack="True" CssClass="PointerCursor" ToolTip="Tamaño de la imágen...">
                                                                        <asp:ListItem Value="400">400%</asp:ListItem>
                                                                        <asp:ListItem Value="300">300%</asp:ListItem>
                                                                        <asp:ListItem Value="200">200%</asp:ListItem>
                                                                        <asp:ListItem Value="150">150%</asp:ListItem>
                                                                        <asp:ListItem Value="100">100%</asp:ListItem>
                                                                        <asp:ListItem Value="90">90%</asp:ListItem>
                                                                        <asp:ListItem Value="80" Selected="True">80%</asp:ListItem>
                                                                        <asp:ListItem Value="70">70%</asp:ListItem>
                                                                        <asp:ListItem Value="60">60%</asp:ListItem>
                                                                        <asp:ListItem Value="50">50%</asp:ListItem>
                                                                        <asp:ListItem Value="40">40%</asp:ListItem>
                                                                        <asp:ListItem Value="30">30%</asp:ListItem>
                                                                        <asp:ListItem Value="20">20%</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td valign="middle" align="left">
                                                                    <asp:CheckBox id="chkWatermark" runat="server" Width="88px" Text="Confidencial" AutoPostBack="true" 
                                                                            oncheckedchanged="chkWatermark_CheckedChanged" CssClass="PointerCursor">
                                                                    </asp:CheckBox>
                                                                </td>
                                                                <td align="left" valign="middle">
                                                                    <asp:ImageButton id="DeleteButton" Visible="false" onclick="DeleteButton_Click" runat="server" 
                                                                            ImageUrl="~/AlfaNetImagen/ToolBar/Delete.png" CssClass="PointerCursor" 
                                                                            AlternateText="Rotar a la derecha..." OnClientClick='return confirmSubmit()' 
                                                                            ToolTip="Elminar Imagen">
                                                                    </asp:ImageButton>
                                                                    <asp:LinkButton ID="LinkButton1" Visible="false" runat="server" OnClick="DeleteButton_Click" 
                                                                            Width="83px" OnClientClick="return confirmSubmit()">
                                                                        Eliminar Imagen
                                                                    </asp:LinkButton>
                                                                </td>
                                                              
                                                                <td align="left" valign="middle" style="width: 90px">
                                                                    <asp:Panel ID="PnlPrint" runat="server">
                                                                        <asp:ImageButton ID="ImageButton2" OnClick="ImageButtonguardar_click" runat="server" 
                                                                                ImageUrl="~/AlfaNetImagen/icono_guardar.gif"
                                                                                ToolTip="Guardar Imagen..." Visible="False" />
                                                                        <asp:ImageButton ID="ImgBtnPrintPDF" runat="server" Height="21px" 
                                                                                ImageUrl="~/AlfaNetImagen/ToolBar/icono_pdf.gif"
                                                                                Width="20px" OnClick="ImgBtnPrintPDF_Click" ToolTip="Guardar como PDF" Visible="False" />
                                                                        <asp:Image ID="ImgPrint" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/action_print.gif" 
                                                                                Width="16px" ToolTip="Imprimir imágen" Visible="False" />
                                                                            &nbsp;
                                                                        <asp:ImageButton ID="ImgShow" 
                                                                                runat="server" 
                                                                                ImageUrl="~/AlfaNetImagen/ToolBar/Read.png"
																				
                                                                                Width="21px" ToolTip="Ver imágen en pantalla completa" CssClass="PointerCursor" />
																				   Ver Imagen en Pantalla Completa
																				     </asp:ImageButton>
                                                                        &nbsp;
																		
                                                                    </asp:Panel>
                                                                </td>
                                                                <td align="left" style="width: 60px" valign="middle">
                                                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/cross.png"
                                                                            OnClientClick="return exit();" />
                                                                    <asp:LinkButton ID="LinkButton2" runat="server" OnClientClick="return exit();">
                                                                        Cerrar
                                                                    </asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top" align="center" colspan="3">
                                                    <div id ="currentPage" class="viewerContainer">
                                                        <neoimg:ImageDraw ID="ImageDraw2" name="ImageDraw2" runat="server" CacheExpiresAtDateTime=""
                                                                ImageFormat="Jpeg" Monochrome="False">
                                                            <Canvas CenterElements="True" Fill-BackgroundColor="115, 111, 110" />
                                                            <Elements>
                                                                <neoimg:ImageElement  MultiPageIndex="0" Name="myTiff" 
                                                                        NullImageUrl="~/AlfaNetImagen/iconos/icono_Blanco.JPG" Source="File" 
                                                                        UseSourceDpi="False" >
                                                                </neoimg:ImageElement>
                                                            </Elements>
                                                        </neoimg:ImageDraw>
                                                        <asp:Panel ID="Panel1" runat="server">
                                                            <iframe id="FramePDF" name="iframe1" runat="server" enableviewstate="true" visible="false" 
                                                                    style="width: 700px; height: 700px" frameborder="0" 
                                                                    src="../../AlfaNetRepositorioImagenes/Registros/2010/6/VisorI2.pdf" >
                                                            </iframe>
                                                        </asp:Panel>
                                                        &nbsp;
                                                    </div>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </Template>
                        </ig:SplitterPane>
                    </Panes>
                </ig:WebSplitter>  
            </div> 
            <table>
                <tr>
                    <td style="width: 100px">
                        <asp:HiddenField ID="HFRutaCodigo" runat="server" Value="1" />
                    </td>
                    <td style="width: 100px">
                        <asp:HiddenField ID="HFNroDoc" runat="server" />
                    </td>
                    <td style="width: 100px">
                        <asp:HiddenField ID="HFPath" runat="server" /><asp:HiddenField ID="HFFileName" runat="server" />
                    </td>
                    <td style="width: 100px">
                        <asp:HiddenField ID="HFZoom" runat="server" />
                    </td>
                </tr>
            </table>  
        </form>
    </body>
</html>
