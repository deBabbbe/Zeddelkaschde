using Core;
using NUnit.Framework.Internal;
using AutoFixture;

namespace CoreTests;
public class LogicTests
{
    public class ZeddelTests
    {
        private Fixture _fixture = new();

        [Test]
        public void GetZeddelListTest_InitiallyEmpty() =>
            Assert.That(new Logic().GetZeddelList(), Is.Empty);

        [Test]
        public void AddZeddelTest()
        {
            var zeddel1 = _fixture.Create<Zeddel>();
            var zeddel2 = _fixture.Create<Zeddel>();

            var target = new Logic();

            target.AddZeddel(zeddel1);
            target.AddZeddel(zeddel2);

            var result = target.GetZeddelList();

            Assert.That(result, Has.Member(zeddel1));
            Assert.That(result, Has.Member(zeddel2));
        }

        [Test]
        public void RemoveZeddelTest()
        {
            var zeddel = _fixture.Create<Zeddel>();
            var target = new Logic();
            target.AddZeddel(zeddel);

            target.RemoveZeddel(zeddel);

            var result = target.GetZeddelList();
            Assert.That(result, Is.Empty);
        }
    }

    public class KaschdeTests
    {
        private Fixture _fixture = new();

        [Test]
        public void GetKaschdeListTest_InitiallyEmpty() =>
            Assert.That(new Logic().GetKaschdeList(), Is.Empty);

        [Test]
        public void AddKaschdeTest()
        {
            var kaschde1 = _fixture.Create<Kaschde>();
            var kaschde2 = _fixture.Create<Kaschde>();

            var target = new Logic();

            target.AddKaschde(kaschde1);
            target.AddKaschde(kaschde2);

            var result = target.GetKaschdeList();

            Assert.That(result, Has.Member(kaschde1));
            Assert.That(result, Has.Member(kaschde2));
        }

        [Test]
        public void RemoveKaschdeTest()
        {
            var kaschde = _fixture.Create<Kaschde>();
            var target = new Logic();
            target.AddKaschde(kaschde);
            var result = target.GetKaschdeList();

            target.RemoveKaschde(kaschde);

            Assert.That(result, Is.Empty);
        }
    }
}
