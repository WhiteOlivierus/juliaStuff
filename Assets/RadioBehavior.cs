using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class RadioBehavior : MonoBehaviour
{
    private IList<Toggle> toggles;

    private IList<bool> togglesState;

    private void OnEnable()
    {
        toggles = GetComponentsInChildren<Toggle>().ToList();

        SetOneValue(0);

        foreach (Toggle toggle in toggles)
        {
            toggle.onValueChanged.AddListener(OnValueChanged);
        }
    }

    private void SetOneValue(int index)
    {
        togglesState = Enumerable.Repeat(false, toggles.Count()).ToList();
        togglesState[index] = true;
    }

    private void OnValueChanged(bool value)
    {
        IList<bool> togglesNewState = toggles.Select(toggle => toggle.isOn).ToList();

        int indexDifference = togglesNewState
            .Select((x, y) => new { element = x, index = y += 1 })
            .Where(z => togglesState.Contains(z.element))
            .Select(s => s.index).FirstOrDefault();

        SetOneValue(indexDifference);
    }
}
