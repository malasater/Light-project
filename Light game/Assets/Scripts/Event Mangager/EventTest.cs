using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class EventTest : MonoBehaviour
{

    

  

    void OnEnable()
    {
        EventManager.StartListening("test", someListener);
        
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
        
}
