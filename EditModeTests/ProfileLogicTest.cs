using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Profile.Logic;
public class ProfileLogicTest
{
    private ProfileLogicSample profileLogic;

    [OneTimeSetUp]
    public void SetUp()
    {
        profileLogic = new ProfileLogicSample();
    }
    [Test]
    public void GetProfileText_Test()
    {
        User user = new User
        {
            Name = "Jimmy",
            Company = "Company Inc.",

        };
        string actualText =profileLogic.GetProfileText(user,5,6);
        string expectedText = "<b>Name : </b>" + "Jimmy"
                    + "\n\n<b>Company: </b>" + "Company Inc."
                    + "\n\n<b>No of Stored Samples on Device: </b>" +
                    5
                    + "\n\n<b>No of Submitted Samples from this Device: </b>" +
                    6;
        Assert.AreEqual(actualText, expectedText);
    }
/*    [Test]
    public void CreateProfile_Test()
    {
        //SaveData saveData
    }*/

   
}
