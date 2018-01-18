using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;

using Ninjin.Cindy;
using Ninjin.Cindy.Model;
using System.Threading.Tasks;

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
            listBox1.Items.Clear();
            client = new ListClient();
            
            await client.FetchDataAsync(ModelType.Mondai);
            await client.FetchDataAsync(ModelType.Comment);
            await client.FetchDataAsync(ModelType.Star);
            await client.FetchDataAsync(ModelType.User);
            var list = client.Objects.OfType<Mondai>().OrderByDescending(x => x.GiverExperience);
            BeginInvoke(new Action(() =>
            {
                foreach (var item in list)
                {
                    listBox1.Items.Add(item.ToString());
                }
                foreach (var item in client.Objects.OfType<Comment>())
                {
                    listBox1.Items.Add(item.ToString());
                }
                foreach (var item in client.Objects.OfType<Star>())
                {
                    listBox1.Items.Add(item.ToString());
                }
                foreach (var item in client.Objects.OfType<User>())
                {
                    listBox1.Items.Add(item.ToString());
                }
            }));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //check null
            if (client == null)
            {
                return;
            }
            //make sure an item in combobox is selected
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
                    else if (comboBox1.SelectedIndex == 4)
                    {
                        var mondais = client.Objects.OfType<Mondai>();
                        var stars = client.Objects.OfType<Star>();
                        var docs = client.Objects
                            .OfType<User>()
                            .Select(user => string.Format("{0},{1},{2},{3},{4}", user.Nickname, mondais.Count(x => x.SenderId == user.Id), stars.Count(x => x.Mondai.SenderId == user.Id), stars.Where(x=>x.Mondai.SenderId==user.Id).Sum(x => x.Value), user.Experience));
                        File.WriteAllText(dialog.FileName, "NickName,Mondai Count,Star Count,Total Star,Experience\n" + string.Join("\n", docs), System.Text.Encoding.GetEncoding("shift_jis"));
                    }
                }
            }
        }
    }
}
