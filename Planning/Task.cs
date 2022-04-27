using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning
{
    public class Task
    {
        public String Name { get; }
        public int Time { get; }
        public Task(String Name, int Time)
        {
            this.Name=Name;
            this.Time = Time;
        }
    }
}
