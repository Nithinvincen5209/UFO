using UnityEngine;

public class SpaceshipRotation : MonoBehaviour
{
    [SerializeField] float rotationX;
    [SerializeField] float rotationY;
    [SerializeField] float rotationZ;
    
    private bool canRotate = true;
    
     void Start()
    {
        
    }

    
    void Update()
    {
        if(canRotate)
        {
            Spaceship();
        }
        
        
    }
    void Spaceship()
    {
        
        transform.Rotate(rotationX,rotationY,rotationZ);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            canRotate = false;
        }
        
    }
}
