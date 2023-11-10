using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class AlfaNetDocumentos_DocEnviado_DocEnviadoDevPorNoCompetencia : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string RegistroCodigo = this.Request.QueryString["RegistroCodigo"];
        if (string.IsNullOrEmpty(RegistroCodigo))
            throw new ApplicationException("Se esperaba el Codigo del Registro");
        
        
        DSRegistroTableAdapters.Registro_ReadRegistroTableAdapter TAConsultaRegistro = new DSRegistroTableAdapters.Registro_ReadRegistroTableAdapter();
        DSRegistro.Registro_ReadRegistroDataTable DTRegistro = TAConsultaRegistro.GetRegistroById(Convert.ToString(2), RegistroCodigo);

        if (1 == DTRegistro.Rows.Count)
        {
            DSRegistro.Registro_ReadRegistroRow DRowRegistro = (DSRegistro.Registro_ReadRegistroRow)DTRegistro.Rows[0];

            //Obtener Informacion del Radicado
            DSRadicadoFuenteSQLTableAdapters.RadicadoFuente_ReadRadicadoFuenteTableAdapter TARadFuente = new DSRadicadoFuenteSQLTableAdapters.RadicadoFuente_ReadRadicadoFuenteTableAdapter();
            DSRadicadoFuenteSQL.RadicadoFuente_ReadRadicadoFuenteDataTable DTRadFuente = TARadFuente.GetRadFuente("2", Convert.ToInt32(DRowRegistro.RegistroCodigo));
            if (0 == DTRadFuente.Rows.Count) 
                throw new ApplicationException("Este registro no responde ningún radicado PQR");
            DSRadicadoFuenteSQL.RadicadoFuente_ReadRadicadoFuenteRow DRowRadFuente = (DSRadicadoFuenteSQL.RadicadoFuente_ReadRadicadoFuenteRow)DTRadFuente.Rows[0];
            string RadicadoCodigo = DRowRadFuente.RadicadoCodigoFuente.ToString();
            
            DSRadicadoTableAdapters.Radicado_ReadRadTableAdapter TAConsulaRadicado = new DSRadicadoTableAdapters.Radicado_ReadRadTableAdapter();
            DSRadicado.Radicado_ReadRadDataTable DTRadicado = TAConsulaRadicado.GetRadicadoByCodigo(RadicadoCodigo);
            DSRadicado.Radicado_ReadRadRow DRowRadicado = (DSRadicado.Radicado_ReadRadRow)DTRadicado.Rows[0];

            //Fecha del Registro
            this.lbFecha.Text = "Bogotá, D.C. " + string.Format(new System.Globalization.CultureInfo("es-CO"), "{0:MMMM dd} de {0:yyyy}", Convert.ToDateTime(DRowRegistro.WFMovimientoFecha));
            //Destino del Registro
            this.lbProcedencia.Text = DRowRegistro.ProcedenciaNombre;
            //Direccion de destino del Registro
            this.lbDireccionProcedencia.Attributes.Add("style", "display:none;");
            //Ciudad Procedencia
            this.ldCiudadProcedencia.Text = DRowRegistro.CiudadNombre;
            //Numero del Radicado que se esta respondiendo
            this.lbRadicadoNumero.Text = RadicadoCodigo;
            //Fecha del Radicado
            this.lbRadicadoFecha.Text = string.Format(new System.Globalization.CultureInfo("es-CO"), "{0:dd} de {0:MMMM} de {0:yyyy}", Convert.ToDateTime(DRowRadicado.WFMovimientoFecha));
            //Procedencia del Radicado
            this.lbRadicadoProcedencia.Text = DRowRadicado.ProcedenciaNombre;
        }
        //IFormatProvider proveedor = new System.Globalization.CultureInfo("en-en");
        //string.Format(
        //Convert.ToDateTime()
    }
    public void Page_Error(object Sender, EventArgs e) 
    {
        Exception objErr = Server.GetLastError().GetBaseException();
        string err = "<b>Error Caught in Page_Error event</b><hr><br>" +
                "<br><b>Error in: </b>" + Request.Url.ToString() +
                "<br><b>Error Message: </b>" + objErr.Message.ToString() +
                "<br><b>Stack Trace:</b><br>" +
                          objErr.StackTrace.ToString();
        Response.Write(err.ToString());
        Server.ClearError();
    }
}
