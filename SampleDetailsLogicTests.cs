using App.Samples;
using NUnit.Framework;
using Samples.Data;
using UnityEditor.SceneManagement;
/// <summary>
/// tests the sample details script
/// </summary>
public class SampleDetailsLogicTests
{
    private SampleLogic _sampleLogic;
    [OneTimeSetUp]
    public void ResetScene()
    {
        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
    }
    [OneTimeSetUp]
    public void SetUp()
    {
        _sampleLogic = new SampleLogic();
    }
    /// <summary>
    /// tests a valid date is authenticated
    /// </summary>
    [Test]
    public void TestIsDateValid_Pass_PassedData()
    {
        Assert.IsTrue(_sampleLogic.IsDateValid("3-2-2022"));
       
    }
    /// <summary>
    /// tests an invalid future date is not authenticated
    /// </summary>
    [Test]
    public void TestIsDateValid_Fail_FutureDate()
    {
        Assert.IsFalse(_sampleLogic.IsDateValid("3-2-2024"));
    }
    /// <summary>
    /// tests an invalid string  is not authenticated as a date
    /// </summary>
    [Test]
    public void TestIsDateValid_Fail_NotADate()
    {
        Assert.IsFalse(_sampleLogic.IsDateValid("not a date"));
    }
    /// <summary>
    /// tests tehe correct sample string is returned: with ices location
    /// </summary>
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
        string actualString = _sampleLogic.SampleWithIcesToString(sample);
        Assert.AreEqual(expectedString, actualString);

    }
    /// <summary>
    /// tests tehe correct sample string is returned: with sample location
    /// </summary>
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
        string actualString = _sampleLogic.SampleWithLocationToString(sample);
        Assert.AreEqual(expectedString, actualString);

    }
    /// <summary>
    /// test the get date function correctly parses the date
    /// </summary>
    [Test]
    public void GetDate_Test()
    {
        Assert.AreEqual("2022-02-02", _sampleLogic.GetDate("02", "02", "2022"));
    }
    /// <summary>
    /// MissingName method
    /// tests an empty name string returns the correct error message 
    /// </summary>
    [Test]
    public void MissingName_Test()
    {
        Assert.AreEqual("Please enter a name\n", _sampleLogic.MissingName("", null));
    }
    /// <summary>
    /// MissingDate method
    /// tests an empty date string returns the correct error message 
    /// </summary>
    [Test]
    public void MissingDate_Test()
    {
        Assert.AreEqual("Please enter a valid date\n", _sampleLogic.MissingDate("", null));
    }
    /// <summary>
    /// MissingCompany method
    /// tests an empty company string returns the correct error message 
    /// </summary>
    [Test]
    public void MissingCompany_Test()
    {
        Assert.AreEqual("Please enter a company name\n", _sampleLogic.MissingCompany("", null));
    }
    /// <summary>
    /// MissingOrDualLocation method
    /// tests dual null locations return the correct error message 
    /// </summary>
    [Test]
    public void MissingOrDualLocation_Test_BothNull()
    {
        Assert.AreEqual("You must enter <i>either</i> a Sample Location Date <i>or</i> an Ices Rectangle No.\n",
            _sampleLogic.MissingOrDualLocation("", null,null));
    }
    /// <summary>
    /// MissingOrDualLocation method
    /// tests dual locations return the correct error message 
    /// </summary>
    [Test]
    public void MissingOrDualLocation_Test_BothNotNull()
    {
        Assert.AreEqual("You must enter <i>either</i> a Sample Location Date <i>or</i> an Ices Rectangle No.\n",
            _sampleLogic.MissingOrDualLocation("", "dsad", "dasda"));
    }
    /// <summary>
    /// MissingProductionWeek method
    /// tests an empty week string returns the correct error message 
    /// </summary>
    [Test]
    public void MissingProductionWeek_Test()
    {
        Assert.AreEqual("Please enter the production week\n", _sampleLogic.MissingProductionWeek("", 0));
    }

    /// <summary>
    /// MissingName method
    /// tests a name string returns an empty string    
    /// /// </summary>
    [Test]
    public void MissingName_Test_Empty()
    {
        Assert.AreEqual("", _sampleLogic.MissingName("", "name"));
    }
    /// <summary>
    /// MissingDate method
    /// tests valid date strings returns an empty string    
    /// /// </summary>
    [Test]
    public void MissingDate_Test_Empty()
    {
        Assert.AreEqual("", _sampleLogic.MissingDate("", "2022 - 02 - 02"));
    }
    /// <summary>
    /// MissingCompany method
    /// tests a company string returns an empty string 
    /// </summary>
    [Test]
    public void MissingCompany_Test_Empty()
    {
        Assert.AreEqual("", _sampleLogic.MissingCompany("", "Company"));
    }
    /// <summary>
    /// MissingOrDualLocation method
    /// tests a single location (rectangle) and a null location returns an empty string 
    /// </summary>
    [Test]
    public void MissingOrDualLocation_Test_Location_Empty()
    {
        Assert.AreEqual("",
            _sampleLogic.MissingOrDualLocation("", "Rectangle", null));
    }
    /// <summary>
    /// MissingOrDualLocation method
    /// tests a single location  and a null location returns an empty string 
    /// </summary>
    [Test]
    public void MissingOrDualLocation_Test_Rectangle_Empty()
    {
        Assert.AreEqual("",
            _sampleLogic.MissingOrDualLocation("", null, "Location"));
    }
    /// <summary>
    /// MissingProductionWeek method
    /// tests passing an int returns an empty string 
    /// </summary>
    [Test]
    public void MissingProductionWeek_Test_Empty()
    {
        Assert.AreEqual("", _sampleLogic.MissingProductionWeek("", 5));
    }
}
