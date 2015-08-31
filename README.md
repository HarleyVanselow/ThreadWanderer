ThreadWanderer 
Harley Vanselow 2015

The body of code that powers this application resides in ThreadWanderer/Form1.cs
ThreadWanderer uses multithreading to draw many 'Wanderers' concurrently.
Each time the user clicks the generated canvas, a Wanderer thread is generated which meanders the 
canvas, but always stays in bounds. Each Wanderer exists in its own thread, so the user can click in several places
on the canvas to generate several Wanderers at once.

The GDIDrawer library used was developed by engineers at NAIT and can be viewed here: https://github.com/NAIT-CNT/GDIDrawer
