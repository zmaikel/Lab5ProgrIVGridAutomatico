using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using CapaDatos.Entidades;

namespace Lab5_6_PrograIV_MaikelZamora
{
    public partial class index : System.Web.UI.Page
    {
        GestionDB objGestion;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargaCarro();
            }
        }
        void mostrarMensaje(string txtMensaje, bool Tipo)
        {
            if (Tipo)
            {
                lblExito.Text = txtMensaje;
                lblError.Text = "";
            }
            else
            {
                lblExito.Text = "";
                lblError.Text = txtMensaje;
            }
        }
        void cargaCarro()
        {
            DataTable datosCarro = new DataTable();
            objGestion = new GestionDB();
            datosCarro = objGestion.cargaCarro();

            if (datosCarro.Rows.Count > 0)
            {
                gridCarro.DataSource = datosCarro;
                gridCarro.DataBind();
            }
            else
            {
                datosCarro.Rows.Add(datosCarro.NewRow());
                gridCarro.DataSource = datosCarro;
                gridCarro.DataBind();
                gridCarro.Rows[0].Cells.Clear();
                gridCarro.Rows[0].Cells.Add(new TableCell());
                gridCarro.Rows[0].Cells[0].ColumnSpan = datosCarro.Columns.Count;
                gridCarro.Rows[0].Cells[0].Text = "No hay datos que mostrar.....";
                gridCarro.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }
        }
        protected void gridCarro_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("AddNew"))
            {
                objGestion = new GestionDB();
                Carro objCarro = new Carro();
                objCarro.Marca = (gridCarro.FooterRow.FindControl("txtMarcaPie") as TextBox).Text.Trim();
                objCarro.Modelo = (gridCarro.FooterRow.FindControl("txtModeloPie") as TextBox).Text.Trim();
                objCarro.Pais = (gridCarro.FooterRow.FindControl("txtPaisPie") as TextBox).Text.Trim();
                objCarro.Costo = Convert.ToDecimal((gridCarro.FooterRow.FindControl("txtCostoPie") as TextBox).Text);
                int resultado = objGestion.registrarCarro(objCarro);

                if (resultado == 1)
                {
                    cargaCarro();
                    mostrarMensaje("Registro con exito", true);
                }
                else
                {
                    mostrarMensaje("Existe un error en el registro del Vehiculo", false);

                }

            }


        }
        protected void gridCarro_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridCarro.EditIndex = e.NewEditIndex;
            cargaCarro();
        }

        protected void gridCarro_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridCarro.EditIndex = -1;
            cargaCarro();
        }
        protected void gridCarro_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            objGestion = new GestionDB();
            Carro objCarro = new Carro();
            objCarro.Marca = (gridCarro.FooterRow.FindControl("txtMarcaPie") as TextBox).Text.Trim();
            objCarro.Modelo = (gridCarro.FooterRow.FindControl("txtModeloPie") as TextBox).Text.Trim();
            objCarro.Pais = (gridCarro.FooterRow.FindControl("txtPaisPie") as TextBox).Text.Trim();
            objCarro.Costo = Convert.ToDecimal((gridCarro.FooterRow.FindControl("txtCostoPie") as TextBox).Text);
            objCarro.IdCarro = Convert.ToInt32(gridCarro.DataKeys[e.RowIndex].Value.ToString());
            int resultado = objGestion.actualizarCarro(objCarro);
            gridCarro.EditIndex = -1;


            if (resultado == 1)
            {
                cargaCarro();
                mostrarMensaje("Actualización con exito", true);
            }
            else
            {
                mostrarMensaje("Existe un error en el registro del Vehiculo", false);

            }
        }
        protected void gridCarro_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            objGestion = new GestionDB();
            Carro objCarro = new Carro();
            objCarro.IdCarro = Convert.ToInt32(gridCarro.DataKeys[e.RowIndex].Value.ToString());
            objGestion.eliminarPersona(objCarro);
            gridCarro.EditIndex = -1;
            cargaCarro();

            mostrarMensaje("Elimino con exito", true);
        }

        
    }
}