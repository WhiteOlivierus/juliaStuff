using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class SetStrings : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<IEnumerable<string>> TextUpdateEvent;

    private IList<TMP_InputField> textInputFields;

    private void Start()
    {
        textInputFields = GetComponentsInChildren<TMP_InputField>().ToList();
    }

    public void AddTextInputField(TMP_InputField textInputField)
    {
        if (textInputFields == null)
        {
            textInputFields = GetComponentsInChildren<TMP_InputField>().ToList();
            return;
        }
        textInputFields.Add(textInputField);
        textInputField.onValueChanged.AddListener(OnTextChanged);
    }

    public void OnTextChanged(string value)
    {
        TextUpdateEvent.Invoke(textInputFields.Select(textInputField => textInputField.text));
    }
}
