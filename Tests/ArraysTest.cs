using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests
{
  public class ArraysTest
  {
    [Theory]
    [ClassData(typeof(SorterTestData))]
    public void OrderByBinaryTest(int[] elements, int[] expected)
    {
      var actual = OrderByBinary(elements.Distinct().ToArray());
      Assert.Equal(expected, actual);

      actual = MergeSort(elements.Distinct().ToArray());
      Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(10, 7, -1)]
    public void BinaryComparisonTest(int a, int b, int expected)
    {
      var actual = BinaryComparison(a, b);

      Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(DiagonalAbsoluteDifferenceTestData))]
    public void DiagonalAbsoluteDifferenceTest(int[][] arr, int expected)
    {
      var difference = DiagonalAbsoluteDifference(arr);

      Assert.Equal(expected, difference);
    }

    [Fact]
    public void HourGlass()
    {
      //given
      var arr = new[,]
      {
        {1, 1, 1, 0, 0, 0},
        {0, 1, 0, 0, 0, 0},
        {1, 1, 1, 0, 0, 0},
        {0, 0, 2, 4, 4, 0},
        {0, 0, 0, 2, 0, 0},
        {0, 0, 1, 2, 4, 0}
      };

      //when
      var sumHourGlass = SumHourGlass(arr);

      //then
      Assert.Equal(19, sumHourGlass);
    }

    private int DiagonalAbsoluteDifference(int[][] arr)
    {
      var pDiag = 0;
      var sDiag = 0;
      for (var i = 0; i < arr.GetLength(0); i++)
      {
        for (var j = 0; j < arr[i].GetLength(0); j++)
        {
          if (i == j)
            pDiag += arr[i][j];
          //            Console.Write(string.Join(" ", $"{arr[i][j]}"));
          if (arr.GetUpperBound(0) - i == j)
            sDiag += arr[i][j];
          //            Console.Write(string.Join(" ", $"{arr[i][j]}"));
        }

        //        Console.WriteLine();
      }

      return Math.Abs(pDiag - sDiag);
    }

    private IEnumerable<int> OrderByBinary(int[] elements)
    {
      return elements.OrderBy(n => n, Comparer<int>.Create(BinaryComparison)).Distinct();
    }

    private int BinaryComparison(int a, int b)
    {
      var binaryA = Convert.ToString(a, 2);
      var binaryB = Convert.ToString(b, 2);

      var binaryACount = binaryA.Count(c => c.Equals('1'));
      var binaryBCount = binaryB.Count(c => c.Equals('1'));

      var intComparison = a.CompareTo(b);
      var binaryComparison = binaryACount.CompareTo(binaryBCount);
      return binaryACount == binaryBCount ? intComparison : binaryComparison;
    }

    private IEnumerable<int> MergeSort(int[] elements)
    {
      if (elements.Length <= 1)
        return elements;

      var mid = elements.Length / 2;
      var left = MergeSort(elements.Take(mid).ToArray()).ToArray();
      var right = MergeSort(elements.Skip(mid).ToArray()).ToArray();

      return Merge(left, right);
    }

    private IEnumerable<int> Merge(int[] left, int[] right)
    {
      var result = new List<int>();
      var lCount = 0;
      var rCount = 0;

      while (lCount < left.Length && rCount < right.Length)
      {
        var a = left[lCount];
        var b = right[rCount];

        var binaryA = Convert.ToString(a, 2);
        var binaryB = Convert.ToString(b, 2);

        var binaryACount = binaryA.Count(c => c.Equals('1'));
        var binaryBCount = binaryB.Count(c => c.Equals('1'));
        if (binaryACount == binaryBCount)
        {
          if (a <= b)
          {
            result.Add(a);
            lCount++;
          }
          else
          {
            result.Add(b);
            rCount++;
          }
        }
        else
        {
          if (binaryACount <= binaryBCount)
          {
            result.Add(a);
            lCount++;
          }
          else
          {
            result.Add(b);
            rCount++;
          }
        }
      }

      result.AddRange(rCount > lCount ? left.Skip(lCount) : right.Skip(rCount));

      return result;
    }

    [Fact]
    public void ReverseComplementDna()
    {
      var reverseComplement = GetReverseComplement(@"GTCAG");

      Assert.Equal(@"CTGAC", reverseComplement);
    }

    private string GetReverseComplement(string s)
    {
      var complements = new Dictionary<char, char> { { 'A', 'T' }, { 'T', 'A' }, { 'C', 'G' }, { 'G', 'C' } };
      var reverseComplement = ReverseString(s);

      var result = reverseComplement.Select(key => complements.ContainsKey(key) ? complements[key] : key);

      return string.Concat(result.ToArray());
    }

    private string ReverseString(string dnaStrand)
    {
      var stack = new Stack<char>();
      for (var i = 0; i < dnaStrand.Length; i++)
      {
        stack.Push(dnaStrand[i]);
      }

      return string.Concat(stack.ToArray());
    }

    private int SumHourGlass(int[,] arr)
    {
      var length = arr.GetLength(0);
      for (var i = 0; i < length - length / arr.Rank; i++)
      {
        for (var j = 0; j < length - length / arr.Rank; j++)
        {

        }
      }

      return 0;
    }
  }
}
