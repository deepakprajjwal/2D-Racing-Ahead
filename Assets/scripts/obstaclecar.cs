using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstaclecar : MonoBehaviour
{
    public float moveSpeed = 0f;
    Rigidbody2D carRb;

    // Start is called before the first frame update
    void Start()
    {
        carRb = GetComponent<Rigidbody2D>();
        if(moveSpeed > 0f){
      
       carRb.velocity = transform.up*Time.deltaTime*moveSpeed;
        
    }}

    // Update is called once per frame
     void Update()
    {
         if(moveSpeed > 0f){
       transform.Translate(transform.up*Time.deltaTime*moveSpeed);
       carRb.velocity = transform.up*Time.deltaTime*moveSpeed;
        }
   }
}
