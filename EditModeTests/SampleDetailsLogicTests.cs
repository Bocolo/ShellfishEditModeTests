using NUnit.Framework;
using UnityEditor.SceneManagement;
using UnityEngine;
using UI.Submit;
using System;
using Samples.Logic;
public class SampleDetailsLogicTests
{
    private SampleDetailsLogic sampleDetails;
    [OneTimeSetUp]
    public void ResetScene()
    {
        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
    }
    [OneTimeSetUp]
    public void SetUp()
    {
        sampleDetails = new SampleDetailsLogic();
    }
    [Test]
    public void TestIsDateValid_Pass_PassedData()
    {
        Assert.IsTrue(sampleDetails.IsDateValid("3-2-2022"));
       
    }
    [Test]
    public void TestIsDateValid_Fail_FutureDate()
    {
        Assert.IsFalse(sampleDetails.IsDateValid("3-2-2024"));
    }
    [Test]
    public void TestIsDateValid_Fail_NotADate()
    {
        Assert.IsFalse(sampleDetails.IsDateValid("not a date"));
    }
    [Test]
    public void SampleWithIceString_Test()
    {
        Sample sample = new Sample
        {
            Name = "name",
            Company = "company",
            Species = "species",
            IcesRectangleNo = "254",
            ProductionWeekNo = 22,
            Date="date",
            Comment="comment"
        };
        string expectedString = "Name: " + "name" + "\nCompany: " + "company"
            + "\nSpecies: " + "species"
                 + $"\nICEs Rectangle: 254"
                 + "\nWeek: " + 22 + "\nDate: "
                 + "date" + "\nComment: " + "comment";
        string actualString = sampleDetails.SampleWithIcesToString(sample);
        Assert.AreEqual(expectedString, actualString);

    }
    [Test]
    public void SampleWithLocationToString_Test()
    {
        Sample sample = new Sample
        {
            Name = "name",
            Company = "company",
            Species = "species",
            SampleLocationName = "254",
            ProductionWeekNo = 22,
            Date = "date",
            Comment = "comment"
        };
        string expectedString = 
        "Name: " + "name" + "\nCompany: " + "company"
             + "\nSpecies: " + "species"
                    + "\nLocation: " + "254"
                  + "\nWeek: " + 22 + "\nDate: "
                 + "date" + "\nComment: " + "comment";
        string actualString = sampleDetails.SampleWithLocationToString(sample);
        Assert.AreEqual(expectedString, actualString);

    }
    [Test]
    public void GetDate_Test()
    {
        Assert.AreEqual("2022-02-02", sampleDetails.GetDate("02", "02", "2022"));
    }
    [Test]
    public void MissingName_Test()
    {
        Assert.AreEqual("Please enter a name\n", sampleDetails.MissingName("", null));
    }
    [Test]
    public void MissingDate_Test()
    {
        Assert.AreEqual("Please enter a valid date\n", sampleDetails.MissingDate("", null));
    }
    [Test]
    public void MissingCompany_Test()
    {
        Assert.AreEqual("Please enter a company name\n", sampleDetails.MissingCompany("", null));
    }
    [Test]
    public void MissingOrDualLocation_Test_BothNull()
    {
        Assert.AreEqual("You must enter <i>either</i> a Sample Location Date or an Ices Rectangle No.\n",
            sampleDetails.MissingOrDualLocation("", null,null));
    }
    [Test]
    public void MissingOrDualLocation_Test_BothNotNull()
    {
        Assert.AreEqual("You must enter <i>either</i> a Sample Location Date or an Ices Rectangle No.\n",
            sampleDetails.MissingOrDualLocation("", "dsad", "dasda"));
    }
    [Test]
    public void MissingProductionWeek_Test()
    {
        Assert.AreEqual("Please enter the production week\n", sampleDetails.MissingProductionWeek("", 0));
    }


    [Test]
    public void MissingName_Test_Empty()
    {
        Assert.AreEqual("", sampleDetails.MissingName("", "name"));
    }
    [Test]
    public void MissingDate_Test_Empty()
    {
        Assert.AreEqual("", sampleDetails.MissingDate("", "2022 - 02 - 02"));
    }
    [Test]
    public void MissingCompany_Test_Empty()
    {
        Assert.AreEqual("", sampleDetails.MissingCompany("", "Company"));
    }
    [Test]
    public void MissingOrDualLocation_Test_Location_Empty()
    {
        Assert.AreEqual("",
            sampleDetails.MissingOrDualLocation("", "Rectangle", null));
    }
    [Test]
    public void MissingOrDualLocation_Test_Rectangle_Empty()
    {
        Assert.AreEqual("",
            sampleDetails.MissingOrDualLocation("", null, "Location"));
    }
    [Test]
    public void MissingProductionWeek_Test_Empty()
    {
        Assert.AreEqual("", sampleDetails.MissingProductionWeek("", 5));
    }
}
