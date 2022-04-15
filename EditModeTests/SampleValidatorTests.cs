using NUnit.Framework;
using UnityEditor.SceneManagement;
using UnityEngine;
using UI.Submit;
public class SampleValidatorTests
{
    SampleValidator sampleValidator;
    [OneTimeSetUp]
    public void ResetScene()
    {
        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
    }
    [OneTimeSetUp]
    public void SetUp()
    {
        GameObject go = new GameObject();
        sampleValidator = go.AddComponent<SampleValidator>();
    }
    [Test]
    public void TestIsDateValid_Pass_PassedData()
    {
        Assert.IsTrue(sampleValidator.IsDateValid("3-2-2022"));
    }
    [Test]
    public void TestIsDateValid_Fail_FutureDate()
    {
        Assert.IsFalse(sampleValidator.IsDateValid("3-2-2024"));
    }
    [Test]
    public void TestIsDateValid_Fail_NotADate()
    {
        Assert.IsFalse(sampleValidator.IsDateValid("not a date"));
    }
}
