using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager SharedInstance;

    private GameObject player;
    private Player playerScript;
    public Gui gui;
    public int playerShips;
    public bool paused;
    public float playerScore;
    public int shotsMissed;
    public int shotsFired;
    public int shotsHit;
    public bool isPaused;
    public double playerCash;
    public double cashLost;
    public float time;
    public bool isGameOver;
    public GameObject boss;
    public bool bossActive;
    public GameObject hazardSpawner;
    public int roundTime;



    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
        SharedInstance = this;
        player = GameObject.FindWithTag("Player");
        playerScript = player.transform.GetComponent<Player>();
        bossActive = false;
        //roundTime = 500;
    }

    // Update is called once per frame
    void Update()
    {
        time = Time.timeSinceLevelLoad;
        playerShips = playerScript.ships;

        if (playerShips <= 0 && isGameOver == false) {
            GameOver();
        }
        if (Input.GetKey("c")) {
            ContinueGame();

        }
        if (Input.GetKey("p")) {
            PauseGame();
        }
        if (Input.GetKey("s") && isGameOver == true)
        {
            RestartGame();
        }
        if (Input.GetKey("q") && isGameOver == true || isPaused == true)
        {
            QuitGame();
        }
        if (time >= roundTime&&bossActive==false)
        {
            ActivateBoss();

        }
    }
    void FixedUpdate() {
      
    }
   
    void PauseGame(){
       isPaused=true;
       Time.timeScale = 0;
       gui.PauseScreen();
     }
    void ContinueGame(){
       isPaused=false;
       Time.timeScale = 1;
       gui.ContinueGame();
     }
    public void UpdateGui(){
       gui.UpdateGui();
     }
    public void AddPlayerCash(double cash){
        playerCash+=cash;
        gui.UpdateGui();
    }
    public void GameOver() {
        isGameOver = true;
        Time.timeScale = 0;
        gui.GameOver();
    }
    public void QuitGame() {
        Application.Quit();
    }
    public void RestartGame() {
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        isPaused = false;

        ContinueGame();
    }
    public void ActivateBoss (){
        StartCoroutine(Boss()); 
    }
    IEnumerator Boss() {
        hazardSpawner.SetActive(false);
        yield return new WaitForSeconds(30);

        yield return new WaitForSeconds(10);
        boss.SetActive(true);
    }

}
