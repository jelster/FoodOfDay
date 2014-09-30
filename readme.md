#README

## FoodOfDay Kata

## Kata definition
1.	You must enter time of day as “morning” or “night” 
2.	You must enter a comma delimited list of dish types with at least one selection
3.	The output must print food in the following order: entrée, side, drink, dessert
4.	There is no dessert for morning meals
5.	Input is not case sensitive
6.	If invalid selection is encountered, display valid selections up to the error, then print error
7.	In the morning, you can order multiple cups of coffee
8.	At night, you can have multiple orders of potatoes
9.	Except for the above rules, you can only order 1 of each dish type


Dishes for Each time of day

Dish Type | morning | night

(entrée)	eggs	steak

(side)	Toast	potato

(drink)	coffee	wine

(dessert)	Not Applicable	cake

###Sample Input and Output:

Input: `morning, 1, 2, 3`  Output: `eggs, toast, coffee`

Input: `morning, 2, 1, 3`
Output: `eggs, toast, coffee`

Input: `morning, 1, 2, 3, 4`
Output: `eggs, toast, coffee, error`

Input: `morning, 1, 2, 3, 3, 3`
Output: `eggs, toast, coffee(x3)`

Input: `night, 1, 2, 3, 4`
Output:  `steak, potato, wine, cake`

Input: `night, 1, 2, 2, 4`
Output `steak, potato(x2), cake`

Input: `night, 1, 2, 3, 5`
Output:  `steak, potato, wine, error`

Input: `night, 1, 1, 2, 3, 5`
Output:  `steak, error`







##Example usage
`C:\Source\FoodOfDay\output> foodofday morning, 1, 2, 3`

`eggs, toast, coffee` 

###Overview
FoodOfDay is built using .NET framework 4.5 and C#. The application uses [NUnit](http://nunit.org) to test and verify functionality. By default, the NUnit NuGet package (located at `\packages\NUnit.Runners.2.6.3`) is what the build script calls to run the test suite.

###Build and test instructions
FoodOfDay can be built using the provided DOS- command line script:

**SAMPLE USAGE**

 c:\source\foodofday> buildandtest.cmd 

###Build artifacts and output
You can find the output of the build process in a folder created by the build, `FoodOfDay\output\`
####Note: 
the script assumes that MSBuild is available in your `%ProgramFiles(x86)%\MSBuild\12.0\Bin\` folder. If that's not the case, you may have to adjust the path in the batch file accordingly.

