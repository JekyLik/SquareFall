using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    private UnityEvent _directionChanged;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _directionChanged.Invoke();
        }

        if (Input.touches.Length > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                _directionChanged.Invoke();
            }
        }
    }
}
