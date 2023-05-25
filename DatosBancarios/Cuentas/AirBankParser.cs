using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DatosBancarios
{
    internal class AirBankParser : Cuentas
    {
        public AirBankParser(string contenido)
        {
            cuentaUsuario = Regex.Match(contenido, @"[0-9]*-?[0-9]* / [0-9]{4}").ToString().Replace(" ", "");
            string contenido2 = contenido.Substring(1000);

            List<string> coincidencias = Regex.Split(contenido, @"([0-9]{2}\.[0-9]{2}\.[0-9]{4}\n[0-9]{2}\.[0-9]{2}\.[0-9]{4})").ToList();//[0-9]{2}\.[0-9]{2}\.[0-9]{4}\n[0-9]{2}\.[0-9]{2}\.[0-9]{4}(\n| |.)*-?[0-9]* ?[0-9]*,[0-9]{2}\n \n-?[0-9]* ?[0-9]*,[0-9]{2}
            List<string> strmvtos = new List<string>();
            for (int i = 1; i < coincidencias.Count; i += 2)
            {
                string a = coincidencias[i] + coincidencias[i + 1];
                strmvtos.Add(a);
            }
            //650
            for (int i = 0; i < strmvtos.Count; i++)
            {
                string a = strmvtos[i];
                string origen;
                string destino;
                string descripcion = string.Empty;

                a= Regex.Split(strmvtos[i], @"Pokračování|Vklad|Úročení")[0].ToString();

                //a = Regex.Match(a, @"[0-9]{2}\.[0-9]{2}\.[0-9]{4}\n[0-9]{2}\.[0-9]{2}\.[0-9]{4}(\n| |.)*-?[0-9]* ?[0-9]*,[0-9]{2}\n \n-?[0-9]* ?[0-9]*,[0-9]{2}").ToString();
                a = a.Replace("\n \n", "\n");
                List<string> trocitos = Regex.Split(a, @"\n").ToList();

                while (trocitos[trocitos.Count - 1].Length < 3) { trocitos.RemoveAt(trocitos.Count - 1); }

                DateTime fecha = DateTime.Parse(trocitos[1]);
                string tipo = Regex.Match(trocitos[2], @"(Odchozí úhrada|Příchozí úhrada|Platba kartou|Výběr hotovosti|Vrácení peněz|Odměny za placení|Trvalý příkaz|Daň z úroku|Kreditní úrok|Pojistné|Odměna za platby|Měsíční poplatek|Příchozí SEPA)").ToString().Trim();
                string codigo;// = Regex.IsMatch(trocitos[3], @"[0-9]{11}") ? Regex.Match(trocitos[3], @"[0-9]{11}").ToString().Trim() : Regex.Match(trocitos[4], @"[0-9]{11}").ToString().Trim();
                if (Regex.IsMatch(trocitos[3], @"[0-9]{11}"))
                {
                    codigo = Regex.Match(trocitos[3], @"[0-9]{11}").ToString().Trim();
                }
                else
                {
                    codigo = Regex.Match(trocitos[4], @"[0-9]{11}").ToString().Trim();
                    trocitos.RemoveAt(3);
                }

                if (!Regex.IsMatch(codigo, @"[0-9]{11}"))
                {
                    int asdasd = 0;
                }

                double comision = double.Parse(trocitos[trocitos.Count-1].Replace(" ", ""));
                double cantidad = double.Parse(trocitos[trocitos.Count - 2].Replace(" ", ""));

                trocitos.RemoveRange(0, 4);
                trocitos.RemoveRange(trocitos.Count - 2, 2);
                

                string cuentaagena;
                if (Regex.IsMatch(trocitos[0], @"[0-9]{6}\*{6}[0-9]{4}|[0-9]*-?[0-9]* / [0-9]{4}"))
                {
                    cuentaagena = trocitos[0].Replace(" ", "");
                    trocitos.RemoveAt(0);
                }
                else
                {
                    if (Regex.IsMatch(trocitos[1], @"[0-9]{6}\*{6}[0-9]{4}|[0-9]*-?[0-9]* / [0-9]{4}"))
                    {
                        cuentaagena = trocitos[1].Replace(" ", "");
                        trocitos.RemoveAt(1);
                    }
                    else
                    {
                        cuentaagena = Regex.IsMatch(tipo, @"daň") ? "stát" : "Air Bank";
                    }
                }
                if (tipo == "Platba kartou")
                {
                    trocitos.RemoveAt(0);
                }
                foreach (var trocito in trocitos)
                {
                    descripcion += trocito.Trim() + " ";
                }


                origen = cantidad <= 0 ? cuentaUsuario : cuentaagena;
                destino = cantidad <= 0 ? cuentaagena : cuentaUsuario;
                cantidad = cantidad <0 ? -cantidad : cantidad;
                comision = comision < 0? -comision : comision;


                Movimiento mvto = new Movimiento(codigo, fecha, tipo, origen, destino, cantidad, comision, descripcion);
                movimientos.Add(mvto);
            }

            //"28.06.2021\r\n28.06.2021\r\n \r\nOdchozí úhrada\r\n48087858442\r\n \r\n107405665 / 0300\r\n \r\nVS2021992848\r\nÁlvaro Arias Martínez\r\n \r\n-5 110,00\r\n \r\n0,00"
        }
        //string asdasd = "01.05.2021\r\n01.05.2021\r\n \r\nPříchozí úhrada\r\n46260108822\r\n \r\nZuzana Pavlová\r\n1454883017 / 3030\r\n \r\nZkouška\r\n \r\n100,00\r\n \r\n0,00";
        //string asasd = "06.07.2022\n06.07.2022\n \nOdchozí úhrada\n63260920882\n \nZuzana Pavlová\n1454883017 / 3030\n  \n-5 000,00\n \n0,00";
        //public static GetStrings
    }
}
