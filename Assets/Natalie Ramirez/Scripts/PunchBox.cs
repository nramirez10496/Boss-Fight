using UnityEngine;
using System.Collections.Generic;


namespace NatalieRoman
{
    public class PunchBox : MonoBehaviour
    {
        [SerializeField] Collider punchBox;//punch collider ref
        [SerializeField] int damageAmount = 10;//damage per punch
        [SerializeField] float knockbackForce = 5f;// strength

        HashSet<Damageable> hitTargets = new HashSet<Damageable>();

        void Start()
        {
            punchBox.enabled = false;//box disabled at start
        }

        public void EnableBox()
        {
            hitTargets.Clear();//allow hits on new punch
            punchBox.enabled = true;//enable during punch
        }

        public void DisableBox()
        {
            punchBox.enabled = false;//disable after punch
        }

        void OnTriggerEnter(Collider other)
        {
            Damageable target = other.GetComponentInParent<Damageable>();//find Damageable

            //if no damageable or has been hit
            if (target == null || hitTargets.Contains(target))
            {
                return;
            }

            //calc dir from boss to player
            Vector3 direction = target.transform.position - transform.root.position;
            direction.y = 0f;
            direction.Normalize();

            // damage information
            Damage damage = new Damage();
            damage.amount = damageAmount;
            damage.direction = direction;
            damage.knockbackForce = knockbackForce;

            //damaget arget
            if (target.Hit(damage))
            {
                hitTargets.Add(target);
            }
        }
    }
}
