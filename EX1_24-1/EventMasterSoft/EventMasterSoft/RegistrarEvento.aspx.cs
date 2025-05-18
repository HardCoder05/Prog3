using EventMasterSoftDA.DAO;
using EventMasterSoftDA.Impl;
using EventMasterSoftModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EventMasterSoft
{
    public partial class RegistrarEvento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String accion = Request.QueryString["accion"];
            String idEvento = Request.QueryString["idEvento"];

            if (!IsPostBack)
            {
                // Cargar las productoras PRIMERO
                Cargar_Productoras();

                if (accion != null && accion == "ver" && idEvento != null)
                {
                    lblTitulo.Text = "Visualizar Evento";
                    Evento evento = new EventoMySQL().obtenerPorId(Int32.Parse(idEvento));

                    // Mostrar datos del evento
                    string base64String = Convert.ToBase64String(evento.BannerPromocional);
                    string imageUrl = "data:image/jpeg;base64," + base64String;
                    imgBannerPromocional.ImageUrl = imageUrl;
                    dtpFechaRealizacion.Value = evento.FechaRealizacion.ToString("yyyy-MM-dd");
                    txtIDEvento.Text = evento.IdEvento.ToString();
                    txtNombreEvento.Text = evento.Nombre;
                    txtDescripcion.Value = evento.Descripcion;
                    txtCostoRealizacion.Text = evento.CostoRealizacion.ToString("N2");
                    cbReingreso.Checked = evento.PermiteReingreso;
                    cbGrabacion.Checked = evento.PermiteGrabacion;
                    rbConcierto.Checked = evento.TipoEvento == TipoEvento.CONCIERTO;
                    rbObraTeatral.Checked = evento.TipoEvento == TipoEvento.OBRA_TEATRAL;
                    rbAdultos.Checked = evento.Clasificacion == 'A';
                    rbJovenes.Checked = evento.Clasificacion == 'J';
                    rbNinhos.Checked = evento.Clasificacion == 'N';
                    rbTodos.Checked = evento.Clasificacion == 'T';
                    
                    ddlProductora.SelectedValue = evento.Productora.IdProductora.ToString();

                    Deshabilitar_Componentes();
                }
                else
                {
                    lblTitulo.Text = "Registrar Evento";
                    Cargar_Foto(sender, e);
                }
            }
            else
            {
                // Si es PostBack, solo cargamos la foto
                Cargar_Foto(sender, e);
            }
        }

        private void Cargar_Productoras()
        {
            ProductoraMySQL productoraDAO = new ProductoraMySQL();
            List<Productora> listaProductoras = productoraDAO.listarTodas().ToList();
            ddlProductora.DataSource = listaProductoras;
            ddlProductora.DataTextField = "Nombre";
            ddlProductora.DataValueField = "IdProductora";
            ddlProductora.DataBind();
        }

        public void Deshabilitar_Componentes()
        {
            txtIDEvento.Enabled = false;
            txtNombreEvento.Enabled = false;
            ddlProductora.Enabled = false;
            lbGuardar.Visible = false;
            txtDescripcion.Disabled = true;
            rbConcierto.Disabled = true;
            rbObraTeatral.Disabled = true;
            rbAdultos.Disabled = true;
            rbJovenes.Disabled = true;
            rbNinhos.Disabled = true;
            rbTodos.Disabled = true;
            txtCostoRealizacion.Enabled = false;
            dtpFechaRealizacion.Disabled = true;
            cbReingreso.Disabled = true;
            cbGrabacion.Disabled = true;
            fileUploadBannerPromocional.Enabled = false;
        }

        protected void Cargar_Foto(object sender, EventArgs e)
        {
            if (IsPostBack && fileUploadBannerPromocional.PostedFile != null && fileUploadBannerPromocional.HasFile)
            {
                string extension = System.IO.Path.GetExtension(fileUploadBannerPromocional.FileName);
                if (extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".png" || extension.ToLower() == ".gif")
                {
                    string filename = Guid.NewGuid().ToString() + extension;
                    string filePath = Server.MapPath("~/Uploads/") + filename;
                    fileUploadBannerPromocional.SaveAs(Server.MapPath("~/Uploads/") + filename);
                    imgBannerPromocional.ImageUrl = "~/Uploads/" + filename;
                    imgBannerPromocional.Visible = true;
                    FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    Session["foto"] = br.ReadBytes((int)fs.Length);
                    fs.Close();
                }
                else
                {
                    Response.Write("Por favor, selecciona un archivo de imagen válido.");
                }
            }
        }

        protected void lbRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListarEventos.aspx");
        }

        protected void lbGuardar_Click(object sender, EventArgs e)
        {
            // Obtener datos del formulario
            string idEvento = txtIDEvento.Text;
            string nombreEvento = txtNombreEvento.Text;
            int idProductora = Int32.Parse(ddlProductora.SelectedValue);
            string nombreProductora = ddlProductora.SelectedItem.Text;
            string descripcion = txtDescripcion.Value;
            Double costo = double.Parse(txtCostoRealizacion.Text);
            DateTime fecha = DateTime.Parse(dtpFechaRealizacion.Value);
            bool permiteReingreso = cbReingreso.Checked;
            bool permiteGrabacion = cbGrabacion.Checked;

            // Obtener tipo de evento (enum)
            TipoEvento tipoEvento = rbObraTeatral.Checked ? TipoEvento.OBRA_TEATRAL :
                                     rbConcierto.Checked ? TipoEvento.CONCIERTO :
                                     throw new Exception("Debe seleccionar un tipo de evento.");

            char clasificacion = ' ';

            if (rbAdultos.Checked) {
                clasificacion = 'A';
            }
            else if (rbJovenes.Checked)
            {
                clasificacion = 'J';
            }else if (rbNinhos.Checked)
            {
                clasificacion = 'N';
            }
            else if (rbTodos.Checked)
            {
                clasificacion = 'T';
            }

            // Obtener imagen en bytes desde sesión
            byte[] banner = (byte[])Session["foto"];
            
            Evento evento = new Evento()
            {
                Nombre = nombreEvento,
                Productora = new Productora{
                    IdProductora = idProductora,
                    Nombre = nombreProductora
                },
                Descripcion = descripcion,
                CostoRealizacion = costo,
                FechaRealizacion = fecha,
                PermiteReingreso = permiteReingreso,
                PermiteGrabacion = permiteGrabacion,
                TipoEvento = tipoEvento,
                Clasificacion = clasificacion,
                BannerPromocional = banner
            };

            EventoDAO daoEvento = new EventoMySQL();
            daoEvento.insertar(evento);
            
            Response.Redirect("ListarEventos.aspx");
        }


    }
}