using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DPlayer
{
    public partial class Form1 : Form
    {
        protected Outputable artistList = new Outputable();
        protected Outputable playList = new Outputable();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddArtist();
        }

        private void AddArtist()
        {
            if (IsValid(textBox1))
            {
                this.artistList.Add(new Artist(){ Title = textBox1.Text} );
                OutputArtists();
            }

        }

        private void OutputArtists()
        {
            this.artistList.OutputInListBox(this.listBox3);
            this.artistList.OutputInComboBox(this.comboBox1);
            this.artistList.OutputInComboBox(this.comboBox3);
            this.artistList.OutputInComboBox(this.comboBox4);
            textBox1.Clear();
        }

        private bool IsValid(TextBox textBox)
        {
            if (textBox.Text == "")
            {
                MessageBox.Show("Enter data");
                return false;
            }
            return true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            EditArtist();
        }

        private void EditArtist()
        {
            if (IsValid(textBox1) && HasSelected(listBox3))
            {
                this.artistList[listBox3.SelectedIndex] = new Artist() { Title = textBox1.Text };
                OutputArtists();
            }
        }

        private bool HasSelected(ListBox listBox)
        {
            if (listBox.SelectedIndex == -1)
            {
                MessageBox.Show("Select item");
                return false;
            }
            return true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RemoveArtist();
        }

        private void RemoveArtist()
        {
            if (HasSelected(listBox3))
            {
                artistList.RemoveAt(listBox3.SelectedIndex);
                OutputArtists();
            }
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = listBox3.SelectedItem.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AddAlbum();
        }

        private void AddAlbum()
        {
            if (IsValid(textBox2) && HasSelectedC(comboBox3))
            {
                Artist a = (Artist)artistList[comboBox3.SelectedIndex];
                a.Albums.Add(
                    new Album() { Title = textBox2.Text, Artist = a }
                    );
                OutputAlbums();
            }
        }

        private bool HasSelectedC(ComboBox comboBox, bool flag = true)
        {
            if (comboBox.SelectedIndex == -1)
            {
                if (flag)
                {
                    MessageBox.Show("Select item");
                }
                return false;
            }
            return true;
        }

        private void OutputAlbums()
        {
            textBox2.Clear();
            if (HasSelectedC(comboBox4, false))
            {
                ((Artist)artistList[comboBox4.SelectedIndex]).Albums.OutputInComboBox(comboBox5);
            }
            ((Artist)artistList[comboBox3.SelectedIndex]).Albums.OutputInListBox(listBox4);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((Artist)artistList[comboBox3.SelectedIndex]).Albums.OutputInListBox(listBox4);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            EditAlbum();

        }

        private void EditAlbum()
        {
            if (IsValid(textBox2) && HasSelectedC(comboBox3) && HasSelected(listBox4))
            {
                Artist a = (Artist)artistList[comboBox3.SelectedIndex];
                a.Albums[listBox4.SelectedIndex] = new Album() { Title = textBox2.Text, Artist = a };
                OutputAlbums();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            RemoveAlbum();
        }

        private void RemoveAlbum()
        {
            if (HasSelected(listBox4) && HasSelectedC(comboBox3))
            {
                Artist a = (Artist)artistList[comboBox3.SelectedIndex];
                a.Albums.RemoveAt(listBox4.SelectedIndex);
                OutputAlbums();
            }
        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.Text = listBox4.SelectedItem.ToString();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            AddTrack();
        }

        private void AddTrack()
        {
            if (IsValid(textBox3) && HasSelectedC(comboBox4) && HasSelectedC(comboBox5))
            {
                Artist a = (Artist)artistList[comboBox4.SelectedIndex];
                Album al = (Album)a.Albums[comboBox5.SelectedIndex];
                al.Tracks.Add(new Track() { Title = textBox3.Text, Album = al });
                OutputTracks();
            }
        }

        private void listBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox3.Text = listBox5.SelectedItem.ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            RemoveTrack();
        }

        private void RemoveTrack()
        {
            if (HasSelected(listBox5)) 
            {
                Artist a = (Artist)artistList[comboBox4.SelectedIndex];
                Album al = (Album)a.Albums[comboBox5.SelectedIndex];
                al.Tracks.RemoveAt(listBox5.SelectedIndex);
                OutputTracks();
            }
        }

        private void OutputTracks()
        {
                Artist a = (Artist)artistList[comboBox4.SelectedIndex];
                Album al = (Album)a.Albums[comboBox5.SelectedIndex];
                al.Tracks.OutputInListBox(listBox5);
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (HasSelectedC(comboBox4, false))
            {
                ((Artist)artistList[comboBox4.SelectedIndex]).Albums.OutputInComboBox(comboBox5);
            }

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (HasSelectedC(comboBox5, false))
            {
                Artist a = (Artist)artistList[comboBox4.SelectedIndex];
                Album al = (Album)a.Albums[comboBox5.SelectedIndex];
                al.Tracks.OutputInListBox(listBox5);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (HasSelectedC(comboBox1, false))
            {
                Artist a = (Artist)artistList[comboBox1.SelectedIndex];
                a.Albums.OutputInComboBox(comboBox2);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (HasSelectedC(comboBox1, false))
            {
                Artist a = (Artist)artistList[comboBox1.SelectedIndex];
                Album al = (Album)a.Albums[comboBox2.SelectedIndex];
                al.Tracks.OutputInListBox(listBox1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddToPlayList();
        }

        private void AddToPlayList()
        {
            if (HasSelectedC(comboBox1) && HasSelectedC(comboBox2) && HasSelected(listBox1))
            {
                Artist a = (Artist)artistList[comboBox1.SelectedIndex];
                Album al = (Album)a.Albums[comboBox2.SelectedIndex];
                Track t = (Track)al.Tracks[listBox1.SelectedIndex];
                playList.Add(t);
                OutputPlayList();
            }
        }

        private void OutputPlayList()
        {
            this.playList.OutputInListBox(listBox2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (HasSelected(listBox2))
            {
                listBox2.Items.RemoveAt(listBox2.SelectedIndex);
                OutputPlayList();
            }

        }        

    }
}
