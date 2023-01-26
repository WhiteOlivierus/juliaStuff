using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Radio : MonoBehaviour
{
    public UnityEvent<int> OnClicked;
    private Toggle toggle;
    public int index;

    private void Start()
    {
        toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(OnValueChanged);
    }

    private void OnValueChanged(bool value)
    {
        OnClicked?.Invoke(index);
    }

    public void Set(bool v)
    {
        toggle.SetIsOnWithoutNotify(v);
    }
}
