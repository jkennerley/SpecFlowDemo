using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist; 

namespace GameCore.Specs
{
    [Binding]
    public class CustomConversions
    {
        [StepArgumentTransformation(@"(\d+) days ago")]
        public DateTime DaysAgoTransformation(int daysAgo) {
            return DateTime.Now.Subtract(TimeSpan.FromDays(daysAgo));
        }

        [StepArgumentTransformation]
        public IEnumerable<Weapon> WeaponsTransformation( Table table ) {
            IEnumerable<Weapon> xs = table.CreateSet<Weapon>();
            return xs ;
        }
    }
}