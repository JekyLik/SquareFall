using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField]
    private UnityEvent _playerDied;
    
    [SerializeField]
    private UnityEvent _squareCollected;
    
    [SerializeField]
    private float _scaleChangeDuration;
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag(GlobalConstants.ALLY_TAG))
        {
            collider.enabled = false;//выключим коллайдер, чтобы коллизия не произошла 2 раза.

            collider.transform
                .DOScale(Vector3.zero, _scaleChangeDuration)//изменим скейл до 0
                .OnComplete(() =>
                {
                    _squareCollected.Invoke();
                    Destroy(collider.gameObject);
                });//по окончанию анимации разрушим объект
        }

        if (collider.CompareTag(GlobalConstants.ENEMY_TAG))
        {
            _playerDied.Invoke();
            Destroy(collider.gameObject);
        }
    }
}
