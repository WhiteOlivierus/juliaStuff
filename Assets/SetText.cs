using TMPro;
using UnityEngine;

public class SetText : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        GSchemaManager instance = GSchemaManager.Instance;
        if(instance == null)
        {
            return;
        }
     
        GetComponent<TMP_Text>().text = instance.GetMainThought();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
