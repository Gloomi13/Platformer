using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
[SerializeField] private BoxCollider2D _boxCollider2D;
private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.TryGetComponent<PlayerControl>(out PlayerControl playerControl))
         { 
            Destroy(_boxCollider2D.gameObject);
         }
    }   
}