using NUnit.Framework;
using UnityEditor.SceneManagement;
using UnityEngine;
using UI.Popup;
public class PopUpTests
{
    private PopUp popup;
    [SetUp]
    public void ResetScene()
    {
        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
    }
    [SetUp]
    public void SetUp()
    {
        GameObject go = new GameObject();
         popup = go.AddComponent<PopUp>();
        popup.SetPopUp();
    }
    [Test]
    public void SuccessfulLoginPopUp()
    {
        popup.PopUpAcknowleged();
        Assert.IsFalse(popup.GetPopUp().activeInHierarchy);
        popup.SuccessfulLogin();
        Assert.That(popup.GetPopUp().activeInHierarchy, Is.True);
        Assert.AreEqual(popup.GetPopUpText(), "\n\nLogin Successful");
        popup.PopUpAcknowleged();
        Assert.That(popup.GetPopUp().activeInHierarchy, Is.False);
    }
    [Test]
    public void SuccessfulSignUpPopUp()
    {
        popup.PopUpAcknowleged();
        Assert.That(popup.GetPopUp().activeInHierarchy, Is.False);
        popup.SuccessfulSignUp();
        Assert.That(popup.GetPopUp().activeInHierarchy, Is.True);
        Assert.AreEqual(popup.GetPopUpText(), "\n\nSign Up Successful");
        popup.PopUpAcknowleged();
        Assert.That(popup.GetPopUp().activeInHierarchy, Is.False);
    }
    [Test]
    public void UnsuccessfulSignUpPopUp()
    {
        popup.PopUpAcknowleged();
        Assert.That(popup.GetPopUp().activeInHierarchy, Is.False);
        popup.UnSuccessfulSignUp();
        Assert.That(popup.GetPopUp().activeInHierarchy, Is.True);
        Assert.AreEqual(popup.GetPopUpText(), "\n\nSign Up NOT Successful");
        popup.PopUpAcknowleged();
        Assert.That(popup.GetPopUp().activeInHierarchy, Is.False);
    }
    [Test]
    public void UnsuccessfulLoginPopUp()
    {
        popup.PopUpAcknowleged();
        Assert.That(popup.GetPopUp().activeInHierarchy, Is.False);
        popup.UnSuccessfulLogin();
        Assert.That(popup.GetPopUp().activeInHierarchy, Is.True);
        Assert.AreEqual(popup.GetPopUpText(), "\n\nLogin NOT Successful");
        popup.PopUpAcknowleged();
        Assert.That(popup.GetPopUp().activeInHierarchy, Is.False);
    }
}
