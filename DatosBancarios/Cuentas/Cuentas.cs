using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosBancarios
{
    public abstract class Cuentas
    {
        
        public string cuentaUsuario { get; set; }
        public List<Movimiento> movimientos { get; set; } = new List<Movimiento>();

        public static List<string> posiblesBancos = new List<string>() { "Air Bank" };

        public static readonly string sqlConString = "Server=localhost;Database=Datosbancarios;User Id=sa;Password=28112009;Encrypt=false;";
        public static int cuenta = 0;
        public void ADatabase()
        {
            foreach (Movimiento movimiento in movimientos)
            {
                MvtoAsql(movimiento);
            }
        }
        public void MvtoAsql(Movimiento mvto)
        {
            string connetionString = "Server=localhost;Database=Datosbancarios;User Id=sa;Password=28112009;Encrypt=false;";
            SqlConnection conexion;
            SqlDataAdapter da = new SqlDataAdapter();
            string query = $"insert into Movimientos(codigo, fecha, tipo, cantidad, comision, origen, Destino, Descripcion)\r\n" +
                $"values('{mvto.codigo}', '{mvto.fecha.ToShortDateString()}', '{mvto.tipo}', {mvto.cantidad.ToString().Replace(",", ".")}, {mvto.comision.ToString().Replace(",", ".")}, '{mvto.origen}', '{mvto.destino}', '{mvto.descripcion.Replace("'", "")}')";//

            //MessageBox.Show(query);

            using (conexion = new SqlConnection(connetionString))
            {
                try
                {
                    conexion.Open();
                    da.InsertCommand = new SqlCommand(query, conexion);
                    da.InsertCommand.ExecuteNonQuery();
                    conexion.Close();
                    cuenta++;
                }
                catch (Exception ex)
                {
                    string yaexsiste = $"Infracción de la restricción PRIMARY KEY 'PK_movimientos'. No se puede insertar una clave duplicada en el objeto 'dbo.Movimientos'. El valor de la clave duplicada es ({mvto.codigo}).\r\nSe terminó la instrucción.";
                    if (ex.Message != yaexsiste)
                    {
                        MessageBox.Show(query);
                        throw;
                    }
                    conexion.Close();
                }
            }
        }
        public struct Movimiento
        {
            public string codigo { get; set; }
            public DateTime fecha { get; set; }
            public string tipo { get; set; }
            public string origen { get; set; }  //número de cuenta. Revisar que pasa cuando son bonificaciones del banco
            public string destino { get; set; } //Puede ser una tarjeta o un número de cuenta
            public double cantidad { get; set; }
            public double comision { get; set; }
            public string descripcion { get; set; }

            public Movimiento(string codigo, DateTime fecha, string tipo, string origen, string destino, double cantidad, double comision, string descripcion)
            {
                this.codigo = codigo;
                this.fecha = fecha;
                this.tipo = tipo;
                this.origen = origen;
                this.destino = destino;
                this.cantidad = cantidad;
                this.comision = comision;
                this.descripcion = descripcion;
            }

        }
    }
}
