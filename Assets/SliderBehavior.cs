using System;
using TMPro;
using UnityEngine;

public class SliderBehavior : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _textMeshPro;

    public void SetText(Single text)
    {
        _textMeshPro.text = $"{text}%";
    }
}
