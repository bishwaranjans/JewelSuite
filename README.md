# JewelSuite
JewelSuite is a 3D reservoir modeling application for the Oil & Gas industry. The main functionality of this high
tech application is building 3D reservoir models to calculate volumes of oil and gas. One of the purposes of the application is to calculate the volumes of the oil and gas in place in a certain reservoir zone. In the above simple example model: the volume between the 2 horizons and above the fluid contact.

## JewelSuite Solution Architecture

MVVM with Prism has been used for designing the architecture of the solution by clearly segregating the each responsibility with clear structure.
 - **JewelSuite** : Responsible for holding all the UI component and program entry point. 
 - **JewelSuite.Core** : Contains core logic about the aplication and all the services/utilities which can be used acroos all the modules of the aplication.
 - **JewelSuite.Module** : This module is responsible for managing the key volume calculation functionality. It contains all the UI component through which user can get the oil and gas volumes in major 3 units i.e. CubicFeet, CubicMeter and Barrels.
 - **JewelSuite.UnitTests** : UnitTest project for testing out the VM and core services.
 
