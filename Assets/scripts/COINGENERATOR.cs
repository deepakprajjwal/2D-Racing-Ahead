using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class COINGENERATOR : MonoBehaviour
{
    public GameObject coinPrefab;
    private void Start()
    {
        GenerateCoinsPattern();
    }

    private void GenerateCoinsPattern()
    {
        int noOfCoins = Random.Range(3,8);
        float yPos = -7;
        for (int i = 0; i < noOfCoins; i++)
        {
            
            Transform coin = Instantiate(coinPrefab).transform;
            coin.parent = this.transform;
            coin.localPosition = new Vector2(9f,yPos);
            yPos += 3f;
            
        }
    }
}
