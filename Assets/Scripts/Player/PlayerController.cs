using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Transform _leftBorder; //левая граница бокса игрока
    [SerializeField]
    private Transform _rightBorder; //правая граница бокса игрока

    [SerializeField]
    private float _speed; //скорость игрока

    private bool _isMovingRight; //направление движения игрока
    private float _oneWayTime; //время прохождения пути
    private float _currentTime; //текущее время
    
    private void Awake()
    {
        _oneWayTime = Vector3.Distance(_leftBorder.position, _rightBorder.position) / _speed;
        _currentTime = Vector3.Distance(_leftBorder.position, transform.position) /  _speed;
    }
    
    private void Move()
    {
        _currentTime += _isMovingRight ? Time.deltaTime : -Time.deltaTime;

        var progress = Mathf.PingPong(_currentTime, _oneWayTime) / _oneWayTime;
        transform.position = Vector3.Lerp(_leftBorder.position, _rightBorder.position, progress);
    }
    
    private void Update()
    {
        Move();
    }
    
    public void ChangeDirection()
    {
        _isMovingRight = !_isMovingRight;
    }
}
