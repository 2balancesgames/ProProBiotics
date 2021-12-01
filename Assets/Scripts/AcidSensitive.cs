using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidSensitive : Collidable
{
    private Mortal mortalSoul;

    public string nameMatch;

    public int sensitivity;
    SpriteRenderer renderer;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        mortalSoul = GetComponent<Mortal>();
        renderer = GetComponent<SpriteRenderer>();
    }

    protected override void OnCollide(Collider2D coll){
        if (coll.name.StartsWith(nameMatch)) {
            Destroy(coll.gameObject);
            if (mortalSoul) {
                mortalSoul.TakeDamage(new Damage{
                    damageAmount = sensitivity,
                    origin = coll.transform.position,
                    pushForce = 0.3f
                });
            } else if (gameObject.name =="Player") {
                GameManager.instance.TakeThreeImpact(sensitivity, sensitivity, -sensitivity);
            }
            StartCoroutine(DamageEffectSequence(renderer, Color.white, Color.red, 0.5f, 0.5f));
        }
    }

    IEnumerator DamageEffectSequence(SpriteRenderer sr, Color originColor, Color dmgColor, float duration, float delay)
    {
        // tint the sprite with damage color
        sr.color = dmgColor;

        // you can delay the animation
        yield return new WaitForSeconds(delay);

        // lerp animation with given duration in seconds
        for (float t = 0; t < 1.0f; t += Time.deltaTime/duration)
        {
            sr.color = Color.Lerp(dmgColor, originColor , t);

            yield return null;
        }

        // restore origin color
        sr.color = originColor;
    }
}
