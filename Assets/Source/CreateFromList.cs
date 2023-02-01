using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class CreateFromList : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onCreated;

    [SerializeField]
    private SerializableCallbackIEnumerable values;

    [SerializeField]
    private GameObject template;

    [SerializeField]
    private Transform parent;

    private GameObject copy;

    private bool done;

    private void Awake()
    {
        template.SetActive(false);
    }

    private void Start()
    {
        if (template != null)
        {
            template.SetActive(false);
        }

        if (parent == null)
        {
            parent = transform;
        }

        copy = Instantiate(template, parent);
        copy.transform.SetSiblingIndex(1);

        New();
    }

    public void New()
    {
        if (done || values == null)
        {
            return;
        }

        IEnumerable<string> strings = values.Invoke();

        if (strings == null)
        {
            return;
        }

        foreach (string value in strings)
        {
            GameObject templated = Instantiate(copy, parent);
            templated.transform.SetSiblingIndex(1);
            templated.GetComponentInChildren<Text>().text = value;
            templated.SetActive(true);
        }

        onCreated?.Invoke();
        done = true;
    }
}
