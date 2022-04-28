using NUnit.Framework;
using Search.Logic;
public class SearchLogicTests
{
    private SearchLogic searchLogic;
    [OneTimeSetUp]
    public void SetUp()
    {
        searchLogic = new SearchLogic();
    }

    [Test]
    public void GetSearchLimit_Test_1()
    {
        Assert.AreEqual(1, searchLogic.GetSearchLimit("1"));
    }
    [Test]
    public void GetSearchLimit_Test_100()
    {
        Assert.AreEqual(100, searchLogic.GetSearchLimit("100"));
    }
    [Test]
    public void GetSearchLimit_Test_100_FromInvalidInput()
    {
        Assert.AreEqual(100, searchLogic.GetSearchLimit("dog"));
    }
    [Test]
    public void SetSearchFieldEmpty()
    {
        Assert.AreEqual("",searchLogic.GetSearchField(0));
    }
    [Test]
    public void SetSearchFieldToName()
    {
        Assert.AreEqual("Name", searchLogic.GetSearchField(1));
    }
    [Test]
    public void SetSearchFieldToCompany()
    {
        Assert.AreEqual("Company", searchLogic.GetSearchField(2));

       
    }
    [Test]
    public void SetSearchFieldToSpecies()
    {
        Assert.AreEqual("Species", searchLogic.GetSearchField(3));

    }
    public void SetSearchFieldToProductionWeek()
    {
        Assert.AreEqual("ProductionWeekNo", searchLogic.GetSearchField(4));

    }
    [Test]
    public void SetSearchFieldToDate()
    {
        Assert.AreEqual("Date", searchLogic.GetSearchField(5));

    }
    [Test]
    public void SetSearchFieldToDefault()
    {
        Assert.AreEqual("", searchLogic.GetSearchField(50));

    }
}
