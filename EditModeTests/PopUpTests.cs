using NUnit.Framework;
using UnityEditor.SceneManagement;
using UnityEngine;
using UI.Popup;
public class PopUpTests
{
    private PopUp popup;
    [OneTimeSetUp]
    public void ResetScene()
    {
        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
    }
    [OneTimeSetUp]
    public void SetUp()
    {
        GameObject go = new GameObject();
         popup = go.AddComponent<PopUp>();
    }
    [SetUp]
    public void SetUpDeactivatePopUp()
    {
        popup.gameObject.SetActive(false);
    }
    [Test]
    public void AcknowledgePopUp()
    {
        popup.gameObject.SetActive(true);
        Assert.IsTrue(popup.gameObject.activeInHierarchy);
        popup.PopUpAcknowleged();
        Assert.That(popup.gameObject.activeInHierarchy, Is.False);
    }
}
