using UnityEngine;

public class OnCollision : MonoBehaviour {

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
            if (tag.Equals("slime"))
            {
                GameManager.endCounter += (int)(transform.position.z * (-2));
                Destroy(gameObject);
                GetComponent<AudioSource>().enabled = true;
                GetComponent<AudioSource>().Play();
            }
        }
    }
}
