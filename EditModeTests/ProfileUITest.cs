using NUnit.Framework;
using UnityEditor.SceneManagement;
using UnityEngine;
using UI.Profile;
public class ProfileUITest
{
   private ProfileUI profileUI;
   [SetUp]
    public void ResetScene()
    {
        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
    }
    [SetUp]
    public void SetUp()
    {
        GameObject go = new GameObject();
         profileUI = go.AddComponent<ProfileUI>();
        profileUI.SetInputTextFields();//change to objects not fields?
    }
    [Test]
    public void ViewUpdateProfile()
    {
        profileUI.GoToUpdateProfile();
        Assert.That(profileUI.GetProfileTextGO().activeInHierarchy, Is.False);
        Assert.That(profileUI.GetUpdateProfileButtonGO().activeInHierarchy, Is.False);
        Assert.That(profileUI.GetUserCompanyInputGO().activeInHierarchy, Is.True);
        Assert.That(profileUI.GetUserNameInputGO().activeInHierarchy, Is.True);
        Assert.That(profileUI.GetSaveProfileButtonGO().activeInHierarchy, Is.True);
    }
    [Test]
    public void ViewCurrentProfile()
    {
        profileUI.GoToViewProfile();
        Assert.That(profileUI.GetProfileTextGO().activeInHierarchy, Is.True);
        Assert.That(profileUI.GetUpdateProfileButtonGO().activeInHierarchy, Is.True);
        Assert.That(profileUI.GetUserCompanyInputGO().activeInHierarchy, Is.False);
        Assert.That(profileUI.GetUserNameInputGO().activeInHierarchy, Is.False);
        Assert.That(profileUI.GetSaveProfileButtonGO().activeInHierarchy, Is.False);
    }
    ////
    ///In unity tests test save profle strt
 /*   [Test]
    public void LoadTest()
    {
        profileUI.LoadUser();
    }*/
}
