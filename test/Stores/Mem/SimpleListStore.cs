using System;
using System.Linq;
using Catcher.Stores;
using Src = Catcher.Stores.Mem;
using NUnit.Framework;

namespace test.Stores.Mem
{
    [TestFixture]
    public class SimpleListStore
    {
        private IStore _target;

        [SetUp]
        public void SetUp() =>
            _target = new Src.SimpleListStore();

        [Test]
        [TestCase("testValue1")]
        public void CanSaveASingleDistinctValue(string testCase) =>
            Assert.AreEqual(_target.Save(testCase), testCase);

        [Test]
        [TestCase("testValue2")]
        public void SavesOnlyUniqueValues(string testCase)
        {
            _target.Save(testCase);
            _target.Save(testCase);
            Assert.AreEqual(_target.Read().Count(), 1);
        }

        [Test]
        [TestCase("testValue3")]
        public void ClearRemovesAllEntriesAndReturnsTheNumberRemoved(string testCase)
        {
            _target.Save(testCase);
            Assert.AreEqual(1, _target.Clear());
        }

        [Test]
        [TestCase("testValue4")]
        public void TimestampsAreAvailableForEachEntry(string testCase)
        {
            _target.Save(testCase);
            Assert.AreEqual(_target.Read().Keys.First().GetType(), typeof(DateTime));
        }

    }
}