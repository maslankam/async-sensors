using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dependencyInAction
{
class Program
{
static void Main(string[] args)
{
Task.Run(async () => { await Run(); }).GetAwaiter().GetResult();
}


public static async Task Run(){

List<SensorService> services = new List<SensorService>();

string command = null;
while(command != "exit"){
    Console.WriteLine("Enter Command: 'add' / 'sync' / 'async' / 'exit'");
    command = Console.ReadLine();

    DateTime start = DateTime.UtcNow;
    switch(command){
        case "exit": // Exit the wthile loop, close the program
            break;

        case "sync": // Execute async code
            foreach(var service in services){
            Console.WriteLine(service.currnetLog());} 
            break;

        case "async":
            var allTasks = new List<Task<string>>();
            //Running the tasks async
            foreach(var service in services){
                allTasks.Add(service.currnetLogAsync());
            }

            while (allTasks.Count != 0){
                    Task<string> finished = await Task.WhenAny(allTasks);
                    if(finished != null){
                        Console.WriteLine(finished.Result);
                    allTasks.Remove(finished);
                    //some changes
                    }            
                }
            break;

        case "add":
                ISensor sensor = new TemperatureSensor();
                services.Add(new SensorService(sensor));
                Console.WriteLine("SensorService added, TemperatureSensor id: " + sensor.getId().ToString());
            break;
        default:
            break;
    }
    
    //End of command
    DateTime end = DateTime.UtcNow;
    TimeSpan duration = end - start;
    Console.WriteLine("Execution time in seconds: " + duration.TotalSeconds);
    }
}   


}
}