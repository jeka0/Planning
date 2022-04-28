using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Planning
{
    public partial class Form1 : Form
    {
        private int c = 67, c2=65;
        public static Form1 form;
        private Thread thread, thread2;
        private bool stop1, stop2;
        public Form1()
        {
            InitializeComponent();
            form = this;
        }
        public void ListAdd(String str)
        {
            listBox1.Invoke(new Action(() => { listBox1.Items.Add(str);
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
            }));
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            dataGridView2.AllowUserToAddRows = false;
            dataGridView3.AllowUserToAddRows = false;
            dataGridView1.Rows.Add("A", 8);
            dataGridView1.Rows.Add("B", 4);
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count < 10)
            {
                dataGridView1.Rows.Add((char)c, 4);
                c++;
            }
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            int count = dataGridView1.Rows.Count;
            if (count > 2)
            {
                dataGridView1.Rows.Remove(dataGridView1.Rows[count - 1]);
                c--;
            }
        }

        private void Start_Click(object sender, EventArgs e)
        {
            if (thread == null)
            {
                stop1 = false;
                thread = new Thread(StratThread);
                thread.Start();
            }
        }
        private void StratThread()
        {
            while (!stop1)
            {                
                List<Task> tasks = new List<Task>();
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Invoke(new Action(() =>
                    {
                        String Name = dataGridView1[0, i].Value.ToString();
                        Int32.TryParse(dataGridView1[1, i].Value.ToString(), out int value);
                        if (value < 0) value = 0;
                        tasks.Add(new Task(Name, value));
                    }));
                }
                ShortestTaskFirst shortestTaskFirst = new ShortestTaskFirst(tasks);
                shortestTaskFirst.CreatingQueue();
                textBox2.Invoke(new Action(() => { textBox2.Text = shortestTaskFirst.FindMinTime().ToString(); }));
                dataGridView2.Invoke(new Action(() => { dataGridView2.Rows.Clear(); }));
                foreach (Task task in tasks) dataGridView2.Invoke(new Action(() =>
                {
                    dataGridView2.Rows.Add(task.Name, task.Time);
                }));
                shortestTaskFirst.Start();
            }
            thread = null;
        }
        private void StratThread2()
        {
            List<Task> tasks = new List<Task>();
            c2 = 65;
            for (int i = 0; i < numericUpDown1.Value; i++)
            {
                String Name = (char)c2 + "";
                tasks.Add(new Task(Name));
                c2++;
            }
            Int32.TryParse(textBox1.Text, out int value);
            if (value == 0) value = 1;
            SelectingShortestProcess shortestProcess = new SelectingShortestProcess(tasks, value);
            while (!stop2)
            {
                shortestProcess.SetNewTime();
                shortestProcess.CreatingQueue();
                textBox3.Invoke(new Action(() => { textBox3.Text = shortestProcess.FindMinTime().ToString(); }));
                dataGridView3.Invoke(new Action(() => { dataGridView3.Rows.Clear(); }));
                foreach (Task task in tasks) dataGridView3.Invoke(new Action(() =>
                {
                    dataGridView3.Rows.Add(task.Name, task.Time);
                }));
                shortestProcess.Start();
            }
            thread2 = null;
        }

        private void Start2_Click(object sender, EventArgs e)
        {
            if (thread2 == null)
            {
                stop2 = false;
                thread2 = new Thread(StratThread2);
                thread2.Start();
            }
        }

        private void Stop2_Click(object sender, EventArgs e)
        {
            stop2 = true;
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            stop1 = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (thread != null) { thread.Abort(); Console.WriteLine("+"); }
            if (thread2 != null) thread2.Abort();
        }

    }
}
