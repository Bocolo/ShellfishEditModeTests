using NUnit.Framework;
using UI.Retrieve;
using UnityEditor.SceneManagement;
using UnityEngine;
public class SearchUITests
{
    SearchSampleUI searchSampleUI;
  [OneTimeSetUp]
    public void ResetScene()
    {
        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
    }
    [OneTimeSetUp]
    public void SetUp()
    {
        GameObject go = new GameObject();
         searchSampleUI = go.AddComponent<SearchSampleUI>();
        searchSampleUI.SetUpTestVariables();
      
    }
    [Test]
    public void TestSetSearchValues()
    {
        searchSampleUI.SetSearchInputText("Input");
        searchSampleUI.SetSearchLimitText("3");
        searchSampleUI.SetSearchValues();
    /*    searchSampleUI.SetSeachFieldTest(0);*/
        Assert.AreEqual(searchSampleUI.SearchNameSelection, "Input");
        Assert.AreEqual(searchSampleUI.SearchLimitSelection, 3);
    }
    [Test]
    public void SetSearchFieldEmpty()
    {
       // searchSampleUI.SetSeachFieldTest(0);

        searchSampleUI.SetSeachFieldTest(0);
        Assert.AreEqual(searchSampleUI.SearchFieldSelection, "");
    }
    [Test]
    public void SetSearchFieldToName()
    {
        searchSampleUI.SetSeachFieldTest(1);
        Assert.AreEqual(searchSampleUI.SearchFieldSelection, "Name");
    }
    [Test]
    public void SetSearchFieldToCompany()
    {
        searchSampleUI.SetSeachFieldTest(2);
        Assert.AreEqual(searchSampleUI.SearchFieldSelection, "Company");
    }
    [Test]
    public void SetSearchFieldToSpecies()
    {
        searchSampleUI.SetSeachFieldTest(3);
        Assert.AreEqual(searchSampleUI.SearchFieldSelection, "Species");
    }
    public void SetSearchFieldToProductionWeek()
    {
        searchSampleUI.SetSeachFieldTest(4);
        Assert.AreEqual(searchSampleUI.SearchFieldSelection, "ProductionWeekNo");
    }
    [Test]
    public void SetSearchFieldToDate()
    {
        searchSampleUI.SetSeachFieldTest(5);
        Assert.AreEqual(searchSampleUI.SearchFieldSelection, "Date");
    }
}
