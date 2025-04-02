using UnityEngine;

public class Idol : MonoBehaviour
{
    int toughness = 150;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Weapon weapon))
        {

            this.toughness -= weapon.Dmg;
            Broken();
        }

        void Broken()
        {
            if (this.toughness <= 0)
            {
                Destroy(gameObject);
            }
        }

    }   
   
}
