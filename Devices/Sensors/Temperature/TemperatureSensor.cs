using System;
using System.Threading;
using System.Threading.Tasks;

namespace dependencyInAction{
    public class TemperatureSensor : ISensor{
        private readonly int id;

        public TemperatureSensor(){
            Random r = new Random();
            this.id = r.Next(0,Int32.MaxValue);
        }

        public Status getStatus(){
            return Status.idle;
        }

        public ISensorResponse GetResponse(){
            Random r = new Random();
            int delay = r.Next(50,1000);
            Console.WriteLine("Sensor id:"+ id.ToString()+" here, my delay is: "+delay.ToString());
            Thread.Sleep(r.Next(50,1000));
            return new TemperatureResponse(Convert.ToDouble(r.Next(0,100)));
        }

        public async Task<ISensorResponse> GetResponseAsync(){
            Random r = new Random();
            int delay = r.Next(50,1000);
            Console.WriteLine("Sensor id:"+ id.ToString()+" here, my delay is: "+delay.ToString());
            await Task.Delay(delay); 
             return  new TemperatureResponse(Convert.ToDouble(r.Next(0,100)));
        }


        public int getId(){
            return this.id;
        }
    }
}