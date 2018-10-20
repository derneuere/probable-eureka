using System.Collections.Generic;
using Random = UnityEngine.Random;

public static class ListExtensions
{
    
    /// <summary>Returns a random element from the list</summary>
    public static T Pick<T>(this IList<T> list)
    {
        if (list.Count < 1) return default(T);

        return list[Random.Range(0, list.Count)];
    }

    /// <summary>Returns the first element from the list</summary>
    public static T First<T>(this IList<T> list)
    {
        if (list.Count < 1) return default(T);

        return list[0];
    }

    /// <summary>Returns the last element from the list</summary>
    public static T Last<T>(this IList<T> list)
    {
        if (list.Count < 1) return default(T);

        return list[list.Count-1];
    }

    /// <summary>Returns and removes a random element from the list</summary>
    public static T Pluck<T>(this IList<T> list)
    {
        var i = Random.Range(0, list.Count);
        var element = list[i];
        list.RemoveAt(i);
        return element;
    }

    /// <summary>Creates a fully random permutation.</summary>
    public static void Shuffle<T>(this IList<T> list)
    {
        //Fisher-Yates Algorithm
        var n = list.Count;
        for (var i = 0; i < n - 1; i++)
        {
            var j = Random.Range(i, n);
            var temp = list[i];
            list[i] = list[j];
            list[j] = temp;            
        }        
    }

    /// <summary>Creates a derangement, i.e. a permutation with each element in a new position</summary>
    public static void Derange<T>(this IList<T> list)
    {
        //Sattolo's Algorithm
        var n = list.Count;
        for (var i = 0; i < n - 1; i++)
        {
            var j = Random.Range(i+1, n);
            var temp = list[i];
            list[i] = list[j];
            list[j] = temp;            
        }        
    }
    
    /// <summary>Reverses the list in-situ</summary>
    public static void Reverse<T>(this IList<T> list)
    {
        var n = list.Count ;
        for (var i = 0; i < n / 2; i++)
        {
            var j = n-1-i;
            var temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }        
    }
    
    /// <summary>Returns a random element from the array</summary>
    public static T Pick<T>(this T[] array)
    {
        if (array.Length < 1) return default(T);
        
        return array[Random.Range(0, array.Length)];
    }

    /// <summary>Returns the first element from the array</summary>
    public static T First<T>(this T[] array)
    {
        if (array.Length < 1) return default(T);
        
        return array[0];
    }

    /// <summary>Returns the last element from the array</summary>
    public static T Last<T>(this T[] array)
    {
        if (array.Length < 1) return default(T);
        
        return array[array.Length-1];
    }

    /// <summary>Creates a fully random permutation.</summary>
    public static void Shuffle<T>(this T[] array)
    {
        //Fisher-Yates Algorithm
        var n = array.Length;
        for (var i = 0; i < n - 1; i++)
        {
            var j = Random.Range(i, n);
            var temp = array[i];
            array[i] = array[j];
            array[j] = temp;            
        }
    }

    /// <summary>Creates a derangement, i.e. a permutation with each element in a new position</summary>
    public static void Derange<T>(this T[] array)
    {
        //Sattolo's Algorithm
        var n = array.Length;
        for (var i = 0; i < n - 1; i++)
        {
            var j = Random.Range(i + 1, n);
            var temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }    
    }

    /// <summary>Reverses the array in-situ</summary>
    public static void Reverse<T>(this T[] array)
    {
        var n = array.Length;
        for (var i = 0; i < n / 2; i++)
        {
            var j = n-1 - i;
            var temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}


/*
Written by Moritz Voss in 2018

This is free and unencumbered software released into the public domain.

Anyone is free to copy, modify, publish, use, compile, sell, or
distribute this software, either in source code form or as a compiled
binary, for any purpose, commercial or non-commercial, and by any
means.

In jurisdictions that recognize copyright laws, the author or authors
of this software dedicate any and all copyright interest in the
software to the public domain. We make this dedication for the benefit
of the public at large and to the detriment of our heirs and
successors. We intend this dedication to be an overt act of
relinquishment in perpetuity of all present and future rights to this
software under copyright law.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
IN NO EVENT SHALL THE AUTHORS BE LIABLE FOR ANY CLAIM, DAMAGES OR
OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
OTHER DEALINGS IN THE SOFTWARE.

For more information, please refer to <http://unlicense.org>
*/