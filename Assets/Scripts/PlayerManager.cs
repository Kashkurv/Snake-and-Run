using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
     public Material matViolet;
     public Material matPink;
     public Material matYellow;
     public Material matBlue;
     public Material matTurquoise;
     public Material matGreen;
     public Material matBlack;
     public Material matWhite;


    [HideInInspector] public int matVioletIndex = 1;
    [HideInInspector] public int matPinkIndex = 2;
    [HideInInspector] public int matYellowIndex = 3;
    [HideInInspector] public int matBlueIndex = 4;
    [HideInInspector] public int matTurquoiseIndex = 5;
    [HideInInspector] public int matGreenIndex = 6;
    [HideInInspector] public int matBlackIndex = 7;
    [HideInInspector] public int matWhiteIndex = 8;

    [HideInInspector] public int activeColor;
    [HideInInspector] public int enemyID;

    public PlayerState playerState;
    public LevelState levelState;

    

    public float speed;

    public int countDedEnemy;

    int countQueue, countCrystal, countEnemy;

    [SerializeField] UIManager uiManager;
    public enum PlayerState
    {
        Stop,
        Move,
        Fever
    }
    public enum LevelState 
    {
        NotFinished,
        Finished
    }
    private void Start()
    {
        uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        countQueue = 0;
        countCrystal = 0;
        countEnemy = 0;
    }
    public void ColorActive(int value)
    {
        activeColor = value;
    }
    public void CountCrystal(int value)
    {
        countCrystal+=value;
        uiManager.CountCrystalUI(countCrystal);
    }
    public void CountDedEnemy(int value)
    {
        if (value == activeColor && playerState == PlayerState.Move)
        {
            countEnemy++;
            uiManager.CountEnemyUI(countEnemy);
        }else if(playerState == PlayerState.Fever){
            countEnemy++;
            uiManager.CountEnemyUI(countEnemy);
        }
        else
        {
            GameOver();
        }
    }
    public void CheckQueue(string name)
    {
        if (name == "Enemy")
        {
            countQueue = 0;
        }else if (name == "Crystal")
        {
            countQueue++;
            if (countQueue == 3)
            {                
                uiManager.CountCrystalUI(countCrystal);
                StartCoroutine(Fever());
            }
        }
    }

    private IEnumerator Fever()
    {
        playerState = PlayerState.Fever;
        yield return new WaitForSeconds(5);
        playerState = PlayerState.Move;
        uiManager.CountCrystalUI(countCrystal);
        countQueue = 0;
        countCrystal = 0;
    }
    public void FinishLevel()
    {
        levelState = LevelState.Finished;
        playerState = PlayerState.Stop;
        uiManager.GameCompletedUI();
    }
    public void GameOver()
    {
        levelState = LevelState.NotFinished;
        playerState = PlayerState.Stop;
        countEnemy = 0;
        uiManager.GameOverUI();        
    }
}
