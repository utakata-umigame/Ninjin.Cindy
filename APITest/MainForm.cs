using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;

using Ninjin.Cindy;
using Ninjin.Cindy.Model;

namespace Test
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        ListClient client;
        private async void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            client = new ListClient();
            
            await client.FetchDataAsync(ModelType.Mondai);
            await client.FetchDataAsync(ModelType.Comment);
            await client.FetchDataAsync(ModelType.Star);
            await client.FetchDataAsync(ModelType.User);
            var list = client.Objects.OfType<Mondai>().OrderByDescending(x => x.GiverExperience);
            foreach (var item in list)
            {
                BeginInvoke(new Action(() =>
                {
                    richTextBox1.Text += item.ToString();
                }));
            }
            foreach (var item in client.Objects.OfType<Comment>())
            {
                BeginInvoke(new Action(() =>
                {
                    richTextBox1.Text += item.ToString();
                }));
            }
            foreach (var item in client.Objects.OfType<Star>())
            {
                BeginInvoke(new Action(() =>
                {
                    richTextBox1.Text += item.ToString();
                }));
            }
            foreach(var item in client.Objects.OfType<User>())
            {
                BeginInvoke(new Action(() =>
                {
                    richTextBox1.Text += item.ToString();
                }));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //check null
            if (client == null)
            {
                return;
            }
            //check combobox selected
            if (comboBox1.SelectedIndex == -1)
            {
                return;
            }
            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = "CSVファイル(*.csv)|*.csv|TSVファイル(*.tsv)|*.tsv|すべてのファイル(*.*)|*.*";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    if (comboBox1.SelectedIndex == 0)
                    {
                        File.WriteAllText(dialog.FileName, Mondai.CsvHeader + string.Join("", client.Objects.OfType<Mondai>()), System.Text.Encoding.GetEncoding("shift_jis"));
                    }
                    else if (comboBox1.SelectedIndex == 1)
                    {
                        File.WriteAllText(dialog.FileName, Comment.CsvHeader + string.Join("", client.Objects.OfType<Comment>()), System.Text.Encoding.GetEncoding("shift_jis"));
                    }
                    else if (comboBox1.SelectedIndex == 2)
                    {
                        File.WriteAllText(dialog.FileName, Star.CsvHeader + string.Join("", client.Objects.OfType<Star>()), System.Text.Encoding.GetEncoding("shift_jis"));
                    }
                    else if (comboBox1.SelectedIndex == 3)
                    {
                        File.WriteAllText(dialog.FileName, User.CsvHeader + string.Join("", client.Objects.OfType<User>()), System.Text.Encoding.GetEncoding("shift_jis"));
                    }
                }
            }
        }
    }
}
