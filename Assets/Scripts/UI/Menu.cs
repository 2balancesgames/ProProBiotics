using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    // public int acid_idx= 0;
    public Image acidImage;
    public Text acidName;
    public Image foodImage;
    public Text foodPrice;
    public Text foodAmount;
    public Text acidLevel;
    public Text acidEffect;
    public Text gasLevel;
    public Text gasEffect;
    public Text energyLevel;
    public Text energyEffect;

    
    public void OnArrowClick(bool right)
    {
        if (right){
            GameManager.instance.acid_idx +=1;
        } else {
            GameManager.instance.acid_idx += (GameManager.instance.acidSprites.Count - 1);
        }
        GameManager.instance.acid_idx %= GameManager.instance.acidSprites.Count;
        UpdateAcid();
    }

    private void UpdateAcid()
    {
        int acid_idx = GameManager.instance.acid_idx;
        acidName.text = GameManager.instance.acidNames[acid_idx];
        acidImage.sprite = GameManager.instance.acidSprites[acid_idx];
        foodImage.sprite = GameManager.instance.foodSprites[acid_idx];
        foodPrice.text = GameManager.instance.foodPrices[acid_idx].ToString();
        acidEffect.text = GameManager.instance.acidAcid[acid_idx].ToString();
        gasEffect.text = GameManager.instance.acidGas[acid_idx].ToString();
        energyEffect.text = GameManager.instance.acidEnergy[acid_idx].ToString();
        foodAmount.text = GameManager.instance.foodAmount[acid_idx].ToString();
    }

    public void UpdateStatus()
    {
        foodAmount.text = GameManager.instance.foodAmount[GameManager.instance.acid_idx].ToString();
        acidLevel.text = GameManager.instance.acidLevel.ToString();
        gasLevel.text = GameManager.instance.gasLevel.ToString();
        energyLevel.text = GameManager.instance.energyLevel.ToString();
        
    }

}
