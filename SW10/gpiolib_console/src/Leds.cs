using System;
using System.Device.Gpio;
using System.Threading;

namespace ASYD_JoystickLeds {
    public class Leds {

        // APROG HAT rev6       // rev7
        int pinLedRed = 21;     // 16
        int pinLedYellow = 20;  // 20
        int pinLedGreen = 16;   // 21
        int pinLedBlue = 12;    // n/A - set to one of the others!

        bool stateLedRed = false; // PinValue.Low 
        bool stateLedYellow = false;
        bool stateLedGreen = false;
        bool stateLedBlue = false;

        private static GpioController Ctrl { get { return Program.Ctrl; } }
        private static Leds leds = null;
        public static Leds GetInstance() {
            if( leds == null ) {
                leds = new Leds();
            }
            return leds;
        }

        private Leds() {

            if( Ctrl == null )
                throw new Exception( "Constructor Leds needs access to GpioController object." );

            // set GPIO to output mode
            Ctrl.OpenPin( pinLedRed, PinMode.Output );
            Ctrl.OpenPin( pinLedYellow, PinMode.Output );
            Ctrl.OpenPin( pinLedGreen, PinMode.Output );
            Ctrl.OpenPin( pinLedBlue, PinMode.Output );

            // breifly flash Leds: switch all Leds on
            Ctrl.Write( pinLedRed, PinValue.High );
            Ctrl.Write( pinLedYellow, PinValue.High );
            Ctrl.Write( pinLedGreen, PinValue.High );
            Ctrl.Write( pinLedBlue, PinValue.High );
            Thread.Sleep( 50 );
            // switch all Leds off
            Ctrl.Write( pinLedRed, PinValue.Low );
            Ctrl.Write( pinLedYellow, PinValue.Low );
            Ctrl.Write( pinLedGreen, PinValue.Low );
            Ctrl.Write( pinLedBlue, PinValue.Low );

        } // end constructor

        public bool Get( LedColor color ) {
            // horrible spaghetti code!help me fix it!;)
            switch( color ) {
                case LedColor.Red:
                    return stateLedRed;
                case LedColor.Yellow:
                    return stateLedYellow;
                case LedColor.Green:
                    return stateLedGreen;
                case LedColor.Blue:
                    return stateLedBlue;
                default:
                    throw new NotImplementedException( "Unknown LedColor " + color );
            }
        }
        public void Set( LedColor color, bool state ) {
            // horrible spaghetti code! help me fix it! ;)
            switch( color ) {
                case LedColor.Red:
                    stateLedRed = state;
                    Ctrl.Write( pinLedRed, (PinValue)stateLedRed );
                    break;
                case LedColor.Yellow:
                    stateLedYellow = state;
                    Ctrl.Write( pinLedYellow, (PinValue)stateLedYellow );
                    break;
                case LedColor.Green:
                    stateLedGreen = state;
                    Ctrl.Write( pinLedGreen, (PinValue)stateLedGreen );
                    break;
                case LedColor.Blue:
                    stateLedBlue = state;
                    Ctrl.Write( pinLedBlue, (PinValue)stateLedBlue );
                    break;
                default:
                    throw new NotImplementedException( "Unknown LedColor " + color );
            }
        } // end Set()


    } // end class Leds
} // end namespace
