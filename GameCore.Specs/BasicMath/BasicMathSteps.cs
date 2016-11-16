using System.Collections.Generic;
using TechTalk.SpecFlow;
using Xunit;

public class Calc
{

    public Calc() {
        this.stack = new List<int>();
    }

    public List<int> stack { get; set; }

    public int result { get; set; }

    public int Add() {
        this.result = this.stack[0] + this.stack[1];
        return this.result;
    }
}

namespace GameCore.Specs
{
    [Binding]
    public class BasicMathSteps
    {
        private readonly Calc calc;

        public BasicMathSteps() {
            this.calc = new Calc();
        }

        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int p0) {
            this.calc.stack.Add(p0);
        }


        [When(@"I press add")]
        public void WhenIPressAdd() {
            this.calc.Add();
        }

        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int p0) {
            Assert.True(this.calc.result == p0);
        }
    }
}
  