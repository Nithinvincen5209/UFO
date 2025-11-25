using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float playerJump;
    [SerializeField] float playerRotation;
    [SerializeField] public AK.Wwise.Bank SoundBank;
    [SerializeField] AK.Wwise.Event flySfx;
    [SerializeField] AK.Wwise.Event stopFly;
    [SerializeField] ParticleSystem jumpParticle;
    [SerializeField] ParticleSystem rightParticle;
    [SerializeField] ParticleSystem leftParticle;
    Rigidbody rb;
    private bool isPlaying;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if(SoundBank != null)
        {
           
            SoundBank.Unload();
            SoundBank.Load();
        }
    }

   
    void FixedUpdate()
    {
        Jump();
        Rotation();
    }
    void Jump()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * playerJump *Time.deltaTime);
            jumpParticle.Play();
            if(!isPlaying)
            {
                flySfx.Post(gameObject);
                isPlaying = true;
            }
        }
        else if(isPlaying)
        {
            stopFly.Post(gameObject);
            isPlaying = false;
        }
    }
    void Rotation()
    {
        if(Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, 0, playerRotation);
            leftParticle.Play();
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 0, -playerRotation);
            rightParticle.Play();
        }
        
    }
    private void OnDisable()
    {
        if(isPlaying)
        {
            stopFly.Post(gameObject);
            isPlaying = false;
        }
    }
}
