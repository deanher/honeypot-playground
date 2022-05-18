using System.Collections;
using System.Collections.Generic;

namespace Tests
{
  public class SorterTestData : IEnumerable<object[]>
  {
    public IEnumerator<object[]> GetEnumerator()
    {
      yield return new object[] {new[] {3, 1, 2, 3}, new[] {1, 2, 3}};
      yield return new object[] {new[] {7, 8, 6, 5}, new[] {8, 5, 6, 7}};
      yield return new object[] {new[] {5, 5, 3, 7, 10, 14}, new[] {3, 5, 10, 7, 14}};
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
  }
}