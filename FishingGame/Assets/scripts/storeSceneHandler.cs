using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class storeSceneHandler : MonoBehaviour
{
    public GameObject fishText;
    public GameObject moneyText;
    public GameObject rodText;
    public GameObject errorText;
    public GameObject errorImg;
    public GameObject optMenu;


    public bool isVisible = false;

    // Start is called before the first frame update
    void Start()
    {
        UpdateFish();
        UpdateMoney();
        UpdateRod();
        errorImg.SetActive(false);
        errorText.SetActive(false);

        if (PlayerPrefs.GetFloat("RodLevel") == 2) {
            GameObject.FindWithTag("Rod2").SetActive(false);
            GameObject.Find("Level2").SetActive(false);
        } else if (PlayerPrefs.GetFloat("RodLevel") == 3) {
            GameObject.FindWithTag("Rod2").SetActive(false);
            GameObject.Find("Level2").SetActive(false);
            GameObject.FindWithTag("Rod3").SetActive(false);
            GameObject.Find("Level3").SetActive(false);
        } else if (PlayerPrefs.GetFloat("RodLevel") == 4) {
            GameObject.FindWithTag("Rod2").SetActive(false);
            GameObject.Find("Level2").SetActive(false);
            GameObject.FindWithTag("Rod3").SetActive(false);
            GameObject.Find("Level3").SetActive(false);
            GameObject.FindWithTag("Rod4").SetActive(false);
            GameObject.Find("Level4").SetActive(false);
        } else if (PlayerPrefs.GetFloat("RodLevel") == 5) {
            GameObject.FindWithTag("Rod2").SetActive(false);
            GameObject.Find("Level2").SetActive(false);
            GameObject.FindWithTag("Rod3").SetActive(false);
            GameObject.Find("Level3").SetActive(false);
            GameObject.FindWithTag("Rod4").SetActive(false);
            GameObject.Find("Level4").SetActive(false);
            GameObject.FindWithTag("Rod5").SetActive(false);
            GameObject.Find("Level5").SetActive(false);

        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown("escape")){
                Application.Quit();
                QuitGame();
        }

        if (Input.GetKeyDown("o")) {
            if (optMenu.activeInHierarchy) {
                optMenu.SetActive(false);
                resumeGame();
            } else {
                optMenu.SetActive(true);
                pauseGame(); 
            }
        }  
        if (Input.GetKeyDown("q")) {
            SceneManager.LoadScene("menu");
        }

        if (Input.GetKeyDown("h")) {
            SceneManager.LoadScene("Game");
        }

        if (isVisible) {
            StopCoroutine(DelayErrorAway());
            StartCoroutine(DelayErrorAway());
        }
    }


    public void SellFish(string tag) {
        if (tag == "fish") {
            if (PlayerPrefs.GetFloat("Fish") > 0) {
                PlayerPrefs.SetFloat("Fish", PlayerPrefs.GetFloat("Fish") - 1);
                PlayerPrefs.SetFloat("Money", PlayerPrefs.GetFloat("Money") + 10);
            } else {
                Debug.Log("Not able to sell fish");
                errorImg.SetActive(true);
                errorText.SetActive(true);
                Text errorTextB = errorText.GetComponent<Text>();
                errorTextB.text = "No more normal fish to sell. Go Fishing!!";
                isVisible = true;
            }
        } else if (tag == "fish_common") {
            if (PlayerPrefs.GetFloat("Fish_com") > 0) {
                PlayerPrefs.SetFloat("Fish_com", PlayerPrefs.GetFloat("Fish_com") - 1);
                PlayerPrefs.SetFloat("Money", PlayerPrefs.GetFloat("Money") + 5);
            } else {
                Debug.Log("Not able to sell fish");
                errorImg.SetActive(true);
                errorText.SetActive(true);
                Text errorTextB = errorText.GetComponent<Text>();
                errorTextB.text = "No more common fish to sell. Go Fishing!!";
                isVisible = true;
            }

        } else if (tag == "fish_3") {
            if (PlayerPrefs.GetFloat("Fish_3") > 0) {
                PlayerPrefs.SetFloat("Fish_3", PlayerPrefs.GetFloat("Fish_3") - 1);
                PlayerPrefs.SetFloat("Money", PlayerPrefs.GetFloat("Money") + 15);
            } else {
                Debug.Log("Not able to sell fish");
                errorImg.SetActive(true);
                errorText.SetActive(true);
                Text errorTextB = errorText.GetComponent<Text>();
                errorTextB.text = "No more rare fish to sell. Go Fishing!!";
                isVisible = true;
            }
        } else if (tag == "fish_5") {
            if (PlayerPrefs.GetFloat("Fish_5") > 0) {
                PlayerPrefs.SetFloat("Fish_5", PlayerPrefs.GetFloat("Fish_5") - 1);
                PlayerPrefs.SetFloat("Money", PlayerPrefs.GetFloat("Money") + 200);
            } else {
                Debug.Log("Not able to sell fish");
                errorImg.SetActive(true);
                errorText.SetActive(true);
                Text errorTextB = errorText.GetComponent<Text>();
                errorTextB.text = "No more legendary fish to sell. Go Fishing!!";
                isVisible = true;
            }
        }

        UpdateFish();
        UpdateMoney();
    }


    public void Wait(int time) 
    {           
        System.Threading.Thread thread = new System.Threading.Thread(delegate()
        {   
            System.Threading.Thread.Sleep(time);
        });
        thread.Start();
        while (thread.IsAlive) {
        }
        // Application.DoEvents();
    }

    public void BuyRod(string rodNum) {

        switch(rodNum) {
            case "Rod2":
                if (PlayerPrefs.GetFloat("Money") >= 30) {
                    Debug.Log("able to buy rod");
                    PlayerPrefs.SetFloat("Money", PlayerPrefs.GetFloat("Money") - 30);
                    PlayerPrefs.SetFloat("RodLevel", 2);
                    UpdateMoney();
                    UpdateRod(); 

                    // Destroy(GameObject.FindWithTag(rodNum));
                    GameObject.Find("Level2").SetActive(false);
                    GameObject.FindWithTag(rodNum).SetActive(false);
                    Update();

                } else {
                    Debug.Log("Not able to buy rod");
                    errorImg.SetActive(true);
                    errorText.SetActive(true);
                    Text errorTextB = errorText.GetComponent<Text>();
                    errorTextB.text = "Insufficient funds to buy Level 2 Rod. Sell more Fish";
                    isVisible = true;

                }
                break;
            case "Rod3":
                if (PlayerPrefs.GetFloat("RodLevel") == 2) {
                    if (PlayerPrefs.GetFloat("Money") >= 60) {
                        Debug.Log("able to buy rod");
                        PlayerPrefs.SetFloat("Money", PlayerPrefs.GetFloat("Money") - 60);
                        PlayerPrefs.SetFloat("RodLevel", 3);
                        UpdateMoney();
                        UpdateRod();

                        GameObject.Find("Level3").SetActive(false);
                        GameObject.FindWithTag(rodNum).SetActive(false);
                        Update();

                    } else {
                        Debug.Log("Not able to buy rod");
                        errorImg.SetActive(true);
                        errorText.SetActive(true);
                        Text errorTextB = errorText.GetComponent<Text>();
                        errorTextB.text = "Insufficient funds to buy Level 3 Rod. Sell more Fish";
                        isVisible = true;

                    }
                } else {
                    Debug.Log("Not able to buy rod");
                    errorImg.SetActive(true);
                    errorText.SetActive(true);
                    Text errorTextB = errorText.GetComponent<Text>();
                    errorTextB.text = "Must purchase Rod Level 2 first.";
                    isVisible = true;
                }
                break;
            case "Rod4":
                if (PlayerPrefs.GetFloat("RodLevel") == 3) {
                    if (PlayerPrefs.GetFloat("Money") >= 90) {
                        Debug.Log("able to buy rod");
                        PlayerPrefs.SetFloat("Money", PlayerPrefs.GetFloat("Money") - 90);
                        PlayerPrefs.SetFloat("RodLevel", 4);
                        UpdateMoney();
                        UpdateRod();

                        GameObject.Find("Level4").SetActive(false);
                        GameObject.FindWithTag(rodNum).SetActive(false);
                        Update();
                        
                    } else {
                        Debug.Log("Not able to buy rod");
                        errorImg.SetActive(true);
                        errorText.SetActive(true);
                        Text errorTextB = errorText.GetComponent<Text>();
                        errorTextB.text = "Insufficient funds to buy Level 4 Rod. Sell more Fish";
                        isVisible = true;

                    }
                } else {
                    Debug.Log("Not able to buy rod");
                    errorImg.SetActive(true);
                    errorText.SetActive(true);
                    Text errorTextB = errorText.GetComponent<Text>();
                    errorTextB.text = "Must purchase Rod Level 3 first.";
                    isVisible = true;
                }
                break;
            case "Rod5":
                if (PlayerPrefs.GetFloat("RodLevel") == 4) {
                    if (PlayerPrefs.GetFloat("Money") >= 120) {
                        Debug.Log("able to buy rod");
                        PlayerPrefs.SetFloat("Money", PlayerPrefs.GetFloat("Money") - 120);
                        PlayerPrefs.SetFloat("RodLevel", 5);
                        UpdateMoney();
                        UpdateRod();

                        GameObject.Find("Level5").SetActive(false);
                        GameObject.FindWithTag(rodNum).SetActive(false);
                        Update();
                        
                    } else {
                        Debug.Log("Not able to buy rod");
                        errorImg.SetActive(true);
                        errorText.SetActive(true);
                        Text errorTextB = errorText.GetComponent<Text>();
                        errorTextB.text = "Insufficient funds to buy Level 5 Rod. Sell more Fish";
                        isVisible = true;

                    }
                } else {
                    Debug.Log("Not able to buy rod");
                    errorImg.SetActive(true);
                    errorText.SetActive(true);
                    Text errorTextB = errorText.GetComponent<Text>();
                    errorTextB.text = "Must purchase Rod Level 4 first.";
                    isVisible = true;
                }
                break;

        }
    }

    IEnumerator DelayErrorAway() {
        yield return new WaitForSeconds(2f);
        isVisible = false;
        errorText.SetActive(false);
        errorImg.SetActive(false);

    }

    // Update is called once per frame
    void UpdateFish() {
        Text fishTextB = fishText.GetComponent<Text>();
        fishTextB.text = "" + (PlayerPrefs.GetFloat("Fish") + PlayerPrefs.GetFloat("Fish_com")
                                + PlayerPrefs.GetFloat("Fish_3") + PlayerPrefs.GetFloat("Fish_5"));
    }

    void UpdateMoney() {
        Text moneyTextB = moneyText.GetComponent<Text>();
        moneyTextB.text = "" + PlayerPrefs.GetFloat("Money");
    }

    void UpdateRod() {
        Text rodTextB = rodText.GetComponent<Text>();
        rodTextB.text = "" + PlayerPrefs.GetFloat("RodLevel");
    }

    public void QuitGame(){
        // UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();

    }
    
    void pauseGame() {
        Time.timeScale = 0;
    }

    public void resumeGame() {
        Time.timeScale = 1;
    }

}
