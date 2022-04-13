using NUnit.Framework;
using UnityEditor.SceneManagement;
using UnityEngine;
using UI.Submit;
public class SampleValidatorTests
{
    SampleValidator sampleValidator;
    [SetUp]
    public void ResetScene()
    {
        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
    }
    [SetUp]
    public void SetUp()
    {
        GameObject go = new GameObject();
        sampleValidator = go.AddComponent<SampleValidator>();
    }
    [Test]
    public void TestIsDateValid()
    {
        Assert.IsTrue(sampleValidator.IsDateValid("3-2-2022"));
        Assert.IsFalse(sampleValidator.IsDateValid("3-2-2024"));
        Assert.IsFalse(sampleValidator.IsDateValid("not a date"));
    }
 

}
