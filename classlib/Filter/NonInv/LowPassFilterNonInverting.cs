/* 
 * LowPassFilterNonInverting.cs
 * Activ filter OOP Project
 * BFSU 29.05.2022 
 * Meriton Aliu / Dario Casciato
 * This file contains the child class for the active non inverting low pass filter.
 */
using System;

namespace activfilter.classlib.FilterClass
{
    class LowPassFilterNonInverting : Filter
    {   
        //Properties
        public override double VoltageGain //overrides the VoltageGain methode from the filter class
        {
            get
            { 
                double dblVoltageGain = 1 + (ImpedanceTwo / ResistorOne);
                dblVoltageGain = controlVoltageGain(dblVoltageGain); // control the voltage gain
                return dblVoltageGain; 
            }
        }
        public override double Phaseshift //overrides the Phaseshift methode from the filter class
        {
            get 
            {
                //      in Grad                         PHI OPV                                             //PHI LP = PARALLEL
                return (180 / Math.PI) * Math.Atan( ( -2*Math.PI*Frequency*CapacitorTwo ) / ( (1/ResistorTwo) + Math.Pow(2*Math.PI*Frequency*CapacitorTwo, 2) ) );
                //return dblPhaseshift = (180/Math.PI)* (Math.Atan(ResistorOne/ResistorOne) - Math.Atan((1/ReactanceTwo)*ResistorTwo));
            }
        }
        //Constructors
        public LowPassFilterNonInverting()
        {
            //default constructor, set on random working values
            Frequency = 1000;
            ResistorOne = 1592;
            ResistorTwo = 1592;
            CapacitorTwo = 0.000000001;
            FilterTypeName = "LPnonINV";
            MaxGainFilter = 1 + (ResistorTwo / ResistorOne);
        }
        public LowPassFilterNonInverting(double firstresistor, double secondresistor, double secondcapacitor)
        {
            //specific constructor, set on given working values
            ResistorOne = firstresistor;
            ResistorTwo = secondresistor;
            CapacitorTwo = secondcapacitor;
            FilterTypeName = "LPnonINV";
            MaxGainFilter = 1 + (ResistorTwo / ResistorOne);

        }
    }
}