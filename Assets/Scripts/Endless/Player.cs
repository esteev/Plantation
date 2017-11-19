using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
namespace endlessMonkey
{
    public class Player : MonoBehaviour
    {

		private Animator animator;
	//	private Rigidbody2D rb;
		public GameObject Base, StartText, ScoreText;
        public float jumpForce = 450f;
		private bool running = false, jumping = false, jumped=false;
		private float max=1.5f, min=-1.3f;
		private float speed = 0.12f;
		private Vector2 direction = Vector2.up;

        void Start()
        {
	//		rb = GetComponent<Rigidbody2D> ();
			animator = transform.GetChild (0).transform.GetChild (0).GetComponent<Animator> ();
            Input.simulateMouseWithTouches = true;
         //   Physics.gravity = 10 * Physics.gravity;
			Time.timeScale = 1.0f;
        }

        void Update()
        {
			ScoreText.GetComponent<Text>().text = KaChow.Instance.scoreEndless.ToString();
            //if (Input.GetMouseButtonDown(0))
			//{
			if(Input.GetKeyDown(KeyCode.Space))
			{
				if (running) {
					animator.SetTrigger ("jump");
						jumping = true;
					//	rb.AddForce(Vector2.up * jumpForce);
						Debug.Log("Jump");
				} else {
					animator.SetBool ("start", true);	
					running = true;
					Base.GetComponent<Spawner> ().enabled = true;
					StartText.SetActive (false);
					ScoreText.SetActive (true);	
				}
            }

			if(Input.GetKeyDown(KeyCode.Escape))
				{
					Application.Quit();
				}

			if (transform.position.y >= max) {
				direction = Vector2.down;
				jumped = true;
			}

			if (transform.position.y <= min) {
				direction = Vector2.up;
				if(jumped)
					jumping = false;
				jumped = false;
			}

			if (jumping) 
			{
				transform.Translate (direction * speed );
			}

			if (Input.GetKeyDown (KeyCode.R)) 
			{
				Time.timeScale = 1.0f;
				SceneManager.LoadScene ("Endless");
			}

        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
			if (collision.collider.CompareTag ("Enemy")) {
				Debug.Log ("GameOver");
				//	Base.GetComponent<Spawner> ().enabled = false;
				Time.timeScale = 0;
			} else if (collision.collider.CompareTag ("Base")) {
		//		rb.velocity = Vector2.zero;
		//		rb.angularVelocity = 0f;
			}
        }
    }
}