using System.Linq;
using NUnit.Framework;
using Catcher.Stores;

namespace test.Stores
{
    [TestFixture]
    public class MemoryStoreTests
    {
        private IStore _target;

        [SetUp]
        public void SetUp()
        {
            _target = new MemoryStore();
        }

        [Test]
        public void CanSaveASingleUniqueValue() => 
            Assert.AreEqual(_target.Save("testValue1"), "testValue1");

        [Test]
        public void SavesOnlyUniqueValues()
        {
            const string value = "testValue2";
            _target.Save(value);
            _target.Save(value);
            Assert.AreEqual(_target.Read().Count(), 1);
        }
        
    }
}