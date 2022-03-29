using System.Linq;
using GameEngineLibrary;
using NUnit.Framework;

namespace GameEngineLibraryTest;

[TestFixture]
public class TestMap
{
  private Map _uut;

  [SetUp]
  public void Setup()
  {
    _uut = new Map(10);
  }

  [Test]
  public void MapCanReturnRoom()
  {
    int RoomId = 0;

    Assert.That(_uut.GetRoom(RoomId), Is.Empty);
  }
}