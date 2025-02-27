using UnityEngine;

public class CollitionDetection : MonoBehaviour
{
    public GameObject Glow1, Beam1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null && collision.gameObject.CompareTag("Mirrordisc"))
        {
            Glow1.SetActive(false);
            Beam1.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject.CompareTag("Mirrordisc"))
        {
            Glow1.SetActive(true);
            Beam1.SetActive(false);
        }
    }
}
