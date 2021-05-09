using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Character
{
    //public Inventory inventoryPrefab;
    //Inventory inventory;

    public float hitPoints;

    //public HealthBar healthBarPrefab;
    //HealthBar healthBar;

    private void OnEnable()
    {
        ResetCharacter();
    }

    /**void OnTriggerEnter2D(Collider2D collision)
     {
         if (collision.gameObject.CompareTag("CanBePickedUp"))
         {
             Item hitObject = collision.gameObject.GetComponent<Consumable>().item;

             if (hitObject != null)
             {
                 bool shouldDisappear = false;

                 switch (hitObject.itemType)
                 {
                     case Item.ItemType.COIN:
                         shouldDisappear = inventory.AddItem(hitObject);
                         break;
                     case Item.ItemType.HEALTH:
                         shouldDisappear = AdjustHitPoints(hitObject.quantity);
                         break;
                     default:
                         break;
                 }

                 if (shouldDisappear)
                 {
                     collision.gameObject.SetActive(false);
                 }
             }
         }
     }**/
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("floor"))
        {
            KillCharacter();
        }
        if (collision.gameObject.CompareTag("scenechange"))
        {
            SceneManager.LoadScene(collision.GetComponent<SceneChanger>().sceneName);
        }

        if (collision.gameObject.CompareTag("Health Token"))
        {
            if (hitPoints < maxHitPoints)
            {
                HealthToken token = collision.gameObject.GetComponent<HealthToken>();
                collision.gameObject.SetActive(false);
                hitPoints += token.hp;

            }


        }
    }

    public bool AdjustHitPoints(int amount)
    {
        if (hitPoints< maxHitPoints)
        {
            hitPoints = hitPoints + amount;
            return true;
        }
        return false;
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

    public override void KillCharacter()
    {
        EventManager.TriggerEvent("LunaDead");
        base.KillCharacter();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //Destroy(healthBar.gameObject);
        //Destroy(inventory.gameObject);
    }

    /**public override void ResetCharacter()
    {
        inventory = Instantiate(inventoryPrefab);
        healthBar = Instantiate(healthBarPrefab);
        healthBar.character = this;

        hitPoints.value = startingHitPoints;
        GetComponent<SpriteRenderer>().color = Color.white;
    }**/
}