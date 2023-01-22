using System.Collections.Generic;
using TMPro;
using System.Linq;
using UnityEngine;

public class Validator : MonoBehaviour
{
    [SerializeField]
    private List<ValidationRule<string>> rules;

    private TextMeshPro textMeshPro;

    private void Start()
    {
        textMeshPro = GetComponent<TextMeshPro>();
    }

    public bool Validate()
    {
        if (rules == null || rules.Count < 1)
        {
            return true;
        }

        return rules.All(rule => rule.Validate(() => textMeshPro.text));
    }
}
