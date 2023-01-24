using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class SetString : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<string> TextUpdateEvent;

    private TMP_InputField textInputField;

    private void Start()
    {
        textInputField = GetComponent<TMP_InputField>();

        textInputField.onValueChanged.AddListener(OnTextChanged);
    }

    public void OnTextChanged(string value)
    {
        TextUpdateEvent.Invoke(value);
    }
}
