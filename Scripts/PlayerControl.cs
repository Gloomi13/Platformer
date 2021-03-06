using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private ContactFilter2D _filter;
    [SerializeField] private float _powerJump;
    [SerializeField] private float _speed;

    private readonly RaycastHit2D[] _resulst = new RaycastHit2D[1];

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerJump();
        }
    }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = new Vector2(Input.GetAxis("Horizontal") * _speed, _rigidbody2D.velocity.y);
    }

    private void PlayerJump()
    {
        var collisionCoont = _rigidbody2D.Cast(transform.up, _filter, _resulst, -0.1f);

        if (collisionCoont == 1)
        {
            _rigidbody2D.AddForce(transform.up * _powerJump, ForceMode2D.Impulse);

        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent<EnemyMovement>(out EnemyMovement enemyMovement))
        {
            Invoke(nameof(ReloadLevel), 0.2f);
        }
    }

    private void ReloadLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

}
