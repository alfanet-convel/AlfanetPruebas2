﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Security;
using AjaxControlToolkit;
using DevExpress.Web.ASPxGridView;
using System.Web.UI.HtmlControls;
using DevExpress.Web;
using DevExpress.Web.ASPxCallbackPanel;
using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using System.Configuration;
using evointernal;
public partial class AlfanetWorkFlow_AlfanetWF_WorkFlow : System.Web.UI.Page
{
    string emailFrom = ConfigurationManager.AppSettings["EmailFrom"];
    string ModuloLog = "Workflow";
    string ConsecutivoCodigo = "9";
    string ConsecutivoCodigoErr = "4";
    string ActividadLogCodigoErr = "Error";
    protected void Page_Load(object sender, EventArgs e)
    { try {
            IPHostEntry host;
            string localIP = "";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    localIP = ip.ToString();
                    Session["IP"] = localIP;
                }
            }
            Session["Nombrepc"] = host.HostName.ToString();

            if (!Page.IsPostBack)
        {
            MembershipUser user = Membership.GetUser();
            Object CodigoRuta = user.ProviderUserKey;
            String UserId = Convert.ToString(CodigoRuta);
            double DiasExpired = 365;
            int validar = 0;
            DSValidarTableAdapters.Membership_validarTableAdapter vali = new DSValidarTableAdapters.Membership_validarTableAdapter();
            DSValidar.Membership_validarDataTable val = new DSValidar.Membership_validarDataTable();
            val = vali.GetData(UserId, validar);
            string UserIdValidar = val.Rows[0].ItemArray[0].ToString().Trim();

            if (user.LastPasswordChangedDate.AddDays(DiasExpired) < DateTime.Now || user.LastPasswordChangedDate == user.CreationDate || UserIdValidar == "0")
            {
                Response.Redirect("~/AlfanetInicio/InicioPassword/PasswordCambiar/PasswordCambiar.aspx");
            }
            else
            {

            ////////////////////////////////////////////////
            Label5.Visible = false;
            Panel21.Visible = false;
            this.HFmGrupo.Value = "1";
            this.HFmTipo.Value = "1";
            this.HFmDepCod.Value = Profile.GetProfile(User.Identity.Name).CodigoDepUsuario.ToString();
            this.HFmFecha.Value = DateTime.Now.ToString();

            DataView dv = (DataView)SqlDSMultitarea.Select(DataSourceSelectArguments.Empty);
            string reorderedProducts = (string)dv.Table.Rows[0][0];
            if (reorderedProducts != null)
            {
                this.HFMultiTarea.Value = reorderedProducts;
            }
            else
            {
                this.HFMultiTarea.Value = "0";
            }


            //Recibidos
            LblDocRecExtVen.Text = ((DataView)(ODSDocRecExtVen.Select())).Table.Rows.Count.ToString();
            LblDocRecExtProxVen.Text = ((DataView)(ODSDocRecExtProxVen.Select())).Table.Rows.Count.ToString();
            LblDocRecExtPen.Text = ((DataView)(ODSDocRecExtPen.Select())).Table.Rows.Count.ToString();
            LblDocRecCopia.Text = ((DataView)(ODSDocRecCopia.Select())).Table.Rows.Count.ToString();
            //Enviados
            LblDocEnvExtCopia.Text = ((DataView)(ODSDocEnvExtCopia.Select())).Table.Rows.Count.ToString();
            LblDocEnvExt.Text = ((DataView)(ODSDocEnvExtCopia.Select())).Table.Rows.Count.ToString();
            LblDocCopiaInt.Text = ((DataView)(ODSDocEnvIntCopia.Select())).Table.Rows.Count.ToString();
            LblDocEnvIntVen.Text = ((DataView)(ODSDocEnvIntVen.Select())).Table.Rows.Count.ToString();
            LblDocEnvInt.Text = (Convert.ToInt16(LblDocCopiaInt.Text) + Convert.ToInt16(LblDocEnvIntVen.Text)).ToString();

            //Total Recibidos
            LblDocRecExt.Text = (Convert.ToInt16(LblDocRecExtVen.Text) + Convert.ToInt16(LblDocRecExtProxVen.Text) + Convert.ToInt16(LblDocRecExtPen.Text) + Convert.ToInt16(LblDocRecCopia.Text)).ToString();

            //Click Panels
            //this.Panel3.Attributes.Add("onClick", "PanelClickP3();");
            //this.Panel5.Attributes.Add("onClick", "PanelClickP5();");
            ////this.Panel7.Attributes.Add("onClick", "PanelClickP7();");
            //this.Panel25.Attributes.Add("onClick", "PanelClickP25();");
            //this.Panel12.Attributes.Add("onClick", "PanelClickP12();");
            //this.Panel19.Attributes.Add("onClick", "PanelClickP19();");
            //this.Panel10.Attributes.Add("onClick", "PanelClickP10();");
            this.LnkBtnCargarPlantillas.Attributes.Add("onClick", "urlRptaPlantilla(event);");
                //LOG ACCESO
                string ActLogCod = "ACCESO";
                DateTime WFMovimientoFecha = DateTime.Now;
                //OBTENER CONSECUTIVO DE LOGS
                DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter Consecutivos = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                DSGrupoSQL.ConsecutivoLogsDataTable Conse = new DSGrupoSQL.ConsecutivoLogsDataTable();
                Conse = Consecutivos.GetConseActual(ConsecutivoCodigo);
                DataRow[] fila = Conse.Select();
                string x = fila[0].ItemArray[0].ToString();
                string LOG = Convert.ToString(x);
                //Se Realiza el Log
                int NumeroDocumento = 0;
                string GrupoCodigo = "";
                string Datosini = "Acceso a WORKFLOW";
                string Datosfin1 = "";
                string username = Profile.GetProfile(Profile.UserName).UserName.ToString();
                DSUsuarioTableAdapters.UserIdByUserNameTableAdapter objUsr = new DSUsuarioTableAdapters.UserIdByUserNameTableAdapter();
                string UsrId = objUsr.Aspnet_UserIDByUserName(username).ToString();
                DateTime FechaFin = DateTime.Now;
                Int64 LogId = Convert.ToInt64(LOG);
                string IP = Session["IP"].ToString();
                string NombreEquipo = Session["Nombrepc"].ToString();
                System.Web.HttpBrowserCapabilities nav = Request.Browser;
                string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
                Session["Navega"] = Navegador;
                DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter Accediendo = new DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter();
                //Insert de Log workflow Acceso
                Accediendo.GetInsertLogWF(LogId, username, WFMovimientoFecha, ActLogCod, NumeroDocumento, GrupoCodigo, ModuloLog,
                                    Datosini, Datosfin1, FechaFin, IP, NombreEquipo, Navegador);
                //Se actualiza el consecutivo de Log
                DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                ConseLogs.GetConsecutivos(ConsecutivoCodigo);
            }
        }
        else
        {
            string controlName = Request.Params.Get("__EVENTTARGET");
            string argument = Request.Params.Get("__EVENTARGUMENT");
            //if (controlName == "Panel3" && argument == "Click")
            //{
            //    if (ASPxGVDocRecExtVen.DataSourceID == "")
            //    {
            //        ASPxGVDocRecExtVen.DataSourceID = ODSDocRecExtVen.ID.ToString();

            //        this.CPExtender2.Collapsed = false;
            //        this.CPExtender2.ClientState = false.ToString();

            //    }
            //    else
            //    {
            //        ASPxGVDocRecExtVen.DataSourceID = "";
            //        this.CPExtender2.Collapsed = true;
            //        this.CPExtender2.ClientState = true.ToString();

            //    }
            //}
            //if (controlName == "Panel5" && argument == "Click")
            //{
            //    if (ASPxGVDocRecExtProxVen.DataSourceID == "")
            //    {
            //        ASPxGVDocRecExtProxVen.DataSourceID = ODSDocRecExtProxVen.ID.ToString();

            //        this.CPExtender3.Collapsed = false;
            //        this.CPExtender3.ClientState = false.ToString();

            //    }
            //    else
            //    {
            //        ASPxGVDocRecExtProxVen.DataSourceID = "";
            //        this.CPExtender3.Collapsed = true;
            //        this.CPExtender3.ClientState = true.ToString();

            //    }
            //}
            //if (controlName == "Panel7" && argument == "Click")
            //{
            //    if (ASPxGVDocRecExtPen.DataSourceID == "")
            //    {
            //        ASPxGVDocRecExtPen.DataSourceID = this.ODSDocRecExtPen.ID.ToString();

            //        this.CPExtender4.Collapsed = false;
            //        this.CPExtender4.ClientState = false.ToString();

            //    }
            //    else
            //    {
            //        ASPxGVDocRecExtPen.DataSourceID = "";
            //        this.CPExtender4.Collapsed = true;
            //        this.CPExtender4.ClientState = true.ToString();
            //    }
            //}
            //if (controlName == "Panel25" && argument == "Click")
            //{
            //    if (ASPxGVDocRecExtCopia.DataSourceID == "")
            //    {
            //        ASPxGVDocRecExtCopia.DataSourceID = ODSDocRecCopia.ID.ToString();
            //        this.CPEDocRecCopia.Collapsed = false;
            //        this.CPEDocRecCopia.ClientState = false.ToString();
            //    }
            //    else
            //    {
            //        ASPxGVDocRecExtCopia.DataSourceID = "";
            //        this.CPEDocRecCopia.Collapsed = true;
            //        this.CPEDocRecCopia.ClientState = true.ToString();

            //    }
            //}
            //if (controlName == "Panel12" && argument == "Click")
            //{
            //    if (ASPxGVDocEnvExtCopia.DataSourceID == "")
            //    {
            //        ASPxGVDocEnvExtCopia.DataSourceID = ODSDocEnvExtCopia.ID.ToString();
            //        this.CollapsiblePanelExtender1.Collapsed = false;
            //        this.CollapsiblePanelExtender1.ClientState = false.ToString();
            //    }
            //    else
            //    {
            //        ASPxGVDocEnvExtCopia.DataSourceID = "";
            //        this.CollapsiblePanelExtender1.Collapsed = true;
            //        this.CollapsiblePanelExtender1.ClientState = true.ToString();


            //    }
            //}
            //if (controlName == "Panel19" && argument == "Click")
            //{
            //    if (ASPxGVDocEnvIntVen.DataSourceID == "")
            //    {
            //        ASPxGVDocEnvIntVen.DataSourceID = ODSDocEnvIntVen.ID.ToString();
            //        this.CollapsiblePanelExtender5.Collapsed = false;
            //        this.CollapsiblePanelExtender5.ClientState = false.ToString();
            //    }
            //    else
            //    {
            //        ASPxGVDocEnvIntVen.DataSourceID = "";
            //        this.CollapsiblePanelExtender5.Collapsed = true;
            //        this.CollapsiblePanelExtender5.ClientState = true.ToString();


            //    }
            //}
            //if (controlName == "Panel10" && argument == "Click")
            //{
            //    if (ASPxGVDocEnvIntCopia.DataSourceID == "")
            //    {
            //        ASPxGVDocEnvIntCopia.DataSourceID = ODSDocEnvIntCopia.ID.ToString();
            //        this.CollapsiblePanelExtender2.Collapsed = false;
            //        this.CollapsiblePanelExtender2.ClientState = false.ToString();
            //    }
            //    else
            //    {
            //        ASPxGVDocEnvIntCopia.DataSourceID = "";
            //        this.CollapsiblePanelExtender2.Collapsed = true;
            //        this.CollapsiblePanelExtender2.ClientState = true.ToString();


            //    }
            //}
	}}
		catch{}
    }

    /*Visualizar los registros asociados al radicado*/
    protected void callbackPanel_Callback(object source, DevExpress.Web.ASPxClasses.CallbackEventArgsBase e)
    {
        Label LbTitulo = new Label();
        LbTitulo.Text = "Registro Nro.:";
        PnlContent.Controls.Add(LbTitulo);
        PnlContent.Controls.Add(new LiteralControl("<br />"));

        /*Separar los datos de documento y grupo*/
        String s1 = e.Parameter.ToString();
        char[] seps = { '|' };
        String[] Parametros = s1.Split(seps);

        //String listDocs = "";

        double Num;

        bool isNum = double.TryParse(Parametros[0].ToString().Trim(), out Num);

        /*Isertar el link referente al registro registro*/

        if (isNum && (Parametros.Length == 2))
        {
            DSRadicadoFuenteSQLTableAdapters.RadicadoFuente_ReadRadicadoFuenteRegistroTableAdapter DSRadFuenteReg = new DSRadicadoFuenteSQLTableAdapters.RadicadoFuente_ReadRadicadoFuenteRegistroTableAdapter();
            DSRadicadoFuenteSQL.RadicadoFuente_ReadRadicadoFuenteRegistroDataTable DTRadFuenteReg = new DSRadicadoFuenteSQL.RadicadoFuente_ReadRadicadoFuenteRegistroDataTable();
            DTRadFuenteReg = DSRadFuenteReg.GetRegistrosRadicadoFuente(Convert.ToInt32(Parametros[0].ToString()), Parametros[1].ToString());

            int i = 1;
            PnlContent.Controls.Add(new LiteralControl("<table valign=\"middle\">"));
            foreach (DSRadicadoFuenteSQL.RadicadoFuente_ReadRadicadoFuenteRegistroRow DRRadFuenteReg in DTRadFuenteReg.Rows)
            {
                PnlContent.Controls.Add(new LiteralControl("<tr><td>"));
                HyperLink HprRpta = new HyperLink();
                HprRpta.ID = "HprRpta" + i.ToString();
                HprRpta.Text = DRRadFuenteReg.RegistroCodigo.ToString();
                HprRpta.Target = "_Blank";
                HprRpta.ForeColor = System.Drawing.Color.Blue;
                HprRpta.Font.Underline = true;
                HprRpta.Attributes.Add("onClick", "urlInt(event," + DRRadFuenteReg.GrupoRegistroCodigo + ");");
                PnlContent.Controls.Add(HprRpta);
                PnlContent.Controls.Add(new LiteralControl("</td><td>"));
                System.Web.UI.WebControls.Image ImgRpta = new System.Web.UI.WebControls.Image();
                ImgRpta.ID = "ImgRpta" + i.ToString();
                ImgRpta.Width = new Unit("20px");
                ImgRpta.Height = new Unit("20px");
                ImgRpta.ImageUrl = "~/AlfaNetImagen/iconos/icono_tif.JPG";
                ImgRpta.Attributes.Add("onClick", "VImagenesReg(event," + DRRadFuenteReg.RegistroCodigo + "," + DRRadFuenteReg.GrupoRegistroCodigo + ");");
                PnlContent.Controls.Add(ImgRpta);
                PnlContent.Controls.Add(new LiteralControl("</td></tr>"));

                i += 1;
            }
            PnlContent.Controls.Add(new LiteralControl("</table>"));
        }
    }

    protected void LnkBtnCargarPlantillas_Click(object sender, EventArgs e)
    {
        Session.Add("OpcionPlantilla", "0");
    }

    protected void Label5_Init(object sender, EventArgs e)
    {
        //DSWorkFlow.WFMovimientos_ReadAllDependenciasDataTable Datos = new DSWorkFlow.WFMovimientos_ReadAllDependenciasDataTable();
        //DSWorkFlowTableAdapters.WFMovimientos_ReadAllDependenciasTableAdapter Tabla = new DSWorkFlowTableAdapters.WFMovimientos_ReadAllDependenciasTableAdapter();
        //Datos = Tabla.GetData(HFmDepCod);
    }

    protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ObjectDataSource ODSDoc = ((ObjectDataSource)e.Row.FindControl("ObjectDataReadDocumentos"));
            Label mDato = ((Label)e.Row.FindControl("Label10"));

            ODSDoc.SelectParameters["DependenciaCodigo"].DefaultValue = mDato.Text;
            if (mDato.Text == "")
            {
                Label5.Visible = false;
                Panel21.Visible = false;
            }
            else
            {
                Label5.Visible = false;
                Panel21.Visible = false;
            }
        }
    }

    protected void GridView4_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        HiddenField Grupo;
        Grupo = HFmGrupo;

        HiddenField Expediente =
            (HiddenField)e.Row.FindControl("HFExpediente1");

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label NroDoc = ((Label)e.Row.FindControl("Label18"));
            NroDoc.Attributes.Add("onClick", "url(event," + Grupo.Value + ");");
            ((HyperLink)e.Row.FindControl("HprLnkHisExtven1")).Attributes.Add("onClick", "Historico(event," + NroDoc.Text + "," + Grupo.Value + ");");

            ((HyperLink)e.Row.FindControl("HprLnkImgExtVen1")).Attributes.Add("onClick", "VImagenesReg(event," + NroDoc.Text + ",'" + Grupo.Value + "');");
            //((HyperLink)e.Row.FindControl("HprLnkHisExtven")).Attributes.Add("onClick", "HistoricoReg(event," + NroDoc.Text + ",'" + Grupo.Value + "');");
            ((HyperLink)e.Row.FindControl("HprLnkExp")).Attributes.Add("onClick", "Expediente(event," + NroDoc.Text + ",'" + Expediente.Value + "','" + Grupo.Value + "');");
        }
    }

    protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = ((GridView)sender).SelectedRow;

        if (row == null) return;

        ModalPopupExtender extender = row.FindControl("ModalPopupExtender2") as ModalPopupExtender;

        if (extender != null)
        {
            extender.Show();
        }
    }

    protected void ImgBtnFindProcedencia_Click(object sender, ImageClickEventArgs e)
    {
        if (TxtProcedencia.Text != "")
        {
        }
        else
        {
            this.ODSDocRecExtVen.DataBind();
        }
    }

    protected void ImgBtnFindDependenciaExt_Click(object sender, ImageClickEventArgs e)
    {
        if (TxtDependenciaExt.Text == "")
        {
            this.ODSDocEnvExtCopia.DataBind();
        }
    }

    protected void ImgBtnFindDependencia_Click(object sender, ImageClickEventArgs e)
    {
        if (TxtDependencia.Text == "")
        {
            this.ODSDocEnvIntVen.DataBind();
        }
    }

    protected void RadBtnLastFindbySerie_SelectedIndexChanged(object sender, EventArgs e)
    {

        int startVisibleIndex = ASPxGVDocRecExtVen.VisibleStartIndex;
        // The number of visible rows displayed within the current page. 
        int visibleRowCount = ASPxGVDocRecExtVen.GetCurrentPageRowValues("V.B").Count;
        // The visible index of the last row within the current page. 
        int endVisibleIndex = startVisibleIndex + visibleRowCount - 1;

        bool atLeastOneRowSelected = false;
        GridViewDataColumn colCarga = ASPxGVDocRecExtVen.Columns["Cargar a:"] as GridViewDataColumn;
        GridViewDataColumn colVB = ASPxGVDocRecExtVen.Columns["V.B"] as GridViewDataColumn;
        for (int i = startVisibleIndex; i <= endVisibleIndex; i++)
        {
            RadioButton rbSerie = (RadioButton)ASPxGVDocRecExtVen.FindRowCellTemplateControl(i, colCarga, "RadBtnLastFindbySerie");
            var autoComplete = ASPxGVDocRecExtVen.FindRowCellTemplateControl(i, colCarga, "AutoCompleteExtender2") as AjaxControlToolkit.AutoCompleteExtender; ;

            var cVB = (CheckBox)ASPxGVDocRecExtVen.FindRowCellTemplateControl(i, colVB, "SelectorDocumento");
            if( rbSerie.Checked) {
                autoComplete.ServiceMethod = "GetSerieByText";
            }
            else
            {
                autoComplete.ServiceMethod = "GetDependenciaByText";
            }

        }


    }
    protected void RadBtnLastFindbyDep_SelectedIndexChanged(object sender, EventArgs e)
    {


        int startVisibleIndex = ASPxGVDocRecExtVen.VisibleStartIndex;
        // The number of visible rows displayed within the current page. 
        int visibleRowCount = ASPxGVDocRecExtVen.GetCurrentPageRowValues("V.B").Count;
        // The visible index of the last row within the current page. 
        int endVisibleIndex = startVisibleIndex + visibleRowCount - 1;

        bool atLeastOneRowSelected = false;
        GridViewDataColumn colCarga = ASPxGVDocRecExtVen.Columns["Cargar a:"] as GridViewDataColumn;
        GridViewDataColumn colVB = ASPxGVDocRecExtVen.Columns["V.B"] as GridViewDataColumn;
        for (int i = startVisibleIndex; i <= endVisibleIndex; i++)
        {
            RadioButton rbDep = (RadioButton)ASPxGVDocRecExtVen.FindRowCellTemplateControl(i, colCarga, "RadBtnLastFindbyDep");
            var autoComplete = ASPxGVDocRecExtVen.FindRowCellTemplateControl(i, colCarga, "AutoCompleteExtender2") as AjaxControlToolkit.AutoCompleteExtender; ;

            var cVB = (CheckBox)ASPxGVDocRecExtVen.FindRowCellTemplateControl(i, colVB, "SelectorDocumento");
            if (rbDep.Checked)
            {
                autoComplete.ServiceMethod = "GetDependenciaByText";
            }
            else
            {
                autoComplete.ServiceMethod = "GetDependenciaByText";
            }

        }


    }
    protected void RadioButtonList111_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedValue == "1")
        {
            this.AutoCompleteExtender2.ServiceMethod = "GetSerieByText";
            this.TxtProcedencia.Text = "";
        }
        else if (RadioButtonList1.SelectedValue == "0")
        {
            this.AutoCompleteExtender2.ServiceMethod = "GetDependenciaByText";
            this.TxtProcedencia.Text = "";

        }
        else if (RadioButtonList1.SelectedValue == "2")
        {
            this.AutoCompleteExtender2.ServiceMethod = "GetDependenciaByText";
            this.TxtProcedencia.Text = "";

        }
        this.TxtProcedencia.Focus();
    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedValue == "1")
        {
            this.AutoCompleteExtender2.ServiceMethod = "GetRadicadoByCodigo";
            this.TxtProcedencia.Text = "";
        }
        else if (RadioButtonList1.SelectedValue == "0")
        {
            this.AutoCompleteExtender2.ServiceMethod = "GetProcedenciaByTextNombre";
            this.TxtProcedencia.Text = "";

        }
        else if (RadioButtonList1.SelectedValue == "2")
        {
            this.AutoCompleteExtender2.ServiceMethod = "GetNaturalezaByText";
            this.TxtProcedencia.Text = "";

        }
        this.TxtProcedencia.Focus();
    }

    protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonList2.SelectedValue == "1")
        {
            this.AutoCompleteExtender3.ServiceMethod = "GetRadicadoByCodigo";
            this.TxtDependencia.Text = "";
        }
        else if (RadioButtonList2.SelectedValue == "0")
        {
            this.AutoCompleteExtender3.ServiceMethod = "GetDependenciaByText";
            this.TxtDependencia.Text = "";
        }
        else if (RadioButtonList2.SelectedValue == "2")
        {
            this.AutoCompleteExtender3.ServiceMethod = "GetNaturalezaByText";
            this.TxtDependencia.Text = "";
        }
    }

    protected void RadioButtonList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonList3.SelectedValue == "1")
        {
            this.AutoCompleteExtender4.ServiceMethod = "GetRadicadoByCodigo";
            this.TxtDependenciaExt.Text = "";
        }
        else if (RadioButtonList3.SelectedValue == "0")
        {
            this.AutoCompleteExtender4.ServiceMethod = "GetDependenciaByText";
            this.TxtDependenciaExt.Text = "";

        }
        else if (RadioButtonList3.SelectedValue == "2")
        {
            this.AutoCompleteExtender4.ServiceMethod = "GetNaturalezaByText";
            this.TxtDependenciaExt.Text = "";

        }
    }

    protected void BtnTerminarDocrecVen_Click(object sender, EventArgs e)
    {
        try
        {
            this.LblMessageBox.Text = "";
            Terminartarea(ASPxGVDocRecExtVen, ODSDocRecExtVen, LblDocRecExtVen);

        }
        catch (Exception Error)
        {
            //Display a user-friendly message
            this.LblMessageBox.Text = "Ocurrio un problema al tratar de descargar el documento. ";
            Exception inner = Error.InnerException;
            this.LblMessageBox.Text += ErrorHandled.FindError(inner);
            this.LblMessageBox.Text += Error.Message.ToString();
            this.MPEMensaje.Show();
        }
        finally
        {
        }
    }

    protected void BtnTerminarIntEnvVen_Click(object sender, EventArgs e)
    {
        try
        {
            this.LblMessageBox.Text = "";
            Terminartarea(ASPxGVDocEnvIntVen, ODSDocEnvIntVen, LblDocEnvIntVen);
            LblDocEnvInt.Text = (Convert.ToInt16(LblDocCopiaInt.Text) + Convert.ToInt16(LblDocEnvIntVen.Text)).ToString();
        }
        catch (Exception Error)
        {
            //Display a user-friendly message
            this.LblMessageBox.Text = "Ocurrio un problema al tratar de descargar el documento. ";
            Exception inner = Error.InnerException;
            this.LblMessageBox.Text += ErrorHandled.FindError(inner);
            this.LblMessageBox.Text += Error.Message.ToString();
            this.MPEMensaje.Show();
        }
        finally
        {

        }
    }

    protected void BtnTerminarCopEnvExt_Click(object sender, EventArgs e)
    {
        try
        {
            this.LblMessageBox.Text = "";
            TerminarCopia(ASPxGVDocEnvExtCopia, ODSDocEnvExtCopia, LblDocEnvExtCopia);
            LblDocEnvExt.Text = LblDocEnvExtCopia.Text;
        }
        catch (Exception Error)
        {
            //Display a user-friendly message
            this.LblMessageBox.Text = "Ocurrio un problema al tratar de descargar el documento. ";
            Exception inner = Error.InnerException;
            this.LblMessageBox.Text += ErrorHandled.FindError(inner);
            this.LblMessageBox.Text += Error.Message.ToString();
            this.MPEMensaje.Show();
        }
        finally
        {

        }
    }

    protected void ASPxGVDocRecExtVen_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs e)
    {
        if (e.RowType == DevExpress.Web.ASPxGridView.GridViewRowType.Data)
        {
            ASPxRowBoundVen(ASPxGVDocRecExtProxVen, e, sender);
        }
    }

    protected void ASPxGVDocRecExtCopia_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs e)
    {
        if (e.RowType == DevExpress.Web.ASPxGridView.GridViewRowType.Data)
        {
            ASPxRowBoundCopia(ASPxGVDocRecExtProxVen, e, sender);
        }
    }

    protected void ASPxRowBoundCopiaEnv_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs e)
    {
        if (e.RowType == DevExpress.Web.ASPxGridView.GridViewRowType.Data)
        {
            ASPxRowBoundCopiaEnv(ASPxGVDocRecExtProxVen, e, sender);
        }
    }

    protected void ASPxRowBoundEnvIntVen_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs e)
    {
        if (e.RowType == DevExpress.Web.ASPxGridView.GridViewRowType.Data)
        {
            ASPxRowBoundEnvIntVen(ASPxGVDocRecExtProxVen, e, sender);
        }
    }

    /*Llenar los campos referentes a documentos copia enviados*/

    protected void ASPxRowBoundCopiaEnv(ASPxGridView GV, ASPxGridViewTableRowEventArgs GVR, Object sender)
    {
        GridViewDataColumn colReg =
                ((ASPxGridView)sender).Columns["Registro&lt;br/&gt;No."] as GridViewDataColumn;
        GridViewDataColumn colVB =
               ((ASPxGridView)sender).Columns["V.B"] as GridViewDataColumn;
        GridViewDataColumn colOpc =
               ((ASPxGridView)sender).Columns["Opciones"] as GridViewDataColumn;

        /*Obtiene los valores de los hiddenfield en opciones*/

        HiddenField Grupo =
            (HiddenField)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colOpc, "HFGrupo");
        HiddenField Expediente =
            (HiddenField)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colOpc, "HFExpediente");
        if (Expediente.Value == "")
        {
            Expediente.Value = "30001";
        }

        /*Insertar el metodo para el checkbox de visto bueno*/

        ((CheckBox)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colVB, "SelectorDocumento")).Attributes.Add("onClick", "ColorRow(this);");

        /*Insertar el método del hiperlink del numero de registro*/

        HyperLink NroDoc =
            (HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colReg, "HyperLink1");
        NroDoc.Attributes.Add("onClick", "urlInt(event," + Grupo.Value + ");");

        /*Añadir las funciones en los hyperlinks de la columna opciones*/
        ((HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colOpc, "HprLnkImgExtVen")).Attributes.Add("onClick", "VImagenesReg(event," + NroDoc.Text + ",'" + Grupo.Value + "');");
        ((HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colOpc, "HprLnkHisExtven")).Attributes.Add("onClick", "HistoricoReg(event," + NroDoc.Text + ",'" + Grupo.Value + "');");
        ((HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colOpc, "HprLnkExp")).Attributes.Add("onClick", "Expediente(event," + NroDoc.Text + ",'" + Expediente.Value + "','" + Grupo.Value + "');");
    }

    /*Llenar los campos para documentos recibidos*/
    protected void ASPxRowBoundVen(ASPxGridView GV, ASPxGridViewTableRowEventArgs GVR, Object sender)
    {
        /*Editar funcionalidades de columna Rpta*/

        GridViewDataColumn colPostIt =
               ((ASPxGridView)sender).Columns["Post It"] as GridViewDataColumn;
        HiddenField hfExpediente =
            ((HiddenField)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colPostIt, "hfExpediente"));

        /*Editar funcionalidades del columa Ver Post It*/

        GridViewDataColumn colCPostIt =
              ((ASPxGridView)sender).Columns["Ver Post It"] as GridViewDataColumn;

        Image ImgNot =
        ((Image)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colCPostIt, "ImgDocNotasExtVen"));

        TextBox TxtCnPosIt =
            ((TextBox)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colCPostIt, "TxtDocNotasExtVen"));

        if (TxtCnPosIt.Text != "")
        {
            ImgNot.Visible = true;
        }

        /*Buscar datos ocultos en la columna opciones*/

        GridViewDataColumn colOpc =
               ((ASPxGridView)sender).Columns["Opciones"] as GridViewDataColumn;

        HiddenField Grupo =
            (HiddenField)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colOpc, "HFGrupo");
        HiddenField Expediente =
            (HiddenField)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colOpc, "HFExpediente");

        /*Editar funcionalidades de columna Radicado Codigo*/

        GridViewDataColumn colRad =
                ((ASPxGridView)sender).Columns["RadicadoCodigo"] as GridViewDataColumn;

        HyperLink NroDoc =
            (HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colRad, "HyperLink1");
        NroDoc.Attributes.Add("onClick", "url(event,1);");

        /*Editar funcionalidades de columna Rpta*/

        GridViewDataColumn colRpta =
               ((ASPxGridView)sender).Columns["Rpta"] as GridViewDataColumn;

        ((ImageButton)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colRpta, "ImageButton3")).Attributes.Add("onClick", "urlRpta(event," + NroDoc.Text + ");");

        /*Editar funcionalidades de columna Opciones*/
        if (Expediente.Value == "")
        {
            Expediente.Value = "30001";
        }
        ((HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colOpc, "HprLnkImgExtVen")).Attributes.Add("onClick", "VImagenes(event," + NroDoc.Text + ",'" + Grupo.Value + "');");
        ((HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colOpc, "HprLnkHisExtven")).Attributes.Add("onClick", "Historico(event," + NroDoc.Text + ",'" + Grupo.Value + "');");
        ((HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colOpc, "HprLnkExp")).Attributes.Add("onClick", "Expediente(event," + NroDoc.Text + ",'" + Expediente.Value + "','" + Grupo.Value + "');");

        /*Editar funcionalidades de columna Cargar a: , Accion y V.B.*/
        GridViewDataColumn colCargar =
               ((ASPxGridView)sender).Columns["Cargar a:"] as GridViewDataColumn;

        GridViewDataColumn colAccion =
               ((ASPxGridView)sender).Columns["Acci&#243;n:"] as GridViewDataColumn;

        GridViewDataColumn colVB =
               ((ASPxGridView)sender).Columns["V.B"] as GridViewDataColumn;

        TextBox mCargar =
             (TextBox)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colCargar, "TxtCargarDocVen");

        HiddenField mHFCarga =
            (HiddenField)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colCargar, "HFCargar");

        TextBox TAcc =
            (TextBox)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colAccion, "TxtAccionDocExtVen");
        
        RadioButton rbSerie = 
            (RadioButton)GV.FindRowCellTemplateControl(GVR.VisibleIndex, colCargar, "RadBtnLastFindbySerie");

        mCargar.Attributes.Add("onkeydown", "return Disable_Attr(event,getElementById('" + mCargar.ClientID + "'),getElementById('" + mHFCarga.ClientID + "'));");

        ((CheckBox)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colVB, "SelectorDocumento")).Attributes.Add("onClick", "ColorRowVen(this," + mCargar.ClientID + "," + TAcc.ClientID + ");");
        
        ((TreeView)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colAccion, "TreeVDependencia")).Attributes.Add("onClick", "return OnTreeClick2(event,getElementById('" + mCargar.ClientID + "'),getElementById('" + mHFCarga.ClientID + "'));");
        ((TreeView)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colAccion, "TreeVSerie")).Attributes.Add("onClick", "return OnTreeClickSerie(event,getElementById('" + mCargar.ClientID + "'),getElementById('" + mHFCarga.ClientID + "'));");

        /*Editar funcionalidades de columna RadicadoCodigo*/

        HiddenField LabelResuesta = (HiddenField)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colRad, "Label60");//GVR.Row.FindControl("Label60"));
        Image Image1 = (Image)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colRad, "Image1");//GVR.Row.FindControl("Image1");

        if (LabelResuesta.Value == "0")
        {
            LabelResuesta.Value = "Sin Respuesta";
            Image1.Visible = false;
        }
        else
        {
            HtmlControl c1 = (HtmlControl)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colRad, "LnkRpta");
            c1.Attributes.Add("onclick", "OnMoreInfoClick(this,'" + NroDoc.Text + "|" + Grupo.Value.ToString() + "'" + ")");
        }
    }

    /*Lllena los campos referentes a documentos recibidos pendientes*/
    protected void ASPxRowBoundEnvIntVen(ASPxGridView GV, ASPxGridViewTableRowEventArgs GVR, Object sender)
    {
        /*Busca las columnas a editar*/
        GridViewDataColumn colReg =
                ((ASPxGridView)sender).Columns["Registro&lt;br/&gt;No."] as GridViewDataColumn;
        GridViewDataColumn colVB =
               ((ASPxGridView)sender).Columns["V.B"] as GridViewDataColumn;
        GridViewDataColumn colOpc =
               ((ASPxGridView)sender).Columns["Opciones"] as GridViewDataColumn;
        GridViewDataColumn colCargar =
               ((ASPxGridView)sender).Columns["Cargar a:"] as GridViewDataColumn;
        GridViewDataColumn colAccion =
               ((ASPxGridView)sender).Columns[11] as GridViewDataColumn;
        GridViewDataColumn colpit =
               ((ASPxGridView)sender).Columns[6] as GridViewDataColumn;
        GridViewDataColumn colvpit =
               ((ASPxGridView)sender).Columns[5] as GridViewDataColumn;

        TextBox mCargar = (TextBox)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colCargar, "TxtCargarDocVen");
        TextBox TAcc = (TextBox)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colAccion, "TxtAccionDocExtVen");

        HyperLink NroDoc = (HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colReg, "HyperLink1");

        HiddenField Expediente = (HiddenField)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colOpc, "HFExpediente");
        HiddenField Grupo = (HiddenField)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colOpc, "HFGrupo");

        HiddenField mHFCarga = (HiddenField)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colCargar, "HFCargar");

        if (Expediente.Value == "")
        {
            Expediente.Value = "30001";
        }

        /*Adicionar las funciones al hyperlink del numero de registro*/
        NroDoc.Attributes.Add("onClick", "urlInt(event," + Grupo.Value + ");");

        /*Adicionar las funciones a los hyperlinks de la columna de opciones*/
        ((HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colOpc, "HprLnkImgExtVen")).Attributes.Add("onClick", "VImagenesReg(event," + NroDoc.Text + ",'" + Grupo.Value + "');");
        ((HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colOpc, "HprLnkHisExtven")).Attributes.Add("onClick", "HistoricoReg(event," + NroDoc.Text + ",'" + Grupo.Value + "');");
        ((HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colOpc, "HprLnkExp")).Attributes.Add("onClick", "Expediente(event," + NroDoc.Text + ",'" + Expediente.Value + "','" + Grupo.Value + "');");

        /*Insertar el metodo para el checkbox de visto bueno*/

        ((CheckBox)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colVB, "SelectorDocumento")).Attributes.Add("onClick", "ColorRowVen(this," + mCargar.ClientID + "," + TAcc.ClientID + ");");

        /*Inserta las funcionalidades a los treeview*/

        mCargar.Attributes.Add("onkeydown", "return Disable_Attr(event,getElementById('" + mCargar.ClientID + "'),getElementById('" + mHFCarga.ClientID + "'));");

        ((TreeView)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colCargar, "TreeVDependencia")).Attributes.Add("onClick", "return OnTreeClick2(event,getElementById('" + mCargar.ClientID + "'),getElementById('" + mHFCarga.ClientID + "'));");
        ((TreeView)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colCargar, "TreeVFinalizar")).Attributes.Add("onClick", "return OnTreeClickSerie(event,getElementById('" + mCargar.ClientID + "'),getElementById('" + mHFCarga.ClientID + "'));");
        ((TreeView)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colCargar, "TreeVMultitarea")).Attributes.Add("onClick", "OnTreeClickMultitarea(event,getElementById('" + mCargar.ClientID + "'),getElementById('" + mHFCarga.ClientID + "'));");

        /*Controlar la visualizacion de la opcion de ver post it*/

        TextBox LblNot = (TextBox)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colvpit, "TxtDocNotasextven");
        Image ImgNot = (Image)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colvpit, "ImgDocNotasExtVen");

        if (LblNot.Text == "")
        {
            ImgNot.Visible = false;
        }

        if (HFMultiTarea.Value != "1")
        {
            ((TreeView)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colCargar, "TreeVMultitarea")).Visible = false;
        }
    }

    /*Llenar los campos referentes a copia de recibidos*/

    protected void ASPxRowBoundCopia(ASPxGridView GV, ASPxGridViewTableRowEventArgs GVR, Object sender)
    {
        /*Editar funcionalidades de columna Rpta*/

        GridViewDataColumn colRPostIt =
               ((ASPxGridView)sender).Columns["Rpta"] as GridViewDataColumn;

        ((ImageButton)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colRPostIt, "ImageButton3")).Attributes.Add("onClick", "urlRpta(event);");

        /*Editar funcionalidades del columa Ver Post It*/

        GridViewDataColumn colCPostIt =
              ((ASPxGridView)sender).Columns["Ver Post It"] as GridViewDataColumn;

        Image ImgNot =
        ((Image)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colCPostIt, "ImgDocNotasExtVen"));

        TextBox TxtCnPosIt =
            ((TextBox)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colCPostIt, "TxtDocNotasExtVen"));

        if (TxtCnPosIt.Text != "")
        {
            ImgNot.Visible = true;
        }

        /*Buscar datos ocultos en la columna opciones*/

        GridViewDataColumn colOpc =
               ((ASPxGridView)sender).Columns["Opciones"] as GridViewDataColumn;

        HiddenField Grupo =
            (HiddenField)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colOpc, "HFGrupo");
        HiddenField Expediente =
            (HiddenField)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colOpc, "HFExpediente");

        /*Editar funcionalidades de columna Radicado Codigo*/

        GridViewDataColumn colRad =
                ((ASPxGridView)sender).Columns["RadicadoCodigo"] as GridViewDataColumn;

        HyperLink NroDoc =
            (HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colRad, "HyperLink1");
        NroDoc.Attributes.Add("onClick", "url(event,1);");

        /*Editar funcionalidades de columna Opciones*/
        if (Expediente.Value == "")
        {
            Expediente.Value = "30001";
        }
        ((HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colOpc, "HprLnkImgExtVen")).Attributes.Add("onClick", "VImagenes(event," + NroDoc.Text + ",'" + Grupo.Value + "');");
        ((HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colOpc, "HprLnkHisExtven")).Attributes.Add("onClick", "Historico(event," + NroDoc.Text + ",'" + Grupo.Value + "');");
        ((HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colOpc, "HprLnkExp")).Attributes.Add("onClick", "Expediente(event," + NroDoc.Text + ",'" + Expediente.Value + "','" + Grupo.Value + "');");

        /*Editar funcionalidades de columna Cargar a: , Accion y V.B.*/

        GridViewDataColumn colVB =
               ((ASPxGridView)sender).Columns["V.B"] as GridViewDataColumn;

        ((CheckBox)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colVB, "SelectorDocumento")).Attributes.Add("onClick", "ColorRow(this);");

        /*Editar funcionalidades de columna RadicadoCodigo*/

        HiddenField LabelResuesta = (HiddenField)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colRad, "Label60");//GVR.Row.FindControl("Label60"));
        Image Image1 = (Image)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colRad, "Image1");//GVR.Row.FindControl("Image1");

        if (LabelResuesta.Value == "0")
        {
            LabelResuesta.Value = "Sin Respuesta";
            Image1.Visible = false;
        }
        else
        {
            HtmlControl c1 = (HtmlControl)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colRad, "LnkRpta");
            c1.Attributes.Add("onclick", "OnMoreInfoClick(this,'" + NroDoc.Text + "|" + Grupo.Value.ToString() + "'" + ")");
        }
    }

    protected void ODSDocEnvIntVen_Filtering(object sender, ObjectDataSourceFilteringEventArgs e)
    {
        String CodProcedencia = TxtDependencia.Text;
        if (TxtDependencia.Text != "")
        {
            if (CodProcedencia != null)
            {
                if (CodProcedencia.Contains(" | "))
                {
                    CodProcedencia = CodProcedencia.Remove(CodProcedencia.IndexOf(" | "));
                }
            }
            e.ParameterValues.Clear();
            if (RadioButtonList2.SelectedValue == "0")
            {
                ODSDocEnvIntVen.FilterExpression = "DependenciaCodOrigen='{0}'";
                e.ParameterValues.Add("DependenciaCodOrigen", CodProcedencia);
            }
            else if (RadioButtonList2.SelectedValue == "1")
            {
                ODSDocEnvIntVen.FilterExpression = "NumeroDocumento='{0}'";
                e.ParameterValues.Add("NumeroDocumento", CodProcedencia);
            }
            else if (RadioButtonList2.SelectedValue == "2")
            {
                ODSDocEnvIntVen.FilterExpression = "NaturalezaCodigo='{0}'";
                e.ParameterValues.Add("NaturalezaCodigo", CodProcedencia);
            }
        }
        else
        {
            this.ODSDocEnvIntVen.FilterExpression = null;
        }
    }

    protected void ODSDocEnvExtCopia_Filtering(object sender, ObjectDataSourceFilteringEventArgs e)
    {
        String CodProcedencia = TxtDependenciaExt.Text;
        if (TxtDependenciaExt.Text != "")
        {
            if (CodProcedencia != null)
            {
                if (CodProcedencia.Contains(" | "))
                {
                    CodProcedencia = CodProcedencia.Remove(CodProcedencia.IndexOf(" | "));
                }
            }
            e.ParameterValues.Clear();
            if (RadioButtonList3.SelectedValue == "0")
            {
                ODSDocEnvExtCopia.FilterExpression = "DependenciaCodOrigen='{0}'";
                e.ParameterValues.Add("DependenciaCodOrigen", CodProcedencia);
            }
            else if (RadioButtonList3.SelectedValue == "1")
            {
                ODSDocEnvExtCopia.FilterExpression = "NumeroDocumento='{0}'";
                e.ParameterValues.Add("NumeroDocumento", CodProcedencia);
            }
            else if (RadioButtonList3.SelectedValue == "2")
            {
                ODSDocEnvExtCopia.FilterExpression = "NaturalezaCodigo='{0}'";
                e.ParameterValues.Add("NaturalezaCodigo", CodProcedencia);
            }
        }
        else
        {
            this.ODSDocEnvExtCopia.FilterExpression = null;
        }
    }

    protected void TreeVDependencia_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        ArbolesBLL ObjArbolDep = new ArbolesBLL();
        DSDependenciaSQL.DependenciaByTextDataTable DTDependencia = new DSDependenciaSQL.DependenciaByTextDataTable();
        DTDependencia = ObjArbolDep.GetDependenciaTree(e.Node.Value);
        PopulateNodes(DTDependencia, e.Node.ChildNodes, "DependenciaCodigo", "DependenciaNombre", "0");
    }

    protected void TreeVSerie_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        ArbolesBLL ObjArbolSer = new ArbolesBLL();
        DSSerieSQL.SerieByTextDataTable DTSerie = new DSSerieSQL.SerieByTextDataTable();
        DTSerie = ObjArbolSer.GetSerieTree(e.Node.Value);
        PopulateNodes(DTSerie, e.Node.ChildNodes, "SerieCodigo", "SerieNombre", "1");

    }

    private void PopulateNodes(DataTable dt, TreeNodeCollection nodes, String Codigo, String Nombre, string SeleccionarNodo)
    {
        foreach (DataRow dr in dt.Rows)
        {
            TreeNode tn = new TreeNode();
            tn.Text = dr[Codigo].ToString() + " | " + dr[Nombre].ToString();
            tn.Value = dr[Codigo].ToString();
            tn.NavigateUrl = "javascript:void(0);";

            if (SeleccionarNodo == "1")
            {
                if (Convert.ToInt32(dr["childnodecount"]) > 0)
                {
                    tn.SelectAction = TreeNodeSelectAction.None;
                }
                else
                {
                }
            }
            else
            {
                tn.SelectAction = TreeNodeSelectAction.Select;
            }
            nodes.Add(tn);

            tn.PopulateOnDemand = (Convert.ToInt32(dr["childnodecount"]) > 0);
        }
    }

    protected void BtnTerminarDocRecProx_Click(object sender, EventArgs e)
    {
        try
        {
            this.LblMessageBox.Text = "";
            Terminartarea(ASPxGVDocRecExtProxVen, ODSDocRecExtProxVen, LblDocRecExtProxVen);
        }
        catch (Exception Error)
        {
            //Display a user-friendly message
            this.LblMessageBox.Text = "Ocurrio un problema al tratar de descargar el documento. ";
            Exception inner = Error.InnerException;
            this.LblMessageBox.Text += ErrorHandled.FindError(inner);
            this.LblMessageBox.Text += Error.Message.ToString();
            this.MPEMensaje.Show();
        }
        finally
        {
        }
    }

    protected void BtnTerminarDocRecPen_Click(object sender, EventArgs e)
    {
        try
        {
            this.LblMessageBox.Text = "";
            Terminartarea(ASPxGVDocRecExtPen, ODSDocRecExtPen, LblDocRecExtPen);
        }
        catch (Exception Error)
        {
            //Display a user-friendly message
            this.LblMessageBox.Text = "Ocurrio un problema al tratar de descargar el documento. ";
            Exception inner = Error.InnerException;
            this.LblMessageBox.Text += ErrorHandled.FindError(inner);
            this.LblMessageBox.Text += Error.Message.ToString();
            this.MPEMensaje.Show();
        }
        finally
        {
        }
    }

    protected void BtnTerminarEnvIntCop_Click(object sender, EventArgs e)
    {
        try
        {
            this.LblMessageBox.Text = "";
            TerminarCopia(ASPxGVDocEnvIntCopia, ODSDocEnvIntCopia, LblDocCopiaInt);
            LblDocEnvInt.Text = (Convert.ToInt16(LblDocCopiaInt.Text) + Convert.ToInt16(LblDocEnvIntVen.Text)).ToString();
        }
        catch (Exception Error)
        {
            //Display a user-friendly message
            this.LblMessageBox.Text = "Ocurrio un problema al tratar de descargar el documento. ";
            Exception inner = Error.InnerException;
            this.LblMessageBox.Text += ErrorHandled.FindError(inner);
            this.LblMessageBox.Text += Error.Message.ToString();
            this.MPEMensaje.Show();
        }
        finally
        {

        }
    }

    protected void BtnTerminarCop_Click(object sender, EventArgs e)
    {
        try
        {

            this.LblMessageBox.Text = "";
            TerminarCopia(ASPxGVDocRecExtCopia, ODSDocRecCopia, LblDocRecCopia);
            LblDocRecExt.Text = LblDocRecExt.Text = (Convert.ToInt16(LblDocRecExtVen.Text) + Convert.ToInt16(LblDocRecExtProxVen.Text) + Convert.ToInt16(LblDocRecExtPen.Text) + Convert.ToInt16(LblDocRecCopia.Text)).ToString();
        }
        catch (Exception Error)
        {
            //Display a user-friendly message
            this.LblMessageBox.Text = "Ocurrio un problema al tratar de descargar el documento. ";
            Exception inner = Error.InnerException;
            this.LblMessageBox.Text += ErrorHandled.FindError(inner);
            this.LblMessageBox.Text += Error.Message.ToString();
            this.MPEMensaje.Show();
        }
        finally
        {
        }
    }

    /*Sobreescritura del método de terminar copia */
    protected void TerminarCopia(ASPxGridView GV, ObjectDataSource ODS, Label LblLocal)
    {
        // Iterate through the Products.Rows property

        // The visible index of the fist row within the current page. 
        int startVisibleIndex = GV.VisibleStartIndex;
        // The number of visible rows displayed within the current page. 
        int visibleRowCount = GV.GetCurrentPageRowValues("V.B").Count;
        // The visible index of the last row within the current page. 
        int endVisibleIndex = startVisibleIndex + visibleRowCount - 1;

        bool atLeastOneRowSelected = false;

        for (int i = startVisibleIndex; i <= endVisibleIndex; i++)
        {
            GridViewDataColumn colVB = GV.Columns["V.B"] as GridViewDataColumn;
            GridViewDataColumn colOpc = GV.Columns["Opciones"] as GridViewDataColumn;
            GridViewDataColumn colPit = GV.Columns["Post<br/>It"] as GridViewDataColumn;

            /*Revisa el checkBox*/
            CheckBox ch1 = (CheckBox)GV.FindRowCellTemplateControl(i, colVB, "SelectorDocumento");

            HiddenField hdWfMovTipo = (HiddenField)GV.FindRowCellTemplateControl(i, colOpc, "HFWFMovimiento");

            if (ch1 != null && ch1.Checked)
            {
                atLeastOneRowSelected = true;

                // First, get the DocumentID for the selected row
                GridViewDataColumn colDoc = GV.Columns["NumeroDocumento"] as GridViewDataColumn;
                int mNumeroDocumento = Convert.ToInt32(((HyperLink)GV.FindRowCellTemplateControl(i, colDoc, "HyperLink1")).Text.ToString());

                int mWFMovimientoPaso = Convert.ToInt32(((HiddenField)GV.FindRowCellTemplateControl(i, colOpc, "HFWFMovimientoPaso")).Value.ToString());
                DateTime mWFFechaMovimientoFin = DateTime.Now;

                int mWFMovimientoTipoini = Convert.ToInt32(hdWfMovTipo.Value.ToString());

                TextBox TxtNewNotas = ((TextBox)GV.FindRowCellTemplateControl(i, colPit, "TextBox4"));
                string mWFMovimientoNotas = TxtNewNotas.Text;
                string mGrupoCodigo = ((HiddenField)GV.FindRowCellTemplateControl(i, colOpc, "HFGrupo")).Value.ToString();
                string mDependenciaCodOrigen = Profile.GetProfile(User.Identity.Name).CodigoDepUsuario.ToString();

                DateTime mWFMovimientoFecha = DateTime.Now;
                DateTime mWFMovimientoFechaEst = DateTime.Now;
                string mWFMovimientoMultitarea = "1";
                DSWorkFlowTableAdapters.WFMovimientoTableAdapter TAWFMovimiento = new DSWorkFlowTableAdapters.WFMovimientoTableAdapter();

                TAWFMovimiento.WFMovimiento_UpdateWFMovimientoCopia(mNumeroDocumento,
                                                   mWFMovimientoPaso,
                                                   mWFFechaMovimientoFin,
                                                   mWFMovimientoTipoini,
                                                   mWFMovimientoNotas,
                                                   mGrupoCodigo,
                                                   mDependenciaCodOrigen,
                                                   mWFMovimientoMultitarea);

                this.LblMessageBox.Text += string.Format("Se descargo el documento {0}", mNumeroDocumento);
                this.LblMessageBox.Text += " de su escritorio<br />";
            }
        }
        if (atLeastOneRowSelected == true)
        {
            GV.DataBind();
            ODS.DataBind();
            LblLocal.Text = ((DataView)(ODS.Select())).Table.Rows.Count.ToString();
            this.MPEMensaje.Show();
        }
        else
        {
            this.LblMessageBox.Text = "No selecciono documentos para descargar de su escritorio.";
            this.MPEMensaje.Show();
        }
    }

    /*Sobrescritura del método de terminar tarea*/
    protected void Terminartarea(ASPxGridView GV, ObjectDataSource ODS, Label LblLocal)
    {
        ////////////////////////////////////////////////
        MembershipUser user = Membership.GetUser();
        Object CodigoRuta = user.ProviderUserKey;
        String UserId = Convert.ToString(CodigoRuta);
        ////////////////////////////////////////////////

        try
        {
            bool atLeastOneRowSelected = false;
            // Iterate through the Products.Rows property

            // The visible index of the fist row within the current page. 
            int startVisibleIndex = GV.VisibleStartIndex;
            // The number of visible rows displayed within the current page. 
            int visibleRowCount = GV.GetCurrentPageRowValues("V.B").Count;
            // The visible index of the last row within the current page. 
            int endVisibleIndex = startVisibleIndex + visibleRowCount - 1;


            for (int i = startVisibleIndex; i <= endVisibleIndex; i++)
            {
                GridViewDataColumn colVB = GV.Columns["V.B"] as GridViewDataColumn;

                GridViewDataColumn colOpc = GV.Columns["Opciones"] as GridViewDataColumn;

                GridViewDataColumn colRpta = GV.Columns["Rpta"] as GridViewDataColumn;

                /*Revisa el checkBox*/
                CheckBox ch1 = (CheckBox)GV.FindRowCellTemplateControl(i, colVB, "SelectorDocumento");

                HiddenField hdWfMovTipo = (HiddenField)GV.FindRowCellTemplateControl(i, colOpc, "HFWFMovimiento");

                if (ch1 != null && ch1.Checked)
                {
                    //// Delete row! (Well, not really...)
                    atLeastOneRowSelected = true;

                    /*Si se va el radicado normal (1)*/
                    if (hdWfMovTipo.Value == "1")
                    {
                        //// First, get the DocumentID for the selected row
                        GridViewDataColumn colDoc = GV.Columns[1] as GridViewDataColumn;
                        int mNumeroDocumento = Convert.ToInt32(((HyperLink)GV.FindRowCellTemplateControl(i, colDoc, "HyperLink1")).Text.ToString());
                        GridViewDataColumn colCarga = GV.Columns["Cargar a:"] as GridViewDataColumn;
                        TextBox TxtDepDesitno = ((TextBox)GV.FindRowCellTemplateControl(i, colCarga, "TxtCargarDocVen"));


                        HiddenField mHFCarga = ((HiddenField)GV.FindRowCellTemplateControl(i, colCarga, "HFCargar"));
                        RadioButton rbSerie = (RadioButton)GV.FindRowCellTemplateControl(i, colCarga, "RadBtnLastFindbySerie");
                        if (rbSerie.Checked)
                        {
                            mHFCarga.Value = "Serie";
                        }

                        if (TxtDepDesitno.Text != "")
                        {
                            if (TxtDepDesitno.Text.Contains(" | "))
                            {
                                TxtDepDesitno.Text = TxtDepDesitno.Text.Remove(TxtDepDesitno.Text.IndexOf(" | "));
                            }
                            else
                            {
                                TxtDepDesitno.Text = null;
                            }
                        }
                        else
                        {
                            TxtDepDesitno.Text = null;
                        }

                        string mDependenciaCodOrigen = Profile.GetProfile(User.Identity.Name).CodigoDepUsuario.ToString();
                        GridViewDataColumn colAccion = GV.Columns["Acci&#243;n:"] as GridViewDataColumn;
                        TextBox TxtNewAccion = ((TextBox)GV.FindRowCellTemplateControl(i, colAccion, "TxtAccionDocExtVen"));
                        string mWFAccionCodigo = TxtNewAccion.Text;
                        if (mWFAccionCodigo != "")
                        {
                            if (mWFAccionCodigo.Contains(" | "))
                            {
                                mWFAccionCodigo = mWFAccionCodigo.Remove(mWFAccionCodigo.IndexOf(" | "));
                            }
                            else
                            {
                                mWFAccionCodigo = null;
                                TxtNewAccion.Text = null;
                            }
                        }
                        else
                        {
                            mWFAccionCodigo = null;
                            TxtNewAccion.Text = null;
                        }

                        int mWFMovimientoPaso = Convert.ToInt32(((HiddenField)GV.FindRowCellTemplateControl(i, colOpc, "HFWFMovimientoPaso")).Value.ToString());
                        int mWFMovimientoPasoActual = 1;
                        int mWFMovimientoPasoFinal = 0;
                        int mWFMovimientoTipoini = Convert.ToInt32(hdWfMovTipo.Value.ToString());
                        GridViewDataColumn colPit = GV.Columns["Post<br/>It"] as GridViewDataColumn;
                        TextBox TxtNewNotas = ((TextBox)GV.FindRowCellTemplateControl(i, colPit, "TextBox4"));
                        string mWFMovimientoNotas = TxtNewNotas.Text;
                        string mGrupoCodigo = ((HiddenField)GV.FindRowCellTemplateControl(i, colOpc, "HFGrupo")).Value.ToString();
                        DateTime mWFMovimientoFecha = DateTime.Now;
                        DateTime mWFMovimientoFechaEst = DateTime.Now;
                        DateTime mWFFechaMovimientoFin = DateTime.Now;
                        string mWFProcesoCodigo = null;
                        string mSerieCodigo;
                        string mDependenciaCodDestino;
                        string mWFMovimientoMultitarea;
                        int mWFMovimientoTipo;

                        if ((mHFCarga.Value == "Dependencia" || mHFCarga.Value == "") && TxtDepDesitno.Text != "" && TxtNewAccion.Text != "")
                        {
                            mDependenciaCodDestino = TxtDepDesitno.Text;
                            if (TxtDepDesitno.Text == "")
                                mDependenciaCodDestino = null;
                            mSerieCodigo = null;
                            mWFMovimientoMultitarea = "0";
                            mWFMovimientoTipo = 1;

                            DSWorkFlowTableAdapters.WFMovimientoTableAdapter TAWFMovimiento = new DSWorkFlowTableAdapters.WFMovimientoTableAdapter();
                            TAWFMovimiento.InsertaWFMovimiento(mNumeroDocumento,
                                                               mDependenciaCodDestino,
                                                               mWFMovimientoPaso,
                                                               mWFMovimientoPasoActual,
                                                               mWFMovimientoPasoFinal,
                                                               mWFFechaMovimientoFin,
                                                               mWFMovimientoTipo,
                                                               mWFMovimientoTipoini,
                                                               mWFMovimientoNotas,
                                                               mGrupoCodigo,
                                                               mDependenciaCodOrigen,
                                                               mWFProcesoCodigo,
                                                               mWFAccionCodigo,
                                                               mWFMovimientoFecha,
                                                               mWFMovimientoFechaEst,
                                                               mSerieCodigo,
                                                               mWFMovimientoMultitarea,
                                                               UserId
                                                               );

                            /*Registrar el evento Dependencia*/
                            String Ip_cliente = Context.Request.UserHostAddress;
                            //LOG WORKFLOW GESTIONAR A DEPENDENCIAS-13/06/2019 Juan Figueredo
                            string ActLogCod = "Gestionar a Dependencia";
                            DateTime WFMovimientoFecha = DateTime.Now;
                            //OBTENER CONSECUTIVO DE LOGS
                            DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter Consecutivos = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                            DSGrupoSQL.ConsecutivoLogsDataTable Conse = new DSGrupoSQL.ConsecutivoLogsDataTable();
                            Conse = Consecutivos.GetConseActual(ConsecutivoCodigo);
                            DataRow[] fila = Conse.Select();
                            string x = fila[0].ItemArray[0].ToString();
                            string LOG = Convert.ToString(x);
                            //Se Realiza el Log
                            int NumeroDocumento = mNumeroDocumento;
                            string GrupoCodigo = mGrupoCodigo;
                            string Datosini = "Gestion de documento";
                            // Dependencia Destino + Cargar A + Post it + Accion
                            string Datosfin1 = mDependenciaCodDestino + TxtDepDesitno.Text + mWFMovimientoNotas + mWFAccionCodigo;
                            string username = Profile.GetProfile(Profile.UserName).UserName.ToString();
                            DSUsuarioTableAdapters.UserIdByUserNameTableAdapter objUsr = new DSUsuarioTableAdapters.UserIdByUserNameTableAdapter();
                            string UsrId = objUsr.Aspnet_UserIDByUserName(username).ToString();
                            DateTime FechaFin = DateTime.Now;
                            Int64 LogId = Convert.ToInt64(LOG);
                            string IP = Session["IP"].ToString();
                            string NombreEquipo = Session["Nombrepc"].ToString();
                            System.Web.HttpBrowserCapabilities nav = Request.Browser;
                            string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
                            Session["Navega"] = Navegador;
                            DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter Accediendo = new DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter();
                            //Se inserta Log de workflow Gestionar documento
                            Accediendo.GetInsertLogWF(LogId, username, WFMovimientoFecha, ActLogCod, NumeroDocumento, GrupoCodigo, ModuloLog,
                                                Datosini, Datosfin1, FechaFin, IP, NombreEquipo, Navegador);
                            //Se actualiza el consecutivo Log
                            DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                            ConseLogs.GetConsecutivos(ConsecutivoCodigo);

                            TreeView TreeMulti = ((TreeView)(GV.FindRowCellTemplateControl(i, colCarga, "TreeVMultitarea")));

                            foreach (TreeNode myNode in TreeMulti.CheckedNodes)
                            {
                                mWFMovimientoMultitarea = "1";
                                mSerieCodigo = null;
                                mDependenciaCodDestino = null;
                                mWFAccionCodigo = "2";
                                if (mGrupoCodigo == "1")
                                {
                                    mWFMovimientoTipo = 2;
                                }
                                else if (mGrupoCodigo == "2")
                                {
                                    mWFMovimientoTipo = 6;
                                }

                                mDependenciaCodDestino = myNode.Value;

                                TAWFMovimiento.InsertaWFMovimiento(mNumeroDocumento,
                                                                   mDependenciaCodDestino,
                                                                   mWFMovimientoPaso,
                                                                   mWFMovimientoPasoActual,
                                                                   mWFMovimientoPasoFinal,
                                                                   mWFFechaMovimientoFin,
                                                                   mWFMovimientoTipo,
                                                                   mWFMovimientoTipoini,
                                                                   mWFMovimientoNotas,
                                                                   mGrupoCodigo,
                                                                   mDependenciaCodOrigen,
                                                                   mWFProcesoCodigo,
                                                                   mWFAccionCodigo,
                                                                   mWFMovimientoFecha,
                                                                   mWFMovimientoFechaEst,
                                                                   mSerieCodigo,
                                                                   mWFMovimientoMultitarea,
                                                                   UserId
                                                                   );
                                /*Registrar el evento Dependencia*/

                            }
                            string Detalle = null;
                            MailBLL Correo = new MailBLL();
                            MembershipUser usuario;
                            DSUsuarioTableAdapters.UsuariosxdependenciaTableAdapter ObjTaUsuarioxDependencia = new DSUsuarioTableAdapters.UsuariosxdependenciaTableAdapter();
                            DSUsuario.UsuariosxdependenciaDataTable DTUsuariosxDependencia = new DSUsuario.UsuariosxdependenciaDataTable();
                            DTUsuariosxDependencia = ObjTaUsuarioxDependencia.GetUsuariosxDependenciaByDependencia(mDependenciaCodDestino);
                            if (mGrupoCodigo == "1")
                            {
                                DSRadicadoTableAdapters.Radicado_DetalleTableAdapter Radicado = new DSRadicadoTableAdapters.Radicado_DetalleTableAdapter();
                                DSRadicado.Radicado_DetalleDataTable Radi = new DSRadicado.Radicado_DetalleDataTable();
                                Radi = Radicado.GetData(mNumeroDocumento);
                                Detalle = Radi.Rows[0].ItemArray[0].ToString().Trim();
                            }
                            else if (mGrupoCodigo == "2")
                            {
                                DSRegistroTableAdapters.Registro_DetalleTableAdapter Registro = new DSRegistroTableAdapters.Registro_DetalleTableAdapter();
                                DSRegistro.Registro_DetalleDataTable Regi = new DSRegistro.Registro_DetalleDataTable();
                                Regi = Registro.GetData(mNumeroDocumento);
                                Detalle = Regi.Rows[0].ItemArray[0].ToString().Trim();
                            }
                            if (DTUsuariosxDependencia.Count > 0)
                            {
                                DataRow[] rows = DTUsuariosxDependencia.Select();
                                System.Guid a = new Guid(rows[0].ItemArray[0].ToString().Trim());
                                usuario = Membership.GetUser(a);
                                mWFAccionCodigo = TxtNewAccion.Text;
                                string Body = "Tiene una nueva Tarea Nro " + mNumeroDocumento + "<BR>" + " Fecha de Radicacion: " +
                                DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString() + "<BR>" +
                                " Accion: " + mWFAccionCodigo + "<BR>"
                                + " Detalle: " + Detalle + "<BR>"; 
                                Correo.EnvioCorreo(emailFrom, usuario.Email, "Tarea Nro" + " " + mNumeroDocumento, Body, true, "1");
                            }
                        }

                        else if (mHFCarga.Value == "Serie" && TxtDepDesitno.Text != "")
                        {
                            if (TxtDepDesitno.Text == "")
                            {
                                mSerieCodigo = null;
                                mDependenciaCodDestino = null;
                            }
                            else
                            {
                                mSerieCodigo = TxtDepDesitno.Text;
                                mDependenciaCodDestino = mDependenciaCodOrigen;
                            }
                            mWFMovimientoMultitarea = "0";
                            mWFMovimientoTipo = 3;
                            if (mWFAccionCodigo == null)
                                mWFAccionCodigo = "2";
                            DSWorkFlowTableAdapters.WFMovimientoTableAdapter TAWFMovimiento = new DSWorkFlowTableAdapters.WFMovimientoTableAdapter();
                            TAWFMovimiento.InsertaWFMovimiento(mNumeroDocumento,
                                                               mDependenciaCodDestino,
                                                               mWFMovimientoPaso,
                                                               0,
                                                               1,
                                                               mWFFechaMovimientoFin,
                                                               mWFMovimientoTipo,
                                                               mWFMovimientoTipoini,
                                                               mWFMovimientoNotas,
                                                               mGrupoCodigo,
                                                               mDependenciaCodOrigen,
                                                               mWFProcesoCodigo,
                                                               mWFAccionCodigo,
                                                               mWFMovimientoFecha,
                                                               mWFMovimientoFechaEst,
                                                               mSerieCodigo,
                                                               mWFMovimientoMultitarea,
                                                               UserId
                                                               );
                            /*Registrar el evento Dependencia*/
                            String Ip_cliente = Context.Request.UserHostAddress;
                            //LOG WORKFLOW ARCHIVAR EN SERIE. -13/06/2019 Juan Figueredo
                            string ActLogCod = "Archivar";
                            DateTime WFMovimientoFecha = DateTime.Now;
                            //OBTENER CONSECUTIVO DE LOGS
                            DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter Consecutivos = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                            DSGrupoSQL.ConsecutivoLogsDataTable Conse = new DSGrupoSQL.ConsecutivoLogsDataTable();
                            Conse = Consecutivos.GetConseActual(ConsecutivoCodigo);
                            DataRow[] fila = Conse.Select();
                            string x = fila[0].ItemArray[0].ToString();
                            string LOG = Convert.ToString(x);
                            //Se Realiza el Log
                            int NumeroDocumento = mNumeroDocumento;
                            string GrupoCodigo = mGrupoCodigo;
                            string Datosini = "Archivar en una serie";
                            // Dependencia Destino + Archivar en + Post it + Accion
                            string Datosfin1 = mDependenciaCodDestino + mSerieCodigo + mWFMovimientoNotas + mWFAccionCodigo;
                            string username = Profile.GetProfile(Profile.UserName).UserName.ToString();
                            DSUsuarioTableAdapters.UserIdByUserNameTableAdapter objUsr = new DSUsuarioTableAdapters.UserIdByUserNameTableAdapter();
                            string UsrId = objUsr.Aspnet_UserIDByUserName(username).ToString();
                            DateTime FechaFin = DateTime.Now;
                            Int64 LogId = Convert.ToInt64(LOG);
                            string IP = Session["IP"].ToString();
                            string NombreEquipo = Session["Nombrepc"].ToString();
                            System.Web.HttpBrowserCapabilities nav = Request.Browser;
                            string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
                            Session["Navega"] = Navegador;
                            DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter Accediendo = new DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter();
                            //Se inserta Log de workflow Archivar documento
                            Accediendo.GetInsertLogWF(LogId, username, WFMovimientoFecha, ActLogCod, NumeroDocumento, GrupoCodigo, ModuloLog,
                                                Datosini, Datosfin1, FechaFin, IP, NombreEquipo, Navegador);
                            //Se actualiza el consecutivo Log
                            DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                            ConseLogs.GetConsecutivos(ConsecutivoCodigo);
                        }
                        else if (mHFCarga.Value == "Finalizar")
                        {
                            mWFMovimientoMultitarea = "0";
                            DSWorkFlowTableAdapters.WFMovimientoTableAdapter TAWFMovimiento = new DSWorkFlowTableAdapters.WFMovimientoTableAdapter();

                            TAWFMovimiento.WFMovimiento_UpdateWFMovimientoCopia(mNumeroDocumento,
                                                               mWFMovimientoPaso,
                                                               mWFFechaMovimientoFin,
                                                               mWFMovimientoTipoini,
                                                               mWFMovimientoNotas,
                                                               mGrupoCodigo,
                                                               mDependenciaCodOrigen,
                                                               mWFMovimientoMultitarea);
                        }
                        else
                        {
                            this.LblMessageBox.Text += "Falta uno o mas parametros pàra descargar la tarea. ";
                        }
                        this.LblMessageBox.Text += string.Format("Se descargo el documento {0}", mNumeroDocumento);
                        this.LblMessageBox.Text += " de su escritorio<br />";
                        this.MPEMensaje.Show();
                    }
                    else if (hdWfMovTipo.Value == "4") /*Si se va el radicado por proceso (4)*/
                    {
                        GridViewDataColumn colDoc = GV.Columns[1] as GridViewDataColumn;
                        GridViewDataColumn colPit = GV.Columns["Post<br/>It"] as GridViewDataColumn;
                        int mNumeroDocumento = Convert.ToInt32(((HyperLink)GV.FindRowCellTemplateControl(i, colDoc, "HyperLink1")).Text.ToString());
                        int mWFMovimientoPaso = Convert.ToInt32(((HiddenField)GV.FindRowCellTemplateControl(i, colOpc, "HFWFMovimientoPaso")).Value.ToString());
                        DateTime mWFFechaMovimientoFin = DateTime.Now;
                        int mWFMovimientoTipoini = Convert.ToInt32(((HiddenField)GV.FindRowCellTemplateControl(i, colOpc, "HFWFMovimiento")).Value.ToString());
                        TextBox TxtNewNotas = ((TextBox)GV.FindRowCellTemplateControl(i, colPit, "TextBox4"));
                        string mWFMovimientoNotas = TxtNewNotas.Text;
                        string mGrupoCodigo = ((HiddenField)GV.FindRowCellTemplateControl(i, colOpc, "HFGrupo")).Value.ToString();
                        string mDependenciaCodOrigen = Profile.GetProfile(User.Identity.Name).CodigoDepUsuario.ToString();
                        string mWFProcesoCodigo = ((HiddenField)GV.FindRowCellTemplateControl(i, colOpc, "HFProceso")).Value.ToString();
                        DateTime mWFMovimientoFecha = DateTime.Now;
                        DateTime mWFMovimientoFechaEst = DateTime.Now;
                        string mWFMovimientoMultitarea = "0";

                        DSWorkFlowTableAdapters.WFMovimientos_CreateRadicadoProcesosTableAdapter TAWFMovPro = new DSWorkFlowTableAdapters.WFMovimientos_CreateRadicadoProcesosTableAdapter();

                        TAWFMovPro.WFMovimientos_CreateRadicadoProcesos(mNumeroDocumento,
                                                                        mWFMovimientoPaso,
                                                                        1,
                                                                        0,
                                                                        mWFFechaMovimientoFin,
                                                                        mWFMovimientoTipoini,
                                                                        mWFMovimientoTipoini,
                                                                        mWFMovimientoNotas,
                                                                        mGrupoCodigo,
                                                                        mDependenciaCodOrigen,
                                                                        mWFProcesoCodigo,
                                                                        mWFMovimientoFecha,
                                                                        mWFMovimientoFechaEst,
                                                                        mWFMovimientoMultitarea);

                        /*Registrar el evento Dependencia*/
                        String Ip_cliente = Context.Request.UserHostAddress;
                        string ActLogCod = "Gestionar a Proceso";
                        DateTime WFMovimientoFecha = DateTime.Now;
                        //OBTENER CONSECUTIVO DE LOGS
                        DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter Consecutivos = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                        DSGrupoSQL.ConsecutivoLogsDataTable Conse = new DSGrupoSQL.ConsecutivoLogsDataTable();
                        Conse = Consecutivos.GetConseActual(ConsecutivoCodigo);
                        DataRow[] fila = Conse.Select();
                        string x = fila[0].ItemArray[0].ToString();
                        string LOG = Convert.ToString(x);
                        //Se Realiza el Log
                        int NumeroDocumento = mNumeroDocumento;
                        string GrupoCodigo = mGrupoCodigo;
                        string Datosini = "Proceso";
                        // Cod proceso + Grupo Cod + Post it + Dependencia origen
                        string Datosfin1 = mWFProcesoCodigo + mGrupoCodigo + mWFMovimientoNotas + mDependenciaCodOrigen;
                        string username = Profile.GetProfile(Profile.UserName).UserName.ToString();
                        DSUsuarioTableAdapters.UserIdByUserNameTableAdapter objUsr = new DSUsuarioTableAdapters.UserIdByUserNameTableAdapter();
                        string UsrId = objUsr.Aspnet_UserIDByUserName(username).ToString();
                        DateTime FechaFin = DateTime.Now;
                        Int64 LogId = Convert.ToInt64(LOG);
                        string IP = Session["IP"].ToString();
                        string NombreEquipo = Session["Nombrepc"].ToString();
                        System.Web.HttpBrowserCapabilities nav = Request.Browser;
                        string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
                        Session["Navega"] = Navegador;
                        DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter Accediendo = new DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter();
                        //Se inserta Log de workflow Archivar documento
                        Accediendo.GetInsertLogWF(LogId, username, WFMovimientoFecha, ActLogCod, NumeroDocumento, GrupoCodigo, ModuloLog, Datosini, Datosfin1, FechaFin, IP, NombreEquipo, Navegador);
                        //Se actualiza el consecutivo Log
                        DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                        ConseLogs.GetConsecutivos(ConsecutivoCodigo);
                        this.LblMessageBox.Text += string.Format("Se descargo el documento {0}", mNumeroDocumento);
                        this.LblMessageBox.Text += " de su escritorio<br />";
                    }
                }
            }
            if (atLeastOneRowSelected == true)
            {
                ODS.DataBind();
                GV.DataBind();
                LblLocal.Text = ((DataView)(ODS.Select())).Table.Rows.Count.ToString();
                LblDocRecExt.Text = LblDocRecExt.Text = (Convert.ToInt16(LblDocRecExtVen.Text) + Convert.ToInt16(LblDocRecExtProxVen.Text) + Convert.ToInt16(LblDocRecExtPen.Text) + Convert.ToInt16(LblDocRecCopia.Text)).ToString();
                this.MPEMensaje.Show();
            }
            else
            {
                this.LblMessageBox.Text = "No selecciono documentos para descargar de su escritorio.";
                this.MPEMensaje.Show();
            }
        }
        catch (Exception Error)
        {
            ODS.DataBind();
            GV.DataBind();
            //Display a user-friendly message
            this.LblMessageBox.Text = "Ocurrio un problema al tratar de descargar el documento. ";
            Exception inner = Error.InnerException;
            this.LblMessageBox.Text += ErrorHandled.FindError(inner);
            this.LblMessageBox.Text += Error.Message.ToString();
            this.MPEMensaje.Show();
        }
        finally
        {

        }
    }
    protected void image4_onclick(object sender, ImageClickEventArgs e)
    {
        if (ASPxGVDocRecExtPen.DataSourceID == "")
        {
            ASPxGVDocRecExtPen.DataSourceID = this.ODSDocRecExtPen.ID.ToString();

            this.CPExtender4.Collapsed = false;
            this.CPExtender4.ClientState = false.ToString();

        }
        else
        {
            ASPxGVDocRecExtPen.DataSourceID = "";
            this.CPExtender4.Collapsed = true;
            this.CPExtender4.ClientState = true.ToString();
        }
    }
    protected void Image2_Click(object sender, ImageClickEventArgs e)
    {
        if (ASPxGVDocRecExtVen.DataSourceID == "")
        {
            ASPxGVDocRecExtVen.DataSourceID = ODSDocRecExtVen.ID.ToString();

            this.CPExtender2.Collapsed = false;
            this.CPExtender2.ClientState = false.ToString();

        }
        else
        {
            ASPxGVDocRecExtVen.DataSourceID = "";
            this.CPExtender2.Collapsed = true;
            this.CPExtender2.ClientState = true.ToString();

        }
    }
    protected void Image3_Click(object sender, ImageClickEventArgs e)
    {
        if (ASPxGVDocRecExtProxVen.DataSourceID == "")
        {
            ASPxGVDocRecExtProxVen.DataSourceID = ODSDocRecExtProxVen.ID.ToString();

            this.CPExtender3.Collapsed = false;
            this.CPExtender3.ClientState = false.ToString();

        }
        else
        {
            ASPxGVDocRecExtProxVen.DataSourceID = "";
            this.CPExtender3.Collapsed = true;
            this.CPExtender3.ClientState = true.ToString();

        }
    }
    protected void ImageBtnCopia_Click(object sender, ImageClickEventArgs e)
    {
        if (ASPxGVDocRecExtCopia.DataSourceID == "")
        {
            ASPxGVDocRecExtCopia.DataSourceID = ODSDocRecCopia.ID.ToString();
            this.CPEDocRecCopia.Collapsed = false;
            this.CPEDocRecCopia.ClientState = false.ToString();
        }
        else
        {
            ASPxGVDocRecExtCopia.DataSourceID = "";
            this.CPEDocRecCopia.Collapsed = true;
            this.CPEDocRecCopia.ClientState = true.ToString();

        }
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        if (ASPxGVDocEnvExtCopia.DataSourceID == "")
        {
            ASPxGVDocEnvExtCopia.DataSourceID = ODSDocEnvExtCopia.ID.ToString();
            this.CollapsiblePanelExtender1.Collapsed = false;
            this.CollapsiblePanelExtender1.ClientState = false.ToString();
        }
        else
        {
            ASPxGVDocEnvExtCopia.DataSourceID = "";
            this.CollapsiblePanelExtender1.Collapsed = true;
            this.CollapsiblePanelExtender1.ClientState = true.ToString();
        }
    }
    protected void ImageButton6_Click(object sender, ImageClickEventArgs e)
    {
        if (ASPxGVDocEnvIntVen.DataSourceID == "")
        {
            ASPxGVDocEnvIntVen.DataSourceID = ODSDocEnvIntVen.ID.ToString();
            this.CollapsiblePanelExtender5.Collapsed = false;
            this.CollapsiblePanelExtender5.ClientState = false.ToString();
        }
        else
        {
            ASPxGVDocEnvIntVen.DataSourceID = "";
            this.CollapsiblePanelExtender5.Collapsed = true;
            this.CollapsiblePanelExtender5.ClientState = true.ToString();
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (ASPxGVDocEnvIntCopia.DataSourceID == "")
        {
            ASPxGVDocEnvIntCopia.DataSourceID = ODSDocEnvIntCopia.ID.ToString();
            this.CollapsiblePanelExtender2.Collapsed = false;
            this.CollapsiblePanelExtender2.ClientState = false.ToString();
        }
        else
        {
            ASPxGVDocEnvIntCopia.DataSourceID = "";
            this.CollapsiblePanelExtender2.Collapsed = true;
            this.CollapsiblePanelExtender2.ClientState = true.ToString();
        }
    }
}