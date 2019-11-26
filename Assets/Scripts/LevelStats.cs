using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    [System.Serializable]
    public class LevelStats
    {
        [Header("Level Details")]
        [SerializeField]
        [Tooltip("A flavourful name/ description of the level")]
        private string flavourName;
        public string getFlavourName() {
            return flavourName;
        }

        [SerializeField]
        [Tooltip("The starting angle of the ball in unity z rotation (aligned by the y axis)")]
        /** The starting angle of the ball in unity z rotation (aligned by the y axis) */
        private float startingAngle;
        public float getStartingAngle() {
            return startingAngle;
        }

        [Header("Level Targets")]
        [SerializeField]
        [Tooltip("The time to beat the level")]
        /** The time to beat the level */
        private float timeToBeat;
        /** Accessor for time to beat the level */
        public float getTime() {
            return timeToBeat;
        }
        [SerializeField]
        [Tooltip("The number of shots to beat the level in")]
        /** The number of shots to beat the level in */
        private int shotsToBeat;
        /** Accessor for the number of shots to beat the level */
        public int getShots() {
            return shotsToBeat;
        }


    }
}
