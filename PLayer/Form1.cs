using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace PLayer
{
    public partial class Form1 : Form
    {
        static string[] files = Directory.GetFiles("C:\\", "*.mp3");//pobiera liste piosenek z na dysku C:\\ 
        WMPLib.WindowsMediaPlayer players = new WMPLib.WindowsMediaPlayer();
       

        public Form1()
        {
            InitializeComponent();
            dataGridView1.ColumnCount = 1;
            dataGridView1.Columns[0].Name = "Tytuł";            
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            for (int n = 0; n < files.Length; n++)
            {
                dataGridView1.Rows.Add(files[n]);                    
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell != null) {
                int currentIndex = dataGridView1.CurrentCell.RowIndex;
                players.URL = files[currentIndex];
                players.controls.play();
            }
            
        }//play the selected index

        private void button3_Click(object sender, EventArgs e)
        {
            players.controls.stop();
        }//stop

        private void button4_Click(object sender, EventArgs e)
        {
            Random rng = new Random();
            int n = files.Length;
            int x = rng.Next(n);
            players.URL = files[x];
            players.controls.play();            
            dataGridView1.ClearSelection();

        }//shuffle

        private void button2_Click(object sender, EventArgs e)
        {
            players.controls.pause();
        }//pause

        private void button5_Click(object sender, EventArgs e)
        {
            using(var fbd = new OpenFileDialog())
            {
                fbd.Filter = "mp3 files (*.mp3)|*.mp3";
                DialogResult result= fbd.ShowDialog();
                if (result == DialogResult.OK) {                  
                    files = files.Concat(new string[] { fbd.FileName }).ToArray();
                    dataGridView1.Rows.Add(fbd.FileName);
                                       
                }
                
            }
            
        }//dodawanie pojedynczych plików
    }
}
