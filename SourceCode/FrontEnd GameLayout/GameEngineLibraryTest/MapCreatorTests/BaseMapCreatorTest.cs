using System;
using System.IO;
using GameEngineLibrary.MapCreator;
using NUnit.Framework;


namespace GameEngineLibraryTest.MapTests;

[TestFixture]
public class BaseMapCreatorTest
{
  private BaseMapCreator _uut;

  [SetUp]
  public void Setup()
  {
    _uut = new BaseMapCreator(@"TestMapFile");
  }

  [Test]
  public void BaseMapCreatorConcatenateCorrectFilePath()
  {
    Assert.That(_uut.FilePath,Is.EqualTo(Environment.CurrentDirectory +@"\\" + @"TestMapFile"));
    
  }

  [Test]
  public void BaseMapCreatorMapLayoutFileExists()
  {
    Assert.That(File.Exists(_uut.FilePath),Is.True);
  }

  [TearDown]
  public void TearDown()
  {
    GC.Collect();
    File.Delete(_uut.FilePath);
  }
}