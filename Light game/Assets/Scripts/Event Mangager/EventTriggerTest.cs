using UnityEngine;
using System.Collections;

public class EventTriggerTest : MonoBehaviour
{
    public float mindist = 15.0f;
    public GameObject monster;

    /* void Update()
     {
         if (Vector3.Distance(transform.position, monster.transform.position) <= mindist)
          {
              EventManager.TriggerEvent("test");
          }
    }*/
    void OnTriggerEnter2D(Collider2D col)
    {
        EventManager.TriggerEvent("test");
        if (col.gameObject.CompareTag("Light off"))
        {
            EventManager.TriggerEvent("Lightdisable");
        }
        if (col.gameObject.CompareTag("Light on"))
        {
            EventManager.TriggerEvent("Lightenable");
        }
    }
   /** void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Light off"))
        {
            EventManager.TriggerEvent("Lightenable");
        }

    }**/


}
