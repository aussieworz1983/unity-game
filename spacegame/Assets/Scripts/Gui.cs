using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Gui : MonoBehaviour
{
    
    public Canvas canvas;
    public Text scoreText;
    public Text cashText;
    public Text shipsText;
    public Text mercCostText;
    public Text timeText;
    public Text centerText;
   
    // Start is called before the first frame update
    void Start()
    {
        
       canvas=gameObject.GetComponent<Canvas>(); 
       
       foreach(Text txt in GetComponentsInChildren<Text>()){
            if(txt.name=="PlayerShips"){
                shipsText=txt;
             }
            if(txt.name=="PlayerScore"){
                scoreText=txt;
            }
            if(txt.name=="MercCost"){
                mercCostText=txt;
            }
            if(txt.name=="TimeText"){
                timeText=txt;
            }
            if(txt.name=="PlayerCash"){
                cashText=txt;
            }
            if(txt.name=="CenterText"){
                centerText=txt;
            }
             Debug.Log(txt.name);
        }
        
        StartCoroutine(Wait());
        
    }

    // Update is called once per frame
    void Update()
    {
       timeText.text="Time Played: " +GameManager.SharedInstance.time;
    }
    public void UpdateGui(){
        StartCoroutine(Wait());
    }
     IEnumerator Wait(){
       
       yield return new WaitForSeconds(1);
       shipsText.text="Ships: " +GameManager.SharedInstance.playerShips;
        scoreText.text="Score: " +GameManager.SharedInstance.playerScore;
        cashText.text="Cash: " +GameManager.SharedInstance.playerCash;
        mercCostText.text="Cost: " +GameManager.SharedInstance.cashLost;
     }
     public void PauseScreen (){
        centerText.text="Game Is Paused Press C To Continue q to quit";

     }
     public void ContinueGame(){
        centerText.text="";
      }
     public void GameOver() {
        centerText.text = "Game Over press s to restart q to quit";
    }


}
