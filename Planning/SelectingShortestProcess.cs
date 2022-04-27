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
        public SelectingShortestProcess(List<Task> tasks)
        {
            SelectingShortestProcess.tasks = tasks;
        }
        public void CreatingQueue()
        {
            //tasks.Sort((a, b) => a.Time.CompareTo(b.Time));
        }
        public void Start()
        {
            /*foreach (Task task in tasks)
            {
                Thread.Sleep(task.Time * 100);
            }*/
        }
        public Task FindMinTask()
        {
            /*Task min = tasks[0];
            foreach (Task task in tasks)
            {
                if (task.Time < min.Time) min = task;
            }
            return min;*/
            return null;
        }
    }
}
