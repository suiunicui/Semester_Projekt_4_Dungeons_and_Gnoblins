using System.Security.Cryptography.X509Certificates;
using GameEngine.Implementations;
using GameEngine.Interfaces;
using NUnit.Framework;

namespace GameEngineTest.LogTest;

[TestFixture]
public class LogTest
{
    private ILog uut;

    [SetUp]
    public void SetUp()
    {
        uut = new Log();
    }

    [Test]
    public void Constructor_Dictionary_IsEmpty()
    {
        Assert.That(uut.LogEntry,Is.Empty);
    }

    [Test]
    public void RecordEvent_CanRecordEvent()
    {
        uut.RecordEvent("message", "Hello Test");
        Assert.That(uut.LogEntry["message"],Is.EqualTo("Hello Test"));
    }

    [Test]
    public void GetRecord_CanRetrieveEvent()
    {
        uut.RecordEvent("Message", "Hello Test");
        Assert.That(uut.GetRecord("Message"),Is.EqualTo("Hello Test"));
    }

    [Test]
    public void GetRecord_CaseInsensitive_canRetrieveEvent()
    {
        uut.RecordEvent("MESsage", "Hello Test");
        Assert.That(uut.GetRecord("message"), Is.EqualTo("Hello Test"));
    }
}