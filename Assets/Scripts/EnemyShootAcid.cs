using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class EnemyShootAcid : MonoBehaviour
{
    public AcidDrop acidDrop;
    public float speed = 5;

    public float shootInterval = 1f;

    private float lastShootTime;

    void Start()
    {
        lastShootTime = Time.time;
    }
    public void Update()
    {
        if (GameManager.instance.gameIsOver || Time.time - lastShootTime < shootInterval) return;
        lastShootTime = Time.time;
        // GameManager.instance.TakeThreeImpact(1,0,0);
        Vector3 shootDirection = Motions.GetARandomDirection();
        AcidDrop ad = Instantiate(acidDrop, gameObject.transform.position, Quaternion.identity);
        ad.SetDirection(shootDirection.x, shootDirection.y);
        ad.transform.rotation = Quaternion.LookRotation(Vector3.forward, shootDirection);
        ad.SetSpeed(4);
    }

}
