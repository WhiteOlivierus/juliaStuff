using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class CreateFromTemplate : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<TMP_InputField> onCreate;

    [SerializeField]
    private GameObject toCopy;

    [SerializeField]
    private Transform parent;

    private GameObject template;

    private void Start()
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
    }

    public void New()
    {
        GameObject templated = Instantiate(template, parent);
        templated.transform.SetSiblingIndex(1);
        templated.SetActive(true);
        onCreate.Invoke(templated.GetComponent<TMP_InputField>());
    }
}
