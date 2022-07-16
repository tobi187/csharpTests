using Microsoft.AspNetCore.SignalR.Client;

namespace Kniffel
{
    public partial class Form1 : Form
    {
        public List<Button> wuerfelAnzeige { get; set; }
        public List<TextBox> zahlBoxen { get; set; }
        public List<TextBox> sonderBoxen { get; set; }
        public List<dynamic> allControls { get; set; } = new List<dynamic>();
        public bool isPlaying { get; set; }
        public string groupNr;
        HubConnection connection;

        public Form1(string gNr, bool firstPlayer, HubConnection conn)
        {
            isPlaying = firstPlayer;
            connection = conn;
            groupNr = gNr;
            InitializeComponent();
            WurfCounter.Text = "3";

            MultiplayerConnection();
        }

        public async void MultiplayerConnection()
        {
            connection.On<string>("PlayerChange", (count) =>
            {
                isPlaying = !isPlaying;
                if (isPlaying)
                {
                    enemyPoints.Text = count;
                    EnableAll();
                }
                else
                    DisableAll();
            });

            connection.On<bool>("StartGameFirst", async (isFirst) =>
            {
                isPlaying = !isFirst;
                await connection.InvokeAsync("OnChange", groupNr, "0");
            });


            if (isPlaying)
                await connection.InvokeAsync("OnStart", groupNr);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            wuerfelAnzeige = new List<Button>()
            {
                button1,
                button2,
                button3,
                button4,
                button5,
            };
            wuerfelAnzeige.ForEach(x => x.Text = "0");

            zahlBoxen = new()
            {
                einserBox,
                zweierBox,
                dreierBox,
                viererBox,
                fuenferBox,
                sechserBox
            };

            sonderBoxen = new()
            {
                dreierpasch_box,
                viererpasch_box,
                KniffelBox,
                fullHouseBox,
                textBox3,
                textBox1
            };
            sonderBoxen.ForEach(x => allControls.Add(x));
            zahlBoxen.ForEach(x => allControls.Add(x));
            wuerfelAnzeige.ForEach(x => allControls.Add(x));
            allControls.Add(wuerfelButton);
        }

        private void wuerfelButton_Click(object sender, EventArgs e)
        {
            if (WurfCounter.Text == "1")
                wuerfelButton.Enabled = false;

            WurfCounter.Text = (int.Parse(WurfCounter.Text) - 1).ToString();

            var r = new Random();
            foreach (var wuerfel in wuerfelAnzeige)
            {
                if (wuerfel.Enabled)
                    wuerfel.Text = r.Next(1, 7).ToString();
            }
        }

        private void LockWuerfel(object sender, EventArgs e)
        {
            var button = (Button)sender;
            button.Enabled = false;
            button.BackColor = Color.Green;
        }

        public void BoxClickEvent(object sender, EventArgs e)
        {
            var boxIndex = zahlBoxen.IndexOf((TextBox)sender);
            var sumOfOnes =
                wuerfelAnzeige
                .Select(x => int.Parse(x.Text))
                .Where(x => x == boxIndex + 1)
                .Sum();

            ((TextBox)sender).Text = sumOfOnes.ToString();
            allControls.Remove((TextBox)sender);
            
            gesamtBox.Text =
                zahlBoxen
                .Where(x => x.Text != "")
                .Select(x => int.Parse(x.Text))
                .Sum()
                .ToString();
            
            RenewWuerfel();
        }

        private async void RenewWuerfel()
        {
            if (zahlBoxen.All(x => x.Enabled == false) && sonderBoxen.All(x => x.Enabled == false))
            {
                gesamtBox.Text = "0";
                for (var i = 0; i < zahlBoxen.Count; i++)
                {
                    zahlBoxen[i].Text = "";
                    zahlBoxen[i].Enabled = true;
                    sonderBoxen[i].Text = "";
                    sonderBoxen[i].Enabled = true;
                }
            }

            WurfCounter.Text = "3";
            foreach (var wuerfel in wuerfelAnzeige)
            {
                wuerfel.Text = "0";
                wuerfel.Enabled = true;
                wuerfel.BackColor = Color.White;
            }

            await connection.InvokeAsync("OnChange", groupNr, gesamtBox.Text);
        }

        private void fullHouseBox_Click(object sender, EventArgs e)
        {
            var result = wuerfelAnzeige.GroupBy(x => x.Text);

            if (result.Count() == 2 && result.Any(x => x.Count() == 2))
            {
                fullHouseBox.Text = "25";
            }
            else
            {
                fullHouseBox.Text = "0";
            }
            allControls.Remove(fullHouseBox);
        }

        async void button6_Click(object sender, EventArgs e)
        {
            var wielandtext = textBox2.Text;

            bool has_only_valid_digits = wielandtext.All(x => "123456".Contains(x));
            if (!has_only_valid_digits)
            {
                button6.Enabled = false;
                label10.Show();
                await Task.Delay(2000);
                button6.Enabled = true;
                await Task.Delay(3000);
                label10.Hide();
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    if (wielandtext.Length > i)
                        wuerfelAnzeige[i].Text = wielandtext[i].ToString();
                }
            }
        }
        private void pasch_eintragen(TextBox tb, int pasch)
        {
            var wuerfelMenge = new int[] { 0, 0, 0, 0, 0, 0, 0 };
            for (int i = 0; i < wuerfelAnzeige.Count; i++)
            {
                var gewuerfelte_zahl = int.Parse(wuerfelAnzeige[i].Text);
                wuerfelMenge[gewuerfelte_zahl] += 1;
            }
            if (wuerfelMenge.Any(x => x >= pasch))
            {
                var sum = 0;
                for (int i = 0; i < wuerfelMenge.Count(); i++)
                {
                    var x = wuerfelMenge[i] * i;
                    sum += x;
                }
                tb.Text = sum.ToString();
            }
            else
            {
                tb.Text = "0";
            }
            allControls.Remove(tb);
            RenewWuerfel();
        }

        private void dreierpasch_box_Click(object sender, EventArgs e)
        {
            pasch_eintragen(dreierpasch_box, 3);
        }

        private void viererpasch_box_Click(object sender, EventArgs e)
        {
            pasch_eintragen(viererpasch_box, 4);
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            List<int> gstreet1 = new List<int>() { 1, 2, 3, 4, 5 };
            List<int> gstreet2 = new List<int>() { 2, 3, 4, 5, 6 };
            var wuerfel = wuerfelAnzeige.Select(x => int.Parse(x.Text)).ToList();

            wuerfel.Sort();
            if (Enumerable.SequenceEqual(gstreet1, wuerfel))
            {
                textBox1.Text = "40";
            }
            else if (Enumerable.SequenceEqual(gstreet2, wuerfel))
            {
                textBox1.Text = "40";
            }
            else
            {
                textBox1.Text = "0";
            }
            allControls.Remove(textBox1);
            RenewWuerfel();
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            if (CheckForSmallStreet())
            {
                textBox3.Text = "30";
            }
            else
            {
                textBox3.Text = "0";
            }
            allControls.Remove(textBox3);
            RenewWuerfel();
        }

        public bool CheckForSmallStreet()
        {
            wuerfelAnzeige = wuerfelAnzeige.Distinct().ToList();
            var wuerfel = wuerfelAnzeige.Select(x => int.Parse(x.Text)).OrderBy(x => x).ToList();
            List<int> test_if_street = new List<int>();
            for (int i = 1; i < wuerfel.Count; i++)
            {

                var kstreet = wuerfel[i] - (wuerfel[i - 1]);
                if (kstreet == 1)
                {
                    test_if_street.Add(i);
                }
                else
                {
                    test_if_street.Clear();
                }

                if (test_if_street.Count >= 3)
                {
                    return true;
                }
            }
            return false;
        }

        private void KniffelBox_Click(object sender, EventArgs e)
        {
            if (wuerfelAnzeige.All(x => x.Text == wuerfelAnzeige[0].Text))
                KniffelBox.Text = "50";
            else
                KniffelBox.Text = "0";

            allControls.Remove(KniffelBox);
            RenewWuerfel();
        }

        private void DisableAll()
        {
            foreach (Control c in Controls)
            {
                c.Enabled = false;
            }
        }
        private void EnableAll()
        {
            foreach (Control c in allControls)
            {
                c.Enabled = true;
            }
        }
    }
}