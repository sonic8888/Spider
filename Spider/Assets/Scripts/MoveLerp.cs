using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
/// <summary>
/// для перемещения используется функция Lerp
/// что дает притормаживание при приближении к конечно точке
/// </summary>
public class MoveLerp : MonoBehaviour
{
    /// <summary>
    /// конечная точка перемещения
    /// </summary>
    public Vector3 EndPoint;
    /// <summary>
    /// конечная точка перемещения указываемая при помощи игрового обьекта
    /// </summary>
    public GameObject EndGameObject;
    /// <summary>
    /// скорость перемещения
    /// </summary>
    public float speed = 1f;
    /// <summary>
    /// дистанция при которой считается что обьект достиг конечной точки передвижения.
    /// </summary>
    public float Distancia=0.01f;
    /// <summary>
    /// переменная прекращает движение при достижении конечной точки передвижения.
    /// </summary>
    public bool IsEndPath = true;
 


    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;




    void Start()
    {
        if (EndGameObject!=null)
        {
            EndPoint = EndGameObject.transform.position;
        }
        // Keep a note of the time the movement started.
        startTime = Time.time;
        // Calculate the journey length.
        journeyLength = Vector3.Distance(transform.position, EndPoint);
    }


    void Update()
    {
        if (IsEndPath)
        {
            // Distance moved equals elapsed time times speed..
            float distCovered = (Time.time - startTime) * speed;
            // Fraction of journey completed equals current distance divided by total distance.
            float fractionOfJourney = distCovered / journeyLength;

            // Set our position as a fraction of the distance between the markers.
            transform.position = Vector3.Lerp(transform.position, EndGameObject.transform.position, fractionOfJourney);
            if (Vector3.Distance(transform.position, EndPoint) < Distancia)
            {
                transform.position = EndPoint;
                IsEndPath = false;
            } 
        }
    }
    /// <summary>
    /// инициализирует конечную точку и запускает передвижение
    /// </summary>
    /// <param name="gameObject"></param>
    public void InitEndPoint(GameObject gameObject)
    {
        EndPoint = gameObject.transform.position;
        startTime = Time.time;
        journeyLength = Vector3.Distance(transform.position, EndPoint);
        IsEndPath = true;
    }
    /// <summary>
    /// инициализирует конечную точку и запускает передвижение
    /// </summary>
    /// <param name="vector3"></param>
    public void InitEndPoint(Vector3 vector3)
    {
        EndPoint = vector3;
        startTime = Time.time;
        journeyLength = Vector3.Distance(transform.position, EndPoint);
        IsEndPath = true;
    }




}
