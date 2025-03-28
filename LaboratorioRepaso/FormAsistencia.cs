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
    public partial class FormAsistencia: Form
    {
        
        List<Asistencia> asistencias = new List<Asistencia>();
        public FormAsistencia()
        {
            InitializeComponent();
        }
        private void Mostrar()
        {
            AsistenciaArchivo asistenciaArchivo = new AsistenciaArchivo();
            asistencias = asistenciaArchivo.Leer("../../Asistencias.json");
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = asistencias;
            dataGridView1.Refresh();
        }

        private void FormAsistencia_Load(object sender, EventArgs e)
        {
            Mostrar();
            List<Empleado> empleados = new List<Empleado>();
            EmpleadoArchivo empleadoArchivo = new EmpleadoArchivo();
            empleados = empleadoArchivo.Leer("../../Empleados.json");
            comboBox1.DisplayMember = "Nombre" ;
            comboBox1.ValueMember = "NoEmpleado";
            comboBox1.DataSource = empleados;
            //AsistenciaArchivo asistencia = new AsistenciaArchivo();
            //asistencias = asistencia.Leer("../../Empleados.json");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            Asistencia asistencia = new Asistencia();
            asistencia.noEmpleado = Convert.ToInt16(comboBox1.SelectedValue);
            asistencia.horasMes =  Convert.ToInt16(numericUpDownHoras.Value);
            asistencia.Mes = Convert.ToInt16(numericUpDown1.Value);
            asistencias.Add(asistencia);
            AsistenciaArchivo asistenciaArchivo = new AsistenciaArchivo();
            asistenciaArchivo.guardar("../../Asistencias.json",asistencias);
            Mostrar();
        }

    }
}
