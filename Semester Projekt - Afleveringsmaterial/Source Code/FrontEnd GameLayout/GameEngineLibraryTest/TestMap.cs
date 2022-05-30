using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using GameEngineLibrary;
using GameEngineLibrary.MapImpl;
using NUnit.Framework;

namespace GameEngineLibraryTest;

[TestFixture]
private class TestMap
{
  private Map _uut;
  private string filepath = Environment.CurrentDirectory + "\\Resource.resources";

  [SetUp]
  public void Setup()
  {
    ResourceWriter filecreator = new ResourceWriter(filepath);
    filecreator.Close();
  }

  [Test]
  public void MapConstructorGivesEmptyListByDefault()
  {
    ResourceWriter rw = new ResourceWriter(filepath);
    rw.Close();

    _uut = new Map();
    
    Assert.That(_uut.MapLayout, Is.Empty);
  }

  [Test]
  public void MapConstructorWorks()
  {
    ResourceWriter rw = new ResourceWriter(filepath);
    rw.AddResource("room1","0,0,0,1");
    rw.Close();

    _uut = new Map();
    LinkedList<int> rooms = new LinkedList<int>();
    rooms.AddLast(0);
    rooms.AddLast(0);
    rooms.AddLast(0);
    rooms.AddLast(1);

    Assert.That(_uut.MapLayout[0], Is.EqualTo(rooms));
  }

  [TearDown]
  public void TearDown()
  {
    // GC.Collect();
    // File.Delete(filepath);
  }

}
