using System;
using UnityEngine;

public class RigidbodyCharacter : MonoBehaviour
{
    public float Speed = 5f;
    public float JumpHeight = 2f;
    public float GroundDistance = 0.2f;
    public float DashDistance = 5f;
    public LayerMask Ground;

    private Rigidbody _body;
    private Vector3 _inputs = Vector3.zero;
    private bool _isGrounded = true;
    private Transform _groundChecker;
    private bool walking;
    private Animator _anim;

    void Start()
    {
        _anim = GetComponent<Animator>();
        _body = GetComponent<Rigidbody>();
        _groundChecker = transform.GetChild(0);
    }

    void Update()
    {
        float h = Input.mousePosition.x - Screen.width / 2f;
        float v = Input.mousePosition.y - Screen.height / 2f;

        float yRotation = (float) Math.Atan2(h, v);
        Quaternion target = Quaternion.Euler(0, yRotation * 60f, 0);

        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 10f);

        _isGrounded = Physics.CheckSphere(_groundChecker.position, GroundDistance, Ground, QueryTriggerInteraction.Ignore);

        _inputs = Vector3.zero;
        _inputs.x = Input.GetAxis("Horizontal");
        _inputs.z = Input.GetAxis("Vertical");
        _inputs = Vector3.ClampMagnitude(this._inputs, 1f);
        //walking andimation

        if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d")
            || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.UpArrow)
            || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            walking = true;
        }

        else walking = false;

        _anim.SetBool("Walk", walking);

        if (_inputs != Vector3.zero)
            transform.TransformVector(_inputs);

        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _body.AddForce(Vector3.up * Mathf.Sqrt(JumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
        }

        // Was causing an error in console

        // if (Input.GetButtonDown("Dash"))
        // {
        //     Vector3 dashVelocity = Vector3.Scale(transform.forward, DashDistance * new Vector3((Mathf.Log(1f / (Time.deltaTime * _body.drag + 1)) / -Time.deltaTime), 0, (Mathf.Log(1f / (Time.deltaTime * _body.drag + 1)) / -Time.deltaTime)));
        //     _body.AddForce(dashVelocity, ForceMode.VelocityChange);
        // }
    }


    void FixedUpdate()
    {
        _body.MovePosition(_body.position + _inputs * Speed * Time.fixedDeltaTime);
    }
}