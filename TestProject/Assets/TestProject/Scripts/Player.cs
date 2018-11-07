using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameOverLabel;
    [SerializeField]
    private GameObject _finishLabel;

    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Enemy"))
        {
            _gameOverLabel.SetActive(true);
            rend.enabled = false;
            StartCoroutine(Restart());
        }

        if (other.collider.CompareTag("Finish"))
        {
            _finishLabel.SetActive(true);
            rend.enabled = false;
            StartCoroutine(Restart());
        }
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);
    }
}
