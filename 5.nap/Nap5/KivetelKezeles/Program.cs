using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;

namespace KivetelKezeles
{

    class Program
    {
        static int BB()
        {
            try
            {
                //return 0;
                Console.WriteLine("Try BB");
                throw new InvalidOperationException();
            }
            catch (StackOverflowException e)
            {
                
                Console.WriteLine("Catch BB");
                //throw new StackOverflowException();               
                //return 0;
            }
            finally
            {
                Console.WriteLine("Finally BB");
                //OutOfMemoryException ome = new OutOfMemoryException();
                //ome.InnerException=
                //throw new OutOfMemoryException();
                //return 0;
            }
            Console.WriteLine("After Finally BB");
            return 0;
        }

        static int AA()
        {
            try
            {
                Console.WriteLine("Try AA");
                BB();
            }
            catch (Exception e)
            {
                // elkapom
                Console.WriteLine("Catch AA");
                //throw e; // re-throw (nem a legjobb)
                // throw; //  ez jobb

                // megegy megoldas:
                Exception sajat = new Exception("sajat exception", e);
                throw sajat;
            }
            finally
            {
                Console.WriteLine("Finaly AA");
            }
            Console.WriteLine("After Finaly AA");
            return 1;
        }

        static void Main(string[] args)
        {

            AppDomain.CurrentDomain.FirstChanceException += new EventHandler<System.Runtime.ExceptionServices.FirstChanceExceptionEventArgs>(CurrentDomain_FirstChanceException);

            try
            {
                AA();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.Source);
                Console.WriteLine(e.TargetSite);
                Console.WriteLine("");
                Console.WriteLine(e.StackTrace);
                Console.WriteLine("");
                if(e.InnerException!=null)
                    Console.WriteLine(e.InnerException.StackTrace);
            }
            finally
            {
                //throw new Exception("");
            }
            










            //try
            //{
            //    // 1
            //    // 2
            //    // 3
            //}
            //catch (OutOfMemoryException e)
            //{

            //}
            //catch (NullReferenceException e)
            //{

            //}
            //catch (Exception e)
            //{
            //    // RuntimeWrappedException
            //    // 1
            //    // 2 ex
            //    // 3 

            //}
            ///*catch // 2.0
            //{

            //}*/
            //finally
            //{
            //    // mindig
            //}
            Console.ReadLine();
        }

        static void CurrentDomain_FirstChanceException(object sender, System.Runtime.ExceptionServices.FirstChanceExceptionEventArgs e)
        {
            // minden catch elott
            Console.WriteLine("exception valtodott ki ");
        }
    }

}









