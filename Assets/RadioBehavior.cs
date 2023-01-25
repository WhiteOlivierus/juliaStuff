using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RadioBehavior : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<int> OnChange;

    private IList<Toggle> toggles;

    private Toggle activeToggle;

    private void OnEnable()
    {
        toggles = GetComponentsInChildren<Toggle>().ToList();

        activeToggle = toggles.FirstOrDefault();
        activeToggle.isOn = true;
        int arg0 = GetIndex();
        OnChange.Invoke(arg0);

        foreach (Toggle toggle in toggles)
        {
            toggle.onValueChanged.AddListener(OnValueChanged);
        }
    }

    private int GetIndex()
    {
        return toggles.IndexOf(activeToggle);
    }

    private void OnValueChanged(bool value)
    {
        if (!value)
        {
            activeToggle.SetIsOnWithoutNotify(true);
            return;
        }

        activeToggle.SetIsOnWithoutNotify(false);

        activeToggle = toggles.Where(toggle => toggle.isOn).FirstOrDefault();

        OnChange.Invoke(GetIndex());
    }
}
