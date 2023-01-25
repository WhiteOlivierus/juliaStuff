using UnityEngine;
using UnityEngine.Events;

public class SetInt : MonoBehaviour
{
    [SerializeField]
    private SerializableCallbackInt index;

    [SerializeField]
    private UnityEvent<int> TextUpdateEvent;

    public void OnTextChanged(int value)
    {
        if (index.target != null)
        {
            value = index.Invoke();
        }

        TextUpdateEvent?.Invoke(value);
    }
}
