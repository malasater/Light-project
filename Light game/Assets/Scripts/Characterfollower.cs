using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characterfollower : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject character;
    private Vector3 offset;
    public float speed = 1.0f;
    private Vector3 target;
    void Start()
    {
        offset = transform.position - character.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        target = character.transform.position + offset;

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        //transform.position = character.transform.position + offset;
        
    }
}
