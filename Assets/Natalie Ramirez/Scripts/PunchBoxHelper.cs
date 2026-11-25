using UnityEngine;

namespace NatalieRoman
{
    public class PunchBoxHelper : MonoBehaviour
    {
        [SerializeField] PunchBox punchBox;//punch box script ref

        public void EnableBox()
        {
            punchBox.EnableBox();//enable animation event
        }

        public void DisableBox()
        {
            punchBox.DisableBox();//disable animation event
        }
    }
}
