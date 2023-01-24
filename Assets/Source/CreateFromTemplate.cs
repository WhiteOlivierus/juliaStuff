using UnityEngine;

public class CreateFromTemplate : MonoBehaviour
{
    [SerializeField]
    private GameObject toCopy;

    [SerializeField]
    private Transform parent;

    private GameObject template;

    private void Start()
    {
        if (parent == null)
        {
            parent = transform;
        }

        template = Instantiate(toCopy, parent);
        template.transform.SetSiblingIndex(1);
        template.SetActive(false);
    }

    public void New()
    {
        GameObject templated = Instantiate(template, parent);
        templated.transform.SetSiblingIndex(1);
        template.SetActive(true);
    }
}
