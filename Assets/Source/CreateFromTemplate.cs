using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class CreateFromTemplate : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<TMP_InputField> onCreate;

    [SerializeField]
    private GameObject template;

    [SerializeField]
    private Transform parent;

    [SerializeField]
    private bool CreateOnStart = true;

    private GameObject copy;

    private void Start()
    {
        if (template != null)
        {
            template.SetActive(false);
        }
        else
        {
            Debug.LogError($"No template was set on {gameObject.name}");
        }

        if (parent == null)
        {
            parent = transform;
        }

        copy = Instantiate(template, parent);
        copy.transform.SetSiblingIndex(1);

        if (CreateOnStart)
        {
            New();
        }
    }

    public void New()
    {
        GameObject templated = Instantiate(copy, parent);
        templated.transform.SetSiblingIndex(2);
        templated.SetActive(true);
        onCreate.Invoke(templated.GetComponentInChildren<TMP_InputField>());
    }
}
