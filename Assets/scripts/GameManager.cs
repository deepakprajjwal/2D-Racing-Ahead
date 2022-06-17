using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject gamePlayRelated;
    public GameStates gameStates;
    public float moveSpeed = 5f;
    public enum GameStates
    {
        none,
        mainMenu,
        gamePlaying,
        playerDied,
        gameOver
    }
    void Awake(){
        instance = this;

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         MoveGamePlayObjects();
        
    }
    private void MoveGamePlayObjects(){
        if (gameStates == GameStates.gamePlaying){
            gamePlayRelated.transform.position += Vector3.up * Time.deltaTime*moveSpeed;
        }
    }
}
