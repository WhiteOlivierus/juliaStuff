using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class ToggleItems : MonoBehaviour
{
    private Form form;

    [SerializeField]
    private UnityEvent endOfItemsEvent;

    [SerializeField]
    private List<GameObject> items;

    [SerializeField]
    private GameObject validationText;

    private void Start()
    {
        GameObject firstItem = items.First();

        if (!firstItem.activeSelf)
        {
            firstItem.SetActive(true);
        }

        form = firstItem.GetComponentInParent<Form>();
    }

    public void NextItem()
    {
        bool validationResult = form.Validate();

        if (!validationResult)
        {
            validationText.SetActive(true);
            return;
        }

        GameObject activeItem = items.FirstOrDefault(item => item.activeSelf);

        int nextItemId = items.IndexOf(activeItem) + 1;
        GameObject nextItem = items.ElementAtOrDefault(nextItemId);

        if (activeItem != null)
        {
            activeItem.SetActive(false);
        }

        if (nextItem != null)
        {
            nextItem.SetActive(true);
        }
        else
        {
            endOfItemsEvent.Invoke();
        }
    }
}

public class ValidationResult
{
    public bool isValid;
    public string errorMessage;
}
