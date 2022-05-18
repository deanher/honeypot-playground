using System.Linq;
using Xunit;

namespace Tests
{
  public class StringsTest
  {
    [Theory]
    [InlineData(@"baca", @"bcaa")]
    [InlineData(@"xy", @"yx")]
    [InlineData(@"hefg", @"hegf")]
    public void RearrangeWord(string word, string expected)
    {
      var result = Rearrange(word);
      Assert.Equal(expected, result);
    }

    private string Rearrange(string word)
    {
      var temp = word.ToList();
      for (var i = word.Length - 1; i > 0; i--)
      {
        var prev = temp[i - 1];
        var curr = temp[i];

        if (prev >= curr) continue;
        temp[i] = prev;
        temp[i - 1] = curr;
        break;
      }

      return string.Concat(temp);
    }
  }
}
