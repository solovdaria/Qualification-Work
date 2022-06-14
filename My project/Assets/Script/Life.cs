using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Life : MonoBehaviour
{

    [SerializeField] AudioSource fallSound;
    [SerializeField] AudioSource deathSound;
    bool dead = false;

    private void Update()
    {
        if (transform.position.y < -1f && !dead)
        {
            //Die();
            //fallSound.Play();
        }
        if (transform.position.y < -5f && !dead)
        {
            Die();
            fallSound.Play();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Body"))
        {
            Die();
            deathSound.Play();
            //collision.gameObject.transform.SetParent(transform);
        }
    }


    void Die()
    {
        //GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<PlayerMovement>().enabled = false;
        //Destroy(gameObject);
        //GetComponent<Camera>().enabled = true;
        //Destroy(collision.transform.parent.gameObject);
        //transform.position = new Vector3(0.0f, 0.0f, 20.0f);
        //transform.Rotate(180.0f, 0.0f, 0.0f);
        Invoke(nameof(ReloadLevel), 0.5f);
        dead = true;
        PlayerMovement.killsCount = 0;
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
