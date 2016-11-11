This project is an implementation of the CodeKata Data Munging kata @http://codekata.com/kata/kata04-data-munging/.

Per the instructions, the project contains three disctint 
implementations. The initial Weather Differential problem, 
the second GFGA Differential implementation and an implementation 
that consolodates and encapsultates the shared implementations.

Running the main Kata program will execute this code per the instructions.

This project uses both MSTest and Approval tests (ApprovalTest.net). 

Special attention is due to the approvals files that are normally 
hidden in the project. These files are the reference master passing 
output. Each test run, a new file is generated and compared to the 
reference master. When there is a difference a diff tool is used to 
determine the new reference master. As you might expect, having deltas 
can be advantages in both greenfield and brown field situtations.