
The ideia behind this implementation is bring flexibility for the solution. 

If an algorithm is directly within the class that uses the algorithm is inflexible and stops the class from being reusable.

The solution defines a separate object that encapsulates an algorithm, and classes that implement the interface (algorithm) 
in different ways. At run-time, the context class can choose the algorithm to be executed.

The IProcessorTrip defines the contracts, and ContextProcessor encapsulates the algorithm.

TripProcessor class implements the scenario of the challenge and the class TripProcessorGrouped
implements a new scenario(different input layout) to show the flexibility. At run-time the client class 
can choose what algorithm to use.


