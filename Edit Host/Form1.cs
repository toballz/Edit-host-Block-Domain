using System;
using System.IO;
using System.Windows.Forms;

namespace Edit_Host
{
    public partial class Form1 : Form
    {
        private const string _kip = "211.222.233.244";
        private const string _watermark = "#by_edithost";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string _domain2add = new Uri(domain2add.Text).Host.Trim();

                string _hostfile = File.ReadAllText(@"C:\Windows\System32\drivers\etc\hosts");
                if (_hostfile.Contains(_domain2add) == false)
                {
                    using (StreamWriter sw = File.AppendText(@"C:\Windows\System32\drivers\etc\hosts"))
                    {
                        sw.WriteLine(_kip + " " + _domain2add + " " + _watermark);
                        domain2add.Text = _domain2add;
                    }
                }
                else
                {
                    MessageBox.Show("Domain already there.");
                }
            }catch(Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}
