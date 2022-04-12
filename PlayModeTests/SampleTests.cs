using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.TestTools;
using Assert = NUnit.Framework.Assert;
//https://forum.unity.com/threads/testing-private-fields-with-unity-test-tools.368444/
public class SampleTests
{
 [Test]
    public async void FireBaseAuthenticationTest()
    {
        GameObject go = new GameObject();
        FirebaseAuthentication firebaseAuthentication = go.AddComponent<FirebaseAuthentication>();
        await firebaseAuthentication.AuthenticationTest("email", "1234", "bronagh");
    }
    [UnityTest]
    public IEnumerator LoginOutButtons()
    {
        GameObject go = new GameObject();
/*        LogInOutButtonManager logInOutButtonManager = go.AddComponent<LogInOutButtonManager>();
        logInOutButtonManager.SetButtons();
        logInOutButtonManager.SetLoggedIn(true);
        Assert.That(logInOutButtonManager.GetLoggedIn(), Is.True);
        logInOutButtonManager.TestButtonInteractable();
        Assert.That(logInOutButtonManager.GetLoginButton().interactable, Is.False);
        Assert.That(logInOutButtonManager.GetSignoutButton().interactable, Is.True);
        logInOutButtonManager.SetLoggedIn(false);
        Assert.That(logInOutButtonManager.GetLoggedIn(), Is.False);
        logInOutButtonManager.TestButtonInteractable();
        Assert.That(logInOutButtonManager.GetLoginButton().interactable, Is.True);
        Assert.That(logInOutButtonManager.GetSignoutButton().interactable, Is.False);*/
        yield return null;
    }
}
