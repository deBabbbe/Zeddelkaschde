using AutoFixture;
using Core;
using Core.DataAccessLayer;
using Core.DataTypes;
using NUnit.Framework.Internal;

namespace CoreTests.DataAccessLayer;

public class ZeddelkaschdeAccessLayerTests
{
    [Test]
    public void ConstructorTest() =>
        Assert.That(new ZeddelkaschdeAccessLayer(), Is.InstanceOf<IZeddelkaschdeAccessLayer>());

    public class ZeddelTests
    {
        private Fixture _fixture = new();

        [SetUp]
        public void Setup()
        {
            using var db = new ZeddelkaschdeContext();
            var allZeddel = db.ZeddelList.ToList();
            if (allZeddel.Count > 0)
            {
                db.ZeddelList.RemoveRange(allZeddel);
                db.SaveChanges();
            }
        }

        [Test]
        public void AddZeddelTest()
        {
            var zeddel1 = new Zeddel
            {
                Answer = new ZeddelContent
                {
                    Id = Guid.NewGuid(),
                    Text = "Answer1"
                },
                Id = Guid.NewGuid(),
                Question = new ZeddelContent
                {
                    Id = Guid.NewGuid(),
                    Text = "Question1"
                },
            };
            var zeddel2 = new Zeddel
            {
                Answer = new ZeddelContent
                {
                    Id = Guid.NewGuid(),
                    Text = "Answer2"
                },
                Id = Guid.NewGuid(),
                Question = new ZeddelContent
                {
                    Id = Guid.NewGuid(),
                    Text = "Question2"
                },
            };

            var target = new ZeddelkaschdeAccessLayer();

            target.AddZeddel(zeddel1);
            target.AddZeddel(zeddel2);

            var result = target.GetZeddelList();

            Assert.That(result, Has.Member(zeddel1));
            Assert.That(result, Has.Member(zeddel2));
        }

        public class KaschdeTests
        { }
    }
}
