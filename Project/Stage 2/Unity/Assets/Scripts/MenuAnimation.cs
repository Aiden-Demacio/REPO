using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Playables;

public class MenuAnimation : MonoBehaviour
{
    [SerializeField] private GameObject brokenPrefab;
    [SerializeField] private PlayableDirector director;
    
    private bool hasClicked;
    // Start is called before the first frame update
    private void Awake()
    {
        //director.Play();
    }

    void Start()
    {
        //director.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !hasClicked)
        {
            director.Play();
            hasClicked = true;
            gameObject.GetComponent<MeshRenderer>().enabled = false;

            Transform t = Instantiate(brokenPrefab, transform.position, quaternion.identity).transform;
            t.transform.rotation = transform.rotation;
            
            Destroy(t.gameObject, 3);
            Destroy(this, 3);
        }
    }
}
