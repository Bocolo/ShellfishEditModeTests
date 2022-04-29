using App.Samples;
using NUnit.Framework;
/// <summary>
/// test the search logic script
/// </summary>
public class SearchLogicTests
{
    private SearchLogic _searchLogic;
    [OneTimeSetUp]
    public void SetUp()
    {
        _searchLogic = new SearchLogic();
    }
    #region "GetSearchLimit Tests"
    /// <summary>
    /// The following tests test the return value of the
    /// GetSearchLimit function is as expected
    /// this method parses a string to an int and returns the int
    /// if the string cant be parsed 100 is returned
    /// i
    /// </summary>
    [Test]
    public void GetSearchLimit_Test_1()
    {
        Assert.AreEqual(1, _searchLogic.GetSearchLimit("1"));
    }
    [Test]
    public void GetSearchLimit_Test_100()
    {
        Assert.AreEqual(100, _searchLogic.GetSearchLimit("100"));
    }
    [Test]
    public void GetSearchLimit_Test_100_FromInvalidInput()
    {
        Assert.AreEqual(100, _searchLogic.GetSearchLimit("dog"));
    }
    #endregion
    #region "GetSearchField Tests"
    /// <summary>
    /// The following tests test the return value of the
    /// GetSearchField function is as expected
    /// </summary>
    [Test]
    public void SetSearchFieldEmpty()
    {
        Assert.AreEqual("",_searchLogic.GetSearchField(0));
    }
    [Test]
    public void SetSearchFieldToName()
    {
        Assert.AreEqual("Name", _searchLogic.GetSearchField(1));
    }
    [Test]
    public void SetSearchFieldToCompany()
    {
        Assert.AreEqual("Company", _searchLogic.GetSearchField(2));

       
    }
    [Test]
    public void SetSearchFieldToSpecies()
    {
        Assert.AreEqual("Species", _searchLogic.GetSearchField(3));

    }
    public void SetSearchFieldToProductionWeek()
    {
        Assert.AreEqual("ProductionWeekNo", _searchLogic.GetSearchField(4));

    }
    [Test]
    public void SetSearchFieldToDate()
    {
        Assert.AreEqual("Date", _searchLogic.GetSearchField(5));

    }
    [Test]
    public void SetSearchFieldToDefault()
    {
        Assert.AreEqual("", _searchLogic.GetSearchField(50));

    }
    #endregion

}
