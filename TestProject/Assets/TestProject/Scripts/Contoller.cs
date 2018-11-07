using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contoller : MonoBehaviour
{
    [SerializeField]
    private GameObject _bounds;

    [SerializeField]
    private float _AngleRotation;

	void Update ()
	{
        float _hAxis = Input.GetAxis("Horizontal");
        float _vAxis = Input.GetAxis("Vertical");

        Vector3 eulerAngles = transform.eulerAngles;
	    eulerAngles.x += _vAxis * _AngleRotation;
	    eulerAngles.z += -_hAxis * _AngleRotation;
	    _bounds.transform.eulerAngles = eulerAngles;

    }
}
