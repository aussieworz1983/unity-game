using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public Player playerScript;
    public int playerShips;
    public bool paused;
    
    // Start is called before the first frame update
    void Start()
    {
       player= GameObject.FindWithTag("Player"); 
       playerScript=player.transform.GetComponent<Player>();
       
    }

    // Update is called once per frame
    void Update()
    {
        playerShips=playerScript.ships;
        
        if(playerShips<=0){
          	Debug.Log("Game Over");
        }
    }
    void PauseGame(){
       Time.timeScale = 0;
     }
    void ContinueGame(){
       Time.timeScale = 1;
     }
}
