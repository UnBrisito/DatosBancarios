using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DatosBancarios
{
    public static class Idiomas
    {
        public static readonly List<string> idiomas = getidiomas();
        private static string idioma = File.Exists("idioma.txt") ? File.ReadAllText("idioma.txt") : "Español";

        public static string Idioma
        {
            get => idioma;
            set 
            { 
                idioma = idiomas.Contains(value) ? value : throw new ArgumentException("idioma no válido"); 
                File.WriteAllText("idioma.txt", idioma);
            }
        }

        private static List<string> getidiomas()
        {
            List<string> list = new List<string>();
            using (SqlConnection conexion = new SqlConnection(Cuentas.sqlConString))
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'idiomas';", conexion);
                SqlDataReader reader = comando.ExecuteReader();
                reader.Read();
                while (reader.Read())
                {
                    string lang = (string)reader["COLUMN_NAME"];
                    list.Add(lang);

                }
                reader.Close();
                conexion.Close();
            }

            return list;
        }

        public static string getText(string lugar)
        {
            string texto = string.Empty;
            using (SqlConnection conexion = new SqlConnection(Cuentas.sqlConString))
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand($"select {Idiomas.idioma} from idiomas where lugar = '{lugar}'", conexion);
                SqlDataReader reader = comando.ExecuteReader();

                reader.Read();
                texto = (string)reader[Idiomas.idioma];

                reader.Close();
                conexion.Close();
            }
            return texto;
        }


        
    }
}
