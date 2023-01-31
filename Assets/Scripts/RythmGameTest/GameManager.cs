using UnityEngine;
using UnityEngine.UI;

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

    private void Start()
    {
        state = BattleState.START;
        SetupGame();
    }

    private void Update()
    {
        switch (state)
        {
            case BattleState.ARGUMENT:
                playerScript.onArgumentCreated.AddListener(CreateArgument);
                state = BattleState.WAITINGFORARGUMENT;
                break;

            case BattleState.WAITINGFORARGUMENT:
                break;

            case BattleState.PREATTACK:
                playerScript.onArgumentCreated.RemoveListener(CreateArgument);
                playerScript.Disable(true);
                Attack();
                break;

            case BattleState.RYTHMATTACK:
                RythmGame();
                PullBack();
                break;

            case BattleState.ENDATTACK:
                SetPositionMainthought();
                playerScript.Disable(false);
                break;

            case BattleState.WIN:
                winPanel.SetActive(true);
                break;

            case BattleState.LOSE:
                losePanel.SetActive(true);
                break;
        }
    }

    public void SetupGame()
    {
        instance = this;
        currentMultiplier = 1;
        canAttack = false;
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
        Instantiate(playerArgument, playerGrappler.transform);
        Instantiate(enemyArgument, enemyGrappler.transform);
        state = BattleState.PREATTACK;
    }

    public void Attack()
    {
        if (!Input.GetMouseButtonDown(0) || theGrapplingHook.hasShot == true)
        {
            return;
        }

        theGrapplingHook.Shoot();

        state = BattleState.RYTHMATTACK;
    }

    private void RythmGame()
    {
        rythmObjectHolder.SetActive(true);
        theBeatScroller.hasStarted = true;
        theMusic.Play();
    }

    public void PullBack()
    {
        if (!Input.GetMouseButtonDown(0))
        {
            return;
        }

        theGrapplingHook.Release();
        rythmObjectHolder.SetActive(false);
        theBeatScroller.hasStarted = false;
        theMusic.Stop();
        state = BattleState.ENDATTACK;
    }

    public void NoteHit()
    {
        Debug.Log("Hit on time");

        if (currentMultiplier - 1 < multiplierThresholds.Length)
        {
            multiplierTracker++;

            if (multiplierThresholds[currentMultiplier - 1] <= multiplierTracker)
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
        state = BattleState.ARGUMENT;
    }
}
