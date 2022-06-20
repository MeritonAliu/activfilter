## OOP aktive Filter Projekt
### Auftrag
Sie erstellen in 2er-Gruppen eine Klasse, welche das Verhalten eines aktiven Filters (Tiefpass, Hochpass und/oder Bandpass) simuliert.
Zudem erstellen Sie ein einfaches Programm (Hauptprogramm), um die Funktion ihres Filters zu testen.

### Programm
- Zwei Methoden um das programm zu starten:
  1. In Visual Studio öffnen und durchlaufen lassen.
  2. Per CMD Projektöffnen und dotnet build eingeben, im bin/Debug verzeichniss dann activfilter.exe starten.

- Das Programm erstellt zu allen Filter jeweils eine CSV Datei.
- Insgesamt enthalten sind 6 Filter: BP, HP, TP jeweils invertiert und nicht invertierend.
- Schema der Filter unter /img zu finden.
- Die Mutterklasse, bei /Filter, entählt alle Daten welche alle Filter benutzen können, alle unteren 6 Filterklassen erben von dieser Klasse, zu finden unter Filter/Inv oder Filter/NonInv.
- Verstärkung und Phasengang von OPV wurden mit berechnet.
- Mit Objekt.runBodePlot(); kann eine Simulation vom Amplituden und Phasengang logarithmisch erstellt werden von 1Hz bis 10MHz, ausser MaxFreqBodePlot wird umgestellt.
- Mit Objekt.runGainCalculation(Frequenz); und Objekt.runPhaseCalculation(Frequenz)); können Phase und Amplitude einzeln ausgegeben werden.


### Schemas
<p align="left">
  <img src="img/nonInvSchema.jpg" width="350" height="300" title="NonInvertingFilter">
  <img src="img/InvSchema.jpg" width="350" height="200" title="NonInvertingFilter, Source = https://www.electronics-tutorials.ws/">
</p>

### Benötigtee Nuget Pakete:
CsvHelper 27.2.1  

### Fussnote
- Meriton Aliu & Dario Casciato
- 29.05.2022 / BFSU Uster / HST / M.Maeder
