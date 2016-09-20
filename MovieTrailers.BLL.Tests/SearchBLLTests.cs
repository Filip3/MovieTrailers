using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieTrailers.Contracts;
using MovieTrailers.BLL;

namespace MovieTrailers.BLL.Tests
{
    [TestClass]
    public class SearchBLLTests
    {
        private ISearchBLL _searchBLL;

        [TestInitialize]
        public void Setup()
        {
            _searchBLL = new SearchBLL();
        }

        [TestCleanup]
        public void CleanUp()
        {
            _searchBLL = null;
        }
        
        // Example test
        [TestMethod]
        public void RetrieveTitleDescriptionForSearch_RetrievesEverythingToTheComma_ReturnsTest()
        {
            // Arrange
            string titleDescription = "Test, part that needs to be removed";
            
            // Act
            var result = _searchBLL.RetrieveTitleDescriptionForSearch(titleDescription);

            // Assert
            Assert.AreEqual("Test", result);
        }
    }
}
