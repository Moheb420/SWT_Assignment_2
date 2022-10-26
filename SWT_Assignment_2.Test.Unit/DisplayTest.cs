using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NSubstitute;
using SWT_Assignment_2.Interfaces;

namespace SWT_Assignment_2.Test.Unit
{
    [TestFixture]
    public class DisplayTest
    {
        private const string StationMsg = "Station message : ";
        private const string ChargerMsg = "Charger message : ";
        

        private const string chargerMessageInit = "none";

        private const string StationMessageInit = "init";

        private const string ProgramMessageinit = "Started";

        private Display _uut;
        private IDisplay fakeDisplay;
            [SetUp]
            public void Setup()
            {
           
            fakeDisplay = Substitute.For<IDisplay>();
                _uut = new Display(fakeDisplay);
        }

        [TestCase("test")]
        [TestCase(null)]
        [TestCase("")]

        public void DisplayProgramMessage(string test)
        {

            _uut.displayProgramMessage(test);
            string mytext = _uut.programMessage;
            Assert.AreEqual(mytext, test);

            _uut.Writeline(ProgramMessageinit);
            Assert.AreEqual("Started",ProgramMessageinit);

            _uut.Writeline(StationMsg + StationMessageInit);
            Assert.AreEqual("Station message : init", StationMsg + StationMessageInit);

            _uut.Writeline(ChargerMsg + chargerMessageInit);
            Assert.AreEqual("Charger message : none", ChargerMsg + chargerMessageInit);
        }


        [TestCase("test")]
        [TestCase(null)]
        [TestCase("")]

        public void DisplayStationMessage(string test)
        {

           _uut.displayStationMessage(test);
            string mytext = _uut.programMessage;
            Assert.AreEqual(mytext, test);

            _uut.Writeline(ProgramMessageinit);
            Assert.AreEqual("Started",ProgramMessageinit);

            _uut.Writeline(StationMsg + StationMessageInit);
            Assert.AreEqual("Station message : init", StationMsg + StationMessageInit);

            _uut.Writeline(ChargerMsg + chargerMessageInit);
            Assert.AreEqual("Charger message : none", ChargerMsg + chargerMessageInit);
        }



        [TestCase("test")]
        [TestCase(null)]
        [TestCase("")]

        public void DisplayChargerMessage(string test)
        {
            _uut.displayChargingMessage(test);
            string mytext = _uut.programMessage;
            Assert.AreEqual(mytext, test);

            _uut.Writeline(ProgramMessageinit);
            Assert.AreEqual("Started",ProgramMessageinit);

            _uut.Writeline(StationMsg + StationMessageInit);
            Assert.AreEqual("Station message : init", StationMsg + StationMessageInit);

            _uut.Writeline(ChargerMsg + chargerMessageInit);
            Assert.AreEqual("Charger message : none", ChargerMsg + chargerMessageInit);
        }
    }
}
