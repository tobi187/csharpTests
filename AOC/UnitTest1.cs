namespace AOC
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ExtractSuperSeq()
        {
            var x = new AdressSplitter("abba[mnop]qrst");
            x.DoNext();
            Assert.That(x.super, Is.EqualTo(new List<string> { "abba" }));
            x.DoNext();
            Assert.That(x.hyper, Is.EqualTo(new List<string> { "mnop" }));
        }

        [Test]
        public void ExtractHypereq()
        {
            var x = new AdressSplitter("[mnop]qrst");
            x.DoNext();

            Assert.That(x.hyper, Is.EqualTo(new List<string> { "mnop" }));
        }

        [Test]
        public void ExtractAll()
        {
            var x = new AdressSplitter("abba[mnop]qrst");
            x.DoAll();
            Assert.That(x.super, Is.EqualTo(new List<string> { "abba", "qrst" }));
            Assert.That(x.hyper, Is.EqualTo(new List<string> { "mnop" }));
        }

        [Test]
        public void CheckSuperPalindrom()
        {
            var f = new AdressSplitter("xabba[mnop]qrst");
            f.DoAll();
            Assert.That(f.superAbba, Is.True);
        }

        [Test]
        public void CheckHyperPalindrom()
        {
            var f = new AdressSplitter("abba[aaaa]qrst");
            f.DoAll();
            Assert.That(f.hyperAbba, Is.False);
        }

        [Test]
        public void Container()
        {
            var f = Solution.CountCorrectLines(File.ReadAllLines("data.txt"));

            Assert.That(f, Is.EqualTo(118));
        }
    }

    internal class Solution
    {
        public Solution()
        {
        }
        public static int CountCorrectLines(string[] strings)
        {
            var counter = 0;
            foreach (var line in strings)
            {
                var s = new AdressSplitter(line);
                s.DoAll();
                if (s.superAbba && !s.hyperAbba)
                    counter++;
            }
            return counter;
        }
    }
}