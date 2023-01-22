using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class SetTextValue : MonoBehaviour
{
    private TextMeshPro textMeshPro;

    [SerializeField]
    private UnityEvent<string> SetTextEvent;

    private void Start()
    {
        textMeshPro = GetComponent<TextMeshPro>();
    }

    public void SetText()
    {
        SetTextEvent.Invoke(textMeshPro.text);
    }
}
