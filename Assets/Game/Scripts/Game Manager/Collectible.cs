using UnityEngine;

public class Collectible : MonoBehaviour
{
   public int point = 10;

   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.CompareTag("Player"))
      {
         GameManager.Instance.AddScore(point);
         Destroy(gameObject);
      }
   }
}
