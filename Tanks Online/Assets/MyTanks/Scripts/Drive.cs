using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Drive : NetworkBehaviour
{
    [SerializeField]
    private float _moveSpeed;
    [SerializeField]
    private float _rotSpeed;
    [SerializeField]
    private Rigidbody _bulletPrefab;
    [SerializeField]
    private GameObject _animPrefab;
    [SerializeField]
    private Transform _firePoint;


    private void Update()
    {
        if (!isLocalPlayer)
            return;

        var y = Input.GetAxis("Horizontal") * Time.deltaTime * _rotSpeed;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * _moveSpeed;

        transform.Rotate(0, y, 0);
        transform.Translate(0, 0, z);

        if (Input.GetButtonDown("Fire1"))
            CmdFire();
    }

    [Command]

    private void CmdFire()
    {
        var bullet = Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
        var AnimBullet = Instantiate(_animPrefab, _firePoint.position, _firePoint.rotation);
        bullet.velocity = bullet.transform.forward * 8f;
        NetworkServer.Spawn(bullet.gameObject);
        NetworkServer.Spawn(AnimBullet.gameObject);
    }

    public void Start()
    {
        if (!isLocalPlayer)
            foreach (var r in GetComponentsInChildren<Renderer>())
                r.material.color = Color.red;
        else
            foreach (var r in GetComponentsInChildren<Renderer>())
                r.material.color = Color.green;
    }
}

