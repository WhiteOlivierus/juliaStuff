using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class ToggleItems : MonoBehaviour
{
    [SerializeField]
    private UnityEvent endOfItemsEvent;

    [SerializeField]
    private List<GameObject> items;

    [SerializeField]
    private GameObject validationText;

    private void Start()
    {
        items.ForEach(item => item.SetActive(false));

        GameObject firstItem = items.First();

        if (firstItem != null)
        {
            firstItem.SetActive(true);
        }
    }

    public void NextItem()
    {
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
