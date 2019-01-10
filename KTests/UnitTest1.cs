using Xunit;
using POC_KMap;

namespace KTests
{
    public class KmapTesting
    {
        private KMapExamples _examples;
        public KmapTesting()
        {
            _examples = new KMapExamples();
        }

        [Theory]
        [InlineData(false, false, false)]
        [InlineData(false, true, false)]
        [InlineData(false, true, true)]
        [InlineData(true, false, true)]
        [InlineData(true, true, false)]
        [InlineData(true, true, true)]
        public void TestMethod1(bool a, bool b, bool c)
        {
            _examples.C = c;
            _examples.B = b;
            _examples.A = a;

            var res = _examples.Result();

            Assert.True(res);
        }

        [Theory]
        [InlineData(false, false, false)]
        [InlineData(false, true, false)]
        [InlineData(false, true, true)]
        [InlineData(true, false, true)]
        [InlineData(true, true, false)]
        [InlineData(true, true, true)]
        public void TestKmapResult(bool a, bool b, bool c)
        {
            _examples.C = c;
            _examples.B = b;
            _examples.A = a;

            var res = _examples.KmapResult();

            Assert.True(res);
        }
    }
}
