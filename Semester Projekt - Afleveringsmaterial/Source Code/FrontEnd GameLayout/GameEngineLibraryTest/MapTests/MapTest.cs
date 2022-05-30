using System;
using System.Collections.Generic;
using System.IO;
using System.Resources;
using Castle.Core.Internal;
using GameEngineLibrary.MapCreator;
using GameEngineLibrary.MapImpl;
using NUnit.Framework;

namespace GameEngineLibraryTest.MapTests;

[TestFixture]
public class MapTest_baseMap
{
  private Map _uut;

  [SetUp]
  public void SetUp()
  {
    _uut = new Map(new BaseMapCreator());
  }

  [Test]
  public void BaseMapHasNineTeenRoomsByDefault()
  {
    Assert.That(_uut.MapLayout.Length, Is.EqualTo(19));
  }

  [Test]
  public void BaseMapConstructorGivesNonEmptyMapLayoutList()
  {
    Assert.That(_uut.MapLayout,Is.Not.Null);
  }

  [Test]
  public void BaseMapConstructorCorrectlyConstructLayoutList()
  {
    LinkedList<int> rooms = new LinkedList<int>();
    rooms.AddLast(2);
    rooms.AddLast(4);
    rooms.AddLast(-1);
    rooms.AddLast(5);

    Assert.That(_uut.MapLayout[2], Is.EqualTo(rooms));
  }


}