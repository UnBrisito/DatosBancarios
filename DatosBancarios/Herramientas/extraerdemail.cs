using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MailKit;
using MailKit.Net.Imap;
using MimeKit;

namespace DatosBancarios
{
    public class Extraerdemail
    {
        public string dirImap { get; set; }
        public string mail { get; set; }
        public string contraseña { get; set; }
        public string banco { get; set; }
        public const string destino = "documentospdf";

        protected static readonly Dictionary<string, Regex> regexDic = new Dictionary<string, Regex>()
        {
            {"Air bank", new Regex(@"Vypis z bezneho uctu za.*\.pdf$") }
        };

        public Extraerdemail(string dirImap, string mail, string contraseña, string banco)
        {
            this.dirImap = dirImap;
            this.mail = mail;
            this.contraseña = contraseña;
            this.banco = banco;
            

        }
        
        
        public List<string> GetFiles()
        {
            List<string> files = new List<string>();

            using (var client = new ImapClient())
            {
                client.Connect(dirImap, 993, true);
                client.Authenticate(mail, contraseña);

                var inbox = client.Inbox;
                inbox.Open(FolderAccess.ReadOnly);

                Regex rg = regexDic[banco];
                if (!Directory.Exists(destino)) { Directory.CreateDirectory(destino); }

                foreach (var summary in inbox.Fetch(0, -1, MessageSummaryItems.UniqueId | MessageSummaryItems.BodyStructure))
                {
                    if (summary.Body is BodyPartMultipart)
                    {
                        var multipart = (BodyPartMultipart)summary.Body;
                        var attachment = multipart.BodyParts.OfType<BodyPartBasic>().FirstOrDefault(x => Checkid(x.FileName, rg));
                        if (attachment != null)
                        {
                            if (!File.Exists(attachment.FileName))
                            {
                                var part = (MimePart)inbox.GetBodyPart(summary.UniqueId, attachment);
                                using (var stream = File.Create($"{destino}/{attachment.FileName}")) { part.Content.DecodeTo(stream); }
                                files.Add($"{destino}/{attachment.FileName}");

                            }

                        }
                    }

                }
                client.Disconnect(true);
                MessageBox.Show($"{files.Count}");
            }
            return files;
        }

        protected static bool Checkid(string argstr, Regex rg)
        {
            if (argstr != null)
            {
                //Console.WriteLine(argstr);
                return rg.IsMatch(argstr);
            }
            else { return false; }
        }
    }
}
