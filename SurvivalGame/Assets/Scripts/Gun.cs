using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class Gun : MonoBehaviour
{
    public float speed = 0;
    public float damage = 10f;
   

    public float impactForce = 10f;
    public static bool isHit = false;
    public  TextMeshProUGUI countText;
    public TextMeshProUGUI winTextObject;
    public TextMeshProUGUI loseTextObject;

    public Camera fpsCam;
    public ParticleSystem flare;
    public GameObject impactEffect;
    

    void Start()
    {

        SetCountText();
        winTextObject.enabled = false;
        winTextObject.gameObject.SetActive(false);
        loseTextObject.enabled = false;
        loseTextObject.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        if (Enemy.isDestroyed == true && CountDownTimer.getCurrentTimer() > 1)
        {

                
                winTextObject.enabled = true;
                winTextObject.gameObject.SetActive(true);
                Enemy.isDestroyed = false;
                ChasePlayer.lost = false;

        }
        if(ChasePlayer.lost == true || CountDownTimer.getCurrentTimer() <= 0)
        {
                loseTextObject.enabled = true;
                loseTextObject.gameObject.SetActive(true);
                ChasePlayer.lost = false;
                Enemy.isDestroyed = false;
            
        }
    }

    void Shoot()
    {

        RaycastHit hit;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit))
        {
            //Debug.Log(hit.transform.name);
            /*
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                if (hit.transform.name == "EnemyAI")
                {
                    target.TakeDamage(20);

                }
            }
            */
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                if (hit.transform.name == "EnemyAI")
                {

                    if (Count.getCount() > 0)
                    {
                        flare.Play();
                        isHit = true;
                        Count.decrementCount();
                        SetCountText();


                        if (hit.rigidbody != null)
                        {
                            hit.rigidbody.AddForce(hit.normal * impactForce);

                            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));

                            Destroy(impactGO, 2f);
                        }
                    }

                }

            }
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                if (hit.transform.tag == "target")
                {

                    if (Count.getCount() > 0)
                    {
                        flare.Play();
                        Count.decrementCount();
                        SetCountText();


                        if (hit.rigidbody != null)
                        {
                            hit.rigidbody.AddForce(hit.normal * impactForce);

                            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));

                            Destroy(impactGO, 2f);
                        }
                    }

                }

            }

        }
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

    public Gun(bool iH)
    {
        isHit = iH;
    }

    public static void setIsHit(bool iH)
    {
        isHit = iH;
    }
}
