using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts {
    class Angle {
        /** The angle is by default aligned to the x axis as is used in some trig math */
        private float angle;

        public Angle(float initialAngle) {
            angle = initialAngle + 90;
        }

        /** Gets the angle aligned by the x axis */
        public float getAngleXAligned() {
            return ((angle ) % 360f);
        }

        /** Gets the angle aligned by the y axis */
        public float getAngleYAligned() {
            return ((angle - 90) % 360f);
        }

        /** Changes the angle by some amount */
        public void addToAngle(float value) {
            angle += (value % 360f);
        }
    }
}
