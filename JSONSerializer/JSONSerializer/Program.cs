using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Json;

namespace JSONSerializer
{
    class Program
    {
        static void Main(string[] args)
        {
            //Чтобы сериализовать экземпляр типа Person в формат JSON, создайте объект DataContractJsonSerializer и с помощью метода WriteObject запишите данные JSON в поток.
            Person p = new Person();
            p.name = "John";
            p.age = 32;

            //Сериализуйте объект Person в поток памяти с помощью сериализатора DataContractJsonSerializer.
            MemoryStream stream1 = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Person));

            //С помощью метода WriteObject запишите данные JSON в поток.
            ser.WriteObject(stream1, p);

            //Отобразите выходные данные JSON.
            stream1.Position = 0;
            StreamReader sr = new StreamReader(stream1);
            Console.WriteLine("JSON form of Person object: ");
            Console.WriteLine(sr.ReadToEnd());

            //Дессериализация в новый экземпляр типа Person

            //Десериализуйте данные в кодировке JSON в новый экземпляр типа Person с помощью метода ReadObject сериализатора DataContractJsonSerializer.
            stream1.Position = 0;
            Person p2 = (Person)ser.ReadObject(stream1);
            //Отобразите результаты.
            Console.Write("Deserialized back, got name= ");
            Console.Write(p2.name);
            Console.Write(", age= ");
            Console.WriteLine(p2.age);
        }
    }

    //Используем контракт данных Person для сериализации
    //Ссылка на сборку System.Runtime.Serialization
    [DataContract] //DataContractAttribute к классу
    internal class Person
    {   [DataMember] //DataMemberAttribute к элементам которые требуется сериализовать
        internal string name;
        [DataMember]
        internal int age;
    }
}
