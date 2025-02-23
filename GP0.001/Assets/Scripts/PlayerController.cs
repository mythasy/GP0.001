using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float jumpSpeed = 10f;

    [SerializeField] private ScoreKeeper scoreKeeper;

    private Animator _myAnim;
    private Rigidbody2D _myRigidbody;

    private bool _isJumping = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        _myAnim = GetComponent<Animator>();
        _myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");

        // Move the character
        _myRigidbody.linearVelocity = new Vector2(moveInput * speed, _myRigidbody.linearVelocityY);

        // Check if the character is moving and not jumping
        if (!_isJumping && Mathf.Abs(_myRigidbody.linearVelocityX) > 0.1f)
        {
            _myAnim.SetBool("IsRunning", true);
        }
        else
        {
            _myAnim.SetBool("IsRunning", false);
        }

        // Handle jumping
        if (Input.GetKeyDown(KeyCode.Space) && !_isJumping)
        {
            _isJumping = true;
            _myRigidbody.linearVelocity = new Vector2(_myRigidbody.linearVelocityX, jumpSpeed);
            _myAnim.SetBool("IsJumping", true); // Set the jumping parameter in the Animator
        }

        // Flip the character direction
        if (_myRigidbody?.linearVelocityX > 0.1f)
        {
            transform.localScale = Vector2.one;
        }
        else if (_myRigidbody?.linearVelocityX < -0.1f)
        {
            transform.localScale = new Vector2(-1, 1);
        }
    }

    //Check if player on ground or not
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("On the ground");
            _isJumping = false;
            _myAnim.SetBool("IsJumping", false); // Reset the jumping parameter in the Animator
        }
    }

    //Check if player collide with gold & destroy gold
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Gold"))
        {
            scoreKeeper.IncreaseScore();
            Destroy(collision.gameObject);
        }
    }
}
