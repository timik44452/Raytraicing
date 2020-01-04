using Math;
using System.Drawing;
using System.Windows.Forms;

namespace Tracer.Windows
{
    public class Window : Form
    {
        public bool IsMouseLeft { get => isMouseLeft; }
        public bool IsMouseRight { get => isMouseRight; }
        public bool IsMouseMiddle { get => isMouseMiddle; }

        public Vector2 MouseDelta { get => mouseDelta; }
        public new Vector2 MousePosition { get => mousePosition; }

        private bool isMouseLeft = false;
        private bool isMouseRight = false;
        private bool isMouseMiddle = false;

        private Vector2 mouseDelta = Vector2.zero;
        private Vector2 mousePosition = Vector2.zero;

        public Window()
        {
            Load += (sender, args) => OnLoad();

            KeyDown += (sender, args) => OnKeyDown(args.KeyCode);
            MouseDown += (sender, args) => MouseDownHandler(args.Button);
            MouseUp += (sender, args) => MouseUpHandler(args.Button);
            MouseMove += (sender, args) => MouseMoveHandler(args.Location);

            Timer timer = new Timer();
            timer.Interval = 1;
            timer.Tick += (sender, args) => OnUpdate();
            timer.Start();
        }

        public virtual void OnLoad()
        {

        }

        public virtual void OnUpdate()
        {

        }

        public virtual void OnKeyDown(Keys key)
        {

        }

        public virtual void OnMouseEvent()
        {

        }

        private void MouseDownHandler(MouseButtons mouseButton)
        {
            if (mouseButton == MouseButtons.Left)
                isMouseLeft = true;
            if (mouseButton == MouseButtons.Right)
                isMouseRight = true;
            if (mouseButton == MouseButtons.Middle)
                isMouseMiddle = true;

            OnMouseEvent();
        }

        private void MouseUpHandler(MouseButtons mouseButton)
        {
            if (mouseButton == MouseButtons.Left)
                isMouseLeft = false;
            if (mouseButton == MouseButtons.Right)
                isMouseRight = false;
            if (mouseButton == MouseButtons.Middle)
                isMouseMiddle = false;

            OnMouseEvent();
        }

        private void MouseMoveHandler(Point location)
        {
            mouseDelta = new Vector2(location.X, location.Y) - mousePosition;
            mousePosition.SetXY(location.X, location.Y);

            OnMouseEvent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Window
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.KeyPreview = true;
            this.Name = "Window";
            this.ResumeLayout(false);

        }
    }
}
