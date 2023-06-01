using System;
using HXINTL_HFT_2022232.Logic;
using HXINTL_HFT_2022232.Models;
using HXINTL_HFT_2022232.Repository;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace HXINTL_HFT_2022232.Test
{
    public class LogicLayerTest
    {
        [TestFixture]
        public class TrackTest
        {
            [Test]
            public void TrackNameTest()
            {
                Track t = new Track { NamePlace = "ballads", TrackId = 1 };
                Assert.AreEqual("ballads", t.NamePlace);
            }
            [Test]
            public void TrackNameTest2()
            {
                Track t = new Track { NamePlace = "novelty songs", TrackId = 2 };
                Assert.AreEqual("novelty songs", t.NamePlace);
            }
            [Test]
            public void TrackFirstCharacterTest()
            {
                Track t = new Track { NamePlace = "ballads" };
                Assert.That(t.NamePlace.First, Is.EqualTo('b'));
            }
            [Test]

            public void TrackIdTest()
            {
                Track t = new Track { NamePlace = "blues", TrackId = 5 };
                Assert.That(t.TrackId, Is.EqualTo(5));
            }
            [Test]
            public void TrackFirstCharacterTest2()
            {
                Track t = new Track { NamePlace = "anthems" };
                Assert.That(t.NamePlace.First, Is.EqualTo('a'));
            }
            [Test]
            public void TrackAlbumTest()
            {
                Track t = new Track { NamePlace = "ballads", Length = 15 };
                Assert.That(t.Length, Is.EqualTo(15));
            }
            [Test]
            public void TrackAlbumTest2()
            {
                Track t = new Track { NamePlace = "rock", Length = 30 };
                Assert.That(t.Length, Is.EqualTo(30));
            }

            [Test]
            public void TrackObjectThrowsTest()
            {
                Track t = new();
                Assert.That(() => t.CreateInstanceFromString("#EMINEM%2012"),
                    Throws.TypeOf<FormatException>());
            }

            [Test]
            public void TrackObjectNotThrowsTest()
            {
                Track t = new();
                Assert.That(() => t.CreateInstanceFromString("EMINEM%2012"),
                    !Throws.TypeOf<FormatException>());
            }

        }
        public class LogicLayerTest2
        {
            [TestFixture]

            public class LogicLayerTestMock
            {
                AlbumLogic A1;


                [SetUp]
                public void Init()
                {
                    var MockA = new Mock<IAlbumRepository>();

                    Track fakeTrack = new Track();
                    fakeTrack.TrackId = 1;
                    fakeTrack.NamePlace = "ballads";
                    var albums = new List<Beand>()
                {
                    new Beand(){
                        AlbumID = 11, Title = "Title 1 " , TracktID = 1 ,BasePrice =1000
                    },
                    new Beand(){
                       AlbumID = 22, Title = "Title 2", TracktID = 1,BasePrice=2000
                    }
                }.AsQueryable();

                    MockA.Setup((r) => r.GetAll())
                        .Returns(albums);

                    A1 = new AlbumLogic(MockA.Object);
                }


                [Test]
                public void AVGPriceOfAlbum()
                {

                    var result = A1.AVGPrice();

                    Assert.That(result, Is.EqualTo(1500));

                }



            }
        }

    }
}

