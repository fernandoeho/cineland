using Cineland.SharedKernel;

namespace Cineland.UnitTests.SharedKernel;

public class ResultTests
{
    [Fact]
    public void IsSuccess_ErrorNotNone_ThrowException()
    {
        var action = () => new Result(true, Error.Failure(string.Empty, string.Empty), null);

        var exception = Assert.Throws<ArgumentException>(action);
        Assert.Equal(typeof(ArgumentException), exception.GetType());
    }

    [Fact]
    public void IsNotSuccess_ErrorNone_ThrowException()
    {
        var action = () => new Result(false, Error.None(), null);

        var exception = Assert.Throws<ArgumentException>(action);
        Assert.Equal(typeof(ArgumentException), exception.GetType());
    }

}