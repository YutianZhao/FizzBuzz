using FizzBuzz.Controllers;
using FizzBuzz.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace FizzBuzz.UnitTests.Controllers
{
    [TestFixture]
    public class FizzBuzzControllerTests
    {
        private Mock<IFizzBuzzService> _fizzBuzzService;
        private FizzBuzzController _fizzBuzzController;
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
            _fizzBuzzService = new Mock<IFizzBuzzService>();
            _fizzBuzzController = new FizzBuzzController(_fizzBuzzService.Object);
        }

        [Test]
        public void ProcessFizzBuzz_ShouldReturnOkResult()
        {
            _fizzBuzzService.Setup(s => s.ProcessFizzBuzz(It.IsAny<object?[]>())).Returns(_expectedResult);
            var result = _fizzBuzzController.ProcessFizzBuzz(_mockData);
            Assert.IsNotNull(result.Result);
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
            var OkResult = (OkObjectResult)result.Result;
            Assert.That(OkResult.StatusCode, Is.EqualTo(200));
        }

        [Test]
        public void ProcessFizzBuzz_ShouldReturnBadRequestResult_InputArrayIsEmpty()
        {
            _fizzBuzzService.Setup(s => s.ProcessFizzBuzz(It.IsAny<object?[]>())).Returns(_expectedResult);
            var result = _fizzBuzzController.ProcessFizzBuzz([]);
            Assert.IsNotNull(result.Result);
            Assert.IsInstanceOf<BadRequestObjectResult>(result.Result);
            var badRequestResult = (BadRequestObjectResult)result.Result;
            Assert.That(badRequestResult.StatusCode, Is.EqualTo(400));
            Assert.That(badRequestResult.Value, Is.EqualTo("Input array cannot be null or empty"));
        }

    }
}
