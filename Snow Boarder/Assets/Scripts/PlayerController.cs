using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float torqueAmount = 1.0f;
    [SerializeField] private float boostSpeed = 30f;
    [SerializeField] private float baseSpeed = 20f;
    
    private Rigidbody2D _rb2d;
    private SurfaceEffector2D _surfaceEffector2D;
    private bool _canMove = true;

    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    void Update()
    {
        if (_canMove)
        {
            RotatePlayer();
            RespondToBoost();
        }
    }

    private void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _rb2d.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            _rb2d.AddTorque(-torqueAmount);
        }
    }

    private void RespondToBoost()
    {
        _surfaceEffector2D.speed = Input.GetKey(KeyCode.UpArrow) ? boostSpeed : baseSpeed;
    }

    public void DisableControls()
    {
        _canMove = false;
    }
}
