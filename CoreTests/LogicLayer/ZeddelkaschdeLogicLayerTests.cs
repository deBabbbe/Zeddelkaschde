using NUnit.Framework.Internal;
using AutoFixture;
using Moq;
using Core.DataAccessLayer;
using Core.DataTypes;
using Core.LogicLayer;

namespace CoreTests.LogicLayer;

public class ZeddelkaschdeLogicLayerTests
{
    [Test]
    public void ConstructorTest() =>
        Assert.That(new ZeddelkaschdeLogicLayer(null), Is.InstanceOf<IZeddelkaschdeLogicLayer>());

    public class ZeddelTests
    {
        private Fixture _fixture = new();

        private IZeddelkaschdeAccessLayer _accessLayer;

        [SetUp]
        public void SetUp()
        {
            var mockZeddelList = new List<Zeddel>();
            var accessLayerMock = new Mock<IZeddelkaschdeAccessLayer>();
            accessLayerMock.Setup(mock => mock.GetZeddelList()).Returns(mockZeddelList);
            accessLayerMock.Setup(mock => mock.AddZeddel(It.IsAny<Zeddel>()))
                .Callback<Zeddel>(mockZeddelList.Add);
            accessLayerMock.Setup(mock => mock.RemoveZeddel(It.IsAny<Zeddel>()))
                .Callback<Zeddel>(zeddel => mockZeddelList.Remove(zeddel));
            _accessLayer = accessLayerMock.Object;
        }

        [Test]
        public void GetZeddelListTest_InitiallyEmpty() =>
            Assert.That(new ZeddelkaschdeLogicLayer(_accessLayer).GetZeddelList(), Is.Empty);

        [Test]
        public void AddZeddelTest()
        {
            var zeddel1 = _fixture.Create<Zeddel>();
            var zeddel2 = _fixture.Create<Zeddel>();

            var target = new ZeddelkaschdeLogicLayer(_accessLayer);

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
            var target = new ZeddelkaschdeLogicLayer(_accessLayer);
            target.AddZeddel(zeddel);

            target.RemoveZeddel(zeddel);

            var result = target.GetZeddelList();
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void RemoveZeddelTest_ZeddelNotFound()
        {
            var addedZeddel = _fixture.Create<Zeddel>();
            var notAddedZeddel = _fixture.Create<Zeddel>();
            var target = new ZeddelkaschdeLogicLayer(_accessLayer);
            target.AddZeddel(addedZeddel);

            Assert.DoesNotThrow(() => target.RemoveZeddel(notAddedZeddel));

            var result = target.GetZeddelList();
            Assert.That(result, Has.Member(addedZeddel));
        }
    }

    public class KaschdeTests
    {
        private Fixture _fixture = new();

        private IZeddelkaschdeAccessLayer _accessLayer;


        [SetUp]
        public void SetUp()
        {
            var mockKaschdeList = new List<Kaschde>();
            var accessLayerMock = new Mock<IZeddelkaschdeAccessLayer>();
            accessLayerMock.Setup(mock => mock.GetKaschdeList()).Returns(mockKaschdeList);
            accessLayerMock.Setup(mock => mock.AddKaschde(It.IsAny<Kaschde>()))
                .Callback<Kaschde>(mockKaschdeList.Add);
            accessLayerMock.Setup(mock => mock.RemoveKaschde(It.IsAny<Kaschde>()))
                .Callback<Kaschde>(kaschde => mockKaschdeList.Remove(kaschde));
            _accessLayer = accessLayerMock.Object;
        }

        [Test]
        public void GetKaschdeListTest_InitiallyEmpty() =>
            Assert.That(new ZeddelkaschdeLogicLayer(_accessLayer).GetKaschdeList(), Is.Empty);

        [Test]
        public void AddKaschdeTest()
        {
            var kaschde1 = _fixture.Create<Kaschde>();
            var kaschde2 = _fixture.Create<Kaschde>();

            var target = new ZeddelkaschdeLogicLayer(_accessLayer);

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
            var target = new ZeddelkaschdeLogicLayer(_accessLayer);
            target.AddKaschde(kaschde);
            var result = target.GetKaschdeList();

            target.RemoveKaschde(kaschde);

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void RemoveKaschdeTest_KaschdeNotFound()
        {
            var addedKaschde = _fixture.Create<Kaschde>();
            var notAddedKaschde = _fixture.Create<Kaschde>();
            var target = new ZeddelkaschdeLogicLayer(_accessLayer);
            target.AddKaschde(addedKaschde);

            Assert.DoesNotThrow(() => target.RemoveKaschde(notAddedKaschde));

            var result = target.GetKaschdeList();
            Assert.That(result, Has.Member(addedKaschde));
        }
    }
}
