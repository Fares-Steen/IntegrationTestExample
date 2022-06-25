using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Edabit.Tests;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void SockPairs()
    {
        var socks = "CABBACC";

        int result = EdabitChallenges.SockPairs2(socks);
        Assert.AreEqual(3,result);
    }

    [TestMethod]
    public void TestLambda()
    {
        EdabitChallenges.TestLambda();
    }

    [TestMethod]
    public void IsDisarium()
    {
        EdabitChallenges.IsDisarium(135);
    }

    // [TestMethod]
    // [DataRow("babad","bab")]
    // [DataRow("cbbd","bb")]
    // [DataRow("faaaaaf","faaaaaf")]
    // [DataRow("gfaaaaafg","gfaaaaafg")]
    // [DataRow("asdfaafasd","faaf")]
    // [DataRow("s","s")]
    // [DataRow("aacabdkacaa","aca")]
    // public void LongestPalindrome(string word, string expectedResult)
    // {
    //     var result = EdabitChallenges.LongestPalindrome(word);
    //     
    //     Assert.AreEqual(expectedResult,result);
    // }

    [TestMethod]
    public void CombinationSum()
    {
        var input2 = new int[] {2,7,6,3,5,1};
        var target2 = 9;
        List<int[]> expectedResult2 = new List<int[]> {new []{2,2,2,2}, new[]{2,3,3},new[]{3,5}};
        
        var result2 = EdabitChallenges.CombinationSum2(input2, target2);
    }
}