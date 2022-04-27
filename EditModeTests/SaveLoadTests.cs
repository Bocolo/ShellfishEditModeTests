using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Save.Logic;
public class SaveLoadTests
{
    private SaveDataLogic saveData;

    [OneTimeSetUp]
    public void SetUp()
    {
        saveData = new SaveDataLogic();
    }

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
        saveData.SaveSamples("saveSamplesTest", samplesList);
        List<Sample> loadedSamplesList = saveData.LoadSamples("saveSamplesTest");
        Assert.AreEqual(samplesList.Count, loadedSamplesList.Count);

        Assert.AreEqual(samplesList[0], loadedSamplesList[0]);
        Assert.AreEqual(samplesList[1], loadedSamplesList[1]);
        Assert.AreEqual(samplesList, loadedSamplesList);
    }
    [Test]
    public void SaveAndLoadUser_Test()
    {
        User user = new User
        {
            Name = "Name",
            Company = "Company",
            SubmittedSamplesCount = 5
        };
        saveData.SaveUser("saveUserTest", user);
       User loadedUser= saveData.LoadUserProfile("saveUserTest");
        Assert.AreEqual(user, loadedUser);
        Assert.AreEqual(user.Name, loadedUser.Name);
        Assert.AreEqual(user.Company, loadedUser.Company);
        Assert.AreEqual(user.SubmittedSamplesCount, loadedUser.SubmittedSamplesCount);

    }



}
