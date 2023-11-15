using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;

namespace parcial2
{
    public partial class GestionArchivos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //debe recuperarse el valor nombre de usuario de la Session anterior
            if (this.Session["nombreUsuario"] != null)
            {
                Label1.Text = "Bienvenido " + Session["nombreUsuario"].ToString();
                cargarGrilla();
            }
        }


        public void cargarGrilla()
        {
            string folderPath = getFullPath();
            //en caso que si exista la recorre y completa un Gridview
            //con los archivos subidos y la posibilidad de descargar el archivo.
            if (Directory.Exists(folderPath))
            {
                string[] files = Directory.GetFiles(folderPath);
                List<Archivo> fileList = new List<Archivo>();
                foreach (string file in files)
                {
                    Archivo fileNew = new Archivo(Path.GetFileName(file), file);
                    fileList.Add(fileNew);
                }
                GridView1.DataSource = fileList;
                GridView1.DataBind();
            }
        }

        public string getFullPath()
        {
            String folderName = Session["nombreUsuario"].ToString();
            String folderPath = $"{Server.MapPath("")}/{folderName}";
            return folderPath;
        }


        protected void LoadFileButton_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            // debe verificar si existe la carpeta $"{Server.MapPath(".")}/{nombreUsuario}"
            // en caso que no exista la crea        
            string folderPath = getFullPath();
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            foreach (HttpPostedFile archivo in FileUpload1.PostedFiles)
            {
                if (archivo.ContentLength > 1000000)
                {
                    mensaje += $"El archivo {archivo.FileName} debe ser menor a 1 Mb.\n";
                }
                else
                {
                    if (File.Exists(folderPath + "/" + archivo.FileName))
                    {
                        mensaje += $"El archivo {archivo.FileName} ya existe.\n";
                    }
                    else
                    {
                        FileUpload1.SaveAs(folderPath + "/" + archivo.FileName);
                    }
                }
            }
            if (mensaje == string.Empty)
            {
                mensaje = "Los archivos se cargaron correctamente";
            }
            Label2.Text = mensaje;
            cargarGrilla();
        }

        protected void GridView1_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Descargar")
            {
                GridViewRow registro = GridView1.Rows[Convert.ToInt32(e.CommandArgument)];
                string filePath = registro.Cells[2].Text;
                Response.ContentType = "application/octet-stream";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
                Response.TransmitFile(filePath);
                Response.End();
            }
        }
    }
}