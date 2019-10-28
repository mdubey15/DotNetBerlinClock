using BerlinClock.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace BerlinClock.BDD
{
    public class TimeFeaturesStep
    {
        private string _time;
        int _hours, _minutes, _seconds;

        #region Parse


        [When(@"the time is parsed as ""(.*)""")]
        public void WhenTheTimeIsParsedAs(string time)
        {
            _time = time;
        }


        [Then(@"the parse error in the (time) portion")]
        public void ThenTheProgrammerShouldGetAParseErrorInThePortion(string parameterName)
        {
            try
            {
                Time.Parse(_time);
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual(parameterName, e.ParamName);
                return;
            }
            Assert.Inconclusive();
        }



        [Then(@"the parsed instance that looks like ""(.*)""")]
        public void GetAParsedInstanceThatLooksLike(string expectedTimeRepresentation)
        {
            Assert.AreEqual(expectedTimeRepresentation, Time.Parse(_time).ToString());
        }


        #endregion Parse

        #region Ctor

        [When(@"the time is constructed using (-?\d+), (-?\d+), (-?\d+)")]
        public void WhenTheTimeIsConstructedUsing(int hours, int minutes, int seconds)
        {
            _hours = hours;
            _minutes = minutes;
            _seconds = seconds;
        }



        [Then(@"the constructor error in the (hours|minutes|seconds) portion")]
        public void ConstructorErrorInThePortion(string parameterName)
        {
            try
            {
                new Time(_hours, _minutes, _seconds);
                Assert.Fail();
            }

            catch (ArgumentException e)
            {
                Assert.AreEqual(parameterName, e.ParamName);
            }
        }


        [Then(@"the constructed instance that looks like ""(.*)""")]
        public void ThenTheProgrammerShouldGetAConstructedInstanceThatLooksLike(string expectedStringRepresentation)
        {
            Assert.AreEqual(expectedStringRepresentation, new Time(_hours, _minutes, _seconds).ToString());
        }

        #endregion Ctor
    }
}
