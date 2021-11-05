using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject gameObject = null;
    Rotation rotation;
    void Start()
    {
        rotation = gameObject.GetComponent<Rotation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            rotation.RotationObject();
        }
    }
}
