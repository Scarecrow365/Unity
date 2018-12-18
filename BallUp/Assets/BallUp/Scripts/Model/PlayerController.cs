using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _sensitive;
    [SerializeField]
    private GameObject _gameOverMenu;
    [SerializeField]
    private float _jumpForce;
    [SerializeField]
    private float _abyss;

    private float _leftlimit;
    private float _rightlimit;
    float PositionX;

    private Rigidbody _rb;

	void Start ()
	{
	    _rb = GetComponent<Rigidbody>();
	}
	
	void Update ()
	{
		Controller();
	    GameOver();
    }

    private void Controller()
    {
        //BoundOfScreen();
        
        PositionX += Input.GetAxis("Mouse X") * _sensitive * Time.deltaTime;
        transform.position = new Vector2(PositionX, transform.position.y);
    }

    //private void BoundOfScreen()
    //{
    //    var zDistance = Camera.main.transform.position.z - transform.position.z;

    //    //Ограничение по левому краю с учётом наклона камеры, при использовании Math.cos
    //    _leftlimit = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 
    //        -zDistance / Mathf.Cos(Camera.main.transform.localEulerAngles.x * Mathf.Deg2Rad))).x;

    //    //Ограничение по правому краю с учётом наклона камеры, при использовании Math.cos
    //    _rightlimit = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0,
    //        -zDistance / Mathf.Cos(Camera.main.transform.localEulerAngles.x * Mathf.Deg2Rad))).x;

    //    //Проверка на нахождение игрока за пределами экрана
    //    if (transform.position.x < _leftlimit)
    //        transform.position = new Vector3(_leftlimit, transform.position.y, transform.position.z);
    //    else if (transform.position.x > _rightlimit)
    //        transform.position = new Vector3(_rightlimit, transform.position.y, transform.position.z);
    //}

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.CompareTag("Platform"))
        {
            SceneManager.instance.IncreaseJumpScore(1);
            SceneManager.instance.JumpVFX(1);
            Jump();
            col.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Coin"))
        {
            SceneManager.instance.IncreaseCoinScore(1);
            SceneManager.instance.CoinVFX(1);
            Destroy(col.gameObject, 0.01f);
        }
    }

    void Jump()
    {
        Vector3 jumpVector = new Vector3(0, _jumpForce, 0);
        _rb.AddForce(jumpVector,ForceMode.Impulse);
    }

    void GameOver()
    {
        if (transform.position.y <= _abyss)
        {
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            _gameOverMenu.SetActive(true);
        }
    }
}
