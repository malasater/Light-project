using System.Collections;
using UnityEngine;

public class Enemy : Character
{
    public int damageStrength;

    Coroutine damageCoroutine;

    float hitPoints;

    private void OnEnable()
    {
        ResetCharacter();
    }

    public override void ResetCharacter()
    {
        hitPoints = startingHitPoints;
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    public IEnumerator DamageCharacter(int damage, float interval)
    {
        while (true)
        {
            StartCoroutine(FlickerCharacter());

            hitPoints = hitPoints - damage;

            if (hitPoints <= float.Epsilon)
            {
                KillCharacter();
                break;
            }

            if (interval > float.Epsilon)
            {
                yield return new WaitForSeconds(interval);
            }
            else
            {
                break;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Because only enemies can only hurt the player
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();

            // Only call DamageCharacter on the player if we don't currently have a DamageCharacter() Coroutine running.
            if (damageCoroutine == null)
            {
                damageCoroutine = StartCoroutine(player.DamageCharacter(damageStrength, 1.0f));
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (damageCoroutine != null)
            {
                StopCoroutine(damageCoroutine);
                damageCoroutine = null;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("sword"))
        {
            Enemy enemy = gameObject.GetComponent<Enemy>();
            if (damageCoroutine == null)
            {
                damageCoroutine = StartCoroutine(enemy.DamageCharacter(damageStrength, 1.0f));
            }
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("sword"))
        {
            if (damageCoroutine != null)
            {
                StopCoroutine(damageCoroutine);
                damageCoroutine = null;
            }
        }
    }
}