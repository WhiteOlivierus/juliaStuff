using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class SetFeelings : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<IEnumerable<Feeling>> TextUpdateEvent;

    private IEnumerable<FeelingInputField> feelingsInputField;

    private readonly IList<Feeling> feelings = new List<Feeling>();

    private void Start()
    {
        feelingsInputField = GetComponentsInChildren<FeelingInputField>();

        foreach (FeelingInputField feelingInputField in feelingsInputField)
        {
            feelingInputField.OnFeelingChanged.AddListener(OnFeelingChanged);
        }
    }

    public void OnFeelingChanged(FeelingUi value)
    {
        Feeling existingFeeling = feelings.FirstOrDefault(feeling => feeling.Emotion == value.Emotion);

        if (existingFeeling != null)
        {
            feelings.Remove(existingFeeling);
        }

        if (!value.Selected)
        {
            TextUpdateEvent.Invoke(feelings);
            return;
        }

        Feeling newFeeling = new Feeling()
        {
            Emotion = value.Emotion,
            Percentage = value.Percentage,
        };

        feelings.Add(newFeeling);

        TextUpdateEvent.Invoke(feelings);
    }
}
