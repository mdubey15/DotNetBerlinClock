using System;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using BerlinClock.Classes;

namespace BerlinClock
{
    [Binding]
    public class TheBerlinClockSteps
    {
        private ITimeConverter<string> berlinClock = new TimeConverter();
        private Time theTime;

        
        [When(@"the time is ""(.*)""")]
        public void WhenTheTimeIs(Time time)
        {
            theTime = time;
        }
        
        [Then(@"the clock should look like")]
        public void ThenTheClockShouldLookLike(string theExpectedBerlinClockOutput)
        {
            Assert.AreEqual(berlinClock.convertTime(theTime), theExpectedBerlinClockOutput);
        }

        [StepArgumentTransformation(@"\d{2}:\d{2}:\d{2}")]
        public Time ParseTime(string time)
        {
            return Time.Parse(time);
        }


    }
}
