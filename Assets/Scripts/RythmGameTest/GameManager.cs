using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, ARGUMENT, PREATTACK, RYTHMATTACK, ENDATTACK, WIN, LOSE }

public class GameManager : MonoBehaviour
{

    public BattleState state;

    public AudioSource theMusic;

    public GameObject player;
    public CreateArgument playerScript;

    public bool startPlaying;

    public BeatScroller theBeatScroller;

    public GameObject argumentCanvas;

    public static GameManager instance; 

    public int currentScore;
    public int scorePerNote = 100;
    public int scorePerGoodNote = 125;
    public int scorePerPerfectNote = 150;
    public GameObject hitEffect, missEffect, goodEffect, perfectEffect;
    public GameObject scoreEffectPosition;
    public GameObject rythmObjectHolder;
    public bool rythmGameEnded;

    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThresholds;

    public Text scoreText;
    public Text multiplierText;

    private bool canCreateArgument;
    public GameObject playerArgument;
    public GameObject enemyArgument;

    public GrapplingHook theGrapplingHook;
    public GameObject playerGrappler;
    public GameObject enemyGrappler;

    public MoveMainthought moveTheMainThought;
    public GameObject mainThought;
    public bool mainthoughtCanMove;
    public Vector3 normalPosition;
    public Vector3 goodPosition;
    public Vector3 perfectPosition;

    public GameObject winPanel;
    public GameObject losePanel;

    private bool canAttack = false;
    // Start is called before the first frame update

    void Start()
    {
        state = BattleState.START;
        SetupGame();
    }

    // Update is called once per frame
    void Update()
    {
        if(canCreateArgument)
        {
            CreateArgument();
        }
        if (state == BattleState.PREATTACK)
        {
            Attack();
        }
       
        if(state == BattleState.RYTHMATTACK)
        {
            StartCoroutine(RythmGame());
        }

        if (rythmGameEnded)
        {
            state = BattleState.ENDATTACK;
        }

        if(state == BattleState.ENDATTACK)
        {
            PullBack();
            if (mainthoughtCanMove)
            {
                SetPositionMainthought();
            }
            
        }

        if(state == BattleState.WIN)
        {
            winPanel.SetActive(true);
        }

        if (state == BattleState.LOSE)
        {
            losePanel.SetActive(true);
        }
    }

    public void SetupGame()
    {
        instance = this;
        currentMultiplier = 1;
        canAttack = false;
        canCreateArgument = true;
        rythmObjectHolder.SetActive(false);
        rythmGameEnded = false;
        argumentCanvas.SetActive(false);
        mainthoughtCanMove = false;
        winPanel.SetActive(false);
        losePanel.SetActive(false);

        state = BattleState.ARGUMENT;

    }

    public void CreateArgument()
    {
        if (playerScript.argumentCreated == true)
        {
            Instantiate(playerArgument, playerGrappler.transform);
            Instantiate(enemyArgument, enemyGrappler.transform);
            //theGrapplingHook.hasShot = true;
            state = BattleState.PREATTACK;
        }
    }

    public void Attack()
    {
        if (Input.GetMouseButtonDown(0) && theGrapplingHook.hasShot!= true)
        {
            theGrapplingHook.Shoot();
            
            state = BattleState.RYTHMATTACK;                   
        }
    }

    IEnumerator RythmGame()
    {
        yield return new WaitForSeconds(2f);
        rythmObjectHolder.SetActive(true);
        startPlaying = true;
        theBeatScroller.hasStarted = true;        
        theMusic.Play();
    }

    public void PullBack()
    {
        if (Input.GetMouseButtonDown(1))
        {
            theGrapplingHook.Release();
            rythmGameEnded = false;
            mainthoughtCanMove = true;
        }
    }

    public void NoteHit()
    {
        Debug.Log("Hit on time");

        if(currentMultiplier - 1 < multiplierThresholds.Length)
        {
            multiplierTracker++;

            if(multiplierThresholds[currentMultiplier - 1]<= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }

        multiplierText.text = "Multiplier: x" + currentMultiplier;

        //currentScore += scorePerNote * currentMultiplier;
        scoreText.text = "Score " + currentScore;
        
        rythmObjectHolder.SetActive(false);
        rythmGameEnded = true;
        Debug.Log("Is at end");
        
    }

    public void NormalHit()
    {
        currentScore += scorePerNote * currentMultiplier;
        Instantiate(hitEffect, scoreEffectPosition.transform.position, hitEffect.transform.rotation);
        moveTheMainThought.newPosition = normalPosition;
        NoteHit();
    }

    public void GoodHit()
    {
        currentScore += scorePerGoodNote * currentMultiplier;
        Instantiate(goodEffect, scoreEffectPosition.transform.position, goodEffect.transform.rotation);
        moveTheMainThought.newPosition = goodPosition;
        NoteHit();
    }

    public void PerfectHit()
    {
        currentScore += scorePerPerfectNote * currentMultiplier;
        Instantiate(perfectEffect, scoreEffectPosition.transform.position, perfectEffect.transform.rotation);
        moveTheMainThought.newPosition = perfectPosition;
        NoteHit();
    }


    public void NoteMissed()
    {
        Debug.Log("Missed note");

        Instantiate(missEffect, transform.position, missEffect.transform.rotation);
        currentMultiplier = 1;
        multiplierTracker = 0;

        multiplierText.text = "Multiplier: x" + currentMultiplier;
    }

    public void SetPositionMainthought()
    {
        moveTheMainThought.OperateMainthought();
        Debug.Log("Is WORKING");
        mainthoughtCanMove = true;
        
    }
}
