## FoodOf Day README

##Example usage
`C:\Source\FoodOfDay> foodofday morning 1, 2, 3`

`eggs, toast, coffee` 

###Overview
FoodOfDay is built using .NET framework 4.5 and C#. The application uses [NUnit](http://nunit.org) to test and verify functionality. By default, the NUnit NuGet package (located at `\packages\NUnit.Runners.2.6.3`) is what the build script calls to run the test suite.

###Build and test instructions
FoodOfDay can be built using the provided DOS- command line script:

**SAMPLE USAGE**

 c:\source\foodofday> buildandtest.cmd 

####Note: 
the script assumes that MSBuild is available in your `%ProgramFiles(x86)%\MSBuild\12.0\Bin\` folder. If that's not the case, you may have to adjust the path in the batch file accordingly.

