using NUnit.Framework;
using Save.Manager;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
public class SaveTests
{
    private SaveData saveData;
    [OneTimeSetUp]
    public void ResetScene()
    {
        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
    }
    [OneTimeSetUp]
    public void SetUp()
    {
        GameObject go = new GameObject();
         saveData = go.AddComponent<SaveData>();
    }
    [TearDown]
    public void TearDown()
    {
        saveData.DeleteSubmittedSamplesFromDevice();
        saveData.UpdateSubmittedStoredSamples();
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
        Assert.AreEqual("AddToSubmittedList Test", afterLoad[0].Name);
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
        Assert.AreEqual("AddToStoredList Test", afterLoad[0].Name);
        Assert.AreNotEqual(new Sample(), afterLoad[0]);
     
    }
    /// <summary>
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
        int beforeAddStoredCount = saveData.LoadAndGetStoredSamples().Count;
        saveData.AddAndSaveStoredSample(sampleA);
        int afterAddStoredCount = saveData.LoadAndGetStoredSamples().Count;
       
        Assert.AreEqual(beforeAddStoredCount + 1, afterAddStoredCount);
       
        int beforeUpdateSubmittedCount = saveData.LoadAndGetSubmittedSamples().Count;
        saveData.AddToSubmittedSamples(saveData.LoadAndGetStoredSamples()[0]);
        saveData.UpdateSubmittedStoredSamples();
        int afterUpdateStoredCount = saveData.LoadAndGetStoredSamples().Count;
        int afterUpdateSubmittedCount = saveData.LoadAndGetSubmittedSamples().Count;//saveData.LoadAndGetSubmittedSamples().Count;
       
        Assert.AreEqual(beforeUpdateSubmittedCount +1, afterUpdateSubmittedCount);//new add
        Assert.AreEqual(afterUpdateStoredCount, 0);
        Assert.AreNotEqual(afterAddStoredCount, afterUpdateStoredCount);
    }
    [Test]
    public void UpdateSubmittedStoredSamplesTestSimple()
    {
        Sample sample = new Sample
        {
            Name = "AddToStoredList Test"
        };
        saveData.AddToStoredSamples(sample);
        saveData.UpdateSubmittedStoredSamples();
        List<Sample> storedSamples = saveData.UsersStoredSamples;
        Assert.IsEmpty(storedSamples);
        List<Sample> loadedStoredSamples = saveData.LoadAndGetStoredSamples();
        Assert.IsEmpty(loadedStoredSamples);

    }
    [Test]
    public void AddAndClearSubmittedSamples()
    {
        int loadedSamplesSize = saveData.UsersSubmittedSamples.Count;
        Assert.AreEqual(loadedSamplesSize, 0);
        saveData.AddToSubmittedSamples(new Sample());
        int newloadedSamplesSize = saveData.UsersSubmittedSamples.Count;
        Assert.AreNotEqual(loadedSamplesSize, newloadedSamplesSize);
        Assert.AreEqual(loadedSamplesSize+1, newloadedSamplesSize);
        saveData.ClearSubmittedSamplesList();
        Assert.AreNotEqual(newloadedSamplesSize, saveData.UsersSubmittedSamples.Count);
        Assert.AreEqual(saveData.UsersSubmittedSamples.Count, 0);
    }
    [Test]
    public void AddAndClearStoredSamples()
    {
        int loadedSamplesSize = saveData.UsersStoredSamples.Count;
        Assert.AreEqual(loadedSamplesSize, 0);
        saveData.AddToStoredSamples(new Sample());
        int newloadedSamplesSize = saveData.UsersStoredSamples.Count;
        Assert.AreNotEqual(loadedSamplesSize, newloadedSamplesSize);
        Assert.AreEqual(loadedSamplesSize + 1, newloadedSamplesSize);
        saveData.ClearStoredSamplesList();
        Assert.AreNotEqual(newloadedSamplesSize, saveData.UsersStoredSamples.Count);
        Assert.AreEqual(saveData.UsersStoredSamples.Count, 0);
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
    [Test]
    public void LoadAndGetSubmittedSamplesTest()
    {
        List<Sample> afterLoad = saveData.LoadAndGetSubmittedSamples();
        Assert.IsNotNull(afterLoad);
    }
    [Test]
    public void LoadAndGetStoredSamplesTest()
    {
        List<Sample> afterLoad = saveData.LoadAndGetStoredSamples();
        Assert.IsNotNull(afterLoad);
    }
    [Test]
    public void ClearSubmittedTest()
    {
        Sample sample = new Sample
        {
            Name = "AddToSubmittedList Test"
        };
        saveData.AddToSubmittedSamples(sample);
        List<Sample> submittedSamples = saveData.UsersSubmittedSamples;
        Assert.IsNotEmpty(submittedSamples);
        saveData.ClearSubmittedSamplesList();
        Assert.IsEmpty(submittedSamples);
    }
    [Test]
    public void ClearStoredTest()
    {
        Sample sample = new Sample
        {
            Name = "AddToStoredList Test"
        };
        saveData.AddToStoredSamples(sample);
        List<Sample> storedSamples = saveData.UsersStoredSamples;
        Assert.IsNotEmpty(storedSamples);
        saveData.ClearStoredSamplesList();
        Assert.IsEmpty(storedSamples);


    }
    /*  [Test]//maybe remove this
      public void LoadProfile()
      {
          string filepath = Application.persistentDataPath + "/userSave.dat";
          User user;
          if (System.IO.File.Exists(filepath))
          {
              user = saveData.LoadUserProfile();
              Assert.IsNotNull(user);//yeah not sure this is needed with abovce
          }
      }*/
}
