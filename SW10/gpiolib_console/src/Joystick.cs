using System;
using System.Device.Gpio;
using System.Device.Gpio.Drivers;


namespace ASYD_JoystickLeds {
    internal class Joystick {
        // public event EventHandler<JoystickEventArgs> JoystickChanged;

        protected int buttonLeft = 6;
        protected int buttonRight = 5;
        protected int buttonUp = 19;
        protected int buttonDown = 13;
        protected int buttonCenter = 26;

        private static GpioController Ctrl { get { return Program.Ctrl; } }
        private static Joystick joystick = null;

        public static Joystick GetInstance() {
            if( joystick == null ) {
                joystick = new Joystick();
            }
            return joystick;
        }

        private Joystick() {

            if( Ctrl == null )
                throw new Exception( "Constructor Joystick needs access to GpioController object." );

            Console.WriteLine( "in Joystick() - Initializing Pins" );
            Ctrl.OpenPin( buttonLeft, PinMode.Input );
            Ctrl.OpenPin( buttonRight, PinMode.Input );
            Ctrl.OpenPin( buttonUp, PinMode.Input );
            Ctrl.OpenPin( buttonDown, PinMode.Input );
            Ctrl.OpenPin( buttonCenter, PinMode.Input );

        } // end constructor

        public JoystickButtons State {
            get {
                JoystickButtons state = JoystickButtons.None;

                // PinValue v = ctrl.Read( buttonLeft );
                if( Ctrl.Read( buttonLeft ) == false ) state |= JoystickButtons.Left;
                if( Ctrl.Read( buttonRight ) == false ) state |= JoystickButtons.Right;
                if( Ctrl.Read( buttonUp ) == false ) state |= JoystickButtons.Up;
                if( Ctrl.Read( buttonDown ) == false ) state |= JoystickButtons.Down;
                if( Ctrl.Read( buttonCenter ) == false ) state |= JoystickButtons.Center;
                return state;
            }
        } // property State

    } // end class Joystick
}
