using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private float gameStartTime;
    public Animator ggAnim;
    public GameOver gameOver;
    public Text AGEText;
    public bool gameIsOver = false;
    
    private void Awake(){
        if (GameManager.instance != null){
            GameManager.instance.Reset();
            Destroy(gameObject);
            return;
        }
        PlayerPrefs.DeleteAll();
        instance = this;
        gameStartTime = Time.time;
        // SceneManager.sceneLoaded += LoadState;
        // DontDestroyOnLoad(gameObject);
    }

    public FloatingTextManager floatingTextManager;
    public List<string> acidNames;
    public List<Sprite> acidSprites;
    public List<Sprite> foodSprites;
    public List<int> foodPrices;
    public List<int> foodAmount;

    public List<int> acidAcid;
    public List<int> acidGas;
    public List<int> acidEnergy;
    public int acidLevel;
    public int gasLevel;
    public int energyLevel;

    public int acid_idx;
    public Player player;

    public void Reset(){
        gameStartTime = Time.time;
    }
    public void PauseGame(){
        Time.timeScale = 0;
    }

    public void ContinueGame(){
        Time.timeScale = 1;
    }

    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration){
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }
    public bool TakeAcidEffect(){
        if (foodAmount[acid_idx]<foodPrices[acid_idx]) {
            ShowText("Not enough food to generate acid!", 30, Color.red, player.transform.position + new Vector3(0, 0.5f, 0), new Vector3(0, 30, 0), 3f);
            return false;
        } 
        foodAmount[acid_idx]-=foodPrices[acid_idx];
        TakeThreeImpact(acidAcid[acid_idx], acidGas[acid_idx], acidEnergy[acid_idx]);
        return true;
    }

    public void TakeThreeImpact(int acidImpact, int gasImpact, int energyImpact){
        acidLevel += acidImpact;
        gasLevel += gasImpact;
        energyLevel += energyImpact;
        AGEText.text = "Acid: "+ acidLevel + "  Gas: "+ gasLevel + "  Energy: "+ energyLevel;
        CheckIfGameOver();
    }

    private void UpdateAGEText(){

    }

    private void CheckIfGameOver(){
        if (gameIsOver) return;
        if (acidLevel > 100 ){
            gameIsOver = true;
            gameOver.UpdateEndGutStat("Acid level too high");
        } else if (acidLevel< -100){
            gameIsOver = true;
            gameOver.UpdateEndGutStat("Acid level too low");
        } else if (gasLevel > 100){
            gameIsOver = true;
            gameOver.UpdateEndGutStat("Gas level too high");
        } else if (gasLevel < -100){
            gameIsOver = true;
            gameOver.UpdateEndGutStat("Gas level too low");
        } else if (energyLevel > 100){
            gameIsOver = true;
            gameOver.UpdateEndGutStat("Energy level too high");
        } else if (energyLevel < -100){
            gameIsOver = true;
            gameOver.UpdateEndGutStat("Energy level too low");
        }
        if (gameIsOver){
            int timePassed = (int)(Time.time - gameStartTime);
            gameOver.UpdateSurvialTime( timePassed.ToString() + " Seconds");
            ggAnim.SetTrigger("show");
        }
    }


    
}
