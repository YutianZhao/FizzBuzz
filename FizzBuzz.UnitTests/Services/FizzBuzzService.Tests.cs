using FizzBuzz.Services;

namespace FizzBuzz.UnitTests.Services
{
    [TestFixture]
    public class FizzBuzzServiceTests
    {
        private IFizzBuzzService _service;
        private readonly object?[] _mockData = { 1, 3, 5, null, 15, "A", 23 };
        private List<List<string>> _expectedResult = new List<List<string>>
        {
            { ["0", "0"] },
            { ["Fizz"] },
            { ["Buzz"] },
            { ["Invalid Item"] },
            { ["FizzBuzz"] },
            { ["Invalid Item"] },
            { ["7", "4"] }
        };
        [SetUp]
        public void Setup()
        {
            _service = new FizzBuzzService();
        }

        [Test]
        public void ProcessFizzBuzz_ShouldReturnCorrectType()
        {
            var result = _service.ProcessFizzBuzz(_mockData);
            Assert.IsInstanceOf<List<List<string>>>(result);
        }

        [Test]
        public void ProcessFizzBuzz_ShouldReturnCorrectResult()
        {
            var result = _service.ProcessFizzBuzz(_mockData);
            Assert.That(result, Is.EqualTo(_expectedResult));
        }
    }
}