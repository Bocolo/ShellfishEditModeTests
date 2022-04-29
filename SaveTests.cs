using App.SaveSystem.Manager;
using NUnit.Framework;
using Samples.Data;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using Users.Data;
/// <summary>
/// tests the Save Data singleton
/// </summary>
public class SaveTests
{
    private SaveData _saveData;
    [OneTimeSetUp]
    public void ResetScene()
    {
        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
    }
    [OneTimeSetUp]
    public void SetUp()
    {
        GameObject go = new GameObject();
        _saveData = go.AddComponent<SaveData>();
        _saveData.SetSaveDataLogic();
    }
    /// <summary>
    /// clears submitted and stored samples after test
    /// </summary>
    [TearDown]
    public void TearDown()
    {
        _saveData.DeleteSubmittedSamplesFromDevice();
        _saveData.UpdateSubmittedStoredSamples();
    }
    /// <summary>
    /// tests the AddAndSaveSubmittedSample and LoadAndGetSubmittedSamples methods
    /// </summary>
    [Test]
    public void AddToSubmittedList()
    {
        Sample sample = new Sample
        {
            Name = "AddToSubmittedList Test"
        };
        _saveData.AddAndSaveSubmittedSample(sample);
        List<Sample> afterLoad = _saveData.LoadAndGetSubmittedSamples();
        Assert.AreEqual(sample, afterLoad[0]);
        Assert.AreEqual("AddToSubmittedList Test", afterLoad[0].Name);
        Assert.AreNotEqual(new Sample(), afterLoad[0]);
    }
    /// <summary>
    /// tests the AddAndSaveStoredSample and LoadAndGetStoredSamples methods
    /// </summary>
    [Test]
    public void AddToStoredList()
    {
        Sample sample = new Sample
        {
            Name = "AddToStoredList Test"
        };
        _saveData.AddAndSaveStoredSample(sample);
        List<Sample> afterLoad = _saveData.LoadAndGetStoredSamples();
        Assert.AreEqual(sample, afterLoad[0]);
        Assert.AreEqual("AddToStoredList Test", afterLoad[0].Name);
        Assert.AreNotEqual(new Sample(), afterLoad[0]);
     
    }
    /// <summary>
    /// test UpdateSubmittedStoredSamples
    /// UpdateSubmittedStoredSamples should: 
    /// 1. clear stored sample list
    /// 2. save the cleared stored sample list
    /// 3. save the submitted sample list
    /// </summary>
    [Test]
    public void UpdateSubmittedStoredSamples()
    {
        Sample sampleA = new Sample
        {
            Name = "UpdateSubmitted_StoredSamples Test"
        };
        Sample sampleB = new Sample
        {
            Name = "AddToSubmittedList Test"
        };
        int beforeAddStoredCount = _saveData.LoadAndGetStoredSamples().Count;
        _saveData.AddAndSaveStoredSample(sampleA);
        int afterAddStoredCount = _saveData.LoadAndGetStoredSamples().Count;
       
        Assert.AreEqual(beforeAddStoredCount + 1, afterAddStoredCount);
       
        int beforeUpdateSubmittedCount = _saveData.LoadAndGetSubmittedSamples().Count;
        _saveData.AddToSubmittedSamples(_saveData.LoadAndGetStoredSamples()[0]);
        _saveData.UpdateSubmittedStoredSamples();
        int afterUpdateStoredCount = _saveData.LoadAndGetStoredSamples().Count;
        int afterUpdateSubmittedCount = _saveData.LoadAndGetSubmittedSamples().Count;
       
        Assert.AreEqual(beforeUpdateSubmittedCount +1, afterUpdateSubmittedCount);
        Assert.AreEqual(afterUpdateStoredCount, 0);
        Assert.AreNotEqual(afterAddStoredCount, afterUpdateStoredCount);
    }
    /// <summary>
    /// 
    /// testa UpdateSubmittedStoredSamples with single sample
    /// </summary>
    [Test]
    public void UpdateSubmittedStoredSamplesTest_Simple()
    {
        Sample sample = new Sample
        {
            Name = "AddToStoredList Test"
        };
        _saveData.AddToStoredSamples(sample);
        _saveData.UpdateSubmittedStoredSamples();
        List<Sample> storedSamples = _saveData.UsersStoredSamples;
        Assert.IsEmpty(storedSamples);
        List<Sample> loadedStoredSamples = _saveData.LoadAndGetStoredSamples();
        Assert.IsEmpty(loadedStoredSamples);

    }
    /// <summary>
    /// tests the ClearSubmittedSamplesList method clears the sample list
    /// </summary>
    [Test]
    public void AddAndClearSubmittedSamples()
    {
        int loadedSamplesSize = _saveData.UsersSubmittedSamples.Count;
        Assert.AreEqual(loadedSamplesSize, 0);
        _saveData.AddToSubmittedSamples(new Sample());
        int newloadedSamplesSize = _saveData.UsersSubmittedSamples.Count;
        Assert.AreNotEqual(loadedSamplesSize, newloadedSamplesSize);
        Assert.AreEqual(loadedSamplesSize+1, newloadedSamplesSize);
        _saveData.ClearSubmittedSamplesList();
        Assert.AreNotEqual(newloadedSamplesSize, _saveData.UsersSubmittedSamples.Count);
        Assert.AreEqual(_saveData.UsersSubmittedSamples.Count, 0);
    }
    /// <summary>
    /// tests the ClearStoredSamplesList method clears the sample list
    /// </summary>
    [Test]
    public void AddAndClearStoredSamples()
    {
        int loadedSamplesSize = _saveData.UsersStoredSamples.Count;
        Assert.AreEqual(loadedSamplesSize, 0);
        _saveData.AddToStoredSamples(new Sample());
        int newloadedSamplesSize = _saveData.UsersStoredSamples.Count;
        Assert.AreNotEqual(loadedSamplesSize, newloadedSamplesSize);
        Assert.AreEqual(loadedSamplesSize + 1, newloadedSamplesSize);
        _saveData.ClearStoredSamplesList();
        Assert.AreNotEqual(newloadedSamplesSize, _saveData.UsersStoredSamples.Count);
        Assert.AreEqual(_saveData.UsersStoredSamples.Count, 0);
    }
    /// <summary>
    /// Tests the save and load user profile functions
    /// </summary>
    [Test]
    public void SaveLoadUserProfile()
    {
        User savedUser = new User()
        {
            Name = "Test User",
            Company = "Test Company",
            Email = "Test Email",
            SubmittedSamplesCount = 10
        };
        _saveData.SaveUserProfile(savedUser);
        User loadedUser = _saveData.LoadUserProfile();
        Assert.AreEqual(savedUser, loadedUser);
    }
    /// <summary>
    /// Simple test - to see if LoadAndGetSubmittedSamples returns a samples list
    /// </summary>
    [Test]
    public void LoadAndGetSubmittedSamplesTest()
    {
        List<Sample> afterLoad = _saveData.LoadAndGetSubmittedSamples();
        Assert.IsNotNull(afterLoad);
       
    }
    /// <summary>
    /// Simple test - to see if LoadAndGetStoredSamples returns a samples list
    /// </summary>
    [Test]
    public void LoadAndGetStoredSamplesTest()
    {
        List<Sample> afterLoad = _saveData.LoadAndGetStoredSamples();
        Assert.IsNotNull(afterLoad);
    }
    /// <summary>
    /// that the submitted samples list is cleared when ClearSubmittedSamplesList 
    /// is called
    /// </summary>
    [Test]
    public void ClearSubmittedTest()
    {
        Sample sample = new Sample
        {
            Name = "AddToSubmittedList Test"
        };
        _saveData.AddToSubmittedSamples(sample);
        List<Sample> submittedSamples = _saveData.UsersSubmittedSamples;
        Assert.IsNotEmpty(submittedSamples);
        _saveData.ClearSubmittedSamplesList();
        Assert.IsEmpty(submittedSamples);
    }
    /// <summary>
    /// that the submitted samples list is cleared when AddToStoredSamples 
    /// is called
    /// </summary>
    [Test]
    public void ClearStoredTest()
    {
        Sample sample = new Sample
        {
            Name = "AddToStoredList Test"
        };
        _saveData.AddToStoredSamples(sample);
        List<Sample> storedSamples = _saveData.UsersStoredSamples;
        Assert.IsNotEmpty(storedSamples);
        _saveData.ClearStoredSamplesList();
        Assert.IsEmpty(storedSamples);


    }

}
