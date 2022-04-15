using Data.Access;
using NUnit.Framework;

public class SampleDaoTests
{
    SampleDAO sampleDAO;
    [OneTimeSetUp]
    public void SetUp()
    {
        sampleDAO = new SampleDAO();
    }
  // [Test]
 /*   public async void SamplesBySearchWithLimit()
    {
        //how do i get await async tests to work
  *//*      List<Sample> limitedSamples =await sampleDAO.GetSamplesBySearch("", "", 3);
        Assert.AreEqual(limitedSamples.Count, 3);
        List<Sample> limitedSamples2 = await sampleDAO.GetSamplesBySearch("", "", 2);
        Assert.AreEqual(limitedSamples2.Count, 2);
        List<Sample> limitedSamples4 = await sampleDAO.GetSamplesBySearch("", "", 2);
        Assert.AreEqual(limitedSamples4.Count, 0);*//*
    }*/
}
