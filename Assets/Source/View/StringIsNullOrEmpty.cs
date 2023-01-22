using System;
using UnityEngine;

public class StringIsNullOrEmpty<T> : ValidationRule<T>
{
    public override bool Validate(Func<T> value)
    {
        string t = value.Invoke() as string;
        return string.IsNullOrEmpty(t);
    }
}
