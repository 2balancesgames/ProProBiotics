using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOGenerator : MonoBehaviour
{
    private Transform playerTransform;
    public List<GameObject> gameObjects;
    private float generateChance = 10f;
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
        int rand = Random.Range(0, gameObjects.Count);
        Vector3 location = Motions.GetARandomDirection() * radius + playerTransform.position;
        Instantiate(gameObjects[rand], location , Quaternion.identity);
    }
}
