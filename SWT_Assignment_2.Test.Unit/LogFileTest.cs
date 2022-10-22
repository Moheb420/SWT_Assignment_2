using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWT_Assignment_2.Interfaces;
using static System.Net.Mime.MediaTypeNames;

namespace SWT_Assignment_2.Test.Unit
{
    [TestFixture]
    public class LogFileTest
    {
        private string FileNameTest = "logtest";
        private LogFile _uut;

        [SetUp]
        public void Setup()
        {
            _uut = new LogFile(FileNameTest);
        }



        [TestCase()]
        public void LogFileExist()
        {
            _uut.log(FileNameTest);
            Assert.That(File.Exists(FileNameTest));
        }


        [TestCase()]
        public void LogTest()
        {
            Assert.DoesNotThrow((() => _uut.log(FileNameTest)));
        }


        //[TestCase("test")]
        ////[TestCase(null)]
        ////[TestCase("")]
        //public void WriteToLogFile(string text)
        //{
        //    string result;
        //    DateTime dt = DateTime.Now;
        //    _uut.log(text);
        //     //Assert.That(File.Exists(FileNameTest));

        //    using (StreamReader sr = new StreamReader(File.OpenRead(FileNameTest)))
        //    {
        //        result = sr.ReadLine();
        //    }
        //    Assert.That(result == $"{dt}: {text}");
        //}


        //[TestCase("hello", "its me","who?")]
        //[TestCase(null,"Arhus", "University")]
        //public void WriteToLogFile(string param1,string param2, string param3)
        //{
        //    DateTime dt = DateTime.Now;
        //    string result;
        //    _uut.log(param1);

        //    _uut.log(param2);

        //    _uut.log(param3);
        //    Assert.That(File.Exists(FileNameTest));

        //    using (StreamReader sr = new StreamReader(File.OpenRead(FileNameTest)))
        //    {
        //        result = sr.ReadLine();
        //        Assert.That(result == $"{dt}: {param1}");

        //        result = sr.ReadLine();
        //        Assert.That(result == $"{dt}: {param2}");

        //        result = sr.ReadLine();
        //        Assert.That(result == $"{dt}: {param3}");
        //    }
        //}

    }
}
