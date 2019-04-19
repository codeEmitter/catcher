using System.Linq;
using Catcher.Stores;
using Catcher.Stores.Mem;
using NUnit.Framework;

namespace test.Stores.Mem
{
    [TestFixture]
    public class SimpleListStoreTests
    {
        private IStore _target;

        [SetUp]
        public void SetUp() =>
            _target = new SimpleListStore();

        [Test]
        public void CanSaveASingleUniqueValue()
        {
            const string val = "testValue1";
            Assert.AreEqual(
                _target.Save(val), val);
        }

        [Test]
        public void SavesOnlyUniqueValues()
        {
            const string value = "testValue2";
            _target.Save(value);
            _target.Save(value);
            Assert.AreEqual(_target.Read().Count(), 1);
        }

        [Test]
        public void ClearRemovesAllEntriesAndReturnsTheNumberRemoved()
        {
            const string value = "testValue1";
            _target.Save(value);
            Assert.AreEqual(1, _target.Clear());
        }
    }
}