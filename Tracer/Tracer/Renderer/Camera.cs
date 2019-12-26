using Math;

namespace Renderer
{
    public class Camera
    {
        public enum RotationMode
        {
            Euler,
            Radian
        }

        public Vector3 Position { get => position; }
        public Vector3 RadianRotation { get => rad_rotation; }
        public Vector3 Rotation { get => rotation; }

        public Vector3 Up { get => up; }
        public Vector3 Right { get => right; }
        public Vector3 Forward { get => forward; }


        private Vector3 position;
        private Vector3 rotation;
        private Vector3 rad_rotation;

        private Vector3 up;
        private Vector3 right;
        private Vector3 forward;

        public Camera(Vector3 position, Vector3 rotation)
        {
            SetPosition(position);
            SetRotation(rotation, RotationMode.Euler);
        }

        public void SetPosition(Vector3 position)
        {
            this.position = position;
        }

        public void SetRotation(Vector3 rotation, RotationMode rotationMode)
        {
            if(rotationMode == RotationMode.Euler)
            {
                this.rotation = rotation;
                rad_rotation = MathService.ToRadian(rotation);
            }
            else
            {
                this.rotation = MathService.ToEuler(rotation);
                rad_rotation = rotation;
            }

            Recalculte();
        }

        private void Recalculte()
        {
            Matrix4x4 rotationMatrix = Matrix4x4.RotationMatrix(rad_rotation);

            up = rotationMatrix.Multiply(Vector3.Up);
            right = rotationMatrix.Multiply(Vector3.Right);
            forward = rotationMatrix.Multiply(Vector3.Forward);
        }
    }
}
