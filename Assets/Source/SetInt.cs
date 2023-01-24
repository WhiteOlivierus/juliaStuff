using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class SetInt : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<int> TextUpdateEvent;

    private TMP_InputField textInputField;

    private void Start()
    {
        textInputField = GetComponent<TMP_InputField>();
    }

    public void OnTextChanged(int value)
    {
        TextUpdateEvent.Invoke(value);
    }
}
