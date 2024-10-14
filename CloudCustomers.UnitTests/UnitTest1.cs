namespace CloudCustomers.UnitTests;

public class UnitTest1
{

    /*
        Below is the method that needs to be run. You can tell it by looking at the [Fact] attribute.
     */
    [Fact]
    public void Test1()
    {

    }

    /*
        There is another attribute that shows a method is [Theory] which allows to write parameterized unittests.
        You can use [InlineData] attribute to give parameters as much as you want as in below sample
     */
    [Theory]
    [InlineData("foo", 1)]
    [InlineData("bar", 1)]
    public void Test2(string input, int bar) 
    {
        
    }


}