using NUnit.Framework;
using MidtermExam.Prob02;

namespace MidtermExam.Tests
{
    [TestFixture, Category("MidtermExam"), Category("Prob02")]
    public class Prob02_BrowserStack_Testcase
    {
        [TestCase("open google.com; current", "google.com")]
        [TestCase("open google.com; open youtube.com; back; current", "google.com")]
        [TestCase("back; current", "")]
        [TestCase("open google.com; open youtube.com; back; forward; current", "youtube.com")]
        [TestCase("open google.com; forward; current", "google.com")]
        [TestCase("open google.com; open youtube.com; open github.com; back; back; forward; current", "youtube.com")]
        [TestCase("open a; open b; back; open c; forward; current", "c")]
        [TestCase("open a; back; back; forward; forward; current", "a")]
        [TestCase("open a; open b; open c; back; back; back; forward; forward; forward; current", "c")]
        [TestCase(" ; open   a ; unknown ; current ; ", "a")]
        public void NavigationMatchesExpectedPage(string actions, string expected)
        {
            Assert.That(new BrowserNavigation().AS02_WebBrowserNavigation(actions),
                Is.EqualTo(new[] { expected }));
        }

        [Test]
        public void EveryCurrentProducesOneOutput()
        {
            Assert.That(new BrowserNavigation().AS02_WebBrowserNavigation(
                "current; open a; current; open b; back; current"),
                Is.EqualTo(new[] { "", "a", "a" }));
        }

        [TestCase(null), TestCase(""), TestCase("   "), TestCase("open a; back")]
        public void NoCurrentProducesNoOutput(string actions)
        {
            Assert.That(new BrowserNavigation().AS02_WebBrowserNavigation(actions), Is.Empty);
        }

        [Test]
        public void BrowserStartsEmptyAndBoundaryNavigationDoesNothing()
        {
            var browser = new StudentWebBrowser();
            Assert.That(browser.Current(), Is.EqualTo(string.Empty));
            browser.Back();
            browser.Forward();
            Assert.That(browser.Current(), Is.EqualTo(string.Empty));
        }

        [Test]
        public void InvalidOpenPreservesBothHistories()
        {
            var browser = new StudentWebBrowser();
            browser.Open(null);
            browser.Open(" ");
            Assert.That(browser.Current(), Is.EqualTo(string.Empty));
            browser.Open("a");
            browser.Open("b");
            browser.Open("c");
            browser.Back();
            browser.Open(null);
            browser.Open("");
            browser.Open(" \t ");
            Assert.That(browser.Current(), Is.EqualTo("b"));
            browser.Forward();
            Assert.That(browser.Current(), Is.EqualTo("c"));
            browser.Back();
            browser.Back();
            Assert.That(browser.Current(), Is.EqualTo("a"));
        }

        [Test]
        public void ReopeningCurrentPageClearsForwardAndAddsBackEntry()
        {
            var browser = new StudentWebBrowser();
            browser.Open("start");
            browser.Open("a");
            browser.Open("b");
            browser.Back();
            browser.Open("a");
            browser.Forward();
            Assert.That(browser.Current(), Is.EqualTo("a"));
            browser.Back();
            Assert.That(browser.Current(), Is.EqualTo("a"));
            browser.Back();
            Assert.That(browser.Current(), Is.EqualTo("start"));
        }

        [Test]
        public void DirectOpenPreservesUrlText()
        {
            var browser = new StudentWebBrowser();
            browser.Open("  example.com  ");
            Assert.That(browser.Current(), Is.EqualTo("  example.com  "));
        }

        [Test]
        public void ParserCallsAndBrowserInstancesHaveIndependentState()
        {
            var navigation = new BrowserNavigation();
            Assert.That(navigation.AS02_WebBrowserNavigation("open a; current"), Is.EqualTo(new[] { "a" }));
            Assert.That(navigation.AS02_WebBrowserNavigation("current"), Is.EqualTo(new[] { "" }));
            var first = new StudentWebBrowser();
            var second = new StudentWebBrowser();
            first.Open("first");
            Assert.That(second.Current(), Is.EqualTo(string.Empty));
        }
    }
}
