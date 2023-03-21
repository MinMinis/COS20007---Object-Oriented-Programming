using ClockClass;

namespace ClockTests
{
    public class ClockTests
    {
        [TestFixture()]
        public class ClockTest
        {
            private Clock clockTest;
            [SetUp]
            public void SetUp()
            {
                clockTest = new Clock();
            }
            [Test()]
            public void TestClockZero()
            {
                Assert.That(clockTest.ReadTime(), Is.EqualTo("0:0:0"));
            }

            [Test()]
            public void TestClockTicks()
            {
                for (int i = 0; i < 12; i++)
                {
                    clockTest.Tick();
                }
                Assert.That(clockTest.ReadTime(), Is.EqualTo("0:0:12"));
            }

            [Test()]
            public void TestClockMinutes()
            {
                for (int i = 0; i < 60; i++)
                {
                    clockTest.Tick();
                }
                Assert.That(clockTest.ReadTime(), Is.EqualTo("0:1:0"));
            }

            [Test()]
            public void TestClockHours()
            {
                for (int i = 0; i < 60 * 60; i++)
                {
                    clockTest.Tick();
                }

                Assert.That(clockTest.ReadTime(), Is.EqualTo("1:0:0"));
            }

            [Test()]
            public void Test1Day()
            {
                for (int i = 0; i < 60 * 60 * 24 + 1; i++)
                {
                    clockTest.Tick();
                }

                Assert.That(clockTest.ReadTime(), Is.EqualTo("0:0:1"));
            }

            [Test()]
            public void TestReset()
            {
                for (int i = 0; i < 50; i++)
                {
                    clockTest.Tick();
                }
                clockTest.Reset();

                Assert.That(clockTest.ReadTime(), Is.EqualTo("0:0:0"));
            }
        }
    }
}