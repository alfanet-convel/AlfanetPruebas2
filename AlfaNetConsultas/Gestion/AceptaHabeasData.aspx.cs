using System;
using ASP;
using Microsoft;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DSRadicadoTableAdapters;
using DSGrupoSQLTableAdapters;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Collections;
using System.Collections.Generic;
using AjaxControlToolkit;
using System.Text;
using DevExpress.Utils;
using System.IO;
using DevExpress.XtraCharts;
using DevExpress.XtraExport;
using System.Drawing;
using DevExpress.Web;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxCallbackPanel;
//using log4net;
//using System.Drawing;


public partial class AceptaHabeasData : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                //DDLOtros.SelectedValue = null;
                this.AccordionPane3.Visible = false;
                this.AccordionPane2.Visible = true;
            }
            else
            {
                ASPxGridView1.Columns[1].CellStyle.HorizontalAlign = HorizontalAlign.Center;
                ASPxGridView1.Columns[3].CellStyle.HorizontalAlign = HorizontalAlign.Center;
                ASPxGridView1.Columns[5].CellStyle.HorizontalAlign = HorizontalAlign.Center;
            }

        }
        catch (Exception Error)
        {
            this.ExceptionDetails.Text = "Problema" + Error;
        }
    }
    protected void ChBFechaRad_CheckedChanged(object sender, EventArgs e)
    {
        if (ChBFechaRad.Checked == true)
        {
            this.LblFechaFinal.Visible = true;
            this.LblFechaInicial.Visible = true;
            this.TxtFechaFinal.Visible = true;
            this.TxtFechaInicial.Visible = true;
            this.ImgCalendarFinal.Visible = true;
            this.ImgCalendarInicial.Visible = true;
        }
        else
        {
            this.LblFechaFinal.Visible = false;
            this.LblFechaInicial.Visible = false;
            this.TxtFechaFinal.Visible = false;
            this.TxtFechaInicial.Visible = false;
            this.TxtFechaFinal.Text = "";
            this.TxtFechaInicial.Text = "";
            this.ImgCalendarFinal.Visible = false;
            this.ImgCalendarInicial.Visible = false;
        }
    }
    protected void ChBNroRad_CheckedChanged(object sender, EventArgs e)
    {
        if (ChBNroRad.Checked == true)
        {
            this.LblNroRadFinal.Visible = true;
            this.LblNroRadInicial.Visible = true;
            this.TxtNroRadFinal.Visible = true;
            this.TxtNroRadInicial.Visible = true;

        }
        else
        {
            this.LblNroRadFinal.Visible = false;
            this.LblNroRadInicial.Visible = false;
            this.TxtNroRadFinal.Visible = false;
            this.TxtNroRadInicial.Visible = false;
            this.TxtNroRadFinal.Text = "";
            this.TxtNroRadInicial.Text = "";
        }
    }
    protected void ChBProcedId_CheckedChanged(object sender, EventArgs e)
    {
        if (ChBProcedId.Checked == true)
        {
            this.LblProcedId.Visible = true;
            this.TxtProcedId.Visible = true;
        }
        else
        {
            this.LblProcedId.Visible = false;
            this.TxtProcedId.Visible = false;
            this.TxtProcedId.Text = "";
        }
    }
    //protected void ChBProcedencia_CheckedChanged(object sender, EventArgs e)
    //{
    //    if (ChBProcedencia.Checked == true)
    //    {
    //        this.LblProcedencia.Visible = true;
    //        this.TxtBProcedencia.Visible = true;
    //    }
    //    else
    //    {
    //        this.LblProcedencia.Visible = false;
    //        this.TxtBProcedencia.Visible = false;
    //        this.TxtBProcedencia.Text = "";
    //    }
    //}
    protected void chkAcepta_CheckedChanged(object sender, EventArgs e)
    {
        if (chkAcepta.Checked == true)
        {
            LblAcepta.Visible = true;
            RblAcepta.Visible = true;
        }
        else
        {
            LblAcepta.Visible = false;
            RblAcepta.Visible = false;
        }
    }



    protected void TreeVDependencia_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        ArbolesBLL ObjArbolDep = new ArbolesBLL();
        DSDependenciaSQL.DependenciaByTextDataTable DTDependencia = new DSDependenciaSQL.DependenciaByTextDataTable();
        DTDependencia = ObjArbolDep.GetDependenciaTree(e.Node.Value);
        PopulateNodes(DTDependencia, e.Node.ChildNodes, "DependenciaCodigo", "DependenciaNombre");
    }
    private void PopulateNodes(DataTable dt, TreeNodeCollection nodes, String Codigo, String Nombre)
    {
        foreach (DataRow dr in dt.Rows)
        {
            TreeNode tn = new TreeNode();
            //dr["title"].ToString();
            tn.Text = dr[Codigo].ToString() + " | " + dr[Nombre].ToString();
            tn.Value = dr[Codigo].ToString();
            nodes.Add(tn);

            //If node has child nodes, then enable on-demand populating
            tn.PopulateOnDemand = (Convert.ToInt32(dr["childnodecount"]) > 0);
        }
    }
    protected void cmdBuscar_Click(object sender, EventArgs e)
    {
        ////////////////////////////////////////////////
        MembershipUser user = Membership.GetUser();
        Object CodigoRuta = user.ProviderUserKey;
        String UserId = Convert.ToString(CodigoRuta);
        ////////////////////////////////////////////////

        string lotros = "";
        string dt_qw = "";

        try
        {

            this.ODSBuscarGraph.SelectParameters["WFMovimientoFecha"].DefaultValue = this.TxtFechaInicial.Text;
            this.ODSBuscarGraph.SelectParameters["WFMovimientoFecha1"].DefaultValue = this.TxtFechaFinal.Text;
            this.ODSBuscarGraph.SelectParameters["RadicadoCodigo"].DefaultValue = this.TxtNroRadInicial.Text;
            this.ODSBuscarGraph.SelectParameters["RadicadoCodigo1"].DefaultValue = this.TxtNroRadFinal.Text;
            //this.ODSBuscarGraph.SelectParameters["ExpedienteCodigo"].DefaultValue = ""; //Texto con AVISO PRIVACIDAD
            this.ODSBuscarGraph.SelectParameters["ProcedenciaCodigo"].DefaultValue = this.TxtProcedId.Text;
            this.ODSBuscarGraph.SelectParameters["ProcedenciaNombre"].DefaultValue = this.TxtProcedId.Text;
            this.ODSBuscarGraph.SelectParameters["DependenciaConsulta"].DefaultValue = Profile.GetProfile(Profile.UserName).CodigoDepUsuario.ToString();
            this.ODSBuscarGraph.SelectParameters["AceptaHabeasData"].DefaultValue = this.RblAcepta.SelectedValue.ToString();
            //this.ODSBuscarGraph.SelectParameters["DependenciaCodDestino"].DefaultValue = this.TxtProcedId.Text;
            //this.ODSBuscarGraph.SelectParameters["DependenciaNomDestino"].DefaultValue = this.TxtProcedId.Text;
            //this.ODSBuscarGraph.SelectParameters["NaturalezaCodigo"].DefaultValue = this.TxtBNaturaleza.Text;
            //this.ODSBuscarGraph.SelectParameters["NaturalezaNombre"].DefaultValue = this.TxtBNaturaleza.Text;


            if (this.RBLTblRpt.SelectedValue == "1")
            {
                this.AccordionPane2.Visible = true;
                this.AccordionPane3.Visible = false;

                ASPxGridView1.DataSourceID = "ODSBuscarGraph";
                ReportViewer1.LocalReport.DataSources[0].DataSourceId = "";
                ASPxGridView1.DataBind();

            }
            else
            {
                ASPxGridView1.DataSourceID = "";
                this.AccordionPane3.Visible = true;
                this.AccordionPane2.Visible = false;

                ReportViewer1.LocalReport.DataSources[0].DataSourceId = "ODSBuscarGraph";
                //Microsoft.Reporting.WebForms.ReportDataSource RDS = new Microsoft.Reporting.WebForms.ReportDataSource();
                //RDS.Name = ODSBuscarGraph.ToString();
                //RDS.Value = ODSBuscarGraph.Select();
                //this.ReportViewer1.LocalReport.DataSources.Add(RDS);
                this.ReportViewer1.DataBind();
            }

            this.MyAccordion.SelectedIndex = 1;


            /*Registrar el evento de busqueda*/
            String Ip_cliente = Context.Request.UserHostAddress;
            //String Uri_OrigRef = Context.Request.UrlReferrer.OriginalString;

            //log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


            //String Log = "6" + " " + this.TxtFechaInicial.Text + "?" + this.TxtFechaFinal.Text + "?" + this.TxtNroRadInicial.Text + "?" +
            //    this.TxtNroRadFinal.Text + "?" + this.TxtNroRadFinal.Text + "?" + value_pipe(this.TxtBExpediente.Text) + "?" +
            //    value_pipe(TxtBProcedencia.Text) + "?" + value_pipe(TxtBProcedencia.Text) + "?" + value_pipe(TxtBMedio.Text) + "?" + value_pipe(TxtProcedId.Text) + "?" + value_pipe(TxtProcedId.Text) + "?" +
            //    Profile.GetProfile(Profile.UserName).CodigoDepUsuario.ToString() + "?" + value_pipe(TxtBNaturaleza.Text) + "?" + lotros;


            //ILog logger = LogManager.GetLogger("primerEjemplo");
            //logger.Fatal(Ip_cliente +" "+ Log); 

            //logger.Debug("Mensaje de nivel DEBUG");
            //logger.Info("Mensaje de nivel INFO");
            //logger.Warn("Mensaje de nivel WARN");
            //logger.Error("Mensaje de nivel ERROR");
            //logger.Fatal("Mwnsaje de nivel FATAL"); 

            //rutinas r1 = new rutinas();
            //// DataTable t1 = r1.rtn_registrar_log("0", UserId, "5",
            //     this.TxtFechaInicial.Text + "?" + this.TxtFechaFinal.Text + "?" + this.TxtNroRadInicial.Text+ "?"+
            //     this.TxtNroRadFinal.Text + "?" + this.TxtNroRadFinal.Text + "?" + value_pipe(this.TxtBExpediente.Text) + "?" +
            //     value_pipe(TxtBProcedencia.Text) + "?" + value_pipe(TxtBProcedencia.Text) + "?" + value_pipe(TxtBMedio.Text) + "?" + value_pipe(TxtProcedId.Text) + "?" + value_pipe(TxtProcedId.Text) + "?" +
            //     Profile.GetProfile(Profile.UserName).CodigoDepUsuario.ToString() + "?" + value_pipe(TxtBNaturaleza.Text) + "?" + lotros
            //     , "1");


        }
        catch (Exception Error)
        {
            this.ExceptionDetails.Text = "Problema" + Error;
        }

    }


    /*Prodecimiento para devolver el id de un campo si este contiene separadores*/

    protected string value_pipe(string val_1)
    {
        string res = "";
        if (val_1 != "" && val_1 != null)
        {
            if (val_1.Contains(" | "))
            {
                res = val_1.Remove(val_1.IndexOf(" | "));
            }
            else
            {
                res = val_1;
            }
        }
        return res;
    }

    protected void BtnNuevo_Click(object sender, EventArgs e)
    {

    }
    protected void GVBuscar_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //RadicadoBLL ObjConsultaRad = new RadicadoBLL();
        //DSRadicado.Radicado_ConsultasRadicadoDataTable ConsultaRadicado = new DSRadicado.Radicado_ConsultasRadicadoDataTable();
        //if (DDLOtros.SelectedValue == "")
        //    ConsultaRadicado = ObjConsultaRad.GetConsultasRadicado(this.TxtFechaInicial.Text, this.TxtFechaFinal.Text, this.TxtNroRadInicial.Text, this.TxtNroRadFinal.Text, this.TxtBExpediente.Text, this.TxtBProcedencia.Text, this.TxtBMedio.Text, this.TxtProcedId.Text, null, null, null, this.TxtBNaturaleza.Text);
        //else if (DDLOtros.SelectedValue == "Detalle")
        //    ConsultaRadicado = ObjConsultaRad.GetConsultasRadicado(this.TxtFechaInicial.Text, this.TxtFechaFinal.Text, this.TxtNroRadInicial.Text, this.TxtNroRadFinal.Text, this.TxtBExpediente.Text, this.TxtBProcedencia.Text, this.TxtBMedio.Text, this.TxtProcedId.Text, this.TxtBOtros.Text.ToString(), null, null, this.TxtBNaturaleza.Text);
        //else if (DDLOtros.SelectedValue == "NroExterno")
        //    ConsultaRadicado = ObjConsultaRad.GetConsultasRadicado(this.TxtFechaInicial.Text, this.TxtFechaFinal.Text, this.TxtNroRadInicial.Text, this.TxtNroRadFinal.Text, this.TxtBExpediente.Text, this.TxtBProcedencia.Text, this.TxtBMedio.Text, this.TxtProcedId.Text, null, this.TxtBOtros.Text.ToString(), null, this.TxtBNaturaleza.Text);
        //else if (DDLOtros.SelectedValue == "Anexo")
        //    ConsultaRadicado = ObjConsultaRad.GetConsultasRadicado(this.TxtFechaInicial.Text, this.TxtFechaFinal.Text, this.TxtNroRadInicial.Text, this.TxtNroRadFinal.Text, this.TxtBExpediente.Text, this.TxtBProcedencia.Text, this.TxtBMedio.Text, this.TxtProcedId.Text, null, null, this.TxtBOtros.Text.ToString(), this.TxtBNaturaleza.Text);
        //GVBuscar.DataSource = ConsultaRadicado;
        //this.GVBuscar.PageIndex = e.NewPageIndex;
        //this.GVBuscar.DataBind();
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {

        //String RadicadoCodigo = GVBuscar.DataKeys[dato1].Value.ToString();
        ////String RadicadoCodigo = GVBuscar.SelectedDataKey.Value.ToString();
        ////String RadicadoCodigo = this.GVBuscar.SelectedValue.ToString();
        //Session["NroDoc"] = "1" + RadicadoCodigo;
        //Response.Redirect("~/AlfaNetImagen/VisorImagenes/VisorImagenes.aspx");
    }
    protected void ButtonOpen_Click(object sender, EventArgs e)
    {
        Export(false);
    }
    protected void ButtonSaveAs_Click(object sender, EventArgs e)
    {
        Export(true);
    }
    protected void Export(Boolean saveAs)
    {
        DevExpress.Utils.Paint.XPaint.ForceGDIPlusPaint();
        MemoryStream stream = new MemoryStream();
        String contentType = "";
        String fileName = "";


        //this.ASPxGridViewExporter1.OptionsPrint.PrintHeadersOnEveryPage = true;
        //this.ASPxGridViewExporter1.OptionsPrint.PrintFilterHeaders = DefaultBoolean.True;
        //this.ASPxGridViewExporter1.OptionsPrint.PrintColumnHeaders = DefaultBoolean.True;
        //this.ASPxGridViewExporter1.OptionsPrint.PrintRowHeaders = DefaultBoolean.True;
        //this.ASPxGridViewExporter1.OptionsPrint.PrintDataHeaders = DefaultBoolean.True;
        //this.ASPxGridViewExporter1.ReportHeader.

        int caseSwitch = 1;
        switch (this.listExportFormat.SelectedIndex)
        {
            case 0:
                contentType = "application/pdf";
                fileName = "PivotGrid.pdf";
                this.ASPxGridViewExporter1.WritePdf(stream);
                break;
            case 1:
                contentType = "application/ms-excel";
                fileName = "PivotGrid.xls";
                this.ASPxGridViewExporter1.WriteXls(stream);
                break;
            case 2:
                contentType = "text/enriched";
                fileName = "PivotGrid.rtf";
                this.ASPxGridViewExporter1.WriteRtf(stream);
                break;
            case 3:
                contentType = "text/plain";
                fileName = "PivotGrid.txt";
                this.ASPxGridViewExporter1.WriteCsv(stream);
                break;
        }
        Byte[] buffer = stream.GetBuffer();
        // Dim buffer() As Byte = stream.GetBuffer()

        String disposition;
        if (saveAs)
        {
            disposition = "attachment";
        }
        else
        {
            disposition = "inline";
        }
        if (listExportFormat.SelectedIndex != -1)
        {
            Response.Clear();
            Response.Buffer = false;
            Response.AppendHeader("Content-Type", contentType);
            Response.AppendHeader("Content-Transfer-Encoding", "binary");
            Response.AppendHeader("Content-Disposition", disposition + "; filename=" + fileName);
            Response.BinaryWrite(buffer);
            Response.End();
        }
    }

    protected void ASPxGridView1_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs e)
    {
        //if (e.RowType == GridViewRowType.Filter) 
        //{ 

        //}
        if (e.RowType == DevExpress.Web.ASPxGridView.GridViewRowType.Data)
        {
            // Int32 Radicado = (Int32)e.GetValue("RadicadoCodigo");
            //String ExpedienteCodigo = (String)e.GetValue("ExpedienteCodigo");
            //String GrupoCodigo = (String)e.GetValue("GrupoCodigo");

            GridViewDataColumn colRad =
                ((ASPxGridView)sender).Columns["RadicadoCodigo"] as GridViewDataColumn;
            GridViewDataColumn colAviso =
                ((ASPxGridView)sender).Columns["AvisoPrivacidad"] as GridViewDataColumn;

          //  HyperLink HprAviso =
          //(HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(e.VisibleIndex, colAviso, "HprLnkTexto");
          //  HprAviso.Attributes.Add("onClick", "UrlAvisoPrivacidad(event);");

            HyperLink NroDoc =
                (HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(e.VisibleIndex, colRad, "HyperLink1");
            NroDoc.Attributes.Add("onClick", "url(event,1);");

          //  HyperLink HprVisor =
          // (HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(e.VisibleIndex, colOps, "HyperLinkVisor");
          //  HprVisor.Attributes.Add("onClick", "VImagenes(event," + NroDoc.Text + ",1);");

          //  HyperLink HprHisto =
          // (HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(e.VisibleIndex, colOps, "HprLnkHisExtven");
          //  HprHisto.Attributes.Add("onClick", "Historico(event," + NroDoc.Text + ",1);");

          //  HyperLink HprExp =
          //(HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(e.VisibleIndex, colOps, "HprLnkExp");
          //  HprExp.Attributes.Add("onClick", "Expediente(event," + NroDoc.Text + ",'" + ExpedienteCodigo + "'," + GrupoCodigo + ");");

          //  System.Web.UI.WebControls.Image ImgRpta =
          //(System.Web.UI.WebControls.Image)((ASPxGridView)sender).FindRowCellTemplateControl(e.VisibleIndex, colRpta, "Image1");

          //  Label LabelResuesta =
          //(Label)((ASPxGridView)sender).FindRowCellTemplateControl(e.VisibleIndex, colRpta, "Label6");


            //if (LabelResuesta.Text == "0")
            //{
            //    ImgRpta.Visible = false;
            //}
            //else if (Convert.ToInt32(LabelResuesta.Text) > 0)
            //{
            //    ImgRpta.Visible = true;

            //}
        }
    }


    protected void callbackPanel_Callback(object source, DevExpress.Web.ASPxClasses.CallbackEventArgsBase e)
    {

        litText.Text = GetNotes(e.Parameter).ToString();
    }
    object GetNotes(string id)
    {
        DSRadicadoFuenteSQLTableAdapters.RadicadoFuente_ReadRadicadoFuenteRegistroTableAdapter DSRadFuenteReg = new DSRadicadoFuenteSQLTableAdapters.RadicadoFuente_ReadRadicadoFuenteRegistroTableAdapter();
        DSRadicadoFuenteSQL.RadicadoFuente_ReadRadicadoFuenteRegistroDataTable DTRadFuenteReg = new DSRadicadoFuenteSQL.RadicadoFuente_ReadRadicadoFuenteRegistroDataTable();
        DTRadFuenteReg = DSRadFuenteReg.GetRegistrosRadicadoFuente(Convert.ToInt32(id), "1");

        int i = 1;
        foreach (DSRadicadoFuenteSQL.RadicadoFuente_ReadRadicadoFuenteRegistroRow DRRadFuenteReg in DTRadFuenteReg.Rows)
        {
            HyperLink HprRpta = new HyperLink();
            HprRpta.ID = "HprRpta" + i.ToString();
            HprRpta.Text = DRRadFuenteReg.RegistroCodigo.ToString();
            HprRpta.Target = "_Blank";
            HprRpta.ForeColor = System.Drawing.Color.Blue;
            HprRpta.Font.Underline = true;
            HprRpta.Visible = true;
            HprRpta.Attributes.Add("onClick", "urlInt(event," + DRRadFuenteReg.GrupoRegistroCodigo + ");");

            callbackPanel.Controls.Add(HprRpta);
            callbackPanel.Controls.Add(new LiteralControl("&nbsp;"));
            System.Web.UI.WebControls.Image ImgRpta = new System.Web.UI.WebControls.Image();
            ImgRpta.ID = "ImgRpta" + i.ToString();
            ImgRpta.ImageUrl = "~/AlfaNetImagen/iconos/icono_tif.JPG";
            ImgRpta.Attributes.Add("onClick", "VImagenesReg(event," + DRRadFuenteReg.RegistroCodigo + "," + DRRadFuenteReg.GrupoRegistroCodigo + ");");
            callbackPanel.Controls.Add(ImgRpta);
            callbackPanel.Controls.Add(new LiteralControl("<br />"));
            i += 1;
        }
        //Image1.Visible = true;
        //Panel popup = ((Panel)e.Row.FindControl("popup"));

        return "";
    }


}

