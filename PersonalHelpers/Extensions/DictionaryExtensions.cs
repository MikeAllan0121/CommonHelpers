using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PersonalHelpers.Enums;

public static class DictionaryExtensions
{
    public static void ForEach<TKey, TValue>(this IDictionary<TKey, TValue>? dict, Action<TKey, TValue> action)
    {
        if (dict is null)
            return;
        var count = dict.Count;
        var keys = dict.Keys
            .ToList();
        var values = dict.Values
            .ToList();

        for (var i = 0; i < count; i++)
        {
            action.Invoke(keys[i], values[i]);
        }
    }

    public static void ForEach<TKey, TValue>(this IDictionary<TKey, TValue>? dict, Action<(TKey key, TValue value)> action)
    {
        if (dict is null)
            return;
        var count = dict.Count;
        var keys = dict.Keys
            .ToList();
        var values = dict.Values
            .ToList();

        for (var i = 0; i < count; i++)
        {
            action.Invoke((keys[i], values[i]));
        }
    }

    public static void ForEach<TKey, TValue>(this IDictionary<TKey, TValue>? dict, Action<TKey>? keyAction = null, Action<TValue>? valueAction = null)
    {
        if (dict is null)
            return;
        var count = dict.Count;
        var keys = dict.Keys
            .ToList();
        var values = dict.Values
            .ToList();

        for (var i = 0; i < count; i++)
        {
            keyAction?.Invoke(keys[i]);
            valueAction?.Invoke(values[i]);
        }
    }
}
