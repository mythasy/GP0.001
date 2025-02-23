using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Enmyandloadmenmenu : MonoBehaviour
{
    [SerializeField] private GameObject _Player;
    [SerializeField] private AudioClip _Sound;
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);


            AudioSource.PlayClipAtPoint(_Sound, Camera.main.transform.position);

        }
        


        

        

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        SceneManager.LoadScene("Menu");
    }




}//class
