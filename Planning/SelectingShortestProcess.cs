using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Planning
{
    public class SelectingShortestProcess
    {
        public static List<Task> tasks;
        private Random random = new Random();
        private double a = 0.5;
        private int quantum;
        public SelectingShortestProcess(List<Task> tasks, int quantum)
        {
            SelectingShortestProcess.tasks = tasks;
            this.quantum = quantum;
            foreach (Task task in tasks) task.Time = random.Next(1, 50);
        }
        public void SetNewTime()
        {
            foreach (Task task in tasks)
            {
                int time = (int)(a * task.Time + (1 - a) * random.Next(1, 50));
                if (time < 0) task.Time = 0;
                else task.Time = time;
            }
        }
        public void CreatingQueue()
        {
            tasks.Sort((a, b) => a.Time.CompareTo(b.Time));
        }
        public void Start()
        {
            int i = 0;
            Task task = tasks.Find((a) => a.Time > 0);
            while(task!=null)
            {
                int time = tasks[i].Time;
                Form1.form.ListAdd("Процесс "+ tasks[i].Name + " выполняется");
                if (time > 0) { Thread.Sleep(quantum * 50); tasks[i].Time -= quantum; }
                i++;
                if (i >= tasks.Count) i = 0;
                task = tasks.Find((a) => a.Time > 0);
            }
        }
    }
}
