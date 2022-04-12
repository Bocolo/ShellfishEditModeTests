using NUnit.Framework;
using UnityEditor.SceneManagement;
using UnityEngine;
using UI.Authentication;
public class LoginUI
{
   private LogInOutButtonManager logInOutButtonManager;
   [SetUp]
    public void ResetScene()
    {
        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
    }
    [SetUp]
    public void SetUpButtons()
    {
        GameObject go = new GameObject();
        logInOutButtonManager = go.AddComponent<LogInOutButtonManager>();
        logInOutButtonManager.SetTestButtons();
    }
/*    [Test]
    public void SetLoggedinTrueTest()
    {
        logInOutButtonManager.SetLoggedIn(true);
        Assert.That(logInOutButtonManager.GetLoggedIn(), Is.True);
      
    }
    [Test]
    public void SetLoggedinFalseTest()
    {
        logInOutButtonManager.SetLoggedIn(false);
        Assert.That(logInOutButtonManager.GetLoggedIn(), Is.False);
      
    }*/
    [Test]
    public void TestButtonInteractable_SignedIn()
    {
      
        logInOutButtonManager.TestButtonInteractable(true);
        Assert.That(logInOutButtonManager.GetLoginButton().interactable, Is.False);
        Assert.That(logInOutButtonManager.GetSignoutButton().interactable, Is.True);
    }
    [Test]
    public void TestButtonInteractable_SignedOut()
    {

        logInOutButtonManager.TestButtonInteractable(false);
     
        Assert.That(logInOutButtonManager.GetLoginButton().interactable, Is.True);
        Assert.That(logInOutButtonManager.GetSignoutButton().interactable, Is.False);
    }
}
