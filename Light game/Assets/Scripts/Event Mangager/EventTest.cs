using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class EventTest : MonoBehaviour
{

    
    //hi
  

    void OnEnable()
    {
        EventManager.StartListening("test", someListener);

        EventManager.StartListening("disable", turnOff);
    }

    void OnDisable()
    {
        EventManager.StopListening("test", someListener);

    }

    void someListener()
    {
        Debug.Log("hi");
        //EventManager.StopListening("test", someListener);
    }
    void turnOff()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        EventManager.StartListening("enable", turnOn);
        EventManager.StopListening("disable", turnOff);

    }
    void turnOn()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        EventManager.StartListening("disable", turnOff);
        EventManager.StopListening("enable", turnOn);
    }
        
}
