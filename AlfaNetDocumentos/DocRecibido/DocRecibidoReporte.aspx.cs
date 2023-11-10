
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

public partial class _DocRecibidoReporte : System.Web.UI.Page 
{
    //string GrpDocRad = "1";
    

    protected void Page_Load(object sender, EventArgs e)
    {  
    try
    {     

        if (!IsPostBack)
            {
                string Admon = Request["Admon"];
                if (Admon == "S")
                {
                    ((MainMaster)this.Master).hidemenu();
                }
                else
                {
                    ((MainMaster)this.Master).showmenu();
                }

                String codImagen = Request["RadicadoCodigo"];
                HFGrupo.Value = Request["GrupoCodigo"];
                HFTipoDB.Value = Request["TipoCodigo"];
                HFControlDias.Value = Request["ControlDias"];
                HFDepenOrig.Value = Profile.GetProfile(User.Identity.Name).CodigoDepUsuario.ToString();
                HFWFMovFecha.Value = Convert.ToString(DateTime.Now);
                string senrodoc;
                if (codImagen != null)
                {
                    senrodoc = codImagen;
                    Session["NroDoc"] = codImagen;
                }

                senrodoc = (string)(Session["NroDoc"]);
                if (Session["NroDoc"] != null)
                {
                    senrodoc = Session["NroDoc"].ToString();
                    string Tipo = senrodoc.Substring(0, 1);
                    string nrodoc = senrodoc.Substring(1);
                    if (Tipo == "1")
                    {
                        RadicadoBLL ObjRad = new RadicadoBLL();
                        DSRadicado.Radicado_ReadRadDataTable radicados = new DSRadicado.Radicado_ReadRadDataTable();
                        radicados = ObjRad.GetDataBy(nrodoc, HFGrupo.Value);
                        DataRow[] rows = radicados.Select();
                       
                        Session["NroDoc"] = "1" + nrodoc;
                        this.HFNroRad.Value = nrodoc; 
                       
                    }
                    else
                    {
                        this.Session.Clear();

                    }
                }        
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

    protected void cmdCancel_Click(object sender, EventArgs e)
    {
        try
        {
            this.Session.Clear();
            Response.Redirect("~");
        }
        catch (Exception Error)
        {
            this.ExceptionDetails.Text = "Problema" + Error;
        }
    }
   protected void BtnNuevoRad_Click(object sender, EventArgs e)
    {
          try
            {
                this.Session.Clear();
                Response.Redirect("~/AlfaNetDocumentos/DocRecibido/NuevoDocRecibido1.aspx");
        
            }
    catch (SqlException err)
    {
        //cnn.rol
       this.ExceptionDetails.Text = "Error: " + err.Message.ToString();

    }
}   
    
}
        
           
      
