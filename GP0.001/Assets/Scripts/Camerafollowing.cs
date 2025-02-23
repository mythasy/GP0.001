using UnityEngine;
using UnityEngine.SceneManagement;

public class Camerafollowing : MonoBehaviour
{
    [SerializeField] private float _followSpeed;
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _min, _max;
    [SerializeField] private Vector3 _offset;
    [Range(1, 10)]
    [SerializeField] private float _smoothf = 5f;
    [SerializeField] private float _playerSpeed = 5f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        FixedUpdate();

    }//Update

    private void FixedUpdate()
    {
        Vector3 targetposition = _target.position + _offset;
        Vector3 boundposition = new Vector3(Mathf.Clamp(targetposition.x, _min.x, _max.x),
            Mathf.Clamp(targetposition.y, _min.y, _max.y),
            Mathf.Clamp(targetposition.y, _min.y, _max.y)
           );

        Vector3 _smoothf = Vector3.Lerp(transform.position, targetposition, _followSpeed + _playerSpeed * Time.fixedDeltaTime);
        transform.position = _smoothf;
    }

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("SampleScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");

    }


}
