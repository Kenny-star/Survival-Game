using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    public GameObject thirdCamera;
    public GameObject firstCamera;
    public GameObject gunVisible;
    public int CanMode;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Camera"))
        {
            if(CanMode == 1)
            {
                CanMode = 0;
            }
            else
            {
                CanMode += 1;
            }
            StartCoroutine(CanChange());
        }
    }
    IEnumerator CanChange()
    {
        yield return new WaitForSeconds(0.01f);
        if(CanMode == 0)
        {
            thirdCamera.SetActive(true);
            firstCamera.SetActive(false);
            gunVisible.SetActive(false);
        }
        if(CanMode == 1)
        {
            gunVisible.SetActive(true);
            firstCamera.SetActive(true);
            thirdCamera.SetActive(false);
        }
    }
}
