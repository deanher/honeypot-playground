using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Xunit;

namespace Tests
{
  public class DateTest
  {
    [Theory]
    [InlineData(@"12:00:00AM", @"00:00:00")]
    [InlineData(@"12:00:00PM", @"12:00:00")]
    [InlineData(@"6:00:00PM", @"18:00:00")]
    [InlineData(@"6:00:00AM", @"06:00:00")]
    public void TimeConversion(string input, string expected)
    {
      var result = Convert12HourTo24Hour(input);
      Assert.Equal(expected, result);
    }

    [Theory]
    [ClassData(typeof(LibraryFineTestData))]
    public void LibraryFine((int day, int month, int year) returnDate, (int day, int month, int year)  dueDate, int expected)
    {
      var result = CalculateFine(returnDate.day, returnDate.month, returnDate.year, dueDate.day, dueDate.month, dueDate.year);
      Assert.Equal(expected, result);
    }

    private int CalculateFine(int d1, int m1, int y1, int d2, int m2, int y2)
    {
      if (y1 > y2)
        return 10000;
      if (m1 > m2 && y1 == y2)
        return (m1 - m2) * 500;
      if (d1 > d2 && m1 == m2 && y1 == y2)
        return (d1 - d2) * 15;
      return 0;
    }

    private string Convert12HourTo24Hour(string s)
    {
      var canParse = DateTime.TryParse(s, new DateTimeFormatInfo { LongTimePattern = @"hh:mm:sstt" }, DateTimeStyles.None, out var result);
      if (!canParse)
        return null;
      return result.ToString("HH:mm:ss");
    }
  }

  internal class LibraryFineTestData: IEnumerable<object[]>
  {
    public IEnumerator<object[]> GetEnumerator()
    {
      yield return new object[] {(day: 9, month: 6, year: 2015), (day: 6, month: 6, year: 2015), 45};
      yield return new object[] {(day: 9, month: 7, year: 2015), (day: 6, month: 6, year: 2015), 500};
      yield return new object[] {(day: 9, month: 6, year: 2016), (day: 6, month: 6, year: 2015), 10000};
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
  }
}