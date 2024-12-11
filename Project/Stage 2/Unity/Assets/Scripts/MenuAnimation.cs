using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimation : MonoBehaviour
{
    [SerializeField] private GameObject brokenPrefab;

    private bool hasClicked;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !hasClicked)
        {
            hasClicked = true;
            gameObject.GetComponent<MeshRenderer>().enabled = false;

            Instantiate(brokenPrefab, transform);
            
            Destroy(this, 3);
        }
    }
}
