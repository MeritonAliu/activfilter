/*Header
*
*
*
*/
using activfilter.classlib.FilterClass;
using activfilter.classlib.FilterConsole;
using System;

class Programm
{
    public static void Main()
    {
        FilterConsole.MainMenue();

        //Create instances of all non inverting classes
        BandPassFilterNonInverting BPnonINV = new BandPassFilterNonInverting(1592, 0.0000001, 1592, 0.000000001);
        HighPassFilterNonInverting HPnonINV = new HighPassFilterNonInverting(1592, 0.0000001, 1592);
        LowPassFilterNonInverting LPnonINV = new LowPassFilterNonInverting(1592, 1592, 0.0000001);

        //Create instances of all inverting classes
        BandPassFilterInverting BPINV = new BandPassFilterInverting(1592, 0.0000001, 1592, 0.000000001);
        HighPassFilterInverting HPINV = new HighPassFilterInverting(1000, 0.000001, 10000);
        LowPassFilterInverting LPINV = new LowPassFilterInverting(1592, 1592, 0.0000001);

        //create Bode Analyse in a CSV file and on the console
        //LPINV.MaxFreqBodePlot = 10000000000;
        BPINV.runBodePlot();
        BPnonINV.runBodePlot();
        HPINV.runBodePlot();
        HPnonINV.runBodePlot();
        LPnonINV.runBodePlot();
        LPINV.runBodePlot();
       
        //test to show gain and phase at any frequency
        //just change the object and the frequency
        Console.WriteLine(HPnonINV.runGainCalculation(1500));
        Console.WriteLine(HPnonINV.runPhaseCalculation(1500));

        //stops console from closing
        Console.ReadLine();
    }
}
