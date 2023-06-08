using UnityEngine.SceneManagement;
using UnityEngine;

public class EscExit : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private AudioClip audioFon;
    private void Start() {
        //_audioSource = GetComponent<AudioSource>();
        //_audioSource.PlayOneShot(audioFon);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            SceneManager.LoadScene(1);
        }
    }
}
