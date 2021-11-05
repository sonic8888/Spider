using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ����������� ������� �� ��������� ��������� � ����� �� �����.
/// ���� �������� ����� ����������� ��� ������ �������� �������: EndGameObject
/// �� ����� ������� ������� �����: InitEndPoint() � 
/// ����� �����: StartOver().
/// ���� �������� ����� ����������� ��� ������ �������: EndPoint
/// �� ������ �������� �����: StartOver().
/// </summary>
public class Move : MonoBehaviour
{
    /// <summary>
    /// �������� ����� �����������
    /// </summary>
    public Vector3 EndPoint;
    /// <summary>
    /// �������� ����� ����������� ����������� ��� ������ �������� �������
    /// </summary>
    public GameObject EndGameObject;
    /// <summary>
    /// �������� �����������
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
    /// ���������� ������������� ������
    /// ���� ����� � ��� ���������� �������������
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
    /// ��������� �������� ����� �����������
    /// ��� ������ �������� �������
    /// </summary>
    public void InitEndPoint()
    {
        EndPoint = EndGameObject.transform.position;
    }

}