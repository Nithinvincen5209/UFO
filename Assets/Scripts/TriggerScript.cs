using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    [SerializeField] GameObject rock;
    
    
    Rigidbody rb;
    
     void Start()
    {
        
        rock.SetActive(false);
         
    }

    
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            rock.SetActive(true);
            
            
        }
    }
}
