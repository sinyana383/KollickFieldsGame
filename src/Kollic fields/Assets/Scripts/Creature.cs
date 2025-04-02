using System.Text.RegularExpressions;
using Unity.VisualScripting;
using UnityEngine;

public class Creature : MonoBehaviour
{
    int hp = 100;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Weapon weapon))
        {
            this.transform.position += new Vector3(0.3f, 0, 0);

            this.hp -= weapon.Dmg;
            Dead();
        }

        void Dead()
        {
            if(this.hp <= 0)
            {
                Destroy(this.gameObject);
            }
        }

    }

}
