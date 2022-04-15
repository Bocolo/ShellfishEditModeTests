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
        popup.SetPopUp();
      
    }
    [SetUp]
    public void SetUpDeactivatePopUp()
    {
        popup.gameObject.SetActive(false);
    }
    [Test]
    public void SuccessfulLoginPopUp()
    {
        Assert.IsFalse(popup.gameObject.activeInHierarchy);
        popup.SuccessfulLogin();
        Assert.That(popup.gameObject.activeInHierarchy, Is.True);
        Assert.AreEqual(popup.GetPopUpText(), "\n\nLogin Successful");
    }
    public void AcknowledgePopUp()
    {
        popup.gameObject.SetActive(true);
        Assert.IsTrue(popup.gameObject.activeInHierarchy);
        popup.PopUpAcknowleged();
        Assert.That(popup.gameObject.activeInHierarchy, Is.False);
    }
    [Test]
    public void SuccessfulSignUpPopUp()
    {
        Assert.That(popup.gameObject.activeInHierarchy, Is.False);
        popup.SuccessfulSignUp();
        Assert.That(popup.gameObject.activeInHierarchy, Is.True);
        Assert.AreEqual(popup.GetPopUpText(), "\n\nSign Up Successful");
    }
    [Test]
    public void UnsuccessfulSignUpPopUp()
    {
        Assert.That(popup.gameObject.activeInHierarchy, Is.False);
        popup.UnSuccessfulSignUp();
        Assert.That(popup.gameObject.activeInHierarchy, Is.True);
        Assert.AreEqual(popup.GetPopUpText(), "\n\nSign Up NOT Successful");
    }
    [Test]
    public void UnsuccessfulLoginPopUp()
    {
        Assert.That(popup.gameObject.activeInHierarchy, Is.False);
        popup.UnSuccessfulLogin();
        Assert.That(popup.gameObject.activeInHierarchy, Is.True);
        Assert.AreEqual(popup.GetPopUpText(), "\n\nLogin NOT Successful");
    }
}
