using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectH
{
    public class Charactermove : MonoBehaviour
    {
        public float movespeed;

        public Rigidbody rb;
        public Animator animator;

        Vector3 movement;



        
        void Update()
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
           

        } 
        

        void FixedUpdate()
        {
            rb.MovePosition(rb.position + movement * movespeed * Time.fixedDeltaTime);
        }
    }
}
