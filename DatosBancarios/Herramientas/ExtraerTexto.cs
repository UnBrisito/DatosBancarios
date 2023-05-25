using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DatosBancarios.Herramientas
{
    public class ExtraerTexto
    {
        public List<string> contraseñas { get; set; } = new List<string>();
        public List<string> archivosPdf { get; set; } = new List<string>();
        public const string destino = "documentostxt";

        public ExtraerTexto() { }

        public List<string> Extraccion(bool todos = true)
        {
            List<string> ret = new List<string>();
            List<string> archivospdf = todos ? Directory.GetFiles(Extraerdemail.destino).ToList() : archivosPdf;
            foreach (string archivopdf in archivospdf)
            {
                string archivopdff = archivopdf.Replace("\\", "/");
                string archivotxt = Extraer(archivopdff);
                if (archivotxt.IsNullOrEmpty()) continue;
                ret.Add(archivotxt);
            }
            return ret;
        }

        public string Extraer(string origen)
        {

            string archivo = string.Empty;
            List <string> ctrseñas = contraseñas.Count > 0 ? contraseñas : new List<string>() { "" };

            foreach (string contraseña in ctrseñas)
            {

                try
                {
                    byte[] contraseñaB = System.Text.Encoding.Default.GetBytes(contraseña);

                    string texto = string.Empty;
                    using (PdfReader reader = new PdfReader(origen, contraseñaB))
                    {


                        for (int page = 1; page <= reader.NumberOfPages; page++)
                        {
                            //con SimpleTextExtractionStrategy el texto de cada celda aparece separado por un renglón vacío. 
                            //Con LocationTextExtractionStrategy el texto aparece como aparece en el documento, pero no se puede saber con certeza donde acaba una celda

                            ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();

                            string pagina = PdfTextExtractor.GetTextFromPage(reader, page, strategy);
                            texto += pagina;
                        }
                        archivo = destino + Regex.Match(origen, @"/.*\.pdf").ToString().Replace(".pdf", ".txt");
                        File.WriteAllText(archivo, texto);

                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    if(ex.Message == "Bad user password")
                    {
                        continue;
                    }
                    MessageBox.Show(ex.ToString());
                }
            }


            return archivo;
        }

    }
}
