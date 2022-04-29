using App.Authentication.UI;
using NUnit.Framework;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Tests the LogInOutButtonManager in Edit Mode
/// </summary>
public class LoginLogicTests
{
    private LoginLogic loginLogic;
    private Button loginButton;
    private Button logoutButton;

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
        loginLogic = new LoginLogic();
        GameObject go = new GameObject(); 
        GameObject go2 = new GameObject();
        loginButton = go.AddComponent<Button>();
        logoutButton = go2.AddComponent<Button>();
    }
    /// <summary>
    /// assess if buttons are correctly actived/deactivated based on bool
    /// </summary>
    [Test]
    public void TestButtonInteractable_SignedIn()
    {
        loginLogic.SetButtonInteractable(true, loginButton, logoutButton);
        Assert.That(loginButton.interactable, Is.False);
        Assert.That(logoutButton.interactable, Is.True);
    }
    /// <summary>
    /// assess if buttons are correctly actived/deactivated based on bool
    /// </summary>
    [Test]
    public void TestButtonInteractable_SignedOut()
    {

        loginLogic.SetButtonInteractable(false, loginButton, logoutButton);
        Assert.That(loginButton.interactable, Is.True);
        Assert.That(logoutButton.interactable, Is.False);
    }
   
}
