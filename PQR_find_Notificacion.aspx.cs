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


public partial class PQR_find_Notificacion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        

        this.txbpqr.Visible = true;
        this.Label10.Visible = true;
        this.txbpqr.Text = ClientQueryString;




        DataTable tabla = new DataTable();
        rutinas ejecutar = new rutinas();
        if ((this.txbpqr.Text.Trim() != "") && (this.txbpqr.Text.Trim().Contains(":") == false))
        {


            Double result2;
            bool valid_c2;
            valid_c2 = Double.TryParse(this.txbpqr.Text.Trim(), out result2);
            string ddlval = this.DDLTipoID.SelectedValue.ToString();


            if ((valid_c2 == true) && (ddlval.Trim().ToString() != ""))
            {
                tabla = ejecutar.rtn_traer_respuesta("", this.txbpqr.Text, "");
                if (tabla.Rows.Count > 0)
                {
                    this.DataList1.Visible = true;
                    DataTable t1 = new DataTable();
                    t1 = tabla.Copy();
                    if (t1.Rows.Count > 1)
                    {
                        for (int i = 1; i < t1.Rows.Count; i++)
                        {
                            t1.Rows[i].Delete();
                        }
                    }

                    this.DataList1.DataSource = t1;
                    this.DataList1.DataBind();

                    this.txbpqr.CssClass = "WaterMarkedTextBox";
                    this.DDLTipoID.CssClass = "WaterMarkedDDL";

                }
                else
                {

                    this.HFmensaje.Value = "1";
                    this.HFCabezote.Value = "Información";
                    this.HFContenido.Value = "No se ha encontrado resultados referentes a la solicitud N° " + this.txbpqr.Text;

                    this.DataList1.Visible = false;
                    this.txbpqr.CssClass = "Ejemplo:455554411";
                    this.txbpqr.CssClass = "WaterMarkedTextBox";
                    this.DDLTipoID.CssClass = "WaterMarkedDDL";

                }
            }
            else
            {
                this.HFmensaje.Value = "1";
                this.HFCabezote.Value = "Información";
                this.HFContenido.Value = "Uno o varios campos tienen un formato inválido, por favor revise de nuevo";

                this.DataList1.Visible = false;


                if (valid_c2 == false)
                {
                    this.txbpqr.Text = "Ejemplo:455554411";
                    this.txbpqr.CssClass = "AlarmTextBox2";
                }
                else
                {
                    this.txbpqr.Text = Convert.ToString(result2);
                    this.txbpqr.CssClass = "NormalTextBox";
                }
                if (ddlval.Trim().ToString() == "")
                {
                    this.DDLTipoID.CssClass = "WaterMarkedDDLError";

                }
                else
                {
                    this.DDLTipoID.CssClass = "WaterMarkedDDL";
                }
            }

        }
        else
        {
            if (this.HFIsClicked.Value == "1")
            {
                string tipoDocumento = DDLTipoID.SelectedValue.ToString();
                tipoDocumento = tipoDocumento.Trim();

            }
        }



        txbpqr.Enabled = false;
            
            ClientScript.RegisterStartupScript(this.GetType(), "myscript", "<script>javascript:enable_divtel(this);</script>");
            
    }  
    

    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
    {

            HtmlControl c1 = (HtmlControl)e.Item.FindControl("divrespuesta");
            HiddenField hf1 = (HiddenField)e.Item.FindControl("HFPQRNat");
            Label l1 = (Label)e.Item.FindControl("Label3");
            if (!l1.Text.ToString().Contains("EN PROCESO"))
            {
               
                c1.Visible = true;
                Label lbresp = (Label)e.Item.FindControl("Label5");
                HiddenField hf11 = (HiddenField)e.Item.FindControl("HFImagen");

                if (hf1.Value != null)
                {
                    if (hf11.Value.Trim() != "")
                    {
                        HtmlControl c2 = (HtmlControl)e.Item.FindControl("LinkImagen");
                        c2.Attributes.Add("href", "ALfanetImagen/VisorImagenes/VisorImagenes.aspx?DocumentoCodigo=" + lbresp.Text + "&GrupoCodigo=2&GrupoPadreCodigo=2&ImagenFolio=1&q=jqmodal&width=60%&height=96%&jqmRefresh=false");
                        c2.Visible = true;
                    }
                }          
            }
            
        //}
    }
    protected void btnNuevaConsulta_Click(object sender, EventArgs e)
    {
        Response.Redirect("PQR_find.aspx");
    }
    protected void DDLTipoID_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Write("<script>parent.location.href('http://wlserver.unab.edu.co/guido/');</script>");
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        this.txbpqr.Visible = true;
        this.Label10.Visible = true;
    }
}
 