using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Ninjin.Cindy;
using Ninjin.Cindy.Model;

namespace GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ListClient client;
        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    client = new ListClient(ModelType.Mondai);
                    client.FetchDataAsync();
                    break;
                case 1:
                    client = new ListClient(ModelType.Comment);
                    client.FetchDataAsync();
                    break;
                default:
                    break;
            }
            client.Load += () =>
            {
                var orderedMondais = client.Objects.OfType<Mondai>().OrderByDescending(x=>x.GiverExperience);
                var comments = client.Objects.OfType<Comment>();

                foreach (var item in orderedMondais)
                {
                    BeginInvoke(new Action(()=> { richTextBox1.Text += string.Format("{0}({1}):{2}\n", item.ToString(),item.Sender,item.Score); }));
                }
                foreach (var item in comments)
                {
                    BeginInvoke(new Action(() => { richTextBox1.Text += item.ToString()+":" + item.Mondai.Title + "\n"; }));
                }
            };
        }
    }
}
