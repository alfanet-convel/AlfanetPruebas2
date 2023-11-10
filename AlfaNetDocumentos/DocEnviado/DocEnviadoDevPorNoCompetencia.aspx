<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DocEnviadoDevPorNoCompetencia.aspx.cs" Inherits="AlfaNetDocumentos_DocEnviado_DocEnviadoDevPorNoCompetencia" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>PQR - Devolucón por no competencia</title>
    <style type="text/css">
        body{
            font-family: Arial,Helvetica,sans-serif;
            font-size: 12pt;
            text-align: justify;
        }
        .pieDePagina{
            font-family: Arial,Helvetica,sans-serif;
            font-size: 7pt;
            color: #2d4083;
            /*color: #33ccff;*/
            text-align: justify;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetRegistroById" TypeName="DSRegistroTableAdapters.Registro_ReadRegistroTableAdapter">
            <SelectParameters>
                <asp:Parameter DefaultValue="2" Name="grupo" Type="String" />
                <asp:QueryStringParameter DefaultValue="NULL" Name="RegistroCodigo" QueryStringField="RegistroCodigo"
                    Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:Panel ID="pnlContenedor" runat="server" Width="603px">
            <asp:Panel ID="pnlCabezote" runat="server" Height="54px">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/AlfaNetImagen/Logo/Logo.jpg" />
                <asp:Image ID="Image2" runat="server" ImageUrl="~/AlfaNetImagen/Logo/Logo.jpg" style="float:right;" />
                <div style="clear:both;">
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlCuerpo" runat="server">
                <br />
                <br />
                <p>
                <asp:Label ID="lbFecha" runat="server" Text="Bogotá, D.C. mayo  2011"></asp:Label>&nbsp;</p>
                <p>
                </p>
                <p>
                    &nbsp;</p>
                <p>
                    Señores <br />
                    <asp:Label ID="lbProcedencia" runat="server" Font-Bold="True"></asp:Label><br />
                    <asp:Label ID="lbDireccionProcedencia" runat="server" Text="Calle 7 No. 12-77"></asp:Label>
                    <asp:Label ID="ldCiudadProcedencia" runat="server" Text="Bogotá D.C."></asp:Label>
                </p>
                <br />
                
                <p>
                    Referencia: Derecho de Petición radicado No. <asp:Label ID="lbRadicadoNumero" runat="server"></asp:Label>
                    del <asp:Label ID="lbRadicadoFecha" runat="server"></asp:Label>
                </p>
                <p>
                    &nbsp;</p>
                
                <p>
                    Respetados señores: De manera atenta y para lo de su competencia, me permito remitir la comunicación de la referencia, suscrita por el/la señor(a)
                    <asp:Label id="lbRadicadoProcedencia" runat="server" Text="INELSA JUDITH CASTRO CANTILLO" Font-Bold="True"></asp:Label>.
                </p>
                
                <p>
                    Agradezco nos envíen copia de la respuesta a la peticionaria.
                </p>    
                    
                <p>
                    &nbsp;</p>
                <p>
                    &nbsp;</p>
                <p>
                    Cordial saludo,
                </p>
                
                <p>
                    &nbsp;</p>    
                <p>
                    <asp:Image id="imgFirmaRemitente" runat="server"></asp:Image><br />
                    <asp:Label id="lbRemitenteNombre" runat="server" Text="LUCY ESTELLA PALACIOS VALOYES" Font-Bold="True"></asp:Label><br />
                    Coordinadora Punto de Atención al Ciudadano y al Operador<br />
                </p>
                </asp:Panel>
            <asp:Panel ID="pnlPiedePagina" runat="server">
                <asp:Image ID="Image3" runat="server" ImageUrl="~/AlfaNetImagen/Logo/Logo.jpg" style="float:right;" />
                <p class="pieDePagina">
                    Edificio Murillo Toro, Carrera 8a, entre calles 12 y 13<br />
                    Código Postal: 117711 . Bogotá, Colombia<br />
                    T: +57 (1) 3443460 Fax: 57 (1) 344 2248<br />
                    www.mintic.gov.co <br />
                    www.vivedigital.gov.co<br />
                </p>
                <div style="clear:both;"></div>
            </asp:Panel>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
