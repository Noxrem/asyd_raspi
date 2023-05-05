using System;
using System.Threading;
using System.Device.Gpio;
using System.Device.Gpio.Drivers;

namespace ASYD_JoystickLeds {

    internal class Program {
        public static GpioController Ctrl { get; set; }

        static void Main( string[] args ) {
            Console.WriteLine( "Hello World!" );

            // Set up GPIO

            int gpioBank = 0;
            Console.WriteLine( "in Joystick() - create LibGpiodDriver" );
            LibGpiodDriver libGpiodDriver = new LibGpiodDriver( gpioBank );

            Console.WriteLine( "in Joystick() - create GpioController" );
            GpioController ctrl = new GpioController( PinNumberingScheme.Logical, libGpiodDriver );
            Ctrl = ctrl; // set in public property so joystick and leds can access it

            Thread t = new Thread( Run );
            // Background thread, ends when Main() ends
            t.IsBackground = false;
            t.Start();
            // Program ends, but Run-Thread keeps working
        }
        protected static void Run() {
            Joystick joystick = Joystick.GetInstance();

            Leds leds = Leds.GetInstance();

            JoystickButtons oldState = JoystickButtons.None;
            JoystickButtons newState;
            while( true ) {
                newState = joystick.State;
                if( oldState != newState ) {
                    Console.WriteLine( newState );

                    leds.Set( LedColor.Green, (newState & JoystickButtons.Up) > 0 );
                    leds.Set( LedColor.Yellow, ( newState & JoystickButtons.Down ) > 0 );
                    leds.Set( LedColor.Red, ( newState & JoystickButtons.Left ) > 0 );
                    leds.Set( LedColor.Blue, ( newState & JoystickButtons.Right ) > 0 );
                    oldState = newState;
                }
                Thread.Sleep( 50 );
            }
        } // end Run()
    } // end class Program

} // end namespace
