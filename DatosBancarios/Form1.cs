using DatosBancarios.Herramientas;
using static DatosBancarios.Idiomas;
namespace DatosBancarios

{
    public partial class Form1 : Form
    {
        ExtraerTexto extractordetexto = new();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbBancosMail.DataSource = Cuentas.posiblesBancos;
            cbIdiomas.DataSource = idiomas;
            botonMail.AutoSize = true;
            setTextos();
        }
        private void setTextos()
        {
            botonIdioma.Text = getText("botonIdioma");
            botonMail.Text = getText("botonMail");
            botonContraseña.Text = getText("botonConstraseña");
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            string dirImap = "imap.gmail.com";
            string mail = "alvaroariasmartinez@gmail.com";
            string contraseña = "izenevfnowmaxkbe";
            string banco = "Air bank";
            extractordetexto.contraseñas.Add("777949085");
            extractordetexto.contraseñas.Add("608400244");

            //Extraerdemail extractordeemail = new(dirImap, mail, contraseña, banco);
            //List<string> archivosdescargados = extractordeemail.GetFiles();
            //extractordetexto.archivosPdf = archivosdescargados;

            //List<string> archivosextraidos = extractordetexto.Extraccion(true);
            List<string> archivostxt = Directory.GetFiles(ExtraerTexto.destino).ToList();
            foreach (string archivo in archivostxt)
            {
                Task.Factory.StartNew(() =>
                {
                    AirBankParser air = new(File.ReadAllText(archivo));
                    air.ADatabase();
                    MessageBox.Show(archivo);
                });
                
            }

        }

        private void botonIdioma_Click(object sender, EventArgs e)
        {
            Idioma = cbIdiomas.Text;
            setTextos();
        }
    }
}