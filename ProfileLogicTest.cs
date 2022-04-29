using App.Profile;
using NUnit.Framework;
using Users.Data;
/// <summary>
/// tests the profile logic script
/// </summary>
public class ProfileLogicTest
{
    private ProfileLogic _profileLogic;
    /// <summary>
    /// creates the profile logic object
    /// </summary>
    [OneTimeSetUp]
    public void SetUp()
    {
        _profileLogic = new ProfileLogic();
    }
    /// <summary>
    /// tests the correct profile text is returned
    /// </summary>
    [Test]
    public void GetProfileText_Test()
    {
        User user = new User
        {
            Name = "Jimmy",
            Company = "Company Inc.",

        };
        string actualText =_profileLogic.GetProfileText(user,5,6);
        string expectedText = "<b>Name : </b>" + "Jimmy"
                    + "\n\n<b>Company: </b>" + "Company Inc."
                    + "\n\n<b>No of Stored Samples on Device: </b>" +
                    5
                    + "\n\n<b>No of Submitted Samples from this Device: </b>" +
                    6;
        Assert.AreEqual(expectedText, actualText);
    }

}
