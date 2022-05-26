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

    public float timeFever;

    public int countLevelCristalFever;
    [Header("Speed Palayer")]
    public float speed =10;

    public int countDedEnemy;

    int countQueue, countCrystal, countEnemy;

    [SerializeField] UIManager uiManager;
    [SerializeField] PPEffect _PPEffect;
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
        _PPEffect = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PPEffect>();

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
       // countCrystal+=value;
        //uiManager.UpdateLevelProgresBarFever(1);
    }
    public void CountDedEnemy(int value)
    {
        if (value == activeColor && playerState == PlayerState.Move)
        {
            countEnemy++; 
            uiManager.UpdateLevelProgresBarFever(countEnemy);            
        }
        else if(playerState == PlayerState.Fever){
           // countEnemy++;
            //uiManager.CountEnemyUI(countEnemy);
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
            countQueue++;
            print(countQueue.ToString());
            if (countQueue == countDedEnemy)
            {
                StartCoroutine(Fever());
            }
        }
        else if (name == "Crystal")
        {
            countCrystal++;
            addCristal(countCrystal);
        }
    }

    private IEnumerator Fever()
    {
        playerState = PlayerState.Fever;
        _PPEffect.PostProcessOn();
        yield return new WaitForSeconds(timeFever);
        playerState = PlayerState.Move;
        _PPEffect.PostProcessOff();
        countCrystal += 10;
        addCristal(countCrystal);
        countQueue = 0;
        countEnemy = 0;
        uiManager.UpdateLevelProgresBarFever(countEnemy);   
    }

    private void addCristal(int value)
    {        
        uiManager.CountCrystalUI(countCrystal);
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
