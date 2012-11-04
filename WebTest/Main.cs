using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WebTest
{
    public partial class Main : Form
    {
        private string url1 = "";
        private string url2 = "";
        private DateTime StartTime;
        private bool isCancel = false;

        private static int runPerThread = 0;
        private static bool toggle = false;
        private static bool kill = false;
        private static object locker = new object();
        private static List<float> resultsURL1 = new List<float>();
        private static List<float> resultsURL2 = new List<float>();
        private static object drawlocker = new object();
        private static bool drawing = false;
        private static int exited = 0;
        private static float averageURL1 = 0;
        private static float url1_low = 0;
        private static float url1_high = 0;
        private static float averageURL2 = 0;
        private static float url2_low = 0;
        private static float url2_high = 0;

        System.ComponentModel.BackgroundWorker[] Workers;

        public Main()
        {
            InitializeComponent();
        }

        private void CodeButton_Click(object sender, EventArgs e)
        {
            Code codePage = new Code();
            codePage.Show();
        }

        private void Go_Click(object sender, EventArgs e)
        {
            if (isCancel)
            {
                DialogResult result = MessageBox.Show("Would you liek to cancel?", "Cancel?", MessageBoxButtons.YesNo);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    lock (locker)
                    {
                        kill = true;
                    }
                    return;
                }
                else
                {
                    return;
                }
            }

            //New start
            Go.Text = "Cancel";
            Workers = new BackgroundWorker[int.Parse(ThreadCount.Value.ToString())];

            runPerThread = (int.Parse(testNumber.Value.ToString()) / int.Parse(ThreadCount.Value.ToString()) * 2);
            url1 = url1Editable.Text;
            url2 = url2Ediable.Text;
            exited = 0;
            averageURL1 = 0;
            averageURL2 = 0;
            QuickCompare.Items.Clear();

            for (int i = 0; i < Workers.Length; i++)
            {
                Workers[i] = new BackgroundWorker();
                Workers[i].DoWork += new System.ComponentModel.DoWorkEventHandler(bw1_running);
                Workers[i].RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw1_RunWorkerCompleted);
                Workers[i].RunWorkerAsync();
            }
        }

        void bw1_running(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            int runs = 0;
            bool toogle = false;
            lock (locker)
            {
                runs = runPerThread;
                toogle = toggle;
                if ((runs % 2) == 1)
                {
                    toggle = !toggle;
                }
            }

            System.Net.WebClient WorkingClient = new System.Net.WebClient();
            string temp_text = "";

            List<float> LocalresultsURL1 = new List<float>();
            List<float> LocalresultsURL2 = new List<float>();

            for(int k = 0; k < runs; k++)
            {
                bool localKill = false;
                lock (locker)
                {
                    if (kill)
                    {
                        localKill = kill;
                    }
                }
                if (localKill)
                {
                    return;
                }
                if (!toogle)
                {
                    temp_text = WorkingClient.DownloadString(url1);
                }
                else
                {
                    temp_text = WorkingClient.DownloadString(url2);
                }


                int pos = temp_text.IndexOf("seconds ") + 8;
                int pos2 = temp_text.IndexOf(" ",pos);
                if (!toogle)
                {
                    if (pos2 == -1)
                    {
                        LocalresultsURL1.Add(float.Parse(temp_text.Substring(pos)));
                    }
                    else
                    {
                        LocalresultsURL1.Add(float.Parse(temp_text.Substring(pos, pos2 - pos)));
                    }
                }
                else
                {
                    if (pos2 == -1)
                    {
                        LocalresultsURL2.Add(float.Parse(temp_text.Substring(pos)));
                    }
                    else
                    {
                        LocalresultsURL2.Add(float.Parse(temp_text.Substring(pos, pos2 - pos)));
                    }
                }
                
                toogle = !toogle;
            }
            lock (locker)
            {
                resultsURL1.AddRange(LocalresultsURL1);
                resultsURL2.AddRange(LocalresultsURL2);
            }
        }

        private void bw1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lock (drawlocker)
            {
                drawing = true;
            }
            lock (locker)
            {
                //keep last element
                int loopcount = 0;
                if (resultsURL1.Count != resultsURL2.Count)
                {
                    if (resultsURL1.Count < resultsURL2.Count)
                    {
                        loopcount = resultsURL1.Count;
                    }else{
                        loopcount = resultsURL2.Count;
                    }
                }else{
                    loopcount = resultsURL1.Count;
                }

                for (int j = 0; j < loopcount; j++)
                {
                    ListViewItem tempItem = new ListViewItem();

                    if (url1_low != 0)
                    {
                        if (resultsURL1[j] < url1_low)
                        {
                            url1_low = resultsURL1[j];
                        }
                    }
                    else
                    {
                        url1_low = resultsURL1[j];
                    }

                    if (url1_high != 0)
                    {
                        if (resultsURL1[j] > url1_high)
                        {
                            url1_high = resultsURL1[j];
                        }
                    }
                    else
                    {
                        url1_high = resultsURL1[j];
                    }


                    tempItem.Text = resultsURL1[j].ToString();
                    averageURL1 += resultsURL1[j];
                    if (resultsURL1[j] < resultsURL2[j])
                    {
                         tempItem.SubItems.Add(@"<     ");
                    }else{
                        tempItem.SubItems.Add(@"     >");
                    }
                    tempItem.SubItems.Add(resultsURL2[j].ToString());

                    if (url2_low != 0)
                    {
                        if (resultsURL2[j] < url2_low)
                        {
                            url2_low = resultsURL2[j];
                        }
                    }
                    else
                    {
                        url2_low = resultsURL2[j];
                    }

                    if (url2_high != 0)
                    {
                        if (resultsURL2[j] > url2_high)
                        {
                            url2_high = resultsURL2[j];
                        }
                    }
                    else
                    {
                        url2_high = resultsURL2[j];
                    }

                    averageURL2 += resultsURL2[j];
                    QuickCompare.Items.Add(tempItem);
                    QuickCompare.Items[QuickCompare.Items.Count - 1].Group = QuickCompare.Groups[1];
                }
                resultsURL1.Clear();
                resultsURL2.Clear();
                int getexited = 0;
                lock (drawlocker)
                {
                    getexited = exited;
                }
                if (getexited == (Workers.Count() - 1))
                {
                    ListViewItem tempItem = new ListViewItem();
                    tempItem.Text = (averageURL1 / ((runPerThread / 2) * Workers.Count())).ToString();
                    if (averageURL1 < averageURL2)//odds of collision are low
                    {
                        tempItem.SubItems.Add(@"<     ");
                    }
                    else
                    {
                        if (averageURL1 == averageURL2)
                        {
                            tempItem.SubItems.Add(@"  =   ");
                        }
                        else
                        {
                            tempItem.SubItems.Add(@"     >");
                        }
                    }
                    tempItem.SubItems.Add((averageURL2 / ((runPerThread / 2) * Workers.Count())).ToString());
                    QuickCompare.Items.Add(tempItem);
                    QuickCompare.Items[QuickCompare.Items.Count - 1].Group = QuickCompare.Groups[0];

                    tempItem = new ListViewItem();
                    tempItem.Text = url1_low.ToString();
                    tempItem.SubItems.Add(@"URL Fastest Response");
                    tempItem.SubItems.Add(url2_low.ToString());
                    QuickCompare.Items.Add(tempItem);
                    QuickCompare.Items[QuickCompare.Items.Count - 1].Group = QuickCompare.Groups[0];

                    tempItem = new ListViewItem();
                    tempItem.Text = url1_high.ToString();
                    tempItem.SubItems.Add(@"URL Longest Response");
                    tempItem.SubItems.Add(url2_high.ToString());
                    QuickCompare.Items.Add(tempItem);
                    QuickCompare.Items[QuickCompare.Items.Count - 1].Group = QuickCompare.Groups[0];

                    tempItem = new ListViewItem();
                    tempItem.Text = (url1_high - url1_low).ToString();
                    tempItem.SubItems.Add(@"URL Response Longest-Shortest");
                    tempItem.SubItems.Add((url2_high - url2_low).ToString());
                    QuickCompare.Items.Add(tempItem);
                    QuickCompare.Items[QuickCompare.Items.Count - 1].Group = QuickCompare.Groups[0];
                    Go.Text = "GO";
                }
              
            }
            lock (drawlocker)
            {
                drawing = false;
                exited++;
            }
        }

    }
}
