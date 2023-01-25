using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class FeelingInputField : MonoBehaviour
{
    public UnityEvent<FeelingUi> OnFeelingChanged;

    private readonly FeelingUi feeling = new();

    private void Start()
    {
        string text = GetComponentInChildren<Text>().text;
        feeling.Emotion = Enum.Parse<Emotion>(text);
    }

    public void SetSelected(bool value)
    {
        feeling.Selected = value;
        OnFeelingChanged.Invoke(feeling);
    }

    public void SetPercentage(Single value)
    {
        feeling.Percentage = (int)value;
        OnFeelingChanged.Invoke(feeling);
    }
}
