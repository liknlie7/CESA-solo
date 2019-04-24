using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class burst : MonoBehaviour
{
    [SerializeField]
    GameObject Circle;

    bool is_action;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!Circle.gameObject.activeSelf && !is_action)
        {
            GetComponent<ParticleSystem>().Play();
            is_action = true;
        }
    }
}
