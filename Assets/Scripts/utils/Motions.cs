using UnityEngine;
public class Motions {
    // public static 
    public static Vector3 GetDirectionToMouse(Transform transform){
        Vector3 shootDirection;
        shootDirection = Input.mousePosition;
        shootDirection.z = 0.0f;
        shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
        shootDirection = shootDirection-transform.position;
        shootDirection = Vector3.Normalize(shootDirection);
        return shootDirection;
    }

    public static Vector3 GetARandomDirection(){
        float angle = 2f * Mathf.PI * Random.Range(0f, 360f) / 360f;
        return new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);
    }
}