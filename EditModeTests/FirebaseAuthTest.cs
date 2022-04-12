using NUnit.Framework;
using System.Threading.Tasks;
using UnityEditor.SceneManagement;
using UnityEngine;
public class FirebaseAuthTest
{
    FirebaseAuthentication firebaseAuthentication;
   [SetUp]
    public void ResetScene()
    {
        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
    }
    [SetUp]
    public void SetUp()
    {
        GameObject go = new GameObject();
         firebaseAuthentication = go.AddComponent<FirebaseAuthentication>();
    }
    [Test]
    public async Task FireBaseAuthenticationTest()
    {
         await firebaseAuthentication.AuthenticationTest("email", "1234", "bronagh");
    }
}
