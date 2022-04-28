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
        public int FindMinTime()
        {
            int sum = 0, count = tasks.Count;
            foreach (Task task in tasks) sum += task.Time * count--;
            return sum/ tasks.Count;
        }
    }
}
