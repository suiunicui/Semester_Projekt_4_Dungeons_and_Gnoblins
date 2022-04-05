using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using GameEngineLibrary;
using NUnit.Framework;

namespace GameEngineLibraryTest;

[TestFixture]
public class TestMap
{
  private Map _uut;
  private string filepath = Environment.CurrentDirectory + "\\Resource.txt";

  [SetUp]
  public void Setup()
  {
    var filecreator = File.Create(filepath);
    filecreator.Close();
    ResourceWriter rw = new ResourceWriter(filepath);
    rw.AddResource("room1","0,0,0,1");
    rw.AddResource("room2","0,1,0,0");
    rw.Close();
  }

  [Test]
  public void MapConstructorWorks()
  {
    _uut = new Map(2);
    LinkedList<int> rooms = new LinkedList<int>();
    rooms.AddLast(0);
    rooms.AddLast(0);
    rooms.AddLast(0);
    rooms.AddLast(1);

    LinkedList<int> rooms2 = new LinkedList<int>();
    rooms2.AddLast(0);
    rooms2.AddLast(1);
    rooms2.AddLast(0);
    rooms2.AddLast(0);

    Assert.That(_uut.MapLayout[0], Is.EqualTo(rooms));
    Assert.That(_uut.MapLayout[1], Is.EqualTo(rooms2));
  }

  [TearDown]
  public void TearDown()
  {
    GC.Collect();
    File.Delete(filepath);
  }

}
