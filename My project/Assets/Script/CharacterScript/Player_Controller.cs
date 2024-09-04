using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectH
{
    public class Player_Controller : MonoBehaviour
    {
        private CharacterController controller;
        private Vector3 playerVelocity;
        [SerializeField] private bool groundedPlayer;
        [SerializeField] private float playerSpeed = 2.0f;
        [SerializeField] private float jumpHeight = 1.0f;
        [SerializeField] private float gravityValue = -9.81f;
        [SerializeField] private float sprintSpeed = 5.0f;

        public bool pressShitf;
        public bool canJump;

        private void Start()
        {
            controller = gameObject.AddComponent<CharacterController>();
            pressShitf = false;
            canJump = false;
        }

        void Update()
        {


            groundedPlayer = controller.isGrounded;
            if (groundedPlayer && playerVelocity.y < 0)
            {
                playerVelocity.y = 0f;
            }

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                pressShitf = true;
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                pressShitf = false;
            }
            
            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            controller.Move(move * Time.deltaTime * playerSpeed);

            if (pressShitf == true)
            {
                controller.Move(move * Time.deltaTime * sprintSpeed);
            }


            if (move != Vector3.zero)
            {
                gameObject.transform.forward = move;
            }
            // Changes the height position of the player..
            if (Input.GetButtonDown("Jump") && groundedPlayer && canJump== true)
            {
                playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            }

            playerVelocity.y += gravityValue * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);
        }
    }
}
