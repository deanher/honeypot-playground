using System.Collections;
using System.Collections.Generic;

namespace Tests
{
  internal class DiagonalAbsoluteDifferenceTestData : IEnumerable<object[]>
  {
    public IEnumerator<object[]> GetEnumerator()
    {
      yield return new object[] {new [] {new[] {1, 2, 3}, new[] {4, 5, 6}, new[] {9, 8, 9}}, 2};
      yield return new object[] {new [] {new[] {11, 2, 4}, new[] {4, 5, 6}, new[] {10, 8, -12}}, 15};
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
  }
}