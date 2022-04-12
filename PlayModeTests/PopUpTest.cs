using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UI.Popup;
public class PopUpTest
{
    [UnityTest]
    public IEnumerator PopUpTestWithEnumeratorPasses()
    {
        GameObject go = new GameObject();
        PopUp popup =go.AddComponent<PopUp>();
        popup.SetPopUp();
     //   yield return null;
        Debug.Log("Active? " + popup.GetPopUp().activeInHierarchy);
        popup.PopUpAcknowleged();
        Assert.IsFalse(popup.GetPopUp().activeInHierarchy);
        popup.SuccessfulLogin();
        Assert.That(popup.GetPopUp().activeInHierarchy, Is.True);
        Assert.AreEqual(popup.GetPopUpText(), "\n\nLogin Successful");
        popup.PopUpAcknowleged();
        Assert.That(popup.GetPopUp().activeInHierarchy, Is.False);
        popup.SuccessfulSignUp();
        Assert.That(popup.GetPopUp().activeInHierarchy, Is.True);
        Assert.AreEqual(popup.GetPopUpText(), "\n\nSign Up Successful");
        popup.PopUpAcknowleged();
        Assert.That(popup.GetPopUp().activeInHierarchy, Is.False);
        popup.UnSuccessfulLogin();
        Assert.That(popup.GetPopUp().activeInHierarchy, Is.True);
        Assert.AreEqual(popup.GetPopUpText(), "\n\nLogin NOT Successful");
        popup.PopUpAcknowleged();
        Assert.That(popup.GetPopUp().activeInHierarchy, Is.False);
        popup.UnSuccessfulSignUp();
        Assert.That(popup.GetPopUp().activeInHierarchy, Is.True);
        Assert.AreEqual(popup.GetPopUpText(), "\n\nSign Up NOT Successful");
        yield return null;
    }
}
