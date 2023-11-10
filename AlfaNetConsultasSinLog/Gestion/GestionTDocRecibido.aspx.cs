using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxGridView;
using System.IO;
using AjaxControlToolkit;
using System.Web.Security;
using System.Data;

public partial class AlfaNetConsultas_Gestion_GestionTDocRecibido : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                this.RadioButtonList1.SelectedValue = null;
            }
            else
            {

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

    protected void ChBNaturaleza_CheckedChanged(object sender, EventArgs e)
    {
        if (ChBNaturaleza.Checked == true)
        {
            this.LblNaturaleza.Visible = true;
            this.TxtBNaturaleza.Visible = true;
        }
        else
        {
            this.LblNaturaleza.Visible = false;
            this.TxtBNaturaleza.Visible = false;
            this.TxtBNaturaleza.Text = "";
        }
    }

    protected void TreeVNaturaleza_SelectedNodeChanged(object sender, EventArgs e)
    {
        if ((String.IsNullOrEmpty(this.TreeVNaturaleza.SelectedNode.Text)) == false)
        {
            // Popup result is the selected task}
            PopupControlExtender.GetProxyForCurrentPopup(this.Page).Commit(TreeVNaturaleza.SelectedNode.Text);
        }
    }

    protected void TreeVNaturaleza_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        if (TreeVNaturaleza.SelectedNode == null)
        {
            ArbolesBLL ObjArbolNat = new ArbolesBLL();
            DSNaturalezaSQL.NaturalezaByTextDataTable DTNaturaleza = new DSNaturalezaSQL.NaturalezaByTextDataTable();
            DTNaturaleza = ObjArbolNat.GetNaturalezaTree(e.Node.Value);
            PopulateNodes(DTNaturaleza, e.Node.ChildNodes, "NaturalezaCodigo", "NaturalezaNombre");
        }
    }

    protected void TreeVDependencia_SelectedNodeChanged(object sender, EventArgs e)
    {
        if ((String.IsNullOrEmpty(this.TreeVDependencia.SelectedNode.Text)) == false)
        {
            // Popup result is the selected task}
            PopupControlExtender.GetProxyForCurrentPopup(this.Page).Commit(TreeVDependencia.SelectedNode.Text);
        }
    }

    protected void TreeVDependencia_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        ArbolesBLL ObjArbolDep = new ArbolesBLL();
        DSDependenciaSQL.DependenciaByTextDataTable DTDependencia = new DSDependenciaSQL.DependenciaByTextDataTable();
        DTDependencia = ObjArbolDep.GetDependenciaTree(e.Node.Value);
        PopulateNodes(DTDependencia, e.Node.ChildNodes, "DependenciaCodigo", "DependenciaNombre");
    }

    protected void TVDepDestino_SelectedNodeChanged(object sender, EventArgs e)
    {
        if ((String.IsNullOrEmpty(this.TVDepDestino.SelectedNode.Text)) == false)
        {
            // Popup result is the selected task}
            PopupControlExtender.GetProxyForCurrentPopup(this.Page).Commit(TVDepDestino.SelectedNode.Text);
        }
    }

    protected void TreeVProceso_SelectedNodeChanged(object sender, EventArgs e)
    {
        if ((String.IsNullOrEmpty(this.TreeVProceso.SelectedNode.Text)) == false)
        {
            // Popup result is the selected task}
            PopupControlExtender.GetProxyForCurrentPopup(this.Page).Commit(TreeVProceso.SelectedNode.Text);
        }
    }

    protected void TreeVProceso_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        if (TreeVProceso.SelectedNode == null)
        {
            ProcesoTableAdapters.WFProcesoTableAdapter TAPRO = new ProcesoTableAdapters.WFProcesoTableAdapter();
            Proceso.WFProcesoDataTable DTProceso = new Proceso.WFProcesoDataTable();
            DTProceso = TAPRO.GetProcesoTreeVDataBy(Convert.ToString(e.Node.Value));
            PopulateNodes(DTProceso, e.Node.ChildNodes, "WFProcesoCodigo", "WFProcesoDescripcion");
        }
    }

    protected void TreeVAccion_SelectedNodeChanged(object sender, EventArgs e)
    {
        if ((String.IsNullOrEmpty(this.TreeVAccion.SelectedNode.Text)) == false)
        {
            // Popup result is the selected task}
            PopupControlExtender.GetProxyForCurrentPopup(this.Page).Commit(TreeVAccion.SelectedNode.Text);
        }
    }

    protected void TreeVAccion_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        DSAccionTableAdapters.WFAccion_SelectByTextTableAdapter TADSWFA = new DSAccionTableAdapters.WFAccion_SelectByTextTableAdapter();
        DSAccion.WFAccion_SelectByTextDataTable DTWFAccion = new DSAccion.WFAccion_SelectByTextDataTable();
        DTWFAccion = TADSWFA.GetWFAccionTreeDataBy(Convert.ToString(e.Node.Value));

        PopulateNodes(DTWFAccion, e.Node.ChildNodes, "WFAccionCodigo", "WFAccionNombre");
    }

    private void PopulateNodes(DataTable dt, TreeNodeCollection nodes, String Codigo, String Nombre)
    {
        foreach (DataRow dr in dt.Rows)
        {
            TreeNode tn = new TreeNode();
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
        try
        {
            if (DDLSel.SelectedValue == "0")
            {
                this.ODSBuscar.SelectParameters["WFMovimientoTipo"].DefaultValue = "1";
                this.ODSBuscar.SelectParameters["WFMovimientoTipo1"].DefaultValue = "3";
                this.ODSBuscar.SelectParameters["WFMovimientoPasoActual"].DefaultValue = "";
                this.ODSBuscar.SelectParameters["WFMovimientoPasoFinal"].DefaultValue = "";
                lotros = "1?3??";
            }
            else if (DDLSel.SelectedValue == "1")
            {
                this.ODSBuscar.SelectParameters["WFMovimientoTipo"].DefaultValue = "3";
                this.ODSBuscar.SelectParameters["WFMovimientoTipo1"].DefaultValue = "3";
                this.ODSBuscar.SelectParameters["WFMovimientoPasoActual"].DefaultValue = "0";
                this.ODSBuscar.SelectParameters["WFMovimientoPasoFinal"].DefaultValue = "1";
                lotros = "3?3?0?1";
            }
            else if (DDLSel.SelectedValue == "2")
            {
                this.ODSBuscar.SelectParameters["WFMovimientoTipo"].DefaultValue = "1";
                this.ODSBuscar.SelectParameters["WFMovimientoTipo1"].DefaultValue = "1";
                this.ODSBuscar.SelectParameters["WFMovimientoPasoActual"].DefaultValue = "1";
                this.ODSBuscar.SelectParameters["WFMovimientoPasoFinal"].DefaultValue = "0";
                lotros = "1?1?1?0";
            }
            this.ODSBuscar.SelectParameters["WFMovimientoFecha"].DefaultValue = this.TxtFechaInicial.Text;
            this.ODSBuscar.SelectParameters["WFMovimientoFecha1"].DefaultValue = this.TxtFechaFinal.Text;
            this.ODSBuscar.SelectParameters["WFMovimientoFechaFin"].DefaultValue = this.TxtFechaFinInicial.Text;
            this.ODSBuscar.SelectParameters["WFMovimientoFechaFin1"].DefaultValue = this.TxtFechaFinFinal.Text;
            this.ODSBuscar.SelectParameters["RadicadoFechaVencimiento"].DefaultValue = this.TxtFechaVenInicial.Text;
            this.ODSBuscar.SelectParameters["RadicadoFechaVencimiento1"].DefaultValue = this.TxtFechaVenFinal.Text;
            this.ODSBuscar.SelectParameters["DependenciaCodOrigen"].DefaultValue = this.TxtBDepOrigen.Text;
            this.ODSBuscar.SelectParameters["DependenciaCodDestino"].DefaultValue = this.TxtBDepDestino.Text;
            this.ODSBuscar.SelectParameters["RadicadoCodigoFuente"].DefaultValue = this.RadioButtonList1.SelectedValue;
            this.ODSBuscar.SelectParameters["WFProcesoCodigo"].DefaultValue = this.TxtBProceso.Text;
            this.ODSBuscar.SelectParameters["WFAccionCodigo"].DefaultValue = this.TxtBAccion.Text;
            this.ODSBuscar.SelectParameters["SerieCodigo"].DefaultValue = "";
            this.ODSBuscar.SelectParameters["NaturalezaCodigo"].DefaultValue = this.TxtBNaturaleza.Text;
            this.ODSBuscar.SelectParameters["ProcedenciaCodigo"].DefaultValue = this.TxtBProcedencia.Text;
            this.ODSBuscar.SelectParameters["ExpedienteCodigo"].DefaultValue = this.TxtBExpediente.Text;
            //insertar la dependencia de donde se está haciendo la consulta modif feb 28 2011
            this.ODSBuscar.SelectParameters["DependenciaConsulta"].DefaultValue = Profile.CodigoDepUsuario.ToString();

            ASPxGridView1.DataSourceID = "ODSBuscar";
            ASPxGridView1.DataBind();

            this.MyAccordion.SelectedIndex = 1;
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

    protected void LinkButton1_Click(object sender, EventArgs e)
    {

    }

    protected void LnkBtnGTRecibidas_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AlfaNetDocumentos/DocRecibido/DocRecibidoReporte.aspx?TipoCodigo=1&RadicadoCodigo=1" + ((LinkButton)sender).Text + "&GrupoCodigo=1&ControlDias=2");

    }
    
    protected void ChBFechaFin_CheckedChanged(object sender, EventArgs e)
    {
        if (ChBFechaFin.Checked == true)
        {
            this.LblFechaFinFinal.Visible = true;
            this.LblFechaFinInicial.Visible = true;
            this.TxtFechaFinFinal.Visible = true;
            this.TxtFechaFinInicial.Visible = true;
            this.ImgCalendarFinFinal.Visible = true;
            this.ImgCalendarFinInicial.Visible = true;
        }
        else
        {
            this.LblFechaFinFinal.Visible = false;
            this.LblFechaFinInicial.Visible = false;
            this.TxtFechaFinFinal.Visible = false;
            this.TxtFechaFinInicial.Visible = false;
            this.TxtFechaFinFinal.Text = "";
            this.TxtFechaFinInicial.Text = "";
            this.ImgCalendarFinFinal.Visible = false;
            this.ImgCalendarFinInicial.Visible = false;
        }
    }

    protected void ChBFechaVen_CheckedChanged(object sender, EventArgs e)
    {
        if (ChBFechaVen.Checked == true)
        {
            this.LblFechaVenFinal.Visible = true;
            this.LblFechaVenInicial.Visible = true;
            this.TxtFechaVenFinal.Visible = true;
            this.TxtFechaVenInicial.Visible = true;
            this.ImgCalendarVenFinal.Visible = true;
            this.ImgCalendarVenInicial.Visible = true;
        }
        else
        {
            this.LblFechaVenFinal.Visible = false;
            this.LblFechaVenInicial.Visible = false;
            this.TxtFechaVenFinal.Visible = false;
            this.TxtFechaVenInicial.Visible = false;
            this.TxtFechaVenFinal.Text = "";
            this.TxtFechaVenInicial.Text = "";
            this.ImgCalendarVenFinal.Visible = false;
            this.ImgCalendarVenInicial.Visible = false;
        }
    }

    protected void ChBDependencias_CheckedChanged(object sender, EventArgs e)
    {
        if (ChBDependencias.Checked == true)
        {
            this.LblDepOrigen.Visible = true;
            this.LblDepDestino.Visible = true;

            this.TxtBDepOrigen.Visible = true;
            this.TxtBDepDestino.Visible = true;
        }
        else
        {
            this.LblDepOrigen.Visible = false;
            this.LblDepDestino.Visible = false;

            this.TxtBDepOrigen.Visible = false;
            this.TxtBDepDestino.Visible = false;

            this.TxtBDepOrigen.Text = "";
            this.TxtBDepDestino.Text = "";
        }
    }

    protected void ChBFuente_CheckedChanged(object sender, EventArgs e)
    {
        if (ChBFuente.Checked == true)
        {
            this.LblFuente.Visible = true;
            this.RadioButtonList1.Visible = true;
            this.RadioButtonList1.SelectedValue = null;
        }
        else
        {
            this.LblFuente.Visible = false;
            this.RadioButtonList1.Visible = false;
            this.RadioButtonList1.SelectedValue = null;
        }
    }

    protected void ChBProceso_CheckedChanged(object sender, EventArgs e)
    {
        if (ChBProceso.Checked == true)
        {
            this.LblProceso.Visible = true;
            this.TxtBProceso.Visible = true;
        }
        else
        {
            this.LblProceso.Visible = false;
            this.TxtBProceso.Visible = false;
            this.TxtBProceso.Text = "";
        }
    }

    protected void ChBAccion_CheckedChanged(object sender, EventArgs e)
    {
        if (ChBAccion.Checked == true)
        {
            this.LblAccion.Visible = true;
            this.TxtBAccion.Visible = true;
        }
        else
        {
            this.LblAccion.Visible = false;
            this.TxtBAccion.Visible = false;
            this.TxtBAccion.Text = "";
        }
    }
    
    protected void ChBExpediente_CheckedChanged(object sender, EventArgs e)
    {
        if (ChBExpediente.Checked == true)
        {
            this.LblExpediente.Visible = true;
            this.TxtBExpediente.Visible = true;
        }
        else
        {
            this.LblExpediente.Visible = false;
            this.TxtBExpediente.Visible = false;
            this.TxtBExpediente.Text = "";
        }
    }

    protected void ChBProcedencia_CheckedChanged(object sender, EventArgs e)
    {
        if (ChBProcedencia.Checked == true)
        {
            this.LblProcedencia.Visible = true;
            this.TxtBProcedencia.Visible = true;
        }
        else
        {
            this.LblProcedencia.Visible = false;
            this.TxtBProcedencia.Visible = false;
            this.TxtBProcedencia.Text = "";
        }
    }

    protected void TreeVExpediente_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        if (TreeVExpediente.SelectedNode == null)
        {
            ArbolesBLL ObjArbolExp = new ArbolesBLL();
            DSExpedienteSQL.ExpedienteByTextDataTable DTExpediente = new DSExpedienteSQL.ExpedienteByTextDataTable();
            DTExpediente = ObjArbolExp.GetExpedienteTree(e.Node.Value);
            PopulateNodes(DTExpediente, e.Node.ChildNodes, "ExpedienteCodigo", "ExpedienteNombre");
        }
    }

    protected void TreeVExpediente_SelectedNodeChanged(object sender, EventArgs e)
    {
        if ((String.IsNullOrEmpty(this.TreeVExpediente.SelectedNode.Text)) == false)
        {
            // Popup result is the selected task}
            PopupControlExtender.GetProxyForCurrentPopup(this.Page).Commit(TreeVExpediente.SelectedNode.Text);
        }
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
        if (e.RowType == DevExpress.Web.ASPxGridView.GridViewRowType.Data)
        {
            String ExpedienteCodigo = (String)e.GetValue("ExpedienteCodigo");
            String GrupoCodigo = (String)e.GetValue("GrupoCodigo");

            GridViewDataColumn colRad =
                ((ASPxGridView)sender).Columns["RadicadoCodigo"] as GridViewDataColumn;
            GridViewDataColumn colOps =
                ((ASPxGridView)sender).Columns["Opciones"] as GridViewDataColumn;
            GridViewDataColumn colRpta =
                ((ASPxGridView)sender).Columns["Rpta"] as GridViewDataColumn;

            HyperLink NroDoc =
                (HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(e.VisibleIndex, colRad, "HyperLink1");
            NroDoc.Attributes.Add("onClick", "url(event,1);");

            HyperLink HprVisor =
           (HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(e.VisibleIndex, colOps, "HyperLinkVisor");
            HprVisor.Attributes.Add("onClick", "VImagenes(event," + NroDoc.Text + ",1);");

            HyperLink HprHisto =
           (HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(e.VisibleIndex, colOps, "HprLnkHisExtven");
            HprHisto.Attributes.Add("onClick", "Historico(event," + NroDoc.Text + ",1);");

            HyperLink HprExp =
          (HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(e.VisibleIndex, colOps, "HprLnkExp");
            HprExp.Attributes.Add("onClick", "Expediente(event," + NroDoc.Text + ",'" + ExpedienteCodigo + "'," + GrupoCodigo + ");");

            System.Web.UI.WebControls.Image ImgRpta =
          (System.Web.UI.WebControls.Image)((ASPxGridView)sender).FindRowCellTemplateControl(e.VisibleIndex, colRpta, "Image1");

            Label LabelResuesta =
          (Label)((ASPxGridView)sender).FindRowCellTemplateControl(e.VisibleIndex, colRpta, "Label6");


            if (LabelResuesta.Text == "0")
            {
                ImgRpta.Visible = false;
            }
            else if (Convert.ToInt32(LabelResuesta.Text) > 0)
            {
                ImgRpta.Visible = true;
            }
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
        DTRadFuenteReg = DSRadFuenteReg.GetRegistrosRadicadoFuente(Convert.ToInt64(id), "1");

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
        return "";
    }
}