using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disable : MonoBehaviour
{
    
	void Start ()
	{
		Invoke("Off",0.2f);
	}

    void Off()
    {
        Destroy(gameObject);
    }
	
}
