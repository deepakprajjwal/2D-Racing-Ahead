using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIMANAGER : MonoBehaviour
{
    public GameObject gameName;
    public GameObject scoreUI;
    public GameObject coinsUI;
    public GameObject pauseBtn;
    public GameObject playButton;
    public GameObject quitButton;
    public GameObject restartButton;
    public GameObject highScoreAndCoin;
    public GameObject buyCar;
    public Text highScoreText;
    public Text totalCoinsText;
    public Text scoreText;
    [Space(10)]
    public GameObject carPurchasePanel;
    [Space(10)]
    public Image carImage;
    public Text priceText;
    public Button buyButton;
    public Sprite[] carSprite;
    public int[] carsPrice;
    public bool[] carPurchaseStatus;
    int carSpriteCounter=0;

    private int scoreInt;
    public int coinInt;
    public Text coinText;
    private int highScore;
    private int totalCoins;

    private void Awake()
    {
        if(PlayerPrefs.HasKey("highScore"))
        {
            highScore = PlayerPrefs.GetInt("highScore");
        }
        if(PlayerPrefs.HasKey("totalCoins"))
        {
            totalCoins = PlayerPrefs.GetInt("totalCoins");
        }
        highScoreText.text = highScore.ToString();
        totalCoinsText.text = totalCoins.ToString();
    }
    private void Start()
    {
        scoreInt = 0;
        scoreText.text = scoreInt.ToString();
        coinInt = 0;
        coinText.text = coinInt.ToString();
        restartButton.SetActive(false);
        ToggleUI(false);
        carImage.sprite = carSprite[0];
        priceText.text="";
        buyButton.GetComponentInChildren<Text>().text="select";
        //priceText.text = "Rs. "+ carsPrice[carSpriteCounter].ToString();

    }

    public void PlayGame()
    {
        gameName.SetActive(false);
        playButton.SetActive(false);
        quitButton.SetActive(false);
        highScoreAndCoin.SetActive(false);
        buyCar.SetActive(false);
        ToggleUI(true);

        GameManager.instance.gameStates = GameManager.GameStates.gamePlaying;
        StartCoroutine("IncreaseScore");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void ActivateRestartUI()
    {
        gameName.SetActive(true);
        restartButton.SetActive(true);
        quitButton.SetActive(true);

    }
    public void QuitGame()
    {
        #if UNITY_EDITOR
        EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
        Debug.Log("Game Quit.");
    }
    private void ToggleUI(bool isActive)
    {
        scoreUI.SetActive(isActive);
        coinsUI.SetActive(isActive);
        pauseBtn.SetActive(isActive);
    }
     public void IncreaseCoins()
     {
         coinInt += 1;
         coinText.text = coinInt.ToString();
     }

     public void SaveGameData()
     {
         if(scoreInt > highScore)
         {
             highScore = scoreInt;
         }
         totalCoins += coinInt;
         PlayerPrefs.SetInt("highScore",highScore);
         PlayerPrefs.SetInt("totalCoins",totalCoins);
     }
    IEnumerator IncreaseScore()
    {
        yield return new WaitForSeconds(1f);
        while(true)
        {
            if (GameManager.instance.gameStates == GameManager.GameStates.gamePlaying)
            {
            scoreInt += 1;
            scoreText.text = scoreInt.ToString();  
             }    
            yield return new WaitForSeconds(0.2f);
             }

    }
    public void SelectNextOrPreviousCar(bool trueNextCarFalsePreviousCar_)
    {
       if(trueNextCarFalsePreviousCar_)
       {
           carSpriteCounter++;
           if(carSpriteCounter>=carSprite.Length)
           {
               carSpriteCounter=0;
           }
           /*carImage.sprite=carSprite[carSpriteCounter];
           
        priceText.text = "Rs. " + carsPrice[carSpriteCounter].ToString();
        buyButton.GetComponentInChildren<Text>().text="Buy";*/
        DisplayCarPurchasingStatus();
         
       } 
       else{
            carSpriteCounter--;
           if(carSpriteCounter<0)
           {
               carSpriteCounter=carSprite.Length - 1;
           }
          DisplayCarPurchasingStatus();
       } 
       void DisplayCarPurchasingStatus()
       {
            carImage.sprite=carSprite[carSpriteCounter];
           
        priceText.text = "Rs. " + carsPrice[carSpriteCounter].ToString();
        if(carPurchaseStatus[carSpriteCounter]==true)
        buyButton.GetComponentInChildren<Text>().text="select";
        else
        buyButton.GetComponentInChildren<Text>().text="Buy";
       }
       
    }
    public void buyCars(){
        carPurchasePanel.SetActive(true);

    }
    public void GoBackFromPurchaseCarsPanel()
    {
        carPurchasePanel.SetActive(false);
    }
}
