using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using CapaEntidad; //Se agregan las referencias de capa entidad y capa negocio
using CapaNegocio;

namespace ProgramaCarros
{
    public partial class Form1 : Form
    {

        ClassEntidad objent = new ClassEntidad(); //Variable que representan a la clase de entidad y negocio
        ClassNegocio objneg = new ClassNegocio();
        public Form1()
        {
            InitializeComponent();
        }

        void mantenimiento (String Accion) //Para ahorrar codigo se usa el void y asi no tener que escribir todo otra vez
        {
            objent.Codigo = txtCodigo.Text; 
            objent.Marca = txtMarca.Text;
            objent.Modelo = txtModelo.Text;
            objent.Año = txtAño.Text;
            objent.Tipo = txtTipo.Text;
            objent.Precio = Convert.ToDecimal(txtPrecio.Text);
            objent.Accion = Accion;
            String men = objneg.N_mantenimiento_carros(objent);
            MessageBox.Show(men, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information); //Va a lanzar un mensaje de confirmacion
        }

        void limpiar() //Limpiar
        {
            txtCodigo.Text = ""; //Deja los texbox en blanco
            txtMarca.Text = "";
            txtModelo.Text = "";
            txtAño.Text = "";
            txtTipo.Text = "";
            txtPrecio.Text = "";
            dataGridView1.DataSource = objneg.N_listar_carros(); //Muestra la lista de carros en el DataGridView
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = objneg.N_listar_carros(); //Al abrir el formulario debe cargar el DataGriedView con todos los carros ingresados
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar(); //En la opcion nuevo ejecutara limpiar
        }

        private void registrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "") //Solo se puede registrar si el texbox de codigo esta vacio, ya que no se puede ingresar 2 carros con el mismo codigo
            {

                if(MessageBox.Show("¿Desea registrar a: " +txtMarca.Text+ "?", "Mensaje",  //Muestra este mensaje de confirmacion
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    mantenimiento("1"); //Opcion 1 en el mantenimiento, va a ingresar
                    limpiar(); //Una vez ingresado va a limpiar 
                }
                
            }
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "") //Se modigica cuando codigo no este vacio
            {

                if (MessageBox.Show("¿Desea Modificar a: " + txtMarca.Text + "?", "Mensaje", //Se muestra un mensaje de confirmacion
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    mantenimiento("2"); //Se ejecuta la opcion 2 de mantenimiento
                    limpiar(); //Limpia
                }

            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "") //Se modifica cuando codigo no este vacio
            {

                if (MessageBox.Show("¿Desea Eliminar a: " + txtMarca.Text + "?", "Mensaje", //Se muestra un mensaje de confirmacion
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    mantenimiento("3"); //Se ejecuta la opcion 3 de mantenimiento
                    limpiar(); //Limpia
                }

            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text != "") //Basta con una letra para buscar los carros
            {
                objent.Marca = txtBuscar.Text; //Va buscar que el dato de marca sea igual al de buscar
                DataTable dt = new DataTable();
                dt = objneg.N_buscar_carros(objent);
                dataGridView1.DataSource = dt;
            }

            else
            {
                dataGridView1.DataSource = objneg.N_listar_carros(); //En caso no tenga un caracter listar todos los carros
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) //Envia los datos a la caja de texto con CellContentClick
        {
            int fila = dataGridView1.CurrentCell.RowIndex;

            txtCodigo.Text = dataGridView1[0, fila].Value.ToString(); //En este caso hay 6 columnas pero se cuenta de 0
            txtMarca.Text = dataGridView1[1, fila].Value.ToString();
            txtModelo.Text = dataGridView1[2, fila].Value.ToString();
            txtAño.Text = dataGridView1[3, fila].Value.ToString();
            txtTipo.Text = dataGridView1[4, fila].Value.ToString();
            txtPrecio.Text = dataGridView1[5, fila].Value.ToString();
        }
    }
}
