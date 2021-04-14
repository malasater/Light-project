using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class EventTest : MonoBehaviour
{

    
    //hi
  

    void OnEnable()
    {
        EventManager.StartListening("test", someListener);

        EventManager.StartListening("Lightdisable", turnOff);
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
        EventManager.StartListening("Lightenable", turnOn);
        EventManager.StopListening("Lightdisable", turnOff);

    }
    void turnOn()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        EventManager.StartListening("Lightdisable", turnOff);
        EventManager.StopListening("Lightenable", turnOn);
    }
        
}
