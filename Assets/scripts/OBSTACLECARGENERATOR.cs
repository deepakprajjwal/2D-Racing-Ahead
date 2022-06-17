using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBSTACLECARGENERATOR : MonoBehaviour
{
   
    public GameObject[] obstacleCars;
    // Start is called before the first frame update
    void Start()
    {
       InvokeRepeating("GenerateObstacleCars",1f,Random.Range (0.8f,2.5f));
        
    }
    // Update is called once per frame
    void Update(){
    
        
    }
    private void GenerateObstacleCars() {
        if(GameManager.instance.gameStates == GameManager.GameStates.gamePlaying){
        float carGenerationPoint = GameManager.instance.gamePlayRelated.transform.position.y+20f;
        int randomNum = Random.Range(0,3);
        if(randomNum == 0){

        Instantiate(obstacleCars[Random.Range(0, obstacleCars.Length)], new Vector3( -14f,carGenerationPoint,-6f),Quaternion.identity);
    }
    else if (randomNum == 1){

        Instantiate(obstacleCars[Random.Range(0, obstacleCars.Length)], new Vector3( -8f,carGenerationPoint,-6f),Quaternion.identity);
    }
    else
    {
        Instantiate(obstacleCars[Random.Range(0, obstacleCars.Length)], new Vector3( -2f,carGenerationPoint,-6f),Quaternion.identity);
        
    }}}
}
