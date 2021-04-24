using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public Collider2D sword;
    public SpriteRenderer swordsprite;
    private bool rightflag;

    // Start is called before the first frame update
    void Start()
    {
        swordsprite = gameObject.GetComponentInChildren<SpriteRenderer>();
        swordsprite.enabled = false;
        sword = gameObject.GetComponentInChildren<Collider2D>();
        EventManager.StartListening("Lightdisable", swordOn);
        EventManager.StartListening("flipsword", flipSword);
        //EventManager.StartListening("flipswordleft", flipSwordLeft);
        sword.enabled = false;
        rightflag = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            sword.enabled = true;
            //transform.Translate(0.5f, -0.9f, 0.0f);
            if (rightflag)
            {
                transform.Rotate(0.0f, 0.0f, -60.0f);
            }
            if (!rightflag)
            {
                transform.Rotate(0.0f, 0.0f, 60.0f);
            }


        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            sword.enabled = false;
            if (rightflag)
            {
                transform.Rotate(0.0f, 0.0f, 60.0f);
            }
            if (!rightflag)
            {
                transform.Rotate(0.0f, 0.0f, -60.0f);
            }
            //transform.Rotate(0.0f, 0.0f, 60.0f);
            //transform.Translate(-0.5f, 0.9f, 0.0f);
        }
    }
    void swordOff()
    {
        swordsprite.enabled = false;
        EventManager.StartListening("Lightdisable", swordOn);
        EventManager.StopListening("Lightenable", swordOff);

    }
    void swordOn()
    {
        swordsprite.enabled = true;
        EventManager.StartListening("Lightenable", swordOff);
        EventManager.StopListening("Lightdisable", swordOn);
    }
    void flipSword()
    {
        Vector3 temp = transform.localScale;
        temp.x = temp.x * -1.0f;
        transform.localScale = temp;
        rightflag = !rightflag;
    }
    void flipSwordLeft()
    {
        rightflag = false;
        //transform.Translate(-1.1f, 0.0f, 0.0f);
        transform.Rotate(0.0f, 0.0f, 60.0f);
        
    }


}

