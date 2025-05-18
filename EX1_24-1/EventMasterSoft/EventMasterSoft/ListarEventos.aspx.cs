using EventMasterSoftDA.DAO;
using EventMasterSoftDA.Impl;
using EventMasterSoftModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EventMasterSoft
{
    public partial class ListarEventos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarEventos();
            }
        }

        private void CargarEventos(string nombreBusqueda = "")
        {
            EventoDAO eventoDAO = new EventoMySQL();
            BindingList<Evento> lista = eventoDAO.listarPorNombre(nombreBusqueda);
            gvEventos.DataSource = lista.Select(e => new
            {
                Nombre = e.Nombre,
                Productora = e.Productora.Nombre,
                Fecha = e.FechaRealizacion.ToString("dd/MM/yyyy"),
                IdEvento = e.IdEvento
            }).ToList();
            gvEventos.DataBind();
        }

        protected void lbRegistrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistrarEvento.aspx");
        }

        protected void lbVisualizar_Click(object sender, EventArgs e)
        {
            int idEvento = Int32.Parse(((LinkButton)sender).CommandArgument);
            Response.Redirect("RegistrarEvento.aspx?accion=ver&idEvento=" + idEvento);
        }

        protected void lbBuscar_Click(object sender, EventArgs e)
        {
            string nombreBusqueda = txtNombre.Text.Trim();
            CargarEventos(nombreBusqueda);
        }
    }
}