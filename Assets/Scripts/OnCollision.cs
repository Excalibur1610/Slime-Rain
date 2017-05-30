using UnityEngine;

public class OnCollision : MonoBehaviour {
    public AudioClip splash;
    AudioSource Audio;

    protected void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag.Equals("bullet"))
        {
            Destroy(col.gameObject);
            if (tag.Equals("slime"))
            {
                GameManager.score += transform.position.z * (-4);
                Destroy(gameObject);
            }
            else
            {
                GameManager.score -= 2;
            }
        } 
    }

    protected void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name.Equals("Ground"))
        {
            Audio = col.GetComponent<AudioSource>();
            if (tag.Equals("slime"))
            {
                Audio.PlayOneShot(splash, 0.5f);
                GameManager.endCounter += (int)(transform.position.z * (-2));
                Destroy(gameObject);
            }
        }
    }
}
