using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerCollision : MonoBehaviour
{
    [SerializeField] float delaytime = 1.5f;
    [SerializeField] float delaytime2 = 2f;
    [SerializeField] ParticleSystem sucessParticle;
    [SerializeField] ParticleSystem collisionParticle;
    [SerializeField] AK.Wwise.Event stopFly;
    [SerializeField] AK.Wwise.Event playAmb;
    [SerializeField] AK.Wwise.Event stopAmb;
    [SerializeField] AK.Wwise.Event explosionSfx;
    [SerializeField] AK.Wwise.Event successSfx;
    public TextMeshProUGUI FlyText;
    public TextMeshProUGUI LandText;
    bool isplaying = false;
    void Start()
    {
        GetComponent<PlayerMovement>().enabled = true;
        playAmb.Post(gameObject);
        isplaying = false;
        StartCoroutine(UIText());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Start":
                Debug.Log(" YOU READY FOR LAUNCH");
                break;
            case "Finish":
                Debug.Log(" SUCCESSFULLY LANDED");  
                Loadingscene2();
                stopsfx();
                break;
            case "Winner":
                Debug.Log("WINNER");
                sucessParticle.Play();
                successSfx.Post(gameObject);
                break;
            default:
                Debug.Log(" YOU CRASHED");
                Timetoreload();
                stopsfx();
                break;
        }
    }

    private void Loadingscene2()
    {
        GetComponent<PlayerMovement>().enabled = false;
        if(!isplaying)
        {
            successSfx.Post(gameObject);
            sucessParticle.Play();
        }
        Invoke("Loadscene2", delaytime2);
    }

    private void Timetoreload()
    {
        
        GetComponent<PlayerMovement>().enabled = false;
        Invoke("Reload", delaytime);
        if(!isplaying)
        {
            isplaying = true;
            explosionSfx.Post(gameObject);
            collisionParticle.Play();
        }
        
    }

    void Reload()
    {
        isplaying = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void Loadscene2()
    {
        isplaying = false;
        
        SceneManager.LoadScene(2);
    }
    void stopsfx()
    {
        stopAmb.Post(gameObject);
        stopFly.Post(gameObject);
        
    }
    IEnumerator UIText()
    {
        FlyText.gameObject.SetActive(true);
        LandText.gameObject.SetActive(false);
        yield return new WaitForSeconds(3);
        FlyText.gameObject.SetActive(false);
        LandText.gameObject.SetActive(true);
        yield return new WaitForSeconds(4);
        LandText.gameObject.SetActive(false);
    }
   
}
