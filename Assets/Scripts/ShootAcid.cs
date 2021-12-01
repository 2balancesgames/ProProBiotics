using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class ShootAcid : MonoBehaviour
{
    public AcidDrop acidDrop;
    public float speed = 4;

    public void Update()
    {
        if ( Input.GetButtonDown("Fire1") && ! EventSystem.current.IsPointerOverGameObject())
        {
            bool canShoot = GameManager.instance.TakeAcidEffect();
            if(!canShoot) return;
            Vector3 shootDirection = Motions.GetDirectionToMouse(transform);
            AcidDrop ad = Instantiate(acidDrop, transform.position, Quaternion.identity);
            int acid_idx = GameManager.instance.acid_idx;
            ad.name = GameManager.instance.acidNames[acid_idx];
            SpriteRenderer renderer =  ad.GetComponent<SpriteRenderer>();
            renderer.sprite = GameManager.instance.acidSprites[acid_idx];
            ad.SetDirection(shootDirection.x, shootDirection.y);
            ad.transform.rotation = Quaternion.LookRotation(Vector3.forward, shootDirection);
            ad.SetSpeed(4);
        }
    }

}
