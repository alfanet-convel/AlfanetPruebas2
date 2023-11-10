using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Imaging;

public partial class Captcha : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Configuración texto Captcha
        Font f = new Font("Comic Sans MS", 30, FontStyle.Strikeout);
        // Dimenciones captcha
        Bitmap b = new Bitmap(200, 100);

        Graphics g = Graphics.FromImage(b);

        //Color Fondo
        g.Clear(Color.White);

        //Generación Imagen aleatorio
        String CaptchaString = generateRandomString();
        //Recuperación Captcha desde otra pagina
        Session.Add("CAPTCHA", CaptchaString);

        g.DrawString(CaptchaString, f, Brushes.Blue, 10, 10);

        Response.ContentType = "Image/GIF";

        b.Save(Response.OutputStream, ImageFormat.Gif);

        //Opcional
        f.Dispose();
        b.Dispose();
        g.Dispose();
    }
    public String generateRandomString()
    {
        String result = "";
        //Caracteres de Captcha
        String str = "b,B,C,D,E,d,e,g,4,5,6,h,i,n,K,L,M,p,q,r,s,t,v,w,x,y,z,1,3,7,G,H,J,N,O,P,Q,R,T,8,9,A,F,U,V,W,k,l,m,X,Y,Z";
        String[] arr = str.Split(',');

        //Generación Codigo aleatorio
        Random r = new Random();
        //For para indicar que solamente genere 5 campos
        for (int i = 0; i < 5; i++)
        {

            int num = r.Next(0, arr.Length);
            result += arr[num];
        }
        return result;
    }
}