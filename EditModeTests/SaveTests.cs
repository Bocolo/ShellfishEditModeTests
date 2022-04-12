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

        List<Sample> beforeAddSubmitted = saveData.GetUserSubmittedSamples();
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
        List<Sample> loadedSamples = saveData.GetUserSubmittedSamples();
        int loadedSamplesSize = loadedSamples.Count;
        Assert.AreEqual(loadedSamplesSize, 0);
        saveData.AddToSubmittedSamples(new Sample());
        loadedSamples = saveData.GetUserSubmittedSamples();
        int newloadedSamplesSize = loadedSamples.Count;
        Assert.AreNotEqual(loadedSamplesSize, newloadedSamplesSize);
        Assert.AreEqual(loadedSamplesSize+1, newloadedSamplesSize);
        saveData.ClearSubmittedSamplesList();
        loadedSamples = saveData.GetUserSubmittedSamples();
        Assert.AreNotEqual(newloadedSamplesSize, loadedSamples.Count);
        Assert.AreEqual(loadedSamples.Count, 0);
    }
    [Test]
    public void AddAndClearStoredSamples()
    {
        // saveData.LoadStoredSamples();
        List<Sample> loadedSamples = saveData.GetUserStoredSamples();
        int loadedSamplesSize = loadedSamples.Count;
        Assert.AreEqual(loadedSamplesSize, 0);
        saveData.AddToStoredSamples(new Sample());
        loadedSamples = saveData.GetUserStoredSamples();
        int newloadedSamplesSize = loadedSamples.Count;
        Assert.AreNotEqual(loadedSamplesSize, newloadedSamplesSize);
        Assert.AreEqual(loadedSamplesSize + 1, newloadedSamplesSize);
        saveData.ClearStoredSamplesList();
        loadedSamples = saveData.GetUserStoredSamples();
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


/*    [Test]
    public void LoadAndSaveSubmittedSamples()
    {
        saveData.LoadSubmittedSamples();
        saveData.ClearSubmittedSamplesList();
        List<Sample> emptyListSamples = saveData.GetUserSubmittedSamples();
        int emptyListSamplesSize = emptyListSamples.Count;
        Assert.AreEqual(emptyListSamplesSize, 0);
        saveData.AddToSubmittedSamples(new Sample());
        List<Sample> submittedSamples = saveData.GetUserSubmittedSamples();
        int newListSize = submittedSamples.Count;
        Assert.AreEqual(newListSize, 1);
       
        
        //saveData.SaveSubmittedSamples();
        saveData.ClearSubmittedSamplesList();
        List<Sample> unsavedSamplesList = saveData.GetUserSubmittedSamples();
        int unsavedSamplesListSize = unsavedSamplesList.Count;
        saveData.LoadSubmittedSamples();
        List<Sample> savedSamplesList = saveData.GetUserSubmittedSamples();
        int savedSamplesListSize = savedSamplesList.Count;
        bool result = unsavedSamplesListSize < savedSamplesListSize;
        Assert.That(result, Is.True);
        Assert.AreEqual(unsavedSamplesListSize, 0);
        Assert.AreEqual(savedSamplesListSize,1);
    }
    [Test]
    public void LoadStoredSamples()
    {
        List<Sample> beforeLoad = saveData.GetUserStoredSamples();
        saveData.LoadStoredSamples();
        List<Sample> afterLoad = saveData.GetUserStoredSamples();
        Assert.AreNotEqual(afterLoad, beforeLoad);
    }*/
//[Test]
/*    public void LoadAndSaveStoredSamples()
    {
        saveData.LoadStoredSamples();
        saveData.ClearStoredSamplesList();
        List<Sample> emptyListSamples = saveData.GetUserStoredSamples();
        int emptyListSamplesSize = emptyListSamples.Count;
        Assert.AreEqual(emptyListSamplesSize, 0);
        saveData.AddToStoredSamples(new Sample());
        List<Sample> StoredSamples = saveData.GetUserStoredSamples();
        int newListSize = StoredSamples.Count;
        Assert.AreEqual(newListSize, 1);
        saveData.SaveStoredSamples();
        saveData.ClearStoredSamplesList();
        List<Sample> unsavedSamplesList = saveData.GetUserStoredSamples();
        int unsavedSamplesListSize = unsavedSamplesList.Count;
        saveData.LoadStoredSamples();
        List<Sample> savedSamplesList = saveData.GetUserStoredSamples();
        int savedSamplesListSize = savedSamplesList.Count;
        bool result = unsavedSamplesListSize < savedSamplesListSize;
        Assert.That(result, Is.True);
        Assert.AreEqual(unsavedSamplesListSize, 0);
        Assert.AreEqual(savedSamplesListSize, 1);
    }
    [Test]
    public void SaveDataStoredSamples()
    {
        saveData.LoadStoredSamples();
        saveData.ClearStoredSamplesList();
        int originalCount = saveData.GetUserStoredSamples().Count;
        Assert.AreEqual(originalCount, 0);
        saveData.AddToStoredSamples(new Sample() { Species = "Dog" });
        saveData.SaveStoredSamples();
        Assert.AreNotEqual(originalCount, saveData.GetUserStoredSamples().Count);
        saveData.ClearStoredSamplesList();
        Assert.AreEqual(originalCount, saveData.GetUserStoredSamples().Count);
        saveData.LoadStoredSamples();
        Assert.AreEqual(saveData.GetUserStoredSamples().ElementAt(0).Species, "Dog");
        int newCount = saveData.GetUserStoredSamples().Count;
        bool result = originalCount < newCount;
        Assert.That(result, Is.True);
     //   yield return null;
    }

    [Test]
    public void LoadSubmittedSamples()
    {
        //chekc the values 0--dfsdfa they are autoo
        //not equal because they are new lists when loaded even if values
        //are equal
        List<Sample> beforeLoad = saveData.GetUserSubmittedSamples();

        List<Sample> afterLoad = saveData.LoadAndGetSubmittedSamples();
        Assert.AreNotEqual(afterLoad, beforeLoad);
    }*/