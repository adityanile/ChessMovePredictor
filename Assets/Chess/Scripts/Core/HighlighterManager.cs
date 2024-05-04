using System.Collections;
using UnityEngine;

public class HighlighterManager : MonoBehaviour
{
    // Disable the sprite initially So that wo don't get a visual glitch
    SpriteRenderer sprite;
    void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        sprite.enabled = false;
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.1f);
        sprite.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            transform.localScale = new Vector3(1, 1, 1);
            sprite.color = Color.red;
        }
        else if(other.gameObject.CompareTag("Limit"))
        {
            // Do Nothing
        }
        // Specially for knight, If there is already our piece then delete the higlighter
        else
        {
            Destroy(gameObject);
        }

    }

}
