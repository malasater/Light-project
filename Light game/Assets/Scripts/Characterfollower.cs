using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characterfollower : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject character;
    private Vector3 rightoffset;
    private Vector3 leftoffset;
    private bool leftflag = false;
    public float speed = 1.0f;
    private Vector3 target;
    private float initDist;
    private Vector3 newpos;
    void Start()
    {
        leftoffset = transform.position - character.transform.position;
        rightoffset.Set(-(leftoffset.x), leftoffset.y, leftoffset.z);
        initDist = Vector3.Distance(transform.position, character.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (character == null)
        {
            Destroy(gameObject);
        }
        if (transform.position == (character.transform.position + leftoffset))
        {
            leftflag = false;
                
        }
        if (transform.position == (character.transform.position + rightoffset))
        {
            leftflag = true;
        }
        if (leftflag)
        {
            target = character.transform.position + leftoffset;

            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
        if (!leftflag)
        {
            target = character.transform.position + rightoffset;

            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }

       

        //transform.position = character.transform.position + offset;

    }

   
}
