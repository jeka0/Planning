using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Planning
{
    public class ShortestTaskFirst
    {

        public static List<Task> tasks;
        public ShortestTaskFirst(List<Task> tasks)
        {
            ShortestTaskFirst.tasks = tasks;
        }
        public void CreatingQueue()
        {
            tasks.Sort((a,b)=>a.Time.CompareTo(b.Time));
        }
        public void Start()
        {
            foreach(Task task in tasks)
            {
                Thread.Sleep(task.Time*100);
            }
        }
        public Task FindMinTask()
        {
            Task min = tasks[0];
            foreach(Task task in tasks)
            {
                if (task.Time < min.Time) min = task;
            }
            return min;
        }
    }
}
