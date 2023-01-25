using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CreateFromList : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onCreated;

    [SerializeField]
    private SerializableCallbackIEnumerable values;

    [SerializeField]
    private GameObject toCopy;

    [SerializeField]
    private Transform parent;

    private GameObject template;

    private bool done;

    private void Awake()
    {
        if (toCopy != null)
        {
            toCopy.SetActive(false);
        }

        if (parent == null)
        {
            parent = transform;
        }

        template = Instantiate(toCopy, parent);
        template.transform.SetSiblingIndex(1);

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
            GameObject templated = Instantiate(template, parent);
            templated.transform.SetSiblingIndex(1);
            templated.GetComponentInChildren<Text>().text = value;
            templated.SetActive(true);
        }

        onCreated?.Invoke();
        done = true;
    }
}
