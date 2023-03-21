using ClockClass;
using System;

namespace CounterTests
{
    public class CounterTests
    {
        [TestFixture()]
        public class CounterTest
        {
            private Counter _counter;

            [SetUp]
            public void SetUp()
            {
                _counter = new Counter("Count");
            }

            [Test()]
            public void TestStartsZero()
            {
                string actual = _counter.Count.ToString();
                Assert.That(actual, Is.EqualTo("0"));
            }

            [Test()]
            public void TestIncrement()
            {
                _counter.Increment();
                Assert.That(_counter, Has.Count.EqualTo(1));
            }

            [Test()]
            public void TestIncrementMultiple()
            {
                _counter.Increment();
                _counter.Increment();
                _counter.Increment();
                _counter.Increment();
                Assert.That(_counter, Has.Count.EqualTo(4));
            }

            [Test()]
            public void TestReset()
            {
                _counter.Increment();
                _counter.Increment();
                _counter.Increment();
                _counter.Reset();
                Assert.That(_counter, Has.Count.EqualTo(0));
            }
        }
    }
}