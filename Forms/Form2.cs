using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TipoParcial.Entidades;
using TipoParcial.Servicios;

namespace TipoParcial
{
    //Joaquin romero Beskow 1w1 405632
    public partial class Form2 : Form
    {
        IServicio servicio;
        Ordenes nuevaOrden;
        public Form2()
        {
            InitializeComponent();
            servicio = new ServicioDao();
            nuevaOrden = new Ordenes();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            txtCantidad.Text = "1";

            CargarProductos();
        }

        private void bntAcpetar_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtResponsable.Text))
            {
                MessageBox.Show("Deve ingresar un responsable");
                return;
            }
            if(dvgOrdenes.Rows.Count == 0)
            {
                MessageBox.Show("Deve ingresar almenos un detalle!");
                return;
            }
            CrearOrden();
        }

        private void CrearOrden()
        {
            nuevaOrden.Fecha = Convert.ToDateTime(dtpFecha.Text);
            nuevaOrden.Responsable = txtResponsable.Text;
            if(servicio.CrearOrden(nuevaOrden))
            {
                MessageBox.Show("Se registró con éxito la orden");
                this.Dispose();
            }
            else
            {
                MessageBox.Show("NO se pudo registrar la orden");
            }
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cboMateriales.SelectedIndex == -1)
            {
                MessageBox.Show("Deve seleccionar un material");
                return;
            } 
            if(string.IsNullOrEmpty(txtCantidad.Text))
            {
                MessageBox.Show("Deve ingresar una cantidad");
                return;
            }

            Materiales m = (Materiales)cboMateriales.SelectedItem;
            int cant = Convert.ToInt32(txtCantidad.Text);

            DetallesOrdenes det = new DetallesOrdenes(m, cant);
            nuevaOrden.QgregarDetalle(det);
            dvgOrdenes.Rows.Add(new object[] { m.Nombre, m.Stock, cant, "Quitar" });
        }
        private void dvgOrdenes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dvgOrdenes.CurrentCell.ColumnIndex == 3)
            {
                nuevaOrden.QuitarDEtalle(dvgOrdenes.CurrentRow.Index);
                dvgOrdenes.Rows.RemoveAt(dvgOrdenes.CurrentRow.Index);
            }
        }
        private void CargarProductos()
        {
           cboMateriales.DataSource = servicio.TraerMateriales();
            cboMateriales.ValueMember = "Codigo";
            cboMateriales.DisplayMember = "Nombre";
        }
    private void bntCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
