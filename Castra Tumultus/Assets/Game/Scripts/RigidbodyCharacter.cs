using System.Collections;
using System.Collections.Generic;
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
    private Health _health;
    private bool isDead = false;

    void Start()
    {
        _health = GetComponent<Health>();
        _anim = GetComponent<Animator>();
        _body = GetComponent<Rigidbody>();
        _groundChecker = transform.GetChild(0);
    }

    void Update()
    {
        if (isDead == false)
        {
            _isGrounded = Physics.CheckSphere(_groundChecker.position, GroundDistance, Ground, QueryTriggerInteraction.Ignore);

            _inputs = Vector3.zero;
            _inputs.x = Input.GetAxis("Horizontal");
            _inputs.z = Input.GetAxis("Vertical");
            _inputs = Vector3.ClampMagnitude(this._inputs, 1f);
            //walking animation

            if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d")
                || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.UpArrow)
                || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
            {

                walking = true;


            }

            else walking = false;

            _anim.SetBool("Walk", walking);

            //crossbow animation
            if (Input.GetMouseButtonDown(0) && isDead == false)
            {
                _anim.SetBool("Crossbow Aim", true);
            }
            else
            {
                _anim.SetBool("Crossbow Aim", false);
            }



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
        if (Input.GetButtonDown("Dash"))
        {
            Vector3 dashVelocity = Vector3.Scale(transform.forward, DashDistance * new Vector3((Mathf.Log(1f / (Time.deltaTime * _body.drag + 1)) / -Time.deltaTime), 0, (Mathf.Log(1f / (Time.deltaTime * _body.drag + 1)) / -Time.deltaTime)));
            _body.AddForce(dashVelocity, ForceMode.VelocityChange);
        }



        //die animation when health gets to zero
        if (_health.getCurrentHealth() <= 0 && isDead == false)
        {
            _anim.Play("Die");
            //_anim.enabled = false;

            isDead = true;

        }
    }


    void FixedUpdate()
    {
        if (_health.getCurrentHealth() > 0)
        {
            _body.MovePosition(_body.position + _inputs * Speed * Time.fixedDeltaTime);
        }

    }
}