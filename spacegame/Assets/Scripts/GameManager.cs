using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
       
       SharedInstance = this;
       player= GameObject.FindWithTag("Player"); 
       playerScript=player.transform.GetComponent<Player>();
       
    }

    // Update is called once per frame
    void Update()
    {
        time=Time.time;
        playerShips=playerScript.ships;
        
        if(playerShips<=0){
          	Debug.Log("Game Over");
        }
    }
    void FixedUpdate(){
         if(isPaused==true&&Input.GetKey("c")){
           ContinueGame();
           
         }
         if(Input.GetKey("p")){
           PauseGame();
         }
    }
    void PauseGame(){
       isPaused=true;
       Time.timeScale = 0;
     }
    void ContinueGame(){
       isPaused=false;
       Time.timeScale = 1;
     }
    public void UpdateGui(){
       gui.UpdateGui();
     }
}
