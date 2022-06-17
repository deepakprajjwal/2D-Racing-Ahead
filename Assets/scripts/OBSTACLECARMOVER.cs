using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBSTACLECARMOVER : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "ObstacleCar"){
            obstaclecar obsCar = other.GetComponent<obstaclecar>();
            GiveRandomSpeed(obsCar);
            
        }

    }
    private void GiveRandomSpeed(obstaclecar  _obstacleCar){
        float randomSpeed = Random.Range(3f,11f);
        if(_obstacleCar.moveSpeed == 0f){
        _obstacleCar.moveSpeed = randomSpeed;
    }}
}
