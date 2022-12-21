using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MailLab
{
    public partial class Form1 : Form
    {

        List<string> files=new List<string>();
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                MailClass mail = new MailClass(textBox2.Text, textBox1.Text, files.ToArray(), smtp.Text, log.Text, pas.Text, int.Parse(por.Text),textBox3.Text);
                mail.Start();
            }
            catch (Exception)
            {
                MessageBox.Show("К сожалению, не удалось отправить сообщение, проверьте данные!");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;
            files.Add(openFileDialog1.FileName);
            MessageBox.Show("Добавление прошло успешно!");

        }
    }
}
