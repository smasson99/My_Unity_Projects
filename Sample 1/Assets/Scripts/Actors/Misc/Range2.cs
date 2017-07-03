using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Actors.Misc
{
    [Serializable]
    public class Range2
    {
        [Tooltip("Max distance of the right rotation")]
        [SerializeField]
        [Range(-5, 5)]
        private float addMax;
        [Tooltip("Min distance of the left rotation")]
        [SerializeField]
        [Range(-5, 5)]
        private float addMin;
    }
}
