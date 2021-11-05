using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    /// <summary>
    /// повернуть на 180 градусов
    /// </summary>
    private Vector3 faceUp;
    private Vector3 faceBack;
    /// <summary>
    /// повернуть на -180 градусов
    /// </summary>
    private Quaternion rotationUp;
    private Quaternion zero;
    public Quaternion rotationTo;
    public float SpeedRotation = 0.1f;
    private bool _isLock = true;
    public bool IsFaceBack =true;

    // Start is called before the first frame update
    void Start()
    {
        faceUp = Vector3.zero;
        faceBack = new Vector3(0, 0, 180);
        rotationTo = transform.rotation;
        rotationTo.eulerAngles = faceBack;
        //Quaternion quaternion = transform.rotation;
        //Debug.Log(quaternion);
    }

    // Update is called once per frame
    void Update()
    {
        if (_isLock)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, rotationTo, Time.deltaTime * SpeedRotation);
            if (transform.rotation.eulerAngles== faceBack)
            {
                _isLock = false;
                IsFaceBack = false;
            }
        }
        //Debug.Log(transform.rotation.eulerAngles);

    }
    public void RotationObject()
    {
        if (!IsFaceBack)
        {
            _isLock = true;
            IsFaceBack = true;
            rotationTo.eulerAngles = faceUp;
        }
        else
        {
            _isLock = true;
            IsFaceBack = true;
            rotationTo.eulerAngles = faceBack;
        }
    }
}
