using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    public interface IAlarmListener
    {
        void alarm();
    }

    class SensorSystem
    {
        List<IAlarmListener> devices = new List<IAlarmListener>();

        public void register( IAlarmListener al)
        {
            devices.Add(al);
        }

        public void soundAlarm()
        {
            foreach(IAlarmListener i in devices)
            {
                i.alarm();
            }
        }
    }
    
    class Lighting : IAlarmListener
    {
        public void alarm()
        {
            Console.WriteLine("luzes acendidas");
        }
    }

    class Gate : IAlarmListener
    {
        public void alarm()
        {
            Console.WriteLine("portões fechados");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SensorSystem ss = new SensorSystem();
            ss.register(new Lighting());
            ss.register(new Gate());

            ss.soundAlarm();
            Console.ReadKey();
        }
    }
}
