using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;

namespace Typing_test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            current_cubes = new Dictionary<char, List<Label>>();

            r = new Random();

            deadline_textbox_cube_right = deadline_textbox.Right - cube_size.Width;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Player_name = name_textbox.Text;
            HP = init_HP;
            Score = 0;
            // 0 => game is stopped 1 => game start
            game_state = 0;
            stored_time = 0;

            foreach (KeyValuePair<char, List<Label>> pair in current_cubes)
            {
                for (int i = 0; i < pair.Value.Count; ++i)
                    pair.Value[i].Dispose();

                pair.Value.Clear();
            }

            current_cubes.Clear();

            current_cubes = new Dictionary<char, List<Label>>();

            start_btn.Enabled = true;

            FileInfo finfo = new FileInfo(score_path);
            StreamWriter sw = finfo.AppendText();
            sw.Close();

            log_textbox.Text = "";
            StreamReader sr = new StreamReader(score_path);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] line_split = line.Split(' ');
                log_textbox.Text += score_log(
                    line_split[0],
                    int.Parse(line_split[1]),
                    System.DateTime.ParseExact(line_split[2] + " " + line_split[3], "yyyy/M/d HH:mm:ss", CultureInfo.InvariantCulture)
                );
            }
            sr.Close();
        }

        private void start_btn_Click(object sender, EventArgs e)
        {
            switch (game_state)
            {
                case 0:
                    game_state = 1;
                    start_btn.Enabled = false;
                    timer.Start();
                    break;
                default:
                    log_textbox.Text += "unexpected game_state in start_btn_Click\r\n";
                    break;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            switch (game_state)
            {
                case 1:
                    stored_time += timer.Interval;
                    if (stored_time > cube_interval)
                    {
                        // generate cubes
                        char basic = 'a', c;

                        if (r.Next(10) == 0)
                            basic = 'A';

                        c = (char)(r.Next(26) + basic);

                        Label cube = new Label();
                        cube.BackColor = Color.Black;
                        cube.ForeColor = Color.White;
                        cube.Font = new Font(cube.Font.Name, cube_font_size, FontStyle.Bold);
                        cube.Size = cube_size;
                        cube.Text = c.ToString();

                        Controls.Add(cube);

                        cube.Top = 0;
                        cube.Left = r.Next(deadline_textbox.Left, deadline_textbox_cube_right);

                        if (current_cubes.ContainsKey(c))
                            current_cubes[c].Add(cube);
                        else
                            current_cubes[c] = new List<Label>() { cube };

                        stored_time = 0; 
                    }

                    // move those cubes
                    foreach (KeyValuePair<char, List<Label>> pair in current_cubes)
                        for (int i = 0; i < pair.Value.Count; ++i)
                        {
                            pair.Value[i].Top += (int)gravity;

                            if (pair.Value[i].Bottom >= deadline_textbox.Top)
                            {
                                // bomb
                                if (HP == 1)
                                {
                                    // avoid the error in foreach
                                    --HP;
                                    return;
                                }

                                --HP;
                                
                                pair.Value[i].Dispose();
                                pair.Value.RemoveAt(i);
                                --i;
                            }
                        }
                    break;
                default:
                    break;
            }
        }

        void check_typing(char c)
        {
            try
            {
                if (current_cubes.ContainsKey(c))
                {
                    current_cubes[c][0].Dispose();
                    current_cubes[c].RemoveAt(0);

                    if (current_cubes[c].Count == 0)
                        current_cubes.Remove(c);

                    ++Score;
                }
            }
            catch
            {
                return;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (game_state)
            {
                case 1:

                    // capital
                    // 16 is the "shift" code in int
                    if (e.Shift && e.KeyValue != 16)
                        check_typing((char)e.KeyValue);

                    // small
                    if (!e.Shift)
                        check_typing((char)(e.KeyValue + 32));
                    break;
                default:
                    break;
            }
        }

        private void restart_btn_Click(object sender, EventArgs e)
        {
            Form1_Load(this, null);
        }

        private void name_btn_Click(object sender, EventArgs e)
        {
            Player_name = name_textbox.Text;
        }

        string score_log(string n, int s, System.DateTime t)
        {
            return "player " + n + " get " + s.ToString() + " points at "
                + string.Format("{0:yyyy/M/d HH:mm:ss}", t) + "\r\n";
        }
        
        private void clear_btn_Click(object sender, EventArgs e)
        {
            log_textbox.Text = "";
            FileInfo finfo = new FileInfo(score_path);
            finfo.Delete();
        }

        string Player_name
        {
            get { return player_name; }
            set
            {
                player_name = value;
                name_label.Text = "player: " + player_name;
            }
        }

        int Score
        {
            get { return score; }
            set
            {
                score = value;
                score_label.Text = "score:\r\n" + score.ToString();

                gravity = (00.2f + score * 0.005f) * timer.Interval;
            }
        }

        int HP
        {
            get { return hp; }
            set
            {
                hp = value;
                HP_label.Text = "HP:\r\n" + hp.ToString();

                if (hp == 0 && game_state == 1)
                {
                    // game over

                    // show score log
                    log_textbox.Text += score_log(Player_name, Score, System.DateTime.Now);

                    // store the score log
                    StreamWriter sw = new StreamWriter(score_path, true);
                    sw.WriteLine(Player_name + " " + Score.ToString() + " "
                        + string.Format("{0:yyyy/M/d HH:mm:ss}", System.DateTime.Now));
                    sw.Close();

                    timer.Stop();

                    Form1_Load(this, null);
                }

            }
        }

        Dictionary<char, List<Label>> current_cubes;

        Random r;
        Size cube_size = new Size(30, 30);
        string score_path = @"score.txt";
        string player_name;
        float gravity;
        int init_HP = 10, cube_interval = 499, cube_font_size = 20;
        int hp, score, game_state, stored_time;
        int deadline_textbox_cube_right;
    }
}
