using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    private bool walking;
    private Animator _anim;


    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d")
    || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.UpArrow)
    || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            walking = true;
        }

        else walking = false;

        _anim.SetBool("Walk", walking);

        if (Input.GetMouseButtonDown(0))
            {
            _anim.SetBool("Crossbow Aim", true);
            }

    }
}
