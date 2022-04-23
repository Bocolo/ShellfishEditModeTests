using NUnit.Framework;
using UI.Authentication;
using UnityEditor.SceneManagement;
using UnityEngine;
/// <summary>
/// Tests the LogInOutButtonManager in Edit Mode
/// </summary>
public class LoginUI
{
    private LoginUIManager logInOutButtonManager;

    /// <summary>
    /// sets an empty scene
    /// </summary>
    [OneTimeSetUp]
    public void ResetScene()
    {
        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
    }
    /// <summary>
    /// Sets the relevant objects adding the monobehaviour components
    /// Uses "#if UNITY_INCLUDE_TESTS" methods to access private details: SetTestButtons
    /// </summary>
    [OneTimeSetUp]
    public void SetUpButtons()
    {
        GameObject go = new GameObject();
        logInOutButtonManager = go.AddComponent<LoginUIManager>();
        logInOutButtonManager.SetTestButtons();
    }
    /// <summary>
    /// Uses "#if UNITY_INCLUDE_TESTS" methods to access private details varaibles
    /// 
    /// assess if buttons are correctly actived/deactivated based on bool
    /// </summary>

    [Test]
    public void TestButtonInteractable_SignedIn()
    {

        logInOutButtonManager.TestButtonInteractable(true);
        Assert.That(logInOutButtonManager.GetLoginButton().interactable, Is.False);
        Assert.That(logInOutButtonManager.GetSignoutButton().interactable, Is.True);
    }
    /// <summary>
    /// Uses "#if UNITY_INCLUDE_TESTS" methods to access private details varaibles
    /// 
    /// assess if buttons are correctly actived/deactivated based on bool
    /// </summary>
    [Test]
    public void TestButtonInteractable_SignedOut()
    {

        logInOutButtonManager.TestButtonInteractable(false);

        Assert.That(logInOutButtonManager.GetLoginButton().interactable, Is.True);
        Assert.That(logInOutButtonManager.GetSignoutButton().interactable, Is.False);
    }
}
