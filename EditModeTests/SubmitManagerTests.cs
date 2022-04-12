using NUnit.Framework;
using UnityEditor.SceneManagement;
using UnityEngine;
using Data.Submit;
public class SubmitManagerTests
{

     private SubmitSampleManager submitSampleManager;
    [SetUp]
    public void ResetScene()
    {
        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
    }
    [SetUp]
    public void SetUp()
    {
        GameObject go = new GameObject();
        submitSampleManager = go.AddComponent<SubmitSampleManager>();
    }
    [Test]
    public void StoreSample_Test()
    {
        //play mode tests
    }
    [Test]
    public void UploadSample_Test()
    {
    }
    [Test]
    public void SubmitSaveSample_Test()
    {
    }

}

