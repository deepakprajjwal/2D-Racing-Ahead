using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PLAYERCAR : MonoBehaviour
{
    private bool carChangingLane;
    private bool isPlayerCarGoingLeft;
    private  bool clearPlayerCarRotation;
    public float moveSpeed=1f;
     private float xPos=1.5f;
    
    private float zRotation = 0f;
    public ROAD road;
    public UIMANAGER uIManager;
    // Start is called before the first frame update
    AudioSource ads;
    void Start()
    { ads = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow)){
           StartLeftMove();
            //this.transform.position = new Vector3 (5f,transform.position.y,transform.position.z);
        }
        if(Input.GetKeyDown(KeyCode.RightArrow)){
           StartRightMove();
            }
            if(Input.GetKeyUp (KeyCode.LeftArrow)|| Input.GetKeyUp(KeyCode.RightArrow)){
                StopMove();
            }
            if(Input.GetMouseButton(0))
            {
                Vector3 mousePos = Input.mousePosition;
                if(mousePos.x < Screen.width/2f)
                {
                    StartLeftMove();
                }
                if(mousePos.x > Screen.width/2f)
                {
                    StartRightMove();

                }

            }
            if(Input.GetMouseButtonUp(0))
            {
                StopMove();
            }
           // this.transform.position = new Vector3 (22f, transform.position.y,transform.position.z);
            if(GameManager.instance.gameStates == GameManager.GameStates.gamePlaying){
            ChangeCarLane();
            }
        }
        private void StopMove()
        {
          carChangingLane=false;
                clearPlayerCarRotation=true;  
        }
        private void StartRightMove()
        { carChangingLane = true;
            isPlayerCarGoingLeft=false;
            clearPlayerCarRotation=false;

        }
        private void StartLeftMove()
        {
             carChangingLane = true;
            isPlayerCarGoingLeft=true;
            clearPlayerCarRotation=false;
        }
        private void ChangeCarLane(){
            if(carChangingLane  && !clearPlayerCarRotation){
               
                if(isPlayerCarGoingLeft)
                {
                    if(xPos>-6f){
                        xPos-=Time.deltaTime*moveSpeed;

                    }
                    if(zRotation<10f){
                        zRotation+=Time.deltaTime*moveSpeed;
                    }

                }
                else if (!isPlayerCarGoingLeft){
                    if(xPos<=8f){
                        xPos+=Time.deltaTime*moveSpeed;

                    }
                    if(zRotation>-10f){
                        zRotation-=Time.deltaTime*moveSpeed;
                    }
                    
                }
                this.transform.position=new Vector3( xPos, transform.position.y,transform.position.z);
                this.transform.rotation=Quaternion.Euler (0f ,0f, zRotation); 
              
          
            }
             if(clearPlayerCarRotation){
                    zRotation = Mathf.Lerp(zRotation,0f,Time.deltaTime*moveSpeed);
                    this.transform.position=new Vector3( xPos, transform.position.y,transform.position.z);
                this.transform.rotation=Quaternion.Euler (0f ,0f, zRotation); 
                }
                
                if(zRotation == 0f){
                clearPlayerCarRotation = false;
        }
}

    
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "ObstacleCar") {
            Destroy(other.gameObject);
            road.speed = 0f;
            GameManager.instance.gameStates = GameManager.GameStates.playerDied;
            uIManager.ActivateRestartUI();
            uIManager.SaveGameData();
            ads.Play();
            GetComponentInChildren<SpriteRenderer>().color = new Color(1f,1f,1f, 0.3f);
            GetComponent<PLAYERCAR>().enabled = false;
            
            //Invoke("SelfDeactivate", 0.2f);
            //this.gameObject.SetActive (false);
        }
        /*if (other.tag == "Coin"){
            Destroy(other.gameObject);
            uIManager.IncreaseCoins();
        }*/
    }
    /*void SelfDeactivate()
    {
        this.gameObject.SetActive (false);
    }*/
}
