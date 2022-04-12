using NUnit.Framework;
using Save.Manager;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class SaveTests
{
    private SaveData saveData;
    [SetUp]
    public void ResetScene()
    {
        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
    }
    [SetUp]
    public void SetUp()
    {
        GameObject go = new GameObject();
         saveData = go.AddComponent<SaveData>();
    }
    [Test]
    public void AddToSubmittedList()
    {
        Sample sample = new Sample
        {
            Name = "AddToSubmittedList Test"
        };
        saveData.AddAndSaveSubmittedSample(sample);
        List<Sample> afterLoad = saveData.LoadAndGetSubmittedSamples();
        Assert.AreEqual(sample, afterLoad[0]);
        Assert.AreNotEqual(new Sample(), afterLoad[0]);

    }
    [Test]
    public void AddToStoredList()
    {
        Sample sample = new Sample
        {
            Name = "AddToStoredList Test"
        };
        saveData.AddAndSaveStoredSample(sample);
        List<Sample> afterLoad = saveData.LoadAndGetStoredSamples();
        Assert.AreEqual(sample, afterLoad[0]);
        Assert.AreNotEqual(new Sample(), afterLoad[0]);

    }
    /// <summary>
    /// UpdateSubmittedStoredSamples should: 
    /// 1. clear stored sample list
    /// 2. save the cleared stored sample list
    /// 3. save the submitted sample list
    /// </summary>
    [Test]
    public void UpdateSubmitted_StoredSamples()
    {
        Sample sampleA = new Sample
        {
            Name = "UpdateSubmitted_StoredSamples Test"
        };
        Sample sampleB = new Sample
        {
            Name = "AddToSubmittedList Test"
        };
        saveData.AddAndSaveStoredSample(sampleA);
        List<Sample> afterLoad = saveData.LoadAndGetStoredSamples();
        Assert.AreEqual(sampleA, afterLoad[0]);

        List<Sample> beforeAddSubmitted = saveData.UsersSubmittedSamples;
        saveData.AddToSubmittedSamples(sampleB);

        saveData.UpdateSubmittedStoredSamples();
        List<Sample> afterUpdateSubmitted = saveData.LoadAndGetSubmittedSamples();
        List<Sample> afterUpdateStored = saveData.LoadAndGetStoredSamples();

        Assert.AreEqual(afterUpdateStored.Count, 0);

        Assert.AreEqual(afterUpdateSubmitted.Count, 1);



    }
 
    [Test]
    public void AddAndClearSubmittedSamples()
    {
       // saveData.LoadSubmittedSamples();
        List<Sample> loadedSamples = saveData.UsersSubmittedSamples;
        int loadedSamplesSize = loadedSamples.Count;
        Assert.AreEqual(loadedSamplesSize, 0);
        saveData.AddToSubmittedSamples(new Sample());
        loadedSamples = saveData.UsersSubmittedSamples;
        int newloadedSamplesSize = loadedSamples.Count;
        Assert.AreNotEqual(loadedSamplesSize, newloadedSamplesSize);
        Assert.AreEqual(loadedSamplesSize+1, newloadedSamplesSize);
        saveData.ClearSubmittedSamplesList();
        loadedSamples = saveData.UsersSubmittedSamples;
        Assert.AreNotEqual(newloadedSamplesSize, loadedSamples.Count);
        Assert.AreEqual(loadedSamples.Count, 0);
    }
    [Test]
    public void AddAndClearStoredSamples()
    {
        // saveData.LoadStoredSamples();
        List<Sample> loadedSamples = saveData.UsersStoredSamples;
        int loadedSamplesSize = loadedSamples.Count;
        Assert.AreEqual(loadedSamplesSize, 0);
        saveData.AddToStoredSamples(new Sample());
        loadedSamples = saveData.UsersStoredSamples;
        int newloadedSamplesSize = loadedSamples.Count;
        Assert.AreNotEqual(loadedSamplesSize, newloadedSamplesSize);
        Assert.AreEqual(loadedSamplesSize + 1, newloadedSamplesSize);
        saveData.ClearStoredSamplesList();
        loadedSamples = saveData.UsersStoredSamples;
        Assert.AreNotEqual(newloadedSamplesSize, loadedSamples.Count);
        Assert.AreEqual(loadedSamples.Count, 0);
    }
 
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
        saveData.SaveUserProfile(savedUser);
        User loadedUser = saveData.LoadUserProfile();
        Assert.AreEqual(savedUser, loadedUser);
      //  yield return null;
    }
    [Test]//maybe remove this
    public void LoadProfile()
    {
        string filepath = Application.persistentDataPath + "/userSave.dat";
        User user;
        if (System.IO.File.Exists(filepath))
        {
            user = saveData.LoadUserProfile();
            Assert.IsNotNull(user);//yeah not sure this is needed with abovce
        }
    }
}
