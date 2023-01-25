using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FeelingsList : MonoBehaviour
{
    public IEnumerable<string> GetEmotions()
    {
        return Enum.GetNames(typeof(Emotion)).Where(s => s != "None");
    }
}
