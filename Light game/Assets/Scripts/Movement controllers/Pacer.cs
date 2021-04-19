using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pacer : MonoBehaviour
{
    public float dist;
    public float speed;
    private Vector3 startPoint;
    private bool eastflag;
    // Start is called before the first frame update
    void Start()
    {
        startPoint = transform.position;
        eastflag = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (eastflag == true)
        {

            //transform.position.Set(transform.position.x + (speed * Time.deltaTime), transform.position.y, transform.position.z);
            transform.Translate(Vector3.right *Time.deltaTime*speed);
            if (transform.position.x - startPoint.x >= dist)
            {
                
                eastflag = false;
            }
        }
        if (eastflag == false)
        {
            //transform.position.Set(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
            transform.Translate(Vector3.left* Time.deltaTime * speed);
            if (transform.position.x <= startPoint.x)
            {
                eastflag = true;
            }

        }
    }
}
