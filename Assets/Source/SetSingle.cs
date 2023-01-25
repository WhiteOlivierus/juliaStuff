using System;
using UnityEngine;
using UnityEngine.Events;

public class SetSingle : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<Single> TextUpdateEvent;

    public void OnTextChanged(Single value)
    {
        TextUpdateEvent.Invoke(value);
    }
}
