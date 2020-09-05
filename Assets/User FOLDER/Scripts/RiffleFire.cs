using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiffleFire : MonoBehaviour
{
    public Animator animatorOfCharacter;
    public float animationChangeTime;
    public GameObject fireHandler;
    public string type ;

    private void Start()
    {
        //animatorOfCharacter = GetComponent<Animator>();
    }
    public void Fire()
    {
        if(Input.GetMouseButton(0))
        {
            
            if (fireHandler != null)
            {
                animationChangeTime = 1.5f;
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.forward, out hit, 20f))
                {
                    if (hit.collider.CompareTag("Enemy"))
                    {
                        hit.transform.SendMessage("OnTakeDamage");
                    }
                }
            }
        }
    }

    private void Update()
    {

        if (animationChangeTime > 0)
        {
            animationChangeTime -= Time.deltaTime;
           
            animatorOfCharacter.SetBool("Shoot", true);
        }
        if (gameObject.activeSelf == false || animationChangeTime < 0)
        {
            animatorOfCharacter.SetBool("Shoot", false);
        }
       

    }

    private void OnDrawGizmos()
    {
        if (Input.GetMouseButton(0))
        {
            
                Gizmos.color = Color.green;
                Gizmos.DrawRay(fireHandler.transform.position, fireHandler.transform.forward * 10);
        }     
    }
    
}
