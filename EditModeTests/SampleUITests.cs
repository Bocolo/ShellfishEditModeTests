using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UI.SampleDisplay;
using UnityEngine.UI;

public class SampleUITests
{
    private SampleUI sampleUI;
    private List<Sample> samples;
    [SetUp]
    public void ResetScene()
    {
        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
    }
    [SetUp]
    public void SetUp()
    {
        GameObject go1 = new GameObject();
        sampleUI = go1.AddComponent<SampleUI>();
        sampleUI.SetUpTestVariables();

        samples = new List<Sample>();
        samples.Add(new Sample());
        samples.Add(new Sample());
        samples.Add(new Sample());
    }
    [Test]
    public void SimplePrefabTest()
    {
        
        sampleUI.AddTextAndPrefab(samples);
        int childPrefabCount = sampleUI.GetContentParent().transform.childCount;
        Assert.AreEqual(childPrefabCount, samples.Count);
    }
    [Test]
    public void ListSamples_PrefabTest()
    {
        samples = new List<Sample>();
        Sample sampleA = new Sample
        {
            Name = "Test Sample",
            Company = "Test Company",
            Species = "Test Species",
            ProductionWeekNo = 99,
            IcesRectangleNo = "Test Rectangle",
            Date = "Test Date",
            Comment = "Test Comment"

        };
        Sample sampleB = new Sample
        {
            Name = "Test Sample",
            Company = "Test Company",
            Species = "Test Species",
            ProductionWeekNo = 99,
            SampleLocationName = "Test Location",
            Date = "Test Date",
            Comment = "Test Comment"

        };
        samples.Add(sampleA);
        samples.Add(sampleB);
        sampleUI.AddTextAndPrefab(samples);
        int childPrefabCount = sampleUI.GetContentParent().transform.childCount;
        
        Assert.AreEqual(childPrefabCount, samples.Count);


        Text childA = sampleUI.GetContentParent().GetChild(0).GetChild(0).gameObject.GetComponent<Text>();
        string expectedStringA = "Name: " + sampleA.Name + "\nCompany: " + sampleA.Company + "\nSpecies: " + sampleA.Species
               + $"\nICEs Rectangle: {sampleA.IcesRectangleNo}"
               + "\nWeek: " + sampleA.ProductionWeekNo + "\nDate: " + sampleA.Date + "\nComment: " + sampleA.Comment;
        
        Assert.AreEqual(expectedStringA, childA.text);


        Text childB = sampleUI.GetContentParent().GetChild(1).GetChild(0).gameObject.GetComponent<Text>();
        string expectedStringB = ("Name: " + sampleB.Name + "\nCompany: " + sampleB.Company + "\nSpecies: " + sampleB.Species
                + "\nLocation: " + sampleB.SampleLocationName + "\nWeek: " + sampleB.ProductionWeekNo + "\nDate: " + sampleB.Date
                + "\nComment: " + sampleB.Comment);
        
        Assert.AreEqual(expectedStringB, childB.text);

        Assert.AreNotEqual("Will Fail", childA.text);
        Assert.AreNotEqual("Will Fail", childB.text);
    }
    [Test]
    public void SingleSample_PrefabTest_Ices()
    {
        Sample sample = new Sample
        {
            Name = "Test Sample",
            Company = "Test Company",
            Species = "Test Species",
            ProductionWeekNo = 99,
            IcesRectangleNo = "Test Rectangle",
            Date = "Test Date",
            Comment ="Test Comment"

        };
        sampleUI.AddTextAndPrefab(sample);
        int childPrefabCount = sampleUI.GetContentParent().transform.childCount;
        Assert.AreEqual(1,childPrefabCount);
        Text child = sampleUI.GetContentParent().GetChild(0).GetChild(0).gameObject.GetComponent<Text>();
        string expectedString = "Name: " + sample.Name + "\nCompany: " + sample.Company + "\nSpecies: " + sample.Species
               + $"\nICEs Rectangle: {sample.IcesRectangleNo}"
               + "\nWeek: " + sample.ProductionWeekNo + "\nDate: " + sample.Date + "\nComment: " + sample.Comment;
        Assert.AreEqual(expectedString, child.text);
    }
    [Test]
    public void SingleSample_PrefabTest_Location()
    {
        Sample sample = new Sample
        {
            Name = "Test Sample",
            Company = "Test Company",
            Species = "Test Species",
            ProductionWeekNo = 99,
            SampleLocationName = "Test Location",
            Date = "Test Date",
            Comment = "Test Comment"

        };
        sampleUI.AddTextAndPrefab(sample);
        int childPrefabCount = sampleUI.GetContentParent().transform.childCount;

        Assert.AreEqual(1, childPrefabCount);

        Text child = sampleUI.GetContentParent().GetChild(0).GetChild(0).gameObject.GetComponent<Text>();
        string expectedString = ("Name: " + sample.Name + "\nCompany: " + sample.Company + "\nSpecies: " + sample.Species
                + "\nLocation: " + sample.SampleLocationName + "\nWeek: " + sample.ProductionWeekNo + "\nDate: " + sample.Date
                + "\nComment: " + sample.Comment);
        Assert.AreEqual(expectedString, child.text);
    }
    //testing add TExt and prefabs
}
