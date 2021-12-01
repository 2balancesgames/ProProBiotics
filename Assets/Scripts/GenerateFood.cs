using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateFood : MonoBehaviour
{
    public GameObject food;
    public int howMany = 3;

    public List<int> foodVariety ;

    private List<Sprite> foodPictures ;

    void Start()
    {
        foodPictures = GameManager.instance.foodSprites;
    }

    public void Generate()
    {
        for (int i = 0 ; i < howMany; i++ ){
            int rand = Random.Range(0,foodVariety.Count);
            Debug.Log("Rand "+ rand);
            Debug.Log("Food variety " + foodVariety.Count);
            int food_id = foodVariety[rand];
            Debug.Log("Generated Food _ " + food_id );
            GameObject go = Instantiate(food, transform.position, Quaternion.identity);
            go.name = "food_"+ food_id;
            go.GetComponent<SpriteRenderer>().sprite = foodPictures[food_id];
            Destroy(go, 6);
        }
    }

}
