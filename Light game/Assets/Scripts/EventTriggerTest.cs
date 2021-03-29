using UnityEngine;
using System.Collections;

public class EventTriggerTest : MonoBehaviour
{
    public float mindist = 15.0f;
    public GameObject monster;

    void Update()
    {
       if (Vector3.Distance(transform.position, monster.transform.position) <= mindist)
        {
            EventManager.TriggerEvent("test");
        }
    }
}
