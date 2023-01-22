using UnityEngine;

public class Form<T> : MonoBehaviour
{
    [SerializeField]
    private T Model;

    private void Start()
    {
    }
}

public class GSchemaForm : Form<GSchemaDto>
{
}
