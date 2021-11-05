using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// перемещение обьекта из исходного положения в какую то точку.
/// если конечная точка указывается при помощи игрового обьекта: EndGameObject
/// то нужно вначале вызвать метод: InitEndPoint() и 
/// затем метод: StartOver().
/// если конечная точка указывается при помощи вектора: EndPoint
/// то просто вызываем метод: StartOver().
/// </summary>
public class Move : MonoBehaviour
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
    private Vector3 _direction;
    private Vector3 _directionSpeed;
    private Vector3 _lenghtPath;
    private bool _isLock;


    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;




    void Start()
    {
        if (EndGameObject == null && EndPoint == Vector3.zero)
        {
            _isLock = false;
            return;
        }
        else
        {
            if (EndGameObject != null)
            {
                InitEndPoint();
            }
        }
        InitData();




    }


    void Update()
    {
        if (_isLock)
        {
            _lenghtPath = EndPoint - transform.position;
            _lenghtPath = _lenghtPath.normalized;
            float dt = Vector3.Dot(_direction, _lenghtPath);
            if (dt > 0)
            {
                transform.Translate(_directionSpeed * Time.deltaTime);
            }
            else
            {
                transform.position = EndPoint;
                _isLock = false;
            }
        }
     




    }
    /// <summary>
    /// производит инициализацию данных
    /// втом числе и для повторного использования
    /// </summary>
    public void StartOver()
    {
        InitData();

    }
    private void InitData()
    {
        if (EndPoint == transform.position)
            return;
        _direction = EndPoint - transform.position;
        _direction = _direction.normalized;
        _directionSpeed = _direction * speed;
        _isLock = true;
    }
    /// <summary>
    /// указываем конечную точку перемещения
    /// при помощи игрового обьекта
    /// </summary>
    public void InitEndPoint()
    {
        EndPoint = EndGameObject.transform.position;
    }

}