using Xunit;

namespace BaseProject.Test
{
    public class MathHelperTest
    {
        [Fact]
        public void IsEvenTest()
        {
            var calculator = new MathFormulas();

            int x = 1;
            int y = 2;

            var xResult = calculator.IsEven(x);
            var yResult = calculator.IsEven(y);

            Assert.False(xResult);
            Assert.True(yResult);
        }

        [Theory]
        [InlineData(1, 2, 1)]
        //[InlineData(1, 3, 1)]
        public void DiffTest(int x, int y, int expectvalue)
        {
            var calculator = new MathFormulas();
            var result = calculator.Diff(x, y);
            Assert.Equal(expectvalue, result);
        }
    }
}