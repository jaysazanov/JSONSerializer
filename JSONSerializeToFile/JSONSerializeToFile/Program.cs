using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Threading;

namespace JSONSerializeToFile
{
    [DataContract]
    public class Person
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Age { get; set; }

        public Person(string name, int year)
        {
            Name = name;
            Age = year;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("as");
            Person person1 = new Person("Tom", 30);
            Person person2 = new Person("Bill", 20);
            Person[] persons = new Person[] { person1, person2 };

            DataContractJsonSerializer jsonFormatter =
                new DataContractJsonSerializer(typeof(Person[]));

            using (FileStream fs = new FileStream("persons.json",
                FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs, persons);
            }
            using (FileStream fs = new FileStream("persons.json",
                FileMode.OpenOrCreate))
            {
                Person[] newPersons = (Person[])jsonFormatter.ReadObject(fs);
                foreach (Person p in newPersons)
                {
                    Console.WriteLine("Name: {0} --- Age: {1}", p.Name, p.Age);
                    Thread.Sleep(1000);
                }
            }
            Console.ReadLine();
        }
    }
}
