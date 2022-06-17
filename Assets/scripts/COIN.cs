using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class COIN : MonoBehaviour
{
    AudioSource ads;
    // Start is called before the first frame update
   private void Start()
    {
       ads = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PLAYERCAR>())
        {
            ads.Play();
            collision.GetComponent<PLAYERCAR>().uIManager.IncreaseCoins();
            SelfDeactivate();
        }
    }

    

void SelfDeactivate()
{
    Destroy(this.gameObject, 0.1f);
}
}