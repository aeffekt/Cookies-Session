using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Collections.Specialized.BitVector32;

namespace parcial2
{
    public partial class Registracion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Al registrar el dato debe crearse 1 Cookie con la contraseña 
            // y 1 Session con el nombre de usuario
            HttpCookie cookie1 = new HttpCookie("cookiePass", TextBox1.Text);            
            cookie1.Expires = DateTime.Now.AddDays(2);
            Response.Cookies.Add(cookie1);

            this.Session["nombreUsuario"] = TextBox1.Text;

            Response.Redirect("GestionArchivos.aspx");
        }
    }
}