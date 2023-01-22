using System;
using UnityEngine;

public abstract class ValidationRule<T> : MonoBehaviour
{
    public abstract bool Validate(Func<T> value);
}
