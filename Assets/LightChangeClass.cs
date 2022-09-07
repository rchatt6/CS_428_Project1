using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightChangeClass : MonoBehaviour
{
    public GameObject sun;
    public GameObject moon;

    int state = 1;
    // Start is called before the first frame update
    void Start()
    {
        moon.SetActive(false);
        sun.SetActive(true);

        InvokeRepeating("lightchanging", 2f, 6f);
    }

    
    void lightchanging()
    {
        if ((transform.up.y < 0f) && (state == 0))
        {
            moon.active = false;
            sun.active = true;
            state = 1;
        }

        else if ((transform.up.y < 0f) && (state == 1))
        {
            moon.active = true;
            sun.active = false;
            state = 0;
        }
    }

    }
