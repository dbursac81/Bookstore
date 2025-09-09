using Bookstore.Data.Context;
using Xunit;

namespace Bookstore.Tests
{
    public class TitleNormalizationTests
    {
        [Fact]
        public void NormalizeTitle_TrimsAndLowercases()
        {
            //Arrange
            var input = " true and Present Danger  ";

            //Act
            var output = BookstoreContext.NormalizeTitle(input);

            //Assert
            Assert.Equal("true and present danger", output);
        }

        [Fact]
        public void NormalizeTitle_HandlesEmptyString()
        {
            // Arrange
            var input = "   ";

            // Act
            var result = BookstoreContext.NormalizeTitle(input);

            // Assert
            Assert.Equal(string.Empty, result);
        }

        [Fact]
        public void NormalizeTitle_AlreadyNormalized_ReturnsSame()
        {
            // Arrange
            var input = "clean code";

            // Act
            var result = BookstoreContext.NormalizeTitle(input);

            // Assert
            Assert.Equal("clean code", result);
        }
    }
}
