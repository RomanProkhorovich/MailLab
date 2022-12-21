using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using System.Xml.Linq;

namespace MailLab
{
    internal class MailClass
    {
        private  string Host;
        private  string DisplayName = "This is Laba";
        private  string myAddres;
        private  string pass;
        private  int port=25 ;
        private string sub;
        private string userAddres;
        private string text;
        private string[] files;

       public void Start()
        {
            MailAddress from = new MailAddress(myAddres, DisplayName);
            MailAddress to = new MailAddress(userAddres);
            MailMessage mes = new MailMessage(from, to);
            mes.Subject = sub;
            mes.Body = text;
            foreach (var item in files)
            {
                mes.Attachments.Add(new Attachment(item));
            }
            SmtpClient smtp = new SmtpClient(Host, port);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(myAddres, pass);
            smtp.EnableSsl = true;
            smtp.Send(mes);
        }
        public MailClass(string userAddres, string text, string[] files,string host, string add, string pas,int p,string subj)
        {
            this.userAddres = userAddres;
            this.text = text;
            this.files = files;
            Host = host;
            myAddres = add;
            pass = pas;
            port= p;
            sub= subj;
        }
    }

    
}
