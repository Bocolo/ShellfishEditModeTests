using App.UI;
using NUnit.Framework;
using UnityEditor.SceneManagement;
using UnityEngine;
/// <summary>
/// Test the pop up script
/// </summary>
public class PopUpTests
{
    private PopUp _popup;
    /// <summary>
    /// sets an empty scene
    /// </summary>
    [OneTimeSetUp]
    public void ResetScene()
    {
        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
    }
    /// <summary>
    /// sets the required gameobjects
    /// </summary>
    [OneTimeSetUp]
    public void SetUp()
    {
        GameObject go = new GameObject();
         _popup = go.AddComponent<PopUp>();
    }
    /// <summary>
    /// set the pop up to deactivated
    /// </summary>
    [SetUp]
    public void SetUpDeactivatePopUp()
    {
        _popup.gameObject.SetActive(false);
    }
    /// <summary>
    /// tests PopUpAcknowleged deactivates the popup
    /// </summary>
    [Test]
    public void AcknowledgePopUp()
    {
        _popup.gameObject.SetActive(true);
        Assert.IsTrue(_popup.gameObject.activeInHierarchy);
        _popup.PopUpAcknowleged();
        Assert.That(_popup.gameObject.activeInHierarchy, Is.False);
    }
}
