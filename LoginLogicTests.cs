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
    private LoginLogic _loginLogic;
    private Button _loginButton;
    private Button _logoutButton;

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
        _loginLogic = new LoginLogic();
        GameObject go = new GameObject(); 
        GameObject go2 = new GameObject();
        _loginButton = go.AddComponent<Button>();
        _logoutButton = go2.AddComponent<Button>();
    }
    /// <summary>
    /// assess if buttons are correctly actived/deactivated based on bool
    /// </summary>
    [Test]
    public void TestButtonInteractable_SignedIn()
    {
        _loginLogic.SetButtonInteractable(true, _loginButton, _logoutButton);
        Assert.That(_loginButton.interactable, Is.False);
        Assert.That(_logoutButton.interactable, Is.True);
    }
    /// <summary>
    /// assess if buttons are correctly actived/deactivated based on bool
    /// </summary>
    [Test]
    public void TestButtonInteractable_SignedOut()
    {

        _loginLogic.SetButtonInteractable(false, _loginButton, _logoutButton);
        Assert.That(_loginButton.interactable, Is.True);
        Assert.That(_logoutButton.interactable, Is.False);
    }
   
}
