using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    [SerializeField]
    GameObject weapon = null;
    [SerializeField]
    GameObject[] weapones;
    public GameObject rightHand;
    Animator anim;
    public GameObject pistol;
    public GameObject riffle;
    public RiffleFire rf;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Weapon"))

        {
            if (other.gameObject.GetComponent<RiffleFire>().type == "Riffle")
            {
                riffle = Instantiate(other.gameObject);
                riffle.SetActive(false);
                Destroy(other.gameObject);

                riffle.transform.SetParent(rightHand.transform);
                riffle.transform.position = rightHand.transform.position;
                riffle.transform.rotation = rightHand.transform.rotation;
            }
            else if (other.gameObject.GetComponent<RiffleFire>().type == "Pistol")
            {
                pistol = Instantiate(other.gameObject);
                pistol.SetActive(false);
                Destroy(other.gameObject);

                pistol.transform.SetParent(rightHand.transform);
                pistol.transform.position = rightHand.transform.position;
                pistol.transform.rotation = rightHand.transform.rotation;
            }

        }      
               
            
    }
    

    private void Update()
    {
        TakeRiffle();
        TakePistol();
        //TakeMili();
        ShootController();
    }

    void TakeRiffle()

    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (riffle != null)
            {
                if (riffle.activeSelf == false)
                {
                    if (pistol != null)
                    {
                        pistol.SetActive(false);
                    }
                    riffle.GetComponent<Collider>().enabled = false;
                    riffle.SetActive(true);
                    anim.SetBool("Riffle", true);
                }

                else
                {
                    riffle.SetActive(false);
                    anim.SetBool("Shoot", false);
                    anim.SetBool("Riffle", false);
                }

            }
        }
    }

    public void TakePistol()
    {

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (pistol != null)
            {
                if (pistol.activeSelf == false)
                {
                    if (riffle != null)
                    {
                        riffle.SetActive(false);
                    }
                    pistol.GetComponent<Collider>().enabled = false;
                    pistol.SetActive(true);
                    anim.SetBool("Pistol", true);
                }

                else
                {
                    pistol.SetActive(false);
                    anim.SetBool("Shoot", false);
                    anim.SetBool("Pistol", false);
                }

            }

        }
        
    }

    //void TakeMili()
    //{
    //    if (Input.GetKeyDown(KeyCode.Alpha3))
    //    {
    //        if (weapones[2] != null)
    //        {
    //            if (weapones[2].activeSelf == false)
    //            {
    //                anim.SetBool("Riffle", true);
    //                for (int i = 0; i < weapones.Length; i++)
    //                {
    //                    if (weapones[i] != null) weapones[i].SetActive(false);

    //                }

    //                weapones[2].GetComponent<Collider>().enabled = false;
    //                weapones[2].SetActive(true);
    //            }

    //            else
    //            {
    //                weapones[2].SetActive(false);
    //                anim.SetBool("Riffle", false);
    //            }

    //        }
    //    }
    //}

    void ShootController()
    {
        if (Input.GetMouseButton(0))
        {
           
                if (pistol != null)
                {
                    if (pistol.activeSelf == true)
                    {
                        pistol.SendMessage("Fire");
                    }
                }

            if (riffle != null)
            {
                if (riffle.activeSelf == true)
                {
                    riffle.SendMessage("Fire");
                }
            }
        }
    }
}
    

