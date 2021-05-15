using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Collect : MonoBehaviour
{
    public TextMeshProUGUI countText;
    public Camera fpsCam;

    // Start is called before the first frame update
    void Start()
    {

        SetCountText();

    }

    void SetCountText()
    {
        countText.text = "Ammo: " + Count.getCount().ToString();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            Count.incrementCount();

            SetCountText();
        }
    }
}
