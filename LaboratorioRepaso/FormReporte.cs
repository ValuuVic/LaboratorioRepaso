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
    public partial class FormReporte: Form
    {
        List<Empleado> empleados = new List<Empleado>();
        List <Asistencia> asistencias = new List<Asistencia>();
        List<ReporteSueldo> reportes = new List<ReporteSueldo>();
        public FormReporte()
        {
            InitializeComponent();
        }
        private void CargarEmpleados()
        {
            EmpleadoArchivo empleadoArchivo = new EmpleadoArchivo();
            empleados = empleadoArchivo.Leer("../../Empleados.json");
        }
        private void CargarAsistencia()
        {
            AsistenciaArchivo asistenciaArchivo = new AsistenciaArchivo();
            asistencias = asistenciaArchivo.Leer("../../Asistencias.json");
        }
        private void FormReporte_Load(object sender, EventArgs e)
        {
            CargarEmpleados();
            CargarAsistencia();
        }

        private void buttonMostrar_Click(object sender, EventArgs e)
        {
            foreach (var empleado in empleados)
            {
                foreach(var asistencia in asistencias)
                {
                    if(empleado.noEmpleado == asistencia.noEmpleado)
                    {
                        ReporteSueldo reporte = new ReporteSueldo();
                        reporte.Nombre = empleado.Nombre;
                        reporte.Mes = asistencia.Mes.ToString();
                        reporte.SueldoTotal = empleado.SueldoHora * asistencia.horasMes;
                        reportes.Add(reporte);
                    }
                }
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = reportes;
            dataGridView1.Refresh();
        }

        private void buttonRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
