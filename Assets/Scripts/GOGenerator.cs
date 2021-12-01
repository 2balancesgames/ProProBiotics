using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOGenerator : MonoBehaviour
{
    private Transform playerTransform;
    public List<GameObject> gameObjects;
    public List<int> percentages;

    private float generateChance = 6f;
    private int radius = 15;

    void Start()
    {
        playerTransform = GameManager.instance.player.transform; 
    }
    void Update()
    {
        if (GameManager.instance.gameIsOver) Destroy(gameObject);
        float rand = Random.Range(0f, 1000f);
        if (rand < generateChance){
            GenerateGO();
        }
    }

    private void GenerateGO(){
        int rand = Random.Range(0, 100);
        int idx = 0;
        int bar = 0;
        for (int i =0; i< percentages.Count; i++ ){
            bar += percentages[i];
            if ( rand <= bar) {
                break;
            } else {
                idx += 1;
            }
        }
        Vector3 location = Motions.GetARandomDirection() * radius + playerTransform.position;
        Instantiate(gameObjects[idx], location , Quaternion.identity);
    }
}
