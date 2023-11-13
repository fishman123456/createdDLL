using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;


namespace DinamicLinkTest_shambala08_11_2023
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Assembly libAsm = Assembly.Load(
                AssemblyName.GetAssemblyName("ClassLibrary1.dll")
                );
            Console.WriteLine($"Загружена сборка {libAsm.FullName}");
            Module libModule = libAsm.GetModule("ClassLibrary1.dll");
            Console.WriteLine($"Загружен модуль {libModule.FullyQualifiedName}");

            // получим тип нужного класса
            var types = libModule.GetTypes();
            foreach (var t in types)
            {
                Console.WriteLine(t.FullName);
            }
            Type encoderType = libModule.GetType("ClassLibrary1.CustomEncoder");
            Console.WriteLine($"Получен тип:{encoderType.FullName} ");
            // создадим обьект полученного типа
            object encoder = Activator.CreateInstance(encoderType);
            // вызовем библиотечный метод
            string line = "hello";
            string result = encoderType.GetMethod("encode").Invoke(encoder, new object[] {line}) as string;
            Console.WriteLine($"Закодированная строка  {line} : {result}");
            //Assembly libAsmt = Assembly.Load(
            //    AssemblyName.GetAssemblyName("autocad_wf_layer_add_29-03-2023.dll")
            //    );
            Console.ReadKey();
        }
    }
}
