
Tools used:
Specflow
Gherkin syntax
C#
Visual studio 2019

I have used Specflow to perform this test as it is a BBD framework that allows you to create feature files to describe tests to carry out clearly.
Easy to read for anyone technical/non technical.
Also has some good powerful features that can allow repeating of same test steps between different tests without duplicating the steps.

Issues/Improvements needed:

Improvements if more time:
 
 1. Intermittant issues with chromedriver exe in framework, sometimes fails the build because the chromedriver.exe was in use 
 and has not been unlocked.

 2. Chromedriver nuget package sometimes not copied to bin folder, even when property
 set to copy to output directory also causing failures.

 3. Write more feature files and create more tests for more intricate tests with variety different test data.

 4. Tidy up code and reduce duplication where possible.

 5. Code to move slider need improvement as a bit slow to find elements each time.

 6. Structure code better in tests with less repeatable code.

 7. Write test to cover last working day and few other scenarios around it.
