﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene : MonoBehaviour
{
    [SerializeField]
    GameObject circle;

    GameObject distance;

    int time;

    // Start is called before the first frame update
    void Start()
    {
        time = 300;

        distance = GameObject.Find("Distance");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        time--;

        if (!circle.activeSelf)
        {
            distance.GetComponent<Text>().text = "CLEAR!!";

            if (time < 0)
            {
                SceneManager.LoadScene("Stage_2");
            }
        }
    }

}
