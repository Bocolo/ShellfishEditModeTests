using NUnit.Framework;/*
using Submit.UI;*/
using Save.Manager;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

public class SaveTests
{
/*    [UnityTest]
    public IEnumerator SaveDataSubmittedSamples()
    {
        GameObject go = new GameObject();
        go.AddComponent<SaveData>();
        //add maybe get list and compare to loaded list
       List<Sample> beforeLoad = SaveData.Instance.GetUserSubmittedSamples();
        SaveData.Instance.LoadSubmittedSamples();
        List<Sample> afterLoad = SaveData.Instance.GetUserSubmittedSamples();
        Assert.AreNotEqual(afterLoad,beforeLoad );
        SaveData.Instance.LoadSubmittedSamples();
        SaveData.Instance.ClearSubmittedSamplesList();
        int originalCount = SaveData.Instance.GetUserSubmittedSamples().Count;
        Assert.AreEqual(originalCount,0);
        SaveData.Instance.AddToSubmittedSamples(new Sample() { Species = "Dog" });
        SaveData.Instance.SaveSubmittedSamples();
        Assert.AreNotEqual(originalCount, SaveData.Instance.GetUserSubmittedSamples().Count);
        SaveData.Instance.ClearSubmittedSamplesList();
        Assert.AreEqual(originalCount, SaveData.Instance.GetUserSubmittedSamples().Count);
        SaveData.Instance.LoadSubmittedSamples();
        Assert.AreEqual(SaveData.Instance.GetUserSubmittedSamples().ElementAt(0).Species, "Dog");
        int newCount = SaveData.Instance.GetUserSubmittedSamples().Count;
        bool result = originalCount < newCount;
        Assert.That(result, Is.True);
        yield return null;
    }*/
/*    [UnityTest]
    public IEnumerator SaveDataStoredSamples()
    {
        GameObject go = new GameObject();
        go.AddComponent<SaveData>();
        SaveData.Instance.LoadStoredSamples();
        SaveData.Instance.ClearStoredSamplesList();
        int originalCount = SaveData.Instance.GetUserStoredSamples().Count;
        Assert.AreEqual(originalCount, 0);
        SaveData.Instance.AddToStoredSamples(new Sample() { Species = "Dog" });
        SaveData.Instance.SaveStoredSamples();
        Assert.AreNotEqual(originalCount, SaveData.Instance.GetUserStoredSamples().Count);
        SaveData.Instance.ClearStoredSamplesList();
        Assert.AreEqual(originalCount, SaveData.Instance.GetUserStoredSamples().Count);
        SaveData.Instance.LoadStoredSamples();
        Assert.AreEqual(SaveData.Instance.GetUserStoredSamples().ElementAt(0).Species, "Dog");
        int newCount = SaveData.Instance.GetUserStoredSamples().Count;
        bool result = originalCount < newCount;
        Assert.That(result, Is.True);
        yield return null;
    }*/
    [UnityTest]
    public IEnumerator SaveDataUserProfile()
    {
        GameObject go = new GameObject();
        go.AddComponent<SaveData>();
        User savedUser = new User()
        {
            Name = "Test User",
            Company = "Test Company",
            Email = "Test Email",
            SubmittedSamplesCount = 10
        };
        SaveData.Instance.SaveUserProfile(savedUser);
        User loadedUser = SaveData.Instance.LoadUserProfile();
        Assert.AreEqual(savedUser,loadedUser);
        yield return null;
    }
}
/*     
 *     
 *     
 *     
 *       
 *       
 *           [UnityTest]
    public IEnumerator MenuScene()
    {
        GameObject go = new GameObject();
        BackToMenu btm = go.AddComponent<BackToMenu>();
        btm.ReturnToMenu();
        yield return null;
        Assert.AreEqual(SceneManager.GetActiveScene().buildIndex, 0);
    }
    [UnityTest]
    public IEnumerator MenuScenes()
    {
        GameObject go = new GameObject();
        Menu menu = go.AddComponent<Menu>();
        menu.SubmitPage();
        yield return null;
        Assert.AreEqual(SceneManager.GetActiveScene().buildIndex, 1);
       menu.UserSamplesPage();
        Assert.AreEqual(SceneManager.GetActiveScene().buildIndex, 3);
        menu.ProfilePage();
        Assert.AreEqual(SceneManager.GetActiveScene().buildIndex, 4);
        menu.LoginPage();
        Assert.AreEqual(SceneManager.GetActiveScene().buildIndex, 5);
        menu.HelpPage();
        Assert.AreEqual(SceneManager.GetActiveScene().buildIndex, 6);
    }
 *       
 *       List<Sample> submittedSamples = new List<Sample>();
        Assert.That(submittedSamples, Is.Empty);
        submittedSamples.Add(new Sample());
        Assert.That(submittedSamples, Is.Not.Empty);
        SaveData.Instance.ClearSubmittedSamplesList();
        submittedSamples =   SaveData.Instance.GetUserSubmittedSamples();
        Assert.That(submittedSamples, Is.Empty);
        SaveData.Instance.AddToSubmittedSamples(new Sample());
        Assert.That(submittedSamples, Is.Empty);
        yield return null;
 *     
 *     
 *     GameObject go = new GameObject();
        go.AddComponent<SaveData>();
        List<Sample> submittedSamples= SaveData.Instance.GetUserSubmittedSamples();
        // yield return null;
        yield return new WaitForSeconds(1);
        *//*        Assert.IsEmpty( submittedSamples);*//*
        Assert.AreEqual(1, submittedSamples.Count);
        yield return new WaitForSeconds(1);
        SaveData.Instance.AddToSubmittedSamples(new Sample());
        Assert.AreEqual(1, submittedSamples.Count);
        List<Sample> storedSamples = SaveData.Instance.GetUserStoredSamples();
        Assert.IsEmpty(storedSamples);
        SaveData.Instance.AddToStoredSamples(new Sample());
        Assert.AreEqual(1, storedSamples.Count);
        SaveData.Instance.ClearStoredSamples();
        Assert.AreEqual(0, storedSamples.Count);
    //    SaveData.Instance.LoadStoredSamples();
        SaveData.Instance.SaveSubmittedSamples();
        SaveData.Instance.AddToSubmittedSamples(new Sample());
        Assert.AreEqual(2, submittedSamples.Count);
        submittedSamples = SaveData.Instance.GetUserSubmittedSamples();
        Assert.AreEqual(1, submittedSamples.Count);*/