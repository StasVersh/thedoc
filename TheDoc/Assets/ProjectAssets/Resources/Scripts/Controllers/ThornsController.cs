using ProjectAssets.Resources.Doc.Scripts.Utilitys;
using UnityEngine;

public class ThornsController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            EventHandler.ThromsDeth.Invoke();
        }
    }
}
