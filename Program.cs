using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

#region Q1 Generic Range<T> class
public class Range<T> where T : IComparable<T>
{
    private T min;
    private T max;

    public Range(T min, T max)
    {
        if (min.CompareTo(max) > 0)
            throw new ArgumentException("Minimum value cannot be greater than maximum value.");

        this.min = min;
        this.max = max;
    }

    public bool IsInRange(T value)
    {
        return value.CompareTo(min) >= 0 && value.CompareTo(max) <= 0;
    }

    public dynamic Length()
    {
        return (dynamic)max - (dynamic)min;
    }
}

#endregion

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////

#region  Q2 Reverse an ArrayList without using built-in Reverse
public static class ArrayListExtensions
{
    public static void ReverseArrayList(ArrayList list)
    {
        int left = 0, right = list.Count - 1;
        while (left < right)
        {
            object temp = list[left];
            list[left] = list[right];
            list[right] = temp;
            left++;
            right--;
        }
    }
}
#endregion

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////

#region Q3 Filtering even numbers from a list
public static class ListExtensions
{
    public static List<int> GetEvenNumbers(List<int> numbers)
    {
        return numbers.Where(n => n % 2 == 0).ToList();
    }
}
#endregion

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////

#region Q4 FixedSizeList<T> implementation
public class FixedSizeList<T>
{
    private T[] items;
    private int count;

    public FixedSizeList(int capacity)
    {
        while (true)
        {
            if (capacity <= 0)
                throw new ArgumentException("Capacity must be greater than zero , try again :");
            else
            {
                items = new T[capacity];
                count = 0;
            }
        }

    }
    public void Add(T item)
    {
        while (true)
        {
            if (count >= items.Length)
                throw new InvalidOperationException("List is full.");
            else
            {
                items[count++] = item;
            }
        }
    }
    public T Get(int index)
    {
        while (true)
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException("Invalid index.");
            else
            {
                return items[index];
            }
        }
    }
}
#endregion

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////

#region Q5 Find first non-repeated character in a string
public static class StringExtensions
{
    public static int FirstNonRepeatedCharacterIndex(string input)
    {
        if (string.IsNullOrEmpty(input))
            return -1;

        Dictionary<char, int> charCount = new Dictionary<char, int>();

        foreach (char c in input)
        {
            if (charCount.ContainsKey(c))
                charCount[c]++;
            else
                charCount[c] = 1;
        }

        for (int i = 0; i < input.Length; i++)
        {
            if (charCount[input[i]] == 1)
                return i;
        }

        return -1; // No non-repeated character found
    }
}

#endregion

