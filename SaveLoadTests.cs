using App.SaveSystem;
using NUnit.Framework;
using Samples.Data;
using System.Collections.Generic;
using Users.Data;

public class SaveLoadTests
{
    private SaveDataLogic _saveDatLogca;

    [OneTimeSetUp]
    public void SetUp()
    {
        _saveDatLogca = new SaveDataLogic();
    }
    /// <summary>
    /// Test the Save Data load and save sample functions
    /// </summary>
    [Test]
    public void SaveAndLoadSamples_Test()
    {
        List<Sample> samplesList = new List<Sample>();
        Sample sampleA = new Sample
        {
            Name = "Name",
            Company = "Company",
            Comment="Comment",
            Species="Species",
            SampleLocationName="location",
            ProductionWeekNo =3,
            IcesRectangleNo ="Rectangle"
        };
        Sample sampleB = new Sample
        {
            Name = "Name2",
            Company = "Company2",
            Comment = "Comment2",
            Species = "Species2",
            SampleLocationName = "location2",
            ProductionWeekNo = 30,
            IcesRectangleNo = "Rectangle2"
        };
        samplesList.Add(sampleA);
        samplesList.Add(sampleB);
        _saveDatLogca.SaveSamples("saveSamplesTest", samplesList);
        List<Sample> loadedSamplesList = _saveDatLogca.LoadSamples("saveSamplesTest");
        Assert.AreEqual(samplesList.Count, loadedSamplesList.Count);

        Assert.AreEqual(samplesList[0], loadedSamplesList[0]);
        Assert.AreEqual(samplesList[1], loadedSamplesList[1]);
        Assert.AreEqual(samplesList, loadedSamplesList);
    }
    /// <summary>
    /// Test the Save Data load and save user functions
    /// </summary>
    [Test]
    public void SaveAndLoadUser_Test()
    {
        User user = new User
        {
            Name = "Name",
            Company = "Company",
            SubmittedSamplesCount = 5
        };
        _saveDatLogca.SaveUser("saveUserTest", user);
       User loadedUser= _saveDatLogca.LoadUserProfile("saveUserTest");
        Assert.AreEqual(user, loadedUser);
        Assert.AreEqual(user.Name, loadedUser.Name);
        Assert.AreEqual(user.Company, loadedUser.Company);
        Assert.AreEqual(user.SubmittedSamplesCount, loadedUser.SubmittedSamplesCount);
    }



}
