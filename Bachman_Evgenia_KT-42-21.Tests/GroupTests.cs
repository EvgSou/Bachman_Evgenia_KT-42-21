using BachmanEvgeniaKT_42_21.Models;

namespace Bachman_Evgenia_KT_42_21.Tests
{
    public class GroupTests
    {
        [Fact]
        public void IsValidGroupName_KT4221_True()
        {
            //arrange
            var testGroup = new Group
            {
                GroupName = "สา-42-21"
            };

            //act
            var result = testGroup.IsValidGroupName();

            //assert
            Assert.True(result);
        }
    }
}