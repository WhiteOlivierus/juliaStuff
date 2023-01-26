using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class RadioBehavior : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<int> OnChange;

    private IList<Radio> radios;

    private void Start()
    {
        radios = GetComponentsInChildren<Radio>().ToList();

        Radio activeRadio = radios.FirstOrDefault();
        activeRadio.Set(true);
        OnChange.Invoke(0);

        for (int i = 0; i < radios.Count; i++)
        {
            Radio radio = radios[i];
            radio.index = i;
            radio.OnClicked.AddListener(OnValueChanged);
        }
    }

    private void OnValueChanged(int value)
    {
        foreach (Radio radio in radios)
        {
            radio.Set(false);
        }
        radios[value].Set(true);
        OnChange.Invoke(value);
    }
}
