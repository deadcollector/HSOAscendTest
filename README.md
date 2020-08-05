# HSOAscendTest
Steps to run the app.
1- It was written in C#.  You must have Visual Studio 19 to run it. 
2- Download the repo to your favorite directory.
3- Open the HSOAscendTest solution with VS 19
4- Once open, the app should be ready to run.  Just click the Play button to start the Web Service
  You should have a localhost running which opens at https://localhost:44313/api/CSVFormat
5- Open Postman
6- Paste the following into the URL input...

https://localhost:44313/api/csvformat?csv="Patient Name","SSN","Age","Phone Number","Status"
"Prescott, Zeke","542-51-6641",21,"801-555-2134","Opratory=2,PCP=1"
"Goldstein, Bucky","635-45-1254",42,"435-555-1541","Opratory=1,PCP=1"
"Vox, Bono","414-45-1475",51,"801-555-2100","Opratory=3,PCP=2"

Hit Send...

The reformatted csv string will return. 
