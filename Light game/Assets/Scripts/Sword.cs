using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public Collider2D sword;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        sword = gameObject.GetComponent<Collider2D>();
        EventManager.StartListening("Lightdisable", swordOn);
        sword.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            sword.enabled = true;
            transform.Rotate(0.0f, 0.0f, -60.0f);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            sword.enabled = false;
            transform.Rotate(0.0f, 0.0f, 60.0f);
        }
    }
    void swordOff()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        EventManager.StartListening("Lightdisable", swordOn);
        EventManager.StopListening("Lightenable", swordOff);

    }
    void swordOn()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        EventManager.StartListening("Lightenable", swordOff);
        EventManager.StopListening("Lightdisable", swordOn);
    }

}

