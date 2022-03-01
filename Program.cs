using System;
using System.Diagnostics;
using System.Threading;
using NFTestTreading.Models;
using nanoFramework.Json;
using System.Text;
using nanoFramework.json;

namespace NFTestTreading
{
    public class Program
    {
        const string TestDataRaw = @"/XMX5LGF0000453094270

1-3:0.2.8(50)
0-0:1.0.0(210304120347W)
0-0:96.1.1(4530303531303035333039343237303139)
1-0:1.8.1(001819.387*kWh)
1-0:1.8.2(002093.302*kWh)
1-0:2.8.1(000088.650*kWh)
1-0:2.8.2(000157.206*kWh)
0-0:96.14.0(0002)
1-0:1.7.0(00.288*kW)
1-0:2.7.0(00.000*kW)
0-0:96.7.21(00015)
0-0:96.7.9(00002)
1-0:99.97.0(1)(0-0:96.7.19)(190226161118W)(0000000541*s)
1-0:32.32.0(00019)
1-0:32.36.0(00002)
0-0:96.13.0()
1-0:32.7.0(231.0*V)
1-0:31.7.0(001*A)
1-0:21.7.0(00.288*kW)
1-0:22.7.0(00.000*kW)
0-1:24.1.0(003)
0-1:96.1.0(4730303339303031393231393034393139)
0-1:24.2.1(210304120005W)(01980.598*m3)
!894F  ";

        private static string testInvocationReceiveMessage = @"{
        ""type"":1,
        ""target"":""ReceiveAdvancedMessage"",
        ""arguments"": [
            {
                ""age"":22,
                ""name"":""Monica"",
                ""gender"":1,
                ""car"":{
                    ""age"":5,
                    ""model"":""Tesla""
                }
            },
            {
                ""age"":88,
                ""name"":""Grandpa"",
                ""gender"":0,
                ""car"":{
                    ""age"":35,
                    ""model"":""Buick""
                }
            },
            3
        ]}";


        static int count = 0;
        static int counter = 0;
        public static void Main()
        {
            Debug.WriteLine("Hello from nanoFramework!");
            Debug.WriteLine(System.Environment.TickCount64.ToString());
            Timer timer = new Timer(EatCpu, count, 0, 1000);
            
            Thread.Sleep(Timeout.Infinite);
        }

        private static void EatCpu(object state)
        {
            //test 5
            //var dserResult = (InvocationReceiveMessage)JsonConvert.DeserializeObject(@"{""type"":1,""target"":""ReceiveMessage"",""arguments"":[""I_am_a_string"",""I_am_another_string""]}", typeof(InvocationReceiveMessage));
            //string arg0 = (string)JsonConvert.DeserializeObject(JsonConvert.SerializeObject(dserResult.arguments[0]), typeof(string));
            //string arg1 = (string)JsonConvert.DeserializeObject(JsonConvert.SerializeObject(dserResult.arguments[1]), typeof(string));
            //Debug.WriteLine(arg0);
            //Debug.WriteLine(arg1);
            int round = count;
            count++;
            long startTime = System.Environment.TickCount64;
            Debug.WriteLine(startTime.ToString());
            //var dserResult = (InvocationReceiveMessage)JsonConvert.DeserializeObject(testInvocationReceiveMessage, typeof(InvocationReceiveMessage));
            //Debug.WriteLine($"{round} new Json implementation = {System.Environment.TickCount64 - startTime}");
            //Debug.WriteLine((dserResult.type == 1).ToString());
            //Debug.WriteLine(((int)dserResult.arguments[2] == 3).ToString());
            //int argsCount = (int)JsonConvert.DeserializeObject(JsonConvert.SerializeObject(dserResult.arguments[2]), typeof(int));
            //Debug.WriteLine(argsCount.ToString());
            //Person2 person1 = (Person2)JsonConvert.DeserializeObject(JsonConvert.SerializeObject(dserResult.arguments[0]), typeof(Person2));
            //Person2 person2 = (Person2)JsonConvert.DeserializeObject(JsonConvert.SerializeObject(dserResult.arguments[1]), typeof(Person2));
            
            
            byte[] serialdata = Encoding.UTF8.GetBytes(TestDataRaw);
           
            var model = P1MessageDecoder.DecodeData(serialdata);

            
            startTime = System.Environment.TickCount64;
            var json1 =JsonConvert.SerializeObject(model);
            Debug.WriteLine(json1);
            Debug.WriteLine($"{round} new Json implementation = {System.Environment.TickCount64 - startTime}");
            startTime = System.Environment.TickCount64;
            var json2 = JsonSerializer.Serialize(model);
            
            Debug.WriteLine($"{round} old Json implementation = {System.Environment.TickCount64 - startTime}");
            Debug.WriteLine(json2);
        }
    }

    public class Person2
    {
        public int age { get; set; }
        public string name { get; set; }
        public Gender gender { get; set; }
        public Car car { get; set; }
    }

    public class Car
    {
        public int age { get; set; }
        public string model { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }
}
