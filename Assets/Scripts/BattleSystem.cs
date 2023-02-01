using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleStates { START, PREATTACK, ENDATTACK, WIN, LOOSE }

public class BattleSystem : MonoBehaviour
{

    public BattleStates state;

    public Transform playerGrappler;
    public Transform enemyGrappler;

    public GameObject playerArgument;
    public GameObject enemyArgument;

    // Start is called before the first frame update
    void Start()
    {
        state = BattleStates.START;
        CreateArgument();
    }

    public void CreateArgument()
    {
        Instantiate(playerArgument, playerGrappler);
        Instantiate(enemyArgument, enemyGrappler);
    }
}
