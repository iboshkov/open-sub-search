using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenSubSearchLib;

namespace OpenSubSearch
{
    public partial class Form1 : Form
    {
        private Metadata _meta;

        private Metadata meta
        {
            get { return _meta; }
            set
            {
                _meta = value;
                meta_changed();
            }
        }

        private String _hashStr;

        protected String hashStr
        {
            get { return _hashStr; }
            set
            {
                _hashStr = value;
                hash_changed();
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        public void hash_changed()
        {
            var _hash = hashStr != null ? hashStr : "Calculating...";
            hashLabel.Text = $"Hash: {_hash}";
        }

        public void meta_changed()
        {
            meta_title.Text = meta.title;
            meta_season.Text = meta.season >= 0 ? meta.season.ToString() : "";
            meta_episode.Text = meta.episode >= 0 ? meta.episode.ToString() : "";
            meta_group.Text = meta.group;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            Console.WriteLine(openFileDialog1.FileName);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult res = openFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                processFile(openFileDialog1.FileName);
            }
        }

        private void processFile(String filepath)
        {
            String filename = Path.GetFileNameWithoutExtension(filepath);
            FilenameParser parser = new FilenameParser(filename);
            meta = parser.parse();
            backgroundWorker1.RunWorkerAsync(filepath);
            hashStr = null;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            String path = (string) e.Argument;

            String hashStr = "";

            using (var stream = File.OpenRead(path))
            {
                byte[] hash = HashUtils.calculateMD5(stream, (float progress) =>
                {
                    Console.WriteLine($"Progress {progress}");
                    backgroundWorker1.ReportProgress((int)(progress * 100));
                });
                hashStr = BitConverter.ToString(hash).Replace("-", "").ToLower();
            }

            e.Result = hashStr;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            hashProgress.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            hashStr = e.Result as string;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] filePaths = (string[])(e.Data.GetData(DataFormats.FileDrop));
                foreach (string fileLoc in filePaths)
                {
                    Console.WriteLine(fileLoc);
                    processFile(fileLoc);
                }
            }
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }
    }
}