using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaboratorioRepaso
{
    public partial class FormEmpleado: Form
    {
        List<Empleado> empleados = new List<Empleado>();
        public FormEmpleado()
        {
            InitializeComponent();
        }
        private void Mostrar()
        {
            EmpleadoArchivo empleadoArchivo = new EmpleadoArchivo();
            empleados = empleadoArchivo.Leer("../../Empleados.json");
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = empleados;
            dataGridView1.Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Mostrar();
        }

        private void buttonAsistencia_Click(object sender, EventArgs e)
        {
            FormAsistencia formAsistencia = new FormAsistencia();
            formAsistencia.Show();

        }

        private void buttonRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            Empleado empleado = new Empleado();
            empleado.noEmpleado = Convert.ToInt16(numericUpDown1.Value);
            empleado.Nombre = textBoxNombre.Text;
            empleado.SueldoHora= Convert.ToDecimal(maskedTextBoxSueldo.Text);
            empleados.Add(empleado);
            EmpleadoArchivo empleadoArchivo = new EmpleadoArchivo();
            empleadoArchivo.guardar("../../Empleados.json", empleados);
            Mostrar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormReporte form = new FormReporte();   
            form.Show();
        }
    }
}
