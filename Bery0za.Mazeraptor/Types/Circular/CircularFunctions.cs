using System;
using System.Collections.Generic;

namespace Bery0za.Mazerator.Types.Circular
{
    public static class CircularFunctions
    {
        private const float PI2 = (float)(Math.PI * 2);

        public static int CellsInRing(int ring, float ratio = 1, int prevRingCount = 0)
        {
            if (ring == 0)
            {
                return 1;
            }

            float circumference = PI2 * ring;

            if (ring == 1)
            {
                return (int)(circumference * ratio);
            }

            int prevCount = prevRingCount == 0 ? CellsInRing(ring - 1, ratio) : prevRingCount;

            if ((circumference * ratio) >= (prevCount * 2))
            {
                prevCount *= 2;
            }

            return prevCount;
        }

        public static (float radius, float angle) CircularPositionToPolar(
            CircularPosition position,
            float ringHeight,
            int cellsInRing)
        {
            return CircularPositionToPolar(position.ring, (float)position.step, ringHeight, cellsInRing);
        }

        public static (float radius, float angle) CircularPositionToPolar(
            float ring,
            float step,
            float ringHeight,
            int cellsInRing)
        {
            return (ring * ringHeight, StepToAngle(step, cellsInRing));
        }

        public static (float x, float y) PolarToCartesian(float radius, float angle)
        {
            return (radius * (float)Math.Cos(angle), radius * (float)Math.Sin(angle));
        }

        public static float StepToAngle(float step, int cellsInRing)
        {
            return PI2 / cellsInRing * step;
        }

        public static float RadToDeg(float radians)
        {
            const float conversion = (float)(180 / Math.PI);

            return radians * conversion;
        }
    }
}