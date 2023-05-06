using System;
using System.Threading;

namespace ASYD_Demo {
    internal class Program {
        static void Main( string[] args ) {

            if( args.Length >= 1 && args[0] == "--help" ) {
                PrintUsageAndExit();
                return;
            }

            int a = args.Length >= 1 ? Convert.ToInt32( args[0] ) : -1;
            int b = args.Length >= 2 ? Convert.ToInt32( args[1] ) : -1;
            if( a > b ) { (a, b) = (b, a); } // swap so that a < b

            int counter = a >= 0 ? a : 1;
            int to = b >= 0 ? b : int.MaxValue;

            Console.WriteLine( $"Counting from {counter} to {( to == int.MaxValue ? "2^32" : to )}" );

            while( counter <= to ) {
                Console.WriteLine( $"Counter: {counter++}" );
                if( counter <= to )
                    Thread.Sleep( 1000 );
            }
        } // end Main()

        public static void PrintUsageAndExit( int err = 0 ) {
            Console.WriteLine( System.AppDomain.CurrentDomain.FriendlyName + " [[from] to]" );
            Console.WriteLine( "  Counts in 1-second intervals . " +
                "If specified, counts from \"from\" to \"to\" and exists, otherwise from 0 to 2^32." );
            System.Environment.Exit( err );

        } // end Usage()

    } // end Program
} // end namespace

